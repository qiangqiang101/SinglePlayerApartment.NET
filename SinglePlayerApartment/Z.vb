Imports GTA
Imports SinglePlayerApartment.SinglePlayerApartment

Public Class Z
    Inherits Script

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
                    MediumEndLastLocationName = DreamTower._Name & DreamTower.Unit
                Case "CougarAve"
                    MediumEndLastLocationName = CougarAve._Name & CougarAve.Unit
                Case "BayCityAve"
                    MediumEndLastLocationName = BayCityAve._Name & BayCityAve.Unit
                Case "0184MiltonRd"
                    MediumEndLastLocationName = MiltonRd0184._Name & MiltonRd0184.Unit
                Case "0325SouthRockfordDr"
                    MediumEndLastLocationName = SouthRockfordDrive0325._Name & SouthRockfordDrive0325.Unit
                Case "SouthMoMiltonDr"
                    MediumEndLastLocationName = SouthMoMiltonDr._Name & SouthMoMiltonDr.Unit
                Case "0604LasLagunasBlvd"
                    MediumEndLastLocationName = LasLagunasBlvd0604._Name & LasLagunasBlvd0604.Unit
                Case "SpanishAve"
                    MediumEndLastLocationName = SpanishAve._Name & SpanishAve.Unit
                Case "BlvdDelPerro"
                    MediumEndLastLocationName = BlvdDelPerro._Name & BlvdDelPerro.Unit
                Case "PowerSt"
                    MediumEndLastLocationName = PowerSt._Name & PowerSt.Unit
                Case "ProsperitySt"
                    MediumEndLastLocationName = ProsperitySt._Name & ProsperitySt.Unit
                Case "SanVitasSt"
                    MediumEndLastLocationName = SanVitasSt._Name & SanVitasSt.Unit
                Case "2143LasLagunasBlvd"
                    MediumEndLastLocationName = LasLagunasBlvd2143._Name & LasLagunasBlvd2143.Unit
                Case "TheRoyale"
                    MediumEndLastLocationName = TheRoyale._Name & TheRoyale.Unit
                Case "HangmanAve"
                    MediumEndLastLocationName = HangmanAve._Name & HangmanAve.Unit
                Case "SustanciaRd"
                    MediumEndLastLocationName = SustanciaRd._Name & SustanciaRd.Unit
                Case "4401ProcopioDr"
                    MediumEndLastLocationName = ProcopioDr4401._Name & ProcopioDr4401.Unit
                Case "4584ProcopioDr"
                    MediumEndLastLocationName = ProcopioDr4584._Name & ProcopioDr4584.Unit
                Case "VespucciBlvd"
                    LowEndLastLocationName = VespucciBlvd._Name & VespucciBlvd.Unit
                Case "0112SouthRockfordDr"
                    LowEndLastLocationName = SouthRockfordDr0112._Name & SouthRockfordDr0112.Unit
                Case "ZancudoAve"
                    LowEndLastLocationName = ZancudoAve._Name & ZancudoAve.Unit
                Case "PaletoBlvd"
                    LowEndLastLocationName = PaletoBlvd._Name & PaletoBlvd.Unit
                Case "GrapeseedAve"
                    LowEndLastLocationName = GrapeseedAve._Name & GrapeseedAve.Unit
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
