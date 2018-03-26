namespace MainApp
{
    partial class ViewSavings
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboYearSearch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMonthSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSourceSearch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileNoSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalSavings = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExportSavings = new System.Windows.Forms.Button();
            this.lblSavingsRecordNo = new System.Windows.Forms.Label();
            this.datGridViewSavings = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSelectedSavingsTotal = new System.Windows.Forms.Label();
            this.lblSavingsRecordDetail = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnExportSavingsDetails = new System.Windows.Forms.Button();
            this.datGridSavingsDetails = new System.Windows.Forms.DataGridView();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDateFilter = new System.Windows.Forms.Button();
            this.cboToYearSearch = new System.Windows.Forms.ComboBox();
            this.cboToMonthSearch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFromYearSearch = new System.Windows.Forms.ComboBox();
            this.cboFromMonthSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGridViewSavings)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGridSavingsDetails)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.cboYearSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboMonthSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboSourceSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFileNoSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(621, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 32);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(569, 22);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(52, 32);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboYearSearch
            // 
            this.cboYearSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearSearch.FormattingEnabled = true;
            this.cboYearSearch.Items.AddRange(new object[] {
            "",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
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
            ""});
            this.cboYearSearch.Location = new System.Drawing.Point(466, 27);
            this.cboYearSearch.Name = "cboYearSearch";
            this.cboYearSearch.Size = new System.Drawing.Size(98, 23);
            this.cboYearSearch.TabIndex = 7;
            this.cboYearSearch.SelectedIndexChanged += new System.EventHandler(this.cboYearSearch_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Year";
            // 
            // cboMonthSearch
            // 
            this.cboMonthSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonthSearch.FormattingEnabled = true;
            this.cboMonthSearch.Items.AddRange(new object[] {
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
            this.cboMonthSearch.Location = new System.Drawing.Point(335, 27);
            this.cboMonthSearch.Name = "cboMonthSearch";
            this.cboMonthSearch.Size = new System.Drawing.Size(90, 23);
            this.cboMonthSearch.TabIndex = 5;
            this.cboMonthSearch.SelectedIndexChanged += new System.EventHandler(this.cboMonthSearch_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Month";
            // 
            // cboSourceSearch
            // 
            this.cboSourceSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSourceSearch.FormattingEnabled = true;
            this.cboSourceSearch.Items.AddRange(new object[] {
            "",
            "Contribution",
            "Deduction",
            "Loan",
            "Withdrawal"});
            this.cboSourceSearch.Location = new System.Drawing.Point(186, 27);
            this.cboSourceSearch.Name = "cboSourceSearch";
            this.cboSourceSearch.Size = new System.Drawing.Size(97, 23);
            this.cboSourceSearch.TabIndex = 3;
            this.cboSourceSearch.SelectedIndexChanged += new System.EventHandler(this.cboSourceSearch_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Source";
            // 
            // txtFileNoSearch
            // 
            this.txtFileNoSearch.Location = new System.Drawing.Point(59, 27);
            this.txtFileNoSearch.Name = "txtFileNoSearch";
            this.txtFileNoSearch.Size = new System.Drawing.Size(77, 23);
            this.txtFileNoSearch.TabIndex = 1;
            this.txtFileNoSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFileNoSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File No. ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalSavings);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnExportSavings);
            this.groupBox2.Controls.Add(this.lblSavingsRecordNo);
            this.groupBox2.Controls.Add(this.datGridViewSavings);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1106, 263);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblTotalSavings
            // 
            this.lblTotalSavings.AutoSize = true;
            this.lblTotalSavings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavings.Location = new System.Drawing.Point(258, 241);
            this.lblTotalSavings.Name = "lblTotalSavings";
            this.lblTotalSavings.Size = new System.Drawing.Size(83, 15);
            this.lblTotalSavings.TabIndex = 4;
            this.lblTotalSavings.Text = "Total Savings: ";
            // 
            // button2
            // 
            this.button2.Image = global::MainApp.Properties.Resources.Text;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1038, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Print";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnExportSavings
            // 
            this.btnExportSavings.Image = global::MainApp.Properties.Resources.excel;
            this.btnExportSavings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportSavings.Location = new System.Drawing.Point(960, 234);
            this.btnExportSavings.Name = "btnExportSavings";
            this.btnExportSavings.Size = new System.Drawing.Size(76, 26);
            this.btnExportSavings.TabIndex = 2;
            this.btnExportSavings.Text = "Export";
            this.btnExportSavings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSavings.UseVisualStyleBackColor = true;
            this.btnExportSavings.Click += new System.EventHandler(this.btnExportSavings_Click);
            // 
            // lblSavingsRecordNo
            // 
            this.lblSavingsRecordNo.AutoSize = true;
            this.lblSavingsRecordNo.Location = new System.Drawing.Point(7, 239);
            this.lblSavingsRecordNo.Name = "lblSavingsRecordNo";
            this.lblSavingsRecordNo.Size = new System.Drawing.Size(88, 15);
            this.lblSavingsRecordNo.TabIndex = 1;
            this.lblSavingsRecordNo.Text = "No of Records: ";
            // 
            // datGridViewSavings
            // 
            this.datGridViewSavings.AllowUserToAddRows = false;
            this.datGridViewSavings.AllowUserToDeleteRows = false;
            this.datGridViewSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGridViewSavings.Location = new System.Drawing.Point(10, 13);
            this.datGridViewSavings.Name = "datGridViewSavings";
            this.datGridViewSavings.Size = new System.Drawing.Size(1089, 218);
            this.datGridViewSavings.TabIndex = 0;
            this.datGridViewSavings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGridViewSavings_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSelectedSavingsTotal);
            this.groupBox3.Controls.Add(this.lblSavingsRecordDetail);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.btnExportSavingsDetails);
            this.groupBox3.Controls.Add(this.datGridSavingsDetails);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1106, 198);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Savings Details";
            // 
            // lblSelectedSavingsTotal
            // 
            this.lblSelectedSavingsTotal.AutoSize = true;
            this.lblSelectedSavingsTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedSavingsTotal.Location = new System.Drawing.Point(265, 174);
            this.lblSelectedSavingsTotal.Name = "lblSelectedSavingsTotal";
            this.lblSelectedSavingsTotal.Size = new System.Drawing.Size(39, 15);
            this.lblSelectedSavingsTotal.TabIndex = 7;
            this.lblSelectedSavingsTotal.Text = "Total: ";
            // 
            // lblSavingsRecordDetail
            // 
            this.lblSavingsRecordDetail.AutoSize = true;
            this.lblSavingsRecordDetail.Location = new System.Drawing.Point(7, 174);
            this.lblSavingsRecordDetail.Name = "lblSavingsRecordDetail";
            this.lblSavingsRecordDetail.Size = new System.Drawing.Size(88, 15);
            this.lblSavingsRecordDetail.TabIndex = 6;
            this.lblSavingsRecordDetail.Text = "No of Records: ";
            // 
            // button3
            // 
            this.button3.Image = global::MainApp.Properties.Resources.Text;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1038, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "Print";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnExportSavingsDetails
            // 
            this.btnExportSavingsDetails.Image = global::MainApp.Properties.Resources.excel;
            this.btnExportSavingsDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportSavingsDetails.Location = new System.Drawing.Point(960, 170);
            this.btnExportSavingsDetails.Name = "btnExportSavingsDetails";
            this.btnExportSavingsDetails.Size = new System.Drawing.Size(76, 26);
            this.btnExportSavingsDetails.TabIndex = 4;
            this.btnExportSavingsDetails.Text = "Export";
            this.btnExportSavingsDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSavingsDetails.UseVisualStyleBackColor = true;
            this.btnExportSavingsDetails.Click += new System.EventHandler(this.btnExportSavingsDetails_Click);
            // 
            // datGridSavingsDetails
            // 
            this.datGridSavingsDetails.AllowUserToAddRows = false;
            this.datGridSavingsDetails.AllowUserToDeleteRows = false;
            this.datGridSavingsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGridSavingsDetails.Location = new System.Drawing.Point(10, 18);
            this.datGridSavingsDetails.Name = "datGridSavingsDetails";
            this.datGridSavingsDetails.Size = new System.Drawing.Size(1089, 149);
            this.datGridSavingsDetails.TabIndex = 0;
            this.datGridSavingsDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGridSavingsDetails_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDateFilter);
            this.groupBox4.Controls.Add(this.cboToYearSearch);
            this.groupBox4.Controls.Add(this.cboToMonthSearch);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cboFromYearSearch);
            this.groupBox4.Controls.Add(this.cboFromMonthSearch);
            this.groupBox4.Location = new System.Drawing.Point(691, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(421, 62);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search By Date Interval";
            // 
            // btnDateFilter
            // 
            this.btnDateFilter.Location = new System.Drawing.Point(358, 22);
            this.btnDateFilter.Name = "btnDateFilter";
            this.btnDateFilter.Size = new System.Drawing.Size(52, 32);
            this.btnDateFilter.TabIndex = 22;
            this.btnDateFilter.Text = "Filter";
            this.btnDateFilter.UseVisualStyleBackColor = true;
            this.btnDateFilter.Click += new System.EventHandler(this.btnDateFilter_Click_1);
            // 
            // cboToYearSearch
            // 
            this.cboToYearSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToYearSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToYearSearch.FormattingEnabled = true;
            this.cboToYearSearch.Items.AddRange(new object[] {
            "",
            "",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
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
            this.cboToYearSearch.Location = new System.Drawing.Point(288, 27);
            this.cboToYearSearch.Name = "cboToYearSearch";
            this.cboToYearSearch.Size = new System.Drawing.Size(65, 23);
            this.cboToYearSearch.TabIndex = 21;
            // 
            // cboToMonthSearch
            // 
            this.cboToMonthSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToMonthSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToMonthSearch.FormattingEnabled = true;
            this.cboToMonthSearch.Items.AddRange(new object[] {
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
            this.cboToMonthSearch.Location = new System.Drawing.Point(200, 27);
            this.cboToMonthSearch.Name = "cboToMonthSearch";
            this.cboToMonthSearch.Size = new System.Drawing.Size(86, 23);
            this.cboToMonthSearch.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "To";
            // 
            // cboFromYearSearch
            // 
            this.cboFromYearSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromYearSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromYearSearch.FormattingEnabled = true;
            this.cboFromYearSearch.Items.AddRange(new object[] {
            "",
            "",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
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
            this.cboFromYearSearch.Location = new System.Drawing.Point(100, 27);
            this.cboFromYearSearch.Name = "cboFromYearSearch";
            this.cboFromYearSearch.Size = new System.Drawing.Size(65, 23);
            this.cboFromYearSearch.TabIndex = 18;
            // 
            // cboFromMonthSearch
            // 
            this.cboFromMonthSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromMonthSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromMonthSearch.FormattingEnabled = true;
            this.cboFromMonthSearch.Items.AddRange(new object[] {
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
            this.cboFromMonthSearch.Location = new System.Drawing.Point(11, 27);
            this.cboFromMonthSearch.Name = "cboFromMonthSearch";
            this.cboFromMonthSearch.Size = new System.Drawing.Size(86, 23);
            this.cboFromMonthSearch.TabIndex = 17;
            // 
            // ViewSavings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 543);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ViewSavings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings | View Savings";
            this.Load += new System.EventHandler(this.ViewSavings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGridViewSavings)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGridSavingsDetails)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datGridViewSavings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView datGridSavingsDetails;
        private System.Windows.Forms.Label lblSavingsRecordNo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExportSavings;
        private System.Windows.Forms.Label lblSavingsRecordDetail;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnExportSavingsDetails;
        private System.Windows.Forms.Label lblTotalSavings;
        private System.Windows.Forms.Label lblSelectedSavingsTotal;
        private System.Windows.Forms.TextBox txtFileNoSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSourceSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboYearSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMonthSearch;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDateFilter;
        private System.Windows.Forms.ComboBox cboToYearSearch;
        private System.Windows.Forms.ComboBox cboToMonthSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFromYearSearch;
        private System.Windows.Forms.ComboBox cboFromMonthSearch;
    }
}