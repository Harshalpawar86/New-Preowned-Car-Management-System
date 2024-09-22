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
        public int staffMobileNumber { get; set; }
        public String staffEmail { get; set; }
        public String staffAddress { get; set; }
        public String jobDesignation { get; set; }

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
                else
                {
                    string queryHistory = "SELECT MAX(SupplierId) FROM HistoryTable";
                    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                    var result2 = cmd2.ExecuteScalar();

                    if (result2 != DBNull.Value && result2 != null)
                    {
                        lastSupplierId = Convert.ToInt64(result2) + 1;
                    }
                }
            }

            StaffIdTextBox.Text = lastSupplierId.ToString();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            staffName=StaffNameTextBox.Text;
            staffGender=GenderComboBox.Text;
            staffMobileNumber = Convert.ToInt32(textBox2.Text);
            staffEmail=StaffEmailTextBox.Text;
            staffBOD = dateTimePicker1.Value.ToString();
            staffAddress=richTextBox1.Text;
            staffId = Convert.ToInt32(StaffIdTextBox.Text);
            jobDesignation=JobDesignationComboBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
