using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class AccessoriesForm : Form
    {
        ContextMenuStrip contextMenu;
        String connectionString = DashBoardForm.connectionString;
        static List<AccessoryData> accessoryDataList = null;
        public AccessoriesForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update Accessory Record", null, ContextMenuOption1_Click);
            contextMenu.Items.Add("Delete Faulty Accessories", null, ContextMenuOption2_Click);
        }
        public void AddAccessoriesData(long accessoryId, string accessoriesName, string accessoriesDate, Image accessoriesImage, int accessoriesCount, decimal price)
        {
            Panel panel = new Panel();
            panel.Tag = accessoryId;
            panel.Name = "AccessoriesData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Padding = new Padding(10);
            pictureBox.Name = "AccessoriesImage";
            pictureBox.Size = new Size(200, 150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox.Image = accessoriesImage;

            Label label1 = new Label();
            label1.Name = "AccessoriesNameLabel";
            label1.Text = "Accessory Name : " + accessoriesName;
            label1.Location = new Point(12, pictureBox.Bottom + 5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label idLabel = new Label();
            idLabel.Name = "AccessoryIdLabel";
            idLabel.Text = "Accessory Id : " + accessoryId;
            idLabel.Location = new Point(12, label1.Bottom + 5);
            idLabel.ForeColor = Color.Black;
            idLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            idLabel.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "AccessoriesCountLabel";
            label2.Text = "Accessory Count : " + accessoriesCount;
            label2.Location = new Point(12, idLabel.Bottom + 5);
            if (accessoriesCount == 0)
            {

                label2.ForeColor = Color.Red;

            }
            else
            {
                label2.ForeColor = Color.Black;

            }
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label plabel = new Label();
            plabel.Name = "AccessoriesPriceLabel";
            plabel.Text = "Accessory Price : " + price;
            plabel.Location = new Point(12, label2.Bottom + 5);
            plabel.ForeColor = Color.Black;
            plabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            plabel.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "AccessoriesDateLabel";
            label3.Text = "Purchase Date : " + accessoriesDate;
            label3.Location = new Point(12, plabel.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label1);
            panel.Controls.Add(idLabel);
            panel.Controls.Add(label2);
            panel.Controls.Add(plabel);
            panel.Controls.Add(label3);

            panel.MouseClick += Panel_MouseClick;
            pictureBox.MouseClick += Panel_MouseClick;
            label1.MouseClick += Panel_MouseClick;
            label2.MouseClick += Panel_MouseClick;

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

        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl is Panel panel)
            {
                long accessoryId = (long)panel.Tag;

                UpdateAccessoryForm form = new UpdateAccessoryForm(accessoryId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Data Updated Successfully..", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                    var accessoryData = accessoryDataList.FirstOrDefault(a => a.AccessoryId == accessoryId);
                    if (accessoryData != null)
                    {

                        accessoryData.AccessoryName = form.AccessoryName;
                        accessoryData.AccessoryId = form.AccessoryId;
                        accessoryData.AccessoryPrice = form.AccessoryPrice;
                        accessoryData.AccessoryDate = form.AccessoryDate;


                    }
                    flowLayoutPanel1.Controls.Clear();
                    LoadExistingData();
                }
            }
        }
        private void ContextMenuOption2_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl is Panel panel)
            {
                long accessoryId = (long)panel.Tag;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this Accessory ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);


                if (result == DialogResult.Yes)
                {

                    try
                    {

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            String query = "DELETE FROM AccessoryTable WHERE AccessoryId=@AccessoryId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {

                                cmd.Parameters.AddWithValue("@AccessoryId", accessoryId);
                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();
                            MessageBox.Show("Accessory data Deleted Successfully", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                            var accessoryData = accessoryDataList.FirstOrDefault(a => a.AccessoryId == accessoryId);
                            if (accessoryData != null)
                            {

                                accessoryDataList.Remove(accessoryData);
                            }
                        }
                    }
                    catch (Exception exp)
                    {

                        MessageBox.Show("Something went wrong data not deleted", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                        MessageBox.Show(exp.ToString());
                    }

                    LoadExistingData();
                }
            }
        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {

        }
        private byte[] convertImage(String imageString)
        {

            Image image = Image.FromFile(imageString);

            using (MemoryStream ms = new MemoryStream())
            {

                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private Image convertFromBytes(byte[] imageBytes)
        {

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {

                return Image.FromStream(ms);
            }
        }
        private void LoadExistingData()
        {
            //        try
            //        {
            //            flowLayoutPanel1.Controls.Clear();
            //            using (SqlConnection conn = new SqlConnection(connectionString))
            //            {
            //                conn.Open();
            //                String query = "SELECT * FROM AccessoryTable";
            //                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
            //                {

            //                    DataTable dataTable = new DataTable();
            //                    sqlDataAdapter.Fill(dataTable);

            //                    foreach (DataRow row in dataTable.Rows)
            //                    {

            //                        string accessoriesName = row["AccessoryName"].ToString();
            //                        int accessoriesCount = Convert.ToInt32(row["AccessoryCount"]);
            //                        string accessoriesDate = row["AccessoryDate"].ToString();
            //                        Image image = convertFromBytes((byte[])row["AccessoryImage"]);
            //                        double accessoryprice = Convert.ToDouble(row["AccessoryPrice"]);
            //                        long accessoryId = Convert.ToInt64(row["AccessoryId"]);

            //                        AddAccessoriesData(accessoryId: accessoryId, accessoriesName: accessoriesName, accessoriesDate: accessoriesDate, accessoriesImage: image, accessoriesCount: accessoriesCount, price: accessoryprice);

            //                    }
            //                }
            //                conn.Close();
            //            }
            //        }
            //        catch (Exception exp) {

            //            MessageBox.Show("Something went wrong data not loaded", "Error", 
            //MessageBoxButtons.OK, 
            //MessageBoxIcon.Error,
            //MessageBoxDefaultButton.Button1);
            //            MessageBox.Show(exp.ToString());
            //        }
            flowLayoutPanel1.Controls.Clear();
            if (accessoryDataList != null && accessoryDataList.Count > 0)
            {

                foreach (var accessoryData in accessoryDataList)
                {

                    AddAccessoriesData(
                        accessoryId: accessoryData.AccessoryId,
                        accessoriesName: accessoryData.AccessoryName,
                        accessoriesDate: accessoryData.AccessoryDate,
                        accessoriesImage: accessoryData.AccessoryImage,
                        accessoriesCount: accessoryData.AccessoryCount,
                        price: accessoryData.AccessoryPrice
                    );
                }
                // MessageBox.Show("Retrieved from List");
                return;
            }
            try
            {

                accessoryDataList = new List<AccessoryData>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM AccessoryTable";  // Modify your query as per requirements
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            AccessoryData accessoryData = new AccessoryData
                            {
                                AccessoryName = row["AccessoryName"].ToString(),
                                AccessoryCount = Convert.ToInt32(row["AccessoryCount"]),
                                AccessoryDate = row["AccessoryDate"].ToString(),
                                AccessoryImage = convertFromBytes((byte[])row["AccessoryImage"]),
                                AccessoryPrice = Convert.ToDecimal(row["AccessoryPrice"]),
                                AccessoryId = Convert.ToInt64(row["AccessoryId"])

                            };

                            accessoryDataList.Add(accessoryData);  // Add to the cached list

                            // Add the supplier info to the UI (flowLayoutPanel1)
                            AddAccessoriesData(
                                accessoryId: accessoryData.AccessoryId,
                                accessoriesName: accessoryData.AccessoryName,
                                accessoriesDate: accessoryData.AccessoryDate,
                                accessoriesImage: accessoryData.AccessoryImage,
                                accessoriesCount: accessoryData.AccessoryCount,
                                price: accessoryData.AccessoryPrice
                            );

                        }
                        // MessageBox.Show("Retrieved from Database");
                    }
                }


            }
            catch (Exception exp) { }
        }

        private void AddBuyerButton_Click(object sender, EventArgs e)
        {
            AddAccessoriesForm addAccessoriesForm = new AddAccessoriesForm();
            if (addAccessoriesForm.ShowDialog() == DialogResult.OK)
            {
                String accessoriesName = addAccessoriesForm.accessoriesName;
                String accessoriesDate = addAccessoriesForm.accessoriesDate;
                int accessoriesCount = addAccessoriesForm.accessoriesCount;
                String image = addAccessoriesForm.ImagePath;
                decimal accessoryPrice = addAccessoriesForm.accessoriesPrice;
                long accessoryId = addAccessoriesForm.accessoryId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "INSERT INTO AccessoryTable(AccessoryId,AccessoryName,AccessoryDate,AccessoryCount,AccessoryImage,AccessoryPrice) VALUES (@AccessoryId,@AccessoryName,@AccessoryDate,@AccessoryCount,@AccessoryImage,@AccessoryPrice);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@AccessoryName", accessoriesName);
                        cmd.Parameters.AddWithValue("@AccessoryDate", accessoriesDate);
                        cmd.Parameters.AddWithValue("@AccessoryCount", accessoriesCount);
                        cmd.Parameters.AddWithValue("@AccessoryImage", convertImage(image));
                        cmd.Parameters.AddWithValue("@AccessoryPrice", accessoryPrice);
                        cmd.Parameters.AddWithValue("@AccessoryId", accessoryId);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {

                            MessageBox.Show("Data Inserted Successfully", "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
                            Image image1 = convertFromBytes(convertImage(image));
                            AccessoryData accessoryData = new AccessoryData
                            {

                                AccessoryId = accessoryId,
                                AccessoryPrice = accessoryPrice,
                                AccessoryCount = accessoriesCount,
                                AccessoryDate = accessoriesDate,
                                AccessoryImage = image1,
                                AccessoryName = accessoriesName
                            };
                            accessoryDataList.Add(accessoryData);

                            AddAccessoriesData(
                                accessoryId: accessoryId,
                                accessoriesName: accessoriesName,
                                accessoriesDate: accessoriesDate,
                                accessoriesImage: image1,
                                accessoriesCount: accessoriesCount,
                                price: accessoryPrice
                            );

                        }
                        else
                        {

                            MessageBox.Show("Data Insertion Failed", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                flowLayoutPanel1.Controls.Clear();
                LoadExistingData();

            }
        }

        private void AccessoriesForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Accessory Name to Search", "Input Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);

            }
            else
            {
                searchAccessory(SearchTextBox.Text);

            }
        }
        private void searchAccessory(String name)
        {

            flowLayoutPanel1.Controls.Clear();
            try
            {

                String query = "SELECT * FROM AccessoryTable WHERE AccessoryName=@AccessoryName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AccessoryName", name);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                string accessoriesName = reader["AccessoryName"].ToString();
                                int accessoriesCount = Convert.ToInt32(reader["AccessoryCount"]);
                                string accessoriesDate = reader["AccessoryDate"].ToString();
                                Image image = convertFromBytes((byte[])reader["AccessoryImage"]);
                                decimal accessoryprice = Convert.ToDecimal(reader["AccessoryPrice"]);
                                long accessoryId = Convert.ToInt64(reader["AccessoryId"]);
                                AddAccessoriesData(accessoryId: accessoryId, accessoriesName: accessoriesName, accessoriesDate: accessoriesDate, accessoriesImage: image, accessoriesCount: accessoriesCount, price: accessoryprice);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Accessory Record not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
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
    public class AccessoryData
    {

        public long AccessoryId { get; set; }
        public string AccessoryName { get; set; }
        public int AccessoryCount { get; set; }
        public string AccessoryDate { get; set; }
        public Image AccessoryImage { get; set; }
        public decimal AccessoryPrice { get; set; }
    }
}