using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaine
{
    public partial class SettingsForm : ShadowedForm
    {
        private static readonly List<string> NetworkScaleDictionary = new List<string>() { "Small-scale", "Medium-scale", "Large-scale" };
        public SettingsForm()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                kaineComboBox1.Items.Add(NetworkScaleDictionary[i]);
            }
            switch (StartMenu.PacketsCacheSize)
            {
                case 10:
                    kaineComboBox1.SelectedIndex = 0;
                    break;
                case 40:
                    kaineComboBox1.SelectedIndex = 1;
                    break;
                case 70:
                    kaineComboBox1.SelectedIndex = 2;
                    break;
            }
            for (int i = 1; i < 61; i++)
            {
                kaineComboBox2.Items.Add(i);
            }
            kaineComboBox2.SelectedIndex = StartMenu.CheckEntriesInterval - 1;
            checkBox1.Checked = StartMenu.ApplyStrictCheckRules;
        }

        private void kaineComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (kaineComboBox1.SelectedIndex)
            {
                case 0:
                    StartMenu.PacketsCacheSize = 10;
                    break;
                case 1:
                    StartMenu.PacketsCacheSize = 40;
                    break;
                case 2:
                    StartMenu.PacketsCacheSize = 70;
                    break;
            }
            
        }
        private void kaineComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            StartMenu.CheckEntriesInterval = kaineComboBox2.SelectedIndex + 1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            StartMenu.ApplyStrictCheckRules = checkBox1.Checked;
        }
        // Border
        private void SettingsForm_OnPaint(object sender, PaintEventArgs e)
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
