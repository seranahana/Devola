
namespace Kaine
{
    partial class StartMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.kaineFormStyle1 = new Kaine.KaineFormStyle(this.components);
            this.ProtectionButton = new Kaine.TextOnlyButton();
            this.CheckArpCacheButton = new Kaine.TextOnlyButton();
            this.AboutButton = new Kaine.TextOnlyButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.MinimizeButton = new Kaine.TextOnlyButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SettingsButton = new Kaine.TextOnlyButton();
            this.SuspendLayout();
            // 
            // kaineFormStyle1
            // 
            this.kaineFormStyle1.AllowUserResize = true;
            this.kaineFormStyle1.BackColor = System.Drawing.Color.Black;
            this.kaineFormStyle1.ControlBoxButtonsWidth = 24;
            this.kaineFormStyle1.Form = this;
            this.kaineFormStyle1.FormStyle = Kaine.KaineFormStyle.fStyle.Telegram;
            this.kaineFormStyle1.HeaderColor = System.Drawing.Color.Black;
            this.kaineFormStyle1.HeaderHeight = 20;
            this.kaineFormStyle1.HeaderHorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.kaineFormStyle1.HeaderImage = null;
            this.kaineFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.kaineFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kaineFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.kaineFormStyle1.ShowMaximizeButton = true;
            this.kaineFormStyle1.ShowMinimizeButton = true;
            // 
            // ProtectionButton
            // 
            this.ProtectionButton.BackColor = System.Drawing.Color.Black;
            this.ProtectionButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.ProtectionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProtectionButton.Location = new System.Drawing.Point(12, 53);
            this.ProtectionButton.Name = "ProtectionButton";
            this.ProtectionButton.Size = new System.Drawing.Size(217, 33);
            this.ProtectionButton.TabIndex = 0;
            this.ProtectionButton.Text = "Start Protection";
            this.ProtectionButton.Click += new System.EventHandler(this.ProtectionButton_Click);
            this.ProtectionButton.isProtectionButton = true;
            // 
            // CheckArpCacheButton
            // 
            this.CheckArpCacheButton.BackColor = System.Drawing.Color.Black;
            this.CheckArpCacheButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.CheckArpCacheButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CheckArpCacheButton.Location = new System.Drawing.Point(12, 89);
            this.CheckArpCacheButton.Name = "CheckArpCacheButton";
            this.CheckArpCacheButton.Size = new System.Drawing.Size(217, 33);
            this.CheckArpCacheButton.TabIndex = 1;
            this.CheckArpCacheButton.Text = "Check Windows ARP Cache";
            this.CheckArpCacheButton.Click += new System.EventHandler(this.CheckArpCacheButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.BackColor = System.Drawing.Color.Black;
            this.AboutButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.AboutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AboutButton.Location = new System.Drawing.Point(12, 161);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(217, 33);
            this.AboutButton.TabIndex = 2;
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(235, 53);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(544, 385);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.Black;
            this.MinimizeButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.MinimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MinimizeButton.Location = new System.Drawing.Point(12, 125);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(217, 33);
            this.MinimizeButton.TabIndex = 4;
            this.MinimizeButton.Text = "Minimize";
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Kainé";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Black;
            this.SettingsButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.SettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SettingsButton.Location = new System.Drawing.Point(12, 197);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(217, 33);
            this.SettingsButton.TabIndex = 5;
            this.SettingsButton.Text = "Advanced Settings";
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.CheckArpCacheButton);
            this.Controls.Add(this.ProtectionButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "StartMenu";
            this.Text = "Kainé";
            this.ResumeLayout(false);

        }

        #endregion

        private KaineFormStyle kaineFormStyle1;
        private TextOnlyButton ProtectionButton;
        private TextOnlyButton CheckArpCacheButton;
        private TextOnlyButton AboutButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private TextOnlyButton MinimizeButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private TextOnlyButton SettingsButton;
    }
}

