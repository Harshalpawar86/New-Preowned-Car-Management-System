using CrystalDecisions.CrystalReports.Engine;
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
    public partial class ReportDetailsFrom : Form
    {
        ReportDocument reportDocument;
        String reportName;
        public ReportDetailsFrom(String reportName)
        {
            this.reportName = reportName;
            InitializeComponent();
        }

        private void ReportDetailsFrom_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        String GetReportPath() {
            String supplierPath = "E:\\College Project\\Preowned Car Management System\\Preowned Car Management System\\SupplierCrystalReport.rpt";
            String stockPath = "E:\\College Project\\Preowned Car Management System\\Preowned Car Management System\\StockCrystalReport.rpt";
            String buyerPath = "E:\\College Project\\Preowned Car Management System\\Preowned Car Management System\\BuyersCrystalReport.rpt";
            if (reportName == "Supplier") {

                return supplierPath;
            } else if (reportName == "Stock") {

                return stockPath;
            } else if (reportName=="Buyer") {
            
                return buyerPath;
            }
            return "";
        }
        void LoadReport() {
            String path = GetReportPath();
            try {
            
                reportDocument = new ReportDocument();
                reportDocument.Load(path);
                crystalReportViewer1.ReportSource= reportDocument;
                crystalReportViewer1.RefreshReport();
            }catch(Exception exp){

                MessageBox.Show("Unable to load report");
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
