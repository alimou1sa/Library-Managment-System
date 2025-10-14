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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace Library_Manegment_System
{
    public partial class frmLoanManagment : Form
    {
        public frmLoanManagment()
        {
            InitializeComponent();
        }

        DataTable _DtLoan;

        private async Task  _RefreshLOansList()
        {
            _DtLoan =await  clsLoanes.GetListLoanes();
            dgvListLoan.DataSource = _DtLoan;
            lblRecordsCount.Text = dgvListLoan.Rows.Count.ToString();
        }

        private async void frmLoanManagment_Load(object sender, EventArgs e)
        {
 
           await  _RefreshLOansList();
            dgvListLoan.DataSource = _DtLoan;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListLoan.Rows.Count.ToString();
            dgvListLoan.ColumnHeadersHeight = 70;


            if (dgvListLoan.Rows.Count > 0)
            {
                dgvListLoan.Columns[0].Width = 80;
                dgvListLoan.Columns[1].Width = 80;
                dgvListLoan.Columns[2].Width = 80;
                dgvListLoan.Columns[6].HeaderText = "Is MemberID Active";
                dgvListLoan.Columns[6].Width = 130;
                dgvListLoan.Columns[7].HeaderText = "Library Card Number";
                dgvListLoan.Columns[7].Width = 150;
                dgvListLoan.Columns[8].HeaderText = "Full Name";
                dgvListLoan.Columns[9].HeaderText = "Return By User";
                dgvListLoan.Columns[10].Width = 130;
                dgvListLoan.Columns[10].HeaderText = "Loan Date";
                dgvListLoan.Columns[11].HeaderText = "Due Date";
                dgvListLoan.Columns[12].HeaderText = "Return Date";
                dgvListLoan.Columns[13].HeaderText = "Is Return";

            }

        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";


            switch (cbFiterBy.Text)
            {
                case "Loan ID":
                    FilterColumn = "LoanID";
                    break;
                case "Copy ID":
                    FilterColumn = "CopyID";
                    break;
                case "Book ID":
                    FilterColumn = "BookID";
                    break;
                case "ISBN":
                    FilterColumn = "ISBN";
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
                _DtLoan.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListLoan.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LoanID" || FilterColumn == "CopyID" || FilterColumn == "BookID")


                _DtLoan.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _DtLoan.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListLoan.Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cbFiterBy.Text == "Is Return")
            {
                cbStatus.Visible = true;
                txtFiter.Visible = false;

                return;
            }
            else
            {

                txtFiter.Visible = (cbFiterBy.Text != "None");
                cbStatus.Visible = false;
                if (cbFiterBy.Text == "None")
                {
                    txtFiter.Enabled = false;
                   // _DtLoan.DefaultView.RowFilter = "";
                }
                else
                    txtFiter.Enabled = true;


                //    _DtLoan.DefaultView.RowFilter = "";
                dgvListLoan.DataSource = _DtLoan;
                txtFiter.Text = "";
                lblRecordsCount.Text = dgvListLoan.Rows.Count.ToString();
                txtFiter.Focus();
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReturn";
            string FilterValue = "";
            switch (cbStatus.Text)
            {
                case "All":
                    FilterValue = "All";
                    break;
                case "Yes":
                    FilterValue = "Yes";
                    break;
                case "No":
                    FilterValue = "No";
                    break;



            }
            if (FilterValue == "All")
                _DtLoan.DefaultView.RowFilter = "";
            else
                _DtLoan.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = dgvListLoan.Rows.Count.ToString();
        }

        private async void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoanBook  frmBorrowBook2 = new frmLoanBook((int)dgvListLoan.CurrentRow.Cells[0].Value,false );
            frmBorrowBook2.ShowDialog();
           await  _RefreshLOansList();
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "Loan ID"|| cbFiterBy.Text == "Copy ID" || cbFiterBy.Text == "Book ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (! await  clsLoanes.IsLoanesBorrowedeByLoanID((int)dgvListLoan.CurrentRow.Cells[0].Value))
                returnBookToolStripMenuItem.Enabled = false;
            else
                returnBookToolStripMenuItem.Enabled = true;
        }

        private async void btnPeopleManagment_Click(object sender, EventArgs e)
        {
            frmLoanBook frmBorrowBook2 = new frmLoanBook();
            frmBorrowBook2.ShowDialog();
            await _RefreshLOansList();
        }

        private async void loanDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoanDetails frmLoanDetails =new frmLoanDetails((int)dgvListLoan.CurrentRow.Cells[0].Value);
            frmLoanDetails.ShowDialog();
           await  _RefreshLOansList();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoanID = (int)dgvListLoan .CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do want to delete this Loan?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (await  clsLoanes.IsLoanesExisteByID(LoanID))
            {

                    if (await  clsLoanes.DeleteLoanes(LoanID))
                    {

                     await clsBookCopies.ChangeCopyStatus((int)dgvListLoan.CurrentRow.Cells[1].Value, clsBookCopies.enStatusCopy.Available);

                        MessageBox.Show("Loan Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLoanManagment_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete Loan, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoanBook frmBorrow =new frmLoanBook((int)dgvListLoan.CurrentRow.Cells[0].Value,true);
            frmBorrow.ShowDialog();
            frmLoanManagment_Load(null, null);
        }
    }
 }
