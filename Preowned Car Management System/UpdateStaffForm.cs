using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class UpdateStaffForm : Form
    {
        public String staffName { get; set; }
        public long staffMobileNumber { get; set; }
        public String staffEmail { get; set; }



        public String staffAddress { get; set; }
        public String staffJob { get; set; }
        public String password { get; set; }


        public UpdateStaffForm()
        {
            InitializeComponent();
        }

        private void UpdateStaffForm_Load(object sender, EventArgs e)
        {
            StaffNameTextBox.Text = staffName;
            MobileNumberTextBox.Text = staffMobileNumber.ToString();
            StaffEmailTextBox.Text = staffEmail;
            AddressTextBox.Text = staffAddress;
            JobDesignationComboBox.Text = staffJob;
            PasswordTextBox.Text = password;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                staffName = StaffNameTextBox.Text;
                staffMobileNumber = Convert.ToInt64(MobileNumberTextBox.Text);
                staffAddress = AddressTextBox.Text;
                staffEmail = StaffEmailTextBox.Text;
                staffJob = JobDesignationComboBox.Text;
                password = PasswordTextBox.Text;

                DialogResult = DialogResult.OK;

            }
            else
            {

                MessageBox.Show("Please Enter Valid Data");
            }
        }
        private bool ValidateData()
        {
            return !string.IsNullOrEmpty(StaffNameTextBox.Text) &&
                   !string.IsNullOrEmpty(StaffEmailTextBox.Text) &&
                   !string.IsNullOrEmpty(PasswordTextBox.Text) &&
                   !string.IsNullOrEmpty(JobDesignationComboBox.Text) &&
                   long.TryParse(MobileNumberTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(AddressTextBox.Text);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
