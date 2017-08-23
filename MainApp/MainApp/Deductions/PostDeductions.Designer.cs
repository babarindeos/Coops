namespace MainApp
{
    partial class PostDeductions
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
            this.btnPostDeduction = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.lblPreviousPosting = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDeductions = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datGrdSavings = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.datGrdLoans = new System.Windows.Forms.DataGridView();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.btnRemoveDeductions = new System.Windows.Forms.Button();
            this.btnAddDeduction = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddFileNo = new System.Windows.Forms.TextBox();
            this.grpDeductionList = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnViewSelectedDeduction = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdSavings)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdLoans)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.grpDeductionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPostDeduction);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.lblPreviousPosting);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(872, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous | Current Deduction Dates";
            // 
            // btnPostDeduction
            // 
            this.btnPostDeduction.Location = new System.Drawing.Point(186, 51);
            this.btnPostDeduction.Name = "btnPostDeduction";
            this.btnPostDeduction.Size = new System.Drawing.Size(101, 32);
            this.btnPostDeduction.TabIndex = 3;
            this.btnPostDeduction.Text = "Post Deduction";
            this.btnPostDeduction.UseVisualStyleBackColor = true;
            this.btnPostDeduction.Click += new System.EventHandler(this.btnPostDeduction_Click);
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(111, 56);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(72, 23);
            this.cboYear.TabIndex = 2;
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(6, 56);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(101, 23);
            this.cboMonth.TabIndex = 1;
            // 
            // lblPreviousPosting
            // 
            this.lblPreviousPosting.AutoSize = true;
            this.lblPreviousPosting.Location = new System.Drawing.Point(11, 29);
            this.lblPreviousPosting.Name = "lblPreviousPosting";
            this.lblPreviousPosting.Size = new System.Drawing.Size(36, 15);
            this.lblPreviousPosting.TabIndex = 0;
            this.lblPreviousPosting.Text = "None";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDeductions);
            this.groupBox2.Location = new System.Drawing.Point(3, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(863, 492);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Members Monthly Deductions";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lstDeductions
            // 
            this.lstDeductions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDeductions.Location = new System.Drawing.Point(9, 24);
            this.lstDeductions.Name = "lstDeductions";
            this.lstDeductions.Size = new System.Drawing.Size(848, 462);
            this.lstDeductions.TabIndex = 0;
            this.lstDeductions.UseCompatibleStateImageBehavior = false;
            this.lstDeductions.SelectedIndexChanged += new System.EventHandler(this.lstDeductions_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datGrdSavings);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(872, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 167);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Savings Details [Monthly Savings]";
            // 
            // datGrdSavings
            // 
            this.datGrdSavings.AllowUserToAddRows = false;
            this.datGrdSavings.AllowUserToDeleteRows = false;
            this.datGrdSavings.AllowUserToResizeRows = false;
            this.datGrdSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdSavings.Location = new System.Drawing.Point(6, 23);
            this.datGrdSavings.Name = "datGrdSavings";
            this.datGrdSavings.Size = new System.Drawing.Size(406, 138);
            this.datGrdSavings.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.datGrdLoans);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(872, 351);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 150);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Loan Details [Monthly Loan Repayment]";
            // 
            // datGrdLoans
            // 
            this.datGrdLoans.AllowUserToAddRows = false;
            this.datGrdLoans.AllowUserToDeleteRows = false;
            this.datGrdLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdLoans.Location = new System.Drawing.Point(6, 22);
            this.datGrdLoans.Name = "datGrdLoans";
            this.datGrdLoans.Size = new System.Drawing.Size(406, 122);
            this.datGrdLoans.TabIndex = 0;
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(10, 505);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(97, 17);
            this.lblRecordNo.TabIndex = 4;
            this.lblRecordNo.Text = "No. of Records";
            // 
            // btnRemoveDeductions
            // 
            this.btnRemoveDeductions.Location = new System.Drawing.Point(878, 117);
            this.btnRemoveDeductions.Name = "btnRemoveDeductions";
            this.btnRemoveDeductions.Size = new System.Drawing.Size(80, 28);
            this.btnRemoveDeductions.TabIndex = 5;
            this.btnRemoveDeductions.Text = "Remove";
            this.btnRemoveDeductions.UseVisualStyleBackColor = true;
            this.btnRemoveDeductions.Click += new System.EventHandler(this.btnRemoveDeductions_Click);
            // 
            // btnAddDeduction
            // 
            this.btnAddDeduction.Enabled = false;
            this.btnAddDeduction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDeduction.Location = new System.Drawing.Point(135, 16);
            this.btnAddDeduction.Name = "btnAddDeduction";
            this.btnAddDeduction.Size = new System.Drawing.Size(61, 28);
            this.btnAddDeduction.TabIndex = 6;
            this.btnAddDeduction.Text = "Add";
            this.btnAddDeduction.UseVisualStyleBackColor = true;
            this.btnAddDeduction.Click += new System.EventHandler(this.btnAddDeduction_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtAddFileNo);
            this.groupBox5.Controls.Add(this.btnAddDeduction);
            this.groupBox5.Location = new System.Drawing.Point(962, 100);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(206, 49);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "File No.";
            // 
            // txtAddFileNo
            // 
            this.txtAddFileNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddFileNo.Location = new System.Drawing.Point(59, 19);
            this.txtAddFileNo.Name = "txtAddFileNo";
            this.txtAddFileNo.Size = new System.Drawing.Size(70, 23);
            this.txtAddFileNo.TabIndex = 7;
            this.txtAddFileNo.TextChanged += new System.EventHandler(this.txtAddFileNo_TextChanged);
            // 
            // grpDeductionList
            // 
            this.grpDeductionList.Controls.Add(this.btnViewSelectedDeduction);
            this.grpDeductionList.Controls.Add(this.listView1);
            this.grpDeductionList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDeductionList.Location = new System.Drawing.Point(1171, 2);
            this.grpDeductionList.Name = "grpDeductionList";
            this.grpDeductionList.Size = new System.Drawing.Size(113, 180);
            this.grpDeductionList.TabIndex = 8;
            this.grpDeductionList.TabStop = false;
            this.grpDeductionList.Text = "Deduction List";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(7, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(100, 128);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnViewSelectedDeduction
            // 
            this.btnViewSelectedDeduction.Location = new System.Drawing.Point(25, 151);
            this.btnViewSelectedDeduction.Name = "btnViewSelectedDeduction";
            this.btnViewSelectedDeduction.Size = new System.Drawing.Size(67, 25);
            this.btnViewSelectedDeduction.TabIndex = 1;
            this.btnViewSelectedDeduction.Text = "View";
            this.btnViewSelectedDeduction.UseVisualStyleBackColor = true;
            // 
            // PostDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 531);
            this.Controls.Add(this.grpDeductionList);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnRemoveDeductions);
            this.Controls.Add(this.lblRecordNo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PostDeductions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post Deductions | Collective";
            this.Load += new System.EventHandler(this.PostDeductions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdSavings)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdLoans)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpDeductionList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstDeductions;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView datGrdSavings;
        private System.Windows.Forms.DataGridView datGrdLoans;
        private System.Windows.Forms.Button btnPostDeduction;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label lblPreviousPosting;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.Button btnRemoveDeductions;
        private System.Windows.Forms.Button btnAddDeduction;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddFileNo;
        private System.Windows.Forms.GroupBox grpDeductionList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnViewSelectedDeduction;
    }
}