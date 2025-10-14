using DVLD.Classes;
using Guna.UI2.WinForms;
using Library;
using Library_Business;
using Library_Manegment_System.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static Library_Manegment_System.frmAddUpdatePersons;

namespace Library_Manegment_System
{
    public partial class frmAddUpdateMembers : Form
    {
        public delegate void DataBackEventHandler(object sender, int MemberID);
        public event DataBackEventHandler DataBack;

        public frmAddUpdateMembers()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateMembers(int MemberID)
        {
            InitializeComponent();
            _Mode=enMode.Update;
            _MemberID=MemberID;

        }


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int? _MemberID = null;
        clsMembers _Member;

        private  int? _SubscriptionID=null;
        clsMemberSubscriptions _MemberSubscriptions;

        private int? _PlaneID = null;
        clsMembershipPlans _MembershipPlans;

        private int ? PaymentDetailsID=null;
        clsPaymentDetails _PaymentDetails;

        private async Task _FillSubscriptionPlansInComoboBox()
        {
            DataTable dtSubscription =await  clsMembershipPlans.GetListMembershipPlans();

            foreach (DataRow row in dtSubscription.Rows)
            {
                cbPlane.Items.Add(row["PlanName"]);
            }
        }

        private async Task _FillPaymentTypeInComoboBox()
        {
            DataTable dtPayment = await  clsPaymentTypes.GetListPaymentTypes();
            foreach (DataRow row in dtPayment.Rows)
            {
                cbPaymentType.Items.Add(row["TypeName"]);
            }
        }

        private async Task _FillCountriesInComoboBox()
        {
            DataTable dtCountries = await  clsCountries.GetListCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCounties.Items.Add(row["CountryName"]);
            }
        }

        private  async Task _ResetDefualtValues()
        {
           await  _FillSubscriptionPlansInComoboBox();
           await  _FillPaymentTypeInComoboBox();
           await  _FillCountriesInComoboBox();

          
            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add New Member";
                this.Text = "Add New Member";
               _Member = new clsMembers();
                _MemberSubscriptions=new clsMemberSubscriptions();
                _PaymentDetails = new clsPaymentDetails();
                tpMembershipInfo.Enabled = false;
       
            
            }
            else
            {
                lblTitel.Text = "Update Member";
                this.Text = "Update Member";

                tpMembershipInfo.Enabled = true;
                btnSave.Enabled = true;
                cbPlane.Enabled = false;
                cbPaymentType.Enabled = false;
            }

            cbIsActive.Enabled = true ;
            chbIsSubscribtionActive.Enabled = true ;
          


            txtLibrayCardNum.Text = "";
            lblCreatedByUserID.Text =clsGlobal.CurrentUser.UserName;


            cbPaymentType.SelectedIndex = 0;
            lblPaymentDate.Text = DateTime.Now.ToString("yyyy:MM:dd");
            lblPaymentStatus.Text = clsPayments.GetPaymentStatusText(clsPayments.enPaymentStatus.Pending);


            cbSubStatus.SelectedIndex = 1;
            cbPlane.SelectedIndex = 0;
            lblStartDate.Text = DateTime.Now.ToString("yyyy:MM:dd");
   


            if (rbMale.Checked)
                pbPersonImage.Image = Resources.undraw_male_avatar_zkzx;
            else
                pbPersonImage.Image = Resources.undraw_female_avatar_7t6k;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-10);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCounties.SelectedIndex = 0;
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";


            lblCreatedByUserID.Text=clsGlobal.CurrentUser.UserName;
        }

        private void _LoadData()
        {
            if (!_MemberID.HasValue)
                return;
           
            _Member = clsMembers.FindByID(_MemberID.Value);

            if (_Member == null)
            {
                MessageBox.Show("No Member with ID = " + _MemberID, ",MemberID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            _PaymentDetails = clsPaymentDetails.FindByEntityID(_Member.SubscriptionsInfo.SubscriptionID, (byte)clsPaymentEntities.enEntityType.MemberSubscription);
            if(_PaymentDetails==null )
            {
                MessageBox.Show("No Member with ID = " + _MemberID, ",MemberID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            _MemberSubscriptions = _Member.SubscriptionsInfo;

            lblPersonID.Text = _Member.PersonID.ToString();
            txtFirstName.Text = _Member.FirstName;
            txtSecondName.Text = _Member.SecondName;
            txtThirdName.Text = _Member.ThirdName;
            txtLastName.Text = _Member.LastName;
            txtNationalNo.Text = _Member.NationalNo;
            dtpDateOfBirth.Value = _Member.DateOfBirth;

            if (_Member.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Member.Address;
            txtPhone.Text = _Member.Phone;
            txtEmail.Text = _Member.Email;
            cbCounties.SelectedIndex = cbCounties.FindString(_Member.clsCountries.CountryName);
            if (_Member.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Member.ImagePath;
            }

            llRemoveImage.Visible = (_Member.ImagePath != "");

            lblMemberID.Text = _Member.MemberID.ToString();
            txtLibrayCardNum.Text = _Member.LibraryCardNumber;
            lblCreatedByUserID.Text=_Member.CreatedByUserID.ToString();
            cbIsActive.Checked = _Member.IsActive;
          

            lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
            cbPaymentType.SelectedIndex = _PaymentDetails.PaymentTypeID - 1;
            lblPaymentDetailsID.Text = _PaymentDetails.PaymentDetailID.ToString();
            lblPaymentDate.Text = _PaymentDetails.PaymentDate.ToString("yyyy:MM:dd");
            lblPaymentStatus.Text = clsPayments.GetPaymentStatusText((clsPayments.enPaymentStatus)_PaymentDetails.PaymentStatus);

            
            cbSubStatus.SelectedIndex = _Member.SubscriptionsInfo.SubscriptionStatus - 1;
            lblSubscriptionID.Text = _Member.LastSubscriptionID.ToString();
            lblStartDate.Text = _Member.SubscriptionsInfo. StartDate.ToString("yyyy:MM:dd");
            lblEndDate.Text = _Member.SubscriptionsInfo.EndDate.ToString("yyyy:MM:dd");
            cbPlane.SelectedIndex = _Member.SubscriptionsInfo.PlanID - 1;
            chbIsSubscribtionActive.Checked = _Member.SubscriptionsInfo.IsActive;


        }

        private async void frmAddUpdateMembers_Load(object sender, EventArgs e)
        {
           await  _ResetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void DataBackEvent(object sender, int SubscriptionID)
        {
            //if(SubscriptionID!=-1)
            //{
            //    linkelblAddSubscription.Enabled = false;
            //    ctrlSubscriptiomInfo1 .Enabled = true;
            //    ctrlSubscriptiomInfo1.LoadMemberSubscriptionsInfo(SubscriptionID);
            //    cbIsActive.Checked = true;
            //}
        }
     
        private bool _HandlePersonImage()
        {

            if (_Member.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Member.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Member.ImagePath);
                    }
                    catch (IOException)
                    {

                    }

                }

                if (pbPersonImage.ImageLocation != null)
                {

                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void _FillMemberInfo()
        {
            _Member.LibraryCardNumber = txtLibrayCardNum.Text.Trim();
            _Member.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Member.IsActive = cbIsActive.Checked;

            int NationalityCountryID = clsCountries.Find(cbCounties.Text).CountryID;
            _Member.FirstName = txtFirstName.Text.Trim();
            _Member.SecondName = txtSecondName.Text.Trim();
            _Member.ThirdName = txtThirdName.Text.Trim();
            _Member.LastName = txtLastName.Text.Trim();
            _Member.NationalNo = txtNationalNo.Text.Trim();
            _Member.Email = txtEmail.Text.Trim();
            _Member.Phone = txtPhone.Text.Trim();
            _Member.Address = txtAddress.Text.Trim();
            _Member.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                _Member.Gendor = (byte)enGendor.Male;
            else
                _Member.Gendor = (byte)enGendor.Female;

            _Member.NationalityCountryID = NationalityCountryID;
            if (pbPersonImage.ImageLocation != null)
                _Member.ImagePath = pbPersonImage.ImageLocation;
            else
                _Member.ImagePath = "";
        }

        private void _FillPaymentInfo()
        {
                 _PaymentDetails.PaymentTypeID = clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID;
                _PaymentDetails.MemberID = _Member.MemberID;
                _PaymentDetails.Amount = _MembershipPlans.Price;
                _PaymentDetails.PaymentStatus = (byte)clsPayments.enPaymentStatus.Paid;
                _PaymentDetails.CreateByUserID = clsGlobal.CurrentUser.UserID;
                _PaymentDetails.PaymentDate = DateTime.Now;
                int EntityTypeID = (byte)clsPaymentEntities.enEntityType.MemberSubscription;
                _PaymentDetails.EntityTypeID = clsPaymentEntities.FindByID(EntityTypeID).EntityTypeID;

        }

        private void _FilMemberSubscriptionsInfo()
        {
            _MembershipPlans = clsMembershipPlans.FindByPlanName(cbPlane.Text);
            _MemberSubscriptions.PlanID = _MembershipPlans.PlanID;
            _MemberSubscriptions.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _MemberSubscriptions.IsActive =chbIsSubscribtionActive.Checked; 
            _MemberSubscriptions.SubscriptionStatus = clsMemberSubscriptions.GetSubscriptionStatusAsByte(cbSubStatus.Text.Trim());
              
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            if(_Mode==enMode.AddNew)
            {
        

            }


            _FillMemberInfo();

            _FilMemberSubscriptionsInfo();

            _FillPaymentInfo();
           
             /*
              
                if (_Mode == enMode.AddNew)
            {
       
            }
            else
            {
                 if (!clsMemberSubscriptions.IsSubscriptionActivByStatus((clsMemberSubscriptions
                     .enSubscriptionStatus)clsMemberSubscriptions.GetSubscriptionStatusAsByte(cbSubStatus.Text.Trim())))
                 {
                     _Member.IsActive = false;
                 }
                 else
                 {
                     _Member.IsActive = true;
                 }

                _MemberSubscriptions.SubscriptionStatus = clsMemberSubscriptions.GetSubscriptionStatusAsByte(cbSubStatus.Text.Trim());

                _PaymentDetails.PaymentTypeID = clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID;
            }
             
              */



            if (!await _Member.Save())
            {
                MessageBox.Show("Error:Payment Details  Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _PaymentDetails.MemberID = _Member.MemberID;
            _MemberSubscriptions.MemberID = _Member.MemberID;
        

            if (!await _MemberSubscriptions.Save())
            {
                MessageBox.Show("Error:Member Subscriptions  Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PaymentDetails.EntityID = _MemberSubscriptions.SubscriptionID;
            _Member.LastSubscriptionID = _MemberSubscriptions.SubscriptionID;


            if (await _PaymentDetails.Save())
            {

                lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
                lblPaymentDetailsID.Text = _PaymentDetails.PaymentDetailID.ToString();
                lblSubscriptionID.Text = _Member.LastSubscriptionID.ToString();
                lblMemberID.Text = _Member.MemberID.ToString();
                cbSubStatus.Enabled = true;
                cbPaymentType.Enabled = false;
                cbPlane.Enabled = false;
                if (_Mode == enMode.AddNew) cbSubStatus.SelectedIndex = 0;

                cbIsActive.Checked = _Member.IsActive;
                _Mode = enMode.Update;
                lblTitel.Text = "Update Member";
                this.Text = "Update Member";

                DataBack?.Invoke(this, _Member.MemberID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private async void txtLibrayCardNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLibrayCardNum.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLibrayCardNum, "Library Card Number cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtLibrayCardNum, null);
            };

            if (txtLibrayCardNum.Text.Trim() != _Member.NationalNo && await clsMembers.IsMembersExisteByLCN(txtLibrayCardNum.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLibrayCardNum, "Library Card Number  is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtLibrayCardNum, null);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                btnSave.Enabled = true;
                tpMembershipInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpMembershipInfo"];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPlane_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MembershipPlans = clsMembershipPlans.FindByPlanName(cbPlane.Text.Trim());
            if (_MembershipPlans != null)
            {
                lblEndDate.Text = DateTime.Now.Date.AddMonths(_MembershipPlans.DurationMonths).ToString("yyyy:MM:dd");
                lblSubscriptionPrice.Text = _MembershipPlans.Price.ToString();
            }
        }

        private void chbIsSubscribtionActive_CheckedChanged(object sender, EventArgs e)
        {
        //    cbIsActive.Checked = chbIsSubscribtionActive.Checked;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;

            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.undraw_male_avatar_zkzx;
            else
                pbPersonImage.Image = Resources.undraw_female_avatar_7t6k;

            llRemoveImage.Visible = false;
        }

        private async void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }


            if (txtNationalNo.Text.Trim() != _Member.NationalNo && await  clsPeople.isPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (txtEmail.Text.Trim() == "")
                return;


            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.undraw_male_avatar_zkzx;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.undraw_female_avatar_7t6k;
        }
      
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            Guna2TextBox Temp = ((Guna2TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {

                errorProvider1.SetError(Temp, null);
            }
        }

        private void cbSubStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbSubStatus.Text))
                return;
            
            if (!clsMemberSubscriptions.IsSubscriptionActivByStatus((clsMemberSubscriptions.enSubscriptionStatus)clsMemberSubscriptions.GetSubscriptionStatusAsByte(cbSubStatus.Text.Trim())))
            {
                chbIsSubscribtionActive.Checked = false;
                cbIsActive.Checked = false;
       
            }

        }
   
    
    }
}
