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
            contextMenu.Items.Add("Edit Information", null, ContextMenuOption1_Click);
        }
        public void AddStaffInfoFun(String staffName, String staffBOD,long staffId, String staffGender, int staffMobileNumber, String staffEmail, String staffAddress, String jobDesignation)
        {
            Panel panel = new Panel();
            panel.Name = "StaffData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label StaffNameLabel = new Label();
            StaffNameLabel.Name = "StaffNameLabel";
            StaffNameLabel.Text = "Name : " + staffName;
            StaffNameLabel.Location = new Point(12, 5);
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

                            AddStaffInfoFun(staffName: staffName, staffBOD: staffDOB, staffGender: staffGender, staffMobileNumber: staffNumber,staffId:staffId, staffEmail: staffMail, staffAddress: staffAddress, jobDesignation: staffJob); 
                            }
                        }
                }
            
  
        }


        private void AddStaffButton_Click(object sender, EventArgs e)
        {

            AddStaffInfoForm addStaffInfoForm = new AddStaffInfoForm();
            try
            {
               
                if (addStaffInfoForm.ShowDialog() == DialogResult.OK)
                {
                   String  StaffName = addStaffInfoForm.staffName;
                   String StaffGender  = addStaffInfoForm.staffGender;
                    String StaffDOB = addStaffInfoForm.staffBOD;
                    int StaffNumber = addStaffInfoForm.staffMobileNumber;
                    String StaffMail = addStaffInfoForm.staffEmail;
                    String StaffAddress = addStaffInfoForm.staffAddress;
                    String StaffJob = addStaffInfoForm.jobDesignation;
                    long staffId = addStaffInfoForm.staffId;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO StaffTable (StaffName, StaffGender, StaffDOB, StaffNumber, StaffMail,StaffAddress,StaffJob,StaffId) " +
                                       "VALUES (@StaffName, @StaffGender, @StaffDOB, @StaffNumber, @StaffMail,@StaffAddress,@StaffJob,@StaffId)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StaffName", StaffName);
                            cmd.Parameters.AddWithValue("@StaffGender", StaffGender);
                            cmd.Parameters.AddWithValue("@StaffDOB", StaffDOB);
                            cmd.Parameters.AddWithValue("@StaffNumber", StaffNumber);
                            cmd.Parameters.AddWithValue("@StaffMail", StaffMail);
                            cmd.Parameters.AddWithValue("@StaffAddress", StaffAddress);
                            cmd.Parameters.AddWithValue("@StaffJob",StaffJob);
                            cmd.Parameters.AddWithValue("@StaffId",staffId);

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }
    }
}
