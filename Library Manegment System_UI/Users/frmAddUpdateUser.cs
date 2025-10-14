using DVLD.Classes;
using Guna.UI2.WinForms;
using Library_Business;
using Library_Manegment_System.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library_Manegment_System.frmAddUpdatePersons;

namespace Library_Manegment_System
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode=enMode.Update;
            _UserID=UserID;
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUsers _User;

        private async Task  _FillCountriesInComoboBox()
        {
            DataTable dtCountries = await  clsCountries.GetListCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private async Task  _ResetDefualtValues()
        {
           await  _FillCountriesInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUsers();
                tpUserInfo .Enabled = false;

            }
            else
            {
                lblTitel.Text = "Update User";
                this.Text = "Update User";

                tpUserInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            txtUserName.Text = "";
            txtConfirmPassword.Text = "";
            txtJobTitle.Text = "";
            txtPassword.Text = "";
            txtSalary.Text = "";
            cbIsActive.Checked = true;
            chbFullAccess.Checked = true;


            if (rbMale.Checked)
                pbPersonImage.Image = Resources.undraw_male_avatar_zkzx;
            else
                pbPersonImage.Image = Resources.undraw_female_avatar_7t6k;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-20);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);


            cbCountry.SelectedIndex = 1;
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _LoadData()
        {

            _User  = clsUsers .FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }


            lblUserID.Text = _User.UserID.ToString();
            txtUserName .Text = _User.UserName.ToString();
            txtSalary .Text = _User.Salary.ToString();
            txtPassword.Text = clsUtil.Decrypt(_User.Password.ToString(),clsUtil.Key);
            txtConfirmPassword.Text =txtPassword.Text.ToString();
            cbIsActive.Checked = _User.IsActive;
            txtJobTitle .Text = _User.JobTitle.ToString();


            lblPersonID.Text = _User.PersonID.ToString();
            txtFirstName.Text = _User.FirstName;
            txtSecondName.Text = _User.SecondName;
            txtThirdName.Text = _User.ThirdName;
            txtLastName.Text = _User.LastName;
            txtNationalNo.Text = _User.NationalNo;
            dtpDateOfBirth.Value = _User.DateOfBirth;

            if (_User.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _User.Address;
            txtPhone.Text = _User.Phone;
            txtEmail.Text = _User.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_User.clsCountries.CountryName);


            if (_User.ImagePath != "")
                pbPersonImage.ImageLocation = _User.ImagePath;
          

            llRemoveImage.Visible = (_User.ImagePath != "");


            FillCheckBoxPermissions(_User.Permissions);
        }

        private int _ReadPermissionsToSet()
        {

            int Permissions = 0;

            if (chbFullAccess.Checked)
            {
                Permissions += (int)clsUsers.enPermissions.FullAccess;
                return Permissions;
            }
            if (chbManageMember.Checked)
                Permissions += (int)clsUsers.enPermissions.ManageMembers;
            if (chbManagrBooks.Checked)
                Permissions += (int)clsUsers.enPermissions.ManageBooks;
            if (chbMenageUsers.Checked)
                Permissions += (int)clsUsers.enPermissions.ManageUsers;
            if (chbManageLoan.Checked)
                Permissions += (int)clsUsers.enPermissions.ManageLoan;
            if (chbManageReservations.Checked)
                Permissions += (int)clsUsers.enPermissions.ManageReservation;
            if (chbManagePayments.Checked)
                Permissions += (int)clsUsers.enPermissions.ManagePayments;
            if (chbManagePurchases.Checked)
                Permissions += (int)clsUsers.enPermissions.ManagePurchasesBook;

            return Permissions;
        }

        private async void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (!_AllItemChecked())
            {
                chbFullAccess.Checked = false;
            }
            else
            {
                chbFullAccess.Checked = true;
            }


           await  _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        public void Clear()
        {
            foreach (CheckBox item in gbPermissions.Controls)
            {
                item.Checked = false;
            }

        }

        public void FillCheckBoxPermissions(int Permissions)
        {
            if (Permissions == -1)
            {
                chbFullAccess.Checked = true;
                return;
            }
            chbFullAccess.Checked = false;
            foreach (Guna2CheckBox item in gbPermissions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if (_User.CheckAccessPermission((clsUsers.enPermissions)(Convert.ToInt32(item.Tag))))
                        item.Checked = true;
                    
                    else
                        item.Checked = false;
                }
            }

        }

        private bool _HandlePersonImage()
        {

            if (_User.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_User.ImagePath != "")
                {

                    try
                    {
                        File.Delete(_User.ImagePath);
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;

            int NationalityCountryID = clsCountries.Find(cbCountry.Text).CountryID;

            _User.FirstName = txtFirstName.Text.Trim();
            _User.SecondName = txtSecondName.Text.Trim();
            _User.ThirdName = txtThirdName.Text.Trim();
            _User.LastName = txtLastName.Text.Trim();
            _User.NationalNo = txtNationalNo.Text.Trim();
            _User.Email = txtEmail.Text.Trim();
            _User.Phone = txtPhone.Text.Trim();
            _User.Address = txtAddress.Text.Trim();
            _User.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _User.Gendor = (byte)enGendor.Male;
            else
                _User.Gendor = (byte)enGendor.Female;

            _User.NationalityCountryID = NationalityCountryID;

            if (pbPersonImage.ImageLocation != null)
                _User.ImagePath = pbPersonImage.ImageLocation;
            else
                _User.ImagePath = "";


            _User.UserName = txtUserName.Text.Trim();
            _User.Salary =Convert.ToDouble( txtSalary.Text);
            _User.JobTitle = txtJobTitle.Text.Trim();
            if(txtPassword.Text.Trim()==txtConfirmPassword.Text.Trim())
                _User.Password =clsUtil.Encrypt(txtConfirmPassword.Text.Trim(),clsUtil.Key);

            _User.IsActive = cbIsActive.Checked;
            _User.Permissions = _ReadPermissionsToSet();

            if (await _User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                lblPersonID.Text = _User.PersonID.ToString();
                _Mode = enMode.Update;
                lblTitel.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private async void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            };


            if (_Mode == enMode.AddNew)
            {

                if (await  clsUsers .isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (await  clsUsers .isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        { 

                    btnSave.Enabled = true;
                    tpUserInfo.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tpUserInfo"];
   
        }

        private void frmAddUpdateUser_Validated(object sender, EventArgs e)
        { 
        }

        private void txtJobTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtJobTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtJobTitle, "Job Title cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtJobTitle, null);
            };
        }

        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSalary, "Salary cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtSalary, null);
            };
        }


        private bool _AllItemChecked()
        {
            foreach (Guna2CheckBox item in gbPermissions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if (!item.Checked)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        private void chbFullAccess_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Guna2CheckBox item in gbPermissions.Controls)
            {
                item.Checked = chbFullAccess.Checked;

            }
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


            if (txtNationalNo.Text.Trim() != _User.NationalNo &&await  clsPeople.isPersonExist(txtNationalNo.Text.Trim()))
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


            TextBox Temp = ((TextBox)sender);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
