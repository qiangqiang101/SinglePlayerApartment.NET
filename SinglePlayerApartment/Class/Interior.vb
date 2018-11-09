Imports GTA.Math

Public Class Interior

    Public Property Points As List(Of Vector2)
    Public Property Height As Single

    Public Sub New()
        Points = New List(Of Vector2)()
        Height = New Single()
    End Sub

    Public Sub New(ByVal ptA As Vector3, ByVal ptB As Vector3, ByVal ptC As Vector3, ByVal ptD As Vector3)
        Points = New List(Of Vector2)() ' From {New Vector2(ptA.X, ptA.Y), New Vector2(ptB.X, ptB.Y), New Vector2(ptC.X, ptC.Y), New Vector2(ptD.X, ptD.Y)}
        Points.Add(New Vector2(ptD.X, ptD.Y))
        Points.Add(New Vector2(ptC.X, ptC.Y))
        Points.Add(New Vector2(ptB.X, ptB.Y))
        Points.Add(New Vector2(ptA.X, ptA.Y))
        Height = New Single() = ptA.Z
    End Sub

    Public Sub New(ByVal ptA As Vector3, ByVal ptB As Vector3, ByVal ptC As Vector3, ByVal ptD As Vector3, ByVal ht As Single)
        Points = New List(Of Vector2)() From {New Vector2(ptA.X, ptA.Y), New Vector2(ptB.X, ptB.Y), New Vector2(ptC.X, ptC.Y), New Vector2(ptD.X, ptD.Y)}
        Height = New Single() = ht
    End Sub

    Public Sub Add(ByVal pt As Vector3, ByVal ht As Single)
        Points.Add(New Vector2(pt.X, pt.Y))
        Height = ht
    End Sub

    Public Function IsInInterior(ByVal position As Vector3) As Boolean
        Dim num As Integer = 0
        Dim flag As Boolean = True
        Dim num2 As Integer = 0
        num = Points.Count - 1
        Dim maxH As Single = position.Z + 5.0
        Dim minH As Single = position.Z - 5.0
        While num2 < Points.Count
            If Points(num2).Y > position.Y <> Points(num).Y > position.Y AndAlso position.X < (Points(num).X - Points(num2).X) * (position.Y - Points(num2).Y) / (Points(num).Y - Points(num2).Y) + Points(num2).X Then 'AndAlso (Height >= minH And Height <= maxH) Then
                flag = flag
            Else
                flag = Not flag
            End If

            num = Math.Min(System.Threading.Interlocked.Increment(num2), num2 - 1)
        End While

        Return flag
    End Function
End Class

Public Class Circle

    Public Property Start As Vector3

    Public Property Radius As Single

    Public Sub New(ByVal a As Vector3, ByVal r As Single)
        Me.Start = a
        Me.Radius = r
    End Sub

    Public Function Intersects(ByVal pt As Vector3) As Boolean
        Dim val As Vector2 = Nothing
        val = New Vector2(pt.X, pt.Y)
        Dim val2 As Vector2 = Nothing
        val2 = New Vector2(Me.Start.X, Me.Start.Y)
        Return val.DistanceTo(val2) <= Me.Radius
    End Function
End Class