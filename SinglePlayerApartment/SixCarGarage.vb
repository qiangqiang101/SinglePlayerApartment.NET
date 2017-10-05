Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports SinglePlayerApartment.SinglePlayerApartment

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
            Translate()
            InteriorID = INMNative.Apartment.GetInteriorID(New Vector3(193.9493, -1004.425, -99.99999))
            If Not InteriorID = 0 Then InteriorIDList.Add(InteriorID)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadGarageVehicle(ByRef veh As Vehicle, file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If veh = Nothing Then
                veh = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            Else
                veh.Delete()
                veh = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
            End If

            SetModKit(veh, file, False)
            veh.Rotation = rot
            If ReadCfgValue("Active", file) = "True" Then veh.Delete()
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

            If IO.File.Exists(file & "Vehicle_0.cfg") Then LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
            If IO.File.Exists(file & "Vehicle_1.cfg") Then LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
            If IO.File.Exists(file & "Vehicle_2.cfg") Then LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
            If IO.File.Exists(file & "Vehicle_3.cfg") Then LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
            If IO.File.Exists(file & "Vehicle_4.cfg") Then LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
            If IO.File.Exists(file & "Vehicle_5.cfg") Then LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)

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
            If IO.File.Exists(file & "vehicle_0.cfg") Then If ReadCfgValue("Active", file & "vehicle_0.cfg") = "False" AndAlso Not veh0.Exists Then LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_1.cfg") Then If ReadCfgValue("Active", file & "vehicle_1.cfg") = "False" AndAlso Not veh1.Exists Then LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_2.cfg") Then If ReadCfgValue("Active", file & "vehicle_2.cfg") = "False" AndAlso Not veh2.Exists Then LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
            If IO.File.Exists(file & "vehicle_3.cfg") Then If ReadCfgValue("Active", file & "vehicle_3.cfg") = "False" AndAlso Not veh3.Exists Then LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
            If IO.File.Exists(file & "vehicle_4.cfg") Then If ReadCfgValue("Active", file & "vehicle_4.cfg") = "False" AndAlso Not veh4.Exists Then LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
            If IO.File.Exists(file & "vehicle_5.cfg") Then If ReadCfgValue("Active", file & "vehicle_5.cfg") = "False" AndAlso Not veh5.Exists Then LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)
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



    Public Shared Sub SaveGarageVehicle(file As String)
        Try
            If Not IO.File.Exists(file & "vehicle_0.cfg") Then
                CreateFile(file & "vehicle_0.cfg")
                UpdateGarageVehicle(file & "vehicle_0.cfg", "False")
                LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot02, -60)
                TenCarGarage.IfTransferVehicle()
                Game.FadeScreenOut(500)
                Wait(500)
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
                    LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot02, -60)
                    TenCarGarage.IfTransferVehicle()
                    Game.FadeScreenOut(500)
                    Wait(500)
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
                        LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot02, -60)
                        TenCarGarage.IfTransferVehicle()
                        Game.FadeScreenOut(500)
                        Wait(500)
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
                            LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot35, -60)
                            TenCarGarage.IfTransferVehicle()
                            Game.FadeScreenOut(500)
                            Wait(500)
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
                                LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot35, -60)
                                TenCarGarage.IfTransferVehicle()
                                Game.FadeScreenOut(500)
                                Wait(500)
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
                                    LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot35, -60)
                                    TenCarGarage.IfTransferVehicle()
                                    Game.FadeScreenOut(500)
                                    Wait(500)
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
        'Updated on v1.9.2
        WriteCfgValue("TrimColor", playerPed.CurrentVehicle.TrimColor, file)
        WriteCfgValue("DashboardColor", playerPed.CurrentVehicle.DashboardColor, file)
        'Added on v1.9.2
        WriteCfgValue("ExtraTen", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 10), file)
        WriteCfgValue("CustomRoof", GetTornadoCustomRoof(playerPed.CurrentVehicle), file)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            If Not Game.IsLoading Then
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
            End If
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
            Wait(500)

            playerPed.CurrentVehicle.Delete()
            If GetPlayerName() = "Michael" Then
                If Mechanic.MPV0 = Nothing Then
                    Mechanic.MPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.MPV0.IsPersistent = True
                    Mechanic.MPV0.AddBlip()
                    Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.MPV0.CurrentBlip.Color = BlipColor2.Michael
                    Mechanic.MPV0.CurrentBlip.IsShortRange = True
                    Mechanic.MPV0.CurrentBlip.Name = Mechanic.MPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.MPV0, VehicleSeat.Driver)
                    Mechanic.MPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.MPV0)
                Else
                    Mechanic.MPV0.Delete()
                    Mechanic.MPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.MPV0.IsPersistent = True
                    Mechanic.MPV0.AddBlip()
                    Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.MPV0.CurrentBlip.Color = BlipColor2.Michael
                    Mechanic.MPV0.CurrentBlip.IsShortRange = True
                    Mechanic.MPV0.CurrentBlip.Name = Mechanic.MPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.MPV0, VehicleSeat.Driver)
                    Mechanic.MPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.MPV0)
                End If
            ElseIf GetPlayerName() = "Franklin" Then
                If Mechanic.FPV0 = Nothing Then
                    Mechanic.FPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.FPV0.IsPersistent = True
                    Mechanic.FPV0.AddBlip()
                    Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.FPV0.CurrentBlip.Color = BlipColor2.Franklin
                    Mechanic.FPV0.CurrentBlip.IsShortRange = True
                    Mechanic.FPV0.CurrentBlip.Name = Mechanic.FPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.FPV0, VehicleSeat.Driver)
                    Mechanic.FPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.FPV0)
                Else
                    Mechanic.FPV0.Delete()
                    Mechanic.FPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.FPV0.IsPersistent = True
                    Mechanic.FPV0.AddBlip()
                    Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.FPV0.CurrentBlip.Color = BlipColor2.Franklin
                    Mechanic.FPV0.CurrentBlip.IsShortRange = True
                    Mechanic.FPV0.CurrentBlip.Name = Mechanic.FPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.FPV0, VehicleSeat.Driver)
                    Mechanic.FPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.FPV0)
                End If
            ElseIf GetPlayerName() = "Trevor" Then
                If Mechanic.TPV0 = Nothing Then
                    Mechanic.TPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.TPV0.IsPersistent = True
                    Mechanic.TPV0.AddBlip()
                    Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.TPV0.CurrentBlip.Color = BlipColor2.Trevor
                    Mechanic.TPV0.CurrentBlip.IsShortRange = True
                    Mechanic.TPV0.CurrentBlip.Name = Mechanic.TPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.TPV0, VehicleSeat.Driver)
                    Mechanic.TPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.TPV0)
                Else
                    Mechanic.TPV0.Delete()
                    Mechanic.TPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.TPV0.IsPersistent = True
                    Mechanic.TPV0.AddBlip()
                    Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.TPV0.CurrentBlip.Color = BlipColor2.Trevor
                    Mechanic.TPV0.CurrentBlip.IsShortRange = True
                    Mechanic.TPV0.CurrentBlip.Name = Mechanic.TPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.TPV0, VehicleSeat.Driver)
                    Mechanic.TPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.TPV0)
                End If
            ElseIf GetPlayerName() = "Player3" Then
                If Mechanic.PPV0 = Nothing Then
                    Mechanic.PPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.PPV0.IsPersistent = True
                    Mechanic.PPV0.AddBlip()
                    Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
                    Mechanic.PPV0.CurrentBlip.IsShortRange = True
                    Mechanic.PPV0.CurrentBlip.Name = Mechanic.PPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.PPV0, VehicleSeat.Driver)
                    Mechanic.PPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.PPV0)
                Else
                    Mechanic.PPV0.Delete()
                    Mechanic.PPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
                    SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
                    Mechanic.PPV0.IsPersistent = True
                    Mechanic.PPV0.AddBlip()
                    Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
                    Mechanic.PPV0.CurrentBlip.IsShortRange = True
                    Mechanic.PPV0.CurrentBlip.Name = Mechanic.PPV0.FriendlyName
                    SetIntoVehicle(playerPed, Mechanic.PPV0, VehicleSeat.Driver)
                    Mechanic.PPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.PPV0)
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
            Wait(500)
            playerPed.Position = lastLocationVector
            SinglePlayerApartment.player.LastVehicle.Delete()
            Wait(500)
            Game.FadeScreenIn(500)
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso (GarageDoorLDistance < 3.0 Or GarageDoorRDistance < 3.0) Then
            Game.FadeScreenOut(500)
            Wait(500)
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
