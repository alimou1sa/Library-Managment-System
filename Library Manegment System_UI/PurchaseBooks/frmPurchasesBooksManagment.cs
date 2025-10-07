using Library_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace Library_Manegment_System
{
    public partial class frmPurchasesBooksManagment : Form
    {
        public frmPurchasesBooksManagment()
        {
            InitializeComponent();
        }
        DataTable _dtPurchasesBooks = clsPurchasesBooks.GetListPurchasesBooks();

        private void _RefreshReservationsList()
        {
            _dtPurchasesBooks = clsPurchasesBooks.GetListPurchasesBooks();
            dgvListPurchasesBooks.DataSource = _dtPurchasesBooks;
            lblRecordsCount.Text = dgvListPurchasesBooks.Rows.Count.ToString();
        }

        private void frmPurchasesBooksManagment_Load(object sender, EventArgs e)
        {
            _RefreshReservationsList();
            dgvListPurchasesBooks.DataSource = _dtPurchasesBooks;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListPurchasesBooks.Rows.Count.ToString();
            dgvListPurchasesBooks.ColumnHeadersHeight = 70;

            if (dgvListPurchasesBooks.Rows.Count > 0)
            {

                dgvListPurchasesBooks.Columns[4].HeaderText = "CategoryName";
                dgvListPurchasesBooks.Columns[4].Width = 120;
                dgvListPurchasesBooks.Columns[6].HeaderText = "Full Name";
                dgvListPurchasesBooks.Columns[6].Width = 140;
                dgvListPurchasesBooks.Columns[7].HeaderText = "Library Card Number";
                dgvListPurchasesBooks.Columns[7].Width = 155;
                dgvListPurchasesBooks.Columns[8].HeaderText = "Copies Purchased";
                dgvListPurchasesBooks.Columns[8].Width = 130;
                dgvListPurchasesBooks.Columns[9].HeaderText = "Total Price";
                dgvListPurchasesBooks.Columns[9].Width = 130;
                dgvListPurchasesBooks.Columns[10].HeaderText = "Purchase Date";
                dgvListPurchasesBooks.Columns[10].Width = 130;
                dgvListPurchasesBooks.Columns[11].HeaderText = "Create By UserID";
                dgvListPurchasesBooks.Columns[11].Width = 130;
            }

        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
          

            switch (cbFiterBy.Text)
            {
                case "PurchaseID":
                    FilterColumn = "PurchaseID";
                    break;
                case "BookID":
                    FilterColumn = "BookID";
                    break;
                case "MemberID":
                    FilterColumn = "MemberID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                case "ISBN":
                    FilterColumn = "ISBN";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Library Card Number":
                    FilterColumn = "LibraryCardNumber";
                    break;
                case "Total Price":
                    FilterColumn = "TotalPrice";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPurchasesBooks.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListPurchasesBooks.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PurchaseID" || FilterColumn == "BookID" || FilterColumn == "MemberID" || FilterColumn == "TotalPrice")


                _dtPurchasesBooks.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _dtPurchasesBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListPurchasesBooks .Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {


                txtFiter.Visible = (cbFiterBy.Text != "None");


                if (cbFiterBy.Text == "None")
                {
                    txtFiter.Enabled = false;
                }
                else
                    txtFiter.Enabled = true;

                txtFiter.Text = "";
                txtFiter.Focus();
            
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            frmPurchasesBook frmPurchases =new frmPurchasesBook();
            frmPurchases.ShowDialog();
            _RefreshReservationsList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasesBook frmPurchases = new frmPurchasesBook( (int)dgvListPurchasesBooks.CurrentRow.Cells[0].Value);
            frmPurchases.ShowDialog();
            _RefreshReservationsList();

        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "PurchaseID" || cbFiterBy.Text == "BookID" || cbFiterBy.Text == "MemberID" || cbFiterBy.Text == "TotalPrice")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PurchasesID = (int)dgvListPurchasesBooks .CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do want to delete this Purchases?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (clsPurchasesBooks.IsPurchasesBooksExisteByID(PurchasesID))
            {

                if (clsPurchasesBooks.DeletePurchasesBooks(PurchasesID))
                {

                    MessageBox.Show("Purchases Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPurchasesBooksManagment_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete Purchases, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void purchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasesBookDetails frmPurchasesBook=new frmPurchasesBookDetails((int)dgvListPurchasesBooks.CurrentRow.Cells[0].Value);
            frmPurchasesBook.ShowDialog();
        }
    }
}
