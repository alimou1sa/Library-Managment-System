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
using System.Xml.Linq;

namespace Library_Manegment_System
{
    public partial class frmAddUpdateAuther_Publisher : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        public enum enFormType { Auther = 0, Publisher = 1 };
        enFormType _FormType = enFormType.Auther;

        string _Value = "";


        public delegate void DataBackEventHandler(object sender, string Name);
      
        public event DataBackEventHandler DataBack;
        public frmAddUpdateAuther_Publisher(bool IsAuther)
        {
            InitializeComponent();

            if (IsAuther)
                _FormType=enFormType.Auther;
            else
                _FormType =enFormType.Publisher;

            
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateAuther_Publisher(bool IsAuther,string Value)
        {
            InitializeComponent();
            if (IsAuther)
                _FormType = enFormType.Auther;
            else
                _FormType = enFormType.Publisher;

            _Mode = enMode.Update;
            
            _Value = Value;
        }


        clsAuthors  _Authors=null;
        clsPublishers _Publishers=null;


        private void _ResetDefualtValues()
        {


            if (_Mode == enMode.AddNew)
            {
                if (_FormType == enFormType.Auther)
                {
                    lblTitl.Text = "Add New Auther";
                    this.Text = "Add New Auther";
                    lbl2.Visible = false;
                    txt2.Visible = false;
                    lbl3.Text = "Bio:";
                    _Authors = new clsAuthors();
                }
                else if (_FormType == enFormType.Publisher)
                {
                    lblTitl.Text = "Add New Publisher";
                    this.Text = "Add New Publisher";
            
                    lbl3.Text = "Phone:";
                    lbl2.Text = "Address:";


                    _Publishers = new clsPublishers();
                }

            }
            else
            {
                if (_FormType == enFormType.Auther)
                {
                    lblTitl.Text = "Update Auther";
                    this.Text = "Update Auther";
                    lbl2.Visible = false;
                    txt2.Visible = false;
                    lbl3.Text = "Bio:";
                }
                else if (_FormType == enFormType.Publisher)
                {
                    lblTitl.Text = "Update Category";
                    this.Text = "Update Category";
                    lbl3.Text = "Phone:";
                    lbl2.Text = "Address:";
                }

            }

            txtName.Text = "";

        }
        private void _LoadData()
        {

            if (_FormType == enFormType.Auther)
            {
                _Authors = clsAuthors.Find(_Value);

                if (_Authors == null)
                {
                    MessageBox.Show("No Authors with Name = " + _Value, " Authors Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                txtName.Text=_Authors.Name;
                txt3.Text=_Authors.BIi;
                lblID.Text = _Authors.AutherID.ToString();

            }
            else if (_FormType == enFormType.Publisher)
            {
                _Publishers =clsPublishers.FindByPublisgerName(_Value);

                if (_Publishers == null)
                {
                    MessageBox.Show("No Publishers with  = " + _Value, "Publishers Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                lblID.Text = _Publishers.PublisherID.ToString();
                txtName.Text = _Publishers.Name;
                txt3.Text = _Publishers.Phone;
                txt2.Text=_Publishers.Address;
            }

        }

        private void frmAddUpdateAuther_Publisher_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "This field is required!");
            }
            else
            {

                errorProvider1.SetError(txtName, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_FormType == enFormType.Auther)
            {

                _Authors.Name = txtName.Text;
                _Authors.BIi=txt3.Text;
                

                if (await  _Authors.Save())
                {
                    lblID.Text = _Authors.AutherID.ToString();

                    _Mode = enMode.Update;
                    lblTitl.Text = "Update Authors";
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataBack?.Invoke(this, _Authors.Name);
                }
                else
                    MessageBox.Show("Error: Data Is not Safully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            if (_FormType == enFormType.Publisher)
            {
                _Publishers.Name = txtName.Text;
                _Publishers.Address=txt2.Text;
                _Publishers.Phone=txt3.Text.Trim();

                if (await  _Publishers.Save())
                {
                    lblID.Text = _Publishers.PublisherID.ToString();

                    _Mode = enMode.Update;
                    lblTitl.Text = "Update Publishers";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    DataBack?.Invoke(this, _Publishers.Name);
                }
                else
                    MessageBox.Show("Error: Data Is not Safully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
