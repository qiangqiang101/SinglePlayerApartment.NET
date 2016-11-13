Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.Resources
Imports SinglePlayerApartment.INMNative

Public Class SixCarGarage
    Inherits Script

    Public Shared InteriorID As Integer
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
    Public Shared MenuActivator As Vector3 = New Vector3(204.1768, -995.3179, -99.9999)
    Public Shared ElevatorDistance As Single
    Public Shared GarageDoorLDistance As Single
    Public Shared GarageDoorRDistance As Single
    Public Shared GarageMarkerDistance As Single
    Public Shared veh0Pos As Vector3 = New Vector3(197.5, -1004.425, -99.99999)
    Public Shared veh1Pos As Vector3 = New Vector3(201.06, -1004.425, -99.99999)
    Public Shared veh2Pos As Vector3 = New Vector3(204.62, -1004.425, -99.99999)
    Public Shared veh3Pos As Vector3 = New Vector3(192.9262, -996.3292, -99.99999)
    Public Shared veh4Pos As Vector3 = New Vector3(197.5, -996.3292, -99.99999)
    Public Shared veh5Pos As Vector3 = New Vector3(203.9257, -999.1467, -99.99999)
    Public Shared vehRot02 As Vector3 = New Vector3(0.0001003991, 4.043804, -4.035995)
    Public Shared vehRot35 As Vector3 = New Vector3(9.383157, -5.855135, -146.2832)

    Public Sub New()
        Try
            'New Language
            Garage = ReadCfgValue("Garage", langFile)
            GrgFull = ReadCfgValue("GrgFull", langFile)
            EnterElevator = ReadCfgValue("EnterElevator", langFile)
            ExitGarage = ReadCfgValue("ExitGarage", langFile)
            ManageGarage = ReadCfgValue("ManageGarage", langFile)
            'End Language

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
            InteriorID = INMNative.Apartment.GetInteriorID(New Vector3(193.9493, -1004.425, -99.99999))
            InteriorIDList.Add(InteriorID)

            AddHandler Tick, AddressOf OnTick
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

#Region "LoadGarageVehicles"
    Public Shared Sub LoadGarageVehicle0(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh0 = Nothing Then
                veh0 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh0.Delete()
                veh0 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh0, file, False)
            veh0.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh0.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle1(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh1 = Nothing Then
                veh1 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh1.Delete()
                veh1 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh1, file, False)
            veh1.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh1.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle2(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh2 = Nothing Then
                veh2 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh2.Delete()
                veh2 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh2, file, False)
            veh2.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh2.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle3(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh3 = Nothing Then
                veh3 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh3.Delete()
                veh3 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh3, file, False)
            veh3.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh3.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle4(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh4 = Nothing Then
                veh4 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh4.Delete()
                veh4 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh4, file, False)
            veh4.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh4.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle5(file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh5 = Nothing Then
                veh5 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh5.Delete()
                veh5 = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh5, file, False)
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

            TenCarGarage.IfReturnedVehicle()
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub RefreshGarageVehicles(file As String)
        Try
            If IO.File.Exists(file & "vehicle_0.cfg") Then If ReadCfgValue("Active", file & "vehicle_0.cfg") = "False" AndAlso Not veh0.Exists Then LoadGarageVehicle0(file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_1.cfg") Then If ReadCfgValue("Active", file & "vehicle_1.cfg") = "False" AndAlso Not veh1.Exists Then LoadGarageVehicle1(file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_2.cfg") Then If ReadCfgValue("Active", file & "vehicle_2.cfg") = "False" AndAlso Not veh2.Exists Then LoadGarageVehicle2(file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_3.cfg") Then If ReadCfgValue("Active", file & "vehicle_3.cfg") = "False" AndAlso Not veh3.Exists Then LoadGarageVehicle3(file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
            If IO.File.Exists(file & "vehicle_4.cfg") Then If ReadCfgValue("Active", file & "vehicle_4.cfg") = "False" AndAlso Not veh4.Exists Then LoadGarageVehicle4(file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
            If IO.File.Exists(file & "vehicle_5.cfg") Then If ReadCfgValue("Active", file & "vehicle_5.cfg") = "False" AndAlso Not veh5.Exists Then LoadGarageVehicle5(file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)
            veh0.MarkAsNoLongerNeeded()
            veh1.MarkAsNoLongerNeeded()
            veh2.MarkAsNoLongerNeeded()
            veh3.MarkAsNoLongerNeeded()
            veh4.MarkAsNoLongerNeeded()
            veh5.MarkAsNoLongerNeeded()
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String, EngineRunning As Boolean)
        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = ReadCfgValue("PrimaryColor", VehicleCfgFile)
        _Vehicle.SecondaryColor = ReadCfgValue("SecondaryColor", VehicleCfgFile)
        _Vehicle.PearlescentColor = ReadCfgValue("PearlescentColor", VehicleCfgFile)
        If ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomPrimaryColor = Drawing.Color.FromArgb(ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile))
        If ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomSecondaryColor = Drawing.Color.FromArgb(ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile))
        _Vehicle.RimColor = ReadCfgValue("RimColor", VehicleCfgFile)
        If ReadCfgValue("HasNeonLightBack", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Back, True)
        If ReadCfgValue("HasNeonLightFront", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Front, True)
        If ReadCfgValue("HasNeonLightLeft", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Left, True)
        If ReadCfgValue("HasNeonLightRight", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Right, True)
        _Vehicle.NeonLightsColor = Drawing.Color.FromArgb(ReadCfgValue("NeonColorRed", VehicleCfgFile), ReadCfgValue("NeonColorGreen", VehicleCfgFile), ReadCfgValue("NeonColorBlue", VehicleCfgFile))
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
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), False)
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
        _Vehicle.TireSmokeColor = Drawing.Color.FromArgb(ReadCfgValue("TyreSmokeColorRed", VehicleCfgFile), ReadCfgValue("TyreSmokeColorGreen", VehicleCfgFile), ReadCfgValue("TyreSmokeColorBlue", VehicleCfgFile))
        _Vehicle.SetMod(VehicleMod.Horns, ReadCfgValue("Horn", VehicleCfgFile), True)
        If ReadCfgValue("BulletproofTyres", VehicleCfgFile) = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, _Vehicle, False)
        'Added on v1.3.4
        'Fixed on v1.3.4.2
        If My.Settings.HasLowriderUpdate = True Then Native.Function.Call(&H6089CDF6A57F326C, _Vehicle.Handle, CInt(ReadCfgValue("DashboardColor", VehicleCfgFile)))
        If My.Settings.HasLowriderUpdate = True Then Native.Function.Call(&HF40DD601A65F7F19UL, _Vehicle.Handle, CInt(ReadCfgValue("TrimColor", VehicleCfgFile)))
        'End of Added on v1.3.4
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
        If EngineRunning = True Then _Vehicle.EngineRunning = True
        'Make sure it is set to correct Engine
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), False)
    End Sub

    Public Shared Sub SaveGarageVehicle(file As String)
        Try
            If Not IO.File.Exists(file & "vehicle_0.cfg") Then
                CreateFile(file & "vehicle_0.cfg")
                UpdateGarageVehicle(file & "vehicle_0.cfg", "False")
                LoadGarageVehicle0(file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
                TenCarGarage.IfTransferVehicle()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                playerPed.CurrentVehicle.Delete()
                If Not veh0 = Nothing Then
                    playerPed.Position = veh0Pos
                    SetIntoVehicle(playerPed, veh0, VehicleSeat.Driver)
                Else
                    playerPed.Position = veh0Pos
                End If
                Wait(500)
                Game.FadeScreenIn(500)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
            Else
                If Not IO.File.Exists(file & "vehicle_1.cfg") Then
                    CreateFile(file & "vehicle_1.cfg")
                    UpdateGarageVehicle(file & "vehicle_1.cfg", "False")
                    LoadGarageVehicle1(file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
                    TenCarGarage.IfTransferVehicle()
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    playerPed.CurrentVehicle.Delete()
                    If Not veh1 = Nothing Then
                        playerPed.Position = veh1Pos
                        SetIntoVehicle(playerPed, veh1, VehicleSeat.Driver)
                    Else
                        playerPed.Position = veh1Pos
                    End If
                    Wait(500)
                    Game.FadeScreenIn(500)
                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Else
                    If Not IO.File.Exists(file & "vehicle_2.cfg") Then
                        CreateFile(file & "vehicle_2.cfg")
                        UpdateGarageVehicle(file & "vehicle_2.cfg", "False")
                        LoadGarageVehicle2(file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
                        TenCarGarage.IfTransferVehicle()
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        playerPed.CurrentVehicle.Delete()
                        If Not veh2 = Nothing Then
                            playerPed.Position = veh2Pos
                            SetIntoVehicle(playerPed, veh2, VehicleSeat.Driver)
                        Else
                            playerPed.Position = veh2Pos
                        End If
                        Wait(500)
                        Game.FadeScreenIn(500)
                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                    Else
                        If Not IO.File.Exists(file & "vehicle_3.cfg") Then
                            CreateFile(file & "vehicle_3.cfg")
                            UpdateGarageVehicle(file & "vehicle_3.cfg", "False")
                            LoadGarageVehicle3(file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
                            TenCarGarage.IfTransferVehicle()
                            Game.FadeScreenOut(500)
                            Wait(&H3E8)
                            playerPed.CurrentVehicle.Delete()
                            If Not veh3 = Nothing Then
                                playerPed.Position = veh3Pos
                                SetIntoVehicle(playerPed, veh3, VehicleSeat.Driver)
                            Else
                                playerPed.Position = veh3Pos
                            End If
                            Wait(500)
                            Game.FadeScreenIn(500)
                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                        Else
                            If Not IO.File.Exists(file & "vehicle_4.cfg") Then
                                CreateFile(file & "vehicle_4.cfg")
                                UpdateGarageVehicle(file & "vehicle_4.cfg", "False")
                                LoadGarageVehicle4(file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
                                TenCarGarage.IfTransferVehicle()
                                Game.FadeScreenOut(500)
                                Wait(&H3E8)
                                playerPed.CurrentVehicle.Delete()
                                If Not veh4 = Nothing Then
                                    playerPed.Position = veh4Pos
                                    SetIntoVehicle(playerPed, veh4, VehicleSeat.Driver)
                                Else
                                    playerPed.Position = veh4Pos
                                End If
                                Wait(500)
                                Game.FadeScreenIn(500)
                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                            Else
                                If Not IO.File.Exists(file & "vehicle_5.cfg") Then
                                    CreateFile(file & "vehicle_5.cfg")
                                    UpdateGarageVehicle(file & "vehicle_5.cfg", "False")
                                    LoadGarageVehicle5(file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)
                                    TenCarGarage.IfTransferVehicle()
                                    Game.FadeScreenOut(500)
                                    Wait(&H3E8)
                                    playerPed.CurrentVehicle.Delete()
                                    If Not veh5 = Nothing Then
                                        playerPed.Position = veh5Pos
                                        SetIntoVehicle(playerPed, veh5, VehicleSeat.Driver)
                                    Else
                                        playerPed.Position = veh5Pos
                                    End If
                                    Wait(500)
                                    Game.FadeScreenIn(500)
                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                Else
                                    UI.ShowSubtitle(GrgFull)
                                    ShowAllHiddenMapObject()
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

    Public Shared Sub UpdateGarageVehicle(file As String, Active As String)
        WriteCfgValue("VehicleName", playerPed.CurrentVehicle.FriendlyName, file)
        'WriteCfgValue("VehicleModel", GetModelFromHash(playerPed.CurrentVehicle), file)
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
        If playerPed.CurrentVehicle.NumberPlate.Contains("MENYOO") Or playerPed.CurrentVehicle.NumberPlate.Contains("ENHANCED") Then
            Dim g As Guid = Guid.NewGuid()
            playerPed.CurrentVehicle.NumberPlate = g.ToString()
        End If
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
        'Added on v1.3.4
        WriteCfgValue("TrimColor", GetVehicleInteriorTrimColor2(playerPed.CurrentVehicle), file)
        WriteCfgValue("DashboardColor", GetVehicleInteriorDashboardColor2(playerPed.CurrentVehicle), file)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            ElevatorDistance = World.GetDistance(playerPed.Position, Elevator)
            GarageDoorLDistance = World.GetDistance(playerPed.Position, GarageDoorL)
            GarageDoorRDistance = World.GetDistance(playerPed.Position, GarageDoorR)
            'GarageMiddleDistance = World.GetDistance(playerPed.Position, GarageMiddle)
            GarageMarkerDistance = World.GetDistance(playerPed.Position, MenuActivator)

            If InteriorID = playerInterior Then
                World.DrawMarker(MarkerType.VerticalCylinder, MenuActivator, Vector3.Zero, Vector3.Zero, New Vector3(1.0, 1.0, 1.0), Drawing.Color.LightBlue)
                If My.Settings.RefreshGrgVehs = True Then RefreshGarageVehicles(CurrentPath)
            Else
                If Not Game.Player.Character.IsInVehicle Then
                    If Not veh0 = Nothing Then veh0.Delete()
                    If Not veh1 = Nothing Then veh1.Delete()
                    If Not veh2 = Nothing Then veh2.Delete()
                    If Not veh3 = Nothing Then veh3.Delete()
                    If Not veh4 = Nothing Then veh4.Delete()
                    If Not veh5 = Nothing Then veh5.Delete()
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso ElevatorDistance < 3.0 Then
                DisplayHelpTextThisFrame(EnterElevator & LastLocationName)
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso (GarageDoorLDistance < 3.0 Or GarageDoorRDistance < 3.0) Then
                DisplayHelpTextThisFrame(ExitGarage & Garage)
            End If

            If Not playerPed.IsDead AndAlso GarageMarkerDistance < 1.5 Then
                DisplayHelpTextThisFrame(ManageGarage)
            End If

            ControlsKeyDown()

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ControlsKeyDown()
        On Error Resume Next
        If playerPed.IsInVehicle AndAlso playerPed.CurrentVehicle.Speed > 1.5 AndAlso InteriorID = playerInterior AndAlso IsInGarageVehicle(playerPed) = True Then ' GarageMiddleDistance < 20.0
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
            Wait(&H3E8)

            playerPed.CurrentVehicle.Delete()
            If playerName = "Michael" Then
                If Mechanic.MPV1 = Nothing Then
                    Mechanic.MPV1 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.MPV1, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.MPV1.IsPersistent = True
                    Mechanic.MPV1.AddBlip()
                    Mechanic.MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.MPV1.CurrentBlip.Color = BlipColor2.Michael
                    Mechanic.MPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.MPV1.FriendlyName, Mechanic.MPV1.CurrentBlip)
                    SetIntoVehicle(playerPed, Mechanic.MPV1, VehicleSeat.Driver)
                    Mechanic.MVDict.Add(MD5Gen(Mechanic.MPV1.DisplayName & Mechanic.MPV1.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                Else
                    If Mechanic.MPV2 = Nothing Then
                        Mechanic.MPV2 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                        SetModKit(Mechanic.MPV2, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                        Mechanic.MPV2.IsPersistent = True
                        Mechanic.MPV2.AddBlip()
                        Mechanic.MPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.MPV2.CurrentBlip.Color = BlipColor2.Michael
                        Mechanic.MPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.MPV2.FriendlyName, Mechanic.MPV2.CurrentBlip)
                        SetIntoVehicle(playerPed, Mechanic.MPV2, VehicleSeat.Driver)
                        Mechanic.MVDict.Add(MD5Gen(Mechanic.MPV2.DisplayName & Mechanic.MPV2.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Else
                        If Mechanic.MPV3 = Nothing Then
                            Mechanic.MPV3 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                            SetModKit(Mechanic.MPV3, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                            Mechanic.MPV3.IsPersistent = True
                            Mechanic.MPV3.AddBlip()
                            Mechanic.MPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.MPV3.CurrentBlip.Color = BlipColor2.Michael
                            Mechanic.MPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.MPV3.FriendlyName, Mechanic.MPV3.CurrentBlip)
                            SetIntoVehicle(playerPed, Mechanic.MPV3, VehicleSeat.Driver)
                            Mechanic.MVDict.Add(MD5Gen(Mechanic.MPV3.DisplayName & Mechanic.MPV3.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Else
                            If Mechanic.MPV4 = Nothing Then
                                Mechanic.MPV4 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                SetModKit(Mechanic.MPV4, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                Mechanic.MPV4.IsPersistent = True
                                Mechanic.MPV4.AddBlip()
                                Mechanic.MPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.MPV4.CurrentBlip.Color = BlipColor2.Michael
                                Mechanic.MPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.MPV4.FriendlyName, Mechanic.MPV4.CurrentBlip)
                                SetIntoVehicle(playerPed, Mechanic.MPV4, VehicleSeat.Driver)
                                Mechanic.MVDict.Add(MD5Gen(Mechanic.MPV4.DisplayName & Mechanic.MPV4.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Else
                                If Mechanic.MPV0 = Nothing Then
                                    Mechanic.MPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.MPV0.IsPersistent = True
                                    Mechanic.MPV0.AddBlip()
                                    Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.MPV0.CurrentBlip.Color = BlipColor2.Michael
                                    Mechanic.MPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.MPV0.FriendlyName, Mechanic.MPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.MPV0, VehicleSeat.Driver)
                                    Mechanic.MVDict.Add(MD5Gen(Mechanic.MPV0.DisplayName & Mechanic.MPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Else
                                    Mechanic.MPV0.Delete()
                                    Mechanic.MPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.MPV0.IsPersistent = True
                                    Mechanic.MPV0.AddBlip()
                                    Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.MPV0.CurrentBlip.Color = BlipColor2.Michael
                                    Mechanic.MPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.MPV0.FriendlyName, Mechanic.MPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.MPV0, VehicleSeat.Driver)
                                    Mechanic.MVDict.Add(MD5Gen(Mechanic.MPV0.DisplayName & Mechanic.MPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf playerName = "Franklin" Then
                If Mechanic.FPV1 = Nothing Then
                    Mechanic.FPV1 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.FPV1, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.FPV1.IsPersistent = True
                    Mechanic.FPV1.AddBlip()
                    Mechanic.FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.FPV1.CurrentBlip.Color = BlipColor2.Franklin
                    Mechanic.FPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.FPV1.FriendlyName, Mechanic.FPV1.CurrentBlip)
                    SetIntoVehicle(playerPed, Mechanic.FPV1, VehicleSeat.Driver)
                    Mechanic.FVDict.Add(MD5Gen(Mechanic.FPV1.DisplayName & Mechanic.FPV1.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                Else
                    If Mechanic.FPV2 = Nothing Then
                        Mechanic.FPV2 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                        SetModKit(Mechanic.FPV2, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                        Mechanic.FPV2.IsPersistent = True
                        Mechanic.FPV2.AddBlip()
                        Mechanic.FPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.FPV2.CurrentBlip.Color = BlipColor2.Franklin
                        Mechanic.FPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.FPV2.FriendlyName, Mechanic.FPV2.CurrentBlip)
                        SetIntoVehicle(playerPed, Mechanic.FPV2, VehicleSeat.Driver)
                        Mechanic.FVDict.Add(MD5Gen(Mechanic.FPV2.DisplayName & Mechanic.FPV2.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Else
                        If Mechanic.FPV3 = Nothing Then
                            Mechanic.FPV3 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                            SetModKit(Mechanic.FPV3, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                            Mechanic.FPV3.IsPersistent = True
                            Mechanic.FPV3.AddBlip()
                            Mechanic.FPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.FPV3.CurrentBlip.Color = BlipColor2.Franklin
                            Mechanic.FPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.FPV3.FriendlyName, Mechanic.FPV3.CurrentBlip)
                            SetIntoVehicle(playerPed, Mechanic.FPV3, VehicleSeat.Driver)
                            Mechanic.FVDict.Add(MD5Gen(Mechanic.FPV3.DisplayName & Mechanic.FPV3.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Else
                            If Mechanic.FPV4 = Nothing Then
                                Mechanic.FPV4 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                SetModKit(Mechanic.FPV4, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                Mechanic.FPV4.IsPersistent = True
                                Mechanic.FPV4.AddBlip()
                                Mechanic.FPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.FPV4.CurrentBlip.Color = BlipColor2.Franklin
                                Mechanic.FPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.FPV4.FriendlyName, Mechanic.FPV4.CurrentBlip)
                                SetIntoVehicle(playerPed, Mechanic.FPV4, VehicleSeat.Driver)
                                Mechanic.FVDict.Add(MD5Gen(Mechanic.FPV4.DisplayName & Mechanic.FPV4.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Else
                                If Mechanic.FPV0 = Nothing Then
                                    Mechanic.FPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.FPV0.IsPersistent = True
                                    Mechanic.FPV0.AddBlip()
                                    Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.FPV0.CurrentBlip.Color = BlipColor2.Franklin
                                    Mechanic.FPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.FPV0.FriendlyName, Mechanic.FPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.FPV0, VehicleSeat.Driver)
                                    Mechanic.FVDict.Add(MD5Gen(Mechanic.FPV0.DisplayName & Mechanic.FPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Else
                                    Mechanic.FPV0.Delete()
                                    Mechanic.FPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.FPV0.IsPersistent = True
                                    Mechanic.FPV0.AddBlip()
                                    Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.FPV0.CurrentBlip.Color = BlipColor2.Franklin
                                    Mechanic.FPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.FPV0.FriendlyName, Mechanic.FPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.FPV0, VehicleSeat.Driver)
                                    Mechanic.FVDict.Add(MD5Gen(Mechanic.FPV0.DisplayName & Mechanic.FPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf playerName = "Trevor" Then
                If Mechanic.TPV1 = Nothing Then
                    Mechanic.TPV1 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.TPV1, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.TPV1.IsPersistent = True
                    Mechanic.TPV1.AddBlip()
                    Mechanic.TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.TPV1.CurrentBlip.Color = BlipColor2.Trevor
                    Mechanic.TPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.TPV1.FriendlyName, Mechanic.TPV1.CurrentBlip)
                    SetIntoVehicle(playerPed, Mechanic.TPV1, VehicleSeat.Driver)
                    Mechanic.TVDict.Add(MD5Gen(Mechanic.TPV1.DisplayName & Mechanic.TPV1.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                Else
                    If Mechanic.TPV2 = Nothing Then
                        Mechanic.TPV2 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                        SetModKit(Mechanic.TPV2, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                        Mechanic.TPV2.IsPersistent = True
                        Mechanic.TPV2.AddBlip()
                        Mechanic.TPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.TPV2.CurrentBlip.Color = BlipColor2.Trevor
                        Mechanic.TPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.TPV2.FriendlyName, Mechanic.TPV2.CurrentBlip)
                        SetIntoVehicle(playerPed, Mechanic.TPV2, VehicleSeat.Driver)
                        Mechanic.TVDict.Add(MD5Gen(Mechanic.TPV2.DisplayName & Mechanic.TPV2.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Else
                        If Mechanic.TPV3 = Nothing Then
                            Mechanic.TPV3 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                            SetModKit(Mechanic.TPV3, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                            Mechanic.TPV3.IsPersistent = True
                            Mechanic.TPV3.AddBlip()
                            Mechanic.TPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.TPV3.CurrentBlip.Color = BlipColor2.Trevor
                            Mechanic.TPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.TPV3.FriendlyName, Mechanic.TPV3.CurrentBlip)
                            SetIntoVehicle(playerPed, Mechanic.TPV3, VehicleSeat.Driver)
                            Mechanic.TVDict.Add(MD5Gen(Mechanic.TPV3.DisplayName & Mechanic.TPV3.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Else
                            If Mechanic.TPV4 = Nothing Then
                                Mechanic.TPV4 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                SetModKit(Mechanic.TPV4, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                Mechanic.TPV4.IsPersistent = True
                                Mechanic.TPV4.AddBlip()
                                Mechanic.TPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.TPV4.CurrentBlip.Color = BlipColor2.Trevor
                                Mechanic.TPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.TPV4.FriendlyName, Mechanic.TPV4.CurrentBlip)
                                SetIntoVehicle(playerPed, Mechanic.TPV4, VehicleSeat.Driver)
                                Mechanic.TVDict.Add(MD5Gen(Mechanic.TPV4.DisplayName & Mechanic.TPV4.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Else
                                If Mechanic.TPV0 = Nothing Then
                                    Mechanic.TPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.TPV0.IsPersistent = True
                                    Mechanic.TPV0.AddBlip()
                                    Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.TPV0.CurrentBlip.Color = BlipColor2.Trevor
                                    Mechanic.TPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.TPV0.FriendlyName, Mechanic.TPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.TPV0, VehicleSeat.Driver)
                                    Mechanic.TVDict.Add(MD5Gen(Mechanic.TPV0.DisplayName & Mechanic.TPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Else
                                    Mechanic.TPV0.Delete()
                                    Mechanic.TPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.TPV0.IsPersistent = True
                                    Mechanic.TPV0.AddBlip()
                                    Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.TPV0.CurrentBlip.Color = BlipColor2.Trevor
                                    Mechanic.TPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.TPV0.FriendlyName, Mechanic.TPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.TPV0, VehicleSeat.Driver)
                                    Mechanic.TVDict.Add(MD5Gen(Mechanic.TPV0.DisplayName & Mechanic.TPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf playerName = "Player3" Then
                If Mechanic.PPV1 = Nothing Then
                    Mechanic.PPV1 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.PPV1, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.PPV1.IsPersistent = True
                    Mechanic.PPV1.AddBlip()
                    Mechanic.PPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.PPV1.CurrentBlip.Color = BlipColor.Yellow
                    Mechanic.PPV1.CurrentBlip.IsShortRange = True
                    SetBlipName(Mechanic.PPV1.FriendlyName, Mechanic.PPV1.CurrentBlip)
                    SetIntoVehicle(playerPed, Mechanic.PPV1, VehicleSeat.Driver)
                    Mechanic.PVDict.Add(MD5Gen(Mechanic.PPV1.DisplayName & Mechanic.PPV1.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                Else
                    If Mechanic.PPV2 = Nothing Then
                        Mechanic.PPV2 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                        SetModKit(Mechanic.PPV2, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                        Mechanic.PPV2.IsPersistent = True
                        Mechanic.PPV2.AddBlip()
                        Mechanic.PPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Mechanic.PPV2.CurrentBlip.Color = BlipColor.Yellow
                        Mechanic.PPV2.CurrentBlip.IsShortRange = True
                        SetBlipName(Mechanic.PPV2.FriendlyName, Mechanic.PPV2.CurrentBlip)
                        SetIntoVehicle(playerPed, Mechanic.PPV2, VehicleSeat.Driver)
                        Mechanic.PVDict.Add(MD5Gen(Mechanic.PPV2.DisplayName & Mechanic.PPV2.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                    Else
                        If Mechanic.PPV3 = Nothing Then
                            Mechanic.PPV3 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                            SetModKit(Mechanic.PPV3, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                            Mechanic.PPV3.IsPersistent = True
                            Mechanic.PPV3.AddBlip()
                            Mechanic.PPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            Mechanic.PPV3.CurrentBlip.Color = BlipColor.Yellow
                            Mechanic.PPV3.CurrentBlip.IsShortRange = True
                            SetBlipName(Mechanic.PPV3.FriendlyName, Mechanic.PPV3.CurrentBlip)
                            SetIntoVehicle(playerPed, Mechanic.PPV3, VehicleSeat.Driver)
                            Mechanic.PVDict.Add(MD5Gen(Mechanic.PPV3.DisplayName & Mechanic.PPV3.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                        Else
                            If Mechanic.PPV4 = Nothing Then
                                Mechanic.PPV4 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                SetModKit(Mechanic.PPV4, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                Mechanic.PPV4.IsPersistent = True
                                Mechanic.PPV4.AddBlip()
                                Mechanic.PPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                Mechanic.PPV4.CurrentBlip.Color = BlipColor.Yellow
                                Mechanic.PPV4.CurrentBlip.IsShortRange = True
                                SetBlipName(Mechanic.PPV4.FriendlyName, Mechanic.PPV4.CurrentBlip)
                                SetIntoVehicle(playerPed, Mechanic.PPV4, VehicleSeat.Driver)
                                Mechanic.PVDict.Add(MD5Gen(Mechanic.PPV4.DisplayName & Mechanic.PPV4.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                            Else
                                If Mechanic.PPV0 = Nothing Then
                                    Mechanic.PPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.PPV0.IsPersistent = True
                                    Mechanic.PPV0.AddBlip()
                                    Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
                                    Mechanic.PPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.PPV0.FriendlyName, Mechanic.PPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.PPV0, VehicleSeat.Driver)
                                    Mechanic.PVDict.Add(MD5Gen(Mechanic.PPV0.DisplayName & Mechanic.PPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                Else
                                    Mechanic.PPV0.Delete()
                                    Mechanic.PPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                                    SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                                    Mechanic.PPV0.IsPersistent = True
                                    Mechanic.PPV0.AddBlip()
                                    Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
                                    Mechanic.PPV0.CurrentBlip.IsShortRange = True
                                    SetBlipName(Mechanic.PPV0.FriendlyName, Mechanic.PPV0.CurrentBlip)
                                    SetIntoVehicle(playerPed, Mechanic.PPV0, VehicleSeat.Driver)
                                    Mechanic.PVDict.Add(MD5Gen(Mechanic.PPV0.DisplayName & Mechanic.PPV0.Handle), CurrentPath & "vehicle_" & PPCV & ".cfg")
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            playerPed.CurrentVehicle.Repair()
            Brain.TVOn = False
            playerPed.CurrentVehicle.Position = lastLocationGarageOutVector
            playerPed.CurrentVehicle.Heading = lastLocationGarageOutHeading
            ShowAllHiddenMapObject()
            LowEndLastLocationName = Nothing
            Wait(500)
            Game.FadeScreenIn(500)
            UnLoadMPDLCMap()
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso ElevatorDistance < 3.0 Then
            Game.FadeScreenOut(500)
            Wait(&H3E8)
            playerPed.Position = lastLocationVector
            SinglePlayerApartment.player.LastVehicle.Delete()
            Wait(500)
            Game.FadeScreenIn(500)
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso (GarageDoorLDistance < 3.0 Or GarageDoorRDistance < 3.0) Then
            Game.FadeScreenOut(500)
            Wait(&H3E8)
            Brain.TVOn = False
            playerPed.Position = lastLocationGarageVector
            ShowAllHiddenMapObject()
            LowEndLastLocationName = Nothing
            SinglePlayerApartment.player.LastVehicle.Delete()
            Wait(500)
            Game.FadeScreenIn(500)
            UnLoadMPDLCMap()
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso GarageMarkerDistance < 1.5 AndAlso Not Mechanic._menuPool.IsAnyMenuOpen Then
            Mechanic.CreateGarageMenu6CarGarage(CurrentPath)
            Mechanic.CreateGarageMenu2("Six")
            Mechanic.GarageMenu.Visible = True
            World.RenderingCamera = World.CreateCamera(New Vector3(190.1158, -993.1951, -97.41743), New Vector3(-17.44125, 0, -130.9189), 50)
        End If
    End Sub

    Public Shared Sub ShowAllHiddenMapObject()
        Brain.TVOn = False
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        Try
            If Not veh0 = Nothing Then veh0.Delete()
            If Not veh1 = Nothing Then veh1.Delete()
            If Not veh2 = Nothing Then veh2.Delete()
            If Not veh3 = Nothing Then veh3.Delete()
            If Not veh4 = Nothing Then veh4.Delete()
            If Not veh5 = Nothing Then veh5.Delete()
        Catch ex As Exception
        End Try
    End Sub
End Class
