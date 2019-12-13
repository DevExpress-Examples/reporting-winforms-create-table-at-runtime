using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
// ...

namespace XRTable_RuntimeCreation {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void createReportWithTableInCode_Click(object sender, EventArgs e) {
            XtraReport report = CreateReport();
            
            AddTablesIntoReport(report);

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
        private void createReportInCodeAndAddTableOnEvent_Click(object sender, EventArgs e) {
            XtraReport report = CreateReport();
            report.BeforePrint += Report_BeforePrint;

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
        public static void AddTablesIntoReport(XtraReport report) {
            List<string> fields = new List<string>() {
                "CompanyName",
                "ContactName",
                "Phone",
                "City"
            };

            XRTable headerTable = GetHeaderTable(fields, report.PageWidth - report.Margins.Left - report.Margins.Right);
            XRTable table = GetTableWithBinding(fields, report.PageWidth - report.Margins.Left - report.Margins.Right);

            DetailBand detailBand = report.Bands.GetBandByType(typeof(DetailBand)) as DetailBand;
            PageHeaderBand pageHeaderBand = report.Bands.GetBandByType(typeof(PageHeaderBand)) as PageHeaderBand;

            pageHeaderBand.Controls.Add(headerTable);
            detailBand.Controls.Add(table);

            pageHeaderBand.HeightF = headerTable.HeightF;
            detailBand.HeightF = table.HeightF;
        }
        public static XRTable GetHeaderTable(List<string> fields, float tableSize) {
            var table = new XRTable();
            
            table.BeginInit();
            
            table.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);
            table.Borders = DevExpress.XtraPrinting.BorderSide.All;
            
            var tableRow = new XRTableRow();
            float cellSize = tableSize / fields.Count;

            foreach(var field in fields) {
                var cell = new XRTableCell() {
                    Text = field,
                    WidthF = cellSize,
                    BackColor = System.Drawing.Color.Gray
                };
                tableRow.Cells.Add(cell);
            }
            
            
            table.Rows.Add(tableRow);

            table.AdjustSize();
            
            table.EndInit();
            
            return table;
        }
        public static XRTable GetTableWithBinding(List<string> fields, float tableSize) {
            var table = new XRTable();

            table.BeginInit();

            table.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);
            table.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;

            var tableRow = new XRTableRow();
            float cellSize = tableSize / fields.Count;

            foreach(var field in fields) {
                var cell = new XRTableCell() {
                    Text = field,
                    WidthF = cellSize
                };
                cell.ExpressionBindings.Add(new ExpressionBinding("Text", $"[{field}]"));
                tableRow.Cells.Add(cell);
            }

            table.Rows.Add(tableRow);

            table.AdjustSize();
            table.EndInit();

            return table;
        }
        public static XtraReport CreateReport() {
            XtraReport report = new XtraReport() {
                DataSource = SqlDataSource(),
                DataMember = "Customers"
            };
            var pageHeaderBand = new PageHeaderBand();
            var detailBand = new DetailBand();
            report.Bands.AddRange(new Band[] { pageHeaderBand, detailBand });
            return report;
        }
        public static SqlDataSource SqlDataSource() {
            string rootPath = Path.GetDirectoryName(typeof(Form1).Assembly.Location);
            Access97ConnectionParameters connectionParameters = new Access97ConnectionParameters(Path.Combine(rootPath, "nwind.mdb"), "", "");
            SqlDataSource sqlDataSource = new SqlDataSource(connectionParameters);

            SelectQuery querySalesPerson = SelectQueryFluentBuilder.AddTable("Customers").SelectAllColumnsFromTable().Build("Customers");
            sqlDataSource.Queries.Add(querySalesPerson);
            return sqlDataSource;
        }
        private void Report_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            var report = sender as XtraReport;
            AddTablesIntoReport(report);
        }
    }
}
