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
    public partial class frmSubscriptionInfo : Form
    {
        private int? _MemberID = null;
        public frmSubscriptionInfo(int MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubscriptionInfo_Load(object sender, EventArgs e)
        {

            ctrlMemberSubscriptionInfo1.LoadMemberSubscriptionInfo(_MemberID.Value);
        }
    }
}
