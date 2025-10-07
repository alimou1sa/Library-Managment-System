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
    public partial class ctrlLoanInfo : UserControl
    {
        public ctrlLoanInfo()
        {
            InitializeComponent();
        }


        private clsLoanes _Loane;
        private int _LoanID = -1;

        public int LoanID
        {
            get { return _LoanID; }
        }
        public clsLoanes SelectLoaneInfo
        {
            get { return _Loane; }
        }

        private void _FillLoanInfo()
        {
            _LoanID = _Loane.LoanID;
            ctrlMemberCard1.LoadMemberInfo(_Loane.MemberID);
            lblLoanID.Text = _Loane.LoanID.ToString();
            lbBookName.Text=_Loane.CopyID.ToString();
            lblLoanByUser.Text=_Loane.LoanUserInfo.UserName;
            clsUsers ReturnUserInfo = clsUsers.FindByUserID(_Loane.ReturnByUserID);
            lbBookName.Text=_Loane.BookCopiesInfo.BooksInfo.Title.ToString();
            if (ReturnUserInfo != null && _Loane.ReturnByUserID != -1)
            {
                lblReturnDate.Text = _Loane.ReturnDate.ToString("yyyy:MM:dd");
                lblReturnByUser.Text = ReturnUserInfo.UserName;
                lblIsReturn.Text = "Yes";

            }
            else
                lblIsReturn.Text = "No";
            lblDueDate.Text= _Loane.DueDate.ToString("yyyy:MM:dd");
            lblLoanDate.Text= _Loane.DueDate.ToString("yyyy:MM:dd");

        }


        private void _ResetLoanInfo()
        {

            ctrlMemberCard1.ResetText();
            lblIsReturn.Text = "[???]";
            lblDueDate.Text = "[???]";
            lblLoanDate.Text = "[???]";
            lbBookName.Text = "[???]";
            lblLoanByUser.Text = "[???]";
            lblReturnDate.Text = "[???]";
            lblLoanID.Text = "[???]";
            lblReturnByUser.Text = "[???]";

        }

        public void LoadLaonInfo(int LoanID)
        {
            _Loane = clsLoanes.FindByID(LoanID);
            if (_Loane == null)
            {
                _ResetLoanInfo();
                MessageBox.Show("No Loan with LoanID = " + LoanID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLoanInfo();
        }






    }
}
