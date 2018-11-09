Public Class lmsItem
    Private Sub lmsItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim l As Layer
        l = New Layer("Title")
        l.Graphics.Add(New Graphic(My.Resources.lms_item_title, New Point(0, 0), New Size(256, 40)))
        If Not _dlc = Nothing Then l.Graphics.Add(New Graphic(TextToImage(_dlc, "Arial", 11, Brushes.Black), New Point(4, 4)))
        Canvas1.Layers.Add(l)

        l = New Layer("Car")
        l.Graphics.Add(New Graphic(My.Resources.ResourceManager.GetObject(_vehModel), New Point(0, 40), New Size(256, 148)))
        Canvas1.Layers.Add(l)

        l = New Layer("Button")
        l.Graphics.Add(New Graphic(My.Resources.lms_item_button, New Point(182, 189)))
        l.Graphics.Add(New Graphic(TextToImage(_vehName, "Arial", 11, Brushes.White), New Point(4, 195)))
        l.Graphics.Add(New Graphic(TextToImage(String.Format("${0}", _vehPrice.ToString("###,###")), "Arial", 10, Brushes.White), New Point(185, 195)))
        Canvas1.Layers.Add(l)

        l = New Layer("Frame")
        l.Graphics.Add(New Graphic(My.Resources.lms_frame, New Point(0, 0)))
        Canvas1.Layers.Add(l)

        Canvas1.Invalidate()
    End Sub

    Private _vehName As String
    Public Property VehicleName() As String
        Get
            Return _vehName
        End Get
        Set(value As String)
            _vehName = value
        End Set
    End Property

    Private _vehPrice As Integer
    Public Property VehiclePrice() As String
        Get
            Return _vehPrice
        End Get
        Set(value As String)
            _vehPrice = value
        End Set
    End Property

    Private _vehModel As String
    Public Property VehicleModel() As String
        Get
            Return _vehModel
        End Get
        Set(value As String)
            _vehModel = value
        End Set
    End Property

    Private _category As String
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(value As String)
            _category = value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Private _dlc As String
    Public Property DLC() As String
        Get
            Return _dlc
        End Get
        Set(value As String)
            _dlc = value
        End Set
    End Property

    Private Sub Canvas1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Dim li As New LegendaryItem
        li.lblCarName.Text = _vehName
        li.lblDesc.Text = _description
        li.lblPrice.Text = String.Format("${0}", _vehPrice.ToString("###,###"))
        li.pbVehicle.BackgroundImage = My.Resources.ResourceManager.GetObject(_vehModel)
        li.price = _vehPrice
        li.model = _vehModel
        frmWeb.ControlPanel1.lblURL.Text = frmWeb.ControlPanel1.lblURL.Text & "/" & _vehModel

        frmWeb.ControlPanel1.Back = New Legendary

        frmWeb.Panel1.Controls.Clear()
        frmWeb.Panel1.Controls.Add(li)
        li.Dock = DockStyle.Fill
    End Sub
End Class
