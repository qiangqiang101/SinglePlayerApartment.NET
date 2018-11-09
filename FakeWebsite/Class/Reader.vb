Imports System.IO
Imports System.Collections.Generic
Public Class Reader
    Private parms As String()
    Private filePath As String
    Private lines As New List(Of Line)()
    Public ReadOnly Property Count() As Integer
        Get
            Return lines.Count
        End Get
    End Property

    Public Sub New(ByVal file As String, ByVal parms As String())
        Me.parms = parms
        Me.filePath = file
        readFile()
    End Sub

    Private Sub readFile()
        Using sr As New StreamReader(filePath)
            Dim line As String
            Dim strLine As String
            Dim values As String() = New String(4095) {}

            Do
                line = sr.ReadLine()
                If line Is Nothing Then Exit Do 'Check if line is null then Exit Loop

                Dim currentLine As New Line()
                If line.StartsWith(";") Then
                    Continue Do
                End If
                strLine = line
                strLine = line.Replace(Environment.NewLine, "")
                For i As Integer = 0 To parms.Length - 1
                    If i = 0 Then
                        strLine = strLine.Replace(parms(0), "")
                    End If
                    strLine = strLine.Replace(parms(i), ",")
                Next
                values = strLine.Split(",")
                For i As Integer = 0 To values.Length - 1
                    Dim currentParameter As String = parms(i).Replace("[", "")
                    currentParameter = currentParameter.Replace("]", "")
                    currentLine.AddParameter(currentParameter, values(i))
                Next
                lines.Add(currentLine)
            Loop
        End Using
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As Line
        Get
            Return lines(index)
        End Get
    End Property

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function
End Class

Public Class Line
    Private row As New Dictionary(Of String, String)()

    Default Public ReadOnly Property Item(ByVal key As String) As String
        Get
            Try
                Return row(key).ToString()
            Catch ex As Exception
                Return String.Empty
            End Try
        End Get
    End Property

    Public Sub AddParameter(ByVal parameter As String, ByVal value As String)
        row.Add(parameter, value)
    End Sub

    Public ReadOnly Property ParameterCount() As Integer
        Get
            Return row.Count
        End Get
    End Property

    Public Sub ClearAllParameters()
        row.Clear()
    End Sub

    Public Sub RemoveParameter(ByVal parameter As String)
        row.Remove(parameter)
    End Sub
End Class
