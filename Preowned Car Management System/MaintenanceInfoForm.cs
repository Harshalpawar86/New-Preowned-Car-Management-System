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
    public partial class MaintenanceInfoForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        public int carId { get; set; }
        public int maintenanceId { get; set; }
        public String maintenanceDate { get; set; }
        public String maintenanceInfo { get; set; }
        public decimal maintenanceCost { get; set; }

        public MaintenanceInfoForm()
        {
            InitializeComponent();
        }

        private void MaintenanceInfoForm_Load(object sender, EventArgs e)
        {
            LoadMaintenanceId();
        }
        private void LoadMaintenanceId()
        {
            // Initial MaintenanceId set to 501
            long maintenanceId = 501;

            // Query to get the maximum MaintenanceId from MaintenanceTable
            string queryStock = "SELECT MAX(MaintenanceId) FROM MaintenanceTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Execute the query to fetch the highest MaintenanceId in MaintenanceTable
                SqlCommand cmd = new SqlCommand(queryStock, conn);
                var result = cmd.ExecuteScalar();

                // Check if a valid MaintenanceId exists in MaintenanceTable
                if (result != DBNull.Value && result != null && Convert.ToInt64(result) >= 501)
                {
                    // Increment the MaintenanceId
                    maintenanceId = Convert.ToInt64(result) + 1;
                }
                else
                {
                    // Query to check MaintenanceId in HistoryTable if MaintenanceTable doesn't have valid entries
                    string queryHistory = "SELECT MAX(MaintenanceId) FROM HistoryTable";
                    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                    var result2 = cmd2.ExecuteScalar();

                    // Check if a valid MaintenanceId exists in HistoryTable
                    if (result2 != DBNull.Value && result2 != null && Convert.ToInt64(result2) >= 501)
                    {
                        // Increment the MaintenanceId based on HistoryTable if applicable
                        maintenanceId = Convert.ToInt64(result2) + 1;
                    }
                }
            }

            // Display the next MaintenanceId in the textbox
            MaintenanceIdTextBox.Text = maintenanceId.ToString();
        }

        private void CarIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void OKButton_Click(object sender, EventArgs e)
        {
            bool exception = false;
            try
            {
                carId =Convert.ToInt32( CarIdTextBox.Text);
                maintenanceId = Convert.ToInt32(MaintenanceIdTextBox.Text);
                maintenanceCost = Convert.ToDecimal(MaintenanceCostTextBox.Text);
                maintenanceDate = dateTimePicker1.Value.ToString();
                maintenanceInfo = MaintenanceIdRichTextBox.Text;
                exception = false;
            }
            catch (Exception exp) {
                exception = true;
                MessageBox.Show("Please Enter Valid Data");
              //  MessageBox.Show(exp.ToString());
            }


            if (exception == false)
            {
                DialogResult = DialogResult.OK;
            }
  
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GetCarIdButton_Click(object sender, EventArgs e)
        {
            GetCarIdForm form = new GetCarIdForm();
            if (form.ShowDialog() == DialogResult.OK) {

                CarIdTextBox.Text =form.carId.ToString();
            }
        }
    }
}
