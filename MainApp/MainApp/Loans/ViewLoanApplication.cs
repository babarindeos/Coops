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
    public partial class ViewLoanApplication : Form
    {

        private string strFilter = string.Empty;
        private string loanApproval = string.Empty;
        DataTable dt;

        public ViewLoanApplication(string loanApproval)
        {
            InitializeComponent();
            this.loanApproval = loanApproval;
            
        }

        private void ViewLoanApplication_Load(object sender, EventArgs e)
        {
            loadLoanApplications();
            loadCategory();
            loadType();           
        }

        private void loadType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoanTypeID, Type from LoanType";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanType");
                DataTable dt = ds.Tables["LoanType"];

                cboType.DisplayMember = "Type";
                cboType.ValueMember = "LoanTypeID";

                DataRow row = dt.NewRow();
                row["Type"] = "";
                dt.Rows.InsertAt(row, 0);
                cboType.DataSource = dt;

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

        private void loadCategory()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoanCategoryID, Name from LoanCategory";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanCategory");
                DataTable dt = ds.Tables["LoanCategory"];

                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "LoanCategoryID";
                

                DataRow row = dt.NewRow();
                row["Name"] = "";
                dt.Rows.InsertAt(row, 0);

                cboCategory.DataSource = dt;
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
        

        private void loadLoanApplications()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = string.Empty;

            lblAmountPaid.Text = "0";
            lblOutstandingAmt.Text = "0";
            lblRepaymentStatus.Text = string.Empty;

            if (loanApproval == "Yes")
            {
                //If the loanApplication is Approved (Yes)
                switch (strFilter)
                {
                    case "":
                        strQuery = "Select a.LoanApplicationID, mon.Month 'Month',a.AppYear 'Year',m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                           "lc.Name 'Category', lt.Type, a.LoanAmount 'Loan Amount', a.FormFee 'Form Fee', a.LoanDuration 'Duration',a.InterestRate 'Interest Rate',a.InterestAmount 'Interest Amt.',a.TotalRepayment 'Repayment',a.MonthlyRepayment 'Monthly',a.ApprovalStatus 'Approval', " +
                           "l.AmountPaid 'Amount Paid', l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status', a.TransactionID 'Transact ID',a.DatePosted 'Date Posted' " +
                           "from LoanApplication a left join Members m on a.MemberID = m.MemberID " +
                           "left join Loans l on a.LoanApplicationID=l.LoanApplicationID " +
                           "left join MonthByName mon on a.AppMonth = mon.MonthID " +
                           "left join LoanCategory lc on a.LoanCategoryID = lc.LoanCategoryID " +
                           "left join LoanType lt on a.LoanTypeID = lt.LoanTypeID " +
                           "where a.ApprovalStatus='Yes' " +
                           "order by LoanApplicationID desc ";
                        break;
                    default:
                        strQuery = "Select a.LoanApplicationID, mon.Month 'Month',a.AppYear 'Year',m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                            "lc.Name 'Category', lt.Type, a.LoanAmount 'Loan Amount', a.FormFee 'Form Fee', a.LoanDuration 'Duration',a.InterestRate 'Interest Rate',a.InterestAmount 'Interest Amt.',a.TotalRepayment 'Repayment',a.MonthlyRepayment 'Monthly',a.ApprovalStatus 'Approval', " +
                            "l.AmountPaid 'Amount Paid', l.OutStandingAmount 'Outstanding Amt.', l.PaymentStatus 'Payment Status', a.TransactionID 'Transact ID',a.DatePosted 'Date Posted' " +
                            "from LoanApplication a left join Members m on a.MemberID = m.MemberID " +
                            "left join Loans l on a.LoanApplicationID=l.LoanApplicationID " +
                            "left join MonthByName mon on a.AppMonth = mon.MonthID " +
                            "left join LoanCategory lc on a.LoanCategoryID = lc.LoanCategoryID " +
                            "left join LoanType lt on a.LoanTypeID = lt.LoanTypeID " + strFilter +
                            "where a.ApprovalStatus='Yes' " +
                            "order by LoanApplicationID desc ";
                        break;
                }


            }
            else
            {
                switch (strFilter)
                {
                    case "":
                        strQuery = "Select a.LoanApplicationID, mon.Month 'Month',a.AppYear 'Year',m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                           "lc.Name 'Category', lt.Type, a.LoanAmount 'Loan Amount', a.FormFee 'Form Fee', a.LoanDuration 'Duration',a.InterestRate 'Interest Rate',a.InterestAmount 'Interest Amt.',a.TotalRepayment 'Repayment',a.MonthlyRepayment 'Monthly',a.ApprovalStatus 'Approval', " +
                           "l.AmountPaid 'Amount Paid', l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status', a.TransactionID 'Transact ID',a.DatePosted 'Date Posted' " +
                           "from LoanApplication a left join Members m on a.MemberID = m.MemberID " +
                           "left join Loans l on a.LoanApplicationID=l.LoanApplicationID " +
                           "left join MonthByName mon on a.AppMonth = mon.MonthID " +
                           "left join LoanCategory lc on a.LoanCategoryID = lc.LoanCategoryID " +
                           "left join LoanType lt on a.LoanTypeID = lt.LoanTypeID " +
                           "order by LoanApplicationID desc ";
                        break;
                    default:
                        strQuery = "Select a.LoanApplicationID, mon.Month 'Month',a.AppYear 'Year',m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                            "lc.Name 'Category', lt.Type, a.LoanAmount 'Loan Amount', a.FormFee 'Form Fee', a.LoanDuration 'Duration',a.InterestRate 'Interest Rate',a.InterestAmount 'Interest Amt.',a.TotalRepayment 'Repayment',a.MonthlyRepayment 'Monthly',a.ApprovalStatus 'Approval', " +
                            "l.AmountPaid 'Amount Paid', l.OutStandingAmount 'Outstanding Amt.', l.PaymentStatus 'Payment Status', a.TransactionID 'Transact ID',a.DatePosted 'Date Posted' " +
                            "from LoanApplication a left join Members m on a.MemberID = m.MemberID " +
                            "left join Loans l on a.LoanApplicationID=l.LoanApplicationID " +
                            "left join MonthByName mon on a.AppMonth = mon.MonthID " +
                            "left join LoanCategory lc on a.LoanCategoryID = lc.LoanCategoryID " +
                            "left join LoanType lt on a.LoanTypeID = lt.LoanTypeID " + strFilter +
                            "order by LoanApplicationID desc ";
                        break;

                }


            }
            
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            //MessageBox.Show(strQuery);

            try
            {
                conn.Open();
                da.Fill(ds, "LoanApplication");
                dt = ds.Tables["LoanApplication"];
                datGrdVwLoanApplications.DataSource = dt;

                datGrdVwLoanApplications.Columns["LoanApplicationID"].Visible = false;

                datGrdVwLoanApplications.Columns["Full Name"].Width = 200;

                datGrdVwLoanApplications.Columns["Year"].Width = 60;

                datGrdVwLoanApplications.Columns["Approval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                datGrdVwLoanApplications.Columns["Loan Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Loan Amount"].DefaultCellStyle.Format = "N2";

                datGrdVwLoanApplications.Columns["Form Fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Form Fee"].DefaultCellStyle.Format = "N2";

                datGrdVwLoanApplications.Columns["Interest Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                datGrdVwLoanApplications.Columns["Duration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                datGrdVwLoanApplications.Columns["Interest Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Interest Amt."].DefaultCellStyle.Format = "N2";

                datGrdVwLoanApplications.Columns["Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Repayment"].DefaultCellStyle.Format = "N2";

                datGrdVwLoanApplications.Columns["Monthly"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Monthly"].DefaultCellStyle.Format = "N2";

                datGrdVwLoanApplications.Columns["Amount Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Amount Paid"].DefaultCellStyle.Format = "N2";

                datGrdVwLoanApplications.Columns["Outstanding Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoanApplications.Columns["Outstanding Amt."].DefaultCellStyle.Format = "N2";



                lblRecordNo.Text = "No. of Records : " + dt.Rows.Count.ToString();


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

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            if (txtFileNo.Text != string.Empty)
            {
                strFilter = " where m.FileNo='" + txtFileNo.Text + "' ";
            }
            else
            {
                strFilter = string.Empty;
            }

            loadLoanApplications();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex != 0)
            {
                strFilter = " where a.AppMonth=" + cboMonth.SelectedIndex + " ";
            }
            else
            {
                strFilter = string.Empty;
            }

            loadLoanApplications();

        }

        private void datGrdVwLoanApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datGrdVwLoanApplications.SelectedRows.Count > 0)
            {
                lblAmountPaid.Text = string.Empty;
                lblOutstandingAmt.Text = string.Empty;
                lblRepaymentStatus.Text = string.Empty;

                //MessageBox.Show(e.ColumnIndex.ToString());
                string amountPaid = datGrdVwLoanApplications.SelectedRows[0].Cells[14].Value.ToString();
                string outstanding = datGrdVwLoanApplications.SelectedRows[0].Cells[15].Value.ToString();
                string repaymentStatus = datGrdVwLoanApplications.SelectedRows[0].Cells[16].Value.ToString();
                //MessageBox.Show(amountPaid.ToString());
                if (amountPaid != string.Empty)
                {
                    lblAmountPaid.Text = CheckForNumber.formatCurrency2(amountPaid);
                }
                if (outstanding != string.Empty)
                {
                    lblOutstandingAmt.Text = CheckForNumber.formatCurrency2(outstanding);
                }
                lblRepaymentStatus.Text = repaymentStatus;

                if (amountPaid == string.Empty || outstanding == string.Empty)
                {
                    btnViewDetails.Enabled = false;
                }
                else
                {
                    btnViewDetails.Enabled = true;
                }


            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex != 0)
            {
                strFilter = " where a.AppYear=" + cboYear.Text + " ";
            }
            else
            {
                strFilter = string.Empty;
            }
            loadLoanApplications();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex != 0)
            {
                strFilter = " where a.LoanCategoryID=" + cboCategory.SelectedValue + " ";
            }
            else
            {
                strFilter = string.Empty;
            }
            loadLoanApplications();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex != 0)
            {
                strFilter = " where a.LoanTypeID=" + cboType.SelectedValue + " ";
            }
            else
            {
                strFilter = string.Empty;
            }
            loadLoanApplications();
        }

        private void cboApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboApproval.SelectedIndex != 0 && cboApproval.SelectedIndex != 3)
            {
                strFilter = " where a.ApprovalStatus='" + cboApproval.Text + "' "; 
            }
            else if (cboApproval.SelectedIndex == 3)
            {
                strFilter = " where a.ApprovalStatus is NULL ";
            }
            else if (cboApproval.SelectedIndex == 0)
            {
                strFilter = string.Empty;
            }
            loadLoanApplications();
        }

        private void cboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPayment.SelectedIndex != 0)
            {
                strFilter = " where l.PaymentStatus='" + cboPayment.Text + "' ";
            }
            else
            {
                strFilter = string.Empty;
            }
            loadLoanApplications();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            strFilter = string.Empty;

            #region constructing filter
            if (txtFileNo.Text != string.Empty)
            {
                strFilter = " m.FileNo='" + txtFileNo.Text + "' ";
            }

            if (cboMonth.Text != string.Empty)
            {
                if (strFilter != string.Empty)
                {
                    strFilter += " AND a.AppMonth=" + cboMonth.SelectedIndex + " ";
                }
                else
                {
                    strFilter += " a.AppMonth=" + cboMonth.SelectedIndex + " ";
                }
            }


            if (cboYear.Text != string.Empty)
            {
                if (strFilter != string.Empty)
                {
                   strFilter += " AND a.AppYear=" + cboYear.Text + " ";
                }
                else
                {
                    strFilter += " a.AppYear=" + cboYear.Text + " ";
                }
            }

            if (cboCategory.Text != string.Empty)
            {
                if (strFilter != string.Empty)
                {
                    strFilter += " AND a.LoanCategoryID=" + cboCategory.SelectedValue + " ";
                }
                else
                {
                    strFilter += "a.LoanCategoryID=" + cboCategory.SelectedValue + " ";
                }
            }


            if (cboType.Text != string.Empty)
            {
                if (strFilter != string.Empty)
                {
                    strFilter += " AND a.LoanTypeID=" + cboType.SelectedValue + " ";
                }
                else
                {
                    strFilter += " a.LoanTypeID=" + cboType.SelectedValue + " ";
                }
            }

            if (cboPayment.Text != string.Empty)
            {
                if (strFilter != string.Empty)
                {
                   strFilter += " AND l.PaymentStatus='" + cboPayment.Text + "' ";
                }
                else
                {
                    strFilter += " l.PaymentStatus='" + cboPayment.Text + "' ";
                }
            }

            if (cboApproval.Text != string.Empty)
            {
                if (strFilter != string.Empty)
                {
                    if (cboApproval.SelectedIndex == 1 || cboApproval.SelectedIndex == 2)
                    {
                        strFilter += "AND a.ApprovalStatus='" + cboApproval.Text + "' "; 
                    }
                    else
                    {
                        strFilter += " AND a.ApprovalStatus is NULL ";
                    }
                }
                else
                {
                    if (cboApproval.SelectedIndex == 1 || cboApproval.SelectedIndex == 2)
                    {
                        strFilter += " a.ApprovalStatus='" + cboApproval.Text + "' ";
                    }
                    else
                    {
                        strFilter += " a.ApprovalStatus is NULL ";
                    }
                }
            }

            #endregion

            if (strFilter != string.Empty)
            {
                strFilter = "where " + strFilter;
            }

            loadLoanApplications();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            string loanApproval = string.Empty;
            ViewLoanApplication viewLoanApplication = new ViewLoanApplication(loanApproval);
            viewLoanApplication.MdiParent = this.ParentForm;
            viewLoanApplication.Show();

            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Columns.Count > 0)
                {
                    ExportData newExport = new ExportData();
                    newExport.ExportToExcel(dt, saveFD);
                }
                else
                {
                    MessageBox.Show("There is no record to save", "View Loans", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (datGrdVwLoanApplications.SelectedRows.Count > 0)
            {
                string loanID = datGrdVwLoanApplications.SelectedRows[0].Cells[0].Value.ToString();
                ViewLoanDetails viewLoanDetails = new ViewLoanDetails(loanID);
                viewLoanDetails.MdiParent = this.ParentForm;
                viewLoanDetails.Show();
            }
            else
            {
                MessageBox.Show("Select a record to View Details","View Loan",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }

                    
    }
}
