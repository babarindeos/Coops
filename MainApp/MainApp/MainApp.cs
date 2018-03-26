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
    public partial class MainApp : Form
    {
        private string userId;
        private string lastname;
        private string firstname;

        private string loanApproval;

        public MainApp(string UserID, string Lastname, string Firstname)
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            userId = UserID;
            lastname = Lastname;
            firstname = Firstname;

            loanApproval = string.Empty;

            string ActivityType = "LogIn";
            string Description = Lastname + " " + Firstname + " with UserID [" + userId + "] logged In";
            logUserActivity(userId,ActivityType,Description);
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMember addMemberForm = new AddMember();
            addMemberForm.MdiParent = this;
            addMemberForm.Show();
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.MdiParent = this;
            addDepartment.Show();
        }

        private void viewDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDepartments viewDept = new ViewDepartments();
            viewDept.MdiParent = this;
            viewDept.Show();
        }

        private void editDepartmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDepartment editDept = new EditDepartment();
            editDept.MdiParent = this;
            editDept.Show();


        }

        private void deleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDepartment delDept = new DeleteDepartment();
            delDept.MdiParent = this;
            delDept.Show();
        }

        private void addBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBank addBank = new AddBank();
            addBank.MdiParent = this;
            addBank.Show();
        }

        private void viewBanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBanks viewBanks = new ViewBanks();
            viewBanks.MdiParent = this;
                viewBanks.Show();
        }

        private void editBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBank editBank = new EditBank();
            editBank.MdiParent = this;
            editBank.Show();
        }

        private void deleteBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBank deleteBank = new DeleteBank();
            deleteBank.MdiParent = this;
            deleteBank.Show();
        }

        private void addTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateSavingsType createSavingsType = new CreateSavingsType();
            createSavingsType.MdiParent = this;
            createSavingsType.Show();
        }

        private void editTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditSavingsType editSavingsType = new EditSavingsType();
            editSavingsType.MdiParent = this;
            editSavingsType.Show();
        }

        private void memberListToolStripMenuItem_Click(object sender, EventArgs e)
        {
             MembersList membersList = new MembersList();
             membersList.MdiParent = this;
             membersList.Show();
        }

        private void findMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindMember findMember = new FindMember();
            findMember.MdiParent = this;
            findMember.Show();
        }

        private void editMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMember editMember = new EditMember();
            editMember.MdiParent = this;
            editMember.Show();
        }

        private void setupSavingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUpMemberSavingsAccount setUpMemberSavingsAccount = new SetUpMemberSavingsAccount();
            setUpMemberSavingsAccount.MdiParent = this;
            setUpMemberSavingsAccount.Show();

        }

        private void editSavingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMemberSavings editMemberSavings = new EditMemberSavings();
            editMemberSavings.MdiParent = this;
            editMemberSavings.Show();
        }

        private void makeContributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeContributions makeContributions = new MakeContributions();
            makeContributions.MdiParent = this;
            makeContributions.Show();
        }

        private void viewContributionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewContributions viewContributions = new ViewContributions();
            viewContributions.MdiParent = this;
            viewContributions.Show();
        }

        private void editContributionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContributions editContributions = new EditContributions();
            editContributions.MdiParent = this;
            editContributions.Show();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateLoanCategory createLoanCategory = new CreateLoanCategory();
            createLoanCategory.MdiParent = this;
            createLoanCategory.Show();
            


        }

        private void addTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateLoanType createLoanType = new CreateLoanType();
            createLoanType.MdiParent = this;
            createLoanType.Show();
        }

        private void newApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoanApplication loanApplication = new LoanApplication(userId);
            loanApplication.MdiParent = this;
            loanApplication.Show();
        }

        private void loansApprovalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoanApplicationApproval loanApplicationApproval = new LoanApplicationApproval();
            loanApplicationApproval.MdiParent = this;
            loanApplicationApproval.Show();
        }

        private void postRepaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostLoanRepayment postLoanRepayment = new PostLoanRepayment();
            postLoanRepayment.MdiParent = this;
            postLoanRepayment.Show();
        }

        private void postDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void collectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostDeductions postDeductions = new PostDeductions(userId);
            postDeductions.MdiParent = this;
            postDeductions.Show();
        }

        private void individualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostDeduction_Individual postIndividualDeduction = new PostDeduction_Individual(userId);
            postIndividualDeduction.MdiParent = this;
            postIndividualDeduction.Show();
        }

        private void viewSavingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSavings viewSavings = new ViewSavings();
            viewSavings.MdiParent = this;
            viewSavings.Show();
        }

        private void membersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportMembers frmReportMembers = new FrmReportMembers();
            frmReportMembers.MdiParent = this;
            frmReportMembers.Show();


        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            //((MainApp)this.MdiParent).toolStripStatusLoggedInUser.Text = "Seyibabs";
            lblLoggedInUserID.Text = userId;
            lblLoggedInUserName.Text = lastname.ToString().ToUpper() + ' ' + firstname.ToString();

            //toolStripStatusOps.Text = "Progress...";
            //statusStrip1.Refresh();

            toolStripStatusLblSpring.Text = string.Empty;

            toolStripStatusLblLoggedInUser.Text = "Logged In User: " + lblLoggedInUserName.Text;

            
        }

        private void memberProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenerateMemberProfileByFileNo frmGenerateMemberProfileByFileNo = new FrmGenerateMemberProfileByFileNo();
            frmGenerateMemberProfileByFileNo.MdiParent = this;
            frmGenerateMemberProfileByFileNo.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really wish to Exit Application?", "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void logUserActivity(string userId, string ActivityType,string Description)
        {
            ActivityLog.logActivity(userId, ActivityType, Description);
        }

        private void viewDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string month = string.Empty;
            string year = string.Empty;

            ViewDeductions viewductions = new ViewDeductions(month,year);
            viewductions.MdiParent = this;
            viewductions.Show();
        }

        private void withdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MembershipWithdrawal withdrawal = new MembershipWithdrawal();
            withdrawal.MdiParent = this;
            withdrawal.Show();
        }

        private void savingsForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingsForward savingsForward = new SavingsForward(userId);
            savingsForward.MdiParent = this;
            savingsForward.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSavingsForward editSavingsForward = new EditSavingsForward(userId);
            editSavingsForward.MdiParent = this;
            editSavingsForward.Show();
        }
        
        private void toolStripButtonNewMember_Click(object sender, EventArgs e)
        {
            registrationToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonMembers_Click(object sender, EventArgs e)
        {
            findMemberToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonFindMember_Click(object sender, EventArgs e)
        {
            findMemberToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonEditMember_Click(object sender, EventArgs e)
        {
            editMemberToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSavings_Click(object sender, EventArgs e)
        {
            viewSavingsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonEditSavings_Click(object sender, EventArgs e)
        {
            editSavingsToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteSavingsForward deleteSavingsForward = new DeleteSavingsForward();
            deleteSavingsForward.MdiParent = this;
            deleteSavingsForward.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLoanApplication deleteLoanApplication = new DeleteLoanApplication();
            deleteLoanApplication.MdiParent = this;
            deleteLoanApplication.Show();
        }

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void makeWithdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeWithdrawal makewithdrawal = new MakeWithdrawal(userId);
            makewithdrawal.MdiParent = this;
            makewithdrawal.Show();
        }

        private void deleteWithdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWithdrawal deleteWithdrawal = new DeleteWithdrawal(userId);
            deleteWithdrawal.MdiParent = this;
            deleteWithdrawal.Show();

        }

        private void newLoanBFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLoanBroughtForward newLoanBroughtForward = new NewLoanBroughtForward(userId);
            newLoanBroughtForward.MdiParent = this;
            newLoanBroughtForward.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditLoansBroughtForward editLoansBroughtForward = new EditLoansBroughtForward(userId);
            editLoansBroughtForward.MdiParent = this;
            editLoansBroughtForward.Show();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteLoanBroughtForward deleteLoanBroughtForward = new DeleteLoanBroughtForward(userId);
            deleteLoanBroughtForward.MdiParent = this;
            deleteLoanBroughtForward.Show();
        }

       
        private void viewLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loanApproval = "Yes";
            ViewLoanApplication viewLoanApplication = new ViewLoanApplication(loanApproval);
            viewLoanApplication.MdiParent = this;
            viewLoanApplication.Show();
        }

        private void viewApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLoanApplication viewApplicationLoan = new ViewLoanApplication(loanApproval);
            viewApplicationLoan.MdiParent = this;
            viewApplicationLoan.Show();
        }

        private void deleteDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnpostDeductions unpostDeductions = new UnpostDeductions(userId);
            unpostDeductions.MdiParent = this;
            unpostDeductions.Show();
        }

        private void memberSavingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRprtMemberSavings frmRprtMemberSavings = new FrmRprtMemberSavings();
            frmRprtMemberSavings.MdiParent = this;
            frmRprtMemberSavings.Show();
        }

       

        
    }
}
