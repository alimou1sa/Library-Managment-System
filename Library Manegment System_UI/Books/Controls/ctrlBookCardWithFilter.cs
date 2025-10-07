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

namespace Library_Manegment_System
{
    public partial class ctrlBookCardWithFilter : UserControl
    {

        public class BookSelectedEventArgs : EventArgs
        {
            public int BookID { get; }
            public string ISBN { get; }

            public BookSelectedEventArgs(int BookID, string ISBN)
            {
                this.BookID = BookID;
                this.ISBN = ISBN;

            }
        }

        public event EventHandler<BookSelectedEventArgs> OnBookSelected;

        public void BookSelected(int BookID, string ISBN)
        {
            BookSelected(new BookSelectedEventArgs(BookID, ISBN));
        }

        protected virtual void BookSelected(BookSelectedEventArgs e)
        {
            OnBookSelected?.Invoke(this, e);
        }



        private bool _ShowAddBook = true;
        public bool ShowAddBook
        {
            get
            {
                return _ShowAddBook;
            }
            set
            {
                _ShowAddBook = value;
                btnAddNewBook.Visible = _ShowAddBook;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }



        public ctrlBookCardWithFilter()
        {
            InitializeComponent();
        }

        private int _BookID = -1;

        public int BookID
        {
            get { return ctrBookInfo1.BookID; }
        }

        public clsBooks SelectedBookInfo
        {
            get { return ctrBookInfo1.SelectBookInfo; }
        }

        public void LoadBookInfo(int BookID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = BookID.ToString();
            FindNow();

        }

        private void FindNow()
        {

            switch (cbFilterBy.Text)
            {
                case "Book ID":
                    ctrBookInfo1.LoadBookInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "ISBN":
                    ctrBookInfo1.LoadBookInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnBookSelected != null && FilterEnabled)

                BookSelected(ctrBookInfo1.BookID,ctrBookInfo1.ISBN);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                //e.co = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void ctrlBookCardWithFilter_Load(object sender, EventArgs e)
        {
           // cbFilterBy.SelectedIndex = 0;
           // txtFilterValue.Focus();
        }

        private void DataBackEvent(object sender, int BookID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = BookID.ToString();
            ctrBookInfo1.LoadBookInfo(BookID);
        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            frmAddUpdateBooks frm1 = new frmAddUpdateBooks();
            frm1.DataBack += DataBackEvent;
            frm1.ShowDialog();
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }


            if (cbFilterBy.Text == "Book ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
