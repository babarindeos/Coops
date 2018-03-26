namespace MainApp
{
    partial class EditLoansBroughtForward
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
            this.datGrdVwLoansForward = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblPaymentFinishedDate = new System.Windows.Forms.Label();
            this.dtPickerPaymentFinished = new System.Windows.Forms.DateTimePicker();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOutstandingAmt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblInterestRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonthlyRepayment = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.txtTotalRepayment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cboLoanType = new System.Windows.Forms.ComboBox();
            this.cboLoanCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartRepayment = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtAppDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnableEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoansForward)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datGrdVwLoansForward);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1198, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // datGrdVwLoansForward
            // 
            this.datGrdVwLoansForward.AllowUserToAddRows = false;
            this.datGrdVwLoansForward.AllowUserToDeleteRows = false;
            this.datGrdVwLoansForward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwLoansForward.Location = new System.Drawing.Point(7, 19);
            this.datGrdVwLoansForward.Name = "datGrdVwLoansForward";
            this.datGrdVwLoansForward.ReadOnly = true;
            this.datGrdVwLoansForward.Size = new System.Drawing.Size(1185, 218);
            this.datGrdVwLoansForward.TabIndex = 0;
            this.datGrdVwLoansForward.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGrdVwLoansForward_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.lblPaymentFinishedDate);
            this.groupBox2.Controls.Add(this.dtPickerPaymentFinished);
            this.groupBox2.Controls.Add(this.txtAmountPaid);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtRemark);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtOutstandingAmt);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblInterestRate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblDuration);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMonthlyRepayment);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtInterest);
            this.groupBox2.Controls.Add(this.txtTotalRepayment);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.cboLoanType);
            this.groupBox2.Controls.Add(this.cboLoanCategory);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtStartRepayment);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtAppDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(4, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1099, 289);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::MainApp.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(512, 244);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 36);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.Text = "Update Record";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblPaymentFinishedDate
            // 
            this.lblPaymentFinishedDate.AutoSize = true;
            this.lblPaymentFinishedDate.Location = new System.Drawing.Point(866, 136);
            this.lblPaymentFinishedDate.Name = "lblPaymentFinishedDate";
            this.lblPaymentFinishedDate.Size = new System.Drawing.Size(128, 15);
            this.lblPaymentFinishedDate.TabIndex = 51;
            this.lblPaymentFinishedDate.Text = "Payment Finished Date";
            this.lblPaymentFinishedDate.Visible = false;
            // 
            // dtPickerPaymentFinished
            // 
            this.dtPickerPaymentFinished.Location = new System.Drawing.Point(868, 155);
            this.dtPickerPaymentFinished.Name = "dtPickerPaymentFinished";
            this.dtPickerPaymentFinished.Size = new System.Drawing.Size(190, 23);
            this.dtPickerPaymentFinished.TabIndex = 50;
            this.dtPickerPaymentFinished.Visible = false;
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(676, 121);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(177, 23);
            this.txtAmountPaid.TabIndex = 41;
            this.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaid.Leave += new System.EventHandler(this.txtAmountPaid_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(587, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 15);
            this.label16.TabIndex = 49;
            this.label16.Text = "Amount Paid";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(676, 190);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(382, 50);
            this.txtRemark.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(617, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 15);
            this.label15.TabIndex = 48;
            this.label15.Text = "Remark";
            // 
            // txtOutstandingAmt
            // 
            this.txtOutstandingAmt.Location = new System.Drawing.Point(676, 155);
            this.txtOutstandingAmt.Name = "txtOutstandingAmt";
            this.txtOutstandingAmt.ReadOnly = true;
            this.txtOutstandingAmt.Size = new System.Drawing.Size(177, 23);
            this.txtOutstandingAmt.TabIndex = 42;
            this.txtOutstandingAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(544, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 15);
            this.label14.TabIndex = 47;
            this.label14.Text = "Outstanding Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(752, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 15);
            this.label11.TabIndex = 46;
            this.label11.Text = "Months ";
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInterestRate.Location = new System.Drawing.Point(985, 87);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(73, 23);
            this.lblInterestRate.TabIndex = 45;
            this.lblInterestRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(886, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 44;
            this.label7.Text = "Interest Rate (%)";
            // 
            // lblDuration
            // 
            this.lblDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDuration.Location = new System.Drawing.Point(676, 87);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(73, 23);
            this.lblDuration.TabIndex = 40;
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(608, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "Duration ";
            // 
            // txtMonthlyRepayment
            // 
            this.txtMonthlyRepayment.Location = new System.Drawing.Point(152, 220);
            this.txtMonthlyRepayment.Name = "txtMonthlyRepayment";
            this.txtMonthlyRepayment.Size = new System.Drawing.Size(248, 23);
            this.txtMonthlyRepayment.TabIndex = 35;
            this.txtMonthlyRepayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 223);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 38;
            this.label13.Text = "Monthly Repayment";
            // 
            // txtInterest
            // 
            this.txtInterest.Location = new System.Drawing.Point(152, 153);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(248, 23);
            this.txtInterest.TabIndex = 33;
            this.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterest.Leave += new System.EventHandler(this.txtInterest_Leave);
            // 
            // txtTotalRepayment
            // 
            this.txtTotalRepayment.Location = new System.Drawing.Point(152, 186);
            this.txtTotalRepayment.Name = "txtTotalRepayment";
            this.txtTotalRepayment.Size = new System.Drawing.Size(248, 23);
            this.txtTotalRepayment.TabIndex = 34;
            this.txtTotalRepayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 37;
            this.label10.Text = "Total Repayment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "Interest Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(152, 119);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(248, 23);
            this.txtAmount.TabIndex = 32;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // cboLoanType
            // 
            this.cboLoanType.FormattingEnabled = true;
            this.cboLoanType.Location = new System.Drawing.Point(152, 86);
            this.cboLoanType.Name = "cboLoanType";
            this.cboLoanType.Size = new System.Drawing.Size(343, 23);
            this.cboLoanType.TabIndex = 31;
            this.cboLoanType.SelectedIndexChanged += new System.EventHandler(this.cboLoanType_SelectedIndexChanged);
            this.cboLoanType.Leave += new System.EventHandler(this.cboLoanType_Leave);
            // 
            // cboLoanCategory
            // 
            this.cboLoanCategory.FormattingEnabled = true;
            this.cboLoanCategory.Location = new System.Drawing.Point(152, 54);
            this.cboLoanCategory.Name = "cboLoanCategory";
            this.cboLoanCategory.Size = new System.Drawing.Size(289, 23);
            this.cboLoanCategory.TabIndex = 30;
            this.cboLoanCategory.Leave += new System.EventHandler(this.cboLoanCategory_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Loan Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Loan Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Loan Category";
            // 
            // dtStartRepayment
            // 
            this.dtStartRepayment.Location = new System.Drawing.Point(676, 24);
            this.dtStartRepayment.Name = "dtStartRepayment";
            this.dtStartRepayment.Size = new System.Drawing.Size(196, 23);
            this.dtStartRepayment.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(538, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Repayment Start Date";
            // 
            // dtAppDate
            // 
            this.dtAppDate.Location = new System.Drawing.Point(152, 24);
            this.dtAppDate.Name = "dtAppDate";
            this.dtAppDate.Size = new System.Drawing.Size(196, 23);
            this.dtAppDate.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Application Date (M|Y)";
            // 
            // btnEnableEdit
            // 
            this.btnEnableEdit.Enabled = false;
            this.btnEnableEdit.Image = global::MainApp.Properties.Resources.edit_savings;
            this.btnEnableEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnableEdit.Location = new System.Drawing.Point(1110, 263);
            this.btnEnableEdit.Name = "btnEnableEdit";
            this.btnEnableEdit.Size = new System.Drawing.Size(93, 35);
            this.btnEnableEdit.TabIndex = 2;
            this.btnEnableEdit.Text = "Enable Edit ";
            this.btnEnableEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnableEdit.UseVisualStyleBackColor = true;
            this.btnEnableEdit.Click += new System.EventHandler(this.btnEnableEdit_Click);
            // 
            // EditLoansBroughtForward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 547);
            this.Controls.Add(this.btnEnableEdit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditLoansBroughtForward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans | Edit Loans Brought Forward";
            this.Load += new System.EventHandler(this.EditLoansBroughtForward_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoansForward)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datGrdVwLoansForward;
        private System.Windows.Forms.DateTimePicker dtStartRepayment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtAppDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMonthlyRepayment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.TextBox txtTotalRepayment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cboLoanType;
        private System.Windows.Forms.ComboBox cboLoanCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPaymentFinishedDate;
        private System.Windows.Forms.DateTimePicker dtPickerPaymentFinished;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtOutstandingAmt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblInterestRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEnableEdit;
    }
}