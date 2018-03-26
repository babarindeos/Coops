namespace MainApp
{
    partial class DeleteLoanBroughtForward
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
            this.btnFileNoSearch = new System.Windows.Forms.Button();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.datGrdVwLoansForward = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoansForward)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileNoSearch);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1215, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnFileNoSearch
            // 
            this.btnFileNoSearch.Enabled = false;
            this.btnFileNoSearch.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFileNoSearch.Location = new System.Drawing.Point(196, 19);
            this.btnFileNoSearch.Name = "btnFileNoSearch";
            this.btnFileNoSearch.Size = new System.Drawing.Size(52, 40);
            this.btnFileNoSearch.TabIndex = 3;
            this.btnFileNoSearch.UseVisualStyleBackColor = true;
            this.btnFileNoSearch.Click += new System.EventHandler(this.btnFileNoSearch_Click);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(67, 29);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(121, 23);
            this.txtFileNo.TabIndex = 2;
            this.txtFileNo.TextChanged += new System.EventHandler(this.txtFileNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "File No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRecordNo);
            this.groupBox2.Controls.Add(this.datGrdVwLoansForward);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1214, 447);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.AutoSize = true;
            this.lblRecordNo.Location = new System.Drawing.Point(7, 421);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(83, 15);
            this.lblRecordNo.TabIndex = 1;
            this.lblRecordNo.Text = "No. of Record:";
            // 
            // datGrdVwLoansForward
            // 
            this.datGrdVwLoansForward.AllowUserToAddRows = false;
            this.datGrdVwLoansForward.AllowUserToDeleteRows = false;
            this.datGrdVwLoansForward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwLoansForward.Location = new System.Drawing.Point(6, 15);
            this.datGrdVwLoansForward.Name = "datGrdVwLoansForward";
            this.datGrdVwLoansForward.ReadOnly = true;
            this.datGrdVwLoansForward.Size = new System.Drawing.Size(1200, 396);
            this.datGrdVwLoansForward.TabIndex = 0;
            this.datGrdVwLoansForward.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datGrdVwLoansForward_CellClick);
            // 
            // DeleteLoanBroughtForward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeleteLoanBroughtForward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans | Loan Delete Loan Brought Forward";
            this.Load += new System.EventHandler(this.DeleteLoanBroughtForward_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwLoansForward)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datGrdVwLoansForward;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFileNoSearch;
    }
}