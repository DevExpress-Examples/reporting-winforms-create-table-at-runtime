using System.Drawing;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
// ...

namespace XRTable_RuntimeCreation {
    public partial class XtraReport1 : XtraReport {

        #region #Report Creation
        public XtraReport1() {
            InitializeComponent();
        }

        private void XtraReport1_BeforePrint(object sender, PrintEventArgs e) {
            this.Detail.Controls.Add(CreateXRTable());
        }
        #endregion

        public XRTable CreateXRTable() {
            XRTable table = new XRTable();
            table.BeginInit();

            table.Borders = DevExpress.XtraPrinting.BorderSide.All;

            int tableHeight = 0;
            int tableWidth = 0;

            for (int i = 0; i < 3; i++) {
                XRTableRow row = new XRTableRow();
                row.Height = 100;
                tableHeight += row.Height;

                for (int j = 0; j < 5; j++) {
                    XRTableCell cell = new XRTableCell();
                    cell.Width = 100;

                    // When rendering tables with a great number of rows,
                    // you can optimize the performance
                    // by setting the Weight property to 1 for every cell.
                    cell.Weight = 1;

                    tableWidth += cell.Width;
                    row.Cells.Add(cell);
                }

                table.Rows.Add(row);
            }

            tableWidth = tableWidth / table.Rows.Count;

            table.Size = new Size(tableWidth, tableHeight);
            //table.Width = tableWidth;

            table.EndInit();

            return table;
        }

    }
}
