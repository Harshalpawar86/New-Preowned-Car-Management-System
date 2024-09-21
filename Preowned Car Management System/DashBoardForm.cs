using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class DashBoardForm : Form
    {

        public static String connectionString = "Data Source=LAPTOP-Q6RR7BFH\\SQLEXPRESS08;Initial Catalog=PreOwnedCarManagementDatabase;Integrated Security=True;";
     

       // public static String connectionString = "Data Source=MONU\\SQLEXPRESS;Initial Catalog=PreOwnedCarManagementDatabase;Integrated Security=True;TrustServerCertificate=True";
        public DashBoardForm()
        {
            InitializeComponent();
            LoginForm form = new LoginForm();
            this.Size = form.Size;
          
        }

        private void DashPanel_Paint(object sender, PaintEventArgs e)
        {

        }



        private void DashBoardForm_Load(object sender, EventArgs e)
        {
           
        }

        

        private void StockButton_Click_1(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            LoadGivenForm(stockForm);
            
        }
        void LoadGivenForm(Form form) {

            flowLayoutPanel1.Controls.Clear();
            form.TopLevel = false;
            flowLayoutPanel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        } 
        


        private void SuppliersButton_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            LoadGivenForm(supplierForm);
        }

        private void BuyersButton_Click(object sender, EventArgs e)
        {
            BuyersForm buyersForm = new BuyersForm();
            LoadGivenForm(buyersForm);
        }

        private void AccessoriesButton_Click(object sender, EventArgs e)
        {
            AccessoriesForm accessoriesForm = new AccessoriesForm();
            LoadGivenForm(accessoriesForm);
        }

        private void MaintenanceButton_Click(object sender, EventArgs e)
        {
            MaintenanceForm maintenanceForm = new MaintenanceForm();
            LoadGivenForm(maintenanceForm);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void StaffButton_Click(object sender, EventArgs e)
        {
            StaffForm staffForm = new StaffForm();
            LoadGivenForm(staffForm);
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            LoadGivenForm(historyForm);
        }
    }
}