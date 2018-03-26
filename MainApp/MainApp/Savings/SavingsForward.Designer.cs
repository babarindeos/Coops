namespace MainApp
{
    partial class SavingsForward
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblMemberProfile = new System.Windows.Forms.Label();
            this.grpBoxSavingsInfo = new System.Windows.Forms.GroupBox();
            this.btnPostSavings = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRemoveSavings = new System.Windows.Forms.Button();
            this.lblTotalSavings = new System.Windows.Forms.Label();
            this.lstVwSavings = new System.Windows.Forms.ListView();
            this.btnAddSavings = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSavingsAcct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalSavingsForward = new System.Windows.Forms.Label();
            this.dtGrdVwSavingsForward = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblMemberTotalSavings = new System.Windows.Forms.Label();
            this.dtGrdVwSavings = new System.Windows.Forms.DataGridView();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.grpBoxSavingsInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavingsForward)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMember);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 67);
            this.groupBox1.TabIndex = 0;
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
            // lblMemberProfile
            // 
            this.lblMemberProfile.AutoSize = true;
            this.lblMemberProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberProfile.Location = new System.Drawing.Point(357, 7);
            this.lblMemberProfile.Name = "lblMemberProfile";
            this.lblMemberProfile.Size = new System.Drawing.Size(54, 21);
            this.lblMemberProfile.TabIndex = 2;
            this.lblMemberProfile.Text = "label2";
            this.lblMemberProfile.Visible = false;
            // 
            // grpBoxSavingsInfo
            // 
            this.grpBoxSavingsInfo.Controls.Add(this.btnPostSavings);
            this.grpBoxSavingsInfo.Controls.Add(this.txtComment);
            this.grpBoxSavingsInfo.Controls.Add(this.label9);
            this.grpBoxSavingsInfo.Controls.Add(this.btnRemoveSavings);
            this.grpBoxSavingsInfo.Controls.Add(this.lblTotalSavings);
            this.grpBoxSavingsInfo.Controls.Add(this.lstVwSavings);
            this.grpBoxSavingsInfo.Controls.Add(this.btnAddSavings);
            this.grpBoxSavingsInfo.Controls.Add(this.txtAmount);
            this.grpBoxSavingsInfo.Controls.Add(this.label5);
            this.grpBoxSavingsInfo.Controls.Add(this.cboYear);
            this.grpBoxSavingsInfo.Controls.Add(this.cboMonth);
            this.grpBoxSavingsInfo.Controls.Add(this.label4);
            this.grpBoxSavingsInfo.Controls.Add(this.cboSavingsAcct);
            this.grpBoxSavingsInfo.Controls.Add(this.label3);
            this.grpBoxSavingsInfo.Enabled = false;
            this.grpBoxSavingsInfo.Location = new System.Drawing.Point(7, 83);
            this.grpBoxSavingsInfo.Name = "grpBoxSavingsInfo";
            this.grpBoxSavingsInfo.Size = new System.Drawing.Size(533, 473);
            this.grpBoxSavingsInfo.TabIndex = 3;
            this.grpBoxSavingsInfo.TabStop = false;
            // 
            // btnPostSavings
            // 
            this.btnPostSavings.Enabled = false;
            this.btnPostSavings.Image = global::MainApp.Properties.Resources.save;
            this.btnPostSavings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPostSavings.Location = new System.Drawing.Point(428, 431);
            this.btnPostSavings.Name = "btnPostSavings";
            this.btnPostSavings.Size = new System.Drawing.Size(99, 33);
            this.btnPostSavings.TabIndex = 13;
            this.btnPostSavings.Text = "Post Savings";
            this.btnPostSavings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPostSavings.UseVisualStyleBackColor = true;
            this.btnPostSavings.Click += new System.EventHandler(this.btnPostSavings_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(118, 345);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(406, 50);
            this.txtComment.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Comment";
            // 
            // btnRemoveSavings
            // 
            this.btnRemoveSavings.Enabled = false;
            this.btnRemoveSavings.Image = global::MainApp.Properties.Resources.Erase;
            this.btnRemoveSavings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveSavings.Location = new System.Drawing.Point(447, 294);
            this.btnRemoveSavings.Name = "btnRemoveSavings";
            this.btnRemoveSavings.Size = new System.Drawing.Size(77, 27);
            this.btnRemoveSavings.TabIndex = 10;
            this.btnRemoveSavings.Text = "Remove";
            this.btnRemoveSavings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveSavings.UseVisualStyleBackColor = true;
            this.btnRemoveSavings.Click += new System.EventHandler(this.btnRemoveSavings_Click);
            // 
            // lblTotalSavings
            // 
            this.lblTotalSavings.AutoSize = true;
            this.lblTotalSavings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavings.Location = new System.Drawing.Point(121, 297);
            this.lblTotalSavings.Name = "lblTotalSavings";
            this.lblTotalSavings.Size = new System.Drawing.Size(36, 15);
            this.lblTotalSavings.TabIndex = 9;
            this.lblTotalSavings.Text = "Total:";
            // 
            // lstVwSavings
            // 
            this.lstVwSavings.Location = new System.Drawing.Point(118, 144);
            this.lstVwSavings.Name = "lstVwSavings";
            this.lstVwSavings.Size = new System.Drawing.Size(405, 148);
            this.lstVwSavings.TabIndex = 8;
            this.lstVwSavings.UseCompatibleStateImageBehavior = false;
            this.lstVwSavings.SelectedIndexChanged += new System.EventHandler(this.lstVwSavings_SelectedIndexChanged);
            // 
            // btnAddSavings
            // 
            this.btnAddSavings.Location = new System.Drawing.Point(345, 104);
            this.btnAddSavings.Name = "btnAddSavings";
            this.btnAddSavings.Size = new System.Drawing.Size(77, 27);
            this.btnAddSavings.TabIndex = 7;
            this.btnAddSavings.Text = "Add";
            this.btnAddSavings.UseVisualStyleBackColor = true;
            this.btnAddSavings.Click += new System.EventHandler(this.btnAddSavings_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(118, 106);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(224, 23);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Amount";
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboYear.Location = new System.Drawing.Point(271, 28);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(93, 23);
            this.cboYear.TabIndex = 4;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "",
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
            this.cboMonth.Location = new System.Drawing.Point(118, 28);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(147, 23);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Savings Period";
            // 
            // cboSavingsAcct
            // 
            this.cboSavingsAcct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavingsAcct.FormattingEnabled = true;
            this.cboSavingsAcct.Location = new System.Drawing.Point(118, 67);
            this.cboSavingsAcct.Name = "cboSavingsAcct";
            this.cboSavingsAcct.Size = new System.Drawing.Size(225, 23);
            this.cboSavingsAcct.TabIndex = 1;
            this.cboSavingsAcct.SelectedIndexChanged += new System.EventHandler(this.cboSavingsAcct_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Savings Account";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalSavingsForward);
            this.groupBox3.Controls.Add(this.dtGrdVwSavingsForward);
            this.groupBox3.Location = new System.Drawing.Point(546, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(623, 243);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Savings Brought Forward";
            // 
            // lblTotalSavingsForward
            // 
            this.lblTotalSavingsForward.AutoSize = true;
            this.lblTotalSavingsForward.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavingsForward.Location = new System.Drawing.Point(9, 218);
            this.lblTotalSavingsForward.Name = "lblTotalSavingsForward";
            this.lblTotalSavingsForward.Size = new System.Drawing.Size(33, 15);
            this.lblTotalSavingsForward.TabIndex = 1;
            this.lblTotalSavingsForward.Text = "Total";
            // 
            // dtGrdVwSavingsForward
            // 
            this.dtGrdVwSavingsForward.AllowUserToAddRows = false;
            this.dtGrdVwSavingsForward.AllowUserToDeleteRows = false;
            this.dtGrdVwSavingsForward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwSavingsForward.Location = new System.Drawing.Point(10, 19);
            this.dtGrdVwSavingsForward.Name = "dtGrdVwSavingsForward";
            this.dtGrdVwSavingsForward.ReadOnly = true;
            this.dtGrdVwSavingsForward.Size = new System.Drawing.Size(607, 191);
            this.dtGrdVwSavingsForward.TabIndex = 0;
            this.dtGrdVwSavingsForward.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdVwSavingsForward_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblMemberTotalSavings);
            this.groupBox4.Controls.Add(this.dtGrdVwSavings);
            this.groupBox4.Location = new System.Drawing.Point(546, 331);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 224);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Savings";
            // 
            // lblMemberTotalSavings
            // 
            this.lblMemberTotalSavings.AutoSize = true;
            this.lblMemberTotalSavings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberTotalSavings.Location = new System.Drawing.Point(9, 201);
            this.lblMemberTotalSavings.Name = "lblMemberTotalSavings";
            this.lblMemberTotalSavings.Size = new System.Drawing.Size(33, 15);
            this.lblMemberTotalSavings.TabIndex = 1;
            this.lblMemberTotalSavings.Text = "Total";
            // 
            // dtGrdVwSavings
            // 
            this.dtGrdVwSavings.AllowUserToAddRows = false;
            this.dtGrdVwSavings.AllowUserToDeleteRows = false;
            this.dtGrdVwSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwSavings.Location = new System.Drawing.Point(12, 20);
            this.dtGrdVwSavings.Name = "dtGrdVwSavings";
            this.dtGrdVwSavings.ReadOnly = true;
            this.dtGrdVwSavings.Size = new System.Drawing.Size(605, 172);
            this.dtGrdVwSavings.TabIndex = 0;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Location = new System.Drawing.Point(272, 4);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(78, 75);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 1;
            this.picMember.TabStop = false;
            this.picMember.Visible = false;
            // 
            // SavingsForward
            // 
            this.AcceptButton = this.btnFindMember;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 568);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpBoxSavingsInfo);
            this.Controls.Add(this.lblMemberProfile);
            this.Controls.Add(this.picMember);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SavingsForward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings | Savings Brought Forward";
            this.Load += new System.EventHandler(this.SavingsForward_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxSavingsInfo.ResumeLayout(false);
            this.grpBoxSavingsInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavingsForward)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label lblMemberProfile;
        private System.Windows.Forms.GroupBox grpBoxSavingsInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboSavingsAcct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveSavings;
        private System.Windows.Forms.Label lblTotalSavings;
        private System.Windows.Forms.ListView lstVwSavings;
        private System.Windows.Forms.Button btnAddSavings;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalSavingsForward;
        private System.Windows.Forms.DataGridView dtGrdVwSavingsForward;
        private System.Windows.Forms.Label lblMemberTotalSavings;
        private System.Windows.Forms.DataGridView dtGrdVwSavings;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPostSavings;
    }
}