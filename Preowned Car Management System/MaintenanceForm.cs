using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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
            contextMenu.Items.Add("Update Maintenance", null, ContextMenuOption1_Click);
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
                    Text = carId,
                    Location = new Point(12, 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceIdLabel = new Label
                {
                    Name = "MaintenanceIdLabel",
                    Text = maintenanceId,
                    Location = new Point(12, carIdLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceDateLabel = new Label
                {
                    Name = "MaintenanceDateDateLabel",
                    Text = maintenanceDate,
                    Location = new Point(12, maintenanceIdLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceCostLabel = new Label
                {
                    Name = "MaintenanceCostLabel",
                    Text = maintenanceCost,
                    Location = new Point(12, maintenanceDateLabel.Bottom + 5),
                    ForeColor = Color.Black,
                    Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                    AutoSize = true
                };

                Label maintenanceInfoLabel = new Label
                {
                    Name = "MaintenanceInfoLabel",
                    Text = maintenanceInfo,
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

        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {
            try
            {
                if (contextMenu.SourceControl is Panel panel)
                {
                    string maintenanceId = panel.Tag as string;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM maintenanceTable WHERE maintenanceId = @MaintenanceId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaintenanceId", maintenanceId);
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                MaintenanceInfoForm updateForm = new MaintenanceInfoForm
                                {
                                    carId = reader["CarId"].ToString(),
                                    maintenanceId = reader["MaintenanceId"].ToString(),
                                    maintenanceCost = reader["MaintenanceCost"].ToString(),
                                    maintenanceDate = reader["MaintenanceDate"].ToString(),
                                    maintenanceInfo = reader["MaintenanceInfo"].ToString()
                                };

                                if (updateForm.ShowDialog() == DialogResult.OK)
                                {
                                    string updateQuery = "UPDATE maintenanceTable SET CarId = @CarId, MaintenanceDate = @MaintenanceDate, MaintenanceCost = @MaintenanceCost, MaintenanceInfo = @MaintenanceInfo WHERE MaintenanceId = @MaintenanceId";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@CarId", updateForm.carId);
                                        updateCmd.Parameters.AddWithValue("@MaintenanceId", updateForm.maintenanceId);
                                        updateCmd.Parameters.AddWithValue("@MaintenanceDate", updateForm.maintenanceDate);
                                        updateCmd.Parameters.AddWithValue("@MaintenanceCost", updateForm.maintenanceCost);
                                        updateCmd.Parameters.AddWithValue("@MaintenanceInfo", updateForm.maintenanceInfo);

                                        reader.Close();
                                        int result = updateCmd.ExecuteNonQuery();
                                        if (result > 0)
                                        {
                                            MessageBox.Show("Maintenance record updated successfully.");
                                            flowLayoutPanel1.Controls.Clear();
                                            LoadExistingData();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Failed to update maintenance record.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the maintenance record: {ex.Message}");
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
                            string query = "DELETE FROM maintenanceTable WHERE MaintenanceId = @MaintenanceId";
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
                    string query = "SELECT * FROM maintenanceTable;";
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
            try
            {
                MaintenanceInfoForm addMaintenanceForm = new MaintenanceInfoForm();
                if (addMaintenanceForm.ShowDialog() == DialogResult.OK)
                {
                    string carId = addMaintenanceForm.carId;
                    string maintenanceId = addMaintenanceForm.maintenanceId;
                    string maintenanceDate = addMaintenanceForm.maintenanceDate;
                    string maintenanceInfo = addMaintenanceForm.maintenanceInfo;
                    string maintenanceCost = addMaintenanceForm.maintenanceCost;

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
