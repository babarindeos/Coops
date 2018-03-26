namespace MainApp
{
    partial class UnpostDeductions
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
            this.btnBulkUnpost = new System.Windows.Forms.Button();
            this.lblBulkStatus = new System.Windows.Forms.Label();
            this.dtGrdBulkDeductions = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSingleUnpost = new System.Windows.Forms.Button();
            this.lblSingleStatus = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtGrdSingleDeductions = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdBulkDeductions)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdSingleDeductions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBulkUnpost);
            this.groupBox1.Controls.Add(this.lblBulkStatus);
            this.groupBox1.Controls.Add(this.dtGrdBulkDeductions);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bulk Action - Unpost Monthly Deduction";
            // 
            // btnBulkUnpost
            // 
            this.btnBulkUnpost.Enabled = false;
            this.btnBulkUnpost.Image = global::MainApp.Properties.Resources.Erase;
            this.btnBulkUnpost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBulkUnpost.Location = new System.Drawing.Point(390, 411);
            this.btnBulkUnpost.Name = "btnBulkUnpost";
            this.btnBulkUnpost.Size = new System.Drawing.Size(135, 32);
            this.btnBulkUnpost.TabIndex = 2;
            this.btnBulkUnpost.Text = "Unpost Deduction";
            this.btnBulkUnpost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBulkUnpost.UseVisualStyleBackColor = true;
            this.btnBulkUnpost.Click += new System.EventHandler(this.btnBulkUnpost_Click);
            // 
            // lblBulkStatus
            // 
            this.lblBulkStatus.AutoSize = true;
            this.lblBulkStatus.Location = new System.Drawing.Point(8, 419);
            this.lblBulkStatus.Name = "lblBulkStatus";
            this.lblBulkStatus.Size = new System.Drawing.Size(39, 15);
            this.lblBulkStatus.TabIndex = 1;
            this.lblBulkStatus.Text = "Status";
            // 
            // dtGrdBulkDeductions
            // 
            this.dtGrdBulkDeductions.AllowUserToAddRows = false;
            this.dtGrdBulkDeductions.AllowUserToDeleteRows = false;
            this.dtGrdBulkDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdBulkDeductions.Location = new System.Drawing.Point(6, 30);
            this.dtGrdBulkDeductions.MultiSelect = false;
            this.dtGrdBulkDeductions.Name = "dtGrdBulkDeductions";
            this.dtGrdBulkDeductions.ReadOnly = true;
            this.dtGrdBulkDeductions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdBulkDeductions.Size = new System.Drawing.Size(518, 376);
            this.dtGrdBulkDeductions.TabIndex = 0;
            this.dtGrdBulkDeductions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdBulkDeductions_CellClick);
            this.dtGrdBulkDeductions.SelectionChanged += new System.EventHandler(this.dtGrdBulkDeductions_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSingleUnpost);
            this.groupBox2.Controls.Add(this.lblSingleStatus);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.dtGrdSingleDeductions);
            this.groupBox2.Location = new System.Drawing.Point(544, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 448);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single Action - Unpost Individual Monthly Deduction";
            // 
            // btnSingleUnpost
            // 
            this.btnSingleUnpost.Enabled = false;
            this.btnSingleUnpost.Image = global::MainApp.Properties.Resources.Erase;
            this.btnSingleUnpost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSingleUnpost.Location = new System.Drawing.Point(531, 411);
            this.btnSingleUnpost.Name = "btnSingleUnpost";
            this.btnSingleUnpost.Size = new System.Drawing.Size(132, 32);
            this.btnSingleUnpost.TabIndex = 5;
            this.btnSingleUnpost.Text = "Unpost Deduction";
            this.btnSingleUnpost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSingleUnpost.UseVisualStyleBackColor = true;
            this.btnSingleUnpost.Click += new System.EventHandler(this.btnSingleUnpost_Click);
            // 
            // lblSingleStatus
            // 
            this.lblSingleStatus.AutoSize = true;
            this.lblSingleStatus.Location = new System.Drawing.Point(8, 420);
            this.lblSingleStatus.Name = "lblSingleStatus";
            this.lblSingleStatus.Size = new System.Drawing.Size(39, 15);
            this.lblSingleStatus.TabIndex = 4;
            this.lblSingleStatus.Text = "Status";
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::MainApp.Properties.Resources.search_member2;
            this.btnFilter.Location = new System.Drawing.Point(457, 23);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(66, 35);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "File No. | Surname";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(118, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(333, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // dtGrdSingleDeductions
            // 
            this.dtGrdSingleDeductions.AllowUserToAddRows = false;
            this.dtGrdSingleDeductions.AllowUserToDeleteRows = false;
            this.dtGrdSingleDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdSingleDeductions.Location = new System.Drawing.Point(7, 62);
            this.dtGrdSingleDeductions.MultiSelect = false;
            this.dtGrdSingleDeductions.Name = "dtGrdSingleDeductions";
            this.dtGrdSingleDeductions.ReadOnly = true;
            this.dtGrdSingleDeductions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdSingleDeductions.Size = new System.Drawing.Size(655, 343);
            this.dtGrdSingleDeductions.TabIndex = 0;
            this.dtGrdSingleDeductions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdSingleDeductions_CellClick);
            // 
            // UnpostDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UnpostDeductions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unpost Deductions";
            this.Load += new System.EventHandler(this.UnpostDeductions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdBulkDeductions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdSingleDeductions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGrdBulkDeductions;
        private System.Windows.Forms.DataGridView dtGrdSingleDeductions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblBulkStatus;
        private System.Windows.Forms.Button btnBulkUnpost;
        private System.Windows.Forms.Label lblSingleStatus;
        private System.Windows.Forms.Button btnSingleUnpost;
    }
}