namespace MainApp
{
    partial class ViewLoanDetails
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
            this.dtGrdVwLoans = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGrdVwRepayment = new System.Windows.Forms.DataGridView();
            this.lblRecNo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwLoans)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwRepayment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGrdVwLoans);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dtGrdVwLoans
            // 
            this.dtGrdVwLoans.AllowUserToAddRows = false;
            this.dtGrdVwLoans.AllowUserToDeleteRows = false;
            this.dtGrdVwLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwLoans.Location = new System.Drawing.Point(8, 22);
            this.dtGrdVwLoans.Name = "dtGrdVwLoans";
            this.dtGrdVwLoans.ReadOnly = true;
            this.dtGrdVwLoans.Size = new System.Drawing.Size(1177, 84);
            this.dtGrdVwLoans.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRecNo);
            this.groupBox2.Controls.Add(this.dtGrdVwRepayment);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1191, 361);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Repayment";
            // 
            // dtGrdVwRepayment
            // 
            this.dtGrdVwRepayment.AllowUserToAddRows = false;
            this.dtGrdVwRepayment.AllowUserToDeleteRows = false;
            this.dtGrdVwRepayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwRepayment.Location = new System.Drawing.Point(8, 22);
            this.dtGrdVwRepayment.Name = "dtGrdVwRepayment";
            this.dtGrdVwRepayment.ReadOnly = true;
            this.dtGrdVwRepayment.Size = new System.Drawing.Size(1176, 311);
            this.dtGrdVwRepayment.TabIndex = 1;
            // 
            // lblRecNo
            // 
            this.lblRecNo.AutoSize = true;
            this.lblRecNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecNo.Location = new System.Drawing.Point(9, 339);
            this.lblRecNo.Name = "lblRecNo";
            this.lblRecNo.Size = new System.Drawing.Size(97, 15);
            this.lblRecNo.TabIndex = 2;
            this.lblRecNo.Text = "No. of Records :  ";
            // 
            // ViewLoanDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ViewLoanDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan | View Loan Details";
            this.Load += new System.EventHandler(this.ViewLoanDetails_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwLoans)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwRepayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGrdVwLoans;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGrdVwRepayment;
        private System.Windows.Forms.Label lblRecNo;
    }
}