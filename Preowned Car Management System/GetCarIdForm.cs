using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class GetCarIdForm : Form
    {
        public int carId { get; set; }
        String connectionString = DashBoardForm.connectionString;
        bool exception = false;
        public GetCarIdForm()
        {
            InitializeComponent();
        }

        private void GetCarIdForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                String query = "SELECT CarName,CarId,SupplierId,PurchaseAmount,PurchaseDate,OwnerType,CarInfo FROM StockTable ";

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                {

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (exception == false)
            {

                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Please Select Valid Row");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            exception = false;
            try
            {

                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                    carId = Convert.ToInt32(row.Cells["CarId"].Value);
                    exception = false;
                }
            }
            catch (Exception exp)
            {
             //   MessageBox.Show(exp.ToString());
                MessageBox.Show("Please Select Valid Row");
                exception = true;

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
