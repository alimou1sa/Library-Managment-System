using Library_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library_Manegment_System.frmAddUpdatePersons;
using System.Xml.Linq;

namespace Library_Manegment_System
{
    public partial class frmUsersManagments : Form
    {
        public frmUsersManagments()
        {
            InitializeComponent();
        }
        DataTable _dtUsers;//= clsUsers.GetAllUsers();

        private async Task  _RefreshUserssList()
        {
            _dtUsers =await  clsUsers.GetAllUsers();
            dgvShowUserList.DataSource = _dtUsers;
            lblRecordsCount.Text = dgvShowUserList.Rows.Count.ToString();
        }

        private async void frmUsersManagments_Load(object sender, EventArgs e)
        {
           await  _RefreshUserssList();
            dgvShowUserList.DataSource = _dtUsers;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvShowUserList.Rows.Count.ToString();
            dgvShowUserList.ColumnHeadersHeight = 70;

            if (dgvShowUserList .Rows.Count > 0)
            {
                dgvShowUserList.Columns[0].Width = 70;
                dgvShowUserList.Columns[1].HeaderText = "User Name";
                dgvShowUserList.Columns[5].HeaderText = "Full Name";
                 dgvShowUserList.Columns[4].HeaderText = "Job Title";
                dgvShowUserList.Columns[9].HeaderText = "Date Of Birth";
                dgvShowUserList.Columns[9].Width = 130;
                dgvShowUserList.Columns[10].HeaderText = "Gendor Caption";
                dgvShowUserList.Columns[10].Width = 130;
                dgvShowUserList.Columns[12].HeaderText = "Country Name";
                dgvShowUserList.Columns[12].Width = 120;
            }

        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFiterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
                case "Job Title":
                    FilterColumn = "JobTitle";
                    break;
                case "Salary":
                    FilterColumn = "Salary";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvShowUserList .Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "UserID"|| FilterColumn == "Salary")

                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvShowUserList.Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.Text == "Is Active")
            {
                cbGender.Visible = false;
                txtFiter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;

                return;
            }
            if (cbFiterBy.Text == "Gendor Caption")
            {
                cbIsActive.Visible = false;
                txtFiter.Visible = false;
                cbGender.Visible = true;
                cbGender.Focus();
                cbGender.SelectedIndex = 0;

                return;
            }
            else
            {

                txtFiter.Visible = (cbFiterBy.Text != "None");
                cbIsActive.Visible = false;
                cbGender.Visible = false;
                if (cbFiterBy.Text == "None")
                {
                    txtFiter.Enabled = false;
                }
                else
                    txtFiter.Enabled = true;

                txtFiter.Text = "";
                txtFiter.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtUsers.Rows.Count.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "GendorCaption";
            string FilterValue = cbGender.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Male":
                    FilterValue = "Male";
                    break;
                case "Female":
                    FilterValue = "Female";
                    break;
            }


            if (FilterValue == "All")
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _dtUsers.Rows.Count.ToString();
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "User ID"||cbFiterBy .Text== "Salary")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void btnPeopleManagment_Click(object sender, EventArgs e)
        {
            frmPeopleManrgment frmAddUpdatePersons = new frmPeopleManrgment();
            frmAddUpdatePersons.ShowDialog();
          await   _RefreshUserssList();
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUser = new frmAddUpdateUser();
            frmAddUser.ShowDialog();
           await  _RefreshUserssList();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUser = new frmAddUpdateUser((int)dgvShowUserList .CurrentRow.Cells[0].Value);
            frmAddUser.ShowDialog();
          await   _RefreshUserssList();
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUser =new frmUserDetails((int)dgvShowUserList.CurrentRow.Cells[0].Value);
            frmUser.ShowDialog();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvShowUserList.CurrentRow.Cells[0].Value;
            clsUsers users = clsUsers.FindByUserID(UserID);
            if (users != null)
            {
                if (await  users.DeleteUser())
                {
                    MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUsersManagments_Load(null, null);
                }
            }
            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private async void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUser = new frmAddUpdateUser();
            frmAddUser.ShowDialog();
          await   _RefreshUserssList();
        }
    }
}
