namespace MainApp
{
    partial class MembersList
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
            this.datGrdMembers = new System.Windows.Forms.DataGridView();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblFileNo = new System.Windows.Forms.Label();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.dtGrdPersonalProfile = new System.Windows.Forms.DataGridView();
            this.dtGrdVwSavings = new System.Windows.Forms.DataGridView();
            this.dtGrdVwContributions = new System.Windows.Forms.DataGridView();
            this.dtGrdVwDeductions = new System.Windows.Forms.DataGridView();
            this.dtGrdVwLoans = new System.Windows.Forms.DataGridView();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdMembers)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdPersonalProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwContributions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwLoans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.lblFileNo);
            this.groupBox1.Controls.Add(this.datGrdMembers);
            this.groupBox1.Controls.Add(this.lblRecordNo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Members Records";
            // 
            // datGrdMembers
            // 
            this.datGrdMembers.AllowUserToAddRows = false;
            this.datGrdMembers.AllowUserToDeleteRows = false;
            this.datGrdMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdMembers.Location = new System.Drawing.Point(6, 51);
            this.datGrdMembers.Name = "datGrdMembers";
            this.datGrdMembers.ReadOnly = true;
            this.datGrdMembers.RowHeadersWidth = 45;
            this.datGrdMembers.Size = new System.Drawing.Size(452, 194);
            this.datGrdMembers.TabIndex = 6;
            this.datGrdMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGrdMembers_CellContentClick);
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(366, 394);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(105, 15);
            this.lblRecordNo.TabIndex = 5;
            this.lblRecordNo.Text = "MemberRecordNo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGrdVwSavings);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(478, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 164);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Savings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtGrdPersonalProfile);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(478, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(807, 84);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Personal Profile";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtGrdVwContributions);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(8, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(660, 148);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Contributions";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtGrdVwLoans);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(8, 405);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(660, 160);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Loans";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtGrdVwDeductions);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(674, 255);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(611, 148);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Deductions";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridView6);
            this.groupBox8.Location = new System.Drawing.Point(674, 405);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(611, 160);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Withdrawals";
            // 
            // lblFileNo
            // 
            this.lblFileNo.AutoSize = true;
            this.lblFileNo.Location = new System.Drawing.Point(6, 24);
            this.lblFileNo.Name = "lblFileNo";
            this.lblFileNo.Size = new System.Drawing.Size(47, 15);
            this.lblFileNo.TabIndex = 7;
            this.lblFileNo.Text = "File No.";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(64, 22);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(124, 23);
            this.txtFileNo.TabIndex = 8;
            // 
            // dtGrdPersonalProfile
            // 
            this.dtGrdPersonalProfile.AllowUserToAddRows = false;
            this.dtGrdPersonalProfile.AllowUserToDeleteRows = false;
            this.dtGrdPersonalProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdPersonalProfile.Location = new System.Drawing.Point(6, 17);
            this.dtGrdPersonalProfile.Name = "dtGrdPersonalProfile";
            this.dtGrdPersonalProfile.ReadOnly = true;
            this.dtGrdPersonalProfile.Size = new System.Drawing.Size(794, 65);
            this.dtGrdPersonalProfile.TabIndex = 0;
            // 
            // dtGrdVwSavings
            // 
            this.dtGrdVwSavings.AllowUserToAddRows = false;
            this.dtGrdVwSavings.AllowUserToDeleteRows = false;
            this.dtGrdVwSavings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwSavings.Location = new System.Drawing.Point(6, 18);
            this.dtGrdVwSavings.Name = "dtGrdVwSavings";
            this.dtGrdVwSavings.ReadOnly = true;
            this.dtGrdVwSavings.Size = new System.Drawing.Size(793, 140);
            this.dtGrdVwSavings.TabIndex = 1;
            // 
            // dtGrdVwContributions
            // 
            this.dtGrdVwContributions.AllowUserToAddRows = false;
            this.dtGrdVwContributions.AllowUserToDeleteRows = false;
            this.dtGrdVwContributions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwContributions.Location = new System.Drawing.Point(6, 19);
            this.dtGrdVwContributions.Name = "dtGrdVwContributions";
            this.dtGrdVwContributions.ReadOnly = true;
            this.dtGrdVwContributions.Size = new System.Drawing.Size(648, 125);
            this.dtGrdVwContributions.TabIndex = 2;
            // 
            // dtGrdVwDeductions
            // 
            this.dtGrdVwDeductions.AllowUserToAddRows = false;
            this.dtGrdVwDeductions.AllowUserToDeleteRows = false;
            this.dtGrdVwDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwDeductions.Location = new System.Drawing.Point(6, 19);
            this.dtGrdVwDeductions.Name = "dtGrdVwDeductions";
            this.dtGrdVwDeductions.ReadOnly = true;
            this.dtGrdVwDeductions.Size = new System.Drawing.Size(597, 123);
            this.dtGrdVwDeductions.TabIndex = 3;
            // 
            // dtGrdVwLoans
            // 
            this.dtGrdVwLoans.AllowUserToAddRows = false;
            this.dtGrdVwLoans.AllowUserToDeleteRows = false;
            this.dtGrdVwLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwLoans.Location = new System.Drawing.Point(9, 24);
            this.dtGrdVwLoans.Name = "dtGrdVwLoans";
            this.dtGrdVwLoans.ReadOnly = true;
            this.dtGrdVwLoans.Size = new System.Drawing.Size(642, 130);
            this.dtGrdVwLoans.TabIndex = 13;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(6, 24);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.Size = new System.Drawing.Size(597, 130);
            this.dataGridView6.TabIndex = 3;
            // 
            // MembersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 572);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MembersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Members | Members List";
            this.Load += new System.EventHandler(this.MembersList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdMembers)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdPersonalProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwSavings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwContributions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwLoans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView datGrdMembers;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label lblFileNo;
        private System.Windows.Forms.DataGridView dtGrdVwSavings;
        private System.Windows.Forms.DataGridView dtGrdPersonalProfile;
        private System.Windows.Forms.DataGridView dtGrdVwContributions;
        private System.Windows.Forms.DataGridView dtGrdVwLoans;
        private System.Windows.Forms.DataGridView dtGrdVwDeductions;
        private System.Windows.Forms.DataGridView dataGridView6;

    }
}