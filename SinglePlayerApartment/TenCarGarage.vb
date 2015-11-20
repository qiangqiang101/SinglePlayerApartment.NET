Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.IO
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports AnimationV

Public Class TenCarGarage
    Inherits Script

    Public Shared playerHash As String
    Public Shared veh0, veh1, veh2, veh3, veh4, veh5, veh6, veh7, veh8, veh9 As Vehicle
    Public Shared LastLocationName As String
    Public Shared lastLocationVector As Vector3
    Public Shared lastLocationGarageVector As Vector3
    Public Shared lastLocationGarageOutVector As Vector3
    Public Shared lastLocationGarageOutHeading As Single
    Public Shared Elevator As Vector3 = New Vector3(238.7097, -1004.8488, -98.9999)
    Public Shared GarageDoorL As Vector3 = New Vector3(231.9013, -1006.686, -98.9999)
    Public Shared GarageDoorR As Vector3 = New Vector3(224.4288, -1006.6892, -98.9999)
    Public Shared GarageMiddle As Vector3 = New Vector3(228.7026, -989.8284, -98.9999)
    Public Shared MenuActivator As Vector3 = New Vector3(226.5738, -975.5375, -99.9999)
    Public Shared ElevatorDistance As Single
    Public Shared GarageDoorLDistance As Single
    Public Shared GarageDoorRDistance As Single
    Public Shared GarageMiddleDistance As Single
    Public Shared GarageMarkerDistance As Single
    Public Shared veh0Pos As Vector3 = New Vector3(223.4, -1001, -99.0)
    Public Shared veh1Pos As Vector3 = New Vector3(223.4, -996, -99.0)
    Public Shared veh2Pos As Vector3 = New Vector3(223.4, -991, -99.0)
    Public Shared veh3Pos As Vector3 = New Vector3(223.4, -986, -99.0)
    Public Shared veh4Pos As Vector3 = New Vector3(223.4, -981, -99.0)
    Public Shared veh5Pos As Vector3 = New Vector3(232.7, -1001, -99.0)
    Public Shared veh6Pos As Vector3 = New Vector3(232.7, -996, -99.0)
    Public Shared veh7Pos As Vector3 = New Vector3(232.7, -991, -99.0)
    Public Shared veh8Pos As Vector3 = New Vector3(232.7, -986, -99.0)
    Public Shared veh9Pos As Vector3 = New Vector3(232.7, -981, -99.0)
    Public Shared vehRot04 As Vector3 = New Vector3(0, 0, -60)
    Public Shared vehRot59 As Vector3 = New Vector3(0, 0, 60)
    Public Shared GarageMarker As New Marker(MarkerType.VerticalCylinder, MenuActivator, Color.LightBlue, AnimationType.Normal)
    Public Shared isInGarage As Boolean = False

    Public Sub New()
        Try
            uiLanguage = Game.Language.ToString
            If uiLanguage = "Chinese" Then
                Garage = "車庫"
            Else
                Garage = " Garage"
            End If

            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            Else
                playerName = "None"
            End If

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle0(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh0 = Nothing Then
                veh0 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh0.Delete()
                veh0 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh0, 0)
            veh0.Rotation = rot
            veh0.DirtLevel = 0F
            veh0.PrimaryColor = PrimaryColor
            veh0.SecondaryColor = SecondaryColor
            veh0.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh0.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh0.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh0.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh0.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh0.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh0.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh0.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh0.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh0.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh0.WheelType = WheelType
            veh0.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh0, PlateType)
            veh0.NumberPlate = PlateNumber
            veh0.WindowTint = WindowTint
            veh0.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh0.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh0.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh0.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh0.SetMod(VehicleMod.Frame, Frame, True)
            veh0.SetMod(VehicleMod.Grille, Grille, True)
            veh0.SetMod(VehicleMod.Hood, Hood, True)
            veh0.SetMod(VehicleMod.Fender, Fender, True)
            veh0.SetMod(VehicleMod.RightFender, RightFender, True)
            veh0.SetMod(VehicleMod.Roof, Roof, True)
            veh0.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh0.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh0.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh0.SetMod(VehicleMod.Suspension, Suspension, True)
            veh0.SetMod(VehicleMod.Engine, Engine, True)
            veh0.SetMod(VehicleMod.Brakes, Brakes, True)
            veh0.SetMod(VehicleMod.Transmission, Transmission, True)
            veh0.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh0.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh0.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle1(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh1 = Nothing Then
                veh1 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh1.Delete()
                veh1 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh1, 0)
            veh1.Rotation = rot
            veh1.DirtLevel = 0F
            veh1.PrimaryColor = PrimaryColor
            veh1.SecondaryColor = SecondaryColor
            veh1.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh1.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh1.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh1.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh1.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh1.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh1.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh1.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh1.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh1.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh1.WheelType = WheelType
            veh1.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh1, PlateType)
            veh1.NumberPlate = PlateNumber
            veh1.WindowTint = WindowTint
            veh1.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh1.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh1.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh1.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh1.SetMod(VehicleMod.Frame, Frame, True)
            veh1.SetMod(VehicleMod.Grille, Grille, True)
            veh1.SetMod(VehicleMod.Hood, Hood, True)
            veh1.SetMod(VehicleMod.Fender, Fender, True)
            veh1.SetMod(VehicleMod.RightFender, RightFender, True)
            veh1.SetMod(VehicleMod.Roof, Roof, True)
            veh1.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh1.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh1.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh1.SetMod(VehicleMod.Suspension, Suspension, True)
            veh1.SetMod(VehicleMod.Engine, Engine, True)
            veh1.SetMod(VehicleMod.Brakes, Brakes, True)
            veh1.SetMod(VehicleMod.Transmission, Transmission, True)
            veh1.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh1.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh1.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle2(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh2 = Nothing Then
                veh2 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh2.Delete()
                veh2 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh2, 0)
            veh2.Rotation = rot
            veh2.DirtLevel = 0F
            veh2.PrimaryColor = PrimaryColor
            veh2.SecondaryColor = SecondaryColor
            veh2.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh2.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh2.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh2.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh2.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh2.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh2.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh2.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh2.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh2.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh2.WheelType = WheelType
            veh2.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh2, PlateType)
            veh2.NumberPlate = PlateNumber
            veh2.WindowTint = WindowTint
            veh2.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh2.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh2.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh2.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh2.SetMod(VehicleMod.Frame, Frame, True)
            veh2.SetMod(VehicleMod.Grille, Grille, True)
            veh2.SetMod(VehicleMod.Hood, Hood, True)
            veh2.SetMod(VehicleMod.Fender, Fender, True)
            veh2.SetMod(VehicleMod.RightFender, RightFender, True)
            veh2.SetMod(VehicleMod.Roof, Roof, True)
            veh2.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh2.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh2.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh2.SetMod(VehicleMod.Suspension, Suspension, True)
            veh2.SetMod(VehicleMod.Engine, Engine, True)
            veh2.SetMod(VehicleMod.Brakes, Brakes, True)
            veh2.SetMod(VehicleMod.Transmission, Transmission, True)
            veh2.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh2.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh2.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle3(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh3 = Nothing Then
                veh3 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh3.Delete()
                veh3 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh3, 0)
            veh3.Rotation = rot
            veh3.DirtLevel = 0F
            veh3.PrimaryColor = PrimaryColor
            veh3.SecondaryColor = SecondaryColor
            veh3.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh3.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh3.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh3.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh3.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh3.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh3.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh3.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh3.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh3.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh3.WheelType = WheelType
            veh3.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh3, PlateType)
            veh3.NumberPlate = PlateNumber
            veh3.WindowTint = WindowTint
            veh3.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh3.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh3.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh3.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh3.SetMod(VehicleMod.Frame, Frame, True)
            veh3.SetMod(VehicleMod.Grille, Grille, True)
            veh3.SetMod(VehicleMod.Hood, Hood, True)
            veh3.SetMod(VehicleMod.Fender, Fender, True)
            veh3.SetMod(VehicleMod.RightFender, RightFender, True)
            veh3.SetMod(VehicleMod.Roof, Roof, True)
            veh3.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh3.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh3.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh3.SetMod(VehicleMod.Suspension, Suspension, True)
            veh3.SetMod(VehicleMod.Engine, Engine, True)
            veh3.SetMod(VehicleMod.Brakes, Brakes, True)
            veh3.SetMod(VehicleMod.Transmission, Transmission, True)
            veh3.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh3.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh3.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle4(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh4 = Nothing Then
                veh4 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh4.Delete()
                veh4 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh4, 0)
            veh4.Rotation = rot
            veh4.DirtLevel = 0F
            veh4.PrimaryColor = PrimaryColor
            veh4.SecondaryColor = SecondaryColor
            veh4.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh4.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh4.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh4.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh4.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh4.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh4.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh4.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh4.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh4.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh4.WheelType = WheelType
            veh4.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh4, PlateType)
            veh4.NumberPlate = PlateNumber
            veh4.WindowTint = WindowTint
            veh4.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh4.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh4.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh4.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh4.SetMod(VehicleMod.Frame, Frame, True)
            veh4.SetMod(VehicleMod.Grille, Grille, True)
            veh4.SetMod(VehicleMod.Hood, Hood, True)
            veh4.SetMod(VehicleMod.Fender, Fender, True)
            veh4.SetMod(VehicleMod.RightFender, RightFender, True)
            veh4.SetMod(VehicleMod.Roof, Roof, True)
            veh4.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh4.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh4.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh4.SetMod(VehicleMod.Suspension, Suspension, True)
            veh4.SetMod(VehicleMod.Engine, Engine, True)
            veh4.SetMod(VehicleMod.Brakes, Brakes, True)
            veh4.SetMod(VehicleMod.Transmission, Transmission, True)
            veh4.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh4.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh4.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle5(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh5 = Nothing Then
                veh5 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh5.Delete()
                veh5 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh5, 0)
            veh5.Rotation = rot
            veh5.DirtLevel = 0F
            veh5.PrimaryColor = PrimaryColor
            veh5.SecondaryColor = SecondaryColor
            veh5.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh5.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh5.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh5.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh5.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh5.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh5.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh5.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh5.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh5.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh5.WheelType = WheelType
            veh5.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh5, PlateType)
            veh5.NumberPlate = PlateNumber
            veh5.WindowTint = WindowTint
            veh5.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh5.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh5.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh5.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh5.SetMod(VehicleMod.Frame, Frame, True)
            veh5.SetMod(VehicleMod.Grille, Grille, True)
            veh5.SetMod(VehicleMod.Hood, Hood, True)
            veh5.SetMod(VehicleMod.Fender, Fender, True)
            veh5.SetMod(VehicleMod.RightFender, RightFender, True)
            veh5.SetMod(VehicleMod.Roof, Roof, True)
            veh5.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh5.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh5.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh5.SetMod(VehicleMod.Suspension, Suspension, True)
            veh5.SetMod(VehicleMod.Engine, Engine, True)
            veh5.SetMod(VehicleMod.Brakes, Brakes, True)
            veh5.SetMod(VehicleMod.Transmission, Transmission, True)
            veh5.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh5.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh5.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle6(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh6 = Nothing Then
                veh6 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh6.Delete()
                veh6 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh6, 0)
            veh6.Rotation = rot
            veh6.DirtLevel = 0F
            veh6.PrimaryColor = PrimaryColor
            veh6.SecondaryColor = SecondaryColor
            veh6.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh6.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh6.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh6.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh6.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh6.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh6.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh6.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh6.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh6.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh6.WheelType = WheelType
            veh6.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh6, PlateType)
            veh6.NumberPlate = PlateNumber
            veh6.WindowTint = WindowTint
            veh6.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh6.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh6.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh6.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh6.SetMod(VehicleMod.Frame, Frame, True)
            veh6.SetMod(VehicleMod.Grille, Grille, True)
            veh6.SetMod(VehicleMod.Hood, Hood, True)
            veh6.SetMod(VehicleMod.Fender, Fender, True)
            veh6.SetMod(VehicleMod.RightFender, RightFender, True)
            veh6.SetMod(VehicleMod.Roof, Roof, True)
            veh6.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh6.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh6.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh6.SetMod(VehicleMod.Suspension, Suspension, True)
            veh6.SetMod(VehicleMod.Engine, Engine, True)
            veh6.SetMod(VehicleMod.Brakes, Brakes, True)
            veh6.SetMod(VehicleMod.Transmission, Transmission, True)
            veh6.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh6.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh6.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle7(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh7 = Nothing Then
                veh7 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh7.Delete()
                veh7 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh7, 0)
            veh7.Rotation = rot
            veh7.DirtLevel = 0F
            veh7.PrimaryColor = PrimaryColor
            veh7.SecondaryColor = SecondaryColor
            veh7.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh7.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh7.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh7.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh7.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh7.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh7.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh7.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh7.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh7.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh7.WheelType = WheelType
            veh7.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh7, PlateType)
            veh7.NumberPlate = PlateNumber
            veh7.WindowTint = WindowTint
            veh7.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh7.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh7.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh7.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh7.SetMod(VehicleMod.Frame, Frame, True)
            veh7.SetMod(VehicleMod.Grille, Grille, True)
            veh7.SetMod(VehicleMod.Hood, Hood, True)
            veh7.SetMod(VehicleMod.Fender, Fender, True)
            veh7.SetMod(VehicleMod.RightFender, RightFender, True)
            veh7.SetMod(VehicleMod.Roof, Roof, True)
            veh7.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh7.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh7.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh7.SetMod(VehicleMod.Suspension, Suspension, True)
            veh7.SetMod(VehicleMod.Engine, Engine, True)
            veh7.SetMod(VehicleMod.Brakes, Brakes, True)
            veh7.SetMod(VehicleMod.Transmission, Transmission, True)
            veh7.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh7.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh7.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle8(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh8 = Nothing Then
                veh8 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh8.Delete()
                veh8 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh8, 0)
            veh8.Rotation = rot
            veh8.DirtLevel = 0F
            veh8.PrimaryColor = PrimaryColor
            veh8.SecondaryColor = SecondaryColor
            veh8.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh8.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh8.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh8.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh8.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh8.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh8.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh8.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh8.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh8.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh8.WheelType = WheelType
            veh8.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh8, PlateType)
            veh8.NumberPlate = PlateNumber
            veh8.WindowTint = WindowTint
            veh8.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh8.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh8.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh8.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh8.SetMod(VehicleMod.Frame, Frame, True)
            veh8.SetMod(VehicleMod.Grille, Grille, True)
            veh8.SetMod(VehicleMod.Hood, Hood, True)
            veh8.SetMod(VehicleMod.Fender, Fender, True)
            veh8.SetMod(VehicleMod.RightFender, RightFender, True)
            veh8.SetMod(VehicleMod.Roof, Roof, True)
            veh8.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh8.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh8.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh8.SetMod(VehicleMod.Suspension, Suspension, True)
            veh8.SetMod(VehicleMod.Engine, Engine, True)
            veh8.SetMod(VehicleMod.Brakes, Brakes, True)
            veh8.SetMod(VehicleMod.Transmission, Transmission, True)
            veh8.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh8.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh8.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle9(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", file)
            Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", file)
            Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", file)
            Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", file)
            Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", file)
            Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", file)
            Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", file)
            Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", file)
            Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", file)
            Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", file)
            Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", file)
            Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", file)
            Dim RimColor As String = ReadCfgValue("RimColor", file)
            Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", file)
            Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", file)
            Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", file)
            Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", file)
            Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", file)
            Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", file)
            Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", file)
            Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", file)
            Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", file)
            Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", file)
            Dim WheelType As String = ReadCfgValue("WheelType", file)
            Dim Livery As String = ReadCfgValue("Livery", file)
            Dim PlateType As String = ReadCfgValue("PlateType", file)
            Dim PlateNumber As String = ReadCfgValue("PlateNumber", file)
            Dim WindowTint As String = ReadCfgValue("WindowTint", file)
            Dim Spoiler As String = ReadCfgValue("Spoiler", file)
            Dim FrontBumper As String = ReadCfgValue("FrontBumper", file)
            Dim RearBumper As String = ReadCfgValue("RearBumper", file)
            Dim SideSkirt As String = ReadCfgValue("SideSkirt", file)
            Dim Frame As String = ReadCfgValue("Frame", file)
            Dim Grille As String = ReadCfgValue("Grille", file)
            Dim Hood As String = ReadCfgValue("Hood", file)
            Dim Fender As String = ReadCfgValue("Fender", file)
            Dim RightFender As String = ReadCfgValue("RightFender", file)
            Dim Roof As String = ReadCfgValue("Roof", file)
            Dim Exhaust As String = ReadCfgValue("Exhaust", file)
            Dim FrontWheels As String = ReadCfgValue("FrontWheels", file)
            Dim BackWheels As String = ReadCfgValue("BackWheels", file)
            Dim Suspension As String = ReadCfgValue("Suspension", file)
            Dim Engine As String = ReadCfgValue("Engine", file)
            Dim Brakes As String = ReadCfgValue("Brakes", file)
            Dim Transmission As String = ReadCfgValue("Transmission", file)
            Dim Armor As String = ReadCfgValue("Armor", file)
            Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", file)
            Dim Turbo As String = ReadCfgValue("Turbo", file)

            If veh9 = Nothing Then
                veh9 = World.CreateVehicle(VehicleModel, pos, head)
            Else
                veh9.Delete()
                veh9 = World.CreateVehicle(VehicleModel, pos, head)
            End If

            Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, veh9, 0)
            veh9.Rotation = rot
            veh9.DirtLevel = 0F
            veh9.PrimaryColor = PrimaryColor
            veh9.SecondaryColor = SecondaryColor
            veh9.PearlescentColor = PearlescentColor
            If HasCustomPriColor = "True" Then veh9.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
            If HasCustomSecColor = "True" Then veh9.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
            veh9.RimColor = RimColor
            If HasNeonLightBack = "True" Then veh9.SetNeonLightsOn(VehicleNeonLight.Back, True)
            If HasNeonLightFront = "True" Then veh9.SetNeonLightsOn(VehicleNeonLight.Front, True)
            If HasNeonLightLeft = "True" Then veh9.SetNeonLightsOn(VehicleNeonLight.Left, True)
            If HasNeonLightRight = "True" Then veh9.SetNeonLightsOn(VehicleNeonLight.Right, True)
            veh9.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
            veh9.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
            veh9.WheelType = WheelType
            veh9.Livery = Livery
            Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, veh9, PlateType)
            veh9.NumberPlate = PlateNumber
            veh9.WindowTint = WindowTint
            veh9.SetMod(VehicleMod.Spoilers, Spoiler, True)
            veh9.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
            veh9.SetMod(VehicleMod.RearBumper, RearBumper, True)
            veh9.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
            veh9.SetMod(VehicleMod.Frame, Frame, True)
            veh9.SetMod(VehicleMod.Grille, Grille, True)
            veh9.SetMod(VehicleMod.Hood, Hood, True)
            veh9.SetMod(VehicleMod.Fender, Fender, True)
            veh9.SetMod(VehicleMod.RightFender, RightFender, True)
            veh9.SetMod(VehicleMod.Roof, Roof, True)
            veh9.SetMod(VehicleMod.Exhaust, Exhaust, True)
            veh9.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
            veh9.SetMod(VehicleMod.BackWheels, BackWheels, True)
            veh9.SetMod(VehicleMod.Suspension, Suspension, True)
            veh9.SetMod(VehicleMod.Engine, Engine, True)
            veh9.SetMod(VehicleMod.Brakes, Brakes, True)
            veh9.SetMod(VehicleMod.Transmission, Transmission, True)
            veh9.SetMod(VehicleMod.Armor, Armor, True)
            If XenonHeadlights = "True" Then veh9.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
            If Turbo = "True" Then veh9.ToggleMod(VehicleToggleMod.Turbo, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVechicles(file As String)
        Try
            If Not veh0 = Nothing Then veh0.Delete()
            If Not veh1 = Nothing Then veh1.Delete()
            If Not veh2 = Nothing Then veh2.Delete()
            If Not veh3 = Nothing Then veh3.Delete()
            If Not veh4 = Nothing Then veh4.Delete()
            If Not veh5 = Nothing Then veh5.Delete()
            If Not veh6 = Nothing Then veh6.Delete()
            If Not veh7 = Nothing Then veh7.Delete()
            If Not veh8 = Nothing Then veh8.Delete()
            If Not veh9 = Nothing Then veh9.Delete()

            If IO.File.Exists(file & "vehicle_0.cfg") Then LoadGarageVehicle0(file & "vehicle_0.cfg", veh0Pos, vehRot04, -60)
            If IO.File.Exists(file & "vehicle_1.cfg") Then LoadGarageVehicle1(file & "vehicle_1.cfg", veh1Pos, vehRot04, -60)
            If IO.File.Exists(file & "vehicle_2.cfg") Then LoadGarageVehicle2(file & "vehicle_2.cfg", veh2Pos, vehRot04, -60)
            If IO.File.Exists(file & "vehicle_3.cfg") Then LoadGarageVehicle3(file & "vehicle_3.cfg", veh3Pos, vehRot04, -60)
            If IO.File.Exists(file & "vehicle_4.cfg") Then LoadGarageVehicle4(file & "vehicle_4.cfg", veh4Pos, vehRot04, -60)
            If IO.File.Exists(file & "vehicle_5.cfg") Then LoadGarageVehicle5(file & "vehicle_5.cfg", veh5Pos, vehRot59, -60)
            If IO.File.Exists(file & "vehicle_6.cfg") Then LoadGarageVehicle6(file & "vehicle_6.cfg", veh6Pos, vehRot59, -60)
            If IO.File.Exists(file & "vehicle_7.cfg") Then LoadGarageVehicle7(file & "vehicle_7.cfg", veh7Pos, vehRot59, -60)
            If IO.File.Exists(file & "vehicle_8.cfg") Then LoadGarageVehicle8(file & "vehicle_8.cfg", veh8Pos, vehRot59, -60)
            If IO.File.Exists(file & "vehicle_9.cfg") Then LoadGarageVehicle9(file & "vehicle_9.cfg", veh9Pos, vehRot59, -60)

            Mechanic.Path = file
            Mechanic.CreateGarageMenu(file)
            AddHandler Mechanic.GarageMenu.OnItemSelect, AddressOf Mechanic.ItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SaveGarageVehicle(file As String)
        Try
            If Not IO.File.Exists(file & "vehicle_0.cfg") Then
                IO.File.WriteAllText(file & "vehicle_0.cfg", My.Resources.vehicle)
                UpdateGarageVehicle(file & "vehicle_0.cfg")
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                playerPed.CurrentVehicle.Position = veh0Pos
                playerPed.CurrentVehicle.Rotation = vehRot04
                Script.Wait(500)
                Game.FadeScreenIn(500)
            Else
                If Not IO.File.Exists(file & "vehicle_1.cfg") Then
                    IO.File.WriteAllText(file & "vehicle_1.cfg", My.Resources.vehicle)
                    UpdateGarageVehicle(file & "vehicle_1.cfg")
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    playerPed.CurrentVehicle.Position = veh1Pos
                    playerPed.CurrentVehicle.Rotation = vehRot04
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                Else
                    If Not IO.File.Exists(file & "vehicle_2.cfg") Then
                        IO.File.WriteAllText(file & "vehicle_2.cfg", My.Resources.vehicle)
                        UpdateGarageVehicle(file & "vehicle_2.cfg")
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        playerPed.CurrentVehicle.Position = veh2Pos
                        playerPed.CurrentVehicle.Rotation = vehRot04
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                    Else
                        If Not IO.File.Exists(file & "vehicle_3.cfg") Then
                            IO.File.WriteAllText(file & "vehicle_3.cfg", My.Resources.vehicle)
                            UpdateGarageVehicle(file & "vehicle_3.cfg")
                            Game.FadeScreenOut(500)
                            Script.Wait(&H3E8)
                            playerPed.CurrentVehicle.Position = veh3Pos
                            playerPed.CurrentVehicle.Rotation = vehRot04
                            Script.Wait(500)
                            Game.FadeScreenIn(500)
                        Else
                            If Not IO.File.Exists(file & "vehicle_4.cfg") Then
                                IO.File.WriteAllText(file & "vehicle_4.cfg", My.Resources.vehicle)
                                UpdateGarageVehicle(file & "vehicle_4.cfg")
                                Game.FadeScreenOut(500)
                                Script.Wait(&H3E8)
                                playerPed.CurrentVehicle.Position = veh4Pos
                                playerPed.CurrentVehicle.Rotation = vehRot04
                                Script.Wait(500)
                                Game.FadeScreenIn(500)
                            Else
                                If Not IO.File.Exists(file & "vehicle_5.cfg") Then
                                    IO.File.WriteAllText(file & "vehicle_5.cfg", My.Resources.vehicle)
                                    UpdateGarageVehicle(file & "vehicle_5.cfg")
                                    Game.FadeScreenOut(500)
                                    Script.Wait(&H3E8)
                                    playerPed.CurrentVehicle.Position = veh5Pos
                                    playerPed.CurrentVehicle.Rotation = vehRot59
                                    Script.Wait(500)
                                    Game.FadeScreenIn(500)
                                Else
                                    If Not IO.File.Exists(file & "vehicle_6.cfg") Then
                                        IO.File.WriteAllText(file & "vehicle_6.cfg", My.Resources.vehicle)
                                        UpdateGarageVehicle(file & "vehicle_6.cfg")
                                        Game.FadeScreenOut(500)
                                        Script.Wait(&H3E8)
                                        playerPed.CurrentVehicle.Position = veh6Pos
                                        playerPed.CurrentVehicle.Rotation = vehRot59
                                        Script.Wait(500)
                                        Game.FadeScreenIn(500)
                                    Else
                                        If Not IO.File.Exists(file & "vehicle_7.cfg") Then
                                            IO.File.WriteAllText(file & "vehicle_7.cfg", My.Resources.vehicle)
                                            UpdateGarageVehicle(file & "vehicle_7.cfg")
                                            Game.FadeScreenOut(500)
                                            Script.Wait(&H3E8)
                                            playerPed.CurrentVehicle.Position = veh7Pos
                                            playerPed.CurrentVehicle.Rotation = vehRot59
                                            Script.Wait(500)
                                            Game.FadeScreenIn(500)
                                        Else
                                            If Not IO.File.Exists(file & "vehicle_8.cfg") Then
                                                IO.File.WriteAllText(file & "vehicle_8.cfg", My.Resources.vehicle)
                                                UpdateGarageVehicle(file & "vehicle_8.cfg")
                                                Game.FadeScreenOut(500)
                                                Script.Wait(&H3E8)
                                                playerPed.CurrentVehicle.Position = veh8Pos
                                                playerPed.CurrentVehicle.Rotation = vehRot59
                                                Script.Wait(500)
                                                Game.FadeScreenIn(500)
                                            Else
                                                If Not IO.File.Exists(file & "vehicle_9.cfg") Then
                                                    IO.File.WriteAllText(file & "vehicle_9.cfg", My.Resources.vehicle)
                                                    UpdateGarageVehicle(file & "vehicle_9.cfg")
                                                    Game.FadeScreenOut(500)
                                                    Script.Wait(&H3E8)
                                                    playerPed.CurrentVehicle.Position = veh9Pos
                                                    playerPed.CurrentVehicle.Rotation = vehRot59
                                                    Script.Wait(500)
                                                    Game.FadeScreenIn(500)
                                                Else
                                                    If uiLanguage = "Chinese" Then
                                                        UI.ShowSubtitle("車庫~r~已滿~w~。")
                                                    Else
                                                        UI.ShowSubtitle("Garage is ~r~Full~w~.")
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub UpdateGarageVehicle(file As String)
        WriteCfgValue("VehicleName", playerPed.CurrentVehicle.FriendlyName, file)
        WriteCfgValue("VehicleModel", playerPed.CurrentVehicle.DisplayName, file)
        WriteCfgValue("PrimaryColor", playerPed.CurrentVehicle.PrimaryColor, file)
        WriteCfgValue("SecondaryColor", playerPed.CurrentVehicle.SecondaryColor, file)
        WriteCfgValue("PearlescentColor", playerPed.CurrentVehicle.PearlescentColor, file)
        WriteCfgValue("HasCustomPrimaryColor", playerPed.CurrentVehicle.IsPrimaryColorCustom, file)
        WriteCfgValue("HasCustomSecondaryColor", playerPed.CurrentVehicle.IsSecondaryColorCustom, file)
        WriteCfgValue("CustomPrimaryColorRed", playerPed.CurrentVehicle.CustomPrimaryColor.R, file)
        WriteCfgValue("CustomPrimaryColorGreen", playerPed.CurrentVehicle.CustomPrimaryColor.G, file)
        WriteCfgValue("CustomPrimaryColorBlue", playerPed.CurrentVehicle.CustomPrimaryColor.B, file)
        WriteCfgValue("CustomSecondaryColorRed", playerPed.CurrentVehicle.CustomSecondaryColor.R, file)
        WriteCfgValue("CustomSecondaryColorGreen", playerPed.CurrentVehicle.CustomSecondaryColor.G, file)
        WriteCfgValue("CustomSecondaryColorBlue", playerPed.CurrentVehicle.CustomSecondaryColor.B, file)
        WriteCfgValue("RimColor", playerPed.CurrentVehicle.RimColor, file)
        WriteCfgValue("HasNeonLightBack", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Back), file)
        WriteCfgValue("HasNeonLightFront", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Front), file)
        WriteCfgValue("HasNeonLightLeft", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Left), file)
        WriteCfgValue("HasNeonLightRight", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Right), file)
        WriteCfgValue("NeonColorRed", playerPed.CurrentVehicle.NeonLightsColor.R, file)
        WriteCfgValue("NeonColorGreen", playerPed.CurrentVehicle.NeonLightsColor.G, file)
        WriteCfgValue("NeonColorBlue", playerPed.CurrentVehicle.NeonLightsColor.B, file)
        WriteCfgValue("TyreSmokeColorRed", playerPed.CurrentVehicle.TireSmokeColor.R, file)
        WriteCfgValue("TyreSmokeColorGreen", playerPed.CurrentVehicle.TireSmokeColor.G, file)
        WriteCfgValue("TyreSmokeColorBlue", playerPed.CurrentVehicle.TireSmokeColor.B, file)
        WriteCfgValue("WheelType", playerPed.CurrentVehicle.WheelType, file)
        WriteCfgValue("Livery", playerPed.CurrentVehicle.Livery, file)
        WriteCfgValue("PlateType", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, playerPed.CurrentVehicle), file)
        WriteCfgValue("PlateNumber", playerPed.CurrentVehicle.NumberPlate, file)
        WriteCfgValue("WindowTint", playerPed.CurrentVehicle.WindowTint, file)
        WriteCfgValue("Spoiler", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 1), file)
        WriteCfgValue("FrontBumper", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 1), file)
        WriteCfgValue("RearBumper", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 2), file)
        WriteCfgValue("SideSkirt", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 3), file)
        WriteCfgValue("Frame", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 5), file)
        WriteCfgValue("Grille", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 6), file)
        WriteCfgValue("Hood", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 7), file)
        WriteCfgValue("Fender", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 8), file)
        WriteCfgValue("RightFender", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 9), file)
        WriteCfgValue("Roof", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 10), file)
        WriteCfgValue("Exhaust", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 4), file)
        WriteCfgValue("FrontWheels", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 23), file)
        WriteCfgValue("BackWheels", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 24), file)
        WriteCfgValue("Suspension", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 15), file)
        WriteCfgValue("Engine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 11), file)
        WriteCfgValue("Brakes", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 12), file)
        WriteCfgValue("Transmission", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 13), file)
        WriteCfgValue("Armor", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 16), file)
        WriteCfgValue("XenonHeadlights", Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, playerPed.CurrentVehicle, 22), file)
        WriteCfgValue("Turbo", Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, playerPed.CurrentVehicle, 18), file)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            ElevatorDistance = World.GetDistance(playerPed.Position, Elevator)
            GarageDoorLDistance = World.GetDistance(playerPed.Position, GarageDoorL)
            GarageDoorRDistance = World.GetDistance(playerPed.Position, GarageDoorR)
            GarageMiddleDistance = World.GetDistance(playerPed.Position, GarageMiddle)
            GarageMarkerDistance = World.GetDistance(playerPed.Position, MenuActivator)

            If isInGarage = True Then
                GarageMarker.Flag = RenderFlag.Nearby
                GarageMarker.Draw()
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso ElevatorDistance < 3.0 Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 進入" & LastLocationName & "。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " & LastLocationName)
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso (GarageDoorLDistance < 3.0 Or GarageDoorRDistance < 3.0) Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 離開" & Garage & "。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to exit" & Garage)
                End If
            End If

            If Not playerPed.IsDead AndAlso GarageMarkerDistance < 3.0 Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 管理車輛。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to manage vehicles.")
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        If Game.IsControlJustPressed(0, GTA.Control.VehicleAccelerate) AndAlso playerPed.IsInVehicle AndAlso GarageMiddleDistance < 15.0 Then
            Game.FadeScreenOut(500)
            Script.Wait(&H3E8)
            playerPed.CurrentVehicle.Position = lastLocationGarageOutVector
            playerPed.CurrentVehicle.Heading = lastLocationGarageOutHeading
            playerPed.CurrentVehicle.AddBlip()
            playerPed.CurrentVehicle.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            isInGarage = False
            If playerName = "Michael" Then
                playerPed.CurrentVehicle.CurrentBlip.Color = BlipColor.Blue
            ElseIf playerName = "Franklin" Then
                playerPed.CurrentVehicle.CurrentBlip.Color = BlipColor.Green
            ElseIf playerName = “Trevor"
                playerPed.CurrentVehicle.CurrentBlip.Color = 17
            End If
            SetBlipName(playerPed.CurrentVehicle.FriendlyName, playerPed.CurrentVehicle.CurrentBlip)
            Script.Wait(500)
            Game.FadeScreenIn(500)
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso ElevatorDistance < 3.0 Then
            Game.FadeScreenOut(500)
            Script.Wait(&H3E8)
            isInGarage = False
            playerPed.Position = lastLocationVector
            SinglePlayerApartment.player.LastVehicle.Delete()
            Script.Wait(500)
            Game.FadeScreenIn(500)
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso (GarageDoorLDistance < 3.0 Or GarageDoorRDistance < 3.0) Then
            Game.FadeScreenOut(500)
            Script.Wait(&H3E8)
            isInGarage = False
            playerPed.Position = lastLocationGarageVector
            SinglePlayerApartment.player.LastVehicle.Delete()
            Script.Wait(500)
            Game.FadeScreenIn(500)
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso GarageMarkerDistance < 3.0 Then
            Mechanic.GarageMenu.Visible = True
        End If

    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try
                If Not veh0 = Nothing Then veh0.Delete()
                If Not veh1 = Nothing Then veh1.Delete()
                If Not veh2 = Nothing Then veh2.Delete()
                If Not veh3 = Nothing Then veh3.Delete()
                If Not veh4 = Nothing Then veh4.Delete()
                If Not veh5 = Nothing Then veh5.Delete()
                If Not veh6 = Nothing Then veh6.Delete()
                If Not veh7 = Nothing Then veh7.Delete()
                If Not veh8 = Nothing Then veh8.Delete()
                If Not veh9 = Nothing Then veh9.Delete()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
