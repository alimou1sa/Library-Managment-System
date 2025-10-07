using Library_Business;
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
    public partial class ctrlReservatiomsInfo : UserControl
    {
        public ctrlReservatiomsInfo()
        {
            InitializeComponent();
        }


        clsReservations _Reservation;
        int _ReservationID;
        public int ReservationID
        {
            get { return _ReservationID; }
        }

        public clsReservations SelectReservationInfo
        {
            get { return _Reservation; }
        }

        public void ResetReservationInfo()
        {
            _ReservationID = -1;

            lblCreateByUser.Text = "[????]";
            lblReservationDate.Text = "[????]";
            lblReservationID.Text = "[????]";
            lblReservationStatus.Text = "[????]";
            lblReservationStatus.Text = "[????]";
         linkelblShowMember.Enabled = false;    
            ctrBookInfo1.ResetText();

        }
        private void _FillReservationsInfo()
        {
            _ReservationID=_Reservation.ReservationID;
            lblCreateByUser.Text = _Reservation.UsersInfo.UserName;
            lblReservationDate.Text = _Reservation.ReservationDate.ToString("yyyy:MM:dd");
            lblReservationID.Text = _Reservation.ReservationID.ToString();
            lblReservationStatus.Text = clsReservations.GetReservationStatusAsString(_Reservation.Status);
          lblMemberID.Text= _Reservation.MemberID.ToString();
            ctrBookInfo1.LoadBookInfo(_Reservation.BookID);

        }
        public void LoadReservationInfo(int ReservationID)
        {
            _Reservation = clsReservations.FindByID(ReservationID);
            if (_Reservation == null)
            {
                ResetReservationInfo();
                MessageBox.Show("No _Reservatio with ReservationID. = " + ReservationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            linkelblShowMember.Enabled = true ;
            _FillReservationsInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMemberDetails frmMember=new frmMemberDetails(_Reservation.MemberID);
            frmMember.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
