using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class SelectStaffForm : Form
    {
        public int staffId { get; set; }
        bool noException1 = false;
        String connectionString = DashBoardForm.connectionString;
        public SelectStaffForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SelectStaffForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            LoadExistingData();
        }
        void LoadExistingData() {

            dataGridView1.ClearSelection();            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                String query = "SELECT * FROM StaffTable";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            dataGridView1.ClearSelection();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (noException1 == true)
            {
                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Please Enter Valid Data");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
                             
  

        private void BuyerStaffTextBox_TextChanged_1(object sender, EventArgs e)
        {
            String name = BuyerStaffTextBox.Text;
            SearchStaff(name);
        }
        void SearchStaff(String searchText) {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM StaffTable WHERE StaffName LIKE @SearchText";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

        }

        private void SearchStaffButton_Click(object sender, EventArgs e)
        {
            String name = BuyerStaffTextBox.Text;
            SearchStaff(name);
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            BuyerStaffTextBox.Clear();
            LoadExistingData();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            noException1 = false;
            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    staffId = Convert.ToInt32(row.Cells["StaffId"].Value);
                    noException1 = true;
                }
            }
            catch (Exception exp)
            {
               // MessageBox.Show(exp.ToString());
                noException1 = false;
            }
        }
    }
}
