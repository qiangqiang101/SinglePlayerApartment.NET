<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LegendaryItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.pbVehicle = New System.Windows.Forms.PictureBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblCarName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.pbVehicle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.lblDesc)
        Me.Panel1.Controls.Add(Me.pbVehicle)
        Me.Panel1.Controls.Add(Me.lblPrice)
        Me.Panel1.Controls.Add(Me.lblCarName)
        Me.Panel1.Location = New System.Drawing.Point(103, 288)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(815, 441)
        Me.Panel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.lms_order_but
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(22, 329)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(220, 50)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "BUY IT NOW"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblDesc
        '
        Me.lblDesc.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblDesc.ForeColor = System.Drawing.Color.White
        Me.lblDesc.Location = New System.Drawing.Point(19, 66)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(219, 260)
        Me.lblDesc.TabIndex = 3
        Me.lblDesc.Text = "Description"
        '
        'pbVehicle
        '
        Me.pbVehicle.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.adder
        Me.pbVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbVehicle.Location = New System.Drawing.Point(248, 66)
        Me.pbVehicle.Name = "pbVehicle"
        Me.pbVehicle.Size = New System.Drawing.Size(543, 313)
        Me.pbVehicle.TabIndex = 2
        Me.pbVehicle.TabStop = False
        '
        'lblPrice
        '
        Me.lblPrice.Font = New System.Drawing.Font("Arial", 19.0!)
        Me.lblPrice.ForeColor = System.Drawing.Color.White
        Me.lblPrice.Location = New System.Drawing.Point(542, 15)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(249, 31)
        Me.lblPrice.TabIndex = 1
        Me.lblPrice.Text = "$1,000,000"
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCarName
        '
        Me.lblCarName.AutoSize = True
        Me.lblCarName.Font = New System.Drawing.Font("Arial", 19.0!)
        Me.lblCarName.ForeColor = System.Drawing.Color.White
        Me.lblCarName.Location = New System.Drawing.Point(19, 15)
        Me.lblCarName.Name = "lblCarName"
        Me.lblCarName.Size = New System.Drawing.Size(249, 31)
        Me.lblCarName.TabIndex = 0
        Me.lblCarName.Text = "TRUFFADE ADDER"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.Maroon
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 838)
        Me.Panel2.TabIndex = 4
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.lms_bottom_nothing
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox2.Image = Global.FakeWebsite.My.Resources.Resources.lms_bottom
        Me.PictureBox2.Location = New System.Drawing.Point(0, 735)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1024, 103)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.lms_texture_1
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1024, 348)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'LegendaryItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Name = "LegendaryItem"
        Me.Size = New System.Drawing.Size(1024, 838)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbVehicle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCarName As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblDesc As Label
    Friend WithEvents pbVehicle As PictureBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
End Class
