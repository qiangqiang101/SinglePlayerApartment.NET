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
    Public Shared saveFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg"
    Public Shared settingFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\setting.cfg"
    Public Shared langFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Languages\" & Game.Language.ToString & ".cfg"
    Public Shared playerMap As String
    Public Shared MediumEndLastLocationName As String = Nothing
    Public Shared LowEndLastLocationName As String = Nothing
    Public Shared InteriorIDList As List(Of Integer) = New List(Of Integer)

    'Translate
    Public Shared ExitApt, SellApt, EnterGarage, AptOptions, Garage, GrgOptions, GrgRemove, GrgRemoveAndDrive, GrgMove, GrgSell, GrgSelectVeh, GrgTooHot, GrgPlate, GrgRename, GrgTransfer, _Mechanic, _Pegasus, ChooseApt As String
    Public Shared ModernStyle, MoodyStyle, VibrantStyle, SharpStyle, MonochromeStyle, SeductiveStyle, RegalStyle, AquaStyle, ChooseVeh, ChooseVehDesc, ReturnVeh, AptStyle, _Phone, PegasusDeliver, PegasusDelete, CannotStore As String
    Public Shared GrgFull, MechanicBill, EnterElevator, ExitGarage, ManageGarage, Maze, Fleeca, BOL, ForSale, PropPurchased, InsFundApartment, EnterApartment, SaveGame, ExitApartment, ChangeClothes, _EnterGarage As String
    Public Shared Insurance1, Insurance2, Insurance3, Insurance4, MorsMutual As String
    Public Shared ExecRich, ExecCool, ExecContrast, OldSpiClassical, OldSpiVintage, OldSpiWarms, PowBrkConservative, PowBrkPolished, PowBrkIce, OfficeGarage1, OfficeGarage2, OfficeGarage3, OfficeAutoShop As String

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

            Translate()

            LoadSettingFromCFG()
            If My.Settings.AlwaysEnableMPMaps = True Then LoadMPDLCMap()
            If Not Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)) = 0 Then InteriorIDList.Add(Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)))
            If Not Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)) = 0 Then InteriorIDList.Add(Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)))
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SavePosition()
        Try
            If GetPlayerName() = "Michael" Then
                WriteCfgValue("MlastInterior", playerMap, saveFile)
                WriteCfgValue("MlastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("MlastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("MlastPosZ", playerPed.Position.Z.ToString, saveFile)
            ElseIf GetPlayerName() = "Franklin" Then
                WriteCfgValue("FlastInterior", playerMap, saveFile)
                WriteCfgValue("FlastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("FlastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("FlastPosZ", playerPed.Position.Z.ToString, saveFile)
            ElseIf GetPlayerName() = "Trevor" Then
                WriteCfgValue("TlastInterior", playerMap, saveFile)
                WriteCfgValue("TlastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("TlastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("TlastPosZ", playerPed.Position.Z.ToString, saveFile)
            ElseIf GetPlayerName() = "Player3" Then
                WriteCfgValue("3lastInterior", playerMap, saveFile)
                WriteCfgValue("3lastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("3lastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("3lastPosZ", playerPed.Position.Z.ToString, saveFile)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SavePosition2()
        Try
            If GetPlayerName() = "Michael" Then
                WriteCfgValue("MlastInterior", "None", saveFile)
            ElseIf GetPlayerName() = "Franklin" Then
                WriteCfgValue("FlastInterior", "None", saveFile)
            ElseIf GetPlayerName() = "Trevor" Then
                WriteCfgValue("TlastInterior", "None", saveFile)
            ElseIf GetPlayerName() = "Player3" Then
                WriteCfgValue("3lastInterior", "None", saveFile)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadSettingFromCFG()
        Try
            My.Settings.CreateFileMethod = ReadCfgValue("CreateFileMethod", settingFile)
            My.Settings.MlastPosX = Convert.ToSingle(ReadCfgValue("MlastPosX", saveFile))
            My.Settings.MlastPosY = Convert.ToSingle(ReadCfgValue("MlastPosY", saveFile))
            My.Settings.MlastPosZ = Convert.ToSingle(ReadCfgValue("MlastPosZ", saveFile))
            My.Settings.FlastPosX = Convert.ToSingle(ReadCfgValue("FlastPosX", saveFile))
            My.Settings.FlastPosY = Convert.ToSingle(ReadCfgValue("FlastPosY", saveFile))
            My.Settings.FlastPosZ = Convert.ToSingle(ReadCfgValue("FlastPosZ", saveFile))
            My.Settings.TlastPosX = Convert.ToSingle(ReadCfgValue("TlastPosX", saveFile))
            My.Settings.TlastPosY = Convert.ToSingle(ReadCfgValue("TlastPosY", saveFile))
            My.Settings.TlastPosZ = Convert.ToSingle(ReadCfgValue("TlastPosZ", saveFile))
            Dim AlwaysEnableMPMaps As String = ReadCfgValue("AlwaysEnableMPMaps", settingFile)
            If AlwaysEnableMPMaps = "True" Then
                My.Settings.AlwaysEnableMPMaps = True
            Else
                My.Settings.AlwaysEnableMPMaps = False
            End If
            Dim HasLowriderUpdate As Integer = Game.Version
            If HasLowriderUpdate < 13 Then
                My.Settings.HasLowriderUpdate = False
            Else
                My.Settings.HasLowriderUpdate = True
            End If
            Dim NeverEnableMPMaps As String = ReadCfgValue("NeverEnableMPMaps", settingFile)
            If NeverEnableMPMaps = "True" Then
                My.Settings.NeverEnableMPMaps = True
            Else
                My.Settings.NeverEnableMPMaps = False
            End If
            My.Settings.VehicleSpawn = ReadCfgValue("VehicleSpawn", settingFile)
            My.Settings.Volume = ReadCfgValue("Volume", settingFile)
            My.Settings.PreviewPointX = ReadCfgValue("PointX", settingFile)
            My.Settings.PreviewPointY = ReadCfgValue("PointY", settingFile)
            My.Settings.ThreeAltaStreet = ReadCfgValue("3AltaStreet", settingFile)
            My.Settings.FourIntegrityWay = ReadCfgValue("4IntegrityWay", settingFile)
            My.Settings.DelPerroHeight = ReadCfgValue("DelPerroHeights", settingFile)
            My.Settings.DreamTower = ReadCfgValue("DreamTower", settingFile)
            My.Settings.EclipseTower = ReadCfgValue("EclipseTower", settingFile)
            My.Settings.RichardMajestic = ReadCfgValue("RichardMajestic", settingFile)
            My.Settings.TinselTower = ReadCfgValue("TinselTower", settingFile)
            My.Settings.VespucciBlvd = ReadCfgValue("VespucciBlvd", settingFile)
            My.Settings.WeazelPlaza = ReadCfgValue("WeazelPlaza", settingFile)
            My.Settings.Hillcrest2862 = ReadCfgValue("2862Hillcrest", settingFile)
            My.Settings.Hillcrest2868 = ReadCfgValue("2868Hillcrest", settingFile)
            My.Settings.Hillcrest2874 = ReadCfgValue("2874Hillcrest", settingFile)
            My.Settings.MadWayne2113 = ReadCfgValue("2113MadWayne", settingFile)
            My.Settings.MiltonRd2117 = ReadCfgValue("2117MiltonRd", settingFile)
            My.Settings.NorthConker2044 = ReadCfgValue("2044NorthConker", settingFile)
            My.Settings.NorthConker2045 = ReadCfgValue("2045NorthConker", settingFile)
            My.Settings.Whispymound3677 = ReadCfgValue("3677Whispymound", settingFile)
            My.Settings.WildOats3655 = ReadCfgValue("3655WildOats", settingFile)
            My.Settings.CougarAve = ReadCfgValue("CougarAve", settingFile)
            My.Settings.BayCityAve = ReadCfgValue("BayCityAve", settingFile)
            My.Settings.MiltonRd0184 = ReadCfgValue("0184MiltonRd", settingFile)
            My.Settings.SouthRockfordDr0325 = ReadCfgValue("0325SouthRockfordDr", settingFile)
            My.Settings.SouthMoMiltonDr = ReadCfgValue("SouthMoMiltonDr", settingFile)
            My.Settings.LasLagunasBlvd0604 = ReadCfgValue("0604LasLagunasBlvd", settingFile)
            My.Settings.SpanishAve = ReadCfgValue("SpanishAve", settingFile)
            My.Settings.BlvdDelPerro = ReadCfgValue("BlvdDelPerro", settingFile)
            My.Settings.PowerSt = ReadCfgValue("PowerSt", settingFile)
            My.Settings.ProsperitySt = ReadCfgValue("ProsperitySt", settingFile)
            My.Settings.SanVitasSt = ReadCfgValue("SanVitasSt", settingFile)
            My.Settings.LasLagunasBlvd2143 = ReadCfgValue("2143LasLagunasBlvd", settingFile)
            My.Settings.TheRoyale = ReadCfgValue("TheRoyale", settingFile)
            My.Settings.HangmanAve = ReadCfgValue("HangmanAve", settingFile)
            My.Settings.SustanciaRd = ReadCfgValue("SustanciaRd", settingFile)
            My.Settings.ProcopioDr4401 = ReadCfgValue("4401ProcopioDr", settingFile)
            My.Settings.ProcopioDr4584 = ReadCfgValue("4584ProcopioDr", settingFile)
            My.Settings.SouthRockfordDr0112 = ReadCfgValue("0112SouthRockfordDr", settingFile)
            My.Settings.ZancudoAve = ReadCfgValue("ZancudoAve", settingFile)
            My.Settings.PaletoBlvd = ReadCfgValue("PaletoBlvd", settingFile)
            My.Settings.GrapeseedAve = ReadCfgValue("GrapeseedAve", settingFile)
            My.Settings.MechanicPad = ReadCfgValue("PadMechanic", settingFile)
            My.Settings.SecondMechanicPad = ReadCfgValue("SecondPadMechanic", settingFile)
            My.Settings.RefreshGrgVehs = ReadCfgValue("RefreshGarageVehicles", settingFile)
            My.Settings.Save()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String = Nothing
            Dim lastPosX, lastPosY, lastPosZ As Single
            If GetPlayerName() = "Michael" Then
                lastInterior = ReadCfgValue("MlastInterior", saveFile)
                lastPosX = My.Settings.MlastPosX
                lastPosY = My.Settings.MlastPosY
                lastPosZ = My.Settings.MlastPosZ
            ElseIf GetPlayerName() = "Franklin" Then
                lastInterior = ReadCfgValue("FlastInterior", saveFile)
                lastPosX = My.Settings.FlastPosX
                lastPosY = My.Settings.FlastPosY
                lastPosZ = My.Settings.FlastPosZ
            ElseIf GetPlayerName() = "Trevor" Then
                lastInterior = ReadCfgValue("TlastInterior", saveFile)
                lastPosX = My.Settings.TlastPosX
                lastPosY = My.Settings.TlastPosY
                lastPosZ = My.Settings.TlastPosZ
            ElseIf GetPlayerName() = "Player3" Then
                lastInterior = ReadCfgValue("3lastInterior", saveFile)
                lastPosX = My.Settings.TlastPosX
                lastPosY = My.Settings.TlastPosY
                lastPosZ = My.Settings.TlastPosZ
            End If
            Select Case lastInterior
                Case "3Alta"
                    SetInteriorActive2(-280.74, -961.5, 91.11) '3 alta street 57
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    _3AltaStreet.Apartment.IsAtHome = True
                Case "4Integrity"
                    SetInteriorActive2(-37.41, -582.82, 88.71) '4 integrity way 30
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    _4IntegrityWay.Apartment.IsAtHome = True
                Case "DelPerro"
                    SetInteriorActive2(-1477.14, -538.75, 55.5264) 'del perro 7
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    DelPerroHeight.Apartment.IsAtHome = True
                Case "Eclipse"
                    SetInteriorActive2(-795.04, 342.37, 206.22) 'eclipse tower 5
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "4IntegrityHL"
                    SetInteriorActive2(_4IntegrityWay.ApartmentHL.Interior.X, _4IntegrityWay.ApartmentHL.Interior.Y, _4IntegrityWay.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    _4IntegrityWay.Apartment.IsAtHome = True
                Case "DelPerroHL"
                    SetInteriorActive2(DelPerroHeight.ApartmentHL.Interior.X, DelPerroHeight.ApartmentHL.Interior.Y, DelPerroHeight.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    DelPerroHeight.Apartment.IsAtHome = True
                Case "EclipseHL"
                    SetInteriorActive2(EclipseTower.ApartmentHL.Interior.X, EclipseTower.ApartmentHL.Interior.Y, EclipseTower.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "RichardHL"
                    SetInteriorActive2(RichardMajestic.ApartmentHL.Interior.X, RichardMajestic.ApartmentHL.Interior.Y, RichardMajestic.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    RichardMajestic.Apartment.IsAtHome = True
                Case "TinselHL"
                    SetInteriorActive2(TinselTower.ApartmentHL.Interior.X, TinselTower.ApartmentHL.Interior.Y, TinselTower.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    TinselTower.Apartment.IsAtHome = True
                Case "Richard"
                    SetInteriorActive2(-897.197, -369.246, 84.0779) 'richards majestic 4
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    RichardMajestic.Apartment.IsAtHome = True
                Case "SinnerSt", "CougarAve", "BayCityAve", "0184MiltonRd", "0325SouthRockfordDr", "SouthMoMiltonDr", "0604LasLagunasBlvd", "SpanishAve", "BlvdDelPerro", "PowerSt", "ProsperitySt", "SanVitasSt", "2143LasLagunasBlvd", "TheRoyale", "HangmanAve", "SustanciaRd", "4401ProcopioDr", "4584ProcopioDr"
                    SetInteriorActive2(343.85, -999.08, -99.198) 'midrange apartment
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Tinsel"
                    SetInteriorActive2(-575.305, 42.3233, 92.2236) 'tinsel tower 29
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    TinselTower.Apartment.IsAtHome = True
                Case "Weazel"
                    SetInteriorActive2(-909.054, -441.466, 120.205) 'weazel plaza 70
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    WeazelPlaza.Apartment.IsAtHome = True
                Case "VespucciBlvd", "0112SouthRockfordDr", "ZancudoAve", "PaletoBlvd", "GrapeseedAve"
                    SetInteriorActive2(263.86999, -998.78002, -99.010002) 'low end apartment
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "NConker2044"
                    SetInteriorActive2(NorthConker2044.Apartment.Interior.X, NorthConker2044.Apartment.Interior.Y, NorthConker2044.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    NorthConker2044.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_04_ext1")
                Case "HillcrestA2862"
                    SetInteriorActive2(HillcrestAve2862.Apartment.Interior.X, HillcrestAve2862.Apartment.Interior.Y, HillcrestAve2862.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    HillcrestAve2862.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09c_ext2")
                Case "HillcrestA2868"
                    SetInteriorActive2(HillcrestAve2868.Apartment.Interior.X, HillcrestAve2868.Apartment.Interior.Y, HillcrestAve2868.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    HillcrestAve2868.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09b_ext3")
                Case "WildOats3655"
                    SetInteriorActive2(WildOats3655.Apartment.Interior.X, WildOats3655.Apartment.Interior.Y, WildOats3655.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    WildOats3655.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_05e_ext1")
                Case "NConker2045"
                    SetInteriorActive2(NorthConker2045.Apartment.Interior.X, NorthConker2045.Apartment.Interior.Y, NorthConker2045.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    NorthConker2045.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_04_ext2")
                Case "MiltonR2117"
                    SetInteriorActive2(MiltonRd2117.Apartment.Interior.X, MiltonRd2117.Apartment.Interior.Y, MiltonRd2117.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    MiltonRd2117.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09c_ext3")
                Case "HillcrestA2874"
                    SetInteriorActive2(HillcrestAve2874._Apartment.Interior.X, HillcrestAve2874._Apartment.Interior.Y, HillcrestAve2874._Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    HillcrestAve2874._Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09b_ext2")
                Case "Whispy3677"
                    SetInteriorActive2(Whispymound3677.Apartment.Interior.X, Whispymound3677.Apartment.Interior.Y, Whispymound3677.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    Whispymound3677.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_05c_ext1")
                Case "MadWayne2113"
                    SetInteriorActive2(MadWayne2113.Apartment.Interior.X, MadWayne2113.Apartment.Interior.Y, MadWayne2113.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    MadWayne2113.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_12b_ext1")
                Case "EclipsePS1"
                    SetInteriorActive2(EclipseTower.ApartmentPS1.Interior.X, EclipseTower.ApartmentPS1.Interior.Y, EclipseTower.ApartmentPS1.Interior.Z)
                    ToggleIPL(ReadCfgValue("ETP1ipl", saveFile), EclipseTower.ApartmentPS1.Interior)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "EclipsePS2"
                    SetInteriorActive2(EclipseTower.ApartmentPS2.Interior.X, EclipseTower.ApartmentPS2.Interior.Y, EclipseTower.ApartmentPS2.Interior.Z)
                    ToggleIPL(ReadCfgValue("ETP2ipl", saveFile), EclipseTower.ApartmentPS2.Interior)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "EclipsePS3"
                    SetInteriorActive2(EclipseTower.ApartmentPS3.Interior.X, EclipseTower.ApartmentPS3.Interior.Y, EclipseTower.ApartmentPS3.Interior.Z)
                    ToggleIPL(ReadCfgValue("ETP3ipl", saveFile), EclipseTower.ApartmentPS3.Interior)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
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
        Dim lastPosX, lastPosY, lastPosZ As Single

        Select Case GetPlayerName()
            Case "Michael"
                lastPosX = My.Settings.MlastPosX
                lastPosY = My.Settings.MlastPosY
                lastPosZ = My.Settings.MlastPosZ
            Case "Franklin"
                lastPosX = My.Settings.FlastPosX
                lastPosY = My.Settings.FlastPosY
                lastPosZ = My.Settings.FlastPosZ
            Case "Trevor"
                lastPosX = My.Settings.TlastPosX
                lastPosY = My.Settings.TlastPosY
                lastPosZ = My.Settings.TlastPosZ
            Case "Player3"
                lastPosX = My.Settings.TlastPosX
                lastPosY = My.Settings.TlastPosY
                lastPosZ = My.Settings.TlastPosZ
        End Select

        Return New Vector3(lastPosX, lastPosY, lastPosZ)
    End Function

End Class
