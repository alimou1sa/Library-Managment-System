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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Library_Manegment_System
{
    public partial class frmPaymentManagments : Form
    {
        public frmPaymentManagments()
        {
            InitializeComponent();
        }

        DataTable _dtPayments;//= clsPaymentDetails.GetListPaymentDetails();

        private async Task  _RefreshPaymentsList()
        {
            _dtPayments = await  clsPaymentDetails.GetListPaymentDetails();
            dgvListPayments.DataSource = _dtPayments;
            lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();
        }

        private async void frmPaymentManagments_Load(object sender, EventArgs e)
        {
           await  _RefreshPaymentsList();
            dgvListPayments.DataSource = _dtPayments;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();
            dgvListPayments.ColumnHeadersHeight = 60;


            if (dgvListPayments.Rows.Count > 0)
            {

                dgvListPayments.Columns[0].HeaderText = "Payment DetailID";
                dgvListPayments.Columns[0].Width = 150;
                dgvListPayments.Columns[1].HeaderText = "Payments ID";
                dgvListPayments.Columns[1].Width = 130;
                dgvListPayments.Columns[2].HeaderText = "Entity Name";
                dgvListPayments.Columns[2].Width = 130;
                dgvListPayments.Columns[3].HeaderText = "Entity ID";
                dgvListPayments.Columns[3].Width = 100;
                dgvListPayments.Columns[4].HeaderText = "Payments Type";
                dgvListPayments.Columns[4].Width = 140;
                dgvListPayments.Columns[7].HeaderText = "Payment Status";
                dgvListPayments.Columns[7].Width = 140;
                dgvListPayments.Columns[8].HeaderText = "Create By UserID";
                dgvListPayments.Columns[8].Width = 140;
                dgvListPayments.Columns[9].HeaderText = "Payment Date";
                dgvListPayments.Columns[9].Width = 140;


            }

        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        { 

                    string FilterColumn = "";


            switch (cbFiterBy.Text)
            {
                case "Payment DetailID":
                    FilterColumn = "PaymentDetailID";
                    break;
                case "MemberID":
                    FilterColumn = "MemberID";
                    break;
                case "Amount":
                    FilterColumn = "Amount";
                    break;
                case "Entity Name":
                    FilterColumn = "EntityName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPayments.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PaymentDetailID" || FilterColumn == "Amount" || FilterColumn == "MemberID")

                _dtPayments.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _dtPayments.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();


        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            if (cbFiterBy.Text == "Payment Status")
            {
                cbPaymentStatus.Visible = true;
                txtFiter.Visible = false;
                cbPaymentStatus.Focus();
                cbPaymentStatus.SelectedIndex = 0;

                return;
            }
            else
            {

                txtFiter.Visible = (cbFiterBy.Text != "None");
                cbPaymentStatus.Visible = false;
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

        private void cbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "PaymentStatus";
            string FilterValue = cbPaymentStatus.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Pending":
                    FilterValue = "Pending";
                    break;
                case "Paid":
                    FilterValue = "Paid";
                    break;
                case "Refunded":
                    FilterValue = "Refunded";
                    break;
                case "Cancelled":
                    FilterValue = "Cancelled";
                    break;
            }


            if (FilterValue == "All")
                _dtPayments.DefaultView.RowFilter = "";
            else
                _dtPayments.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _dtPayments.Rows.Count.ToString();
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "PaymentDetailID" || cbFiterBy.Text == "Amount")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure do want to delete this Payments?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int PaymentID = (int)dgvListPayments.CurrentRow.Cells[0].Value;

            clsPaymentDetails paymentDetails =
                clsPaymentDetails.FindByID(PaymentID);

            if (paymentDetails != null)
            {
                if (await  paymentDetails.Delete())
                {
                    MessageBox.Show("Payments Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPaymentManagments_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete Payments, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePayments updatePayments =new frmAddUpdatePayments((int)dgvListPayments.CurrentRow.Cells[0].Value);
            updatePayments.ShowDialog();
           await  _RefreshPaymentsList();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {

        }
    }
}
