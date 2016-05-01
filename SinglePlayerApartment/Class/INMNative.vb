Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports INMNativeUI
Imports System.Drawing

Namespace INMNative

    Public Class Apartment

        Private _cost As Integer
        Private _owner, _name, _desc, _unit, _grgpath, _savefile, _playermap, _ipl, _lastipl As String
        Private _aptblip, _grgblip As Blip
        Private _entrance, _save, _telin, _telout, _exit, _wardrobe, _garageent, _grgout, _camerapos, _camerarot, _interior, _ascamerapos, _ascamerarot As Vector3
        Private _grgoutheading, _camerafov, _wardrobeheading, _ascamerafov As Single
        Private _isathome, _enabled As Boolean

        Public Sub New(Name As String, Unit As String, Cost As Integer, Optional Description As String = "")
            _name = Name
            _unit = Unit
            _cost = Cost
            _desc = Description
            _enabled = True
        End Sub

        Public Property Owner() As String
            Get
                Return _owner
            End Get
            Set(value As String)
                _owner = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property Unit() As String
            Get
                Return _unit
            End Get
            Set(value As String)
                _unit = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _desc
            End Get
            Set(value As String)
                _desc = value
            End Set
        End Property

        Public Property Cost() As Integer
            Get
                Return _cost
            End Get
            Set(value As Integer)
                _cost = value
            End Set
        End Property

        Public Property AptBlip() As Blip
            Get
                Return _aptblip
            End Get
            Set(value As Blip)
                _aptblip = value
            End Set
        End Property

        Public Property GrgBlip() As Blip
            Get
                Return _grgblip
            End Get
            Set(value As Blip)
                _grgblip = value
            End Set
        End Property

        Public Property Entrance() As Vector3
            Get
                Return _entrance
            End Get
            Set(value As Vector3)
                _entrance = value
            End Set
        End Property

        Public Property Save() As Vector3
            Get
                Return _save
            End Get
            Set(value As Vector3)
                _save = value
            End Set
        End Property

        Public Property TeleportInside() As Vector3
            Get
                Return _telin
            End Get
            Set(value As Vector3)
                _telin = value
            End Set
        End Property

        Public Property TeleportOutside() As Vector3
            Get
                Return _telout
            End Get
            Set(value As Vector3)
                _telout = value
            End Set
        End Property

        Public Property ApartmentExit() As Vector3
            Get
                Return _exit
            End Get
            Set(value As Vector3)
                _exit = value
            End Set
        End Property

        Public Property Wardrobe() As Vector3
            Get
                Return _wardrobe
            End Get
            Set(value As Vector3)
                _wardrobe = value
            End Set
        End Property

        Public Property WardrobeHeading() As Single
            Get
                Return _wardrobeheading
            End Get
            Set(value As Single)
                _wardrobeheading = value
            End Set
        End Property

        Public Property GarageEntrance() As Vector3
            Get
                Return _garageent
            End Get
            Set(value As Vector3)
                _garageent = value
            End Set
        End Property

        Public Property GarageOutside() As Vector3
            Get
                Return _grgout
            End Get
            Set(value As Vector3)
                _grgout = value
            End Set
        End Property

        Public Property GarageOutHeading() As Single
            Get
                Return _grgoutheading
            End Get
            Set(value As Single)
                _grgoutheading = value
            End Set
        End Property

        Public Property CameraPosition() As Vector3
            Get
                Return _camerapos
            End Get
            Set(value As Vector3)
                _camerapos = value
            End Set
        End Property

        Public Property CameraRotation() As Vector3
            Get
                Return _camerarot
            End Get
            Set(value As Vector3)
                _camerarot = value
            End Set
        End Property

        Public Property CameraFOV() As Single
            Get
                Return _camerafov
            End Get
            Set(value As Single)
                _camerafov = value
            End Set
        End Property

        Public ReadOnly Property GarageDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageEntrance)
            End Get
        End Property

        Public ReadOnly Property WardrobeDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Wardrobe)
            End Get
        End Property

        Public ReadOnly Property EntranceDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Entrance)
            End Get
        End Property

        Public ReadOnly Property SaveDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, Save)
            End Get
        End Property

        Public ReadOnly Property ExitDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, ApartmentExit)
            End Get
        End Property

        Public Property IsAtHome() As Boolean
            Get
                Return _isathome
            End Get
            Set(value As Boolean)
                _isathome = value
            End Set
        End Property

        Public ReadOnly Property Position() As Vector3
            Get
                Return Entrance
            End Get
        End Property

        Public ReadOnly Property IsForSale() As Boolean
            Get
                If AptBlip.Sprite = BlipSprite.SafehouseForSale Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Property Enabled() As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
            End Set
        End Property

        Public Property GaragePath() As String
            Get
                Return _grgpath
            End Get
            Set(value As String)
                _grgpath = value
            End Set
        End Property

        Public Property Interior() As Vector3
            Get
                Return _interior
            End Get
            Set(value As Vector3)
                _interior = value
            End Set
        End Property

        Public Property SaveFile() As String
            Get
                Return _savefile
            End Get
            Set(value As String)
                _savefile = value
            End Set
        End Property

        Public Property PlayerMap() As String
            Get
                Return _playermap
            End Get
            Set(value As String)
                _playermap = value
            End Set
        End Property

        Public Property IPL() As String
            Get
                Return _ipl
            End Get
            Set(value As String)
                _ipl = value
            End Set
        End Property

        Public Property LastIPL() As String
            Get
                Return _lastipl
            End Get
            Set(value As String)
                _lastipl = value
            End Set
        End Property

        Public Property ApartmentStyleCameraPosition() As Vector3
            Get
                Return _ascamerapos
            End Get
            Set(value As Vector3)
                _ascamerapos = value
            End Set
        End Property

        Public Property ApartmentStyleCameraRotation() As Vector3
            Get
                Return _ascamerarot
            End Get
            Set(value As Vector3)
                _ascamerarot = value
            End Set
        End Property

        Public Property ApartmentStyleCameraFOV() As Single
            Get
                Return _ascamerafov
            End Get
            Set(value As Single)
                _ascamerafov = value
            End Set
        End Property

        Public Sub SetInteriorActive()
            Try
                Dim interiorID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Interior.X, Interior.Y, Interior.Z)
                Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {interiorID})
                Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, interiorID, True)
                Native.Function.Call(Hash.DISABLE_INTERIOR, interiorID, False)
            Catch ex As Exception
                logger.Log(ex.Message & " " & ex.StackTrace)
            End Try
        End Sub

        Public Sub Create(Apartment1 As Apartment, Optional Apartment2 As Apartment = Nothing)
            If Apartment2 Is Nothing Then
                Apartment1.AptBlip = World.CreateBlip(Apartment1.Entrance)
                If Apartment1.Owner = "Michael" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Blue
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Blue
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Franklin" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Green
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Green
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Trevor" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Orange
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Orange
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Player3" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Yellow
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Yellow
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                Else
                    Apartment1.AptBlip.Sprite = BlipSprite.SafehouseForSale
                    Apartment1.AptBlip.Color = INMBlipColor.White
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = SinglePlayerApartment.ForSale
                End If
            Else
                Apartment1.AptBlip = World.CreateBlip(Apartment1.Entrance)
                If Apartment1.Owner = "Michael" AndAlso Apartment2.Owner = "Michael" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Blue
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Blue
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Franklin" AndAlso Apartment2.Owner = "Franklin" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Green
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Green
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Trevor" AndAlso Apartment2.Owner = "Trevor" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Orange
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Orange
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Player3" AndAlso Apartment2.Owner = "Player3" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Yellow
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Yellow
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner <> Apartment2.Owner Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.White
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.White
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                Else
                    Apartment1.AptBlip.Sprite = BlipSprite.SafehouseForSale
                    Apartment1.AptBlip.Color = INMBlipColor.White
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = SinglePlayerApartment.ForSale
                End If
            End If
        End Sub

        Public Sub CreateStilt(Apartment1 As Apartment)
            Apartment1.AptBlip = World.CreateBlip(Apartment1.Entrance)
            If Apartment1.Owner = "Michael" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Blue
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Blue
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Franklin" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Green
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Green
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Trevor" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Orange
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Orange
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Player3" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Yellow
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Yellow
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            Else
                Apartment1.AptBlip.Sprite = BlipSprite.SafehouseForSale
                Apartment1.AptBlip.Color = INMBlipColor.White
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = SinglePlayerApartment.ForSale
            End If
        End Sub

        Public Sub Create5(Apartment1 As Apartment, Apartment2 As Apartment, Apartment3 As Apartment, Apartment4 As Apartment, Apartment5 As Apartment)
            Apartment1.AptBlip = World.CreateBlip(Apartment1.Entrance)
            If Apartment1.Owner = "Michael" AndAlso Apartment2.Owner = "Michael" AndAlso Apartment3.Owner = "Michael" AndAlso Apartment4.Owner = "Michael" AndAlso Apartment5.Owner = "Michael" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Blue
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Blue
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Franklin" AndAlso Apartment2.Owner = "Franklin" AndAlso Apartment3.Owner = "Franklin" AndAlso Apartment4.Owner = "Franklin" AndAlso Apartment5.Owner = "Franklin" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Green
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Green
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Trevor" AndAlso Apartment2.Owner = "Trevor" AndAlso Apartment3.Owner = "Trevor" AndAlso Apartment4.Owner = "Trevor" AndAlso Apartment5.Owner = "Trevor" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Orange
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Orange
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Player3" AndAlso Apartment2.Owner = "Player3" AndAlso Apartment3.Owner = "Player3" AndAlso Apartment4.Owner = "Player3" AndAlso Apartment5.Owner = "Player3" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Yellow
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Yellow
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            ElseIf (Apartment1.Owner <> Apartment2.Owner) Or (Apartment1.Owner <> Apartment3.Owner) Or (Apartment1.Owner <> Apartment4.Owner) Or (Apartment1.Owner <> Apartment5.Owner) Or (Apartment2.Owner <> Apartment3.Owner) Or (Apartment2.Owner <> Apartment4.Owner) Or (Apartment2.Owner <> Apartment5.Owner) Or (Apartment3.Owner <> Apartment4.Owner) Or (Apartment3.Owner <> Apartment5.Owner) Or (Apartment4.Owner <> Apartment5.Owner) Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.White
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.White
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            Else
                Apartment1.AptBlip.Sprite = BlipSprite.SafehouseForSale
                Apartment1.AptBlip.Color = INMBlipColor.White
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = SinglePlayerApartment.ForSale
            End If
        End Sub

    End Class

    'Public Class Transform

    '    Public Position As Vector3
    '    Public Rotation As Vector3

    '    Public Sub New()
    '    End Sub

    '    Public Sub New(pos As Vector3, rot As Vector3)
    '        Position = pos
    '        Rotation = rot
    '    End Sub

    '    Public Function Clone() As Transform
    '        Return New Transform With {.Position = Position, .Rotation = Rotation}
    '    End Function

    'End Class

    'Friend Class AnimatedCameraScript
    '    Inherits Script

    '    Public Shared prevPos As Transform = New Transform
    '    Public Shared splineCamera As Camera = Nothing

    '    Public Sub New()
    '        World.DestroyAllCameras()
    '        RecreateCam()
    '        AddHandler Tick, New EventHandler(AddressOf OnTick)
    '    End Sub

    '    Public Shared Sub AddNode(ByVal transform As Transform, ByVal time As Integer)
    '        AddNode(transform.Position, transform.Rotation, time)
    '    End Sub

    '    Public Shared Sub AddNode(ByVal position As Vector3, ByVal rotation As Vector3, ByVal time As Integer)
    '        Dim arguments As InputArgument() = New InputArgument() {splineCamera.Handle, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, time, 3, 2}
    '        Native.Function.Call(Hash._0x8609C75EC438FB3B, arguments)
    '    End Sub

    '    Private Sub OnTick(ByVal sender As Object, ByVal e As EventArgs)
    '        If (World.RenderingCamera.Handle = -1) Then
    '            prevPos.Position = GameplayCamera.Position
    '            prevPos.Rotation = GameplayCamera.Rotation
    '        Else
    '            prevPos.Position = World.RenderingCamera.Position
    '            prevPos.Rotation = World.RenderingCamera.Rotation
    '        End If
    '    End Sub

    '    Public Shared Sub BeginNodes()
    '        RecreateCam()
    '        Dim arguments As InputArgument() = New InputArgument() {splineCamera.Handle, prevPos.Position.X, prevPos.Position.Y, prevPos.Position.Z, prevPos.Rotation.X, prevPos.Rotation.Y, prevPos.Rotation.Z, 0, 3, 2}
    '        Native.Function.Call(Hash._0x8609C75EC438FB3B, arguments)
    '    End Sub

    '    Public Shared Sub CameraShake(ByVal shake As CameraShake, ByVal intensity As Single)
    '        splineCamera.Shake(shake, intensity)
    '    End Sub

    '    Public Shared Sub DisableCamera()
    '        World.RenderingCamera = Nothing
    '    End Sub

    '    Public Shared Sub EnableCamera()
    '        World.RenderingCamera = splineCamera
    '    End Sub

    '    Public Shared Sub RecreateCam()
    '        If (Not splineCamera Is Nothing) Then
    '            splineCamera.Destroy()
    '        End If
    '        Dim arguments As InputArgument() = New InputArgument() {"DEFAULT_SPLINE_CAMERA", 1}
    '        splineCamera = New Camera(Native.Function.Call(Of Integer)(Hash._0xC3981DCE61D9E13F, arguments))
    '        Dim argumentArray2 As InputArgument() = New InputArgument() {splineCamera.Handle, prevPos.Position.X, prevPos.Position.Y, prevPos.Position.Z, prevPos.Rotation.X, prevPos.Rotation.Y, prevPos.Rotation.Z, GameplayCamera.FieldOfView, 0, 2, 2, 2}
    '        Native.Function.Call(Hash._0xBFD8727AEA3CCEBA, argumentArray2)
    '        splineCamera.MotionBlurStrength = 1.0!
    '        splineCamera.FieldOfView = GameplayCamera.FieldOfView
    '        splineCamera.DepthOfFieldStrength = 100.0!
    '        splineCamera.NearDepthOfField = 1.0!
    '        splineCamera.FarDepthOfField = 0.01!
    '        Dim argumentArray3 As InputArgument() = New InputArgument() {splineCamera.Handle, 0!, 0!, 0!, 10.0!}
    '        Native.Function.Call(Hash._0x3CF48F6F96E749DC, argumentArray3)
    '    End Sub

    '    Public Shared Sub SetPrevPosition(ByVal transform As Transform)
    '        prevPos = transform.Clone
    '    End Sub

    '    Public Shared Sub TransitionToCamera(ByVal cam As Camera, ByVal time As Integer, ByVal Optional easeType As Integer = 3)
    '        Dim arguments As InputArgument() = New InputArgument() {splineCamera.Handle, cam.Handle, time, easeType}
    '        Native.Function.Call(Hash._0x0A9F2A468B328E74, arguments)
    '    End Sub

    '    Public Shared Sub TransitionToPoint(ByVal transform As Transform, ByVal time As Integer)
    '        TransitionToPoint(transform.Position, transform.Rotation, time)
    '    End Sub

    '    Public Shared Sub TransitionToPoint(ByVal position As Vector3, ByVal rotation As Vector3, ByVal time As Integer)
    '        RecreateCam()
    '        Dim arguments As InputArgument() = New InputArgument() {splineCamera.Handle, prevPos.Position.X, prevPos.Position.Y, prevPos.Position.Z, prevPos.Rotation.X, prevPos.Rotation.Y, prevPos.Rotation.Z, 0, 3, 2}
    '        Native.Function.Call(Hash._0x8609C75EC438FB3B, arguments)
    '        Dim argumentArray2 As InputArgument() = New InputArgument() {splineCamera.Handle, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, time, 3, 2}
    '        Native.Function.Call(Hash._0x8609C75EC438FB3B, argumentArray2)
    '    End Sub

    '    Public Shared Sub TransitionToPointList(ByVal transforms As Transform(), ByVal gaps As Integer, ByVal Optional transitionType As Integer = 0, ByVal Optional smoothStart As Boolean = False)
    '        RecreateCam()

    '        If smoothStart Then
    '            Dim arguments As InputArgument() = New InputArgument() {splineCamera.Handle, prevPos.Position.X, prevPos.Position.Y, prevPos.Position.Z, prevPos.Rotation.X, prevPos.Rotation.Y, prevPos.Rotation.Z, 0, 3, 5}
    '            Native.Function.Call(Hash._0x8609C75EC438FB3B, arguments)
    '        End If
    '        Dim i As Integer
    '        For i = 0 To transforms.Length - 1
    '            Dim argumentArray2 As InputArgument() = New InputArgument() {splineCamera.Handle, transforms(i).Position.X, transforms(i).Position.Y, transforms(i).Position.Z, transforms(i).Rotation.X, transforms(i).Rotation.Y, transforms(i).Rotation.Z, (gaps * i), 3, transitionType}
    '            Native.Function.Call(Hash._0x8609C75EC438FB3B, argumentArray2)
    '        Next i
    '    End Sub
    'End Class

    Public Enum INMBlipColor
        White = 0
        Red = 1
        Green = 2
        Blue = 3
        Unk = 4
        Unk2 = 5
        Unk3 = 6
        Unk4 = 7
        Unk5 = 8
        Unk6 = 9
        Unk7 = 10
        Unk8 = 11
        Unk9 = 12
        Unk10 = 13
        Unk11 = 14
        Unk12 = 15
        Unk13 = 16
        Orange = 17
        Unk14 = 18
        Purple = 19
        Grey = 20
        Brown = 21
        Unk15 = 22
        Pink = 23
        Unk16 = 24
        DarkGreen = 25
        Unk17 = 26
        DarkPurple = 27
        Unk18 = 28
        DarkBlue = 29
        Yellow = 66
    End Enum
End Namespace
