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
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(24, 30)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(223, 56)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Create the report with table in code"
            Me.button1.UseVisualStyleBackColor = True
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(24, 109)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(223, 56)
            Me.button2.TabIndex = 0
            Me.button2.Text = "Create the report in code and add table on event"
            Me.button2.UseVisualStyleBackColor = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 205)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents button1 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
    End Class
End Namespace

