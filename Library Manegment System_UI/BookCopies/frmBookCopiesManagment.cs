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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Manegment_System
{
    public partial class frmBookCopiesManagment : Form
    {

        private static int _BookID;
        public frmBookCopiesManagment(int BooKID)
        {
            InitializeComponent();
            _BookID = BooKID;
        }

        DataTable _dtBookCopies = null; 
        private async void _RefreshBookCopiesList()
        {
            _dtBookCopies = await  clsBookCopies.GetListBookCopies(_BookID);
            dgvListBookCopies.DataSource = _dtBookCopies;
            lblRecordsCount.Text = dgvListBookCopies.Rows.Count.ToString();
        }

        private void frmBookCopiesManagment_Load(object sender, EventArgs e)
        {
            _RefreshBookCopiesList();
            dgvListBookCopies.DataSource = _dtBookCopies;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListBookCopies.Rows.Count.ToString();
            dgvListBookCopies.ColumnHeadersHeight = 70;

            if (dgvListBookCopies.Rows.Count > 0)
            {

                //    dgvShowBooks.Columns[0].Width = 40;

                //    dgvShowBooks.Columns[3].HeaderText = "Genre";
                //    dgvShowBooks.Columns[4].HeaderText = "PublisherName";
                //    dgvShowBooks.Columns[5].HeaderText = "Year Published";
                //    dgvShowBooks.Columns[5].Width = 130;
                //    dgvShowBooks.Columns[6].HeaderText = "Additional Details";
                //    dgvShowBooks.Columns[6].Width = 160;
                //    dgvShowBooks.Columns[7].HeaderText = "Category Name";
                //    dgvShowBooks.Columns[7].Width = 130;
                //    dgvShowBooks.Columns[8].HeaderText = "Author Name";
                //    dgvShowBooks.Columns[8].Width = 130;
                //    dgvShowBooks.Columns[9].HeaderText = "Book Price";
                //    dgvShowBooks.Columns[10].HeaderText = "Total Copies";
                //    dgvShowBooks.Columns[11].HeaderText = "Available Copies";
                //    dgvShowBooks.Columns[11].Width = 130;

            }

        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFiterBy.Text)
            {
                case "Copy ID":
                    FilterColumn = "_CopyID";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }


            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtBookCopies.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListBookCopies.Rows.Count.ToString();
                return;
            }


            if ( FilterColumn == "_CopyID")


                _dtBookCopies.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _dtBookCopies.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListBookCopies.Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cbFiterBy.Text == "Copy Status")
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
               
                }
                else
                    txtFiter.Enabled = true;


                _dtBookCopies.DefaultView.RowFilter = "";
                txtFiter.Text = "";
                lblRecordsCount.Text = dgvListBookCopies.Rows.Count.ToString();
                txtFiter.Focus();
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "CopyStatus";
            string FilterValue = "";
            switch (cbStatus.Text)
            {
                case "All":
                    FilterValue = "All";
                    break;
                  case "Available":
                    FilterValue = "Available";
                      break;
                  case "Damaged":
                    FilterValue = "Damaged";
                      break;
                  case "Lost":
                    FilterValue = "Lost";
                      break;
                  case "Borrowed":
                    FilterValue = "Borrowed";
                      break;
                case "Sold":
                    FilterValue = "Sold";
                    break;

            }
            if (FilterValue == "All")
                _dtBookCopies.DefaultView.RowFilter = "";
            else
                _dtBookCopies.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = dgvListBookCopies .Rows.Count.ToString();
        }

        private void btnAddBookCopy_Click(object sender, EventArgs e)
        {
            frmAddUpdatebookCopies frmAddUpdatebookCopies =new frmAddUpdatebookCopies(_BookID);
             frmAddUpdatebookCopies.ShowDialog();
            _RefreshBookCopiesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatebookCopies frmAddUpdatebookCopies = new frmAddUpdatebookCopies((int)dgvListBookCopies.CurrentRow.Cells[0].Value, (int)dgvListBookCopies.CurrentRow.Cells[1].Value);
            frmAddUpdatebookCopies.ShowDialog();
            _RefreshBookCopiesList();
        }
    }
 }
