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
        public StockForm()
        {
            InitializeComponent();
        }
        public void AddStockInfo(string ownerName, string carName, string mobileNumber, Image image, string address, string vehicleInfo)
        {
            Panel panel = new Panel();
            panel.Name = "Stock Data";
            panel.BackColor = Color.White;
           // panel.Size = new Size(125, 205);
           panel.AutoSize = true;
            panel.Margin = new Padding(10);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "Stock Image";
            pictureBox.Size = new Size(100, 168);
            pictureBox.Location = new Point(12, 10);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = image;

            Label label1 = new Label();
            label1.Name = "OwnerNameLabel";
            label1.Text = ownerName;
            label1.Location = new Point(12, pictureBox.Bottom+5);
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

            Label mobileNumberLabel = new Label();
            mobileNumberLabel.Name = "MobileNumberLabel";
            mobileNumberLabel.Text = mobileNumber;
            mobileNumberLabel.Location = new Point(12, label2.Bottom + 5);
            mobileNumberLabel.ForeColor = Color.Black;
            mobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            mobileNumberLabel.AutoSize = true;

            Label addressLabel = new Label();
            addressLabel.Name = "AddressLabel";
            addressLabel.Text = address;
            addressLabel.Location = new Point(12, mobileNumberLabel.Bottom + 5);
            addressLabel.ForeColor = Color.Black;
            addressLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            addressLabel.AutoSize = true;

            Label vehicleInfoLabel = new Label();
            vehicleInfoLabel.Name = "VehicleInfoLabel";
            vehicleInfoLabel.Text = vehicleInfo;
            vehicleInfoLabel.Location = new Point(12, addressLabel.Bottom + 5);
            vehicleInfoLabel.ForeColor = Color.Black;
            vehicleInfoLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            vehicleInfoLabel.AutoSize = true;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(mobileNumberLabel);
            panel.Controls.Add(addressLabel);
            panel.Controls.Add(vehicleInfoLabel);

            flowLayoutPanel1.Controls.Add(panel);
        }


        private void StockForm_Load(object sender, EventArgs e)
        {

        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            AddStockInfo("ownerName","carName","mobileNumber",Properties.Resources.pngkey_com_neon_frame_png_1112636,"address","vehicleInfo");
        }
    }
}