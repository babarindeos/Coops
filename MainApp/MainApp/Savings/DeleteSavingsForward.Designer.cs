namespace MainApp
{
    partial class DeleteSavingsForward
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindMember = new System.Windows.Forms.Button();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.grpBoxSavingsInfo = new System.Windows.Forms.GroupBox();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.dtGrdVwSavings = new System.Windows.Forms.DataGridView();
            this.grpBoxDetails = new System.Windows.Forms.GroupBox();
            this.lstVwSavingDetails = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.grpBoxSavingsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).BeginInit();
            this.grpBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMemberProfile
            // 
            this.lblMemberProfile.AutoSize = true;
            this.lblMemberProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberProfile.Location = new System.Drawing.Point(356, 7);
            this.lblMemberProfile.Name = "lblMemberProfile";
            this.lblMemberProfile.Size = new System.Drawing.Size(54, 21);
            this.lblMemberProfile.TabIndex = 5;
            this.lblMemberProfile.Text = "label2";
            this.lblMemberProfile.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
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
            // picMember
            // 
            this.picMember.Location = new System.Drawing.Point(271, 4);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(78, 75);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 4;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // grpBoxSavingsInfo
            // 
            this.grpBoxSavingsInfo.Controls.Add(this.lblRecordNo);
            this.grpBoxSavingsInfo.Controls.Add(this.dtGrdVwSavings);
            this.grpBoxSavingsInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxSavingsInfo.Location = new System.Drawing.Point(5, 92);
            this.grpBoxSavingsInfo.Name = "grpBoxSavingsInfo";
            this.grpBoxSavingsInfo.Size = new System.Drawing.Size(746, 451);
            this.grpBoxSavingsInfo.TabIndex = 6;
            this.grpBoxSavingsInfo.TabStop = false;
            this.grpBoxSavingsInfo.Text = "Savings Brought Forward";
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(12, 427);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(85, 15);
            this.lblRecordNo.TabIndex = 1;
            this.lblRecordNo.Text = "No. of Records";
            // 
            // dtGrdVwSavings
            // 
            this.dtGrdVwSavings.AllowUserToAddRows = false;
            this.dtGrdVwSavings.AllowUserToDeleteRows = false;
            this.dtGrdVwSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwSavings.Location = new System.Drawing.Point(10, 22);
            this.dtGrdVwSavings.Name = "dtGrdVwSavings";
            this.dtGrdVwSavings.ReadOnly = true;
            this.dtGrdVwSavings.Size = new System.Drawing.Size(729, 399);
            this.dtGrdVwSavings.TabIndex = 0;
            this.dtGrdVwSavings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdVwSavings_CellContentClick);
            // 
            // grpBoxDetails
            // 
            this.grpBoxDetails.Controls.Add(this.lstVwSavingDetails);
            this.grpBoxDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxDetails.Location = new System.Drawing.Point(757, 92);
            this.grpBoxDetails.Name = "grpBoxDetails";
            this.grpBoxDetails.Size = new System.Drawing.Size(371, 451);
            this.grpBoxDetails.TabIndex = 7;
            this.grpBoxDetails.TabStop = false;
            this.grpBoxDetails.Text = "Details";
            // 
            // lstVwSavingDetails
            // 
            this.lstVwSavingDetails.Location = new System.Drawing.Point(10, 20);
            this.lstVwSavingDetails.Name = "lstVwSavingDetails";
            this.lstVwSavingDetails.Size = new System.Drawing.Size(355, 400);
            this.lstVwSavingDetails.TabIndex = 0;
            this.lstVwSavingDetails.UseCompatibleStateImageBehavior = false;
            // 
            // DeleteSavingsForward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 573);
            this.Controls.Add(this.grpBoxDetails);
            this.Controls.Add(this.grpBoxSavingsInfo);
            this.Controls.Add(this.lblMemberProfile);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeleteSavingsForward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings | Delete Savings Brought Forward";
            this.Load += new System.EventHandler(this.DeleteSavingsForward_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.grpBoxSavingsInfo.ResumeLayout(false);
            this.grpBoxSavingsInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).EndInit();
            this.grpBoxDetails.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dtGrdVwSavings;
        private System.Windows.Forms.GroupBox grpBoxDetails;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.ListView lstVwSavingDetails;
    }
}