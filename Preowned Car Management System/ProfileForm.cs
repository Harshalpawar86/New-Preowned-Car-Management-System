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
    public partial class ProfileForm : Form
    {
        long staffId;
        String coonectionString = DashBoardForm.connectionString;
        public ProfileForm(long id)
        {
            staffId = id;
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadStaffDetails();
        }
        void LoadStaffDetails() {
            using (SqlConnection conn = new SqlConnection(coonectionString)) {
                conn.Open();
                String query = "SELECT * FROM StaffTable WHERE StaffId=@StaffId";
                using (SqlCommand cmd = new SqlCommand(query,conn)) {
                    cmd.Parameters.AddWithValue("@StaffId",staffId);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        if (reader.Read()) {

                            UserNameLabel.Text = "UserName : "+reader["StaffUserName"].ToString();
                            StaffNameLabel.Text = "Name : " + reader["StaffName"].ToString();
                            StaffIdLabel.Text = "Staff Id : " + reader["StaffId"].ToString();
                            StaffGenderLabel.Text = "Gender : " + reader["StaffGender"].ToString();
                            StaffDOBLabel.Text = "Date Of Birth : " + reader["StaffDOB"].ToString();
                            StaffNumberLabel.Text = "Mobile Number : " + reader["StaffNumber"].ToString();
                            StaffGmailLabel.Text = "G-Mail : " + reader["StaffMail"].ToString();
                            StaffAddressLabel.Text = "Address : " + reader["StaffAddress"].ToString();
                            StaffJobLabel.Text = "Job Designation : " + reader["StaffJob"].ToString();
                        }
                    }
                }
                conn.Close();
            }
        }

        private void EditProfilePanel_Click(object sender, EventArgs e)
        {
            EditProfile();
        }
        void EditProfile() {

            EditSelfDetails form = new EditSelfDetails(staffId);
            if (form.ShowDialog() == DialogResult.OK)
            {

                
                MessageBox.Show("Data Updated Successfully", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                LoadStaffDetails();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            EditProfile();
        }
    }
}
