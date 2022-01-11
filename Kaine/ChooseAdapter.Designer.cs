
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
            this.kaineComboBox1 = new Kaine.KaineComboBox();
            this.OKButton = new Kaine.TextOnlyButton();
            this.kaineFormStyle1 = new Kaine.KaineFormStyle(this.components);
            this.SuspendLayout();
            // 
            // kaineComboBox1
            // 
            this.kaineComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.kaineComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.kaineComboBox1.BackColor = System.Drawing.Color.Black;
            this.kaineComboBox1.BorderColor = System.Drawing.Color.White;
            this.kaineComboBox1.BorderSize = 1;
            this.kaineComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.kaineComboBox1.ForeColor = System.Drawing.Color.White;
            this.kaineComboBox1.IconColor = System.Drawing.Color.White;
            this.kaineComboBox1.ListBackColor = System.Drawing.Color.Black;
            this.kaineComboBox1.ListForeColor = System.Drawing.Color.White;
            this.kaineComboBox1.Location = new System.Drawing.Point(12, 39);
            this.kaineComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.kaineComboBox1.Name = "kaineComboBox1";
            this.kaineComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.kaineComboBox1.Size = new System.Drawing.Size(350, 30);
            this.kaineComboBox1.TabIndex = 2;
            this.kaineComboBox1.Texts = "";
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
            this.ClientSize = new System.Drawing.Size(390, 150);
            this.Controls.Add(this.kaineComboBox1);
            this.Controls.Add(this.OKButton);
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
        private TextOnlyButton OKButton;
        private KaineComboBox kaineComboBox1;
    }
}