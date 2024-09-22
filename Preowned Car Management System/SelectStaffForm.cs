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
        }

        private void SelectStaffForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                String query = "SELECT * FROM StaffTable";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn)) {
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridView1.DataSource=dt;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (noException1 == true)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                MessageBox.Show(exp.ToString());
                noException1 = false;
            }
        }
    }
}
