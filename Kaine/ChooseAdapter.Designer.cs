
namespace Kaine
{
    partial class ChooseAdapter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.OKButton = new Kaine.TextOnlyButton();
            this.kaineFormStyle1 = new Kaine.KaineFormStyle(this.components);
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(330, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.Transparent;
            this.OKButton.Font = new System.Drawing.Font("Verdana", 11F);
            this.OKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OKButton.Location = new System.Drawing.Point(157, 75);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(40, 20);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // kaineFormStyle1
            // 
            this.kaineFormStyle1.AllowUserResize = false;
            this.kaineFormStyle1.BackColor = System.Drawing.Color.Black;
            this.kaineFormStyle1.ControlBoxButtonsWidth = 24;
            this.kaineFormStyle1.Form = this;
            this.kaineFormStyle1.FormStyle = Kaine.KaineFormStyle.fStyle.Telegram;
            this.kaineFormStyle1.HeaderColor = System.Drawing.Color.Black;
            this.kaineFormStyle1.HeaderHeight = 20;
            this.kaineFormStyle1.HeaderHorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.kaineFormStyle1.HeaderImage = null;
            this.kaineFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.kaineFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kaineFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.kaineFormStyle1.ShowMaximizeButton = false;
            this.kaineFormStyle1.ShowMinimizeButton = false;
            // 
            // ChooseAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 150);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.comboBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "ChooseAdapter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose network interface";
            this.ResumeLayout(false);

        }

        #endregion

        private KaineFormStyle kaineFormStyle1;
        private System.Windows.Forms.ComboBox comboBox1;
        private TextOnlyButton OKButton;
    }
}