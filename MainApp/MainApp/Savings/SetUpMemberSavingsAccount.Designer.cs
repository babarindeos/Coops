namespace MainApp
{
    partial class SetUpMemberSavingsAccount
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
            this.btnFindRecord = new System.Windows.Forms.Button();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddSavingsType = new System.Windows.Forms.Button();
            this.txtSavingsAmount = new System.Windows.Forms.TextBox();
            this.cboSavingsType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRegularSavings = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSavings = new System.Windows.Forms.Label();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.btnRemoveSavingsType = new System.Windows.Forms.Button();
            this.lstVSavings = new System.Windows.Forms.ListView();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.lblMemberProfileInfo = new System.Windows.Forms.Label();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindRecord);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retrieve Savings Account By File No.";
            // 
            // btnFindRecord
            // 
            this.btnFindRecord.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindRecord.Location = new System.Drawing.Point(251, 28);
            this.btnFindRecord.Name = "btnFindRecord";
            this.btnFindRecord.Size = new System.Drawing.Size(44, 33);
            this.btnFindRecord.TabIndex = 1;
            this.btnFindRecord.UseVisualStyleBackColor = true;
            this.btnFindRecord.Click += new System.EventHandler(this.btnFindRecord_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(6, 32);
            this.txtFileNo.MaxLength = 49;
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(239, 25);
            this.txtFileNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.cboSavingsType);
            this.groupBox2.Location = new System.Drawing.Point(9, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New Savings Package Type to Account";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddSavingsType);
            this.groupBox4.Controls.Add(this.txtSavingsAmount);
            this.groupBox4.Location = new System.Drawing.Point(450, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 60);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Enter Amount for Savings Type";
            // 
            // btnAddSavingsType
            // 
            this.btnAddSavingsType.Enabled = false;
            this.btnAddSavingsType.Image = global::MainApp.Properties.Resources.add_icon;
            this.btnAddSavingsType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSavingsType.Location = new System.Drawing.Point(269, 21);
            this.btnAddSavingsType.Name = "btnAddSavingsType";
            this.btnAddSavingsType.Size = new System.Drawing.Size(54, 32);
            this.btnAddSavingsType.TabIndex = 1;
            this.btnAddSavingsType.Text = "Add";
            this.btnAddSavingsType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSavingsType.UseVisualStyleBackColor = true;
            this.btnAddSavingsType.Click += new System.EventHandler(this.btnAddSavingsType_Click);
            // 
            // txtSavingsAmount
            // 
            this.txtSavingsAmount.Enabled = false;
            this.txtSavingsAmount.Location = new System.Drawing.Point(11, 24);
            this.txtSavingsAmount.Name = "txtSavingsAmount";
            this.txtSavingsAmount.ReadOnly = true;
            this.txtSavingsAmount.Size = new System.Drawing.Size(251, 25);
            this.txtSavingsAmount.TabIndex = 0;
            this.txtSavingsAmount.Leave += new System.EventHandler(this.txtSavingsAmount_Leave);
            // 
            // cboSavingsType
            // 
            this.cboSavingsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavingsType.FormattingEnabled = true;
            this.cboSavingsType.Location = new System.Drawing.Point(6, 35);
            this.cboSavingsType.Name = "cboSavingsType";
            this.cboSavingsType.Size = new System.Drawing.Size(438, 25);
            this.cboSavingsType.TabIndex = 0;
            this.cboSavingsType.SelectedIndexChanged += new System.EventHandler(this.cboSavingsType_SelectedIndexChanged);
            this.cboSavingsType.Click += new System.EventHandler(this.cboSavingsType_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRegularSavings);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblTotalSavings);
            this.groupBox3.Controls.Add(this.lblRecordNo);
            this.groupBox3.Controls.Add(this.btnRemoveSavingsType);
            this.groupBox3.Controls.Add(this.lstVSavings);
            this.groupBox3.Location = new System.Drawing.Point(9, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(785, 336);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Members Savings Type (Monthly)";
            // 
            // txtRegularSavings
            // 
            this.txtRegularSavings.Location = new System.Drawing.Point(113, 27);
            this.txtRegularSavings.Name = "txtRegularSavings";
            this.txtRegularSavings.ReadOnly = true;
            this.txtRegularSavings.Size = new System.Drawing.Size(223, 25);
            this.txtRegularSavings.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Shares Savings";
            // 
            // lblTotalSavings
            // 
            this.lblTotalSavings.AutoSize = true;
            this.lblTotalSavings.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavings.Location = new System.Drawing.Point(219, 305);
            this.lblTotalSavings.Name = "lblTotalSavings";
            this.lblTotalSavings.Size = new System.Drawing.Size(37, 17);
            this.lblTotalSavings.TabIndex = 3;
            this.lblTotalSavings.Text = "Total";
            this.lblTotalSavings.Visible = false;
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(8, 304);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(108, 17);
            this.lblRecordNo.TabIndex = 2;
            this.lblRecordNo.Text = "No of Records: 0";
            // 
            // btnRemoveSavingsType
            // 
            this.btnRemoveSavingsType.Enabled = false;
            this.btnRemoveSavingsType.Image = global::MainApp.Properties.Resources.minus;
            this.btnRemoveSavingsType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveSavingsType.Location = new System.Drawing.Point(699, 296);
            this.btnRemoveSavingsType.Name = "btnRemoveSavingsType";
            this.btnRemoveSavingsType.Size = new System.Drawing.Size(79, 34);
            this.btnRemoveSavingsType.TabIndex = 1;
            this.btnRemoveSavingsType.Text = "Remove";
            this.btnRemoveSavingsType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveSavingsType.UseVisualStyleBackColor = true;
            this.btnRemoveSavingsType.Click += new System.EventHandler(this.btnRemoveSavingsType_Click);
            // 
            // lstVSavings
            // 
            this.lstVSavings.Location = new System.Drawing.Point(6, 60);
            this.lstVSavings.Name = "lstVSavings";
            this.lstVSavings.Size = new System.Drawing.Size(771, 230);
            this.lstVSavings.TabIndex = 0;
            this.lstVSavings.UseCompatibleStateImageBehavior = false;
            this.lstVSavings.SelectedIndexChanged += new System.EventHandler(this.lstVSavings_SelectedIndexChanged);
            this.lstVSavings.Click += new System.EventHandler(this.lstVSavings_Click);
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(322, 20);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(78, 68);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 3;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // lblMemberProfileInfo
            // 
            this.lblMemberProfileInfo.AutoSize = true;
            this.lblMemberProfileInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberProfileInfo.Location = new System.Drawing.Point(406, 22);
            this.lblMemberProfileInfo.Name = "lblMemberProfileInfo";
            this.lblMemberProfileInfo.Size = new System.Drawing.Size(151, 21);
            this.lblMemberProfileInfo.TabIndex = 4;
            this.lblMemberProfileInfo.Text = "MemberProfileInfo";
            this.lblMemberProfileInfo.Visible = false;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Location = new System.Drawing.Point(407, 66);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(95, 17);
            this.lblRegistrationDate.TabIndex = 5;
            this.lblRegistrationDate.Text = "Member since ";
            this.lblRegistrationDate.Visible = false;
            // 
            // SetUpMemberSavingsAccount
            // 
            this.AcceptButton = this.btnFindRecord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 525);
            this.Controls.Add(this.lblRegistrationDate);
            this.Controls.Add(this.lblMemberProfileInfo);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetUpMemberSavingsAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings | SetUp Member Savings Account";
            this.Load += new System.EventHandler(this.SetUpMemberSavingsAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindRecord;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveSavingsType;
        private System.Windows.Forms.ListView lstVSavings;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddSavingsType;
        private System.Windows.Forms.TextBox txtSavingsAmount;
        private System.Windows.Forms.ComboBox cboSavingsType;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label lblMemberProfileInfo;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.TextBox txtRegularSavings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalSavings;
        private System.Windows.Forms.Label lblRegistrationDate;
    }
}