
namespace Kaine
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.kaineFormStyle1 = new Kaine.KaineFormStyle(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.kaineComboBox1 = new Kaine.KaineComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kaineComboBox2 = new Kaine.KaineComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.kaineFormStyle1.HeaderHorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.kaineFormStyle1.HeaderImage = null;
            this.kaineFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.kaineFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kaineFormStyle1.HeaderVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.kaineFormStyle1.ShowMaximizeButton = false;
            this.kaineFormStyle1.ShowMinimizeButton = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Network Size (affects packet cache size)";
            // 
            // kaineComboBox1
            // 
            this.kaineComboBox1.BackColor = System.Drawing.Color.Black;
            this.kaineComboBox1.BorderColor = System.Drawing.Color.White;
            this.kaineComboBox1.BorderSize = 1;
            this.kaineComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.kaineComboBox1.ForeColor = System.Drawing.Color.White;
            this.kaineComboBox1.IconColor = System.Drawing.Color.White;
            this.kaineComboBox1.ListBackColor = System.Drawing.Color.Black;
            this.kaineComboBox1.ListForeColor = System.Drawing.Color.White;
            this.kaineComboBox1.Location = new System.Drawing.Point(309, 67);
            this.kaineComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.kaineComboBox1.Name = "kaineComboBox1";
            this.kaineComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.kaineComboBox1.Size = new System.Drawing.Size(213, 30);
            this.kaineComboBox1.TabIndex = 1;
            this.kaineComboBox1.Texts = "";
            this.kaineComboBox1.OnSelectedIndexChanged += new System.EventHandler(this.kaineComboBox1_OnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check ARP Entries Interval (seconds)";
            // 
            // kaineComboBox2
            // 
            this.kaineComboBox2.BackColor = System.Drawing.Color.Black;
            this.kaineComboBox2.BorderColor = System.Drawing.Color.White;
            this.kaineComboBox2.BorderSize = 1;
            this.kaineComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.kaineComboBox2.ForeColor = System.Drawing.Color.White;
            this.kaineComboBox2.IconColor = System.Drawing.Color.White;
            this.kaineComboBox2.ListBackColor = System.Drawing.Color.Black;
            this.kaineComboBox2.ListForeColor = System.Drawing.Color.White;
            this.kaineComboBox2.Location = new System.Drawing.Point(309, 117);
            this.kaineComboBox2.MinimumSize = new System.Drawing.Size(200, 30);
            this.kaineComboBox2.Name = "kaineComboBox2";
            this.kaineComboBox2.Padding = new System.Windows.Forms.Padding(1);
            this.kaineComboBox2.Size = new System.Drawing.Size(213, 30);
            this.kaineComboBox2.TabIndex = 3;
            this.kaineComboBox2.Texts = "";
            this.kaineComboBox2.OnSelectedIndexChanged += new System.EventHandler(this.kaineComboBox2_OnSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apply Strict Packet Check Rules*";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(309, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 7F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(100, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(427, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "*Checking this will make packet scanner to search for duplicate replies only";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kaineComboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kaineComboBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "SettingsForm";
            this.MaximizeBox = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KaineFormStyle kaineFormStyle1;
        private System.Windows.Forms.Label label1;
        private KaineComboBox kaineComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private KaineComboBox kaineComboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
    }
}