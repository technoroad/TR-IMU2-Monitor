using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMU_PlatformTool2.Forms
{
    public partial class FirmwareInfoForm : Form
    {
        public FirmwareInfoForm()
        {
            InitializeComponent();

            closeButton.Click += (sender, e) => this.Close();
            this.Shown += (sender, args) => closeButton.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void url_copy_btn_Click(object sender, EventArgs e)
        {
            var text = cube_prog_url_tb.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show(
                    this,
                    "コピーする内容がありません。",
                    "情報",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            Clipboard.SetText(text);
        }

        private void github_url_copy_btn_Click(object sender, EventArgs e)
        {
            var text = github_url_tb.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show(
                    this,
                    "コピーする内容がありません。",
                    "情報",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            Clipboard.SetText(text);
        }
    }
}
