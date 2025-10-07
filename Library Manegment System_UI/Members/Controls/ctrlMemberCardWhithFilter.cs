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
    public partial class ctrlMemberCardWhithFilter : UserControl
    {

        public class MemberSelectedEventArgs : EventArgs
        {
            public int MemberID { get; }
            public string LibraryCardNumber { get; }

            public MemberSelectedEventArgs(int MemberID, string LibraryCardNumber)
            {
                this.MemberID = MemberID;
                this.LibraryCardNumber = LibraryCardNumber;

            }
        }

        public event EventHandler<MemberSelectedEventArgs> OnMemberSelected;

        public void MemberSelected(int PersonID, string NationalNo)
        {
            MemberSelected(new MemberSelectedEventArgs(PersonID, NationalNo));
        }

        protected virtual void MemberSelected(MemberSelectedEventArgs e)
        {
            OnMemberSelected?.Invoke(this, e);
        }


        private bool _ShowAddMember = true;
        public bool ShowAddMember
        {
            get
            {
                return _ShowAddMember;
            }
            set
            {
                _ShowAddMember = value;
                btnAddNewMember.Visible = _ShowAddMember;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public ctrlMemberCardWhithFilter()
        {
            InitializeComponent();
        }


        private int _MemberID = -1;

        public int MemberID
        {
            get { return ctrlMemberCard1.MemberID; }
        }

        public clsMembers SelectedMemberInfo
        {
            get { return ctrlMemberCard1.SelectMemberInfo; }
        }

        public void LoadMemberInfo(int MemberID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = MemberID.ToString();
            FindNow();

        }
        private void FindNow()
        {

            switch (cbFilterBy.Text)
            {
                case "Member ID":
                    ctrlMemberCard1.LoadMemberInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "ISBN":
                    ctrlMemberCard1.LoadMemberInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnMemberSelected != null && FilterEnabled)
                MemberSelected(ctrlMemberCard1.MemberID,ctrlMemberCard1.LibraryCardNumber);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                //e.co = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void ctrlMemberCardWhithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
        private void DataBackEvent(object sender, int MemberID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = MemberID.ToString();
            ctrlMemberCard1.LoadMemberInfo(MemberID);
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddUpdateMembers frm1 = new frmAddUpdateMembers();
            frm1.DataBack += DataBackEvent;
            frm1.ShowDialog();
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            if (cbFilterBy.Text == "Member ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctrlMemberCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
