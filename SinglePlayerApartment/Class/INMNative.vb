Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports INMNativeUI
Imports System.Drawing

Namespace INMNative

    Public Class Apartment

        Private _cost, _interiorID, _radio As Integer
        Private _radioRoomList As List(Of String) = New List(Of String)
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

        Public Property InteriorID() As Integer
            Get
                Return _interiorID
            End Get
            Set(value As Integer)
                _interiorID = value
            End Set
        End Property

        Public Shared Function GetInteriorID(interior As Vector3) As Integer
            Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, interior.X, interior.Y, interior.Z)
        End Function

        Public Sub SetInteriorActive()
            Try
                Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Interior.X, Interior.Y, Interior.Z)
                Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
                Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
                Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
                'InteriorID = intID
                If Not intID = 0 AndAlso Not SinglePlayerApartment.InteriorIDList.Contains(intID) Then SinglePlayerApartment.InteriorIDList.Add(intID)
            Catch ex As Exception
                logger.Log(ex.Message & " " & ex.StackTrace)
            End Try
        End Sub

        Public Sub Create(Apartment1 As Apartment, Optional Apartment2 As Apartment = Nothing)
            If Apartment2 Is Nothing Then
                Apartment1.AptBlip = World.CreateBlip(Apartment1.Entrance)
                If Apartment1.Owner = "Michael" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Michael
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Michael
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Franklin" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Franklin
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Franklin
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Trevor" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Trevor
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Trevor
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
                    Apartment1.AptBlip.Color = INMBlipColor.Michael
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Michael
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Franklin" AndAlso Apartment2.Owner = "Franklin" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Franklin
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Franklin
                    Apartment1.GrgBlip.IsShortRange = True
                    Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
                ElseIf Apartment1.Owner = "Trevor" AndAlso Apartment2.Owner = "Trevor" Then
                    Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                    Apartment1.AptBlip.Color = INMBlipColor.Trevor
                    Apartment1.AptBlip.IsShortRange = True
                    Apartment1.AptBlip.Name = Apartment1.Name
                    Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                    Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                    Apartment1.GrgBlip.Color = INMBlipColor.Trevor
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
                Apartment1.AptBlip.Color = INMBlipColor.Michael
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Michael
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Franklin" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Franklin
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Franklin
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Trevor" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Trevor
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Trevor
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
                Apartment1.AptBlip.Color = INMBlipColor.Michael
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Michael
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Franklin" AndAlso Apartment2.Owner = "Franklin" AndAlso Apartment3.Owner = "Franklin" AndAlso Apartment4.Owner = "Franklin" AndAlso Apartment5.Owner = "Franklin" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Franklin
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Franklin
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Trevor" AndAlso Apartment2.Owner = "Trevor" AndAlso Apartment3.Owner = "Trevor" AndAlso Apartment4.Owner = "Trevor" AndAlso Apartment5.Owner = "Trevor" Then
                Apartment1.AptBlip.Sprite = BlipSprite.Safehouse
                Apartment1.AptBlip.Color = INMBlipColor.Trevor
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Trevor
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

    Public Class SPAVehicle
        Inherits Entity

        Private _active As Boolean = False, _owner As String = "NULL", _file As String = "NULL", _name As String = "NULL"

        Public Sub New(handle As Integer)
            MyBase.New(handle)
        End Sub

        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(value As Boolean)
                _active = value
            End Set
        End Property

        Public Property Owner() As String
            Get
                Return _owner
            End Get
            Set(value As String)
                _owner = value
            End Set
        End Property

        Public Property File() As String
            Get
                Return _file
            End Get
            Set(value As String)
                _file = value
            End Set
        End Property

        Public Property DimName() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public ReadOnly Property DisplayName() As String
            Get
                Return Native.Function.Call(Of String)(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, MyBase.Model.Hash)
            End Get
        End Property
        Public ReadOnly Property FriendlyName() As String
            Get
                Return Game.GetGXTEntry(DisplayName)
            End Get
        End Property
        Public ReadOnly Property ClassType() As VehicleClass
            Get
                Return Native.Function.Call(Of VehicleClass)(Hash.GET_VEHICLE_CLASS, Handle)
            End Get
        End Property

        Public Property BodyHealth() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_BODY_HEALTH, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_BODY_HEALTH, Handle, Value)
            End Set
        End Property
        Public Property EngineHealth() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_ENGINE_HEALTH, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_ENGINE_HEALTH, Handle, Value)
            End Set
        End Property
        Public Property PetrolTankHealth() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_PETROL_TANK_HEALTH, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, Handle, Value)
            End Set
        End Property

        Public Property EngineRunning() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash._IS_VEHICLE_ENGINE_ON, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Handle, Value, True)
            End Set
        End Property
        Public WriteOnly Property IsRadioEnabled() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Handle, Value)
            End Set
        End Property

        Public Property Speed() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_ENTITY_SPEED, Handle)
            End Get
            Set
                If Model.IsTrain Then
                    Native.Function.Call(Hash.SET_TRAIN_SPEED, Handle, Value)
                    Native.Function.Call(Hash.SET_TRAIN_CRUISE_SPEED, Handle, Value)
                Else
                    Native.Function.Call(Hash.SET_VEHICLE_FORWARD_SPEED, Handle, Value)
                End If
            End Set
        End Property

        Public ReadOnly Property HasForks() As Boolean
            Get
                Return HasBone("forks")
            End Get
        End Property

        Public WriteOnly Property HasAlarm() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_ALARM, Handle, Value)
            End Set
        End Property
        Public ReadOnly Property AlarmActive() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_ALARM_ACTIVATED, Handle)
            End Get
        End Property
        Public Sub StartAlarm()
            Native.Function.Call(Hash.START_VEHICLE_ALARM, Handle)
        End Sub

        Public ReadOnly Property HasSiren() As Boolean
            Get
                Return HasBone("siren1")
            End Get
        End Property
        Public Property SirenActive() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_SIREN_ON, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_SIREN, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property IsSirenSilent() As Boolean
            Set
                ' Sets if the siren is silent actually 
                Native.Function.Call(Hash.DISABLE_VEHICLE_IMPACT_EXPLOSION_ACTIVATION, Handle, Value)
            End Set
        End Property
        Public Sub SoundHorn(duration As Integer)
            Native.Function.Call(Hash.START_VEHICLE_HORN, Handle, duration, Game.GenerateHash("HELDDOWN"), 0)
        End Sub

        Public Property Livery() As Integer
            Get
                Dim modCount As Integer = GetModCount(VehicleMod.Livery)

                If modCount > 0 Then
                    Return modCount
                End If

                Return Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_LIVERY, Handle)
            End Get
            Set
                If GetModCount(VehicleMod.Livery) > 0 Then
                    SetMod(VehicleMod.Livery, Value, False)
                Else
                    Native.Function.Call(Hash.SET_VEHICLE_LIVERY, Handle, Value)
                End If
            End Set
        End Property
        Public ReadOnly Property LiveryCount() As Integer
            Get
                Dim modCount As Integer = GetModCount(VehicleMod.Livery)

                If modCount > 0 Then
                    Return modCount
                End If

                Return Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_LIVERY_COUNT, Handle)
            End Get
        End Property

        Public Property LightsOn() As Boolean
            Get
                Dim lightState1 = New OutputArgument()
                Dim lightState2 = New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_LIGHTS_STATE, Handle, lightState1, lightState2)

                Return lightState1.GetResult(Of Boolean)()
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_LIGHTS, Handle, If(Value, 3, 4))
            End Set
        End Property
        Public Property HighBeamsOn() As Boolean
            Get
                Dim lightState1 = New OutputArgument()
                Dim lightState2 = New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_LIGHTS_STATE, Handle)

                Return lightState2.GetResult(Of Boolean)()
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_FULLBEAM, Handle, Value)
            End Set
        End Property

        Public Property SearchLightOn() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_SEARCHLIGHT_ON, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_SEARCHLIGHT, Handle, Value, 0)
            End Set
        End Property
        Public Property TaxiLightOn() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_TAXI_LIGHT_ON, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_TAXI_LIGHTS, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property LeftIndicatorLightOn() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, Handle, True, Value)
            End Set
        End Property
        Public WriteOnly Property RightIndicatorLightOn() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, Handle, False, Value)
            End Set
        End Property
        Public WriteOnly Property HandbrakeOn() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_HANDBRAKE, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property BrakeLightsOn() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_BRAKE_LIGHTS, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property LightsMultiplier() As Single
            Set
                Native.Function.Call(Hash.SET_VEHICLE_LIGHT_MULTIPLIER, Handle, Value)
            End Set
        End Property

        Public WriteOnly Property CanBeVisiblyDamaged() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, Handle, Value)
            End Set
        End Property

        Public ReadOnly Property IsDamaged() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash._IS_VEHICLE_DAMAGED, Handle)
            End Get
        End Property
        Public Property IsDriveable() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_DRIVEABLE, Handle, 0)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_UNDRIVEABLE, Handle, Not Value)
            End Set
        End Property
        Public ReadOnly Property HasRoof() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.DOES_VEHICLE_HAVE_ROOF, Handle)
            End Get
        End Property

        Public ReadOnly Property IsRearBumperBrokenOff() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, Handle, False)
            End Get
        End Property
        Public ReadOnly Property IsFrontBumperBrokenOff() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, Handle, True)
            End Get
        End Property

        Public WriteOnly Property IsAxlesStrong() As Boolean
            Set
                Native.Function.Call(Of Boolean)(Hash.SET_VEHICLE_HAS_STRONG_AXLES, Handle, Value)
            End Set
        End Property

        Public WriteOnly Property EngineCanDegrade() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_ENGINE_CAN_DEGRADE, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property EnginePowerMultiplier() As Single
            Set
                Native.Function.Call(Hash._SET_VEHICLE_ENGINE_POWER_MULTIPLIER, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property EngineTorqueMultiplier() As Single
            Set
                Native.Function.Call(Hash._SET_VEHICLE_ENGINE_TORQUE_MULTIPLIER, Handle, Value)
            End Set
        End Property

        Public Property WheelType() As VehicleWheelType
            Get
                Return Native.Function.Call(Of VehicleWheelType)(Hash.GET_VEHICLE_WHEEL_TYPE, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, Handle, Value)
            End Set
        End Property
        Public Property WindowTint() As VehicleWindowTint
            Get
                Return Native.Function.Call(Of VehicleWindowTint)(Hash.GET_VEHICLE_WINDOW_TINT, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_WINDOW_TINT, Handle, Value)
            End Set
        End Property

        Public Property PrimaryColor() As Integer
            Get
                Dim color1 As New OutputArgument()
                Dim color2 As New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_COLOURS, Handle, color1, color2)

                Return color1.GetResult(Of Integer)()
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_COLOURS, Handle, Value, SecondaryColor)
            End Set
        End Property

        Public Property SecondaryColor() As Integer
            Get
                Dim color1 As New OutputArgument()
                Dim color2 As New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_COLOURS, Handle, color1, color2)

                Return color2.GetResult(Of Integer)()
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_COLOURS, Handle, PrimaryColor, Value)
            End Set
        End Property
        Public Property RimColor() As Integer
            Get
                Dim color1 As New OutputArgument()
                Dim color2 As New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, Handle, color1, color2)

                Return color2.GetResult(Of Integer)()
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, Handle, PearlescentColor, Value)
            End Set
        End Property
        Public Property PearlescentColor() As Integer
            Get
                Dim color1 As New OutputArgument()
                Dim color2 As New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, Handle, color1, color2)

                Return color1.GetResult(Of Integer)()
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, Handle, Value, RimColor)
            End Set
        End Property
        Public Property TrimColor() As Integer
            Get
                Dim color As New OutputArgument()
                Native.Function.Call(DirectCast(9012939617897488694UL, Hash), Handle, color)

                Return color.GetResult(Of Integer)()
            End Get
            Set
                Native.Function.Call(DirectCast(17585947422526242585UL, Hash), Handle, Value)
            End Set
        End Property
        Public Property DashboardColor() As Integer
            Get
                Dim color As New OutputArgument()
                Native.Function.Call(DirectCast(13214509638265019391UL, Hash), Handle, color)

                Return color.GetResult(Of Integer)()
            End Get
            Set
                Native.Function.Call(DirectCast(6956317558672667244UL, Hash), Handle, Value)
            End Set
        End Property
        Public Property ColorCombination() As Integer
            Get
                Return Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_COLOUR_COMBINATION, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_COLOUR_COMBINATION, Handle, Value)
            End Set
        End Property
        Public ReadOnly Property ColorCombinationCount() As Integer
            Get
                Return Native.Function.Call(Of Integer)(Hash.GET_NUMBER_OF_VEHICLE_COLOURS, Handle)
            End Get
        End Property
        Public Property TireSmokeColor() As Color
            Get
                Dim red = New OutputArgument()
                Dim green = New OutputArgument()
                Dim blue = New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, Handle, red, green, blue)

                Return Color.FromArgb(red.GetResult(Of Integer)(), green.GetResult(Of Integer)(), blue.GetResult(Of Integer)())
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, Handle, Value.R, Value.G, Value.B)
            End Set
        End Property
        Public Property NeonLightsColor() As Color
            Get
                Dim red = New OutputArgument()
                Dim green = New OutputArgument()
                Dim blue = New OutputArgument()
                Native.Function.Call(Hash._GET_VEHICLE_NEON_LIGHTS_COLOUR, Handle, red, green, blue)

                Return Color.FromArgb(red.GetResult(Of Integer)(), green.GetResult(Of Integer)(), blue.GetResult(Of Integer)())
            End Get
            Set
                Native.Function.Call(Hash._SET_VEHICLE_NEON_LIGHTS_COLOUR, Handle, Value.R, Value.G, Value.B)
            End Set
        End Property
        Public Property CustomPrimaryColor() As Color
            Get
                Dim red = New OutputArgument()
                Dim green = New OutputArgument()
                Dim blue = New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_CUSTOM_PRIMARY_COLOUR, Handle, red, green, blue)

                Return Color.FromArgb(red.GetResult(Of Integer)(), green.GetResult(Of Integer)(), blue.GetResult(Of Integer)())
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, Handle, Value.R, Value.G, Value.B)
            End Set
        End Property
        Public Property CustomSecondaryColor() As Color
            Get
                Dim red = New OutputArgument()
                Dim green = New OutputArgument()
                Dim blue = New OutputArgument()
                Native.Function.Call(Hash.GET_VEHICLE_CUSTOM_SECONDARY_COLOUR, Handle, red, green, blue)

                Return Color.FromArgb(red.GetResult(Of Integer)(), green.GetResult(Of Integer)(), blue.GetResult(Of Integer)())
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, Handle, Value.R, Value.G, Value.B)
            End Set
        End Property
        Public ReadOnly Property IsPrimaryColorCustom() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.GET_IS_VEHICLE_PRIMARY_COLOUR_CUSTOM, Handle)
            End Get
        End Property
        Public ReadOnly Property IsSecondaryColorCustom() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.GET_IS_VEHICLE_SECONDARY_COLOUR_CUSTOM, Handle)
            End Get
        End Property
        Public Sub ClearCustomPrimaryColor()
            Native.Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_PRIMARY_COLOUR, Handle)
        End Sub
        Public Sub ClearCustomSecondaryColor()
            Native.Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_SECONDARY_COLOUR, Handle)
        End Sub

        Public Property NumberPlateType() As NumberPlateType
            Get
                Return Native.Function.Call(Of NumberPlateType)(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, Handle, Value)
            End Set
        End Property
        Public ReadOnly Property NumberPlateMounting() As NumberPlateMounting
            Get
                Return Native.Function.Call(Of NumberPlateMounting)(Hash.GET_VEHICLE_PLATE_TYPE, Handle)
            End Get
        End Property
        Public Property NumberPlate() As String
            Get
                Return Native.Function.Call(Of String)(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, Handle, Value)
            End Set
        End Property

        Public Property LandingGear() As VehicleLandingGear
            Get
                Return Native.Function.Call(Of VehicleLandingGear)(Hash._GET_VEHICLE_LANDING_GEAR, Handle)
            End Get
            Set
                Native.Function.Call(Hash._SET_VEHICLE_LANDING_GEAR, Handle, Value)
            End Set
        End Property
        Public Property RoofState() As VehicleRoofState
            Get
                Return Native.Function.Call(Of VehicleRoofState)(Hash.GET_CONVERTIBLE_ROOF_STATE, Handle)
            End Get
            Set
                Select Case Value
                    Case VehicleRoofState.Closed
                        Native.Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, Handle, True)
                        Native.Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, Handle, False)
                        Exit Select
                    Case VehicleRoofState.Closing
                        Native.Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, Handle, False)
                        Exit Select
                    Case VehicleRoofState.Opened
                        Native.Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, Handle, True)
                        Native.Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, Handle, False)
                        Exit Select
                    Case VehicleRoofState.Opening
                        Native.Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, Handle, False)
                        Exit Select
                End Select
            End Set
        End Property
        Public Property LockStatus() As VehicleLockStatus
            Get
                Return Native.Function.Call(Of VehicleLockStatus)(Hash.GET_VEHICLE_DOOR_LOCK_STATUS, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, Handle, Value)
            End Set
        End Property

        Public ReadOnly Property MaxBraking() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_MAX_BRAKING, Handle)
            End Get
        End Property
        Public ReadOnly Property MaxTraction() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_MAX_TRACTION, Handle)
            End Get
        End Property

        Public ReadOnly Property IsOnAllWheels() As Boolean

            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_ON_ALL_WHEELS, Handle)
            End Get
        End Property

        Public ReadOnly Property IsStopped() As Boolean

            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_STOPPED, Handle)
            End Get
        End Property
        Public ReadOnly Property IsStoppedAtTrafficLights() As Boolean

            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_STOPPED_AT_TRAFFIC_LIGHTS, Handle)
            End Get
        End Property

        Public Property IsStolen() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_STOLEN, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_IS_STOLEN, Handle, Value)
            End Set
        End Property

        Public ReadOnly Property IsConvertible() As Boolean

            Get
                Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_A_CONVERTIBLE, Handle, 0)
            End Get
        End Property

        Public Function IsInBurnout() As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_IN_BURNOUT, Handle)
        End Function

        Public ReadOnly Property Driver() As Ped
            Get
                Return GetPedOnSeat(VehicleSeat.Driver)
            End Get
        End Property
        Public ReadOnly Property Occupants() As Ped()
            Get
                Dim driver__1 As Ped = Driver

                If Not Ped.Exists(driver__1) Then
                    Return Passengers
                End If

                Dim result = New Ped(PassengerCount) {}
                result(0) = driver__1

                Dim i As Integer = 0, seats As Integer = PassengerSeats
                While i < seats AndAlso i <= result.Length
                    result(i + 1) = GetPedOnSeat(DirectCast(i, VehicleSeat))
                    i += 1
                End While

                Return result
            End Get
        End Property
        Public ReadOnly Property Passengers() As Ped()
            Get
                Dim result = New Ped(PassengerCount - 1) {}

                If result.Length = 0 Then
                    Return result
                End If

                Dim i As Integer = 0, seats As Integer = PassengerSeats
                While i < seats AndAlso i < result.Length
                    result(i) = GetPedOnSeat(DirectCast(i, VehicleSeat))
                    i += 1
                End While

                Return result
            End Get
        End Property
        Public ReadOnly Property PassengerSeats() As Integer
            Get
                Return Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, Handle)
            End Get
        End Property
        Public ReadOnly Property PassengerCount() As Integer
            Get
                Return Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_NUMBER_OF_PASSENGERS, Handle)
            End Get
        End Property

        Public Sub InstallModKit()
            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, Handle, 0)
        End Sub
        Public Function GetMod(modType As VehicleMod) As Integer
            Return Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, Handle, modType)
        End Function
        Public Sub SetMod(modType As VehicleMod, modIndex As Integer, variations As Boolean)
            Native.Function.Call(Hash.SET_VEHICLE_MOD, Handle, modType, modIndex, variations)
        End Sub
        Public Function GetModCount(modType As VehicleMod) As Integer
            Return Native.Function.Call(Of Integer)(Hash.GET_NUM_VEHICLE_MODS, Handle, modType)
        End Function
        Public Sub ToggleMod(toggleMod__1 As VehicleToggleMod, toggle As Boolean)
            Native.Function.Call(Hash.TOGGLE_VEHICLE_MOD, Handle, toggleMod__1, toggle)
        End Sub
        Public Function IsToggleModOn(toggleMod As VehicleToggleMod) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, Handle, toggleMod)
        End Function
        Public Function GetModTypeName(modType As VehicleMod) As String
            Return Native.Function.Call(Of String)(Hash.GET_MOD_SLOT_NAME, Handle, modType)
        End Function
        Public Function GetToggleModTypeName(toggleModType As VehicleToggleMod) As String
            Return Native.Function.Call(Of String)(Hash.GET_MOD_SLOT_NAME, Handle, toggleModType)
        End Function
        Public Function GetModName(modType As VehicleMod, modValue As Integer) As String
            Return Native.Function.Call(Of String)(Hash.GET_MOD_TEXT_LABEL, Handle, modType, modValue)
        End Function

        Public Function ExtraExists(extra As Integer) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.DOES_EXTRA_EXIST, Handle, extra)
        End Function
        Public Function IsExtraOn(extra As Integer) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, Handle, extra)
        End Function
        Public Sub ToggleExtra(extra As Integer, toggle As Boolean)
            Native.Function.Call(Hash.SET_VEHICLE_EXTRA, Handle, extra, Not toggle)
        End Sub

        Public Function GetPedOnSeat(seat As VehicleSeat) As Ped
            Return New Ped(Native.Function.Call(Of Integer)(Hash.GET_PED_IN_VEHICLE_SEAT, Handle, seat))
        End Function
        Public Function IsSeatFree(seat As VehicleSeat) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_SEAT_FREE, Handle, seat)
        End Function

        Public Sub Wash()
            DirtLevel = 0F
        End Sub
        Public Property DirtLevel() As Single
            Get
                Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_DIRT_LEVEL, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, Handle, Value)
            End Set
        End Property

        Public Function PlaceOnGround() As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Handle)
        End Function
        Public Sub PlaceOnNextStreet()
            Dim currentPosition As Vector3 = Position
            Dim headingArg = New OutputArgument()
            Dim newPositionArg = New OutputArgument()

            For i As Integer = 1 To 39
                Native.Function.Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_WITH_HEADING, currentPosition.X, currentPosition.Y, currentPosition.Z, i, newPositionArg,
                headingArg, New OutputArgument(), 1, &H40400000, 0)

                Dim newPosition = newPositionArg.GetResult(Of Vector3)()

                If Not Native.Function.Call(Of Boolean)(Hash.IS_POINT_OBSCURED_BY_A_MISSION_ENTITY, newPosition.X, newPosition.Y, newPosition.Z, 5.0F, 5.0F,
                5.0F, 0) Then
                    Position = newPosition
                    PlaceOnGround()
                    Heading = headingArg.GetResult(Of Single)()
                    Exit For
                End If
            Next
        End Sub

        Public Sub Repair()
            Native.Function.Call(Hash.SET_VEHICLE_FIXED, Handle)
        End Sub
        Public Sub Explode()
            Native.Function.Call(Hash.EXPLODE_VEHICLE, Handle, True, False)
        End Sub

        Public Property CanTiresBurst() As Boolean
            Get
                Return Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_TYRES_CAN_BURST, Handle)
            End Get
            Set
                Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, Handle, Value)
            End Set
        End Property
        Public WriteOnly Property CanWheelsBreak() As Boolean
            Set
                Native.Function.Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, Handle, Value)
            End Set
        End Property
        Public Sub FixTire(wheel As Integer)
            Native.Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, Handle, wheel)
        End Sub
        Public Sub BurstTire(wheel As Integer)
            Native.Function.Call(Hash.SET_VEHICLE_TYRE_BURST, Handle, wheel, 1, 1000.0F)
        End Sub
        Public Function IsTireBurst(wheel As Integer) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_TYRE_BURST, Handle, wheel, False)
        End Function

        Public Function GetDoors() As VehicleDoor()
            Dim list = New List(Of VehicleDoor)()

            If HasBone("door_dside_f") Then
                list.Add(VehicleDoor.FrontLeftDoor)
            End If
            If HasBone("door_pside_f") Then
                list.Add(VehicleDoor.FrontRightDoor)
            End If
            If HasBone("door_dside_r") Then
                list.Add(VehicleDoor.BackLeftDoor)
            End If
            If HasBone("door_pside_r") Then
                list.Add(VehicleDoor.BackRightDoor)
            End If
            If HasBone("bonnet") Then
                list.Add(VehicleDoor.Hood)
            End If
            If HasBone("hood") Then
                list.Add(VehicleDoor.Trunk)
            End If

            Return list.ToArray()
        End Function
        Public Sub OpenDoor(door As VehicleDoor, loose As Boolean, instantly As Boolean)
            Native.Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, Handle, door, loose, instantly)
        End Sub
        Public Sub CloseDoor(door As VehicleDoor, instantly As Boolean)
            Native.Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, Handle, door, instantly)
        End Sub
        Public Sub BreakDoor(door As VehicleDoor, Optional delete As Boolean = True)
            Native.Function.Call(Hash.SET_VEHICLE_DOOR_BROKEN, Handle, door, delete)
        End Sub
        Public Function IsDoorOpen(door As VehicleDoor) As Boolean
            Return GetDoorAngleRatio(door) > 0
        End Function
        Public Function IsDoorBroken(door As VehicleDoor) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_DOOR_DAMAGED, Handle, door)
        End Function
        Public Sub SetDoorBreakable(door As VehicleDoor, isBreakable As Boolean)
            Native.Function.Call(Hash._SET_VEHICLE_DOOR_BREAKABLE, Handle, door, isBreakable)
        End Sub
        Public Function GetDoorAngleRatio(door As VehicleDoor) As Single
            Return Native.Function.Call(Of Single)(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, Handle, door)
        End Function

        Public ReadOnly Property HasBombBay() As Boolean
            Get
                Return HasBone("door_hatch_l") AndAlso HasBone("door_hatch_r")
            End Get
        End Property
        Public Sub OpenBombBay()
            If HasBombBay Then
                Native.Function.Call(Hash._OPEN_VEHICLE_BOMB_BAY, Handle)
            End If
        End Sub

        Public Sub FixWindow(window As VehicleWindow)
            Native.Function.Call(Hash.FIX_VEHICLE_WINDOW, Handle, window)
        End Sub
        Public Sub SmashWindow(window As VehicleWindow)
            Native.Function.Call(Hash.SMASH_VEHICLE_WINDOW, Handle, window)
        End Sub
        Public Sub RollUpWindow(window As VehicleWindow)
            Native.Function.Call(Hash.ROLL_UP_WINDOW, Handle, window)
        End Sub
        Public Sub RollDownWindow(window As VehicleWindow)
            Native.Function.Call(Hash.ROLL_DOWN_WINDOW, Handle, window)
        End Sub
        Public Sub RollDownWindows()
            Native.Function.Call(Hash.ROLL_DOWN_WINDOWS, Handle)
        End Sub
        Public Sub RemoveWindow(window As VehicleWindow)
            Native.Function.Call(Hash.REMOVE_VEHICLE_WINDOW, Handle, window)
        End Sub

        Public Function IsNeonLightsOn(light As VehicleNeonLight) As Boolean
            Return Native.Function.Call(Of Boolean)(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, Handle, light)
        End Function
        Public Sub SetNeonLightsOn(light As VehicleNeonLight, [on] As Boolean)
            Native.Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, Handle, light, [on])
        End Sub

        Public Sub SetHeliYawPitchRollMult(mult As Single)
            If Model.IsHelicopter AndAlso mult >= 0 AndAlso mult <= 1 Then
                Native.Function.Call(Hash._SET_HELICOPTER_ROLL_PITCH_YAW_MULT, Handle, mult)
            End If
        End Sub

        Public Sub DropCargobobHook(hook As CargobobHook)
            If Model.IsCargobob Then
                Native.Function.Call(Hash._ENABLE_CARGOBOB_HOOK, Handle, hook)
            End If
        End Sub
        Public Sub RetractCargobobHook()
            If Model.IsCargobob Then
                Native.Function.Call(Hash._RETRACT_CARGOBOB_HOOK, Handle)
            End If
        End Sub
        Public Function IsCargobobHookActive() As Boolean
            If Model.IsCargobob Then
                Return Native.Function.Call(Of Boolean)(Hash._IS_CARGOBOB_HOOK_ACTIVE, Handle) OrElse Native.Function.Call(Of Boolean)(Hash._IS_CARGOBOB_MAGNET_ACTIVE, Handle)
            End If

            Return False
        End Function
        Public Function IsCargobobHookActive(hook As CargobobHook) As Boolean
            If Model.IsCargobob Then
                Select Case hook
                    Case CargobobHook.Hook
                        Return Native.Function.Call(Of Boolean)(Hash._IS_CARGOBOB_HOOK_ACTIVE, Handle)
                    Case CargobobHook.Magnet
                        Return Native.Function.Call(Of Boolean)(Hash._IS_CARGOBOB_MAGNET_ACTIVE, Handle)
                End Select
            End If

            Return False
        End Function
        Public Sub CargoBobMagnetGrabVehicle()
            If IsCargobobHookActive(CargobobHook.Magnet) Then
                Native.Function.Call(Hash._CARGOBOB_MAGNET_GRAB_VEHICLE, Handle, True)
            End If
        End Sub
        Public Sub CargoBobMagnetReleaseVehicle()
            If IsCargobobHookActive(CargobobHook.Magnet) Then
                Native.Function.Call(Hash._CARGOBOB_MAGNET_GRAB_VEHICLE, Handle, False)
            End If
        End Sub

        Public ReadOnly Property HasTowArm() As Boolean
            Get
                Return HasBone("tow_arm")
            End Get
        End Property

        Public ReadOnly Property TowedVehicle() As Vehicle
            Get
                Return New Vehicle(Native.Function.Call(Of Integer)(Hash.GET_ENTITY_ATTACHED_TO_TOW_TRUCK, Handle))
            End Get
        End Property
        Public Sub TowVehicle(vehicle As Vehicle, rear As Boolean)
            Native.Function.Call(Hash.ATTACH_VEHICLE_TO_TOW_TRUCK, Handle, vehicle.Handle, rear, 0F, 0F,
            0F)
        End Sub
        Public Sub DetachFromTowTruck()
            Native.Function.Call(Hash.DETACH_VEHICLE_FROM_ANY_TOW_TRUCK, Handle)
        End Sub
        Public Sub DetachTowedVehicle()
            Dim vehicle As Vehicle = TowedVehicle

            If Exists(vehicle) Then
                Native.Function.Call(Hash.DETACH_VEHICLE_FROM_TOW_TRUCK, Handle, vehicle.Handle)
            End If
        End Sub

        Public Sub ApplyDamage(position As Vector3, damageAmount As Single, radius As Single)
            Native.Function.Call(Hash.SET_VEHICLE_DAMAGE, position.X, position.Y, position.Z, damageAmount, radius)
        End Sub

        Public Function CreatePedOnSeat(seat As VehicleSeat, model As Model) As Ped
            If Not model.IsPed OrElse Not model.Request(1000) Then
                Return Nothing
            End If

            Return New Ped(Native.Function.Call(Of Integer)(Hash.CREATE_PED_INSIDE_VEHICLE, Handle, 26, model.Hash, seat, 1,
            1))
        End Function
        Public Function CreateRandomPedOnSeat(seat As VehicleSeat) As Ped
            If seat = VehicleSeat.Driver Then
                Return New Ped(Native.Function.Call(Of Integer)(Hash.CREATE_RANDOM_PED_AS_DRIVER, Handle, True))
            Else
                Dim pedHandle As Integer = Native.Function.Call(Of Integer)(Hash.CREATE_RANDOM_PED, 0F, 0F, 0F)
                Native.Function.Call(Hash.SET_PED_INTO_VEHICLE, pedHandle, Handle, seat)

                Return New Ped(pedHandle)
            End If
        End Function
    End Class

    Public Enum INMBlipColor
        White = 0
        Franklin = 43
        Michael = 42
        Trevor = 44
        Yellow = 66
    End Enum
End Namespace
