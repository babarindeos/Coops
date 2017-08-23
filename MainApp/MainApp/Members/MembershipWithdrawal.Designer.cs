namespace MainApp
{
    partial class MembershipWithdrawal
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
            this.datGrdVwWithdrawn = new System.Windows.Forms.DataGridView();
            this.lblMemberProfileInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.lblFinancialStatus = new System.Windows.Forms.Label();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwWithdrawn)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Member By File No.";
            // 
            // btnFindMember
            // 
            this.btnFindMember.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFindMember.Location = new System.Drawing.Point(152, 14);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(48, 35);
            this.btnFindMember.TabIndex = 1;
            this.btnFindMember.UseVisualStyleBackColor = true;
            this.btnFindMember.Click += new System.EventHandler(this.btnFindMember_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(10, 22);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(137, 23);
            this.txtFileNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datGrdVwWithdrawn);
            this.groupBox2.Location = new System.Drawing.Point(8, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(925, 286);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Withdrawned Members";
            // 
            // datGrdVwWithdrawn
            // 
            this.datGrdVwWithdrawn.AllowUserToAddRows = false;
            this.datGrdVwWithdrawn.AllowUserToDeleteRows = false;
            this.datGrdVwWithdrawn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwWithdrawn.Location = new System.Drawing.Point(10, 19);
            this.datGrdVwWithdrawn.Name = "datGrdVwWithdrawn";
            this.datGrdVwWithdrawn.ReadOnly = true;
            this.datGrdVwWithdrawn.Size = new System.Drawing.Size(908, 261);
            this.datGrdVwWithdrawn.TabIndex = 0;
            // 
            // lblMemberProfileInfo
            // 
            this.lblMemberProfileInfo.AutoSize = true;
            this.lblMemberProfileInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberProfileInfo.Location = new System.Drawing.Point(390, 7);
            this.lblMemberProfileInfo.Name = "lblMemberProfileInfo";
            this.lblMemberProfileInfo.Size = new System.Drawing.Size(51, 21);
            this.lblMemberProfileInfo.TabIndex = 3;
            this.lblMemberProfileInfo.Text = "label1";
            this.lblMemberProfileInfo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "No. of Records";
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Enabled = false;
            this.btnWithdraw.Location = new System.Drawing.Point(217, 72);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(73, 28);
            this.btnWithdraw.TabIndex = 5;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtComment);
            this.groupBox3.Controls.Add(this.btnWithdraw);
            this.groupBox3.Location = new System.Drawing.Point(5, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 103);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remark";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(4, 18);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(285, 53);
            this.txtComment.TabIndex = 0;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // picMember
            // 
            this.picMember.Image = global::MainApp.Properties.Resources.profile_img;
            this.picMember.Location = new System.Drawing.Point(312, 4);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(73, 68);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 2;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // lblFinancialStatus
            // 
            this.lblFinancialStatus.AutoSize = true;
            this.lblFinancialStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinancialStatus.Location = new System.Drawing.Point(391, 75);
            this.lblFinancialStatus.Name = "lblFinancialStatus";
            this.lblFinancialStatus.Size = new System.Drawing.Size(115, 21);
            this.lblFinancialStatus.TabIndex = 7;
            this.lblFinancialStatus.Text = "financialStatus";
            this.lblFinancialStatus.Visible = false;
            // 
            // btnShowHide
            // 
            this.btnShowHide.Location = new System.Drawing.Point(747, 133);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(186, 30);
            this.btnShowHide.TabIndex = 8;
            this.btnShowHide.Text = "Show Withdrawned Sheet";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // MembershipWithdrawal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 484);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.lblFinancialStatus);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMemberProfileInfo);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MembershipWithdrawal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Membership |  Withdrawal";
            this.Load += new System.EventHandler(this.MembershipWithdrawal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwWithdrawn)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label lblMemberProfileInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.DataGridView datGrdVwWithdrawn;
        private System.Windows.Forms.Label lblFinancialStatus;
        private System.Windows.Forms.Button btnShowHide;
    }
}