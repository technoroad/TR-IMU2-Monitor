namespace IMU_PlatformTool2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ComPortNameLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.serial_connect_btn = new System.Windows.Forms.Button();
            this.comGimPort = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.helixWindow1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.read_cmd_vl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.send_cnt_vl = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
            this.warn_code_vl = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
            this.quat_w_vl = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
            this.quat_x_vl = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.flowLayoutPanel18 = new System.Windows.Forms.FlowLayoutPanel();
            this.quat_y_vl = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.flowLayoutPanel19 = new System.Windows.Forms.FlowLayoutPanel();
            this.quat_z_vl = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.flowLayoutPanel20 = new System.Windows.Forms.FlowLayoutPanel();
            this.temp_vl = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.flowLayoutPanel21 = new System.Windows.Forms.FlowLayoutPanel();
            this.imu_data_cnt_vl = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.flowLayoutPanel22 = new System.Windows.Forms.FlowLayoutPanel();
            this.imu_miss_vl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.flowLayoutPanel23 = new System.Windows.Forms.FlowLayoutPanel();
            this.internal_miss_vl = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.flowLayoutPanel24 = new System.Windows.Forms.FlowLayoutPanel();
            this.elapsed_vl = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.flowLayoutPanel25 = new System.Windows.Forms.FlowLayoutPanel();
            this.spi_time_vl = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.in0_input_ll = new LampLabel();
            this.in0_trig_ll = new LampLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel26 = new System.Windows.Forms.FlowLayoutPanel();
            this.accl_raw_x_vl = new System.Windows.Forms.TextBox();
            this.accl_raw_x_lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel27 = new System.Windows.Forms.FlowLayoutPanel();
            this.accl_raw_y_vl = new System.Windows.Forms.TextBox();
            this.accl_raw_y_lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel28 = new System.Windows.Forms.FlowLayoutPanel();
            this.accl_raw_z_vl = new System.Windows.Forms.TextBox();
            this.accl_raw_z_lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel29 = new System.Windows.Forms.FlowLayoutPanel();
            this.gyro_raw_x_vl = new System.Windows.Forms.TextBox();
            this.gyro_raw_x_lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel30 = new System.Windows.Forms.FlowLayoutPanel();
            this.gyro_raw_y_vl = new System.Windows.Forms.TextBox();
            this.gyro_raw_y_lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel31 = new System.Windows.Forms.FlowLayoutPanel();
            this.gyro_raw_z_vl = new System.Windows.Forms.TextBox();
            this.gyro_raw_z_lb = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.label6 = new System.Windows.Forms.Label();
            this.renban_tbox = new System.Windows.Forms.TextBox();
            this.group = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.pose_est_reset_btn = new System.Windows.Forms.Button();
            this.receive_freq_label = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.Stop_btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.draw_cb = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.camera_sel_cbox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.frame_rate_cbox = new System.Windows.Forms.ComboBox();
            this.fullscreen_btn = new System.Windows.Forms.Button();
            this.blowse_cube_cb = new System.Windows.Forms.CheckBox();
            this.blowse_grid_cb = new System.Windows.Forms.CheckBox();
            this.tabpage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel32 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel33 = new System.Windows.Forms.FlowLayoutPanel();
            this.version_vl = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.flowLayoutPanel34 = new System.Windows.Forms.FlowLayoutPanel();
            this.accl_sens_vl = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.flowLayoutPanel35 = new System.Windows.Forms.FlowLayoutPanel();
            this.gyro_sens_vl = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.flowLayoutPanel36 = new System.Windows.Forms.FlowLayoutPanel();
            this.sample_rate_vl = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.flowLayoutPanel37 = new System.Windows.Forms.FlowLayoutPanel();
            this.product_vl = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.flowLayoutPanel38 = new System.Windows.Forms.FlowLayoutPanel();
            this.board_name_vl = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.board_info_pb = new System.Windows.Forms.Button();
            this.get_config_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.in0_trigger_cbox = new System.Windows.Forms.ComboBox();
            this.in0_pupd_cbox = new System.Windows.Forms.ComboBox();
            this.input_pin_conf_pb = new System.Windows.Forms.Button();
            this.in0_conf_btn = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.reboot_btn = new System.Windows.Forms.Button();
            this.option_pb = new System.Windows.Forms.Button();
            this.LoadConfig_btn = new System.Windows.Forms.Button();
            this.SaveConfig_btn = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.filter_sel_cbox = new System.Windows.Forms.ComboBox();
            this.filter_sel_btn = new System.Windows.Forms.Button();
            this.filter_sel_pb = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.read_32bit_rb = new System.Windows.Forms.RadioButton();
            this.read_16bit_rb = new System.Windows.Forms.RadioButton();
            this.imu_config_btn = new System.Windows.Forms.Button();
            this.imu_conf_pb = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comm_conf_btn = new System.Windows.Forms.Button();
            this.comm_conf_pb = new System.Windows.Forms.Button();
            this.uart4_en_cb = new System.Windows.Forms.CheckBox();
            this.fdcan_en_cb = new System.Windows.Forms.CheckBox();
            this.usb_en_cb = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.grav_corr_btn = new System.Windows.Forms.Button();
            this.grav_corr_en_cb = new System.Windows.Forms.CheckBox();
            this.filter_conf_pb = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tcp_conf_gbox = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.find_btn = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.manual_input_cb = new System.Windows.Forms.CheckBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.manual_input_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.input_ip_tb = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.input_port_tb = new System.Windows.Forms.TextBox();
            this.tcp_apply_btn = new System.Windows.Forms.Button();
            this.w55rp20_cbox = new System.Windows.Forms.ComboBox();
            this.ip_addr_tb = new System.Windows.Forms.TextBox();
            this.port_tb = new System.Windows.Forms.TextBox();
            this.config_reset_btn = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.update_info = new System.Windows.Forms.Button();
            this.cli_tb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.stm32_prog_cli_path_tb = new System.Windows.Forms.TextBox();
            this.stm32_prog_cli_path_btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.firmware_path_tb = new System.Windows.Forms.TextBox();
            this.firmware_path_btn = new System.Windows.Forms.Button();
            this.dfu_gbox = new System.Windows.Forms.GroupBox();
            this.jump_dfu_btn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.check_dfu_btn = new System.Windows.Forms.Button();
            this.firmware_write_btn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel39 = new System.Windows.Forms.FlowLayoutPanel();
            this.csv_record_btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel41 = new System.Windows.Forms.FlowLayoutPanel();
            this.label42 = new System.Windows.Forms.Label();
            this.csv_save_status_lb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel42 = new System.Windows.Forms.FlowLayoutPanel();
            this.label43 = new System.Windows.Forms.Label();
            this.csv_record_time_lb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel43 = new System.Windows.Forms.FlowLayoutPanel();
            this.label44 = new System.Windows.Forms.Label();
            this.csv_record_sample_lb = new System.Windows.Forms.TextBox();
            this.csv_save_config_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label47 = new System.Windows.Forms.Label();
            this.csv_save_path_tb = new System.Windows.Forms.TextBox();
            this.path_init_btn = new System.Windows.Forms.Button();
            this.csv_save_path_btn = new System.Windows.Forms.Button();
            this.file_directory_btn = new System.Windows.Forms.Button();
            this.csv_pose_format_gbox = new System.Windows.Forms.GroupBox();
            this.euler_rbtn = new System.Windows.Forms.RadioButton();
            this.quat_rbtn = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel49 = new System.Windows.Forms.FlowLayoutPanel();
            this.label45 = new System.Windows.Forms.Label();
            this.csv_timelimit_cbox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel47 = new System.Windows.Forms.FlowLayoutPanel();
            this.label46 = new System.Windows.Forms.Label();
            this.csv_prescaler_cbox = new System.Windows.Forms.ComboBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.battery_warning_tb = new System.Windows.Forms.TextBox();
            this.version_lb = new System.Windows.Forms.Label();
            this.comm_sel_gbox = new System.Windows.Forms.GroupBox();
            this.serial_rbtn = new System.Windows.Forms.RadioButton();
            this.tcp_rbtn = new System.Windows.Forms.RadioButton();
            this.usb_gbox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tcp_gbox = new System.Windows.Forms.GroupBox();
            this.tcp_port_watch_lb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tcp_ip_watch_lb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tcp_connect_btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tcp_status_lb = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel15.SuspendLayout();
            this.flowLayoutPanel16.SuspendLayout();
            this.flowLayoutPanel17.SuspendLayout();
            this.flowLayoutPanel18.SuspendLayout();
            this.flowLayoutPanel19.SuspendLayout();
            this.flowLayoutPanel20.SuspendLayout();
            this.flowLayoutPanel21.SuspendLayout();
            this.flowLayoutPanel22.SuspendLayout();
            this.flowLayoutPanel23.SuspendLayout();
            this.flowLayoutPanel24.SuspendLayout();
            this.flowLayoutPanel25.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel26.SuspendLayout();
            this.flowLayoutPanel27.SuspendLayout();
            this.flowLayoutPanel28.SuspendLayout();
            this.flowLayoutPanel29.SuspendLayout();
            this.flowLayoutPanel30.SuspendLayout();
            this.flowLayoutPanel31.SuspendLayout();
            this.group.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.tabpage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel32.SuspendLayout();
            this.flowLayoutPanel33.SuspendLayout();
            this.flowLayoutPanel34.SuspendLayout();
            this.flowLayoutPanel35.SuspendLayout();
            this.flowLayoutPanel36.SuspendLayout();
            this.flowLayoutPanel37.SuspendLayout();
            this.flowLayoutPanel38.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tcp_conf_gbox.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.manual_input_panel.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flowLayoutPanel12.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel13.SuspendLayout();
            this.flowLayoutPanel14.SuspendLayout();
            this.dfu_gbox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel39.SuspendLayout();
            this.flowLayoutPanel41.SuspendLayout();
            this.flowLayoutPanel42.SuspendLayout();
            this.flowLayoutPanel43.SuspendLayout();
            this.csv_save_config_panel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.csv_pose_format_gbox.SuspendLayout();
            this.flowLayoutPanel49.SuspendLayout();
            this.flowLayoutPanel47.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.comm_sel_gbox.SuspendLayout();
            this.usb_gbox.SuspendLayout();
            this.tcp_gbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComPortNameLabel
            // 
            this.ComPortNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ComPortNameLabel.Location = new System.Drawing.Point(315, 52);
            this.ComPortNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ComPortNameLabel.Name = "ComPortNameLabel";
            this.ComPortNameLabel.Size = new System.Drawing.Size(688, 20);
            this.ComPortNameLabel.TabIndex = 232;
            this.ComPortNameLabel.Text = "なし";
            this.ComPortNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusLabel
            // 
            this.StatusLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StatusLabel.Location = new System.Drawing.Point(315, 19);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(190, 27);
            this.StatusLabel.TabIndex = 231;
            this.StatusLabel.Text = "未接続";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(212, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 230;
            this.label7.Text = "ステータス：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serial_connect_btn
            // 
            this.serial_connect_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.serial_connect_btn.Location = new System.Drawing.Point(120, 28);
            this.serial_connect_btn.Margin = new System.Windows.Forms.Padding(4);
            this.serial_connect_btn.Name = "serial_connect_btn";
            this.serial_connect_btn.Size = new System.Drawing.Size(84, 39);
            this.serial_connect_btn.TabIndex = 229;
            this.serial_connect_btn.Text = "接続";
            this.serial_connect_btn.UseVisualStyleBackColor = true;
            this.serial_connect_btn.Click += new System.EventHandler(this.comm_connect_btn_Click);
            // 
            // comGimPort
            // 
            this.comGimPort.FormattingEnabled = true;
            this.comGimPort.Location = new System.Drawing.Point(8, 33);
            this.comGimPort.Margin = new System.Windows.Forms.Padding(4);
            this.comGimPort.Name = "comGimPort";
            this.comGimPort.Size = new System.Drawing.Size(107, 28);
            this.comGimPort.TabIndex = 228;
            this.comGimPort.DropDown += new System.EventHandler(this.comGimPort_DropDown);
            this.comGimPort.SelectedIndexChanged += new System.EventHandler(this.comGimPort_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabpage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(10, 94);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1170, 557);
            this.tabControl1.TabIndex = 288;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(1162, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "テレメトリ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.helixWindow1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.group);
            this.panel1.Controls.Add(this.flowLayoutPanel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 522);
            this.panel1.TabIndex = 305;
            // 
            // helixWindow1
            // 
            this.helixWindow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helixWindow1.Location = new System.Drawing.Point(758, 118);
            this.helixWindow1.Name = "helixWindow1";
            this.helixWindow1.Size = new System.Drawing.Size(400, 400);
            this.helixWindow1.TabIndex = 305;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel1.Controls.Add(this.splitter1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1, 1, 3, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(581, 517);
            this.flowLayoutPanel1.TabIndex = 304;
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.label1);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel15);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel16);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel17);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel18);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel19);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel20);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel21);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel22);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel23);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel24);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel25);
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(283, 515);
            this.flowLayoutPanel10.TabIndex = 306;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 303;
            this.label1.Text = "受信したテレメトリ";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.read_cmd_vl);
            this.flowLayoutPanel6.Controls.Add(this.label3);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(1, 29);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel6.TabIndex = 305;
            // 
            // read_cmd_vl
            // 
            this.read_cmd_vl.BackColor = System.Drawing.Color.White;
            this.read_cmd_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.read_cmd_vl.Location = new System.Drawing.Point(1, 1);
            this.read_cmd_vl.Margin = new System.Windows.Forms.Padding(1);
            this.read_cmd_vl.Name = "read_cmd_vl";
            this.read_cmd_vl.ReadOnly = true;
            this.read_cmd_vl.Size = new System.Drawing.Size(100, 28);
            this.read_cmd_vl.TabIndex = 318;
            this.read_cmd_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(105, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 28);
            this.label3.TabIndex = 317;
            this.label3.Text = "コマンドエコーバック";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.send_cnt_vl);
            this.flowLayoutPanel11.Controls.Add(this.label18);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(1, 61);
            this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel11.TabIndex = 316;
            // 
            // send_cnt_vl
            // 
            this.send_cnt_vl.BackColor = System.Drawing.Color.White;
            this.send_cnt_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.send_cnt_vl.Location = new System.Drawing.Point(1, 1);
            this.send_cnt_vl.Margin = new System.Windows.Forms.Padding(1);
            this.send_cnt_vl.Name = "send_cnt_vl";
            this.send_cnt_vl.ReadOnly = true;
            this.send_cnt_vl.Size = new System.Drawing.Size(100, 28);
            this.send_cnt_vl.TabIndex = 319;
            this.send_cnt_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(105, 1);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 28);
            this.label18.TabIndex = 317;
            this.label18.Text = "送信カウンタ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel15
            // 
            this.flowLayoutPanel15.Controls.Add(this.warn_code_vl);
            this.flowLayoutPanel15.Controls.Add(this.label19);
            this.flowLayoutPanel15.Location = new System.Drawing.Point(1, 93);
            this.flowLayoutPanel15.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel15.Name = "flowLayoutPanel15";
            this.flowLayoutPanel15.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel15.TabIndex = 317;
            // 
            // warn_code_vl
            // 
            this.warn_code_vl.BackColor = System.Drawing.Color.White;
            this.warn_code_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warn_code_vl.Location = new System.Drawing.Point(1, 1);
            this.warn_code_vl.Margin = new System.Windows.Forms.Padding(1);
            this.warn_code_vl.Name = "warn_code_vl";
            this.warn_code_vl.ReadOnly = true;
            this.warn_code_vl.Size = new System.Drawing.Size(100, 28);
            this.warn_code_vl.TabIndex = 319;
            this.warn_code_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(105, 1);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(170, 28);
            this.label19.TabIndex = 317;
            this.label19.Text = "マイコン警告";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel16
            // 
            this.flowLayoutPanel16.Controls.Add(this.quat_w_vl);
            this.flowLayoutPanel16.Controls.Add(this.label20);
            this.flowLayoutPanel16.Location = new System.Drawing.Point(1, 125);
            this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel16.Name = "flowLayoutPanel16";
            this.flowLayoutPanel16.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel16.TabIndex = 318;
            // 
            // quat_w_vl
            // 
            this.quat_w_vl.BackColor = System.Drawing.Color.White;
            this.quat_w_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quat_w_vl.Location = new System.Drawing.Point(1, 1);
            this.quat_w_vl.Margin = new System.Windows.Forms.Padding(1);
            this.quat_w_vl.Name = "quat_w_vl";
            this.quat_w_vl.ReadOnly = true;
            this.quat_w_vl.Size = new System.Drawing.Size(100, 28);
            this.quat_w_vl.TabIndex = 319;
            this.quat_w_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(105, 1);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(170, 28);
            this.label20.TabIndex = 317;
            this.label20.Text = "Quat：W";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel17
            // 
            this.flowLayoutPanel17.Controls.Add(this.quat_x_vl);
            this.flowLayoutPanel17.Controls.Add(this.label21);
            this.flowLayoutPanel17.Location = new System.Drawing.Point(1, 157);
            this.flowLayoutPanel17.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel17.Name = "flowLayoutPanel17";
            this.flowLayoutPanel17.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel17.TabIndex = 319;
            // 
            // quat_x_vl
            // 
            this.quat_x_vl.BackColor = System.Drawing.Color.White;
            this.quat_x_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quat_x_vl.Location = new System.Drawing.Point(1, 1);
            this.quat_x_vl.Margin = new System.Windows.Forms.Padding(1);
            this.quat_x_vl.Name = "quat_x_vl";
            this.quat_x_vl.ReadOnly = true;
            this.quat_x_vl.Size = new System.Drawing.Size(100, 28);
            this.quat_x_vl.TabIndex = 319;
            this.quat_x_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(105, 1);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(170, 28);
            this.label21.TabIndex = 317;
            this.label21.Text = "Quat：X";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel18
            // 
            this.flowLayoutPanel18.Controls.Add(this.quat_y_vl);
            this.flowLayoutPanel18.Controls.Add(this.label22);
            this.flowLayoutPanel18.Location = new System.Drawing.Point(1, 189);
            this.flowLayoutPanel18.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel18.Name = "flowLayoutPanel18";
            this.flowLayoutPanel18.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel18.TabIndex = 320;
            // 
            // quat_y_vl
            // 
            this.quat_y_vl.BackColor = System.Drawing.Color.White;
            this.quat_y_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quat_y_vl.Location = new System.Drawing.Point(1, 1);
            this.quat_y_vl.Margin = new System.Windows.Forms.Padding(1);
            this.quat_y_vl.Name = "quat_y_vl";
            this.quat_y_vl.ReadOnly = true;
            this.quat_y_vl.Size = new System.Drawing.Size(100, 28);
            this.quat_y_vl.TabIndex = 319;
            this.quat_y_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(105, 1);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(170, 28);
            this.label22.TabIndex = 317;
            this.label22.Text = "Quat：Y";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel19
            // 
            this.flowLayoutPanel19.Controls.Add(this.quat_z_vl);
            this.flowLayoutPanel19.Controls.Add(this.label23);
            this.flowLayoutPanel19.Location = new System.Drawing.Point(1, 221);
            this.flowLayoutPanel19.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel19.Name = "flowLayoutPanel19";
            this.flowLayoutPanel19.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel19.TabIndex = 321;
            // 
            // quat_z_vl
            // 
            this.quat_z_vl.BackColor = System.Drawing.Color.White;
            this.quat_z_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quat_z_vl.Location = new System.Drawing.Point(1, 1);
            this.quat_z_vl.Margin = new System.Windows.Forms.Padding(1);
            this.quat_z_vl.Name = "quat_z_vl";
            this.quat_z_vl.ReadOnly = true;
            this.quat_z_vl.Size = new System.Drawing.Size(100, 28);
            this.quat_z_vl.TabIndex = 319;
            this.quat_z_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(105, 1);
            this.label23.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(170, 28);
            this.label23.TabIndex = 317;
            this.label23.Text = "Quat：Z";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel20
            // 
            this.flowLayoutPanel20.Controls.Add(this.temp_vl);
            this.flowLayoutPanel20.Controls.Add(this.label24);
            this.flowLayoutPanel20.Location = new System.Drawing.Point(1, 253);
            this.flowLayoutPanel20.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel20.Name = "flowLayoutPanel20";
            this.flowLayoutPanel20.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel20.TabIndex = 322;
            // 
            // temp_vl
            // 
            this.temp_vl.BackColor = System.Drawing.Color.White;
            this.temp_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.temp_vl.Location = new System.Drawing.Point(1, 1);
            this.temp_vl.Margin = new System.Windows.Forms.Padding(1);
            this.temp_vl.Name = "temp_vl";
            this.temp_vl.ReadOnly = true;
            this.temp_vl.Size = new System.Drawing.Size(100, 28);
            this.temp_vl.TabIndex = 318;
            this.temp_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(105, 1);
            this.label24.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(170, 28);
            this.label24.TabIndex = 317;
            this.label24.Text = "温度[degC]";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel21
            // 
            this.flowLayoutPanel21.Controls.Add(this.imu_data_cnt_vl);
            this.flowLayoutPanel21.Controls.Add(this.label25);
            this.flowLayoutPanel21.Location = new System.Drawing.Point(1, 285);
            this.flowLayoutPanel21.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel21.Name = "flowLayoutPanel21";
            this.flowLayoutPanel21.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel21.TabIndex = 323;
            // 
            // imu_data_cnt_vl
            // 
            this.imu_data_cnt_vl.BackColor = System.Drawing.Color.White;
            this.imu_data_cnt_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imu_data_cnt_vl.Location = new System.Drawing.Point(1, 1);
            this.imu_data_cnt_vl.Margin = new System.Windows.Forms.Padding(1);
            this.imu_data_cnt_vl.Name = "imu_data_cnt_vl";
            this.imu_data_cnt_vl.ReadOnly = true;
            this.imu_data_cnt_vl.Size = new System.Drawing.Size(100, 28);
            this.imu_data_cnt_vl.TabIndex = 318;
            this.imu_data_cnt_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(105, 1);
            this.label25.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(170, 28);
            this.label25.TabIndex = 317;
            this.label25.Text = "IMUデータカウンタ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel22
            // 
            this.flowLayoutPanel22.Controls.Add(this.imu_miss_vl);
            this.flowLayoutPanel22.Controls.Add(this.label26);
            this.flowLayoutPanel22.Location = new System.Drawing.Point(1, 317);
            this.flowLayoutPanel22.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel22.Name = "flowLayoutPanel22";
            this.flowLayoutPanel22.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel22.TabIndex = 324;
            // 
            // imu_miss_vl
            // 
            this.imu_miss_vl.BackColor = System.Drawing.Color.White;
            this.imu_miss_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imu_miss_vl.Location = new System.Drawing.Point(1, 1);
            this.imu_miss_vl.Margin = new System.Windows.Forms.Padding(1);
            this.imu_miss_vl.Name = "imu_miss_vl";
            this.imu_miss_vl.ReadOnly = true;
            this.imu_miss_vl.Size = new System.Drawing.Size(100, 28);
            this.imu_miss_vl.TabIndex = 318;
            this.imu_miss_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(105, 1);
            this.label26.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(170, 28);
            this.label26.TabIndex = 317;
            this.label26.Text = "連番ミス回数(アプリ側)";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel23
            // 
            this.flowLayoutPanel23.Controls.Add(this.internal_miss_vl);
            this.flowLayoutPanel23.Controls.Add(this.label27);
            this.flowLayoutPanel23.Location = new System.Drawing.Point(1, 349);
            this.flowLayoutPanel23.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel23.Name = "flowLayoutPanel23";
            this.flowLayoutPanel23.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel23.TabIndex = 325;
            // 
            // internal_miss_vl
            // 
            this.internal_miss_vl.BackColor = System.Drawing.Color.White;
            this.internal_miss_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.internal_miss_vl.Location = new System.Drawing.Point(1, 1);
            this.internal_miss_vl.Margin = new System.Windows.Forms.Padding(1);
            this.internal_miss_vl.Name = "internal_miss_vl";
            this.internal_miss_vl.ReadOnly = true;
            this.internal_miss_vl.Size = new System.Drawing.Size(100, 28);
            this.internal_miss_vl.TabIndex = 318;
            this.internal_miss_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label27
            // 
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(105, 1);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(172, 28);
            this.label27.TabIndex = 317;
            this.label27.Text = "連番ミス回数(マイコン側)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel24
            // 
            this.flowLayoutPanel24.Controls.Add(this.elapsed_vl);
            this.flowLayoutPanel24.Controls.Add(this.label28);
            this.flowLayoutPanel24.Location = new System.Drawing.Point(1, 381);
            this.flowLayoutPanel24.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel24.Name = "flowLayoutPanel24";
            this.flowLayoutPanel24.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel24.TabIndex = 326;
            // 
            // elapsed_vl
            // 
            this.elapsed_vl.BackColor = System.Drawing.Color.White;
            this.elapsed_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.elapsed_vl.Location = new System.Drawing.Point(1, 1);
            this.elapsed_vl.Margin = new System.Windows.Forms.Padding(1);
            this.elapsed_vl.Name = "elapsed_vl";
            this.elapsed_vl.ReadOnly = true;
            this.elapsed_vl.Size = new System.Drawing.Size(100, 28);
            this.elapsed_vl.TabIndex = 318;
            this.elapsed_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(105, 1);
            this.label28.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(170, 28);
            this.label28.TabIndex = 317;
            this.label28.Text = "姿勢の計算時間[us]";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel25
            // 
            this.flowLayoutPanel25.Controls.Add(this.spi_time_vl);
            this.flowLayoutPanel25.Controls.Add(this.label29);
            this.flowLayoutPanel25.Location = new System.Drawing.Point(1, 413);
            this.flowLayoutPanel25.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel25.Name = "flowLayoutPanel25";
            this.flowLayoutPanel25.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel25.TabIndex = 327;
            // 
            // spi_time_vl
            // 
            this.spi_time_vl.BackColor = System.Drawing.Color.White;
            this.spi_time_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spi_time_vl.Location = new System.Drawing.Point(1, 1);
            this.spi_time_vl.Margin = new System.Windows.Forms.Padding(1);
            this.spi_time_vl.Name = "spi_time_vl";
            this.spi_time_vl.ReadOnly = true;
            this.spi_time_vl.Size = new System.Drawing.Size(100, 28);
            this.spi_time_vl.TabIndex = 318;
            this.spi_time_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label29
            // 
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(105, 1);
            this.label29.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(170, 28);
            this.label29.TabIndex = 317;
            this.label29.Text = "SPIの通信時間[us]";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.in0_input_ll);
            this.flowLayoutPanel2.Controls.Add(this.in0_trig_ll);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1, 445);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(280, 36);
            this.flowLayoutPanel2.TabIndex = 302;
            // 
            // in0_input_ll
            // 
            this.in0_input_ll.AutoSize = false;
            this.in0_input_ll.Location = new System.Drawing.Point(4, 4);
            this.in0_input_ll.Margin = new System.Windows.Forms.Padding(4);
            this.in0_input_ll.Name = "in0_input_ll";
            this.in0_input_ll.OffColor = System.Drawing.Color.DarkGray;
            this.in0_input_ll.OnColor = System.Drawing.Color.LimeGreen;
            this.in0_input_ll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.in0_input_ll.Size = new System.Drawing.Size(130, 28);
            this.in0_input_ll.TabIndex = 301;
            this.in0_input_ll.Text = "INピン_状態";
            // 
            // in0_trig_ll
            // 
            this.in0_trig_ll.AutoSize = false;
            this.in0_trig_ll.Location = new System.Drawing.Point(142, 4);
            this.in0_trig_ll.Margin = new System.Windows.Forms.Padding(4);
            this.in0_trig_ll.Name = "in0_trig_ll";
            this.in0_trig_ll.OffColor = System.Drawing.Color.DarkGray;
            this.in0_trig_ll.OnColor = System.Drawing.Color.LimeGreen;
            this.in0_trig_ll.Size = new System.Drawing.Size(130, 28);
            this.in0_trig_ll.TabIndex = 301;
            this.in0_trig_ll.Text = "INピン_トリガ";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Location = new System.Drawing.Point(286, 1);
            this.splitter1.Margin = new System.Windows.Forms.Padding(1);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 515);
            this.splitter1.TabIndex = 307;
            this.splitter1.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel26);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel27);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel28);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel29);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel30);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel31);
            this.flowLayoutPanel3.Controls.Add(this.splitter2);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.renban_tbox);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(291, 1);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(285, 515);
            this.flowLayoutPanel3.TabIndex = 305;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 304;
            this.label2.Text = "6軸データ";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.radioButton3);
            this.flowLayoutPanel4.Controls.Add(this.radioButton4);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(1, 29);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // radioButton3
            // 
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(4, 4);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(131, 24);
            this.radioButton3.TabIndex = 261;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "小数点表示";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(143, 4);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(123, 24);
            this.radioButton4.TabIndex = 262;
            this.radioButton4.Text = "デジタルデータ";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // flowLayoutPanel26
            // 
            this.flowLayoutPanel26.Controls.Add(this.accl_raw_x_vl);
            this.flowLayoutPanel26.Controls.Add(this.accl_raw_x_lb);
            this.flowLayoutPanel26.Location = new System.Drawing.Point(1, 61);
            this.flowLayoutPanel26.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel26.Name = "flowLayoutPanel26";
            this.flowLayoutPanel26.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel26.TabIndex = 328;
            // 
            // accl_raw_x_vl
            // 
            this.accl_raw_x_vl.BackColor = System.Drawing.Color.White;
            this.accl_raw_x_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accl_raw_x_vl.Location = new System.Drawing.Point(1, 1);
            this.accl_raw_x_vl.Margin = new System.Windows.Forms.Padding(1);
            this.accl_raw_x_vl.Name = "accl_raw_x_vl";
            this.accl_raw_x_vl.ReadOnly = true;
            this.accl_raw_x_vl.Size = new System.Drawing.Size(100, 28);
            this.accl_raw_x_vl.TabIndex = 318;
            this.accl_raw_x_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // accl_raw_x_lb
            // 
            this.accl_raw_x_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.accl_raw_x_lb.Location = new System.Drawing.Point(105, 1);
            this.accl_raw_x_lb.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.accl_raw_x_lb.Name = "accl_raw_x_lb";
            this.accl_raw_x_lb.Size = new System.Drawing.Size(170, 28);
            this.accl_raw_x_lb.TabIndex = 317;
            this.accl_raw_x_lb.Text = "X_加速度[g]";
            this.accl_raw_x_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel27
            // 
            this.flowLayoutPanel27.Controls.Add(this.accl_raw_y_vl);
            this.flowLayoutPanel27.Controls.Add(this.accl_raw_y_lb);
            this.flowLayoutPanel27.Location = new System.Drawing.Point(1, 93);
            this.flowLayoutPanel27.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel27.Name = "flowLayoutPanel27";
            this.flowLayoutPanel27.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel27.TabIndex = 329;
            // 
            // accl_raw_y_vl
            // 
            this.accl_raw_y_vl.BackColor = System.Drawing.Color.White;
            this.accl_raw_y_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accl_raw_y_vl.Location = new System.Drawing.Point(1, 1);
            this.accl_raw_y_vl.Margin = new System.Windows.Forms.Padding(1);
            this.accl_raw_y_vl.Name = "accl_raw_y_vl";
            this.accl_raw_y_vl.ReadOnly = true;
            this.accl_raw_y_vl.Size = new System.Drawing.Size(100, 28);
            this.accl_raw_y_vl.TabIndex = 318;
            this.accl_raw_y_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // accl_raw_y_lb
            // 
            this.accl_raw_y_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.accl_raw_y_lb.Location = new System.Drawing.Point(105, 1);
            this.accl_raw_y_lb.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.accl_raw_y_lb.Name = "accl_raw_y_lb";
            this.accl_raw_y_lb.Size = new System.Drawing.Size(170, 28);
            this.accl_raw_y_lb.TabIndex = 317;
            this.accl_raw_y_lb.Text = "Y_加速度[g]";
            this.accl_raw_y_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel28
            // 
            this.flowLayoutPanel28.Controls.Add(this.accl_raw_z_vl);
            this.flowLayoutPanel28.Controls.Add(this.accl_raw_z_lb);
            this.flowLayoutPanel28.Location = new System.Drawing.Point(1, 125);
            this.flowLayoutPanel28.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel28.Name = "flowLayoutPanel28";
            this.flowLayoutPanel28.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel28.TabIndex = 330;
            // 
            // accl_raw_z_vl
            // 
            this.accl_raw_z_vl.BackColor = System.Drawing.Color.White;
            this.accl_raw_z_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accl_raw_z_vl.Location = new System.Drawing.Point(1, 1);
            this.accl_raw_z_vl.Margin = new System.Windows.Forms.Padding(1);
            this.accl_raw_z_vl.Name = "accl_raw_z_vl";
            this.accl_raw_z_vl.ReadOnly = true;
            this.accl_raw_z_vl.Size = new System.Drawing.Size(100, 28);
            this.accl_raw_z_vl.TabIndex = 318;
            this.accl_raw_z_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // accl_raw_z_lb
            // 
            this.accl_raw_z_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.accl_raw_z_lb.Location = new System.Drawing.Point(105, 1);
            this.accl_raw_z_lb.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.accl_raw_z_lb.Name = "accl_raw_z_lb";
            this.accl_raw_z_lb.Size = new System.Drawing.Size(170, 28);
            this.accl_raw_z_lb.TabIndex = 317;
            this.accl_raw_z_lb.Text = "Z_加速度[g]";
            this.accl_raw_z_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel29
            // 
            this.flowLayoutPanel29.Controls.Add(this.gyro_raw_x_vl);
            this.flowLayoutPanel29.Controls.Add(this.gyro_raw_x_lb);
            this.flowLayoutPanel29.Location = new System.Drawing.Point(1, 157);
            this.flowLayoutPanel29.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel29.Name = "flowLayoutPanel29";
            this.flowLayoutPanel29.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel29.TabIndex = 331;
            // 
            // gyro_raw_x_vl
            // 
            this.gyro_raw_x_vl.BackColor = System.Drawing.Color.White;
            this.gyro_raw_x_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gyro_raw_x_vl.Location = new System.Drawing.Point(1, 1);
            this.gyro_raw_x_vl.Margin = new System.Windows.Forms.Padding(1);
            this.gyro_raw_x_vl.Name = "gyro_raw_x_vl";
            this.gyro_raw_x_vl.ReadOnly = true;
            this.gyro_raw_x_vl.Size = new System.Drawing.Size(100, 28);
            this.gyro_raw_x_vl.TabIndex = 318;
            this.gyro_raw_x_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gyro_raw_x_lb
            // 
            this.gyro_raw_x_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gyro_raw_x_lb.Location = new System.Drawing.Point(105, 1);
            this.gyro_raw_x_lb.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.gyro_raw_x_lb.Name = "gyro_raw_x_lb";
            this.gyro_raw_x_lb.Size = new System.Drawing.Size(170, 28);
            this.gyro_raw_x_lb.TabIndex = 317;
            this.gyro_raw_x_lb.Text = "X_ジャイロ[deg/s]";
            this.gyro_raw_x_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel30
            // 
            this.flowLayoutPanel30.Controls.Add(this.gyro_raw_y_vl);
            this.flowLayoutPanel30.Controls.Add(this.gyro_raw_y_lb);
            this.flowLayoutPanel30.Location = new System.Drawing.Point(1, 189);
            this.flowLayoutPanel30.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel30.Name = "flowLayoutPanel30";
            this.flowLayoutPanel30.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel30.TabIndex = 332;
            // 
            // gyro_raw_y_vl
            // 
            this.gyro_raw_y_vl.BackColor = System.Drawing.Color.White;
            this.gyro_raw_y_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gyro_raw_y_vl.Location = new System.Drawing.Point(1, 1);
            this.gyro_raw_y_vl.Margin = new System.Windows.Forms.Padding(1);
            this.gyro_raw_y_vl.Name = "gyro_raw_y_vl";
            this.gyro_raw_y_vl.ReadOnly = true;
            this.gyro_raw_y_vl.Size = new System.Drawing.Size(100, 28);
            this.gyro_raw_y_vl.TabIndex = 318;
            this.gyro_raw_y_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gyro_raw_y_lb
            // 
            this.gyro_raw_y_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gyro_raw_y_lb.Location = new System.Drawing.Point(105, 1);
            this.gyro_raw_y_lb.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.gyro_raw_y_lb.Name = "gyro_raw_y_lb";
            this.gyro_raw_y_lb.Size = new System.Drawing.Size(170, 28);
            this.gyro_raw_y_lb.TabIndex = 317;
            this.gyro_raw_y_lb.Text = "Y_ジャイロ[deg/s]";
            this.gyro_raw_y_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel31
            // 
            this.flowLayoutPanel31.Controls.Add(this.gyro_raw_z_vl);
            this.flowLayoutPanel31.Controls.Add(this.gyro_raw_z_lb);
            this.flowLayoutPanel31.Location = new System.Drawing.Point(1, 221);
            this.flowLayoutPanel31.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel31.Name = "flowLayoutPanel31";
            this.flowLayoutPanel31.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel31.TabIndex = 333;
            // 
            // gyro_raw_z_vl
            // 
            this.gyro_raw_z_vl.BackColor = System.Drawing.Color.White;
            this.gyro_raw_z_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gyro_raw_z_vl.Location = new System.Drawing.Point(1, 1);
            this.gyro_raw_z_vl.Margin = new System.Windows.Forms.Padding(1);
            this.gyro_raw_z_vl.Name = "gyro_raw_z_vl";
            this.gyro_raw_z_vl.ReadOnly = true;
            this.gyro_raw_z_vl.Size = new System.Drawing.Size(100, 28);
            this.gyro_raw_z_vl.TabIndex = 318;
            this.gyro_raw_z_vl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gyro_raw_z_lb
            // 
            this.gyro_raw_z_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gyro_raw_z_lb.Location = new System.Drawing.Point(105, 1);
            this.gyro_raw_z_lb.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.gyro_raw_z_lb.Name = "gyro_raw_z_lb";
            this.gyro_raw_z_lb.Size = new System.Drawing.Size(170, 28);
            this.gyro_raw_z_lb.TabIndex = 317;
            this.gyro_raw_z_lb.Text = "Z_ジャイロ[deg/s]";
            this.gyro_raw_z_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 255);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(276, 10);
            this.splitter2.TabIndex = 311;
            this.splitter2.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 272);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 20);
            this.label6.TabIndex = 305;
            this.label6.Text = "トリガがあった時のデータカウンタ";
            // 
            // renban_tbox
            // 
            this.renban_tbox.Location = new System.Drawing.Point(2, 298);
            this.renban_tbox.Margin = new System.Windows.Forms.Padding(2);
            this.renban_tbox.Multiline = true;
            this.renban_tbox.Name = "renban_tbox";
            this.renban_tbox.Size = new System.Drawing.Size(274, 206);
            this.renban_tbox.TabIndex = 266;
            // 
            // group
            // 
            this.group.Controls.Add(this.label40);
            this.group.Controls.Add(this.pose_est_reset_btn);
            this.group.Controls.Add(this.receive_freq_label);
            this.group.Controls.Add(this.Start_btn);
            this.group.Controls.Add(this.Stop_btn);
            this.group.Location = new System.Drawing.Point(594, 4);
            this.group.Margin = new System.Windows.Forms.Padding(4);
            this.group.Name = "group";
            this.group.Padding = new System.Windows.Forms.Padding(4);
            this.group.Size = new System.Drawing.Size(562, 106);
            this.group.TabIndex = 285;
            this.group.TabStop = false;
            this.group.Text = "操作";
            // 
            // label40
            // 
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(440, 22);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(112, 22);
            this.label40.TabIndex = 290;
            this.label40.Text = "受信周期";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pose_est_reset_btn
            // 
            this.pose_est_reset_btn.Location = new System.Drawing.Point(7, 63);
            this.pose_est_reset_btn.Margin = new System.Windows.Forms.Padding(4);
            this.pose_est_reset_btn.Name = "pose_est_reset_btn";
            this.pose_est_reset_btn.Size = new System.Drawing.Size(190, 33);
            this.pose_est_reset_btn.TabIndex = 284;
            this.pose_est_reset_btn.Text = "姿勢推定のリセット";
            this.pose_est_reset_btn.UseVisualStyleBackColor = true;
            this.pose_est_reset_btn.Click += new System.EventHandler(this.pose_est_reset_btn_Click);
            // 
            // receive_freq_label
            // 
            this.receive_freq_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.receive_freq_label.Location = new System.Drawing.Point(444, 50);
            this.receive_freq_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.receive_freq_label.Name = "receive_freq_label";
            this.receive_freq_label.Size = new System.Drawing.Size(108, 22);
            this.receive_freq_label.TabIndex = 289;
            this.receive_freq_label.Text = "0 [Hz]";
            this.receive_freq_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(8, 22);
            this.Start_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(190, 33);
            this.Start_btn.TabIndex = 282;
            this.Start_btn.Text = "データの取得開始";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // Stop_btn
            // 
            this.Stop_btn.Location = new System.Drawing.Point(231, 22);
            this.Stop_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(90, 33);
            this.Stop_btn.TabIndex = 283;
            this.Stop_btn.Text = "停止";
            this.Stop_btn.UseVisualStyleBackColor = true;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel9.Controls.Add(this.draw_cb);
            this.flowLayoutPanel9.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel9.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel9.Controls.Add(this.fullscreen_btn);
            this.flowLayoutPanel9.Controls.Add(this.blowse_cube_cb);
            this.flowLayoutPanel9.Controls.Add(this.blowse_grid_cb);
            this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(597, 118);
            this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(158, 400);
            this.flowLayoutPanel9.TabIndex = 289;
            // 
            // draw_cb
            // 
            this.draw_cb.AutoSize = true;
            this.draw_cb.Location = new System.Drawing.Point(4, 4);
            this.draw_cb.Margin = new System.Windows.Forms.Padding(4);
            this.draw_cb.Name = "draw_cb";
            this.draw_cb.Size = new System.Drawing.Size(84, 24);
            this.draw_cb.TabIndex = 288;
            this.draw_cb.Text = "描画オン";
            this.draw_cb.UseVisualStyleBackColor = true;
            this.draw_cb.CheckedChanged += new System.EventHandler(this.draw_cb_CheckedChanged);
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.label4);
            this.flowLayoutPanel7.Controls.Add(this.camera_sel_cbox);
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(1, 33);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(155, 70);
            this.flowLayoutPanel7.TabIndex = 287;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 305;
            this.label4.Text = "視点";
            // 
            // camera_sel_cbox
            // 
            this.camera_sel_cbox.FormattingEnabled = true;
            this.camera_sel_cbox.Items.AddRange(new object[] {
            "0度",
            "90度",
            "180度",
            "270度"});
            this.camera_sel_cbox.Location = new System.Drawing.Point(4, 32);
            this.camera_sel_cbox.Margin = new System.Windows.Forms.Padding(4);
            this.camera_sel_cbox.Name = "camera_sel_cbox";
            this.camera_sel_cbox.Size = new System.Drawing.Size(140, 28);
            this.camera_sel_cbox.TabIndex = 306;
            this.camera_sel_cbox.SelectedIndexChanged += new System.EventHandler(this.camera_sel_cbox_SelectedIndexChanged);
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.label5);
            this.flowLayoutPanel8.Controls.Add(this.frame_rate_cbox);
            this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(1, 105);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(155, 70);
            this.flowLayoutPanel8.TabIndex = 288;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 305;
            this.label5.Text = "フレームレート";
            // 
            // frame_rate_cbox
            // 
            this.frame_rate_cbox.FormattingEnabled = true;
            this.frame_rate_cbox.Items.AddRange(new object[] {
            "最大",
            "10hz",
            "5hz",
            "2hz",
            "1hz"});
            this.frame_rate_cbox.Location = new System.Drawing.Point(4, 32);
            this.frame_rate_cbox.Margin = new System.Windows.Forms.Padding(4);
            this.frame_rate_cbox.Name = "frame_rate_cbox";
            this.frame_rate_cbox.Size = new System.Drawing.Size(141, 28);
            this.frame_rate_cbox.TabIndex = 306;
            this.frame_rate_cbox.SelectedIndexChanged += new System.EventHandler(this.frame_rate_cbox_SelectedIndexChanged);
            // 
            // fullscreen_btn
            // 
            this.fullscreen_btn.Location = new System.Drawing.Point(4, 180);
            this.fullscreen_btn.Margin = new System.Windows.Forms.Padding(4);
            this.fullscreen_btn.Name = "fullscreen_btn";
            this.fullscreen_btn.Size = new System.Drawing.Size(136, 41);
            this.fullscreen_btn.TabIndex = 283;
            this.fullscreen_btn.Text = "拡大表示";
            this.fullscreen_btn.UseVisualStyleBackColor = true;
            this.fullscreen_btn.Click += new System.EventHandler(this.fullscreen_btn_Click);
            // 
            // blowse_cube_cb
            // 
            this.blowse_cube_cb.AutoSize = true;
            this.blowse_cube_cb.Location = new System.Drawing.Point(4, 229);
            this.blowse_cube_cb.Margin = new System.Windows.Forms.Padding(4);
            this.blowse_cube_cb.Name = "blowse_cube_cb";
            this.blowse_cube_cb.Size = new System.Drawing.Size(109, 24);
            this.blowse_cube_cb.TabIndex = 307;
            this.blowse_cube_cb.Text = "キューブ表示";
            this.blowse_cube_cb.UseVisualStyleBackColor = true;
            this.blowse_cube_cb.CheckedChanged += new System.EventHandler(this.blowse_cube_cb_CheckedChanged);
            // 
            // blowse_grid_cb
            // 
            this.blowse_grid_cb.AutoSize = true;
            this.blowse_grid_cb.Checked = true;
            this.blowse_grid_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blowse_grid_cb.Location = new System.Drawing.Point(4, 261);
            this.blowse_grid_cb.Margin = new System.Windows.Forms.Padding(4);
            this.blowse_grid_cb.Name = "blowse_grid_cb";
            this.blowse_grid_cb.Size = new System.Drawing.Size(101, 24);
            this.blowse_grid_cb.TabIndex = 308;
            this.blowse_grid_cb.Text = "グリッド表示";
            this.blowse_grid_cb.UseVisualStyleBackColor = true;
            this.blowse_grid_cb.CheckedChanged += new System.EventHandler(this.blowse_grid_cb_CheckedChanged);
            // 
            // tabpage2
            // 
            this.tabpage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabpage2.Controls.Add(this.panel2);
            this.tabpage2.Location = new System.Drawing.Point(4, 29);
            this.tabpage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabpage2.Name = "tabpage2";
            this.tabpage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabpage2.Size = new System.Drawing.Size(1162, 524);
            this.tabpage2.TabIndex = 1;
            this.tabpage2.Text = "設定";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.get_config_btn);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox9);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 516);
            this.panel2.TabIndex = 293;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel32);
            this.groupBox1.Controls.Add(this.board_info_pb);
            this.groupBox1.Location = new System.Drawing.Point(735, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 236);
            this.groupBox1.TabIndex = 327;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基板情報";
            // 
            // flowLayoutPanel32
            // 
            this.flowLayoutPanel32.Controls.Add(this.flowLayoutPanel33);
            this.flowLayoutPanel32.Controls.Add(this.flowLayoutPanel34);
            this.flowLayoutPanel32.Controls.Add(this.flowLayoutPanel35);
            this.flowLayoutPanel32.Controls.Add(this.flowLayoutPanel36);
            this.flowLayoutPanel32.Controls.Add(this.flowLayoutPanel37);
            this.flowLayoutPanel32.Controls.Add(this.flowLayoutPanel38);
            this.flowLayoutPanel32.Location = new System.Drawing.Point(6, 27);
            this.flowLayoutPanel32.Name = "flowLayoutPanel32";
            this.flowLayoutPanel32.Size = new System.Drawing.Size(350, 201);
            this.flowLayoutPanel32.TabIndex = 328;
            // 
            // flowLayoutPanel33
            // 
            this.flowLayoutPanel33.Controls.Add(this.version_vl);
            this.flowLayoutPanel33.Controls.Add(this.label30);
            this.flowLayoutPanel33.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel33.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel33.Name = "flowLayoutPanel33";
            this.flowLayoutPanel33.Size = new System.Drawing.Size(346, 30);
            this.flowLayoutPanel33.TabIndex = 317;
            // 
            // version_vl
            // 
            this.version_vl.BackColor = System.Drawing.Color.White;
            this.version_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.version_vl.Location = new System.Drawing.Point(1, 1);
            this.version_vl.Margin = new System.Windows.Forms.Padding(1);
            this.version_vl.Name = "version_vl";
            this.version_vl.ReadOnly = true;
            this.version_vl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.version_vl.Size = new System.Drawing.Size(158, 28);
            this.version_vl.TabIndex = 319;
            // 
            // label30
            // 
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(163, 1);
            this.label30.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(170, 28);
            this.label30.TabIndex = 317;
            this.label30.Text = "ビルド日時情報";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel34
            // 
            this.flowLayoutPanel34.Controls.Add(this.accl_sens_vl);
            this.flowLayoutPanel34.Controls.Add(this.label31);
            this.flowLayoutPanel34.Location = new System.Drawing.Point(1, 33);
            this.flowLayoutPanel34.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel34.Name = "flowLayoutPanel34";
            this.flowLayoutPanel34.Size = new System.Drawing.Size(346, 30);
            this.flowLayoutPanel34.TabIndex = 318;
            // 
            // accl_sens_vl
            // 
            this.accl_sens_vl.BackColor = System.Drawing.Color.White;
            this.accl_sens_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accl_sens_vl.Location = new System.Drawing.Point(1, 1);
            this.accl_sens_vl.Margin = new System.Windows.Forms.Padding(1);
            this.accl_sens_vl.Name = "accl_sens_vl";
            this.accl_sens_vl.ReadOnly = true;
            this.accl_sens_vl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accl_sens_vl.Size = new System.Drawing.Size(158, 28);
            this.accl_sens_vl.TabIndex = 319;
            // 
            // label31
            // 
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(163, 1);
            this.label31.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(170, 28);
            this.label31.TabIndex = 317;
            this.label31.Text = "加速度の感度";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel35
            // 
            this.flowLayoutPanel35.Controls.Add(this.gyro_sens_vl);
            this.flowLayoutPanel35.Controls.Add(this.label32);
            this.flowLayoutPanel35.Location = new System.Drawing.Point(1, 65);
            this.flowLayoutPanel35.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel35.Name = "flowLayoutPanel35";
            this.flowLayoutPanel35.Size = new System.Drawing.Size(346, 30);
            this.flowLayoutPanel35.TabIndex = 319;
            // 
            // gyro_sens_vl
            // 
            this.gyro_sens_vl.BackColor = System.Drawing.Color.White;
            this.gyro_sens_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gyro_sens_vl.Location = new System.Drawing.Point(1, 1);
            this.gyro_sens_vl.Margin = new System.Windows.Forms.Padding(1);
            this.gyro_sens_vl.Name = "gyro_sens_vl";
            this.gyro_sens_vl.ReadOnly = true;
            this.gyro_sens_vl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gyro_sens_vl.Size = new System.Drawing.Size(158, 28);
            this.gyro_sens_vl.TabIndex = 319;
            // 
            // label32
            // 
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(163, 1);
            this.label32.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(170, 28);
            this.label32.TabIndex = 317;
            this.label32.Text = "ジャイロの感度";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel36
            // 
            this.flowLayoutPanel36.Controls.Add(this.sample_rate_vl);
            this.flowLayoutPanel36.Controls.Add(this.label33);
            this.flowLayoutPanel36.Location = new System.Drawing.Point(1, 97);
            this.flowLayoutPanel36.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel36.Name = "flowLayoutPanel36";
            this.flowLayoutPanel36.Size = new System.Drawing.Size(346, 30);
            this.flowLayoutPanel36.TabIndex = 320;
            // 
            // sample_rate_vl
            // 
            this.sample_rate_vl.BackColor = System.Drawing.Color.White;
            this.sample_rate_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sample_rate_vl.Location = new System.Drawing.Point(1, 1);
            this.sample_rate_vl.Margin = new System.Windows.Forms.Padding(1);
            this.sample_rate_vl.Name = "sample_rate_vl";
            this.sample_rate_vl.ReadOnly = true;
            this.sample_rate_vl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sample_rate_vl.Size = new System.Drawing.Size(158, 28);
            this.sample_rate_vl.TabIndex = 319;
            // 
            // label33
            // 
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(163, 1);
            this.label33.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(170, 28);
            this.label33.TabIndex = 317;
            this.label33.Text = "サンプルレート[Hz]";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel37
            // 
            this.flowLayoutPanel37.Controls.Add(this.product_vl);
            this.flowLayoutPanel37.Controls.Add(this.label34);
            this.flowLayoutPanel37.Location = new System.Drawing.Point(1, 129);
            this.flowLayoutPanel37.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel37.Name = "flowLayoutPanel37";
            this.flowLayoutPanel37.Size = new System.Drawing.Size(346, 30);
            this.flowLayoutPanel37.TabIndex = 321;
            // 
            // product_vl
            // 
            this.product_vl.BackColor = System.Drawing.Color.White;
            this.product_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.product_vl.Location = new System.Drawing.Point(1, 1);
            this.product_vl.Margin = new System.Windows.Forms.Padding(1);
            this.product_vl.Name = "product_vl";
            this.product_vl.ReadOnly = true;
            this.product_vl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.product_vl.Size = new System.Drawing.Size(158, 28);
            this.product_vl.TabIndex = 319;
            // 
            // label34
            // 
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(163, 1);
            this.label34.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(170, 28);
            this.label34.TabIndex = 317;
            this.label34.Text = "製品型番";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel38
            // 
            this.flowLayoutPanel38.Controls.Add(this.board_name_vl);
            this.flowLayoutPanel38.Controls.Add(this.label35);
            this.flowLayoutPanel38.Location = new System.Drawing.Point(1, 161);
            this.flowLayoutPanel38.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel38.Name = "flowLayoutPanel38";
            this.flowLayoutPanel38.Size = new System.Drawing.Size(346, 30);
            this.flowLayoutPanel38.TabIndex = 322;
            // 
            // board_name_vl
            // 
            this.board_name_vl.BackColor = System.Drawing.Color.White;
            this.board_name_vl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.board_name_vl.Location = new System.Drawing.Point(1, 1);
            this.board_name_vl.Margin = new System.Windows.Forms.Padding(1);
            this.board_name_vl.Name = "board_name_vl";
            this.board_name_vl.ReadOnly = true;
            this.board_name_vl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.board_name_vl.Size = new System.Drawing.Size(158, 28);
            this.board_name_vl.TabIndex = 319;
            // 
            // label35
            // 
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(163, 1);
            this.label35.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(170, 28);
            this.label35.TabIndex = 317;
            this.label35.Text = "基板名";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // board_info_pb
            // 
            this.board_info_pb.BackColor = System.Drawing.Color.Transparent;
            this.board_info_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.board_info_pb.Location = new System.Drawing.Point(363, 25);
            this.board_info_pb.Margin = new System.Windows.Forms.Padding(4);
            this.board_info_pb.Name = "board_info_pb";
            this.board_info_pb.Size = new System.Drawing.Size(40, 40);
            this.board_info_pb.TabIndex = 289;
            this.board_info_pb.UseVisualStyleBackColor = false;
            this.board_info_pb.Click += new System.EventHandler(this.board_info_pb_Click);
            // 
            // get_config_btn
            // 
            this.get_config_btn.Location = new System.Drawing.Point(735, 10);
            this.get_config_btn.Margin = new System.Windows.Forms.Padding(4);
            this.get_config_btn.Name = "get_config_btn";
            this.get_config_btn.Size = new System.Drawing.Size(410, 41);
            this.get_config_btn.TabIndex = 214;
            this.get_config_btn.Text = "設定情報の読み出し";
            this.get_config_btn.UseVisualStyleBackColor = true;
            this.get_config_btn.Click += new System.EventHandler(this.get_config_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.in0_trigger_cbox);
            this.groupBox2.Controls.Add(this.in0_pupd_cbox);
            this.groupBox2.Controls.Add(this.input_pin_conf_pb);
            this.groupBox2.Controls.Add(this.in0_conf_btn);
            this.groupBox2.Location = new System.Drawing.Point(250, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(321, 159);
            this.groupBox2.TabIndex = 292;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入力ピンの設定";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 293;
            this.label13.Text = "トリガ条件：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 292;
            this.label12.Text = "内部抵抗：";
            // 
            // in0_trigger_cbox
            // 
            this.in0_trigger_cbox.FormattingEnabled = true;
            this.in0_trigger_cbox.Items.AddRange(new object[] {
            "立ち上がり",
            "立ち下がり",
            "変化した時"});
            this.in0_trigger_cbox.Location = new System.Drawing.Point(111, 65);
            this.in0_trigger_cbox.Margin = new System.Windows.Forms.Padding(4);
            this.in0_trigger_cbox.Name = "in0_trigger_cbox";
            this.in0_trigger_cbox.Size = new System.Drawing.Size(192, 28);
            this.in0_trigger_cbox.TabIndex = 291;
            this.in0_trigger_cbox.SelectedIndexChanged += new System.EventHandler(this.in0_pupd_cbox_SelectedIndexChanged);
            // 
            // in0_pupd_cbox
            // 
            this.in0_pupd_cbox.FormattingEnabled = true;
            this.in0_pupd_cbox.Items.AddRange(new object[] {
            "フロート",
            "内部プルアップ",
            "内部プルダウン"});
            this.in0_pupd_cbox.Location = new System.Drawing.Point(111, 29);
            this.in0_pupd_cbox.Margin = new System.Windows.Forms.Padding(4);
            this.in0_pupd_cbox.Name = "in0_pupd_cbox";
            this.in0_pupd_cbox.Size = new System.Drawing.Size(192, 28);
            this.in0_pupd_cbox.TabIndex = 290;
            this.in0_pupd_cbox.SelectedIndexChanged += new System.EventHandler(this.in0_pupd_cbox_SelectedIndexChanged);
            // 
            // input_pin_conf_pb
            // 
            this.input_pin_conf_pb.BackColor = System.Drawing.Color.Transparent;
            this.input_pin_conf_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.input_pin_conf_pb.Location = new System.Drawing.Point(264, 110);
            this.input_pin_conf_pb.Margin = new System.Windows.Forms.Padding(4);
            this.input_pin_conf_pb.Name = "input_pin_conf_pb";
            this.input_pin_conf_pb.Size = new System.Drawing.Size(40, 40);
            this.input_pin_conf_pb.TabIndex = 289;
            this.input_pin_conf_pb.UseVisualStyleBackColor = false;
            this.input_pin_conf_pb.Click += new System.EventHandler(this.input_pin_conf_pb_Click);
            // 
            // in0_conf_btn
            // 
            this.in0_conf_btn.Location = new System.Drawing.Point(18, 110);
            this.in0_conf_btn.Margin = new System.Windows.Forms.Padding(4);
            this.in0_conf_btn.Name = "in0_conf_btn";
            this.in0_conf_btn.Size = new System.Drawing.Size(79, 40);
            this.in0_conf_btn.TabIndex = 289;
            this.in0_conf_btn.Text = "設定";
            this.in0_conf_btn.UseVisualStyleBackColor = true;
            this.in0_conf_btn.Click += new System.EventHandler(this.in0_conf_btn_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.reboot_btn);
            this.groupBox9.Controls.Add(this.option_pb);
            this.groupBox9.Controls.Add(this.LoadConfig_btn);
            this.groupBox9.Controls.Add(this.SaveConfig_btn);
            this.groupBox9.Location = new System.Drawing.Point(587, 353);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(558, 155);
            this.groupBox9.TabIndex = 284;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "オプション";
            // 
            // reboot_btn
            // 
            this.reboot_btn.Location = new System.Drawing.Point(409, 92);
            this.reboot_btn.Margin = new System.Windows.Forms.Padding(4);
            this.reboot_btn.Name = "reboot_btn";
            this.reboot_btn.Size = new System.Drawing.Size(131, 55);
            this.reboot_btn.TabIndex = 285;
            this.reboot_btn.Text = "再起動";
            this.reboot_btn.UseVisualStyleBackColor = true;
            this.reboot_btn.Click += new System.EventHandler(this.reboot_btn_Click);
            // 
            // option_pb
            // 
            this.option_pb.BackColor = System.Drawing.Color.Transparent;
            this.option_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.option_pb.Location = new System.Drawing.Point(500, 22);
            this.option_pb.Margin = new System.Windows.Forms.Padding(4);
            this.option_pb.Name = "option_pb";
            this.option_pb.Size = new System.Drawing.Size(40, 40);
            this.option_pb.TabIndex = 289;
            this.option_pb.UseVisualStyleBackColor = false;
            this.option_pb.Click += new System.EventHandler(this.option_pb_Click);
            // 
            // LoadConfig_btn
            // 
            this.LoadConfig_btn.Location = new System.Drawing.Point(8, 92);
            this.LoadConfig_btn.Margin = new System.Windows.Forms.Padding(4);
            this.LoadConfig_btn.Name = "LoadConfig_btn";
            this.LoadConfig_btn.Size = new System.Drawing.Size(159, 55);
            this.LoadConfig_btn.TabIndex = 215;
            this.LoadConfig_btn.Text = "設定の初期化";
            this.LoadConfig_btn.UseVisualStyleBackColor = true;
            this.LoadConfig_btn.Click += new System.EventHandler(this.LoadConfig_btn_Click);
            // 
            // SaveConfig_btn
            // 
            this.SaveConfig_btn.Location = new System.Drawing.Point(7, 22);
            this.SaveConfig_btn.Margin = new System.Windows.Forms.Padding(4);
            this.SaveConfig_btn.Name = "SaveConfig_btn";
            this.SaveConfig_btn.Size = new System.Drawing.Size(160, 55);
            this.SaveConfig_btn.TabIndex = 214;
            this.SaveConfig_btn.Text = "設定の保存";
            this.SaveConfig_btn.UseVisualStyleBackColor = true;
            this.SaveConfig_btn.Click += new System.EventHandler(this.SaveConfig_btn_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.filter_sel_cbox);
            this.groupBox7.Controls.Add(this.filter_sel_btn);
            this.groupBox7.Controls.Add(this.filter_sel_pb);
            this.groupBox7.Location = new System.Drawing.Point(250, 177);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(321, 140);
            this.groupBox7.TabIndex = 291;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "姿勢推定フィルタの選択";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 294;
            this.label14.Text = "フィルタ：";
            // 
            // filter_sel_cbox
            // 
            this.filter_sel_cbox.FormattingEnabled = true;
            this.filter_sel_cbox.Items.AddRange(new object[] {
            "姿勢推定しない",
            "MKAE(Mahony)",
            "VQF(Double)",
            "VQF(Mixed)",
            "VQF(Float)",
            "Fusion(Float)",
            "未定義1",
            "未定義2"});
            this.filter_sel_cbox.Location = new System.Drawing.Point(111, 29);
            this.filter_sel_cbox.Margin = new System.Windows.Forms.Padding(4);
            this.filter_sel_cbox.Name = "filter_sel_cbox";
            this.filter_sel_cbox.Size = new System.Drawing.Size(192, 28);
            this.filter_sel_cbox.TabIndex = 290;
            this.filter_sel_cbox.SelectedIndexChanged += new System.EventHandler(this.filter_sel_cbox_SelectedIndexChanged);
            // 
            // filter_sel_btn
            // 
            this.filter_sel_btn.Location = new System.Drawing.Point(20, 92);
            this.filter_sel_btn.Margin = new System.Windows.Forms.Padding(4);
            this.filter_sel_btn.Name = "filter_sel_btn";
            this.filter_sel_btn.Size = new System.Drawing.Size(77, 40);
            this.filter_sel_btn.TabIndex = 289;
            this.filter_sel_btn.Text = "設定";
            this.filter_sel_btn.UseVisualStyleBackColor = true;
            this.filter_sel_btn.Click += new System.EventHandler(this.filter_sel_btn_Click);
            // 
            // filter_sel_pb
            // 
            this.filter_sel_pb.BackColor = System.Drawing.Color.Transparent;
            this.filter_sel_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.filter_sel_pb.Location = new System.Drawing.Point(263, 92);
            this.filter_sel_pb.Margin = new System.Windows.Forms.Padding(4);
            this.filter_sel_pb.Name = "filter_sel_pb";
            this.filter_sel_pb.Size = new System.Drawing.Size(40, 40);
            this.filter_sel_pb.TabIndex = 289;
            this.filter_sel_pb.UseVisualStyleBackColor = false;
            this.filter_sel_pb.Click += new System.EventHandler(this.filter_sel_pb_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.read_32bit_rb);
            this.groupBox6.Controls.Add(this.read_16bit_rb);
            this.groupBox6.Controls.Add(this.imu_config_btn);
            this.groupBox6.Controls.Add(this.imu_conf_pb);
            this.groupBox6.Location = new System.Drawing.Point(13, 177);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(229, 140);
            this.groupBox6.TabIndex = 290;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "imuの設定";
            // 
            // read_32bit_rb
            // 
            this.read_32bit_rb.AutoSize = true;
            this.read_32bit_rb.Location = new System.Drawing.Point(8, 58);
            this.read_32bit_rb.Name = "read_32bit_rb";
            this.read_32bit_rb.Size = new System.Drawing.Size(127, 24);
            this.read_32bit_rb.TabIndex = 328;
            this.read_32bit_rb.Text = "32bit読み込み";
            this.read_32bit_rb.UseVisualStyleBackColor = true;
            this.read_32bit_rb.CheckedChanged += new System.EventHandler(this.read_16bit_rb_CheckedChanged);
            // 
            // read_16bit_rb
            // 
            this.read_16bit_rb.AutoSize = true;
            this.read_16bit_rb.Checked = true;
            this.read_16bit_rb.Location = new System.Drawing.Point(8, 28);
            this.read_16bit_rb.Name = "read_16bit_rb";
            this.read_16bit_rb.Size = new System.Drawing.Size(127, 24);
            this.read_16bit_rb.TabIndex = 328;
            this.read_16bit_rb.TabStop = true;
            this.read_16bit_rb.Text = "16bit読み込み";
            this.read_16bit_rb.UseVisualStyleBackColor = true;
            this.read_16bit_rb.CheckedChanged += new System.EventHandler(this.read_16bit_rb_CheckedChanged);
            // 
            // imu_config_btn
            // 
            this.imu_config_btn.Location = new System.Drawing.Point(7, 92);
            this.imu_config_btn.Margin = new System.Windows.Forms.Padding(4);
            this.imu_config_btn.Name = "imu_config_btn";
            this.imu_config_btn.Size = new System.Drawing.Size(79, 40);
            this.imu_config_btn.TabIndex = 289;
            this.imu_config_btn.Text = "設定";
            this.imu_config_btn.UseVisualStyleBackColor = true;
            this.imu_config_btn.Click += new System.EventHandler(this.imu_config_btn_Click);
            // 
            // imu_conf_pb
            // 
            this.imu_conf_pb.BackColor = System.Drawing.Color.Transparent;
            this.imu_conf_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.imu_conf_pb.Location = new System.Drawing.Point(179, 92);
            this.imu_conf_pb.Margin = new System.Windows.Forms.Padding(4);
            this.imu_conf_pb.Name = "imu_conf_pb";
            this.imu_conf_pb.Size = new System.Drawing.Size(40, 40);
            this.imu_conf_pb.TabIndex = 289;
            this.imu_conf_pb.UseVisualStyleBackColor = false;
            this.imu_conf_pb.Click += new System.EventHandler(this.imu_conf_pb_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comm_conf_btn);
            this.groupBox4.Controls.Add(this.comm_conf_pb);
            this.groupBox4.Controls.Add(this.uart4_en_cb);
            this.groupBox4.Controls.Add(this.fdcan_en_cb);
            this.groupBox4.Controls.Add(this.usb_en_cb);
            this.groupBox4.Location = new System.Drawing.Point(13, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(229, 159);
            this.groupBox4.TabIndex = 288;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "通信方式の設定";
            // 
            // comm_conf_btn
            // 
            this.comm_conf_btn.Location = new System.Drawing.Point(7, 112);
            this.comm_conf_btn.Margin = new System.Windows.Forms.Padding(4);
            this.comm_conf_btn.Name = "comm_conf_btn";
            this.comm_conf_btn.Size = new System.Drawing.Size(79, 38);
            this.comm_conf_btn.TabIndex = 289;
            this.comm_conf_btn.Text = "設定";
            this.comm_conf_btn.UseVisualStyleBackColor = true;
            this.comm_conf_btn.Click += new System.EventHandler(this.usb_en_btn_Click);
            // 
            // comm_conf_pb
            // 
            this.comm_conf_pb.BackColor = System.Drawing.Color.Transparent;
            this.comm_conf_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.comm_conf_pb.Location = new System.Drawing.Point(179, 110);
            this.comm_conf_pb.Margin = new System.Windows.Forms.Padding(4);
            this.comm_conf_pb.Name = "comm_conf_pb";
            this.comm_conf_pb.Size = new System.Drawing.Size(40, 40);
            this.comm_conf_pb.TabIndex = 289;
            this.comm_conf_pb.UseVisualStyleBackColor = false;
            this.comm_conf_pb.Click += new System.EventHandler(this.comm_conf_pb_Click);
            // 
            // uart4_en_cb
            // 
            this.uart4_en_cb.AutoSize = true;
            this.uart4_en_cb.Checked = true;
            this.uart4_en_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uart4_en_cb.Location = new System.Drawing.Point(7, 82);
            this.uart4_en_cb.Margin = new System.Windows.Forms.Padding(4);
            this.uart4_en_cb.Name = "uart4_en_cb";
            this.uart4_en_cb.Size = new System.Drawing.Size(72, 24);
            this.uart4_en_cb.TabIndex = 288;
            this.uart4_en_cb.Text = "UART";
            this.uart4_en_cb.UseVisualStyleBackColor = true;
            this.uart4_en_cb.CheckedChanged += new System.EventHandler(this.usb_en_cb_CheckedChanged);
            // 
            // fdcan_en_cb
            // 
            this.fdcan_en_cb.AutoSize = true;
            this.fdcan_en_cb.Location = new System.Drawing.Point(7, 55);
            this.fdcan_en_cb.Margin = new System.Windows.Forms.Padding(4);
            this.fdcan_en_cb.Name = "fdcan_en_cb";
            this.fdcan_en_cb.Size = new System.Drawing.Size(83, 24);
            this.fdcan_en_cb.TabIndex = 287;
            this.fdcan_en_cb.Text = "FDCAN";
            this.fdcan_en_cb.UseVisualStyleBackColor = true;
            this.fdcan_en_cb.CheckedChanged += new System.EventHandler(this.usb_en_cb_CheckedChanged);
            // 
            // usb_en_cb
            // 
            this.usb_en_cb.AutoSize = true;
            this.usb_en_cb.Checked = true;
            this.usb_en_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.usb_en_cb.Location = new System.Drawing.Point(7, 28);
            this.usb_en_cb.Margin = new System.Windows.Forms.Padding(4);
            this.usb_en_cb.Name = "usb_en_cb";
            this.usb_en_cb.Size = new System.Drawing.Size(61, 24);
            this.usb_en_cb.TabIndex = 286;
            this.usb_en_cb.Text = "USB";
            this.usb_en_cb.UseVisualStyleBackColor = true;
            this.usb_en_cb.CheckedChanged += new System.EventHandler(this.usb_en_cb_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.grav_corr_btn);
            this.groupBox8.Controls.Add(this.grav_corr_en_cb);
            this.groupBox8.Controls.Add(this.filter_conf_pb);
            this.groupBox8.Location = new System.Drawing.Point(13, 325);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(229, 108);
            this.groupBox8.TabIndex = 290;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "姿勢推定の設定";
            // 
            // grav_corr_btn
            // 
            this.grav_corr_btn.Location = new System.Drawing.Point(7, 60);
            this.grav_corr_btn.Margin = new System.Windows.Forms.Padding(4);
            this.grav_corr_btn.Name = "grav_corr_btn";
            this.grav_corr_btn.Size = new System.Drawing.Size(79, 40);
            this.grav_corr_btn.TabIndex = 289;
            this.grav_corr_btn.Text = "設定";
            this.grav_corr_btn.UseVisualStyleBackColor = true;
            this.grav_corr_btn.Click += new System.EventHandler(this.grav_corr_btn_Click);
            // 
            // grav_corr_en_cb
            // 
            this.grav_corr_en_cb.AutoSize = true;
            this.grav_corr_en_cb.Checked = true;
            this.grav_corr_en_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.grav_corr_en_cb.Location = new System.Drawing.Point(7, 28);
            this.grav_corr_en_cb.Margin = new System.Windows.Forms.Padding(4);
            this.grav_corr_en_cb.Name = "grav_corr_en_cb";
            this.grav_corr_en_cb.Size = new System.Drawing.Size(92, 24);
            this.grav_corr_en_cb.TabIndex = 286;
            this.grav_corr_en_cb.Text = "重力補正";
            this.grav_corr_en_cb.UseVisualStyleBackColor = true;
            this.grav_corr_en_cb.CheckedChanged += new System.EventHandler(this.grav_corr_en_cb_CheckedChanged);
            // 
            // filter_conf_pb
            // 
            this.filter_conf_pb.BackColor = System.Drawing.Color.Transparent;
            this.filter_conf_pb.Image = global::IMU_PlatformTool2.Properties.Resources.info;
            this.filter_conf_pb.Location = new System.Drawing.Point(179, 60);
            this.filter_conf_pb.Margin = new System.Windows.Forms.Padding(4);
            this.filter_conf_pb.Name = "filter_conf_pb";
            this.filter_conf_pb.Size = new System.Drawing.Size(40, 40);
            this.filter_conf_pb.TabIndex = 289;
            this.filter_conf_pb.UseVisualStyleBackColor = false;
            this.filter_conf_pb.Click += new System.EventHandler(this.filter_conf_pb_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1162, 524);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "接続設定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.tcp_conf_gbox);
            this.panel3.Controls.Add(this.config_reset_btn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1156, 518);
            this.panel3.TabIndex = 0;
            // 
            // tcp_conf_gbox
            // 
            this.tcp_conf_gbox.Controls.Add(this.label38);
            this.tcp_conf_gbox.Controls.Add(this.find_btn);
            this.tcp_conf_gbox.Controls.Add(this.label36);
            this.tcp_conf_gbox.Controls.Add(this.flowLayoutPanel5);
            this.tcp_conf_gbox.Controls.Add(this.tcp_apply_btn);
            this.tcp_conf_gbox.Controls.Add(this.w55rp20_cbox);
            this.tcp_conf_gbox.Controls.Add(this.ip_addr_tb);
            this.tcp_conf_gbox.Controls.Add(this.port_tb);
            this.tcp_conf_gbox.Location = new System.Drawing.Point(4, 4);
            this.tcp_conf_gbox.Margin = new System.Windows.Forms.Padding(4);
            this.tcp_conf_gbox.Name = "tcp_conf_gbox";
            this.tcp_conf_gbox.Padding = new System.Windows.Forms.Padding(4);
            this.tcp_conf_gbox.Size = new System.Drawing.Size(1140, 132);
            this.tcp_conf_gbox.TabIndex = 294;
            this.tcp_conf_gbox.TabStop = false;
            this.tcp_conf_gbox.Text = "TCPクライアント接続設定";
            // 
            // label38
            // 
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(709, 60);
            this.label38.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(116, 28);
            this.label38.TabIndex = 298;
            this.label38.Text = "PORT：";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // find_btn
            // 
            this.find_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.find_btn.Location = new System.Drawing.Point(9, 29);
            this.find_btn.Margin = new System.Windows.Forms.Padding(4);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(130, 39);
            this.find_btn.TabIndex = 291;
            this.find_btn.Text = "W55RP20探索";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // label36
            // 
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(722, 28);
            this.label36.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(103, 28);
            this.label36.TabIndex = 296;
            this.label36.Text = "IP：";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.manual_input_cb);
            this.flowLayoutPanel5.Controls.Add(this.splitter3);
            this.flowLayoutPanel5.Controls.Add(this.manual_input_panel);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(52, 76);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(536, 46);
            this.flowLayoutPanel5.TabIndex = 322;
            // 
            // manual_input_cb
            // 
            this.manual_input_cb.Location = new System.Drawing.Point(3, 7);
            this.manual_input_cb.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.manual_input_cb.Name = "manual_input_cb";
            this.manual_input_cb.Size = new System.Drawing.Size(84, 28);
            this.manual_input_cb.TabIndex = 321;
            this.manual_input_cb.Text = "手入力";
            this.manual_input_cb.UseVisualStyleBackColor = true;
            this.manual_input_cb.CheckedChanged += new System.EventHandler(this.manual_input_cb_CheckedChanged);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(93, 3);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 39);
            this.splitter3.TabIndex = 322;
            this.splitter3.TabStop = false;
            // 
            // manual_input_panel
            // 
            this.manual_input_panel.Controls.Add(this.label37);
            this.manual_input_panel.Controls.Add(this.input_ip_tb);
            this.manual_input_panel.Controls.Add(this.label39);
            this.manual_input_panel.Controls.Add(this.input_port_tb);
            this.manual_input_panel.Enabled = false;
            this.manual_input_panel.Location = new System.Drawing.Point(102, 3);
            this.manual_input_panel.Name = "manual_input_panel";
            this.manual_input_panel.Size = new System.Drawing.Size(422, 39);
            this.manual_input_panel.TabIndex = 296;
            // 
            // label37
            // 
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(1, 3);
            this.label37.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(103, 28);
            this.label37.TabIndex = 292;
            this.label37.Text = "IP(入力可)：";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_ip_tb
            // 
            this.input_ip_tb.Location = new System.Drawing.Point(106, 3);
            this.input_ip_tb.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.input_ip_tb.Name = "input_ip_tb";
            this.input_ip_tb.Size = new System.Drawing.Size(137, 28);
            this.input_ip_tb.TabIndex = 297;
            this.input_ip_tb.Text = "192.168.0.1";
            // 
            // label39
            // 
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(245, 3);
            this.label39.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(68, 28);
            this.label39.TabIndex = 294;
            this.label39.Text = "PORT：";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_port_tb
            // 
            this.input_port_tb.Location = new System.Drawing.Point(315, 3);
            this.input_port_tb.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.input_port_tb.Name = "input_port_tb";
            this.input_port_tb.Size = new System.Drawing.Size(97, 28);
            this.input_port_tb.TabIndex = 299;
            this.input_port_tb.Text = "5000";
            // 
            // tcp_apply_btn
            // 
            this.tcp_apply_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tcp_apply_btn.Location = new System.Drawing.Point(595, 29);
            this.tcp_apply_btn.Margin = new System.Windows.Forms.Padding(4);
            this.tcp_apply_btn.Name = "tcp_apply_btn";
            this.tcp_apply_btn.Size = new System.Drawing.Size(88, 81);
            this.tcp_apply_btn.TabIndex = 320;
            this.tcp_apply_btn.Text = "設定⇒";
            this.tcp_apply_btn.UseVisualStyleBackColor = true;
            this.tcp_apply_btn.Click += new System.EventHandler(this.tcp_apply_btn_Click);
            // 
            // w55rp20_cbox
            // 
            this.w55rp20_cbox.FormattingEnabled = true;
            this.w55rp20_cbox.Location = new System.Drawing.Point(145, 35);
            this.w55rp20_cbox.Margin = new System.Windows.Forms.Padding(4);
            this.w55rp20_cbox.Name = "w55rp20_cbox";
            this.w55rp20_cbox.Size = new System.Drawing.Size(443, 28);
            this.w55rp20_cbox.TabIndex = 228;
            // 
            // ip_addr_tb
            // 
            this.ip_addr_tb.BackColor = System.Drawing.Color.White;
            this.ip_addr_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ip_addr_tb.Location = new System.Drawing.Point(830, 28);
            this.ip_addr_tb.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.ip_addr_tb.Name = "ip_addr_tb";
            this.ip_addr_tb.ReadOnly = true;
            this.ip_addr_tb.Size = new System.Drawing.Size(306, 28);
            this.ip_addr_tb.TabIndex = 293;
            this.ip_addr_tb.Text = "192.168.0.1";
            this.ip_addr_tb.TextChanged += new System.EventHandler(this.ip_addr_tb_TextChanged);
            // 
            // port_tb
            // 
            this.port_tb.BackColor = System.Drawing.Color.White;
            this.port_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.port_tb.Location = new System.Drawing.Point(830, 60);
            this.port_tb.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.port_tb.Name = "port_tb";
            this.port_tb.ReadOnly = true;
            this.port_tb.Size = new System.Drawing.Size(306, 28);
            this.port_tb.TabIndex = 295;
            this.port_tb.Text = "5000";
            this.port_tb.TextChanged += new System.EventHandler(this.ip_addr_tb_TextChanged);
            // 
            // config_reset_btn
            // 
            this.config_reset_btn.Location = new System.Drawing.Point(4, 475);
            this.config_reset_btn.Margin = new System.Windows.Forms.Padding(4);
            this.config_reset_btn.Name = "config_reset_btn";
            this.config_reset_btn.Size = new System.Drawing.Size(205, 39);
            this.config_reset_btn.TabIndex = 282;
            this.config_reset_btn.Text = "アプリ設定の初期化";
            this.config_reset_btn.UseVisualStyleBackColor = true;
            this.config_reset_btn.Click += new System.EventHandler(this.config_reset_btn_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.update_info);
            this.tabPage4.Controls.Add(this.cli_tb);
            this.tabPage4.Controls.Add(this.flowLayoutPanel12);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1162, 524);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "アップデート";
            // 
            // update_info
            // 
            this.update_info.BackColor = System.Drawing.Color.Transparent;
            this.update_info.Location = new System.Drawing.Point(556, 9);
            this.update_info.Margin = new System.Windows.Forms.Padding(4);
            this.update_info.Name = "update_info";
            this.update_info.Size = new System.Drawing.Size(241, 40);
            this.update_info.TabIndex = 296;
            this.update_info.Text = "ファームウェアアップデート説明書";
            this.update_info.UseVisualStyleBackColor = false;
            this.update_info.Click += new System.EventHandler(this.update_info_Click);
            // 
            // cli_tb
            // 
            this.cli_tb.Location = new System.Drawing.Point(556, 56);
            this.cli_tb.Multiline = true;
            this.cli_tb.Name = "cli_tb";
            this.cli_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cli_tb.Size = new System.Drawing.Size(593, 465);
            this.cli_tb.TabIndex = 295;
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.Controls.Add(this.groupBox3);
            this.flowLayoutPanel12.Controls.Add(this.dfu_gbox);
            this.flowLayoutPanel12.Controls.Add(this.groupBox5);
            this.flowLayoutPanel12.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel12.Location = new System.Drawing.Point(5, 3);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(545, 471);
            this.flowLayoutPanel12.TabIndex = 294;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel13);
            this.groupBox3.Controls.Add(this.flowLayoutPanel14);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 166);
            this.groupBox3.TabIndex = 298;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手順１";
            // 
            // flowLayoutPanel13
            // 
            this.flowLayoutPanel13.Controls.Add(this.label15);
            this.flowLayoutPanel13.Controls.Add(this.stm32_prog_cli_path_tb);
            this.flowLayoutPanel13.Controls.Add(this.stm32_prog_cli_path_btn);
            this.flowLayoutPanel13.Location = new System.Drawing.Point(6, 27);
            this.flowLayoutPanel13.Name = "flowLayoutPanel13";
            this.flowLayoutPanel13.Size = new System.Drawing.Size(528, 59);
            this.flowLayoutPanel13.TabIndex = 295;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 3);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(279, 20);
            this.label15.TabIndex = 294;
            this.label15.Text = "STM32_Programmer_CLI.exeのパス";
            // 
            // stm32_prog_cli_path_tb
            // 
            this.stm32_prog_cli_path_tb.Location = new System.Drawing.Point(3, 26);
            this.stm32_prog_cli_path_tb.Name = "stm32_prog_cli_path_tb";
            this.stm32_prog_cli_path_tb.ReadOnly = true;
            this.stm32_prog_cli_path_tb.Size = new System.Drawing.Size(464, 28);
            this.stm32_prog_cli_path_tb.TabIndex = 0;
            // 
            // stm32_prog_cli_path_btn
            // 
            this.stm32_prog_cli_path_btn.Location = new System.Drawing.Point(474, 27);
            this.stm32_prog_cli_path_btn.Margin = new System.Windows.Forms.Padding(4);
            this.stm32_prog_cli_path_btn.Name = "stm32_prog_cli_path_btn";
            this.stm32_prog_cli_path_btn.Size = new System.Drawing.Size(41, 23);
            this.stm32_prog_cli_path_btn.TabIndex = 295;
            this.stm32_prog_cli_path_btn.Text = "・・・";
            this.stm32_prog_cli_path_btn.UseVisualStyleBackColor = true;
            this.stm32_prog_cli_path_btn.Click += new System.EventHandler(this.stm32_prog_cli_path_btn_Click);
            // 
            // flowLayoutPanel14
            // 
            this.flowLayoutPanel14.Controls.Add(this.label16);
            this.flowLayoutPanel14.Controls.Add(this.firmware_path_tb);
            this.flowLayoutPanel14.Controls.Add(this.firmware_path_btn);
            this.flowLayoutPanel14.Location = new System.Drawing.Point(6, 92);
            this.flowLayoutPanel14.Name = "flowLayoutPanel14";
            this.flowLayoutPanel14.Size = new System.Drawing.Size(528, 59);
            this.flowLayoutPanel14.TabIndex = 296;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 3);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(317, 20);
            this.label16.TabIndex = 294;
            this.label16.Text = "書き込むファームウェアのパス　　　　　　　　　　　　";
            // 
            // firmware_path_tb
            // 
            this.firmware_path_tb.Location = new System.Drawing.Point(3, 26);
            this.firmware_path_tb.Name = "firmware_path_tb";
            this.firmware_path_tb.ReadOnly = true;
            this.firmware_path_tb.Size = new System.Drawing.Size(464, 28);
            this.firmware_path_tb.TabIndex = 0;
            // 
            // firmware_path_btn
            // 
            this.firmware_path_btn.Location = new System.Drawing.Point(474, 27);
            this.firmware_path_btn.Margin = new System.Windows.Forms.Padding(4);
            this.firmware_path_btn.Name = "firmware_path_btn";
            this.firmware_path_btn.Size = new System.Drawing.Size(41, 23);
            this.firmware_path_btn.TabIndex = 295;
            this.firmware_path_btn.Text = "・・・";
            this.firmware_path_btn.UseVisualStyleBackColor = true;
            this.firmware_path_btn.Click += new System.EventHandler(this.firmware_path_btn_Click);
            // 
            // dfu_gbox
            // 
            this.dfu_gbox.Controls.Add(this.jump_dfu_btn);
            this.dfu_gbox.Enabled = false;
            this.dfu_gbox.Location = new System.Drawing.Point(3, 175);
            this.dfu_gbox.Name = "dfu_gbox";
            this.dfu_gbox.Size = new System.Drawing.Size(540, 91);
            this.dfu_gbox.TabIndex = 297;
            this.dfu_gbox.TabStop = false;
            this.dfu_gbox.Text = "手順２";
            // 
            // jump_dfu_btn
            // 
            this.jump_dfu_btn.Location = new System.Drawing.Point(7, 28);
            this.jump_dfu_btn.Margin = new System.Windows.Forms.Padding(4);
            this.jump_dfu_btn.Name = "jump_dfu_btn";
            this.jump_dfu_btn.Size = new System.Drawing.Size(514, 48);
            this.jump_dfu_btn.TabIndex = 286;
            this.jump_dfu_btn.Text = "マイコンを書き込みモードにする(USB DFU)";
            this.jump_dfu_btn.UseVisualStyleBackColor = true;
            this.jump_dfu_btn.Click += new System.EventHandler(this.jump_dfu_btn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.check_dfu_btn);
            this.groupBox5.Controls.Add(this.firmware_write_btn);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(3, 272);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(540, 187);
            this.groupBox5.TabIndex = 299;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "手順３";
            // 
            // check_dfu_btn
            // 
            this.check_dfu_btn.Location = new System.Drawing.Point(9, 132);
            this.check_dfu_btn.Margin = new System.Windows.Forms.Padding(4);
            this.check_dfu_btn.Name = "check_dfu_btn";
            this.check_dfu_btn.Size = new System.Drawing.Size(142, 48);
            this.check_dfu_btn.TabIndex = 291;
            this.check_dfu_btn.Text = "接続チェック";
            this.check_dfu_btn.UseVisualStyleBackColor = true;
            this.check_dfu_btn.Click += new System.EventHandler(this.check_dfu_btn_Click);
            // 
            // firmware_write_btn
            // 
            this.firmware_write_btn.Enabled = false;
            this.firmware_write_btn.Location = new System.Drawing.Point(159, 132);
            this.firmware_write_btn.Margin = new System.Windows.Forms.Padding(4);
            this.firmware_write_btn.Name = "firmware_write_btn";
            this.firmware_write_btn.Size = new System.Drawing.Size(362, 48);
            this.firmware_write_btn.TabIndex = 289;
            this.firmware_write_btn.Text = "USB DFUへ書込み開始";
            this.firmware_write_btn.UseVisualStyleBackColor = true;
            this.firmware_write_btn.Click += new System.EventHandler(this.firmware_write_btn_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(422, 100);
            this.label17.TabIndex = 290;
            this.label17.Text = "【注意点】\r\n・設定は全て初期値に戻ります\r\n・拡張子が\".hex\"、\".bin\"のファイルは全て書き込めてしまいます。\r\n・書き込む前に必ず正しいファイルである" +
    "か確認してください。\r\n・書き込みには STM32CubeProgのインストールが必須です。";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.panel4);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1162, 524);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "CSV保存";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flowLayoutPanel39);
            this.panel4.Controls.Add(this.csv_save_config_panel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1156, 518);
            this.panel4.TabIndex = 326;
            // 
            // flowLayoutPanel39
            // 
            this.flowLayoutPanel39.Controls.Add(this.csv_record_btn);
            this.flowLayoutPanel39.Controls.Add(this.flowLayoutPanel41);
            this.flowLayoutPanel39.Controls.Add(this.flowLayoutPanel42);
            this.flowLayoutPanel39.Controls.Add(this.flowLayoutPanel43);
            this.flowLayoutPanel39.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel39.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel39.Name = "flowLayoutPanel39";
            this.flowLayoutPanel39.Size = new System.Drawing.Size(454, 161);
            this.flowLayoutPanel39.TabIndex = 0;
            // 
            // csv_record_btn
            // 
            this.csv_record_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.csv_record_btn.Location = new System.Drawing.Point(4, 4);
            this.csv_record_btn.Margin = new System.Windows.Forms.Padding(4);
            this.csv_record_btn.Name = "csv_record_btn";
            this.csv_record_btn.Size = new System.Drawing.Size(113, 40);
            this.csv_record_btn.TabIndex = 230;
            this.csv_record_btn.Text = "記録開始";
            this.csv_record_btn.UseVisualStyleBackColor = true;
            this.csv_record_btn.Click += new System.EventHandler(this.csv_record_btn_Click);
            // 
            // flowLayoutPanel41
            // 
            this.flowLayoutPanel41.Controls.Add(this.label42);
            this.flowLayoutPanel41.Controls.Add(this.csv_save_status_lb);
            this.flowLayoutPanel41.Location = new System.Drawing.Point(1, 49);
            this.flowLayoutPanel41.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel41.Name = "flowLayoutPanel41";
            this.flowLayoutPanel41.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel41.TabIndex = 320;
            // 
            // label42
            // 
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(3, 1);
            this.label42.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(100, 28);
            this.label42.TabIndex = 317;
            this.label42.Text = "状態：";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // csv_save_status_lb
            // 
            this.csv_save_status_lb.BackColor = System.Drawing.SystemColors.Control;
            this.csv_save_status_lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.csv_save_status_lb.Location = new System.Drawing.Point(105, 5);
            this.csv_save_status_lb.Margin = new System.Windows.Forms.Padding(1, 5, 0, 0);
            this.csv_save_status_lb.Name = "csv_save_status_lb";
            this.csv_save_status_lb.ReadOnly = true;
            this.csv_save_status_lb.Size = new System.Drawing.Size(165, 21);
            this.csv_save_status_lb.TabIndex = 318;
            this.csv_save_status_lb.Text = "待機中";
            // 
            // flowLayoutPanel42
            // 
            this.flowLayoutPanel42.Controls.Add(this.label43);
            this.flowLayoutPanel42.Controls.Add(this.csv_record_time_lb);
            this.flowLayoutPanel42.Location = new System.Drawing.Point(1, 81);
            this.flowLayoutPanel42.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel42.Name = "flowLayoutPanel42";
            this.flowLayoutPanel42.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel42.TabIndex = 321;
            // 
            // label43
            // 
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(3, 1);
            this.label43.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(100, 28);
            this.label43.TabIndex = 317;
            this.label43.Text = "時間：";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // csv_record_time_lb
            // 
            this.csv_record_time_lb.BackColor = System.Drawing.SystemColors.Control;
            this.csv_record_time_lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.csv_record_time_lb.Location = new System.Drawing.Point(105, 5);
            this.csv_record_time_lb.Margin = new System.Windows.Forms.Padding(1, 5, 0, 0);
            this.csv_record_time_lb.Name = "csv_record_time_lb";
            this.csv_record_time_lb.ReadOnly = true;
            this.csv_record_time_lb.Size = new System.Drawing.Size(165, 21);
            this.csv_record_time_lb.TabIndex = 318;
            this.csv_record_time_lb.Text = "00:00:00";
            // 
            // flowLayoutPanel43
            // 
            this.flowLayoutPanel43.Controls.Add(this.label44);
            this.flowLayoutPanel43.Controls.Add(this.csv_record_sample_lb);
            this.flowLayoutPanel43.Location = new System.Drawing.Point(1, 113);
            this.flowLayoutPanel43.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel43.Name = "flowLayoutPanel43";
            this.flowLayoutPanel43.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel43.TabIndex = 322;
            // 
            // label44
            // 
            this.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label44.Location = new System.Drawing.Point(3, 1);
            this.label44.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(100, 28);
            this.label44.TabIndex = 317;
            this.label44.Text = "サンプル数：";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // csv_record_sample_lb
            // 
            this.csv_record_sample_lb.BackColor = System.Drawing.SystemColors.Control;
            this.csv_record_sample_lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.csv_record_sample_lb.Location = new System.Drawing.Point(105, 5);
            this.csv_record_sample_lb.Margin = new System.Windows.Forms.Padding(1, 5, 0, 0);
            this.csv_record_sample_lb.Name = "csv_record_sample_lb";
            this.csv_record_sample_lb.ReadOnly = true;
            this.csv_record_sample_lb.Size = new System.Drawing.Size(165, 21);
            this.csv_record_sample_lb.TabIndex = 318;
            this.csv_record_sample_lb.Text = "0";
            // 
            // csv_save_config_panel
            // 
            this.csv_save_config_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.csv_save_config_panel.Controls.Add(this.panel5);
            this.csv_save_config_panel.Controls.Add(this.csv_pose_format_gbox);
            this.csv_save_config_panel.Controls.Add(this.flowLayoutPanel49);
            this.csv_save_config_panel.Controls.Add(this.flowLayoutPanel47);
            this.csv_save_config_panel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.csv_save_config_panel.Location = new System.Drawing.Point(0, 307);
            this.csv_save_config_panel.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.csv_save_config_panel.Name = "csv_save_config_panel";
            this.csv_save_config_panel.Size = new System.Drawing.Size(1154, 211);
            this.csv_save_config_panel.TabIndex = 325;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label47);
            this.panel5.Controls.Add(this.csv_save_path_tb);
            this.panel5.Controls.Add(this.path_init_btn);
            this.panel5.Controls.Add(this.csv_save_path_btn);
            this.panel5.Controls.Add(this.file_directory_btn);
            this.panel5.Location = new System.Drawing.Point(3, 146);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1150, 62);
            this.panel5.TabIndex = 339;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(4, 3);
            this.label47.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(178, 20);
            this.label47.TabIndex = 294;
            this.label47.Text = "保存先　　　　　　　　　　　";
            // 
            // csv_save_path_tb
            // 
            this.csv_save_path_tb.Location = new System.Drawing.Point(3, 26);
            this.csv_save_path_tb.Name = "csv_save_path_tb";
            this.csv_save_path_tb.ReadOnly = true;
            this.csv_save_path_tb.Size = new System.Drawing.Size(464, 28);
            this.csv_save_path_tb.TabIndex = 0;
            // 
            // path_init_btn
            // 
            this.path_init_btn.Location = new System.Drawing.Point(936, 26);
            this.path_init_btn.Margin = new System.Windows.Forms.Padding(4);
            this.path_init_btn.Name = "path_init_btn";
            this.path_init_btn.Size = new System.Drawing.Size(210, 32);
            this.path_init_btn.TabIndex = 338;
            this.path_init_btn.Text = "保存先の設定を初期化";
            this.path_init_btn.UseVisualStyleBackColor = true;
            this.path_init_btn.Click += new System.EventHandler(this.path_init_btn_Click);
            // 
            // csv_save_path_btn
            // 
            this.csv_save_path_btn.Location = new System.Drawing.Point(474, 24);
            this.csv_save_path_btn.Margin = new System.Windows.Forms.Padding(4);
            this.csv_save_path_btn.Name = "csv_save_path_btn";
            this.csv_save_path_btn.Size = new System.Drawing.Size(60, 31);
            this.csv_save_path_btn.TabIndex = 295;
            this.csv_save_path_btn.Text = "設定";
            this.csv_save_path_btn.UseVisualStyleBackColor = true;
            this.csv_save_path_btn.Click += new System.EventHandler(this.csv_save_path_btn_Click);
            // 
            // file_directory_btn
            // 
            this.file_directory_btn.Location = new System.Drawing.Point(542, 24);
            this.file_directory_btn.Margin = new System.Windows.Forms.Padding(4);
            this.file_directory_btn.Name = "file_directory_btn";
            this.file_directory_btn.Size = new System.Drawing.Size(159, 31);
            this.file_directory_btn.TabIndex = 295;
            this.file_directory_btn.Text = "エクスプローラで開く";
            this.file_directory_btn.UseVisualStyleBackColor = true;
            this.file_directory_btn.Click += new System.EventHandler(this.file_directory_btn_Click);
            // 
            // csv_pose_format_gbox
            // 
            this.csv_pose_format_gbox.Controls.Add(this.euler_rbtn);
            this.csv_pose_format_gbox.Controls.Add(this.quat_rbtn);
            this.csv_pose_format_gbox.Location = new System.Drawing.Point(3, 77);
            this.csv_pose_format_gbox.Name = "csv_pose_format_gbox";
            this.csv_pose_format_gbox.Size = new System.Drawing.Size(464, 63);
            this.csv_pose_format_gbox.TabIndex = 329;
            this.csv_pose_format_gbox.TabStop = false;
            this.csv_pose_format_gbox.Text = "CSVに書き込む姿勢の形式";
            // 
            // euler_rbtn
            // 
            this.euler_rbtn.AutoSize = true;
            this.euler_rbtn.Location = new System.Drawing.Point(217, 27);
            this.euler_rbtn.Name = "euler_rbtn";
            this.euler_rbtn.Size = new System.Drawing.Size(145, 24);
            this.euler_rbtn.TabIndex = 0;
            this.euler_rbtn.Text = "オイラー角(Euler)";
            this.euler_rbtn.UseVisualStyleBackColor = true;
            // 
            // quat_rbtn
            // 
            this.quat_rbtn.AutoSize = true;
            this.quat_rbtn.Checked = true;
            this.quat_rbtn.Location = new System.Drawing.Point(6, 27);
            this.quat_rbtn.Name = "quat_rbtn";
            this.quat_rbtn.Size = new System.Drawing.Size(176, 24);
            this.quat_rbtn.TabIndex = 0;
            this.quat_rbtn.TabStop = true;
            this.quat_rbtn.Text = "四元数(Quaternion)";
            this.quat_rbtn.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel49
            // 
            this.flowLayoutPanel49.Controls.Add(this.label45);
            this.flowLayoutPanel49.Controls.Add(this.csv_timelimit_cbox);
            this.flowLayoutPanel49.Location = new System.Drawing.Point(0, 43);
            this.flowLayoutPanel49.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.flowLayoutPanel49.Name = "flowLayoutPanel49";
            this.flowLayoutPanel49.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel49.TabIndex = 327;
            // 
            // label45
            // 
            this.label45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label45.Location = new System.Drawing.Point(3, 1);
            this.label45.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(100, 28);
            this.label45.TabIndex = 318;
            this.label45.Text = "時間上限：";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // csv_timelimit_cbox
            // 
            this.csv_timelimit_cbox.FormattingEnabled = true;
            this.csv_timelimit_cbox.Items.AddRange(new object[] {
            "1分",
            "5分",
            "10分",
            "30分",
            "1時間",
            "24時間"});
            this.csv_timelimit_cbox.Location = new System.Drawing.Point(105, 1);
            this.csv_timelimit_cbox.Margin = new System.Windows.Forms.Padding(1);
            this.csv_timelimit_cbox.Name = "csv_timelimit_cbox";
            this.csv_timelimit_cbox.Size = new System.Drawing.Size(110, 28);
            this.csv_timelimit_cbox.TabIndex = 327;
            // 
            // flowLayoutPanel47
            // 
            this.flowLayoutPanel47.Controls.Add(this.label46);
            this.flowLayoutPanel47.Controls.Add(this.csv_prescaler_cbox);
            this.flowLayoutPanel47.Location = new System.Drawing.Point(0, 11);
            this.flowLayoutPanel47.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.flowLayoutPanel47.Name = "flowLayoutPanel47";
            this.flowLayoutPanel47.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel47.TabIndex = 326;
            // 
            // label46
            // 
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(3, 1);
            this.label46.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(100, 28);
            this.label46.TabIndex = 318;
            this.label46.Text = "記録レート：";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // csv_prescaler_cbox
            // 
            this.csv_prescaler_cbox.FormattingEnabled = true;
            this.csv_prescaler_cbox.Items.AddRange(new object[] {
            "1000Hz",
            "500Hz",
            "200Hz",
            "100Hz",
            "50Hz",
            "1Hz"});
            this.csv_prescaler_cbox.Location = new System.Drawing.Point(105, 1);
            this.csv_prescaler_cbox.Margin = new System.Windows.Forms.Padding(1);
            this.csv_prescaler_cbox.Name = "csv_prescaler_cbox";
            this.csv_prescaler_cbox.Size = new System.Drawing.Size(110, 28);
            this.csv_prescaler_cbox.TabIndex = 327;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.battery_warning_tb);
            this.tabPage6.Controls.Add(this.version_lb);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1162, 524);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "About";
            // 
            // battery_warning_tb
            // 
            this.battery_warning_tb.BackColor = System.Drawing.SystemColors.Control;
            this.battery_warning_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battery_warning_tb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.battery_warning_tb.Location = new System.Drawing.Point(4, 4);
            this.battery_warning_tb.Margin = new System.Windows.Forms.Padding(1);
            this.battery_warning_tb.Multiline = true;
            this.battery_warning_tb.Name = "battery_warning_tb";
            this.battery_warning_tb.ReadOnly = true;
            this.battery_warning_tb.Size = new System.Drawing.Size(1153, 153);
            this.battery_warning_tb.TabIndex = 332;
            this.battery_warning_tb.Text = "VQF-C: A Lightweight Implementation of VQF for Embedded Devices\r\nhttps://github.c" +
    "om/DusKing1/vqf-c";
            // 
            // version_lb
            // 
            this.version_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version_lb.Location = new System.Drawing.Point(7, 373);
            this.version_lb.Margin = new System.Windows.Forms.Padding(4);
            this.version_lb.Name = "version_lb";
            this.version_lb.Size = new System.Drawing.Size(503, 144);
            this.version_lb.TabIndex = 331;
            this.version_lb.Text = " ";
            this.version_lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // comm_sel_gbox
            // 
            this.comm_sel_gbox.Controls.Add(this.serial_rbtn);
            this.comm_sel_gbox.Controls.Add(this.tcp_rbtn);
            this.comm_sel_gbox.Location = new System.Drawing.Point(10, 5);
            this.comm_sel_gbox.Margin = new System.Windows.Forms.Padding(4);
            this.comm_sel_gbox.Name = "comm_sel_gbox";
            this.comm_sel_gbox.Padding = new System.Windows.Forms.Padding(4);
            this.comm_sel_gbox.Size = new System.Drawing.Size(140, 84);
            this.comm_sel_gbox.TabIndex = 290;
            this.comm_sel_gbox.TabStop = false;
            this.comm_sel_gbox.Text = "通信方式の選択";
            // 
            // serial_rbtn
            // 
            this.serial_rbtn.Checked = true;
            this.serial_rbtn.Location = new System.Drawing.Point(8, 24);
            this.serial_rbtn.Margin = new System.Windows.Forms.Padding(4);
            this.serial_rbtn.Name = "serial_rbtn";
            this.serial_rbtn.Size = new System.Drawing.Size(102, 24);
            this.serial_rbtn.TabIndex = 0;
            this.serial_rbtn.TabStop = true;
            this.serial_rbtn.Text = "Serial";
            this.serial_rbtn.UseVisualStyleBackColor = true;
            this.serial_rbtn.CheckedChanged += new System.EventHandler(this.CommModeRadio_CheckedChanged);
            // 
            // tcp_rbtn
            // 
            this.tcp_rbtn.Location = new System.Drawing.Point(8, 54);
            this.tcp_rbtn.Margin = new System.Windows.Forms.Padding(4);
            this.tcp_rbtn.Name = "tcp_rbtn";
            this.tcp_rbtn.Size = new System.Drawing.Size(102, 24);
            this.tcp_rbtn.TabIndex = 1;
            this.tcp_rbtn.Text = "TCP";
            this.tcp_rbtn.UseVisualStyleBackColor = true;
            this.tcp_rbtn.CheckedChanged += new System.EventHandler(this.CommModeRadio_CheckedChanged);
            // 
            // usb_gbox
            // 
            this.usb_gbox.Controls.Add(this.label8);
            this.usb_gbox.Controls.Add(this.comGimPort);
            this.usb_gbox.Controls.Add(this.serial_connect_btn);
            this.usb_gbox.Controls.Add(this.label7);
            this.usb_gbox.Controls.Add(this.StatusLabel);
            this.usb_gbox.Controls.Add(this.ComPortNameLabel);
            this.usb_gbox.Location = new System.Drawing.Point(158, 5);
            this.usb_gbox.Margin = new System.Windows.Forms.Padding(4);
            this.usb_gbox.Name = "usb_gbox";
            this.usb_gbox.Padding = new System.Windows.Forms.Padding(4);
            this.usb_gbox.Size = new System.Drawing.Size(1014, 84);
            this.usb_gbox.TabIndex = 291;
            this.usb_gbox.TabStop = false;
            this.usb_gbox.Text = "USB接続設定";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(208, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 233;
            this.label8.Text = "機器情報：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcp_gbox
            // 
            this.tcp_gbox.Controls.Add(this.tcp_port_watch_lb);
            this.tcp_gbox.Controls.Add(this.label11);
            this.tcp_gbox.Controls.Add(this.tcp_ip_watch_lb);
            this.tcp_gbox.Controls.Add(this.label9);
            this.tcp_gbox.Controls.Add(this.tcp_connect_btn);
            this.tcp_gbox.Controls.Add(this.label10);
            this.tcp_gbox.Controls.Add(this.tcp_status_lb);
            this.tcp_gbox.Location = new System.Drawing.Point(155, 5);
            this.tcp_gbox.Margin = new System.Windows.Forms.Padding(4);
            this.tcp_gbox.Name = "tcp_gbox";
            this.tcp_gbox.Padding = new System.Windows.Forms.Padding(4);
            this.tcp_gbox.Size = new System.Drawing.Size(1016, 84);
            this.tcp_gbox.TabIndex = 291;
            this.tcp_gbox.TabStop = false;
            this.tcp_gbox.Text = "TCPステータス";
            this.tcp_gbox.Visible = false;
            // 
            // tcp_port_watch_lb
            // 
            this.tcp_port_watch_lb.Location = new System.Drawing.Point(536, 47);
            this.tcp_port_watch_lb.Margin = new System.Windows.Forms.Padding(0);
            this.tcp_port_watch_lb.Name = "tcp_port_watch_lb";
            this.tcp_port_watch_lb.ReadOnly = true;
            this.tcp_port_watch_lb.Size = new System.Drawing.Size(96, 28);
            this.tcp_port_watch_lb.TabIndex = 295;
            this.tcp_port_watch_lb.Text = "5000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(460, 50);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 294;
            this.label11.Text = "PORT：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcp_ip_watch_lb
            // 
            this.tcp_ip_watch_lb.Location = new System.Drawing.Point(271, 47);
            this.tcp_ip_watch_lb.Margin = new System.Windows.Forms.Padding(0);
            this.tcp_ip_watch_lb.Name = "tcp_ip_watch_lb";
            this.tcp_ip_watch_lb.ReadOnly = true;
            this.tcp_ip_watch_lb.Size = new System.Drawing.Size(177, 28);
            this.tcp_ip_watch_lb.TabIndex = 293;
            this.tcp_ip_watch_lb.Text = "192.168.0.1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(222, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 292;
            this.label9.Text = "IP：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcp_connect_btn
            // 
            this.tcp_connect_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tcp_connect_btn.Location = new System.Drawing.Point(20, 29);
            this.tcp_connect_btn.Margin = new System.Windows.Forms.Padding(4);
            this.tcp_connect_btn.Name = "tcp_connect_btn";
            this.tcp_connect_btn.Size = new System.Drawing.Size(113, 40);
            this.tcp_connect_btn.TabIndex = 229;
            this.tcp_connect_btn.Text = "接続";
            this.tcp_connect_btn.UseVisualStyleBackColor = true;
            this.tcp_connect_btn.Click += new System.EventHandler(this.comm_connect_btn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(178, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 230;
            this.label10.Text = "ステータス：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcp_status_lb
            // 
            this.tcp_status_lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tcp_status_lb.Location = new System.Drawing.Point(267, 16);
            this.tcp_status_lb.Margin = new System.Windows.Forms.Padding(0);
            this.tcp_status_lb.Name = "tcp_status_lb";
            this.tcp_status_lb.Size = new System.Drawing.Size(105, 32);
            this.tcp_status_lb.TabIndex = 231;
            this.tcp_status_lb.Text = "未接続";
            this.tcp_status_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.comm_sel_gbox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.usb_gbox);
            this.Controls.Add(this.tcp_gbox);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "TR-IMU2-Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.flowLayoutPanel15.ResumeLayout(false);
            this.flowLayoutPanel15.PerformLayout();
            this.flowLayoutPanel16.ResumeLayout(false);
            this.flowLayoutPanel16.PerformLayout();
            this.flowLayoutPanel17.ResumeLayout(false);
            this.flowLayoutPanel17.PerformLayout();
            this.flowLayoutPanel18.ResumeLayout(false);
            this.flowLayoutPanel18.PerformLayout();
            this.flowLayoutPanel19.ResumeLayout(false);
            this.flowLayoutPanel19.PerformLayout();
            this.flowLayoutPanel20.ResumeLayout(false);
            this.flowLayoutPanel20.PerformLayout();
            this.flowLayoutPanel21.ResumeLayout(false);
            this.flowLayoutPanel21.PerformLayout();
            this.flowLayoutPanel22.ResumeLayout(false);
            this.flowLayoutPanel22.PerformLayout();
            this.flowLayoutPanel23.ResumeLayout(false);
            this.flowLayoutPanel23.PerformLayout();
            this.flowLayoutPanel24.ResumeLayout(false);
            this.flowLayoutPanel24.PerformLayout();
            this.flowLayoutPanel25.ResumeLayout(false);
            this.flowLayoutPanel25.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel26.ResumeLayout(false);
            this.flowLayoutPanel26.PerformLayout();
            this.flowLayoutPanel27.ResumeLayout(false);
            this.flowLayoutPanel27.PerformLayout();
            this.flowLayoutPanel28.ResumeLayout(false);
            this.flowLayoutPanel28.PerformLayout();
            this.flowLayoutPanel29.ResumeLayout(false);
            this.flowLayoutPanel29.PerformLayout();
            this.flowLayoutPanel30.ResumeLayout(false);
            this.flowLayoutPanel30.PerformLayout();
            this.flowLayoutPanel31.ResumeLayout(false);
            this.flowLayoutPanel31.PerformLayout();
            this.group.ResumeLayout(false);
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel8.ResumeLayout(false);
            this.tabpage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel32.ResumeLayout(false);
            this.flowLayoutPanel33.ResumeLayout(false);
            this.flowLayoutPanel33.PerformLayout();
            this.flowLayoutPanel34.ResumeLayout(false);
            this.flowLayoutPanel34.PerformLayout();
            this.flowLayoutPanel35.ResumeLayout(false);
            this.flowLayoutPanel35.PerformLayout();
            this.flowLayoutPanel36.ResumeLayout(false);
            this.flowLayoutPanel36.PerformLayout();
            this.flowLayoutPanel37.ResumeLayout(false);
            this.flowLayoutPanel37.PerformLayout();
            this.flowLayoutPanel38.ResumeLayout(false);
            this.flowLayoutPanel38.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tcp_conf_gbox.ResumeLayout(false);
            this.tcp_conf_gbox.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.manual_input_panel.ResumeLayout(false);
            this.manual_input_panel.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.flowLayoutPanel12.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel13.ResumeLayout(false);
            this.flowLayoutPanel13.PerformLayout();
            this.flowLayoutPanel14.ResumeLayout(false);
            this.flowLayoutPanel14.PerformLayout();
            this.dfu_gbox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel39.ResumeLayout(false);
            this.flowLayoutPanel41.ResumeLayout(false);
            this.flowLayoutPanel41.PerformLayout();
            this.flowLayoutPanel42.ResumeLayout(false);
            this.flowLayoutPanel42.PerformLayout();
            this.flowLayoutPanel43.ResumeLayout(false);
            this.flowLayoutPanel43.PerformLayout();
            this.csv_save_config_panel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.csv_pose_format_gbox.ResumeLayout(false);
            this.csv_pose_format_gbox.PerformLayout();
            this.flowLayoutPanel49.ResumeLayout(false);
            this.flowLayoutPanel47.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.comm_sel_gbox.ResumeLayout(false);
            this.usb_gbox.ResumeLayout(false);
            this.usb_gbox.PerformLayout();
            this.tcp_gbox.ResumeLayout(false);
            this.tcp_gbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ComPortNameLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button serial_connect_btn;
        private System.Windows.Forms.ComboBox comGimPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpage2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button LoadConfig_btn;
        private System.Windows.Forms.Button SaveConfig_btn;
        private System.Windows.Forms.Button get_config_btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button comm_conf_btn;
        private System.Windows.Forms.CheckBox uart4_en_cb;
        private System.Windows.Forms.CheckBox fdcan_en_cb;
        private System.Windows.Forms.CheckBox usb_en_cb;
        private System.Windows.Forms.Button reboot_btn;
        private System.Windows.Forms.Button jump_dfu_btn;
        private System.Windows.Forms.GroupBox comm_sel_gbox;
        private System.Windows.Forms.RadioButton serial_rbtn;
        private System.Windows.Forms.RadioButton tcp_rbtn;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.GroupBox usb_gbox;
        private System.Windows.Forms.GroupBox tcp_gbox;
        private System.Windows.Forms.ComboBox w55rp20_cbox;
        private System.Windows.Forms.Button tcp_connect_btn;
        private System.Windows.Forms.Label tcp_status_lb;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button imu_config_btn;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button filter_sel_btn;
        private System.Windows.Forms.ComboBox filter_sel_cbox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button grav_corr_btn;
        private System.Windows.Forms.CheckBox grav_corr_en_cb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox in0_pupd_cbox;
        private System.Windows.Forms.Button in0_conf_btn;
        private System.Windows.Forms.ComboBox in0_trigger_cbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tcp_ip_watch_lb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tcp_port_watch_lb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox stm32_prog_cli_path_tb;
        private System.Windows.Forms.Button stm32_prog_cli_path_btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel12;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox firmware_path_tb;
        private System.Windows.Forms.Button firmware_path_btn;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox dfu_gbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox cli_tb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button firmware_write_btn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox renban_tbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.CheckBox draw_cb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox camera_sel_cbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox frame_rate_cbox;
        private System.Windows.Forms.Button fullscreen_btn;
        private System.Windows.Forms.CheckBox blowse_cube_cb;
        private System.Windows.Forms.CheckBox blowse_grid_cb;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.Button pose_est_reset_btn;
        private System.Windows.Forms.Label receive_freq_label;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Button Stop_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button check_dfu_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton read_32bit_rb;
        private System.Windows.Forms.RadioButton read_16bit_rb;
        private System.Windows.Forms.Button comm_conf_pb;
        private System.Windows.Forms.Button option_pb;
        private System.Windows.Forms.Button board_info_pb;
        private System.Windows.Forms.Button filter_sel_pb;
        private System.Windows.Forms.Button input_pin_conf_pb;
        private System.Windows.Forms.Button filter_conf_pb;
        private System.Windows.Forms.Button imu_conf_pb;
        private System.Windows.Forms.Button update_info;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private LampLabel in0_input_ll;
        private LampLabel in0_trig_ll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox read_cmd_vl;
        private System.Windows.Forms.TextBox quat_w_vl;
        private System.Windows.Forms.TextBox quat_y_vl;
        private System.Windows.Forms.TextBox send_cnt_vl;
        private System.Windows.Forms.TextBox warn_code_vl;
        private System.Windows.Forms.TextBox quat_x_vl;
        private System.Windows.Forms.TextBox quat_z_vl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel20;
        private System.Windows.Forms.TextBox temp_vl;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel21;
        private System.Windows.Forms.TextBox imu_data_cnt_vl;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel22;
        private System.Windows.Forms.TextBox imu_miss_vl;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel23;
        private System.Windows.Forms.TextBox internal_miss_vl;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel24;
        private System.Windows.Forms.TextBox elapsed_vl;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel25;
        private System.Windows.Forms.TextBox spi_time_vl;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel26;
        private System.Windows.Forms.TextBox accl_raw_x_vl;
        private System.Windows.Forms.Label accl_raw_x_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel27;
        private System.Windows.Forms.TextBox accl_raw_y_vl;
        private System.Windows.Forms.Label accl_raw_y_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel28;
        private System.Windows.Forms.TextBox accl_raw_z_vl;
        private System.Windows.Forms.Label accl_raw_z_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel29;
        private System.Windows.Forms.TextBox gyro_raw_x_vl;
        private System.Windows.Forms.Label gyro_raw_x_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel30;
        private System.Windows.Forms.TextBox gyro_raw_y_vl;
        private System.Windows.Forms.Label gyro_raw_y_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel31;
        private System.Windows.Forms.TextBox gyro_raw_z_vl;
        private System.Windows.Forms.Label gyro_raw_z_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel32;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel33;
        private System.Windows.Forms.TextBox version_vl;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel34;
        private System.Windows.Forms.TextBox accl_sens_vl;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel35;
        private System.Windows.Forms.TextBox gyro_sens_vl;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel36;
        private System.Windows.Forms.TextBox sample_rate_vl;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel37;
        private System.Windows.Forms.TextBox product_vl;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel38;
        private System.Windows.Forms.TextBox board_name_vl;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Panel helixWindow1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox tcp_conf_gbox;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button config_reset_btn;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox manual_input_cb;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.FlowLayoutPanel manual_input_panel;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox input_ip_tb;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox input_port_tb;
        private System.Windows.Forms.Button tcp_apply_btn;
        private System.Windows.Forms.TextBox ip_addr_tb;
        private System.Windows.Forms.TextBox port_tb;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button csv_record_btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox csv_save_status_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox csv_record_sample_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox csv_record_time_lb;
        private System.Windows.Forms.FlowLayoutPanel csv_save_config_panel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel47;
        private System.Windows.Forms.ComboBox csv_prescaler_cbox;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel49;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox csv_timelimit_cbox;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox csv_save_path_tb;
        private System.Windows.Forms.Button csv_save_path_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel39;
        private System.Windows.Forms.GroupBox csv_pose_format_gbox;
        private System.Windows.Forms.RadioButton quat_rbtn;
        private System.Windows.Forms.RadioButton euler_rbtn;
        private System.Windows.Forms.Button file_directory_btn;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button path_init_btn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label version_lb;
        private System.Windows.Forms.TextBox battery_warning_tb;
    }
}

