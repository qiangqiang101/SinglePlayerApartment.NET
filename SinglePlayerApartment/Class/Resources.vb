Imports System.Windows.Forms
Imports GTA

Public Class Resources

    Public Shared Dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public Shared AddOnCars As String = Application.StartupPath & "\scripts\SinglePlayerApartment\add-ons.txt"
    Public Shared Parameters As String() = {"[hash]", "[model]"}

    Public Shared Sub ReadDict()
        Dim format As New Reader(AddOnCars, Parameters)
        For i As Integer = 0 To format.Count - 1
            Dictionary.Add(format(i)("hash"), format(i)("model"))
        Next
    End Sub
End Class
