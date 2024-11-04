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
    public partial class SellAccessoriesForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        long carId;
        public SellAccessoriesForm(long carId)
        {
            InitializeComponent();
            this.carId = carId;
        }

        private void SellAccessoriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            //MessageBox.Show(carId+"");
            dataGridView1.Columns.Clear();  
            dataGridView1.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                String query = "SELECT AccessoryDate,AccessoryName,AccessoryId,AccessoryCount,AccessoryPrice FROM AccessoryTable";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        DataTable dt = new DataTable();
                        conn.Open();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            DataGridViewTextBoxColumn countColumn = new DataGridViewTextBoxColumn();
            countColumn.Width = 200;
            countColumn.HeaderText = "Required Accessory Count";
            countColumn.Name = "Required Accessory Count";
            dataGridView1.Columns.Add(countColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool exception = false;
            bool accessoriesSold = false; 
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Required Accessory Count"].Value != null &&
                            !string.IsNullOrWhiteSpace(row.Cells["Required Accessory Count"].Value.ToString()))
                        {
                            string accessoryName = row.Cells["AccessoryName"].Value.ToString();
                            int accessoryId = Convert.ToInt32(row.Cells["AccessoryId"].Value);
                            int accessoryCount = Convert.ToInt32(row.Cells["AccessoryCount"].Value);
                            decimal accessoryPrice = Convert.ToDecimal(row.Cells["AccessoryPrice"].Value);
                            int requiredAccessoryCount = Convert.ToInt32(row.Cells["Required Accessory Count"].Value);

                            if (requiredAccessoryCount > accessoryCount)
                            {
                                MessageBox.Show($"Not enough stock for accessory '{accessoryName}'. Available count: {accessoryCount}");
                                continue; 
                            }

                            string query = @"INSERT INTO AccessorySales 
                        (CarId, AccessoryId, AccessoryName, AccessoryPrice, AccessorySoldCount, TotalPrice, SaleDate) 
                        VALUES (@CarId, @AccessoryId, @AccessoryName, @AccessoryPrice, @AccessorySoldCount, @TotalPrice, @SaleDate)";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@CarId", carId);
                                cmd.Parameters.AddWithValue("@AccessoryId", accessoryId);
                                cmd.Parameters.AddWithValue("@AccessoryName", accessoryName);
                                cmd.Parameters.AddWithValue("@AccessoryPrice", accessoryPrice);
                                cmd.Parameters.AddWithValue("@AccessorySoldCount", requiredAccessoryCount);
                                cmd.Parameters.AddWithValue("@TotalPrice", (accessoryPrice * requiredAccessoryCount));
                                cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

                                cmd.ExecuteNonQuery();
                            }

                            string updateQuery = @"UPDATE AccessoryTable 
                                           SET AccessoryCount = AccessoryCount - @RequiredAccessoryCount 
                                           WHERE AccessoryId = @AccessoryId";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@RequiredAccessoryCount", requiredAccessoryCount);
                                updateCmd.Parameters.AddWithValue("@AccessoryId", accessoryId);

                                updateCmd.ExecuteNonQuery();
                            }

                            accessoriesSold = true; 
                        }
                    }
                }
                exception = false;
            }
            catch (Exception exp)
            {
            //    MessageBox.Show(exp.Message);
                exception = true;
            }

            if (exception == false && accessoriesSold)
            {
                MessageBox.Show("Accessories sold successfully!", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                DialogResult = DialogResult.OK;
            }
            else if (!accessoriesSold) 
            {
                MessageBox.Show("Please enter valid accessory counts.", "Input Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}