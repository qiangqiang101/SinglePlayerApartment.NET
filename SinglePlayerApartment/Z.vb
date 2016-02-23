Imports GTA
Imports GTA.Native
Imports GTA.Math
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
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
