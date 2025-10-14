using Library;
using Library_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegment_System
{
    public partial class frmMain : Form
    {
        Login _frmLogin;
        public frmMain(Login form)
        {
            InitializeComponent();
            _frmLogin = form;
        }
        public static void OpenChildForm(Form childForm, Panel panel)
        {

            try
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panel.Controls.Add(childForm);
                panel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the child form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGlobal.CurrentUser = null;
            if (clsGlobal.CurrentUser == null)
                Application.Exit();
        }

        private void listBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageBooks))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                listBookCopiesToolStripMenuItem.Enabled = false;
                return;

            }
            OpenChildForm(new frmBooksManagment(), panel1);
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageBooks))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                xToolStripMenuItem.Enabled = false;
                return;
            }
        }

        private void listMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageMembers))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }

            OpenChildForm(new frmMembersManagment(), panel1);
        }

        private void usersManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageUsers))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }
            OpenChildForm(new frmUsersManagments(), panel1);
        }

        private void listBookCopiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageUsers))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }
            frmAddUpdateBooks frmAddUpdateBooks=  new frmAddUpdateBooks();

            frmAddUpdateBooks.ShowDialog();
        }

        private void listLosnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageLoan))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }
            OpenChildForm(new frmLoanManagment(), panel1);

        }

        private void listReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageReservation))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }
            OpenChildForm(new frmReservationsManagments(), panel1);
        }

        private void listPurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManagePurchasesBook))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }
            OpenChildForm(new frmPurchasesBooksManagment(), panel1);
        }

        private void listPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManagePayments))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                return;

            }
            OpenChildForm(new frmPaymentManagments(), panel1);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUserName.Text=clsGlobal.CurrentUser.UserName;
            lblTimeNow.Text = DateTime.Now.ToString("yyyy:MM:dd");
            lblJobtitle.Text=clsGlobal.CurrentUser.JobTitle;
        }

        private void crrentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails =new frmUserDetails(clsGlobal.CurrentUser.UserID);
            frmUserDetails.ShowDialog();
        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            Login log = new Login();

            this.Hide();
            this.Close();
            log.ShowDialog();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassowrd frmChangePassowrd=new frmChangePassowrd(clsGlobal.CurrentUser.UserID);
            frmChangePassowrd.ShowDialog();
        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateMembers frmAddUpdateMembers = new frmAddUpdateMembers();
            frmAddUpdateMembers.ShowDialog();
        }

        private void listMemberSubscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new frmMemberSubscribtionManagment(), panel1);
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting setting = new frmSetting();
            setting.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void findBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindBook frmFindBook = new frmFindBook();
            frmFindBook.ShowDialog();
        }

        private void lblJobtitle_Click(object sender, EventArgs e)
        {

        }

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManagePurchasesBook))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                purchasesToolStripMenuItem.Enabled = false;
                return;
            }
        }

        private async void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
        
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageMembers))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                membersToolStripMenuItem.Enabled = false;
                return;
            }
         
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageUsers))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                usersToolStripMenuItem.Enabled = false;
                return;
            }
        }

        private void loanBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageLoan))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                loanBooksToolStripMenuItem.Enabled = false;
                return;
            }
        }

        private void resevationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManageReservation))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                resevationsToolStripMenuItem.Enabled = false;
                
                return;
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUsers.enPermissions.ManagePayments))
            {
                MessageBox.Show(" Access Denied! Contact your Admin..");
                paymentsToolStripMenuItem.Enabled = false;
            
                return;
            }
        }
    }
}
