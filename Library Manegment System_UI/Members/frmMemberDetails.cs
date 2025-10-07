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
    public partial class frmMemberDetails : Form
    {
        private int _MemberID=-1;
        public frmMemberDetails(int MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;

        }

        private void ctrlMemberCard1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            ctrlMemberCard1.LoadMemberInfo(_MemberID);
        }
    }
}
