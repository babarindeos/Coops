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
    public partial class RprtMemberSavings : Form
    {
        string strFileNo;
        DateTime strFromDt;
        DateTime strToDt;

        public RprtMemberSavings(string strFNo,string strFromDt,string strToDt)
        {
            InitializeComponent();
            this.strFileNo = strFNo;
            this.strFromDt = Convert.ToDateTime(Convert.ToDateTime(strFromDt).ToShortDateString());
            this.strToDt = Convert.ToDateTime(Convert.ToDateTime(strToDt).ToShortDateString());
        }

        private void RprtMemberSavings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DatasetMembers.Savings' table. You can move, or remove it, as needed.
            this.SavingsTableAdapter.FillByMemberSavings(this.DatasetMembers.Savings, strFileNo, strFromDt, strToDt);
            // TODO: This line of code loads data into the 'DatasetMembers.Members' table. You can move, or remove it, as needed.
            this.MembersTableAdapter.Fill(this.DatasetMembers.Members);
            
            this.reportViewer1.RefreshReport();
           
            
        }
    }
}
