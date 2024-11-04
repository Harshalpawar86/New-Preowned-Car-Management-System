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
    public partial class EditSelfDetails : Form
    {
        long staffId;
        String connectionString = DashBoardForm.connectionString;
        public EditSelfDetails(long staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        private void EditSelfDetails_Load(object sender, EventArgs e)
        {
            LoadStaffDetails();
        }
        void LoadStaffDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = "SELECT * FROM StaffTable WHERE StaffId=@StaffId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", staffId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            StaffNameTextBox.Text = reader["StaffName"].ToString();
                            MobileNumberTextBox.Text = reader["StaffNumber"].ToString();
                            StaffEmailTextBox.Text = reader["StaffMail"].ToString();
                            AddressTextBox.Text =reader["StaffAddress"].ToString();
                            PasswordTextBox.Text = reader["StaffPassword"].ToString();
                        }
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ValidateStaffDetails()
        {
            return !string.IsNullOrEmpty(StaffNameTextBox.Text) &&
                   !string.IsNullOrEmpty(MobileNumberTextBox.Text) &&
                   long.TryParse(MobileNumberTextBox.Text, out _) &&  // Validate mobile number as a long
                   !string.IsNullOrEmpty(StaffEmailTextBox.Text) &&
                   !string.IsNullOrEmpty(AddressTextBox.Text) &&
                   !string.IsNullOrEmpty(PasswordTextBox.Text);
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            bool exception = true;

            if (ValidateStaffDetails())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        String query = @"UPDATE StaffTable 
                             SET StaffName = @StaffName, 
                                 StaffNumber = @StaffNumber, 
                                 StaffMail = @StaffMail, 
                                 StaffAddress = @StaffAddress, 
                                 StaffPassword = @StaffPassword 
                             WHERE StaffId = @StaffId";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Adding parameters to the query
                            cmd.Parameters.AddWithValue("@StaffName", StaffNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@StaffNumber", MobileNumberTextBox.Text);
                            cmd.Parameters.AddWithValue("@StaffMail", StaffEmailTextBox.Text);
                            cmd.Parameters.AddWithValue("@StaffAddress", AddressTextBox.Text);
                            cmd.Parameters.AddWithValue("@StaffPassword", PasswordTextBox.Text);
                            cmd.Parameters.AddWithValue("@StaffId", staffId);

                            // Execute the update command
                            cmd.ExecuteNonQuery();
                        }
                    }
                    exception = false;
                }
                catch (Exception exp) {

                    exception = true;
                    MessageBox.Show(exp.ToString());
                }
            }
            if (exception == false)
            {

                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Data not updated\nSomething went wrong", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
            }
        }
    }
}
