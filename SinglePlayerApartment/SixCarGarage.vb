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
Imports System.Runtime.InteropServices

Public Class SixCarGarage
    Inherits Script

    Public Shared CurrentPath As String
    Public Shared veh0, veh1, veh2, veh3, veh4, veh5 As Vehicle
    Public Shared LastLocationName As String
    Public Shared lastLocationVector As Vector3
    Public Shared lastLocationGarageVector As Vector3
    Public Shared lastLocationGarageOutVector As Vector3
    Public Shared lastLocationGarageOutHeading As Single
    Public Shared Elevator As Vector3 = New Vector3(207.1506, -998.9948, -98.9999)
    Public Shared GarageDoorL As Vector3 = New Vector3(202.2906, -1007.7249, -98.9992)
    Public Shared GarageDoorR As Vector3 = New Vector3(194.4465, -1007.7326, -98.9999)
    Public Shared GarageMiddle As Vector3 = New Vector3(197.9781, -1000.8287, -98.9999)
    Public Shared MenuActivator As Vector3 = New Vector3(204.6184, -994.6097, -99.9999)
    Public Shared ElevatorDistance As Single
    Public Shared GarageDoorLDistance As Single
    Public Shared GarageDoorRDistance As Single
    Public Shared GarageMiddleDistance As Single
    Public Shared GarageMarkerDistance As Single
    Public Shared veh0Pos As Vector3 = New Vector3(197.5, -1004.425, -99.99999)
    Public Shared veh1Pos As Vector3 = New Vector3(201.06, -1004.425, -99.99999)
    Public Shared veh2Pos As Vector3 = New Vector3(204.62, -1004.425, -99.99999)
    Public Shared veh3Pos As Vector3 = New Vector3(192.9262, -996.3292, -99.99999)
    Public Shared veh4Pos As Vector3 = New Vector3(197.5, -996.3292, -99.99999)
    Public Shared veh5Pos As Vector3 = New Vector3(203.9257, -999.1467, -99.99999)
    Public Shared vehRot02 As Vector3 = New Vector3(0.0001003991, 4.043804, -4.035995)
    Public Shared vehRot35 As Vector3 = New Vector3(9.383157, -5.855135, -146.2832)
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
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "None"
            End If

            AddHandler Tick, AddressOf OnTick

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

#Region "LoadGarageVehicles"
    Public Shared Sub LoadGarageVehicle0(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If ReadCfgValue("VehicleModel", file) = "" Then
                If veh0 = Nothing Then
                    veh0 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                Else
                    veh0.Delete()
                    veh0 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                End If
            Else
                If veh0 = Nothing Then
                    veh0 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                Else
                    veh0.Delete()
                    veh0 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                End If
            End If

            SetModKit(veh0, file)
            veh0.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh0.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle1(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If ReadCfgValue("VehicleModel", file) = "" Then
                If veh1 = Nothing Then
                    veh1 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                Else
                    veh1.Delete()
                    veh1 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                End If
            Else
                If veh1 = Nothing Then
                    veh1 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                Else
                    veh1.Delete()
                    veh1 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                End If
            End If

            SetModKit(veh1, file)
            veh1.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh1.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle2(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If ReadCfgValue("VehicleModel", file) = "" Then
                If veh2 = Nothing Then
                    veh2 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                Else
                    veh2.Delete()
                    veh2 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                End If
            Else
                If veh2 = Nothing Then
                    veh2 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                Else
                    veh2.Delete()
                    veh2 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                End If
            End If

            SetModKit(veh2, file)
            veh2.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh2.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle3(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If ReadCfgValue("VehicleModel", file) = "" Then
                If veh3 = Nothing Then
                    veh3 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                Else
                    veh3.Delete()
                    veh3 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                End If
            Else
                If veh3 = Nothing Then
                    veh3 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                Else
                    veh3.Delete()
                    veh3 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                End If
            End If

            SetModKit(veh3, file)
            veh3.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh3.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle4(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If ReadCfgValue("VehicleModel", file) = "" Then
                If veh4 = Nothing Then
                    veh4 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                Else
                    veh4.Delete()
                    veh4 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                End If
            Else
                If veh4 = Nothing Then
                    veh4 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                Else
                    veh4.Delete()
                    veh4 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                End If
            End If

            SetModKit(veh4, file)
            veh4.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh4.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle5(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If ReadCfgValue("VehicleModel", file) = "" Then
                If veh5 = Nothing Then
                    veh5 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                Else
                    veh5.Delete()
                    veh5 = World.CreateVehicle(CInt(ReadCfgValue("VehicleHash", file)), pos, head)
                End If
            Else
                If veh5 = Nothing Then
                    veh5 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                Else
                    veh5.Delete()
                    veh5 = World.CreateVehicle(ReadCfgValue("VehicleModel", file), pos, head)
                End If
            End If

            SetModKit(veh5, file)
            veh5.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh5.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
#End Region

    Public Shared Sub LoadGarageVechicles(file As String)
        Try
            If Not veh0 = Nothing Then veh0.Delete()
            If Not veh1 = Nothing Then veh1.Delete()
            If Not veh2 = Nothing Then veh2.Delete()
            If Not veh3 = Nothing Then veh3.Delete()
            If Not veh4 = Nothing Then veh4.Delete()
            If Not veh5 = Nothing Then veh5.Delete()

            If IO.File.Exists(file & "vehicle_0.cfg") Then LoadGarageVehicle0(file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_1.cfg") Then LoadGarageVehicle1(file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_2.cfg") Then LoadGarageVehicle2(file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_3.cfg") Then LoadGarageVehicle3(file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
            If IO.File.Exists(file & "vehicle_4.cfg") Then LoadGarageVehicle4(file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
            If IO.File.Exists(file & "vehicle_5.cfg") Then LoadGarageVehicle5(file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)

            Mechanic.Path = file
            Mechanic.CreateGarageMenu6CarGarage(file)
            Mechanic.CreateGarageMenu2("Six")

            veh0.MarkAsNoLongerNeeded()
            veh1.MarkAsNoLongerNeeded()
            veh2.MarkAsNoLongerNeeded()
            veh3.MarkAsNoLongerNeeded()
            veh4.MarkAsNoLongerNeeded()
            veh5.MarkAsNoLongerNeeded()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String)
        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = ReadCfgValue("PrimaryColor", VehicleCfgFile)
        _Vehicle.SecondaryColor = ReadCfgValue("SecondaryColor", VehicleCfgFile)
        _Vehicle.PearlescentColor = ReadCfgValue("PearlescentColor", VehicleCfgFile)
        If ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomPrimaryColor = Color.FromArgb(ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile))
        If ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomSecondaryColor = Color.FromArgb(ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile))
        _Vehicle.RimColor = ReadCfgValue("RimColor", VehicleCfgFile)
        If ReadCfgValue("HasNeonLightBack", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Back, True)
        If ReadCfgValue("HasNeonLightFront", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Front, True)
        If ReadCfgValue("HasNeonLightLeft", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Left, True)
        If ReadCfgValue("HasNeonLightRight", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Right, True)
        _Vehicle.NeonLightsColor = Color.FromArgb(ReadCfgValue("NeonColorRed", VehicleCfgFile), ReadCfgValue("NeonColorGreen", VehicleCfgFile), ReadCfgValue("NeonColorBlue", VehicleCfgFile))
        _Vehicle.WheelType = ReadCfgValue("WheelType", VehicleCfgFile)
        _Vehicle.Livery = ReadCfgValue("Livery", VehicleCfgFile)
        Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, _Vehicle, CInt(ReadCfgValue("PlateType", VehicleCfgFile)))
        _Vehicle.NumberPlate = ReadCfgValue("PlateNumber", VehicleCfgFile)
        _Vehicle.WindowTint = ReadCfgValue("WindowTint", VehicleCfgFile)
        _Vehicle.SetMod(VehicleMod.Spoilers, ReadCfgValue("Spoiler", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.FrontBumper, ReadCfgValue("FrontBumper", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.RearBumper, ReadCfgValue("RearBumper", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.SideSkirt, ReadCfgValue("SideSkirt", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Frame, ReadCfgValue("Frame", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Grille, ReadCfgValue("Grille", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Hood, ReadCfgValue("Hood", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Fender, ReadCfgValue("Fender", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.RightFender, ReadCfgValue("RightFender", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Roof, ReadCfgValue("Roof", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Exhaust, ReadCfgValue("Exhaust", VehicleCfgFile), True)
        If ReadCfgValue("FrontTireVariation", VehicleCfgFile) = "True" Then _Vehicle.SetMod(VehicleMod.FrontWheels, ReadCfgValue("FrontWheels", VehicleCfgFile), True) Else _Vehicle.SetMod(VehicleMod.FrontWheels, ReadCfgValue("FrontWheels", VehicleCfgFile), False)
        If ReadCfgValue("BackTireVariation", VehicleCfgFile) = "True" Then _Vehicle.SetMod(VehicleMod.BackWheels, ReadCfgValue("BackWheels", VehicleCfgFile), True) Else _Vehicle.SetMod(VehicleMod.BackWheels, ReadCfgValue("BackWheels", VehicleCfgFile), False)
        _Vehicle.SetMod(VehicleMod.Suspension, ReadCfgValue("Suspension", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Brakes, ReadCfgValue("Brakes", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Transmission, ReadCfgValue("Transmission", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Armor, ReadCfgValue("Armor", VehicleCfgFile), True)
        _Vehicle.SetMod(25, ReadCfgValue("TwentyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(26, ReadCfgValue("TwentySix", VehicleCfgFile), True)
        _Vehicle.SetMod(27, ReadCfgValue("TwentySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(28, ReadCfgValue("TwentyEight", VehicleCfgFile), True)
        _Vehicle.SetMod(29, ReadCfgValue("TwentyNine", VehicleCfgFile), True)
        _Vehicle.SetMod(30, ReadCfgValue("ThirtyZero", VehicleCfgFile), True)
        _Vehicle.SetMod(31, ReadCfgValue("ThirtyOne", VehicleCfgFile), True)
        _Vehicle.SetMod(32, ReadCfgValue("ThirtyTwo", VehicleCfgFile), True)
        _Vehicle.SetMod(33, ReadCfgValue("ThirtyThree", VehicleCfgFile), True)
        _Vehicle.SetMod(34, ReadCfgValue("ThirtyFour", VehicleCfgFile), True)
        _Vehicle.SetMod(35, ReadCfgValue("ThirtyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(36, ReadCfgValue("ThirtySix", VehicleCfgFile), True)
        _Vehicle.SetMod(37, ReadCfgValue("ThirtySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(38, ReadCfgValue("ThirtyEight", VehicleCfgFile), True)
        _Vehicle.SetMod(39, ReadCfgValue("ThirtyNine", VehicleCfgFile), True)
        _Vehicle.SetMod(40, ReadCfgValue("ForthyZero", VehicleCfgFile), True)
        _Vehicle.SetMod(41, ReadCfgValue("ForthyOne", VehicleCfgFile), True)
        _Vehicle.SetMod(42, ReadCfgValue("ForthyTwo", VehicleCfgFile), True)
        _Vehicle.SetMod(43, ReadCfgValue("ForthyThree", VehicleCfgFile), True)
        _Vehicle.SetMod(44, ReadCfgValue("ForthyFour", VehicleCfgFile), True)
        _Vehicle.SetMod(45, ReadCfgValue("ForthyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(46, ReadCfgValue("ForthySix", VehicleCfgFile), True)
        _Vehicle.SetMod(47, ReadCfgValue("ForthySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(48, ReadCfgValue("ForthyEight", VehicleCfgFile), True)
        If ReadCfgValue("XenonHeadlights", VehicleCfgFile) = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
        If ReadCfgValue("Turbo", VehicleCfgFile) = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.Turbo, True)
        _Vehicle.ToggleMod(VehicleToggleMod.TireSmoke, True)
        _Vehicle.TireSmokeColor = Color.FromArgb(ReadCfgValue("TyreSmokeColorRed", VehicleCfgFile), ReadCfgValue("TyreSmokeColorGreen", VehicleCfgFile), ReadCfgValue("TyreSmokeColorBlue", VehicleCfgFile))
        _Vehicle.SetMod(VehicleMod.Horns, ReadCfgValue("Horn", VehicleCfgFile), True)
        If ReadCfgValue("BulletproofTyres", VehicleCfgFile) = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, _Vehicle, False)
        _Vehicle.RoofState = CInt(ReadCfgValue("VehicleRoof", VehicleCfgFile))
        'Added on v1.3.3
        If ReadCfgValue("ExtraOne", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 1, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 1, -1)
        If ReadCfgValue("ExtraTwo", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 2, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 2, -1)
        If ReadCfgValue("ExtraThree", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 3, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 3, -1)
        If ReadCfgValue("ExtraFour", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 4, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 4, -1)
        If ReadCfgValue("ExtraFive", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 5, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 5, -1)
        If ReadCfgValue("ExtraSix", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 6, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 6, -1)
        If ReadCfgValue("ExtraSeven", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 7, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 7, -1)
        If ReadCfgValue("ExtraEight", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 8, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 8, -1)
        If ReadCfgValue("ExtraNine", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 9, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 9, -1)
    End Sub

    Public Shared Sub SaveGarageVehicle(file As String)
        Try
            If Not IO.File.Exists(file & "vehicle_0.cfg") Then
                IO.File.WriteAllText(file & "vehicle_0.cfg", My.Resources.vehicle)
                UpdateGarageVehicle(file & "vehicle_0.cfg", "False")
                LoadGarageVehicle0(file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                playerPed.CurrentVehicle.Delete()
                If Not veh0 = Nothing Then
                    playerPed.Position = veh0Pos
                    playerPed.SetIntoVehicle(veh0, VehicleSeat.Driver)
                Else
                    playerPed.Position = veh0Pos
                End If
                Script.Wait(500)
                Game.FadeScreenIn(500)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
            Else
                If Not IO.File.Exists(file & "vehicle_1.cfg") Then
                    IO.File.WriteAllText(file & "vehicle_1.cfg", My.Resources.vehicle)
                    UpdateGarageVehicle(file & "vehicle_1.cfg", "False")
                    LoadGarageVehicle1(file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    playerPed.CurrentVehicle.Delete()
                    If Not veh1 = Nothing Then
                        playerPed.Position = veh1Pos
                        playerPed.SetIntoVehicle(veh1, VehicleSeat.Driver)
                    Else
                        playerPed.Position = veh1Pos
                    End If
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Else
                    If Not IO.File.Exists(file & "vehicle_2.cfg") Then
                        IO.File.WriteAllText(file & "vehicle_2.cfg", My.Resources.vehicle)
                        UpdateGarageVehicle(file & "vehicle_2.cfg", "False")
                        LoadGarageVehicle2(file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        playerPed.CurrentVehicle.Delete()
                        If Not veh2 = Nothing Then
                            playerPed.Position = veh2Pos
                            playerPed.SetIntoVehicle(veh2, VehicleSeat.Driver)
                        Else
                            playerPed.Position = veh2Pos
                        End If
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                    Else
                        If Not IO.File.Exists(file & "vehicle_3.cfg") Then
                            IO.File.WriteAllText(file & "vehicle_3.cfg", My.Resources.vehicle)
                            UpdateGarageVehicle(file & "vehicle_3.cfg", "False")
                            LoadGarageVehicle3(file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
                            Game.FadeScreenOut(500)
                            Script.Wait(&H3E8)
                            playerPed.CurrentVehicle.Delete()
                            If Not veh3 = Nothing Then
                                playerPed.Position = veh3Pos
                                playerPed.SetIntoVehicle(veh3, VehicleSeat.Driver)
                            Else
                                playerPed.Position = veh3Pos
                            End If
                            Script.Wait(500)
                            Game.FadeScreenIn(500)
                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                        Else
                            If Not IO.File.Exists(file & "vehicle_4.cfg") Then
                                IO.File.WriteAllText(file & "vehicle_4.cfg", My.Resources.vehicle)
                                UpdateGarageVehicle(file & "vehicle_4.cfg", "False")
                                LoadGarageVehicle4(file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
                                Game.FadeScreenOut(500)
                                Script.Wait(&H3E8)
                                playerPed.CurrentVehicle.Delete()
                                If Not veh4 = Nothing Then
                                    playerPed.Position = veh4Pos
                                    playerPed.SetIntoVehicle(veh4, VehicleSeat.Driver)
                                Else
                                    playerPed.Position = veh4Pos
                                End If
                                Script.Wait(500)
                                Game.FadeScreenIn(500)
                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                            Else
                                If Not IO.File.Exists(file & "vehicle_5.cfg") Then
                                    IO.File.WriteAllText(file & "vehicle_5.cfg", My.Resources.vehicle)
                                    UpdateGarageVehicle(file & "vehicle_5.cfg", "False")
                                    LoadGarageVehicle5(file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)
                                    Game.FadeScreenOut(500)
                                    Script.Wait(&H3E8)
                                    playerPed.CurrentVehicle.Delete()
                                    If Not veh5 = Nothing Then
                                        playerPed.Position = veh5Pos
                                        playerPed.SetIntoVehicle(veh5, VehicleSeat.Driver)
                                    Else
                                        playerPed.Position = veh5Pos
                                    End If
                                    Script.Wait(500)
                                    Game.FadeScreenIn(500)
                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                Else
                                    If uiLanguage = "Chinese" Then
                                        UI.ShowSubtitle("車庫~r~已滿~w~。")
                                    Else
                                        UI.ShowSubtitle("Garage ~r~Full~w~.")
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

    <StructLayout(LayoutKind.Explicit)>
    Public Structure UnionInt32
        <FieldOffset(0)>
        Public IntValue As Int32
        <FieldOffset(0)>
        Public UIntValue As UInt32
    End Structure

    Public Shared Sub UpdateGarageVehicle(file As String, Active As String)
        WriteCfgValue("VehicleName", playerPed.CurrentVehicle.FriendlyName, file)
        'Lowriders DLC
        If playerPed.CurrentVehicle.Model.GetHashCode() = -1013450936 Then
            WriteCfgValue("VehicleModel", "BUCCANEER2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -1361687965 Then
            WriteCfgValue("VehicleModel", "CHINO2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -2119578145 Then
            WriteCfgValue("VehicleModel", "FACTION", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -1790546981 Then
            WriteCfgValue("VehicleModel", "FACTION2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 525509695 Then
            WriteCfgValue("VehicleModel", "MOONBEAM", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 1896491931 Then
            WriteCfgValue("VehicleModel", "MOONBEAM2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 2006667053 Then
            WriteCfgValue("VehicleModel", "VOODOO", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -2040426790 Then
            WriteCfgValue("VehicleModel", "PRIMO2", file)
            'Halloween Surprise DLC
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 2068293287 Then
            WriteCfgValue("VehicleModel", "LURCHER", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -831834716 Then
            WriteCfgValue("VehicleModel", "BTYPE2", file)
            'Executives and other criminals DLC
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 1102544804 Then
            WriteCfgValue("VehicleModel", "VERLIERER2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -1943285540 Then
            WriteCfgValue("VehicleModel", "NIGHTSHADE", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -1660945322 Then
            WriteCfgValue("VehicleModel", "MAMBA", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -114627507 Then
            WriteCfgValue("VehicleModel", "LIMO2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -1485523546 Then
            WriteCfgValue("VehicleModel", "SCHAFTER3", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 1489967196 Then
            WriteCfgValue("VehicleModel", "SCHAFTER4", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -888242983 Then
            WriteCfgValue("VehicleModel", "SCHAFTER5", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 1922255844 Then
            WriteCfgValue("VehicleModel", "SCHAFTER6", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 906642318 Then
            WriteCfgValue("VehicleModel", "COG55", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 704435172 Then
            WriteCfgValue("VehicleModel", "COG552", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -2030171296 Then
            WriteCfgValue("VehicleModel", "COGNOSCENTI", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = -604842630 Then
            WriteCfgValue("VehicleModel", "COGNOSCENTI2", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 1878062887 Then
            WriteCfgValue("VehicleModel", "BALLER3", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 634118882 Then
            WriteCfgValue("VehicleModel", "BALLER4", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 470404958 Then
            WriteCfgValue("VehicleModel", "BALLER5", file)
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 666166960 Then
            WriteCfgValue("VehicleModel", "BALLER6", file)
            'Christmas 2015 DLC
        ElseIf playerPed.CurrentVehicle.Model.GetHashCode() = 972671128 Then
            WriteCfgValue("VehicleModel", "TAMPA", file)
        Else
            Dim VhNames As Array = GTA.Native.VehicleHash.GetNames(GetType(VehicleHash))
            Dim VhHash As Array = GTA.Native.VehicleHash.GetValues(GetType(VehicleHash))
            Dim tmpUint As UnionInt32
            tmpUint.IntValue = Game.Player.Character.CurrentVehicle.Model.Hash
            Dim UIntVal As UInt32 = tmpUint.UIntValue

            For i = 0 To UBound(VhHash)
                If VhHash(i) = UIntVal Then
                    WriteCfgValue("VehicleModel", VhNames(i), file)
                    Exit For
                End If
            Next
        End If
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
        WriteCfgValue("Spoiler", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 0), file)
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
        'Added on v1.1.3
        WriteCfgValue("Horn", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 14), file)
        WriteCfgValue("BulletproofTyres", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_TYRES_CAN_BURST, playerPed.CurrentVehicle), file)
        WriteCfgValue("Active", Active, file)
        'Added on v1.2.1
        WriteCfgValue("FrontTireVariation", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, playerPed.CurrentVehicle, 23), file)
        WriteCfgValue("BackTireVariation", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, playerPed.CurrentVehicle, 24), file)
        WriteCfgValue("TwentyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 25), file)
        WriteCfgValue("TwentySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 26), file)
        WriteCfgValue("TwentySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 27), file)
        WriteCfgValue("TwentyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 28), file)
        WriteCfgValue("TwentyNine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 29), file)
        WriteCfgValue("ThirtyZero", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 30), file)
        WriteCfgValue("ThirtyOne", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 31), file)
        WriteCfgValue("ThirtyTwo", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 32), file)
        WriteCfgValue("ThirtyThree", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 33), file)
        WriteCfgValue("ThirtyFour", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 34), file)
        WriteCfgValue("ThirtyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 35), file)
        WriteCfgValue("ThirtySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 36), file)
        WriteCfgValue("ThirtySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 37), file)
        WriteCfgValue("ThirtyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 38), file)
        WriteCfgValue("ThirtyNine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 39), file)
        WriteCfgValue("ForthyZero", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 40), file)
        WriteCfgValue("ForthyOne", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 41), file)
        WriteCfgValue("ForthyTwo", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 42), file)
        WriteCfgValue("ForthyThree", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 43), file)
        WriteCfgValue("ForthyFour", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 44), file)
        WriteCfgValue("ForthyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 45), file)
        WriteCfgValue("ForthySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 46), file)
        WriteCfgValue("ForthySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 47), file)
        WriteCfgValue("ForthyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 48), file)
        'Added on v1.3.1
        WriteCfgValue("VehicleHash", playerPed.CurrentVehicle.Model.GetHashCode().ToString, file)
        WriteCfgValue("VehicleRoof", Native.Function.Call(Of Integer)(Hash.GET_CONVERTIBLE_ROOF_STATE, playerPed.CurrentVehicle), file)
        'Added on v1.3.3
        WriteCfgValue("ExtraOne", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 1), file)
        WriteCfgValue("ExtraTwo", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 2), file)
        WriteCfgValue("ExtraThree", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 3), file)
        WriteCfgValue("ExtraFour", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 4), file)
        WriteCfgValue("ExtraFive", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 5), file)
        WriteCfgValue("ExtraSix", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 6), file)
        WriteCfgValue("ExtraSeven", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 7), file)
        WriteCfgValue("ExtraEight", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 8), file)
        WriteCfgValue("ExtraNine", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 9), file)
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

            ControlsKeyDown()

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ControlsKeyDown()
        On Error Resume Next
        If Game.IsControlJustPressed(0, GTA.Control.VehicleAccelerate) AndAlso playerPed.IsInVehicle AndAlso GarageMiddleDistance < 20.0 Then
            Dim PPCV As Integer = -1
            If playerPed.CurrentVehicle = veh0 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_0.cfg")
                PPCV = 0
            ElseIf playerPed.CurrentVehicle = veh1 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_1.cfg")
                PPCV = 1
            ElseIf playerPed.CurrentVehicle = veh2 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_2.cfg")
                PPCV = 2
            ElseIf playerPed.CurrentVehicle = veh3 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_3.cfg")
                PPCV = 3
            ElseIf playerPed.CurrentVehicle = veh4 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_4.cfg")
                PPCV = 4
            ElseIf playerPed.CurrentVehicle = veh5 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_5.cfg")
                PPCV = 5
            End If
            Game.FadeScreenOut(500)
            Script.Wait(&H3E8)

            playerPed.CurrentVehicle.Delete()
            If playerName = "Michael" Then
                If Mechanic.MPV1 = Nothing Then
                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                        Mechanic.MPV1 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                    Else
                        Mechanic.MPV1 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                    End If
                    Mechanic.MPV1.Heading = lastLocationGarageOutHeading
                    SetModKit(Mechanic.MPV1, CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Mechanic.MPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV1, True, False)
                    Mechanic.MPV1.AddBlip()
                    Mechanic.MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.MPV1.CurrentBlip.Color = BlipColor.Blue
                    Mechanic.MPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.MPV1.FriendlyName, Mechanic.MPV1.CurrentBlip)
                    playerPed.SetIntoVehicle(Mechanic.MPV1, VehicleSeat.Driver)
                Else
                    If Mechanic.MPV2 = Nothing Then
                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                            Mechanic.MPV2 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                        Else
                            Mechanic.MPV2 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                        End If
                        Mechanic.MPV2.Heading = lastLocationGarageOutHeading
                        SetModKit(Mechanic.MPV2, CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Mechanic.MPV2.MarkAsNoLongerNeeded()
                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV2, True, False)
                        Mechanic.MPV2.AddBlip()
                        Mechanic.MPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.MPV2.CurrentBlip.Color = BlipColor.Blue
                        Mechanic.MPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.MPV2.FriendlyName, Mechanic.MPV2.CurrentBlip)
                        playerPed.SetIntoVehicle(Mechanic.MPV2, VehicleSeat.Driver)
                    Else
                        If Mechanic.MPV3 = Nothing Then
                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                Mechanic.MPV3 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                            Else
                                Mechanic.MPV3 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                            End If
                            Mechanic.MPV3.Heading = lastLocationGarageOutHeading
                            SetModKit(Mechanic.MPV3, CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Mechanic.MPV3.MarkAsNoLongerNeeded()
                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV3, True, False)
                            Mechanic.MPV3.AddBlip()
                            Mechanic.MPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.MPV3.CurrentBlip.Color = BlipColor.Blue
                            Mechanic.MPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.MPV3.FriendlyName, Mechanic.MPV3.CurrentBlip)
                            playerPed.SetIntoVehicle(Mechanic.MPV3, VehicleSeat.Driver)
                        Else
                            If Mechanic.MPV4 = Nothing Then
                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                    Mechanic.MPV4 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                Else
                                    Mechanic.MPV4 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                End If
                                Mechanic.MPV4.Heading = lastLocationGarageOutHeading
                                SetModKit(Mechanic.MPV4, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Mechanic.MPV4.MarkAsNoLongerNeeded()
                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV4, True, False)
                                Mechanic.MPV4.AddBlip()
                                Mechanic.MPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.MPV4.CurrentBlip.Color = BlipColor.Blue
                                Mechanic.MPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.MPV4.FriendlyName, Mechanic.MPV4.CurrentBlip)
                                playerPed.SetIntoVehicle(Mechanic.MPV4, VehicleSeat.Driver)
                            Else
                                If Mechanic.MPV5 = Nothing Then
                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                        Mechanic.MPV5 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                    Else
                                        Mechanic.MPV5 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                    End If
                                    Mechanic.MPV5.Heading = lastLocationGarageOutHeading
                                    SetModKit(Mechanic.MPV5, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                    Mechanic.MPV5.MarkAsNoLongerNeeded()
                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV5, True, False)
                                    Mechanic.MPV5.AddBlip()
                                    Mechanic.MPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.MPV5.CurrentBlip.Color = BlipColor.Blue
                                    Mechanic.MPV5.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.MPV5.FriendlyName, Mechanic.MPV5.CurrentBlip)
                                    playerPed.SetIntoVehicle(Mechanic.MPV5, VehicleSeat.Driver)
                                Else
                                    If Mechanic.MPV6 = Nothing Then
                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                            Mechanic.MPV6 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                        Else
                                            Mechanic.MPV6 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                        End If
                                        Mechanic.MPV6.Heading = lastLocationGarageOutHeading
                                        SetModKit(Mechanic.MPV6, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                        Mechanic.MPV6.MarkAsNoLongerNeeded()
                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV6, True, False)
                                        Mechanic.MPV6.AddBlip()
                                        Mechanic.MPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        Mechanic.MPV6.CurrentBlip.Color = BlipColor.Blue
                                        Mechanic.MPV6.CurrentBlip.IsShortRange = True
                                        SetBlipName(Mechanic.MPV6.FriendlyName, Mechanic.MPV6.CurrentBlip)
                                        playerPed.SetIntoVehicle(Mechanic.MPV6, VehicleSeat.Driver)
                                    Else
                                        If Mechanic.MPV7 = Nothing Then
                                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                Mechanic.MPV7 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                            Else
                                                Mechanic.MPV7 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                            End If
                                            Mechanic.MPV7.Heading = lastLocationGarageOutHeading
                                            SetModKit(Mechanic.MPV7, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                            Mechanic.MPV7.MarkAsNoLongerNeeded()
                                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV7, True, False)
                                            Mechanic.MPV7.AddBlip()
                                            Mechanic.MPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            Mechanic.MPV7.CurrentBlip.Color = BlipColor.Blue
                                            Mechanic.MPV7.CurrentBlip.IsShortRange = True
                                            SetBlipName(Mechanic.MPV7.FriendlyName, Mechanic.MPV7.CurrentBlip)
                                            playerPed.SetIntoVehicle(Mechanic.MPV7, VehicleSeat.Driver)
                                        Else
                                            If Mechanic.MPV8 = Nothing Then
                                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                    Mechanic.MPV8 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                Else
                                                    Mechanic.MPV8 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                End If
                                                Mechanic.MPV8.Heading = lastLocationGarageOutHeading
                                                SetModKit(Mechanic.MPV8, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                Mechanic.MPV8.MarkAsNoLongerNeeded()
                                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV8, True, False)
                                                Mechanic.MPV8.AddBlip()
                                                Mechanic.MPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                Mechanic.MPV8.CurrentBlip.Color = BlipColor.Blue
                                                Mechanic.MPV8.CurrentBlip.IsShortRange = True
                                                SetBlipName(Mechanic.MPV8.FriendlyName, Mechanic.MPV8.CurrentBlip)
                                                playerPed.SetIntoVehicle(Mechanic.MPV8, VehicleSeat.Driver)
                                            Else
                                                If Mechanic.MPV9 = Nothing Then
                                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                        Mechanic.MPV9 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                    Else
                                                        Mechanic.MPV9 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                    End If
                                                    Mechanic.MPV9.Heading = lastLocationGarageOutHeading
                                                    SetModKit(Mechanic.MPV9, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                    Mechanic.MPV9.MarkAsNoLongerNeeded()
                                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV9, True, False)
                                                    Mechanic.MPV9.AddBlip()
                                                    Mechanic.MPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    Mechanic.MPV9.CurrentBlip.Color = BlipColor.Blue
                                                    Mechanic.MPV9.CurrentBlip.IsShortRange = True
                                                    SetBlipName(Mechanic.MPV9.FriendlyName, Mechanic.MPV9.CurrentBlip)
                                                    playerPed.SetIntoVehicle(Mechanic.MPV9, VehicleSeat.Driver)
                                                Else
                                                    If Mechanic.MPV0 = Nothing Then
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.MPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.MPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.MPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.MPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV0, True, False)
                                                        Mechanic.MPV0.AddBlip()
                                                        Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.MPV0.CurrentBlip.Color = BlipColor.Blue
                                                        Mechanic.MPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.MPV0.FriendlyName, Mechanic.MPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.MPV0, VehicleSeat.Driver)
                                                    Else
                                                        Mechanic.MPV0.Delete()
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.MPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.MPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.MPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.MPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.MPV0, True, False)
                                                        Mechanic.MPV0.AddBlip()
                                                        Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.MPV0.CurrentBlip.Color = BlipColor.Blue
                                                        Mechanic.MPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.MPV0.FriendlyName, Mechanic.MPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.MPV0, VehicleSeat.Driver)
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
            ElseIf playerName = "Franklin" Then
                If Mechanic.FPV1 = Nothing Then
                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                        Mechanic.FPV1 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                    Else
                        Mechanic.FPV1 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                    End If
                    Mechanic.FPV1.Heading = lastLocationGarageOutHeading
                    SetModKit(Mechanic.FPV1, CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Mechanic.FPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV1, True, False)
                    Mechanic.FPV1.AddBlip()
                    Mechanic.FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.FPV1.CurrentBlip.Color = BlipColor.Green
                    Mechanic.FPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.FPV1.FriendlyName, Mechanic.FPV1.CurrentBlip)
                    playerPed.SetIntoVehicle(Mechanic.FPV1, VehicleSeat.Driver)
                Else
                    If Mechanic.FPV2 = Nothing Then
                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                            Mechanic.FPV2 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                        Else
                            Mechanic.FPV2 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                        End If
                        Mechanic.FPV2.Heading = lastLocationGarageOutHeading
                        SetModKit(Mechanic.FPV2, CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Mechanic.FPV2.MarkAsNoLongerNeeded()
                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV2, True, False)
                        Mechanic.FPV2.AddBlip()
                        Mechanic.FPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.FPV2.CurrentBlip.Color = BlipColor.Green
                        Mechanic.FPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.FPV2.FriendlyName, Mechanic.FPV2.CurrentBlip)
                        playerPed.SetIntoVehicle(Mechanic.FPV2, VehicleSeat.Driver)
                    Else
                        If Mechanic.FPV3 = Nothing Then
                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                Mechanic.FPV3 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                            Else
                                Mechanic.FPV3 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                            End If
                            Mechanic.FPV3.Heading = lastLocationGarageOutHeading
                            SetModKit(Mechanic.FPV3, CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Mechanic.FPV3.MarkAsNoLongerNeeded()
                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV3, True, False)
                            Mechanic.FPV3.AddBlip()
                            Mechanic.FPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.FPV3.CurrentBlip.Color = BlipColor.Green
                            Mechanic.FPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.FPV3.FriendlyName, Mechanic.FPV3.CurrentBlip)
                            playerPed.SetIntoVehicle(Mechanic.FPV3, VehicleSeat.Driver)
                        Else
                            If Mechanic.FPV4 = Nothing Then
                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                    Mechanic.FPV4 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                Else
                                    Mechanic.FPV4 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                End If
                                Mechanic.FPV4.Heading = lastLocationGarageOutHeading
                                SetModKit(Mechanic.FPV4, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Mechanic.FPV4.MarkAsNoLongerNeeded()
                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV4, True, False)
                                Mechanic.FPV4.AddBlip()
                                Mechanic.FPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.FPV4.CurrentBlip.Color = BlipColor.Green
                                Mechanic.FPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.FPV4.FriendlyName, Mechanic.FPV4.CurrentBlip)
                                playerPed.SetIntoVehicle(Mechanic.FPV4, VehicleSeat.Driver)
                            Else
                                If Mechanic.FPV5 = Nothing Then
                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                        Mechanic.FPV5 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                    Else
                                        Mechanic.FPV5 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                    End If
                                    Mechanic.FPV5.Heading = lastLocationGarageOutHeading
                                    SetModKit(Mechanic.FPV5, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                    Mechanic.FPV5.MarkAsNoLongerNeeded()
                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV5, True, False)
                                    Mechanic.FPV5.AddBlip()
                                    Mechanic.FPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.FPV5.CurrentBlip.Color = BlipColor.Green
                                    Mechanic.FPV5.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.FPV5.FriendlyName, Mechanic.FPV5.CurrentBlip)
                                    playerPed.SetIntoVehicle(Mechanic.FPV5, VehicleSeat.Driver)
                                Else
                                    If Mechanic.FPV6 = Nothing Then
                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                            Mechanic.FPV6 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                        Else
                                            Mechanic.FPV6 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                        End If
                                        Mechanic.FPV6.Heading = lastLocationGarageOutHeading
                                        SetModKit(Mechanic.FPV6, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                        Mechanic.FPV6.MarkAsNoLongerNeeded()
                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV6, True, False)
                                        Mechanic.FPV6.AddBlip()
                                        Mechanic.FPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        Mechanic.FPV6.CurrentBlip.Color = BlipColor.Green
                                        Mechanic.FPV6.CurrentBlip.IsShortRange = True
                                        SetBlipName(Mechanic.FPV6.FriendlyName, Mechanic.FPV6.CurrentBlip)
                                        playerPed.SetIntoVehicle(Mechanic.FPV6, VehicleSeat.Driver)
                                    Else
                                        If Mechanic.FPV7 = Nothing Then
                                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                Mechanic.FPV7 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                            Else
                                                Mechanic.FPV7 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                            End If
                                            Mechanic.FPV7.Heading = lastLocationGarageOutHeading
                                            SetModKit(Mechanic.FPV7, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                            Mechanic.FPV7.MarkAsNoLongerNeeded()
                                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV7, True, False)
                                            Mechanic.FPV7.AddBlip()
                                            Mechanic.FPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            Mechanic.FPV7.CurrentBlip.Color = BlipColor.Green
                                            Mechanic.FPV7.CurrentBlip.IsShortRange = True
                                            SetBlipName(Mechanic.FPV7.FriendlyName, Mechanic.FPV7.CurrentBlip)
                                            playerPed.SetIntoVehicle(Mechanic.FPV7, VehicleSeat.Driver)
                                        Else
                                            If Mechanic.FPV8 = Nothing Then
                                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                    Mechanic.FPV8 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                Else
                                                    Mechanic.FPV8 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                End If
                                                Mechanic.FPV8.Heading = lastLocationGarageOutHeading
                                                SetModKit(Mechanic.FPV8, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                Mechanic.FPV8.MarkAsNoLongerNeeded()
                                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV8, True, False)
                                                Mechanic.FPV8.AddBlip()
                                                Mechanic.FPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                Mechanic.FPV8.CurrentBlip.Color = BlipColor.Green
                                                Mechanic.FPV8.CurrentBlip.IsShortRange = True
                                                SetBlipName(Mechanic.FPV8.FriendlyName, Mechanic.FPV8.CurrentBlip)
                                                playerPed.SetIntoVehicle(Mechanic.FPV8, VehicleSeat.Driver)
                                            Else
                                                If Mechanic.FPV9 = Nothing Then
                                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                        Mechanic.FPV9 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                    Else
                                                        Mechanic.FPV9 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                    End If
                                                    Mechanic.FPV9.Heading = lastLocationGarageOutHeading
                                                    SetModKit(Mechanic.FPV9, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                    Mechanic.FPV9.MarkAsNoLongerNeeded()
                                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV9, True, False)
                                                    Mechanic.FPV9.AddBlip()
                                                    Mechanic.FPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    Mechanic.FPV9.CurrentBlip.Color = BlipColor.Green
                                                    Mechanic.FPV9.CurrentBlip.IsShortRange = True
                                                    SetBlipName(Mechanic.FPV9.FriendlyName, Mechanic.FPV9.CurrentBlip)
                                                    playerPed.SetIntoVehicle(Mechanic.FPV9, VehicleSeat.Driver)
                                                Else
                                                    If Mechanic.FPV0 = Nothing Then
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.FPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.FPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.FPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.FPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV0, True, False)
                                                        Mechanic.FPV0.AddBlip()
                                                        Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.FPV0.CurrentBlip.Color = BlipColor.Green
                                                        Mechanic.FPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.FPV0.FriendlyName, Mechanic.FPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.FPV0, VehicleSeat.Driver)
                                                    Else
                                                        Mechanic.FPV0.Delete()
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.FPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.FPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.FPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.FPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.FPV0, True, False)
                                                        Mechanic.FPV0.AddBlip()
                                                        Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.FPV0.CurrentBlip.Color = BlipColor.Green
                                                        Mechanic.FPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.FPV0.FriendlyName, Mechanic.FPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.FPV0, VehicleSeat.Driver)
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
            ElseIf playerName = "Trevor" Then
                If Mechanic.TPV1 = Nothing Then
                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                        Mechanic.TPV1 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                    Else
                        Mechanic.TPV1 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                    End If
                    Mechanic.TPV1.Heading = lastLocationGarageOutHeading
                    SetModKit(Mechanic.TPV1, CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Mechanic.TPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV1, True, False)
                    Mechanic.TPV1.AddBlip()
                    Mechanic.TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.TPV1.CurrentBlip.Color = 17
                    Mechanic.TPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.TPV1.FriendlyName, Mechanic.TPV1.CurrentBlip)
                    playerPed.SetIntoVehicle(Mechanic.TPV1, VehicleSeat.Driver)
                Else
                    If Mechanic.TPV2 = Nothing Then
                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                            Mechanic.TPV2 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                        Else
                            Mechanic.TPV2 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                        End If
                        Mechanic.TPV2.Heading = lastLocationGarageOutHeading
                        SetModKit(Mechanic.TPV2, CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Mechanic.TPV2.MarkAsNoLongerNeeded()
                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV2, True, False)
                        Mechanic.TPV2.AddBlip()
                        Mechanic.TPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.TPV2.CurrentBlip.Color = 17
                        Mechanic.TPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.TPV2.FriendlyName, Mechanic.TPV2.CurrentBlip)
                        playerPed.SetIntoVehicle(Mechanic.TPV2, VehicleSeat.Driver)
                    Else
                        If Mechanic.TPV3 = Nothing Then
                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                Mechanic.TPV3 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                            Else
                                Mechanic.TPV3 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                            End If
                            Mechanic.TPV3.Heading = lastLocationGarageOutHeading
                            SetModKit(Mechanic.TPV3, CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Mechanic.TPV3.MarkAsNoLongerNeeded()
                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV3, True, False)
                            Mechanic.TPV3.AddBlip()
                            Mechanic.TPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.TPV3.CurrentBlip.Color = 17
                            Mechanic.TPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.TPV3.FriendlyName, Mechanic.TPV3.CurrentBlip)
                            playerPed.SetIntoVehicle(Mechanic.TPV3, VehicleSeat.Driver)
                        Else
                            If Mechanic.TPV4 = Nothing Then
                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                    Mechanic.TPV4 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                Else
                                    Mechanic.TPV4 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                End If
                                Mechanic.TPV4.Heading = lastLocationGarageOutHeading
                                SetModKit(Mechanic.TPV4, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Mechanic.TPV4.MarkAsNoLongerNeeded()
                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV4, True, False)
                                Mechanic.TPV4.AddBlip()
                                Mechanic.TPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.TPV4.CurrentBlip.Color = 17
                                Mechanic.TPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.TPV4.FriendlyName, Mechanic.TPV4.CurrentBlip)
                                playerPed.SetIntoVehicle(Mechanic.TPV4, VehicleSeat.Driver)
                            Else
                                If Mechanic.TPV5 = Nothing Then
                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                        Mechanic.TPV5 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                    Else
                                        Mechanic.TPV5 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                    End If
                                    Mechanic.TPV5.Heading = lastLocationGarageOutHeading
                                    SetModKit(Mechanic.TPV5, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                    Mechanic.TPV5.MarkAsNoLongerNeeded()
                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV5, True, False)
                                    Mechanic.TPV5.AddBlip()
                                    Mechanic.TPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.TPV5.CurrentBlip.Color = 17
                                    Mechanic.TPV5.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.TPV5.FriendlyName, Mechanic.TPV5.CurrentBlip)
                                    playerPed.SetIntoVehicle(Mechanic.TPV5, VehicleSeat.Driver)
                                Else
                                    If Mechanic.TPV6 = Nothing Then
                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                            Mechanic.TPV6 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                        Else
                                            Mechanic.TPV6 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                        End If
                                        Mechanic.TPV6.Heading = lastLocationGarageOutHeading
                                        SetModKit(Mechanic.TPV6, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                        Mechanic.TPV6.MarkAsNoLongerNeeded()
                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV6, True, False)
                                        Mechanic.TPV6.AddBlip()
                                        Mechanic.TPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        Mechanic.TPV6.CurrentBlip.Color = 17
                                        Mechanic.TPV6.CurrentBlip.IsShortRange = True
                                        SetBlipName(Mechanic.TPV6.FriendlyName, Mechanic.TPV6.CurrentBlip)
                                        playerPed.SetIntoVehicle(Mechanic.TPV6, VehicleSeat.Driver)
                                    Else
                                        If Mechanic.TPV7 = Nothing Then
                                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                Mechanic.TPV7 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                            Else
                                                Mechanic.TPV7 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                            End If
                                            Mechanic.TPV7.Heading = lastLocationGarageOutHeading
                                            SetModKit(Mechanic.TPV7, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                            Mechanic.TPV7.MarkAsNoLongerNeeded()
                                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV7, True, False)
                                            Mechanic.TPV7.AddBlip()
                                            Mechanic.TPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            Mechanic.TPV7.CurrentBlip.Color = 17
                                            Mechanic.TPV7.CurrentBlip.IsShortRange = True
                                            SetBlipName(Mechanic.TPV7.FriendlyName, Mechanic.TPV7.CurrentBlip)
                                            playerPed.SetIntoVehicle(Mechanic.TPV7, VehicleSeat.Driver)
                                        Else
                                            If Mechanic.TPV8 = Nothing Then
                                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                    Mechanic.TPV8 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                Else
                                                    Mechanic.TPV8 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                End If
                                                Mechanic.TPV8.Heading = lastLocationGarageOutHeading
                                                SetModKit(Mechanic.TPV8, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                Mechanic.TPV8.MarkAsNoLongerNeeded()
                                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV8, True, False)
                                                Mechanic.TPV8.AddBlip()
                                                Mechanic.TPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                Mechanic.TPV8.CurrentBlip.Color = 17
                                                Mechanic.TPV8.CurrentBlip.IsShortRange = True
                                                SetBlipName(Mechanic.TPV8.FriendlyName, Mechanic.TPV8.CurrentBlip)
                                                playerPed.SetIntoVehicle(Mechanic.TPV8, VehicleSeat.Driver)
                                            Else
                                                If Mechanic.TPV9 = Nothing Then
                                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                        Mechanic.TPV9 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                    Else
                                                        Mechanic.TPV9 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                    End If
                                                    Mechanic.TPV9.Heading = lastLocationGarageOutHeading
                                                    SetModKit(Mechanic.TPV9, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                    Mechanic.TPV9.MarkAsNoLongerNeeded()
                                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV9, True, False)
                                                    Mechanic.TPV9.AddBlip()
                                                    Mechanic.TPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    Mechanic.TPV9.CurrentBlip.Color = 17
                                                    Mechanic.TPV9.CurrentBlip.IsShortRange = True
                                                    SetBlipName(Mechanic.TPV9.FriendlyName, Mechanic.TPV9.CurrentBlip)
                                                    playerPed.SetIntoVehicle(Mechanic.TPV9, VehicleSeat.Driver)
                                                Else
                                                    If Mechanic.TPV0 = Nothing Then
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.TPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.TPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.TPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.TPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV0, True, False)
                                                        Mechanic.TPV0.AddBlip()
                                                        Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.TPV0.CurrentBlip.Color = 17
                                                        Mechanic.TPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.TPV0.FriendlyName, Mechanic.TPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.TPV0, VehicleSeat.Driver)
                                                    Else
                                                        Mechanic.TPV0.Delete()
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.TPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.TPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.TPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.TPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.TPV0, True, False)
                                                        Mechanic.TPV0.AddBlip()
                                                        Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.TPV0.CurrentBlip.Color = 17
                                                        Mechanic.TPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.TPV0.FriendlyName, Mechanic.TPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.TPV0, VehicleSeat.Driver)
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
            ElseIf playerName = "Player3" Then
                If Mechanic.PPV1 = Nothing Then
                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                        Mechanic.PPV1 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                    Else
                        Mechanic.PPV1 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                    End If
                    Mechanic.PPV1.Heading = lastLocationGarageOutHeading
                    SetModKit(Mechanic.PPV1, CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Mechanic.PPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV1, True, False)
                    Mechanic.PPV1.AddBlip()
                    Mechanic.PPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.PPV1.CurrentBlip.Color = BlipColor.Yellow
                    Mechanic.PPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.PPV1.FriendlyName, Mechanic.PPV1.CurrentBlip)
                    playerPed.SetIntoVehicle(Mechanic.PPV1, VehicleSeat.Driver)
                Else
                    If Mechanic.PPV2 = Nothing Then
                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                            Mechanic.PPV2 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                        Else
                            Mechanic.PPV2 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                        End If
                        Mechanic.PPV2.Heading = lastLocationGarageOutHeading
                        SetModKit(Mechanic.PPV2, CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Mechanic.PPV2.MarkAsNoLongerNeeded()
                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV2, True, False)
                        Mechanic.PPV2.AddBlip()
                        Mechanic.PPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.PPV2.CurrentBlip.Color = BlipColor.Yellow
                        Mechanic.PPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.PPV2.FriendlyName, Mechanic.PPV2.CurrentBlip)
                        playerPed.SetIntoVehicle(Mechanic.PPV2, VehicleSeat.Driver)
                    Else
                        If Mechanic.PPV3 = Nothing Then
                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                Mechanic.PPV3 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                            Else
                                Mechanic.PPV3 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                            End If
                            Mechanic.PPV3.Heading = lastLocationGarageOutHeading
                            SetModKit(Mechanic.PPV3, CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Mechanic.PPV3.MarkAsNoLongerNeeded()
                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV3, True, False)
                            Mechanic.PPV3.AddBlip()
                            Mechanic.PPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.PPV3.CurrentBlip.Color = BlipColor.Yellow
                            Mechanic.PPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.PPV3.FriendlyName, Mechanic.PPV3.CurrentBlip)
                            playerPed.SetIntoVehicle(Mechanic.PPV3, VehicleSeat.Driver)
                        Else
                            If Mechanic.PPV4 = Nothing Then
                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                    Mechanic.PPV4 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                Else
                                    Mechanic.PPV4 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                End If
                                Mechanic.PPV4.Heading = lastLocationGarageOutHeading
                                SetModKit(Mechanic.PPV4, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Mechanic.PPV4.MarkAsNoLongerNeeded()
                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV4, True, False)
                                Mechanic.PPV4.AddBlip()
                                Mechanic.PPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.PPV4.CurrentBlip.Color = BlipColor.Yellow
                                Mechanic.PPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.PPV4.FriendlyName, Mechanic.PPV4.CurrentBlip)
                                playerPed.SetIntoVehicle(Mechanic.PPV4, VehicleSeat.Driver)
                            Else
                                If Mechanic.PPV5 = Nothing Then
                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                        Mechanic.PPV5 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                    Else
                                        Mechanic.PPV5 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                    End If
                                    Mechanic.PPV5.Heading = lastLocationGarageOutHeading
                                    SetModKit(Mechanic.PPV5, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                    Mechanic.PPV5.MarkAsNoLongerNeeded()
                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV5, True, False)
                                    Mechanic.PPV5.AddBlip()
                                    Mechanic.PPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.PPV5.CurrentBlip.Color = BlipColor.Yellow
                                    Mechanic.PPV5.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.PPV5.FriendlyName, Mechanic.PPV5.CurrentBlip)
                                    playerPed.SetIntoVehicle(Mechanic.PPV5, VehicleSeat.Driver)
                                Else
                                    If Mechanic.PPV6 = Nothing Then
                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                            Mechanic.PPV6 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                        Else
                                            Mechanic.PPV6 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                        End If
                                        Mechanic.PPV6.Heading = lastLocationGarageOutHeading
                                        SetModKit(Mechanic.PPV6, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                        Mechanic.PPV6.MarkAsNoLongerNeeded()
                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV6, True, False)
                                        Mechanic.PPV6.AddBlip()
                                        Mechanic.PPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        Mechanic.PPV6.CurrentBlip.Color = BlipColor.Yellow
                                        Mechanic.PPV6.CurrentBlip.IsShortRange = True
                                        SetBlipName(Mechanic.PPV6.FriendlyName, Mechanic.PPV6.CurrentBlip)
                                        playerPed.SetIntoVehicle(Mechanic.PPV6, VehicleSeat.Driver)
                                    Else
                                        If Mechanic.PPV7 = Nothing Then
                                            If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                Mechanic.PPV7 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                            Else
                                                Mechanic.PPV7 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                            End If
                                            Mechanic.PPV7.Heading = lastLocationGarageOutHeading
                                            SetModKit(Mechanic.PPV7, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                            Mechanic.PPV7.MarkAsNoLongerNeeded()
                                            Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV7, True, False)
                                            Mechanic.PPV7.AddBlip()
                                            Mechanic.PPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            Mechanic.PPV7.CurrentBlip.Color = BlipColor.Yellow
                                            Mechanic.PPV7.CurrentBlip.IsShortRange = True
                                            SetBlipName(Mechanic.PPV7.FriendlyName, Mechanic.PPV7.CurrentBlip)
                                            playerPed.SetIntoVehicle(Mechanic.PPV7, VehicleSeat.Driver)
                                        Else
                                            If Mechanic.PPV8 = Nothing Then
                                                If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                    Mechanic.PPV8 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                Else
                                                    Mechanic.PPV8 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                End If
                                                Mechanic.PPV8.Heading = lastLocationGarageOutHeading
                                                SetModKit(Mechanic.PPV8, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                Mechanic.PPV8.MarkAsNoLongerNeeded()
                                                Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV8, True, False)
                                                Mechanic.PPV8.AddBlip()
                                                Mechanic.PPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                Mechanic.PPV8.CurrentBlip.Color = BlipColor.Yellow
                                                Mechanic.PPV8.CurrentBlip.IsShortRange = True
                                                SetBlipName(Mechanic.PPV8.FriendlyName, Mechanic.PPV8.CurrentBlip)
                                                playerPed.SetIntoVehicle(Mechanic.PPV8, VehicleSeat.Driver)
                                            Else
                                                If Mechanic.PPV9 = Nothing Then
                                                    If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                        Mechanic.PPV9 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                    Else
                                                        Mechanic.PPV9 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                    End If
                                                    Mechanic.PPV9.Heading = lastLocationGarageOutHeading
                                                    SetModKit(Mechanic.PPV9, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                    Mechanic.PPV9.MarkAsNoLongerNeeded()
                                                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV9, True, False)
                                                    Mechanic.PPV9.AddBlip()
                                                    Mechanic.PPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    Mechanic.PPV9.CurrentBlip.Color = BlipColor.Yellow
                                                    Mechanic.PPV9.CurrentBlip.IsShortRange = True
                                                    SetBlipName(Mechanic.PPV9.FriendlyName, Mechanic.PPV9.CurrentBlip)
                                                    playerPed.SetIntoVehicle(Mechanic.PPV9, VehicleSeat.Driver)
                                                Else
                                                    If Mechanic.PPV0 = Nothing Then
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.PPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.PPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.PPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.PPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV0, True, False)
                                                        Mechanic.PPV0.AddBlip()
                                                        Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
                                                        Mechanic.PPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.PPV0.FriendlyName, Mechanic.PPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.PPV0, VehicleSeat.Driver)
                                                    Else
                                                        Mechanic.PPV0.Delete()
                                                        If ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg") = "" Then
                                                            Mechanic.PPV0 = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector.X, lastLocationGarageOutVector.Y, lastLocationGarageOutVector.Z, lastLocationGarageOutHeading, False, False)
                                                        Else
                                                            Mechanic.PPV0 = World.CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector)
                                                        End If
                                                        Mechanic.PPV0.Heading = lastLocationGarageOutHeading
                                                        SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg")
                                                        Mechanic.PPV0.MarkAsNoLongerNeeded()
                                                        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, Mechanic.PPV0, True, False)
                                                        Mechanic.PPV0.AddBlip()
                                                        Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
                                                        Mechanic.PPV0.CurrentBlip.IsShortRange = True
                                                        SetBlipName(Mechanic.PPV0.FriendlyName, Mechanic.PPV0.CurrentBlip)
                                                        playerPed.SetIntoVehicle(Mechanic.PPV0, VehicleSeat.Driver)
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

            playerPed.CurrentVehicle.Repair()
            playerPed.CurrentVehicle.Position = lastLocationGarageOutVector
            playerPed.CurrentVehicle.Heading = lastLocationGarageOutHeading
            isInGarage = False
            Script.Wait(500)
            Game.FadeScreenIn(500)
            UnLoadMPDLCMap()
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
            UnLoadMPDLCMap()
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso GarageMarkerDistance < 3.0 Then
            Mechanic.CreateGarageMenu6CarGarage(CurrentPath)
            Mechanic.CreateGarageMenu2("Six")
            Mechanic.GarageMenu.Visible = True
            World.RenderingCamera = World.CreateCamera(New Vector3(190.1158, -993.1951, -97.41743), New Vector3(-17.44125, 0, -130.9189), 50)
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
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
