namespace MainApp
{
    partial class LoanApplicationApproval
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOneDateSearch = new System.Windows.Forms.Button();
            this.cboSingleYearSearch = new System.Windows.Forms.ComboBox();
            this.cboSingleMonthSearch = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datLoanApplicationGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtFileNoSearch = new System.Windows.Forms.TextBox();
            this.btnFileNoSearch = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboToMonth = new System.Windows.Forms.ComboBox();
            this.cboToYear = new System.Windows.Forms.ComboBox();
            this.cboFromMonth = new System.Windows.Forms.ComboBox();
            this.btnBetweenDateSearch = new System.Windows.Forms.Button();
            this.cboFromYear = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTransactionIDSearch = new System.Windows.Forms.TextBox();
            this.btnTransactionIDSearch = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnStatusSearch = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRepaymentDate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtInterestAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalRepayment = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMonthRepayment = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.picSurety1 = new System.Windows.Forms.PictureBox();
            this.picSurety2 = new System.Windows.Forms.PictureBox();
            this.picWitness = new System.Windows.Forms.PictureBox();
            this.lblSurety1 = new System.Windows.Forms.Label();
            this.lblSurety2 = new System.Windows.Forms.Label();
            this.lblWitness = new System.Windows.Forms.Label();
            this.txtMemberProfile = new System.Windows.Forms.TextBox();
            this.lblMemberFileNo = new System.Windows.Forms.Label();
            this.lblApprovalStatus = new System.Windows.Forms.Label();
            this.txtApplicationDate = new System.Windows.Forms.TextBox();
            this.grpApproval = new System.Windows.Forms.GroupBox();
            this.btnPerformAction = new System.Windows.Forms.Button();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtApplicationID = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datLoanApplicationGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSurety1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSurety2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWitness)).BeginInit();
            this.grpApproval.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOneDateSearch);
            this.groupBox1.Controls.Add(this.cboSingleYearSearch);
            this.groupBox1.Controls.Add(this.cboSingleMonthSearch);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By Date";
            // 
            // btnOneDateSearch
            // 
            this.btnOneDateSearch.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnOneDateSearch.Location = new System.Drawing.Point(159, 21);
            this.btnOneDateSearch.Name = "btnOneDateSearch";
            this.btnOneDateSearch.Size = new System.Drawing.Size(51, 40);
            this.btnOneDateSearch.TabIndex = 2;
            this.btnOneDateSearch.UseVisualStyleBackColor = true;
            this.btnOneDateSearch.Click += new System.EventHandler(this.btnOneDateSearch_Click);
            // 
            // cboSingleYearSearch
            // 
            this.cboSingleYearSearch.FormattingEnabled = true;
            this.cboSingleYearSearch.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboSingleYearSearch.Location = new System.Drawing.Point(95, 30);
            this.cboSingleYearSearch.Name = "cboSingleYearSearch";
            this.cboSingleYearSearch.Size = new System.Drawing.Size(62, 23);
            this.cboSingleYearSearch.TabIndex = 1;
            // 
            // cboSingleMonthSearch
            // 
            this.cboSingleMonthSearch.FormattingEnabled = true;
            this.cboSingleMonthSearch.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboSingleMonthSearch.Location = new System.Drawing.Point(11, 30);
            this.cboSingleMonthSearch.Name = "cboSingleMonthSearch";
            this.cboSingleMonthSearch.Size = new System.Drawing.Size(83, 23);
            this.cboSingleMonthSearch.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datLoanApplicationGridView);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1126, 249);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Applications";
            // 
            // datLoanApplicationGridView
            // 
            this.datLoanApplicationGridView.AllowUserToAddRows = false;
            this.datLoanApplicationGridView.AllowUserToDeleteRows = false;
            this.datLoanApplicationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datLoanApplicationGridView.Location = new System.Drawing.Point(10, 22);
            this.datLoanApplicationGridView.Name = "datLoanApplicationGridView";
            this.datLoanApplicationGridView.Size = new System.Drawing.Size(1110, 217);
            this.datLoanApplicationGridView.TabIndex = 0;
            this.datLoanApplicationGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datLoanApplicationGridView_CellClick);
            this.datLoanApplicationGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datLoanApplicationGridView_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFileNoSearch);
            this.groupBox4.Controls.Add(this.btnFileNoSearch);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(620, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(147, 70);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search  By File No.";
            // 
            // txtFileNoSearch
            // 
            this.txtFileNoSearch.Location = new System.Drawing.Point(6, 30);
            this.txtFileNoSearch.Name = "txtFileNoSearch";
            this.txtFileNoSearch.Size = new System.Drawing.Size(81, 23);
            this.txtFileNoSearch.TabIndex = 3;
            // 
            // btnFileNoSearch
            // 
            this.btnFileNoSearch.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFileNoSearch.Location = new System.Drawing.Point(89, 21);
            this.btnFileNoSearch.Name = "btnFileNoSearch";
            this.btnFileNoSearch.Size = new System.Drawing.Size(51, 40);
            this.btnFileNoSearch.TabIndex = 2;
            this.btnFileNoSearch.UseVisualStyleBackColor = true;
            this.btnFileNoSearch.Click += new System.EventHandler(this.btnFileNoSearch_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.cboToMonth);
            this.groupBox5.Controls.Add(this.cboToYear);
            this.groupBox5.Controls.Add(this.cboFromMonth);
            this.groupBox5.Controls.Add(this.btnBetweenDateSearch);
            this.groupBox5.Controls.Add(this.cboFromYear);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(229, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(385, 70);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search  By Dates";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "To";
            // 
            // cboToMonth
            // 
            this.cboToMonth.FormattingEnabled = true;
            this.cboToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboToMonth.Location = new System.Drawing.Point(182, 30);
            this.cboToMonth.Name = "cboToMonth";
            this.cboToMonth.Size = new System.Drawing.Size(83, 23);
            this.cboToMonth.TabIndex = 5;
            // 
            // cboToYear
            // 
            this.cboToYear.FormattingEnabled = true;
            this.cboToYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboToYear.Location = new System.Drawing.Point(266, 30);
            this.cboToYear.Name = "cboToYear";
            this.cboToYear.Size = new System.Drawing.Size(62, 23);
            this.cboToYear.TabIndex = 4;
            // 
            // cboFromMonth
            // 
            this.cboFromMonth.FormattingEnabled = true;
            this.cboFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboFromMonth.Location = new System.Drawing.Point(6, 30);
            this.cboFromMonth.Name = "cboFromMonth";
            this.cboFromMonth.Size = new System.Drawing.Size(83, 23);
            this.cboFromMonth.TabIndex = 3;
            // 
            // btnBetweenDateSearch
            // 
            this.btnBetweenDateSearch.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnBetweenDateSearch.Location = new System.Drawing.Point(329, 21);
            this.btnBetweenDateSearch.Name = "btnBetweenDateSearch";
            this.btnBetweenDateSearch.Size = new System.Drawing.Size(51, 40);
            this.btnBetweenDateSearch.TabIndex = 2;
            this.btnBetweenDateSearch.UseVisualStyleBackColor = true;
            this.btnBetweenDateSearch.Click += new System.EventHandler(this.btnBetweenDateSearch_Click);
            // 
            // cboFromYear
            // 
            this.cboFromYear.FormattingEnabled = true;
            this.cboFromYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboFromYear.Location = new System.Drawing.Point(91, 30);
            this.cboFromYear.Name = "cboFromYear";
            this.cboFromYear.Size = new System.Drawing.Size(62, 23);
            this.cboFromYear.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTransactionIDSearch);
            this.groupBox6.Controls.Add(this.btnTransactionIDSearch);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(772, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(208, 70);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search  By Transaction ID";
            // 
            // txtTransactionIDSearch
            // 
            this.txtTransactionIDSearch.Location = new System.Drawing.Point(6, 30);
            this.txtTransactionIDSearch.Name = "txtTransactionIDSearch";
            this.txtTransactionIDSearch.Size = new System.Drawing.Size(144, 23);
            this.txtTransactionIDSearch.TabIndex = 3;
            // 
            // btnTransactionIDSearch
            // 
            this.btnTransactionIDSearch.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnTransactionIDSearch.Location = new System.Drawing.Point(153, 20);
            this.btnTransactionIDSearch.Name = "btnTransactionIDSearch";
            this.btnTransactionIDSearch.Size = new System.Drawing.Size(51, 40);
            this.btnTransactionIDSearch.TabIndex = 2;
            this.btnTransactionIDSearch.UseVisualStyleBackColor = true;
            this.btnTransactionIDSearch.Click += new System.EventHandler(this.btnTransactionIDSearch_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnStatusSearch);
            this.groupBox8.Controls.Add(this.cboStatus);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(986, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(153, 70);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Status";
            // 
            // btnStatusSearch
            // 
            this.btnStatusSearch.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnStatusSearch.Location = new System.Drawing.Point(98, 22);
            this.btnStatusSearch.Name = "btnStatusSearch";
            this.btnStatusSearch.Size = new System.Drawing.Size(51, 40);
            this.btnStatusSearch.TabIndex = 4;
            this.btnStatusSearch.UseVisualStyleBackColor = true;
            this.btnStatusSearch.Click += new System.EventHandler(this.btnStatusSearch_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Pending",
            "Approved",
            "Unapproved"});
            this.cboStatus.Location = new System.Drawing.Point(5, 30);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(91, 23);
            this.cboStatus.TabIndex = 0;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(1029, 20);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(92, 91);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 0;
            this.picMember.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(95, 15);
            this.label22.TabIndex = 2;
            this.label22.Text = "Application Date";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 97);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 15);
            this.label21.TabIndex = 3;
            this.label21.Text = "Loan Category";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(110, 92);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(227, 23);
            this.txtCategory.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(36, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 15);
            this.label20.TabIndex = 5;
            this.label20.Text = "Loan Type";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(110, 122);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(227, 23);
            this.txtType.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 155);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 15);
            this.label19.TabIndex = 7;
            this.label19.Text = "Loan Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(110, 152);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(227, 23);
            this.txtAmount.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 15);
            this.label18.TabIndex = 9;
            this.label18.Text = "Repayment Date";
            // 
            // txtRepaymentDate
            // 
            this.txtRepaymentDate.Location = new System.Drawing.Point(110, 182);
            this.txtRepaymentDate.Name = "txtRepaymentDate";
            this.txtRepaymentDate.ReadOnly = true;
            this.txtRepaymentDate.Size = new System.Drawing.Size(227, 23);
            this.txtRepaymentDate.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(376, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 15);
            this.label17.TabIndex = 11;
            this.label17.Text = "Loan Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(467, 68);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(49, 23);
            this.txtDuration.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(386, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 15);
            this.label16.TabIndex = 13;
            this.label16.Text = "Interest Rate";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(467, 96);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.ReadOnly = true;
            this.txtInterestRate.Size = new System.Drawing.Size(73, 23);
            this.txtInterestRate.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(365, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 15);
            this.label15.TabIndex = 15;
            this.label15.Text = "Interest Amount";
            // 
            // txtInterestAmount
            // 
            this.txtInterestAmount.Location = new System.Drawing.Point(467, 124);
            this.txtInterestAmount.Name = "txtInterestAmount";
            this.txtInterestAmount.ReadOnly = true;
            this.txtInterestAmount.Size = new System.Drawing.Size(152, 23);
            this.txtInterestAmount.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "Total Repayment";
            // 
            // txtTotalRepayment
            // 
            this.txtTotalRepayment.Location = new System.Drawing.Point(467, 152);
            this.txtTotalRepayment.Name = "txtTotalRepayment";
            this.txtTotalRepayment.ReadOnly = true;
            this.txtTotalRepayment.Size = new System.Drawing.Size(171, 23);
            this.txtTotalRepayment.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(343, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 19;
            this.label13.Text = "Monthly Repayment";
            // 
            // txtMonthRepayment
            // 
            this.txtMonthRepayment.Location = new System.Drawing.Point(467, 180);
            this.txtMonthRepayment.Name = "txtMonthRepayment";
            this.txtMonthRepayment.ReadOnly = true;
            this.txtMonthRepayment.Size = new System.Drawing.Size(171, 23);
            this.txtMonthRepayment.TabIndex = 20;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(375, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(83, 15);
            this.label24.TabIndex = 21;
            this.label24.Text = "Transaction ID";
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Location = new System.Drawing.Point(467, 39);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.ReadOnly = true;
            this.txtTransactionID.Size = new System.Drawing.Size(170, 23);
            this.txtTransactionID.TabIndex = 22;
            // 
            // picSurety1
            // 
            this.picSurety1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSurety1.Image = global::MainApp.Properties.Resources.profile_img;
            this.picSurety1.Location = new System.Drawing.Point(644, 26);
            this.picSurety1.Name = "picSurety1";
            this.picSurety1.Size = new System.Drawing.Size(69, 60);
            this.picSurety1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSurety1.TabIndex = 23;
            this.picSurety1.TabStop = false;
            // 
            // picSurety2
            // 
            this.picSurety2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSurety2.Image = global::MainApp.Properties.Resources.profile_img;
            this.picSurety2.Location = new System.Drawing.Point(644, 90);
            this.picSurety2.Name = "picSurety2";
            this.picSurety2.Size = new System.Drawing.Size(69, 55);
            this.picSurety2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSurety2.TabIndex = 24;
            this.picSurety2.TabStop = false;
            // 
            // picWitness
            // 
            this.picWitness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWitness.Image = global::MainApp.Properties.Resources.profile_img;
            this.picWitness.Location = new System.Drawing.Point(644, 148);
            this.picWitness.Name = "picWitness";
            this.picWitness.Size = new System.Drawing.Size(69, 58);
            this.picWitness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWitness.TabIndex = 25;
            this.picWitness.TabStop = false;
            // 
            // lblSurety1
            // 
            this.lblSurety1.AutoSize = true;
            this.lblSurety1.Location = new System.Drawing.Point(715, 50);
            this.lblSurety1.Name = "lblSurety1";
            this.lblSurety1.Size = new System.Drawing.Size(59, 15);
            this.lblSurety1.TabIndex = 26;
            this.lblSurety1.Text = "lblSurety1";
            // 
            // lblSurety2
            // 
            this.lblSurety2.AutoSize = true;
            this.lblSurety2.Location = new System.Drawing.Point(715, 104);
            this.lblSurety2.Name = "lblSurety2";
            this.lblSurety2.Size = new System.Drawing.Size(59, 15);
            this.lblSurety2.TabIndex = 27;
            this.lblSurety2.Text = "lblSurety2";
            // 
            // lblWitness
            // 
            this.lblWitness.AutoSize = true;
            this.lblWitness.Location = new System.Drawing.Point(715, 162);
            this.lblWitness.Name = "lblWitness";
            this.lblWitness.Size = new System.Drawing.Size(61, 15);
            this.lblWitness.TabIndex = 28;
            this.lblWitness.Text = "lblWitness";
            // 
            // txtMemberProfile
            // 
            this.txtMemberProfile.Location = new System.Drawing.Point(837, 19);
            this.txtMemberProfile.Name = "txtMemberProfile";
            this.txtMemberProfile.ReadOnly = true;
            this.txtMemberProfile.Size = new System.Drawing.Size(190, 23);
            this.txtMemberProfile.TabIndex = 29;
            // 
            // lblMemberFileNo
            // 
            this.lblMemberFileNo.AutoSize = true;
            this.lblMemberFileNo.Location = new System.Drawing.Point(969, 48);
            this.lblMemberFileNo.Name = "lblMemberFileNo";
            this.lblMemberFileNo.Size = new System.Drawing.Size(54, 15);
            this.lblMemberFileNo.TabIndex = 30;
            this.lblMemberFileNo.Text = "lblFileNo";
            // 
            // lblApprovalStatus
            // 
            this.lblApprovalStatus.AutoSize = true;
            this.lblApprovalStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApprovalStatus.Location = new System.Drawing.Point(194, 31);
            this.lblApprovalStatus.Name = "lblApprovalStatus";
            this.lblApprovalStatus.Size = new System.Drawing.Size(134, 20);
            this.lblApprovalStatus.TabIndex = 31;
            this.lblApprovalStatus.Text = "lblApprovalStatus";
            // 
            // txtApplicationDate
            // 
            this.txtApplicationDate.Location = new System.Drawing.Point(109, 63);
            this.txtApplicationDate.Name = "txtApplicationDate";
            this.txtApplicationDate.ReadOnly = true;
            this.txtApplicationDate.Size = new System.Drawing.Size(227, 23);
            this.txtApplicationDate.TabIndex = 32;
            // 
            // grpApproval
            // 
            this.grpApproval.Controls.Add(this.btnPerformAction);
            this.grpApproval.Controls.Add(this.radNo);
            this.grpApproval.Controls.Add(this.radYes);
            this.grpApproval.Location = new System.Drawing.Point(993, 125);
            this.grpApproval.Name = "grpApproval";
            this.grpApproval.Size = new System.Drawing.Size(128, 77);
            this.grpApproval.TabIndex = 33;
            this.grpApproval.TabStop = false;
            this.grpApproval.Text = "Approve Loan";
            // 
            // btnPerformAction
            // 
            this.btnPerformAction.Location = new System.Drawing.Point(20, 47);
            this.btnPerformAction.Name = "btnPerformAction";
            this.btnPerformAction.Size = new System.Drawing.Size(94, 26);
            this.btnPerformAction.TabIndex = 2;
            this.btnPerformAction.Text = "Perform";
            this.btnPerformAction.UseVisualStyleBackColor = true;
            this.btnPerformAction.Click += new System.EventHandler(this.btnPerformAction_Click);
            // 
            // radNo
            // 
            this.radNo.AutoSize = true;
            this.radNo.Location = new System.Drawing.Point(70, 21);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(41, 19);
            this.radNo.TabIndex = 1;
            this.radNo.TabStop = true;
            this.radNo.Text = "No";
            this.radNo.UseVisualStyleBackColor = true;
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Location = new System.Drawing.Point(24, 21);
            this.radYes.Name = "radYes";
            this.radYes.Size = new System.Drawing.Size(43, 19);
            this.radYes.TabIndex = 0;
            this.radYes.TabStop = true;
            this.radYes.Text = "Yes";
            this.radYes.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(519, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 15);
            this.label23.TabIndex = 34;
            this.label23.Text = "Month";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(543, 101);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 15);
            this.label25.TabIndex = 35;
            this.label25.Text = "%";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 37);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 15);
            this.label26.TabIndex = 37;
            this.label26.Text = "Application ID";
            // 
            // txtApplicationID
            // 
            this.txtApplicationID.Location = new System.Drawing.Point(109, 35);
            this.txtApplicationID.Name = "txtApplicationID";
            this.txtApplicationID.ReadOnly = true;
            this.txtApplicationID.Size = new System.Drawing.Size(79, 23);
            this.txtApplicationID.TabIndex = 38;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtApplicationID);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.grpApproval);
            this.groupBox7.Controls.Add(this.txtApplicationDate);
            this.groupBox7.Controls.Add(this.lblApprovalStatus);
            this.groupBox7.Controls.Add(this.lblMemberFileNo);
            this.groupBox7.Controls.Add(this.txtMemberProfile);
            this.groupBox7.Controls.Add(this.lblWitness);
            this.groupBox7.Controls.Add(this.lblSurety2);
            this.groupBox7.Controls.Add(this.lblSurety1);
            this.groupBox7.Controls.Add(this.picWitness);
            this.groupBox7.Controls.Add(this.picSurety2);
            this.groupBox7.Controls.Add(this.picSurety1);
            this.groupBox7.Controls.Add(this.txtTransactionID);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.txtMonthRepayment);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.txtTotalRepayment);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.txtInterestAmount);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.txtInterestRate);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.txtDuration);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.txtRepaymentDate);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.txtAmount);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.txtType);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.txtCategory);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.picMember);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(12, 342);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1127, 211);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Application Details";
            this.groupBox7.Visible = false;
            // 
            // LoanApplicationApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 552);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoanApplicationApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans | Loan Application Status";
            this.Load += new System.EventHandler(this.LoanApplicationApproval_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datLoanApplicationGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSurety1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSurety2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWitness)).EndInit();
            this.grpApproval.ResumeLayout(false);
            this.grpApproval.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOneDateSearch;
        private System.Windows.Forms.ComboBox cboSingleYearSearch;
        private System.Windows.Forms.ComboBox cboSingleMonthSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtFileNoSearch;
        private System.Windows.Forms.Button btnFileNoSearch;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboToMonth;
        private System.Windows.Forms.ComboBox cboToYear;
        private System.Windows.Forms.ComboBox cboFromMonth;
        private System.Windows.Forms.Button btnBetweenDateSearch;
        private System.Windows.Forms.ComboBox cboFromYear;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtTransactionIDSearch;
        private System.Windows.Forms.Button btnTransactionIDSearch;
        private System.Windows.Forms.DataGridView datLoanApplicationGridView;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnStatusSearch;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRepaymentDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtInterestAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalRepayment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMonthRepayment;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtTransactionID;
        private System.Windows.Forms.PictureBox picSurety1;
        private System.Windows.Forms.PictureBox picSurety2;
        private System.Windows.Forms.PictureBox picWitness;
        private System.Windows.Forms.Label lblSurety1;
        private System.Windows.Forms.Label lblSurety2;
        private System.Windows.Forms.Label lblWitness;
        private System.Windows.Forms.TextBox txtMemberProfile;
        private System.Windows.Forms.Label lblMemberFileNo;
        private System.Windows.Forms.Label lblApprovalStatus;
        private System.Windows.Forms.TextBox txtApplicationDate;
        private System.Windows.Forms.GroupBox grpApproval;
        private System.Windows.Forms.Button btnPerformAction;
        private System.Windows.Forms.RadioButton radNo;
        private System.Windows.Forms.RadioButton radYes;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtApplicationID;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}