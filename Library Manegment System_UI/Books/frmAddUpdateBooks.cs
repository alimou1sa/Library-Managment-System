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
using static Guna.UI2.Native.WinApi;

namespace Library_Manegment_System
{
    public partial class frmAddUpdateBooks : Form
    {
        public delegate void DataBackEventHandler(object sender, int BookID);


        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _BookID = -1;
        clsBooks _Book;

        public frmAddUpdateBooks()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateBooks(int BookID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _BookID = BookID;
        }

        private async void _FillCategoriesInComoboBox()
        {
            DataTable dtCatecories = await  clsCategories.GetListCategories();

            foreach (DataRow row in dtCatecories.Rows)
            {
                cbCategory.Items.Add(row["CategoryName"]);
            }
        }
        private async void _FillGenreInComoboBox()
        {
            DataTable dtGenre = new DataTable();
  
            dtGenre = await  clsGenres.GetListGenres();

            foreach (DataRow row in dtGenre.Rows)
            {
                cbGenre.Items.Add(row["GenreName"]);
            }
        }
        private async void _FillAutherInComoboBox()
        {
            DataTable dtAuther = await  clsAuthors.GetListAuthors();
 
            foreach (DataRow row in dtAuther.Rows)
            {
                cbAutherName.Items.Add(row["Name"]);
            }
        }
        private async void _FillPublishersInComoboBox()
        {
            DataTable dtPublisher =await  clsPublishers.GetListPublishers();
            foreach (DataRow row in dtPublisher.Rows)
            {
                cbPublisherName.Items.Add(row["Name"]);
            }
        }

        private void _ResetDefualtValues()
        {
            _FillCategoriesInComoboBox();
            _FillGenreInComoboBox();
            _FillAutherInComoboBox();
            _FillPublishersInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add New Book";
                _Book = new clsBooks();
            }
            else
            {
                lblTitel.Text = "Update Book";
                NupDNumofCopies.Enabled = false;

            }

            txtAdditionalDetails.Text = "";
            cbGenre.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
            cbAutherName.SelectedIndex = 0;
            cbPublisherName.SelectedIndex = 0;
            txtISBN.Text = "";
            txtTitle.Text = "";
            lblBookID.Text = "???";
            dtpPublicationDate.Value = DateTime.Now;


        }

        private async void _LoadData()
        {

            _Book = clsBooks.FindByID(_BookID);

            if (_Book == null)
            {
                MessageBox.Show("No Book with ID = " + _BookID, "BookID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }


            txtTitle.Text = _Book.Title.ToString();
            txtISBN.Text = _Book.ISBN.ToString();
            cbAutherName.SelectedIndex = cbAutherName.FindString(_Book.AuthorsInfo.Name);
            txtAdditionalDetails.Text = _Book.AdditionalDetails.ToString();
            cbGenre.SelectedIndex =cbGenre.FindString(_Book.GenresInfo.GenreName);
            cbPublisherName.SelectedIndex = cbPublisherName.FindString(_Book.PublishersInfo.Name);
            txtBookPrice.Text=_Book.BookPrice.ToString();
            lblBookID.Text = _Book.BookID.ToString();
            dtpPublicationDate.Text = _Book.YearPublished.ToString();
            cbCategory.SelectedIndex = cbCategory.FindString(_Book.CategoriesInfo.CategoryName);
            NupDNumofCopies.Value = await  clsBookCopies.GetNumberOfAllBookCopies(_Book.BookID);

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAddUpdateBooks_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void Author_DataBack(object sender,string Name)
        {
            cbAutherName.Items.Clear();
            _FillAutherInComoboBox();
            cbAutherName.SelectedIndex = cbAutherName.FindString(Name);
            return;
        }
        private void Pulisher_DataBack(object sender, string Name)
        {
            cbPublisherName.Items.Clear();
            _FillPublishersInComoboBox();
            cbPublisherName.SelectedIndex = cbPublisherName.FindString(Name);
            return;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateAuther_Publisher frmAddAuther_Publisher = new frmAddUpdateAuther_Publisher(true);
            frmAddAuther_Publisher.DataBack += Author_DataBack;
            frmAddAuther_Publisher.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            frmAddUpdateAuther_Publisher frmAddAuther_Publisher = new frmAddUpdateAuther_Publisher(false);
            frmAddAuther_Publisher.DataBack += Pulisher_DataBack;
            frmAddAuther_Publisher.ShowDialog();
        }



        private async void _AddCobyBooks(short NumberOFCoby)
        {
            for (short i = 0; i < NumberOFCoby; i++)
            {
                clsBookCopies bookCopies = new clsBookCopies();

                bookCopies.BookID = _Book.BookID;
                bookCopies.Status = (byte)clsBookCopies.enStatusCopy.Available;

                if ( ! await bookCopies.Save())
                {
                    MessageBox.Show("Canot Saved Cobies Succesfuly");
                    return;
                }
            }
        }




        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
             
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Book.AdditionalDetails = txtAdditionalDetails.Text.ToString();
            _Book.AuthorID = clsAuthors.Find(cbAutherName.Text).AutherID;
            _Book.ISBN = txtISBN.Text.ToString();
            _Book.Title = txtTitle.Text.ToString();
            _Book.PublisherID=clsPublishers.FindByPublisgerName(cbPublisherName.Text).PublisherID;
            _Book.BookPrice =Convert.ToDouble(txtBookPrice.Text);

            clsCategories category = clsCategories.Find(cbCategory.Text);

            if (category != null)
                _Book.CategoryID = category.CategoryID;
            else
            {
                category = new clsCategories();
                category.CategoryName = cbCategory.Text;
                if (await category.Save())
                    _Book.CategoryID = category.CategoryID;
            }


            clsGenres Genre = clsGenres.FindByGenreNAme(cbGenre.Text);
            if (Genre != null)
                _Book.GenreID = Genre.GenreID;
            else
            {
                Genre = new clsGenres();
                Genre.GenreName = cbGenre.Text;
                if ( await Genre.Save())
                    _Book.GenreID = Genre.GenreID;
            }





            _Book.YearPublished = dtpPublicationDate.Value.Date;

            if (await _Book.Save())
            {
                if(_Mode==enMode.AddNew)
                    _AddCobyBooks(Convert.ToInt16(NupDNumofCopies.Value));


                lblBookID.Text = _Book.BookID.ToString();
                _Mode = enMode.Update;
                lblTitel.Text = "Update Book";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                 DataBack?.Invoke(this, _Book.BookID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtBookPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Genre_DataBack(object sender, string Name)
        {
           
                cbGenre.Items.Clear();
                _FillGenreInComoboBox();
                cbGenre.SelectedIndex = cbGenre.FindString(Name);
                return;
        }

        private void Category_DataBack(object sender, string Name)
        {

            cbCategory.Items.Clear();
            _FillCategoriesInComoboBox();
            cbCategory.SelectedIndex = cbCategory.FindString(Name);
            return;
        }


        private void lblAddGenre_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateGenresAndCategories frmAdd_UpdateGenresAndCategories =new frmAdd_UpdateGenresAndCategories(true);
            frmAdd_UpdateGenresAndCategories.DataBack += Genre_DataBack;
            frmAdd_UpdateGenresAndCategories.ShowDialog();
        }

        private void lblAddCategory_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateGenresAndCategories frmAdd_UpdateGenresAndCategories = new frmAdd_UpdateGenresAndCategories(false);
            frmAdd_UpdateGenresAndCategories.DataBack += Category_DataBack;
            frmAdd_UpdateGenresAndCategories.ShowDialog();
        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateGenresAndCategories frmAdd_UpdateGenresAndCategories = new frmAdd_UpdateGenresAndCategories(cbGenre.Text.Trim(),true);
            frmAdd_UpdateGenresAndCategories.DataBack += Genre_DataBack;
            frmAdd_UpdateGenresAndCategories.ShowDialog();
        }

        private void CMstripCategory_Opening(object sender, CancelEventArgs e)
        {
            frmAdd_UpdateGenresAndCategories frmAdd_UpdateGenresAndCategories = new frmAdd_UpdateGenresAndCategories(cbCategory.Text.Trim(),false);
            frmAdd_UpdateGenresAndCategories.DataBack += Category_DataBack;
            frmAdd_UpdateGenresAndCategories.ShowDialog();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateAuther_Publisher frmAddAuther_Publisher = new frmAddUpdateAuther_Publisher(true,cbAutherName.Text.Trim());
            frmAddAuther_Publisher.DataBack += Author_DataBack;
            frmAddAuther_Publisher.ShowDialog();
        }

        private void editeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateAuther_Publisher frmAddAuther_Publisher = new frmAddUpdateAuther_Publisher(false, cbPublisherName.Text.Trim());
            frmAddAuther_Publisher.DataBack += Pulisher_DataBack;
            frmAddAuther_Publisher.ShowDialog();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
