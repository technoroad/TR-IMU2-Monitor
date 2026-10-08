using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Quaternion = System.Windows.Media.Media3D.Quaternion;
using IMU_PlatformTool2.Services;
using IMU_PlatformTool2.Models;
using IMU_PlatformTool2.Udp;
using IMU_PlatformTool2.Helper;
using System.Text;
using System.Windows.Media.Media3D;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Security.Cryptography;
using HelixToolkit.Wpf;
using System.IO;
using System.Reflection;
using System.Windows.Shell;
using System.Net;
using Timer = System.Windows.Forms.Timer;
using System.Drawing;
using System.Linq;
using System.Windows.Shapes;
using Path = System.IO.Path;
using IMU_PlatformTool2.Forms;
using System.Data;
using System.Windows.Interop;
using System.Globalization;
using Ookii.Dialogs.WinForms;


namespace IMU_PlatformTool2
{
    public partial class Form1 : Form
    {
        Form2 displayForm;

        TcpEndpoint endpoint = new TcpEndpoint();

        SerialPort serialPort;
        private CommLinkManager roverLink;
        private CommandSender commandSender;
        private PacketParser parser;

        private UdpCommunicator udpCommunicator;
        SerialPortList serialPortList = new SerialPortList();

        private Timer connect_watch_timer = new Timer();
        private Timer receive_count_timer = new Timer();
        private Timer W55RP20_find_timer = new Timer();
        private Timer HelixView_update_timer = new Timer();
        private Timer ui_update_timer = new Timer();
        private Timer warnintimer = new Timer();
        private Timer RecvParseTimer = new Timer();

        private bool _suppressCheckedChanged = false;
        bool unsaveflag = false;

        private HelixViewManager manager;

        public Form1()
        {
            InitializeComponent();

            Version version = GetType().Assembly.GetName().Version ?? new Version();
            DateTime buildDate = DateTime.Now;
            string assemblyPath = GetType().Assembly.Location;
            if (!string.IsNullOrEmpty(assemblyPath) && File.Exists(assemblyPath))
            {
                buildDate = File.GetLastWriteTime(assemblyPath);
            }

            this.Text += $"_v{version.Major}.{version.Minor}";

            version_lb.Text = $"バージョン：{version}\n" +
                $"ビルド年月日：{buildDate:yyyy/MM/dd}　{buildDate:HH:mm:ss}";

            serialPort = new SerialPort();
            serialPort.ReadTimeout = 1000;
            serialPort.WriteTimeout = 1000;
            serialPort.WriteBufferSize = 32768;
            serialPort.ReadBufferSize = 32768;
            serialPort.DataBits = 8;
            serialPort.ReceivedBytesThreshold = 32;
            serialPort.BaudRate = 921600;

            serial_rbtn.Tag = CommMode.Serial;
            tcp_rbtn.Tag = CommMode.Tcp;

            manager = new HelixViewManager();
            manager.Initialize();
            manager.ZoomEnable(true);
            manager.ShowGrid(width: 40, length: 40, minor: 1, major: 5, thickness: 0.05);
            manager.InfoDoubleClicked += PoseResetHandle;
            manager.CameraAngleChanged += Manager_CameraAngleChanged;

            helixWindow1.Controls.Add(manager.viewer);

            foreach (var name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                Console.WriteLine(name);
            }

            string dir = Path.Combine(Path.GetTempPath(), "TR-IMU2-Monitor");
            Directory.CreateDirectory(dir);

            string resource = "IMU_PlatformTool2._3d";


            ResourceExtractor.ExtractResourceOBJ(
                resource,
                dir,
                "IMU_Platform"
                );
            ResourceExtractor.ExtractResourceOBJ(
                resource,
                dir,
                "TR_IMU16607"
                );
            ResourceExtractor.ExtractResourceOBJ(
                resource,
                dir,
                "IMU_Platform_14P"
                );
            ResourceExtractor.ExtractResourceOBJ(
                resource,
                dir,
                "IMU_Platform_1647X"
                );

            ResourceExtractor.ExtractResourceOBJ(
                resource,
                dir,
                "IMU_Platform_1650X"
                );
            ResourceExtractor.ExtractResourceOBJ(
                resource,
                dir,
                "IMU_Platform_1660X"
                );

            connect_watch_timer.Interval = 100;
            connect_watch_timer.Tick += connect_watch_timer_Tick;

            W55RP20_find_timer.Interval = 200;
            W55RP20_find_timer.Tick += W55RP20_find_timer_Tick;

            receive_count_timer.Interval = 1000;
            receive_count_timer.Tick += receive_count_timer_Tick;

            HelixView_update_timer.Interval = 100;
            HelixView_update_timer.Tick += HelixView_update_timer_tick;

            ui_update_timer.Interval = 100;
            ui_update_timer.Tick += ui_update_timer_Tick;

            RecvParseTimer.Interval = 10;
            RecvParseTimer.Tick += RecvParseTimer_Tick;

            connect_watch_timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comGimPort.Items.Clear();

            // すべてのシリアル・ポート名を取得する
            string[] ports = SerialPort.GetPortNames();
            // 取得したシリアル・ポート名を出力する
            foreach (string s in ports)
            {
                comGimPort.Items.Add(s);
            }

            //ターゲットデバイス名取得
            serialPortList.Update();
            string target_name = serialPortList.GetComFromVidPid("0483", "5740");
            //該当を選択
            foreach (string s in ports)
            {
                if (s == target_name)
                {
                    comGimPort.SelectedItem = s;
                    ComPortNameLabel.Text = serialPortList.GetDevNameFromCom(s);
                    break;
                }
            }

            var cli = Stm32ProgCliRunner.FindStm32ProgrammerCli();
            if (cli != null)
            {
                Console.WriteLine("Found: " + cli);
                stm32_prog_cli_path_tb.Text = cli;
            }

            LoadAppSettings();

            receive_count_timer.Start();

            udpCommunicator = new UdpCommunicator(50005);
            udpCommunicator.StartReceiving();

            CommMode comm_mode = CommMode.Serial;
            // ラジオボタン次第で初期の通信方式をセット
            if (tcp_rbtn.Checked)
            {
                comm_mode = CommMode.Tcp;
            }

            roverLink = new CommLinkManager(comm_mode, endpoint, serialPort);
            commandSender = new CommandSender(roverLink);
            parser = new PacketParser(roverLink);

            camera_sel_cbox.SelectedIndex = 0;
            frame_rate_cbox.SelectedIndex = 1;
            csv_timelimit_cbox.SelectedIndex = 2;
            csv_prescaler_cbox.SelectedIndex = 0;
        }

        private bool error_delay = false;

        private void FatalErrorReceived()
        {
            if (!error_delay)
            {
                error_delay = true;
                MessageBox.Show(
                    //"センサとの通信が正常に確立できませんでした。\n接続状態と電源をご確認ください。",
                    "マイコンから動作不可能なエラーを受信しました。\n" +
                    "センサが正しく接続されているか確認してください。",
                    "通信エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            commandSender.PeriodicStop();
            Disconnect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsaveflag)
            {
                // ダイアログを表示して、ユーザーが本当に閉じたいか確認する
                var result = MessageBox.Show("設定が保存されていません！\r\n本当に閉じますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // ユーザーが「いいえ」を選択した場合、閉じるのをキャンセル
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// COMが切断した後に再検索している時のフラグ
        /// </summary>
        bool ComSearchFlg = false;

        /// <summary>
        /// COMの切断
        /// </summary>
        void Disconnect()
        {
            //通信切断
            roverLink.ServiceEnd();

            // 処理の停止
            ui_update_timer.Stop();

            serial_connect_btn.Text = "接続";
            StatusLabel.Text = "未接続";
            tcp_connect_btn.Text = "接続";
            tcp_status_lb.Text = "未接続";

            panel1.Enabled = false;
            panel2.Enabled = false;
            panel4.Enabled = false;
            dfu_gbox.Enabled = false;
            comm_sel_gbox.Enabled = true;
            comGimPort.Enabled = true;
            w55rp20_cbox.Enabled = true;
            find_btn.Enabled = true;
        }

        private void comGimPort_DropDown(object sender, EventArgs e)
        {
            comGimPort.Items.Clear();
            comGimPort.Text = "";

            // すべてのシリアル・ポート名を取得する
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            // 取得したシリアル・ポート名を出力する
            foreach (string s in ports)
            {
                comGimPort.Items.Add(s);
            }

            serialPortList.Update();
            string target_name = serialPortList.GetComFromVidPid("0483", "5740");
            //該当を選択
            foreach (string s in ports)
            {
                if (s == target_name)
                {
                    comGimPort.SelectedItem = s;
                    ComPortNameLabel.Text = serialPortList.GetDevNameFromCom(s);
                    break;
                }
            }
        }

        private void comGimPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ターゲットデバイス名取得
            serialPortList.Update();

            //該当するCOMポートの名前を表示する
            ComPortNameLabel.Text = serialPortList.GetDevNameFromCom((string)comGimPort.SelectedItem);
            
            serialPort.PortName = (string)comGimPort.SelectedItem;
        }

        private void comm_connect_btn_Click(object sender, EventArgs e)
        {
            if (ComSearchFlg)
            {
                Disconnect();
                ComSearchFlg = false;
                return;
            }

            // 通信の接続管理部分
            if (roverLink.IsServiceStarted)
            {
                // 既に通信の接続処理が動いていたら切断する。
                draw_cb.Checked = false;
                comm_sel_gbox.Enabled = false;
                helixWindow1.Enabled = false;
                manager.SetVisility(false);
                Disconnect();
                return;  // 切断ならここで終了
            }
            else
            {
                // 通信の接続処理が動いてなければここで開始
                roverLink.ServiceStart();
            }

            RecvParseTimer.Start();
            ui_update_timer.Start();

            error_delay = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel4.Enabled = true;
            dfu_gbox.Enabled = true;
            comGimPort.Enabled = false;
            comm_sel_gbox.Enabled = false;
        }

        private readonly ConcurrentQueue<int> numQueue = new ConcurrentQueue<int>();

        public bool TryDequeue(out int data) => numQueue.TryDequeue(out data);

        private void renban_check()
        {
            if (newer_data.Raws.Cmd == 0x20)
            {
                // 連番チェック（同じロジックでOK）
                if ((p_imu_count + 1) != newer_data.Raws.ImuCount)
                {
                    // 番号ゼロ以外で連番ミスがあればカウントする
                    if (p_imu_count != 0 && newer_data.Raws.ImuCount != 0)
                        imu_count_miss++;
                }
                else
                {
                    // IN0トリガがあった時のデータ番号を保存する。
                    if (newer_data.Decords.in0_trig)
                    {
                        numQueue.Enqueue(newer_data.Raws.ImuCount);
                    }
                }
                p_imu_count = newer_data.Raws.ImuCount;
            }
        }

        private int receive_counter = 0;
        private bool hasTelemetryReceived;
        private DateTime lastTelemetryReceivedUtc;
        TelemetryData newer_data;
        ConfigData newer_confg;

        /// <summary>
        /// コマンド解析用のタイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecvParseTimer_Tick(object sender, EventArgs e)
        {
            // タイマー毎にデータを全部取り出す
            while (parser.TryDequeueTelemetry(out TelemetryData read))
            {
                newer_data = new TelemetryData(read);
                hasTelemetryReceived = true;
                lastTelemetryReceivedUtc = DateTime.UtcNow;
                manager.SetReceiveStatus(true, true);

                if (csv_telemetry_list != null)
                {
                    if (_csvRecordStep <= 1 || (newer_data.Raws.SendCount % _csvRecordStep) == 0)
                    {
                        if (newer_data.Raws.Cmd == 0x20)
                        {
                            csv_telemetry_list.Enqueue(newer_data);
                        }
                    }
                }

                renban_check();
                receive_counter++;
            }

            while (parser.TryDequeueConfig(out ConfigData read))
            {
                newer_confg = new ConfigData(read);
                cmd_received_response(newer_confg.Raws.Cmd);
                receive_counter++;
            }
        }

        private void redo_button_color()
        {
            if (!unsaveflag)
            {
                SaveConfig_btn.ForeColor = Color.Black;
            }
            LoadConfig_btn.ForeColor = Color.Black;
            reboot_btn.ForeColor = Color.Black;
            comm_conf_btn.ForeColor = Color.Black;

            imu_config_btn.ForeColor = Color.Black;
            grav_corr_btn.ForeColor = Color.Black;
            in0_conf_btn.ForeColor = Color.Black;
            filter_sel_btn.ForeColor = Color.Black;
        }

        private void cmd_received_response(byte cmd)
        {
            switch (cmd)
            {
                case 0x30:
                    {
                        break;
                    }
                case 0x34:
                    {
                        warnintimer.Stop();
                        unsaveflag = false;
                        redo_button_color();
                        break;
                    }
                case 0x70:
                    {
                        warnintimer.Stop();
                        redo_button_color();
                        break;
                    }
                case 0x71:
                    {
                        warnintimer.Stop();
                        unsaveflag = false;
                        SaveConfig_btn.ForeColor = Color.Black;
                        MessageBox.Show("設定が保存されました！\n設定の適応には再起動が必要です！", "通知");
                        break;
                    }
                case 0x72:
                    {
                        warnintimer.Stop();
                        unsaveflag = true;
                        SaveConfig_btn.ForeColor = Color.Red;
                        MessageBox.Show("設定を初期値に戻しました！", "通知");
                        break;
                    }
                case 0x35:
                    {
                        MessageBox.Show("プログラムの書き換えモードに移行しました！", "通知");
                        break;
                    }
                case 0x73:
                    {
                        warnintimer.Stop();
                        unsaveflag = true;
                        comm_conf_btn.ForeColor = Color.Black;
                        SaveConfig_btn.ForeColor = Color.Red;
                        MessageBox.Show("通信方式の設定が送信されました！\n反映には保存と再起動を行ってください。", "通知");
                        break;
                    }
                case 0x74:
                    {
                        warnintimer.Stop();
                        unsaveflag = true;
                        imu_config_btn.ForeColor = Color.Black;
                        SaveConfig_btn.ForeColor = Color.Red;
                        MessageBox.Show("imuの設定が送信されました！\n反映には保存と再起動を行ってください。", "通知");
                        break;
                    }
                case 0x75:
                    {
                        warnintimer.Stop();
                        unsaveflag = true;
                        filter_sel_btn.ForeColor = Color.Black;
                        SaveConfig_btn.ForeColor = Color.Red;
                        MessageBox.Show("姿勢推定フィルタの選択が送信されました！\n反映には保存と再起動を行ってください。", "通知");
                        break;
                    }
                case 0x76:
                    {
                        warnintimer.Stop();
                        unsaveflag = true;
                        grav_corr_btn.ForeColor = Color.Black;
                        SaveConfig_btn.ForeColor = Color.Red;
                        MessageBox.Show("姿勢推定の設定が送信されました！\n反映には保存と再起動を行ってください。", "通知");
                        break;
                    }
                case 0x77:
                    {
                        warnintimer.Stop();
                        unsaveflag = true;
                        in0_conf_btn.ForeColor = Color.Black;
                        SaveConfig_btn.ForeColor = Color.Red;
                        MessageBox.Show("入力ピンの設定が送信されました！\n反映には保存と再起動を行ってください。", "通知");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        UInt32 p_imu_count = 0;
        UInt32 imu_count_miss = 0;

        ulong p_conf_recv_cnt = 0;
        ulong p_parsed_recv_cnt = 0;

        double accl_sens = 0;
        double gyro_sens = 0;

        private void UI_Updater()
        {
            try
            {
                // UI更新（Invokeで安全に）
                this.BeginInvoke((Action)(() =>
                {
                    if (newer_data != null)
                    {
                        var parsed = newer_data.Raws;
                        var calc = newer_data.Decords;

                        if ((parsed.warning & 0x10) == 0x10)
                        {
                            FatalErrorReceived();
                        }

                        receive_freq_label.Text = $"{receive_rate} [Hz]";

                        if (p_parsed_recv_cnt != newer_data.Count)
                        {
                            send_cnt_vl.Text = parsed.SendCount + "";
                            elapsed_vl.Text = parsed.ComputationTime + "";
                            internal_miss_vl.Text = parsed.DroppedCount + "";
                            read_cmd_vl.Text = "0x" + parsed.Cmd.ToString("X2");
                            warn_code_vl.Text = parsed.warning + "";
                            quat_w_vl.Text = calc.QuatNorm.W.ToString("+0.000;-0.000;+0.000");
                            quat_x_vl.Text = calc.QuatNorm.X.ToString("+0.000;-0.000;+0.000");
                            quat_y_vl.Text = calc.QuatNorm.Y.ToString("+0.000;-0.000;+0.000");
                            quat_z_vl.Text = calc.QuatNorm.Z.ToString("+0.000;-0.000;+0.000");
                            temp_vl.Text = calc.TempC.ToString("F1");
                            imu_miss_vl.Text = "" + imu_count_miss;
                            spi_time_vl.Text = "" + parsed.SpiTime;
                            in0_trig_ll.Checked = calc.in0_trig;
                            in0_input_ll.Checked = calc.in0_input;
                            imu_data_cnt_vl.Text = parsed.ImuCount + "";

                            if (radioButton3.Checked)
                            {
                                if (gyro_sens != 0 && accl_sens != 0)
                                {
                                    gyro_raw_x_vl.Text = ((int)parsed.Gyro_x / gyro_sens).ToString("+0.000;-0.000;+0.000");
                                    gyro_raw_y_vl.Text = ((int)parsed.Gyro_y / gyro_sens).ToString("+0.000;-0.000;+0.000");
                                    gyro_raw_z_vl.Text = ((int)parsed.Gyro_z / gyro_sens).ToString("+0.000;-0.000;+0.000");
                                    accl_raw_x_vl.Text = ((int)parsed.Accl_x / accl_sens).ToString("+0.000;-0.000;+0.000");
                                    accl_raw_y_vl.Text = ((int)parsed.Accl_y / accl_sens).ToString("+0.000;-0.000;+0.000");
                                    accl_raw_z_vl.Text = ((int)parsed.Accl_z / accl_sens).ToString("+0.000;-0.000;+0.000");
                                }
                            }
                            else if (radioButton4.Checked)
                            {
                                gyro_raw_x_vl.Text = parsed.Gyro_x.ToString("X8");
                                gyro_raw_y_vl.Text = parsed.Gyro_y.ToString("X8");
                                gyro_raw_z_vl.Text = parsed.Gyro_z.ToString("X8");
                                accl_raw_x_vl.Text = parsed.Accl_x.ToString("X8");
                                accl_raw_y_vl.Text = parsed.Accl_y.ToString("X8");
                                accl_raw_z_vl.Text = parsed.Accl_z.ToString("X8");
                            }

                            p_parsed_recv_cnt = newer_data.Count;
                        }
                    }

                    if (newer_confg != null)
                    {
                        var conf = newer_confg;

                        if ((conf.Raws.warning & 0x10) == 0x10)
                        {
                            FatalErrorReceived();
                        }

                        // 設定画面の描画
                        if (p_conf_recv_cnt != conf.Count)
                        {
                            _suppressCheckedChanged = true;
                            usb_en_cb.Checked = conf.Decords.usb_en;
                            fdcan_en_cb.Checked = conf.Decords.fdcan_en;
                            uart4_en_cb.Checked = conf.Decords.uart4_en;

                            if (conf.Decords.read32bit_en)
                            {
                                read_32bit_rb.Checked = true;
                            }
                            else
                            {
                                read_16bit_rb.Checked = true;
                            }

                            grav_corr_en_cb.Checked = conf.Decords.gravity_corr_en;
                            filter_sel_cbox.SelectedIndex = conf.Raws.filter_select;
                            in0_pupd_cbox.SelectedIndex = conf.Raws.in0_pupd;
                            in0_trigger_cbox.SelectedIndex = conf.Raws.in0_trigger;

                            version_vl.Text = conf.Raws.version + "";
                            accl_sens_vl.Text = conf.Decords.accl_sens.ToString("F3");
                            gyro_sens_vl.Text = conf.Decords.gyro_sens.ToString("F3");
                            sample_rate_vl.Text = conf.Raws.sample_rate + "";
                            accl_sens = conf.Decords.accl_sens;
                            gyro_sens = conf.Decords.gyro_sens;

                            product_vl.Text = FormUiValueUtil.MakeProductName(
                                conf.Raws.imu_maker,
                                conf.Raws.product_id,
                                conf.Raws.model);

                            board_name_vl.Text = conf.Decords.board;

                            string path = FormUiValueUtil.MakeModelPathFromBoardInfo(
                                conf.Decords.board,
                                conf.Raws.product_id);

                            change_model3D(path);
                            UpdateCamera(FormUiValueUtil.GetZoomValueFromBoard(newer_confg?.Decords.board, blowse_cube_cb.Checked));

                            p_conf_recv_cnt = conf.Count;
                            _suppressCheckedChanged = false;
                        }
                    }

                    while (TryDequeue(out int data))
                    {
                        if (renban_tbox.Lines.Length == 100)
                        {
                            renban_tbox.Clear();
                        }

                        renban_tbox.AppendText(data + "\r\n");
                    }
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UI_error: {ex}");
            }
        }

        private void change_model3D(string path)
        {
            if (!blowse_cube_cb.Checked)
            {
                string fileName = Path.GetFileNameWithoutExtension(path);

                manager.LoadObj(path, fileName);
            }
            else
            {
                manager.BlowseColorCube();
            }
        }


        private void Start_btn_Click(object sender, EventArgs e)
        {
            p_imu_count = 0;
            imu_count_miss = 0;
            commandSender.PeriodicStart();
        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            commandSender.PeriodicStop();
        }


        private void connect_watch_timer_Tick(object sender, EventArgs e)
        {
            string btn_string = "";
            string status_string = "";

            // シリアルポートとTCPクライアントの監視
            if (roverLink.IsServiceStarted)
            {
                btn_string = "切断";
                if (roverLink.IsConnected)
                {
                    ComSearchFlg = false;
                    status_string = "接続中";
                }
                else
                {
                    ComSearchFlg = true;
                    status_string = "再接続中";
                }
            }
            else
            {
                btn_string = "通信開始";
                status_string = "未接続";
            }

            serial_connect_btn.Text = btn_string;
            StatusLabel.Text = status_string;
            tcp_connect_btn.Text = btn_string;
            tcp_status_lb.Text = status_string;
        }

        private int frame_rate = 0;
        private int rate_counter = 0;
        private int receive_rate = 0;

        private void receive_count_timer_Tick(object sender, EventArgs e)
        {
            // 受信したパケットのカウント
            receive_rate = receive_counter;
            receive_counter = 0;

            // 3D表示を更新した回数のカウント
            frame_rate = rate_counter;
            rate_counter = 0;

            bool receiving = hasTelemetryReceived && DateTime.UtcNow - lastTelemetryReceivedUtc <= TimeSpan.FromSeconds(3);
            manager.SetReceiveStatus(hasTelemetryReceived, receiving);
        }

        private void HelixView_update_timer_tick(object sender, EventArgs e)
        {
            if (draw_cb.Checked)
            {
                if (newer_data == null)
                    return;

                var decords = newer_data.Decords;
                Quaternion q = new Quaternion();
                q = decords.QuatNorm;

                manager.UpdateCubeRotation(q);
                rate_counter++;

                // フルスクリーン表示している時はフルスクリーン優先
                // そうでない時はform1にあるviewに描画する。
                if (displayForm == null || displayForm.IsDisposed)
                {
                    var euler = decords.EulerDeg;

                    manager.SetTelemetry(q, euler, frame_rate);
                }
                else
                {
                    displayForm?.HelixUpdate(q, decords.EulerDeg, frame_rate);
                }
            }
        }

        private void draw_cb_CheckedChanged(object sender, EventArgs e)
        {
            bool check = draw_cb.Checked;

            helixWindow1.Enabled = check;
            manager.SetVisility(check);

            if (check)
            {
                HelixView_update_timer.Start();
            }
            else
            {
                HelixView_update_timer.Stop();
            }
        }

        private void pose_est_reset_btn_Click(object sender, EventArgs e)
        {
            commandSender.ResetPose();
        }

        private void ui_update_timer_Tick(object sender, EventArgs e)
        {
            UI_Updater();
        }

        private void get_config_btn_Click(object sender, EventArgs e)
        {
            commandSender.ReadConfigure();
        }

        private void SaveConfig_btn_Click(object sender, EventArgs e)
        {
            commandSender.SaveConfigure();
        }

        private void LoadConfig_btn_Click(object sender, EventArgs e)
        {
            commandSender.ResetConfigure();
        }

        private void usb_en_btn_Click(object sender, EventArgs e)
        {
            bool usb = usb_en_cb.Checked;
            bool fdcan = fdcan_en_cb.Checked;
            bool uart4 = uart4_en_cb.Checked;
            commandSender.PeripheralEnable(usb, fdcan, uart4);
        }

        private void reboot_btn_Click(object sender, EventArgs e)
        {
            commandSender.SystemReset();
        }

        private void jump_dfu_btn_Click(object sender, EventArgs e)
        {
            var message =
                "【注意】USB DFUモードに移行すると、ファームウェア書き込みを行います。\n\n" +
                "・移行中はデバイスのアプリケーションが停止します。\n" +
                "・USB接続が一時的に切断／再認識されます。\n" +
                "・書き込み中に電源やUSBを抜くと、起動不能になる可能性があります。\n\n" +
                "続行しますか？";

            var title = "USB DFUモード移行（書き込み）確認";

            var result = MessageBox.Show(
                this,                               // 親フォーム（モーダルにする）
                message,
                title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2      // デフォルトをCancel側にして誤操作防止
            );

            if (result != DialogResult.OK)
                return;

            // ここから DFU 移行 → 書き込み処理へ
            commandSender.JumpDfu();
            cli_tb.AppendText("接続チェックボタンを押してください" + Environment.NewLine);
        }

        private void ChangeCommunicationMode(CommMode comm)
        {
            usb_gbox.Visible = comm == CommMode.Serial;
            tcp_gbox.Visible = comm == CommMode.Tcp;

            ChangeCommMode(comm);
        }

        void ChangeCommMode(CommMode mode)
        {
            if (mode == CommMode.Tcp)
            {
                roverLink.Switch(CommMode.Tcp);
            }
            else
            {
                roverLink.Switch(CommMode.Serial);
            }
        }

        private void CommModeRadio_CheckedChanged(object sender, EventArgs e)
        {
            var rbtn = sender as RadioButton;
            if (rbtn == null || !rbtn.Checked) return;

            var mode = (CommMode)rbtn.Tag;

            ChangeCommunicationMode(mode);
        }

        Dictionary<string, (string, int)> W55RP20_dev = new Dictionary<string, (string, int)>();

        bool udp_find_flag = false;

        private void find_btn_Click(object sender, EventArgs e)
        {
            w55rp20_cbox.Items.Clear();
            w55rp20_cbox.Text = "";
            W55RP20_dev.Clear();

            if (udp_find_flag)
            {
                // 中断処理
                W55RP20_find_timer.Stop();
                w55rp20_cbox.Enabled = true;
                find_btn.Text = "W55RP20探索";
                udp_find_flag = false;
                tcp_connect_btn.Enabled = true;
                //udp_find_result();
            }
            else
            {
                // 検索開始
                W55RP20_find_timer.Start();
                w55rp20_cbox.Enabled = false;
                find_btn.Text = "中断";
                tcp_connect_btn.Enabled = false;
                udp_find_flag = true;
            }
        }

        private void W55RP20_find_timer_Tick(object sender, EventArgs e)
        {
            byte[] data = new byte[]
            {
                (byte)'M',(byte)'A', 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x0D, 0x0A,
                (byte)'P',(byte)'W', 0x20, 0x0D, 0x0A,
                (byte)'M',(byte)'C', 0x0D, 0x0A,
                (byte)'L',(byte)'I', 0x0D, 0x0A,
                (byte)'L',(byte)'P', 0x0D, 0x0A,
            };

            udpCommunicator.SendBinary(data, "255.255.255.255", 50001);
            W55RP20_dev = udpCommunicator.GetW55RP20Address(W55RP20_dev);

            if (W55RP20_dev.Count != 0)
            {
                W55RP20_find_timer.Stop();
                udp_find_result();
            }
        }

        private void udp_find_result()
        {
            w55rp20_cbox.Items.Clear();

            foreach (var kvp in W55RP20_dev)
            {
                string key = kvp.Key;
                string value1 = kvp.Value.Item1;
                int value2 = kvp.Value.Item2;
                string str = $"{key},{value1},{value2}";

                if (TcpUtil.IsUsableIPv4(value1))
                {
                    w55rp20_cbox.Items.Add(str);
                }
            }
            if (w55rp20_cbox.Items.Count != 0)
            {
                w55rp20_cbox.SelectedIndex = 0;
            }
            tcp_connect_btn.Enabled = true;
            w55rp20_cbox.Enabled = true;
            find_btn.Text = "W55RP20探索";
            udp_find_flag = false;
        }

        private void imu_config_btn_Click(object sender, EventArgs e)
        {
            bool enable = read_32bit_rb.Checked;
            commandSender.Read32bitEnable(enable);
        }

        private void filter_sel_btn_Click(object sender, EventArgs e)
        {
            int idx = filter_sel_cbox.SelectedIndex;
            commandSender.FilterSelect(idx);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            accl_raw_x_lb.Text = "X_加速度[g]";
            accl_raw_y_lb.Text = "Y_加速度[g]";
            accl_raw_z_lb.Text = "Z_加速度[g]";
            gyro_raw_x_lb.Text = "X_ジャイロ[deg/s]";
            gyro_raw_y_lb.Text = "Y_ジャイロ[deg/s]";
            gyro_raw_z_lb.Text = "Z_ジャイロ[deg/s]";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            accl_raw_x_lb.Text = "X_加速度";
            accl_raw_y_lb.Text = "Y_加速度";
            accl_raw_z_lb.Text = "Z_加速度";
            gyro_raw_x_lb.Text = "X_ジャイロ";
            gyro_raw_y_lb.Text = "Y_ジャイロ";
            gyro_raw_z_lb.Text = "Z_ジャイロ";
        }

        private void grav_corr_btn_Click(object sender, EventArgs e)
        {
            bool enable = grav_corr_en_cb.Checked;
            commandSender.GravityCorrectionEnable(enable);
        }

        private void fullscreen_btn_Click(object sender, EventArgs e)
        {
            if (displayForm == null || displayForm.IsDisposed)
            {
                draw_cb.Checked = true;

                displayForm = new Form2(manager,helixWindow1);
                displayForm.Show();
            }
        }

        private void PoseResetHandle(object sender, EventArgs e)
        {
            commandSender.ResetPose();
        }

        private void in0_conf_btn_Click(object sender, EventArgs e)
        {
            int pupd = 0;
            int trigger = 0;

            pupd = in0_pupd_cbox.SelectedIndex;
            trigger = in0_trigger_cbox.SelectedIndex;

            commandSender.In0Config(pupd, trigger);
        }

        private void UpdateCamera(int zoom)
        {
            int deg = FormUiValueUtil.GetCameraAngleFromSelectedIndex(camera_sel_cbox.SelectedIndex);
            manager.SetCamera(deg, zoom, 6);
        }

        private void Manager_CameraAngleChanged(int angle)
        {
            int selectedIndex = ((angle % 360) + 360) % 360 / 90;
            if (camera_sel_cbox.SelectedIndex != selectedIndex)
                camera_sel_cbox.SelectedIndex = selectedIndex;
        }

        private void camera_sel_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCamera(FormUiValueUtil.GetZoomValueFromBoard(newer_confg?.Decords.board, blowse_cube_cb.Checked));
        }

        private void blowse_cube_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (blowse_cube_cb.Checked)
            {
                manager.BlowseColorCube();
                UpdateCamera(FormUiValueUtil.GetZoomValueFromBoard(newer_confg?.Decords.board, blowse_cube_cb.Checked));
            }
            else
            {
                string path = FormUiValueUtil.MakeModelPathFromBoardInfo(
                    newer_confg.Decords.board,
                    newer_confg.Raws.product_id);

                if (string.IsNullOrEmpty(path))
                    return;

                change_model3D(path);

                UpdateCamera(FormUiValueUtil.GetZoomValueFromBoard(newer_confg?.Decords.board, blowse_cube_cb.Checked));
            }
        }

        private void frame_rate_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (frame_rate_cbox.SelectedIndex)
            {
                case 0:
                    {
                        HelixView_update_timer.Interval = 10;
                        break;
                    }
                case 1:
                    {
                        HelixView_update_timer.Interval = 99;
                        break;
                    }
                case 2:
                    {
                        HelixView_update_timer.Interval = 200;
                        break;
                    }
                case 3:
                    {
                        HelixView_update_timer.Interval = 500;
                        break;
                    }
                case 4:
                    {
                        HelixView_update_timer.Interval = 1000;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void blowse_grid_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (blowse_grid_cb.Checked)
            {
                manager.ShowGrid(width: 40, length: 40, minor: 1, major: 5, thickness: 0.05);
            }
            else
            {
                manager.RemoveGrid();
            }
        }

        private void ButtonForeColor_Red(Button btn)
        {
            if (!_suppressCheckedChanged)
            {
                btn.ForeColor = Color.Red;
            }
        }

        private void usb_en_cb_CheckedChanged(object sender, EventArgs e)
        {
            ButtonForeColor_Red(comm_conf_btn);
        }

        private void grav_corr_en_cb_CheckedChanged(object sender, EventArgs e)
        {
            ButtonForeColor_Red(grav_corr_btn);
        }

        private void in0_pupd_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonForeColor_Red(in0_conf_btn);
        }

        private void filter_sel_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonForeColor_Red(filter_sel_btn);
        }


        private void stm32_prog_cli_path_btn_Click(object sender, EventArgs e)
        {
            const string exeName = Stm32ProgCliRunner.TargetExeName;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "STM32_Programmer_CLI.exe を選択してください";
                ofd.Filter =
                    "STM32 Programmer CLI (STM32_Programmer_CLI.exe)|STM32_Programmer_CLI.exe|" +
                    "実行ファイル (*.exe)|*.exe|すべてのファイル (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;

                // デフォルトはルート
                ofd.InitialDirectory = @"C:\";

                var current = stm32_prog_cli_path_tb.Text;
                if (!string.IsNullOrWhiteSpace(current))
                {
                    current = current.Trim().Trim('"');

                    // ファイルが存在 → そのフォルダを開く
                    if (File.Exists(current))
                    {
                        ofd.InitialDirectory = Path.GetDirectoryName(current);
                        ofd.FileName = Path.GetFileName(current);
                    }
                    // ディレクトリが存在 → そこを開く
                    else if (Directory.Exists(current))
                    {
                        ofd.InitialDirectory = current;
                    }
                }

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                var selected = ofd.FileName;

                if (selected.EndsWith(exeName, StringComparison.OrdinalIgnoreCase))
                {
                    stm32_prog_cli_path_tb.Text = selected;
                }
            }
        }

        private void firmware_path_btn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "書き込むファームウェアを選択してください";
                ofd.Filter =
                    "ファームウェア (*.hex;*.elf)|*.hex;*.elf|" +
                    "HEX (*.hex)|*.hex|" +
                    "ELF (*.elf)|*.elf|" +
                    "すべてのファイル (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;

                // デフォルトはデスクトップ
                ofd.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                var current = firmware_path_tb.Text;
                if (!string.IsNullOrWhiteSpace(current))
                {
                    current = current.Trim().Trim('"');

                    // ファイルが存在 → そのフォルダを開いて選択状態に
                    if (File.Exists(current))
                    {
                        ofd.InitialDirectory = Path.GetDirectoryName(current);
                        ofd.FileName = Path.GetFileName(current);
                    }
                    // ディレクトリが存在 → そこを開く
                    else if (Directory.Exists(current))
                    {
                        ofd.InitialDirectory = current;
                    }
                }

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                firmware_path_tb.Text = ofd.FileName;

                AppSetting.SaveFirmwarePathToSettings(ofd.FileName);
            }
        }

        private async void firmware_write_btn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                this,                               // 親フォーム（モーダルにする）
                "本当に書き込みますか？",
                "確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2      // デフォルトをCancel側にして誤操作防止
            );

            if (result != DialogResult.OK)
                return;


            // 画面入力
            var cliPath = stm32_prog_cli_path_tb.Text;
            var fwPath = firmware_path_tb.Text;
            var port = "USB1";

            // ログ出力補助（末尾に改行を入れる派ならここで統一）
            void Log(string s) => cli_tb.AppendText(s + Environment.NewLine);

            // 1) 入力チェック：CLIパス
            if (string.IsNullOrWhiteSpace(cliPath))
            {
                Log("[ERROR] STM32_Programmer_CLI.exe のパスが未指定です。");
                return;
            }
            if (!File.Exists(cliPath))
            {
                Log("[ERROR] STM32_Programmer_CLI.exe が見つかりません: " + cliPath);
                return;
            }
            if (!cliPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                Log("[WARN] CLIパスが.exeではないようです: " + cliPath);
                // ここでreturnするかは好み。通常は警告だけでもOK
            }

            // 1+a) 接続チェック：USB DFU
            if (await Stm32ProgCliRunner.CheckUsbConnectAsync(cliPath, port, null))
            {
                Log("DFU機材あり (USB1接続OK)\r\n");
            }
            else
            {
                Log("DFU機材なし/接続不可");
                return;
            }

            // 2) 入力チェック：FWパス
            if (string.IsNullOrWhiteSpace(fwPath))
            {
                Log("[ERROR] 書き込むファームウェアが未指定です。");
                return;
            }
            if (!File.Exists(fwPath))
            {
                Log("[ERROR] ファームウェアファイルが見つかりません: " + fwPath);
                return;
            }

            // 3) 拡張子チェック（必要最低限）
            var ext = Path.GetExtension(fwPath) ?? "";
            ext = ext.ToLowerInvariant();

            // STM32CubeProgrammerで一般的な形式
            // （必要なら .dfu は環境によって扱いが異なるのでここでは除外）
            var okExt =
                ext == ".hex" ||
                ext == ".elf";

            if (!okExt)
            {
                Log("[ERROR] 未対応の拡張子です: " + ext);
                Log("        対応: .hex .bin");
                return;
            }

            // 4) UIを固めない＆二重実行防止（任意）
            firmware_write_btn.Enabled = false;
            try
            {
                Log("[INFO] 書込み開始");
                Log("       CLI: " + cliPath);
                Log("       FW : " + fwPath);
                Log("       Port: " + port);


                // UIスレッドで生成するのがポイント（これがUIスレッドへマーシャリングしてくれる）
                var progress = new Progress<string>(line =>
                {
                    // AppendTextはUIスレッドで実行される
                    Log(line);
                });

                if (await Stm32ProgCliRunner.FlashDfuAsync(cliPath, fwPath, port, progress))
                {
                    Log("書込み完了");
                    Log("verify一致");
                    if(await Stm32ProgCliRunner.RunProgDfuAsync(cliPath, port, progress))
                    {
                        Log("プログラム実行");
                        firmware_write_btn.Enabled = false;
                    }
                }
                else
                {
                    Log("書込み失敗");
                    firmware_write_btn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log("[EXCEPTION] " + ex.Message);
                Log(ex.ToString());
            }
            finally
            {
                //firmware_write_btn.Enabled = true;
            }
        }

        private async void check_dfu_btn_Click(object sender, EventArgs e)
        {
            // 画面入力
            var cliPath = stm32_prog_cli_path_tb.Text;
            var fwPath = firmware_path_tb.Text;
            var port = "USB1";

            // ログ出力補助（末尾に改行を入れる派ならここで統一）
            void Log(string s) => cli_tb.AppendText(s + Environment.NewLine);

            // 1) 入力チェック：CLIパス
            if (string.IsNullOrWhiteSpace(cliPath))
            {
                Log("[ERROR] STM32_Programmer_CLI.exe のパスが未指定です。");
                return;
            }
            if (!File.Exists(cliPath))
            {
                Log("[ERROR] STM32_Programmer_CLI.exe が見つかりません: " + cliPath);
                return;
            }
            if (!cliPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                Log("[WARN] CLIパスが.exeではないようです: " + cliPath);
            }


            // 2) 入力チェック：FWパス
            if (string.IsNullOrWhiteSpace(fwPath))
            {
                Log("[ERROR] 書き込むファームウェアが未指定です。");
                return;
            }
            if (!File.Exists(fwPath))
            {
                Log("[ERROR] ファームウェアファイルが見つかりません: " + fwPath);
                return;
            }

            // UIスレッドで生成するのがポイント（これがUIスレッドへマーシャリングしてくれる）
            var progress = new Progress<string>(line =>
            {
                // AppendTextはUIスレッドで実行される
                Log(line);
            });

            if (await Stm32ProgCliRunner.CheckUsbConnectAsync(cliPath, port, progress))
            {
                Log("\r\nDFU機材あり (USB1接続OK)\r\n");
                firmware_write_btn.Enabled = true;
            }
            else
            {
                Log("\r\nDFU機材なし/接続不可");
                return;
            }

        }

        private void ShowInfoDialog(string text, Image image = null)
        {
            using (var info = new InfoForm())
            {
                info.SetInfoText(text);

                if (image != null)
                {
                    info.SetInfoPicture(image);
                }

                info.ShowDialog(this);
            }
        }

        private void comm_conf_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(
                InfoTextUtil.GetCommConfigText(),
                ImageResourceHelper.GetImageFromResx("USB_switch"));
        }

        private void imu_conf_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(InfoTextUtil.GetImuConfigText());
        }

        private void filter_conf_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(InfoTextUtil.GetFilterConfigText());
        }

        private void input_pin_conf_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(InfoTextUtil.GetInputPinConfigText());
        }

        private void filter_sel_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(InfoTextUtil.GetFilterSelectText());
        }

        private void option_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(InfoTextUtil.GetOptionText());
        }

        private void board_info_pb_Click(object sender, EventArgs e)
        {
            ShowInfoDialog(InfoTextUtil.GetBoardInfoText());
        }


        private void read_16bit_rb_CheckedChanged(object sender, EventArgs e)
        {
            ButtonForeColor_Red(imu_config_btn);
        }

        private void update_info_Click(object sender, EventArgs e)
        {
            using (var info = new FirmwareInfoForm())
            {
                info.ShowDialog(this);
            }
        }

        private void tcp_apply_btn_Click(object sender, EventArgs e)
        {
            if (manual_input_cb.Checked)
            {
                string ip = input_ip_tb.Text;
                int port = int.Parse(input_port_tb.Text);

                if (!TcpUtil.IsUsableIPv4(ip))
                    return;

                ip_addr_tb.Text = ip;
                port_tb.Text = port + "";
                tcp_ip_watch_lb.Text = ip_addr_tb.Text;
                tcp_port_watch_lb.Text = port_tb.Text;

                AppSetting.SaveTargetIPAddressToSettings(ip, port);
            }
            else
            {
                string str = (string)w55rp20_cbox.SelectedItem;

                if (string.IsNullOrEmpty(str))
                    return;

                string[] list = str.Split(',');
                string ip = list[1];
                int port = int.Parse(list[2]);

                if (!TcpUtil.IsUsableIPv4(ip))
                    return;

                if (port <= 0)
                    return;

                ip_addr_tb.Text = ip;
                port_tb.Text = port + "";
                tcp_ip_watch_lb.Text = ip_addr_tb.Text;
                tcp_port_watch_lb.Text = port_tb.Text;

                AppSetting.SaveTargetIPAddressToSettings(ip, port);
            }
        }

        private void ip_addr_tb_TextChanged(object sender, EventArgs e)
        {
            if (TcpUtil.IsUsableIPv4(ip_addr_tb.Text))
            {
                tcp_connect_btn.Enabled = true;
            }
            else
            {
                tcp_connect_btn.Enabled = false;
            }

            if (int.Parse(port_tb.Text) > 0)
            {
                tcp_connect_btn.Enabled = true;
            }
            else
            {
                tcp_connect_btn.Enabled = false;
            }

            if (tcp_connect_btn.Enabled)
            {
                endpoint.Ip = ip_addr_tb.Text;
                endpoint.Port = int.Parse(port_tb.Text);
            }
        }

        private void manual_input_cb_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            if (cb.Checked)
            {
                manual_input_panel.Enabled = true;

                find_btn.Enabled = false;
                w55rp20_cbox.Enabled = false;
            }
            else
            {
                manual_input_panel.Enabled = false;

                find_btn.Enabled = true;
                w55rp20_cbox.Enabled = true;
            }
        }

        private volatile bool is_record = false;
        private string _csv_save_path = "";
        private ConcurrentQueue<TelemetryData> csv_telemetry_list;
        private CancellationTokenSource _csvRecordCts;
        private Task _csvWriteTask;
        private uint _csvRecordStep = 1;

        private DateTime _csvRecordStartTime;
        private Timer _csvRecordUiTimer;
        private uint _csv_record_sample;
        private uint _target_record_sample;

        private async void csv_record_btn_Click(object sender, EventArgs e)
        {
            if (!is_record)
            {
                p_imu_count = 0;
                imu_count_miss = 0;
                commandSender.PeriodicStart();
                csv_pose_format_gbox.Enabled = false;

                try
                {
                    DateTime now = DateTime.Now;
                    string baseDir = csv_save_path_tb.Text;

                    if (string.IsNullOrWhiteSpace(baseDir))
                        return;

                    uint recordSeconds = FormUiValueUtil.GetCsvRecordSeconds(csv_timelimit_cbox.SelectedIndex);
                    _csvRecordStep = FormUiValueUtil.GetCsvRecordStep(csv_prescaler_cbox.SelectedIndex);
                    _target_record_sample = FormUiValueUtil.GetTargetRecordSample(recordSeconds, _csvRecordStep, 1000);

                    if (recordSeconds <= 0)
                        return;

                    string filePath = FormUiValueUtil.MakeCsvFilePath(baseDir, now);

                    csv_telemetry_list = new ConcurrentQueue<TelemetryData>();
                    _csv_save_path = filePath;
                    _csvRecordCts = new CancellationTokenSource();

                    is_record = true;
                    csv_record_btn.Text = "記録停止";
                    csv_record_sample_lb.Text = "0";
                    _csv_record_sample = 0;

                    csv_save_config_panel.Enabled = false;

                    InitCsvRecordTimer();

                    _csvWriteTask = CsvWriteTask(_csv_save_path, quat_rbtn.Checked, _csvRecordCts.Token);
                    _ = WaitCsvRecordingStopAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CSV record start error: " + ex);
                    ResetCsvRecordingState();
                }
            }
            else
            {
                await StopCsvRecordingAsync();
            }
        }

        private async Task WaitCsvRecordingStopAsync()
        {
            try
            {
                if (_csvWriteTask != null)
                    await _csvWriteTask;


                csv_pose_format_gbox.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CSV record background error: " + ex);
            }
            finally
            {
                ResetCsvRecordingState();
            }
        }

        private async Task StopCsvRecordingAsync()
        {
            try
            {
                if (_csvRecordCts != null)
                    _csvRecordCts.Cancel();

                if (_csvWriteTask != null)
                    await _csvWriteTask;

                csv_pose_format_gbox.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CSV record stop error: " + ex);
            }
            finally
            {
                ResetCsvRecordingState();
            }
        }

        private void ResetCsvRecordingState()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ResetCsvRecordingState));
                return;
            }

            if (_csvRecordCts != null)
            {
                _csvRecordCts.Dispose();
                _csvRecordCts = null;
            }

            _csvWriteTask = null;
            csv_telemetry_list = null;
            _csv_save_path = "";
            is_record = false;
            csv_record_btn.Text = "記録開始";
            csv_record_sample_lb.Text = _csv_record_sample + "";

            _csvRecordUiTimer.Stop();
            csv_save_status_lb.Text = "待機中";
            csv_save_status_lb.ForeColor = SystemColors.WindowText;
            csv_save_config_panel.Enabled = true;
            csv_pose_format_gbox.Enabled = true;
        }

        private async Task CsvWriteTask(string filePath,bool quat_flag, CancellationToken token)
        {
            string header = FormUiValueUtil.MakeCsvHeader(quat_flag);

            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                await writer.WriteLineAsync(header);

                while (!token.IsCancellationRequested)
                {
                    await FlushCsvQueue(writer);
                    await writer.FlushAsync();

                    try
                    {
                        await Task.Delay(1000, token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }

                // 停止時に残りを全部吐き切る
                await FlushCsvQueue(writer);
                await writer.FlushAsync();
            }
        }

        private async Task FlushCsvQueue(StreamWriter writer)
        {
            if (csv_telemetry_list == null)
                return;

            var sb = new StringBuilder();

            while (csv_telemetry_list.TryDequeue(out var t))
            {
                if (_csv_record_sample < _target_record_sample)
                {
                    _csv_record_sample++;
                    sb.Append(FormUiValueUtil.ToCsvString(t, gyro_sens, accl_sens, quat_rbtn.Checked));
                }
                else
                {
                    _csvRecordCts.Cancel();
                }
            }

            if (sb.Length > 0)
            {
                await writer.WriteAsync(sb.ToString());
            }
        }

        private void InitCsvRecordTimer()
        {
            _csvRecordUiTimer = new Timer();
            _csvRecordUiTimer.Interval = 200;
            _csvRecordUiTimer.Tick += csvRecordUiTimer_Tick;

            csv_save_status_lb.Text = "記録中";
            csv_save_status_lb.ForeColor = Color.Red;
            csv_record_time_lb.Text = "00:00:00";
            csv_record_sample_lb.Text = "0";

            _csvRecordStartTime = DateTime.Now;
            _csvRecordUiTimer.Start();
        }

        private void csvRecordUiTimer_Tick(object sender, EventArgs e)
        {
            if (!is_record)
            {
                csv_record_time_lb.Text = "00:00:00";
                return;
            }

            TimeSpan elapsed = DateTime.Now - _csvRecordStartTime;
            csv_record_time_lb.Text = elapsed.ToString(@"hh\:mm\:ss");
            csv_record_sample_lb.Text = _csv_record_sample + "";
        }

        private void csv_save_path_btn_Click(object sender, EventArgs e)
        {
            using (var dialog = new VistaFolderBrowserDialog())
            {
                string path = ResolveSavePath(csv_save_path_tb.Text);

                if (!string.IsNullOrWhiteSpace(path))
                {
                    dialog.SelectedPath = path;
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    csv_save_path_tb.Text = dialog.SelectedPath;
                    AppSetting.SaveCsvSavePathToSettings(dialog.SelectedPath);
                }
            }
        }

        private void LoadAppSettings()
        {
            AppSetting.Initialize();

            string firmware_path;
            if (AppSetting.LoadFirmwarePathFromSettings(out firmware_path))
            {
                firmware_path_tb.Text = firmware_path;
            }
            else
            {
                firmware_path_tb.Text = "";
            }

            string target_ip;
            int target_port;
            if (!AppSetting.LoadTargetIPAddressFromSettings(out target_ip, out target_port))
            {
                AppSetting.SaveTargetIPAddressToSettings("190.160.0.1", 10001);
                AppSetting.LoadTargetIPAddressFromSettings(out target_ip, out target_port);
            }

            if (!string.IsNullOrWhiteSpace(target_ip) && target_port > 0)
            {
                ApplyTargetSettingsToUi(target_ip, target_port);
            }

            string csv_path;
            if (AppSetting.LoadCsvSavePathFromSetting(out csv_path))
            {
                csv_save_path_tb.Text = csv_path;
            }
            else
            {
                csv_path = ".\\csv";
                AppSetting.SaveCsvSavePathToSettings(csv_path);
                csv_save_path_tb.Text = csv_path;
            }
        }

        private void ApplyTargetSettingsToUi(string ip, int port)
        {
            ip_addr_tb.Text = ip;
            port_tb.Text = port.ToString();
            tcp_ip_watch_lb.Text = ip_addr_tb.Text;
            tcp_port_watch_lb.Text = port_tb.Text;
            endpoint.Ip = ip;
            endpoint.Port = port;
        }

        private string ResolveSavePath(string inputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath))
                return string.Empty;

            inputPath = inputPath.Trim();

            string baseDir = Path.IsPathRooted(inputPath)
                ? inputPath
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputPath);

            return Path.GetFullPath(baseDir);
        }

        private void file_directory_btn_Click(object sender, EventArgs e)
        {
            string path = csv_save_path_tb.Text;

            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("フォルダが存在しません");
            }
        }

        private void path_init_btn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "CSV保存先の設定を初期化します。\n" +
                "初期値のみ実行ファイルからの相対パスが設定されます。\n\n" +
                "CSV保存先：.\\csv\n" +
                "よろしいですか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string csv = ".\\csv";
            csv_save_path_tb.Text = csv;
            AppSetting.SaveCsvSavePathToSettings(csv);
        }

        private void config_reset_btn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                this,
                "設定を初期化しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            AppSetting.Reset();
            LoadAppSettings();
        }
    }
}
