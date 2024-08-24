using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class DashBoardForm : Form
    {
        public DashBoardForm()
        {
            InitializeComponent();
            LoginForm form = new LoginForm();
            this.Size = form.Size;
        }

        private void DashPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StockButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {
           
        }

        private void FormLoaderPanel_Paint(object sender, PaintEventArgs e)
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
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
 

        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {

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
    }
}
