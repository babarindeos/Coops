using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp
{
    public partial class FrmReportMemberProfile : Form
    {
        private string fileNo;
        public FrmReportMemberProfile(string FileNo)
        {
            InitializeComponent();
            fileNo = FileNo;
        }

        private void FrmReportMemberProfile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DatasetMembers.Members' table. You can move, or remove it, as needed.
            this.MembersTableAdapter.FillByMemberFileNo(DatasetMembers.Members, fileNo);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }
    }
}
