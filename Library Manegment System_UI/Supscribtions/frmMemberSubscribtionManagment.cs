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
using static Library_Business.clsMemberSubscriptions;

namespace Library_Manegment_System
{
    public partial class frmMemberSubscribtionManagment : Form
    {
        public frmMemberSubscribtionManagment()
        {
            InitializeComponent();
        }
        DataTable _DTSubscriptions;// = clsMemberSubscriptions.GetListMemberSubscriptions();

        private void _RefreshSubscriptionsList()
        {
           // _DTSubscriptions = clsMemberSubscriptions.GetListMemberSubscriptions();
            dgvListSubscriptions.DataSource = _DTSubscriptions;
            lblRecordsCount.Text = dgvListSubscriptions.Rows.Count.ToString();
        }

        private void frmMemberSubscribtionManagment_Load(object sender, EventArgs e)
        {
            _RefreshSubscriptionsList();
            dgvListSubscriptions.DataSource = _DTSubscriptions;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListSubscriptions.Rows.Count.ToString();
            dgvListSubscriptions.ColumnHeadersHeight = 70;


            if (dgvListSubscriptions.Rows.Count > 0)
            {
                dgvListSubscriptions.Columns[0].Width = 100;
                dgvListSubscriptions.Columns[1].Width = 90;
                dgvListSubscriptions.Columns[2].Width = 90;
                dgvListSubscriptions.Columns[3].HeaderText = "Start Date";
                dgvListSubscriptions.Columns[3].Width = 130;
                dgvListSubscriptions.Columns[4].HeaderText = "End Date";
                dgvListSubscriptions.Columns[4].Width = 130;
                dgvListSubscriptions.Columns[5].HeaderText = "Is Active";
                dgvListSubscriptions.Columns[6].HeaderText = "Subscription Status";
                dgvListSubscriptions.Columns[6].Width = 155;
                dgvListSubscriptions.Columns[7].HeaderText = "Created By UserID";
                dgvListSubscriptions.Columns[7].Width = 155;
                dgvListSubscriptions.Columns[8].HeaderText = "Library Card Number";
                dgvListSubscriptions.Columns[8].Width = 165;
                dgvListSubscriptions.Columns[9].HeaderText = "Plan Name";
                dgvListSubscriptions.Columns[9].Width = 165;
            }
        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFiterBy.Text)
            {
                case "SubscriptionID":
                    FilterColumn = "SubscriptionID";
                    break;
                case "MemberID":
                    FilterColumn = "MemberID";
                    break;
                case "Plan Name":
                    FilterColumn = "PlanName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _DTSubscriptions.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListSubscriptions.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "SubscriptionID" || FilterColumn == "MemberID" )


                _DTSubscriptions.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _DTSubscriptions.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListSubscriptions.Rows.Count.ToString();
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
                _DTSubscriptions.DefaultView.RowFilter = "";
            else
                _DTSubscriptions.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _DTSubscriptions.Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFiterBy.Text == "Is Active")
            {
                cbSubscriptionStatus.Visible = false;
                txtFiter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;

                return;
            }
            if (cbFiterBy.Text == "Subscription Status")
            {
                cbIsActive.Visible = false;
                txtFiter.Visible = false;
                cbSubscriptionStatus.Visible = true;
                cbSubscriptionStatus.Focus();
                cbSubscriptionStatus.SelectedIndex = 0;

                return;
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
            _DTSubscriptions.DefaultView.RowFilter = "";
        }

        private void cbSubscriptionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "SubscriptionStatus";
            string FilterValue = cbSubscriptionStatus .Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "New":
                    FilterValue = "New";
                    break;
                case "ReNew":
                    FilterValue = "ReNew";
                    break;
                case "Cancel":
                    FilterValue = "Cancel";
                    break;
            }


            if (FilterValue == "All")
                _DTSubscriptions.DefaultView.RowFilter = "";
            else
                _DTSubscriptions.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _DTSubscriptions.Rows.Count.ToString();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
        //    frmAdd_UpdateSubscriptions frmAdd_UpdateSubscriptions =new frmAdd_UpdateSubscriptions();
            
        }
    }
}
