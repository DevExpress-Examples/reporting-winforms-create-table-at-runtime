Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraReports.UI
' ...

Namespace XRTable_RuntimeCreation
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub createReportWithTableInCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim report As XtraReport = CreateReport()

            AddTablesIntoReport(report)

            Dim printTool As New ReportPrintTool(report)
            printTool.ShowPreviewDialog()
        End Sub
        Private Sub createReportInCodeAndAddTableOnEvent_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            Dim report As XtraReport = CreateReport()
            AddHandler report.BeforePrint, AddressOf Report_BeforePrint

            Dim printTool As New ReportPrintTool(report)
            printTool.ShowPreviewDialog()
        End Sub
        Public Shared Sub AddTablesIntoReport(ByVal report As XtraReport)
            Dim fields As New List(Of String)() From {"CompanyName", "ContactName", "Phone", "City"}

            Dim headerTable As XRTable = GetHeaderTable(fields, report.PageWidth - report.Margins.Left - report.Margins.Right)
            Dim table As XRTable = GetTableWithBinding(fields, report.PageWidth - report.Margins.Left - report.Margins.Right)

            Dim detailBand As DetailBand = TryCast(report.Bands.GetBandByType(GetType(DetailBand)), DetailBand)
            Dim pageHeaderBand As PageHeaderBand = TryCast(report.Bands.GetBandByType(GetType(PageHeaderBand)), PageHeaderBand)

            pageHeaderBand.Controls.Add(headerTable)
            detailBand.Controls.Add(table)

            pageHeaderBand.HeightF = headerTable.HeightF
            detailBand.HeightF = table.HeightF
        End Sub
        Public Shared Function GetHeaderTable(ByVal fields As List(Of String), ByVal tableSize As Single) As XRTable
            Dim table = New XRTable()

            table.BeginInit()

            table.LocationF = New DevExpress.Utils.PointFloat(0F, 0F)
            table.Borders = DevExpress.XtraPrinting.BorderSide.All

            Dim tableRow = New XRTableRow()
            Dim cellSize As Single = tableSize / fields.Count

            For Each field In fields
                Dim cell = New XRTableCell() With { _
                    .Text = field, _
                    .WidthF = cellSize, _
                    .BackColor = System.Drawing.Color.Gray _
                }
                tableRow.Cells.Add(cell)
            Next field


            table.Rows.Add(tableRow)

            table.AdjustSize()

            table.EndInit()

            Return table
        End Function
        Public Shared Function GetTableWithBinding(ByVal fields As List(Of String), ByVal tableSize As Single) As XRTable
            Dim table = New XRTable()

            table.BeginInit()

            table.LocationF = New DevExpress.Utils.PointFloat(0F, 0F)
            table.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim tableRow = New XRTableRow()
            Dim cellSize As Single = tableSize / fields.Count

            For Each field In fields
                Dim cell = New XRTableCell() With { _
                    .Text = field, _
                    .WidthF = cellSize _
                }
                cell.ExpressionBindings.Add(New ExpressionBinding("Text", $"[{field}]"))
                tableRow.Cells.Add(cell)
            Next field

            table.Rows.Add(tableRow)

            table.AdjustSize()
            table.EndInit()

            Return table
        End Function
        Public Shared Function CreateReport() As XtraReport
            Dim report As New XtraReport() With { _
                .DataSource = SqlDataSource(), _
                .DataMember = "Customers" _
            }
            Dim pageHeaderBand = New PageHeaderBand()
            Dim detailBand = New DetailBand()
            report.Bands.AddRange(New Band() { pageHeaderBand, detailBand })
            Return report
        End Function
        Public Shared Function SqlDataSource() As SqlDataSource
            Dim rootPath As String = Path.GetDirectoryName(GetType(Form1).Assembly.Location)
            Dim connectionParameters As New Access97ConnectionParameters(Path.Combine(rootPath, "nwind.mdb"), "", "")

            Dim sqlDataSource_Renamed As New SqlDataSource(connectionParameters)

            Dim querySalesPerson As SelectQuery = SelectQueryFluentBuilder.AddTable("Customers").SelectAllColumnsFromTable().Build("Customers")
            sqlDataSource_Renamed.Queries.Add(querySalesPerson)
            Return sqlDataSource_Renamed
        End Function
        Private Sub Report_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
            Dim report = TryCast(sender, XtraReport)
            AddTablesIntoReport(report)
        End Sub
    End Class
End Namespace
