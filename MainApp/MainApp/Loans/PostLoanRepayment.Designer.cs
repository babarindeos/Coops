namespace MainApp
{
    partial class PostLoanRepayment
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
            this.btnFindLoanByFileNo = new System.Windows.Forms.Button();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.MemberProfileInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datGrdLoans = new System.Windows.Forms.DataGridView();
            this.grpRepayments = new System.Windows.Forms.GroupBox();
            this.lblNumRepayments = new System.Windows.Forms.Label();
            this.datGrdRepayments = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtOutstanding = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.txtMonthlyRepayment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInterestAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRepaymentAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoanType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartRepayment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServicingLoan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpPostRepayment = new System.Windows.Forms.GroupBox();
            this.txtPaymentStatus = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnPostRepayment = new System.Windows.Forms.Button();
            this.txtExtraFeedback = new System.Windows.Forms.TextBox();
            this.txtCalOutstanding = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCalAmountPaid = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gBoxServicingLoan = new System.Windows.Forms.GroupBox();
            this.txtServicingOutstanding = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtServicingAmtPaid = new System.Windows.Forms.TextBox();
            this.txtServicingRepaymentAmt = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdLoans)).BeginInit();
            this.grpRepayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdRepayments)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpPostRepayment.SuspendLayout();
            this.gBoxServicingLoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindLoanByFileNo);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By File No.";
            // 
            // btnFindLoanByFileNo
            // 
            this.btnFindLoanByFileNo.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindLoanByFileNo.Location = new System.Drawing.Point(166, 18);
            this.btnFindLoanByFileNo.Name = "btnFindLoanByFileNo";
            this.btnFindLoanByFileNo.Size = new System.Drawing.Size(51, 39);
            this.btnFindLoanByFileNo.TabIndex = 1;
            this.btnFindLoanByFileNo.UseVisualStyleBackColor = true;
            this.btnFindLoanByFileNo.Click += new System.EventHandler(this.btnFindLoanByFileNo_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(13, 27);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(147, 23);
            this.txtFileNo.TabIndex = 0;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(246, 4);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(82, 78);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 1;
            this.picMember.TabStop = false;
            // 
            // MemberProfileInfo
            // 
            this.MemberProfileInfo.AutoSize = true;
            this.MemberProfileInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberProfileInfo.Location = new System.Drawing.Point(335, 15);
            this.MemberProfileInfo.Name = "MemberProfileInfo";
            this.MemberProfileInfo.Size = new System.Drawing.Size(156, 21);
            this.MemberProfileInfo.TabIndex = 2;
            this.MemberProfileInfo.Text = "MemberProfileInfo";
            this.MemberProfileInfo.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datGrdLoans);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 186);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loans";
            // 
            // datGrdLoans
            // 
            this.datGrdLoans.AllowUserToAddRows = false;
            this.datGrdLoans.AllowUserToDeleteRows = false;
            this.datGrdLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdLoans.Location = new System.Drawing.Point(9, 24);
            this.datGrdLoans.Name = "datGrdLoans";
            this.datGrdLoans.Size = new System.Drawing.Size(590, 152);
            this.datGrdLoans.TabIndex = 0;
            this.datGrdLoans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGrdLoans_CellClick);
            // 
            // grpRepayments
            // 
            this.grpRepayments.Controls.Add(this.lblNumRepayments);
            this.grpRepayments.Controls.Add(this.datGrdRepayments);
            this.grpRepayments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRepayments.Location = new System.Drawing.Point(10, 287);
            this.grpRepayments.Name = "grpRepayments";
            this.grpRepayments.Size = new System.Drawing.Size(761, 253);
            this.grpRepayments.TabIndex = 4;
            this.grpRepayments.TabStop = false;
            this.grpRepayments.Text = "Loan Repayments";
            // 
            // lblNumRepayments
            // 
            this.lblNumRepayments.AutoSize = true;
            this.lblNumRepayments.Location = new System.Drawing.Point(13, 232);
            this.lblNumRepayments.Name = "lblNumRepayments";
            this.lblNumRepayments.Size = new System.Drawing.Size(85, 15);
            this.lblNumRepayments.TabIndex = 1;
            this.lblNumRepayments.Text = "No. of Records";
            // 
            // datGrdRepayments
            // 
            this.datGrdRepayments.AllowUserToAddRows = false;
            this.datGrdRepayments.AllowUserToDeleteRows = false;
            this.datGrdRepayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdRepayments.Location = new System.Drawing.Point(11, 21);
            this.datGrdRepayments.Name = "datGrdRepayments";
            this.datGrdRepayments.Size = new System.Drawing.Size(744, 205);
            this.datGrdRepayments.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtOutstanding);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtAmountPaid);
            this.groupBox4.Controls.Add(this.txtMonthlyRepayment);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtInterestAmount);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtRepaymentAmount);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtInterestRate);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtDuration);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtLoanAmount);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtLoanType);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtStartRepayment);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(621, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(662, 185);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Loan Details";
            // 
            // txtOutstanding
            // 
            this.txtOutstanding.Location = new System.Drawing.Point(432, 74);
            this.txtOutstanding.Name = "txtOutstanding";
            this.txtOutstanding.ReadOnly = true;
            this.txtOutstanding.Size = new System.Drawing.Size(212, 23);
            this.txtOutstanding.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(355, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Outstanding";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(351, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Amount Paid";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(432, 46);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.ReadOnly = true;
            this.txtAmountPaid.Size = new System.Drawing.Size(212, 23);
            this.txtAmountPaid.TabIndex = 19;
            // 
            // txtMonthlyRepayment
            // 
            this.txtMonthlyRepayment.Location = new System.Drawing.Point(432, 19);
            this.txtMonthlyRepayment.Name = "txtMonthlyRepayment";
            this.txtMonthlyRepayment.ReadOnly = true;
            this.txtMonthlyRepayment.Size = new System.Drawing.Size(212, 23);
            this.txtMonthlyRepayment.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Monthly Payment";
            // 
            // txtInterestAmount
            // 
            this.txtInterestAmount.Location = new System.Drawing.Point(105, 154);
            this.txtInterestAmount.Name = "txtInterestAmount";
            this.txtInterestAmount.ReadOnly = true;
            this.txtInterestAmount.Size = new System.Drawing.Size(203, 23);
            this.txtInterestAmount.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Interest Amt.";
            // 
            // txtRepaymentAmount
            // 
            this.txtRepaymentAmount.Location = new System.Drawing.Point(105, 127);
            this.txtRepaymentAmount.Name = "txtRepaymentAmount";
            this.txtRepaymentAmount.ReadOnly = true;
            this.txtRepaymentAmount.Size = new System.Drawing.Size(203, 23);
            this.txtRepaymentAmount.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Repayment Amt.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "%";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(220, 73);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.ReadOnly = true;
            this.txtInterestRate.Size = new System.Drawing.Size(64, 23);
            this.txtInterestRate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Months";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(105, 73);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(51, 23);
            this.txtDuration.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Duration|Interest";
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Location = new System.Drawing.Point(105, 100);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.ReadOnly = true;
            this.txtLoanAmount.Size = new System.Drawing.Size(203, 23);
            this.txtLoanAmount.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amt. Collected";
            // 
            // txtLoanType
            // 
            this.txtLoanType.Location = new System.Drawing.Point(105, 46);
            this.txtLoanType.Name = "txtLoanType";
            this.txtLoanType.ReadOnly = true;
            this.txtLoanType.Size = new System.Drawing.Size(203, 23);
            this.txtLoanType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loan Type";
            // 
            // txtStartRepayment
            // 
            this.txtStartRepayment.Location = new System.Drawing.Point(105, 19);
            this.txtStartRepayment.Name = "txtStartRepayment";
            this.txtStartRepayment.ReadOnly = true;
            this.txtStartRepayment.Size = new System.Drawing.Size(203, 23);
            this.txtStartRepayment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Repayment";
            // 
            // txtServicingLoan
            // 
            this.txtServicingLoan.Location = new System.Drawing.Point(91, 23);
            this.txtServicingLoan.Name = "txtServicingLoan";
            this.txtServicingLoan.ReadOnly = true;
            this.txtServicingLoan.Size = new System.Drawing.Size(217, 23);
            this.txtServicingLoan.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Servicing Loan";
            // 
            // grpPostRepayment
            // 
            this.grpPostRepayment.Controls.Add(this.txtPaymentStatus);
            this.grpPostRepayment.Controls.Add(this.label19);
            this.grpPostRepayment.Controls.Add(this.label17);
            this.grpPostRepayment.Controls.Add(this.btnPostRepayment);
            this.grpPostRepayment.Controls.Add(this.txtExtraFeedback);
            this.grpPostRepayment.Controls.Add(this.txtCalOutstanding);
            this.grpPostRepayment.Controls.Add(this.txtServicingLoan);
            this.grpPostRepayment.Controls.Add(this.label16);
            this.grpPostRepayment.Controls.Add(this.label10);
            this.grpPostRepayment.Controls.Add(this.label15);
            this.grpPostRepayment.Controls.Add(this.txtCalAmountPaid);
            this.grpPostRepayment.Controls.Add(this.txtRemark);
            this.grpPostRepayment.Controls.Add(this.label14);
            this.grpPostRepayment.Controls.Add(this.txtPayAmount);
            this.grpPostRepayment.Controls.Add(this.label13);
            this.grpPostRepayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPostRepayment.Location = new System.Drawing.Point(777, 287);
            this.grpPostRepayment.Name = "grpPostRepayment";
            this.grpPostRepayment.Size = new System.Drawing.Size(506, 253);
            this.grpPostRepayment.TabIndex = 6;
            this.grpPostRepayment.TabStop = false;
            this.grpPostRepayment.Text = "Post Repayment";
            // 
            // txtPaymentStatus
            // 
            this.txtPaymentStatus.Location = new System.Drawing.Point(91, 221);
            this.txtPaymentStatus.Name = "txtPaymentStatus";
            this.txtPaymentStatus.ReadOnly = true;
            this.txtPaymentStatus.Size = new System.Drawing.Size(217, 23);
            this.txtPaymentStatus.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 223);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 15);
            this.label19.TabIndex = 33;
            this.label19.Text = "Pay Status";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(311, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 15);
            this.label17.TabIndex = 32;
            this.label17.Text = "Extra Feedback";
            // 
            // btnPostRepayment
            // 
            this.btnPostRepayment.Enabled = false;
            this.btnPostRepayment.Location = new System.Drawing.Point(90, 118);
            this.btnPostRepayment.Name = "btnPostRepayment";
            this.btnPostRepayment.Size = new System.Drawing.Size(115, 34);
            this.btnPostRepayment.TabIndex = 31;
            this.btnPostRepayment.Text = "Post Repayment";
            this.btnPostRepayment.UseVisualStyleBackColor = true;
            this.btnPostRepayment.Click += new System.EventHandler(this.btnPostRepayment_Click);
            // 
            // txtExtraFeedback
            // 
            this.txtExtraFeedback.Location = new System.Drawing.Point(314, 43);
            this.txtExtraFeedback.Multiline = true;
            this.txtExtraFeedback.Name = "txtExtraFeedback";
            this.txtExtraFeedback.ReadOnly = true;
            this.txtExtraFeedback.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExtraFeedback.Size = new System.Drawing.Size(186, 204);
            this.txtExtraFeedback.TabIndex = 30;
            // 
            // txtCalOutstanding
            // 
            this.txtCalOutstanding.Location = new System.Drawing.Point(91, 195);
            this.txtCalOutstanding.Name = "txtCalOutstanding";
            this.txtCalOutstanding.ReadOnly = true;
            this.txtCalOutstanding.Size = new System.Drawing.Size(217, 23);
            this.txtCalOutstanding.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 15);
            this.label16.TabIndex = 28;
            this.label16.Text = "Outstanding";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 15);
            this.label15.TabIndex = 27;
            this.label15.Text = "Amount Paid";
            // 
            // txtCalAmountPaid
            // 
            this.txtCalAmountPaid.Location = new System.Drawing.Point(91, 168);
            this.txtCalAmountPaid.Name = "txtCalAmountPaid";
            this.txtCalAmountPaid.ReadOnly = true;
            this.txtCalAmountPaid.Size = new System.Drawing.Size(217, 23);
            this.txtCalAmountPaid.TabIndex = 26;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(91, 76);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(217, 38);
            this.txtRemark.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "Remark";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(91, 49);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(217, 23);
            this.txtPayAmount.TabIndex = 23;
            this.txtPayAmount.TextChanged += new System.EventHandler(this.txtPayAmount_TextChanged);
            this.txtPayAmount.Leave += new System.EventHandler(this.txtPayAmount_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Pay Amount";
            // 
            // gBoxServicingLoan
            // 
            this.gBoxServicingLoan.Controls.Add(this.txtServicingOutstanding);
            this.gBoxServicingLoan.Controls.Add(this.label22);
            this.gBoxServicingLoan.Controls.Add(this.txtServicingAmtPaid);
            this.gBoxServicingLoan.Controls.Add(this.txtServicingRepaymentAmt);
            this.gBoxServicingLoan.Controls.Add(this.label21);
            this.gBoxServicingLoan.Controls.Add(this.label20);
            this.gBoxServicingLoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxServicingLoan.Location = new System.Drawing.Point(950, 6);
            this.gBoxServicingLoan.Name = "gBoxServicingLoan";
            this.gBoxServicingLoan.Size = new System.Drawing.Size(333, 94);
            this.gBoxServicingLoan.TabIndex = 7;
            this.gBoxServicingLoan.TabStop = false;
            this.gBoxServicingLoan.Text = "Currently Servicing Loan";
            // 
            // txtServicingOutstanding
            // 
            this.txtServicingOutstanding.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServicingOutstanding.Location = new System.Drawing.Point(102, 68);
            this.txtServicingOutstanding.Name = "txtServicingOutstanding";
            this.txtServicingOutstanding.ReadOnly = true;
            this.txtServicingOutstanding.Size = new System.Drawing.Size(213, 22);
            this.txtServicingOutstanding.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 71);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 15);
            this.label22.TabIndex = 14;
            this.label22.Text = "Outstanding";
            // 
            // txtServicingAmtPaid
            // 
            this.txtServicingAmtPaid.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServicingAmtPaid.Location = new System.Drawing.Point(102, 44);
            this.txtServicingAmtPaid.Name = "txtServicingAmtPaid";
            this.txtServicingAmtPaid.ReadOnly = true;
            this.txtServicingAmtPaid.Size = new System.Drawing.Size(213, 22);
            this.txtServicingAmtPaid.TabIndex = 13;
            // 
            // txtServicingRepaymentAmt
            // 
            this.txtServicingRepaymentAmt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServicingRepaymentAmt.Location = new System.Drawing.Point(102, 20);
            this.txtServicingRepaymentAmt.Name = "txtServicingRepaymentAmt";
            this.txtServicingRepaymentAmt.ReadOnly = true;
            this.txtServicingRepaymentAmt.Size = new System.Drawing.Size(213, 22);
            this.txtServicingRepaymentAmt.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 15);
            this.label21.TabIndex = 11;
            this.label21.Text = "Amount Paid";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(29, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 15);
            this.label20.TabIndex = 10;
            this.label20.Text = "Repayment";
            // 
            // PostLoanRepayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 552);
            this.Controls.Add(this.gBoxServicingLoan);
            this.Controls.Add(this.grpPostRepayment);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpRepayments);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MemberProfileInfo);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PostLoanRepayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans | Post Repayment";
            this.Load += new System.EventHandler(this.PostLoanRepayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdLoans)).EndInit();
            this.grpRepayments.ResumeLayout(false);
            this.grpRepayments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdRepayments)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpPostRepayment.ResumeLayout(false);
            this.grpPostRepayment.PerformLayout();
            this.gBoxServicingLoan.ResumeLayout(false);
            this.gBoxServicingLoan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindLoanByFileNo;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label MemberProfileInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpRepayments;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView datGrdLoans;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoanAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoanType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartRepayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepaymentAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMonthlyRepayment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInterestAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtServicingLoan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOutstanding;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.DataGridView datGrdRepayments;
        private System.Windows.Forms.GroupBox grpPostRepayment;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCalOutstanding;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCalAmountPaid;
        private System.Windows.Forms.TextBox txtExtraFeedback;
        private System.Windows.Forms.Button btnPostRepayment;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNumRepayments;
        private System.Windows.Forms.TextBox txtPaymentStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gBoxServicingLoan;
        private System.Windows.Forms.TextBox txtServicingAmtPaid;
        private System.Windows.Forms.TextBox txtServicingRepaymentAmt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtServicingOutstanding;
        private System.Windows.Forms.Label label22;
    }
}