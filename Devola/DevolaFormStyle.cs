using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Devola
{
    public partial class DevolaFormStyle : Component
    {
        #region -- Свойства --
        public Form Form { get; set; }
        private fStyle formStyle = fStyle.Telegram;
        public fStyle FormStyle
        {
            get => formStyle;
            set
            {
                formStyle = value;
                ApplyStyle();
            }
        }
        public enum fStyle
        {
            Telegram
        }
        [Description("Указывает, может ли пользователь изменять размер окна")]
        public bool AllowUserResize { get; set; }
        [Description("Ширина кнопок меню окна")]
        public int ControlBoxButtonsWidth { get; set; } = 24;
        [Description("Высота шапки (заголовка)")]
        public int HeaderHeight { get; set; } = 20;
        [Description("Цвет шапки (заголовка)")]
        public Color HeaderColor { get; set; } = Color.Black;
        [Description("Шрифт текста шапки (заголовка)")]
        public Font HeaderTextFont { get; set; } = new Font("Segoe UI", 9F, FontStyle.Bold);

        [Description("Цвет текста шапки (заголовка)")]
        public Color HeaderTextColor { get; set; } = Color.White;

        public Image HeaderImage { get; set; }

        [Description("Фоновый цвет формы")]
        public Color BackColor { get; set; } = Color.Black;
        [Description("Горизонтальное выравнивание текста шапки (заголовка)")]
        public StringAlignment HeaderHorizontalAlignment { get; set; } = StringAlignment.Center;
        [Description("Вертикальное выравнивание текста шапки (заголовка)")]
        public StringAlignment HeaderVerticalAlignment { get; set; } = StringAlignment.Center;
        [Description("Включает или выключает отображение кнопки 'Развернуть'")]
        public bool ShowMaximizeButton { get; set; } = true;
        [Description("Включает или выключает отображение кнопки 'Свернуть'")]
        public bool ShowMinimizeButton { get; set; } = true;
        #endregion

        #region -- Поля --

        private Size IconSize = new Size(14, 14); // Размер икноки формы
        private Rectangle rectIcon = new Rectangle(); // Структура иконки формы
        private bool IconHovered = false; // Наведен ли курсор на иконку

        private StringFormat SF = new StringFormat();

        private bool MousePressed = false; // Кнопка мыши нажата
        private Point clickPosition; // Начальная позиция курсора в момент клика
        private Point moveStartPosition; // Начальная позиция формы в момент клика
        private bool CanDragForm = false; // Указывает может ли форма перетаскивается

        private MouseButtons LastClickedMouseButton; // Какая кнопка мыши была нажата последний раз

        private Size ControlBoxIconSize = new Size(8, 8); // Размер иконок меню окна

        private Rectangle rectBtnClose = new Rectangle(); // Структура кнопки меню окна Закрыть
        private Rectangle rectBtnMax = new Rectangle(); // Структура кнопки меню окна Развернуть/Свернуть в окно
        private Rectangle rectBtnMin = new Rectangle(); // Структура кнопки меню окна Свернуть

        private bool btnCloseHovered = false; // Наведен ли курсор на кнопку Закрыть
        private bool btnMaximizeHovered = false; // Наведен ли курсор на кнопку Развернуть/Свернуть в окно
        private bool btnMinimizeHovered = false; // Наведен ли курсор на кнопку Свернуть

        private Pen penBtnClose = new Pen(Color.White, 1.55F); // Кисть для кнопки Закрыть
        private Pen penBtnMaximize = new Pen(Color.DarkGray, 1.55F); // Кисть для кнопки Развернуть/Свернуть в окно
        private Pen penBtnMinimize = new Pen(Color.Gray, 1.55F); // Кисть для кнопки Свернуть

        private Rectangle rectHeader = new Rectangle(); // Структура заголовка формы
        private Rectangle rectBorder = new Rectangle(); // Структура обводки

        private int ResizeBorderSize = 4; // Размер невидимой границы при наведении на которую меняется курсор, чтобы изменять размер формы
        private int ResizeAngleBorderOffset = 15; // Смещение от углов, где мы трактуем угловую часть для изменения размера по углам
        private bool IsResizing = false; // Режим изменения размера

        private BorderHoverPositionEnum BorderHoverPosition = BorderHoverPositionEnum.None; // Куда наведен курсор в отношении обводки для изменения формы
        enum BorderHoverPositionEnum
        {
            None, // Не наведен
            Left, Top, Right, Bottom, // Стороны
            TopLeft, TopRight, BottomLeft, BottomRight // Углы
        }

        private int ResizeStartRight = 0;
        private int ResizeStartBottom = 0;

        // Указывает, нужно ли восстановить позицию окна,
        // которая была, перед разворачиванием на весь экран (Maximize), с помощью перетаскивания окна вверх экана
        private bool FormNeedReposition = false;

        #endregion
        public DevolaFormStyle()
        {
            InitializeComponent();
        }

        public DevolaFormStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void ApplyStyle()
        {
            if (Form != null)
            {
                Form.HandleCreated += Form_HandleCreated;
                if (Form.IsHandleCreated)
                {
                    SetStyle();
                    Form.Refresh();
                }
            }
        }
        public void SetStyle()
        {
            Form.FormBorderStyle = FormBorderStyle.None;
            FormWindowState formWindowStateTEMP = Form.WindowState;
            Form.WindowState = FormWindowState.Normal;
            OffsetControls(-HeaderHeight);
            Form.Height -= HeaderHeight;

            Form.BackColor = BackColor;

            OffsetControls(HeaderHeight);

            Form.Height += HeaderHeight;
            Form.Refresh();

            Form.WindowState = formWindowStateTEMP;

            SF.Alignment = HeaderHorizontalAlignment;
            SF.LineAlignment = HeaderVerticalAlignment;
            Size minimumSize = new Size(100, 50);
            if (Form.MinimumSize.Width < minimumSize.Width || Form.MinimumSize.Height < minimumSize.Height)
            {
                Form.MinimumSize = minimumSize;
            }
            SetDoubleBuffered(Form);

            Form.Paint += Form_Paint;
            Form.MouseDown += Form_MouseDown;
            Form.MouseUp += Form_MouseUp;
            Form.MouseMove += Form_MouseMove;
            Form.MouseLeave += Form_MouseLeave;
            Form.SizeChanged += Form_SizeChanged;
            Form.DoubleClick += Form_DoubleClick;
            Form.Click += Form_Click;
        }
        /// <param name="offsett"></param>
        private void OffsetControls(int offsett)
        {
            foreach (Control ctrl in Form.Controls)
            {
                ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + offsett);
                ctrl.Refresh();
            }
        }

        #region -- Form Events --

        private void Form_HandleCreated(object sender, EventArgs e)
        {
            SetStyle();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawStyle(e.Graphics);
        }

        private void Form_SizeChanged(object sender, EventArgs e)
        {
            Form.Refresh();
        }

        private void Form_MouseLeave(object sender, EventArgs e)
        {
            btnCloseHovered = false;
            btnMaximizeHovered = false;
            btnMinimizeHovered = false;
            Form.Invalidate();
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {

            // Dragging
            if (CanDragForm && e.Button == MouseButtons.Left)
            {
                if (Form.WindowState == FormWindowState.Maximized)
                {
                    float maxWidth = Form.Width;
                    float cursosOnMaxPosition = e.X;
                    float coeff = cursosOnMaxPosition / (maxWidth / 100f) / 100f;

                    // Change WindowState if is Maximized
                    Form.WindowState = FormWindowState.Normal;

                    int XFormOffset = (int)(Form.Width * coeff);

                    Form.Location = new Point(Cursor.Position.X - XFormOffset, Cursor.Position.Y - HeaderHeight / 2);
                    moveStartPosition = Form.Location;
                    clickPosition = Cursor.Position;
                }
                else
                {
                    // Moving
                    Size frmOffset = new Size(Point.Subtract(Cursor.Position, new Size(clickPosition)));
                    Form.Location = Point.Add(moveStartPosition, frmOffset);
                }
            }
            // Hovering
            else
            {
                // Close Button Hovering
                if (rectBtnClose.Contains(e.Location))
                {
                    if (btnCloseHovered == false)
                    {
                        btnCloseHovered = true;
                    }
                }
                else
                {
                    if (btnCloseHovered == true)
                    {
                        btnCloseHovered = false;
                        Form.Invalidate();
                    }
                }

                // Maximize Button Hovering
                if (rectBtnMax.Contains(e.Location))
                {
                    if (btnMaximizeHovered == false)
                    {
                        btnMaximizeHovered = true;
                    }
                }
                else
                {
                    if (btnMaximizeHovered)
                    {
                        btnMaximizeHovered = false;
                        Form.Invalidate();
                    }
                }

                // Minimize Button Hovering
                if (rectBtnMin.Contains(e.Location))
                {
                    if (btnMinimizeHovered == false)
                    {
                        btnMinimizeHovered = true;
                    }
                }
                else
                {
                    if (btnMinimizeHovered)
                    {
                        btnMinimizeHovered = false;
                        Form.Invalidate();
                    }
                }

                // Icon Hovering
                if (rectIcon.Contains(e.Location))
                {
                    IconHovered = true;
                }
                else
                {
                    IconHovered = false;
                }
            }

            // On hover on border for resize
            if (AllowUserResize && IsResizing == false && Form.WindowState == FormWindowState.Normal)
            {
                if (rectBorder.Top + ResizeBorderSize >= e.Location.Y)
                {
                    // Левый верхний угол
                    if (e.Location.X <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.TopLeft;
                    }
                    // Правый верхний угол
                    else if (e.Location.X >= rectBorder.Width - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.TopRight;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeNS;
                        BorderHoverPosition = BorderHoverPositionEnum.Top;
                    }
                }
                else if (rectBorder.Bottom - ResizeBorderSize <= e.Location.Y)
                {
                    // Левый нижний угол
                    if (e.Location.X <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomLeft;
                    }
                    // Правый нижний угол
                    else if (e.Location.X >= rectBorder.Width - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomRight;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeNS;
                        BorderHoverPosition = BorderHoverPositionEnum.Bottom;
                    }
                }
                else if (rectBorder.Left + ResizeBorderSize >= e.Location.X)
                {
                    // Левый верхний угол
                    if (e.Location.Y <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.TopLeft;
                    }
                    // Левый нижний угол
                    else if (e.Location.Y >= rectBorder.Height - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomLeft;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeWE;
                        BorderHoverPosition = BorderHoverPositionEnum.Left;
                    }
                }
                else if (rectBorder.Right - ResizeBorderSize <= e.Location.X)
                {
                    // Правый верхний угол
                    if (e.Location.Y <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.TopRight;
                    }
                    // Правый нижний угол
                    else if (e.Location.Y >= rectBorder.Height - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomRight;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeWE;
                        BorderHoverPosition = BorderHoverPositionEnum.Right;
                    }
                }
                else if (Form.Cursor != Cursors.Default)
                {
                    Form.Cursor = Cursors.Default;
                    BorderHoverPosition = BorderHoverPositionEnum.None;
                }
            }
            // Resize
            else if (AllowUserResize && IsResizing && Form.WindowState == FormWindowState.Normal)
            {
                // Resize
                switch (BorderHoverPosition)
                {
                    // Стороны / Sides
                    case BorderHoverPositionEnum.Left:
                        Form.Location = new Point(Cursor.Position.X, Form.Location.Y);
                        Form.Width = Form.Width - (Form.Right - ResizeStartRight);
                        break;

                    case BorderHoverPositionEnum.Top:
                        Form.Location = new Point(Form.Location.X, Cursor.Position.Y);
                        Form.Height = Form.Height - (Form.Bottom - ResizeStartBottom);
                        break;

                    case BorderHoverPositionEnum.Right:
                        Form.Width = Cursor.Position.X - Form.Left;
                        break;

                    case BorderHoverPositionEnum.Bottom:
                        Form.Height = Cursor.Position.Y - Form.Top;
                        break;


                    // Углы / Angles
                    case BorderHoverPositionEnum.TopLeft:
                        Form.Location = new Point(Form.Location.X, Cursor.Position.Y);
                        Form.Height = Form.Height - (Form.Bottom - ResizeStartBottom);

                        Form.Location = new Point(Cursor.Position.X, Form.Location.Y);
                        Form.Width = Form.Width - (Form.Right - ResizeStartRight);
                        break;

                    case BorderHoverPositionEnum.TopRight:
                        Form.Location = new Point(Form.Location.X, Cursor.Position.Y);
                        Form.Height = Form.Height - (Form.Bottom - ResizeStartBottom);

                        Form.Width = Cursor.Position.X - Form.Left;
                        break;

                    case BorderHoverPositionEnum.BottomLeft:
                        Form.Height = Cursor.Position.Y - Form.Top;

                        Form.Location = new Point(Cursor.Position.X, Form.Location.Y);
                        Form.Width = Form.Width - (Form.Right - ResizeStartRight);
                        break;

                    case BorderHoverPositionEnum.BottomRight:
                        Form.Height = Cursor.Position.Y - Form.Top;
                        Form.Width = Cursor.Position.X - Form.Left;
                        break;


                }
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (Form.IsHandleCreated == false) return;

            MousePressed = false;
            CanDragForm = false;
            IsResizing = false;

            if (AllowUserResize && BorderHoverPosition != BorderHoverPositionEnum.None)
                return;

            // Если окно поднять вверх -> разворачиваем на весь экран
            if (Cursor.Position.Y == Screen.FromHandle(Form.Handle).WorkingArea.Y
                && Form.WindowState == FormWindowState.Normal)
            {
                Form.WindowState = FormWindowState.Maximized;
                FormNeedReposition = true;
            }

            // Огранечение по Y
            if (Form.Location.Y < Screen.FromHandle(Form.Handle).WorkingArea.Y)
            {
                Form.Location = new Point(Form.Location.X, Screen.FromHandle(Form.Handle).WorkingArea.Y);
            }

            // Нажатия на кнопки управления окном
            if (e.Button == MouseButtons.Left && Form.ControlBox == true)
            {
                // Close Button Click
                if (rectBtnClose.Contains(e.Location))
                    Form.Close();

                // Max Button Click
                if (rectBtnMax.Contains(e.Location) && Form.MaximizeBox == true)
                {
                    if (Form.WindowState == FormWindowState.Maximized)
                    {
                        Form.WindowState = FormWindowState.Normal;

                        if (FormNeedReposition)
                        {
                            FormNeedReposition = false;
                            Form.Location = moveStartPosition;
                        }
                    }
                    else if (Form.WindowState == FormWindowState.Normal)
                    {
                        Form.WindowState = FormWindowState.Maximized;
                    }
                }

                // Min Button Click
                if (rectBtnMin.Contains(e.Location) && Form.MinimizeBox == true)
                    Form.WindowState = FormWindowState.Minimized;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            MousePressed = true;

            if (AllowUserResize && BorderHoverPosition != BorderHoverPositionEnum.None)
            {
                if (e.Button == MouseButtons.Left)
                {
                    IsResizing = true;
                    ResizeStartRight = Form.Right;
                    ResizeStartBottom = Form.Bottom;
                    return;
                }
            }

            if (e.Location.Y <= HeaderHeight
                && !rectBtnClose.Contains(e.Location)
                && !rectBtnMax.Contains(e.Location)
                && !rectBtnMin.Contains(e.Location))
            {
                CanDragForm = true;
                clickPosition = Cursor.Position;
                moveStartPosition = Form.Location;
            }

            LastClickedMouseButton = e.Button;
        }

        private void Form_DoubleClick(object sender, EventArgs e)
        {
            if (BorderHoverPosition != BorderHoverPositionEnum.None || AllowUserResize == false)
                return;

            if (MousePressed && LastClickedMouseButton == MouseButtons.Left && rectHeader.Contains(Form.PointToClient(Cursor.Position)))
            {
                if (Form.WindowState == FormWindowState.Maximized)
                {
                    Form.WindowState = FormWindowState.Normal;
                }
                else if (Form.WindowState == FormWindowState.Normal)
                {
                    Form.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void Form_Click(object sender, EventArgs e)
        {
            Form.Focus();
        }
        #endregion

        #region -- Отрисовка --
        private void DrawStyle(Graphics graph)
        {
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if (HeaderHeight == 0) return;

            // Header Structure
            rectHeader = new Rectangle(0, 0, Form.Width - 1, HeaderHeight);

            // Border Structure
            rectBorder = new Rectangle(0, 0, Form.Width - 1, Form.Height - 1);

            // Icon Structure
            rectIcon = new Rectangle(
                rectHeader.Height / 2 - IconSize.Width / 2,
                rectHeader.Height / 2 - IconSize.Height / 2,
                IconSize.Width, IconSize.Height
                );

            // Title Structure
            Rectangle rectTitleText = new Rectangle(Form.ShowIcon ? rectIcon.Right + 5 : rectIcon.Left, rectHeader.Y, rectHeader.Width, rectHeader.Height);

            // Title Image Structure
            Rectangle rectHeaderImage = new Rectangle();
            if (HeaderImage != null)
            {
                int imageHeight = (int)(HeaderHeight * 0.9f); // Высота картинки = 90% от высоты шапки
                int imageWidth = HeaderImage.Width / (HeaderImage.Height / imageHeight); // Получаем ширину с сохранением пропорций
                rectHeaderImage = new Rectangle(rectIcon.Left, HeaderHeight / 2 - imageHeight / 2, imageWidth, imageHeight);
            }

            // Close Button Structure
            rectBtnClose = new Rectangle(rectHeader.Width - ControlBoxButtonsWidth, rectHeader.Y, ControlBoxButtonsWidth, rectHeader.Height);
            // Crosshair Structure
            Rectangle rectCrosshair = new Rectangle(
                rectBtnClose.X + rectBtnClose.Width / 2 - ControlBoxIconSize.Width / 2,
                rectBtnClose.Height / 2 - ControlBoxIconSize.Height / 2,
                ControlBoxIconSize.Width, ControlBoxIconSize.Height);

            // Maximize Button Structure
            rectBtnMax = new Rectangle(rectBtnClose.X - ControlBoxButtonsWidth, rectHeader.Y, ControlBoxButtonsWidth, rectHeader.Height);
            // Maximize Icon Structure
            Rectangle rectMaxButtonIcon = new Rectangle(
                rectBtnMax.X + rectBtnMax.Width / 2 - ControlBoxIconSize.Width / 2,
                rectBtnMax.Height / 2 - ControlBoxIconSize.Height / 2,
                ControlBoxIconSize.Width, ControlBoxIconSize.Height);
            // Second Maximize Icon Structure [in Maximized state]
            Rectangle rectMaxButtonIconSecond = rectMaxButtonIcon;

            if (Form.WindowState == FormWindowState.Maximized)
            {
                //Inflate - изменяет размер и одновременно положение (В данном случае -1 по ширине и +2 по X, -1 по высоте и +2 по Y)

                rectMaxButtonIconSecond.Inflate(-1, -1);
                rectMaxButtonIconSecond.Offset(1, -1);

                rectMaxButtonIcon.Inflate(-1, -1);
                rectMaxButtonIcon.Offset(-1, 1);
            }

            // Minimize Button Structure
            rectBtnMin = new Rectangle(rectBtnMax.X - ControlBoxButtonsWidth, rectHeader.Y, ControlBoxButtonsWidth, rectHeader.Height);

            Point point1BtnMin = new Point(
                    rectBtnMin.X + rectBtnMin.Width / 2 - ControlBoxIconSize.Width / 2,
                    rectBtnMin.Height / 2 + ControlBoxIconSize.Height / 2
                    );
            Point point2BtnMin = new Point(
                rectBtnMin.X + rectBtnMin.Width / 2 + ControlBoxIconSize.Width / 2,
                rectBtnMin.Height / 2 + ControlBoxIconSize.Height / 2
                );
            Brush headerBrush = new SolidBrush(HeaderColor);

            // Шапка / Header
            graph.DrawRectangle(new Pen(headerBrush), rectHeader);
            graph.FillRectangle(headerBrush, rectHeader);

            if (HeaderImage != null)
            {
                // Картинка, вместо заголовка и иконки
                graph.DrawImage(HeaderImage, rectHeaderImage);
            }
            else
            {
                // Текст заголовка / Title
                graph.DrawString(Form.Text, HeaderTextFont, new SolidBrush(HeaderTextColor), rectTitleText, SF);

                // Иконка / Icon
                if (Form.ShowIcon)
                {
                    graph.DrawImage(Form.Icon.ToBitmap(), rectIcon);
                }
            }

            if (Form.ControlBox == true)
            {
                penBtnClose.Color = penBtnMaximize.Color = penBtnMinimize.Color = Color.White;
                if (Form.MaximizeBox == false)
                    penBtnMaximize.Color = Color.LightGray;
                if (Form.MinimizeBox == false)
                    penBtnMinimize.Color = Color.LightGray;

                // Кнопка Х
                graph.DrawRectangle(new Pen(btnCloseHovered ? FlatColors.Red2 : Color.Transparent), rectBtnClose);
                graph.FillRectangle(new SolidBrush(btnCloseHovered ? FlatColors.Red2 : Color.Transparent), rectBtnClose);
                DrawCrosshair(graph, rectCrosshair, penBtnClose);

                // Кнопка [MAX]
                if (ShowMaximizeButton)
                {
                    graph.DrawRectangle(new Pen(btnMaximizeHovered && Form.MaximizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMax);
                    graph.FillRectangle(new SolidBrush(btnMaximizeHovered && Form.MaximizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMax);

                    // Draw icon
                    if (Form.WindowState == FormWindowState.Maximized)
                    {
                        graph.DrawRectangle(penBtnMaximize, rectMaxButtonIconSecond);
                        //graph.FillRectangle(new SolidBrush(HeaderColor), rectMaxButtonIcon);
                        graph.FillRectangle(headerBrush, rectMaxButtonIcon);
                    }
                    graph.DrawRectangle(penBtnMaximize, rectMaxButtonIcon);
                }

                // Кнопка [ _ ]
                if (ShowMinimizeButton)
                {
                    graph.DrawRectangle(new Pen(btnMinimizeHovered && Form.MinimizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMin);
                    graph.FillRectangle(new SolidBrush(btnMinimizeHovered && Form.MinimizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMin);
                    graph.DrawLine(penBtnMinimize, point1BtnMin, point2BtnMin);
                }
            }
        }

        /// <param name="graph"></param>
        /// <param name="rect"></param>
        /// <param name="pen"></param>
        private void DrawCrosshair(Graphics graph, Rectangle rect, Pen pen)
        {
            graph.DrawLine(
                pen,
                rect.X,
                rect.Y,
                rect.X + rect.Width,
                rect.Y + rect.Height);

            graph.DrawLine(
                pen,
                rect.X + rect.Width,
                rect.Y,
                rect.X,
                rect.Y + rect.Height);
        }
        #endregion
        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
            {
                return;
            }
            System.Reflection.PropertyInfo pDoubleBuffered = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            pDoubleBuffered.SetValue(c, true, null);
        }
    }
}