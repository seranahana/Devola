
namespace Devola
{
    partial class SelectAdapter
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
            this.devolaComboBox1 = new Devola.DevolaComboBox();
            this.devolaFormStyle1 = new Devola.DevolaFormStyle(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DevolaComboBox1
            // 
            this.devolaComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.devolaComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.devolaComboBox1.BackColor = System.Drawing.Color.Black;
            this.devolaComboBox1.BorderColor = System.Drawing.Color.White;
            this.devolaComboBox1.BorderSize = 1;
            this.devolaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.devolaComboBox1.ForeColor = System.Drawing.Color.White;
            this.devolaComboBox1.IconColor = System.Drawing.Color.White;
            this.devolaComboBox1.ListBackColor = System.Drawing.Color.Black;
            this.devolaComboBox1.ListForeColor = System.Drawing.Color.White;
            this.devolaComboBox1.Location = new System.Drawing.Point(12, 39);
            this.devolaComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.devolaComboBox1.Name = "DevolaComboBox1";
            this.devolaComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.devolaComboBox1.Size = new System.Drawing.Size(350, 30);
            this.devolaComboBox1.TabIndex = 2;
            this.devolaComboBox1.Texts = "";
            // 
            // DevolaFormStyle1
            // 
            this.devolaFormStyle1.AllowUserResize = false;
            this.devolaFormStyle1.BackColor = System.Drawing.Color.Black;
            this.devolaFormStyle1.ControlBoxButtonsWidth = 24;
            this.devolaFormStyle1.Form = this;
            this.devolaFormStyle1.FormStyle = Devola.DevolaFormStyle.fStyle.Telegram;
            this.devolaFormStyle1.HeaderColor = System.Drawing.Color.Black;
            this.devolaFormStyle1.HeaderHeight = 20;
            this.devolaFormStyle1.HeaderHorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.devolaFormStyle1.HeaderImage = null;
            this.devolaFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.devolaFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.devolaFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.devolaFormStyle1.ShowMaximizeButton = false;
            this.devolaFormStyle1.ShowMinimizeButton = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(167, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "OK";
            this.label1.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SelectAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devolaComboBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "ChooseAdapter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select network interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectAdapter_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SelectAdapter_OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevolaFormStyle devolaFormStyle1;
        private DevolaComboBox devolaComboBox1;
        private System.Windows.Forms.Label label1;
    }
}