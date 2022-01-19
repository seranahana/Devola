using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devola
{
    public partial class SettingsForm : ShadowedForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            List<string> NetworkScaleDictionary = new List<string>() { "Small-scale", "Medium-scale", "Large-scale" };
            for (int i = 0; i < 3; i++)
            {
                devolaComboBox1.Items.Add(NetworkScaleDictionary[i]);
            }
            switch (StartMenu.PacketsCacheSize)
            {
                case 10:
                    devolaComboBox1.SelectedIndex = 0;
                    break;
                case 40:
                    devolaComboBox1.SelectedIndex = 1;
                    break;
                case 70:
                    devolaComboBox1.SelectedIndex = 2;
                    break;
            }
            for (int i = 1; i < 61; i++)
            {
                devolaComboBox2.Items.Add(i);
            }
            devolaComboBox2.SelectedIndex = StartMenu.CheckEntriesInterval - 1;
            checkBox1.Checked = StartMenu.ApplyStrictCheckRules;
        }

        private void devolaComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (devolaComboBox1.SelectedIndex)
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
        private void devolaComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            StartMenu.CheckEntriesInterval = devolaComboBox2.SelectedIndex + 1;
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
