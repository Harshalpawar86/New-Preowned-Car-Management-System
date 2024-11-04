using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class AddStaffInfoForm : Form
    {
        public String staffName { get; set; }
        public String staffGender { get; set; }
        public String staffBOD { get; set; }
        public long staffMobileNumber { get; set; }
        public String staffEmail { get; set; }
        public String staffAddress { get; set; }
        public String jobDesignation { get; set; }
        public String userName { get; set; }
        public String password { get; set; }

        public long staffId { get; set; }

        String connectionString = DashBoardForm.connectionString;

        public AddStaffInfoForm()
        {
            InitializeComponent();
        }

        private void AddStaffInfoForm_Load(object sender, EventArgs e)
        {
            LoadStaffId();
        }
        void LoadStaffId() {

            long lastSupplierId = 401;
            string queryStock = "SELECT MAX(StaffId) FROM StaffTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryStock, conn);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    lastSupplierId = Convert.ToInt64(result) + 1;
                }
                //else
                //{
                //    string queryHistory = "SELECT MAX(SupplierId) FROM HistoryTable";
                //    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                //    var result2 = cmd2.ExecuteScalar();

                //    if (result2 != DBNull.Value && result2 != null)
                //    {
                //        lastSupplierId = Convert.ToInt64(result2) + 1;
                //    }
                //}
            }

            StaffIdTextBox.Text = lastSupplierId.ToString();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (validateData() == false)
            {
                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Please Enter Valid Data", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
            }
        }
        bool validateData() {
            bool exception = false;
            try
            {
                staffName = StaffNameTextBox.Text;
                staffGender = GenderComboBox.Text;
                staffMobileNumber = Convert.ToInt64(textBox2.Text);
                staffEmail = StaffEmailTextBox.Text;
                staffBOD = dateTimePicker1.Value.Date.ToString("d");
                staffAddress = richTextBox1.Text;
                staffId = Convert.ToInt32(StaffIdTextBox.Text);
                jobDesignation = JobDesignationComboBox.Text;
                userName = UserNameTextBox.Text;
                password = PasswordTextBox.Text;
                exception = false;
            }
            catch (Exception exp) {

                exception = true;
            }
            if (exception == false) {

                if (staffMobileNumber.ToString().Length != 10)
                {
                    MessageBox.Show("Please Enter Valid Mobile Number ..", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                    return true;
                }
                else if (staffEmail.EndsWith("@gmail.com") == false)
                {

                    MessageBox.Show("Please Enter Valid G-mail ..", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                    return true;
                }
                else {

                    return false;
                }
            }
            return true;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void StaffNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                GenderComboBox.Focus();
            }
        }

      

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                StaffEmailTextBox.Focus();
            }
        }

        private void StaffEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                richTextBox1.Focus();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                JobDesignationComboBox.Focus();
            }
        }

        private void UserNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PasswordTextBox.Focus();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                OKButton.Focus();
            }
        }

        private void GenderComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox2.Focus();
            }
        }

        private void JobDesignationComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                UserNameTextBox.Focus();
            }
        }
    }
}
