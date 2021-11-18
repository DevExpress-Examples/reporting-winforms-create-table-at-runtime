Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

' ...
Namespace XRTable_RuntimeCreation

    Public Partial Class XtraReport1
        Inherits XtraReport

'#Region "#Report Creation"
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs)
            Detail.Controls.Add(CreateXRTable())
        End Sub

'#End Region
        Public Function CreateXRTable() As XRTable
            Dim cellsInRow As Integer = 3
            Dim rowsCount As Integer = 3
            Dim rowHeight As Single = 25F
            Dim table As XRTable = New XRTable()
            table.Borders = DevExpress.XtraPrinting.BorderSide.All
            table.BeginInit()
            For i As Integer = 0 To rowsCount - 1
                Dim row As XRTableRow = New XRTableRow()
                row.HeightF = rowHeight
                For j As Integer = 0 To cellsInRow - 1
                    Dim cell As XRTableCell = New XRTableCell()
                    row.Cells.Add(cell)
                Next

                table.Rows.Add(row)
            Next

            AddHandler table.BeforePrint, New PrintEventHandler(AddressOf table_BeforePrint)
            table.AdjustSize()
            table.EndInit()
            Return table
        End Function

        ' The following code makes the table span to the entire page width.
        Private Sub table_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs)
            Dim table As XRTable = CType(sender, XRTable)
            table.LocationF = New DevExpress.Utils.PointFloat(0F, 0F)
            table.WidthF = PageWidth - Margins.Left - Margins.Right
        End Sub
    End Class
End Namespace
