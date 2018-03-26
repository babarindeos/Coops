namespace MainApp
{
    partial class DeleteWithdrawal
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
            this.dtGrdVwWithdrawal = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboSavingsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileNo_Surname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwWithdrawal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGrdVwWithdrawal);
            this.groupBox1.Location = new System.Drawing.Point(6, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1170, 354);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtGrdVwWithdrawal
            // 
            this.dtGrdVwWithdrawal.AllowUserToAddRows = false;
            this.dtGrdVwWithdrawal.AllowUserToDeleteRows = false;
            this.dtGrdVwWithdrawal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwWithdrawal.Location = new System.Drawing.Point(8, 22);
            this.dtGrdVwWithdrawal.MultiSelect = false;
            this.dtGrdVwWithdrawal.Name = "dtGrdVwWithdrawal";
            this.dtGrdVwWithdrawal.ReadOnly = true;
            this.dtGrdVwWithdrawal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdVwWithdrawal.Size = new System.Drawing.Size(1153, 326);
            this.dtGrdVwWithdrawal.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.cboSavingsType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFileNo_Surname);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1170, 69);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFilter.Location = new System.Drawing.Point(562, 22);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(68, 42);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboSavingsType
            // 
            this.cboSavingsType.FormattingEnabled = true;
            this.cboSavingsType.Location = new System.Drawing.Point(324, 35);
            this.cboSavingsType.Name = "cboSavingsType";
            this.cboSavingsType.Size = new System.Drawing.Size(212, 23);
            this.cboSavingsType.TabIndex = 3;
            this.cboSavingsType.SelectedIndexChanged += new System.EventHandler(this.cboSavingsType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Savings Type";
            // 
            // txtFileNo_Surname
            // 
            this.txtFileNo_Surname.Location = new System.Drawing.Point(8, 35);
            this.txtFileNo_Surname.Name = "txtFileNo_Surname";
            this.txtFileNo_Surname.Size = new System.Drawing.Size(266, 23);
            this.txtFileNo_Surname.TabIndex = 1;
            this.txtFileNo_Surname.Leave += new System.EventHandler(this.txtFileNo_Surname_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File No. | Surname";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::MainApp.Properties.Resources.Erase;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(1020, 433);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Selected Record";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DeleteWithdrawal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 478);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeleteWithdrawal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Withdrawal | Delete Withdrawal";
            this.Load += new System.EventHandler(this.DeleteWithdrawal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwWithdrawal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGrdVwWithdrawal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileNo_Surname;
        private System.Windows.Forms.ComboBox cboSavingsType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
    }
}