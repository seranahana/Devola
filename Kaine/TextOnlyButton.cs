using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaine
{
    public class TextOnlyButton : Control
    {
        private StringFormat SF = new StringFormat();
        private bool MouseEntered = false;
        private bool MousePressed = false;
        public TextOnlyButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(100, 20);
            Font = new Font("Verdana", 11F, FontStyle.Regular);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(210, Color.White);
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            Rectangle rectan = new Rectangle(0, 0, Width - 1, Height - 1);
            graph.DrawRectangle(new Pen(BackColor), rectan);
            graph.FillRectangle(new SolidBrush(BackColor), rectan);
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rectan, SF);
            if (MouseEntered)
            {
                graph.DrawString(Text, Font, new SolidBrush(Color.White), rectan, SF);
            }
            if (MousePressed)
            {
                graph.DrawString(Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), rectan, SF);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            Invalidate();
        }
    }
}
