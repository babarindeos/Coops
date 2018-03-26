namespace MainApp
{
    partial class MakeContributions
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
            this.txtfileNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboMemberSavingsType = new System.Windows.Forms.ComboBox();
            this.panelTellerDetails = new System.Windows.Forms.Panel();
            this.txtTellerNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMonthYear = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPaymentMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOtherPayments = new System.Windows.Forms.Panel();
            this.txtOtherPayments = new System.Windows.Forms.TextBox();
            this.lblOtherPaymentMode = new System.Windows.Forms.Label();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.MemberProfileInfo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datGVContributions = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelTellerDetails.SuspendLayout();
            this.panelOtherPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGVContributions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtfileNo);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retrieve Member Record By File No.";
            // 
            // btnFindMember
            // 
            this.btnFindMember.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindMember.Location = new System.Drawing.Point(263, 26);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(52, 42);
            this.btnFindMember.TabIndex = 1;
            this.btnFindMember.UseVisualStyleBackColor = true;
            this.btnFindMember.Click += new System.EventHandler(this.btnFindMember_Click);
            // 
            // txtfileNo
            // 
            this.txtfileNo.Location = new System.Drawing.Point(11, 36);
            this.txtfileNo.MaxLength = 40;
            this.txtfileNo.Name = "txtfileNo";
            this.txtfileNo.Size = new System.Drawing.Size(246, 25);
            this.txtfileNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboMemberSavingsType);
            this.groupBox2.Controls.Add(this.panelTellerDetails);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboYear);
            this.groupBox2.Controls.Add(this.lblYear);
            this.groupBox2.Controls.Add(this.cboMonth);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.chkMonthYear);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtComment);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboPaymentMode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(10, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1072, 239);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contributions Details";
            // 
            // cboMemberSavingsType
            // 
            this.cboMemberSavingsType.FormattingEnabled = true;
            this.cboMemberSavingsType.Location = new System.Drawing.Point(269, 71);
            this.cboMemberSavingsType.Name = "cboMemberSavingsType";
            this.cboMemberSavingsType.Size = new System.Drawing.Size(184, 25);
            this.cboMemberSavingsType.TabIndex = 16;
            // 
            // panelTellerDetails
            // 
            this.panelTellerDetails.Controls.Add(this.txtTellerNo);
            this.panelTellerDetails.Controls.Add(this.label5);
            this.panelTellerDetails.Controls.Add(this.cboBank);
            this.panelTellerDetails.Controls.Add(this.label4);
            this.panelTellerDetails.Location = new System.Drawing.Point(524, 16);
            this.panelTellerDetails.Name = "panelTellerDetails";
            this.panelTellerDetails.Size = new System.Drawing.Size(315, 141);
            this.panelTellerDetails.TabIndex = 15;
            this.panelTellerDetails.Visible = false;
            // 
            // txtTellerNo
            // 
            this.txtTellerNo.Location = new System.Drawing.Point(9, 87);
            this.txtTellerNo.MaxLength = 49;
            this.txtTellerNo.Name = "txtTellerNo";
            this.txtTellerNo.Size = new System.Drawing.Size(294, 25);
            this.txtTellerNo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Teller/Draft No.";
            // 
            // cboBank
            // 
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(11, 26);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(292, 25);
            this.cboBank.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bank";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Specified Date";
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Enabled = false;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(370, 103);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(83, 25);
            this.cboYear.TabIndex = 13;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(330, 107);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(34, 17);
            this.lblYear.TabIndex = 12;
            this.lblYear.Text = "Year";
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Enabled = false;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
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
            this.cboMonth.Location = new System.Drawing.Point(196, 103);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(119, 25);
            this.cboMonth.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Month";
            // 
            // chkMonthYear
            // 
            this.chkMonthYear.AutoSize = true;
            this.chkMonthYear.Location = new System.Drawing.Point(117, 110);
            this.chkMonthYear.Name = "chkMonthYear";
            this.chkMonthYear.Size = new System.Drawing.Size(15, 14);
            this.chkMonthYear.TabIndex = 9;
            this.chkMonthYear.UseVisualStyleBackColor = true;
            this.chkMonthYear.CheckedChanged += new System.EventHandler(this.chkMonthYear_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::MainApp.Properties.Resources.cancelPicture;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(437, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::MainApp.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(366, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(117, 135);
            this.txtComment.MaxLength = 100;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(336, 59);
            this.txtComment.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Comment";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(117, 71);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(146, 25);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount";
            // 
            // cboPaymentMode
            // 
            this.cboPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMode.FormattingEnabled = true;
            this.cboPaymentMode.Location = new System.Drawing.Point(117, 38);
            this.cboPaymentMode.Name = "cboPaymentMode";
            this.cboPaymentMode.Size = new System.Drawing.Size(228, 25);
            this.cboPaymentMode.TabIndex = 1;
            this.cboPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Mode";
            // 
            // panelOtherPayments
            // 
            this.panelOtherPayments.Controls.Add(this.txtOtherPayments);
            this.panelOtherPayments.Controls.Add(this.lblOtherPaymentMode);
            this.panelOtherPayments.Location = new System.Drawing.Point(535, 135);
            this.panelOtherPayments.Name = "panelOtherPayments";
            this.panelOtherPayments.Size = new System.Drawing.Size(314, 76);
            this.panelOtherPayments.TabIndex = 7;
            this.panelOtherPayments.Visible = false;
            // 
            // txtOtherPayments
            // 
            this.txtOtherPayments.Location = new System.Drawing.Point(9, 25);
            this.txtOtherPayments.Name = "txtOtherPayments";
            this.txtOtherPayments.Size = new System.Drawing.Size(291, 25);
            this.txtOtherPayments.TabIndex = 1;
            // 
            // lblOtherPaymentMode
            // 
            this.lblOtherPaymentMode.AutoSize = true;
            this.lblOtherPaymentMode.Location = new System.Drawing.Point(7, 3);
            this.lblOtherPaymentMode.Name = "lblOtherPaymentMode";
            this.lblOtherPaymentMode.Size = new System.Drawing.Size(133, 17);
            this.lblOtherPaymentMode.TabIndex = 0;
            this.lblOtherPaymentMode.Text = "Other Payment Mode";
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(349, 8);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(107, 103);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 2;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // MemberProfileInfo
            // 
            this.MemberProfileInfo.AutoSize = true;
            this.MemberProfileInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberProfileInfo.Location = new System.Drawing.Point(467, 23);
            this.MemberProfileInfo.Name = "MemberProfileInfo";
            this.MemberProfileInfo.Size = new System.Drawing.Size(151, 21);
            this.MemberProfileInfo.TabIndex = 3;
            this.MemberProfileInfo.Text = "MemberProfileInfo";
            this.MemberProfileInfo.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datGVContributions);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1072, 175);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Existing Contributions";
            // 
            // datGVContributions
            // 
            this.datGVContributions.AllowUserToAddRows = false;
            this.datGVContributions.AllowUserToDeleteRows = false;
            this.datGVContributions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGVContributions.Location = new System.Drawing.Point(8, 24);
            this.datGVContributions.Name = "datGVContributions";
            this.datGVContributions.ReadOnly = true;
            this.datGVContributions.Size = new System.Drawing.Size(1056, 145);
            this.datGVContributions.TabIndex = 0;
            // 
            // MakeContributions
            // 
            this.AcceptButton = this.btnFindMember;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 550);
            this.Controls.Add(this.panelOtherPayments);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MemberProfileInfo);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MakeContributions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contributions | Make Contributions";
            this.Load += new System.EventHandler(this.MakeContributions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelTellerDetails.ResumeLayout(false);
            this.panelTellerDetails.PerformLayout();
            this.panelOtherPayments.ResumeLayout(false);
            this.panelOtherPayments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGVContributions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.TextBox txtfileNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPaymentMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MemberProfileInfo;
        private System.Windows.Forms.Panel panelOtherPayments;
        private System.Windows.Forms.TextBox txtOtherPayments;
        private System.Windows.Forms.Label lblOtherPaymentMode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView datGVContributions;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkMonthYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelTellerDetails;
        private System.Windows.Forms.TextBox txtTellerNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMemberSavingsType;
    }
}