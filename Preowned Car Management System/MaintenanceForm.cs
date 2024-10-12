using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class MaintenanceForm : Form
    {
        ContextMenuStrip contextMenu;
        string connectionString = DashBoardForm.connectionString;

        public MaintenanceForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Delete Maintenance", null, ContextMenuOption2_Click);
        }

        public void AddMaintenanceRecord(string carId, string maintenanceId, string maintenanceCost, string maintenanceDate, string maintenanceInfo)
        {
            try
            {
                Panel panel = new Panel
                {
                    Name = "StockData",
                    BackColor = Color.White,
                    AutoSize = true,
                    Margin = new Padding(10),
                    Padding = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = maintenanceId 
                };

                Label carIdLabel = new Label
                {
                    Name = "CarIdLabel",
                    Text = "Car Id : "+carId,
                    Location = new Point(12, 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceIdLabel = new Label
                {
                    Name = "MaintenanceIdLabel",
                    Text = "Maintenance Id : "+maintenanceId,
                    Location = new Point(12, carIdLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceDateLabel = new Label
                {
                    Name = "MaintenanceDateDateLabel",
                    Text = "Maintenance Date : "+maintenanceDate,
                    Location = new Point(12, maintenanceIdLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceCostLabel = new Label
                {
                    Name = "MaintenanceCostLabel",
                    Text = "Maintenance Cost : "+maintenanceCost,
                    Location = new Point(12, maintenanceDateLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceInfoLabel = new Label
                {
                    Name = "MaintenanceInfoLabel",
                    Text = "Maintenance Information : "+maintenanceInfo,
                    Location = new Point(12, maintenanceCostLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true,
                    Width = 200,
                    Height = 100,
                    MaximumSize = new Size(200, 0),
                    TextAlign = ContentAlignment.TopLeft,
                    Padding = new Padding(0)
                };

                panel.Controls.Add(carIdLabel);
                panel.Controls.Add(maintenanceIdLabel);
                panel.Controls.Add(maintenanceDateLabel);
                panel.Controls.Add(maintenanceCostLabel);
                panel.Controls.Add(maintenanceInfoLabel);

                panel.MouseClick += Panel_MouseClick;
                carIdLabel.MouseClick += Panel_MouseClick;
                maintenanceIdLabel.MouseClick += Panel_MouseClick;
                maintenanceDateLabel.MouseClick += Panel_MouseClick;
                maintenanceCostLabel.MouseClick += Panel_MouseClick;
                maintenanceInfoLabel.MouseClick += Panel_MouseClick;

                flowLayoutPanel1.Controls.Add(panel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the maintenance record: {ex.Message}");
            }
        }

        

        private void ContextMenuOption2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dresult = MessageBox.Show("Are you sure you want to delete this maintenance record?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dresult == DialogResult.OK)
                {
                    if (contextMenu.SourceControl is Panel panel)
                    {
                        string maintenanceId = panel.Tag as string;
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM MaintenanceTable WHERE MaintenanceId = @MaintenanceId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaintenanceId", maintenanceId);
                                conn.Open();
                                int result = cmd.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    MessageBox.Show("Maintenance record deleted.");
                                    flowLayoutPanel1.Controls.Clear();
                                    LoadExistingData();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete maintenance record.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the maintenance record: {ex.Message}");
            }
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

        private void LoadExistingData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MaintenanceTable;";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string carId = row["CarId"].ToString();
                            string maintenanceId = row["MaintenanceId"].ToString();
                            string maintenanceDate = row["MaintenanceDate"].ToString();
                            string maintenanceInfo = row["MaintenanceInfo"].ToString();
                            string maintenanceCost = row["MaintenanceCost"].ToString();

                            AddMaintenanceRecord(carId, maintenanceId, maintenanceCost, maintenanceDate, maintenanceInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading existing data: {ex.Message}");
            }
        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void AddMaintenanceButton_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MaintenanceForm_Load_1(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Car Id to Search Maintenance Records..");

            }
            else
            {
                searchId(SearchTextBox.Text);

            }
        }
        private void searchId(String name) {

            flowLayoutPanel1.Controls.Clear();
            try
            {

                String query = "SELECT * FROM MaintenanceTable WHERE CarId=@CarId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("CarId", name);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String carId = reader["CarId"].ToString();
                                String maintenanceId = reader["MaintenanceId"].ToString();
                                String maintenanceCost = reader["MaintenanceCost"].ToString();
                                String maintenanceDate = reader["MaintenanceDate"].ToString();
                                String maintenanceInfo = reader["MaintenanceInfo"].ToString();

                                AddMaintenanceRecord(carId, maintenanceId, maintenanceCost, maintenanceDate, maintenanceInfo);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Maintenance Record not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AddBuyerButton_Click(object sender, EventArgs e)
        {
            try
            {
                MaintenanceInfoForm addMaintenanceForm = new MaintenanceInfoForm();
                if (addMaintenanceForm.ShowDialog() == DialogResult.OK)
                {
                    int carId = Convert.ToInt32(addMaintenanceForm.carId);
                    int maintenanceId = Convert.ToInt32(addMaintenanceForm.maintenanceId);
                    string maintenanceDate = addMaintenanceForm.maintenanceDate;
                    string maintenanceInfo = addMaintenanceForm.maintenanceInfo;
                    decimal maintenanceCost = Convert.ToDecimal(addMaintenanceForm.maintenanceCost);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO maintenanceTable (CarId, MaintenanceId, MaintenanceDate, MaintenanceInfo, MaintenanceCost) " +
                                       "VALUES (@CarId, @MaintenanceId, @MaintenanceDate, @MaintenanceInfo, @MaintenanceCost)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CarId", carId);
                            cmd.Parameters.AddWithValue("@MaintenanceId", maintenanceId);
                            cmd.Parameters.AddWithValue("@MaintenanceDate", maintenanceDate);
                            cmd.Parameters.AddWithValue("@MaintenanceInfo", maintenanceInfo);
                            cmd.Parameters.AddWithValue("@MaintenanceCost", maintenanceCost);

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Maintenance record added successfully.");
                                flowLayoutPanel1.Controls.Clear();
                                LoadExistingData();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add maintenance record.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the maintenance record: {ex.Message}");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
