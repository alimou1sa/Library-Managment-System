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
    public partial class frmReservationsDetails : Form
    {
        private int _ReservationID = -1;
        public frmReservationsDetails(int ReservationID)
        {
            InitializeComponent();
            _ReservationID = ReservationID;
        }

        private void frmReservationsDetails_Load(object sender, EventArgs e)
        {
            ctrlReservatiomsInfo1.LoadReservationInfo(_ReservationID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlReservatiomsInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void ctrlReservatiomsInfo1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
