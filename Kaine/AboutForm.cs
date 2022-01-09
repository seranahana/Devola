using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kaine
{
    public partial class AboutForm : ShadowedForm
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(OnFormLoad);
            this.Resize += new EventHandler(OnFormResize);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"https://t.me/seranahana";
            Process.Start(path);
            linkLabel1.LinkVisited = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"https://github.com/seranahana";
            Process.Start(path);
            linkLabel2.LinkVisited = true;
        }
        private void OnFormLoad (object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            Region rgn = new Region(path);
            pictureBox1.Region = rgn;
            pictureBox1.BackColor = SystemColors.ActiveCaption;
        }
        private void OnFormResize (object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            Region rgn = new Region(path);
            pictureBox1.Region = rgn;
            pictureBox1.BackColor = SystemColors.ActiveCaption;
        }
    }
}
