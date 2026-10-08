using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using Quaternion = System.Windows.Media.Media3D.Quaternion;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;
using System.IO;
using Brush = System.Windows.Media.Brush;

namespace IMU_PlatformTool2
{
    public partial class Form2 : Form
    {
        // 親が購読できるイベント
        public event EventHandler PoseResetHandle;

        // form1にあった時のサイズなどの情報を保存する
        private int _old_hudsize;
        private Control _old_parent;

        HelixViewManager manager;

        public Form2(HelixViewManager m, Control parent)
        {
            InitializeComponent();
            manager = m;

            _old_parent = parent;
            _old_hudsize = manager.GetHudSize();

            _old_parent.Controls.Remove(manager.viewer);
            helixWindow1.Controls.Add(manager.viewer);

            manager.SetDisplayMode(true);
            manager.SetHudSize(300);
            manager.SetVisility(true);

            this.Text = "拡大表示";
        }

        private void HelixWindow_InfoDoubleClicked(object sender, EventArgs e)
        {
            PoseResetHandle?.Invoke(this, EventArgs.Empty);
        }

        public void HelixUpdate(Quaternion q, Vector3 euler,int frame_rate)
        {
            manager.SetTelemetry(q, euler, frame_rate);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (manager != null)
            {
                helixWindow1.Controls.Remove(manager.viewer);
                manager.SetHudSize(_old_hudsize);
                manager.SetDisplayMode(false);
                _old_parent.Controls.Add(manager.viewer);
            }

            _old_parent = null;
        }
    }
}
