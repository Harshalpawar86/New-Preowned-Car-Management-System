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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class StaffForm : Form
    {
        ContextMenuStrip contextMenu;
        String connectionString = DashBoardForm.connectionString;
        public StaffForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update Information", null, ContextMenuOption1_Click);
        }
        public void AddStaffInfoFun(String userName,String staffName, String staffBOD,long staffId, String staffGender, int staffMobileNumber, String staffEmail, String staffAddress, String jobDesignation)
        {
            Panel panel = new Panel();
            panel.Name = "StaffData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Tag = staffId;

            Label StaffUserNameLabel = new Label();
            StaffUserNameLabel.Name = "StaffUserName";
            StaffUserNameLabel.Text = "UserName : " + userName;
            StaffUserNameLabel.Location = new Point(12, 5);
            StaffUserNameLabel.ForeColor = Color.Black;
            StaffUserNameLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffUserNameLabel.AutoSize = true;

            Label StaffNameLabel = new Label();
            StaffNameLabel.Name = "StaffNameLabel";
            StaffNameLabel.Text = "Name : " + staffName;
            StaffNameLabel.Location = new Point(12, StaffUserNameLabel.Bottom+2);
            StaffNameLabel.ForeColor = Color.Black;
            StaffNameLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffNameLabel.AutoSize = true;

            Label StaffIdLabel = new Label();
            StaffIdLabel.Name = "StaffIdLabel";
            StaffIdLabel.Text = "Staff Id : " + staffId.ToString();
            StaffIdLabel.Location = new Point(12,StaffNameLabel.Bottom + 2);
            StaffIdLabel.ForeColor = Color.Black;
            StaffIdLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffIdLabel.AutoSize = true;

            Label StaffGenderLabel = new Label();
            StaffGenderLabel.Name = "StaffGenderLabel";
            StaffGenderLabel.Text = "Gender : " + staffGender;
            StaffGenderLabel.Location = new Point(12, StaffIdLabel.Bottom + 2); // Reduced the gap
            StaffGenderLabel.ForeColor = Color.Black;
            StaffGenderLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffGenderLabel.AutoSize = true;

            Label StaffMobileNumberLabel = new Label();
            StaffMobileNumberLabel.Name = "StaffMobileNumberLabel";
            StaffMobileNumberLabel.Text = "Mobile Number : " + staffMobileNumber.ToString();
            StaffMobileNumberLabel.Location = new Point(12, StaffGenderLabel.Bottom + 2); // Reduced the gap
            StaffMobileNumberLabel.ForeColor = Color.Black;
            StaffMobileNumberLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffMobileNumberLabel.AutoSize = true;

            Label StaffDateOfBirthLabel = new Label();
            StaffDateOfBirthLabel.Name = "StaffDateOfBirthLabel";
            StaffDateOfBirthLabel.Text = "Birth Date : " + staffBOD;
            StaffDateOfBirthLabel.Location = new Point(12, StaffMobileNumberLabel.Bottom + 2); // Reduced the gap
            StaffDateOfBirthLabel.ForeColor = Color.Black;
            StaffDateOfBirthLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffDateOfBirthLabel.AutoSize = true;

            Label StaffEmailLabel = new Label();
            StaffEmailLabel.Name = "StaffEmailLabel";
            StaffEmailLabel.Text = "Email : " + staffEmail;
            StaffEmailLabel.Location = new Point(12, StaffDateOfBirthLabel.Bottom + 2); // Reduced the gap
            StaffEmailLabel.ForeColor = Color.Black;
            StaffEmailLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffEmailLabel.AutoSize = true;

            Label JobDesignationLabel = new Label();
            JobDesignationLabel.Name = "JobDesignationLabel";
            JobDesignationLabel.Text = "Job Designation : " + jobDesignation;
            JobDesignationLabel.Location = new Point(12, StaffEmailLabel.Bottom + 2); // Reduced the gap
            JobDesignationLabel.ForeColor = Color.Black;
            JobDesignationLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            JobDesignationLabel.AutoSize = true;

            Label StaffaddressLabel = new Label();
            StaffaddressLabel.Name = "StaffaddressLabel";
            StaffaddressLabel.Text = "Address : " + staffAddress;
            StaffaddressLabel.Location = new Point(12, JobDesignationLabel.Bottom + 2); // Reduced the gap
            StaffaddressLabel.ForeColor = Color.Black;
            StaffaddressLabel.Font = new Font("Modern No. 20", 9.5f, FontStyle.Regular);
            StaffaddressLabel.AutoSize = true;
            StaffaddressLabel.MaximumSize = new Size(200, 0); // Setting the maximum size to constrain width

            panel.Controls.Add(StaffUserNameLabel);
            panel.Controls.Add(StaffNameLabel);
            panel.Controls.Add(StaffIdLabel);
            panel.Controls.Add(StaffGenderLabel);
            panel.Controls.Add(StaffMobileNumberLabel);
            panel.Controls.Add(StaffDateOfBirthLabel);
            panel.Controls.Add(StaffEmailLabel);
            panel.Controls.Add(JobDesignationLabel);
            panel.Controls.Add(StaffaddressLabel);

            panel.MouseClick += Panel_MouseClick;
            StaffNameLabel.MouseClick += Panel_MouseClick;
            StaffGenderLabel.MouseClick += Panel_MouseClick;
            StaffMobileNumberLabel.MouseClick += Panel_MouseClick;
            StaffDateOfBirthLabel.MouseClick += Panel_MouseClick;
            StaffEmailLabel.MouseClick += Panel_MouseClick;
            JobDesignationLabel.MouseClick += Panel_MouseClick;
            StaffaddressLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel panel = sender as Panel;
                if (panel != null)
                {
                    contextMenu.Show(panel, e.Location);
                }
            }
        }

        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl is Panel panel)
            {

                long staffId = (long)panel.Tag;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "SELECT * FROM StaffTable WHERE StaffId = @StaffId ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {

                            UpdateStaffForm updateStaffForm = new UpdateStaffForm();
                            updateStaffForm.staffName = reader["StaffName"].ToString();
                            updateStaffForm.staffMobileNumber = Convert.ToInt32(reader["StaffNumber"]);
                            updateStaffForm.staffEmail = reader["StaffMail"].ToString();
                            updateStaffForm.staffAddress= reader["StaffAddress"].ToString();
                            updateStaffForm.staffJob = reader["StaffJob"].ToString();
                            updateStaffForm.password = reader["StaffPassword"].ToString();

                            if (updateStaffForm.ShowDialog() == DialogResult.OK)
                            {

                                String updateQuery = "UPDATE StaffTable SET StaffName = @StaffName, StaffNumber = @StaffNumber, StaffMail = @StaffMail, StaffAddress = @StaffAddress, StaffJob = @StaffJob WHERE StaffId = @StaffId";
                                using (SqlCommand upd = new SqlCommand(updateQuery, conn))
                                {

                                    upd.Parameters.AddWithValue("@StaffName", updateStaffForm.staffName);
                                    upd.Parameters.AddWithValue("@StaffNumber", updateStaffForm.staffMobileNumber);
                                    upd.Parameters.AddWithValue("@StaffMail", updateStaffForm.staffEmail);
                                    upd.Parameters.AddWithValue("@StaffAddress", updateStaffForm.staffAddress);
                                    upd.Parameters.AddWithValue("StaffJob",updateStaffForm.staffJob);
                                    upd.Parameters.AddWithValue("@StaffId", staffId);
                                    upd.Parameters.AddWithValue("@StaffPassword",updateStaffForm.password);

                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                    if (result > 0)
                                    {

                                        MessageBox.Show("Staff Data Updated Successfully");
                                        flowLayoutPanel1.Controls.Clear();
                                        LoadExistingData();
                                    }
                                    else
                                    {

                                        MessageBox.Show("Failed to Update Data");
                                    }

                                }

                            }
                        }
                    }
                }
            }
        }

        private void LoadExistingData()
        {
            
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from StaffTable;";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        foreach (DataRow row in datatable.Rows)

                        {

                            String staffName = row["StaffName"].ToString();
                            String staffGender = row["StaffGender"].ToString();
                            String staffDOB = row["StaffDOB"].ToString();
                            int staffNumber = Convert.ToInt32(row["StaffNumber"]);
                            String staffMail = row["StaffMail"].ToString();
                            String staffAddress = row["StaffAddress"].ToString();
                            String staffJob = row["StaffJob"].ToString();
                            long staffId = Convert.ToInt64(row["StaffId"]);
                        String userName = row["StaffUserName"].ToString();

                            AddStaffInfoFun(userName:userName,staffName: staffName, staffBOD: staffDOB, staffGender: staffGender, staffMobileNumber: staffNumber,staffId:staffId, staffEmail: staffMail, staffAddress: staffAddress, jobDesignation: staffJob); 
                            }
                        }
                }
            
  
        }


        private void AddStaffButton_Click(object sender, EventArgs e)
        {

            


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Car Name to Search");

            }
            else
            {
                searchStaff(SearchTextBox.Text);

            }
        }
        private void searchStaff(String name) {

            flowLayoutPanel1.Controls.Clear();
            try
            {

                String query = "SELECT * FROM StaffTable WHERE StaffName=@StaffName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("StaffName", name);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String staffName = reader["StaffName"].ToString();
                                String staffBOD = reader["StaffDOB"].ToString();
                                long staffId = Convert.ToInt64(reader["StaffId"]);
                                String staffGender = reader["StaffGender"].ToString();
                                int staffMobileNumber = Convert.ToInt32(reader["StaffNumber"]);
                                String staffEmail = reader["StaffMail"].ToString();
                                String staffAddress = reader["StaffAddress"].ToString();
                                String jobDesignation = reader["StaffJob"].ToString();
                                String userName = reader["StaffUserName"].ToString();

                                AddStaffInfoFun(userName:userName,staffName: staffName, staffBOD: staffBOD, staffGender: staffGender, staffMobileNumber: staffMobileNumber, staffId: staffId, staffEmail: staffEmail, staffAddress: staffAddress, jobDesignation: jobDesignation);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Staff not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SearchTextBox.Clear();
            LoadExistingData();
        }

        private void AddStaffButton_Click_1(object sender, EventArgs e)
        {
            AddStaffInfoForm addStaffInfoForm = new AddStaffInfoForm();
            try
            {

                if (addStaffInfoForm.ShowDialog() == DialogResult.OK)
                {
                    String StaffName = addStaffInfoForm.staffName;
                    String StaffGender = addStaffInfoForm.staffGender;
                    String StaffDOB = addStaffInfoForm.staffBOD;
                    int StaffNumber = addStaffInfoForm.staffMobileNumber;
                    String StaffMail = addStaffInfoForm.staffEmail;
                    String StaffAddress = addStaffInfoForm.staffAddress;
                    String StaffJob = addStaffInfoForm.jobDesignation;
                    long staffId = addStaffInfoForm.staffId;
                    String userName = addStaffInfoForm.userName;
                    String password = addStaffInfoForm.password;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO StaffTable (StaffName, StaffGender, StaffDOB, StaffNumber, StaffMail,StaffAddress,StaffJob,StaffId,StaffUserName,StaffPassword) " +
                                       "VALUES (@StaffName, @StaffGender, @StaffDOB, @StaffNumber, @StaffMail,@StaffAddress,@StaffJob,@StaffId,@StaffUserName,@StaffPassword)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StaffName", StaffName);
                            cmd.Parameters.AddWithValue("@StaffGender", StaffGender);
                            cmd.Parameters.AddWithValue("@StaffDOB", StaffDOB);
                            cmd.Parameters.AddWithValue("@StaffNumber", StaffNumber);
                            cmd.Parameters.AddWithValue("@StaffMail", StaffMail);
                            cmd.Parameters.AddWithValue("@StaffAddress", StaffAddress);
                            cmd.Parameters.AddWithValue("@StaffJob", StaffJob);
                            cmd.Parameters.AddWithValue("@StaffId", staffId);
                            cmd.Parameters.AddWithValue("@StaffUserName", userName);
                            cmd.Parameters.AddWithValue("@StaffPassword",password);

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Staff record added successfully.");
                                flowLayoutPanel1.Controls.Clear();
                                LoadExistingData();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add Staff record.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
