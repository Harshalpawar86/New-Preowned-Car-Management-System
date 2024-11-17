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
    public partial class UpdateAccessoryForm : Form
    {
        public long AccessoryId { get; set; }
        public string AccessoryName { get; set; }
        public int AccessoryCount { get; set; }
        public string AccessoryDate { get; set; }
        public Image AccessoryImage { get; set; }
        public decimal AccessoryPrice { get; set; }

        String connectionString = DashBoardForm.connectionString;
        long accessoryId;
        public UpdateAccessoryForm(long accessoryId)
        {

            InitializeComponent();
            this.accessoryId = accessoryId;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            bool exception = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "UPDATE AccessoryTable SET AccessoryName=@AccessoryName,AccessoryCount=@AccessoryCount,AccessoryDate=@AccessoryDate,AccessoryPrice=@AccessoryPrice WHERE AccessoryId=@AccessoryId";
                    conn.Open();
                    String accessoryName = AccessoryNameTextBox.Text;
                    int accessoryCount = Convert.ToInt32(AccessoryCountTextBox.Text);
                    String date = dateTimePicker1.Value.Date.ToString("d");
                    decimal accessoryPrice = Convert.ToDecimal(AccessoryPriceTextBox.Text);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@AccessoryId", accessoryId);
                        cmd.Parameters.AddWithValue("@AccessoryName", accessoryName);
                        cmd.Parameters.AddWithValue("@AccessoryCount", accessoryCount);
                        cmd.Parameters.AddWithValue("@AccessoryDate", date);
                        cmd.Parameters.AddWithValue("@AccessoryPrice", accessoryPrice);

                        cmd.ExecuteNonQuery();

                    }
                    AccessoryName = accessoryName;
                    AccessoryCount = accessoryCount;
                    AccessoryDate = date;
                    AccessoryPrice = accessoryPrice;
                    AccessoryId = accessoryId;

                }
                exception = false;
            }
            catch (Exception exp)
            {


                MessageBox.Show(exp.ToString());
                exception = true;
            }
            if (exception == false)
            {

                DialogResult = DialogResult.OK;
            }
            else
            {

                MessageBox.Show("Please Enter Valid Data", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
            }
        }

        private void UpdateAccessoryForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }
        private void LoadExistingData()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AccessoryName, AccessoryCount, AccessoryPrice FROM AccessoryTable WHERE AccessoryId = @AccessoryId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccessoryId", accessoryId);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AccessoryNameTextBox.Text = reader["AccessoryName"].ToString();
                                AccessoryCountTextBox.Text = reader["AccessoryCount"].ToString();
                                AccessoryPriceTextBox.Text = reader["AccessoryPrice"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No accessory found with the provided ID.", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
