namespace MainApp
{
    partial class EditSavingsForward
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
            this.lblMemberProfile = new System.Windows.Forms.Label();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindMember = new System.Windows.Forms.Button();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxSavingsInfo = new System.Windows.Forms.GroupBox();
            this.dtGrdVwSavings = new System.Windows.Forms.DataGridView();
            this.grpBoxDetails = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSavingsID = new System.Windows.Forms.Label();
            this.lblSavingsForwardID = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblSavingsTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSavingsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstVwSavingDetails = new System.Windows.Forms.ListView();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpBoxSavingsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).BeginInit();
            this.grpBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMemberProfile
            // 
            this.lblMemberProfile.AutoSize = true;
            this.lblMemberProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberProfile.Location = new System.Drawing.Point(356, 8);
            this.lblMemberProfile.Name = "lblMemberProfile";
            this.lblMemberProfile.Size = new System.Drawing.Size(54, 21);
            this.lblMemberProfile.TabIndex = 5;
            this.lblMemberProfile.Text = "label2";
            this.lblMemberProfile.Visible = false;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Location = new System.Drawing.Point(271, 5);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(78, 75);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 4;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnFindMember
            // 
            this.btnFindMember.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindMember.Location = new System.Drawing.Point(199, 16);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(53, 40);
            this.btnFindMember.TabIndex = 2;
            this.btnFindMember.UseVisualStyleBackColor = true;
            this.btnFindMember.Click += new System.EventHandler(this.btnFindMember_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(72, 26);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(122, 23);
            this.txtFileNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File No.";
            // 
            // grpBoxSavingsInfo
            // 
            this.grpBoxSavingsInfo.Controls.Add(this.dtGrdVwSavings);
            this.grpBoxSavingsInfo.Enabled = false;
            this.grpBoxSavingsInfo.Location = new System.Drawing.Point(7, 95);
            this.grpBoxSavingsInfo.Name = "grpBoxSavingsInfo";
            this.grpBoxSavingsInfo.Size = new System.Drawing.Size(678, 386);
            this.grpBoxSavingsInfo.TabIndex = 6;
            this.grpBoxSavingsInfo.TabStop = false;
            this.grpBoxSavingsInfo.Text = "Member Savings Brought Forward";
            // 
            // dtGrdVwSavings
            // 
            this.dtGrdVwSavings.AllowUserToAddRows = false;
            this.dtGrdVwSavings.AllowUserToDeleteRows = false;
            this.dtGrdVwSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwSavings.Location = new System.Drawing.Point(6, 24);
            this.dtGrdVwSavings.Name = "dtGrdVwSavings";
            this.dtGrdVwSavings.ReadOnly = true;
            this.dtGrdVwSavings.Size = new System.Drawing.Size(666, 356);
            this.dtGrdVwSavings.TabIndex = 0;
            this.dtGrdVwSavings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdVwSavings_CellContentClick);
            // 
            // grpBoxDetails
            // 
            this.grpBoxDetails.Controls.Add(this.label5);
            this.grpBoxDetails.Controls.Add(this.lblSavingsID);
            this.grpBoxDetails.Controls.Add(this.lblSavingsForwardID);
            this.grpBoxDetails.Controls.Add(this.btnChange);
            this.grpBoxDetails.Controls.Add(this.lblSavingsTotal);
            this.grpBoxDetails.Controls.Add(this.label4);
            this.grpBoxDetails.Controls.Add(this.txtComment);
            this.grpBoxDetails.Controls.Add(this.txtAmount);
            this.grpBoxDetails.Controls.Add(this.label3);
            this.grpBoxDetails.Controls.Add(this.cboSavingsType);
            this.grpBoxDetails.Controls.Add(this.label2);
            this.grpBoxDetails.Controls.Add(this.lstVwSavingDetails);
            this.grpBoxDetails.Location = new System.Drawing.Point(693, 95);
            this.grpBoxDetails.Name = "grpBoxDetails";
            this.grpBoxDetails.Size = new System.Drawing.Size(424, 386);
            this.grpBoxDetails.TabIndex = 7;
            this.grpBoxDetails.TabStop = false;
            this.grpBoxDetails.Text = "Savings Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total: ";
            // 
            // lblSavingsID
            // 
            this.lblSavingsID.AutoSize = true;
            this.lblSavingsID.Location = new System.Drawing.Point(214, 212);
            this.lblSavingsID.Name = "lblSavingsID";
            this.lblSavingsID.Size = new System.Drawing.Size(71, 15);
            this.lblSavingsID.TabIndex = 10;
            this.lblSavingsID.Text = "lblSavingsID";
            this.lblSavingsID.Visible = false;
            // 
            // lblSavingsForwardID
            // 
            this.lblSavingsForwardID.AutoSize = true;
            this.lblSavingsForwardID.Location = new System.Drawing.Point(108, 213);
            this.lblSavingsForwardID.Name = "lblSavingsForwardID";
            this.lblSavingsForwardID.Size = new System.Drawing.Size(101, 15);
            this.lblSavingsForwardID.TabIndex = 9;
            this.lblSavingsForwardID.Text = "SavingsForwardID";
            this.lblSavingsForwardID.Visible = false;
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(341, 353);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(77, 27);
            this.btnChange.TabIndex = 8;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblSavingsTotal
            // 
            this.lblSavingsTotal.AutoSize = true;
            this.lblSavingsTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavingsTotal.Location = new System.Drawing.Point(45, 196);
            this.lblSavingsTotal.Name = "lblSavingsTotal";
            this.lblSavingsTotal.Size = new System.Drawing.Size(31, 15);
            this.lblSavingsTotal.TabIndex = 7;
            this.lblSavingsTotal.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(108, 292);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(309, 59);
            this.txtComment.TabIndex = 5;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(108, 263);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(220, 23);
            this.txtAmount.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Amount";
            // 
            // cboSavingsType
            // 
            this.cboSavingsType.FormattingEnabled = true;
            this.cboSavingsType.Location = new System.Drawing.Point(108, 234);
            this.cboSavingsType.Name = "cboSavingsType";
            this.cboSavingsType.Size = new System.Drawing.Size(220, 23);
            this.cboSavingsType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Savings Account";
            // 
            // lstVwSavingDetails
            // 
            this.lstVwSavingDetails.Location = new System.Drawing.Point(5, 26);
            this.lstVwSavingDetails.Name = "lstVwSavingDetails";
            this.lstVwSavingDetails.Size = new System.Drawing.Size(413, 167);
            this.lstVwSavingDetails.TabIndex = 0;
            this.lstVwSavingDetails.UseCompatibleStateImageBehavior = false;
            this.lstVwSavingDetails.SelectedIndexChanged += new System.EventHandler(this.lstVwSavingDetails_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(1000, 495);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 32);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EditSavingsForward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 534);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grpBoxDetails);
            this.Controls.Add(this.grpBoxSavingsInfo);
            this.Controls.Add(this.lblMemberProfile);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditSavingsForward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings | Edit Savings Forward";
            this.Load += new System.EventHandler(this.EditSavingsForward_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxSavingsInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).EndInit();
            this.grpBoxDetails.ResumeLayout(false);
            this.grpBoxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMemberProfile;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxSavingsInfo;
        private System.Windows.Forms.GroupBox grpBoxDetails;
        private System.Windows.Forms.DataGridView dtGrdVwSavings;
        private System.Windows.Forms.ListView lstVwSavingDetails;
        private System.Windows.Forms.Label lblSavingsTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSavingsType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblSavingsForwardID;
        private System.Windows.Forms.Label lblSavingsID;
        private System.Windows.Forms.Label label5;
    }
}