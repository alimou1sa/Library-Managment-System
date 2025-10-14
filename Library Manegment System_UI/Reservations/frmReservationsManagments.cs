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
using System.Xml.Linq;
using static Guna.UI2.HtmlRenderer.Adapters.RGraphicsPath;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Library_Manegment_System
{
    public partial class frmReservationsManagments : Form
    {
        public frmReservationsManagments()
        {
            InitializeComponent();
        }
        DataTable _DTResevation;// =clsReservations.GetListReservations();

        private async Task  _RefreshReservationsList()
        {
            _DTResevation =await  clsReservations.GetListReservations();
            dgvListReservations .DataSource = _DTResevation;
            lblRecordsCount.Text = dgvListReservations .Rows.Count.ToString();
        }
        private async void frmReservationsManagments_Load(object sender, EventArgs e)
        {
          await  _RefreshReservationsList();
            dgvListReservations.DataSource = _DTResevation;
            cbFiterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListReservations.Rows.Count.ToString();
            dgvListReservations.ColumnHeadersHeight = 70;


            if (dgvListReservations.Rows.Count > 0)
            {

                dgvListReservations.Columns[1].HeaderText = "Reservation Date";
                dgvListReservations.Columns[1].Width = 130;
                dgvListReservations.Columns[2].HeaderText = "Reservations Status";
                dgvListReservations.Columns[2].Width = 140;
                dgvListReservations.Columns[6].HeaderText = "User Name";
                dgvListReservations.Columns[7].HeaderText = "Member ID";
                dgvListReservations.Columns[8].HeaderText = "Library Card Number";
                dgvListReservations.Columns[8].Width = 140;
                dgvListReservations.Columns[9].HeaderText = "Is Member Active";
                dgvListReservations.Columns[9].Width = 110;


            }
            }

        private void txtFiter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

         
            switch (cbFiterBy.Text)
            {
                case "Reservation ID":
                    FilterColumn = "ReservationID";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                case "Book ID":
                    FilterColumn = "BookID";
                    break;
                case "MemberID":
                    FilterColumn = "MemberID";
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
                _DTResevation.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListReservations.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ReservationID" || FilterColumn == "BookID" || FilterColumn == "MemberID")


                _DTResevation.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiter.Text.Trim());
            else
                _DTResevation.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiter.Text.Trim());

            lblRecordsCount.Text = dgvListReservations.Rows.Count.ToString();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.Text == "Reservations Status")
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


                _DTResevation.DefaultView.RowFilter = "";
                txtFiter.Text = "";
                lblRecordsCount.Text = dgvListReservations .Rows.Count.ToString();
                txtFiter.Focus();
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "ReservationsStatus";
            string FilterValue = "";
            switch (cbStatus.Text)
            {
                case "All":
                    FilterValue = "All";
                    break;
                case "Reserved":
                    FilterValue = "Reserved";
                    break;
                case "Conver To Borrowing":
                    FilterValue = "ConvertToBorrowing";
                    break;
                case "Cancelled":
                    FilterValue = "Cancelled";
                    break;


            }
            if (FilterValue == "All")
                _DTResevation.DefaultView.RowFilter = "";
            else
                _DTResevation.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);


            lblRecordsCount.Text = dgvListReservations .Rows.Count.ToString();
        }

        private void txtFiter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.Text == "Reservation ID" || cbFiterBy.Text == "Member ID" || cbFiterBy.Text == "Book ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private async void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateReservations frm=new frmAddUpdateReservations((int)dgvListReservations.CurrentRow.Cells[0].Value, (int)dgvListReservations.CurrentRow.Cells[5].Value);
            frm.ShowDialog();
           await  _RefreshReservationsList();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Reservationid = (int)dgvListReservations .CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do want to delete this Reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


                if (await  clsReservations.DeleteReservations(Reservationid))
                {


                    MessageBox.Show("Reservation Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmReservationsManagments_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete Loan, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
        }

        private async void reservationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReservationsDetails frmReservationsDetails = new frmReservationsDetails((int)dgvListReservations.CurrentRow.Cells[0].Value);
            frmReservationsDetails.ShowDialog();
           await  _RefreshReservationsList();
                    
        }
    }
}
