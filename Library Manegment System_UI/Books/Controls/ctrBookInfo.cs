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
    public partial class ctrBookInfo : UserControl
    {
        public ctrBookInfo()
        {
            InitializeComponent();
        }

        clsBooks _Book;
        private int _BookID;
        public int BookID
        {
            get { return _BookID; }
        }

        private string _ISBN;

        public string ISBN
        {
            get { return _ISBN; }
        }



        public clsBooks SelectBookInfo
        {
            get { return _Book; }
        }
        private async void _FillBookInfo()
        {
            _ISBN=_Book.ISBN;
            _BookID = _Book.BookID;
            lblTite.Text = _Book.Title;
            lblISBN.Text = _Book.ISBN;
            lblGener.Text = _Book.GenresInfo.GenreName;
            lblAutherName.Text = _Book.AuthorsInfo.Name;
            lblAdditionalDetails.Text = _Book.AdditionalDetails;
            lblCategory.Text = _Book.CategoriesInfo.CategoryName;
            lblPublicationDate.Text = _Book.YearPublished.ToString("yyyy");
            lblPublisherName.Text = _Book.PublishersInfo.Name;
            lblBookPrice.Text = _Book.BookPrice.ToString();
           int _Total= await clsBookCopies.GetNumberOfAllBookCopies(BookID);
            lblTotalCopies.Text= _Total.ToString();
            lblBookID.Text = _Book.BookID.ToString(); 
            int _CopiesNum =await clsBookCopies.GetNumberOfAvailableBookCopies(BookID,(byte)clsBookCopies.enStatusCopy.Available);
            lblCopiesAvailble.Text= _CopiesNum.ToString();


        }
        public void ResetBookInfo()
        {
            _BookID = -1;

            lblAdditionalDetails.Text = "[????]";
            lblAutherName.Text = "[????]";
            lblBookID.Text = "[????]";
            lblGener.Text = "[????]";
            lblISBN.Text = "[????]";
            lblTite.Text = "[????]";
            lblPublicationDate.Text = "[????]";
            lblCategory.Text = "[????]";
            lblBookPrice.Text = "[????]";
            lblTotalCopies.Text = "[????]";
            lblPublisherName.Text = "[????]";
            lblCopiesAvailble.Text = "[????]";

        }
        public void LoadBookInfo(int BookID)
        {
            _Book = clsBooks.FindByID(BookID);
            if (_Book == null)
            {
                ResetBookInfo();
                MessageBox.Show("No Book with BookID. = " + BookID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillBookInfo();
        }

        public void LoadBookInfo(string ISBN)
        {
            _Book = clsBooks.FindByISBN(ISBN);
            if (_Book == null)
            {
                ResetBookInfo();
                MessageBox.Show("No Person with ISBN. = " + ISBN.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillBookInfo();
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblCopiesAvalialbe_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
