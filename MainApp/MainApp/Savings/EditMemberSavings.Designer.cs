namespace MainApp
{
    partial class EditMemberSavings
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
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalSavings = new System.Windows.Forms.Label();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.txtSavingsType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstVSavings = new System.Windows.Forms.ListView();
            this.lblMemberProfileInfo = new System.Windows.Forms.Label();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Location = new System.Drawing.Point(8, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retrieve Savings Account By File No.";
            // 
            // btnFindMember
            // 
            this.btnFindMember.Enabled = false;
            this.btnFindMember.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindMember.Location = new System.Drawing.Point(307, 25);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(48, 38);
            this.btnFindMember.TabIndex = 1;
            this.btnFindMember.UseVisualStyleBackColor = true;
            this.btnFindMember.Click += new System.EventHandler(this.btnFindMember_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(13, 33);
            this.txtFileNo.MaxLength = 30;
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(288, 25);
            this.txtFileNo.TabIndex = 0;
            this.txtFileNo.TextChanged += new System.EventHandler(this.txtFileNo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalSavings);
            this.groupBox2.Controls.Add(this.lblRecordNo);
            this.groupBox2.Controls.Add(this.txtSavingsType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtComment);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lstVSavings);
            this.groupBox2.Location = new System.Drawing.Point(9, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(920, 396);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of Saving Types";
            // 
            // lblTotalSavings
            // 
            this.lblTotalSavings.AutoSize = true;
            this.lblTotalSavings.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavings.Location = new System.Drawing.Point(259, 366);
            this.lblTotalSavings.Name = "lblTotalSavings";
            this.lblTotalSavings.Size = new System.Drawing.Size(101, 17);
            this.lblTotalSavings.TabIndex = 9;
            this.lblTotalSavings.Text = "Savings Total: 0";
            this.lblTotalSavings.Visible = false;
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(13, 366);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(111, 17);
            this.lblRecordNo.TabIndex = 8;
            this.lblRecordNo.Text = "No. of Records: 0";
            // 
            // txtSavingsType
            // 
            this.txtSavingsType.Location = new System.Drawing.Point(687, 52);
            this.txtSavingsType.Multiline = true;
            this.txtSavingsType.Name = "txtSavingsType";
            this.txtSavingsType.ReadOnly = true;
            this.txtSavingsType.Size = new System.Drawing.Size(227, 38);
            this.txtSavingsType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Savings Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(684, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Enabled = false;
            this.txtComment.Location = new System.Drawing.Point(687, 174);
            this.txtComment.MaxLength = 50;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(227, 79);
            this.txtComment.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = global::MainApp.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(841, 258);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(73, 28);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(687, 118);
            this.txtAmount.MaxLength = 20;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(227, 25);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount";
            // 
            // lstVSavings
            // 
            this.lstVSavings.Location = new System.Drawing.Point(12, 26);
            this.lstVSavings.Name = "lstVSavings";
            this.lstVSavings.Size = new System.Drawing.Size(666, 332);
            this.lstVSavings.TabIndex = 0;
            this.lstVSavings.UseCompatibleStateImageBehavior = false;
            this.lstVSavings.SelectedIndexChanged += new System.EventHandler(this.lstVSavings_SelectedIndexChanged);
            this.lstVSavings.Click += new System.EventHandler(this.lstVSavings_Click);
            // 
            // lblMemberProfileInfo
            // 
            this.lblMemberProfileInfo.AutoSize = true;
            this.lblMemberProfileInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberProfileInfo.Location = new System.Drawing.Point(497, 25);
            this.lblMemberProfileInfo.Name = "lblMemberProfileInfo";
            this.lblMemberProfileInfo.Size = new System.Drawing.Size(169, 21);
            this.lblMemberProfileInfo.TabIndex = 3;
            this.lblMemberProfileInfo.Text = "lblMemberProfileInfo";
            this.lblMemberProfileInfo.Visible = false;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Location = new System.Drawing.Point(498, 73);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(119, 17);
            this.lblRegistrationDate.TabIndex = 4;
            this.lblRegistrationDate.Text = "lblRegistrationDate";
            this.lblRegistrationDate.Visible = false;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(395, 14);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(97, 99);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 2;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // EditMemberSavings
            // 
            this.AcceptButton = this.btnFindMember;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 516);
            this.Controls.Add(this.lblRegistrationDate);
            this.Controls.Add(this.lblMemberProfileInfo);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditMemberSavings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings | Edit Member Savings";
            this.Load += new System.EventHandler(this.EditMemberSavings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstVSavings;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label lblMemberProfileInfo;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtSavingsType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.Label lblTotalSavings;
    }
}