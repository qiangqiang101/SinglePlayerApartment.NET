Public Class ControlPanel
    Private _back As Control
    Public Property Back() As Control
        Get
            Return _back
        End Get
        Set(value As Control)
            _back = value
        End Set
    End Property

    Private Sub ControlPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Top = (Me.ClientSize.Height / 2) - (Panel1.Height / 2)
        Panel1.Left = (Me.ClientSize.Width / 2) - (Panel1.Width / 2)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ParentForm.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If Not _back Is Nothing Then
            frmWeb.ControlPanel1.lblURL.Text = "www.legendarymotorsport.net"
            frmWeb.Panel1.Controls.Clear()
            frmWeb.Panel1.Controls.Add(_back)
            _back.Dock = DockStyle.Fill
            _back = Nothing
        End If
    End Sub
End Class
