using Guna.UI2.HtmlRenderer.Adapters;
using Library_Business;
using Library_Manegment_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library_Manegment_System.frmAddUpdatePersons;

namespace Library_Manegment_System
{
    public partial class frmAdd_UpdateGenresAndCategories : Form
    {
        public frmAdd_UpdateGenresAndCategories(bool IsGenre)
        {
            InitializeComponent();

            if(IsGenre) 
                _FormType=enFormType.Genre;
            else
                _FormType=enFormType.Category;

            _Mode=enMode.AddNew;
        }
        public frmAdd_UpdateGenresAndCategories(string  Name,bool IsGenre)
        {
            InitializeComponent();
            if (IsGenre)
                _FormType = enFormType.Genre;
            else
                _FormType = enFormType.Category;


           _Name = Name;
            _Mode = enMode.Update;
        }
        public delegate void DataBackEventHandler(object sender, string Name);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        public enum enFormType { Genre = 0, Category = 1 };
        enFormType _FormType = enFormType.Genre;
        private string  _Name ="";


        clsGenres _Genres = null;
        clsCategories _Categories = null;

        private void _ResetDefualtValues()
        {


            if (_Mode == enMode.AddNew)
            {
                if(_FormType == enFormType.Genre)
                {
                    lblTitl.Text = "Add New Genre";
                    this.Text = "Add New Genre";
                    lblTypeName.Text = "Genre Name:";
                    _Genres = new clsGenres();
                }
                else if(_FormType == enFormType.Category)
                {
                    lblTitl.Text = "Add New Category";
                    this.Text = "Add New Category";
                    lblTypeName.Text = "Category Name:";
                    _Categories = new clsCategories();
                }

            }
            else
            {
                if (_FormType == enFormType.Genre)
                {
                    lblTitl.Text = "Update Genre";
                    this.Text = "Update Genre";
                    lblTypeName.Text = "Genre Name:";
                }
                else if (_FormType == enFormType.Category)
                {
                    lblTitl.Text = "Update Category";
                    this.Text = "Update Category";
                    lblTypeName.Text = "Category Name:";

                }

            }

            txtName.Text = "";

        }

        private void _LoadData()
        {

            if (_FormType == enFormType.Genre)
            {
               _Genres=clsGenres.FindByGenreNAme(_Name);

                if (_Genres == null)
                {
                    MessageBox.Show("No Genres with Name = " + _Name, "Genres Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                txtName.Text =_Genres.GenreName;
                lblID.Text=_Genres.GenreID.ToString();

            }
            else if (_FormType == enFormType.Category)
            {
                _Categories = clsCategories.Find(_Name);

                if (_Categories == null)
                {
                    MessageBox.Show("No Categories with  = " + _Name, "Genres Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                lblID.Text = _Categories.CategoryID.ToString();
                txtName.Text =_Categories.CategoryName;
            }

        }

        private void frmAdd_UpdateGenresAndCategories_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode==enMode.Update)
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
            this .Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if(_FormType==enFormType.Genre)
            {

                _Genres.GenreName = txtName.Text;


                if ( await _Genres.Save())
                {
                    lblID.Text = _Genres.GenreID.ToString();

                    _Mode = enMode.Update;
                    lblTitl.Text = "Update Genre";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    DataBack?.Invoke(this, _Genres.GenreName);
                }
                else
                    MessageBox.Show("Error: Data Is not Safully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            if (_FormType==enFormType.Category)
            {
                _Categories.CategoryName = txtName.Text;

                if (await  _Categories.Save())
                {
                    lblID.Text = _Categories.CategoryID.ToString();

                    _Mode = enMode.Update;
                    lblTitl.Text = "Update Category";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    DataBack?.Invoke(this, _Categories.CategoryName);
                }
                else
                    MessageBox.Show("Error: Data Is not Safully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
