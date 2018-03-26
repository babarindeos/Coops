namespace MainApp
{
    partial class PostDeduction_Individual
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
            this.btnFindMember = new System.Windows.Forms.Button();
            this.txtFindByFileNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnApplyChanges = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblTotalLoans = new System.Windows.Forms.Label();
            this.btnChangeLoanAmt = new System.Windows.Forms.Button();
            this.txtChangeLoanAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstVwLoans = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblTotalSavings = new System.Windows.Forms.Label();
            this.btnChangeSavingsAmt = new System.Windows.Forms.Button();
            this.txtChangeSavingsAmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstVwSavings = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPostDeduction = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.lblPreviousPosting = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstMonthlyDeductions = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblPrevDeductionsCount = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtGridVPreviousDeductions = new System.Windows.Forms.DataGridView();
            this.memberPersonalInfo = new System.Windows.Forms.Label();
            this.memberPic = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVPreviousDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberPic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtFindByFileNo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Member By File No";
            // 
            // btnFindMember
            // 
            this.btnFindMember.Enabled = false;
            this.btnFindMember.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindMember.Location = new System.Drawing.Point(144, 20);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(54, 38);
            this.btnFindMember.TabIndex = 1;
            this.btnFindMember.UseVisualStyleBackColor = true;
            this.btnFindMember.Click += new System.EventHandler(this.btnFindMember_Click);
            // 
            // txtFindByFileNo
            // 
            this.txtFindByFileNo.Location = new System.Drawing.Point(10, 27);
            this.txtFindByFileNo.Name = "txtFindByFileNo";
            this.txtFindByFileNo.Size = new System.Drawing.Size(125, 23);
            this.txtFindByFileNo.TabIndex = 0;
            this.txtFindByFileNo.TextChanged += new System.EventHandler(this.txtFindByFileNo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnApplyChanges);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(859, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 520);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnApplyChanges
            // 
            this.btnApplyChanges.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChanges.Location = new System.Drawing.Point(209, 483);
            this.btnApplyChanges.Name = "btnApplyChanges";
            this.btnApplyChanges.Size = new System.Drawing.Size(134, 30);
            this.btnApplyChanges.TabIndex = 4;
            this.btnApplyChanges.Text = "Apply Changes";
            this.btnApplyChanges.UseVisualStyleBackColor = true;
            this.btnApplyChanges.Click += new System.EventHandler(this.btnApplyChanges_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblTotalLoans);
            this.groupBox7.Controls.Add(this.btnChangeLoanAmt);
            this.groupBox7.Controls.Add(this.txtChangeLoanAmount);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.lstVwLoans);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(6, 311);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(336, 155);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Loans";
            // 
            // lblTotalLoans
            // 
            this.lblTotalLoans.AutoSize = true;
            this.lblTotalLoans.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLoans.Location = new System.Drawing.Point(49, 101);
            this.lblTotalLoans.Name = "lblTotalLoans";
            this.lblTotalLoans.Size = new System.Drawing.Size(24, 15);
            this.lblTotalLoans.TabIndex = 7;
            this.lblTotalLoans.Text = "0.0";
            // 
            // btnChangeLoanAmt
            // 
            this.btnChangeLoanAmt.Enabled = false;
            this.btnChangeLoanAmt.Location = new System.Drawing.Point(249, 120);
            this.btnChangeLoanAmt.Name = "btnChangeLoanAmt";
            this.btnChangeLoanAmt.Size = new System.Drawing.Size(65, 28);
            this.btnChangeLoanAmt.TabIndex = 6;
            this.btnChangeLoanAmt.Text = "Change";
            this.btnChangeLoanAmt.UseVisualStyleBackColor = true;
            this.btnChangeLoanAmt.Click += new System.EventHandler(this.btnChangeLoanAmt_Click);
            // 
            // txtChangeLoanAmount
            // 
            this.txtChangeLoanAmount.Enabled = false;
            this.txtChangeLoanAmount.Location = new System.Drawing.Point(104, 123);
            this.txtChangeLoanAmount.Name = "txtChangeLoanAmount";
            this.txtChangeLoanAmount.Size = new System.Drawing.Size(139, 23);
            this.txtChangeLoanAmount.TabIndex = 5;
            this.txtChangeLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChangeLoanAmount.Leave += new System.EventHandler(this.txtChangeLoanAmount_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Change Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total";
            // 
            // lstVwLoans
            // 
            this.lstVwLoans.Location = new System.Drawing.Point(6, 21);
            this.lstVwLoans.Name = "lstVwLoans";
            this.lstVwLoans.Size = new System.Drawing.Size(324, 77);
            this.lstVwLoans.TabIndex = 0;
            this.lstVwLoans.UseCompatibleStateImageBehavior = false;
            this.lstVwLoans.SelectedIndexChanged += new System.EventHandler(this.lstVwLoans_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblTotalSavings);
            this.groupBox6.Controls.Add(this.btnChangeSavingsAmt);
            this.groupBox6.Controls.Add(this.txtChangeSavingsAmt);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.lstVwSavings);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(6, 104);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(336, 201);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Savings";
            // 
            // lblTotalSavings
            // 
            this.lblTotalSavings.AutoSize = true;
            this.lblTotalSavings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavings.Location = new System.Drawing.Point(47, 152);
            this.lblTotalSavings.Name = "lblTotalSavings";
            this.lblTotalSavings.Size = new System.Drawing.Size(24, 15);
            this.lblTotalSavings.TabIndex = 5;
            this.lblTotalSavings.Text = "0.0";
            // 
            // btnChangeSavingsAmt
            // 
            this.btnChangeSavingsAmt.Enabled = false;
            this.btnChangeSavingsAmt.Location = new System.Drawing.Point(248, 169);
            this.btnChangeSavingsAmt.Name = "btnChangeSavingsAmt";
            this.btnChangeSavingsAmt.Size = new System.Drawing.Size(64, 30);
            this.btnChangeSavingsAmt.TabIndex = 4;
            this.btnChangeSavingsAmt.Text = "Change";
            this.btnChangeSavingsAmt.UseVisualStyleBackColor = true;
            this.btnChangeSavingsAmt.Click += new System.EventHandler(this.btnChangeSavingsAmt_Click);
            // 
            // txtChangeSavingsAmt
            // 
            this.txtChangeSavingsAmt.Enabled = false;
            this.txtChangeSavingsAmt.Location = new System.Drawing.Point(104, 173);
            this.txtChangeSavingsAmt.Name = "txtChangeSavingsAmt";
            this.txtChangeSavingsAmt.Size = new System.Drawing.Size(139, 23);
            this.txtChangeSavingsAmt.TabIndex = 3;
            this.txtChangeSavingsAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChangeSavingsAmt.TextChanged += new System.EventHandler(this.txtChangeSavingsAmt_TextChanged);
            this.txtChangeSavingsAmt.Leave += new System.EventHandler(this.txtChangeSavingsAmt_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Change Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total";
            // 
            // lstVwSavings
            // 
            this.lstVwSavings.Location = new System.Drawing.Point(7, 19);
            this.lstVwSavings.Name = "lstVwSavings";
            this.lstVwSavings.Size = new System.Drawing.Size(323, 130);
            this.lstVwSavings.TabIndex = 0;
            this.lstVwSavings.UseCompatibleStateImageBehavior = false;
            this.lstVwSavings.SelectedIndexChanged += new System.EventHandler(this.lstVwSavings_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnPostDeduction);
            this.groupBox5.Controls.Add(this.cboYear);
            this.groupBox5.Controls.Add(this.cboMonth);
            this.groupBox5.Controls.Add(this.lblPreviousPosting);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(298, 89);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Previous | Current Deduction Dates";
            // 
            // btnPostDeduction
            // 
            this.btnPostDeduction.Enabled = false;
            this.btnPostDeduction.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblPreviousPosting.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousPosting.Location = new System.Drawing.Point(4, 29);
            this.lblPreviousPosting.Name = "lblPreviousPosting";
            this.lblPreviousPosting.Size = new System.Drawing.Size(36, 15);
            this.lblPreviousPosting.TabIndex = 0;
            this.lblPreviousPosting.Text = "None";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstMonthlyDeductions);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(846, 119);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Member Monthly Deduction";
            // 
            // lstMonthlyDeductions
            // 
            this.lstMonthlyDeductions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMonthlyDeductions.Location = new System.Drawing.Point(7, 21);
            this.lstMonthlyDeductions.Name = "lstMonthlyDeductions";
            this.lstMonthlyDeductions.Size = new System.Drawing.Size(833, 91);
            this.lstMonthlyDeductions.TabIndex = 0;
            this.lstMonthlyDeductions.UseCompatibleStateImageBehavior = false;
            this.lstMonthlyDeductions.SelectedIndexChanged += new System.EventHandler(this.lstMonthlyDeductions_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblPrevDeductionsCount);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.dtGridVPreviousDeductions);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(7, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(846, 295);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Member Previous Deduction";
            // 
            // lblPrevDeductionsCount
            // 
            this.lblPrevDeductionsCount.AutoSize = true;
            this.lblPrevDeductionsCount.Location = new System.Drawing.Point(12, 268);
            this.lblPrevDeductionsCount.Name = "lblPrevDeductionsCount";
            this.lblPrevDeductionsCount.Size = new System.Drawing.Size(66, 15);
            this.lblPrevDeductionsCount.TabIndex = 3;
            this.lblPrevDeductionsCount.Text = "Record No.";
            // 
            // button3
            // 
            this.button3.Image = global::MainApp.Properties.Resources.Text;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(778, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Print";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::MainApp.Properties.Resources.excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(700, 260);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // dtGridVPreviousDeductions
            // 
            this.dtGridVPreviousDeductions.AllowUserToAddRows = false;
            this.dtGridVPreviousDeductions.AllowUserToDeleteRows = false;
            this.dtGridVPreviousDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridVPreviousDeductions.Location = new System.Drawing.Point(9, 25);
            this.dtGridVPreviousDeductions.Name = "dtGridVPreviousDeductions";
            this.dtGridVPreviousDeductions.Size = new System.Drawing.Size(831, 229);
            this.dtGridVPreviousDeductions.TabIndex = 0;
            // 
            // memberPersonalInfo
            // 
            this.memberPersonalInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberPersonalInfo.Location = new System.Drawing.Point(320, 14);
            this.memberPersonalInfo.Name = "memberPersonalInfo";
            this.memberPersonalInfo.Size = new System.Drawing.Size(286, 48);
            this.memberPersonalInfo.TabIndex = 5;
            this.memberPersonalInfo.Text = "label1";
            this.memberPersonalInfo.Visible = false;
            // 
            // memberPic
            // 
            this.memberPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memberPic.Image = global::MainApp.Properties.Resources.profile_img;
            this.memberPic.Location = new System.Drawing.Point(224, 8);
            this.memberPic.Name = "memberPic";
            this.memberPic.Size = new System.Drawing.Size(88, 83);
            this.memberPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.memberPic.TabIndex = 1;
            this.memberPic.TabStop = false;
            this.memberPic.Visible = false;
            // 
            // PostDeduction_Individual
            // 
            this.AcceptButton = this.btnFindMember;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 526);
            this.Controls.Add(this.memberPersonalInfo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.memberPic);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PostDeduction_Individual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post Deduction | Individual";
            this.Load += new System.EventHandler(this.PostDeduction_Individual_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVPreviousDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox memberPic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label memberPersonalInfo;
        private System.Windows.Forms.DataGridView dtGridVPreviousDeductions;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.TextBox txtFindByFileNo;
        private System.Windows.Forms.ListView lstMonthlyDeductions;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblPrevDeductionsCount;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPostDeduction;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label lblPreviousPosting;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstVwLoans;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstVwSavings;
        private System.Windows.Forms.TextBox txtChangeLoanAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChangeSavingsAmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangeLoanAmt;
        private System.Windows.Forms.Button btnChangeSavingsAmt;
        private System.Windows.Forms.Label lblTotalLoans;
        private System.Windows.Forms.Label lblTotalSavings;
        private System.Windows.Forms.Button btnApplyChanges;
    }
}