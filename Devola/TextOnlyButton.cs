using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devola
{
    public class TextOnlyButton : Control
    {
        private StringFormat SF = new StringFormat();
        public bool MouseEntered = false;
        public bool MousePressed = false;
        private Color BaseColor = Color.Black;
        private Color EnterColor = Color.FromArgb(70, 90, 90, 90);
        private SizeF TextSize;
        public bool isProtectionButton = false;
        public TextOnlyButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(100, 20);
            Font = new Font("Verdana", 11F, FontStyle.Regular);
            BackColor = Color.Black;
            ForeColor = Color.FromArgb(210, Color.White);
            SF.Alignment = StringAlignment.Near;
            SF.LineAlignment = StringAlignment.Center;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            TextSize = graph.MeasureString(Text, Font);
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            Rectangle rectan = new Rectangle(0, 0, Width - 1, Height - 1);
            graph.DrawRectangle(new Pen(BackColor), rectan);
            graph.FillRectangle(new SolidBrush(BackColor), rectan);
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rectan, SF);
            if (MouseEntered)
            {
                graph.DrawString(Text, Font, new SolidBrush(Color.White), rectan, SF);
                Rectangle rectang = new Rectangle(1, Height - 3, (int)TextSize.Width - 2, 2);
                graph.DrawRectangle(new Pen(Color.FromArgb(150, 255, 0, 255)), rectang);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(200, 255, 0, 255)), rectang);
            }
            if (MousePressed)
            {
                graph.DrawString(Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), rectan, SF);
                Rectangle rectang = new Rectangle(1, Height - 3, (int)TextSize.Width - 2, 2);
                graph.DrawRectangle(new Pen(Color.FromArgb(200, 255, 0, 255)), rectang);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(250, 255, 0, 255)), rectang);
            }
            if (isProtectionButton)
            {
                if (StartMenu.ProtectionButtonPressed)
                {
                    Rectangle rectang = new Rectangle(1, Height - 3, (int)TextSize.Width - 2, 2);
                    graph.DrawRectangle(new Pen(Color.FromArgb(200, 255, 0, 255)), rectang);
                    graph.FillRectangle(new SolidBrush(Color.FromArgb(250, 255, 0, 255)), rectang);
                    Text = "Stop Protection";
                }
                else
                {
                    Text = "Start Protection";
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            BackColor = EnterColor;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            BackColor = BaseColor;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            BackColor = BaseColor;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            BackColor = EnterColor;
            Invalidate();
        }
    }
}
