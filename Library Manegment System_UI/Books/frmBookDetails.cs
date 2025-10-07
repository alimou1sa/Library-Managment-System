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
    public partial class frmBookDetails : Form
    {

        int _BookID;
        public frmBookDetails(int BookID)
        {
            InitializeComponent();
            if(BookID!=-1)
               _BookID = BookID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmBookDetails_Load(object sender, EventArgs e)
        {
            ctrBookInfo1.LoadBookInfo(_BookID);
        }
    }
}
