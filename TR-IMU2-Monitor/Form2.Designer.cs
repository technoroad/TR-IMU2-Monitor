namespace IMU_PlatformTool2
{
    partial class Form2
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
            this.helixWindow1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // helixWindow1
            // 
            this.helixWindow1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helixWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helixWindow1.Location = new System.Drawing.Point(3, 3);
            this.helixWindow1.Name = "helixWindow1";
            this.helixWindow1.Size = new System.Drawing.Size(878, 855);
            this.helixWindow1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.helixWindow1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel helixWindow1;
    }
}