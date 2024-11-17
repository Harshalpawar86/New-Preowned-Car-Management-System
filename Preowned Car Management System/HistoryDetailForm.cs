using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using CrystalDecisions.Shared;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Org.BouncyCastle.Asn1.Crmf;
using PdfiumViewer;


namespace Preowned_Car_Management_System
{
    public partial class HistoryDetailForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        long carId;
        decimal grossProfitLoss;
        int staffId;
        String buyerAddress = "";
        String sellerAddress = "";
        private Dictionary<string, (int TotalSoldCount, decimal TotalPrice)> accessoryInfoForPDF;
        private decimal totalAccessoryAmountForPDF;


        public HistoryDetailForm(long carId)
        {
            InitializeComponent();
            this.carId = carId;
        }

        private void HistoryDetailForm_Load(object sender, EventArgs e)
        {
            LoadHistoryDetails();
        }
        void LoadHistoryTable() {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM HistoryTable WHERE CarId = @CarId";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarId", carId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            pictureBox1.Image = ConvertToImage((byte[])reader["CarImage"]);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            CarNameLabel.Text = $"Car Name: {reader["CarName"].ToString()}";
                            CarIdTextBox.Text = $"Car Id: {reader["CarId"].ToString()}";
                            OwnerLabel.Text = $"Owner Type: {reader["OwnerType"].ToString()}";
                            SellerNameLabel.Text = $"Seller Name: {reader["SupplierName"].ToString()}";
                            SellerIdLabel.Text = $"Seller Id: {reader["SupplierId"].ToString()}";
                            BuyerNameLabel.Text = $"Buyer Name: {reader["BuyerName"].ToString()}";
                            buyerAddress = $"Buyer Address: {reader["BuyerAddress"].ToString()}";
                            sellerAddress = $"Buyer Address: {reader["SupplierAddress"].ToString()}";
                            BuyerIdLabel.Text = $"Buyer Id: {reader["BuyerId"].ToString()}";
                            SellingAmtLabel.Text = $"Selling Amount : ₹{reader["AmountPaid"].ToString()}";
                            BuyingAmountLabel.Text = $"Buying Amount : ₹{reader["AmountRecieved"].ToString()}";
                            SellingDateTextBox.Text = $"Selling Date : {reader["PurchaseDate"].ToString()}";
                            grossProfitLoss = Convert.ToDecimal(reader["ProfitOrLoss"]);

                            if (grossProfitLoss > 0)
                            {
                                AmountLabel.ForeColor = System.Drawing.Color.LimeGreen;
                                AmountLabel.Text = $"Profit : ₹{reader["ProfitOrLoss"].ToString()}";
                            }
                            else
                            {

                                AmountLabel.ForeColor = System.Drawing.Color.Red;
                                AmountLabel.Text = $"Loss : ₹{reader["ProfitOrLoss"].ToString()}";
                            }
                            SellerNumberLabel.Text = $"Seller Mobile Number: {reader["SupplierMobileNumber"].ToString()}";
                            BuyerMobileLabel.Text = $"Buyer Mobile Number: {reader["BuyerMobileNumber"].ToString()}";
                            CarInfoLabel.Text = $"Car Info: {reader["CarInfo"].ToString()}";
                            staffId = Convert.ToInt32(reader["StaffId"]);

                            if (reader["MaintenanceId"] == DBNull.Value || reader["MaintenanceId"].ToString() == "0" || string.IsNullOrEmpty(reader["MaintenanceId"].ToString()))
                            {
                                MaintenanceIdLabel.Text = "Maintenance Id : N/A";
                            }
                            else
                            {
                                MaintenanceIdLabel.Text = $"Maintenance Id: {reader["MaintenanceId"].ToString()}";
                            }

                            if (MaintenanceIdLabel.Text == "Maintenance Id : N/A")
                            {
                                MaintenanceInfoLabel.Text = "Maintenance Information : N/A";
                            }
                        }
                    }


                }
                conn.Close();
            }
        }
        void LoadStaffTable() {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String query = "SELECT * FROM StaffTable WHERE StaffId = @StaffId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                StaffNameLabel.Text = $"Staff Name : {reader["StaffName"].ToString()}";
                                StaffIdLabel.Text = $"Staff Id : {reader["StaffId"].ToString()}";
                                StaffMobileLabel.Text = $"Staff Mobile Number : {reader["StaffNumber"].ToString()}";
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error No staff Id Doesnt Exist " + staffId + "\n" + ex.Message);
            }
        }
        void LoadMaintenanceTable() {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaintenanceInfo, MaintenanceCost FROM MaintenanceTable WHERE CarId = @CarId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            string maintenanceInfo = "Maintenance Information:\n";
                            decimal totalMaintenanceCost = 0;

                            while (reader.Read())
                            {
                                string info = reader["MaintenanceInfo"].ToString();
                                decimal cost = Convert.ToDecimal(reader["MaintenanceCost"]);

                                maintenanceInfo += $"{info}{Environment.NewLine}";

                                totalMaintenanceCost += cost;
                            }

                            MaintenanceInfoLabel.Text = maintenanceInfo.TrimEnd();  
                            decimal mCost = totalMaintenanceCost;  
                            if (mCost != 0)
                            {
                                mCostLabel.Text = "Maintenance Cost : ₹" + mCost.ToString();
                            }
                            else
                            {
                                mCostLabel.ForeColor = System.Drawing.Color.FromArgb(0, 106, 255);
                                mCostLabel.Text = "Maintenance Cost : N/A";
                            }
                            

                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        void LoadAccessoryTable() {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AccessoryName, AccessoryPrice, AccessorySoldCount, TotalPrice FROM AccessorySales WHERE CarId = @CarId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Dictionary<string, (int TotalSoldCount, decimal TotalPrice)> accessoryInfo = new Dictionary<string, (int, decimal)>();

                            decimal totalAccessoryAmount = 0;

                            while (reader.Read())
                            {
                                string accessoryName = reader["AccessoryName"].ToString();
                                int accessorySoldCount = reader.GetInt32(reader.GetOrdinal("AccessorySoldCount"));
                                decimal totalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice"));

                                if (accessoryInfo.ContainsKey(accessoryName))
                                {
                                    accessoryInfo[accessoryName] = (
                                        accessoryInfo[accessoryName].TotalSoldCount + accessorySoldCount,
                                        accessoryInfo[accessoryName].TotalPrice + totalPrice
                                    );
                                }
                                else
                                {
                                    accessoryInfo.Add(accessoryName, (accessorySoldCount, totalPrice));
                                }

                                totalAccessoryAmount += totalPrice;
                            }

                            string accessoryNames = "Accessory Information:\n";

                            foreach (var entry in accessoryInfo)
                            {
                                accessoryNames += $"{entry.Key} - {entry.Value.TotalSoldCount} [₹{entry.Value.TotalPrice:F2}]{Environment.NewLine}";
                            }

                            AccessoryInformtaionLabel.Text = accessoryNames.TrimEnd();

                            AccessoryAmountLabel.Text = $"Accessory Amount : ₹{totalAccessoryAmount:F2}";
                            accessoryInfoForPDF = accessoryInfo;
                            totalAccessoryAmountForPDF = totalAccessoryAmount;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            if (string.IsNullOrWhiteSpace(AccessoryInformtaionLabel.Text) || AccessoryInformtaionLabel.Text == "Accessory Information:")
            {
                AccessoryInformtaionLabel.Text = "Accessory Information: N/A";
            }


            LoadTotalBuyingAmount();
        }
        private void LoadHistoryDetails()
        {
            LoadHistoryTable();//get staff id from here then load staff table only
            LoadStaffTable();
            LoadMaintenanceTable();
            LoadAccessoryTable();
            LoadTotalProfit();
        }
        void LoadTotalProfit() {

            decimal grossProfit = ExtractAmountFromLabel(AmountLabel);
            decimal maintenanceCost = ExtractMaintenanceCost(mCostLabel);
            decimal staffCommission = ExtractStaffCommission(StaffComissionLabel);

            decimal netProfit = (grossProfit - (maintenanceCost+ staffCommission));
            if (netProfit >= 0)
            {

                TotalProfitLabel.Text = "Net Profit : " + netProfit;
                TotalProfitLabel.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else
            {

                TotalProfitLabel.Text = "Net Loss : " + netProfit;
                TotalProfitLabel.ForeColor = System.Drawing.Color.Red;
            }

        }
        decimal ExtractStaffCommission(Label staffCommissionLabel)
        {
            if (staffCommissionLabel.Text.Contains("N/A"))
            {
                return 0;  
            }

            string text = staffCommissionLabel.Text.Replace("Staff Commission: ₹", "").Trim();

            if (decimal.TryParse(text, out decimal commission))
            {
                return commission;
            }

            return 0;
        }

        decimal ExtractMaintenanceCost(Label mCostLabel)
        {
            if (mCostLabel.Text.Contains("N/A"))
            {
                return 0;  
            }

            string text = mCostLabel.Text.Replace("Maintenance Cost : ₹", "").Trim();

            if (decimal.TryParse(text, out decimal maintenanceCost))
            {
                return maintenanceCost;
            }

            return 0;
        }

        decimal ExtractAmountFromLabel(Label label)
        {
            string labelText = label.Text;

            string numericPart = labelText.Replace("Profit : ₹", "")
                                          .Replace("Loss : ₹", "")
                                          .Trim();

            decimal amount = 0;
            decimal.TryParse(numericPart, out amount);

            return amount;
        }

        void loadStaffCommission(decimal amt)
        {
            decimal commission = 100;
            if (amt >= 0)
            {
                commission = (1M * amt) / 100;
            }
            StaffComissionLabel.Text = "Staff Commission: ₹" + commission.ToString("F2");
            StaffCommissionCost.Text = "Staff Commission: ₹" + commission.ToString("F2");
        }
        void LoadTotalBuyingAmount() {

            string buyinglabelText = BuyingAmountLabel.Text;

            string buyingnumericPart = buyinglabelText.Replace("Buying Amount : ", "").Replace("₹", "").Trim();

            decimal buyingamt = Convert.ToDecimal(buyingnumericPart);
            string accessorylabelText = AccessoryAmountLabel.Text;

            string accessorynumericpart = accessorylabelText.Replace("Accessory Amount : ", "").Replace("₹", "").Trim();

            decimal accessoryamt = Convert.ToDecimal(accessorynumericpart);
            TotalBuyingAmountLabel.Text = "Total Buying Amount : ₹" + (buyingamt + accessoryamt);
            loadStaffCommission(buyingamt + accessoryamt);
        }


        private System.Drawing.Image ConvertToImage(byte[] image)
        {
            using (MemoryStream ms = new MemoryStream(image))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CarNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MaintenanceInfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        void generateSellerBill() {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "K&P Car Resalers";
                saveFileDialog.FileName = $"Bill_Sell_{carId}.pdf"; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (PdfWriter writer = new PdfWriter(filePath))
                    {
                        using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                        {
                            Document document = new Document(pdf);

                            Table logoTitleTable = new Table(2);
                            logoTitleTable.SetWidth(UnitValue.CreatePercentValue(100));

                            ImageData logoData = ImageDataFactory.Create("E:\\College Project\\Preowned Car Management System\\Preowned Car Management System\\Resources\\logo_preowned.png");
                            iText.Layout.Element.Image logo = new iText.Layout.Element.Image(logoData);

                            logo.SetHeight(100);
                            logo.SetWidth(100);

                            Cell logoCell = new Cell().Add(logo)
                                .SetBorder(Border.NO_BORDER)
                                .SetTextAlignment(TextAlignment.LEFT);
                            logoTitleTable.AddCell(logoCell);

                            Paragraph title = new Paragraph("Invoice")
                                .SetFontSize(30)
                                .SetBold()
                                .SetTextAlignment(TextAlignment.RIGHT);
                            Cell titleCell = new Cell().Add(title)
                                .SetBorder(Border.NO_BORDER)
                                .SetTextAlignment(TextAlignment.RIGHT);
                            logoTitleTable.AddCell(titleCell);

                            document.Add(logoTitleTable);

                            Table headerTable = new Table(2);
                            headerTable.SetWidth(UnitValue.CreatePercentValue(100));

                            string from = "From,";
                            string systemName = "Pre-Owned Car Management System";
                            string systemAddress = "ShivajiNagar,Pune";
                            string systemNumber = "+91 9876543210";
                            string systemEmail = "kp123@gmail.com";
                            string invoiceNumber = "#SELL_" + carId;
                           

                            Paragraph fromDetails = new Paragraph()
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetFontSize(14)
                                .SetBold()
                                .Add(from + "\n")
                                .Add($"{systemName}\n")
                                .Add($"{systemEmail}\n")
                                .Add($"{systemNumber}\n")
                                .Add($"{systemAddress}\n")
                                .Add("\n")
                                .Add($"{invoiceNumber}\n")
                                .Add("\n");

                            Cell fromCell = new Cell().Add(fromDetails)
                                .SetBorder(Border.NO_BORDER);
                            headerTable.AddCell(fromCell);

                            string to = "To,";
                            string customerName = SellerNameLabel.Text.Split(':')[1].Trim();
                            string customerId = SellerIdLabel.Text;
                            string address = sellerAddress.Split(':')[1].Trim();
                            string number = SellerNumberLabel.Text.Split(':')[1].Trim();

                            List<string> addressLines = SplitAddress(address, 25);

                            Paragraph toDetails = new Paragraph()
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFontSize(14)
                                .SetBold()
                                .Add(to + "\n")
                                .Add(customerId + "\n")
                                .Add(customerName + "\n");

                            foreach (var line in addressLines)
                            {
                                toDetails.Add(line + "\n");
                            }

                            toDetails.Add(number + "\n");
                            toDetails.Add(CarIdTextBox.Text);

                            Cell toCell = new Cell().Add(toDetails)
                                .SetBorder(Border.NO_BORDER);
                            headerTable.AddCell(toCell);

                            document.Add(headerTable);

                            string carName = CarNameLabel.Text.Split(':')[1].Trim(); 
                            Table carNameTable = new Table(2);
                            carNameTable.SetWidth(530);
                            
                            String sellingCost = SellingAmtLabel.Text.Split(':')[1].Trim(); 
                            carNameTable.AddHeaderCell("Car Name").SetTextAlignment(TextAlignment.CENTER);
                            carNameTable.AddHeaderCell("Price").SetTextAlignment(TextAlignment.CENTER);
                            carNameTable.AddCell(carName).SetTextAlignment(TextAlignment.CENTER);
                            carNameTable.AddCell($"₹{sellingCost}").SetTextAlignment(TextAlignment.CENTER);

                            document.Add(carNameTable);
               
                            document.Add(new Paragraph("\nThank you for your business!")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetMarginTop(20)
                                .SetFontSize(12));
                            Paragraph stamp = new Paragraph("Stamp")
                                .SetFontSize(20)         
                                .SetBold()
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 120, 30, 100); 
                            document.Add(stamp);


                            document.Close();
                        }
                    }

                    MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        void generateBuyerBill() {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.Title = "K&P Car Resalers";
                saveFileDialog.FileName = $"Bill_Buy_{carId}.pdf"; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (PdfWriter writer = new PdfWriter(filePath))
                    {
                        using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                        {
                            Document document = new Document(pdf);

                            Table logoTitleTable = new Table(2);
                            logoTitleTable.SetWidth(UnitValue.CreatePercentValue(100));

                            ImageData logoData = ImageDataFactory.Create("E:\\College Project\\Preowned Car Management System\\Preowned Car Management System\\Resources\\logo_preowned.png");
                            iText.Layout.Element.Image logo = new iText.Layout.Element.Image(logoData);

                            logo.SetHeight(100);
                            logo.SetWidth(100);

                            Cell logoCell = new Cell().Add(logo)
                                .SetBorder(Border.NO_BORDER)
                                .SetTextAlignment(TextAlignment.LEFT);
                            logoTitleTable.AddCell(logoCell);

                            Paragraph title = new Paragraph("Invoice")
                                .SetFontSize(30)
                                .SetBold()
                                .SetTextAlignment(TextAlignment.RIGHT);
                            Cell titleCell = new Cell().Add(title)
                                .SetBorder(Border.NO_BORDER)
                                .SetTextAlignment(TextAlignment.RIGHT);
                            logoTitleTable.AddCell(titleCell);

                            document.Add(logoTitleTable);

                            Table headerTable = new Table(2);
                            headerTable.SetWidth(UnitValue.CreatePercentValue(100));

                            string from = "From,";
                            string systemName = "Pre-Owned Car Management System";
                            string systemAddress = "ShivajiNagar,Pune";
                            string systemNumber = "+91 9876543210";
                            string systemEmail = "kp123@gmail.com";
                            string invoiceNumber = "#SELL_" + carId;
                            string staffName = StaffNameLabel.Text;
                            string staffNumber = StaffMobileLabel.Text;
                            string staffId = StaffIdLabel.Text;

                            Paragraph fromDetails = new Paragraph()
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetFontSize(14)
                                .SetBold()
                                .Add(from + "\n")
                                .Add($"{systemName}\n")
                                .Add($"{systemEmail}\n")
                                .Add($"{systemNumber}\n")
                                .Add($"{systemAddress}\n")
                                .Add("\n")
                                .Add($"{staffName}\n")
                                .Add($"{staffNumber}\n")
                                .Add($"{staffId}\n")
                                .Add($"{invoiceNumber}\n")
                                .Add("\n");

                            Cell fromCell = new Cell().Add(fromDetails)
                                .SetBorder(Border.NO_BORDER);
                            headerTable.AddCell(fromCell);

                            string to = "To,";
                            string customerName = BuyerNameLabel.Text.Split(':')[1].Trim();
                            string customerId = BuyerIdLabel.Text;
                            string address = buyerAddress.Split(':')[1].Trim();
                            string number = BuyerMobileLabel.Text.Split(':')[1].Trim();

                            List<string> addressLines = SplitAddress(address, 25); 

                            Paragraph toDetails = new Paragraph()
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFontSize(14)
                                .SetBold()
                                .Add(to + "\n")
                                .Add(customerId + "\n")
                                .Add(customerName + "\n");

                            foreach (var line in addressLines)
                            {
                                toDetails.Add(line + "\n");
                            }

                            toDetails.Add(number + "\n");
                            toDetails.Add(CarIdTextBox.Text);

                            Cell toCell = new Cell().Add(toDetails)
                                .SetBorder(Border.NO_BORDER);
                            headerTable.AddCell(toCell);

                            document.Add(headerTable);

                            string carName = CarNameLabel.Text.Split(':')[1].Trim(); 

                            Table carNameTable = new Table(2);
                            carNameTable.SetWidth(UnitValue.CreatePercentValue(100));
                            string amountText = BuyingAmountLabel.Text.Split(':')[1].Trim();

                            decimal sellingCost = decimal.Parse(amountText.Replace("₹", "").Trim());
                            carNameTable.AddHeaderCell("Car Name");
                            carNameTable.AddHeaderCell("Price");
                            carNameTable.AddCell(carName);
                            carNameTable.AddCell("₹" + sellingCost);

                            document.Add(carNameTable);

                            Table accessoryTable = new Table(4);
                            accessoryTable.SetWidth(UnitValue.CreatePercentValue(100));

                            accessoryTable.AddHeaderCell("Accessory");
                            accessoryTable.AddHeaderCell("Count");
                            accessoryTable.AddHeaderCell("Price");
                            accessoryTable.AddHeaderCell("Total Price");

                            decimal totalAccessoryCost = 0;

                            if (accessoryInfoForPDF.Count == 0)
                            {
                                accessoryTable.AddCell(new Paragraph("No accessories"));
                                accessoryTable.AddCell(new Paragraph("N/A")); 
                                accessoryTable.AddCell(new Paragraph("N/A"));
                                accessoryTable.AddCell(new Paragraph("N/A"));
                            }
                            else
                            {
                                foreach (var entry in accessoryInfoForPDF)
                                {
                                    string accessoryName = entry.Key;
                                    int count = entry.Value.TotalSoldCount;
                                    decimal totalPrice = entry.Value.TotalPrice;
                                    decimal price = count > 0 ? totalPrice / count : 0; 
                                  
                                    accessoryTable.AddCell(new Paragraph(accessoryName));
                                    accessoryTable.AddCell(new Paragraph(count.ToString()));
                                    accessoryTable.AddCell(new Paragraph(price.ToString())); 
                                    accessoryTable.AddCell(new Paragraph(totalPrice.ToString())); 

                                    totalAccessoryCost += totalPrice; 
                                }
                            }

                            document.Add(accessoryTable);

                            decimal totalCost = sellingCost + totalAccessoryCost;



                            Table summaryTable = new Table(2);
                            summaryTable.SetWidth(UnitValue.CreatePercentValue(100));
                            summaryTable.SetMarginTop(20); 

                            summaryTable.AddCell(new Cell().Add(new Paragraph("Selling Cost").SetBold()).SetPadding(5).SetBorder(Border.NO_BORDER));
                            summaryTable.AddCell(new Cell().Add(new Paragraph(sellingCost.ToString())).SetPadding(5).SetBorder(Border.NO_BORDER)); // Format as currency

                            summaryTable.AddCell(new Cell().Add(new Paragraph("Total Accessories Cost").SetBold()).SetPadding(5).SetBorder(Border.NO_BORDER));
                            summaryTable.AddCell(new Cell().Add(new Paragraph(totalAccessoryCost.ToString())).SetPadding(5).SetBorder(Border.NO_BORDER)); // Format as currency

                            summaryTable.AddCell(new Cell().Add(new Paragraph("Total Selling Cost").SetBold()).SetPadding(5).SetBorder(Border.NO_BORDER));
                            summaryTable.AddCell(new Cell().Add(new Paragraph(totalCost.ToString()).SetBold()).SetPadding(5).SetBorder(Border.NO_BORDER)); // Format as currency

                            document.Add(summaryTable);

                            document.Add(new Paragraph("\nThank you for your business!")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetMarginTop(20)
                                .SetFontSize(12));
                            Paragraph stamp = new Paragraph("Stamp")
                                .SetFontSize(20)          
                                .SetBold()
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 120, 30, 100); 

                            document.Add(stamp);


                            document.Close();
                        }
                    }

                    MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void Selling_Bill_Button_Click(object sender, EventArgs e)
        {
            generateBuyerBill();
            
        }
        private List<string> SplitAddress(string address, int maxLineLength)
        {
            var lines = new List<string>();
            while (address.Length > maxLineLength)
            {
                int lastSpaceIndex = address.LastIndexOf(' ', maxLineLength);
                if (lastSpaceIndex < 0) lastSpaceIndex = maxLineLength; 

                lines.Add(address.Substring(0, lastSpaceIndex).Trim());
                address = address.Substring(lastSpaceIndex).Trim();
            }
            if (!string.IsNullOrEmpty(address))
            {
                lines.Add(address);
            }

            return lines;
        }

        private void Seller_Bill_Button_Click(object sender, EventArgs e)
        {
            generateSellerBill();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
