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
    public partial class frmAddUpdatebookCopies : Form
    {
        public frmAddUpdatebookCopies(int CopyID, int BookID)
        {
            InitializeComponent();
            _CopyID = CopyID;

            if (BookID != -1)
                _BookID = BookID;
  
            _Mode =enMode.Update;
        }

        public frmAddUpdatebookCopies(int BookID)
        {
            InitializeComponent();
            _Mode =enMode.AddNew;

            if (BookID !=-1 ) 
            _BookID = BookID;


        }


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _CopyID = -1;
        clsBookCopies _bookCopies;
        private int _BookID=-1;
        private void _ResetDefualtValues()
        {
         

            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add New Book Copy";
                this.Text = "Add New Book Copy";
                _bookCopies = new clsBookCopies();

                tpCopyInfo.Enabled = false;
                ctrlBookCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitel.Text = "Update Book Copy";
                this.Text = "Update Book Copy";

                tpCopyInfo.Enabled = true;
                btnSave .Enabled = true;


            }

            cbStatus.SelectedIndex = 0 ;


        }

        private void _LoadData()
        {

            _bookCopies = clsBookCopies.FindByID(_CopyID);
            ctrlBookCardWithFilter1.FilterEnabled = false;

            if (_bookCopies == null)
            {
                MessageBox.Show("No Copy with ID = " + _CopyID, "Book Copy Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblCopyID.Text = _bookCopies.CopyID.ToString();
            cbStatus.Text = _bookCopies.Status.ToString();
            if((_bookCopies.Status>=1)||(_bookCopies.Status<=5))
            cbStatus.SelectedIndex = _bookCopies.Status-1;

             //   ((clsBookCopies.enStatusCopy)_bookCopies.Status)


            ctrlBookCardWithFilter1.LoadBookInfo(_bookCopies.BookID);
        }

        private void frmAddUpdatebookCopies_Load(object sender, EventArgs e)
        {
            if (_BookID != -1)
            {
                ctrlBookCardWithFilter1 .LoadBookInfo(_BookID);
                ctrlBookCardWithFilter1 .FilterEnabled = false;

            }
            else
            {
                ctrlBookCardWithFilter1.Enabled = true;
                ctrlBookCardWithFilter1.FilterFocus();
            }



            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private async void _Save()
        {

            if (!this.ValidateChildren())
            {
             
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _bookCopies.BookID = ctrlBookCardWithFilter1 .BookID;
             byte staus= (byte)(clsBookCopies.enStatusCopy)Enum.Parse(typeof(clsBookCopies.enStatusCopy),cbStatus.Text);

            _bookCopies.Status = staus;

            if ( await _bookCopies.Save())
            {
                lblCopyID.Text = _bookCopies.CopyID.ToString();
                _Mode = enMode.Update;
                lblTitel.Text = "Update Book Copy";
                this.Text = "Update Book Copy";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpCopyInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpCopyInfo"];
                return;
            }


            if (ctrlBookCardWithFilter1.BookID  != -1)
            {

             
                    btnSave.Enabled = true;
                    tpCopyInfo.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tpCopyInfo"];
                
            }

            else

            {
                MessageBox.Show("Please Select a Book", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlBookCardWithFilter1 .FilterFocus();

            }



        }

        private void cbStatus_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbStatus.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(cbStatus, "Status cannot be blank");
            }
            else
            {
                errorProvider1.SetError(cbStatus, null);
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
