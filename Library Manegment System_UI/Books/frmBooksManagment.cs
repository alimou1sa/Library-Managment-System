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
using static Guna.UI2.Native.WinApi;

namespace Library_Manegment_System
{
    public partial class frmBooksManagment : Form
    {
        DataTable _dtBooks=null;

        public frmBooksManagment()
        {
            InitializeComponent();
        }
        private async void _RefreshBooksList()
        {
            _dtBooks = await  clsBooks.GetListBooks();
            dgvShowBooks.DataSource = _dtBooks;
            lblRecordsCount.Text = dgvShowBooks.Rows.Count.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateBooks addUpdateBooks = new frmAddUpdateBooks();
            addUpdateBooks.ShowDialog();
            _RefreshBooksList();
        }

        private void frmListBooks_Load(object sender, EventArgs e)
        {
            _RefreshBooksList();
            dgvShowBooks.DataSource = _dtBooks;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvShowBooks.Rows.Count.ToString();
            dgvShowBooks.ColumnHeadersHeight = 70;

            if (dgvShowBooks.Rows.Count > 0)
            {

                dgvShowBooks.Columns[0].Width = 40;
          
                dgvShowBooks.Columns[3].HeaderText = "Genre";
                dgvShowBooks.Columns[4].HeaderText = "PublisherName";
                dgvShowBooks.Columns[5].HeaderText = "Year Published";
                dgvShowBooks.Columns[5].Width = 130;
                dgvShowBooks.Columns[6].HeaderText = "Additional Details";
                dgvShowBooks.Columns[6].Width = 160;
                dgvShowBooks.Columns[7].HeaderText = "Category Name";
                dgvShowBooks.Columns[7].Width = 130;
                dgvShowBooks.Columns[8].HeaderText = "Author Name";
                dgvShowBooks.Columns[8].Width = 130;
                dgvShowBooks.Columns[9].HeaderText = "Book Price";
                dgvShowBooks.Columns[10].HeaderText = "Total Copies";
                dgvShowBooks.Columns[11].HeaderText = "Available Copies";
                dgvShowBooks.Columns[11].Width = 130;

            }




        }


        private async void _FillGenreInComoboBox()
        {
            DataTable dtGenre = new DataTable();
            dtGenre.Rows.Clear();
            cbForAll.Items.Clear();
            cbForAll.Items.Add("None");
            dtGenre = await  clsGenres.GetListGenres();



            foreach (DataRow row in dtGenre.Rows)
            {
                cbForAll.Items.Add(row["GenreName"]);
            }



        }
    
        private async void _FillAutherInComoboBox()
        {
            DataTable dtAuther = await  clsAuthors.GetListAuthors();
            cbForAll.Items.Clear();
            cbForAll.Items.Add("None");
            foreach (DataRow row in dtAuther.Rows)
            {
                cbForAll.Items.Add(row["Name"]);
            }
        }
    
        private async void _FillCategoryNameInComoboBox()
        {
            DataTable dtCategory = await clsCategories.GetListCategories();
            cbForAll.Items.Clear();
            cbForAll.Items.Add("None");
            foreach (DataRow row in dtCategory.Rows)
            {
                cbForAll.Items.Add(row["CategoryName"]);
            }
        }
   
        private async void _FillPublishersInComoboBox()
        {
            DataTable dtPublisher =await  clsPublishers.GetListPublishers();
            cbForAll.Items.Clear();
            cbForAll.Items.Add("None");
            foreach (DataRow row in dtPublisher.Rows)
            {
                cbForAll.Items.Add(row["Name"]);
            }
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.Text == "Genre")
            {
                txtFiter.Visible = false;
                cbForAll.Visible = true;
                cbForAll.Focus();

                _FillGenreInComoboBox();
                return;
            }
            if (cbFiterBy.Text == "Publisher Name")
            {
                txtFiter.Visible = false;
                cbForAll.Visible = true;
                cbForAll.Focus();
                _FillPublishersInComoboBox();
                return;
            }
            if (cbFiterBy.Text == "Category Name")
            {
                txtFiter.Visible = false;
                cbForAll.Visible = true;
                cbForAll.Focus();
                _FillCategoryNameInComoboBox();
                return;
            }
            if (cbFiterBy.Text == "Auther Name")
            {
                txtFiter.Visible = false;
                cbForAll.Visible = true;
                cbForAll.Focus();
                _FillAutherInComoboBox();
                return;
            }


            txtFiter.Visible = (txtFiter.Text != "None");
            cbForAll.Visible = false;

            if (cbFiterBy.Text == "None")
            {
                txtFiter.Enabled = false;
            }
            else
                txtFiter.Enabled = true;

            txtFiter.Text = "";
            txtFiter.Focus();

        }
        private void txtFiter_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFiterBy.Text)
            {
                case "BookID":
                    FilterColumn = "BookID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                case "ISBN":
                    FilterColumn = "ISBN";
                    break;
                case "Book Price":
                    FilterColumn = "BookPrice";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtBooks.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvShowBooks.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "BookID"|| FilterColumn == "BookPrice")
                //in this case we deal with integer not string.

                _dtBooks.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _dtBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvShowBooks.Rows.Count.ToString();
        }

        private void cbForAll_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";


            switch (cbForAll.Text)
            {
                case "None":
                    FilterColumn = "None";
                    break;
                default:
                    switch (cbFiterBy.Text)
                    {
                        case "Genre":
                            FilterColumn = "GenreName";
                            break;
                        case "Publisher Name":
                            FilterColumn = "PublisherName";
                            break;
                        case "Auther Name":
                            FilterColumn = "AutherName";
                            break;
                        case "Category Name":
                            FilterColumn = "CategoryName";
                            break;
                    }
                    break;

            }
            if (cbForAll.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtBooks.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvShowBooks.Rows.Count.ToString();
                return;
            }

            _dtBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, cbForAll.Text.Trim());

            lblRecordsCount.Text = dgvShowBooks.Rows.Count.ToString();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBooks addUpdateBooks = new frmAddUpdateBooks((int)dgvShowBooks.CurrentRow.Cells[0].Value);
            addUpdateBooks.ShowDialog();
            _RefreshBooksList();


        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookDetails frmBook = new frmBookDetails((int)dgvShowBooks.CurrentRow.Cells[0].Value);
            frmBook.ShowDialog();
            _RefreshBooksList();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }


        private async void deleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = (int)dgvShowBooks.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do want to delete this Book?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (await clsBooks.IsBooksExisteByID(BookID))
            {

                if ( await clsBookCopies.DeleteBookCopiesByBookID(BookID))
                {



                    if (await clsBooks.DeleteBooks(BookID))
                    {
                        MessageBox.Show("Book Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmListBooks_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete Book, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "BookID"|| cbFiterBy.Text== "Book Price")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBooks addUpdateBooks = new frmAddUpdateBooks();
            addUpdateBooks.ShowDialog();
            _RefreshBooksList();
        }

        private void statusCopiesBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookCopiesManagment frmBookCopiesManagment = new frmBookCopiesManagment((int)dgvShowBooks.CurrentRow.Cells[0].Value);
            frmBookCopiesManagment.ShowDialog();
            _RefreshBooksList();
        }

        private void loanBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoanBook frmBorrow=new frmLoanBook((int)dgvShowBooks.CurrentRow.Cells[0].Value);
           frmBorrow.ShowDialog();
            _RefreshBooksList();
        }
    }

    
}
