namespace MainApp
{
    partial class ViewLoanApplication
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
            this.cboApproval = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datGrdVwLoanApplications = new System.Windows.Forms.DataGridView();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOutstandingAmt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRepaymentStatus = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoanApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboApproval);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.cboPayment);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1249, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cboApproval
            // 
            this.cboApproval.FormattingEnabled = true;
            this.cboApproval.Items.AddRange(new object[] {
            "",
            "Yes",
            "No",
            "Pending"});
            this.cboApproval.Location = new System.Drawing.Point(887, 31);
            this.cboApproval.Name = "cboApproval";
            this.cboApproval.Size = new System.Drawing.Size(65, 23);
            this.cboApproval.TabIndex = 15;
            this.cboApproval.SelectedIndexChanged += new System.EventHandler(this.cboApproval_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(831, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Approval";
            // 
            // cboPayment
            // 
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Items.AddRange(new object[] {
            "",
            "Paying",
            "PAID"});
            this.cboPayment.Location = new System.Drawing.Point(1014, 30);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(77, 23);
            this.cboPayment.TabIndex = 11;
            this.cboPayment.SelectedIndexChanged += new System.EventHandler(this.cboPayment_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(958, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Payment";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(687, 30);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(138, 23);
            this.cboType.TabIndex = 9;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(510, 30);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(133, 23);
            this.cboCategory.TabIndex = 7;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "",
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
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.cboYear.Location = new System.Drawing.Point(343, 30);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(104, 23);
            this.cboYear.TabIndex = 5;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year";
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "",
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
            this.cboMonth.Location = new System.Drawing.Point(200, 30);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(104, 23);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(60, 30);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(89, 23);
            this.txtFileNo.TabIndex = 1;
            this.txtFileNo.Leave += new System.EventHandler(this.txtFileNo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datGrdVwLoanApplications);
            this.groupBox2.Location = new System.Drawing.Point(5, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1250, 365);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // datGrdVwLoanApplications
            // 
            this.datGrdVwLoanApplications.AllowUserToAddRows = false;
            this.datGrdVwLoanApplications.AllowUserToDeleteRows = false;
            this.datGrdVwLoanApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwLoanApplications.Location = new System.Drawing.Point(11, 21);
            this.datGrdVwLoanApplications.MultiSelect = false;
            this.datGrdVwLoanApplications.Name = "datGrdVwLoanApplications";
            this.datGrdVwLoanApplications.ReadOnly = true;
            this.datGrdVwLoanApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGrdVwLoanApplications.Size = new System.Drawing.Size(1230, 333);
            this.datGrdVwLoanApplications.TabIndex = 0;
            this.datGrdVwLoanApplications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGrdVwLoanApplications_CellClick);
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(4, 463);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(94, 15);
            this.lblRecordNo.TabIndex = 2;
            this.lblRecordNo.Text = "No. of Records : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(175, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Amount Paid";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmountPaid.Location = new System.Drawing.Point(253, 461);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(149, 22);
            this.lblAmountPaid.TabIndex = 6;
            this.lblAmountPaid.Text = "0";
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(412, 465);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Outstanding Amount";
            // 
            // lblOutstandingAmt
            // 
            this.lblOutstandingAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutstandingAmt.Location = new System.Drawing.Point(533, 461);
            this.lblOutstandingAmt.Name = "lblOutstandingAmt";
            this.lblOutstandingAmt.Size = new System.Drawing.Size(145, 23);
            this.lblOutstandingAmt.TabIndex = 8;
            this.lblOutstandingAmt.Text = "0";
            this.lblOutstandingAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(685, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Repayment Status";
            // 
            // lblRepaymentStatus
            // 
            this.lblRepaymentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepaymentStatus.Location = new System.Drawing.Point(792, 462);
            this.lblRepaymentStatus.Name = "lblRepaymentStatus";
            this.lblRepaymentStatus.Size = new System.Drawing.Size(108, 23);
            this.lblRepaymentStatus.TabIndex = 10;
            this.lblRepaymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Enabled = false;
            this.btnViewDetails.Location = new System.Drawing.Point(908, 458);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(102, 30);
            this.btnViewDetails.TabIndex = 11;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::MainApp.Properties.Resources.Text;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1176, 458);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 30);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::MainApp.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1095, 458);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 30);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReload
            // 
            this.btnReload.Image = global::MainApp.Properties.Resources.Sync;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(1163, 25);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(76, 32);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Reload";
            this.btnReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::MainApp.Properties.Resources.find_icon;
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(1098, 25);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 32);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Filter";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // ViewLoanApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 494);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.lblRepaymentStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOutstandingAmt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAmountPaid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblRecordNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ViewLoanApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans | View Loan Application";
            this.Load += new System.EventHandler(this.ViewLoanApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoanApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datGrdVwLoanApplications;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOutstandingAmt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRepaymentStatus;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboApproval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SaveFileDialog saveFD;
    }
}