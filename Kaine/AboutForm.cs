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
        // Border
        private void AboutForm_OnPaint(object sender, PaintEventArgs e)
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
