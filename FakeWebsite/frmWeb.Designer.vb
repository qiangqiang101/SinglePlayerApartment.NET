<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWeb
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWeb))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ControlPanel1 = New FakeWebsite.ControlPanel()
        Me.Legendary1 = New FakeWebsite.Legendary()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Legendary1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1360, 736)
        Me.Panel1.TabIndex = 1
        '
        'ControlPanel1
        '
        Me.ControlPanel1.AutoScroll = True
        Me.ControlPanel1.BackgroundImage = CType(resources.GetObject("ControlPanel1.BackgroundImage"), System.Drawing.Image)
        Me.ControlPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlPanel1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ControlPanel1.MaximumSize = New System.Drawing.Size(60000, 32)
        Me.ControlPanel1.MinimumSize = New System.Drawing.Size(1024, 32)
        Me.ControlPanel1.Name = "ControlPanel1"
        Me.ControlPanel1.Size = New System.Drawing.Size(1360, 32)
        Me.ControlPanel1.TabIndex = 0
        '
        'Legendary1
        '
        Me.Legendary1.AutoScrollMargin = New System.Drawing.Size(0, 100)
        Me.Legendary1.BackColor = System.Drawing.Color.Black
        Me.Legendary1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Legendary1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Legendary1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Legendary1.Location = New System.Drawing.Point(0, 0)
        Me.Legendary1.Name = "Legendary1"
        Me.Legendary1.Size = New System.Drawing.Size(1360, 736)
        Me.Legendary1.TabIndex = 0
        '
        'frmWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1360, 768)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ControlPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Legendary Motorsport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ControlPanel1 As ControlPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Legendary1 As Legendary
End Class
