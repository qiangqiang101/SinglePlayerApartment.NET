Public Class LegendaryItem

    Public price As Integer
    Public model As String

    Private Sub LegendaryItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Left = (Me.ClientSize.Width / 2) - (Panel1.Width / 2)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel1.Left = (Me.ClientSize.Width / 2) - (Panel1.Width / 2)
    End Sub
End Class
