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
    public partial class frmLoanDetails : Form
    {
        private int _LoanID = -1;
        public frmLoanDetails(int LoanID)
        {
            InitializeComponent();
            if(LoanID !=-1)
                _LoanID = LoanID;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoanDetails_Load(object sender, EventArgs e)
        {
            ctrlLoanInfo1.LoadLaonInfo(_LoanID);
        }
    }
}
