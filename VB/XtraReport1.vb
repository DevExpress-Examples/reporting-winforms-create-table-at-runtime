Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI
' ...

Namespace XRTable_RuntimeCreation
	Partial Public Class XtraReport1
		Inherits XtraReport

		#Region "#Report Creation"
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles MyBase.BeforePrint
			Me.Detail.Controls.Add(CreateXRTable())
		End Sub
		#End Region

		Public Function CreateXRTable() As XRTable
			Dim table As New XRTable()
			' table.BeginInit();

			table.Borders = DevExpress.XtraPrinting.BorderSide.All

			Dim tableHeight As Integer = 0
			Dim tableWidth As Integer = 0

			For i As Integer = 0 To 2
				Dim row As New XRTableRow()
				row.Height = 100
				tableHeight += row.Height

				For j As Integer = 0 To 4
					Dim cell As New XRTableCell()
					cell.Width = 100
					tableWidth += cell.Width
					row.Cells.Add(cell)
				Next j

				table.Rows.Add(row)
			Next i

			tableWidth = tableWidth / table.Rows.Count

			table.Width = tableWidth
			' table.EndInit();

			Return table
		End Function

	End Class
End Namespace
