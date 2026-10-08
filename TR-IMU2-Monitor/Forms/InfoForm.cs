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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();

            closeButton.Click += (sender, e) => this.Close();
            this.Shown += (sender, args) => closeButton.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            richTextBox1.ContentsResized += (s, e) =>
            {
                richTextBox1.Height = e.NewRectangle.Height;
            };

        }

        public void SetInfoText(string str)
        {
            Graphics graphics = this.richTextBox1.CreateGraphics();
            SizeF size = graphics.MeasureString(str, this.richTextBox1.Font);
            graphics.Dispose();
            this.richTextBox1.Width = (int)Math.Round(size.Width);
            this.richTextBox1.Text = str;
        }

        public void SetInfoPicture(Image img)
        {
            if (img != null)
            {
                this.pictureBox1.Image = img;
                this.pictureBox1.Visible = true;
                this.pictureBox1.Size = img.Size;
            }
        }
    }
}
