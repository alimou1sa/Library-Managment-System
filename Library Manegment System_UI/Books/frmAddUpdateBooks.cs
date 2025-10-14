using Library_Business;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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

        private async Task  _FillCategoriesInComoboBox()
        {
            DataTable dtCatecories = await  clsCategories.GetListCategories();

            foreach (DataRow row in dtCatecories.Rows)
            {
                cbCategory.Items.Add(row["CategoryName"]);
            }
        }
    
        private async Task  _FillGenreInComoboBox()
        {
            DataTable dtGenre = new DataTable();
  
            dtGenre = await  clsGenres.GetListGenres();

            foreach (DataRow row in dtGenre.Rows)
            {
                cbGenre.Items.Add(row["GenreName"]);
            }
        }
      
        private async Task  _FillAutherInComoboBox()
        {
            DataTable dtAuther = await  clsAuthors.GetListAuthors();
 
            foreach (DataRow row in dtAuther.Rows)
            {
                cbAutherName.Items.Add(row["Name"]);
            }
        }
    
        private async Task  _FillPublishersInComoboBox()
        {
            DataTable dtPublisher =await  clsPublishers.GetListPublishers();
            foreach (DataRow row in dtPublisher.Rows)
            {
                cbPublisherName.Items.Add(row["Name"]);
            }
        }

        private async Task _ResetDefualtValues()
        {
           Task task1= _FillCategoriesInComoboBox();
           Task task2=_FillGenreInComoboBox();
           Task task3=  _FillAutherInComoboBox();
           Task task4=  _FillPublishersInComoboBox();

           await  Task.WhenAll(task1,task2,task3,task4);
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

        private async Task _LoadData()
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

        private async void frmAddUpdateBooks_Load(object sender, EventArgs e)
        {
           await  _ResetDefualtValues();

            if (_Mode == enMode.Update)
               await  _LoadData();
        }

        private async void Author_DataBack(object sender,string Name)
        {
            cbAutherName.Items.Clear();
           await  _FillAutherInComoboBox();
            cbAutherName.SelectedIndex = cbAutherName.FindString(Name);
            return;
        }
    
        private async void Pulisher_DataBack(object sender, string Name)
        {
            cbPublisherName.Items.Clear();
           await  _FillPublishersInComoboBox();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
             
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Book.GenreID=clsGenres.FindByGenreNAme(cbGenre.Text).GenreID;
            _Book.CategoryID=clsCategories.Find(cbCategory.Text).CategoryID;
            _Book.AdditionalDetails = txtAdditionalDetails.Text.ToString();
            _Book.AuthorID = clsAuthors.Find(cbAutherName.Text).AutherID;
            _Book.ISBN = txtISBN.Text.ToString();
            _Book.Title = txtTitle.Text.ToString();
            _Book.PublisherID=clsPublishers.FindByPublisgerName(cbPublisherName.Text).PublisherID;
            _Book.BookPrice =Convert.ToDouble(txtBookPrice.Text);
            _Book.YearPublished = dtpPublicationDate.Value.Date;
            _Book.NumberOfCopies = Convert.ToInt16(NupDNumofCopies.Value);

            if (await _Book.Save())
            {
                
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

        private async void Genre_DataBack(object sender, string Name)
        {
           
                cbGenre.Items.Clear();
               await  _FillGenreInComoboBox();
                cbGenre.SelectedIndex = cbGenre.FindString(Name);
                return;
        }

        private async void Category_DataBack(object sender, string Name)
        {

            cbCategory.Items.Clear();
           await  _FillCategoriesInComoboBox();
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
            this .Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            };


        }

        private void txtISBN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtISBN.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtISBN, "ISBN cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtISBN, null);
            };


            if (_Mode == enMode.AddNew)
            {

                if ( clsBooks.IsBooksExisteByISBN(txtISBN.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtISBN, "ISBN is used by another Book");
                }
                else
                {
                    errorProvider1.SetError(txtISBN, null);
                };
            }
            else
            {
                if (_Book.ISBN != txtISBN.Text.Trim())
                {
                    if ( clsBooks.IsBooksExisteByISBN(txtISBN.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtISBN, "ISBN is used by another Book");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtISBN, null);
                    };
                }
            }
        }

        private void txtBookPrice_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtBookPrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBookPrice, "Book Price cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBookPrice, null);
            };
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (await clsGenres.DeleteGenres(cbGenre.Text.Trim()))
            {
                MessageBox.Show("Genre Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGenre.Items.Clear();
                await  _FillGenreInComoboBox();
               cbGenre.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Could not delete Genre , other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (await  clsCategories.DeleteCategories(cbCategory.Text .Trim()))
            {
                MessageBox.Show("Category Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCategory.Items.Clear();
                await _FillCategoriesInComoboBox();
                cbCategory.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Could not delete Category , other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (await  clsAuthors.DeleteAuthors (cbAutherName.Text.Trim()))
            {
                MessageBox.Show("Auther Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbAutherName.Items.Clear();
                await _FillAutherInComoboBox();
                cbAutherName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Could not delete Auther , other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (await  clsPublishers.DeletePublishers(cbPublisherName.Text.Trim()))
            {
                MessageBox.Show("Publisher Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbPublisherName.Items.Clear();
                await _FillPublishersInComoboBox();
                cbPublisherName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Could not delete Publisher , other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
