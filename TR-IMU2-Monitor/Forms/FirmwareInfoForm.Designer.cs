namespace IMU_PlatformTool2.Forms
{
    partial class FirmwareInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmwareInfoForm));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.github_url_copy_btn2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.cube_prog_url_tb = new System.Windows.Forms.TextBox();
            this.url_copy_btn = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.github_url_tb = new System.Windows.Forms.TextBox();
            this.github_url_copy_btn = new System.Windows.Forms.Button();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(15, 14);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(756, 566);
            this.tabControl2.TabIndex = 297;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(748, 533);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "書込み手順";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.richTextBox1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.richTextBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(748, 533);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(6, 5);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(736, 160);
            this.richTextBox1.TabIndex = 300;
            this.richTextBox1.Text = "1a.\"STM32_Programmer_CLI.exeのパス\"が自動入力されない場合はパスを指定してください。\n　本体のSTM32CubeProgがインストール" +
    "されていれば、環境変数から自動入力されます。\n\n1b.書き込むファームウェアのパスを指定してください。\n　最新ファームウェアの取得には弊社のgithubを参照し" +
    "てください。";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.textBox1);
            this.flowLayoutPanel2.Controls.Add(this.github_url_copy_btn2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 175);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(726, 49);
            this.flowLayoutPanel2.TabIndex = 293;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(603, 28);
            this.textBox1.TabIndex = 298;
            this.textBox1.Text = "https://github.com/technoroad/TR-IMU2-STM32/releases";
            // 
            // github_url_copy_btn2
            // 
            this.github_url_copy_btn2.Location = new System.Drawing.Point(622, 7);
            this.github_url_copy_btn2.Margin = new System.Windows.Forms.Padding(7);
            this.github_url_copy_btn2.Name = "github_url_copy_btn2";
            this.github_url_copy_btn2.Size = new System.Drawing.Size(97, 35);
            this.github_url_copy_btn2.TabIndex = 299;
            this.github_url_copy_btn2.Text = "copy";
            this.github_url_copy_btn2.UseVisualStyleBackColor = true;
            this.github_url_copy_btn2.Click += new System.EventHandler(this.github_url_copy_btn_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(6, 234);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(726, 294);
            this.richTextBox2.TabIndex = 301;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.flowLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage3.Size = new System.Drawing.Size(748, 533);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "書込むための準備";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.richTextBox3);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.richTextBox4);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel3.Controls.Add(this.richTextBox5);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(736, 523);
            this.flowLayoutPanel3.TabIndex = 298;
            // 
            // richTextBox3
            // 
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(6, 5);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox3.Size = new System.Drawing.Size(710, 131);
            this.richTextBox3.TabIndex = 299;
            this.richTextBox3.Text = "・STM32CubeProgのインストール\n　このアプリはSTM32CubeProg内蔵のSTM32_Programmer_CLI.exeを使用します。\n　アップ" +
    "デートの際は公式からダウンロードとインストールしてからご利用ください。\n　また、STM32CubeProg本体で書き込んだ時と違いはありません。";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.cube_prog_url_tb);
            this.flowLayoutPanel4.Controls.Add(this.url_copy_btn);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 146);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(710, 47);
            this.flowLayoutPanel4.TabIndex = 300;
            // 
            // cube_prog_url_tb
            // 
            this.cube_prog_url_tb.Location = new System.Drawing.Point(6, 5);
            this.cube_prog_url_tb.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cube_prog_url_tb.Name = "cube_prog_url_tb";
            this.cube_prog_url_tb.ReadOnly = true;
            this.cube_prog_url_tb.Size = new System.Drawing.Size(587, 28);
            this.cube_prog_url_tb.TabIndex = 292;
            this.cube_prog_url_tb.Text = "https://www.st.com/ja/development-tools/stm32cubeprog.html";
            // 
            // url_copy_btn
            // 
            this.url_copy_btn.Location = new System.Drawing.Point(606, 7);
            this.url_copy_btn.Margin = new System.Windows.Forms.Padding(7);
            this.url_copy_btn.Name = "url_copy_btn";
            this.url_copy_btn.Size = new System.Drawing.Size(97, 33);
            this.url_copy_btn.TabIndex = 295;
            this.url_copy_btn.Text = "copy";
            this.url_copy_btn.UseVisualStyleBackColor = true;
            this.url_copy_btn.Click += new System.EventHandler(this.url_copy_btn_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(6, 203);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox4.Size = new System.Drawing.Size(726, 83);
            this.richTextBox4.TabIndex = 299;
            this.richTextBox4.Text = "・新ファームウェアの取得\n　弊社githubのTR-IMU-Platform2のReleasesからダウンロードしてください。";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.Controls.Add(this.github_url_tb);
            this.flowLayoutPanel5.Controls.Add(this.github_url_copy_btn);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(6, 296);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(710, 45);
            this.flowLayoutPanel5.TabIndex = 301;
            // 
            // github_url_tb
            // 
            this.github_url_tb.Location = new System.Drawing.Point(6, 5);
            this.github_url_tb.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.github_url_tb.Name = "github_url_tb";
            this.github_url_tb.ReadOnly = true;
            this.github_url_tb.Size = new System.Drawing.Size(587, 28);
            this.github_url_tb.TabIndex = 296;
            this.github_url_tb.Text = "https://github.com/technoroad/TR-IMU2-STM32/releases";
            // 
            // github_url_copy_btn
            // 
            this.github_url_copy_btn.Location = new System.Drawing.Point(606, 7);
            this.github_url_copy_btn.Margin = new System.Windows.Forms.Padding(7);
            this.github_url_copy_btn.Name = "github_url_copy_btn";
            this.github_url_copy_btn.Size = new System.Drawing.Size(97, 31);
            this.github_url_copy_btn.TabIndex = 297;
            this.github_url_copy_btn.Text = "copy";
            this.github_url_copy_btn.UseVisualStyleBackColor = true;
            this.github_url_copy_btn.Click += new System.EventHandler(this.github_url_copy_btn_Click);
            // 
            // richTextBox5
            // 
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Location = new System.Drawing.Point(6, 351);
            this.richTextBox5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox5.Size = new System.Drawing.Size(726, 80);
            this.richTextBox5.TabIndex = 302;
            this.richTextBox5.Text = "※従来品のTR_IMU_Platform とTR-IMU1647Xには対応していません。\n※新ファームウェアはTR-IMU-Platform2とTR-IMU166" +
    "0Xに対応しています。";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.flowLayoutPanel6);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage5.Size = new System.Drawing.Size(748, 533);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "起動不能になった時";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.richTextBox6);
            this.flowLayoutPanel6.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(736, 523);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // richTextBox6
            // 
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Location = new System.Drawing.Point(6, 5);
            this.richTextBox6.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ReadOnly = true;
            this.richTextBox6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox6.Size = new System.Drawing.Size(726, 164);
            this.richTextBox6.TabIndex = 299;
            this.richTextBox6.Text = "書き込み中に電源が落ちるなどが原因で、起動不能・正常動作ができなくなった場合は\n基板に実装されているBOOTスイッチをオンにすると強制的にUSB DFUモードで起" +
    "動します。\nUSB DFUとして正常動作していれば手順３のボタンを押すと書き込みが可能です。\n\nまた、書き込んだ後は必ずBOOTスイッチをオフにしてください。\n" +
    "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IMU_PlatformTool2.Properties.Resources.DIP_switch;
            this.pictureBox1.InitialImage = global::IMU_PlatformTool2.Properties.Resources.DIP_switch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 179);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 251);
            this.pictureBox1.TabIndex = 293;
            this.pictureBox1.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(15, 586);
            this.closeButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(133, 65);
            this.closeButton.TabIndex = 298;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // FirmwareInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tabControl2);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FirmwareInfoForm";
            this.Text = "ファームウェアアップデート説明書";
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox github_url_tb;
        private System.Windows.Forms.Button github_url_copy_btn;
        private System.Windows.Forms.TextBox cube_prog_url_tb;
        private System.Windows.Forms.Button url_copy_btn;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button github_url_copy_btn2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
    }
}
