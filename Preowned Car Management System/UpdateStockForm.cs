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
    public partial class UpdateStockForm : Form
    {
        public String carName { get; set; }
        public double purchaseAmount { get; set; }
        public Image image { get; set; }
        public String ownerType { get; set; }
        public String carInfo { get; set;}
       
        private bool getImage=false;


        public UpdateStockForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool temp = false;
            if (ValidateData())
            {

                carName = CarInfoTextBox.Text;
                purchaseAmount = Convert.ToInt64(PurchaseAmountTextBox.Text);
                ownerType = OwnerTypeComboBox.Text;
                carInfo = CarInfoTextBox.Text;
                temp = true;
            }
            else {

                MessageBox.Show("Please Enter Valid Data");
            }
            if (getImage == false) {

                MessageBox.Show("Please Select a Image");
            }
            if (getImage == true && temp == true) { 
            
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidateData()
        {

            return !string.IsNullOrEmpty(CarNameTextBox.Text) &&
                   !string.IsNullOrEmpty(OwnerTypeComboBox.Text) &&
                   double.TryParse(PurchaseAmountTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(CarInfoTextBox.Text);
        }


        private void UpdateStockForm_Load(object sender, EventArgs e)
        {
            CarNameTextBox.Text = carName;
            PurchaseAmountTextBox.Text = purchaseAmount.ToString();
            OwnerTypeComboBox.Text = ownerType;
            CarInfoTextBox.Text = carInfo;
        }

        private void photo_button_Click(object sender, EventArgs e)
        {
            getImage = false;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {

                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String ImagePath = openFileDialog.FileName;
                    image = Image.FromFile(ImagePath);
                    getImage = true;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void OwnerTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
