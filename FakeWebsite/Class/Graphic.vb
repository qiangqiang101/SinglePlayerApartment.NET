Public Class Graphic
    Private _Image As Image
    Private _Location As Point
    Private _Size As Size

    Public Sub New(ByVal img As Image)
        Me.Bounds = Rectangle.Empty
        Me.Image = img
    End Sub

    Public Sub New(ByVal img As Image, ByVal location As Point)
        Me.New(img)
        Me.Location = location
        Me.Size = img.Size
    End Sub

    Public Sub New(ByVal img As Image, ByVal location As Point, ByVal size As Size)
        Me.New(img)
        Me.Location = location
        Me.Size = size
    End Sub

    Public Property Location() As Point
        Get
            Return _Location
        End Get
        Set(ByVal value As Point)
            _Location = value
        End Set
    End Property

    Public Property Size() As Size
        Get
            Return _Size
        End Get
        Set(ByVal value As Size)
            _Size = value
        End Set
    End Property

    Public Property Bounds() As Rectangle
        Get
            Return New Rectangle(Me.Location, Me.Size)
        End Get
        Set(ByVal value As Rectangle)
            Me.Location = value.Location
            Me.Size = value.Size
        End Set
    End Property

    Public Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
        End Set
    End Property

    Public Sub Move(ByVal dx As Integer, ByVal dy As Integer)
        ' We need to store a copy of the Location, change that, and save it back,
        ' because a Point is a structure and thus a value-type!!
        Dim l = Me.Location
        l.Offset(dx, dy)
        Me.Location = l
    End Sub

    Public Sub Draw(ByVal g As Graphics)
        If Me.Image IsNot Nothing Then
            g.DrawImage(Me.Image, Me.Bounds)
        End If
    End Sub

End Class