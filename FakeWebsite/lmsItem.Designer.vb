<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lmsItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Canvas1 = New FakeWebsite.Canvas()
        CType(Me.Canvas1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Canvas1
        '
        Me.Canvas1.BackColor = System.Drawing.Color.Black
        Me.Canvas1.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.lms_frame
        Me.Canvas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Canvas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Canvas1.Enabled = False
        Me.Canvas1.Location = New System.Drawing.Point(0, 0)
        Me.Canvas1.Name = "Canvas1"
        Me.Canvas1.SelectedLayer = Nothing
        Me.Canvas1.Size = New System.Drawing.Size(256, 219)
        Me.Canvas1.TabIndex = 0
        Me.Canvas1.TabStop = False
        '
        'lmsItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Canvas1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Name = "lmsItem"
        Me.Size = New System.Drawing.Size(256, 219)
        CType(Me.Canvas1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Canvas1 As Canvas
End Class
