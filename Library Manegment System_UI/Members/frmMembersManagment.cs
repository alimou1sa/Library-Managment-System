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

namespace Library_Manegment_System
{
    public partial class frmMembersManagment : Form
    {
        public frmMembersManagment()
        {
            InitializeComponent();
        }
        DataTable _DTMember;// = clsMembers.GetListMembers();

        private async void _RefreshMemberList()
        {
            _DTMember =await  clsMembers.GetListMembers();
            dgvListMembers.DataSource = _DTMember;
            lblRecordsCount.Text = dgvListMembers .Rows.Count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMembersManagment_Load(object sender, EventArgs e)
        {
            _RefreshMemberList();
            dgvListMembers .DataSource = _DTMember;
            cbFiterBy .SelectedIndex = 0;
            lblRecordsCount.Text = dgvListMembers.Rows.Count.ToString();
            dgvListMembers .ColumnHeadersHeight = 60;


            if (dgvListMembers.Rows.Count > 0)
            {
                dgvListMembers.Columns[3].HeaderText = "Library Card Number";
                dgvListMembers.Columns[3].Width = 145;
                dgvListMembers.Columns[4].HeaderText = "National No";
                dgvListMembers.Columns[4].Width = 120;
                dgvListMembers.Columns[5].HeaderText = "Full Name";
                dgvListMembers.Columns[5].Width = 130;
                dgvListMembers.Columns[6].HeaderText = "Plan Name";
                dgvListMembers.Columns[6].Width = 120;
                dgvListMembers.Columns[8].HeaderText = "Start Date";
                dgvListMembers.Columns[8].Width = 130;
                dgvListMembers.Columns[9].HeaderText = "End Date";
                dgvListMembers.Columns[9].Width = 130;
                dgvListMembers.Columns[10].HeaderText = "Subscription Status";
                dgvListMembers.Columns[10].Width = 135;
                dgvListMembers.Columns[11].HeaderText = "Created By UserID";
                dgvListMembers.Columns[11].Width = 130;



            }




        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";


            switch (cbFiterBy.Text)
            {
                case "MemberID":
                    FilterColumn = "MemberID";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
                case "SubscriptionID":
                    FilterColumn = "SubscriptionID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Library Card Number":
                    FilterColumn = "LibraryCardNumber";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _DTMember.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListMembers .Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "MemberID"|| FilterColumn == "SubscriptionID")

                _DTMember .DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _DTMember .DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListMembers.Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy .Text == "Is Active")
            {
                cbSubscriptionStatus.Visible = false;
                txtFiter .Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;

                return;
            }
            if  (cbFiterBy.Text == "Subscription Status")
            {
                cbIsActive.Visible = false;
                txtFiter.Visible = false;
                    cbSubscriptionStatus.Visible = true;
                    cbSubscriptionStatus.Focus();
                    cbSubscriptionStatus.SelectedIndex = 0;
                
                return ;
            }
            else
            {

                txtFiter.Visible = (cbFiterBy.Text != "None");
                cbIsActive.Visible = false;
                cbSubscriptionStatus.Visible = false;
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
                _DTMember.DefaultView.RowFilter = "";
            else
                _DTMember.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _DTMember.Rows.Count.ToString();

        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "SubscriptionStatus";
            string FilterValue = cbSubscriptionStatus .Text;


            switch (FilterValue)
            {
                case "All":
                    break;
                case "Active":
                    FilterValue = "Active";
                    break;
                case "Expired":
                    FilterValue = "Expired";
                    break;
                case "Pending":
                    FilterValue = "Pending";
                    break;
            }


            if (FilterValue == "All")
                _DTMember.DefaultView.RowFilter = "";
            else
                _DTMember.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _DTMember.Rows.Count.ToString();
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy .Text == "MemberID"|| cbFiterBy.Text == "SubscriptionID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            frmAddUpdateMembers frm = new frmAddUpdateMembers();
            frm.ShowDialog();
            _RefreshMemberList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateMembers frm = new frmAddUpdateMembers((int)dgvListMembers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshMemberList();
        }

        private void memberDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails((int)dgvListMembers.CurrentRow.Cells[0].Value);
            frmMemberDetails.ShowDialog();
        }

        private void btnPeopleManagment_Click(object sender, EventArgs e)
        {
            frmPeopleManrgment frm=new frmPeopleManrgment();
            frm.ShowDialog();
        }

        private async void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete MemberID [" + dgvListMembers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                clsMembers members = clsMembers.FindByID((int)dgvListMembers.CurrentRow.Cells[0].Value);
                if (members != null)
                {

                    if (await  members.DeleteMembers())
                    {
                        MessageBox.Show("MemberID Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshMemberList();
                    }
                }
                else
                    MessageBox.Show("MemberID was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async void borrowBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (await  clsMemberSubscriptions.IsMembersHasActiveSubscription((int)dgvListMembers.CurrentRow.Cells[0].Value))
            {
                frmLoanBook frm = new frmLoanBook(-1, (int)dgvListMembers.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            }

        }

        private void memberSubscriptionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubscriptionInfo subscriptionInfo=new frmSubscriptionInfo((int)dgvListMembers.CurrentRow.Cells[0].Value);
            subscriptionInfo.ShowDialog();
        }

        private void showListSubscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageSubscriptionForthisMember frmManageSubscriptionForthisMember = new frmManageSubscriptionForthisMember((int)dgvListMembers.CurrentRow.Cells[0].Value);
            frmManageSubscriptionForthisMember.ShowDialog();
            _RefreshMemberList();
        }

        private void renewSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateSubscriptions frmAdd_UpdateSubscriptions = new frmAdd_UpdateSubscriptions((int)dgvListMembers.CurrentRow.Cells[0].Value);
            frmAdd_UpdateSubscriptions.ShowDialog();
            _RefreshMemberList();
        }
    }
}
