Imports System.Drawing
Imports System.Drawing.Graphics

Public Class Layer

    Private _Graphics As List(Of Graphic)
    Private _Name As String
    Private _Selected As Boolean

    Public Sub New(ByVal name As String)
        Me.Name = name
        Me.Selected = False
        Me.Graphics = New List(Of Graphic)
    End Sub

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Selected() As Boolean
        Get
            Return _Selected
        End Get
        Set(ByVal value As Boolean)
            _Selected = value
        End Set
    End Property

    Public ReadOnly Property Bounds As Rectangle
        Get
            'Combine the bounds of all items
            If Me.Graphics.Count > 0 Then
                Dim b = Me.Graphics(0).Bounds
                For i As Integer = 1 To Me.Graphics.Count - 1
                    b = Rectangle.Union(b, Me.Graphics(i).Bounds)
                Next
                Return b
            End If
            Return Rectangle.Empty
        End Get
    End Property

    Public Property Graphics() As List(Of Graphic)
        Get
            Return _Graphics
        End Get
        Set(ByVal value As List(Of Graphic))
            _Graphics = value
        End Set
    End Property

    Public Sub Move(ByVal dx As Integer, ByVal dy As Integer)
        'Simply move each item 
        For Each item As Graphic In Me.Graphics
            item.Move(dx, dy)
        Next
    End Sub

    Public Sub Draw(ByVal g As System.Drawing.Graphics)
        'Draw each item
        For Each item As Graphic In Me.Graphics
            item.Draw(g)
        Next

        'Draw a selection border if selected
        If Me.Selected Then
            g.DrawRectangle(Pens.Red, Me.Bounds)
        End If
    End Sub

End Class