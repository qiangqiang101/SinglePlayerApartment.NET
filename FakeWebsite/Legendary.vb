Public Class Legendary

    Dim LegendaryFile As String = My.Application.Info.DirectoryPath & "\legendarymotorsport.cfg"
    Dim Parameters As String() = {"[name]", "[price]", "[model]", "[gxt]", "[make]", "[category]", "[desc]"}
    Dim legendaryItem As lmsItem


    Private Sub Legendary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Left = (Me.ClientSize.Width / 2) - (Panel1.Width / 2)

        Try
            Dim Format As New Reader(LegendaryFile, Parameters)
            Dim rowCount As Integer = Format.Count - 1
            Panel1.Size = New Size(Panel1.Width, rowCount * 78)
            Panel3.Size = New Size(Panel3.Width, rowCount * 78)
            For i As Integer = 0 To Format.Count - 1
                legendaryItem = New lmsItem() With {.VehiclePrice = Format(i)("price"), .VehicleName = Format(i)("name"), .VehicleModel = Format(i)("model"), .Category = Format(i)("category"), .DLC = Format(i)("desc")}
                FlowLayoutPanel1.Controls.Add(legendaryItem)
            Next
        Catch ex As Exception
            'MsgBox(ex.Message & ex.StackTrace)
        End Try

        FlowLayoutPanel1.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel1.Left = (Me.ClientSize.Width / 2) - (Panel1.Width / 2)
    End Sub
End Class
