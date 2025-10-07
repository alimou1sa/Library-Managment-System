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
    public partial class ctrlMemberSubscriptionInfo : UserControl
    {
        public ctrlMemberSubscriptionInfo()
        {
            InitializeComponent();
        }

        private clsMembers _Member;
        private int _MemberID = -1;

        private string _LibraryCardNumber = "";
        public string LibraryCardNumber
        {
            get { return _LibraryCardNumber; }
        }
        public int MemberID
        {
            get { return _MemberID; }
        }
        public clsMembers SelectMemberInfo
        {
            get { return _Member; }
        }


        public void LoadMemberSubscriptionInfo(int MemberID)
        {
            _Member = clsMembers.FindByID(MemberID);
            if (_Member == null)
            {
                _ResetMemberSubscriptionInfo();
                MessageBox.Show("No MemberID with MemberID = " + LibraryCardNumber.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMemberSubscriptionInfo();
        }


        private void _FillMemberSubscriptionInfo()
        {
            ctrlMemberCard1.LoadMemberInfo(_Member.MemberID);
            ctrlSubscriptiomInfo1.LoadMemberSubscriptionsInfo(_Member.LasrSubscriptionID);
        }


        public void _ResetMemberSubscriptionInfo()
        {
            ctrlMemberCard1.ResetText();
            ctrlSubscriptiomInfo1.ResetText();
        }

    }
}
