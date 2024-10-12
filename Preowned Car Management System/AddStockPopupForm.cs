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
    public partial class AddStockPopupForm : Form
    {
        public String ImagePath { get; set; }
        public String carName { get; set; }
        public long carId { get; set; }
        public long supplierId { get; set; }
        public String ownerType { get; set; }
        public String carDate { get; set; }
        public String carInfo { get; set; }
        public decimal purchaseAmount { get; set; }

        private bool noException = false;
        private bool getImage = false;

        public AddStockPopupForm()
        {
            InitializeComponent();
        }

        private void photo_button_Click(object sender, EventArgs e)
        {
            getImage = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ImagePath = openFileDialog.FileName;
                    getImage = true;

                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddStockPopupForm_Load(object sender, EventArgs e)
        {

        }
        private void getData() {
            carName = CarNameTextBox.Text;
            carId = long.Parse(CarIdTextBox.Text);
            supplierId = long.Parse(SupplierIdTextBox.Text);
            carDate = dateTimePicker1.Value.ToString("dd / MM / yyyy");
            ownerType = OwnerTypeComboBox.Text;
            carInfo = CarInfoTextBox.Text;
            purchaseAmount = decimal.Parse(PurchaseAmountTextBox.Text);

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            noException = false;
            if (ValidateData()){
                try{
                    getData();
                    noException = true;
                }
                catch (Exception exp){

                    noException = false;
                }
            }else {

                MessageBox.Show("Please Enter Valid Data");
            }
            if (getImage == false) {

                MessageBox.Show("Please Select image");
            }
            if (noException == true && getImage == true){
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidateData() { 
        
            return !string.IsNullOrEmpty(CarNameTextBox.Text) &&
                   !string.IsNullOrEmpty(CarIdTextBox.Text) &&
                   !string.IsNullOrEmpty(OwnerTypeComboBox.Text) &&
                   !string.IsNullOrEmpty(CarIdTextBox.Text) &&
                   long.TryParse(SupplierIdTextBox.Text, out _) &&
                   decimal.TryParse(PurchaseAmountTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(dateTimePicker1.Text);
        }

        private void name_label_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExistingSupplierForm form = new ExistingSupplierForm("ForStock");
            if (form.ShowDialog() == DialogResult.OK) {

                CarNameTextBox.Text = form.carName;
                SupplierIdTextBox.Text=form.supplierId.ToString();
                PurchaseAmountTextBox.Text=form.purchaseAmount.ToString();
                CarIdTextBox.Text=form.carId.ToString();
            }
        }

        private void SupplierIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
