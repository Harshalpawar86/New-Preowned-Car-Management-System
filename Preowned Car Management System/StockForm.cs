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
    public partial class StockForm : Form
    {
        ContextMenuStrip contextMenu;
        public StockForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Sell Car", null, ContextMenuOption1_Click);
        }
        public void AddStockInfo(string carName, string carId,String supplierId ,string carDate, String image, string ownerType, string carInfoLabel)
        {
            Panel panel = new Panel();
            panel.Name = "StockData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Padding = new Padding(10);
            pictureBox.Name = "StockImage";
            pictureBox.Size = new Size(200,150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox.Image = Image.FromFile(image);

            Label label1 = new Label();
            label1.Name = "CarNameLabel";
            label1.Text = carName;
            label1.Location = new Point(12, pictureBox.Bottom+5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "CarIdLabel";
            label2.Text = carId;
            label2.Location = new Point(12, label1.Bottom + 5);
            label2.ForeColor = Color.Black;
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "SupplierIdLabel";
            label3.Text = supplierId;
            label3.Location = new Point(12, label2.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            Label mobileNumberLabel = new Label();
            mobileNumberLabel.Name = "CarDateLabel";
            mobileNumberLabel.Text = carDate;
            mobileNumberLabel.Location = new Point(12, label3.Bottom + 5);
            mobileNumberLabel.ForeColor = Color.Black;
            mobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            mobileNumberLabel.AutoSize = true;

            Label addressLabel = new Label();
            addressLabel.Name = "OwnerTypeLabel";
            addressLabel.Text = ownerType;
            addressLabel.Location = new Point(12, mobileNumberLabel.Bottom + 5);
            addressLabel.ForeColor = Color.Black;
            addressLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            addressLabel.AutoSize = true;

            Label vehicleInfoLabel = new Label();
            vehicleInfoLabel.Name = "CarInfoLabel";
            vehicleInfoLabel.Text = carInfoLabel;
            vehicleInfoLabel.Location = new Point(12, addressLabel.Bottom + 5);
            vehicleInfoLabel.ForeColor = Color.Black;
            vehicleInfoLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            vehicleInfoLabel.AutoSize = true;
            vehicleInfoLabel.Width = 200; 
            vehicleInfoLabel.Height = 100; 
            vehicleInfoLabel.MaximumSize = new Size(200, 0); 
            vehicleInfoLabel.TextAlign = ContentAlignment.TopLeft;
            vehicleInfoLabel.Padding = new Padding(0);



            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(label3);
            panel.Controls.Add(mobileNumberLabel);
            panel.Controls.Add(addressLabel);
            panel.Controls.Add(vehicleInfoLabel);

            panel.MouseClick += Panel_MouseClick;
            pictureBox.MouseClick += Panel_MouseClick;
            label1.MouseClick += Panel_MouseClick;
            label2.MouseClick += Panel_MouseClick;
            mobileNumberLabel.MouseClick += Panel_MouseClick;
            addressLabel.MouseClick += Panel_MouseClick;
            vehicleInfoLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
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

        private void StockForm_Load(object sender, EventArgs e)
        {

        }
        private void ContextMenuOption1_Click(object sender, EventArgs e) { 
        

        }


        private void AddStockButton_Click(object sender, EventArgs e)
        {
            AddStockPopupForm addStockPopupForm = new AddStockPopupForm();
            if (addStockPopupForm.ShowDialog() == DialogResult.OK)
            {
                string carName = addStockPopupForm.carName;
                string carId = addStockPopupForm.carId;
                String supplierId = addStockPopupForm.supplierId;
                string carDate = addStockPopupForm.carDate;
                String imageString = addStockPopupForm.ImagePath;  
                string ownerType = addStockPopupForm.ownerType;
                string carInfoLabel = addStockPopupForm.carInfo;

                AddStockInfo(carName:carName, carId:carId, supplierId:supplierId,carDate:carDate,image:imageString, ownerType:ownerType, carInfoLabel:carInfoLabel);
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}