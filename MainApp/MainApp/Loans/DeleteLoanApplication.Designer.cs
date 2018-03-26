namespace MainApp
{
    partial class DeleteLoanApplication
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
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.datGrdVwLoansApp = new System.Windows.Forms.DataGridView();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnFindRecord = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoansApp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.btnFindRecord);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Loan Application";
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
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
            "2040",
            ""});
            this.cboYear.Location = new System.Drawing.Point(268, 34);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(87, 25);
            this.cboYear.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year";
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
            this.cboMonth.Location = new System.Drawing.Point(66, 34);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(141, 25);
            this.cboMonth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Month";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.lblRecordNo);
            this.groupBox2.Controls.Add(this.datGrdVwLoansApp);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1128, 410);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(13, 387);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(91, 15);
            this.lblRecordNo.TabIndex = 1;
            this.lblRecordNo.Text = "No. of Records: ";
            // 
            // datGrdVwLoansApp
            // 
            this.datGrdVwLoansApp.AllowUserToAddRows = false;
            this.datGrdVwLoansApp.AllowUserToDeleteRows = false;
            this.datGrdVwLoansApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwLoansApp.Location = new System.Drawing.Point(10, 22);
            this.datGrdVwLoansApp.MultiSelect = false;
            this.datGrdVwLoansApp.Name = "datGrdVwLoansApp";
            this.datGrdVwLoansApp.ReadOnly = true;
            this.datGrdVwLoansApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGrdVwLoansApp.Size = new System.Drawing.Size(1112, 350);
            this.datGrdVwLoansApp.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::MainApp.Properties.Resources.Erase;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(1058, 374);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::MainApp.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(980, 374);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 28);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReload
            // 
            this.btnReload.Image = global::MainApp.Properties.Resources.Sync;
            this.btnReload.Location = new System.Drawing.Point(423, 28);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(57, 35);
            this.btnReload.TabIndex = 5;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnFindRecord
            // 
            this.btnFindRecord.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindRecord.Location = new System.Drawing.Point(361, 28);
            this.btnFindRecord.Name = "btnFindRecord";
            this.btnFindRecord.Size = new System.Drawing.Size(57, 35);
            this.btnFindRecord.TabIndex = 4;
            this.btnFindRecord.UseVisualStyleBackColor = true;
            this.btnFindRecord.Click += new System.EventHandler(this.btnFindRecord_Click);
            // 
            // DeleteLoanApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 509);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeleteLoanApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Loan Application";
            this.Load += new System.EventHandler(this.DeleteLoanApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoansApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindRecord;
        private System.Windows.Forms.DataGridView datGrdVwLoansApp;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.Button btnReload;
    }
}