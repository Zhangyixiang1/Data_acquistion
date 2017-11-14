namespace Data_acquisition
{
    partial class Form_Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数校准ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radButton5 = new Telerik.WinControls.UI.RadButton();
            this.radButton6 = new Telerik.WinControls.UI.RadButton();
            this.btn_start = new Telerik.WinControls.UI.RadButton();
            this.lbl_time = new System.Windows.Forms.Label();
            this.highContrastBlackTheme1 = new Telerik.WinControls.Themes.HighContrastBlackTheme();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.timer_log = new System.Windows.Forms.Timer(this.components);
            this.radButton8 = new Telerik.WinControls.UI.RadButton();
            this.timer_now = new System.Windows.Forms.Timer(this.components);
            this.timer_trend = new System.Windows.Forms.Timer(this.components);
            this.radButton7 = new Telerik.WinControls.UI.RadButton();
            this.pnl_setting = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_recurrence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_set = new System.Windows.Forms.TextBox();
            this.rab_none = new System.Windows.Forms.RadioButton();
            this.rab_recurrence = new System.Windows.Forms.RadioButton();
            this.rab_set = new System.Windows.Forms.RadioButton();
            this.rab_interpolation = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_line = new System.Windows.Forms.CheckBox();
            this.cmb_line = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_time = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_end = new System.Windows.Forms.TextBox();
            this.txb_start = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cleanvol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SandType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建施工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.追加施工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束施工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.通道设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像编辑ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_stage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_stagetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_now = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel13 = new System.Windows.Forms.ToolStripStatusLabel();
            this.parashow16 = new Data_acquisition.Ctrl.Parashow();
            this.parashow15 = new Data_acquisition.Ctrl.Parashow();
            this.parashow14 = new Data_acquisition.Ctrl.Parashow();
            this.parashow13 = new Data_acquisition.Ctrl.Parashow();
            this.parashow12 = new Data_acquisition.Ctrl.Parashow();
            this.parashow11 = new Data_acquisition.Ctrl.Parashow();
            this.parashow10 = new Data_acquisition.Ctrl.Parashow();
            this.parashow9 = new Data_acquisition.Ctrl.Parashow();
            this.parashow8 = new Data_acquisition.Ctrl.Parashow();
            this.parashow7 = new Data_acquisition.Ctrl.Parashow();
            this.parashow6 = new Data_acquisition.Ctrl.Parashow();
            this.parashow5 = new Data_acquisition.Ctrl.Parashow();
            this.parashow4 = new Data_acquisition.Ctrl.Parashow();
            this.parashow3 = new Data_acquisition.Ctrl.Parashow();
            this.parashow1 = new Data_acquisition.Ctrl.Parashow();
            this.parashow2 = new Data_acquisition.Ctrl.Parashow();
            this.paraLine1 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine6 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine5 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine4 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine3 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine2 = new Data_acquisition.Ctrl.ParaLine();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton7)).BeginInit();
            this.pnl_setting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 87);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1719, 525);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1912, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.追加ToolStripMenuItem,
            this.回放ToolStripMenuItem,
            this.退出ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建ToolStripMenuItem.Text = "新建施工";
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.追加ToolStripMenuItem.Text = "追加施工";
            // 
            // 回放ToolStripMenuItem
            // 
            this.回放ToolStripMenuItem.Name = "回放ToolStripMenuItem";
            this.回放ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.回放ToolStripMenuItem.Text = "回放";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "结束施工";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem,
            this.参数校准ToolStripMenuItem,
            this.图像编辑ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 参数校准ToolStripMenuItem
            // 
            this.参数校准ToolStripMenuItem.Name = "参数校准ToolStripMenuItem";
            this.参数校准ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.参数校准ToolStripMenuItem.Text = "参数设置";
            // 
            // 图像编辑ToolStripMenuItem
            // 
            this.图像编辑ToolStripMenuItem.Name = "图像编辑ToolStripMenuItem";
            this.图像编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.图像编辑ToolStripMenuItem.Text = "图像编辑";
            this.图像编辑ToolStripMenuItem.Click += new System.EventHandler(this.图像编辑ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视图1ToolStripMenuItem,
            this.视图2ToolStripMenuItem,
            this.视图3ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 视图1ToolStripMenuItem
            // 
            this.视图1ToolStripMenuItem.Name = "视图1ToolStripMenuItem";
            this.视图1ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.视图1ToolStripMenuItem.Text = "视图1";
            this.视图1ToolStripMenuItem.Click += new System.EventHandler(this.视图1ToolStripMenuItem_Click);
            // 
            // 视图2ToolStripMenuItem
            // 
            this.视图2ToolStripMenuItem.Name = "视图2ToolStripMenuItem";
            this.视图2ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.视图2ToolStripMenuItem.Text = "视图2";
            this.视图2ToolStripMenuItem.Click += new System.EventHandler(this.视图2ToolStripMenuItem_Click);
            // 
            // 视图3ToolStripMenuItem
            // 
            this.视图3ToolStripMenuItem.Name = "视图3ToolStripMenuItem";
            this.视图3ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.视图3ToolStripMenuItem.Text = "视图3";
            this.视图3ToolStripMenuItem.Click += new System.EventHandler(this.视图3ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.说明文档ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 说明文档ToolStripMenuItem
            // 
            this.说明文档ToolStripMenuItem.Name = "说明文档ToolStripMenuItem";
            this.说明文档ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.说明文档ToolStripMenuItem.Text = "说明文档";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton1.ForeColor = System.Drawing.Color.White;
            this.radButton1.Location = new System.Drawing.Point(240, 36);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(40, 40);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "打印";
            // 
            // radButton2
            // 
            this.radButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton2.ForeColor = System.Drawing.Color.White;
            this.radButton2.Location = new System.Drawing.Point(286, 36);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(40, 40);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "左移";
            // 
            // radButton3
            // 
            this.radButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton3.ForeColor = System.Drawing.Color.White;
            this.radButton3.Location = new System.Drawing.Point(332, 36);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(40, 40);
            this.radButton3.TabIndex = 2;
            this.radButton3.Text = "右移";
            // 
            // radButton4
            // 
            this.radButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton4.ForeColor = System.Drawing.Color.White;
            this.radButton4.Location = new System.Drawing.Point(378, 36);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(40, 40);
            this.radButton4.TabIndex = 2;
            this.radButton4.Text = "放大";
            // 
            // radButton5
            // 
            this.radButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton5.ForeColor = System.Drawing.Color.White;
            this.radButton5.Location = new System.Drawing.Point(424, 36);
            this.radButton5.Name = "radButton5";
            this.radButton5.Size = new System.Drawing.Size(40, 40);
            this.radButton5.TabIndex = 2;
            this.radButton5.Text = "缩小";
            // 
            // radButton6
            // 
            this.radButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton6.ForeColor = System.Drawing.Color.White;
            this.radButton6.Location = new System.Drawing.Point(194, 36);
            this.radButton6.Name = "radButton6";
            this.radButton6.Size = new System.Drawing.Size(40, 40);
            this.radButton6.TabIndex = 2;
            this.radButton6.Text = "报表";
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(12, 36);
            this.btn_start.Name = "btn_start";
            // 
            // 
            // 
            this.btn_start.RootElement.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_start.Size = new System.Drawing.Size(40, 40);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "开始";
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.lbl_time.ForeColor = System.Drawing.Color.White;
            this.lbl_time.Location = new System.Drawing.Point(70, 45);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(82, 22);
            this.lbl_time.TabIndex = 3;
            this.lbl_time.Text = "00:00:00";
            // 
            // timer_log
            // 
            this.timer_log.Interval = 1000;
            this.timer_log.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // radButton8
            // 
            this.radButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton8.ForeColor = System.Drawing.Color.White;
            this.radButton8.Location = new System.Drawing.Point(470, 36);
            this.radButton8.Name = "radButton8";
            this.radButton8.Size = new System.Drawing.Size(40, 40);
            this.radButton8.TabIndex = 14;
            this.radButton8.Text = "<html><p>下一</p><p>阶段</p></html>";
            // 
            // timer_now
            // 
            this.timer_now.Enabled = true;
            this.timer_now.Interval = 1000;
            this.timer_now.Tick += new System.EventHandler(this.timer_now_Tick);
            // 
            // timer_trend
            // 
            this.timer_trend.Interval = 1000;
            this.timer_trend.Tick += new System.EventHandler(this.timer_trend_Tick);
            // 
            // radButton7
            // 
            this.radButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.radButton7.ForeColor = System.Drawing.Color.White;
            this.radButton7.Location = new System.Drawing.Point(516, 36);
            this.radButton7.Name = "radButton7";
            this.radButton7.Size = new System.Drawing.Size(40, 40);
            this.radButton7.TabIndex = 14;
            this.radButton7.Text = "清零";
            // 
            // pnl_setting
            // 
            this.pnl_setting.Controls.Add(this.btn_cancel);
            this.pnl_setting.Controls.Add(this.btn_ok);
            this.pnl_setting.Controls.Add(this.groupBox3);
            this.pnl_setting.Controls.Add(this.groupBox2);
            this.pnl_setting.Controls.Add(this.groupBox1);
            this.pnl_setting.Location = new System.Drawing.Point(1230, 191);
            this.pnl_setting.Name = "pnl_setting";
            this.pnl_setting.Size = new System.Drawing.Size(311, 323);
            this.pnl_setting.TabIndex = 17;
            this.pnl_setting.Visible = false;
            this.pnl_setting.VisibleChanged += new System.EventHandler(this.pnl_setting_VisibleChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(102, 294);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(16, 294);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txb_recurrence);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txb_set);
            this.groupBox3.Controls.Add(this.rab_none);
            this.groupBox3.Controls.Add(this.rab_recurrence);
            this.groupBox3.Controls.Add(this.rab_set);
            this.groupBox3.Controls.Add(this.rab_interpolation);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(7, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 121);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "编辑模式";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(131, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "数量";
            // 
            // txb_recurrence
            // 
            this.txb_recurrence.Location = new System.Drawing.Point(188, 64);
            this.txb_recurrence.Name = "txb_recurrence";
            this.txb_recurrence.Size = new System.Drawing.Size(100, 21);
            this.txb_recurrence.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(131, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "值";
            // 
            // txb_set
            // 
            this.txb_set.Location = new System.Drawing.Point(188, 39);
            this.txb_set.Name = "txb_set";
            this.txb_set.Size = new System.Drawing.Size(100, 21);
            this.txb_set.TabIndex = 5;
            // 
            // rab_none
            // 
            this.rab_none.AutoSize = true;
            this.rab_none.Checked = true;
            this.rab_none.ForeColor = System.Drawing.Color.White;
            this.rab_none.Location = new System.Drawing.Point(9, 90);
            this.rab_none.Name = "rab_none";
            this.rab_none.Size = new System.Drawing.Size(59, 16);
            this.rab_none.TabIndex = 4;
            this.rab_none.TabStop = true;
            this.rab_none.Text = "不编辑";
            this.rab_none.UseVisualStyleBackColor = true;
            // 
            // rab_recurrence
            // 
            this.rab_recurrence.AutoSize = true;
            this.rab_recurrence.ForeColor = System.Drawing.Color.White;
            this.rab_recurrence.Location = new System.Drawing.Point(9, 67);
            this.rab_recurrence.Name = "rab_recurrence";
            this.rab_recurrence.Size = new System.Drawing.Size(71, 16);
            this.rab_recurrence.TabIndex = 4;
            this.rab_recurrence.Text = "递推平均";
            this.rab_recurrence.UseVisualStyleBackColor = true;
            // 
            // rab_set
            // 
            this.rab_set.AutoSize = true;
            this.rab_set.ForeColor = System.Drawing.Color.White;
            this.rab_set.Location = new System.Drawing.Point(9, 44);
            this.rab_set.Name = "rab_set";
            this.rab_set.Size = new System.Drawing.Size(59, 16);
            this.rab_set.TabIndex = 4;
            this.rab_set.Text = "设置值";
            this.rab_set.UseVisualStyleBackColor = true;
            // 
            // rab_interpolation
            // 
            this.rab_interpolation.AutoSize = true;
            this.rab_interpolation.ForeColor = System.Drawing.Color.White;
            this.rab_interpolation.Location = new System.Drawing.Point(9, 21);
            this.rab_interpolation.Name = "rab_interpolation";
            this.rab_interpolation.Size = new System.Drawing.Size(59, 16);
            this.rab_interpolation.TabIndex = 3;
            this.rab_interpolation.Text = "插值法";
            this.rab_interpolation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_line);
            this.groupBox2.Controls.Add(this.cmb_line);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(7, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 55);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "曲线选择";
            // 
            // chk_line
            // 
            this.chk_line.AutoSize = true;
            this.chk_line.ForeColor = System.Drawing.Color.White;
            this.chk_line.Location = new System.Drawing.Point(213, 24);
            this.chk_line.Name = "chk_line";
            this.chk_line.Size = new System.Drawing.Size(72, 16);
            this.chk_line.TabIndex = 3;
            this.chk_line.Text = "所有曲线";
            this.chk_line.UseVisualStyleBackColor = true;
            // 
            // cmb_line
            // 
            this.cmb_line.FormattingEnabled = true;
            this.cmb_line.Location = new System.Drawing.Point(9, 21);
            this.cmb_line.Name = "cmb_line";
            this.cmb_line.Size = new System.Drawing.Size(121, 20);
            this.cmb_line.TabIndex = 3;
            this.cmb_line.SelectedIndexChanged += new System.EventHandler(this.cmb_line_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_time);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txb_end);
            this.groupBox1.Controls.Add(this.txb_start);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间范围";
            // 
            // chk_time
            // 
            this.chk_time.AutoSize = true;
            this.chk_time.ForeColor = System.Drawing.Color.White;
            this.chk_time.Location = new System.Drawing.Point(213, 22);
            this.chk_time.Name = "chk_time";
            this.chk_time.Size = new System.Drawing.Size(72, 16);
            this.chk_time.TabIndex = 3;
            this.chk_time.Text = "整个时间";
            this.chk_time.UseVisualStyleBackColor = true;
            this.chk_time.CheckedChanged += new System.EventHandler(this.chk_time_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "结束时间(s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "开始时间(s)";
            // 
            // txb_end
            // 
            this.txb_end.Location = new System.Drawing.Point(95, 44);
            this.txb_end.Name = "txb_end";
            this.txb_end.Size = new System.Drawing.Size(100, 21);
            this.txb_end.TabIndex = 1;
            // 
            // txb_start
            // 
            this.txb_start.Location = new System.Drawing.Point(95, 19);
            this.txb_start.Name = "txb_start";
            this.txb_start.Size = new System.Drawing.Size(100, 21);
            this.txb_start.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stage,
            this.Sand,
            this.LA1,
            this.LA2,
            this.LA3,
            this.LA4,
            this.DA1,
            this.Cleanvol,
            this.SandType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(13, 615);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1719, 435);
            this.dataGridView1.TabIndex = 18;
            // 
            // Stage
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Stage.DefaultCellStyle = dataGridViewCellStyle2;
            this.Stage.HeaderText = "Stage";
            this.Stage.Name = "Stage";
            // 
            // Sand
            // 
            this.Sand.HeaderText = "Sand(PPA)";
            this.Sand.Name = "Sand";
            // 
            // LA1
            // 
            this.LA1.HeaderText = "LA1(gals/1000)";
            this.LA1.Name = "LA1";
            // 
            // LA2
            // 
            this.LA2.HeaderText = "LA2(gals/1000)";
            this.LA2.Name = "LA2";
            // 
            // LA3
            // 
            this.LA3.HeaderText = "LA3(gals/1000)";
            this.LA3.Name = "LA3";
            // 
            // LA4
            // 
            this.LA4.HeaderText = "LA4(gals/1000)";
            this.LA4.Name = "LA4";
            // 
            // DA1
            // 
            this.DA1.HeaderText = "DA1(lbs/1000)";
            this.DA1.Name = "DA1";
            // 
            // Cleanvol
            // 
            this.Cleanvol.HeaderText = "Clean Vol.(bbls)";
            this.Cleanvol.Name = "Cleanvol";
            // 
            // SandType
            // 
            this.SandType.HeaderText = "SandType";
            this.SandType.Name = "SandType";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem1,
            this.设置ToolStripMenuItem1,
            this.视图ToolStripMenuItem1,
            this.关于ToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1920, 25);
            this.menuStrip2.TabIndex = 23;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 文件ToolStripMenuItem1
            // 
            this.文件ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建施工ToolStripMenuItem,
            this.追加施工ToolStripMenuItem,
            this.结束施工ToolStripMenuItem,
            this.退出ToolStripMenuItem2});
            this.文件ToolStripMenuItem1.Name = "文件ToolStripMenuItem1";
            this.文件ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem1.Text = "文件";
            // 
            // 新建施工ToolStripMenuItem
            // 
            this.新建施工ToolStripMenuItem.Name = "新建施工ToolStripMenuItem";
            this.新建施工ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建施工ToolStripMenuItem.Text = "新建施工";
            // 
            // 追加施工ToolStripMenuItem
            // 
            this.追加施工ToolStripMenuItem.Name = "追加施工ToolStripMenuItem";
            this.追加施工ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.追加施工ToolStripMenuItem.Text = "追加施工";
            // 
            // 结束施工ToolStripMenuItem
            // 
            this.结束施工ToolStripMenuItem.Name = "结束施工ToolStripMenuItem";
            this.结束施工ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.结束施工ToolStripMenuItem.Text = "结束施工";
            // 
            // 退出ToolStripMenuItem2
            // 
            this.退出ToolStripMenuItem2.Name = "退出ToolStripMenuItem2";
            this.退出ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem2.Text = "退出";
            this.退出ToolStripMenuItem2.Click += new System.EventHandler(this.退出ToolStripMenuItem2_Click);
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem1,
            this.通道设置ToolStripMenuItem,
            this.图像编辑ToolStripMenuItem1});
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem1.Text = "设置";
            // 
            // 系统设置ToolStripMenuItem1
            // 
            this.系统设置ToolStripMenuItem1.Name = "系统设置ToolStripMenuItem1";
            this.系统设置ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.系统设置ToolStripMenuItem1.Text = "系统设置";
            // 
            // 通道设置ToolStripMenuItem
            // 
            this.通道设置ToolStripMenuItem.Name = "通道设置ToolStripMenuItem";
            this.通道设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.通道设置ToolStripMenuItem.Text = "通道设置";
            // 
            // 图像编辑ToolStripMenuItem1
            // 
            this.图像编辑ToolStripMenuItem1.Name = "图像编辑ToolStripMenuItem1";
            this.图像编辑ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.图像编辑ToolStripMenuItem1.Text = "图像编辑";
            this.图像编辑ToolStripMenuItem1.Click += new System.EventHandler(this.图像编辑ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem1
            // 
            this.视图ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视图1ToolStripMenuItem1,
            this.视图2ToolStripMenuItem1,
            this.视图3ToolStripMenuItem1,
            this.视图4ToolStripMenuItem});
            this.视图ToolStripMenuItem1.Name = "视图ToolStripMenuItem1";
            this.视图ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.视图ToolStripMenuItem1.Text = "视图";
            // 
            // 视图1ToolStripMenuItem1
            // 
            this.视图1ToolStripMenuItem1.Name = "视图1ToolStripMenuItem1";
            this.视图1ToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.视图1ToolStripMenuItem1.Text = "视图1";
            this.视图1ToolStripMenuItem1.Click += new System.EventHandler(this.视图1ToolStripMenuItem1_Click);
            // 
            // 视图2ToolStripMenuItem1
            // 
            this.视图2ToolStripMenuItem1.Name = "视图2ToolStripMenuItem1";
            this.视图2ToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.视图2ToolStripMenuItem1.Text = "视图2";
            this.视图2ToolStripMenuItem1.Click += new System.EventHandler(this.视图2ToolStripMenuItem1_Click);
            // 
            // 视图3ToolStripMenuItem1
            // 
            this.视图3ToolStripMenuItem1.Name = "视图3ToolStripMenuItem1";
            this.视图3ToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.视图3ToolStripMenuItem1.Text = "视图3";
            this.视图3ToolStripMenuItem1.Click += new System.EventHandler(this.视图3ToolStripMenuItem1_Click);
            // 
            // 视图4ToolStripMenuItem
            // 
            this.视图4ToolStripMenuItem.Name = "视图4ToolStripMenuItem";
            this.视图4ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.视图4ToolStripMenuItem.Text = "视图4";
            this.视图4ToolStripMenuItem.Click += new System.EventHandler(this.视图4ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1});
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem1.Text = "关于";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbl_stage,
            this.toolStripStatusLabel2,
            this.lbl_stagetime,
            this.toolStripStatusLabel3,
            this.lbl_now,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel11,
            this.toolStripStatusLabel10,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel12,
            this.toolStripStatusLabel13});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1048);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1920, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "阶段号：";
            // 
            // lbl_stage
            // 
            this.lbl_stage.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stage.Name = "lbl_stage";
            this.lbl_stage.Size = new System.Drawing.Size(15, 17);
            this.lbl_stage.Text = "1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "阶段时间：";
            // 
            // lbl_stagetime
            // 
            this.lbl_stagetime.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stagetime.Name = "lbl_stagetime";
            this.lbl_stagetime.Size = new System.Drawing.Size(56, 17);
            this.lbl_stagetime.Text = "00:00:00";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel3.Text = "当前时间:";
            // 
            // lbl_now
            // 
            this.lbl_now.BackColor = System.Drawing.Color.Transparent;
            this.lbl_now.Name = "lbl_now";
            this.lbl_now.Size = new System.Drawing.Size(126, 17);
            this.lbl_now.Text = "2017/01/01 00:00:00";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(1346, 17);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel5.Text = "设备:";
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel11.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel11.Text = " ";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel10.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel10.Text = " ";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel9.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel9.Text = " ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel8.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel8.Text = " ";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel7.Text = " ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel6.Text = " ";
            // 
            // toolStripStatusLabel12
            // 
            this.toolStripStatusLabel12.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            this.toolStripStatusLabel12.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel12.Text = "记录";
            // 
            // toolStripStatusLabel13
            // 
            this.toolStripStatusLabel13.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel13.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabel13.Name = "toolStripStatusLabel13";
            this.toolStripStatusLabel13.Size = new System.Drawing.Size(12, 18);
            this.toolStripStatusLabel13.Text = " ";
            // 
            // parashow16
            // 
            this.parashow16.BackColor = System.Drawing.Color.Transparent;
            this.parashow16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow16.Color = System.Drawing.Color.Yellow;
            this.parashow16.Location = new System.Drawing.Point(1742, 990);
            this.parashow16.Name = "parashow16";
            this.parashow16.Size = new System.Drawing.Size(178, 60);
            this.parashow16.TabIndex = 19;
            this.parashow16.Tagname = null;
            this.parashow16.Unit = null;
            // 
            // parashow15
            // 
            this.parashow15.BackColor = System.Drawing.Color.Transparent;
            this.parashow15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow15.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.parashow15.Location = new System.Drawing.Point(1742, 926);
            this.parashow15.Name = "parashow15";
            this.parashow15.Size = new System.Drawing.Size(178, 60);
            this.parashow15.TabIndex = 19;
            this.parashow15.Tagname = null;
            this.parashow15.Unit = null;
            // 
            // parashow14
            // 
            this.parashow14.BackColor = System.Drawing.Color.Transparent;
            this.parashow14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow14.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.parashow14.Location = new System.Drawing.Point(1742, 862);
            this.parashow14.Name = "parashow14";
            this.parashow14.Size = new System.Drawing.Size(178, 60);
            this.parashow14.TabIndex = 19;
            this.parashow14.Tagname = null;
            this.parashow14.Unit = null;
            // 
            // parashow13
            // 
            this.parashow13.BackColor = System.Drawing.Color.Transparent;
            this.parashow13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow13.Color = System.Drawing.Color.Red;
            this.parashow13.Location = new System.Drawing.Point(1742, 798);
            this.parashow13.Name = "parashow13";
            this.parashow13.Size = new System.Drawing.Size(178, 60);
            this.parashow13.TabIndex = 19;
            this.parashow13.Tagname = null;
            this.parashow13.Unit = null;
            // 
            // parashow12
            // 
            this.parashow12.BackColor = System.Drawing.Color.Transparent;
            this.parashow12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow12.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.parashow12.Location = new System.Drawing.Point(1742, 734);
            this.parashow12.Name = "parashow12";
            this.parashow12.Size = new System.Drawing.Size(178, 60);
            this.parashow12.TabIndex = 19;
            this.parashow12.Tagname = null;
            this.parashow12.Unit = null;
            // 
            // parashow11
            // 
            this.parashow11.BackColor = System.Drawing.Color.Transparent;
            this.parashow11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.parashow11.Location = new System.Drawing.Point(1742, 670);
            this.parashow11.Name = "parashow11";
            this.parashow11.Size = new System.Drawing.Size(178, 60);
            this.parashow11.TabIndex = 19;
            this.parashow11.Tagname = null;
            this.parashow11.Unit = null;
            // 
            // parashow10
            // 
            this.parashow10.BackColor = System.Drawing.Color.Transparent;
            this.parashow10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow10.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.parashow10.Location = new System.Drawing.Point(1742, 606);
            this.parashow10.Name = "parashow10";
            this.parashow10.Size = new System.Drawing.Size(178, 60);
            this.parashow10.TabIndex = 19;
            this.parashow10.Tagname = null;
            this.parashow10.Unit = null;
            // 
            // parashow9
            // 
            this.parashow9.BackColor = System.Drawing.Color.Transparent;
            this.parashow9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow9.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.parashow9.Location = new System.Drawing.Point(1742, 542);
            this.parashow9.Name = "parashow9";
            this.parashow9.Size = new System.Drawing.Size(178, 60);
            this.parashow9.TabIndex = 19;
            this.parashow9.Tagname = null;
            this.parashow9.Unit = null;
            // 
            // parashow8
            // 
            this.parashow8.BackColor = System.Drawing.Color.Transparent;
            this.parashow8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.parashow8.Location = new System.Drawing.Point(1742, 478);
            this.parashow8.Name = "parashow8";
            this.parashow8.Size = new System.Drawing.Size(178, 60);
            this.parashow8.TabIndex = 19;
            this.parashow8.Tagname = null;
            this.parashow8.Unit = null;
            // 
            // parashow7
            // 
            this.parashow7.BackColor = System.Drawing.Color.Transparent;
            this.parashow7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.parashow7.Location = new System.Drawing.Point(1742, 414);
            this.parashow7.Name = "parashow7";
            this.parashow7.Size = new System.Drawing.Size(178, 60);
            this.parashow7.TabIndex = 19;
            this.parashow7.Tagname = null;
            this.parashow7.Unit = null;
            // 
            // parashow6
            // 
            this.parashow6.BackColor = System.Drawing.Color.Transparent;
            this.parashow6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.parashow6.Location = new System.Drawing.Point(1742, 350);
            this.parashow6.Name = "parashow6";
            this.parashow6.Size = new System.Drawing.Size(178, 60);
            this.parashow6.TabIndex = 19;
            this.parashow6.Tagname = null;
            this.parashow6.Unit = null;
            // 
            // parashow5
            // 
            this.parashow5.BackColor = System.Drawing.Color.Transparent;
            this.parashow5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow5.Color = System.Drawing.Color.Lime;
            this.parashow5.Location = new System.Drawing.Point(1742, 286);
            this.parashow5.Name = "parashow5";
            this.parashow5.Size = new System.Drawing.Size(178, 60);
            this.parashow5.TabIndex = 19;
            this.parashow5.Tagname = null;
            this.parashow5.Unit = null;
            // 
            // parashow4
            // 
            this.parashow4.BackColor = System.Drawing.Color.Transparent;
            this.parashow4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow4.Color = System.Drawing.Color.Blue;
            this.parashow4.Location = new System.Drawing.Point(1742, 222);
            this.parashow4.Name = "parashow4";
            this.parashow4.Size = new System.Drawing.Size(178, 60);
            this.parashow4.TabIndex = 19;
            this.parashow4.Tagname = null;
            this.parashow4.Unit = null;
            // 
            // parashow3
            // 
            this.parashow3.BackColor = System.Drawing.Color.Transparent;
            this.parashow3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow3.Color = System.Drawing.Color.Yellow;
            this.parashow3.Location = new System.Drawing.Point(1742, 158);
            this.parashow3.Name = "parashow3";
            this.parashow3.Size = new System.Drawing.Size(178, 60);
            this.parashow3.TabIndex = 19;
            this.parashow3.Tagname = null;
            this.parashow3.Unit = null;
            // 
            // parashow1
            // 
            this.parashow1.BackColor = System.Drawing.Color.Transparent;
            this.parashow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow1.Color = System.Drawing.Color.Red;
            this.parashow1.Location = new System.Drawing.Point(1742, 30);
            this.parashow1.Name = "parashow1";
            this.parashow1.Size = new System.Drawing.Size(178, 60);
            this.parashow1.TabIndex = 19;
            this.parashow1.Tagname = null;
            this.parashow1.Unit = null;
            // 
            // parashow2
            // 
            this.parashow2.BackColor = System.Drawing.Color.Transparent;
            this.parashow2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow2.Color = System.Drawing.Color.Red;
            this.parashow2.Location = new System.Drawing.Point(1742, 94);
            this.parashow2.Name = "parashow2";
            this.parashow2.Size = new System.Drawing.Size(178, 60);
            this.parashow2.TabIndex = 19;
            this.parashow2.Tagname = null;
            this.parashow2.Unit = null;
            // 
            // paraLine1
            // 
            this.paraLine1.BackColor = System.Drawing.Color.Transparent;
            this.paraLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine1.Color = System.Drawing.Color.Red;
            this.paraLine1.Line_Enabled = true;
            this.paraLine1.Location = new System.Drawing.Point(783, 30);
            this.paraLine1.Max = null;
            this.paraLine1.Min = null;
            this.paraLine1.Name = "paraLine1";
            this.paraLine1.Size = new System.Drawing.Size(153, 52);
            this.paraLine1.TabIndex = 16;
            this.paraLine1.Tagname = null;
            this.paraLine1.Unit = null;
            // 
            // paraLine6
            // 
            this.paraLine6.BackColor = System.Drawing.Color.Transparent;
            this.paraLine6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine6.Color = System.Drawing.Color.SkyBlue;
            this.paraLine6.Line_Enabled = true;
            this.paraLine6.Location = new System.Drawing.Point(1578, 30);
            this.paraLine6.Max = "1000";
            this.paraLine6.Min = "0";
            this.paraLine6.Name = "paraLine6";
            this.paraLine6.Size = new System.Drawing.Size(153, 52);
            this.paraLine6.TabIndex = 15;
            this.paraLine6.Tagname = null;
            this.paraLine6.Unit = "Mpa";
            // 
            // paraLine5
            // 
            this.paraLine5.BackColor = System.Drawing.Color.Transparent;
            this.paraLine5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine5.Color = System.Drawing.Color.SeaGreen;
            this.paraLine5.Line_Enabled = true;
            this.paraLine5.Location = new System.Drawing.Point(1419, 30);
            this.paraLine5.Max = "1000";
            this.paraLine5.Min = "0";
            this.paraLine5.Name = "paraLine5";
            this.paraLine5.Size = new System.Drawing.Size(153, 52);
            this.paraLine5.TabIndex = 15;
            this.paraLine5.Tagname = null;
            this.paraLine5.Unit = "Mpa";
            // 
            // paraLine4
            // 
            this.paraLine4.BackColor = System.Drawing.Color.Transparent;
            this.paraLine4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine4.Color = System.Drawing.Color.Lime;
            this.paraLine4.Line_Enabled = false;
            this.paraLine4.Location = new System.Drawing.Point(1260, 30);
            this.paraLine4.Max = "1000";
            this.paraLine4.Min = "0";
            this.paraLine4.Name = "paraLine4";
            this.paraLine4.Size = new System.Drawing.Size(153, 52);
            this.paraLine4.TabIndex = 15;
            this.paraLine4.Tagname = null;
            this.paraLine4.Unit = "Mpa";
            // 
            // paraLine3
            // 
            this.paraLine3.BackColor = System.Drawing.Color.Transparent;
            this.paraLine3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine3.Color = System.Drawing.Color.Blue;
            this.paraLine3.Line_Enabled = true;
            this.paraLine3.Location = new System.Drawing.Point(1101, 30);
            this.paraLine3.Max = "1000";
            this.paraLine3.Min = "0";
            this.paraLine3.Name = "paraLine3";
            this.paraLine3.Size = new System.Drawing.Size(153, 52);
            this.paraLine3.TabIndex = 15;
            this.paraLine3.Tagname = null;
            this.paraLine3.Unit = "Mpa";
            // 
            // paraLine2
            // 
            this.paraLine2.BackColor = System.Drawing.Color.Transparent;
            this.paraLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine2.Color = System.Drawing.Color.Yellow;
            this.paraLine2.Line_Enabled = true;
            this.paraLine2.Location = new System.Drawing.Point(942, 30);
            this.paraLine2.Max = "1000";
            this.paraLine2.Min = "0";
            this.paraLine2.Name = "paraLine2";
            this.paraLine2.Size = new System.Drawing.Size(153, 52);
            this.paraLine2.TabIndex = 15;
            this.paraLine2.Tagname = null;
            this.paraLine2.Unit = "Mpa";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1920, 1070);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.parashow16);
            this.Controls.Add(this.parashow15);
            this.Controls.Add(this.parashow14);
            this.Controls.Add(this.parashow13);
            this.Controls.Add(this.parashow12);
            this.Controls.Add(this.parashow11);
            this.Controls.Add(this.parashow10);
            this.Controls.Add(this.parashow9);
            this.Controls.Add(this.parashow8);
            this.Controls.Add(this.parashow7);
            this.Controls.Add(this.parashow6);
            this.Controls.Add(this.parashow5);
            this.Controls.Add(this.parashow4);
            this.Controls.Add(this.parashow3);
            this.Controls.Add(this.parashow1);
            this.Controls.Add(this.parashow2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnl_setting);
            this.Controls.Add(this.paraLine1);
            this.Controls.Add(this.paraLine6);
            this.Controls.Add(this.paraLine5);
            this.Controls.Add(this.paraLine4);
            this.Controls.Add(this.paraLine3);
            this.Controls.Add(this.paraLine2);
            this.Controls.Add(this.radButton7);
            this.Controls.Add(this.radButton8);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.radButton6);
            this.Controls.Add(this.radButton5);
            this.Controls.Add(this.radButton4);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Main";
            this.ThemeName = "Office2013Dark";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton7)).EndInit();
            this.pnl_setting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton radButton5;
        private Telerik.WinControls.UI.RadButton radButton6;
        private Telerik.WinControls.UI.RadButton btn_start;
        private System.Windows.Forms.Label lbl_time;
        private Telerik.WinControls.Themes.HighContrastBlackTheme highContrastBlackTheme1;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.Timer timer_log;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 回放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数校准ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 说明文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private Telerik.WinControls.UI.RadButton radButton8;
        private System.Windows.Forms.Timer timer_now;
        private Ctrl.ParaLine paraLine2;
        private Ctrl.ParaLine paraLine3;
        private Ctrl.ParaLine paraLine4;
        private Ctrl.ParaLine paraLine5;
        private Ctrl.ParaLine paraLine6;
        private Ctrl.ParaLine paraLine1;
        private System.Windows.Forms.Timer timer_trend;
        private Telerik.WinControls.UI.RadButton radButton7;
        private System.Windows.Forms.ToolStripMenuItem 图像编辑ToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_setting;
        private System.Windows.Forms.TextBox txb_start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_end;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_recurrence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_set;
        private System.Windows.Forms.RadioButton rab_none;
        private System.Windows.Forms.RadioButton rab_recurrence;
        private System.Windows.Forms.RadioButton rab_set;
        private System.Windows.Forms.RadioButton rab_interpolation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_line;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.CheckBox chk_time;
        private System.Windows.Forms.CheckBox chk_line;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sand;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cleanvol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SandType;
        private Ctrl.Parashow parashow2;
        private Ctrl.Parashow parashow3;
        private Ctrl.Parashow parashow4;
        private Ctrl.Parashow parashow5;
        private Ctrl.Parashow parashow6;
        private Ctrl.Parashow parashow7;
        private Ctrl.Parashow parashow8;
        private Ctrl.Parashow parashow9;
        private Ctrl.Parashow parashow10;
        private Ctrl.Parashow parashow11;
        private Ctrl.Parashow parashow12;
        private Ctrl.Parashow parashow13;
        private Ctrl.Parashow parashow14;
        private Ctrl.Parashow parashow15;
        private Ctrl.Parashow parashow16;
        private Ctrl.Parashow parashow1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建施工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 追加施工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束施工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 通道设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 视图1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 视图2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 视图3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_stage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbl_stagetime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lbl_now;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel12;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel13;
        private System.Windows.Forms.ToolStripMenuItem 图像编辑ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 视图4ToolStripMenuItem;
    }
}
