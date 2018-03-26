namespace MainApp
{
    partial class ViewDeductions
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
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDateSearch = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.datGrdVwDeductions = new System.Windows.Forms.DataGridView();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwDeductions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.btnDateSearch);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1234, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnReload
            // 
            this.btnReload.Image = global::MainApp.Properties.Resources.Sync;
            this.btnReload.Location = new System.Drawing.Point(923, 23);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(44, 35);
            this.btnReload.TabIndex = 7;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDateSearch
            // 
            this.btnDateSearch.Image = global::MainApp.Properties.Resources.find_icon;
            this.btnDateSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDateSearch.Location = new System.Drawing.Point(798, 26);
            this.btnDateSearch.Name = "btnDateSearch";
            this.btnDateSearch.Size = new System.Drawing.Size(67, 28);
            this.btnDateSearch.TabIndex = 6;
            this.btnDateSearch.Text = "Search";
            this.btnDateSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDateSearch.UseVisualStyleBackColor = true;
            this.btnDateSearch.Click += new System.EventHandler(this.btnDateSearch_Click);
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(711, 29);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(83, 23);
            this.cboYear.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(536, 29);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(130, 23);
            this.cboMonth.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(119, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(348, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File No. or Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewDetails);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnExportExcel);
            this.groupBox2.Controls.Add(this.datGrdVwDeductions);
            this.groupBox2.Location = new System.Drawing.Point(6, 90);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1233, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deductions";
            // 
            // button2
            // 
            this.button2.Image = global::MainApp.Properties.Resources.Text;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1165, 410);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "Print";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::MainApp.Properties.Resources.excel;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(1086, 410);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(77, 33);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "Export";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // datGrdVwDeductions
            // 
            this.datGrdVwDeductions.AllowUserToAddRows = false;
            this.datGrdVwDeductions.AllowUserToDeleteRows = false;
            this.datGrdVwDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdVwDeductions.Location = new System.Drawing.Point(8, 19);
            this.datGrdVwDeductions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.datGrdVwDeductions.MultiSelect = false;
            this.datGrdVwDeductions.Name = "datGrdVwDeductions";
            this.datGrdVwDeductions.ReadOnly = true;
            this.datGrdVwDeductions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGrdVwDeductions.Size = new System.Drawing.Size(1218, 385);
            this.datGrdVwDeductions.TabIndex = 0;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Image = global::MainApp.Properties.Resources.create;
            this.btnViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewDetails.Location = new System.Drawing.Point(990, 410);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(94, 33);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // ViewDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViewDeductions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deductions | View Deductions";
            this.Load += new System.EventHandler(this.ViewDeductions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdVwDeductions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datGrdVwDeductions;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDateSearch;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnViewDetails;
    }
}