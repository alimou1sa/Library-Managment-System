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
    public partial class frmPurchasesBookDetails : Form
    {
        private int _PurchasesBookID = -1;
        public frmPurchasesBookDetails(int purchasesBookID)
        {
            InitializeComponent();
            _PurchasesBookID = purchasesBookID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchasesBookDetails_Load(object sender, EventArgs e)
        {
            ctrlPurchasesBookInfo1.LoadPurchasesBookInfo(_PurchasesBookID);
        }
    }
}
