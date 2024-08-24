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
    public partial class SupplierForm : Form
    {
        ContextMenuStrip contextMenu;
        public SupplierForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Revert Supplier", null, ContextMenuOption1_Click);
        }
        public void AddSupplierInfo(string supplierName, string carName, String carId, string supplierId, String mobileNumber, string address)
        {
            Panel panel = new Panel();
            panel.Name = "SupplierData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label label1 = new Label();
            label1.Name = "SupplierNameLabel";
            label1.Text = supplierName;
            label1.Location = new Point(12, 5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "CarNameLabel";
            label2.Text = carName;
            label2.Location = new Point(12, label1.Bottom + 5);
            label2.ForeColor = Color.Black;
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "CarIdLabel";
            label3.Text = carId;
            label3.Location = new Point(12, label2.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            Label supplierIdLabel = new Label();
            supplierIdLabel.Name = "SupplierIdLabel";
            supplierIdLabel.Text = supplierId;
            supplierIdLabel.Location = new Point(12, label3.Bottom + 5);
            supplierIdLabel.ForeColor = Color.Black;
            supplierIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            supplierIdLabel.AutoSize = true;

            Label mobileNumberLabel = new Label();
            mobileNumberLabel.Name = "MobileNumberLabel";
            mobileNumberLabel.Text = mobileNumber;
            mobileNumberLabel.Location = new Point(12, supplierIdLabel.Bottom + 5);
            mobileNumberLabel.ForeColor = Color.Black;
            mobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            mobileNumberLabel.AutoSize = true;

            Label addressLabel = new Label();
            addressLabel.Name = "CarInfoLabel";
            addressLabel.Text = address;
            addressLabel.Location = new Point(12, mobileNumberLabel.Bottom + 5);
            addressLabel.ForeColor = Color.Black;
            addressLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            addressLabel.AutoSize = true;
            addressLabel.Width = 200;
            addressLabel.Height = 100;
            addressLabel.MaximumSize = new Size(200, 0);
            addressLabel.TextAlign = ContentAlignment.TopLeft;
            addressLabel.Padding = new Padding(0);



            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(label3);
            panel.Controls.Add(supplierIdLabel);
            panel.Controls.Add(mobileNumberLabel);
            panel.Controls.Add(addressLabel);

            panel.MouseClick += Panel_MouseClick;
            label1.MouseClick += Panel_MouseClick;
            label2.MouseClick += Panel_MouseClick;
            mobileNumberLabel.MouseClick += Panel_MouseClick;
            addressLabel.MouseClick += Panel_MouseClick;
            addressLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
        }
        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {


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

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            AddSupplierInfo addSupplierInfo = new AddSupplierInfo();
            if (addSupplierInfo.ShowDialog() == DialogResult.OK)
            {
                String supplierName = addSupplierInfo.supplierName;
                String carId = addSupplierInfo.carId;
                String supplierId = addSupplierInfo.supplierId;
                String carName = addSupplierInfo.carName;
                String mobileNumber = addSupplierInfo.mobileNumber;
                String address = addSupplierInfo.address;

                AddSupplierInfo(supplierName:supplierName,carName: carName, carId: carId, supplierId: supplierId,mobileNumber:mobileNumber,address:address);
            }
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}