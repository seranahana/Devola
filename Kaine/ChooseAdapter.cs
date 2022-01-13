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
    public partial class ChooseAdapter : ShadowedForm
    {
        public static bool ClosedWithOKButton;
        internal static IReadOnlyList<PcapInterface> Interfaces;
        public ChooseAdapter()
        {
            InitializeComponent();
            Invalidate();
            ClosedWithOKButton = false;
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
            ClosedWithOKButton = true;
            Close();
        }
        private void ChooseAdapter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedWithOKButton)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
        }
        // Border
        private void ChooseAdapter_OnPaint(object sender, PaintEventArgs e)
        {
            // Left side
            Graphics graph = e.Graphics;
            Rectangle rectanleft = new Rectangle(3, 1, 1, Height - 6);
            graph.DrawRectangle(new Pen(Color.FromArgb(50, Color.DarkGray)), rectanleft);
            graph.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Gray)), rectanleft);
            // Bottom
            Rectangle rectanbottom = new Rectangle(3, Height - 5, Width - 7, 1);
            graph.DrawRectangle(new Pen(Color.FromArgb(50, Color.DarkGray)), rectanbottom);
            graph.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Gray)), rectanbottom);
            // Right side
            Rectangle rectanright = new Rectangle(Width - 5, 1, 1, Height - 6);
            graph.DrawRectangle(new Pen(Color.FromArgb(50, Color.Gray)), rectanright);
            graph.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Gray)), rectanright);
        }
    }
}
