Namespace XRTable_RuntimeCreation
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.btnTableInCode = New System.Windows.Forms.Button()
            Me.btnTableInEventHandler = New System.Windows.Forms.Button()
            Me.btnLoadReportCodeBehind = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'btnTableInCode
            '
            Me.btnTableInCode.Location = New System.Drawing.Point(46, 25)
            Me.btnTableInCode.Name = "btnTableInCode"
            Me.btnTableInCode.Size = New System.Drawing.Size(223, 56)
            Me.btnTableInCode.TabIndex = 0
            Me.btnTableInCode.Text = "Create a report with a table"
            Me.btnTableInCode.UseVisualStyleBackColor = True
            '
            'btnTableInEventHandler
            '
            Me.btnTableInEventHandler.Location = New System.Drawing.Point(46, 113)
            Me.btnTableInEventHandler.Name = "btnTableInEventHandler"
            Me.btnTableInEventHandler.Size = New System.Drawing.Size(223, 56)
            Me.btnTableInEventHandler.TabIndex = 1
            Me.btnTableInEventHandler.Text = "Create a report and add a table in the event handler"
            Me.btnTableInEventHandler.UseVisualStyleBackColor = True
            '
            'btnLoadReportCodeBehind
            '
            Me.btnLoadReportCodeBehind.Location = New System.Drawing.Point(46, 201)
            Me.btnLoadReportCodeBehind.Name = "btnLoadReportCodeBehind"
            Me.btnLoadReportCodeBehind.Size = New System.Drawing.Size(223, 56)
            Me.btnLoadReportCodeBehind.TabIndex = 2
            Me.btnLoadReportCodeBehind.Text = "Preview a report with a table created in the code behind"
            Me.btnLoadReportCodeBehind.UseVisualStyleBackColor = True
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(314, 285)
            Me.Controls.Add(Me.btnLoadReportCodeBehind)
            Me.Controls.Add(Me.btnTableInEventHandler)
            Me.Controls.Add(Me.btnTableInCode)
            Me.Name = "Form1"
            Me.Text = "Create XRTable at Runtime"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents btnTableInCode As System.Windows.Forms.Button
		Private WithEvents btnTableInEventHandler As System.Windows.Forms.Button
		Private WithEvents btnLoadReportCodeBehind As System.Windows.Forms.Button
	End Class
End Namespace

