<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlPanel
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
        Me.txtWebURL = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.btnHistory = New System.Windows.Forms.PictureBox()
        Me.btnHome = New System.Windows.Forms.PictureBox()
        Me.btnForward = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblURL = New System.Windows.Forms.Label()
        CType(Me.txtWebURL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnForward, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtWebURL
        '
        Me.txtWebURL.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.text_box
        Me.txtWebURL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.txtWebURL.Location = New System.Drawing.Point(208, 0)
        Me.txtWebURL.Name = "txtWebURL"
        Me.txtWebURL.Size = New System.Drawing.Size(618, 27)
        Me.txtWebURL.TabIndex = 0
        Me.txtWebURL.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.close_button
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Location = New System.Drawing.Point(832, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(27, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        '
        'btnHistory
        '
        Me.btnHistory.BackColor = System.Drawing.Color.Transparent
        Me.btnHistory.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.history_button
        Me.btnHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnHistory.Location = New System.Drawing.Point(159, 0)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(43, 27)
        Me.btnHistory.TabIndex = 2
        Me.btnHistory.TabStop = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.Transparent
        Me.btnHome.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.home_button
        Me.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnHome.Location = New System.Drawing.Point(106, 0)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(27, 27)
        Me.btnHome.TabIndex = 3
        Me.btnHome.TabStop = False
        '
        'btnForward
        '
        Me.btnForward.BackColor = System.Drawing.Color.Transparent
        Me.btnForward.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.right_button
        Me.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnForward.Location = New System.Drawing.Point(53, 0)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(27, 27)
        Me.btnForward.TabIndex = 4
        Me.btnForward.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.left_button
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBack.Location = New System.Drawing.Point(0, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(27, 27)
        Me.btnBack.TabIndex = 5
        Me.btnBack.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblURL)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Controls.Add(Me.txtWebURL)
        Me.Panel1.Controls.Add(Me.btnForward)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnHome)
        Me.Panel1.Controls.Add(Me.btnHistory)
        Me.Panel1.Location = New System.Drawing.Point(80, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 27)
        Me.Panel1.TabIndex = 6
        '
        'lblURL
        '
        Me.lblURL.AutoSize = True
        Me.lblURL.BackColor = System.Drawing.Color.White
        Me.lblURL.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblURL.Location = New System.Drawing.Point(215, 6)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(182, 19)
        Me.lblURL.TabIndex = 6
        Me.lblURL.Text = "www.imnotmental.com"
        '
        'ControlPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.FakeWebsite.My.Resources.Resources.toolbar_badger_gradient
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MaximumSize = New System.Drawing.Size(60000, 32)
        Me.MinimumSize = New System.Drawing.Size(1024, 32)
        Me.Name = "ControlPanel"
        Me.Size = New System.Drawing.Size(1024, 32)
        CType(Me.txtWebURL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnForward, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtWebURL As PictureBox
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents btnHistory As PictureBox
    Friend WithEvents btnHome As PictureBox
    Friend WithEvents btnForward As PictureBox
    Friend WithEvents btnBack As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblURL As Label
End Class
