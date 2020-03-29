Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.INMNative

Public Class SinglePlayerApartment
    Inherits Script

    Public Shared player As Player
    Public Shared playerPed As Ped
    Public Shared playerInterior As Integer
    Public Shared playerCash As Integer

    Public Shared playerMap As String
    Public Shared MediumEndLastLocationName As String = Nothing
    Public Shared LowEndLastLocationName As String = Nothing
    Public Shared InteriorIDList As List(Of Integer) = New List(Of Integer)

    Private teleported As Boolean = False
    Private michaelSafeHouse, franklinAuntSafeHouse, franklinSafeHouse, trevorTrailerSafeHouse, trevorPubSafeHouse, floydSafeHouse As Integer

    Public Shared hideHud As Boolean = False
    Public Shared b As Integer = 0
    Public Shared bp As Blip

    Public Sub New()
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            If GetPlayerName() = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = player.Money
            End If

            michaelSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-813.60302734375, 179.47380065918, 72.158325195313))
            franklinAuntSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-9.96562, -1438.54, 31.10151))
            franklinSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(7.1190319061279, 536.61511230469, 176.02365112305))
            trevorTrailerSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(1972.6002197266, 3817.0407714844, 33.426822662354))
            trevorPubSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(96.154197692871, -1290.7312011719, 29.266660690308))
            floydSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-1155.31, -1518.57, 10.63135))

            If OnlineMapEnable Then LoadMPDLCMap()
            If Not Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)) = 0 Then InteriorIDList.Add(Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)))
            If Not Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)) = 0 Then InteriorIDList.Add(Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)))
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SavePosition()
        Try
            Select Case GetPlayerName()
                Case "Michael"
                    saveFile.SetValue(Of Single)("POSITION", "MLastPosX", playerPed.Position.X)
                    saveFile.SetValue(Of Single)("POSITION", "MLastPosY", playerPed.Position.Y)
                    saveFile.SetValue(Of Single)("POSITION", "MLastPosZ", playerPed.Position.Z)
                    saveFile.SetValue(Of String)("POSITION", "MLastInt", playerMap)
                    saveFile.Save()
                Case "Franklin"
                    saveFile.SetValue(Of Single)("POSITION", "FLastPosX", playerPed.Position.X)
                    saveFile.SetValue(Of Single)("POSITION", "FLastPosY", playerPed.Position.Y)
                    saveFile.SetValue(Of Single)("POSITION", "FLastPosZ", playerPed.Position.Z)
                    saveFile.SetValue(Of String)("POSITION", "FLastInt", playerMap)
                    saveFile.Save()
                Case "Trevor"
                    saveFile.SetValue(Of Single)("POSITION", "TLastPosX", playerPed.Position.X)
                    saveFile.SetValue(Of Single)("POSITION", "TLastPosY", playerPed.Position.Y)
                    saveFile.SetValue(Of Single)("POSITION", "TLastPosZ", playerPed.Position.Z)
                    saveFile.SetValue(Of String)("POSITION", "TLastInt", playerMap)
                    saveFile.Save()
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SavePosition2()
        Try
            Select Case GetPlayerName()
                Case "Michael"
                    saveFile.SetValue(Of String)("POSITION", "MLastInt", "None")
                    saveFile.Save()
                Case "Franklin"
                    saveFile.SetValue(Of String)("POSITION", "FLastInt", "None")
                    saveFile.Save()
                Case "Trevor"
                    saveFile.SetValue(Of String)("POSITION", "TLastInt", "None")
                    saveFile.Save()
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String = Nothing
            Dim lastPos As Vector3 = Vector3.Zero

            Select Case GetPlayerName()
                Case "Michael"
                    lastInterior = MLastInt
                    lastPos = MLastPos
                Case "Franklin"
                    lastInterior = FLastInt
                    lastPos = FLastPos
                Case "Trevor"
                    lastInterior = TLastInt
                    lastPos = TLastPos
            End Select

            Select Case lastInterior
                Case "3Alta"
                    SetInteriorActive2(-280.74, -961.5, 91.11) '3 alta street 57
                    Game.Player.Character.Position = lastPos
                    _3AltaStreet.Apartment.IsAtHome = True
                Case "4Integrity"
                    SetInteriorActive2(-37.41, -582.82, 88.71) '4 integrity way 30
                    Game.Player.Character.Position = lastPos
                    _4IntegrityWay.Apartment.IsAtHome = True
                Case "DelPerro"
                    SetInteriorActive2(-1477.14, -538.75, 55.5264) 'del perro 7
                    Game.Player.Character.Position = lastPos
                    DelPerroHeight.Apartment.IsAtHome = True
                Case "Eclipse"
                    SetInteriorActive2(-795.04, 342.37, 206.22) 'eclipse tower 5
                    Game.Player.Character.Position = lastPos
                    EclipseTower.Apartment.IsAtHome = True
                Case "4IntegrityHL"
                    SetInteriorActive2(_4IntegrityWay.ApartmentHL.Interior.X, _4IntegrityWay.ApartmentHL.Interior.Y, _4IntegrityWay.ApartmentHL.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    _4IntegrityWay.Apartment.IsAtHome = True
                Case "DelPerroHL"
                    SetInteriorActive2(DelPerroHeight.ApartmentHL.Interior.X, DelPerroHeight.ApartmentHL.Interior.Y, DelPerroHeight.ApartmentHL.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    DelPerroHeight.Apartment.IsAtHome = True
                Case "EclipseHL"
                    SetInteriorActive2(EclipseTower.ApartmentHL.Interior.X, EclipseTower.ApartmentHL.Interior.Y, EclipseTower.ApartmentHL.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    EclipseTower.Apartment.IsAtHome = True
                Case "RichardHL"
                    SetInteriorActive2(RichardMajestic.ApartmentHL.Interior.X, RichardMajestic.ApartmentHL.Interior.Y, RichardMajestic.ApartmentHL.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    RichardMajestic.Apartment.IsAtHome = True
                Case "TinselHL"
                    SetInteriorActive2(TinselTower.ApartmentHL.Interior.X, TinselTower.ApartmentHL.Interior.Y, TinselTower.ApartmentHL.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    TinselTower.Apartment.IsAtHome = True
                Case "Richard"
                    SetInteriorActive2(-897.197, -369.246, 84.0779) 'richards majestic 4
                    Game.Player.Character.Position = lastPos
                    RichardMajestic.Apartment.IsAtHome = True
                Case "SinnerSt", "CougarAve", "BayCityAve", "0184MiltonRd", "0325SouthRockfordDr", "SouthMoMiltonDr", "0604LasLagunasBlvd", "SpanishAve", "BlvdDelPerro", "PowerSt", "ProsperitySt", "SanVitasSt", "2143LasLagunasBlvd", "TheRoyale", "HangmanAve", "SustanciaRd", "4401ProcopioDr", "4584ProcopioDr"
                    SetInteriorActive2(343.85, -999.08, -99.198) 'midrange apartment
                    Game.Player.Character.Position = lastPos
                Case "Tinsel"
                    SetInteriorActive2(-575.305, 42.3233, 92.2236) 'tinsel tower 29
                    Game.Player.Character.Position = lastPos
                    TinselTower.Apartment.IsAtHome = True
                Case "Weazel"
                    SetInteriorActive2(-909.054, -441.466, 120.205) 'weazel plaza 70
                    Game.Player.Character.Position = lastPos
                    WeazelPlaza.Apartment.IsAtHome = True
                Case "VespucciBlvd", "0112SouthRockfordDr", "ZancudoAve", "PaletoBlvd", "GrapeseedAve"
                    SetInteriorActive2(263.86999, -998.78002, -99.010002) 'low end apartment
                    Game.Player.Character.Position = lastPos
                Case "NConker2044"
                    SetInteriorActive2(NorthConker2044.Apartment.Interior.X, NorthConker2044.Apartment.Interior.Y, NorthConker2044.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    NorthConker2044.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_04_ext1")
                Case "HillcrestA2862"
                    SetInteriorActive2(HillcrestAve2862.Apartment.Interior.X, HillcrestAve2862.Apartment.Interior.Y, HillcrestAve2862.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    HillcrestAve2862.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09c_ext2")
                Case "HillcrestA2868"
                    SetInteriorActive2(HillcrestAve2868.Apartment.Interior.X, HillcrestAve2868.Apartment.Interior.Y, HillcrestAve2868.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    HillcrestAve2868.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09b_ext3")
                Case "WildOats3655"
                    SetInteriorActive2(WildOats3655.Apartment.Interior.X, WildOats3655.Apartment.Interior.Y, WildOats3655.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    WildOats3655.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_05e_ext1")
                Case "NConker2045"
                    SetInteriorActive2(NorthConker2045.Apartment.Interior.X, NorthConker2045.Apartment.Interior.Y, NorthConker2045.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    NorthConker2045.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_04_ext2")
                Case "MiltonR2117"
                    SetInteriorActive2(MiltonRd2117.Apartment.Interior.X, MiltonRd2117.Apartment.Interior.Y, MiltonRd2117.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    MiltonRd2117.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09c_ext3")
                Case "HillcrestA2874"
                    SetInteriorActive2(HillcrestAve2874._Apartment.Interior.X, HillcrestAve2874._Apartment.Interior.Y, HillcrestAve2874._Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    HillcrestAve2874._Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09b_ext2")
                Case "Whispy3677"
                    SetInteriorActive2(Whispymound3677.Apartment.Interior.X, Whispymound3677.Apartment.Interior.Y, Whispymound3677.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    Whispymound3677.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_05c_ext1")
                Case "MadWayne2113"
                    SetInteriorActive2(MadWayne2113.Apartment.Interior.X, MadWayne2113.Apartment.Interior.Y, MadWayne2113.Apartment.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    MadWayne2113.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_12b_ext1")
                Case "EclipsePS1" 'patched 1.10 update
                    ToggleIPL(ETP1ipl, EclipseTower.ApartmentPS1.Interior)
                    SetInteriorActive2(EclipseTower.ApartmentPS1.Interior.X, EclipseTower.ApartmentPS1.Interior.Y, EclipseTower.ApartmentPS1.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    EclipseTower.Apartment.IsAtHome = True
                Case "EclipsePS2"
                    ToggleIPL(ETP2ipl, EclipseTower.ApartmentPS2.Interior)
                    SetInteriorActive2(EclipseTower.ApartmentPS2.Interior.X, EclipseTower.ApartmentPS2.Interior.Y, EclipseTower.ApartmentPS2.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    EclipseTower.Apartment.IsAtHome = True
                Case "EclipsePS3"
                    ToggleIPL(ETP3ipl, EclipseTower.ApartmentPS3.Interior)
                    SetInteriorActive2(EclipseTower.ApartmentPS3.Interior.X, EclipseTower.ApartmentPS3.Interior.Y, EclipseTower.ApartmentPS3.Interior.Z)
                    Game.Player.Character.Position = lastPos
                    EclipseTower.Apartment.IsAtHome = True
                'Case "MazeBankWest" 'added 1.10 update
                '    ToggleIPL(ReadCfgValue("MBWipl", saveFile), MazeBankWest.Apartment.Interior)
                '    SetInteriorActive2(MazeBankWest.Apartment.Interior.X, MazeBankWest.Apartment.Interior.Y, MazeBankWest.Apartment.Interior.Z)
                '   
                '    Game.Player.Character.Position = lastPos
                '    MazeBankWest.Apartment.IsAtHome = True
                Case "None"
                    teleported = True
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            If Not Game.IsLoading Then
                player = Game.Player
                playerPed = Game.Player.Character
                playerInterior = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_FROM_ENTITY, Game.Player.Character)
                If GetPlayerName() = "Player3" Then
                    playerCash = 1000000000
                Else
                    playerCash = player.Money
                End If

                michaelSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-813.60302734375, 179.47380065918, 72.158325195313))
                franklinAuntSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-9.96562, -1438.54, 31.10151))
                franklinSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(7.1190319061279, 536.61511230469, 176.02365112305))
                trevorTrailerSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(1972.6002197266, 3817.0407714844, 33.426822662354))
                trevorPubSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(96.154197692871, -1290.7312011719, 29.266660690308))
                floydSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-1155.31, -1518.57, 10.63135))

                If hideHud Then
                    Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                End If

                If GetPlayerName() = "Player3" Then
                    If Not playerInterior = 0 AndAlso InteriorIDList.Contains(playerInterior) AndAlso Not player.WantedLevel > 0 Then
                        Disable_Switch_Characters()
                        Disable_Weapons()
                        Disable_Controls()
                        If Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, True) Else Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
                        If Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, True) Else Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, False)
                    ElseIf Not playerInterior = 0 AndAlso InteriorIDList.Contains(playerInterior) AndAlso player.WantedLevel > 0 Then
                        Disable_Switch_Characters()
                    Else
                        Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
                    End If
                Else
                    If Not playerInterior = 0 AndAlso InteriorIDList.Contains(playerInterior) AndAlso Not Game.MissionFlag AndAlso Not player.WantedLevel > 0 Then
                        Disable_Switch_Characters()
                        Disable_Weapons()
                        Disable_Controls()
                        If Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, True) Else Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
                        If Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, True) Else Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, False)
                    ElseIf Not playerInterior = 0 AndAlso InteriorIDList.Contains(playerInterior) AndAlso Not Game.MissionFlag AndAlso player.WantedLevel > 0 Then
                        Disable_Switch_Characters()
                    Else
                        Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
                    End If
                End If

                If Not teleported Then
                    If World.GetDistance(playerPed.Position, getPlayerLastLocationCoords) >= 10.0 Then LoadPosition()
                    If InteriorIDList.Contains(playerInterior) Then
                        SavePosition2()
                        teleported = True
                    End If
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Function getPlayerLastLocationCoords() As Vector3
        Dim lastPos As Vector3 = Vector3.Zero

        Select Case GetPlayerName()
            Case "Michael"
                lastPos = MLastPos
            Case "Franklin"
                lastPos = FLastPos
            Case "Trevor"
                lastPos = TLastPos
        End Select

        Return lastPos
    End Function

End Class
