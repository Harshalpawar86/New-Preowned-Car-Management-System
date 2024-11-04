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
    public partial class ForgotPasswordForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                long staffId = long.Parse(StaffIdTextBox.Text);
                long mobileNumber = long.Parse(MobileNumberTextBox.Text);
                string newPassword = PasswordTextBox.Text;
                string userName = UserNameTextBox.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to match StaffId, MobileNumber, and UserName exactly
                    string query = "SELECT COUNT(*) FROM StaffTable WHERE StaffId = @StaffId AND StaffNumber = @MobileNumber AND StaffUserName = @UserName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        int matchCount = (int)cmd.ExecuteScalar();

                        if (matchCount > 0)
                        {
                            // Update password only if the previous details matched
                            string updateQuery = "UPDATE StaffTable SET StaffPassword = @NewPassword WHERE StaffId = @StaffId AND StaffNumber = @MobileNumber AND StaffUserName = @UserName";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                                updateCmd.Parameters.AddWithValue("@StaffId", staffId);
                                updateCmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                                updateCmd.Parameters.AddWithValue("@UserName", userName);

                                int rowsAffected = updateCmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Password updated successfully!", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                                    DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update the password...", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No matching staff found with the provided Staff ID, Mobile Number, and Username.",
                "Staff Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                        }
                    }
                }
            }
        }


        bool validateData() {

            bool temp = !string.IsNullOrEmpty(PasswordTextBox.Text) &&
                   long.TryParse(StaffIdTextBox.Text, out _) &&
                   long.TryParse(MobileNumberTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(ConfirmPasswordTextBox.Text)&&
                   !string.IsNullOrEmpty(UserNameTextBox.Text);

            if (temp == true)
            {

                if (PasswordTextBox.Text == ConfirmPasswordTextBox.Text)
                {

                    return true;
                }
                else
                {

                    MessageBox.Show("New Password doesnot match..", "Password Mismatch",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
                }
            }
            else {

                MessageBox.Show("Please Enter Valid Data", "Invalid Input",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
            return false;
        }
    }
}
