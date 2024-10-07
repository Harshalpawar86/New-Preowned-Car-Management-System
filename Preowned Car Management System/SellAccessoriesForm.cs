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
        public SellAccessoriesForm()
        {
            InitializeComponent();
        }

        private void SellAccessoriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {

            dataGridView1.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                String query = "SELECT * FROM AccessoryTable";
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}