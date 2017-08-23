namespace MainApp
{
    partial class FrmReportMembers
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
            this.MembersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DatasetMembers = new DatasetMembers();
            this.reportMembers = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MembersTableAdapter = new DatasetMembersTableAdapters.MembersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.MembersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // MembersBindingSource
            // 
            this.MembersBindingSource.DataMember = "Members";
            this.MembersBindingSource.DataSource = this.DatasetMembers;
            // 
            // DatasetMembers
            // 
            this.DatasetMembers.DataSetName = "DatasetMembers";
            this.DatasetMembers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportMembers
            // 
            this.reportMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MembersBindingSource;
            this.reportMembers.LocalReport.DataSources.Add(reportDataSource1);
            this.reportMembers.LocalReport.ReportEmbeddedResource = "MainApp.ReportMembers.rdlc";
            this.reportMembers.Location = new System.Drawing.Point(0, 0);
            this.reportMembers.Name = "reportMembers";
            this.reportMembers.Size = new System.Drawing.Size(726, 477);
            this.reportMembers.TabIndex = 0;
            // 
            // MembersTableAdapter
            // 
            this.MembersTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 477);
            this.Controls.Add(this.reportMembers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmReportMembers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report | Members List";
            this.Load += new System.EventHandler(this.FrmReportMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MembersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportMembers;
        private System.Windows.Forms.BindingSource MembersBindingSource;
        private DatasetMembers DatasetMembers;
        private DatasetMembersTableAdapters.MembersTableAdapter MembersTableAdapter;
    }
}