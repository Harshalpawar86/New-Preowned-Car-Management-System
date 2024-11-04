using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CrystalDecisions.Shared;
using iText.Layout;
using iText.Layout.Borders;
using Org.BouncyCastle.Asn1.Crmf;
using PdfiumViewer;


namespace Preowned_Car_Management_System
{
    public partial class SupplierForm : Form
    {
        ContextMenuStrip contextMenu;
        String connectionString = DashBoardForm.connectionString;
        //Trust Server Certificate=True
        public SupplierForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Generate Bill", null, ContextMenuOption1_Click);
            contextMenu.Items.Add("Update Information", null, ContextMenuOption2_Click);
            contextMenu.Items.Add("Delete Supplier", null, ContextMenuOption3_Click);
        }
        public void AddSupplierInfo(string supplierName, string carName, decimal amountPaid,long carId, long supplierId, long mobileNumber, string address)
        {
            Panel panel = new Panel();
            panel.Name = "SupplierData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Tag = carId;
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label label1 = new Label();
            label1.Name = "SupplierNameLabel";
            label1.Text = "Supplier Name : "+supplierName;
            label1.Location = new Point(12, 5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "CarNameLabel";
            label2.Text = "Car Name : "+carName;
            label2.Location = new Point(12, label1.Bottom + 5);
            label2.ForeColor = Color.Black;
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "CarIdLabel";
            label3.Text = "Car Id : "+carId;
            label3.Location = new Point(12, label2.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            Label supplierIdLabel = new Label();
            supplierIdLabel.Name = "SupplierIdLabel";
            supplierIdLabel.Text = "Supplier Id : "+supplierId;
            supplierIdLabel.Location = new Point(12, label3.Bottom + 5);
            supplierIdLabel.ForeColor = Color.Black;
            supplierIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            supplierIdLabel.AutoSize = true;

            Label mobileNumberLabel = new Label();
            mobileNumberLabel.Name = "MobileNumberLabel";
            mobileNumberLabel.Text = "Mobile Number : "+mobileNumber;
            mobileNumberLabel.Location = new Point(12, supplierIdLabel.Bottom + 5);
            mobileNumberLabel.ForeColor = Color.Black;
            mobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            mobileNumberLabel.AutoSize = true;

            Label addressLabel = new Label();
            addressLabel.Name = "CarInfoLabel";
            addressLabel.Text = "Supplier Address : "+address;
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
        private void ContextMenuOption3_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("Are you sure you want to delete this supplier?\nStock for this Supplier will also be deleted!!",
                                                          "Confirm Deletion",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Warning);
            if (dresult == DialogResult.OK)
            {
                if (contextMenu.SourceControl is Panel panel)
                {

                    long carId = (long)panel.Tag;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        String query = "DELETE FROM SupplierTable WHERE CarId = @CarId";
                        String query2 = "DELETE FROM StockTable WHERE CarId = @CarId";
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarId", carId);
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Supplier Data Deleted", "Deletion Successful",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                                flowLayoutPanel1.Controls.Clear();
                                LoadExistingData();
                            }
                        }
                        using (SqlCommand cmd = new SqlCommand(query2, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarId", carId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

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
        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl is Panel panel)
            {
                long carId = (long)panel.Tag;

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


                                string customerNamedb = "";
                                string customerIddb = "";
                                string addressdb = "";
                                string numberdb = "";
                                string carNamedb = "";
                                String sellingCostdb = "";
                                try
                                {
                                    using (SqlConnection conn = new SqlConnection(connectionString)) {
                                               
                                        conn.Open();
                                        String query = "SELECT * FROM SupplierTable WHERE CarId=@CarId";
                                        using (SqlCommand cmd = new SqlCommand(query, conn)) {

                                            cmd.Parameters.AddWithValue("CarId",carId);
                                            using (SqlDataReader reader = cmd.ExecuteReader())
                                            {
                                                if (reader.Read()) // Check if there is any result
                                                {
                                                    customerNamedb = reader["SupplierName"].ToString();
                                                    customerIddb = reader["SupplierId"].ToString();
                                                    addressdb = reader["SupplierAddress"].ToString();
                                                    numberdb = reader["SupplierMobileNumber"].ToString();
                                                    carNamedb = reader["CarName"].ToString();
                                                    sellingCostdb = reader["AmountPaid"].ToString();
                                                }
                                            }

                                        }
                                    }
                            } catch (Exception exp) {
   
                            }

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
                                string customerName = customerNamedb;
                                string customerId = customerIddb;
                                string address = addressdb;
                                string number = numberdb;

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
                            toDetails.Add("Car Id : "+carId);

                            Cell toCell = new Cell().Add(toDetails)
                                .SetBorder(Border.NO_BORDER);
                            headerTable.AddCell(toCell);

                            document.Add(headerTable);

                                string carName = carNamedb;
                            Table carNameTable = new Table(2);
                            carNameTable.SetWidth(530);

                                String sellingCost = sellingCostdb;
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
        }
        private void ContextMenuOption2_Click(object sender, EventArgs e) {

            if (contextMenu.SourceControl is Panel panel) {

                long carId = (long)panel.Tag;
                using (SqlConnection conn = new SqlConnection(connectionString)) {

                    String query = "SELECT * FROM SupplierTable WHERE CarId=@CarId";
                    using (SqlCommand cmd = new SqlCommand(query,conn)) {

                        cmd.Parameters.AddWithValue("@CarId",carId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) { 
                        
                            UpdateSupplierInfoForm updateSupplierInfoForm = new UpdateSupplierInfoForm();
                            updateSupplierInfoForm.supplierName = reader["SupplierName"].ToString();
                            updateSupplierInfoForm.carName = reader["CarName"].ToString();
                            updateSupplierInfoForm.mobileNumber = Convert.ToInt64(reader["SupplierMobileNumber"]);
                            updateSupplierInfoForm.address = reader["SupplierAddress"].ToString();
                            updateSupplierInfoForm.amountPaid = Convert.ToDecimal(reader["AmountPaid"]);

                            if (updateSupplierInfoForm.ShowDialog() == DialogResult.OK) {

                                string updateQuery = "UPDATE SupplierTable SET SupplierName = @SupplierName, CarName = @CarName, SupplierMobileNumber = @SupplierMobileNumber, AmountPaid = @AmountPaid, SupplierAddress = @SupplierAddress WHERE CarId = @CarId";

                                using (SqlCommand upd = new SqlCommand(updateQuery,conn)) {

                                    upd.Parameters.AddWithValue("@SupplierName", updateSupplierInfoForm.supplierName);
                                    upd.Parameters.AddWithValue("@CarName", updateSupplierInfoForm.carName);
                                    upd.Parameters.AddWithValue("@SupplierMobileNumber", updateSupplierInfoForm.mobileNumber);
                                    upd.Parameters.AddWithValue("@AmountPaid", updateSupplierInfoForm.amountPaid);
                                    upd.Parameters.AddWithValue("@SupplierAddress", updateSupplierInfoForm.address);
                                    upd.Parameters.AddWithValue("@CarId", carId);

                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                    if (result > 0)
                                    {

                                        MessageBox.Show("Supplier Data Updated Successfully", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                                        flowLayoutPanel1.Controls.Clear();
                                        LoadExistingData();
                                    }
                                    else {

                                        MessageBox.Show("Failed to Update Data", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                                    }
                                }
                                String updateQuery2 = "UPDATE StockTable SET CarName=@CarName";
                                using (SqlCommand upd = new SqlCommand(updateQuery2, conn))
                                {

                                    upd.Parameters.AddWithValue("@CarName", updateSupplierInfoForm.carName);
                                 

                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                    
                                }
                            }
                        }
                    }
                    
                }
            }

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
            
        }
        private void LoadExistingData() {

            using (SqlConnection conn = new SqlConnection(connectionString)) {

                String query = "SELECT * FROM SupplierTable;";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn)) {

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows) {

                        String supplierName = row["SupplierName"].ToString();
                        long carId = Convert.ToInt64(row["CarId"]);
                        long supplierId = Convert.ToInt64(row["SupplierId"]);
                        String carName = row["CarName"].ToString();
                        long mobileNumber = Convert.ToInt64(row["SupplierMobileNumber"]);
                        decimal amountPaid = Convert.ToDecimal(row["AmountPaid"]);
                        String address = row["SupplierAddress"].ToString();

                        AddSupplierInfo(supplierName:supplierName,carId:carId,supplierId:supplierId,carName:carName,mobileNumber:mobileNumber,amountPaid:amountPaid,address:address);
                    }
                }
            }
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
                LoadExistingData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            AddSupplierInfo addSupplierInfo = new AddSupplierInfo();
            if (addSupplierInfo.ShowDialog() == DialogResult.OK)
            {
                String supplierName = addSupplierInfo.supplierName;
                long carId = addSupplierInfo.carId;
                long supplierId = addSupplierInfo.supplierId;
                String carName = addSupplierInfo.carName;
                long mobileNumber = addSupplierInfo.mobileNumber;
                String address = addSupplierInfo.address;
                decimal amountPaid = addSupplierInfo.amountPaid;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string query = "INSERT INTO SupplierTable (SupplierId, CarId, SupplierName, CarName, SupplierMobileNumber, AmountPaid, SupplierAddress) " + "VALUES (@SupplierId, @CarId, @SupplierName, @CarName, @SupplierMobileNumber, @AmountPaid, @SupplierAddress)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@SupplierId", addSupplierInfo.supplierId);
                        cmd.Parameters.AddWithValue("@CarId", addSupplierInfo.carId);
                        cmd.Parameters.AddWithValue("@SupplierName", addSupplierInfo.supplierName);
                        cmd.Parameters.AddWithValue("@CarName", addSupplierInfo.carName);
                        cmd.Parameters.AddWithValue("@SupplierMobileNumber", addSupplierInfo.mobileNumber);
                        cmd.Parameters.AddWithValue("@AmountPaid", addSupplierInfo.amountPaid);
                        cmd.Parameters.AddWithValue("@SupplierAddress", addSupplierInfo.address);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {

                            MessageBox.Show("Data Inserted Successfully..", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                        }
                        else
                        {

                            MessageBox.Show("Data Insertion Failed..", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                        }
                    }
                }

                AddSupplierInfo(supplierName: supplierName, carName: carName, amountPaid: amountPaid, carId: carId, supplierId: supplierId, mobileNumber: mobileNumber, address: address);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Supplier Name to Search", "Input Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);

            }
            else
            {
                searchSupplier(SearchTextBox.Text.Trim());

            }
        }
        void searchSupplier(String name) {

            flowLayoutPanel1.Controls.Clear();
            try
            {

                String query = "SELECT * FROM SupplierTable WHERE SupplierName=@SupplierName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("SupplierName", name);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String supplierName = reader["SupplierName"].ToString();
                                String carName = reader["CarName"].ToString();
                                decimal amountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                                long carId = Convert.ToInt64(reader["CarId"]);
                                long supplierId = Convert.ToInt64(reader["SupplierId"]);
                                long mobileNumber = Convert.ToInt64(reader["SupplierMobileNumber"]);
                                String address = reader["SupplierAddress"].ToString();
                                AddSupplierInfo(supplierName: supplierName, carName: carName, amountPaid: amountPaid, carId: carId, supplierId: supplierId, mobileNumber: mobileNumber, address: address);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Supplier not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SearchTextBox.Clear();
            LoadExistingData();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                SearchButton.PerformClick();
            }
        }
    }
}