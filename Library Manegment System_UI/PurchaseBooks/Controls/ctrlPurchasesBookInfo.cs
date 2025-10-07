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
    public partial class ctrlPurchasesBookInfo : UserControl
    {
        public ctrlPurchasesBookInfo()
        {
            InitializeComponent();
        }



       private clsPurchasesBooks _purchasesBooks;
        private int _purchaseBookID;
        public int PurchaseBookID
        {
            get { return _purchaseBookID; }
        }

        public clsPurchasesBooks SelectpurchasesBooksInfo
        {
            get { return _purchasesBooks; }
        }

        public void ResetpurchasesBooksInfo()
        {
            _purchaseBookID = -1;

            lblCreateByUser.Text = "[????]";
            lblPurchaseDate.Text = "[????]";
            lblMemberID.Text = "[????]";
            lblCopiesPurchased.Text = "[????]";
            lblTotalPrice.Text = "[????]";
            lblPurchaseID.Text = "[????]";
            linkelblShowMember.Enabled = false;
            ctrBookInfo1.ResetText();

        }
        private void _FillpurchasesBookInfo()
        {
            _purchaseBookID = _purchasesBooks.PurchaseID;
            lblCreateByUser.Text = _purchasesBooks.UsersInfo.UserName;
            lblPurchaseDate.Text = _purchasesBooks.PurchaseDate.ToString("yyyy:MM:dd");
            lblPurchaseID.Text = _purchasesBooks.PurchaseID.ToString();
            lblTotalPrice.Text = _purchasesBooks.TotalPrice.ToString();
            lblCopiesPurchased.Text =_purchasesBooks.CopiesPurchased.ToString();
            lblMemberID.Text =_purchasesBooks.MemberID.ToString();
            ctrBookInfo1.LoadBookInfo(_purchasesBooks.BookID);

        }

        public void LoadPurchasesBookInfo(int ReservationID)
        {
            _purchasesBooks = clsPurchasesBooks.FindByID(ReservationID);
            if (_purchasesBooks == null)
            {
                ResetpurchasesBooksInfo();
                MessageBox.Show("No _Reservatio with ReservationID. = " + ReservationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            linkelblShowMember.Enabled = true;
            _FillpurchasesBookInfo();
        }

        private void linkelblShowMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMemberDetails frmMember = new frmMemberDetails(_purchasesBooks.MemberID);
            frmMember.ShowDialog();

        }
    }
}
