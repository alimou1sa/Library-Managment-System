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
    public partial class frmPeopleManrgment : Form
    {
        public frmPeopleManrgment()
        {
            InitializeComponent();
        }


        DataTable _dtPeople=null ;

        private async void _RefreshPeoplsList()
        {
            _dtPeople =await  clsPeople.GetListPeople();
            dgvListPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvListPeople.Rows.Count.ToString();
        }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";


            switch (cbFiterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Country Name":
                    FilterColumn = "CountryName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFiter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListPeople.Rows.Count.ToString();
        }

        private void frmPeopleManrgment_Load(object sender, EventArgs e)
        {
            _RefreshPeoplsList();
            dgvListPeople.DataSource = _dtPeople;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListPeople.Rows.Count.ToString();
            dgvListPeople.ColumnHeadersHeight = 70;


            if (dgvListPeople.Rows.Count > 0)
            {
                dgvListPeople.Columns[0].Width = 70;
                dgvListPeople.Columns[1].Width = 80;
                dgvListPeople.Columns[2].HeaderText = "First Name";
                dgvListPeople.Columns[2].Width = 100;
                dgvListPeople.Columns[3].HeaderText = "Second Name";
                dgvListPeople.Columns[3].Width = 110;
                dgvListPeople.Columns[4].HeaderText = "Last Name";
                dgvListPeople.Columns[4].Width = 120;
                dgvListPeople.Columns[5].HeaderText = "Date Of Birth";
                dgvListPeople.Columns[6].HeaderText = "Gendor Caption";
                dgvListPeople.Columns[5].Width = 110;
                dgvListPeople.Columns[6].Width = 110;
                dgvListPeople.Columns[7].Width = 90;

            }
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFiterBy.Text == "Gendor Caption")
            {
              
                txtFiter.Visible = false;
                cbGender.Visible = true;
                cbGender.Focus();
                cbGender.SelectedIndex = 0;

                return;
            }
            else
            {

                txtFiter.Visible = (cbFiterBy.Text != "None");
            
                cbGender.Visible = false;
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

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "GendorCaption";
            string FilterValue = cbGender.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Male":
                    FilterValue = "Male";
                    break;
                case "Female":
                    FilterValue = "Female";
                    break;
            }


            if (FilterValue == "All")
                _dtPeople.DefaultView.RowFilter = "";
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _dtPeople.Rows.Count.ToString();
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePersons frmAddUpdatePersons = new frmAddUpdatePersons();
                frmAddUpdatePersons.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePersons frmAddUpdatePersons = new frmAddUpdatePersons((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frmAddUpdatePersons.ShowDialog();
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleDetails frmPeopleDetails=new frmPeopleDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frmPeopleDetails.ShowDialog();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvListPeople .CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (await  clsPeople.DeletePeople((int)dgvListPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplsList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvListPeople_DoubleClick(object sender, EventArgs e)
        {
            frmPeopleDetails frmPeopleDetails = new frmPeopleDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frmPeopleDetails.ShowDialog();
        }
    }
}
