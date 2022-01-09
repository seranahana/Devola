
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
            this.kaineFormStyle1.HeaderImage = null;
            this.kaineFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.kaineFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private KaineFormStyle kaineFormStyle1;
    }
}