using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;

namespace Kaine
{
    public partial class StartMenu : ShadowedForm
    {
        internal static ICaptureDevice captureDevice;
        internal static IReadOnlyList<PcapInterface> Interfaces;
        public static int devIndex { get; set; } = 1;
        internal static bool ProtectionButtonPressed = false;
        private static readonly Dictionary<string, string> ARPEntries = new Dictionary<string, string>();
        private static readonly Queue<ArpPacket> tre = new Queue<ArpPacket>();
        private static Queue<ArpPacket> UtilityQueue = new Queue<ArpPacket>();
        private static readonly Queue<ArpPacket> CapturedPacketsRaw = new Queue<ArpPacket>();
        private static readonly List<string> netshInterfaceList = new List<string>();
        private readonly object lockObjQueue = new object();
        private readonly object lockObjDict = new object();
        public StartMenu()
        {
            InitializeComponent();
            Interfaces = PcapInterface.GetAllPcapInterfaces();
            FormClosed += new FormClosedEventHandler(OnFormClose);
        }

        #region --Event Handlers--
        private void ProtectionButton_Click(object sender, EventArgs e)
        {
            ProtectionButtonPressed = !ProtectionButtonPressed;
            if (ProtectionButtonPressed)
            {
                ChangePBText("Stop Protection");
                tre.Clear();
                UtilityQueue.Clear();
                CapturedPacketsRaw.Clear();
                OutputText("Starting ARP detection module...");
                OutputText("Loading list of device interfaces...");
                CaptureDeviceList devices;
                devices = CaptureDeviceList.Instance;
                if (CaptureDeviceList.Instance.Count == 0 && Interfaces.Count == 0)
                {
                    OutputText("Cannot start module: No network interfaces found!");
                    ChangePBText("Start Protection");
                    ProtectionButtonPressed = !ProtectionButtonPressed;
                    return;
                }
                else
                {
                    ChooseAdapter ChooseAdapterForm = new ChooseAdapter();
                    ChooseAdapterForm.ShowDialog();
                }
                captureDevice = devices[devIndex - 1];
                captureDevice.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival);
                try
                {
                    OutputText("Proceeding with " + Interfaces[devIndex - 1].FriendlyName);
                }
                catch (ArgumentNullException)
                {
                    try
                    {
                        OutputText("Proceeding with " + Interfaces[devIndex - 1].Description);
                    }
                    catch (ArgumentNullException)
                    {
                        OutputText("Proceeding with *Interface Name Unknown*");
                    }
                }
                captureDevice.Open(DeviceModes.Promiscuous);
                try
                {
                    captureDevice.StartCapture();
                }
                catch (Exception ex)
                {
                    OutputText(ex.Message);
                    ChangePBText("Start Protection");
                    ProtectionButtonPressed = !ProtectionButtonPressed;
                    return;
                }
                ARPEntries.Clear();
                Task task = Task.Factory.StartNew(() => CheckEntriesTask());
                OutputText("ARP detection module started succesfully!");
            }
            else
            {
                ChangePBText("Start Protection");
                tre.Clear();
                UtilityQueue.Clear();
                CapturedPacketsRaw.Clear();
                ARPEntries.Clear();
                try
                {
                    captureDevice.StopCapture();
                }
                catch (Exception ex)
                {
                    OutputText("Cannot finish capture: " + ex.Message + "Please, try again.");
                    return;
                }
                captureDevice.Close();
                OutputText("ARP detection module disabled!");
            }
        }

        private void CheckArpCacheButton_Click(object sender, EventArgs e)
        {
            bool CacheObtained = false;
            bool AbnormalitiesFound = false;
            string interfs = "";
            Dictionary<string, string> WindowsARPCache = new Dictionary<string, string>();
            ProcessStartInfo psi = new ProcessStartInfo("arp", "-a");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.StandardOutputEncoding = Encoding.GetEncoding(866);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            string rawOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            while (rawOutput.Length > 1)
            {
                CacheObtained = false;
                try
                {
                    interfs = RetrieveWindowsARPCache(ref rawOutput, ref CacheObtained, ref WindowsARPCache);
                }
                catch (ArgumentNullException)
                {
                    OutputText("Cannot check ARP Cache: Obtaining information failed");
                    return;
                }
                if (!CacheObtained)
                {
                    OutputText("Cannot check ARP Cache: Obtaining information failed");
                    return;
                }
                string cause = "";
                if (CheckMatches(WindowsARPCache, ref cause))
                {
                    OutputText("Duplicate use of " + cause + " found at interface " + interfs + ". Manual disabling of this interface is advised");
                    AbnormalitiesFound = true;
                }
                else
                {
                    OutputText("No abnormalities found at interface " + interfs);
                }
                WindowsARPCache.Clear();
            }
            if (!AbnormalitiesFound)
                OutputText("Checking of Windows ARP Cache spotted no abnormalities");
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
        private void OnPacketArrival (object sender, PacketCapture e)
        {
            if (CapturedPacketsRaw.Count >= 20)
            {
                lock (lockObjQueue)
                {
                    UtilityQueue.Clear();
                    tre.Clear();
                    UtilityQueue = CapturedPacketsRaw;
                    while (tre.Count < 3)
                    {
                        try
                        {
                            tre.Enqueue(UtilityQueue.Dequeue());
                        }
                        catch (ArgumentNullException)
                        {
                            break;
                        }
                    }
                }
                CapturedPacketsRaw.Clear();
                Thread CheckQueueThread = new Thread(CheckQueue);
                CheckQueueThread.Start();
            }
            RawCapture rawCapture = e.GetPacket();
            Packet packet = Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data);
            ArpPacket ARPPack = packet.Extract<ArpPacket>();
            if (ARPPack != null)
            {
                CapturedPacketsRaw.Enqueue(ARPPack);
                if (ARPPack.Operation == ArpOperation.Response)
                {
                    lock (lockObjDict)
                    {
                        if (!ARPEntries.Remove(ARPPack.SenderProtocolAddress.ToString()))
                        {
                            ARPEntries.Add(ARPPack.SenderProtocolAddress.ToString(), ARPPack.SenderHardwareAddress.ToString());
                        }
                    }
                }
            }

        }
        private static void OnFormClose(object sender, EventArgs e)
        {
            if (ProtectionButtonPressed)
            {
                try
                {
                    captureDevice.StopCapture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot finish capture: " + ex.Message + ". Please, try again.", "Error", MessageBoxButtons.OK);
                }
            }
        }
        #endregion

        #region --Check Methods--
        private void CheckQueue()
        {
            lock (lockObjQueue)
            {
                while (UtilityQueue.Count != 0)
                {
                    if (tre.ElementAt(1).SenderHardwareAddress.ToString() == tre.ElementAt(2).SenderHardwareAddress.ToString()
                        && tre.ElementAt(1).TargetHardwareAddress.ToString() == tre.ElementAt(2).TargetHardwareAddress.ToString()
                        && tre.ElementAt(1).Operation == tre.ElementAt(2).Operation
                        && tre.ElementAt(1).Operation == ArpOperation.Response
                        && tre.ElementAt(2).Operation == ArpOperation.Response
                        && tre.ElementAt(0).SenderHardwareAddress.ToString() != tre.ElementAt(1).TargetHardwareAddress.ToString()
                        && tre.ElementAt(0).Operation != ArpOperation.Request)
                    {
                        OutputText("ARP Spoofing signs have been spotted: Multiple responses from " + tre.ElementAt(1).SenderHardwareAddress.ToString() + "detected");
                        SpoofingsSignsFound();
                        return;
                    }
                    tre.Dequeue();
                    tre.Enqueue(UtilityQueue.Dequeue());
                }
            }
        }
        private bool CheckMatches(Dictionary<string, string> cache, ref string cause)
        {
            lock (lockObjDict)
            {
                foreach (var ae in cache)
                {
                    string value = ae.Value;
                    int counter = 0;
                    foreach (var aes in cache)
                    {
                        if (aes.Value == value)
                        {
                            counter++;
                        }
                    }
                    if (counter > 1)
                    {
                        cause = value;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool CheckNetshName(string interfaceName)
        {
            bool netshListObtained = false;
            netshInterfaceList.Clear();
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface show interface");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.StandardOutputEncoding = Encoding.GetEncoding(866);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            string rawOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            try
            {
                RetrieveNetshInterfaceList(rawOutput, ref netshListObtained);
            }
            catch (ArgumentNullException)
            {
                OutputText("Cannot disable interface: Obtaining netsh information failed");
                return false;
            }
            if (!netshListObtained)
            {
                OutputText("Cannot disable interface: Obtaining netsh information failed");
                return false;
            }
            foreach (string ae in netshInterfaceList)
            {
                if (interfaceName == ae)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region --Tasks--
        private void CheckEntriesTask()
        {
            while (ProtectionButtonPressed)
            {
                string cause = "";
                if (CheckMatches(ARPEntries, ref cause))
                {
                    OutputText("ARP Spoofing signs have been spotted: Duplicate use of " + cause + " MAC address detected");
                    SpoofingsSignsFound();
                }
                Task.Delay(15000).Wait();
            }
            ARPEntries.Clear();
        }
        #endregion

        #region --Utilities--
        private void SpoofingsSignsFound()
        {
            MessageBox.Show("Tool has spotted signs of ARP Spoofing. Network interface will be disabled to prevent further damage", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OutputText("Attempting to disable network interface " + Interfaces[devIndex - 1].FriendlyName);
            try
            {
                Task task = Task.Factory.StartNew(() => DisableInterface(Interfaces[devIndex - 1].FriendlyName));
            }
            catch (Exception e)
            {
                OutputText("Cannot disable interface: " + e.Message + ". Manual disabling advised");
            }
            ChangePBText("Start Protection");
            ProtectionButtonPressed = !ProtectionButtonPressed;
            UtilityQueue.Clear();
            CapturedPacketsRaw.Clear();
            try
            {
                captureDevice.StopCapture();
            }
            catch (Exception ex)
            {
                OutputText("Cannot finish capture: " + ex.Message);
                return;
            }
            captureDevice.Close();
            OutputText("ARP detection module disabled!");
        }
        private void DisableInterface (string interfaceName)
        {
            bool intNameExistsInNetsh = CheckNetshName(interfaceName);
            if (intNameExistsInNetsh)
            {
                ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                Process p = new Process();
                p.StartInfo = psi;
                p.Start();
                OutputText("Network interface " + interfaceName + " has been disabled. Take action and re-enable it from control panel or command prompt");
            }
            else
            {
                OutputText("Cannot disable interface: No such interface name found in netsh. Manual disabling advised");
            }
        }
        private string RetrieveWindowsARPCache(ref string rawOutput, ref bool CacheObtained, ref Dictionary<string, string> WindowsARPCache)
        {
            string interfs = "";
            int strings = 0;
            char[] trimchars = { '\r', '\n' };
            rawOutput = rawOutput.TrimEnd(trimchars);
            for (int i = 0; i < rawOutput.Length; i++)
            {
                if (rawOutput[i] == '\n')
                    strings++;
            }
            rawOutput = rawOutput.Substring(rawOutput.IndexOf('\n') + 1);
            while (rawOutput[0] != '\r' && rawOutput[1] != '\n')
            {
                string line = "";
                foreach (char sym in rawOutput)
                {
                    line = line.Insert(line.Length, sym.ToString());
                    if (sym == '\n')
                    {
                        break;
                    }
                }
                rawOutput = rawOutput.Substring(line.Length);
                line = line.TrimEnd(trimchars);
                if (line.Contains("---"))
                {
                    interfs = line.Substring(line.IndexOf(' ') + 1);
                    int indx = interfs.IndexOf(' ');
                    interfs = interfs.Remove(indx, interfs.Length - indx);
                }
                else
                {
                    if (line.Contains('.') && line.Contains('-'))
                    {
                        line = line.Substring(line.IndexOf(' ') + 2);
                        int indx = line.IndexOf(' ');
                        string ipstring = line.Remove(indx, line.Length - indx);
                        string macstring = line.Substring(line.IndexOf('-') - 2);
                        macstring = macstring.Remove(17, macstring.Length - 17);
                        if (macstring != "ff-ff-ff-ff-ff-ff")
                            WindowsARPCache.Add(ipstring, macstring);
                    }
                }
                if(rawOutput.Length < 2)
                {
                    break;
                }
            }
            CacheObtained = true;
            return interfs;
        }
        private void RetrieveNetshInterfaceList(string raw, ref bool netshListObtained)
        {
            int strings = 0;
            for (int i = 0; i < raw.Length; i++)
            {
                if (raw[i] == '\n')
                    strings++;
            }
            for (int i = 0; i < 3; i++)
            {
                raw = raw.Substring(raw.IndexOf('\n') + 1);
            }
            char[] trimchars = { '\r', '\n' };
            raw = raw.TrimEnd(trimchars);
            for (int i = 0; i < strings - 4; i++)
            {
                try
                {
                    string line = raw.Substring(raw.LastIndexOf('\n') + 1);
                    int n = raw.IndexOf(line);
                    raw = raw.Remove(n, line.Length);
                    line = line.Substring(line.LastIndexOf("       ") + 7);
                    raw = raw.TrimEnd(trimchars);
                    netshInterfaceList.Add(line);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            netshListObtained = true;
        }
        private void OutputText (string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(OutputTextUtility), text);
            }
            else
            {
                OutputTextUtility(text);
            }
        }
        private void OutputTextUtility(string text)
        {
            DateTime datetime = DateTime.Now;
            string time = datetime.TimeOfDay.ToString();
            time = time.Remove(7, 8);
            richTextBox1.Text += time + " " + text + Environment.NewLine;
        }
        private void ChangePBText(string text)
        {
            if (ProtectionButton.InvokeRequired)
            {
                ProtectionButton.Invoke(new Action<string>(ChangePBTextUtility), text);
            }
            else
            {
                ChangePBTextUtility(text);
            }
        }
        private void ChangePBTextUtility (string text)
        {
            ProtectionButton.Text = text;
        }
        #endregion
    }
}
