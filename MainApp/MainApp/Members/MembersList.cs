using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MainApp
{
    public partial class MembersList : Form
    {
        public MembersList()
        {
            InitializeComponent();
        }

        private void MembersList_Load(object sender, EventArgs e)
        {
            loadMembersRecords();

        }

        private void loadMembersRecords()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo 'File No', m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name' " +
                "from Members m ";                

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Members");
                DataTable dt = ds.Tables["Members"];
                datGrdMembers.DataSource = dt;

                
                datGrdMembers.Columns["File No"].Width = 70;
                datGrdMembers.Columns["Full Name"].Width = 210;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                datGrdMembers.Columns.Add(btn);
                btn.HeaderText = "Action";
                btn.Text = "Details";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                datGrdMembers.Columns[0].Visible = false;
                lblRecordNo.Text = "No. of Records : " + dt.Rows.Count;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnMemberProfile_Click(object sender, EventArgs e)
        {
            MemberProfile memberProfile = new MemberProfile();

            memberProfile.ShowDialog();
        }

        private void datGrdMembers_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void datGrdMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {                
                    MessageBox.Show(datGrdMembers.Rows[e.RowIndex].Cells[2].Value.ToString());                
            }
        }

        private void datGrdMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            string memberID = string.Empty;

            if (e.ColumnIndex == 0)
            {
                memberID = datGrdMembers.Rows[e.RowIndex].Cells[1].Value.ToString();
                memberPersonalProfile(memberID);
                memberSavings(memberID);
                contributions(memberID);
                deductions(memberID);
                loans(memberID);
            }
        }

        private void memberPersonalProfile(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID 'ID', m.FileNo as [File No.], m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                "m.Gender,m.Address, m.LGA, s.State, m.Phone, m.Email, d.DepartmentName [Department], b.BankName [Bank], m.AccountNo [Account], m.NOKFullName [Next of Kin]," +
                "m.NOKPhone [Kin Phone], m.NOKAddress [NOK Addr.] from Members m " +
                "left join States s on m.StateID = s.StateID " +
                "left join Departments d on m.DepartmentID=d.DepartmentID " +
                "left join Banks b on m.BankID=b.BankID " +
                "where m.MemberID='" + memberID + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Members");
                DataTable dt = ds.Tables["Members"];
                dtGrdPersonalProfile.DataSource = dt;

                dtGrdPersonalProfile.Columns["ID"].Width = 60;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }


                
        }

        private void memberSavings(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select s.SavingsID 'ID',m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                "s.SavingSource 'Saving Source',s.Amount,mnth.Month,s.Year,s.TransactionID,s.Date from Savings s " +
                "left join Members m on m.MemberID=s.MemberID " +
                "left join MonthByName mnth on  mnth.MonthID=s.Month " +
                "where s.MemberID='" + memberID + "' order by s.SavingsID desc";

            SqlCommand cmd = new SqlCommand(strQuery,conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                DataTable dt = ds.Tables["Savings"];

                dtGrdVwSavings.DataSource = dt;
                dtGrdVwSavings.Columns["ID"].Width = 50;
                dtGrdVwSavings.Columns["Full Name"].Width = 150;
                dtGrdVwSavings.Columns["Saving Source"].Width = 120;
                dtGrdVwSavings.Columns["Full Name"].Visible = false;
                dtGrdVwSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdVwSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void contributions(string memberID)
        {
            BuildTempSavingsAcctType.Create();
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select c.ContributionID 'ID',p.PaymentMode,c.OtherPayment,b.BankName,s.Amount,s.SavingSource 'Saving Source',mnth.Month,s.Year,c.TellerNo 'Teller No.',c.ReceiptNo 'Receipt No.',c.Comment, " +
                "t.SavingsName 'Savings Type',s.TransactionID,s.Date from Contributions c " +
                "left join Savings s on c.SavingsID=s.SavingsID " +
                "left join Members m on s.MemberID = m.MemberID " +
                "left join PaymentMode p on p.PaymentModeID=c.PaymentModeID " +
                "left join Banks b on b.BankID=c.BankID " +
                "left join MonthByName mnth on mnth.MonthID=s.Month " +
                "left join TempSavingsAcctType t on c.SavingsAcctID=t.SavingsTypeID " +
                "where s.MemberID='" + memberID + "' order by c.ContributionID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Contributions");
                DataTable dt = ds.Tables["Contributions"];
                dtGrdVwContributions.DataSource = dt;

                dtGrdVwContributions.Columns["ID"].Width = 60;
                dtGrdVwContributions.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdVwContributions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void deductions(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select d.DeductionID 'ID',mnth.Month,d.Year,d.Savings,d.Loans,d.Total,d.TransactionID,DatePosted " +
                "from Deductions d left join MonthByName mnth on d.Month=mnth.MonthID " +
                "where d.MemberID='" + memberID + "' order by d.DeductionID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");
                DataTable dt = ds.Tables["Deductions"];
                dtGrdVwDeductions.DataSource = dt;

                dtGrdVwDeductions.Columns["ID"].Width = 60;
                dtGrdVwDeductions.Columns["Savings"].DefaultCellStyle.Format = "N2";
                dtGrdVwDeductions.Columns["Savings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwDeductions.Columns["Loans"].DefaultCellStyle.Format = "N2";
                dtGrdVwDeductions.Columns["Loans"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwDeductions.Columns["Total"].DefaultCellStyle.Format = "N2";
                dtGrdVwDeductions.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void loans(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select a.LoanApplicationID 'ID',mnth.Month,a.AppYear 'Year',lc.Name 'Loan Category',lt.Type 'Loan Type', "+
                "a.LoanAmount 'Loan Amt.',a.InterestAmount 'Interest',a.TotalRepayment 'Total Repayment',a.MonthlyRepayment 'Monthly Repayment', " +
                "l.AmountPaid 'Amount Paid',l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status',a.DatePosted 'Date Posted' " +
                "from LoanApplication a left join Loans l on a.LoanApplicationID=l.LoanApplicationID " +
                "left join MonthByName mnth on mnth.MonthID=a.AppMonth " +
                "left join LoanCategory lc on lc.LoanCategoryID=a.LoanCategoryID " +
                "left join LoanType lt on lt.LoanTypeID=a.LoanTypeID " +
                "where a.MemberID='" + memberID + "' order by a.LoanApplicationID desc";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Loans");
                DataTable dt = ds.Tables["Loans"];

                dtGrdVwLoans.DataSource = dt;
                dtGrdVwLoans.Columns["ID"].Width = 60;
                dtGrdVwLoans.Columns["Loan Amt."].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Loan Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwLoans.Columns["Interest"].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwLoans.Columns["Total Repayment"].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Total Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwLoans.Columns["Monthly Repayment"].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Monthly Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwLoans.Columns["Amount Paid"].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Amount Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwLoans.Columns["Outstanding Amt."].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Outstanding Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
