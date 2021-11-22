Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraReports.UI
Imports System
Imports System.Collections.Generic
Imports System.IO

Namespace XRTable_RuntimeCreation
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnTableInCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTableInCode.Click
			Dim report As XtraReport = CreateEmptyReport()

			AddTablesToReport(report)

			Dim printTool As New ReportPrintTool(report)
			printTool.ShowPreviewDialog()
		End Sub
		Private Sub btnTableInEventHandler_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTableInEventHandler.Click
			Dim report As XtraReport = CreateEmptyReport()
			AddHandler report.BeforePrint, AddressOf Report_BeforePrint

			Dim printTool As New ReportPrintTool(report)
			printTool.ShowPreviewDialog()
		End Sub

		Private Sub btnLoadReportCodeBehind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoadReportCodeBehind.Click
			Dim report As New TableReport()
			report.ShowPreviewDialog()
		End Sub
		Public Shared Sub AddTablesToReport(ByVal report As XtraReport)
			Dim fields As New List(Of String)() From {"CompanyName", "ContactName", "Phone", "City"}

			Dim headerTable As XRTable = GetHeaderTable(fields, report.PageWidth - report.Margins.Left - report.Margins.Right)
			Dim table As XRTable = GetTableBoundToData(fields, report.PageWidth - report.Margins.Left - report.Margins.Right)

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
				Dim cell = New XRTableCell() With {.Text = field, .WidthF = cellSize, .BackColor = System.Drawing.Color.Gray}
				tableRow.Cells.Add(cell)
			Next field

			table.Rows.Add(tableRow)

			table.AdjustSize()

			table.EndInit()

			Return table
		End Function
		Public Shared Function GetTableBoundToData(ByVal fields As List(Of String), ByVal tableSize As Single) As XRTable
			Dim table = New XRTable()

			table.BeginInit()

			table.LocationF = New DevExpress.Utils.PointFloat(0F, 0F)
			table.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

			Dim tableRow = New XRTableRow()
			Dim cellSize As Single = tableSize / fields.Count

			For Each field In fields
				Dim cell = New XRTableCell() With {.Text = field, .WidthF = cellSize}
				cell.ExpressionBindings.Add(New ExpressionBinding("Text", $"[{field}]"))
				tableRow.Cells.Add(cell)
			Next field

			table.Rows.Add(tableRow)

			table.AdjustSize()
			table.EndInit()

			Return table
		End Function
		Public Shared Function CreateEmptyReport() As XtraReport
			Dim report As New XtraReport() With {.DataSource = CreateSqlDataSource(), .DataMember = "Customers"}
			Dim pageHeaderBand = New PageHeaderBand()
			Dim detailBand = New DetailBand()
			report.Bands.AddRange(New Band() { pageHeaderBand, detailBand })
			Return report
		End Function
		Public Shared Function CreateSqlDataSource() As SqlDataSource
			Dim rootPath As String = Path.GetDirectoryName(GetType(Form1).Assembly.Location)

			Dim connectionParameters As New SQLiteConnectionParameters(Path.Combine(rootPath, "nwind.db"), Nothing)
			Dim sqlDataSource As New SqlDataSource(connectionParameters)

			Dim querySalesPerson As SelectQuery = SelectQueryFluentBuilder.AddTable("Customers").SelectAllColumnsFromTable().Build("Customers")
			sqlDataSource.Queries.Add(querySalesPerson)
			Return sqlDataSource
		End Function
		Private Sub Report_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
			Dim report = TryCast(sender, XtraReport)
			AddTablesToReport(report)
		End Sub

	End Class
End Namespace
