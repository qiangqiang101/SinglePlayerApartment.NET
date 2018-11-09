Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports INMNativeUI
Imports System.Drawing

Namespace INMNative

    Public Class Apartment

        Private _cost, _interiorID, _radio As Integer
        Private _owner, _name, _desc, _unit, _grgpath, _savefile, _playermap, _ipl, _lastipl As String
        Private _aptblip, _grgblip As Blip
        Private _entrance, _save, _telin, _telout, _telheli, _exit, _wardrobe, _garageent, _grgout, _camerapos, _camerarot, _interior, _ascamerapos, _ascamerarot, _assistantpos As Vector3
        Private _grgoutheading, _camerafov, _wardrobeheading, _ascamerafov, _assistantheading As Single
        Private _isathome, _enabled As Boolean
        Private _interiorV2 As Interior
        'added on v1.10
        Private _lrRadio, _hrRadio, _brRadio, _assChair As Prop
        Private lrEmitter, hrEmitter, brEmitter As String
        Private lrPosition, hrPosition, brPosition As Vector3
        Private _officeAssistant As Ped
        Private _garageElevator, _menuActivator, _garageElevator2, _menuActivator2, _garageElevator3, _menuActivator3 As Vector3
        Private veh0Pos, veh1Pos, veh2Pos, veh3Pos, veh4Pos, veh5Pos, veh6Pos, veh7Pos, veh8Pos, veh9Pos, veh10Pos, veh11Pos, veh12Pos, veh13Pos, veh14Pos, veh15Pos, veh16Pos, veh17Pos, veh18Pos, veh19Pos As Vector3
        Private vehRot0613, vehRot1714, vehRot2815, vehRot3916, vehRot41017, vehRot51118, vehRot1219 As Vector3
        Private _garageIPL, _garageIPL2, _garageIPL3, _garageWall1, _garageWall2, _garageWall3, _garageLight1, _garageLight2, _garageLight3, _garageNumber1, _garageNumber2, _garageNumber3 As String
        Private _garageWallText1, _garageLightText1, _garageNumText1, _garageWallText2, _garageLightText2, _garageNumText2, _garageWallText3, _garageLightText3, _garageNumText3 As String
        Private _1fCamPos, _2fCamPos, _3fCamPos, _1fCamRot, _2fCamRot, _3fCamRot As Vector3

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

        Public Property TeleportHelipad() As Vector3
            Get
                Return _telheli
            End Get
            Set(value As Vector3)
                _telheli = value
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

        Public ReadOnly Property RoofDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, TeleportHelipad)
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

        Public Property InteriorV2() As Interior
            Get
                Return _interiorV2
            End Get
            Set(value As Interior)
                _interiorV2 = value
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

        Public Property LivingRoomRadio() As Prop
            Get
                Return _lrRadio
            End Get
            Set(value As Prop)
                _lrRadio = value
            End Set
        End Property

        Public Property BedRoomRadio() As Prop
            Get
                Return _brRadio
            End Get
            Set(value As Prop)
                _brRadio = value
            End Set
        End Property

        Public Property HeistRoomRadio() As Prop
            Get
                Return _hrRadio
            End Get
            Set(value As Prop)
                _hrRadio = value
            End Set
        End Property

        Public Property LivingRoomEmitter() As String
            Get
                Return lrEmitter
            End Get
            Set(value As String)
                lrEmitter = value
            End Set
        End Property

        Public Property BedRoomEmitter() As String
            Get
                Return brEmitter
            End Get
            Set(value As String)
                brEmitter = value
            End Set
        End Property

        Public Property HeistRoomEmitter() As String
            Get
                Return hrEmitter
            End Get
            Set(value As String)
                hrEmitter = value
            End Set
        End Property

        Public Property LivingRoomRadioPosition() As Vector3
            Get
                Return lrPosition
            End Get
            Set(value As Vector3)
                lrPosition = value
            End Set
        End Property

        Public Property BedRoomRadioPosition() As Vector3
            Get
                Return brPosition
            End Get
            Set(value As Vector3)
                brPosition = value
            End Set
        End Property

        Public Property HeistRoomRadioPosition() As Vector3
            Get
                Return hrPosition
            End Get
            Set(value As Vector3)
                hrPosition = value
            End Set
        End Property

        Public Property OfficeAssistant() As Ped
            Get
                Return _officeAssistant
            End Get
            Set(value As Ped)
                _officeAssistant = value
            End Set
        End Property

        Public Property AssistantPosition() As Vector3
            Get
                Return _assistantpos
            End Get
            Set(value As Vector3)
                _assistantpos = value
            End Set
        End Property

        Public Property AssistantChair() As Prop
            Get
                Return _assChair
            End Get
            Set(value As Prop)
                _assChair = value
            End Set
        End Property

        Public Property AssistantHeading() As Single
            Get
                Return _assistantheading
            End Get
            Set(value As Single)
                _assistantheading = value
            End Set
        End Property

        Public Property GarageElevator() As Vector3
            Get
                Return _garageElevator
            End Get
            Set(value As Vector3)
                _garageElevator = value
            End Set
        End Property

        Public Property GarageMenuActivator() As Vector3
            Get
                Return _menuActivator
            End Get
            Set(value As Vector3)
                _menuActivator = value
            End Set
        End Property

        Public ReadOnly Property GarageElevatorDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageElevator)
            End Get
        End Property

        Public ReadOnly Property GarageMenuActivatorDistance() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageMenuActivator)
            End Get
        End Property

        Public Property GarageElevator2() As Vector3
            Get
                Return _garageElevator2
            End Get
            Set(value As Vector3)
                _garageElevator2 = value
            End Set
        End Property

        Public Property GarageMenuActivator2() As Vector3
            Get
                Return _menuActivator2
            End Get
            Set(value As Vector3)
                _menuActivator2 = value
            End Set
        End Property

        Public ReadOnly Property GarageElevatorDistance2() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageElevator2)
            End Get
        End Property

        Public ReadOnly Property GarageMenuActivatorDistance2() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageMenuActivator2)
            End Get
        End Property

        Public Property GarageElevator3() As Vector3
            Get
                Return _garageElevator3
            End Get
            Set(value As Vector3)
                _garageElevator3 = value
            End Set
        End Property

        Public Property GarageMenuActivator3() As Vector3
            Get
                Return _menuActivator3
            End Get
            Set(value As Vector3)
                _menuActivator3 = value
            End Set
        End Property

        Public ReadOnly Property GarageElevatorDistance3() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageElevator3)
            End Get
        End Property

        Public ReadOnly Property GarageMenuActivatorDistance3() As Single
            Get
                Return World.GetDistance(Game.Player.Character.Position, GarageMenuActivator3)
            End Get
        End Property

        Public Property GarageVeh0Pos() As Vector3
            Get
                Return veh0Pos
            End Get
            Set(value As Vector3)
                veh0Pos = value
            End Set
        End Property

        Public Property GarageVeh1Pos() As Vector3
            Get
                Return veh1Pos
            End Get
            Set(value As Vector3)
                veh1Pos = value
            End Set
        End Property

        Public Property GarageVeh2Pos() As Vector3
            Get
                Return veh2Pos
            End Get
            Set(value As Vector3)
                veh2Pos = value
            End Set
        End Property

        Public Property GarageVeh3Pos() As Vector3
            Get
                Return veh3Pos
            End Get
            Set(value As Vector3)
                veh3Pos = value
            End Set
        End Property

        Public Property GarageVeh4Pos() As Vector3
            Get
                Return veh4Pos
            End Get
            Set(value As Vector3)
                veh4Pos = value
            End Set
        End Property

        Public Property GarageVeh5Pos() As Vector3
            Get
                Return veh5Pos
            End Get
            Set(value As Vector3)
                veh5Pos = value
            End Set
        End Property

        Public Property GarageVeh6Pos() As Vector3
            Get
                Return veh6Pos
            End Get
            Set(value As Vector3)
                veh6Pos = value
            End Set
        End Property

        Public Property GarageVeh7Pos() As Vector3
            Get
                Return veh7Pos
            End Get
            Set(value As Vector3)
                veh7Pos = value
            End Set
        End Property

        Public Property GarageVeh8Pos() As Vector3
            Get
                Return veh8Pos
            End Get
            Set(value As Vector3)
                veh8Pos = value
            End Set
        End Property

        Public Property GarageVeh9Pos() As Vector3
            Get
                Return veh9Pos
            End Get
            Set(value As Vector3)
                veh9Pos = value
            End Set
        End Property

        Public Property GarageVeh10Pos() As Vector3
            Get
                Return veh10Pos
            End Get
            Set(value As Vector3)
                veh10Pos = value
            End Set
        End Property

        Public Property GarageVeh11Pos() As Vector3
            Get
                Return veh11Pos
            End Get
            Set(value As Vector3)
                veh11Pos = value
            End Set
        End Property

        Public Property GarageVeh12Pos() As Vector3
            Get
                Return veh12Pos
            End Get
            Set(value As Vector3)
                veh12Pos = value
            End Set
        End Property

        Public Property GarageVeh13Pos() As Vector3
            Get
                Return veh13Pos
            End Get
            Set(value As Vector3)
                veh13Pos = value
            End Set
        End Property

        Public Property GarageVeh14Pos() As Vector3
            Get
                Return veh14Pos
            End Get
            Set(value As Vector3)
                veh14Pos = value
            End Set
        End Property

        Public Property GarageVeh15Pos() As Vector3
            Get
                Return veh15Pos
            End Get
            Set(value As Vector3)
                veh15Pos = value
            End Set
        End Property

        Public Property GarageVeh16Pos() As Vector3
            Get
                Return veh16Pos
            End Get
            Set(value As Vector3)
                veh16Pos = value
            End Set
        End Property

        Public Property GarageVeh17Pos() As Vector3
            Get
                Return veh17Pos
            End Get
            Set(value As Vector3)
                veh17Pos = value
            End Set
        End Property

        Public Property GarageVeh18Pos() As Vector3
            Get
                Return veh18Pos
            End Get
            Set(value As Vector3)
                veh18Pos = value
            End Set
        End Property

        Public Property GarageVeh19Pos() As Vector3
            Get
                Return veh19Pos
            End Get
            Set(value As Vector3)
                veh19Pos = value
            End Set
        End Property

        Public Property GarageVeh0613Rot() As Vector3
            Get
                Return vehRot0613
            End Get
            Set(value As Vector3)
                vehRot0613 = value
            End Set
        End Property

        Public Property GarageVeh1714Rot() As Vector3
            Get
                Return vehRot1714
            End Get
            Set(value As Vector3)
                vehRot1714 = value
            End Set
        End Property

        Public Property GarageVeh2815Rot() As Vector3
            Get
                Return vehRot2815
            End Get
            Set(value As Vector3)
                vehRot2815 = value
            End Set
        End Property

        Public Property GarageVeh3916Rot() As Vector3
            Get
                Return vehRot3916
            End Get
            Set(value As Vector3)
                vehRot3916 = value
            End Set
        End Property

        Public Property GarageVeh41017Rot() As Vector3
            Get
                Return vehRot41017
            End Get
            Set(value As Vector3)
                vehRot41017 = value
            End Set
        End Property

        Public Property GarageVeh51118Rot() As Vector3
            Get
                Return vehRot51118
            End Get
            Set(value As Vector3)
                vehRot51118 = value
            End Set
        End Property

        Public Property GarageVeh1219Rot() As Vector3
            Get
                Return vehRot1219
            End Get
            Set(value As Vector3)
                vehRot1219 = value
            End Set
        End Property

        Public Property GarageIPL() As String
            Get
                Return _garageIPL
            End Get
            Set(value As String)
                _garageIPL = value
            End Set
        End Property

        Public Property GarageIPL2() As String
            Get
                Return _garageIPL2
            End Get
            Set(value As String)
                _garageIPL2 = value
            End Set
        End Property

        Public Property GarageIPL3() As String
            Get
                Return _garageIPL3
            End Get
            Set(value As String)
                _garageIPL3 = value
            End Set
        End Property

        Public Property GarageWall1() As String
            Get
                Return _garageWall1
            End Get
            Set(value As String)
                _garageWall1 = value
            End Set
        End Property

        Public Property GarageWall2() As String
            Get
                Return _garageWall2
            End Get
            Set(value As String)
                _garageWall2 = value
            End Set
        End Property

        Public Property GarageWall3() As String
            Get
                Return _garageWall3
            End Get
            Set(value As String)
                _garageWall3 = value
            End Set
        End Property

        Public Property GarageLight1() As String
            Get
                Return _garageLight1
            End Get
            Set(value As String)
                _garageLight1 = value
            End Set
        End Property

        Public Property GarageLight2() As String
            Get
                Return _garageLight2
            End Get
            Set(value As String)
                _garageLight2 = value
            End Set
        End Property

        Public Property GarageLight3() As String
            Get
                Return _garageLight3
            End Get
            Set(value As String)
                _garageLight3 = value
            End Set
        End Property

        Public Property GarageNumber1() As String
            Get
                Return _garageNumber1
            End Get
            Set(value As String)
                _garageNumber1 = value
            End Set
        End Property

        Public Property GarageNumber2() As String
            Get
                Return _garageNumber2
            End Get
            Set(value As String)
                _garageNumber2 = value
            End Set
        End Property

        Public Property GarageNumber3() As String
            Get
                Return _garageNumber3
            End Get
            Set(value As String)
                _garageNumber3 = value
            End Set
        End Property

        Public Property CamPos1F() As Vector3
            Get
                Return _1fCamPos
            End Get
            Set(value As Vector3)
                _1fCamPos = value
            End Set
        End Property

        Public Property CamPos2F() As Vector3
            Get
                Return _2fCamPos
            End Get
            Set(value As Vector3)
                _2fCamPos = value
            End Set
        End Property

        Public Property CamPos3F() As Vector3
            Get
                Return _3fCamPos
            End Get
            Set(value As Vector3)
                _3fCamPos = value
            End Set
        End Property

        Public Property CamRot1F() As Vector3
            Get
                Return _1fCamRot
            End Get
            Set(value As Vector3)
                _1fCamRot = value
            End Set
        End Property

        Public Property CamRot2F() As Vector3
            Get
                Return _2fCamRot
            End Get
            Set(value As Vector3)
                _2fCamRot = value
            End Set
        End Property

        Public Property CamRot3F() As Vector3
            Get
                Return _3fCamRot
            End Get
            Set(value As Vector3)
                _3fCamRot = value
            End Set
        End Property

        Public Property GarageWallText1() As String
            Get
                Return _garageWallText1
            End Get
            Set(value As String)
                _garageWallText1 = value
            End Set
        End Property

        Public Property GarageLightText1() As String
            Get
                Return _garageLightText1
            End Get
            Set(value As String)
                _garageLightText1 = value
            End Set
        End Property

        Public Property GarageNumberText1() As String
            Get
                Return _garageNumText1
            End Get
            Set(value As String)
                _garageNumText1 = value
            End Set
        End Property

        Public Property GarageWallText2() As String
            Get
                Return _garageWallText2
            End Get
            Set(value As String)
                _garageWallText2 = value
            End Set
        End Property

        Public Property GarageLightText2() As String
            Get
                Return _garageLightText2
            End Get
            Set(value As String)
                _garageLightText2 = value
            End Set
        End Property

        Public Property GarageNumberText2() As String
            Get
                Return _garageNumText2
            End Get
            Set(value As String)
                _garageNumText2 = value
            End Set
        End Property

        Public Property GarageWallText3() As String
            Get
                Return _garageWallText3
            End Get
            Set(value As String)
                _garageWallText3 = value
            End Set
        End Property

        Public Property GarageLightText3() As String
            Get
                Return _garageLightText3
            End Get
            Set(value As String)
                _garageLightText3 = value
            End Set
        End Property

        Public Property GarageNumberText3() As String
            Get
                Return _garageNumText3
            End Get
            Set(value As String)
                _garageNumText3 = value
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

        Public Sub CreateOffice(Apartment1 As Apartment)
            Apartment1.AptBlip = World.CreateBlip(Apartment1.Entrance)
            If Apartment1.Owner = "Michael" Then
                Apartment1.AptBlip.Sprite = BlipSprite2.Office
                Apartment1.AptBlip.Color = INMBlipColor.Michael
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Michael
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Franklin" Then
                Apartment1.AptBlip.Sprite = BlipSprite2.Office
                Apartment1.AptBlip.Color = INMBlipColor.Franklin
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Franklin
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Trevor" Then
                Apartment1.AptBlip.Sprite = BlipSprite2.Office
                Apartment1.AptBlip.Color = INMBlipColor.Trevor
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Trevor
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            ElseIf Apartment1.Owner = "Player3" Then
                Apartment1.AptBlip.Sprite = BlipSprite2.Office
                Apartment1.AptBlip.Color = INMBlipColor.Yellow
                Apartment1.AptBlip.IsShortRange = True
                Apartment1.AptBlip.Name = Apartment1.Name
                Apartment1.GrgBlip = World.CreateBlip(Apartment1.GarageEntrance)
                Apartment1.GrgBlip.Sprite = BlipSprite.Garage
                Apartment1.GrgBlip.Color = INMBlipColor.Yellow
                Apartment1.GrgBlip.IsShortRange = True
                Apartment1.GrgBlip.Name = Apartment1.Name & Apartment1.Unit & SinglePlayerApartment.Garage
            Else
                Apartment1.AptBlip.Sprite = BlipSprite2.OfficeForSale
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

    Public Class PersonalVehicle

        Private _owner As String
        Public Property Owner() As String
            Get
                Return _owner
            End Get
            Set(value As String)
                _owner = value
            End Set
        End Property

        Private _file As String
        Public Property FilePath() As String
            Get
                Return _file
            End Get
            Set(value As String)
                _file = value
            End Set
        End Property

        Private _vehicle As Vehicle
        Public Property Vehicle() As Vehicle
            Get
                Return _vehicle
            End Get
            Set(value As Vehicle)
                _vehicle = value
            End Set
        End Property

        Private _enable As Boolean
        Public Property Enable() As Boolean
            Get
                Return _enable
            End Get
            Set(value As Boolean)
                _enable = value
            End Set
        End Property

        Public ReadOnly Property Exist() As Boolean
            Get
                Return Not _file = Nothing
            End Get
        End Property

        Private _insurance As Integer
        Public Property Insurance() As Integer
            Get
                Return _insurance
            End Get
            Set(value As Integer)
                _insurance = value
            End Set
        End Property

        Public Sub New()
            _enable = False
        End Sub

        Public Sub New(Owner As String, FilePath As String, ByRef Vehicle As Vehicle)
            _owner = Owner
            _file = FilePath
            _vehicle = Vehicle
            _enable = True
            _insurance = 1
        End Sub

        Public Sub Delete()
            Owner = Nothing
            FilePath = Nothing
            Vehicle = Nothing
            Enable = False
        End Sub
    End Class

    Public Enum INMBlipColor
        White = 0
        Franklin = 43
        Michael = 42
        Trevor = 44
        Yellow = 66
    End Enum

    Public Class SPAVehicle
        Public Handle As Vehicle
        Public State As SPAVehicleState
    End Class

    Public Enum SPAVehicleState
        ' Fields
        Active = 1
        InGarage = 0
        Destroyed = 2
    End Enum
End Namespace
