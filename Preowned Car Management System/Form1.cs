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
    public partial class LoginForm : Form
    {
        String connectionString = DashBoardForm.connectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Check for empty fields first
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate login and get staffId
            if (ValidateLogin(username, password, out long id))
            {
                DashBoardForm form = new DashBoardForm(this,id);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLogin(string username, string password, out long id)
        {
            id = -1; // Initialize to an invalid ID

            string query = "SELECT StaffId FROM StaffTable WHERE StaffUserName = @username AND StaffPassword = @password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query
                    {
                        if (reader.Read()) // Read the result
                        {
                            id = Convert.ToInt64(reader["StaffId"]); // Get the staffId from the first column
                                                                     //  MessageBox.Show("In LoginForm Id : "+id);
                            return true; // Valid credentials
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false; // Invalid credentials
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }

}
