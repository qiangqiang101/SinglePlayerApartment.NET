Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GTA
Imports GTA.Math

Module Setting

    Dim keys As String = "KEYS"
    Dim settings As String = "SETTINGS"
    Dim apartments As String = "APARTMENTS"

    Public configFile As ScriptSettings = ScriptSettings.Load("scripts\SinglePlayerApartment\setting.ini")

    Public MechanicKey As Keys = configFile.GetValue(Of Keys)(keys, "MechanicKey", System.Windows.Forms.Keys.F6)
    Public MechanicJoyP As GTA.Control = configFile.GetValue(Of GTA.Control)(keys, "MechanicJoyP", 235)
    Public MechanicJoyS As GTA.Control = configFile.GetValue(Of GTA.Control)(keys, "MechanicJoyS", 223)

    Public OnlineMapEnable As Boolean = configFile.GetValue(Of Boolean)(settings, "OnlineMapEnable", True)
    Public DebugMode As Boolean = configFile.GetValue(Of Boolean)(settings, "DebugMode", False)
    Public WardrobeScenario As String = configFile.GetValue(Of String)(settings, "Scenario", "CODE_HUMAN_STAND_COWER")
    Public MechanicSpawn As Integer = configFile.GetValue(Of Integer)(settings, "MechanicSpawn", 1)
    Public Volume As Integer = configFile.GetValue(Of Integer)(settings, "Volume", 50)
    Public RefreshGarageVehicles As Boolean = configFile.GetValue(Of Boolean)(settings, "RefreshGarageVehicles", True)
    Public ErrorLogs As Boolean = configFile.GetValue(Of Boolean)(settings, "ErrorLogs", True)
    Public PreviewPosition As Point = configFile.GetValue(Of Point)(settings, "PicturePos", New Point(300, 120))

    Public Apt3AltaSt As Boolean = configFile.GetValue(Of Boolean)(apartments, "3AltaStreet", True)
    Public Apt4IntegrityWay As Boolean = configFile.GetValue(Of Boolean)(apartments, "4IntegrityWay", True)
    Public AptDelPerroHgt As Boolean = configFile.GetValue(Of Boolean)(apartments, "DelPerroHeights", True)
    Public AptDreamTwr As Boolean = configFile.GetValue(Of Boolean)(apartments, "DreamTower", True)
    Public AptEclipseTwr As Boolean = configFile.GetValue(Of Boolean)(apartments, "EclipseTower", True)
    Public AptRichardMajestic As Boolean = configFile.GetValue(Of Boolean)(apartments, "RichardMajestic", True)
    Public AptTinselTwr As Boolean = configFile.GetValue(Of Boolean)(apartments, "TinselTower", True)
    Public AptVespucciBlvd As Boolean = configFile.GetValue(Of Boolean)(apartments, "VespucciBlvd", True)
    Public AptWeazelPlz As Boolean = configFile.GetValue(Of Boolean)(apartments, "WeazelPlaza", True)
    Public Apt2862Hillcrest As Boolean = configFile.GetValue(Of Boolean)(apartments, "2862Hillcrest", True)
    Public Apt2868Hillcrest As Boolean = configFile.GetValue(Of Boolean)(apartments, "2868Hillcrest", True)
    Public Apt2874Hillcrest As Boolean = configFile.GetValue(Of Boolean)(apartments, "2874Hillcrest", True)
    Public Apt2113MadWayne As Boolean = configFile.GetValue(Of Boolean)(apartments, "2113MadWayne", True)
    Public Apt2117MiltonRd As Boolean = configFile.GetValue(Of Boolean)(apartments, "2117MiltonRd", True)
    Public Apt2044NorthConker As Boolean = configFile.GetValue(Of Boolean)(apartments, "2044NorthConker", True)
    Public Apt2045NorthConker As Boolean = configFile.GetValue(Of Boolean)(apartments, "2045NorthConker", True)
    Public Apt3677Whispymound As Boolean = configFile.GetValue(Of Boolean)(apartments, "3677Whispymound", True)
    Public Apt3655WildOats As Boolean = configFile.GetValue(Of Boolean)(apartments, "3655WildOats", True)
    Public AptCougarAve As Boolean = configFile.GetValue(Of Boolean)(apartments, "CougarAve", True)
    Public AptBayCityAve As Boolean = configFile.GetValue(Of Boolean)(apartments, "BayCityAve", True)
    Public Apt0184MiltonRd As Boolean = configFile.GetValue(Of Boolean)(apartments, "0184MiltonRd", True)
    Public Apt0325SouthRfDr As Boolean = configFile.GetValue(Of Boolean)(apartments, "0325SouthRockfordDr", True)
    Public AptSouthMoMiltonDr As Boolean = configFile.GetValue(Of Boolean)(apartments, "SouthMoMiltonDr", True)
    Public Apt0604LasLagunas As Boolean = configFile.GetValue(Of Boolean)(apartments, "0604LasLagunasBlvd", True)
    Public AptSpanishAve As Boolean = configFile.GetValue(Of Boolean)(apartments, "SpanishAve", True)
    Public AptBlvdDelPerro As Boolean = configFile.GetValue(Of Boolean)(apartments, "BlvdDelPerro", True)
    Public AptPowerSt As Boolean = configFile.GetValue(Of Boolean)(apartments, "PowerSt", True)
    Public AptProsperitySt As Boolean = configFile.GetValue(Of Boolean)(apartments, "ProsperitySt", True)
    Public AptSanVitasSt As Boolean = configFile.GetValue(Of Boolean)(apartments, "SanVitasSt", True)
    Public Apt2143LasLagunas As Boolean = configFile.GetValue(Of Boolean)(apartments, "2143LasLagunasBlvd", True)
    Public AptTheRoyale As Boolean = configFile.GetValue(Of Boolean)(apartments, "TheRoyale", True)
    Public AptHangmanAve As Boolean = configFile.GetValue(Of Boolean)(apartments, "HangmanAve", True)
    Public AptSustanciaRd As Boolean = configFile.GetValue(Of Boolean)(apartments, "SustanciaRd", True)
    Public Apt4401ProcopioDr As Boolean = configFile.GetValue(Of Boolean)(apartments, "4401ProcopioDr", True)
    Public Apt4584ProcopioDr As Boolean = configFile.GetValue(Of Boolean)(apartments, "4584ProcopioDr", True)
    Public Apt0112SouthRfDr As Boolean = configFile.GetValue(Of Boolean)(apartments, "0112SouthRockfordDr", True)
    Public AptZancudoAve As Boolean = configFile.GetValue(Of Boolean)(apartments, "ZancudoAve", True)
    Public AptPaletoBlvd As Boolean = configFile.GetValue(Of Boolean)(apartments, "PaletoBlvd", True)
    Public AptGrapeseedAve As Boolean = configFile.GetValue(Of Boolean)(apartments, "GrapeseedAve", True)

End Module

Public Module MySave

    Public owners As String = "OWNER"
    Public ipls As String = "IPL"
    Public pos As String = "POSITION"

    Public saveFile As ScriptSettings = ScriptSettings.Load("scripts\SinglePlayerApartment\mysave.ini")

    Public Enum Owner
        None = -1
        Michael
        Franklin
        Trevor
        Player3
    End Enum

    Public altastreet As String = "3AltaStreet"
    Public integrityway As String = "4IntegrityWay", integrityway2 As String = "4IntegrityWay2"
    Public delperrohgh As String = "DelPerroHeights", delperrohgh2 As String = "DelPerroHeights2"
    Public dreamtwr As String = "DreamTower"
    Public eclipsetwr As String = "EclipseTower", eclipsetwr2 As String = "EclipseTower2", eclipsetwr3 As String = "EclipseTower3", eclipsetwr4 As String = "EclipseTower4", eclipsetwr5 As String = "EclipseTower5"
    Public richardmajestic1 As String = "RichardMajestic", richardmajestic2 As String = "RichardMajestic2"
    Public tinseltwr As String = "TinselTower", tinseltwr2 As String = "TinselTower2"
    Public vespucciblvd1 As String = "VespucciBlvd"
    Public weazelplz As String = "WeazelPlaza"
    Public hillcrest2862 As String = "2862Hillcrest", hillcrest2868 As String = "2868Hillcrest", hillcrest2874 As String = "2874Hillcrest"
    Public madwayne As String = "2113MadWayne"
    Public miltonrd2117 As String = "2117MiltonRd", miltonrd0184 As String = "0184MiltonRd"
    Public northconker2044 As String = "2044NorthConker", northconker2045 As String = "2045NorthConker"
    Public whispymound As String = "3677Whispymound"
    Public wildoats As String = "3655WildOats"
    Public cougarave1 As String = "CougarAve"
    Public baycityave1 As String = "BayCityAve"
    Public southrfdr0325 As String = "0325SouthRockfordDr", southrfdr0112 As String = "0112SouthRockfordDr"
    Public southmomiltondr1 As String = "SouthMoMiltonDr"
    Public laslagunas0604 As String = "0604LasLagunasBlvd", laslagunas2143 As String = "2143LasLagunasBlvd"
    Public spanishave1 As String = "SpanishAve"
    Public blvddelperro1 As String = "BlvdDelPerro"
    Public powerst1 As String = "PowerSt"
    Public prosperityst1 As String = "ProsperitySt"
    Public sanvitasst1 As String = "SanVitasSt"
    Public theroyale1 As String = "TheRoyale"
    Public hangmanave1 As String = "HangmanAve"
    Public sustanciard1 As String = "SustanciaRd"
    Public procopiodr4401 As String = "4401ProcopioDr", procopiodr4584 As String = "4584ProcopioDr"
    Public zancudoave1 As String = "ZancudoAve"
    Public paletoblvd1 As String = "PaletoBlvd"
    Public grapeseedave1 As String = "GrapeseedAve"

    Public Apt3AltaStOwner As Owner = saveFile.GetValue(Of Owner)(owners, altastreet, Owner.None)
    Public Apt4IntegrityWayOwner As Owner = saveFile.GetValue(Of Owner)(owners, integrityway, Owner.None)
    Public Apt4IntegrityWayOwner2 As Owner = saveFile.GetValue(Of Owner)(owners, integrityway2, Owner.None)
    Public AptDelPerroHgtOwner As Owner = saveFile.GetValue(Of Owner)(owners, delperrohgh, Owner.None)
    Public AptDelPerroHgtOwner2 As Owner = saveFile.GetValue(Of Owner)(owners, delperrohgh2, Owner.None)
    Public AptDreamTwrOwner As Owner = saveFile.GetValue(Of Owner)(owners, dreamtwr, Owner.None)
    Public AptEclipseTwrOwner As Owner = saveFile.GetValue(Of Owner)(owners, eclipsetwr, Owner.None)
    Public AptEclipseTwrOwner2 As Owner = saveFile.GetValue(Of Owner)(owners, eclipsetwr2, Owner.None)
    Public AptEclipseTwrOwner3 As Owner = saveFile.GetValue(Of Owner)(owners, eclipsetwr3, Owner.None)
    Public AptEclipseTwrOwner4 As Owner = saveFile.GetValue(Of Owner)(owners, eclipsetwr4, Owner.None)
    Public AptEclipseTwrOwner5 As Owner = saveFile.GetValue(Of Owner)(owners, eclipsetwr5, Owner.None)
    Public AptRichardMajesticOwner As Owner = saveFile.GetValue(Of Owner)(owners, richardmajestic1, Owner.None)
    Public AptRichardMajesticOwner2 As Owner = saveFile.GetValue(Of Owner)(owners, richardmajestic2, Owner.None)
    Public AptTinselTwrOwner As Owner = saveFile.GetValue(Of Owner)(owners, tinseltwr, Owner.None)
    Public AptTinselTwrOwner2 As Owner = saveFile.GetValue(Of Owner)(owners, tinseltwr2, Owner.None)
    Public AptVespucciBlvdOwner As Owner = saveFile.GetValue(Of Owner)(owners, vespucciblvd1, Owner.None)
    Public AptWeazelPlzOwner As Owner = saveFile.GetValue(Of Owner)(owners, weazelplz, Owner.None)
    Public Apt2862HillcrestOwner As Owner = saveFile.GetValue(Of Owner)(owners, hillcrest2862, Owner.None)
    Public Apt2868HillcrestOwner As Owner = saveFile.GetValue(Of Owner)(owners, hillcrest2868, Owner.None)
    Public Apt2874HillcrestOwner As Owner = saveFile.GetValue(Of Owner)(owners, hillcrest2874, Owner.None)
    Public Apt2113MadWayneOwner As Owner = saveFile.GetValue(Of Owner)(owners, madwayne, Owner.None)
    Public Apt2117MiltonRdOwner As Owner = saveFile.GetValue(Of Owner)(owners, miltonrd2117, Owner.None)
    Public Apt2044NorthConkerOwner As Owner = saveFile.GetValue(Of Owner)(owners, northconker2044, Owner.None)
    Public Apt2045NorthConkerOwner As Owner = saveFile.GetValue(Of Owner)(owners, northconker2045, Owner.None)
    Public Apt3677WhispymoundOwner As Owner = saveFile.GetValue(Of Owner)(owners, whispymound, Owner.None)
    Public Apt3655WildOatsOwner As Owner = saveFile.GetValue(Of Owner)(owners, wildoats, Owner.None)
    Public AptCougarAveOwner As Owner = saveFile.GetValue(Of Owner)(owners, cougarave1, Owner.None)
    Public AptBayCityAveOwner As Owner = saveFile.GetValue(Of Owner)(owners, baycityave1, Owner.None)
    Public Apt0184MiltonRdOwner As Owner = saveFile.GetValue(Of Owner)(owners, miltonrd0184, Owner.None)
    Public Apt0325SouthRfDrOwner As Owner = saveFile.GetValue(Of Owner)(owners, southrfdr0325, Owner.None)
    Public AptSouthMoMiltonDrOwner As Owner = saveFile.GetValue(Of Owner)(owners, southmomiltondr1, Owner.None)
    Public Apt0604LasLagunasOwner As Owner = saveFile.GetValue(Of Owner)(owners, laslagunas0604, Owner.None)
    Public AptSpanishAveOwner As Owner = saveFile.GetValue(Of Owner)(owners, spanishave1, Owner.None)
    Public AptBlvdDelPerroOwner As Owner = saveFile.GetValue(Of Owner)(owners, blvddelperro1, Owner.None)
    Public AptPowerStOwner As Owner = saveFile.GetValue(Of Owner)(owners, powerst1, Owner.None)
    Public AptProsperityStOwner As Owner = saveFile.GetValue(Of Owner)(owners, prosperityst1, Owner.None)
    Public AptSanVitasStOwner As Owner = saveFile.GetValue(Of Owner)(owners, sanvitasst1, Owner.None)
    Public Apt2143LasLagunasOwner As Owner = saveFile.GetValue(Of Owner)(owners, laslagunas2143, Owner.None)
    Public AptTheRoyaleOwner As Owner = saveFile.GetValue(Of Owner)(owners, theroyale1, Owner.None)
    Public AptHangmanAveOwner As Owner = saveFile.GetValue(Of Owner)(owners, hangmanave1, Owner.None)
    Public AptSustanciaRdOwner As Owner = saveFile.GetValue(Of Owner)(owners, sustanciard1, Owner.None)
    Public Apt4401ProcopioDrOwner As Owner = saveFile.GetValue(Of Owner)(owners, procopiodr4401, Owner.None)
    Public Apt4584ProcopioDrOwner As Owner = saveFile.GetValue(Of Owner)(owners, procopiodr4584, Owner.None)
    Public Apt0112SouthRfDrOwner As Owner = saveFile.GetValue(Of Owner)(owners, southrfdr0112, Owner.None)
    Public AptZancudoAveOwner As Owner = saveFile.GetValue(Of Owner)(owners, zancudoave1, Owner.None)
    Public AptPaletoBlvdOwner As Owner = saveFile.GetValue(Of Owner)(owners, paletoblvd1, Owner.None)
    Public AptGrapeseedAveOwner As Owner = saveFile.GetValue(Of Owner)(owners, grapeseedave1, Owner.None)

    Public ETP1ipl As String = saveFile.GetValue(Of String)(ipls, "ETP1", "apa_v_mp_h_01_a")
    Public ETP2ipl As String = saveFile.GetValue(Of String)(ipls, "ETP2", "apa_v_mp_h_01_b")
    Public ETP3ipl As String = saveFile.GetValue(Of String)(ipls, "ETP3", "apa_v_mp_h_01_c")

    Public MLastPos As Vector3 = New Vector3(saveFile.GetValue(Of Single)(pos, "MLastPosX", 0F), saveFile.GetValue(Of Single)(pos, "MLastPosY", 0F), saveFile.GetValue(Of Single)(pos, "MLastPosZ", 0F))
    Public MLastInt As String = saveFile.GetValue(Of String)(pos, "MLastInt", "None")
    Public FLastPos As Vector3 = New Vector3(saveFile.GetValue(Of Single)(pos, "FLastPosX", 0F), saveFile.GetValue(Of Single)(pos, "FLastPosY", 0F), saveFile.GetValue(Of Single)(pos, "FLastPosZ", 0F))
    Public FLastInt As String = saveFile.GetValue(Of String)(pos, "FLastInt", "None")
    Public TLastPos As Vector3 = New Vector3(saveFile.GetValue(Of Single)(pos, "TLastPosX", 0F), saveFile.GetValue(Of Single)(pos, "TLastPosY", 0F), saveFile.GetValue(Of Single)(pos, "TLastPosZ", 0F))
    Public TLastInt As String = saveFile.GetValue(Of String)(pos, "TLastInt", "None")

    Public Function GetOwner() As Owner
        Select Case GetPlayerName()
            Case "Michael"
                Return MySave.Owner.Michael
            Case "Franklin"
                Return MySave.Owner.Franklin
            Case "Trevor"
                Return MySave.Owner.Trevor
            Case "Player3"
                Return MySave.Owner.Player3
        End Select
        Return MySave.Owner.None
    End Function

    Public Function UpdateValue(Of t)(section As String, name As String, value As t) As t
        saveFile.SetValue(Of t)(section, name, value)
        saveFile.Save()
        Return value
    End Function


End Module
