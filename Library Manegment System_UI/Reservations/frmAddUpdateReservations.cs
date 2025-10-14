using Library;
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
    public partial class frmAddUpdateReservations : Form
    {
        public frmAddUpdateReservations(int BookID)
        {
            InitializeComponent();
            if (BookID != -1)
                _BookID = BookID;
            _Mode=enMode.AddNew;

        }


        public frmAddUpdateReservations(int ReservationID, int BookID)
        {
            InitializeComponent();
            if (BookID != -1)
                _BookID = BookID;

            _ReservationID = ReservationID;
            _Mode = enMode.Update;
        }
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _BookID = -1;
        private int _ReservationID = -1;

        clsReservations _Reservations;

        private void   _ResetDefualtValues()
        {


            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add Reservation";
                this.Text = "Add Reservation";
                _Reservations = new clsReservations();

                tpReservationInfo.Enabled = false;

            }
            else
            {
                lblTitel.Text = "Update Reservation";
                this.Text = "Update Reservation";


            }

            lblBookID.Text = _BookID.ToString();
            lblCreateByUser.Text =clsGlobal.CurrentUser.UserName;
            lblReservationDate.Text = DateTime.Now.ToString("yyyy|MM|dd");
            lblReservationID.Text = "[???]";
            ctrlMemberCardWhithFilter1.FilterFocus();


        }

        private void _LoadData()
        {

            _Reservations = clsReservations.FindByID(_ReservationID);
            ctrlMemberCardWhithFilter1.FilterEnabled = false;

            if (_Reservations == null)
            {
                MessageBox.Show("No ReservationID with ID = " + _ReservationID, "ReservationID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblBookID.Text=_Reservations.BookID.ToString();
            lblCreateByUser.Text = _Reservations.UsersInfo.UserName;
            lblReservationID.Text= _Reservations.ReservationID.ToString();
            lblReservationDate.Text= _Reservations.ReservationDate.ToString("yyyy|MM|dd");
            if ((_Reservations.Status >= 1) || (_Reservations.Status <= 3))
            cbStatus.SelectedIndex = _Reservations.Status - 1;


            ctrlMemberCardWhithFilter1.LoadMemberInfo(_Reservations.MemberID);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmAddReservations_Load(object sender, EventArgs e)
        {


            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpReservationInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpReservationInfo"];
                return;
            }


            if (ctrlMemberCardWhithFilter1.MemberID != -1)
            {
                if (ctrlMemberCardWhithFilter1.SelectedMemberInfo.IsActive != true)
                {
                    MessageBox.Show("This Member Is Not Active ,Choose Anuther One", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnSave.Enabled = true;
                tpReservationInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpReservationInfo"];

            }
            else

            {
                MessageBox.Show("Please Select a Book", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlMemberCardWhithFilter1.FilterFocus();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_Mode == enMode.AddNew)
            {
                _Reservations.MemberID=ctrlMemberCardWhithFilter1.MemberID;
                _Reservations.BookID=_BookID;
                _Reservations.Status= (byte)(clsReservations.enReservationsStatus)Enum.Parse(typeof(clsReservations.enReservationsStatus), cbStatus.Text);
                _Reservations.CreateByUserID=clsGlobal.CurrentUser.UserID;
                _Reservations.ReservationDate= DateTime.Now;

            }
            else if (_Mode == enMode.Update)
            {
                _Reservations.Status = (byte)(clsReservations.enReservationsStatus)Enum.Parse(typeof(clsReservations.enReservationsStatus), cbStatus.Text);

            }

            if (await  _Reservations.Save())
            {
                lblReservationID.Text = _Reservations.ReservationID.ToString();



                if (_Mode == enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    lblTitel.Text = "Update Reservation";
                    this.Text = "Update Reservation";

                }
                else
                {
                    _Mode = enMode.Update;
                    lblTitel.Text = "Update Reservation";
                    this.Text = "Update Reservation";
                    btnSave.Enabled = false;
                }

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
