Imports System.Drawing
Imports System.Drawing.Graphics

Public Class Canvas
    Inherits PictureBox

    Private _MoveStart As Point
    Private _Layers As List(Of Layer)

    Public Sub New()
        Me.DoubleBuffered = True

        _Layers = New List(Of Layer)
    End Sub

    Public ReadOnly Property Layers() As List(Of Layer)
        Get
            Return _Layers
        End Get
    End Property

    Public Property SelectedLayer As Layer
        Get
            'Loop through all layers and return the one that is selected
            For Each l As Layer In Me.Layers
                If l.Selected Then Return l
            Next
            Return Nothing
        End Get
        Set(ByVal value As Layer)
            'Loop through all layers and set their Selected property to True if it is the assigned layer ("value") or False if it isn't.
            For Each l As Layer In Me.Layers
                l.Selected = (l Is value)
            Next
        End Set
    End Property

    Private Function GetLayerFromPoint(ByVal p As Point) As Layer
        ' Finds the layer that contains the point p
        For Each l As Layer In Me.Layers
            If l.Bounds.Contains(p) Then Return l
        Next
        Return Nothing
    End Function

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            ' Store the previous selected layer to refresh the image there
            Dim oldSelection = Me.SelectedLayer

            ' Get the new selected layer
            Me.SelectedLayer = Me.GetLayerFromPoint(e.Location)

            'Update the picturebox
            If oldSelection IsNot Nothing Then Me.InvalidateLayer(oldSelection)
            Me.InvalidateLayer(Me.SelectedLayer)
            Me.Update()

            _MoveStart = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        If Control.MouseButtons = System.Windows.Forms.MouseButtons.Left Then
            If Me.SelectedLayer IsNot Nothing Then

                'Store the old bounds for refreshing
                Dim oldBounds As Rectangle = Me.SelectedLayer.Bounds

                'Move the selected layer
                Me.SelectedLayer.Move(e.Location.X - _MoveStart.X, e.Location.Y - _MoveStart.Y)
                _MoveStart = e.Location

                'Update the picturebox
                Me.InvalidateRectangle(oldBounds)
                Me.InvalidateLayer(Me.SelectedLayer)
                Me.Update()
            End If
        End If
    End Sub

    Private Sub InvalidateLayer(ByVal l As Layer)
        If l IsNot Nothing Then
            Me.InvalidateRectangle(l.Bounds)
        End If
    End Sub

    Private Sub InvalidateRectangle(ByVal r As Rectangle)
        'Inflate by 1 pixel otherwise the border isnt visible 
        r.Inflate(1, 1)
        Me.Invalidate(r)
    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)
        For Each l As Layer In Me.Layers
            l.Draw(pe.Graphics)
        Next
    End Sub

End Class