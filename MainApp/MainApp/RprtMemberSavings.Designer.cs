namespace MainApp
{
    partial class RprtMemberSavings
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SavingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DatasetMembers = new DatasetMembers();
            this.MembersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SavingsTableAdapter = new DatasetMembersTableAdapters.SavingsTableAdapter();
            this.MembersTableAdapter = new DatasetMembersTableAdapters.MembersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SavingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SavingsBindingSource
            // 
            this.SavingsBindingSource.DataMember = "Savings";
            this.SavingsBindingSource.DataSource = this.DatasetMembers;
            // 
            // DatasetMembers
            // 
            this.DatasetMembers.DataSetName = "DatasetMembers";
            this.DatasetMembers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MembersBindingSource
            // 
            this.MembersBindingSource.DataMember = "Members";
            this.MembersBindingSource.DataSource = this.DatasetMembers;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MemberSavings_DataSet";
            reportDataSource1.Value = this.SavingsBindingSource;
            reportDataSource2.Name = "Members_DataSet";
            reportDataSource2.Value = this.MembersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MainApp.ReportMemberSavings.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(879, 381);
            this.reportViewer1.TabIndex = 0;
            // 
            // SavingsTableAdapter
            // 
            this.SavingsTableAdapter.ClearBeforeFill = true;
            // 
            // MembersTableAdapter
            // 
            this.MembersTableAdapter.ClearBeforeFill = true;
            // 
            // RprtMemberSavings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 381);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RprtMemberSavings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report | Report Member Savings";
            this.Load += new System.EventHandler(this.RprtMemberSavings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SavingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SavingsBindingSource;
        private DatasetMembers DatasetMembers;
        private System.Windows.Forms.BindingSource MembersBindingSource;
        private DatasetMembersTableAdapters.SavingsTableAdapter SavingsTableAdapter;
        private DatasetMembersTableAdapters.MembersTableAdapter MembersTableAdapter;
    }
}