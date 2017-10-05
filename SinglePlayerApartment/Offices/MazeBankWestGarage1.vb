Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.INMNative

Public Class MazeBankWestGarage1
    Inherits Script

    Public Shared InteriorID As Integer
    Public Shared CurrentPath As String
    Public Shared veh0, veh1, veh2, veh3, veh4, veh5, veh6, veh7, veh8, veh9, veh10, veh11, veh12, veh13, veh14, veh15, veh16, veh17, veh18, veh19 As Vehicle
    Public Shared LastLocationName As String
    Public Shared lastLocationVector As Vector3
    Public Shared lastLocationGarageVector As Vector3
    Public Shared lastLocationGarageOutVector As Vector3
    Public Shared lastLocationGarageOutHeading As Single
    Public Shared Elevator As Vector3 = New Vector3(-1395.882, -480.5163, 56.10049) '/
    Public Shared MenuActivator As Vector3 = New Vector3(-1395.049, -476.1217, 56.10049)  '/
    Public Shared ElevatorDistance As Single
    Public Shared GarageMarkerDistance As Single
    Public Shared veh0Pos As Vector3 = New Vector3(-1370.5, -482.9, 56.4) '//
    Public Shared veh1Pos As Vector3 = New Vector3(-1370.4, -477.6, 56.4) '//
    Public Shared veh2Pos As Vector3 = New Vector3(-1373.5, -473.0, 56.4) '//
    Public Shared veh3Pos As Vector3 = New Vector3(-1378.3, -471.3, 56.4) '//
    Public Shared veh4Pos As Vector3 = New Vector3(-1383.2, -471.8, 56.4) '//
    Public Shared veh5Pos As Vector3 = New Vector3(-1387.8, -473.2, 56.4) '//

    Public Shared veh6Pos As Vector3 = New Vector3(-1370.5, -482.9, 61.8) '//
    Public Shared veh7Pos As Vector3 = New Vector3(-1370.4, -477.6, 61.8) '//
    Public Shared veh8Pos As Vector3 = New Vector3(-1373.5, -473.0, 61.8) '//
    Public Shared veh9Pos As Vector3 = New Vector3(-1378.3, -471.3, 61.8) '//
    Public Shared veh10Pos As Vector3 = New Vector3(-1383.2, -471.8, 61.8) '//
    Public Shared veh11Pos As Vector3 = New Vector3(-1387.8, -473.2, 61.8) '//
    Public Shared veh12Pos As Vector3 = New Vector3(-1391.9, -475.1, 61.8) '//

    Public Shared veh13Pos As Vector3 = New Vector3(-1370.5, -482.9, 67.1) '//
    Public Shared veh14Pos As Vector3 = New Vector3(-1370.4, -477.6, 67.1) '//
    Public Shared veh15Pos As Vector3 = New Vector3(-1373.5, -473.0, 67.1) '//
    Public Shared veh16Pos As Vector3 = New Vector3(-1378.3, -471.3, 67.1) '//
    Public Shared veh17Pos As Vector3 = New Vector3(-1383.2, -471.8, 67.1) '//
    Public Shared veh18Pos As Vector3 = New Vector3(-1387.8, -473.2, 67.1) '//
    Public Shared veh19Pos As Vector3 = New Vector3(-1391.9, -475.1, 67.1) '//
    Public Shared vehRot0613 As Vector3 = New Vector3(0, 0, 76.5) '//
    Public Shared vehRot1714 As Vector3 = New Vector3(0, 0, 106.0) '//
    Public Shared vehRot2815 As Vector3 = New Vector3(0, 0, 143.1) '//
    Public Shared vehRot3916 As Vector3 = New Vector3(0, 0, 175.0) '//
    Public Shared vehRot41017 As Vector3 = New Vector3(0, 0, 199.5) '//
    Public Shared vehRot51118 As Vector3 = New Vector3(0, 0, 202.5) '//
    Public Shared vehRot1219 As Vector3 = New Vector3(0, 0, 204.8) '//

    Public Sub New()
        Try
            If ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then
                Translate()
            End If
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
            If Not veh6 = Nothing Then veh6.Delete()
            If Not veh7 = Nothing Then veh7.Delete()
            If Not veh8 = Nothing Then veh8.Delete()
            If Not veh9 = Nothing Then veh9.Delete()
            If Not veh10 = Nothing Then veh10.Delete()
            If Not veh11 = Nothing Then veh11.Delete()
            If Not veh12 = Nothing Then veh12.Delete()
            If Not veh13 = Nothing Then veh13.Delete()
            If Not veh14 = Nothing Then veh14.Delete()
            If Not veh15 = Nothing Then veh15.Delete()
            If Not veh16 = Nothing Then veh16.Delete()
            If Not veh17 = Nothing Then veh17.Delete()
            If Not veh18 = Nothing Then veh18.Delete()
            If Not veh19 = Nothing Then veh19.Delete()

            If IO.File.Exists(file & "Vehicle_0.cfg") Then LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot0613, -60)
            If IO.File.Exists(file & "Vehicle_1.cfg") Then LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot1714, -60)
            If IO.File.Exists(file & "Vehicle_2.cfg") Then LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot2815, -60)
            If IO.File.Exists(file & "Vehicle_3.cfg") Then LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot3916, -60)
            If IO.File.Exists(file & "Vehicle_4.cfg") Then LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot41017, -60)
            If IO.File.Exists(file & "Vehicle_5.cfg") Then LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot51118, -60)
            If IO.File.Exists(file & "Vehicle_6.cfg") Then LoadGarageVehicle(veh6, file & "vehicle_6.cfg", veh6Pos, vehRot0613, -60)
            If IO.File.Exists(file & "Vehicle_7.cfg") Then LoadGarageVehicle(veh7, file & "vehicle_7.cfg", veh7Pos, vehRot1714, -60)
            If IO.File.Exists(file & "Vehicle_8.cfg") Then LoadGarageVehicle(veh8, file & "vehicle_8.cfg", veh8Pos, vehRot2815, -60)
            If IO.File.Exists(file & "Vehicle_9.cfg") Then LoadGarageVehicle(veh9, file & "vehicle_9.cfg", veh9Pos, vehRot3916, -60)
            If IO.File.Exists(file & "Vehicle_10.cfg") Then LoadGarageVehicle(veh10, file & "vehicle_10.cfg", veh10Pos, vehRot41017, -60)
            If IO.File.Exists(file & "Vehicle_11.cfg") Then LoadGarageVehicle(veh11, file & "vehicle_11.cfg", veh11Pos, vehRot51118, -60)
            If IO.File.Exists(file & "Vehicle_12.cfg") Then LoadGarageVehicle(veh12, file & "vehicle_12.cfg", veh12Pos, vehRot1219, -60)
            If IO.File.Exists(file & "Vehicle_13.cfg") Then LoadGarageVehicle(veh13, file & "vehicle_13.cfg", veh13Pos, vehRot0613, -60)
            If IO.File.Exists(file & "Vehicle_14.cfg") Then LoadGarageVehicle(veh14, file & "vehicle_14.cfg", veh14Pos, vehRot1714, -60)
            If IO.File.Exists(file & "Vehicle_15.cfg") Then LoadGarageVehicle(veh15, file & "vehicle_15.cfg", veh15Pos, vehRot2815, -60)
            If IO.File.Exists(file & "Vehicle_16.cfg") Then LoadGarageVehicle(veh16, file & "vehicle_16.cfg", veh16Pos, vehRot3916, -60)
            If IO.File.Exists(file & "Vehicle_17.cfg") Then LoadGarageVehicle(veh17, file & "vehicle_17.cfg", veh17Pos, vehRot41017, -60)
            If IO.File.Exists(file & "Vehicle_18.cfg") Then LoadGarageVehicle(veh18, file & "vehicle_18.cfg", veh18Pos, vehRot51118, -60)
            If IO.File.Exists(file & "Vehicle_19.cfg") Then LoadGarageVehicle(veh19, file & "vehicle_19.cfg", veh19Pos, vehRot1219, -60)

            Mechanic.Path = file
            Mechanic.CreateGarageMenu(file, True)
            Mechanic.CreateGarageMenu2("MBWG1Twenty")

            veh0.MarkAsNoLongerNeeded()
            veh1.MarkAsNoLongerNeeded()
            veh2.MarkAsNoLongerNeeded()
            veh3.MarkAsNoLongerNeeded()
            veh4.MarkAsNoLongerNeeded()
            veh5.MarkAsNoLongerNeeded()
            veh6.MarkAsNoLongerNeeded()
            veh7.MarkAsNoLongerNeeded()
            veh8.MarkAsNoLongerNeeded()
            veh9.MarkAsNoLongerNeeded()
            veh10.MarkAsNoLongerNeeded()
            veh11.MarkAsNoLongerNeeded()
            veh12.MarkAsNoLongerNeeded()
            veh13.MarkAsNoLongerNeeded()
            veh14.MarkAsNoLongerNeeded()
            veh15.MarkAsNoLongerNeeded()
            veh16.MarkAsNoLongerNeeded()
            veh17.MarkAsNoLongerNeeded()
            veh18.MarkAsNoLongerNeeded()
            veh19.MarkAsNoLongerNeeded()

            IfReturnedVehicle()
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub RefreshGarageVehicles(file As String)
        Try
            If Not Game.Player.Character.IsInVehicle Then
                If IO.File.Exists(file & "vehicle_0.cfg") Then If ReadCfgValue("Active", file & "vehicle_0.cfg") = "False" AndAlso Not veh0.Exists Then LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot0613, -60)
                If IO.File.Exists(file & "vehicle_1.cfg") Then If ReadCfgValue("Active", file & "vehicle_1.cfg") = "False" AndAlso Not veh1.Exists Then LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot1714, -60)
                If IO.File.Exists(file & "vehicle_2.cfg") Then If ReadCfgValue("Active", file & "vehicle_2.cfg") = "False" AndAlso Not veh2.Exists Then LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot2815, -60)
                If IO.File.Exists(file & "vehicle_3.cfg") Then If ReadCfgValue("Active", file & "vehicle_3.cfg") = "False" AndAlso Not veh3.Exists Then LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot3916, -60)
                If IO.File.Exists(file & "vehicle_4.cfg") Then If ReadCfgValue("Active", file & "vehicle_4.cfg") = "False" AndAlso Not veh4.Exists Then LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot41017, -60)
                If IO.File.Exists(file & "vehicle_5.cfg") Then If ReadCfgValue("Active", file & "vehicle_5.cfg") = "False" AndAlso Not veh5.Exists Then LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot51118, -60)
                If IO.File.Exists(file & "vehicle_6.cfg") Then If ReadCfgValue("Active", file & "vehicle_6.cfg") = "False" AndAlso Not veh6.Exists Then LoadGarageVehicle(veh6, file & "vehicle_6.cfg", veh6Pos, vehRot0613, -60)
                If IO.File.Exists(file & "vehicle_7.cfg") Then If ReadCfgValue("Active", file & "vehicle_7.cfg") = "False" AndAlso Not veh7.Exists Then LoadGarageVehicle(veh7, file & "vehicle_7.cfg", veh7Pos, vehRot1714, -60)
                If IO.File.Exists(file & "vehicle_8.cfg") Then If ReadCfgValue("Active", file & "vehicle_8.cfg") = "False" AndAlso Not veh8.Exists Then LoadGarageVehicle(veh8, file & "vehicle_8.cfg", veh8Pos, vehRot2815, -60)
                If IO.File.Exists(file & "vehicle_9.cfg") Then If ReadCfgValue("Active", file & "vehicle_9.cfg") = "False" AndAlso Not veh9.Exists Then LoadGarageVehicle(veh9, file & "vehicle_9.cfg", veh9Pos, vehRot3916, -60)
                If IO.File.Exists(file & "vehicle_10.cfg") Then If ReadCfgValue("Active", file & "vehicle_10.cfg") = "False" AndAlso Not veh10.Exists Then LoadGarageVehicle(veh10, file & "vehicle_10.cfg", veh10Pos, vehRot41017, -60)
                If IO.File.Exists(file & "vehicle_11.cfg") Then If ReadCfgValue("Active", file & "vehicle_11.cfg") = "False" AndAlso Not veh11.Exists Then LoadGarageVehicle(veh11, file & "vehicle_11.cfg", veh11Pos, vehRot51118, -60)
                If IO.File.Exists(file & "vehicle_12.cfg") Then If ReadCfgValue("Active", file & "vehicle_12.cfg") = "False" AndAlso Not veh12.Exists Then LoadGarageVehicle(veh12, file & "vehicle_12.cfg", veh12Pos, vehRot1219, -60)
                If IO.File.Exists(file & "vehicle_13.cfg") Then If ReadCfgValue("Active", file & "vehicle_13.cfg") = "False" AndAlso Not veh13.Exists Then LoadGarageVehicle(veh13, file & "vehicle_13.cfg", veh13Pos, vehRot0613, -60)
                If IO.File.Exists(file & "vehicle_14.cfg") Then If ReadCfgValue("Active", file & "vehicle_14.cfg") = "False" AndAlso Not veh14.Exists Then LoadGarageVehicle(veh14, file & "vehicle_14.cfg", veh14Pos, vehRot1714, -60)
                If IO.File.Exists(file & "vehicle_15.cfg") Then If ReadCfgValue("Active", file & "vehicle_15.cfg") = "False" AndAlso Not veh15.Exists Then LoadGarageVehicle(veh15, file & "vehicle_15.cfg", veh15Pos, vehRot2815, -60)
                If IO.File.Exists(file & "vehicle_16.cfg") Then If ReadCfgValue("Active", file & "vehicle_16.cfg") = "False" AndAlso Not veh16.Exists Then LoadGarageVehicle(veh16, file & "vehicle_16.cfg", veh16Pos, vehRot3916, -60)
                If IO.File.Exists(file & "vehicle_17.cfg") Then If ReadCfgValue("Active", file & "vehicle_17.cfg") = "False" AndAlso Not veh17.Exists Then LoadGarageVehicle(veh17, file & "vehicle_17.cfg", veh17Pos, vehRot41017, -60)
                If IO.File.Exists(file & "vehicle_18.cfg") Then If ReadCfgValue("Active", file & "vehicle_18.cfg") = "False" AndAlso Not veh18.Exists Then LoadGarageVehicle(veh18, file & "vehicle_18.cfg", veh18Pos, vehRot51118, -60)
                If IO.File.Exists(file & "vehicle_19.cfg") Then If ReadCfgValue("Active", file & "vehicle_19.cfg") = "False" AndAlso Not veh19.Exists Then LoadGarageVehicle(veh19, file & "vehicle_19.cfg", veh19Pos, vehRot1219, -60)
                veh0.MarkAsNoLongerNeeded()
                veh1.MarkAsNoLongerNeeded()
                veh2.MarkAsNoLongerNeeded()
                veh3.MarkAsNoLongerNeeded()
                veh4.MarkAsNoLongerNeeded()
                veh5.MarkAsNoLongerNeeded()
                veh6.MarkAsNoLongerNeeded()
                veh7.MarkAsNoLongerNeeded()
                veh8.MarkAsNoLongerNeeded()
                veh9.MarkAsNoLongerNeeded()
                veh10.MarkAsNoLongerNeeded()
                veh11.MarkAsNoLongerNeeded()
                veh12.MarkAsNoLongerNeeded()
                veh13.MarkAsNoLongerNeeded()
                veh14.MarkAsNoLongerNeeded()
                veh15.MarkAsNoLongerNeeded()
                veh16.MarkAsNoLongerNeeded()
                veh17.MarkAsNoLongerNeeded()
                veh18.MarkAsNoLongerNeeded()
                veh19.MarkAsNoLongerNeeded()
            End If
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub IfReturnedVehicle()
        If playerPed.IsInVehicle Then
            Select Case GetPlayerName()
                Case "Michael"
                    If Mechanic.MPersVeh.Exist Then Mechanic.MPersVeh.Delete()
                Case "Franklin"
                    If Mechanic.FPersVeh.Exist Then Mechanic.FPersVeh.Delete()
                Case "Trevor"
                    If Mechanic.TPersVeh.Exist Then Mechanic.TPersVeh.Delete()
                Case "Player3"
                    If Mechanic.PPersVeh.Exist Then Mechanic.FPersVeh.Delete()
            End Select
        End If
    End Sub

    Public Shared Sub IfTransferVehicle()
        Select Case GetPlayerName()
            Case "Michael"
                If Mechanic.MPersVeh.Exist Then
                    IO.File.Delete(Mechanic.MPersVeh.FilePath)
                    Mechanic.MPersVeh.Delete()
                End If
            Case "Franklin"
                If Mechanic.FPersVeh.Exist Then
                    IO.File.Delete(Mechanic.FPersVeh.FilePath)
                    Mechanic.FPersVeh.Delete()
                End If
            Case "Trevor"
                If Mechanic.TPersVeh.Exist Then
                    IO.File.Delete(Mechanic.TPersVeh.FilePath)
                    Mechanic.TPersVeh.Delete()
                End If
            Case "Player3"
                If Mechanic.PPersVeh.Exist Then
                    IO.File.Delete(Mechanic.PPersVeh.FilePath)
                    Mechanic.FPersVeh.Delete()
                End If
        End Select
    End Sub

    Public Shared Sub SaveGarageVehicle(file As String)
        Try
            If Not IO.File.Exists(file & "vehicle_0.cfg") Then
                CreateFile(file & "vehicle_0.cfg")
                UpdateGarageVehicle(file & "vehicle_0.cfg", "False")
                LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot0613, -60)
                IfTransferVehicle()
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
                    LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot1714, -60)
                    IfTransferVehicle()
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
                        LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot2815, -60)
                        IfTransferVehicle()
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
                            LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot3916, -60)
                            IfTransferVehicle()
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
                                LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot41017, -60)
                                IfTransferVehicle()
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
                                    LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot51118, -60)
                                    IfTransferVehicle()
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
                                    If Not IO.File.Exists(file & "vehicle_6.cfg") Then
                                        CreateFile(file & "vehicle_6.cfg")
                                        UpdateGarageVehicle(file & "vehicle_6.cfg", "False")
                                        LoadGarageVehicle(veh6, file & "vehicle_6.cfg", veh6Pos, vehRot0613, -60)
                                        IfTransferVehicle()
                                        Game.FadeScreenOut(500)
                                        Wait(500)
                                        playerPed.CurrentVehicle.Delete()
                                        If Not veh6 = Nothing Then
                                            playerPed.Position = veh6Pos
                                            SetIntoVehicle(playerPed, veh6, VehicleSeat.Driver)
                                        Else
                                            playerPed.Position = veh6Pos
                                        End If
                                        Wait(500)
                                        Game.FadeScreenIn(500)
                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                    Else
                                        If Not IO.File.Exists(file & "vehicle_7.cfg") Then
                                            CreateFile(file & "vehicle_7.cfg")
                                            UpdateGarageVehicle(file & "vehicle_7.cfg", "False")
                                            LoadGarageVehicle(veh7, file & "vehicle_7.cfg", veh7Pos, vehRot1714, -60)
                                            IfTransferVehicle()
                                            Game.FadeScreenOut(500)
                                            Wait(500)
                                            playerPed.CurrentVehicle.Delete()
                                            If Not veh7 = Nothing Then
                                                playerPed.Position = veh7Pos
                                                SetIntoVehicle(playerPed, veh7, VehicleSeat.Driver)
                                            Else
                                                playerPed.Position = veh7Pos
                                            End If
                                            Wait(500)
                                            Game.FadeScreenIn(500)
                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                        Else
                                            If Not IO.File.Exists(file & "vehicle_8.cfg") Then
                                                CreateFile(file & "vehicle_8.cfg")
                                                UpdateGarageVehicle(file & "vehicle_8.cfg", "False")
                                                LoadGarageVehicle(veh8, file & "vehicle_8.cfg", veh8Pos, vehRot2815, -60)
                                                IfTransferVehicle()
                                                Game.FadeScreenOut(500)
                                                Wait(500)
                                                playerPed.CurrentVehicle.Delete()
                                                If Not veh8 = Nothing Then
                                                    playerPed.Position = veh8Pos
                                                    SetIntoVehicle(playerPed, veh8, VehicleSeat.Driver)
                                                Else
                                                    playerPed.Position = veh8Pos
                                                End If
                                                Wait(500)
                                                Game.FadeScreenIn(500)
                                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                            Else
                                                If Not IO.File.Exists(file & "vehicle_9.cfg") Then
                                                    CreateFile(file & "vehicle_9.cfg")
                                                    UpdateGarageVehicle(file & "vehicle_9.cfg", "False")
                                                    LoadGarageVehicle(veh9, file & "vehicle_9.cfg", veh9Pos, vehRot3916, -60)
                                                    IfTransferVehicle()
                                                    Game.FadeScreenOut(500)
                                                    Wait(500)
                                                    playerPed.CurrentVehicle.Delete()
                                                    If Not veh9 = Nothing Then
                                                        playerPed.Position = veh9Pos
                                                        SetIntoVehicle(playerPed, veh9, VehicleSeat.Driver)
                                                    Else
                                                        playerPed.Position = veh9Pos
                                                    End If
                                                    Wait(500)
                                                    Game.FadeScreenIn(500)
                                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                Else
                                                    If Not IO.File.Exists(file & "vehicle_10.cfg") Then
                                                        CreateFile(file & "vehicle_10.cfg")
                                                        UpdateGarageVehicle(file & "vehicle_10.cfg", "False")
                                                        LoadGarageVehicle(veh10, file & "vehicle_10.cfg", veh10Pos, vehRot41017, -60)
                                                        IfTransferVehicle()
                                                        Game.FadeScreenOut(500)
                                                        Wait(500)
                                                        playerPed.CurrentVehicle.Delete()
                                                        If Not veh10 = Nothing Then
                                                            playerPed.Position = veh10Pos
                                                            SetIntoVehicle(playerPed, veh10, VehicleSeat.Driver)
                                                        Else
                                                            playerPed.Position = veh10Pos
                                                        End If
                                                        Wait(500)
                                                        Game.FadeScreenIn(500)
                                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                    Else
                                                        If Not IO.File.Exists(file & "vehicle_11.cfg") Then
                                                            CreateFile(file & "vehicle_11.cfg")
                                                            UpdateGarageVehicle(file & "vehicle_11.cfg", "False")
                                                            LoadGarageVehicle(veh11, file & "vehicle_11.cfg", veh11Pos, vehRot51118, -60)
                                                            IfTransferVehicle()
                                                            Game.FadeScreenOut(500)
                                                            Wait(500)
                                                            playerPed.CurrentVehicle.Delete()
                                                            If Not veh11 = Nothing Then
                                                                playerPed.Position = veh11Pos
                                                                SetIntoVehicle(playerPed, veh11, VehicleSeat.Driver)
                                                            Else
                                                                playerPed.Position = veh11Pos
                                                            End If
                                                            Wait(500)
                                                            Game.FadeScreenIn(500)
                                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                        Else
                                                            If Not IO.File.Exists(file & "vehicle_12.cfg") Then
                                                                CreateFile(file & "vehicle_12.cfg")
                                                                UpdateGarageVehicle(file & "vehicle_12.cfg", "False")
                                                                LoadGarageVehicle(veh12, file & "vehicle_12.cfg", veh12Pos, vehRot1219, -60)
                                                                IfTransferVehicle()
                                                                Game.FadeScreenOut(500)
                                                                Wait(500)
                                                                playerPed.CurrentVehicle.Delete()
                                                                If Not veh12 = Nothing Then
                                                                    playerPed.Position = veh12Pos
                                                                    SetIntoVehicle(playerPed, veh12, VehicleSeat.Driver)
                                                                Else
                                                                    playerPed.Position = veh12Pos
                                                                End If
                                                                Wait(500)
                                                                Game.FadeScreenIn(500)
                                                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                            Else
                                                                If Not IO.File.Exists(file & "vehicle_13.cfg") Then
                                                                    CreateFile(file & "vehicle_13.cfg")
                                                                    UpdateGarageVehicle(file & "vehicle_13.cfg", "False")
                                                                    LoadGarageVehicle(veh13, file & "vehicle_13.cfg", veh13Pos, vehRot0613, -60)
                                                                    IfTransferVehicle()
                                                                    Game.FadeScreenOut(500)
                                                                    Wait(500)
                                                                    playerPed.CurrentVehicle.Delete()
                                                                    If Not veh13 = Nothing Then
                                                                        playerPed.Position = veh13Pos
                                                                        SetIntoVehicle(playerPed, veh13, VehicleSeat.Driver)
                                                                    Else
                                                                        playerPed.Position = veh13Pos
                                                                    End If
                                                                    Wait(500)
                                                                    Game.FadeScreenIn(500)
                                                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                Else
                                                                    If Not IO.File.Exists(file & "vehicle_14.cfg") Then
                                                                        CreateFile(file & "vehicle_14.cfg")
                                                                        UpdateGarageVehicle(file & "vehicle_14.cfg", "False")
                                                                        LoadGarageVehicle(veh14, file & "vehicle_14.cfg", veh14Pos, vehRot1714, -60)
                                                                        IfTransferVehicle()
                                                                        Game.FadeScreenOut(500)
                                                                        Wait(500)
                                                                        playerPed.CurrentVehicle.Delete()
                                                                        If Not veh14 = Nothing Then
                                                                            playerPed.Position = veh14Pos
                                                                            SetIntoVehicle(playerPed, veh14, VehicleSeat.Driver)
                                                                        Else
                                                                            playerPed.Position = veh14Pos
                                                                        End If
                                                                        Wait(500)
                                                                        Game.FadeScreenIn(500)
                                                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                    Else
                                                                        If Not IO.File.Exists(file & "vehicle_15.cfg") Then
                                                                            CreateFile(file & "vehicle_15.cfg")
                                                                            UpdateGarageVehicle(file & "vehicle_15.cfg", "False")
                                                                            LoadGarageVehicle(veh15, file & "vehicle_15.cfg", veh15Pos, vehRot2815, -60)
                                                                            IfTransferVehicle()
                                                                            Game.FadeScreenOut(500)
                                                                            Wait(500)
                                                                            playerPed.CurrentVehicle.Delete()
                                                                            If Not veh15 = Nothing Then
                                                                                playerPed.Position = veh15Pos
                                                                                SetIntoVehicle(playerPed, veh15, VehicleSeat.Driver)
                                                                            Else
                                                                                playerPed.Position = veh15Pos
                                                                            End If
                                                                            Wait(500)
                                                                            Game.FadeScreenIn(500)
                                                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                        Else
                                                                            If Not IO.File.Exists(file & "vehicle_16.cfg") Then
                                                                                CreateFile(file & "vehicle_16.cfg")
                                                                                UpdateGarageVehicle(file & "vehicle_16.cfg", "False")
                                                                                LoadGarageVehicle(veh16, file & "vehicle_16.cfg", veh16Pos, vehRot3916, -60)
                                                                                IfTransferVehicle()
                                                                                Game.FadeScreenOut(500)
                                                                                Wait(500)
                                                                                playerPed.CurrentVehicle.Delete()
                                                                                If Not veh16 = Nothing Then
                                                                                    playerPed.Position = veh16Pos
                                                                                    SetIntoVehicle(playerPed, veh16, VehicleSeat.Driver)
                                                                                Else
                                                                                    playerPed.Position = veh16Pos
                                                                                End If
                                                                                Wait(500)
                                                                                Game.FadeScreenIn(500)
                                                                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                            Else
                                                                                If Not IO.File.Exists(file & "vehicle_17.cfg") Then
                                                                                    CreateFile(file & "vehicle_17.cfg")
                                                                                    UpdateGarageVehicle(file & "vehicle_17.cfg", "False")
                                                                                    LoadGarageVehicle(veh17, file & "vehicle_17.cfg", veh17Pos, vehRot41017, -60)
                                                                                    IfTransferVehicle()
                                                                                    Game.FadeScreenOut(500)
                                                                                    Wait(500)
                                                                                    playerPed.CurrentVehicle.Delete()
                                                                                    If Not veh17 = Nothing Then
                                                                                        playerPed.Position = veh17Pos
                                                                                        SetIntoVehicle(playerPed, veh17, VehicleSeat.Driver)
                                                                                    Else
                                                                                        playerPed.Position = veh17Pos
                                                                                    End If
                                                                                    Wait(500)
                                                                                    Game.FadeScreenIn(500)
                                                                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                                Else
                                                                                    If Not IO.File.Exists(file & "vehicle_18.cfg") Then
                                                                                        CreateFile(file & "vehicle_18.cfg")
                                                                                        UpdateGarageVehicle(file & "vehicle_18.cfg", "False")
                                                                                        LoadGarageVehicle(veh18, file & "vehicle_18.cfg", veh18Pos, vehRot51118, -60)
                                                                                        IfTransferVehicle()
                                                                                        Game.FadeScreenOut(500)
                                                                                        Wait(500)
                                                                                        playerPed.CurrentVehicle.Delete()
                                                                                        If Not veh18 = Nothing Then
                                                                                            playerPed.Position = veh18Pos
                                                                                            SetIntoVehicle(playerPed, veh18, VehicleSeat.Driver)
                                                                                        Else
                                                                                            playerPed.Position = veh18Pos
                                                                                        End If
                                                                                        Wait(500)
                                                                                        Game.FadeScreenIn(500)
                                                                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                                    Else
                                                                                        If Not IO.File.Exists(file & "vehicle_19.cfg") Then
                                                                                            CreateFile(file & "vehicle_19.cfg")
                                                                                            UpdateGarageVehicle(file & "vehicle_19.cfg", "False")
                                                                                            LoadGarageVehicle(veh19, file & "vehicle_19.cfg", veh19Pos, vehRot1219, -60)
                                                                                            IfTransferVehicle()
                                                                                            Game.FadeScreenOut(500)
                                                                                            Wait(500)
                                                                                            playerPed.CurrentVehicle.Delete()
                                                                                            If Not veh19 = Nothing Then
                                                                                                playerPed.Position = veh19Pos
                                                                                                SetIntoVehicle(playerPed, veh19, VehicleSeat.Driver)
                                                                                            Else
                                                                                                playerPed.Position = veh19Pos
                                                                                            End If
                                                                                            Wait(500)
                                                                                            Game.FadeScreenIn(500)
                                                                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                                                                                        Else
                                                                                            UI.ShowSubtitle(GrgFull)
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
            If ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then
                If Not Game.IsLoading Then
                    ElevatorDistance = World.GetDistance(playerPed.Position, Elevator)
                    GarageMarkerDistance = World.GetDistance(playerPed.Position, MenuActivator)

                    If IsIPLActive("imp_sm_15_cargarage_a") Then
                        InteriorID = INMNative.Apartment.GetInteriorID(New Vector3(-1395.882, -480.5163, 56.10049))
                        If Not InteriorID = 0 AndAlso Not InteriorIDList.Contains(InteriorID) Then InteriorIDList.Add(InteriorID)
                    End If

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
                            If Not veh6 = Nothing Then veh6.Delete()
                            If Not veh7 = Nothing Then veh7.Delete()
                            If Not veh8 = Nothing Then veh8.Delete()
                            If Not veh9 = Nothing Then veh9.Delete()
                            If Not veh10 = Nothing Then veh0.Delete()
                            If Not veh11 = Nothing Then veh11.Delete()
                            If Not veh12 = Nothing Then veh12.Delete()
                            If Not veh13 = Nothing Then veh13.Delete()
                            If Not veh14 = Nothing Then veh14.Delete()
                            If Not veh15 = Nothing Then veh15.Delete()
                            If Not veh16 = Nothing Then veh16.Delete()
                            If Not veh17 = Nothing Then veh17.Delete()
                            If Not veh18 = Nothing Then veh18.Delete()
                            If Not veh19 = Nothing Then veh19.Delete()
                        End If
                    End If

                    If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso ElevatorDistance < 3.0 Then
                        DisplayHelpTextThisFrame(EnterElevator & LastLocationName)
                    End If

                    If Not playerPed.IsDead AndAlso GarageMarkerDistance < 1.5 Then
                        DisplayHelpTextThisFrame(ManageGarage)
                    End If

                    ControlsKeyDown()
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ControlsKeyDown()
        On Error Resume Next

        If playerPed.IsInVehicle AndAlso playerPed.CurrentVehicle.Speed > 1.5 AndAlso InteriorID = playerInterior AndAlso IsInGarageVehicle(playerPed) = True Then
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
            ElseIf playerPed.CurrentVehicle = veh6 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_6.cfg")
                PPCV = 6
            ElseIf playerPed.CurrentVehicle = veh7 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_7.cfg")
                PPCV = 7
            ElseIf playerPed.CurrentVehicle = veh8 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_8.cfg")
                PPCV = 8
            ElseIf playerPed.CurrentVehicle = veh9 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_9.cfg")
                PPCV = 9
            ElseIf playerPed.CurrentVehicle = veh10 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_10.cfg")
                PPCV = 10
            ElseIf playerPed.CurrentVehicle = veh11 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_11.cfg")
                PPCV = 11
            ElseIf playerPed.CurrentVehicle = veh12 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_12.cfg")
                PPCV = 12
            ElseIf playerPed.CurrentVehicle = veh13 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_13.cfg")
                PPCV = 13
            ElseIf playerPed.CurrentVehicle = veh14 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_14.cfg")
                PPCV = 14
            ElseIf playerPed.CurrentVehicle = veh15 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_15.cfg")
                PPCV = 15
            ElseIf playerPed.CurrentVehicle = veh16 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_16.cfg")
                PPCV = 16
            ElseIf playerPed.CurrentVehicle = veh17 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_17.cfg")
                PPCV = 17
            ElseIf playerPed.CurrentVehicle = veh18 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_18.cfg")
                PPCV = 18
            ElseIf playerPed.CurrentVehicle = veh19 Then
                WriteCfgValue("Active", "True", CurrentPath & "vehicle_19.cfg")
                PPCV = 19
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

            Brain.TVOn = False
            playerPed.CurrentVehicle.Repair()
            playerPed.CurrentVehicle.Position = lastLocationGarageOutVector
            playerPed.CurrentVehicle.Heading = lastLocationGarageOutHeading
            Wait(500)
            Game.FadeScreenIn(500)
            UnLoadMPDLCMap()
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso ElevatorDistance < 3.0 Then
            Game.FadeScreenOut(500)
            Wait(500)
            RemoveIPL("imp_sm_15_cargarage_a")
            ToggleIPL(ReadCfgValue("MBWipl", saveFile))
            MazeBankWest.EnableOfficeProp()

            playerPed.Position = lastLocationVector
            SinglePlayerApartment.player.LastVehicle.Delete()
            Wait(500)
            Game.FadeScreenIn(500)
        End If

        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso GarageMarkerDistance < 1.5 AndAlso Not Mechanic._menuPool.IsAnyMenuOpen Then
            Mechanic.CreateGarageMenu(CurrentPath, True)
            Mechanic.CreateGarageMenu2("MBWG1Twenty")
            Mechanic.GarageMenu.Visible = True
            World.RenderingCamera = World.CreateCamera(New Vector3(-1396.66, -481.3375, 59.11948), New Vector3(-18.82641, 0, -73.41509), 50)
        End If
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
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
            If Not veh10 = Nothing Then veh10.Delete()
            If Not veh11 = Nothing Then veh11.Delete()
            If Not veh12 = Nothing Then veh12.Delete()
            If Not veh13 = Nothing Then veh13.Delete()
            If Not veh14 = Nothing Then veh14.Delete()
            If Not veh15 = Nothing Then veh15.Delete()
            If Not veh16 = Nothing Then veh16.Delete()
            If Not veh17 = Nothing Then veh17.Delete()
            If Not veh18 = Nothing Then veh18.Delete()
            If Not veh19 = Nothing Then veh19.Delete()
        Catch ex As Exception
        End Try
    End Sub
End Class
