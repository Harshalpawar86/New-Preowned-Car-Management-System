using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class SellCarForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        SelectTransactionDetailsForm form = new SelectTransactionDetailsForm();

        public SellCarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (form.ShowDialog()==DialogResult.OK) {

                CarIdTextBox.Text = form.carId.ToString();
                SupplierIdTextBox.Text = form.supplierId.ToString();
                BuyerIdTextBox.Text = form.buyerId.ToString();
                PurchaseAmountTextBox.Text = form.amountPaid.ToString();

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SellCarForm_Load(object sender, EventArgs e)
        {

        }
        private byte[] ConvertToByteArray(Image image) {

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private bool validateData()
        {
            
            return !string.IsNullOrEmpty(CarIdTextBox.Text) &&
                   long.TryParse(SupplierIdTextBox.Text, out _) &&
                   long.TryParse(BuyerIdTextBox.Text, out _) &&
                   long.TryParse(CarIdTextBox.Text, out _) &&
                   double.TryParse(PurchaseAmountTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(SellingAmountTextBox.Text);
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (validateData() == true) {
                try
                {
                    DialogResult dresult = MessageBox.Show("Confirm Sell car to " + form.buyerName + "?",
                                                                  "Confirm To Sell",
                                                                  MessageBoxButtons.OKCancel,
                                                                  MessageBoxIcon.Information);
                    if (dresult == DialogResult.OK)
                    {
                        form.amountRecieved = Convert.ToDouble(SellingAmountTextBox.Text);
                        form.staffMember = StaffIdTextBox.Text;
                        form.profitOrLoss = form.amountRecieved - form.amountPaid;
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {

                            conn.Open();
                            string query = "INSERT INTO HISTORYTABLE (CarImage, SupplierMobileNumber, BuyerMobileNumber, SupplierAddress, BuyerAddress, SupplierId, BuyerId, OwnerType, CarInfo, CarId, CarName, SupplierName, BuyerName, AmountPaid, AmountRecieved, StaffId, PurchaseDate, ProfitOrLoss,MaintenanceId) VALUES (@CarImage, @SupplierMobileNumber, @BuyerMobileNumber, @SupplierAddress, @BuyerAddress, @SupplierId, @BuyerId, @OwnerType, @CarInfo, @CarId, @CarName, @SupplierName, @BuyerName, @AmountPaid, @AmountRecieved, @StaffId, @PurchaseDate, @ProfitOrLoss,@MaintenanceId)";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                // MessageBox.Show(""+form.carImage);//image here is String.Iameg.BitMap
                                cmd.Parameters.AddWithValue("@CarImage", ConvertToByteArray(form.carImage));
                                cmd.Parameters.AddWithValue("@SupplierMobileNumber", form.supplierMobileNumber);
                                cmd.Parameters.AddWithValue("@BuyerMobileNumber", form.buyerMobileNumber);
                                cmd.Parameters.AddWithValue("@SupplierAddress", form.supplierAddress);
                                cmd.Parameters.AddWithValue("@BuyerAddress", form.buyerAddress);
                                cmd.Parameters.AddWithValue("@SupplierId", form.supplierId);
                                cmd.Parameters.AddWithValue("@BuyerId", form.buyerId);
                                cmd.Parameters.AddWithValue("@OwnerType", form.ownerType);
                                cmd.Parameters.AddWithValue("@CarInfo", form.carInfo);
                                cmd.Parameters.AddWithValue("@CarId", form.carId);
                                cmd.Parameters.AddWithValue("@CarName", form.carName);
                                cmd.Parameters.AddWithValue("@SupplierName", form.supplierName);
                                cmd.Parameters.AddWithValue("@BuyerName", form.buyerName);
                                cmd.Parameters.AddWithValue("@AmountPaid", form.amountPaid);
                                cmd.Parameters.AddWithValue("@AmountRecieved", form.amountRecieved);
                                cmd.Parameters.AddWithValue("@StaffId", form.staffMember);
                                cmd.Parameters.AddWithValue("@PurchaseDate", form.purchaseDate);
                                cmd.Parameters.AddWithValue("@ProfitOrLoss", form.profitOrLoss);
                                cmd.Parameters.AddWithValue("@MaintenanceId",form.maintenanceId);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {

                            conn.Open();
                            String query = "DELETE FROM StockTable WHERE CarId = @CarId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@CarId", form.carId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {

                            conn.Open();
                            String query = "DELETE FROM SupplierTable WHERE SupplierId = @SupplierId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@SupplierId", form.supplierId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {

                            conn.Open();
                            String query = "DELETE FROM BuyerTable WHERE BuyerId = @BuyerId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@BuyerId", form.buyerId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception exp) {


                    MessageBox.Show("Error : " + exp.Message);
                }
            }
            else {

                MessageBox.Show("Please Enter All Fields..");
            }
        }

        private void SelectStaffButton_Click(object sender, EventArgs e)
        {
            SelectStaffForm staffForm = new SelectStaffForm();
            if (staffForm.ShowDialog() == DialogResult.OK)
            {
                StaffIdTextBox.Text = staffForm.staffId.ToString();
            }
        }
    }
}
