using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;

namespace Kaine
{
    public partial class ChooseAdapter : Form
    {
        internal static IReadOnlyList<PcapInterface> Interfaces;
        public ChooseAdapter()
        {
            InitializeComponent();
            Interfaces = PcapInterface.GetAllPcapInterfaces();
            for (int i = 0; i < Interfaces.Count; i++)
            {
                try
                {
                    kaineComboBox1.Items.Add(Interfaces[i].FriendlyName);
                }
                catch (ArgumentNullException)
                {
                    try
                    {
                        kaineComboBox1.Items.Add(Interfaces[i].Description);
                    }
                    catch (ArgumentNullException)
                    {
                        kaineComboBox1.Items.Add("*Interface Name Unknown*");
                    }
                }
            }
            kaineComboBox1.SelectedIndex = StartMenu.devIndex - 1;
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            StartMenu.devIndex = kaineComboBox1.SelectedIndex + 1;
            Close();
        }
    }
}
