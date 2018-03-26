namespace MainApp
{
    partial class MakeWithdrawal
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
            this.btnGetMember = new System.Windows.Forms.Button();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.lblMemberInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lstVwSavingsSource = new System.Windows.Forms.ListView();
            this.btnPost = new System.Windows.Forms.Button();
            this.lblAmtBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWithdrawAmt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAcctAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSavingsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datGrdVwSavings = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwSavings)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetMember);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retrieve Member By File No.";
            // 
            // btnGetMember
            // 
            this.btnGetMember.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnGetMember.Location = new System.Drawing.Point(195, 28);
            this.btnGetMember.Name = "btnGetMember";
            this.btnGetMember.Size = new System.Drawing.Size(54, 36);
            this.btnGetMember.TabIndex = 1;
            this.btnGetMember.UseVisualStyleBackColor = true;
            this.btnGetMember.Click += new System.EventHandler(this.btnGetMember_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(10, 35);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(179, 25);
            this.txtFileNo.TabIndex = 0;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(284, 11);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(99, 82);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 1;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // lblMemberInfo
            // 
            this.lblMemberInfo.AutoSize = true;
            this.lblMemberInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberInfo.Location = new System.Drawing.Point(389, 19);
            this.lblMemberInfo.Name = "lblMemberInfo";
            this.lblMemberInfo.Size = new System.Drawing.Size(121, 21);
            this.lblMemberInfo.TabIndex = 2;
            this.lblMemberInfo.Text = "lblMemberInfo";
            this.lblMemberInfo.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.lstVwSavingsSource);
            this.groupBox2.Controls.Add(this.btnPost);
            this.groupBox2.Controls.Add(this.lblAmtBalance);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtWithdrawAmt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblAcctAmount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboSavingsType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1047, 254);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(260, 172);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // lstVwSavingsSource
            // 
            this.lstVwSavingsSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVwSavingsSource.Location = new System.Drawing.Point(581, 21);
            this.lstVwSavingsSource.Name = "lstVwSavingsSource";
            this.lstVwSavingsSource.Size = new System.Drawing.Size(454, 176);
            this.lstVwSavingsSource.TabIndex = 9;
            this.lstVwSavingsSource.UseCompatibleStateImageBehavior = false;
            this.lstVwSavingsSource.Click += new System.EventHandler(this.lstVwSavingsSource_Click);
            // 
            // btnPost
            // 
            this.btnPost.Enabled = false;
            this.btnPost.Location = new System.Drawing.Point(376, 205);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(84, 31);
            this.btnPost.TabIndex = 8;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // lblAmtBalance
            // 
            this.lblAmtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmtBalance.Location = new System.Drawing.Point(168, 132);
            this.lblAmtBalance.Name = "lblAmtBalance";
            this.lblAmtBalance.Size = new System.Drawing.Size(291, 28);
            this.lblAmtBalance.TabIndex = 7;
            this.lblAmtBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Balance";
            // 
            // txtWithdrawAmt
            // 
            this.txtWithdrawAmt.Location = new System.Drawing.Point(168, 99);
            this.txtWithdrawAmt.Name = "txtWithdrawAmt";
            this.txtWithdrawAmt.Size = new System.Drawing.Size(291, 25);
            this.txtWithdrawAmt.TabIndex = 5;
            this.txtWithdrawAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWithdrawAmt.TextChanged += new System.EventHandler(this.txtWithdrawAmt_TextChanged);
            this.txtWithdrawAmt.Leave += new System.EventHandler(this.txtWithdrawAmt_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Withdraw Amount";
            // 
            // lblAcctAmount
            // 
            this.lblAcctAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAcctAmount.Location = new System.Drawing.Point(168, 60);
            this.lblAcctAmount.Name = "lblAcctAmount";
            this.lblAcctAmount.Size = new System.Drawing.Size(291, 28);
            this.lblAcctAmount.TabIndex = 3;
            this.lblAcctAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount";
            // 
            // cboSavingsType
            // 
            this.cboSavingsType.FormattingEnabled = true;
            this.cboSavingsType.Location = new System.Drawing.Point(168, 24);
            this.cboSavingsType.Name = "cboSavingsType";
            this.cboSavingsType.Size = new System.Drawing.Size(292, 25);
            this.cboSavingsType.TabIndex = 1;
            this.cboSavingsType.SelectedIndexChanged += new System.EventHandler(this.cboSavingsType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Savings Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datGrdVwSavings);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 347);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1047, 191);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // datGrdVwSavings
            // 
            this.datGrdVwSavings.AllowUserToAddRows = false;
            this.datGrdVwSavings.AllowUserToDeleteRows = false;
            this.datGrdVwSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwSavings.Location = new System.Drawing.Point(9, 15);
            this.datGrdVwSavings.Name = "datGrdVwSavings";
            this.datGrdVwSavings.ReadOnly = true;
            this.datGrdVwSavings.Size = new System.Drawing.Size(1032, 170);
            this.datGrdVwSavings.TabIndex = 5;
            // 
            // MakeWithdrawal
            // 
            this.AcceptButton = this.btnGetMember;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 550);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblMemberInfo);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MakeWithdrawal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Withdrawal | Make Withdrawal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwSavings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label lblMemberInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSavingsType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetMember;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label lblAmtBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWithdrawAmt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAcctAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.ListView lstVwSavingsSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView datGrdVwSavings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}