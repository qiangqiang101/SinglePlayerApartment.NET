Imports System.Drawing
Imports System.Windows.Forms
Imports GTA
Imports SinglePlayerApartment.SinglePlayerApartment

Public Class Z
    Inherits Script

    Public Sub New()
        Try
            SinglePlayerApartment.player = Game.Player
            playerPed = Game.Player.Character

            If GetPlayerName() = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = SinglePlayerApartment.player.Money
            End If

            If AptEclipseTwr Then EclipseTower.CreateEclipseTower()
            If Apt3AltaSt Then _3AltaStreet.Create3AltaStreet()
            If Apt4IntegrityWay Then _4IntegrityWay.Create4IntegrityWay()
            If AptDelPerroHgt Then DelPerroHeight.CreateDelPerroHeight()
            If AptRichardMajestic Then RichardMajestic.CreateRichardsMajestic()
            If AptTinselTwr Then TinselTower.CreateTinselTower()
            If AptWeazelPlz Then WeazelPlaza.CreateWeazelPlaza()
            If AptDreamTwr Then DreamTower.CreateDreamTower()
            If AptVespucciBlvd Then VespucciBlvd.CreateVespucciBlvd()
            If Apt2044NorthConker Then NorthConker2044.CreateNorthConker2044()
            If Apt2868Hillcrest Then HillcrestAve2862.CreateHillcrestAve2862()
            If Apt2868Hillcrest Then HillcrestAve2868.CreateHillcrestAve2868()
            If Apt3655WildOats Then WildOats3655.CreateWildOats3655()
            If Apt2045NorthConker Then NorthConker2045.CreateNorthConker2045()
            If Apt2117MiltonRd Then MiltonRd2117.CreateMiltonRoad2117()
            If Apt2874Hillcrest Then HillcrestAve2874.CreateHillcrestAve2874()
            If Apt3677Whispymound Then Whispymound3677.CreateWhispymound3677()
            If Apt2113MadWayne Then MadWayne2113.CreateMadWayne2113()
            If AptCougarAve Then CougarAve.CreateCougarAve()
            If AptBayCityAve Then BayCityAve.CreateBayCityAve()
            If Apt0184MiltonRd Then MiltonRd0184.Create0184MiltonRoad()
            If Apt0325SouthRfDr Then SouthRockfordDrive0325.Create0325SouthRockfordDr()
            If AptSouthMoMiltonDr Then SouthMoMiltonDr.CreateSouthMoMiltonDr()
            If Apt0604LasLagunas Then LasLagunasBlvd0604.Create0604LasLagunasBlvd()
            If AptSpanishAve Then SpanishAve.CreateSpanishAve()
            If AptBlvdDelPerro Then BlvdDelPerro.CreateBlvdDelPerro()
            If AptPowerSt Then PowerSt.CreatePowerSt()
            If AptProsperitySt Then ProsperitySt.CreateProsperitySt()
            If AptSanVitasSt Then SanVitasSt.CreateSanVitasSt()
            If Apt2143LasLagunas Then LasLagunasBlvd2143.Create2143LasLagunasBlvd()
            If AptTheRoyale Then TheRoyale.CreateTheRoyale()
            If AptHangmanAve Then HangmanAve.CreateHangmanAve()
            If AptSustanciaRd Then SustanciaRd.CreateSustanciaRd()
            If Apt4401ProcopioDr Then ProcopioDr4401.Create4401ProcopioDr()
            If Apt4584ProcopioDr Then ProcopioDr4584.Create4584ProcopioDr()
            If Apt0112SouthRfDr Then SouthRockfordDr0112.Create0112SouthRockfordDr()
            If AptZancudoAve Then ZancudoAve.CreateZancudoAve()
            If AptPaletoBlvd Then PaletoBlvd.CreatePaletoBlvd()
            If AptGrapeseedAve Then GrapeseedAve.CreateGrapeseedAve()
            '1.10 update
            'If ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then MazeBankWest.CreateMazeBankWest()
            LoadPosition()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles MyBase.Tick
        Try
            If Not Game.IsLoading Then
                SinglePlayerApartment.player = Game.Player
                playerPed = Game.Player.Character

                If GetPlayerName() = "Player3" Then
                    playerCash = 1000000000
                Else
                    playerCash = SinglePlayerApartment.player.Money
                End If

                If GetPlayerName() = "Player3" Then
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
                    If Not HillcrestAve2874._Apartment.AptBlip Is Nothing Then HillcrestAve2874._Apartment.AptBlip.Alpha = 255
                    If Not HillcrestAve2874._Apartment.GrgBlip Is Nothing Then HillcrestAve2874._Apartment.GrgBlip.Alpha = 255
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
                    '1.10 update
                    'If Not MazeBankWest.Apartment.AptBlip Is Nothing Then MazeBankWest.Apartment.AptBlip.Alpha = 255
                    'If Not MazeBankWest.Apartment.GrgBlip Is Nothing Then MazeBankWest.Apartment.GrgBlip.Alpha = 255
                Else
                    If Game.MissionFlag Or Game.Player.WantedLevel > 0 Then
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
                        If Not HillcrestAve2874._Apartment.AptBlip Is Nothing Then HillcrestAve2874._Apartment.AptBlip.Alpha = 0
                        If Not HillcrestAve2874._Apartment.GrgBlip Is Nothing Then HillcrestAve2874._Apartment.GrgBlip.Alpha = 0
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
                        '1.10 update
                        'If Not MazeBankWest.Apartment.AptBlip Is Nothing Then MazeBankWest.Apartment.AptBlip.Alpha = 0
                        'If Not MazeBankWest.Apartment.GrgBlip Is Nothing Then MazeBankWest.Apartment.GrgBlip.Alpha = 0
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
                        If Not HillcrestAve2874._Apartment.AptBlip Is Nothing Then HillcrestAve2874._Apartment.AptBlip.Alpha = 255
                        If Not HillcrestAve2874._Apartment.GrgBlip Is Nothing Then HillcrestAve2874._Apartment.GrgBlip.Alpha = 255
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
                        '1.10 update
                        'If Not MazeBankWest.Apartment.AptBlip Is Nothing Then MazeBankWest.Apartment.AptBlip.Alpha = 255
                        'If Not MazeBankWest.Apartment.GrgBlip Is Nothing Then MazeBankWest.Apartment.GrgBlip.Alpha = 255
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String = Nothing

            Select Case GetPlayerName()
                Case "Michael"
                    lastInterior = MLastInt
                Case "Franklin"
                    lastInterior = FLastInt
                Case "Trevor"
                    lastInterior = TLastInt
            End Select

            Select Case lastInterior
                Case "SinnerSt"
                    MediumEndLastLocationName = DreamTower.Apartment.Name
                Case "CougarAve"
                    MediumEndLastLocationName = CougarAve.Apartment.Name
                Case "BayCityAve"
                    MediumEndLastLocationName = BayCityAve.Apartment.Name
                Case "0184MiltonRd"
                    MediumEndLastLocationName = MiltonRd0184.Apartment.Name
                Case "0325SouthRockfordDr"
                    MediumEndLastLocationName = SouthRockfordDrive0325.Apartment.Name
                Case "SouthMoMiltonDr"
                    MediumEndLastLocationName = SouthMoMiltonDr.Apartment.Name
                Case "0604LasLagunasBlvd"
                    MediumEndLastLocationName = LasLagunasBlvd0604.Apartment.Name
                Case "SpanishAve"
                    MediumEndLastLocationName = SpanishAve.Apartment.Name
                Case "BlvdDelPerro"
                    MediumEndLastLocationName = BlvdDelPerro.Apartment.Name
                Case "PowerSt"
                    MediumEndLastLocationName = PowerSt.Apartment.Name
                Case "ProsperitySt"
                    MediumEndLastLocationName = ProsperitySt.Apartment.Name
                Case "SanVitasSt"
                    MediumEndLastLocationName = SanVitasSt.Apartment.Name
                Case "2143LasLagunasBlvd"
                    MediumEndLastLocationName = LasLagunasBlvd2143.Apartment.Name
                Case "TheRoyale"
                    MediumEndLastLocationName = TheRoyale.Apartment.Name
                Case "HangmanAve"
                    MediumEndLastLocationName = HangmanAve.Apartment.Name
                Case "SustanciaRd"
                    MediumEndLastLocationName = SustanciaRd.Apartment.Name
                Case "4401ProcopioDr"
                    MediumEndLastLocationName = ProcopioDr4401.Apartment.Name
                Case "4584ProcopioDr"
                    MediumEndLastLocationName = ProcopioDr4584.Apartment.Name
                Case "VespucciBlvd"
                    LowEndLastLocationName = VespucciBlvd.Apartment.Name
                Case "0112SouthRockfordDr"
                    LowEndLastLocationName = SouthRockfordDr0112.Apartment.Name
                Case "ZancudoAve"
                    LowEndLastLocationName = ZancudoAve.Apartment.Name
                Case "PaletoBlvd"
                    LowEndLastLocationName = PaletoBlvd.Apartment.Name
                Case "GrapeseedAve"
                    LowEndLastLocationName = GrapeseedAve.Apartment.Name
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
