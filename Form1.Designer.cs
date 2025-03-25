namespace CycleSample
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpDBInfo = new System.Windows.Forms.GroupBox();
            this.txtDBPORT = new System.Windows.Forms.TextBox();
            this.lbDBPort = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBSID = new System.Windows.Forms.TextBox();
            this.lbDBStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUSERPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUSERID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDBIP = new System.Windows.Forms.TextBox();
            this.btnDBTest = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSYSID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtViewEquipLog = new System.Windows.Forms.DataGridView();
            this.btnRun = new System.Windows.Forms.Button();
            this.cmbPLCNO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotCnt = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbStatt = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbRunType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpDBInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtViewEquipLog)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDBInfo
            // 
            this.grpDBInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDBInfo.BackColor = System.Drawing.Color.Transparent;
            this.grpDBInfo.Controls.Add(this.txtDBPORT);
            this.grpDBInfo.Controls.Add(this.lbDBPort);
            this.grpDBInfo.Controls.Add(this.label6);
            this.grpDBInfo.Controls.Add(this.txtDBSID);
            this.grpDBInfo.Controls.Add(this.lbDBStatus);
            this.grpDBInfo.Controls.Add(this.label3);
            this.grpDBInfo.Controls.Add(this.txtUSERPW);
            this.grpDBInfo.Controls.Add(this.label2);
            this.grpDBInfo.Controls.Add(this.txtUSERID);
            this.grpDBInfo.Controls.Add(this.label1);
            this.grpDBInfo.Controls.Add(this.txtDBIP);
            this.grpDBInfo.Controls.Add(this.btnDBTest);
            this.grpDBInfo.Location = new System.Drawing.Point(11, 12);
            this.grpDBInfo.Name = "grpDBInfo";
            this.grpDBInfo.Size = new System.Drawing.Size(820, 170);
            this.grpDBInfo.TabIndex = 28;
            this.grpDBInfo.TabStop = false;
            this.grpDBInfo.Text = "DB Info";
            // 
            // txtDBPORT
            // 
            this.txtDBPORT.Location = new System.Drawing.Point(114, 43);
            this.txtDBPORT.Name = "txtDBPORT";
            this.txtDBPORT.Size = new System.Drawing.Size(199, 21);
            this.txtDBPORT.TabIndex = 11;
            this.txtDBPORT.Text = "12345";
            // 
            // lbDBPort
            // 
            this.lbDBPort.AutoSize = true;
            this.lbDBPort.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDBPort.ForeColor = System.Drawing.Color.DimGray;
            this.lbDBPort.Location = new System.Drawing.Point(5, 54);
            this.lbDBPort.Name = "lbDBPort";
            this.lbDBPort.Size = new System.Drawing.Size(65, 12);
            this.lbDBPort.TabIndex = 10;
            this.lbDBPort.Text = "DB PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(4, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "ConnectionSID";
            // 
            // txtDBSID
            // 
            this.txtDBSID.Location = new System.Drawing.Point(114, 72);
            this.txtDBSID.Name = "txtDBSID";
            this.txtDBSID.Size = new System.Drawing.Size(199, 21);
            this.txtDBSID.TabIndex = 8;
            this.txtDBSID.Text = "OHMXDB";
            // 
            // lbDBStatus
            // 
            this.lbDBStatus.AutoSize = true;
            this.lbDBStatus.Font = new System.Drawing.Font("굴림", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDBStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.lbDBStatus.Location = new System.Drawing.Point(575, 141);
            this.lbDBStatus.Name = "lbDBStatus";
            this.lbDBStatus.Size = new System.Drawing.Size(239, 15);
            this.lbDBStatus.TabIndex = 7;
            this.lbDBStatus.Text = "유효하지 않은 접속정보 입니다.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(4, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "USER PW";
            // 
            // txtUSERPW
            // 
            this.txtUSERPW.Location = new System.Drawing.Point(114, 130);
            this.txtUSERPW.Name = "txtUSERPW";
            this.txtUSERPW.PasswordChar = '*';
            this.txtUSERPW.Size = new System.Drawing.Size(199, 21);
            this.txtUSERPW.TabIndex = 4;
            this.txtUSERPW.Text = "12345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(4, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "USER ID";
            // 
            // txtUSERID
            // 
            this.txtUSERID.Location = new System.Drawing.Point(114, 101);
            this.txtUSERID.Name = "txtUSERID";
            this.txtUSERID.Size = new System.Drawing.Size(199, 21);
            this.txtUSERID.TabIndex = 2;
            this.txtUSERID.Text = "KY_K_POWDER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "DB IP";
            // 
            // txtDBIP
            // 
            this.txtDBIP.Location = new System.Drawing.Point(114, 16);
            this.txtDBIP.Name = "txtDBIP";
            this.txtDBIP.Size = new System.Drawing.Size(482, 21);
            this.txtDBIP.TabIndex = 0;
            this.txtDBIP.Text = "hmx-logisol-oracle-db-dev.c5ruasqdgoz7.ap-northeast-2.rds.amazonaws.com";
            // 
            // btnDBTest
            // 
            this.btnDBTest.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDBTest.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnDBTest.Location = new System.Drawing.Point(333, 133);
            this.btnDBTest.Name = "btnDBTest";
            this.btnDBTest.Size = new System.Drawing.Size(121, 23);
            this.btnDBTest.TabIndex = 6;
            this.btnDBTest.Text = "Connection Test";
            this.btnDBTest.UseVisualStyleBackColor = true;
            this.btnDBTest.Click += new System.EventHandler(this.btnDBTest_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(10, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "REG DTM";
            // 
            // cmbSYSID
            // 
            this.cmbSYSID.FormattingEnabled = true;
            this.cmbSYSID.Location = new System.Drawing.Point(325, 225);
            this.cmbSYSID.Name = "cmbSYSID";
            this.cmbSYSID.Size = new System.Drawing.Size(121, 20);
            this.cmbSYSID.TabIndex = 37;
            this.cmbSYSID.SelectedIndexChanged += new System.EventHandler(this.cmbSYSID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(265, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "SYS ID";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(85, 191);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.ShowUpDown = true;
            this.dtFromDate.Size = new System.Drawing.Size(160, 21);
            this.dtFromDate.TabIndex = 30;
            this.dtFromDate.Value = new System.DateTime(2024, 10, 28, 10, 29, 42, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(695, 208);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 72);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "조    회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(287, 191);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.ShowUpDown = true;
            this.dtToDate.Size = new System.Drawing.Size(160, 21);
            this.dtToDate.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "~";
            // 
            // cmbSite
            // 
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(84, 225);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(121, 20);
            this.cmbSite.TabIndex = 34;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(33, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = " SITE";
            // 
            // dtViewEquipLog
            // 
            this.dtViewEquipLog.AllowUserToAddRows = false;
            this.dtViewEquipLog.AllowUserToDeleteRows = false;
            this.dtViewEquipLog.AllowUserToResizeColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtViewEquipLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtViewEquipLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtViewEquipLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dtViewEquipLog.Location = new System.Drawing.Point(11, 295);
            this.dtViewEquipLog.Name = "dtViewEquipLog";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtViewEquipLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtViewEquipLog.RowHeadersVisible = false;
            this.dtViewEquipLog.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtViewEquipLog.RowTemplate.Height = 23;
            this.dtViewEquipLog.Size = new System.Drawing.Size(820, 494);
            this.dtViewEquipLog.TabIndex = 39;
            this.dtViewEquipLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtViewEquipLog_MouseDown);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(713, 804);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(118, 59);
            this.btnRun.TabIndex = 40;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // cmbPLCNO
            // 
            this.cmbPLCNO.FormattingEnabled = true;
            this.cmbPLCNO.Location = new System.Drawing.Point(553, 227);
            this.cmbPLCNO.Name = "cmbPLCNO";
            this.cmbPLCNO.Size = new System.Drawing.Size(121, 20);
            this.cmbPLCNO.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(493, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "PLC NO";
            // 
            // lbTotCnt
            // 
            this.lbTotCnt.AutoSize = true;
            this.lbTotCnt.Location = new System.Drawing.Point(25, 804);
            this.lbTotCnt.Name = "lbTotCnt";
            this.lbTotCnt.Size = new System.Drawing.Size(31, 12);
            this.lbTotCnt.TabIndex = 43;
            this.lbTotCnt.Text = "0 건 ";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(84, 260);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbStatus.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(24, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 44;
            this.label10.Text = "RMK";
            // 
            // cmbStatt
            // 
            this.cmbStatt.FormattingEnabled = true;
            this.cmbStatt.Location = new System.Drawing.Point(325, 257);
            this.cmbStatt.Name = "cmbStatt";
            this.cmbStatt.Size = new System.Drawing.Size(121, 20);
            this.cmbStatt.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(269, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 12);
            this.label11.TabIndex = 46;
            this.label11.Text = "Status";
            // 
            // cmbRunType
            // 
            this.cmbRunType.FormattingEnabled = true;
            this.cmbRunType.Location = new System.Drawing.Point(553, 192);
            this.cmbRunType.Name = "cmbRunType";
            this.cmbRunType.Size = new System.Drawing.Size(121, 20);
            this.cmbRunType.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(479, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "Run Type";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(589, 804);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 59);
            this.btnReset.TabIndex = 50;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID_T_EQUIP_LOG";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SITE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "SYS_ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "TRACK_ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "STATUS";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CYCLE_COUNT";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "RMK";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "REG_DTM";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 210;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "CYCLE_TIME";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ACTION";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(553, 257);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(121, 20);
            this.cmbAction.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(497, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 12);
            this.label13.TabIndex = 51;
            this.label13.Text = "Action";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(843, 871);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cmbRunType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbStatt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbTotCnt);
            this.Controls.Add(this.cmbPLCNO);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dtViewEquipLog);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSYSID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpDBInfo);
            this.Name = "Form1";
            this.Text = "CycleSample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpDBInfo.ResumeLayout(false);
            this.grpDBInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtViewEquipLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDBInfo;
        private System.Windows.Forms.TextBox txtDBPORT;
        private System.Windows.Forms.Label lbDBPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDBSID;
        private System.Windows.Forms.Label lbDBStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUSERPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUSERID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDBIP;
        private System.Windows.Forms.Button btnDBTest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSYSID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtViewEquipLog;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox cmbPLCNO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotCnt;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbStatt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbRunType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label label13;
    }
}

