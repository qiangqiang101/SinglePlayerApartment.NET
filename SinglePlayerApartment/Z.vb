Imports System.Windows.Forms
Imports GTA
Imports SinglePlayerApartment.SinglePlayerApartment

Public Class Z
    Inherits Script

    Private ReloadScripts As Boolean = False

    Public Sub New()
        Try
            SinglePlayerApartment.player = Game.Player
            playerPed = Game.Player.Character
            playerHash = SinglePlayerApartment.player.Character.Model.GetHashCode().ToString
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
            If playerName = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = SinglePlayerApartment.player.Money
            End If

            'New Language
            Website.BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
            Website.DockTease = ReadCfgValue("DockTease", langFile)
            Website.LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
            Website.ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
            Website.PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
            Website.SouthernSA = ReadCfgValue("SouthernSA", langFile)
            Website.WarstockCache = ReadCfgValue("WarstockCache", langFile)
            ExitApt = ReadCfgValue("ExitApt", langFile)
            SellApt = ReadCfgValue("SellApt", langFile)
            EnterGarage = ReadCfgValue("EnterGarage", langFile)
            AptOptions = ReadCfgValue("AptOptions", langFile)
            Garage = ReadCfgValue("Garage", langFile)
            GrgOptions = ReadCfgValue("GrgOptions", langFile)
            GrgRemove = ReadCfgValue("GrgRemove", langFile)
            GrgRemoveAndDrive = ReadCfgValue("GrgRemoveAndDrive", langFile)
            GrgMove = ReadCfgValue("GrgMove", langFile)
            GrgSell = ReadCfgValue("GrgSell", langFile)
            GrgSelectVeh = ReadCfgValue("GrgSelectVeh", langFile)
            GrgTooHot = ReadCfgValue("GrgTooHot", langFile)
            GrgPlate = ReadCfgValue("GrgPlate", langFile)
            GrgRename = ReadCfgValue("GrgRename", langFile)
            GrgTransfer = ReadCfgValue("GrgTransfer", langFile)
            _Mechanic = ReadCfgValue("_Mechanic", langFile)
            _Pegasus = ReadCfgValue("_Pegasus", langFile)
            PegasusDeliver = ReadCfgValue("PegasusDeliver", langFile)
            PegasusDelete = ReadCfgValue("PegasusDelete", langFile)
            _Phone = ReadCfgValue("_Phone", langFile)
            ChooseApt = ReadCfgValue("ChooseApt", langFile)
            ChooseVeh = ReadCfgValue("ChooseVeh", langFile)
            ChooseVehDesc = ReadCfgValue("ChooseVehDesc", langFile)
            ReturnVeh = ReadCfgValue("ReturnVeh", langFile)
            AptStyle = ReadCfgValue("AptStyle", langFile)
            Reach10 = ReadCfgValue("Reach10", langFile)
            MechanicBill = ReadCfgValue("MechanicBill", langFile)
            GrgFull = ReadCfgValue("GrgFull", langFile)
            Maze = ReadCfgValue("Maze", langFile)
            Fleeca = ReadCfgValue("Fleeca", langFile)
            BOL = ReadCfgValue("BOL", langFile)
            ForSale = ReadCfgValue("ForSale", langFile)
            PropPurchased = ReadCfgValue("PropPurchased", langFile)
            InsFundApartment = ReadCfgValue("InsFundApartment", langFile)
            EnterApartment = ReadCfgValue("EnterApartment", langFile)
            SaveGame = ReadCfgValue("SaveGame", langFile)
            ExitApartment = ReadCfgValue("ExitApartment", langFile)
            ChangeClothes = ReadCfgValue("ChangeClothes", langFile)
            _EnterGarage = ReadCfgValue("_EnterGarage", langFile)
            CannotStore = ReadCfgValue("CannotStore", langFile)
            'End Language

            'Save File Generate or Migration
            If Not IO.File.Exists(Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg") Then
                Dim MySave As String = Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg"
                Dim OldSave1 As String = Application.StartupPath & "\scripts\SinglePlayerApartment\save.cfg"
                Dim OldSave2 As String = Application.StartupPath & "\scripts\SinglePlayerApartment\save2.cfg"
                Dim OldSave3 As String = Application.StartupPath & "\scripts\SinglePlayerApartment\save3.cfg"

                'Create Save File
                IO.File.WriteAllText(MySave, My.Resources.MySave)

                'Migrate Save1
                If IO.File.Exists(OldSave1) Then
                    WriteCfgValue("3ASowner", ReadCfgValue("3ASowner", OldSave1), MySave)
                    WriteCfgValue("4IWowner", ReadCfgValue("4IWowner", OldSave1), MySave)
                    WriteCfgValue("DPHwoner", ReadCfgValue("DPHwoner", OldSave1), MySave)
                    WriteCfgValue("DPHHLowner", ReadCfgValue("DPHHLowner", OldSave1), MySave)
                    WriteCfgValue("ETowner", ReadCfgValue("ETowner", OldSave1), MySave)
                    WriteCfgValue("4IWHLowner", ReadCfgValue("4IWHLowner", OldSave1), MySave)
                    WriteCfgValue("ETHLowner", ReadCfgValue("ETHLowner", OldSave1), MySave)
                    WriteCfgValue("RMHLowner", ReadCfgValue("RMHLowner", OldSave1), MySave)
                    WriteCfgValue("TTHLowner", ReadCfgValue("TTHLowner", OldSave1), MySave)
                    WriteCfgValue("RMowner", ReadCfgValue("RMowner", OldSave1), MySave)
                    WriteCfgValue("SSowner", ReadCfgValue("SSowner", OldSave1), MySave)
                    WriteCfgValue("TTowner", ReadCfgValue("TTowner", OldSave1), MySave)
                    WriteCfgValue("WPowner", ReadCfgValue("WPowner", OldSave1), MySave)
                    WriteCfgValue("MlastInterior", ReadCfgValue("MlastInterior", OldSave1), MySave)
                    WriteCfgValue("MlastPosX", ReadCfgValue("MlastPosX", OldSave1), MySave)
                    WriteCfgValue("MlastPosY", ReadCfgValue("MlastPosY", OldSave1), MySave)
                    WriteCfgValue("MlastPosZ", ReadCfgValue("MlastPosZ", OldSave1), MySave)
                    WriteCfgValue("FlastInterior", ReadCfgValue("FlastInterior", OldSave1), MySave)
                    WriteCfgValue("FlastPosX", ReadCfgValue("FlastPosX", OldSave1), MySave)
                    WriteCfgValue("FlastPosY", ReadCfgValue("FlastPosY", OldSave1), MySave)
                    WriteCfgValue("FlastPosZ", ReadCfgValue("FlastPosZ", OldSave1), MySave)
                    WriteCfgValue("TlastInterior", ReadCfgValue("TlastInterior", OldSave1), MySave)
                    WriteCfgValue("TlastPosX", ReadCfgValue("TlastPosX", OldSave1), MySave)
                    WriteCfgValue("TlastPosY", ReadCfgValue("TlastPosY", OldSave1), MySave)
                    WriteCfgValue("TlastPosZ", ReadCfgValue("TlastPosZ", OldSave1), MySave)
                    WriteCfgValue("3lastInterior", ReadCfgValue("3lastInterior", OldSave1), MySave)
                    WriteCfgValue("3lastPosX", ReadCfgValue("3lastPosX", OldSave1), MySave)
                    WriteCfgValue("3lastPosY", ReadCfgValue("3lastPosY", OldSave1), MySave)
                    WriteCfgValue("3lastPosZ", ReadCfgValue("3lastPosZ", OldSave1), MySave)
                    IO.File.Delete(OldSave1)
                End If

                'Migrate Save2
                If IO.File.Exists(OldSave2) Then
                    WriteCfgValue("VPBowner", ReadCfgValue("VPBowner", OldSave2), MySave)
                    WriteCfgValue("2044NCowner", ReadCfgValue("2044NCowner", OldSave2), MySave)
                    WriteCfgValue("2862HAowner", ReadCfgValue("2862HAowner", OldSave2), MySave)
                    WriteCfgValue("2868HAowner", ReadCfgValue("2868HAowner", OldSave2), MySave)
                    WriteCfgValue("3655WODowner", ReadCfgValue("3655WODowner", OldSave2), MySave)
                    WriteCfgValue("2045NCowner", ReadCfgValue("2045NCowner", OldSave2), MySave)
                    WriteCfgValue("2117MRowner", ReadCfgValue("2117MRowner", OldSave2), MySave)
                    WriteCfgValue("2874HAowner", ReadCfgValue("2874HAowner", OldSave2), MySave)
                    WriteCfgValue("3677WMDowner", ReadCfgValue("3677WMDowner", OldSave2), MySave)
                    WriteCfgValue("2113MWTowner", ReadCfgValue("2113MWTowner", OldSave2), MySave)
                    WriteCfgValue("ETP1owner", ReadCfgValue("ETP1owner", OldSave2), MySave)
                    WriteCfgValue("ETP2owner", ReadCfgValue("ETP2owner", OldSave2), MySave)
                    WriteCfgValue("ETP3owner", ReadCfgValue("ETP3owner", OldSave2), MySave)
                    WriteCfgValue("ETP1ipl", ReadCfgValue("ETP1ipl", OldSave2), MySave)
                    WriteCfgValue("ETP2ipl", ReadCfgValue("ETP2ipl", OldSave2), MySave)
                    WriteCfgValue("ETP3ipl", ReadCfgValue("ETP3ipl", OldSave2), MySave)
                    IO.File.Delete(OldSave2)
                End If

                'Migrate Save3
                If IO.File.Exists(OldSave3) Then
                    WriteCfgValue("CAowner", ReadCfgValue("CAowner", OldSave3), MySave)
                    WriteCfgValue("BCAowner", ReadCfgValue("BCAowner", OldSave3), MySave)
                    WriteCfgValue("0184MRowner", ReadCfgValue("0184MRowner", OldSave3), MySave)
                    WriteCfgValue("0325SRDowner", ReadCfgValue("0325SRDowner", OldSave3), MySave)
                    WriteCfgValue("SMMowner", ReadCfgValue("SMMowner", OldSave3), MySave)
                    WriteCfgValue("0604LLBowner", ReadCfgValue("0604LLBowner", OldSave3), MySave)
                    WriteCfgValue("SAonwer", ReadCfgValue("SAonwer", OldSave3), MySave)
                    WriteCfgValue("BDPowner", ReadCfgValue("BDPowner", OldSave3), MySave)
                    WriteCfgValue("PSowner", ReadCfgValue("PSowner", OldSave3), MySave)
                    WriteCfgValue("PPSowner", ReadCfgValue("PPSowner", OldSave3), MySave)
                    WriteCfgValue("SVSowner", ReadCfgValue("SVSowner", OldSave3), MySave)
                    WriteCfgValue("2143LLBowner", ReadCfgValue("2143LLBowner", OldSave3), MySave)
                    WriteCfgValue("TRowner", ReadCfgValue("TRowner", OldSave3), MySave)
                    WriteCfgValue("HAowner", ReadCfgValue("HAowner", OldSave3), MySave)
                    WriteCfgValue("SRowner", ReadCfgValue("SRowner", OldSave3), MySave)
                    WriteCfgValue("4401PDowner", ReadCfgValue("4401PDowner", OldSave3), MySave)
                    WriteCfgValue("4584PDowner", ReadCfgValue("4584PDowner", OldSave3), MySave)
                    WriteCfgValue("0112SRDowner", ReadCfgValue("0112SRDowner", OldSave3), MySave)
                    WriteCfgValue("ZAowner", ReadCfgValue("ZAowner", OldSave3), MySave)
                    WriteCfgValue("PBowner", ReadCfgValue("PBowner", OldSave3), MySave)
                    WriteCfgValue("GAowner", ReadCfgValue("GAowner", OldSave3), MySave)
                    IO.File.Delete(OldSave3)

                    'Reload Scripts
                    ReloadScripts = True
                End If
            End If

            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then EclipseTower.CreateEclipseTower()
            If ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then _3AltaStreet.Create3AltaStreet()
            If ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then _4IntegrityWay.Create4IntegrityWay()
            If ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then DelPerroHeight.CreateDelPerroHeight()
            If ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then RichardMajestic.CreateRichardsMajestic()
            If ReadCfgValue("TinselTower", settingFile) = "Enable" Then TinselTower.CreateTinselTower()
            If ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then WeazelPlaza.CreateWeazelPlaza()
            If ReadCfgValue("DreamTower", settingFile) = "Enable" Then DreamTower.CreateDreamTower()
            If ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then VespucciBlvd.CreateVespucciBlvd()
            If ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then NorthConker2044.CreateNorthConker2044()
            If ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then HillcrestAve2862.CreateHillcrestAve2862()
            If ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then HillcrestAve2868.CreateHillcrestAve2868()
            If ReadCfgValue("3655WildOats", settingFile) = "Enable" Then WildOats3655.CreateWildOats3655()
            If ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then NorthConker2045.CreateNorthConker2045()
            If ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then MiltonRd2117.CreateMiltonRoad2117()
            If ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then HillcrestAve2874.CreateHillcrestAve2874()
            If ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then Whispymound3677.CreateWhispymound3677()
            If ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then MadWayne2113.CreateMadWayne2113()
            If ReadCfgValue("CougarAve", settingFile) = "Enable" Then CougarAve.CreateCougarAve()
            If ReadCfgValue("BayCityAve", settingFile) = "Enable" Then BayCityAve.CreateBayCityAve()
            If ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then MiltonRd0184.Create0184MiltonRoad()
            If ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then SouthRockfordDrive0325.Create0325SouthRockfordDr()
            If ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then SouthMoMiltonDr.CreateSouthMoMiltonDr()
            If ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then LasLagunasBlvd0604.Create0604LasLagunasBlvd()
            If ReadCfgValue("SpanishAve", settingFile) = "Enable" Then SpanishAve.CreateSpanishAve()
            If ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then BlvdDelPerro.CreateBlvdDelPerro()
            If ReadCfgValue("PowerSt", settingFile) = "Enable" Then PowerSt.CreatePowerSt()
            If ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then ProsperitySt.CreateProsperitySt()
            If ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then SanVitasSt.CreateSanVitasSt()
            If ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then LasLagunasBlvd2143.Create2143LasLagunasBlvd()
            If ReadCfgValue("TheRoyale", settingFile) = "Enable" Then TheRoyale.CreateTheRoyale()
            If ReadCfgValue("HangmanAve", settingFile) = "Enable" Then HangmanAve.CreateHangmanAve()
            If ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then SustanciaRd.CreateSustanciaRd()
            If ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then ProcopioDr4401.Create4401ProcopioDr()
            If ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then ProcopioDr4584.Create4584ProcopioDr()
            If ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then SouthRockfordDr0112.Create0112SouthRockfordDr()
            If ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then ZancudoAve.CreateZancudoAve()
            If ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then PaletoBlvd.CreatePaletoBlvd()
            If ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then GrapeseedAve.CreateGrapeseedAve()
            LoadPosition()

            'If System.IO.File.Exists(Application.StartupPath & "\scripts\SinglePlayerApartment\spa.key") Then
            '    Dim F2S As String = Nothing
            '    Using textReader As New System.IO.StreamReader(Application.StartupPath & "\scripts\SinglePlayerApartment\spa.key")
            '        F2S = textReader.ReadToEnd
            '    End Using
            '    If Resources.Decode(F2S) <> Game.Player.Name Then
            '        Dim IE As SHDocVw.InternetExplorer = New SHDocVw.InternetExplorer()
            '        IE.Navigate("http://notmental.ml/spa/")
            '        IE.ToolBar = 0
            '        IE.AddressBar = False
            '        IE.Visible = True
            '        IE.Silent = True
            '    End If
            'Else
            '    Dim IE As SHDocVw.InternetExplorer = New SHDocVw.InternetExplorer()
            '    IE.Navigate("http://notmental.ml/spa/")
            '    IE.ToolBar = 0
            '    IE.AddressBar = False
            '    IE.Visible = True
            '    IE.Silent = True
            'End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles MyBase.Tick
        Try
            If ReloadScripts Then
                Resources.DrawText("Single Player Apartment Save Files Created or Updated, Please press Insert(INS) key to take effect.", New System.Drawing.PointF(Game.ScreenResolution.Width / 2, Game.ScreenResolution.Height / 2), 0.8, System.Drawing.Color.White, Resources.GTAFont.Title, Resources.GTAFontAlign.Center, Resources.GTAFontStyleOptions.DropShadow)
            End If

            If Game.MissionFlag Or Game.Player.WantedLevel > 1 Then
                If Not _3AltaStreet.Apartment.AptBlip Is Nothing Then _3AltaStreet.Apartment.AptBlip.Alpha = 0
                If Not _3AltaStreet.Apartment.GrgBlip Is Nothing Then _3AltaStreet.Apartment.GrgBlip.Alpha = 0
                If Not _4IntegrityWay.Apartment.AptBlip Is Nothing Then _4IntegrityWay.Apartment.AptBlip.Alpha = 0
                If Not _4IntegrityWay.Apartment.GrgBlip Is Nothing Then _4IntegrityWay.Apartment.GrgBlip.Alpha = 0
                If Not DelPerroHeight.Apartment.AptBlip Is Nothing Then DelPerroHeight.Apartment.AptBlip.Alpha = 0
                If Not DelPerroHeight.Apartment.GrgBlip Is Nothing Then DelPerroHeight.Apartment.GrgBlip.Alpha = 0
                If Not EclipseTower.Apartment.AptBlip Is Nothing Then EclipseTower.Apartment.AptBlip.Alpha = 0
                If Not EclipseTower.Apartment.GrgBlip Is Nothing Then EclipseTower.Apartment.GrgBlip.Alpha = 0
                If Not RichardMajestic.Apartment.AptBlip Is Nothing Then RichardMajestic.Apartment.AptBlip.Alpha = 0
                If Not RichardMajestic.Apartment.GrgBlip Is Nothing Then RichardMajestic.Apartment.GrgBlip.Alpha = 0
                If Not TinselTower.Apartment.AptBlip Is Nothing Then TinselTower.Apartment.AptBlip.Alpha = 0
                If Not TinselTower.Apartment.GrgBlip Is Nothing Then TinselTower.Apartment.GrgBlip.Alpha = 0
                If Not WeazelPlaza.Apartment.AptBlip Is Nothing Then WeazelPlaza.Apartment.AptBlip.Alpha = 0
                If Not WeazelPlaza.Apartment.GrgBlip Is Nothing Then WeazelPlaza.Apartment.GrgBlip.Alpha = 0
                If Not HillcrestAve2862.Apartment.AptBlip Is Nothing Then HillcrestAve2862.Apartment.AptBlip.Alpha = 0
                If Not HillcrestAve2862.Apartment.GrgBlip Is Nothing Then HillcrestAve2862.Apartment.GrgBlip.Alpha = 0
                If Not HillcrestAve2868.Apartment.AptBlip Is Nothing Then HillcrestAve2868.Apartment.AptBlip.Alpha = 0
                If Not HillcrestAve2868.Apartment.GrgBlip Is Nothing Then HillcrestAve2868.Apartment.GrgBlip.Alpha = 0
                If Not HillcrestAve2874.Apartment.AptBlip Is Nothing Then HillcrestAve2874.Apartment.AptBlip.Alpha = 0
                If Not HillcrestAve2874.Apartment.GrgBlip Is Nothing Then HillcrestAve2874.Apartment.GrgBlip.Alpha = 0
                If Not MadWayne2113.Apartment.AptBlip Is Nothing Then MadWayne2113.Apartment.AptBlip.Alpha = 0
                If Not MadWayne2113.Apartment.GrgBlip Is Nothing Then MadWayne2113.Apartment.GrgBlip.Alpha = 0
                If Not MiltonRd2117.Apartment.AptBlip Is Nothing Then MiltonRd2117.Apartment.AptBlip.Alpha = 0
                If Not MiltonRd2117.Apartment.GrgBlip Is Nothing Then MiltonRd2117.Apartment.GrgBlip.Alpha = 0
                If Not NorthConker2044.Apartment.AptBlip Is Nothing Then NorthConker2044.Apartment.AptBlip.Alpha = 0
                If Not NorthConker2044.Apartment.GrgBlip Is Nothing Then NorthConker2044.Apartment.GrgBlip.Alpha = 0
                If Not NorthConker2045.Apartment.AptBlip Is Nothing Then NorthConker2045.Apartment.AptBlip.Alpha = 0
                If Not NorthConker2045.Apartment.GrgBlip Is Nothing Then NorthConker2045.Apartment.GrgBlip.Alpha = 0
                If Not Whispymound3677.Apartment.AptBlip Is Nothing Then Whispymound3677.Apartment.AptBlip.Alpha = 0
                If Not Whispymound3677.Apartment.GrgBlip Is Nothing Then Whispymound3677.Apartment.GrgBlip.Alpha = 0
                If Not WildOats3655.Apartment.AptBlip Is Nothing Then WildOats3655.Apartment.AptBlip.Alpha = 0
                If Not WildOats3655.Apartment.GrgBlip Is Nothing Then WildOats3655.Apartment.GrgBlip.Alpha = 0
                If Not BayCityAve.Apartment.AptBlip Is Nothing Then BayCityAve.Apartment.AptBlip.Alpha = 0
                If Not BayCityAve.Apartment.GrgBlip Is Nothing Then BayCityAve.Apartment.GrgBlip.Alpha = 0
                If Not BlvdDelPerro.Apartment.AptBlip Is Nothing Then BlvdDelPerro.Apartment.AptBlip.Alpha = 0
                If Not BlvdDelPerro.Apartment.GrgBlip Is Nothing Then BlvdDelPerro.Apartment.GrgBlip.Alpha = 0
                If Not CougarAve.Apartment.AptBlip Is Nothing Then CougarAve.Apartment.AptBlip.Alpha = 0
                If Not CougarAve.Apartment.GrgBlip Is Nothing Then CougarAve.Apartment.GrgBlip.Alpha = 0
                If Not DreamTower.Apartment.AptBlip Is Nothing Then DreamTower.Apartment.AptBlip.Alpha = 0
                If Not DreamTower.Apartment.GrgBlip Is Nothing Then DreamTower.Apartment.GrgBlip.Alpha = 0
                If Not HangmanAve.Apartment.AptBlip Is Nothing Then HangmanAve.Apartment.AptBlip.Alpha = 0
                If Not HangmanAve.Apartment.GrgBlip Is Nothing Then HangmanAve.Apartment.GrgBlip.Alpha = 0
                If Not LasLagunasBlvd0604.Apartment.AptBlip Is Nothing Then LasLagunasBlvd0604.Apartment.AptBlip.Alpha = 0
                If Not LasLagunasBlvd0604.Apartment.GrgBlip Is Nothing Then LasLagunasBlvd0604.Apartment.GrgBlip.Alpha = 0
                If Not LasLagunasBlvd2143.Apartment.AptBlip Is Nothing Then LasLagunasBlvd2143.Apartment.AptBlip.Alpha = 0
                If Not LasLagunasBlvd2143.Apartment.GrgBlip Is Nothing Then LasLagunasBlvd2143.Apartment.GrgBlip.Alpha = 0
                If Not MiltonRd0184.Apartment.AptBlip Is Nothing Then MiltonRd0184.Apartment.AptBlip.Alpha = 0
                If Not MiltonRd0184.Apartment.GrgBlip Is Nothing Then MiltonRd0184.Apartment.GrgBlip.Alpha = 0
                If Not PowerSt.Apartment.AptBlip Is Nothing Then PowerSt.Apartment.AptBlip.Alpha = 0
                If Not PowerSt.Apartment.GrgBlip Is Nothing Then PowerSt.Apartment.GrgBlip.Alpha = 0
                If Not ProcopioDr4401.Apartment.AptBlip Is Nothing Then ProcopioDr4401.Apartment.AptBlip.Alpha = 0
                If Not ProcopioDr4401.Apartment.GrgBlip Is Nothing Then ProcopioDr4401.Apartment.GrgBlip.Alpha = 0
                If Not ProcopioDr4584.Apartment.AptBlip Is Nothing Then ProcopioDr4584.Apartment.AptBlip.Alpha = 0
                If Not ProcopioDr4584.Apartment.GrgBlip Is Nothing Then ProcopioDr4584.Apartment.GrgBlip.Alpha = 0
                If Not ProsperitySt.Apartment.AptBlip Is Nothing Then ProsperitySt.Apartment.AptBlip.Alpha = 0
                If Not ProsperitySt.Apartment.GrgBlip Is Nothing Then ProsperitySt.Apartment.GrgBlip.Alpha = 0
                If Not SanVitasSt.Apartment.AptBlip Is Nothing Then SanVitasSt.Apartment.AptBlip.Alpha = 0
                If Not SanVitasSt.Apartment.GrgBlip Is Nothing Then SanVitasSt.Apartment.GrgBlip.Alpha = 0
                If Not SouthMoMiltonDr.Apartment.AptBlip Is Nothing Then SouthMoMiltonDr.Apartment.AptBlip.Alpha = 0
                If Not SouthMoMiltonDr.Apartment.GrgBlip Is Nothing Then SouthMoMiltonDr.Apartment.GrgBlip.Alpha = 0
                If Not SouthRockfordDrive0325.Apartment.AptBlip Is Nothing Then SouthRockfordDrive0325.Apartment.AptBlip.Alpha = 0
                If Not SouthRockfordDrive0325.Apartment.GrgBlip Is Nothing Then SouthRockfordDrive0325.Apartment.GrgBlip.Alpha = 0
                If Not SpanishAve.Apartment.AptBlip Is Nothing Then SpanishAve.Apartment.AptBlip.Alpha = 0
                If Not SpanishAve.Apartment.GrgBlip Is Nothing Then SpanishAve.Apartment.GrgBlip.Alpha = 0
                If Not SustanciaRd.Apartment.AptBlip Is Nothing Then SustanciaRd.Apartment.AptBlip.Alpha = 0
                If Not SustanciaRd.Apartment.GrgBlip Is Nothing Then SustanciaRd.Apartment.GrgBlip.Alpha = 0
                If Not TheRoyale.Apartment.AptBlip Is Nothing Then TheRoyale.Apartment.AptBlip.Alpha = 0
                If Not TheRoyale.Apartment.GrgBlip Is Nothing Then TheRoyale.Apartment.GrgBlip.Alpha = 0
                If Not GrapeseedAve.Apartment.AptBlip Is Nothing Then GrapeseedAve.Apartment.AptBlip.Alpha = 0
                If Not GrapeseedAve.Apartment.GrgBlip Is Nothing Then GrapeseedAve.Apartment.GrgBlip.Alpha = 0
                If Not PaletoBlvd.Apartment.AptBlip Is Nothing Then PaletoBlvd.Apartment.AptBlip.Alpha = 0
                If Not PaletoBlvd.Apartment.GrgBlip Is Nothing Then PaletoBlvd.Apartment.GrgBlip.Alpha = 0
                If Not SouthRockfordDr0112.Apartment.AptBlip Is Nothing Then SouthRockfordDr0112.Apartment.AptBlip.Alpha = 0
                If Not SouthRockfordDr0112.Apartment.GrgBlip Is Nothing Then SouthRockfordDr0112.Apartment.GrgBlip.Alpha = 0
                If Not VespucciBlvd.Apartment.AptBlip Is Nothing Then VespucciBlvd.Apartment.AptBlip.Alpha = 0
                If Not VespucciBlvd.Apartment.GrgBlip Is Nothing Then VespucciBlvd.Apartment.GrgBlip.Alpha = 0
                If Not ZancudoAve.Apartment.AptBlip Is Nothing Then ZancudoAve.Apartment.AptBlip.Alpha = 0
                If Not ZancudoAve.Apartment.GrgBlip Is Nothing Then ZancudoAve.Apartment.GrgBlip.Alpha = 0
            Else
                If Not _3AltaStreet.Apartment.AptBlip Is Nothing Then _3AltaStreet.Apartment.AptBlip.Alpha = 255
                If Not _3AltaStreet.Apartment.GrgBlip Is Nothing Then _3AltaStreet.Apartment.GrgBlip.Alpha = 255
                If Not _4IntegrityWay.Apartment.AptBlip Is Nothing Then _4IntegrityWay.Apartment.AptBlip.Alpha = 255
                If Not _4IntegrityWay.Apartment.GrgBlip Is Nothing Then _4IntegrityWay.Apartment.GrgBlip.Alpha = 255
                If Not DelPerroHeight.Apartment.AptBlip Is Nothing Then DelPerroHeight.Apartment.AptBlip.Alpha = 255
                If Not DelPerroHeight.Apartment.GrgBlip Is Nothing Then DelPerroHeight.Apartment.GrgBlip.Alpha = 255
                If Not EclipseTower.Apartment.AptBlip Is Nothing Then EclipseTower.Apartment.AptBlip.Alpha = 255
                If Not EclipseTower.Apartment.GrgBlip Is Nothing Then EclipseTower.Apartment.GrgBlip.Alpha = 255
                If Not RichardMajestic.Apartment.AptBlip Is Nothing Then RichardMajestic.Apartment.AptBlip.Alpha = 255
                If Not RichardMajestic.Apartment.GrgBlip Is Nothing Then RichardMajestic.Apartment.GrgBlip.Alpha = 255
                If Not TinselTower.Apartment.AptBlip Is Nothing Then TinselTower.Apartment.AptBlip.Alpha = 255
                If Not TinselTower.Apartment.GrgBlip Is Nothing Then TinselTower.Apartment.GrgBlip.Alpha = 255
                If Not WeazelPlaza.Apartment.AptBlip Is Nothing Then WeazelPlaza.Apartment.AptBlip.Alpha = 255
                If Not WeazelPlaza.Apartment.GrgBlip Is Nothing Then WeazelPlaza.Apartment.GrgBlip.Alpha = 255
                If Not HillcrestAve2862.Apartment.AptBlip Is Nothing Then HillcrestAve2862.Apartment.AptBlip.Alpha = 255
                If Not HillcrestAve2862.Apartment.GrgBlip Is Nothing Then HillcrestAve2862.Apartment.GrgBlip.Alpha = 255
                If Not HillcrestAve2868.Apartment.AptBlip Is Nothing Then HillcrestAve2868.Apartment.AptBlip.Alpha = 255
                If Not HillcrestAve2868.Apartment.GrgBlip Is Nothing Then HillcrestAve2868.Apartment.GrgBlip.Alpha = 255
                If Not HillcrestAve2874.Apartment.AptBlip Is Nothing Then HillcrestAve2874.Apartment.AptBlip.Alpha = 255
                If Not HillcrestAve2874.Apartment.GrgBlip Is Nothing Then HillcrestAve2874.Apartment.GrgBlip.Alpha = 255
                If Not MadWayne2113.Apartment.AptBlip Is Nothing Then MadWayne2113.Apartment.AptBlip.Alpha = 255
                If Not MadWayne2113.Apartment.GrgBlip Is Nothing Then MadWayne2113.Apartment.GrgBlip.Alpha = 255
                If Not MiltonRd2117.Apartment.AptBlip Is Nothing Then MiltonRd2117.Apartment.AptBlip.Alpha = 255
                If Not MiltonRd2117.Apartment.GrgBlip Is Nothing Then MiltonRd2117.Apartment.GrgBlip.Alpha = 255
                If Not NorthConker2044.Apartment.AptBlip Is Nothing Then NorthConker2044.Apartment.AptBlip.Alpha = 255
                If Not NorthConker2044.Apartment.GrgBlip Is Nothing Then NorthConker2044.Apartment.GrgBlip.Alpha = 255
                If Not NorthConker2045.Apartment.AptBlip Is Nothing Then NorthConker2045.Apartment.AptBlip.Alpha = 255
                If Not NorthConker2045.Apartment.GrgBlip Is Nothing Then NorthConker2045.Apartment.GrgBlip.Alpha = 255
                If Not Whispymound3677.Apartment.AptBlip Is Nothing Then Whispymound3677.Apartment.AptBlip.Alpha = 255
                If Not Whispymound3677.Apartment.GrgBlip Is Nothing Then Whispymound3677.Apartment.GrgBlip.Alpha = 255
                If Not WildOats3655.Apartment.AptBlip Is Nothing Then WildOats3655.Apartment.AptBlip.Alpha = 255
                If Not WildOats3655.Apartment.GrgBlip Is Nothing Then WildOats3655.Apartment.GrgBlip.Alpha = 255
                If Not BayCityAve.Apartment.AptBlip Is Nothing Then BayCityAve.Apartment.AptBlip.Alpha = 255
                If Not BayCityAve.Apartment.GrgBlip Is Nothing Then BayCityAve.Apartment.GrgBlip.Alpha = 255
                If Not BlvdDelPerro.Apartment.AptBlip Is Nothing Then BlvdDelPerro.Apartment.AptBlip.Alpha = 255
                If Not BlvdDelPerro.Apartment.GrgBlip Is Nothing Then BlvdDelPerro.Apartment.GrgBlip.Alpha = 255
                If Not CougarAve.Apartment.AptBlip Is Nothing Then CougarAve.Apartment.AptBlip.Alpha = 255
                If Not CougarAve.Apartment.GrgBlip Is Nothing Then CougarAve.Apartment.GrgBlip.Alpha = 255
                If Not DreamTower.Apartment.AptBlip Is Nothing Then DreamTower.Apartment.AptBlip.Alpha = 255
                If Not DreamTower.Apartment.GrgBlip Is Nothing Then DreamTower.Apartment.GrgBlip.Alpha = 255
                If Not HangmanAve.Apartment.AptBlip Is Nothing Then HangmanAve.Apartment.AptBlip.Alpha = 255
                If Not HangmanAve.Apartment.GrgBlip Is Nothing Then HangmanAve.Apartment.GrgBlip.Alpha = 255
                If Not LasLagunasBlvd0604.Apartment.AptBlip Is Nothing Then LasLagunasBlvd0604.Apartment.AptBlip.Alpha = 255
                If Not LasLagunasBlvd0604.Apartment.GrgBlip Is Nothing Then LasLagunasBlvd0604.Apartment.GrgBlip.Alpha = 255
                If Not LasLagunasBlvd2143.Apartment.AptBlip Is Nothing Then LasLagunasBlvd2143.Apartment.AptBlip.Alpha = 255
                If Not LasLagunasBlvd2143.Apartment.GrgBlip Is Nothing Then LasLagunasBlvd2143.Apartment.GrgBlip.Alpha = 255
                If Not MiltonRd0184.Apartment.AptBlip Is Nothing Then MiltonRd0184.Apartment.AptBlip.Alpha = 255
                If Not MiltonRd0184.Apartment.GrgBlip Is Nothing Then MiltonRd0184.Apartment.GrgBlip.Alpha = 255
                If Not PowerSt.Apartment.AptBlip Is Nothing Then PowerSt.Apartment.AptBlip.Alpha = 255
                If Not PowerSt.Apartment.GrgBlip Is Nothing Then PowerSt.Apartment.GrgBlip.Alpha = 255
                If Not ProcopioDr4401.Apartment.AptBlip Is Nothing Then ProcopioDr4401.Apartment.AptBlip.Alpha = 255
                If Not ProcopioDr4401.Apartment.GrgBlip Is Nothing Then ProcopioDr4401.Apartment.GrgBlip.Alpha = 255
                If Not ProcopioDr4584.Apartment.AptBlip Is Nothing Then ProcopioDr4584.Apartment.AptBlip.Alpha = 255
                If Not ProcopioDr4584.Apartment.GrgBlip Is Nothing Then ProcopioDr4584.Apartment.GrgBlip.Alpha = 255
                If Not ProsperitySt.Apartment.AptBlip Is Nothing Then ProsperitySt.Apartment.AptBlip.Alpha = 255
                If Not ProsperitySt.Apartment.GrgBlip Is Nothing Then ProsperitySt.Apartment.GrgBlip.Alpha = 255
                If Not SanVitasSt.Apartment.AptBlip Is Nothing Then SanVitasSt.Apartment.AptBlip.Alpha = 255
                If Not SanVitasSt.Apartment.GrgBlip Is Nothing Then SanVitasSt.Apartment.GrgBlip.Alpha = 255
                If Not SouthMoMiltonDr.Apartment.AptBlip Is Nothing Then SouthMoMiltonDr.Apartment.AptBlip.Alpha = 255
                If Not SouthMoMiltonDr.Apartment.GrgBlip Is Nothing Then SouthMoMiltonDr.Apartment.GrgBlip.Alpha = 255
                If Not SouthRockfordDrive0325.Apartment.AptBlip Is Nothing Then SouthRockfordDrive0325.Apartment.AptBlip.Alpha = 255
                If Not SouthRockfordDrive0325.Apartment.GrgBlip Is Nothing Then SouthRockfordDrive0325.Apartment.GrgBlip.Alpha = 255
                If Not SpanishAve.Apartment.AptBlip Is Nothing Then SpanishAve.Apartment.AptBlip.Alpha = 255
                If Not SpanishAve.Apartment.GrgBlip Is Nothing Then SpanishAve.Apartment.GrgBlip.Alpha = 255
                If Not SustanciaRd.Apartment.AptBlip Is Nothing Then SustanciaRd.Apartment.AptBlip.Alpha = 255
                If Not SustanciaRd.Apartment.GrgBlip Is Nothing Then SustanciaRd.Apartment.GrgBlip.Alpha = 255
                If Not TheRoyale.Apartment.AptBlip Is Nothing Then TheRoyale.Apartment.AptBlip.Alpha = 255
                If Not TheRoyale.Apartment.GrgBlip Is Nothing Then TheRoyale.Apartment.GrgBlip.Alpha = 255
                If Not GrapeseedAve.Apartment.AptBlip Is Nothing Then GrapeseedAve.Apartment.AptBlip.Alpha = 255
                If Not GrapeseedAve.Apartment.GrgBlip Is Nothing Then GrapeseedAve.Apartment.GrgBlip.Alpha = 255
                If Not PaletoBlvd.Apartment.AptBlip Is Nothing Then PaletoBlvd.Apartment.AptBlip.Alpha = 255
                If Not PaletoBlvd.Apartment.GrgBlip Is Nothing Then PaletoBlvd.Apartment.GrgBlip.Alpha = 255
                If Not SouthRockfordDr0112.Apartment.AptBlip Is Nothing Then SouthRockfordDr0112.Apartment.AptBlip.Alpha = 255
                If Not SouthRockfordDr0112.Apartment.GrgBlip Is Nothing Then SouthRockfordDr0112.Apartment.GrgBlip.Alpha = 255
                If Not VespucciBlvd.Apartment.AptBlip Is Nothing Then VespucciBlvd.Apartment.AptBlip.Alpha = 255
                If Not VespucciBlvd.Apartment.GrgBlip Is Nothing Then VespucciBlvd.Apartment.GrgBlip.Alpha = 255
                If Not ZancudoAve.Apartment.AptBlip Is Nothing Then ZancudoAve.Apartment.AptBlip.Alpha = 255
                If Not ZancudoAve.Apartment.GrgBlip Is Nothing Then ZancudoAve.Apartment.GrgBlip.Alpha = 255
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String = Nothing
            If playerName = "Michael" Then
                lastInterior = ReadCfgValue("MlastInterior", saveFile)
            ElseIf playerName = "Franklin" Then
                lastInterior = ReadCfgValue("FlastInterior", saveFile)
            ElseIf playerName = "Trevor" Then
                lastInterior = ReadCfgValue("TlastInterior", saveFile)
            ElseIf playerName = "Player3" Then
                lastInterior = ReadCfgValue("3lastInterior", saveFile)
            End If
            Select Case lastInterior
                Case "SinnerSt"
                    MediumEndLastLocationName = DreamTower.Apartment.Name & DreamTower.Apartment.Unit
                Case "CougarAve"
                    MediumEndLastLocationName = CougarAve.Apartment.Name & CougarAve.Apartment.Unit
                Case "BayCityAve"
                    MediumEndLastLocationName = BayCityAve.Apartment.Name & BayCityAve.Apartment.Unit
                Case "0184MiltonRd"
                    MediumEndLastLocationName = MiltonRd0184.Apartment.Name & MiltonRd0184.Apartment.Unit
                Case "0325SouthRockfordDr"
                    MediumEndLastLocationName = SouthRockfordDrive0325.Apartment.Name & SouthRockfordDrive0325.Apartment.Unit
                Case "SouthMoMiltonDr"
                    MediumEndLastLocationName = SouthMoMiltonDr.Apartment.Name & SouthMoMiltonDr.Apartment.Unit
                Case "0604LasLagunasBlvd"
                    MediumEndLastLocationName = LasLagunasBlvd0604.Apartment.Name & LasLagunasBlvd0604.Apartment.Unit
                Case "SpanishAve"
                    MediumEndLastLocationName = SpanishAve.Apartment.Name & SpanishAve.Apartment.Unit
                Case "BlvdDelPerro"
                    MediumEndLastLocationName = BlvdDelPerro.Apartment.Name & BlvdDelPerro.Apartment.Unit
                Case "PowerSt"
                    MediumEndLastLocationName = PowerSt.Apartment.Name & PowerSt.Apartment.Unit
                Case "ProsperitySt"
                    MediumEndLastLocationName = ProsperitySt.Apartment.Name & ProsperitySt.Apartment.Unit
                Case "SanVitasSt"
                    MediumEndLastLocationName = SanVitasSt.Apartment.Name & SanVitasSt.Apartment.Unit
                Case "2143LasLagunasBlvd"
                    MediumEndLastLocationName = LasLagunasBlvd2143.Apartment.Name & LasLagunasBlvd2143.Apartment.Unit
                Case "TheRoyale"
                    MediumEndLastLocationName = TheRoyale.Apartment.Name & TheRoyale.Apartment.Unit
                Case "HangmanAve"
                    MediumEndLastLocationName = HangmanAve.Apartment.Name & HangmanAve.Apartment.Unit
                Case "SustanciaRd"
                    MediumEndLastLocationName = SustanciaRd.Apartment.Name & SustanciaRd.Apartment.Unit
                Case "4401ProcopioDr"
                    MediumEndLastLocationName = ProcopioDr4401.Apartment.Name & ProcopioDr4401.Apartment.Unit
                Case "4584ProcopioDr"
                    MediumEndLastLocationName = ProcopioDr4584.Apartment.Name & ProcopioDr4584.Apartment.Unit
                Case "VespucciBlvd"
                    LowEndLastLocationName = VespucciBlvd.Apartment.Name & VespucciBlvd.Apartment.Unit
                Case "0112SouthRockfordDr"
                    LowEndLastLocationName = SouthRockfordDr0112.Apartment.Name & SouthRockfordDr0112.Apartment.Unit
                Case "ZancudoAve"
                    LowEndLastLocationName = ZancudoAve.Apartment.Name & ZancudoAve.Apartment.Unit
                Case "PaletoBlvd"
                    LowEndLastLocationName = PaletoBlvd.Apartment.Name & PaletoBlvd.Apartment.Unit
                Case "GrapeseedAve"
                    LowEndLastLocationName = GrapeseedAve.Apartment.Name & GrapeseedAve.Apartment.Unit
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
