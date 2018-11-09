Imports System.Drawing
Imports GTA
Imports System.Windows.Forms
Imports System.IO.Directory
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI
Imports GTA.Math
Imports SinglePlayerApartment.INMNative
Imports GTA.Native

Public Class Mechanic
    Inherits Script

    Public Shared MPersVeh As PersonalVehicle = New PersonalVehicle(), FPersVeh As PersonalVehicle = New PersonalVehicle(), TPersVeh As PersonalVehicle = New PersonalVehicle(), PPersVeh As PersonalVehicle = New PersonalVehicle()
    Public Shared Path As String
    Public Shared GarageMenu, GarageMenu2, GrgMoveMenu, GrgTransMenu, MechanicMenu, PhoneMenu, AS3Menu, IW4Menu, IW4HLMenu, DPHMenu, DPHHLMenu, DTMenu, ETMenu, ETHLMenu, RMMenu, RMHLMenu, TTMenu, TTHLMenu, WPMenu, VBMenu As UIMenu
    Public Shared NC2044Menu, HA2862Menu, HA2868Menu, WO3655Menu, NC2045Menu, MR2117Menu, HA2874Menu, WD3677Menu, MW2113Menu, ETP1Menu, ETP2Menu, ETP3Menu As UIMenu
    Public Shared BCAMenu, BDPMenu, CAMenu, HAMenu, LLB0604Menu, LLB2143Menu, MR0184Menu, PowerMenu, PD4401Menu, PD4584Menu, ProsperityMenu, SVSMenu, SMMDMenu, SRD0325Menu, SAMenu, SRMenu, TRMenu As UIMenu
    Public Shared GAMenu, PBMenu, SRD0112Menu, ZAMenu As UIMenu
    Public Shared MBWMenu As UIMenu '1.10 update
    Public Shared MichaelPegasusMenu, FranklinPegasusMenu, TrevorPegasusMenu, Player3PegasusMenu, PegasusConfirmMenu As UIMenu
    Public Shared _menuPool As MenuPool
    Public Shared MPV0, FPV0, TPV0, PPV0 As Vehicle
    Public Shared MPVD, FPVD, TPVD, PPVD As Single
    Public Shared MPV10, FPV10, TPV10, PPV10 As Vehicle
    Public Shared MPVV10, FPVV10, TPVV10, PPVV10 As Vector3
    Public Shared MPVVB10, FPVVB10, TPVVB10, PPVVB10 As Blip
    Public Shared MPVF10, FPVF10, TPVF10, PPVF10 As String
    Public Shared itemAS3, itemIW4, itemIW4HL, itemDPH, itemDPHHL, itemDT, itemET, itemETHL, itemRM, itemRMHL, itemTT, itemTTHL, itemWP, itemVB As UIMenuItem
    Public Shared itemNC2044, itemHA2862, itemHA2868, itemWO3655, itemNC2045, itemMR2117, itemHA2874, itemWD3677, itemMW2113, itemETP1, itemETP2, itemETP3 As UIMenuItem
    Public Shared itemBCA, itemBDP, itemCA, itemHA, itemLLB0604, itemLLB2143, itemMR0184, itemPower, itemPD4401, itemPD4584, itemProsperity, itemSVS, itemSMMD, itemSRD0325, itemSA, itemSR, itemTR As UIMenuItem
    Public Shared itemGA, itemPB, itemSRD0112, itemZA As UIMenuItem
    Public Shared itemMBW As UIMenuItem '1.10 update
    Public Shared GarageMenuItem(20) As UIMenuItem
    Public Shared GrgMoveMenuItem(10) As UIMenuItem
    Public Shared GrgTransMenuItem(10) As UIMenuItem
    Public Shared GarageMenuSelectedItem, GarageMenuSelectedFile, MoveMenuSelectedItem, MoveMenuSelectedFile, MoveMenuSelectedIndex, SelectedGarage, PegasusSelectedVehicleFile As String, MoveIndex As Integer = -1
    Public Shared MechanicPed As Ped
    Public Shared MichaelPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Michael\"
    Public Shared FranklinPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Franklin\"
    Public Shared TrevorPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Trevor\"
    Public Shared Player3PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Player3\"
    Public Shared SoundPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Sounds\"

    Public Sub New()
        Try
            Translate()

            My.Settings.Mechanic = [Enum].Parse(GetType(Keys), ReadCfgValue("Mechanic", settingFile), False)
            My.Settings.Save()

            _menuPool = New MenuPool()

            CreatePhoneMenu()
            CreateMechanicMenu()
            CreateVehMenuApartments(AS3Menu, itemAS3, _3AltaStreet.Apartment.GaragePath)
            CreateVehMenuApartments(DTMenu, itemDT, DreamTower.Apartment.GaragePath)
            CreateVehMenuApartments(ETMenu, itemET, EclipseTower.Apartment.GaragePath)
            CreateVehMenuApartments(ETHLMenu, itemETHL, EclipseTower.ApartmentHL.GaragePath)
            CreateVehMenuApartments(IW4Menu, itemIW4, _4IntegrityWay.Apartment.GaragePath)
            CreateVehMenuApartments(IW4HLMenu, itemIW4HL, _4IntegrityWay.ApartmentHL.GaragePath)
            CreateVehMenuApartments(DPHMenu, itemDPH, DelPerroHeight.Apartment.GaragePath)
            CreateVehMenuApartments(DPHHLMenu, itemDPHHL, DelPerroHeight.ApartmentHL.GaragePath)
            CreateVehMenuApartments(RMMenu, itemRM, RichardMajestic.Apartment.GaragePath)
            CreateVehMenuApartments(RMHLMenu, itemRMHL, RichardMajestic.ApartmentHL.GaragePath)
            CreateVehMenuApartments(TTMenu, itemTT, TinselTower.Apartment.GaragePath)
            CreateVehMenuApartments(TTHLMenu, itemTTHL, TinselTower.ApartmentHL.GaragePath)
            CreateVehMenuApartments(WPMenu, itemWP, WeazelPlaza.Apartment.GaragePath)
            CreateVehMenuApartments(NC2044Menu, itemNC2044, NorthConker2044.Apartment.GaragePath)
            CreateVehMenuApartments(HA2862Menu, itemHA2862, HillcrestAve2862.Apartment.GaragePath)
            CreateVehMenuApartments(HA2868Menu, itemHA2868, HillcrestAve2868.Apartment.GaragePath)
            CreateVehMenuApartments(WO3655Menu, itemWO3655, WildOats3655.Apartment.GaragePath)
            CreateVehMenuApartments(NC2045Menu, itemNC2045, NorthConker2045.Apartment.GaragePath)
            CreateVehMenuApartments(MR2117Menu, itemMR2117, MiltonRd2117.Apartment.GaragePath)
            CreateVehMenuApartments(HA2874Menu, itemHA2874, HillcrestAve2874._Apartment.GaragePath)
            CreateVehMenuApartments(WD3677Menu, itemWD3677, Whispymound3677.Apartment.GaragePath)
            CreateVehMenuApartments(MW2113Menu, itemMW2113, MadWayne2113.Apartment.GaragePath)
            CreateVehMenuApartments(ETP1Menu, itemETP1, EclipseTower.ApartmentPS1.GaragePath)
            CreateVehMenuApartments(ETP2Menu, itemETP2, EclipseTower.ApartmentPS2.GaragePath)
            CreateVehMenuApartments(ETP3Menu, itemETP3, EclipseTower.ApartmentPS3.GaragePath)
            CreateVehMenuApartments(BCAMenu, itemBCA, BayCityAve.Apartment.GaragePath)
            CreateVehMenuApartments(BDPMenu, itemBDP, BlvdDelPerro.Apartment.GaragePath)
            CreateVehMenuApartments(CAMenu, itemCA, CougarAve.Apartment.GaragePath)
            CreateVehMenuApartments(HAMenu, itemHA, HangmanAve.Apartment.GaragePath)
            CreateVehMenuApartments(LLB0604Menu, itemLLB0604, LasLagunasBlvd0604.Apartment.GaragePath)
            CreateVehMenuApartments(LLB2143Menu, itemLLB2143, LasLagunasBlvd2143.Apartment.GaragePath)
            CreateVehMenuApartments(MR0184Menu, itemMR0184, MiltonRd0184.Apartment.GaragePath)
            CreateVehMenuApartments(PowerMenu, itemPower, PowerSt.Apartment.GaragePath)
            CreateVehMenuApartments(PD4401Menu, itemPD4401, ProcopioDr4401.Apartment.GaragePath)
            CreateVehMenuApartments(PD4584Menu, itemPD4584, ProcopioDr4584.Apartment.GaragePath)
            CreateVehMenuApartments(ProsperityMenu, itemProsperity, ProsperitySt.Apartment.GaragePath)
            CreateVehMenuApartments(SVSMenu, itemSVS, SanVitasSt.Apartment.GaragePath)
            CreateVehMenuApartments(SMMDMenu, itemSMMD, SouthMoMiltonDr.Apartment.GaragePath)
            CreateVehMenuApartments(SRD0325Menu, itemSRD0325, SouthRockfordDrive0325.Apartment.GaragePath)
            CreateVehMenuApartments(SAMenu, itemSA, SpanishAve.Apartment.GaragePath)
            CreateVehMenuApartments(SRMenu, itemSR, SustanciaRd.Apartment.GaragePath)
            CreateVehMenuApartments(TRMenu, itemTR, TheRoyale.Apartment.GaragePath)
            CreateVehMenuApartments6(VBMenu, itemVB, VespucciBlvd.Apartment.GaragePath)
            CreateVehMenuApartments6(GAMenu, itemGA, GrapeseedAve.Apartment.GaragePath)
            CreateVehMenuApartments6(PBMenu, itemPB, PaletoBlvd.Apartment.GaragePath)
            CreateVehMenuApartments6(SRD0112Menu, itemSRD0112, SouthRockfordDr0112.Apartment.GaragePath)
            CreateVehMenuApartments6(ZAMenu, itemZA, ZancudoAve.Apartment.GaragePath)
            '1.10 update
            'CreateVehMenuApartments20(MBWMenu, itemMBW, MazeBankWest.Apartment.GaragePath)
            CreateConfirmPegasusMenu()
            ReturnAllVehiclesToGarageNEW()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateConfirmPegasusMenu()
        Try
            PegasusConfirmMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            PegasusConfirmMenu.SetBannerType(Rectangle)
            _menuPool.Add(PegasusConfirmMenu)
            PegasusConfirmMenu.AddItem(New UIMenuItem(PegasusDeliver))
            PegasusConfirmMenu.AddItem(New UIMenuItem(PegasusDelete))
            PegasusConfirmMenu.RefreshIndex()
            AddHandler PegasusConfirmMenu.OnItemSelect, AddressOf PegasusConfirmItemSelectHandler
            AddHandler PegasusConfirmMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreatePegasusMenuFor(ByRef menu As UIMenu, dir As String)
        Try
            menu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            menu.SetBannerType(Rectangle)
            _menuPool.Add(menu)
            menu.MenuItems.Clear()
            For Each File As String In GetFiles(dir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .SubString1 = File
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
            AddHandler menu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler menu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreatePhoneMenu()
        Try
            PhoneMenu = New UIMenu("", _Phone, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            PhoneMenu.SetBannerType(Rectangle)
            _menuPool.Add(PhoneMenu)
            PhoneMenu.AddItem(New UIMenuItem(_Mechanic))
            PhoneMenu.AddItem(New UIMenuItem(_Pegasus))
            PhoneMenu.AddItem(New UIMenuItem(Website.BennysOriginal))
            PhoneMenu.AddItem(New UIMenuItem(Website.DockTease))
            PhoneMenu.AddItem(New UIMenuItem(Website.ElitasTravel))
            PhoneMenu.AddItem(New UIMenuItem(Website.LegendaryMotorsport))
            PhoneMenu.AddItem(New UIMenuItem(Website.PedalToMetal))
            PhoneMenu.AddItem(New UIMenuItem(Website.SouthernSA))
            PhoneMenu.AddItem(New UIMenuItem(Website.WarstockCache))
            PhoneMenu.RefreshIndex()
            AddHandler PhoneMenu.OnItemSelect, AddressOf PhoneMenuItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateMechanicMenu()
        Try
            MechanicMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MechanicMenu.SetBannerType(Rectangle)
            _menuPool.Add(MechanicMenu)
            MechanicMenu.MenuItems.Clear()
            If _3AltaStreet.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(_3AltaStreet.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then MechanicMenu.AddItem(itemAS3)
            If _4IntegrityWay.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(_4IntegrityWay.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4)
            If _4IntegrityWay.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(_4IntegrityWay.ApartmentHL.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4HL)
            If DelPerroHeight.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(DelPerroHeight.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPH)
            If DelPerroHeight.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(DelPerroHeight.ApartmentHL.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPHHL)
            If DreamTower.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(DreamTower.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDT)
            If EclipseTower.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemET)
            If EclipseTower.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentHL.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETHL)
            If RichardMajestic.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(RichardMajestic.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRM)
            If RichardMajestic.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(RichardMajestic.ApartmentHL.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRMHL)
            If TinselTower.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(TinselTower.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTT)
            If TinselTower.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(TinselTower.ApartmentHL.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTTHL)
            If WeazelPlaza.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(WeazelPlaza.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWP)
            If VespucciBlvd.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(VespucciBlvd.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemVB)
            If NorthConker2044.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(NorthConker2044.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2044)
            If HillcrestAve2862.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HillcrestAve2862.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2862)
            If HillcrestAve2868.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HillcrestAve2868.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2868)
            If WildOats3655.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(WildOats3655.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWO3655)
            If NorthConker2045.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(NorthConker2045.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2045)
            If MiltonRd2117.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MiltonRd2117.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMR2117)
            If HillcrestAve2874._Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HillcrestAve2874._Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2874)
            If Whispymound3677.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(Whispymound3677.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWD3677)
            If MadWayne2113.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MadWayne2113.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMW2113)
            If EclipseTower.ApartmentPS1.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentPS1.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP1)
            If EclipseTower.ApartmentPS2.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentPS2.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP2)
            If EclipseTower.ApartmentPS3.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentPS3.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP3)
            If BayCityAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(BayCityAve.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("BayCityAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemBCA)
            If BlvdDelPerro.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(BlvdDelPerro.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then MechanicMenu.AddItem(itemBDP)
            If CougarAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(CougarAve.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("CougarAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemCA)
            If HangmanAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HangmanAve.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("HangmanAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA)
            If LasLagunasBlvd0604.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(LasLagunasBlvd0604.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemLLB0604)
            If LasLagunasBlvd2143.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(LasLagunasBlvd2143.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemLLB2143)
            If MiltonRd0184.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MiltonRd0184.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMR0184)
            If PowerSt.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(PowerSt.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("PowerSt", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPower)
            If ProcopioDr4401.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ProcopioDr4401.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPD4401)
            If ProcopioDr4584.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ProcopioDr4584.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPD4584)
            If ProsperitySt.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ProsperitySt.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then MechanicMenu.AddItem(itemProsperity)
            If SanVitasSt.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SanVitasSt.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSVS)
            If SouthMoMiltonDr.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SouthMoMiltonDr.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSMMD)
            If SouthRockfordDrive0325.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SouthRockfordDrive0325.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSRD0325)
            If SpanishAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SpanishAve.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("SpanishAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSA)
            If SustanciaRd.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SustanciaRd.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSR)
            If TheRoyale.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(TheRoyale.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("TheRoyale", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTR)
            If GrapeseedAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(GrapeseedAve.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemGA)
            If PaletoBlvd.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(PaletoBlvd.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPB)
            If SouthRockfordDr0112.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SouthRockfordDr0112.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSRD0112)
            If ZancudoAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ZancudoAve.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemZA)
            '1.10 update
            'If MazeBankWest.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MazeBankWest.Apartment.GaragePath, "*.cfg").Count = 0 AndAlso ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMBW)
            MechanicMenu.RefreshIndex()
            AddHandler MechanicMenu.OnMenuClose, AddressOf CategoryMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

#Region "Create Apartment"
    Public Shared Sub CreateVehTransMenuApt()
        Try
            GrgTransMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgTransMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgTransMenu)
            GrgTransMenu.MenuItems.Clear()

            ReadMenuItems()

            If _3AltaStreet.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(_3AltaStreet.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemAS3)
            If _4IntegrityWay.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(_4IntegrityWay.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemIW4)
            If _4IntegrityWay.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(_4IntegrityWay.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemIW4HL)
            If DelPerroHeight.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(DelPerroHeight.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDPH)
            If DelPerroHeight.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(DelPerroHeight.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDPHHL)
            If DreamTower.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(DreamTower.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDT)
            If EclipseTower.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemET)
            If EclipseTower.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETHL)
            If RichardMajestic.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(RichardMajestic.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemRM)
            If RichardMajestic.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(RichardMajestic.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemRMHL)
            If TinselTower.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(TinselTower.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTT)
            If TinselTower.ApartmentHL.Owner = GetPlayerName() AndAlso Not GetFiles(TinselTower.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTTHL)
            If WeazelPlaza.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(WeazelPlaza.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWP)
            If VespucciBlvd.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(VespucciBlvd.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemVB)
            If NorthConker2044.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(NorthConker2044.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemNC2044)
            If HillcrestAve2862.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HillcrestAve2862.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2862)
            If HillcrestAve2868.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HillcrestAve2868.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2868)
            If WildOats3655.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(WildOats3655.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWO3655)
            If NorthConker2045.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(NorthConker2045.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemNC2045)
            If MiltonRd2117.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MiltonRd2117.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMR2117)
            If HillcrestAve2874._Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HillcrestAve2874._Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2874)
            If Whispymound3677.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(Whispymound3677.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWD3677)
            If MadWayne2113.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MadWayne2113.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMW2113)
            If EclipseTower.ApartmentPS1.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentPS1.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP1)
            If EclipseTower.ApartmentPS2.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentPS2.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP2)
            If EclipseTower.ApartmentPS3.Owner = GetPlayerName() AndAlso Not GetFiles(EclipseTower.ApartmentPS3.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP3)
            If BayCityAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(BayCityAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("BayCityAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemBCA)
            If BlvdDelPerro.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(BlvdDelPerro.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemBDP)
            If CougarAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(CougarAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("CougarAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemCA)
            If HangmanAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(HangmanAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("HangmanAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA)
            If LasLagunasBlvd0604.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(LasLagunasBlvd0604.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemLLB0604)
            If LasLagunasBlvd2143.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(LasLagunasBlvd2143.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemLLB2143)
            If MiltonRd0184.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MiltonRd0184.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMR0184)
            If PowerSt.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(PowerSt.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("PowerSt", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPower)
            If ProcopioDr4401.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ProcopioDr4401.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPD4401)
            If ProcopioDr4584.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ProcopioDr4584.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPD4584)
            If ProsperitySt.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ProsperitySt.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemProsperity)
            If SanVitasSt.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SanVitasSt.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSVS)
            If SouthMoMiltonDr.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SouthMoMiltonDr.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSMMD)
            If SouthRockfordDrive0325.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SouthRockfordDrive0325.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSRD0325)
            If SpanishAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SpanishAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SpanishAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSA)
            If SustanciaRd.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SustanciaRd.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSR)
            If TheRoyale.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(TheRoyale.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("TheRoyale", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTR)
            If GrapeseedAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(GrapeseedAve.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemGA)
            If PaletoBlvd.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(PaletoBlvd.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPB)
            If SouthRockfordDr0112.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(SouthRockfordDr0112.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSRD0112)
            If ZancudoAve.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(ZancudoAve.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemZA)
            '1.10 update
            'If MazeBankWest.Apartment.Owner = GetPlayerName() AndAlso Not GetFiles(MazeBankWest.Apartment.GaragePath, "*.cfg").Count = 20 AndAlso ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMBW)
            GrgTransMenu.RefreshIndex()
            AddHandler GrgTransMenu.OnItemSelect, AddressOf TransVehItemSelectHandler
            AddHandler GrgTransMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub VehMenuAddItem(ByRef Menu As UIMenu, ByRef Item As UIMenuItem, PathDir As String, VehicleFile As String)
        If IO.File.Exists(PathDir & VehicleFile) Then
            Dim Active As String = ReadCfgValue("Active", PathDir & VehicleFile)
            Dim VehName As String = ReadCfgValue("VehicleName", PathDir & VehicleFile)
            Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & VehicleFile)
            Dim VehDispName As String
            If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
            Item = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & VehicleFile) & ")", ChooseVehDesc)
            Menu.AddItem(Item)
            With Item
                .SubString1 = PathDir & VehicleFile
                If Active = "True" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    .Enabled = False
                End If
            End With
        End If
    End Sub

    Public Shared Sub CreateVehMenuApartments(MenuCategory As UIMenu, MenuItem As UIMenuItem, PathDir As String)
        Try
            MenuCategory = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            MenuCategory.MenuItems.Clear()
            Dim item(10) As UIMenuItem

            VehMenuAddItem(MenuCategory, item(0), PathDir, "vehicle_0.cfg")
            VehMenuAddItem(MenuCategory, item(1), PathDir, "vehicle_1.cfg")
            VehMenuAddItem(MenuCategory, item(2), PathDir, "vehicle_2.cfg")
            VehMenuAddItem(MenuCategory, item(3), PathDir, "vehicle_3.cfg")
            VehMenuAddItem(MenuCategory, item(4), PathDir, "vehicle_4.cfg")
            VehMenuAddItem(MenuCategory, item(5), PathDir, "vehicle_5.cfg")
            VehMenuAddItem(MenuCategory, item(6), PathDir, "vehicle_6.cfg")
            VehMenuAddItem(MenuCategory, item(7), PathDir, "vehicle_7.cfg")
            VehMenuAddItem(MenuCategory, item(8), PathDir, "vehicle_8.cfg")
            VehMenuAddItem(MenuCategory, item(9), PathDir, "vehicle_9.cfg")

            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            MenuCategory.AddItem(ReturnVehItem)
            With ReturnVehItem
                .SubString1 = PathDir
            End With
            MenuCategory.RefreshIndex()
            MechanicMenu.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf CategoryItemSelectHandler
            'AddHandler MenuCategory.OnIndexChange, AddressOf GrgMoveIndexChangeHandler
            'AddHandler MenuCategory.OnMenuClose, AddressOf CategoryInGarageMenuCloseHandler
        Catch ex As Exception
            If Not ex.StackTrace.Contains("ContainsKey") Then
                logger.Log(ex.Message & " " & ex.StackTrace)
            End If
        End Try
    End Sub

    Public Shared Sub CreateVehMenuApartments20(MenuCategory As UIMenu, MenuItem As UIMenuItem, PathDir As String)
        Try
            MenuCategory = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            MenuCategory.MenuItems.Clear()
            Dim item(20) As UIMenuItem

            VehMenuAddItem(MenuCategory, item(0), PathDir, "vehicle_0.cfg")
            VehMenuAddItem(MenuCategory, item(1), PathDir, "vehicle_1.cfg")
            VehMenuAddItem(MenuCategory, item(2), PathDir, "vehicle_2.cfg")
            VehMenuAddItem(MenuCategory, item(3), PathDir, "vehicle_3.cfg")
            VehMenuAddItem(MenuCategory, item(4), PathDir, "vehicle_4.cfg")
            VehMenuAddItem(MenuCategory, item(5), PathDir, "vehicle_5.cfg")
            VehMenuAddItem(MenuCategory, item(6), PathDir, "vehicle_6.cfg")
            VehMenuAddItem(MenuCategory, item(7), PathDir, "vehicle_7.cfg")
            VehMenuAddItem(MenuCategory, item(8), PathDir, "vehicle_8.cfg")
            VehMenuAddItem(MenuCategory, item(9), PathDir, "vehicle_9.cfg")
            VehMenuAddItem(MenuCategory, item(10), PathDir, "vehicle_10.cfg")
            VehMenuAddItem(MenuCategory, item(11), PathDir, "vehicle_11.cfg")
            VehMenuAddItem(MenuCategory, item(12), PathDir, "vehicle_12.cfg")
            VehMenuAddItem(MenuCategory, item(13), PathDir, "vehicle_13.cfg")
            VehMenuAddItem(MenuCategory, item(14), PathDir, "vehicle_14.cfg")
            VehMenuAddItem(MenuCategory, item(15), PathDir, "vehicle_15.cfg")
            VehMenuAddItem(MenuCategory, item(16), PathDir, "vehicle_16.cfg")
            VehMenuAddItem(MenuCategory, item(17), PathDir, "vehicle_17.cfg")
            VehMenuAddItem(MenuCategory, item(18), PathDir, "vehicle_18.cfg")
            VehMenuAddItem(MenuCategory, item(19), PathDir, "vehicle_19.cfg")

            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            MenuCategory.AddItem(ReturnVehItem)
            With ReturnVehItem
                .SubString1 = PathDir
            End With
            MenuCategory.RefreshIndex()
            MechanicMenu.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf CategoryItemSelectHandler
            'AddHandler MenuCategory.OnIndexChange, AddressOf GrgMoveIndexChangeHandler
            'AddHandler MenuCategory.OnMenuClose, AddressOf CategoryInGarageMenuCloseHandler
        Catch ex As Exception
            If Not ex.StackTrace.Contains("ContainsKey") Then
                logger.Log(ex.Message & " " & ex.StackTrace)
            End If
        End Try
    End Sub

    Public Shared Sub CreateVehMenuApartments6(MenuCategory As UIMenu, MenuItem As UIMenuItem, PathDir As String)
        Try
            MenuCategory = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            MenuCategory.MenuItems.Clear()
            Dim item(6) As UIMenuItem

            VehMenuAddItem(MenuCategory, item(0), PathDir, "vehicle_0.cfg")
            VehMenuAddItem(MenuCategory, item(1), PathDir, "vehicle_1.cfg")
            VehMenuAddItem(MenuCategory, item(2), PathDir, "vehicle_2.cfg")
            VehMenuAddItem(MenuCategory, item(3), PathDir, "vehicle_3.cfg")
            VehMenuAddItem(MenuCategory, item(4), PathDir, "vehicle_4.cfg")
            VehMenuAddItem(MenuCategory, item(5), PathDir, "vehicle_5.cfg")

            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            MenuCategory.AddItem(ReturnVehItem)
            With ReturnVehItem
                .SubString1 = PathDir
            End With
            MenuCategory.RefreshIndex()
            MechanicMenu.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf CategoryItemSelectHandler
            'AddHandler MenuCategory.OnIndexChange, AddressOf GrgMoveIndexChangeHandler
            'AddHandler MenuCategory.OnMenuClose, AddressOf CategoryInGarageMenuCloseHandler
        Catch ex As Exception
            If Not ex.StackTrace.Contains("ContainsKey") Then
                logger.Log(ex.Message & " " & ex.StackTrace)
            End If
        End Try
    End Sub
#End Region

    Public Shared Sub MoveMenuAddItem(ByRef Menu As UIMenu, ByRef Item As UIMenuItem, PathDir As String, VehicleFile As String)
        If IO.File.Exists(PathDir & VehicleFile) Then
            Dim Active As String = ReadCfgValue("Active", PathDir & VehicleFile)
            Item = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & VehicleFile) & " (" & ReadCfgValue("PlateNumber", PathDir & VehicleFile) & ")", GrgSelectVeh)
            Menu.AddItem(Item)
            With Item
                .SubString1 = VehicleFile
                If Active = "True" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    .Enabled = False
                End If
            End With
        Else
            Item = New UIMenuItem("Empty")
            Menu.AddItem(Item)
            With Item
                .SubString1 = VehicleFile
            End With
        End If
    End Sub

    Public Shared Sub CreateMoveMenu(file As String, SixOrTen As String)
        Try
            GrgMoveMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgMoveMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgMoveMenu)
            GrgMoveMenu.MenuItems.Clear()
            If SixOrTen = "Ten" Then
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(0), file, "vehicle_0.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(1), file, "vehicle_1.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(2), file, "vehicle_2.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(3), file, "vehicle_3.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(4), file, "vehicle_4.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(5), file, "vehicle_5.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(6), file, "vehicle_6.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(7), file, "vehicle_7.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(8), file, "vehicle_8.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(9), file, "vehicle_9.cfg")
            ElseIf SelectedGarage = "Six"
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(0), file, "vehicle_0.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(1), file, "vehicle_1.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(2), file, "vehicle_2.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(3), file, "vehicle_3.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(4), file, "vehicle_4.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(5), file, "vehicle_5.cfg")
            ElseIf SelectedGarage = "Twenty"
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(0), file, "vehicle_0.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(1), file, "vehicle_1.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(2), file, "vehicle_2.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(3), file, "vehicle_3.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(4), file, "vehicle_4.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(5), file, "vehicle_5.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(6), file, "vehicle_6.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(7), file, "vehicle_7.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(8), file, "vehicle_8.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(9), file, "vehicle_9.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(10), file, "vehicle_10.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(11), file, "vehicle_11.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(12), file, "vehicle_12.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(13), file, "vehicle_13.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(14), file, "vehicle_14.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(15), file, "vehicle_15.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(16), file, "vehicle_16.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(17), file, "vehicle_17.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(18), file, "vehicle_18.cfg")
                MoveMenuAddItem(GrgMoveMenu, GrgMoveMenuItem(19), file, "vehicle_19.cfg")
            End If
            GrgMoveMenu.RefreshIndex()
            AddHandler GrgMoveMenu.OnItemSelect, AddressOf GrgMoveItemSelectHandler
            AddHandler GrgMoveMenu.OnIndexChange, AddressOf GrgMoveIndexChangeHandler
            AddHandler GrgMoveMenu.OnMenuClose, AddressOf GrgMoveMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu2(SixOrTen As String)
        Try
            GarageMenu2 = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu2.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu2)
            GarageMenu2.AddItem(New UIMenuItem(GrgRemove))
            GarageMenu2.AddItem(New UIMenuItem(GrgRemoveAndDrive))
            GarageMenu2.AddItem(New UIMenuItem(GrgSell))
            GarageMenu2.AddItem(New UIMenuItem(GrgMove))
            GarageMenu2.AddItem(New UIMenuItem(GrgTransfer))
            GarageMenu2.AddItem(New UIMenuItem(GrgPlate))
            GarageMenu2.AddItem(New UIMenuItem(GrgRename))
            GarageMenu2.RefreshIndex()
            If SixOrTen = "Ten" Then
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(6))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(7))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(8))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(9))
                SelectedGarage = "Ten"
            ElseIf SixOrTen = "Twenty"
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(6))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(7))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(8))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(9))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(10))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(11))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(12))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(13))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(14))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(15))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(16))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(17))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(18))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(19))
                SelectedGarage = "Twenty"
            Else
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                SelectedGarage = "Six"
            End If
            AddHandler GarageMenu2.OnItemSelect, AddressOf ItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GarageMenuAddITem(ByRef Menu As UIMenu, ByRef Item As UIMenuItem, FilePath As String, VehicleFile As String)
        If IO.File.Exists(FilePath & VehicleFile) Then
            Dim Active As String = ReadCfgValue("Active", FilePath & VehicleFile)
            Dim Nick As String = ReadCfgValue("VehicleNick", FilePath & VehicleFile)
            If Nick <> "" Then
                Item = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", FilePath & VehicleFile) & ")", GrgSelectVeh)
            Else
                Item = New UIMenuItem(ReadCfgValue("VehicleName", FilePath & VehicleFile) & " (" & ReadCfgValue("PlateNumber", FilePath & VehicleFile) & ")", GrgSelectVeh)
            End If
            Menu.AddItem(Item)
            With Item
                .SubString1 = VehicleFile
                If Active = "True" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    .Enabled = False
                End If
            End With
        Else
            Item = New UIMenuItem("Empty")
            Menu.AddItem(Item)
            With Item
                .SubString1 = VehicleFile
                .Enabled = False
            End With
        End If
    End Sub

    Public Shared Sub CreateGarageMenu(file As String, Optional Twenty As Boolean = False)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()

            If Twenty Then
                GarageMenuAddITem(GarageMenu, GarageMenuItem(0), file, "vehicle_0.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(1), file, "vehicle_1.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(2), file, "vehicle_2.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(3), file, "vehicle_3.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(4), file, "vehicle_4.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(5), file, "vehicle_5.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(6), file, "vehicle_6.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(7), file, "vehicle_7.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(8), file, "vehicle_8.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(9), file, "vehicle_9.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(10), file, "vehicle_10.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(11), file, "vehicle_11.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(12), file, "vehicle_12.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(13), file, "vehicle_13.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(14), file, "vehicle_14.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(15), file, "vehicle_15.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(16), file, "vehicle_16.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(17), file, "vehicle_17.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(18), file, "vehicle_18.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(19), file, "vehicle_19.cfg")
            Else
                GarageMenuAddITem(GarageMenu, GarageMenuItem(0), file, "vehicle_0.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(1), file, "vehicle_1.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(2), file, "vehicle_2.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(3), file, "vehicle_3.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(4), file, "vehicle_4.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(5), file, "vehicle_5.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(6), file, "vehicle_6.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(7), file, "vehicle_7.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(8), file, "vehicle_8.cfg")
                GarageMenuAddITem(GarageMenu, GarageMenuItem(9), file, "vehicle_9.cfg")
            End If


            GarageMenu.RefreshIndex()
            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler GarageMenu.OnIndexChange, AddressOf GrgMoveIndexChangeHandler
            AddHandler GarageMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu6CarGarage(file As String)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()

            GarageMenuAddITem(GarageMenu, GarageMenuItem(0), file, "vehicle_0.cfg")
            GarageMenuAddITem(GarageMenu, GarageMenuItem(1), file, "vehicle_1.cfg")
            GarageMenuAddITem(GarageMenu, GarageMenuItem(2), file, "vehicle_2.cfg")
            GarageMenuAddITem(GarageMenu, GarageMenuItem(3), file, "vehicle_3.cfg")
            GarageMenuAddITem(GarageMenu, GarageMenuItem(4), file, "vehicle_4.cfg")
            GarageMenuAddITem(GarageMenu, GarageMenuItem(5), file, "vehicle_5.cfg")

            GarageMenu.RefreshIndex()
            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler GarageMenu.OnIndexChange, AddressOf GrgMoveIndexChangeHandler
            AddHandler GarageMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CategoryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ReturnVeh Then
                ReturnVehicle(selectedItem.SubString1)
            ElseIf Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.Car AndAlso Not selectedItem.Text = ReturnVeh Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", selectedItem.SubString1)
                Dim Active As String = ReadCfgValue("Active", selectedItem.SubString1)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", selectedItem.SubString1)

                If GetPlayerName() = "Michael" AndAlso Active = "False" Then
                    Michael_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf GetPlayerName() = "Franklin" AndAlso Active = "False" Then
                    Franklin_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf GetPlayerName() = “Trevor" AndAlso Active = "False" Then
                    Trevor_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf GetPlayerName() = "Player3" AndAlso Active = "False" Then
                    Player3_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                End If
            End If
            sender.Visible = False
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PhoneMenuItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Select Case selectedItem.Text
            Case _Mechanic
                Call_Mechanic()
            Case _Pegasus
                Call_Pegasus(True)
            Case Website.BennysOriginal
                Website.Call_Benny()
            Case Website.DockTease
                Website.Call_DockTease()
            Case Website.ElitasTravel
                Website.Call_ElitasTravel()
            Case Website.LegendaryMotorsport
                Website.Call_Legendary()
            Case Website.PedalToMetal
                Website.Call_PedalToMetal()
            Case Website.SouthernSA
                Website.Call_SouthernSA()
            Case Website.WarstockCache
                Website.Call_Warstock()
        End Select
        sender.Visible = False
    End Sub

    Public Shared Sub TransVehItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            Dim TargetPathDir As String = Nothing
            Select Case selectedItem.Text
                Case itemAS3.Text
                    TargetPathDir = _3AltaStreet.Apartment.GaragePath
                Case itemIW4.Text
                    TargetPathDir = _4IntegrityWay.Apartment.GaragePath
                Case itemIW4HL.Text
                    TargetPathDir = _4IntegrityWay.Apartment.GaragePath
                Case itemDPH.Text
                    TargetPathDir = DelPerroHeight.Apartment.GaragePath
                Case itemDPHHL.Text
                    TargetPathDir = DelPerroHeight.ApartmentHL.GaragePath
                Case itemDT.Text
                    TargetPathDir = DreamTower.Apartment.GaragePath
                Case itemET.Text
                    TargetPathDir = EclipseTower.Apartment.GaragePath
                Case itemETHL.Text
                    TargetPathDir = EclipseTower.ApartmentHL.GaragePath
                Case itemRM.Text
                    TargetPathDir = RichardMajestic.Apartment.GaragePath
                Case itemRMHL.Text
                    TargetPathDir = RichardMajestic.ApartmentHL.GaragePath
                Case itemTT.Text
                    TargetPathDir = TinselTower.Apartment.GaragePath
                Case itemTTHL.Text
                    TargetPathDir = TinselTower.ApartmentHL.GaragePath
                Case itemWP.Text
                    TargetPathDir = WeazelPlaza.Apartment.GaragePath
                Case itemVB.Text
                    TargetPathDir = VespucciBlvd.Apartment.GaragePath
                Case itemNC2044.Text
                    TargetPathDir = NorthConker2044.Apartment.GaragePath
                Case itemHA2862.Text
                    TargetPathDir = HillcrestAve2862.Apartment.GaragePath
                Case itemHA2868.Text
                    TargetPathDir = HillcrestAve2868.Apartment.GaragePath
                Case itemWO3655.Text
                    TargetPathDir = WildOats3655.Apartment.GaragePath
                Case itemNC2045.Text
                    TargetPathDir = NorthConker2045.Apartment.GaragePath
                Case itemMR2117.Text
                    TargetPathDir = MiltonRd2117.Apartment.GaragePath
                Case itemHA2874.Text
                    TargetPathDir = HillcrestAve2874._Apartment.GaragePath
                Case itemWD3677.Text
                    TargetPathDir = Whispymound3677.Apartment.GaragePath
                Case itemMW2113.Text
                    TargetPathDir = MadWayne2113.Apartment.GaragePath
                Case itemETP1.Text
                    TargetPathDir = EclipseTower.ApartmentPS1.GaragePath
                Case itemETP2.Text
                    TargetPathDir = EclipseTower.ApartmentPS2.GaragePath
                Case itemETP3.Text
                    TargetPathDir = EclipseTower.ApartmentPS3.GaragePath
                Case itemBCA.Text
                    TargetPathDir = BayCityAve.Apartment.GaragePath
                Case itemBDP.Text
                    TargetPathDir = BlvdDelPerro.Apartment.GaragePath
                Case itemCA.Text
                    TargetPathDir = CougarAve.Apartment.GaragePath
                Case itemHA.Text
                    TargetPathDir = HangmanAve.Apartment.GaragePath
                Case itemLLB0604.Text
                    TargetPathDir = LasLagunasBlvd0604.Apartment.GaragePath
                Case itemLLB2143.Text
                    TargetPathDir = LasLagunasBlvd2143.Apartment.GaragePath
                Case itemMR0184.Text
                    TargetPathDir = MiltonRd0184.Apartment.GaragePath
                Case itemPower.Text
                    TargetPathDir = PowerSt.Apartment.GaragePath
                Case itemPD4401.Text
                    TargetPathDir = ProcopioDr4401.Apartment.GaragePath
                Case itemPD4584.Text
                    TargetPathDir = ProcopioDr4584.Apartment.GaragePath
                Case itemProsperity.Text
                    TargetPathDir = ProsperitySt.Apartment.GaragePath
                Case itemSVS.Text
                    TargetPathDir = SanVitasSt.Apartment.GaragePath
                Case itemSMMD.Text
                    TargetPathDir = SouthMoMiltonDr.Apartment.GaragePath
                Case itemSRD0325.Text
                    TargetPathDir = SouthRockfordDrive0325.Apartment.GaragePath
                Case itemSA.Text
                    TargetPathDir = SpanishAve.Apartment.GaragePath
                Case itemSR.Text
                    TargetPathDir = SustanciaRd.Apartment.GaragePath
                Case itemTR.Text
                    TargetPathDir = TheRoyale.Apartment.GaragePath
                Case itemGA.Text
                    TargetPathDir = GrapeseedAve.Apartment.GaragePath
                Case itemPB.Text
                    TargetPathDir = PaletoBlvd.Apartment.GaragePath
                Case itemSRD0112.Text
                    TargetPathDir = SouthRockfordDr0112.Apartment.GaragePath
                Case itemZA.Text
                    TargetPathDir = ZancudoAve.Apartment.GaragePath
                    'Case itemMBW.Text '1.10 update
                    '    TargetPathDir = MazeBankWest.Apartment.GaragePath
            End Select

            If IO.File.Exists(TargetPathDir & "vehicle_0.cfg") = False Then
                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_0.cfg")
            Else
                If IO.File.Exists(TargetPathDir & "vehicle_1.cfg") = False Then
                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_1.cfg")
                Else
                    If IO.File.Exists(TargetPathDir & "vehicle_2.cfg") = False Then
                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_2.cfg")
                    Else
                        If IO.File.Exists(TargetPathDir & "vehicle_3.cfg") = False Then
                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_3.cfg")
                        Else
                            If IO.File.Exists(TargetPathDir & "vehicle_4.cfg") = False Then
                                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_4.cfg")
                            Else
                                If IO.File.Exists(TargetPathDir & "vehicle_5.cfg") = False Then
                                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_5.cfg")
                                Else
                                    If IO.File.Exists(TargetPathDir & "vehicle_6.cfg") = False Then
                                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_6.cfg")
                                    Else
                                        If IO.File.Exists(TargetPathDir & "vehicle_7.cfg") = False Then
                                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_7.cfg")
                                        Else
                                            If IO.File.Exists(TargetPathDir & "vehicle_8.cfg") = False Then
                                                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_8.cfg")
                                            Else
                                                If IO.File.Exists(TargetPathDir & "vehicle_9.cfg") = False Then
                                                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_9.cfg")
                                                Else
                                                    If IO.File.Exists(TargetPathDir & "vehicle_10.cfg") = False Then
                                                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_10.cfg")
                                                    Else
                                                        If IO.File.Exists(TargetPathDir & "vehicle_11.cfg") = False Then
                                                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_11.cfg")
                                                        Else
                                                            If IO.File.Exists(TargetPathDir & "vehicle_12.cfg") = False Then
                                                                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_12.cfg")
                                                            Else
                                                                If IO.File.Exists(TargetPathDir & "vehicle_13.cfg") = False Then
                                                                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_13.cfg")
                                                                Else
                                                                    If IO.File.Exists(TargetPathDir & "vehicle_14.cfg") = False Then
                                                                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_14.cfg")
                                                                    Else
                                                                        If IO.File.Exists(TargetPathDir & "vehicle_15.cfg") = False Then
                                                                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_15.cfg")
                                                                        Else
                                                                            If IO.File.Exists(TargetPathDir & "vehicle_16.cfg") = False Then
                                                                                IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_16.cfg")
                                                                            Else
                                                                                If IO.File.Exists(TargetPathDir & "vehicle_17.cfg") = False Then
                                                                                    IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_17.cfg")
                                                                                Else
                                                                                    If IO.File.Exists(TargetPathDir & "vehicle_18.cfg") = False Then
                                                                                        IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_18.cfg")
                                                                                    Else
                                                                                        If IO.File.Exists(TargetPathDir & "vehicle_19.cfg") = False Then
                                                                                            IO.File.Move(Path & GarageMenuSelectedFile, TargetPathDir & "vehicle_19.cfg")
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
            If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
            If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
            'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
            sender.Visible = False
            GarageMenu.Visible = True
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GrgMoveItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            MoveMenuSelectedItem = selectedItem.Text
            MoveMenuSelectedFile = selectedItem.SubString1
            MoveMenuSelectedIndex = index

            If selectedItem.Text <> GarageMenuSelectedItem Then
                If IO.File.Exists(Path & GarageMenuSelectedFile) = True AndAlso IO.File.Exists(Path & MoveMenuSelectedFile) = True Then
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & "vehicle.cfg")
                    IO.File.Move(Path & MoveMenuSelectedFile, Path & GarageMenuSelectedFile)
                    IO.File.Move(Path & "vehicle.cfg", Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                Else
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                End If
            Else
                sender.Visible = False
                GarageMenu.Visible = True
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GrgMoveIndexChangeHandler(sender As UIMenu, index As Integer)
        MoveIndex = index
        'If SelectedGarage = "Twenty" Then
        '    Select Case index
        '        Case 0 To 5
        '            World.DestroyAllCameras()
        '            World.RenderingCamera = World.CreateCamera(TwentyCarGarage.Floor1CamPos, TwentyCarGarage.Floor1CamRot, 50)
        '        Case 6 To 12
        '            World.DestroyAllCameras()
        '            World.RenderingCamera = World.CreateCamera(TwentyCarGarage.Floor2CamPos, TwentyCarGarage.Floor2CamRot, 50)
        '        Case 13 To 19
        '            World.DestroyAllCameras()
        '            World.RenderingCamera = World.CreateCamera(TwentyCarGarage.Floor3CamPos, TwentyCarGarage.Floor3CamRot, 50)
        '        Case Else
        '            World.DestroyAllCameras()
        '            World.RenderingCamera = World.CreateCamera(TwentyCarGarage.Floor1CamPos, TwentyCarGarage.Floor1CamRot, 50)
        '    End Select
        'End If
    End Sub

    Public Shared Sub PegasusConfirmItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If selectedItem.Text = PegasusDeliver Then
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", PegasusSelectedVehicleFile)
            Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", PegasusSelectedVehicleFile)

            If GetPlayerName() = "Michael" Then
                If Not MPV10 = Nothing Then
                    If World.GetDistance(playerPed.Position, MPV10.Position) < 50.0 Then
                        Exit Sub
                    Else
                        MPV10.CurrentBlip.Remove()
                        MPV10.Delete()
                    End If
                End If
                MPV10 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                If MPV10.ClassType = VehicleClass.Boats Then MPV10.Position = GetPlayerZoneForBoat(playerPed)
                If MPV10.ClassType = VehicleClass.Planes Then MPV10.Position = GetPlayerZoneForPlane(playerPed)
                If MPV10.ClassType = VehicleClass.Helicopters Then MPV10.Position = GetPlayerZoneForHeli(playerPed)
                MPV10.PlaceOnGround()
                MPV10.AddBlip()
                If MPV10.ClassType = VehicleClass.Boats Then
                    MPV10.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf MPV10.ClassType = VehicleClass.Helicopters Then
                    MPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf MPV10.ClassType = VehicleClass.Utility
                    MPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf MPV10.ClassType = VehicleClass.Planes Then
                    MPV10.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf MPV10.ClassType = VehicleClass.Military Then
                    MPV10.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    MPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                MPV10.CurrentBlip.Color = BlipColor2.Michael
                MPV10.CurrentBlip.Name = MPV10.FriendlyName
                SetModKit(MPV10, PegasusSelectedVehicleFile)
                If Not (MPV10.ClassType = VehicleClass.Boats Or MPV10.ClassType = VehicleClass.Helicopters Or MPV10.ClassType = VehicleClass.Planes) Then
                    CreateMechanicInVehicle(MPV10)
                Else
                    If World.GetDistance(playerPed.Position, MPV10.Position) > 50.0 Then
                        MPVV10 = MPV10.Position
                        MPVVB10 = World.CreateBlip(MPVV10)
                        MPVVB10.Sprite = MPV10.CurrentBlip.Sprite
                        MPVVB10.Color = BlipColor2.Michael
                        MPVVB10.Name = MPV10.FriendlyName
                        MPVF10 = PegasusSelectedVehicleFile
                        MPV10.Delete()
                    End If
                End If
            ElseIf GetPlayerName() = "Franklin" Then
                If Not FPV10 = Nothing Then
                    If World.GetDistance(playerPed.Position, FPV10.Position) < 50.0 Then
                        Exit Sub
                    Else
                        FPV10.CurrentBlip.Remove()
                        FPV10.Delete()
                    End If
                End If
                FPV10 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                If FPV10.ClassType = VehicleClass.Boats Then FPV10.Position = GetPlayerZoneForBoat(playerPed)
                If FPV10.ClassType = VehicleClass.Planes Then FPV10.Position = GetPlayerZoneForPlane(playerPed)
                If FPV10.ClassType = VehicleClass.Helicopters Then FPV10.Position = GetPlayerZoneForHeli(playerPed)
                FPV10.PlaceOnGround()
                FPV10.AddBlip()
                If FPV10.ClassType = VehicleClass.Boats Then
                    FPV10.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf FPV10.ClassType = VehicleClass.Helicopters Then
                    FPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf FPV10.ClassType = VehicleClass.Utility
                    FPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf FPV10.ClassType = VehicleClass.Planes Then
                    FPV10.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf FPV10.ClassType = VehicleClass.Military Then
                    FPV10.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    FPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                FPV10.CurrentBlip.Color = BlipColor2.Franklin
                FPV10.CurrentBlip.Name = FPV10.FriendlyName
                SetModKit(FPV10, PegasusSelectedVehicleFile)
                If Not (FPV10.ClassType = VehicleClass.Boats Or FPV10.ClassType = VehicleClass.Helicopters Or FPV10.ClassType = VehicleClass.Planes) Then
                    CreateMechanicInVehicle(FPV10)
                Else
                    If World.GetDistance(playerPed.Position, FPV10.Position) > 50.0 Then
                        FPVV10 = FPV10.Position
                        FPVVB10 = World.CreateBlip(FPVV10)
                        FPVVB10.Sprite = FPV10.CurrentBlip.Sprite
                        FPVVB10.Color = BlipColor2.Franklin
                        FPVVB10.Name = FPV10.FriendlyName
                        FPVF10 = PegasusSelectedVehicleFile
                        FPV10.Delete()
                    End If
                End If
            ElseIf GetPlayerName() = “Trevor" Then
                If Not TPV10 = Nothing Then
                    If World.GetDistance(playerPed.Position, TPV10.Position) < 50.0 Then
                        Exit Sub
                    Else
                        TPV10.CurrentBlip.Remove()
                        TPV10.Delete()
                    End If
                End If
                TPV10 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                If TPV10.ClassType = VehicleClass.Boats Then TPV10.Position = GetPlayerZoneForBoat(playerPed)
                If TPV10.ClassType = VehicleClass.Planes Then TPV10.Position = GetPlayerZoneForPlane(playerPed)
                If TPV10.ClassType = VehicleClass.Helicopters Then TPV10.Position = GetPlayerZoneForHeli(playerPed)
                TPV10.PlaceOnGround()
                TPV10.AddBlip()
                If TPV10.ClassType = VehicleClass.Boats Then
                    TPV10.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf TPV10.ClassType = VehicleClass.Helicopters Then
                    TPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf TPV10.ClassType = VehicleClass.Utility
                    TPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf TPV10.ClassType = VehicleClass.Planes Then
                    TPV10.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf TPV10.ClassType = VehicleClass.Military Then
                    TPV10.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    TPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                TPV10.CurrentBlip.Color = BlipColor2.Trevor
                TPV10.CurrentBlip.Name = TPV10.FriendlyName
                SetModKit(TPV10, PegasusSelectedVehicleFile)
                If Not (TPV10.ClassType = VehicleClass.Boats Or TPV10.ClassType = VehicleClass.Helicopters Or TPV10.ClassType = VehicleClass.Planes) Then
                    CreateMechanicInVehicle(TPV10)
                Else
                    If World.GetDistance(playerPed.Position, TPV10.Position) > 50.0 Then
                        TPVV10 = TPV10.Position
                        TPVVB10 = World.CreateBlip(TPVV10)
                        TPVVB10.Sprite = TPV10.CurrentBlip.Sprite
                        TPVVB10.Color = BlipColor2.Trevor
                        TPVVB10.Name = TPV10.FriendlyName
                        TPVF10 = PegasusSelectedVehicleFile
                        TPV10.Delete()
                    End If
                End If
            ElseIf GetPlayerName() = "Player3" Then
                If Not PPV10 = Nothing Then
                    If World.GetDistance(playerPed.Position, PPV10.Position) < 50.0 Then
                        Exit Sub
                    Else
                        PPV10.CurrentBlip.Remove()
                        PPV10.Delete()
                    End If
                End If
                PPV10 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                If PPV10.ClassType = VehicleClass.Boats Then PPV10.Position = GetPlayerZoneForBoat(playerPed)
                If PPV10.ClassType = VehicleClass.Planes Then PPV10.Position = GetPlayerZoneForPlane(playerPed)
                If PPV10.ClassType = VehicleClass.Helicopters Then PPV10.Position = GetPlayerZoneForHeli(playerPed)
                PPV10.PlaceOnGround()
                PPV10.AddBlip()
                If PPV10.ClassType = VehicleClass.Boats Then
                    PPV10.CurrentBlip.Sprite = BlipSprite.Boat
                ElseIf PPV10.ClassType = VehicleClass.Helicopters Then
                    PPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                ElseIf PPV10.ClassType = VehicleClass.Utility
                    PPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                ElseIf PPV10.ClassType = VehicleClass.Planes Then
                    PPV10.CurrentBlip.Sprite = BlipSprite.Plane
                ElseIf PPV10.ClassType = VehicleClass.Military Then
                    PPV10.CurrentBlip.Sprite = BlipSprite.Tank
                Else
                    PPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                End If
                PPV10.CurrentBlip.Color = BlipColor.Yellow
                PPV10.CurrentBlip.Name = PPV10.FriendlyName
                SetModKit(PPV10, PegasusSelectedVehicleFile)
                If Not (PPV10.ClassType = VehicleClass.Boats Or PPV10.ClassType = VehicleClass.Helicopters Or PPV10.ClassType = VehicleClass.Planes) Then
                    CreateMechanicInVehicle(PPV10)
                Else
                    If World.GetDistance(playerPed.Position, PPV10.Position) > 50.0 Then
                        PPVV10 = PPV10.Position
                        PPVVB10 = World.CreateBlip(PPVV10)
                        PPVVB10.Sprite = PPV10.CurrentBlip.Sprite
                        PPVVB10.Color = BlipColor.Yellow
                        PPVVB10.Name = PPV10.FriendlyName
                        PPVF10 = PegasusSelectedVehicleFile
                        PPV10.Delete()
                    End If
                End If
            End If
            SinglePlayerApartment.player.Money = (playerCash - 200)
            SoundPlayer(SoundPathDir & "pegasus_we_are_locating_a_suitable_drop_off_location.wav")
        ElseIf selectedItem.Text = PegasusDelete Then
            IO.File.Delete(PegasusSelectedVehicleFile)
            Call_Pegasus(False)
        End If
        sender.Visible = False
    End Sub

    Public Shared Sub PegasusItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        PegasusSelectedVehicleFile = selectedItem.SubString1
        sender.Visible = False
        PegasusConfirmMenu.Visible = Not PegasusConfirmMenu.Visible
    End Sub

    Public Shared Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If sender Is GarageMenu AndAlso Not selectedItem.Text = "Empty" Then
                GarageMenuSelectedItem = selectedItem.Text
                GarageMenuSelectedFile = selectedItem.SubString1
            End If

            If selectedItem.Text = GrgRemove Then
                IO.File.Delete(Path & GarageMenuSelectedFile)
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRemoveAndDrive Then
                If SelectedGarage = "Ten" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Wait(500)
                        Dim tempVeh As Vehicle
                        playerPed.Position = TenCarGarage.lastLocationGarageOutVector
                        tempVeh = CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), TenCarGarage.lastLocationGarageOutVector, TenCarGarage.lastLocationGarageOutHeading)
                        SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                        tempVeh.MarkAsNoLongerNeeded()
                        SetIntoVehicle(playerPed, tempVeh, VehicleSeat.Driver)
                        IO.File.Delete(Path & GarageMenuSelectedFile)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        sender.Visible = False
                        Wait(500)
                        Game.FadeScreenIn(500)
                        TenCarGarage.ShowAllHiddenMapObject()
                        UnLoadMPDLCMap()
                    End If
                ElseIf SelectedGarage = "Six" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Wait(500)
                        Dim tempVeh As Vehicle
                        playerPed.Position = SixCarGarage.lastLocationGarageOutVector
                        tempVeh = CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), SixCarGarage.lastLocationGarageOutVector, SixCarGarage.lastLocationGarageOutHeading)
                        SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                        tempVeh.MarkAsNoLongerNeeded()
                        SetIntoVehicle(playerPed, tempVeh, VehicleSeat.Driver)
                        IO.File.Delete(Path & GarageMenuSelectedFile)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        sender.Visible = False
                        Wait(500)
                        Game.FadeScreenIn(500)
                        UnLoadMPDLCMap()
                    End If
                    'ElseIf SelectedGarage = "Twenty" Then
                    '    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                    '        Game.FadeScreenOut(500)
                    '        Wait(500)
                    '        Dim tempVeh As Vehicle
                    '        playerPed.Position = TenCarGarage.lastLocationGarageOutVector
                    '        tempVeh = CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), TwentyCarGarage.lastLocationGarageOutVector, TwentyCarGarage.lastLocationGarageOutHeading)
                    '        SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                    '        tempVeh.MarkAsNoLongerNeeded()
                    '        SetIntoVehicle(playerPed, tempVeh, VehicleSeat.Driver)
                    '        IO.File.Delete(Path & GarageMenuSelectedFile)
                    '        World.DestroyAllCameras()
                    '        World.RenderingCamera = Nothing
                    '        sender.Visible = False
                    '        Wait(500)
                    '        Game.FadeScreenIn(500)
                    '        UnLoadMPDLCMap()
                    '    End If
                End If
            ElseIf selectedItem.Text = GrgSell Then
                Dim VehModel As String = ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile)
                Dim VehPrice As Integer = GetVehiclePrice(Path & GarageMenuSelectedFile)
                If VehPrice = 0 Then
                    UI.ShowSubtitle(GrgTooHot)
                Else
                    Select Case GarageMenuSelectedFile
                        Case "vehicle_0.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh0.Delete()
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh0.Delete()
                            Else
                                SixCarGarage.veh0.Delete()
                            End If
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh1.Delete()
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh1.Delete()
                            Else
                                SixCarGarage.veh1.Delete()
                            End If
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh2.Delete()
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh2.Delete()
                            Else
                                SixCarGarage.veh2.Delete()
                            End If
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh3.Delete()
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh3.Delete()
                            Else
                                SixCarGarage.veh3.Delete()
                            End If
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh4.Delete()
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh4.Delete()
                            Else
                                SixCarGarage.veh4.Delete()
                            End If
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh5.Delete()
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh5.Delete()
                            Else
                                SixCarGarage.veh5.Delete()
                            End If
                        Case "vehicle_6.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh6.Delete()
                            Else
                                TenCarGarage.veh6.Delete()
                            End If
                        Case "vehicle_7.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh7.Delete()
                            Else
                                TenCarGarage.veh7.Delete()
                            End If
                        Case "vehicle_8.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh8.Delete()
                            Else
                                TenCarGarage.veh8.Delete()
                            End If
                        Case "vehicle_9.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh9.Delete()
                            Else
                                TenCarGarage.veh9.Delete()
                            End If
                            'Case "vehicle_10.cfg"
                            '    TwentyCarGarage.veh10.Delete()
                            'Case "vehicle_11.cfg"
                            '    TwentyCarGarage.veh11.Delete()
                            'Case "vehicle_12.cfg"
                            '    TwentyCarGarage.veh12.Delete()
                            'Case "vehicle_13.cfg"
                            '    TwentyCarGarage.veh13.Delete()
                            'Case "vehicle_14.cfg"
                            '    TwentyCarGarage.veh14.Delete()
                            'Case "vehicle_15.cfg"
                            '    TwentyCarGarage.veh15.Delete()
                            'Case "vehicle_16.cfg"
                            '    TwentyCarGarage.veh16.Delete()
                            'Case "vehicle_17.cfg"
                            '    TwentyCarGarage.veh17.Delete()
                            'Case "vehicle_18.cfg"
                            '    TwentyCarGarage.veh18.Delete()
                            'Case "vehicle_19.cfg"
                            '    TwentyCarGarage.veh19.Delete()
                    End Select
                    SinglePlayerApartment.player.Money = (playerCash + VehPrice)
                    CreateGarageMenu(Path)
                    IO.File.Delete(Path & GarageMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                End If
            ElseIf selectedItem.Text = GrgMove Then
                CreateMoveMenu(Path, SelectedGarage)
                sender.Visible = False
                GrgMoveMenu.Visible = True
            ElseIf selectedItem.Text = GrgPlate Then
                Dim VehPlate As String = Game.GetUserInput(ReadCfgValue("PlateNumber", Path & GarageMenuSelectedFile), 9)
                If VehPlate <> "" Then
                    Select Case GarageMenuSelectedFile
                        Case "vehicle_0.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh0.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh0.NumberPlate, Path & GarageMenuSelectedFile)
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh0.NumberPlate = VehPlate
                                '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh0.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh0.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh0.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh1.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh1.NumberPlate = VehPlate
                                '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh1.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh2.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh2.NumberPlate = VehPlate
                                '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh2.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh3.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh3.NumberPlate = VehPlate
                                '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh3.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh4.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh4.NumberPlate = VehPlate
                                '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh4.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh5.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                                'ElseIf SelectedGarage = "Twenty" Then
                                '    TwentyCarGarage.veh5.NumberPlate = VehPlate
                                '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh5.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_6.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh6.NumberPlate = VehPlate
                                'WriteCfgValue("PlateNumber", TwentyCarGarage.veh6.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                TenCarGarage.veh6.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh6.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_7.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh7.NumberPlate = VehPlate
                                'WriteCfgValue("PlateNumber", TwentyCarGarage.veh7.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                TenCarGarage.veh7.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh7.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_8.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh8.NumberPlate = VehPlate
                                'WriteCfgValue("PlateNumber", TwentyCarGarage.veh8.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                TenCarGarage.veh8.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh8.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_9.cfg"
                            If SelectedGarage = "Twenty" Then
                                'TwentyCarGarage.veh9.NumberPlate = VehPlate
                                'WriteCfgValue("PlateNumber", TwentyCarGarage.veh9.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                TenCarGarage.veh9.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh9.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                            'Case "vehicle_10.cfg"
                            '    TwentyCarGarage.veh10.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh10.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_11.cfg"
                            '    TwentyCarGarage.veh11.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh11.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_12.cfg"
                            '    TwentyCarGarage.veh12.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh12.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_13.cfg"
                            '    TwentyCarGarage.veh13.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh13.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_14.cfg"
                            '    TwentyCarGarage.veh14.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh14.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_15.cfg"
                            '    TwentyCarGarage.veh15.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh15.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_16.cfg"
                            '    TwentyCarGarage.veh16.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh16.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_17.cfg"
                            '    TwentyCarGarage.veh17.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh17.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_18.cfg"
                            '    TwentyCarGarage.veh18.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh18.NumberPlate, Path & GarageMenuSelectedFile)
                            'Case "vehicle_19.cfg"
                            '    TwentyCarGarage.veh19.NumberPlate = VehPlate
                            '    WriteCfgValue("PlateNumber", TwentyCarGarage.veh19.NumberPlate, Path & GarageMenuSelectedFile)
                    End Select
                End If
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRename Then
                Dim VehName As String = Game.GetUserInput(ReadCfgValue("VehicleNick", Path & GarageMenuSelectedFile), 29)
                If VehName <> "" Then
                    WriteCfgValue("VehicleNick", VehName, Path & GarageMenuSelectedFile)
                End If
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                'If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgTransfer Then
                CreateVehTransMenuApt()
                sender.Visible = False
                GrgTransMenu.Visible = True
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    'Public Shared Sub ItemSelectHandler6CarGarage(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
    '    Try
    '        If Not selectedItem.Text = "Empty" Then
    '            Select Case selectedItem.SubString1
    '                Case "vehicle_0.cfg"
    '                    SixCarGarage.veh0.Delete()
    '                Case "vehicle_1.cfg"
    '                    SixCarGarage.veh1.Delete()
    '                Case "vehicle_2.cfg"
    '                    SixCarGarage.veh2.Delete()
    '                Case "vehicle_3.cfg"
    '                    SixCarGarage.veh3.Delete()
    '                Case "vehicle_4.cfg"
    '                    SixCarGarage.veh4.Delete()
    '                Case "vehicle_5.cfg"
    '                    SixCarGarage.veh5.Delete()
    '            End Select
    '            IO.File.Delete(Path & selectedItem.SubString1)
    '            selectedItem.Text = "Empty"
    '        End If
    '    Catch ex As Exception
    '        logger.Log(ex.Message & " " & ex.StackTrace)
    '    End Try
    'End Sub

    Public Shared Sub PegasusConfirmMenuCloseHandler(sender As UIMenu)
        Dim r As Random = New Random
        Dim rd As Integer = r.Next(1, 5)
        Select Case rd
            Case 1, 2
                SoundPlayer(SoundPathDir & "pegasus_for_your_future_transport_need.wav")
            Case 3, 4
                SoundPlayer(SoundPathDir & "pegasus_call_again.wav")
        End Select

    End Sub

    Public Shared Sub CategoryInGarageMenuCloseHandler(sender As UIMenu)
        MoveIndex = -1
    End Sub

    Public Shared Sub CategoryMenuCloseHandler(sender As UIMenu)
        SoundPlayer(SoundPathDir & "mechanic_get_back_to_work_then.wav")
    End Sub

    Public Shared Sub GrgMoveMenuCloseHandler(sender As UIMenu)
        MoveIndex = -1
        GarageMenu2.Visible = True
    End Sub

    Public Shared Sub MenuCloseHandler(sender As UIMenu)
        MoveIndex = -1
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            If Not Game.IsLoading Then
                _menuPool.ProcessMenus()

                If Not MPV0 = Nothing Then MPVD = World.GetDistance(playerPed.Position, MPV0.Position)
                If Not FPV0 = Nothing Then FPVD = World.GetDistance(playerPed.Position, FPV0.Position)
                If Not TPV0 = Nothing Then TPVD = World.GetDistance(playerPed.Position, TPV0.Position)
                If Not PPV0 = Nothing Then PPVD = World.GetDistance(playerPed.Position, PPV0.Position)

                If (Native.Function.Call(Of Boolean)(Native.Hash._GET_LAST_INPUT_METHOD, 2) = False AndAlso Game.IsControlPressed(2, My.Settings.MechanicPad) AndAlso Game.IsControlPressed(2, My.Settings.SecondMechanicPad)) AndAlso (Not _menuPool.IsAnyMenuOpen() AndAlso Not Website._menuPool.IsAnyMenuOpen()) Then
                    PhoneMenu.Visible = Not PhoneMenu.Visible
                End If

                If SelectedGarage = "Ten" Then
                    Select Case MoveIndex
                        Case 0
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh0Pos.X, TenCarGarage.veh0Pos.Y, TenCarGarage.veh0Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 1
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh1Pos.X, TenCarGarage.veh1Pos.Y, TenCarGarage.veh1Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 2
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh2Pos.X, TenCarGarage.veh2Pos.Y, TenCarGarage.veh2Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 3
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh3Pos.X, TenCarGarage.veh3Pos.Y, TenCarGarage.veh3Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 4
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh4Pos.X, TenCarGarage.veh4Pos.Y, TenCarGarage.veh4Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 5
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh5Pos.X, TenCarGarage.veh5Pos.Y, TenCarGarage.veh5Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 6
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh6Pos.X, TenCarGarage.veh6Pos.Y, TenCarGarage.veh6Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 7
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh7Pos.X, TenCarGarage.veh7Pos.Y, TenCarGarage.veh7Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 8
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh8Pos.X, TenCarGarage.veh8Pos.Y, TenCarGarage.veh8Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 9
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TenCarGarage.veh9Pos.X, TenCarGarage.veh9Pos.Y, TenCarGarage.veh9Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    End Select
                ElseIf SelectedGarage = "Six" Then
                    Select Case MoveIndex
                        Case 0
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(SixCarGarage.veh0Pos.X, SixCarGarage.veh0Pos.Y, SixCarGarage.veh0Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 1
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(SixCarGarage.veh1Pos.X, SixCarGarage.veh1Pos.Y, SixCarGarage.veh1Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 2
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(SixCarGarage.veh2Pos.X, SixCarGarage.veh2Pos.Y, SixCarGarage.veh2Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 3
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(SixCarGarage.veh3Pos.X, SixCarGarage.veh3Pos.Y, SixCarGarage.veh3Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 4
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(SixCarGarage.veh4Pos.X, SixCarGarage.veh4Pos.Y, SixCarGarage.veh4Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                        Case 5
                            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(SixCarGarage.veh5Pos.X, SixCarGarage.veh5Pos.Y, SixCarGarage.veh5Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    End Select
                    'ElseIf SelectedGarage = "Twenty" Then
                    '    Select Case MoveIndex
                    '        Case 0
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh0Pos.X, TwentyCarGarage.veh0Pos.Y, TwentyCarGarage.veh0Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 1
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh1Pos.X, TwentyCarGarage.veh1Pos.Y, TwentyCarGarage.veh1Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 2
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh2Pos.X, TwentyCarGarage.veh2Pos.Y, TwentyCarGarage.veh2Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 3
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh3Pos.X, TwentyCarGarage.veh3Pos.Y, TwentyCarGarage.veh3Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 4
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh4Pos.X, TwentyCarGarage.veh4Pos.Y, TwentyCarGarage.veh4Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 5
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh5Pos.X, TwentyCarGarage.veh5Pos.Y, TwentyCarGarage.veh5Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 6
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh6Pos.X, TwentyCarGarage.veh6Pos.Y, TwentyCarGarage.veh6Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 7
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh7Pos.X, TwentyCarGarage.veh7Pos.Y, TwentyCarGarage.veh7Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 8
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh8Pos.X, TwentyCarGarage.veh8Pos.Y, TwentyCarGarage.veh8Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 9
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh9Pos.X, TwentyCarGarage.veh9Pos.Y, TwentyCarGarage.veh9Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 10
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh10Pos.X, TwentyCarGarage.veh10Pos.Y, TwentyCarGarage.veh10Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 11
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh11Pos.X, TwentyCarGarage.veh11Pos.Y, TwentyCarGarage.veh11Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 12
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh12Pos.X, TwentyCarGarage.veh12Pos.Y, TwentyCarGarage.veh12Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 13
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh13Pos.X, TwentyCarGarage.veh13Pos.Y, TwentyCarGarage.veh13Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 14
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh14Pos.X, TwentyCarGarage.veh14Pos.Y, TwentyCarGarage.veh14Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 15
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh15Pos.X, TwentyCarGarage.veh15Pos.Y, TwentyCarGarage.veh15Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 16
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh16Pos.X, TwentyCarGarage.veh16Pos.Y, TwentyCarGarage.veh16Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 17
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh17Pos.X, TwentyCarGarage.veh17Pos.Y, TwentyCarGarage.veh17Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 18
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh18Pos.X, TwentyCarGarage.veh18Pos.Y, TwentyCarGarage.veh18Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    '        Case 19
                    '            World.DrawMarker(MarkerType.UpsideDownCone, New Vector3(TwentyCarGarage.veh19Pos.X, TwentyCarGarage.veh19Pos.Y, TwentyCarGarage.veh19Pos.Z + 1.5), Vector3.Zero, Vector3.Zero, New Vector3(0.3, 0.3, 0.3), Drawing.Color.Red)
                    'End Select
                End If

                If playerPed.IsInVehicle Then
                    If Not playerPed.CurrentVehicle.CurrentBlip Is Nothing Then playerPed.CurrentVehicle.CurrentBlip.Alpha = 0
                Else
                    If Not MPV0 = Nothing Then
                        MPV0.CurrentBlip.Alpha = 255
                        MPV0.IsPersistent = MPV0.IsAlive
                        If Not MPV0.IsAlive Then ReturnVehicleIfDead(MPV0)
                    End If
                    If Not MPV10 = Nothing AndAlso MPV10.CurrentBlip.Alpha = 0 Then
                        MPV10.CurrentBlip.Alpha = 255
                        MPV10.IsPersistent = MPV10.IsAlive
                    End If
                    If Not FPV0 = Nothing Then
                        FPV0.CurrentBlip.Alpha = 255
                        FPV0.IsPersistent = FPV0.IsAlive
                        If Not FPV0.IsAlive Then ReturnVehicleIfDead(FPV0)
                    End If
                    If Not FPV10 = Nothing AndAlso FPV10.CurrentBlip.Alpha = 0 Then
                        FPV10.CurrentBlip.Alpha = 255
                        FPV10.IsPersistent = FPV10.IsAlive
                    End If
                    If Not TPV0 = Nothing Then
                        TPV0.CurrentBlip.Alpha = 255
                        TPV0.IsPersistent = TPV0.IsAlive
                        If Not TPV0.IsAlive Then ReturnVehicleIfDead(TPV0)
                    End If
                    If Not TPV10 = Nothing AndAlso TPV10.CurrentBlip.Alpha = 0 Then
                        TPV10.CurrentBlip.Alpha = 255
                        TPV10.IsPersistent = TPV10.IsAlive
                    End If
                    If Not PPV0 = Nothing Then
                        PPV0.CurrentBlip.Alpha = 255
                        PPV0.IsPersistent = PPV0.IsAlive
                        If Not PPV0.IsAlive Then ReturnVehicleIfDead(PPV0)
                    End If
                    If Not PPV10 = Nothing AndAlso PPV10.CurrentBlip.Alpha = 0 Then
                        PPV10.CurrentBlip.Alpha = 255
                        PPV10.IsPersistent = PPV10.IsAlive
                    End If
                    If Not MPV10 = Nothing AndAlso MPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                        If MPV10.ClassType = VehicleClass.Boats Then
                            MPV10.CurrentBlip.Sprite = BlipSprite.Boat
                        ElseIf MPV10.ClassType = VehicleClass.Helicopters Then
                            MPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                        ElseIf MPV10.ClassType = VehicleClass.Utility
                            MPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                        ElseIf MPV10.ClassType = VehicleClass.Planes Then
                            MPV10.CurrentBlip.Sprite = BlipSprite.Plane
                        ElseIf MPV10.ClassType = VehicleClass.Military Then
                            MPV10.CurrentBlip.Sprite = BlipSprite.Tank
                        Else
                            MPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        End If
                        MPV10.CurrentBlip.Color = BlipColor2.Michael
                        MPV10.CurrentBlip.Name = MPV10.FriendlyName
                    End If
                    If Not FPV10 = Nothing AndAlso FPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                        If FPV10.ClassType = VehicleClass.Boats Then
                            FPV10.CurrentBlip.Sprite = BlipSprite.Boat
                        ElseIf FPV10.ClassType = VehicleClass.Helicopters Then
                            FPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                        ElseIf FPV10.ClassType = VehicleClass.Utility
                            FPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                        ElseIf FPV10.ClassType = VehicleClass.Planes Then
                            FPV10.CurrentBlip.Sprite = BlipSprite.Plane
                        ElseIf FPV10.ClassType = VehicleClass.Military Then
                            FPV10.CurrentBlip.Sprite = BlipSprite.Tank
                        Else
                            FPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        End If
                        FPV10.CurrentBlip.Color = BlipColor2.Franklin
                        FPV10.CurrentBlip.Name = FPV10.FriendlyName
                    End If
                    If Not TPV10 = Nothing AndAlso TPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                        If TPV10.ClassType = VehicleClass.Boats Then
                            TPV10.CurrentBlip.Sprite = BlipSprite.Boat
                        ElseIf TPV10.ClassType = VehicleClass.Helicopters Then
                            TPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                        ElseIf TPV10.ClassType = VehicleClass.Utility
                            TPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                        ElseIf TPV10.ClassType = VehicleClass.Planes Then
                            TPV10.CurrentBlip.Sprite = BlipSprite.Plane
                        ElseIf TPV10.ClassType = VehicleClass.Military Then
                            TPV10.CurrentBlip.Sprite = BlipSprite.Tank
                        Else
                            TPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        End If
                        TPV10.CurrentBlip.Color = BlipColor2.Trevor
                        TPV10.CurrentBlip.Name = TPV10.FriendlyName
                    End If
                    If Not PPV10 = Nothing AndAlso PPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                        If PPV10.ClassType = VehicleClass.Boats Then
                            PPV10.CurrentBlip.Sprite = BlipSprite.Boat
                        ElseIf PPV10.ClassType = VehicleClass.Helicopters Then
                            PPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                        ElseIf PPV10.ClassType = VehicleClass.Utility
                            PPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                        ElseIf PPV10.ClassType = VehicleClass.Planes Then
                            PPV10.CurrentBlip.Sprite = BlipSprite.Plane
                        ElseIf PPV10.ClassType = VehicleClass.Military Then
                            PPV10.CurrentBlip.Sprite = BlipSprite.Tank
                        Else
                            PPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        End If
                        PPV10.CurrentBlip.Color = BlipColor.Yellow
                        PPV10.CurrentBlip.Name = PPV10.FriendlyName
                    End If
                End If

                If (Not MPV0 = Nothing AndAlso (Not MPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, MPV0.Position) > 50.0)) Then MPV0.Delete()
                If (Not FPV0 = Nothing AndAlso (Not FPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, FPV0.Position) > 50.0)) Then FPV0.Delete()
                If (Not TPV0 = Nothing AndAlso (Not TPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, TPV0.Position) > 50.0)) Then TPV0.Delete()
                If (Not PPV0 = Nothing AndAlso (Not PPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, PPV0.Position) > 50.0)) Then PPV0.Delete()

                If Not MPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, MPVV10) < 50.0 Then
                    Dim VehicleModel As String = ReadCfgValue("VehicleModel", MPVF10)
                    Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", MPVF10)
                    MPV10 = CreateVehicle(VehicleModel, VehicleHash, MPVV10)
                    MPV10.PlaceOnGround()
                    MPV10.AddBlip()
                    MPV10.CurrentBlip.Sprite = MPVVB10.Sprite
                    MPV10.CurrentBlip.Color = BlipColor2.Michael
                    MPV10.CurrentBlip.Name = MPV10.FriendlyName
                    SetModKit(MPV10, MPVF10)
                    MPVVB10.Remove()
                    MPVF10 = Nothing
                End If
                If Not FPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, FPVV10) < 50.0 Then
                    Dim VehicleModel As String = ReadCfgValue("VehicleModel", FPVF10)
                    Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", FPVF10)
                    FPV10 = CreateVehicle(VehicleModel, VehicleHash, FPVV10)
                    FPV10.PlaceOnGround()
                    FPV10.AddBlip()
                    FPV10.CurrentBlip.Sprite = FPVVB10.Sprite
                    FPV10.CurrentBlip.Color = BlipColor2.Franklin
                    FPV10.CurrentBlip.Name = FPV10.FriendlyName
                    SetModKit(FPV10, FPVF10)
                    FPVVB10.Remove()
                    FPVF10 = Nothing
                End If
                If Not TPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, TPVV10) < 50.0 Then
                    Dim VehicleModel As String = ReadCfgValue("VehicleModel", TPVF10)
                    Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", TPVF10)
                    TPV10 = CreateVehicle(VehicleModel, VehicleHash, TPVV10)
                    TPV10.PlaceOnGround()
                    TPV10.AddBlip()
                    TPV10.CurrentBlip.Sprite = TPVVB10.Sprite
                    TPV10.CurrentBlip.Color = BlipColor2.Trevor
                    TPV10.CurrentBlip.Name = TPV10.FriendlyName
                    SetModKit(TPV10, TPVF10)
                    TPVVB10.Remove()
                    TPVF10 = Nothing
                End If
                If Not PPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, PPVV10) < 50.0 Then
                    Dim VehicleModel As String = ReadCfgValue("VehicleModel", PPVF10)
                    Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", PPVF10)
                    PPV10 = CreateVehicle(VehicleModel, VehicleHash, PPVV10)
                    PPV10.PlaceOnGround()
                    PPV10.AddBlip()
                    PPV10.CurrentBlip.Sprite = PPVVB10.Sprite
                    PPV10.CurrentBlip.Color = BlipColor.Yellow
                    PPV10.CurrentBlip.Name = PPV10.FriendlyName
                    SetModKit(PPV10, PPVF10)
                    PPVVB10.Remove()
                    PPVF10 = Nothing
                End If

                If Native.Function.Call(Of Integer)(Hash.GET_CLOCK_HOURS) = 2 AndAlso Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MINUTES) = 0 AndAlso Native.Function.Call(Of Integer)(Hash.GET_CLOCK_SECONDS) = 0 Then
                    SinglePlayerApartment.player.Money = (playerCash - 100)
                    UI.Notify(MechanicBill)
                End If

                If Not MechanicPed = Nothing AndAlso My.Settings.VehicleSpawn = 1 Then
                    Dim veh As Vehicle = MechanicPed.LastVehicle
                    If MechanicPed.IsInVehicle AndAlso MechanicPed.Position.DistanceTo(playerPed.Position) < 5.0 Then
                        MechanicPed.Task.LeaveVehicle()
                    ElseIf Not MechanicPed.IsInVehicle Then
                        MechanicPed.Task.ReactAndFlee(playerPed)
                        MechanicPed.MarkAsNoLongerNeeded()
                    End If
                End If
            End If
        Catch ex As Exception
            If Not ex.StackTrace.Contains("MoveNext") Then logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Call_Mechanic()
        ReadMenuItems()

        CreateMechanicMenu()
        CreateVehMenuApartments(AS3Menu, itemAS3, _3AltaStreet.Apartment.GaragePath)
        CreateVehMenuApartments(DTMenu, itemDT, DreamTower.Apartment.GaragePath)
        CreateVehMenuApartments(ETMenu, itemET, EclipseTower.Apartment.GaragePath)
        CreateVehMenuApartments(ETHLMenu, itemETHL, EclipseTower.ApartmentHL.GaragePath)
        CreateVehMenuApartments(IW4Menu, itemIW4, _4IntegrityWay.Apartment.GaragePath)
        CreateVehMenuApartments(IW4HLMenu, itemIW4HL, _4IntegrityWay.ApartmentHL.GaragePath)
        CreateVehMenuApartments(DPHMenu, itemDPH, DelPerroHeight.Apartment.GaragePath)
        CreateVehMenuApartments(DPHHLMenu, itemDPHHL, DelPerroHeight.ApartmentHL.GaragePath)
        CreateVehMenuApartments(RMMenu, itemRM, RichardMajestic.Apartment.GaragePath)
        CreateVehMenuApartments(RMHLMenu, itemRMHL, RichardMajestic.ApartmentHL.GaragePath)
        CreateVehMenuApartments(TTMenu, itemTT, TinselTower.Apartment.GaragePath)
        CreateVehMenuApartments(TTHLMenu, itemTTHL, TinselTower.ApartmentHL.GaragePath)
        CreateVehMenuApartments(WPMenu, itemWP, WeazelPlaza.Apartment.GaragePath)
        CreateVehMenuApartments(NC2044Menu, itemNC2044, NorthConker2044.Apartment.GaragePath)
        CreateVehMenuApartments(HA2862Menu, itemHA2862, HillcrestAve2862.Apartment.GaragePath)
        CreateVehMenuApartments(HA2868Menu, itemHA2868, HillcrestAve2868.Apartment.GaragePath)
        CreateVehMenuApartments(WO3655Menu, itemWO3655, WildOats3655.Apartment.GaragePath)
        CreateVehMenuApartments(NC2045Menu, itemNC2045, NorthConker2045.Apartment.GaragePath)
        CreateVehMenuApartments(MR2117Menu, itemMR2117, MiltonRd2117.Apartment.GaragePath)
        CreateVehMenuApartments(HA2874Menu, itemHA2874, HillcrestAve2874._Apartment.GaragePath)
        CreateVehMenuApartments(WD3677Menu, itemWD3677, Whispymound3677.Apartment.GaragePath)
        CreateVehMenuApartments(MW2113Menu, itemMW2113, MadWayne2113.Apartment.GaragePath)
        CreateVehMenuApartments(ETP1Menu, itemETP1, EclipseTower.ApartmentPS1.GaragePath)
        CreateVehMenuApartments(ETP2Menu, itemETP2, EclipseTower.ApartmentPS2.GaragePath)
        CreateVehMenuApartments(ETP3Menu, itemETP3, EclipseTower.ApartmentPS3.GaragePath)
        CreateVehMenuApartments(BCAMenu, itemBCA, BayCityAve.Apartment.GaragePath)
        CreateVehMenuApartments(BDPMenu, itemBDP, BlvdDelPerro.Apartment.GaragePath)
        CreateVehMenuApartments(CAMenu, itemCA, CougarAve.Apartment.GaragePath)
        CreateVehMenuApartments(HAMenu, itemHA, HangmanAve.Apartment.GaragePath)
        CreateVehMenuApartments(LLB0604Menu, itemLLB0604, LasLagunasBlvd0604.Apartment.GaragePath)
        CreateVehMenuApartments(LLB2143Menu, itemLLB2143, LasLagunasBlvd2143.Apartment.GaragePath)
        CreateVehMenuApartments(MR0184Menu, itemMR0184, MiltonRd0184.Apartment.GaragePath)
        CreateVehMenuApartments(PowerMenu, itemPower, PowerSt.Apartment.GaragePath)
        CreateVehMenuApartments(PD4401Menu, itemPD4401, ProcopioDr4401.Apartment.GaragePath)
        CreateVehMenuApartments(PD4584Menu, itemPD4584, ProcopioDr4584.Apartment.GaragePath)
        CreateVehMenuApartments(ProsperityMenu, itemProsperity, ProsperitySt.Apartment.GaragePath)
        CreateVehMenuApartments(SVSMenu, itemSVS, SanVitasSt.Apartment.GaragePath)
        CreateVehMenuApartments(SMMDMenu, itemSMMD, SouthMoMiltonDr.Apartment.GaragePath)
        CreateVehMenuApartments(SRD0325Menu, itemSRD0325, SouthRockfordDrive0325.Apartment.GaragePath)
        CreateVehMenuApartments(SAMenu, itemSA, SpanishAve.Apartment.GaragePath)
        CreateVehMenuApartments(SRMenu, itemSR, SustanciaRd.Apartment.GaragePath)
        CreateVehMenuApartments(TRMenu, itemTR, TheRoyale.Apartment.GaragePath)
        CreateVehMenuApartments6(VBMenu, itemVB, VespucciBlvd.Apartment.GaragePath)
        CreateVehMenuApartments6(GAMenu, itemGA, GrapeseedAve.Apartment.GaragePath)
        CreateVehMenuApartments6(PBMenu, itemPB, PaletoBlvd.Apartment.GaragePath)
        CreateVehMenuApartments6(SRD0112Menu, itemSRD0112, SouthRockfordDr0112.Apartment.GaragePath)
        CreateVehMenuApartments6(ZAMenu, itemZA, ZancudoAve.Apartment.GaragePath)
        '1.10 update
        'CreateVehMenuApartments20(MBWMenu, itemMBW, MazeBankWest.Apartment.GaragePath)

        MechanicMenu.Visible = Not MechanicMenu.Visible

        Dim r As Random = New Random
        Dim rd As Integer = r.Next(1, 5)
        Select Case rd
            Case 1, 2
                SoundPlayer(SoundPathDir & "mechanic_u_need_something_huh.wav")
            Case 3, 4
                SoundPlayer(SoundPathDir & "mechanic_on_the_clock_some_wheels.wav")
        End Select

    End Sub

    Public Shared Sub Call_Pegasus(PlaySound As Boolean)
        Try
            Select Case GetPlayerName()
                Case "Michael"
                    CreatePegasusMenuFor(MichaelPegasusMenu, MichaelPathDir)
                    MichaelPegasusMenu.Visible = True
                Case "Franklin"
                    CreatePegasusMenuFor(FranklinPegasusMenu, FranklinPathDir)
                    FranklinPegasusMenu.Visible = True
                Case "Trevor"
                    CreatePegasusMenuFor(TrevorPegasusMenu, TrevorPathDir)
                    TrevorPegasusMenu.Visible = True
                Case "Player3"
                    CreatePegasusMenuFor(Player3PegasusMenu, Player3PathDir)
                    Player3PegasusMenu.Visible = True
            End Select
            If PlaySound = True Then
                Dim r As Random = New Random
                Dim rd As Integer = r.Next(1, 5)
                Select Case rd
                    Case 1, 2
                        SoundPlayer(SoundPathDir & "pegasus_how_can_i_help_u.wav")
                    Case 3, 4
                        SoundPlayer(SoundPathDir & "pegasus_what_do_you_need_us_to_deliver.wav")
                End Select

            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadMenuItems()
        itemAS3 = New UIMenuItem(_3AltaStreet.Apartment.Name & _3AltaStreet.Apartment.Unit)
        itemIW4 = New UIMenuItem(_4IntegrityWay.Apartment.Name & _4IntegrityWay.Apartment.Unit)
        itemIW4HL = New UIMenuItem(_4IntegrityWay.ApartmentHL.Name & _4IntegrityWay.ApartmentHL.Unit)
        itemDPH = New UIMenuItem(DelPerroHeight.Apartment.Name & DelPerroHeight.Apartment.Unit)
        itemDPHHL = New UIMenuItem(DelPerroHeight.ApartmentHL.Name & DelPerroHeight.ApartmentHL.Unit)
        itemDT = New UIMenuItem(DreamTower.Apartment.Name & DreamTower.Apartment.Unit)
        itemET = New UIMenuItem(EclipseTower.Apartment.Name & EclipseTower.Apartment.Unit)
        itemETHL = New UIMenuItem(EclipseTower.ApartmentHL.Name & EclipseTower.ApartmentHL.Unit)
        itemRM = New UIMenuItem(RichardMajestic.Apartment.Name & RichardMajestic.Apartment.Unit)
        itemRMHL = New UIMenuItem(RichardMajestic.ApartmentHL.Name & RichardMajestic.ApartmentHL.Unit)
        itemTT = New UIMenuItem(TinselTower.Apartment.Name & TinselTower.Apartment.Unit)
        itemTTHL = New UIMenuItem(TinselTower.ApartmentHL.Name & TinselTower.ApartmentHL.Unit)
        itemWP = New UIMenuItem(WeazelPlaza.Apartment.Name & WeazelPlaza.Apartment.Unit)
        itemVB = New UIMenuItem(VespucciBlvd.Apartment.Name & VespucciBlvd.Apartment.Unit)
        itemNC2044 = New UIMenuItem(NorthConker2044.Apartment.Name & NorthConker2044.Apartment.Unit)
        itemHA2862 = New UIMenuItem(HillcrestAve2862.Apartment.Name & HillcrestAve2862.Apartment.Unit)
        itemHA2868 = New UIMenuItem(HillcrestAve2868.Apartment.Name & HillcrestAve2868.Apartment.Unit)
        itemWO3655 = New UIMenuItem(WildOats3655.Apartment.Name & WildOats3655.Apartment.Unit)
        itemNC2045 = New UIMenuItem(NorthConker2045.Apartment.Name & NorthConker2045.Apartment.Unit)
        itemMR2117 = New UIMenuItem(MiltonRd2117.Apartment.Name & MiltonRd2117.Apartment.Unit)
        itemHA2874 = New UIMenuItem(HillcrestAve2874._Apartment.Name & HillcrestAve2874._Apartment.Unit)
        itemWD3677 = New UIMenuItem(Whispymound3677.Apartment.Name & Whispymound3677.Apartment.Unit)
        itemMW2113 = New UIMenuItem(MadWayne2113.Apartment.Name & MadWayne2113.Apartment.Unit)
        itemETP1 = New UIMenuItem(EclipseTower.ApartmentPS1.Name & EclipseTower.ApartmentPS1.Unit)
        itemETP2 = New UIMenuItem(EclipseTower.ApartmentPS2.Name & EclipseTower.ApartmentPS2.Unit)
        itemETP3 = New UIMenuItem(EclipseTower.ApartmentPS3.Name & EclipseTower.ApartmentPS3.Unit)
        itemBCA = New UIMenuItem(BayCityAve.Apartment.Name & BayCityAve.Apartment.Unit)
        itemBDP = New UIMenuItem(BlvdDelPerro.Apartment.Name & BlvdDelPerro.Apartment.Unit)
        itemCA = New UIMenuItem(CougarAve.Apartment.Name & CougarAve.Apartment.Unit)
        itemHA = New UIMenuItem(HangmanAve.Apartment.Name & HangmanAve.Apartment.Unit)
        itemLLB0604 = New UIMenuItem(LasLagunasBlvd0604.Apartment.Name & LasLagunasBlvd0604.Apartment.Unit)
        itemLLB2143 = New UIMenuItem(LasLagunasBlvd2143.Apartment.Name & LasLagunasBlvd2143.Apartment.Unit)
        itemMR0184 = New UIMenuItem(MiltonRd0184.Apartment.Name & MiltonRd0184.Apartment.Unit)
        itemPower = New UIMenuItem(PowerSt.Apartment.Name & PowerSt.Apartment.Unit)
        itemPD4401 = New UIMenuItem(ProcopioDr4401.Apartment.Name & ProcopioDr4401.Apartment.Unit)
        itemPD4584 = New UIMenuItem(ProcopioDr4584.Apartment.Name & ProcopioDr4584.Apartment.Unit)
        itemProsperity = New UIMenuItem(ProsperitySt.Apartment.Name & ProsperitySt.Apartment.Unit)
        itemSVS = New UIMenuItem(SanVitasSt.Apartment.Name & SanVitasSt.Apartment.Unit)
        itemSMMD = New UIMenuItem(SouthMoMiltonDr.Apartment.Name & SouthMoMiltonDr.Apartment.Unit)
        itemSRD0325 = New UIMenuItem(SouthRockfordDrive0325.Apartment.Name & SouthRockfordDrive0325.Apartment.Unit)
        itemSA = New UIMenuItem(SpanishAve.Apartment.Name & SpanishAve.Apartment.Unit)
        itemSR = New UIMenuItem(SustanciaRd.Apartment.Name & SustanciaRd.Apartment.Unit)
        itemTR = New UIMenuItem(TheRoyale.Apartment.Name & TheRoyale.Apartment.Unit)
        itemGA = New UIMenuItem(GrapeseedAve.Apartment.Name & GrapeseedAve.Apartment.Unit)
        itemPB = New UIMenuItem(PaletoBlvd.Apartment.Name & PaletoBlvd.Apartment.Unit)
        itemSRD0112 = New UIMenuItem(SouthRockfordDr0112.Apartment.Name & SouthRockfordDr0112.Apartment.Unit)
        itemZA = New UIMenuItem(ZancudoAve.Apartment.Name & ZancudoAve.Apartment.Unit)
        '1.10 update
        'itemMBW = New UIMenuItem(MazeBankWest.Apartment.Name & MazeBankWest.Apartment.Unit)
    End Sub

    Public Shared Sub CreateMechanicInVehicle(Vehicle As Vehicle)
        If My.Settings.VehicleSpawn = 1 Then
            MechanicPed = Vehicle.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Autoshop01SMM)
            DriveTo(MechanicPed, Vehicle, playerPed.Position, 20.0, 15.0, DrivingStyle.Normal)
            MechanicPed.DrivingStyle = DrivingStyle.Normal
        Else
            Wait(5000)
            Vehicle.Position = World.GetNextPositionOnStreet(playerPed.Position)
        End If
    End Sub

    Public Shared Sub ReturnAllVehiclesToGarageNEW()
        ReturnAllVehiclesToGarage(_3AltaStreet.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(_4IntegrityWay.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(_4IntegrityWay.ApartmentHL.GaragePath)
        ReturnAllVehiclesToGarage(DelPerroHeight.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(DelPerroHeight.ApartmentHL.GaragePath)
        ReturnAllVehiclesToGarage(DreamTower.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(EclipseTower.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(EclipseTower.ApartmentHL.GaragePath)
        ReturnAllVehiclesToGarage(EclipseTower.ApartmentPS1.GaragePath)
        ReturnAllVehiclesToGarage(EclipseTower.ApartmentPS2.GaragePath)
        ReturnAllVehiclesToGarage(EclipseTower.ApartmentPS3.GaragePath)
        ReturnAllVehiclesToGarage(RichardMajestic.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(RichardMajestic.ApartmentHL.GaragePath)
        ReturnAllVehiclesToGarage(TinselTower.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(TinselTower.ApartmentHL.GaragePath)
        ReturnAllVehiclesToGarage(WeazelPlaza.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(VespucciBlvd.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(NorthConker2044.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(NorthConker2045.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(HillcrestAve2862.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(HillcrestAve2868.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(WildOats3655.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(MiltonRd2117.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(HillcrestAve2874._Apartment.GaragePath)
        ReturnAllVehiclesToGarage(Whispymound3677.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(MadWayne2113.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(BayCityAve.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(BlvdDelPerro.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(CougarAve.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(HangmanAve.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(LasLagunasBlvd0604.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(LasLagunasBlvd2143.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(MiltonRd0184.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(PowerSt.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(ProcopioDr4401.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(ProcopioDr4584.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(ProsperitySt.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(SanVitasSt.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(SouthMoMiltonDr.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(SouthRockfordDrive0325.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(SpanishAve.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(SustanciaRd.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(TheRoyale.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(GrapeseedAve.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(PaletoBlvd.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(SouthRockfordDr0112.Apartment.GaragePath)
        ReturnAllVehiclesToGarage(ZancudoAve.Apartment.GaragePath)
        '1.10 update
        'ReturnAllVehiclesToGarage(MazeBankWest.Apartment.GaragePath)
    End Sub

    Public Shared Sub ReturnAllVehiclesToGarage(PathDir As String)
        Try
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_0.cfg")
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_1.cfg")
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_2.cfg")
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_3.cfg")
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_4.cfg")
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_5.cfg")
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_6.cfg")
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_7.cfg")
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_8.cfg")
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_9.cfg")
            If IO.File.Exists(PathDir & "vehicle_10.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_10.cfg")
            If IO.File.Exists(PathDir & "vehicle_11.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_11.cfg")
            If IO.File.Exists(PathDir & "vehicle_12.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_12.cfg")
            If IO.File.Exists(PathDir & "vehicle_13.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_13.cfg")
            If IO.File.Exists(PathDir & "vehicle_14.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_14.cfg")
            If IO.File.Exists(PathDir & "vehicle_15.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_15.cfg")
            If IO.File.Exists(PathDir & "vehicle_16.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_16.cfg")
            If IO.File.Exists(PathDir & "vehicle_17.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_17.cfg")
            If IO.File.Exists(PathDir & "vehicle_18.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_18.cfg")
            If IO.File.Exists(PathDir & "vehicle_19.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_19.cfg")
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ReturnVehicleIfDead(ByRef vehicle As Vehicle)
        Try
            vehicle.MarkAsNoLongerNeeded()

            Select Case playerInterior
                Case TenCarGarage.InteriorID, SixCarGarage.InteriorID
                Case Else
                    Select Case GetPlayerName()
                        Case "Michael"
                            If MPersVeh.Exist AndAlso Not MPersVeh.Insurance = 0 Then
                                If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                                Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                                DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                                WriteCfgValue("Active", "False", MPersVeh.FilePath)
                                MPersVeh.Insurance = 0
                                MPersVeh.Delete()
                            End If
                        Case "Franklin"
                            If FPersVeh.Exist AndAlso Not FPersVeh.Insurance = 0 Then
                                If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                                Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                                DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                                WriteCfgValue("Active", "False", FPersVeh.FilePath)
                                FPersVeh.Insurance = 0
                                FPersVeh.Delete()
                            End If
                        Case "Trevor"
                            If TPersVeh.Exist AndAlso Not TPersVeh.Insurance = 0 Then
                                If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                                Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                                DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                                WriteCfgValue("Active", "False", TPersVeh.FilePath)
                                TPersVeh.Insurance = 0
                                TPersVeh.Delete()
                            End If
                        Case "Player3"
                            If PPersVeh.Exist AndAlso Not PPersVeh.Insurance = 0 Then
                                If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                                Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                                DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                                WriteCfgValue("Active", "False", PPersVeh.FilePath)
                                PPersVeh.Insurance = 0
                                PPersVeh.Delete()
                            End If
                    End Select
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Michael_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If MPV0 = Nothing Then
            MPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            MPV0.AddBlip()
            MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            MPV0.CurrentBlip.Color = BlipColor2.Michael
            MPV0.CurrentBlip.IsShortRange = True
            MPV0.CurrentBlip.Name = MPV0.FriendlyName
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(MPV0, SelectedItem_Car)
            CreateMechanicInVehicle(MPV0)
            If MPersVeh.Exist() Then
                MPersVeh.Delete()
                MPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, MPV0)
            Else
                MPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, MPV0)
            End If
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If MPVD >= 30 Then
                    MPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
                    MPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    MPV0.AddBlip()
                    MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    MPV0.CurrentBlip.Color = BlipColor2.Michael
                    MPV0.CurrentBlip.IsShortRange = True
                    MPV0.CurrentBlip.Name = MPV0.FriendlyName
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(MPV0, SelectedItem_Car)
                    CreateMechanicInVehicle(MPV0)
                    If MPersVeh.Exist() Then
                        MPersVeh.Delete()
                        MPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, MPV0)
                    Else
                        MPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, MPV0)
                    End If
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    SoundPlayer(SoundPathDir & "mechanic_cant_get_your_ride.wav")
                End If
            Else
                MPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
                MPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                MPV0.AddBlip()
                MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                MPV0.CurrentBlip.Color = BlipColor2.Michael
                MPV0.CurrentBlip.IsShortRange = True
                MPV0.CurrentBlip.Name = MPV0.FriendlyName
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(MPV0, SelectedItem_Car)
                CreateMechanicInVehicle(MPV0)
                If MPersVeh.Exist() Then
                    MPersVeh.Delete()
                    MPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, MPV0)
                Else
                    MPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, MPV0)
                End If
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub Franklin_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)

        If FPV0 = Nothing Then
            FPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            FPV0.AddBlip()
            FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            FPV0.CurrentBlip.Color = BlipColor2.Franklin
            FPV0.CurrentBlip.IsShortRange = True
            FPV0.CurrentBlip.Name = FPV0.FriendlyName
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(FPV0, SelectedItem_Car)
            CreateMechanicInVehicle(FPV0)
            If FPersVeh.Exist() Then
                FPersVeh.Delete()
                FPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, FPV0)
            Else
                FPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, FPV0)
            End If
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If FPVD >= 30 Then
                    FPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
                    FPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    FPV0.AddBlip()
                    FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    FPV0.CurrentBlip.Color = BlipColor2.Franklin
                    FPV0.CurrentBlip.IsShortRange = True
                    FPV0.CurrentBlip.Name = FPV0.FriendlyName
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(FPV0, SelectedItem_Car)
                    CreateMechanicInVehicle(FPV0)
                    If FPersVeh.Exist() Then
                        FPersVeh.Delete()
                        FPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, FPV0)
                    Else
                        FPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, FPV0)
                    End If
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    SoundPlayer(SoundPathDir & "mechanic_cant_get_your_ride.wav")
                End If
            Else
                FPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
                FPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                FPV0.AddBlip()
                FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                FPV0.CurrentBlip.Color = BlipColor2.Franklin
                FPV0.CurrentBlip.IsShortRange = True
                FPV0.CurrentBlip.Name = FPV0.FriendlyName
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(FPV0, SelectedItem_Car)
                CreateMechanicInVehicle(FPV0)
                If FPersVeh.Exist() Then
                    FPersVeh.Delete()
                    FPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, FPV0)
                Else
                    FPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, FPV0)
                End If
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub Trevor_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)

        If TPV0 = Nothing Then
            TPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            TPV0.AddBlip()
            TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            TPV0.CurrentBlip.Color = BlipColor2.Trevor
            TPV0.CurrentBlip.IsShortRange = True
            TPV0.CurrentBlip.Name = TPV0.FriendlyName
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(TPV0, SelectedItem_Car)
            CreateMechanicInVehicle(TPV0)
            If TPersVeh.Exist() Then
                TPersVeh.Delete()
                TPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, TPV0)
            Else
                TPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, TPV0)
            End If
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If TPVD >= 30 Then
                    TPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
                    TPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    TPV0.AddBlip()
                    TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    TPV0.CurrentBlip.Color = BlipColor2.Trevor
                    TPV0.CurrentBlip.IsShortRange = True
                    TPV0.CurrentBlip.Name = TPV0.FriendlyName
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(TPV0, SelectedItem_Car)
                    CreateMechanicInVehicle(TPV0)
                    If TPersVeh.Exist() Then
                        TPersVeh.Delete()
                        TPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, TPV0)
                    Else
                        TPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, TPV0)
                    End If
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    SoundPlayer(SoundPathDir & "mechanic_cant_get_your_ride.wav")
                End If
            Else
                TPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
                TPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                TPV0.AddBlip()
                TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                TPV0.CurrentBlip.Color = BlipColor2.Trevor
                TPV0.CurrentBlip.IsShortRange = True
                TPV0.CurrentBlip.Name = TPV0.FriendlyName
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(TPV0, SelectedItem_Car)
                CreateMechanicInVehicle(TPV0)
                If TPersVeh.Exist() Then
                    TPersVeh.Delete()
                    TPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, TPV0)
                Else
                    TPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, TPV0)
                End If
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub Player3_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)

        If PPV0 = Nothing Then
            PPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            PPV0.AddBlip()
            PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            PPV0.CurrentBlip.Color = BlipColor.Yellow
            PPV0.CurrentBlip.IsShortRange = True
            PPV0.CurrentBlip.Name = PPV0.FriendlyName
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(PPV0, SelectedItem_Car)
            CreateMechanicInVehicle(PPV0)
            If PPersVeh.Exist() Then
                PPersVeh.Delete()
                PPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, PPV0)
            Else
                PPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, PPV0)
            End If
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If PPVD >= 30 Then
                    PPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
                    PPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    PPV0.AddBlip()
                    PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    PPV0.CurrentBlip.Color = BlipColor.Yellow
                    PPV0.CurrentBlip.IsShortRange = True
                    PPV0.CurrentBlip.Name = PPV0.FriendlyName
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(PPV0, SelectedItem_Car)
                    CreateMechanicInVehicle(PPV0)
                    If PPersVeh.Exist() Then
                        PPersVeh.Delete()
                        PPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, PPV0)
                    Else
                        PPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, PPV0)
                    End If
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    SoundPlayer(SoundPathDir & "mechanic_cant_get_your_ride.wav")
                End If
            Else
                PPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
                PPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                PPV0.AddBlip()
                PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                PPV0.CurrentBlip.Color = BlipColor.Yellow
                PPV0.CurrentBlip.IsShortRange = True
                PPV0.CurrentBlip.Name = PPV0.FriendlyName
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(PPV0, SelectedItem_Car)
                CreateMechanicInVehicle(PPV0)
                If PPersVeh.Exist() Then
                    PPersVeh.Delete()
                    PPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, PPV0)
                Else
                    PPersVeh = New PersonalVehicle(GetPlayerName(), SelectedItem_Car, PPV0)
                End If
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub ReturnVehicle(PathDir As String)
        Game.FadeScreenOut(500)
        Wait(500)
        If IO.File.Exists(PathDir & "vehicle_0.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_0.cfg")
        If IO.File.Exists(PathDir & "vehicle_1.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_1.cfg")
        If IO.File.Exists(PathDir & "vehicle_2.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_2.cfg")
        If IO.File.Exists(PathDir & "vehicle_3.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_3.cfg")
        If IO.File.Exists(PathDir & "vehicle_4.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_4.cfg")
        If IO.File.Exists(PathDir & "vehicle_5.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_5.cfg")
        If IO.File.Exists(PathDir & "vehicle_6.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_6.cfg")
        If IO.File.Exists(PathDir & "vehicle_7.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_7.cfg")
        If IO.File.Exists(PathDir & "vehicle_8.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_8.cfg")
        If IO.File.Exists(PathDir & "vehicle_9.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_9.cfg")
        If IO.File.Exists(PathDir & "vehicle_10.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_10.cfg")
        If IO.File.Exists(PathDir & "vehicle_11.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_11.cfg")
        If IO.File.Exists(PathDir & "vehicle_12.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_12.cfg")
        If IO.File.Exists(PathDir & "vehicle_13.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_13.cfg")
        If IO.File.Exists(PathDir & "vehicle_14.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_14.cfg")
        If IO.File.Exists(PathDir & "vehicle_15.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_15.cfg")
        If IO.File.Exists(PathDir & "vehicle_16.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_16.cfg")
        If IO.File.Exists(PathDir & "vehicle_17.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_17.cfg")
        If IO.File.Exists(PathDir & "vehicle_18.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_18.cfg")
        If IO.File.Exists(PathDir & "vehicle_19.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_19.cfg")
        Wait(500)
        Game.FadeScreenIn(500)

        If GetPlayerName() = "Michael" Then
            If Not MPV0 = Nothing Then MPV0.Delete()
            MPV0 = Nothing
            MPersVeh.Delete()
        ElseIf GetPlayerName() = "Franklin" Then
            If Not FPV0 = Nothing Then FPV0.Delete()
            FPV0 = Nothing
            FPersVeh.Delete()
        ElseIf GetPlayerName() = "Trevor" Then
            If Not TPV0 = Nothing Then TPV0.Delete()
            TPV0 = Nothing
            TPersVeh.Delete()
        ElseIf GetPlayerName() = "Player3" Then
            If Not PPV0 = Nothing Then PPV0.Delete()
            PPV0 = Nothing
            PPersVeh.Delete()
        End If
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = My.Settings.Mechanic AndAlso Not _menuPool.IsAnyMenuOpen() AndAlso Not Website._menuPool.IsAnyMenuOpen() Then
            PhoneMenu.Visible = Not PhoneMenu.Visible
        End If

        'If e.KeyCode = Keys.Y Then
        '    logger.PinPoint(Game.Player.Character.Position)
        'End If
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        Try
            If Not MPV0 = Nothing Then MPV0.Delete()
            If Not FPV0 = Nothing Then FPV0.Delete()
            If Not TPV0 = Nothing Then TPV0.Delete()
            If Not PPV0 = Nothing Then PPV0.Delete()
            If Not MPV10 = Nothing Then MPV10.Delete()
            If Not FPV10 = Nothing Then FPV10.Delete()
            If Not TPV10 = Nothing Then TPV10.Delete()
            If Not PPV10 = Nothing Then PPV10.Delete()
            If Not MPVVB10 = Nothing Then MPVVB10.Remove()
            If Not FPVVB10 = Nothing Then FPVVB10.Remove()
            If Not TPVVB10 = Nothing Then TPVVB10.Remove()
            If Not PPVVB10 = Nothing Then PPVVB10.Remove()
            If Not MechanicPed = Nothing Then MechanicPed.Delete()
        Catch ex As Exception
        End Try
    End Sub
End Class
