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
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            NupDDefultBorrowDays.Value= clsSettings.GetDefualtBorrrowDays();
            NupDDefultLateFineParDay.Value=clsSettings.GetDefualtFineDays();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsSettings.UpdateSettings((int)NupDDefultBorrowDays.Value, (int)NupDDefultLateFineParDay.Value))
                MessageBox.Show("Settings Saved Succesfully");
        }
    }
}
