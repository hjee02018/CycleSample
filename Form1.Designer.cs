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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpDBInfo = new System.Windows.Forms.GroupBox();
            this.txtDBPORT = new System.Windows.Forms.TextBox();
            this.lbDBPort = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBSID = new System.Windows.Forms.TextBox();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtViewEquipLog = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dtFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtToTime = new System.Windows.Forms.DateTimePicker();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.cmbInOutType = new System.Windows.Forms.ComboBox();
            this.lbINOUTType = new System.Windows.Forms.Label();
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
            this.grpDBInfo.Controls.Add(this.cmbAction);
            this.grpDBInfo.Controls.Add(this.label13);
            this.grpDBInfo.Controls.Add(this.lbDBStatus);
            this.grpDBInfo.Controls.Add(this.label3);
            this.grpDBInfo.Controls.Add(this.txtUSERPW);
            this.grpDBInfo.Controls.Add(this.label2);
            this.grpDBInfo.Controls.Add(this.txtUSERID);
            this.grpDBInfo.Controls.Add(this.label1);
            this.grpDBInfo.Controls.Add(this.txtDBIP);
            this.grpDBInfo.Controls.Add(this.btnDBTest);
            this.grpDBInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpDBInfo.Location = new System.Drawing.Point(11, 12);
            this.grpDBInfo.Name = "grpDBInfo";
            this.grpDBInfo.Size = new System.Drawing.Size(990, 176);
            this.grpDBInfo.TabIndex = 28;
            this.grpDBInfo.TabStop = false;
            this.grpDBInfo.Text = "DB Info";
            // 
            // txtDBPORT
            // 
            this.txtDBPORT.Location = new System.Drawing.Point(128, 43);
            this.txtDBPORT.Name = "txtDBPORT";
            this.txtDBPORT.Size = new System.Drawing.Size(199, 21);
            this.txtDBPORT.TabIndex = 11;
            this.txtDBPORT.Text = "12345";
            // 
            // lbDBPort
            // 
            this.lbDBPort.AutoSize = true;
            this.lbDBPort.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.lbDBPort.ForeColor = System.Drawing.Color.DimGray;
            this.lbDBPort.Location = new System.Drawing.Point(5, 54);
            this.lbDBPort.Name = "lbDBPort";
            this.lbDBPort.Size = new System.Drawing.Size(57, 18);
            this.lbDBPort.TabIndex = 10;
            this.lbDBPort.Text = "DB PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(4, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "ConnectionSID";
            // 
            // txtDBSID
            // 
            this.txtDBSID.Location = new System.Drawing.Point(128, 72);
            this.txtDBSID.Name = "txtDBSID";
            this.txtDBSID.Size = new System.Drawing.Size(199, 21);
            this.txtDBSID.TabIndex = 8;
            this.txtDBSID.Text = "OHMXDB";
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(735, 54);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(121, 20);
            this.cmbAction.TabIndex = 52;
            this.cmbAction.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(654, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 51;
            this.label13.Text = "• ACTION";
            this.label13.Visible = false;
            // 
            // lbDBStatus
            // 
            this.lbDBStatus.AutoSize = true;
            this.lbDBStatus.Font = new System.Drawing.Font("D2Coding", 11.75F, System.Drawing.FontStyle.Bold);
            this.lbDBStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.lbDBStatus.Location = new System.Drawing.Point(636, 139);
            this.lbDBStatus.Name = "lbDBStatus";
            this.lbDBStatus.Size = new System.Drawing.Size(248, 18);
            this.lbDBStatus.TabIndex = 7;
            this.lbDBStatus.Text = "유효하지 않은 접속정보 입니다.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(4, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "USER PW";
            // 
            // txtUSERPW
            // 
            this.txtUSERPW.Location = new System.Drawing.Point(128, 130);
            this.txtUSERPW.Name = "txtUSERPW";
            this.txtUSERPW.PasswordChar = '*';
            this.txtUSERPW.Size = new System.Drawing.Size(199, 21);
            this.txtUSERPW.TabIndex = 4;
            this.txtUSERPW.Text = "12345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(4, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "USER ID";
            // 
            // txtUSERID
            // 
            this.txtUSERID.Location = new System.Drawing.Point(128, 101);
            this.txtUSERID.Name = "txtUSERID";
            this.txtUSERID.Size = new System.Drawing.Size(199, 21);
            this.txtUSERID.TabIndex = 2;
            this.txtUSERID.Text = "KY_K_POWDER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "DB IP";
            // 
            // txtDBIP
            // 
            this.txtDBIP.Location = new System.Drawing.Point(128, 16);
            this.txtDBIP.Name = "txtDBIP";
            this.txtDBIP.Size = new System.Drawing.Size(482, 21);
            this.txtDBIP.TabIndex = 0;
            this.txtDBIP.Text = "hmx-logisol-oracle-db-dev.c5ruasqdgoz7.ap-northeast-2.rds.amazonaws.com";
            // 
            // btnDBTest
            // 
            this.btnDBTest.Font = new System.Drawing.Font("D2Coding", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDBTest.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnDBTest.Location = new System.Drawing.Point(343, 130);
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
            this.label9.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(20, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 18);
            this.label9.TabIndex = 38;
            this.label9.Text = "REG DTM";
            // 
            // cmbSYSID
            // 
            this.cmbSYSID.FormattingEnabled = true;
            this.cmbSYSID.Location = new System.Drawing.Point(383, 245);
            this.cmbSYSID.Name = "cmbSYSID";
            this.cmbSYSID.Size = new System.Drawing.Size(121, 20);
            this.cmbSYSID.TabIndex = 37;
            this.cmbSYSID.SelectedIndexChanged += new System.EventHandler(this.cmbSYSID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(302, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "• SYS ID";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(95, 202);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.ShowUpDown = true;
            this.dtFromDate.Size = new System.Drawing.Size(100, 21);
            this.dtFromDate.TabIndex = 30;
            this.dtFromDate.Value = new System.DateTime(2024, 10, 28, 10, 29, 42, 0);
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(323, 202);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.ShowUpDown = true;
            this.dtToDate.Size = new System.Drawing.Size(100, 21);
            this.dtToDate.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "~";
            // 
            // cmbSite
            // 
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(95, 244);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(121, 20);
            this.cmbSite.TabIndex = 34;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(27, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "•  SITE";
            // 
            // dtViewEquipLog
            // 
            this.dtViewEquipLog.AllowUserToAddRows = false;
            this.dtViewEquipLog.AllowUserToDeleteRows = false;
            this.dtViewEquipLog.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("D2Coding", 9F);
            this.dtViewEquipLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtViewEquipLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtViewEquipLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtViewEquipLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column10,
            this.Column9,
            this.Column8});
            this.dtViewEquipLog.Location = new System.Drawing.Point(11, 323);
            this.dtViewEquipLog.Name = "dtViewEquipLog";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("D2Coding", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtViewEquipLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtViewEquipLog.RowHeadersVisible = false;
            this.dtViewEquipLog.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtViewEquipLog.RowTemplate.Height = 23;
            this.dtViewEquipLog.Size = new System.Drawing.Size(990, 496);
            this.dtViewEquipLog.TabIndex = 39;
            this.dtViewEquipLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtViewEquipLog_MouseDown);
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
            this.Column2.Width = 60;
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
            // Column7
            // 
            this.Column7.HeaderText = "RMK";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CYCLE_COUNT";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 110;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ACTION";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 90;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "CYCLE_TIME";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 120;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "REG_DTM";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 220;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Silver;
            this.btnRun.Font = new System.Drawing.Font("D2Coding", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnRun.Location = new System.Drawing.Point(885, 825);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(118, 40);
            this.btnRun.TabIndex = 40;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // cmbPLCNO
            // 
            this.cmbPLCNO.FormattingEnabled = true;
            this.cmbPLCNO.Location = new System.Drawing.Point(95, 283);
            this.cmbPLCNO.Name = "cmbPLCNO";
            this.cmbPLCNO.Size = new System.Drawing.Size(121, 20);
            this.cmbPLCNO.TabIndex = 42;
            this.cmbPLCNO.SelectedIndexChanged += new System.EventHandler(this.cmbPLCNO_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(27, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "• PLC NO";
            // 
            // lbTotCnt
            // 
            this.lbTotCnt.AutoSize = true;
            this.lbTotCnt.Location = new System.Drawing.Point(12, 831);
            this.lbTotCnt.Name = "lbTotCnt";
            this.lbTotCnt.Size = new System.Drawing.Size(31, 12);
            this.lbTotCnt.TabIndex = 43;
            this.lbTotCnt.Text = "0 건 ";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(650, 285);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbStatus.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(555, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 18);
            this.label10.TabIndex = 44;
            this.label10.Text = "• RMK";
            // 
            // cmbStatt
            // 
            this.cmbStatt.FormattingEnabled = true;
            this.cmbStatt.Location = new System.Drawing.Point(383, 285);
            this.cmbStatt.Name = "cmbStatt";
            this.cmbStatt.Size = new System.Drawing.Size(121, 20);
            this.cmbStatt.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(302, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 18);
            this.label11.TabIndex = 46;
            this.label11.Text = "• STATUS";
            // 
            // cmbRunType
            // 
            this.cmbRunType.FormattingEnabled = true;
            this.cmbRunType.Location = new System.Drawing.Point(650, 242);
            this.cmbRunType.Name = "cmbRunType";
            this.cmbRunType.Size = new System.Drawing.Size(121, 20);
            this.cmbRunType.TabIndex = 49;
            this.cmbRunType.SelectedIndexChanged += new System.EventHandler(this.cmbRunType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(555, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 18);
            this.label12.TabIndex = 48;
            this.label12.Text = "• Run Type";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Silver;
            this.btnReset.Font = new System.Drawing.Font("D2Coding", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnReset.Location = new System.Drawing.Point(761, 825);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 40);
            this.btnReset.TabIndex = 50;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtFromTime
            // 
            this.dtFromTime.CustomFormat = "HH:mm:ss";
            this.dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromTime.Location = new System.Drawing.Point(203, 202);
            this.dtFromTime.Name = "dtFromTime";
            this.dtFromTime.ShowUpDown = true;
            this.dtFromTime.Size = new System.Drawing.Size(82, 21);
            this.dtFromTime.TabIndex = 53;
            this.dtFromTime.Value = new System.DateTime(2024, 10, 28, 10, 29, 42, 0);
            // 
            // dtToTime
            // 
            this.dtToTime.CustomFormat = "HH:mm:ss";
            this.dtToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToTime.Location = new System.Drawing.Point(436, 202);
            this.dtToTime.Name = "dtToTime";
            this.dtToTime.ShowUpDown = true;
            this.dtToTime.Size = new System.Drawing.Size(82, 21);
            this.dtToTime.TabIndex = 54;
            this.dtToTime.Value = new System.DateTime(2024, 10, 28, 10, 29, 42, 0);
            // 
            // btnExtract
            // 
            this.btnExtract.BackColor = System.Drawing.Color.Silver;
            this.btnExtract.Font = new System.Drawing.Font("D2Coding", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnExtract.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnExtract.Location = new System.Drawing.Point(637, 825);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(118, 40);
            this.btnExtract.TabIndex = 55;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(109)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(109)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("D2Coding", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnSearch.Location = new System.Drawing.Point(880, 279);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 32);
            this.btnSearch.TabIndex = 148;
            this.btnSearch.Text = "Select";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(49, 831);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(41, 12);
            this.lbTotal.TabIndex = 149;
            this.lbTotal.Text = "/ 0 건 ";
            // 
            // cmbInOutType
            // 
            this.cmbInOutType.FormattingEnabled = true;
            this.cmbInOutType.Location = new System.Drawing.Point(880, 242);
            this.cmbInOutType.Name = "cmbInOutType";
            this.cmbInOutType.Size = new System.Drawing.Size(121, 20);
            this.cmbInOutType.TabIndex = 151;
            this.cmbInOutType.Visible = false;
            // 
            // lbINOUTType
            // 
            this.lbINOUTType.AutoSize = true;
            this.lbINOUTType.Font = new System.Drawing.Font("D2Coding", 10.75F);
            this.lbINOUTType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbINOUTType.Location = new System.Drawing.Point(785, 244);
            this.lbINOUTType.Name = "lbINOUTType";
            this.lbINOUTType.Size = new System.Drawing.Size(64, 18);
            this.lbINOUTType.TabIndex = 150;
            this.lbINOUTType.Text = "• IN/OUT";
            this.lbINOUTType.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1013, 871);
            this.Controls.Add(this.cmbInOutType);
            this.Controls.Add(this.lbINOUTType);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.dtToTime);
            this.Controls.Add(this.dtFromTime);
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
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpDBInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "CycleFRun";
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
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtFromTime;
        private System.Windows.Forms.DateTimePicker dtToTime;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.ComboBox cmbInOutType;
        private System.Windows.Forms.Label lbINOUTType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}

