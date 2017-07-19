Imports System.Drawing
Imports GTA
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI
Imports SinglePlayerApartment.Resources
Imports GTA.Math
Imports SinglePlayerApartment.INMNative

Public Class Mechanic
    Inherits Script

    Public Shared MPersVeh As PersonalVehicle = New PersonalVehicle(), FPersVeh As PersonalVehicle = New PersonalVehicle(), TPersVeh As PersonalVehicle = New PersonalVehicle(), PPersVeh As PersonalVehicle = New PersonalVehicle()
    'Public Shared MVDict As New Dictionary(Of String, String)
    'Public Shared FVDict As New Dictionary(Of String, String)
    'Public Shared TVDict As New Dictionary(Of String, String)
    'Public Shared PVDict As New Dictionary(Of String, String)
    Public Shared Path As String
    Public Shared playerHash As String
    Public Shared GarageMenu, GarageMenu2, GrgMoveMenu, GrgTransMenu, MechanicMenu, PhoneMenu, AS3Menu, IW4Menu, IW4HLMenu, DPHMenu, DPHHLMenu, DTMenu, ETMenu, ETHLMenu, RMMenu, RMHLMenu, TTMenu, TTHLMenu, WPMenu, VBMenu As UIMenu
    Public Shared NC2044Menu, HA2862Menu, HA2868Menu, WO3655Menu, NC2045Menu, MR2117Menu, HA2874Menu, WD3677Menu, MW2113Menu, ETP1Menu, ETP2Menu, ETP3Menu As UIMenu
    Public Shared BCAMenu, BDPMenu, CAMenu, HAMenu, LLB0604Menu, LLB2143Menu, MR0184Menu, PowerMenu, PD4401Menu, PD4584Menu, ProsperityMenu, SVSMenu, SMMDMenu, SRD0325Menu, SAMenu, SRMenu, TRMenu As UIMenu
    Public Shared GAMenu, PBMenu, SRD0112Menu, ZAMenu As UIMenu
    Public Shared MichaelPegasusMenu, FranklinPegasusMenu, TrevorPegasusMenu, Player3PegasusMenu, PegasusConfirmMenu As UIMenu
    Public Shared _menuPool As MenuPool
    Public Shared AS3, IW4, IW4HL, DPH, DPHHL, DT, ET, ETHL, RM, RMHL, TT, TTHL, WP, VB As String
    Public Shared NC2044, HA2862, HA2868, WO3655, NC2045, MR2117, HA2874, WD3677, MW2113, ETP1, ETP2, ETP3, BCA, BDP, CA, HA, LLB0604, LLB2143, MR0184, POWER, PD4401, PD4584, PPS, SVS, SMMD, SRD0325, SA, SR, TR, GA, PB, SRD0112, ZA As String
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
    Public Shared GarageMenuItem(10) As UIMenuItem
    Public Shared GrgMoveMenuItem(10) As UIMenuItem
    Public Shared GrgTransMenuItem(10) As UIMenuItem
    Public Shared GarageMenuSelectedItem, GarageMenuSelectedFile, MoveMenuSelectedItem, MoveMenuSelectedFile, MoveMenuSelectedIndex, SelectedGarage, PegasusSelectedVehicleFile As String, MoveIndex As Integer = -1

    Public Shared AltaPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\"
    Public Shared IntegrityPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\"
    Public Shared Integrity2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
    Public Shared PerroPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\"
    Public Shared Perro2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
    Public Shared DreamPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\"
    Public Shared EclipsePathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
    Public Shared Eclipse2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
    Public Shared RichardPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\"
    Public Shared Richard2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\"
    Public Shared TinselPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
    Public Shared Tinsel2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
    Public Shared WeazelPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\"
    Public Shared VespucciPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
    Public Shared NorthConker2044Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\"
    Public Shared HillcrestAve2862Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\"
    Public Shared HillcrestAve2868Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcreast_ave\"
    Public Shared WildOats3655Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\"
    Public Shared NorthConker2045Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\"
    Public Shared MiltonRoad2117Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\"
    Public Shared HillcrestAve2874Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\"
    Public Shared Whispymound3677Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
    Public Shared MadWayne2113Dri As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\"
    Public Shared EclipseP1PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
    Public Shared EclipseP2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
    Public Shared EclipseP3PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"
    Public Shared BayCityAveDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\bay_city_ave\"
    Public Shared BlvdDelPerroDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\blvd_del_perro\"
    Public Shared CougarAveDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\cougar_ave\"
    Public Shared HangmanAveDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\hangman_ave\"
    Public Shared LasLagunas0604Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0604_las_lagunas_blvd\"
    Public Shared LasLagunas2143Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2143_las_lagunas_blvd\"
    Public Shared MiltonRd0184Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0184_milton_road\"
    Public Shared PowerStDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\power_st\"
    Public Shared ProcopioDr4401Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4401_procopio_dr\"
    Public Shared ProcopioDr4584Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4584_procopio_dr\"
    Public Shared ProsperityStDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\prosperity_st\"
    Public Shared SanVitasStDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\san_vitas_st\"
    Public Shared SouthMoMiltonDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\south_mo_milton_dr\"
    Public Shared SouthRockford0325Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0325_south_rockford_dr\"
    Public Shared SpanishAveDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\spanish_ave\"
    Public Shared SustanciaRdDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\sustancia_rd\"
    Public Shared TheRoyaleDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\the_royale\"
    Public Shared GrapeseedAveDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\grapeseed_ave\"
    Public Shared PaletoBlvdDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\paleto_blvd\"
    Public Shared SouthRockford0012Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\"
    Public Shared ZancudoAveDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\zancudo_ave\"

    Public Shared MichaelPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Michael\"
    Public Shared FranklinPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Franklin\"
    Public Shared TrevorPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Trevor\"
    Public Shared Player3PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Pegasus\Player3\"
    Public Shared SoundPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Sounds\"

    Public Sub New()
        Try
            'New Language
            Website.BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
            Website.DockTease = ReadCfgValue("DockTease", langFile)
            Website.LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
            Website.ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
            Website.PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
            Website.SouthernSA = ReadCfgValue("SouthernSA", langFile)
            Website.WarstockCache = ReadCfgValue("WarstockCache", langFile)
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
            ChooseVeh = ReadCfgValue("ChooseVeh", langFile)
            ChooseVehDesc = ReadCfgValue("ChooseVehDesc", langFile)
            ReturnVeh = ReadCfgValue("ReturnVeh", langFile)
            'End Language

            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "Player3" '"None"
            End If

            AS3 = ReadCfgValue("3ASowner", saveFile)
            IW4 = ReadCfgValue("4IWowner", saveFile)
            IW4HL = ReadCfgValue("4IWHLowner", saveFile)
            DPH = ReadCfgValue("DPHwoner", saveFile)
            DPHHL = ReadCfgValue("DPHHLowner", saveFile)
            DT = ReadCfgValue("SSowner", saveFile)
            ET = ReadCfgValue("ETowner", saveFile)
            ETHL = ReadCfgValue("ETHLowner", saveFile)
            RM = ReadCfgValue("RMowner", saveFile)
            RMHL = ReadCfgValue("RMHLowner", saveFile)
            TT = ReadCfgValue("TTowner", saveFile)
            TTHL = ReadCfgValue("TTHLowner", saveFile)
            WP = ReadCfgValue("WPowner", saveFile)
            VB = ReadCfgValue("VPBowner", saveFile)
            NC2044 = ReadCfgValue("2044NCowner", saveFile)
            HA2862 = ReadCfgValue("2862HAowner", saveFile)
            HA2868 = ReadCfgValue("2868HAowner", saveFile)
            WO3655 = ReadCfgValue("3655WODowner", saveFile)
            NC2045 = ReadCfgValue("2045NCowner", saveFile)
            MR2117 = ReadCfgValue("2117MRowner", saveFile)
            HA2874 = ReadCfgValue("2874HAowner", saveFile)
            WD3677 = ReadCfgValue("3677WMDowner", saveFile)
            MW2113 = ReadCfgValue("2113MWowner", saveFile)
            ETP1 = ReadCfgValue("ETP1owner", saveFile)
            ETP2 = ReadCfgValue("ETP2owner", saveFile)
            ETP3 = ReadCfgValue("ETP3owner", saveFile)
            BCA = ReadCfgValue("BCAowner", saveFile)
            BDP = ReadCfgValue("BDPowner", saveFile)
            CA = ReadCfgValue("CAowner", saveFile)
            HA = ReadCfgValue("HAowner", saveFile)
            LLB0604 = ReadCfgValue("0604LLBowner", saveFile)
            LLB2143 = ReadCfgValue("2143LLBowner", saveFile)
            MR0184 = ReadCfgValue("0184MRowner", saveFile)
            POWER = ReadCfgValue("PSowner", saveFile)
            PD4401 = ReadCfgValue("4401PDowner", saveFile)
            PD4584 = ReadCfgValue("4584PDowner", saveFile)
            PPS = ReadCfgValue("PPSowner", saveFile)
            SVS = ReadCfgValue("SVSowner", saveFile)
            SMMD = ReadCfgValue("SMMowner", saveFile)
            SRD0325 = ReadCfgValue("0325SRDowner", saveFile)
            SA = ReadCfgValue("SAonwer", saveFile)
            SR = ReadCfgValue("SRowner", saveFile)
            TR = ReadCfgValue("TRowner", saveFile)
            GA = ReadCfgValue("GAowner", saveFile)
            PB = ReadCfgValue("PBowner", saveFile)
            SRD0112 = ReadCfgValue("0112SRDowner", saveFile)
            ZA = ReadCfgValue("ZAowner", saveFile)

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            My.Settings.Mechanic = [Enum].Parse(GetType(Keys), ReadCfgValue("Mechanic", settingFile), False)
            My.Settings.Save()

            _menuPool = New MenuPool()

            CreatePhoneMenu()
            CreateMechanicMenu()
            CreateVehMenuApartments(AS3Menu, itemAS3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\")
            CreateVehMenuApartments(DTMenu, itemDT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\")
            CreateVehMenuApartments(ETMenu, itemET, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\")
            CreateVehMenuApartments(ETHLMenu, itemETHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\")
            CreateVehMenuApartments(IW4Menu, itemIW4, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\")
            CreateVehMenuApartments(IW4HLMenu, itemIW4HL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\")
            CreateVehMenuApartments(DPHMenu, itemDPH, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\")
            CreateVehMenuApartments(DPHHLMenu, itemDPHHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\")
            CreateVehMenuApartments(RMMenu, itemRM, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\")
            CreateVehMenuApartments(RMHLMenu, itemRMHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\")
            CreateVehMenuApartments(TTMenu, itemTT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\")
            CreateVehMenuApartments(TTHLMenu, itemTTHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\")
            CreateVehMenuApartments(WPMenu, itemWP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\")
            CreateVehMenuApartments(NC2044Menu, itemNC2044, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\")
            CreateVehMenuApartments(HA2862Menu, itemHA2862, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\")
            CreateVehMenuApartments(HA2868Menu, itemHA2868, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcrest_ave\")
            CreateVehMenuApartments(WO3655Menu, itemWO3655, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\")
            CreateVehMenuApartments(NC2045Menu, itemNC2045, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\")
            CreateVehMenuApartments(MR2117Menu, itemMR2117, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\")
            CreateVehMenuApartments(HA2874Menu, itemHA2874, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\")
            CreateVehMenuApartments(WD3677Menu, itemWD3677, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
            CreateVehMenuApartments(MW2113Menu, itemMW2113, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\")
            CreateVehMenuApartments(ETP1Menu, itemETP1, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\")
            CreateVehMenuApartments(ETP2Menu, itemETP2, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\")
            CreateVehMenuApartments(ETP3Menu, itemETP3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\")
            CreateVehMenuApartments(BCAMenu, itemBCA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\bay_city_ave\")
            CreateVehMenuApartments(BDPMenu, itemBDP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\blvd_del_perro\")
            CreateVehMenuApartments(CAMenu, itemCA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\cougar_ave\")
            CreateVehMenuApartments(HAMenu, itemHA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\hangman_ave\")
            CreateVehMenuApartments(LLB0604Menu, itemLLB0604, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0604_las_lagunas_blvd\")
            CreateVehMenuApartments(LLB2143Menu, itemLLB2143, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2143_las_lagunas_blvd\")
            CreateVehMenuApartments(MR0184Menu, itemMR0184, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0184_milton_road\")
            CreateVehMenuApartments(PowerMenu, itemPower, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\power_st\")
            CreateVehMenuApartments(PD4401Menu, itemPD4401, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4401_procopio_dr\")
            CreateVehMenuApartments(PD4584Menu, itemPD4584, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4584_procopio_dr\")
            CreateVehMenuApartments(ProsperityMenu, itemProsperity, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\prosperity_st\")
            CreateVehMenuApartments(SVSMenu, itemSVS, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\san_vitas_st\")
            CreateVehMenuApartments(SMMDMenu, itemSMMD, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\south_mo_milton_dr\")
            CreateVehMenuApartments(SRD0325Menu, itemSRD0325, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0325_south_rockford_dr\")
            CreateVehMenuApartments(SAMenu, itemSA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\spanish_ave\")
            CreateVehMenuApartments(SRMenu, itemSR, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\sustancia_rd\")
            CreateVehMenuApartments(TRMenu, itemTR, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\the_royale\")
            CreateVehMenuApartments6(VBMenu, itemVB, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\")
            CreateVehMenuApartments6(GAMenu, itemGA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\grapeseed_ave\")
            CreateVehMenuApartments6(PBMenu, itemPB, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\paleto_blvd\")
            CreateVehMenuApartments6(SRD0112Menu, itemSRD0112, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\")
            CreateVehMenuApartments6(ZAMenu, itemZA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\zancudo_ave\")
            CreateConfirmPegasusMenu()
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

    Public Shared Sub CreateMPegasusMenu()
        Try
            MichaelPegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MichaelPegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(MichaelPegasusMenu)
            MichaelPegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(MichaelPathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .SubString1 = File
                End With
                MichaelPegasusMenu.AddItem(item)
            Next
            MichaelPegasusMenu.RefreshIndex()
            AddHandler MichaelPegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler MichaelPegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateFPegasusMenu()
        Try
            FranklinPegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            FranklinPegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(FranklinPegasusMenu)
            FranklinPegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(FranklinPathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .SubString1 = File
                End With
                FranklinPegasusMenu.AddItem(item)
            Next
            FranklinPegasusMenu.RefreshIndex()
            AddHandler FranklinPegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler FranklinPegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateTPegasusMenu()
        Try
            TrevorPegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            TrevorPegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(TrevorPegasusMenu)
            TrevorPegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(TrevorPathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .SubString1 = File
                End With
                TrevorPegasusMenu.AddItem(item)
            Next
            TrevorPegasusMenu.RefreshIndex()
            AddHandler TrevorPegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler TrevorPegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreatePPegasusMenu()
        Try
            Player3PegasusMenu = New UIMenu("", _Pegasus.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player3PegasusMenu.SetBannerType(Rectangle)
            _menuPool.Add(Player3PegasusMenu)
            Player3PegasusMenu.MenuItems.Clear()
            For Each File As String In IO.Directory.GetFiles(Player3PathDir, "*.cfg")
                Dim VehicleName As String = ReadCfgValue("VehicleName", File)
                Dim VehicleNick As String = ReadCfgValue("VehicleNick", File)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", File)
                Dim VehDispName As String
                If VehicleNick = "" Then VehDispName = VehicleName Else VehDispName = VehicleNick
                Dim item As New UIMenuItem(VehDispName & " (" & PlateNumber & ")", ChooseVehDesc)
                With item
                    .SubString1 = File
                End With
                Player3PegasusMenu.AddItem(item)
            Next
            Player3PegasusMenu.RefreshIndex()
            AddHandler Player3PegasusMenu.OnItemSelect, AddressOf PegasusItemSelectHandler
            AddHandler Player3PegasusMenu.OnMenuClose, AddressOf PegasusConfirmMenuCloseHandler
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
            Dim Alta As Integer = IO.Directory.GetFiles(AltaPathDir, "*.cfg").Count
            Dim Integrity As Integer = IO.Directory.GetFiles(IntegrityPathDir, "*.cfg").Count
            Dim Integrity2 As Integer = IO.Directory.GetFiles(Integrity2PathDir, "*.cfg").Count
            Dim Perro As Integer = IO.Directory.GetFiles(PerroPathDir, "*.cfg").Count
            Dim Perro2 As Integer = IO.Directory.GetFiles(Perro2PathDir, "*.cfg").Count
            Dim Dream As Integer = IO.Directory.GetFiles(DreamPathDir, "*.cfg").Count
            Dim Eclipse As Integer = IO.Directory.GetFiles(EclipsePathDir, "*.cfg").Count
            Dim Eclipse2 As Integer = IO.Directory.GetFiles(Eclipse2PathDir, "*.cfg").Count
            Dim Richard As Integer = IO.Directory.GetFiles(RichardPathDir, "*.cfg").Count
            Dim Richard2 As Integer = IO.Directory.GetFiles(Richard2PathDir, "*.cfg").Count
            Dim Tinsel As Integer = IO.Directory.GetFiles(TinselPathDir, "*.cfg").Count
            Dim Tinsel2 As Integer = IO.Directory.GetFiles(Tinsel2PathDir, "*.cfg").Count
            Dim Weazel As Integer = IO.Directory.GetFiles(WeazelPathDir, "*.cfg").Count
            Dim Vespucci As Integer = IO.Directory.GetFiles(VespucciPathDir, "*.cfg").Count
            Dim NConker2044 As Integer = IO.Directory.GetFiles(NorthConker2044Dir, "*.cfg").Count
            Dim Hillcrest2862 As Integer = IO.Directory.GetFiles(HillcrestAve2862Dir, "*.cfg").Count
            Dim Hillcrest2868 As Integer = IO.Directory.GetFiles(HillcrestAve2868Dir, "*.cfg").Count
            Dim Wild3655 As Integer = IO.Directory.GetFiles(WildOats3655Dir, "*.cfg").Count
            Dim NConker2045 As Integer = IO.Directory.GetFiles(NorthConker2045Dir, "*.cfg").Count
            Dim MiltonR2117 As Integer = IO.Directory.GetFiles(MiltonRoad2117Dir, "*.cfg").Count
            Dim Hillcrest2874 As Integer = IO.Directory.GetFiles(HillcrestAve2874Dir, "*.cfg").Count
            Dim Whispymound3677 As Integer = IO.Directory.GetFiles(Whispymound3677Dir, "*.cfg").Count
            Dim MadWayne2113 As Integer = IO.Directory.GetFiles(MadWayne2113Dri, "*.cfg").Count
            Dim EclipseP1 As Integer = IO.Directory.GetFiles(EclipseP1PathDir, "*.cfg").Count
            Dim EclipseP2 As Integer = IO.Directory.GetFiles(EclipseP2PathDir, "*.cfg").Count
            Dim EclipseP3 As Integer = IO.Directory.GetFiles(EclipseP3PathDir, "*.cfg").Count
            Dim BayCity As Integer = IO.Directory.GetFiles(BayCityAveDir, "*.cfg").Count
            Dim BlvdDP As Integer = IO.Directory.GetFiles(BlvdDelPerroDir, "*.cfg").Count
            Dim Cougar As Integer = IO.Directory.GetFiles(CougarAveDir, "*.cfg").Count
            Dim Hangman As Integer = IO.Directory.GetFiles(HangmanAveDir, "*.cfg").Count
            Dim Lagunas0604 As Integer = IO.Directory.GetFiles(LasLagunas0604Dir, "*.cfg").Count
            Dim Lagunas2143 As Integer = IO.Directory.GetFiles(LasLagunas2143Dir, "*.cfg").Count
            Dim MiltonR0184 As Integer = IO.Directory.GetFiles(MiltonRd0184Dir, "*.cfg").Count
            Dim PowerSt As Integer = IO.Directory.GetFiles(PowerStDir, "*.cfg").Count
            Dim Procopio4401 As Integer = IO.Directory.GetFiles(ProcopioDr4401Dir, "*.cfg").Count
            Dim Procopio4584 As Integer = IO.Directory.GetFiles(ProcopioDr4584Dir, "*.cfg").Count
            Dim Prosperity As Integer = IO.Directory.GetFiles(ProsperityStDir, "*.cfg").Count
            Dim SanVitas As Integer = IO.Directory.GetFiles(SanVitasStDir, "*.cfg").Count
            Dim SouthMo As Integer = IO.Directory.GetFiles(SouthMoMiltonDir, "*.cfg").Count
            Dim Rockford0325 As Integer = IO.Directory.GetFiles(SouthRockford0325Dir, "*.cfg").Count
            Dim Spanish As Integer = IO.Directory.GetFiles(SpanishAveDir, "*.cfg").Count
            Dim Sustancia As Integer = IO.Directory.GetFiles(SustanciaRdDir, "*.cfg").Count
            Dim Royale As Integer = IO.Directory.GetFiles(TheRoyaleDir, "*.cfg").Count
            Dim Grapeseed As Integer = IO.Directory.GetFiles(GrapeseedAveDir, "*.cfg").Count
            Dim PaletoBlvd As Integer = IO.Directory.GetFiles(PaletoBlvdDir, "*.cfg").Count
            Dim Rockford0112 As Integer = IO.Directory.GetFiles(SouthRockford0012Dir, "*.cfg").Count
            Dim Zancudo As Integer = IO.Directory.GetFiles(ZancudoAveDir, "*.cfg").Count

            MechanicMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MechanicMenu.SetBannerType(Rectangle)
            _menuPool.Add(MechanicMenu)
            MechanicMenu.MenuItems.Clear()
            If AS3 = playerName AndAlso Not Alta = 0 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then MechanicMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 0 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 0 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWP)
            If VB = playerName AndAlso Not Vespucci = 0 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 0 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 0 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 0 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 0 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 0 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 0 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 0 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not Whispymound3677 = 0 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not MadWayne2113 = 0 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP3)
            If BCA = playerName AndAlso Not BayCity = 0 AndAlso ReadCfgValue("BayCityAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemBCA)
            If BDP = playerName AndAlso Not BlvdDP = 0 AndAlso ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then MechanicMenu.AddItem(itemBDP)
            If CA = playerName AndAlso Not Cougar = 0 AndAlso ReadCfgValue("CougarAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemCA)
            If HA = playerName AndAlso Not Hangman = 0 AndAlso ReadCfgValue("HangmanAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA)
            If LLB0604 = playerName AndAlso Not Lagunas0604 = 0 AndAlso ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemLLB0604)
            If LLB2143 = playerName AndAlso Not Lagunas2143 = 0 AndAlso ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemLLB2143)
            If MR0184 = playerName AndAlso Not MiltonR0184 = 0 AndAlso ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMR0184)
            If POWER = playerName AndAlso Not PowerSt = 0 AndAlso ReadCfgValue("PowerSt", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPower)
            If PD4401 = playerName AndAlso Not Procopio4401 = 0 AndAlso ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPD4401)
            If PD4584 = playerName AndAlso Not Procopio4584 = 0 AndAlso ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPD4584)
            If PPS = playerName AndAlso Not Prosperity = 0 AndAlso ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then MechanicMenu.AddItem(itemProsperity)
            If SVS = playerName AndAlso Not SanVitas = 0 AndAlso ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSVS)
            If SMMD = playerName AndAlso Not SouthMo = 0 AndAlso ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSMMD)
            If SRD0325 = playerName AndAlso Not Rockford0325 = 0 AndAlso ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSRD0325)
            If SA = playerName AndAlso Not Spanish = 0 AndAlso ReadCfgValue("SpanishAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSA)
            If SR = playerName AndAlso Not Sustancia = 0 AndAlso ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSR)
            If TR = playerName AndAlso Not Royale = 0 AndAlso ReadCfgValue("TheRoyale", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTR)
            If GA = playerName AndAlso Not Grapeseed = 0 AndAlso ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemGA)
            If PB = playerName AndAlso Not PaletoBlvd = 0 AndAlso ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemPB)
            If SRD0112 = playerName AndAlso Not Rockford0112 = 0 AndAlso ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then MechanicMenu.AddItem(itemSRD0112)
            If ZA = playerName AndAlso Not Zancudo = 0 AndAlso ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then MechanicMenu.AddItem(itemZA)

            MechanicMenu.RefreshIndex()
            AddHandler MechanicMenu.OnMenuClose, AddressOf CategoryMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

#Region "Create Apartment"
    Public Shared Sub CreateVehTransMenuApt()
        Try
            Dim Alta As Integer = IO.Directory.GetFiles(AltaPathDir, "*.cfg").Count
            Dim Integrity As Integer = IO.Directory.GetFiles(IntegrityPathDir, "*.cfg").Count
            Dim Integrity2 As Integer = IO.Directory.GetFiles(Integrity2PathDir, "*.cfg").Count
            Dim Perro As Integer = IO.Directory.GetFiles(PerroPathDir, "*.cfg").Count
            Dim Perro2 As Integer = IO.Directory.GetFiles(Perro2PathDir, "*.cfg").Count
            Dim Dream As Integer = IO.Directory.GetFiles(DreamPathDir, "*.cfg").Count
            Dim Eclipse As Integer = IO.Directory.GetFiles(EclipsePathDir, "*.cfg").Count
            Dim Eclipse2 As Integer = IO.Directory.GetFiles(Eclipse2PathDir, "*.cfg").Count
            Dim Richard As Integer = IO.Directory.GetFiles(RichardPathDir, "*.cfg").Count
            Dim Richard2 As Integer = IO.Directory.GetFiles(Richard2PathDir, "*.cfg").Count
            Dim Tinsel As Integer = IO.Directory.GetFiles(TinselPathDir, "*.cfg").Count
            Dim Tinsel2 As Integer = IO.Directory.GetFiles(Tinsel2PathDir, "*.cfg").Count
            Dim Weazel As Integer = IO.Directory.GetFiles(WeazelPathDir, "*.cfg").Count
            Dim Vespucci As Integer = IO.Directory.GetFiles(VespucciPathDir, "*.cfg").Count
            Dim NConker2044 As Integer = IO.Directory.GetFiles(NorthConker2044Dir, "*.cfg").Count
            Dim Hillcrest2862 As Integer = IO.Directory.GetFiles(HillcrestAve2862Dir, "*.cfg").Count
            Dim Hillcrest2868 As Integer = IO.Directory.GetFiles(HillcrestAve2868Dir, "*.cfg").Count
            Dim Wild3655 As Integer = IO.Directory.GetFiles(WildOats3655Dir, "*.cfg").Count
            Dim NConker2045 As Integer = IO.Directory.GetFiles(NorthConker2045Dir, "*.cfg").Count
            Dim MiltonR2117 As Integer = IO.Directory.GetFiles(MiltonRoad2117Dir, "*.cfg").Count
            Dim Hillcrest2874 As Integer = IO.Directory.GetFiles(HillcrestAve2874Dir, "*.cfg").Count
            Dim _Whispymound3677 As Integer = IO.Directory.GetFiles(Whispymound3677Dir, "*.cfg").Count
            Dim _MadWayne2113 As Integer = IO.Directory.GetFiles(MadWayne2113Dri, "*.cfg").Count
            Dim EclipseP1 As Integer = IO.Directory.GetFiles(EclipseP1PathDir, "*.cfg").Count
            Dim EclipseP2 As Integer = IO.Directory.GetFiles(EclipseP2PathDir, "*.cfg").Count
            Dim EclipseP3 As Integer = IO.Directory.GetFiles(EclipseP3PathDir, "*.cfg").Count
            Dim BayCity As Integer = IO.Directory.GetFiles(BayCityAveDir, "*.cfg").Count
            Dim BlvdDP As Integer = IO.Directory.GetFiles(BlvdDelPerroDir, "*.cfg").Count
            Dim Cougar As Integer = IO.Directory.GetFiles(CougarAveDir, "*.cfg").Count
            Dim Hangman As Integer = IO.Directory.GetFiles(HangmanAveDir, "*.cfg").Count
            Dim Lagunas0604 As Integer = IO.Directory.GetFiles(LasLagunas0604Dir, "*.cfg").Count
            Dim Lagunas2143 As Integer = IO.Directory.GetFiles(LasLagunas2143Dir, "*.cfg").Count
            Dim MiltonR0184 As Integer = IO.Directory.GetFiles(MiltonRd0184Dir, "*.cfg").Count
            Dim _PowerSt As Integer = IO.Directory.GetFiles(PowerStDir, "*.cfg").Count
            Dim Procopio4401 As Integer = IO.Directory.GetFiles(ProcopioDr4401Dir, "*.cfg").Count
            Dim Procopio4584 As Integer = IO.Directory.GetFiles(ProcopioDr4584Dir, "*.cfg").Count
            Dim Prosperity As Integer = IO.Directory.GetFiles(ProsperityStDir, "*.cfg").Count
            Dim SanVitas As Integer = IO.Directory.GetFiles(SanVitasStDir, "*.cfg").Count
            Dim SouthMo As Integer = IO.Directory.GetFiles(SouthMoMiltonDir, "*.cfg").Count
            Dim Rockford0325 As Integer = IO.Directory.GetFiles(SouthRockford0325Dir, "*.cfg").Count
            Dim Spanish As Integer = IO.Directory.GetFiles(SpanishAveDir, "*.cfg").Count
            Dim Sustancia As Integer = IO.Directory.GetFiles(SustanciaRdDir, "*.cfg").Count
            Dim Royale As Integer = IO.Directory.GetFiles(TheRoyaleDir, "*.cfg").Count
            Dim Grapeseed As Integer = IO.Directory.GetFiles(GrapeseedAveDir, "*.cfg").Count
            Dim _PaletoBlvd As Integer = IO.Directory.GetFiles(PaletoBlvdDir, "*.cfg").Count
            Dim Rockford0112 As Integer = IO.Directory.GetFiles(SouthRockford0012Dir, "*.cfg").Count
            Dim Zancudo As Integer = IO.Directory.GetFiles(ZancudoAveDir, "*.cfg").Count

            GrgTransMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgTransMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgTransMenu)
            GrgTransMenu.MenuItems.Clear()

            AS3 = ReadCfgValue("3ASowner", saveFile)
            IW4 = ReadCfgValue("4IWowner", saveFile)
            IW4HL = ReadCfgValue("4IWHLowner", saveFile)
            DPH = ReadCfgValue("DPHwoner", saveFile)
            DPHHL = ReadCfgValue("DPHHLowner", saveFile)
            DT = ReadCfgValue("SSowner", saveFile)
            ET = ReadCfgValue("ETowner", saveFile)
            ETHL = ReadCfgValue("ETHLowner", saveFile)
            RM = ReadCfgValue("RMowner", saveFile)
            RMHL = ReadCfgValue("RMHLowner", saveFile)
            TT = ReadCfgValue("TTowner", saveFile)
            TTHL = ReadCfgValue("TTHLowner", saveFile)
            WP = ReadCfgValue("WPowner", saveFile)
            VB = ReadCfgValue("VPBowner", saveFile)
            NC2044 = ReadCfgValue("2044NCowner", saveFile)
            HA2862 = ReadCfgValue("2862HAowner", saveFile)
            HA2868 = ReadCfgValue("2868HAowner", saveFile)
            WO3655 = ReadCfgValue("3655WODowner", saveFile)
            NC2045 = ReadCfgValue("2045NCowner", saveFile)
            MR2117 = ReadCfgValue("2117MRowner", saveFile)
            HA2874 = ReadCfgValue("2874HAowner", saveFile)
            WD3677 = ReadCfgValue("3677WMDowner", saveFile)
            MW2113 = ReadCfgValue("2113MWTowner", saveFile)
            ETP1 = ReadCfgValue("ETP1owner", saveFile)
            ETP2 = ReadCfgValue("ETP2owner", saveFile)
            ETP3 = ReadCfgValue("ETP3owner", saveFile)
            BCA = ReadCfgValue("BCAowner", saveFile)
            BDP = ReadCfgValue("BDPowner", saveFile)
            CA = ReadCfgValue("CAowner", saveFile)
            HA = ReadCfgValue("HAowner", saveFile)
            LLB0604 = ReadCfgValue("0604LLBowner", saveFile)
            LLB2143 = ReadCfgValue("2143LLBowner", saveFile)
            MR0184 = ReadCfgValue("0184MRowner", saveFile)
            POWER = ReadCfgValue("PSowner", saveFile)
            PD4401 = ReadCfgValue("4401PDowner", saveFile)
            PD4584 = ReadCfgValue("4584PDowner", saveFile)
            PPS = ReadCfgValue("PPSowner", saveFile)
            SVS = ReadCfgValue("SVSowner", saveFile)
            SMMD = ReadCfgValue("SMMowner", saveFile)
            SRD0325 = ReadCfgValue("0325SRDowner", saveFile)
            SA = ReadCfgValue("SAonwer", saveFile)
            SR = ReadCfgValue("SRowner", saveFile)
            TR = ReadCfgValue("TRowner", saveFile)
            GA = ReadCfgValue("GAowner", saveFile)
            PB = ReadCfgValue("PBowner", saveFile)
            SRD0112 = ReadCfgValue("0112SRDowner", saveFile)
            ZA = ReadCfgValue("ZAowner", saveFile)

            ReadMenuItems()

            If AS3 = playerName AndAlso Not Alta = 10 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 10 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 10 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWP)
            If VB = playerName AndAlso Not Vespucci = 6 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 10 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 10 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 10 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 10 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 10 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 10 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 10 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not _Whispymound3677 = 10 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not _MadWayne2113 = 10 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemETP3)
            If BCA = playerName AndAlso Not BayCity = 10 AndAlso ReadCfgValue("BayCityAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemBCA)
            If BDP = playerName AndAlso Not BlvdDP = 10 AndAlso ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemBDP)
            If CA = playerName AndAlso Not Cougar = 10 AndAlso ReadCfgValue("CougarAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemCA)
            If HA = playerName AndAlso Not Hangman = 10 AndAlso ReadCfgValue("HangmanAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemHA)
            If LLB0604 = playerName AndAlso Not Lagunas0604 = 10 AndAlso ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemLLB0604)
            If LLB2143 = playerName AndAlso Not Lagunas2143 = 10 AndAlso ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemLLB2143)
            If MR0184 = playerName AndAlso Not MiltonR0184 = 10 AndAlso ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemMR0184)
            If POWER = playerName AndAlso Not _PowerSt = 10 AndAlso ReadCfgValue("PowerSt", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPower)
            If PD4401 = playerName AndAlso Not Procopio4401 = 10 AndAlso ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPD4401)
            If PD4584 = playerName AndAlso Not Procopio4584 = 10 AndAlso ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPD4584)
            If PPS = playerName AndAlso Not Prosperity = 10 AndAlso ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemProsperity)
            If SVS = playerName AndAlso Not SanVitas = 10 AndAlso ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSVS)
            If SMMD = playerName AndAlso Not SouthMo = 10 AndAlso ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSMMD)
            If SRD0325 = playerName AndAlso Not Rockford0325 = 10 AndAlso ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSRD0325)
            If SA = playerName AndAlso Not Spanish = 10 AndAlso ReadCfgValue("SpanishAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSA)
            If SR = playerName AndAlso Not Sustancia = 10 AndAlso ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSR)
            If TR = playerName AndAlso Not Royale = 10 AndAlso ReadCfgValue("TheRoyale", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemTR)
            If GA = playerName AndAlso Not Grapeseed = 6 AndAlso ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemGA)
            If PB = playerName AndAlso Not _PaletoBlvd = 6 AndAlso ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemPB)
            If SRD0112 = playerName AndAlso Not Rockford0112 = 6 AndAlso ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemSRD0112)
            If ZA = playerName AndAlso Not Zancudo = 6 AndAlso ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then GrgTransMenu.AddItem(itemZA)

            GrgTransMenu.RefreshIndex()
            AddHandler GrgTransMenu.OnItemSelect, AddressOf TransVehItemSelectHandler
            AddHandler GrgTransMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
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
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_0.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(0) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(0))
                With item(0)
                    .SubString1 = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_1.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(1) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(1))
                With item(1)
                    .SubString1 = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_2.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(2) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(2))
                With item(2)
                    .SubString1 = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_3.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(3) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(3))
                With item(3)
                    .SubString1 = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_4.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(4) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(4))
                With item(4)
                    .SubString1 = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_5.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(5) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(5))
                With item(5)
                    .SubString1 = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_6.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(6) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(6))
                With item(6)
                    .SubString1 = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_7.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(7) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(7))
                With item(7)
                    .SubString1 = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_8.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(8) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(8))
                With item(8)
                    .SubString1 = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_9.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(9) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(9))
                With item(9)
                    .SubString1 = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
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
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_0.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(0) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(0))
                With item(0)
                    .SubString1 = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_1.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(1) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(1))
                With item(1)
                    .SubString1 = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_2.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(2) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(2))
                With item(2)
                    .SubString1 = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_3.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(3) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(3))
                With item(3)
                    .SubString1 = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_4.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(4) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(4))
                With item(4)
                    .SubString1 = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                Dim VehName As String = ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg")
                Dim VehNick As String = ReadCfgValue("VehicleNick", PathDir & "vehicle_5.cfg")
                Dim VehDispName As String
                If VehNick = "" Then VehDispName = VehName Else VehDispName = VehNick
                item(5) = New UIMenuItem(VehDispName & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                MenuCategory.AddItem(item(5))
                With item(5)
                    .SubString1 = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            End If
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

    Public Shared Sub CreateMoveMenu(file As String, SixOrTen As String)
        Try
            GrgMoveMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgMoveMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgMoveMenu)
            GrgMoveMenu.MenuItems.Clear()
            If SixOrTen = "Ten" Then
                If IO.File.Exists(file & "vehicle_0.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                    GrgMoveMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .SubString1 = "vehicle_0.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(0) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .SubString1 = "vehicle_0.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_1.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                    GrgMoveMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .SubString1 = "vehicle_1.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(1) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .SubString1 = "vehicle_1.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_2.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                    GrgMoveMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .SubString1 = "vehicle_2.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(2) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .SubString1 = "vehicle_2.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_3.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                    GrgMoveMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .SubString1 = "vehicle_3.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(3) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .SubString1 = "vehicle_3.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_4.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                    GrgMoveMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .SubString1 = "vehicle_4.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(4) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .SubString1 = "vehicle_4.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_5.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                    GrgMoveMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .SubString1 = "vehicle_5.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(5) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .SubString1 = "vehicle_5.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_6.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                    GrgMoveMenuItem(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(6))
                    With GrgMoveMenuItem(6)
                        .SubString1 = "vehicle_6.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(6) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(6))
                    With GrgMoveMenuItem(6)
                        .SubString1 = "vehicle_6.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_7.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                    GrgMoveMenuItem(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(7))
                    With GrgMoveMenuItem(7)
                        .SubString1 = "vehicle_7.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(7) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(7))
                    With GrgMoveMenuItem(7)
                        .SubString1 = "vehicle_7.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_8.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                    GrgMoveMenuItem(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(8))
                    With GrgMoveMenuItem(8)
                        .SubString1 = "vehicle_8.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(8) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(8))
                    With GrgMoveMenuItem(8)
                        .SubString1 = "vehicle_8.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_9.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                    GrgMoveMenuItem(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(9))
                    With GrgMoveMenuItem(9)
                        .SubString1 = "vehicle_9.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(9) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(9))
                    With GrgMoveMenuItem(9)
                        .SubString1 = "vehicle_9.cfg"
                    End With
                End If
            ElseIf SelectedGarage = "Six"
                If IO.File.Exists(file & "vehicle_0.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                    GrgMoveMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .SubString1 = "vehicle_0.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(0) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .SubString1 = "vehicle_0.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_1.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                    GrgMoveMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .SubString1 = "vehicle_1.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(1) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .SubString1 = "vehicle_1.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_2.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                    GrgMoveMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .SubString1 = "vehicle_2.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(2) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .SubString1 = "vehicle_2.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_3.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                    GrgMoveMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .SubString1 = "vehicle_3.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(3) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .SubString1 = "vehicle_3.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_4.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                    GrgMoveMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .SubString1 = "vehicle_4.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(4) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .SubString1 = "vehicle_4.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_5.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                    GrgMoveMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .SubString1 = "vehicle_5.cfg"
                        If Active = "True" Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            .Enabled = False
                        End If
                    End With
                Else
                    GrgMoveMenuItem(5) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .SubString1 = "vehicle_5.cfg"
                    End With
                End If
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

    Public Shared Sub CreateGarageMenu(file As String)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_0.cfg")
                If Nick <> "" Then
                    GarageMenuItem(0) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .SubString1 = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .SubString1 = "vehicle_0.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_1.cfg")
                If Nick <> "" Then
                    GarageMenuItem(1) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .SubString1 = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .SubString1 = "vehicle_1.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_2.cfg")
                If Nick <> "" Then
                    GarageMenuItem(2) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .SubString1 = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .SubString1 = "vehicle_2.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_3.cfg")
                If Nick <> "" Then
                    GarageMenuItem(3) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .SubString1 = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .SubString1 = "vehicle_3.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_4.cfg")
                If Nick <> "" Then
                    GarageMenuItem(4) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .SubString1 = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .SubString1 = "vehicle_4.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_5.cfg")
                If Nick <> "" Then
                    GarageMenuItem(5) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .SubString1 = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .SubString1 = "vehicle_5.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_6.cfg")
                If Nick <> "" Then
                    GarageMenuItem(6) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(6))
                With GarageMenuItem(6)
                    .SubString1 = "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(6) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(6))
                With GarageMenuItem(6)
                    .SubString1 = "vehicle_6.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_7.cfg")
                If Nick <> "" Then
                    GarageMenuItem(7) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(7))
                With GarageMenuItem(7)
                    .SubString1 = "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(7) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(7))
                With GarageMenuItem(7)
                    .SubString1 = "vehicle_7.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_8.cfg")
                If Nick <> "" Then
                    GarageMenuItem(8) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(8))
                With GarageMenuItem(8)
                    .SubString1 = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(8) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(8))
                With GarageMenuItem(8)
                    .SubString1 = "vehicle_8.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_9.cfg")
                If Nick <> "" Then
                    GarageMenuItem(9) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(9))
                With GarageMenuItem(9)
                    .SubString1 = "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(9) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(9))
                With GarageMenuItem(9)
                    .SubString1 = "vehicle_9.cfg"
                    .Enabled = False
                End With
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
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_0.cfg")
                If Nick <> "" Then
                    GarageMenuItem(0) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .SubString1 = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .SubString1 = "vehicle_0.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_1.cfg")
                If Nick <> "" Then
                    GarageMenuItem(1) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .SubString1 = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .SubString1 = "vehicle_1.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_2.cfg")
                If Nick <> "" Then
                    GarageMenuItem(2) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .SubString1 = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .SubString1 = "vehicle_2.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_3.cfg")
                If Nick <> "" Then
                    GarageMenuItem(3) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .SubString1 = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .SubString1 = "vehicle_3.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_4.cfg")
                If Nick <> "" Then
                    GarageMenuItem(4) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .SubString1 = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .SubString1 = "vehicle_4.cfg"
                    .Enabled = False
                End With
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                Dim Nick As String = ReadCfgValue("VehicleNick", file & "vehicle_5.cfg")
                If Nick <> "" Then
                    GarageMenuItem(5) = New UIMenuItem(Nick & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                Else
                    GarageMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                End If
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .SubString1 = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        .Enabled = False
                    End If
                End With
            Else
                GarageMenuItem(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .SubString1 = "vehicle_5.cfg"
                    .Enabled = False
                End With
            End If
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
                Mechanic2.ReturnVeh(selectedItem.SubString1)
            ElseIf Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.Car AndAlso Not selectedItem.Text = ReturnVeh Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", selectedItem.SubString1)
                Dim Active As String = ReadCfgValue("Active", selectedItem.SubString1)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", selectedItem.SubString1)

                If playerName = "Michael" AndAlso Active = "False" Then
                    Mechanic2.Michael_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf playerName = "Franklin" AndAlso Active = "False" Then
                    Mechanic2.Franklin_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf playerName = “Trevor" AndAlso Active = "False" Then
                    Mechanic2.Trevor_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
                ElseIf playerName = "Player3" AndAlso Active = "False" Then
                    Mechanic2.Player3_SendVehicle(selectedItem.SubString1, VehicleModel, VehicleHash, selectedItem, sender)
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
                    TargetPathDir = AltaPathDir
                Case itemIW4.Text
                    TargetPathDir = IntegrityPathDir
                Case itemIW4HL.Text
                    TargetPathDir = Integrity2PathDir
                Case itemDPH.Text
                    TargetPathDir = PerroPathDir
                Case itemDPHHL.Text
                    TargetPathDir = Perro2PathDir
                Case itemDT.Text
                    TargetPathDir = DreamPathDir
                Case itemET.Text
                    TargetPathDir = EclipsePathDir
                Case itemETHL.Text
                    TargetPathDir = Eclipse2PathDir
                Case itemRM.Text
                    TargetPathDir = RichardPathDir
                Case itemRMHL.Text
                    TargetPathDir = Richard2PathDir
                Case itemTT.Text
                    TargetPathDir = TinselPathDir
                Case itemTTHL.Text
                    TargetPathDir = Tinsel2PathDir
                Case itemWP.Text
                    TargetPathDir = WeazelPathDir
                Case itemVB.Text
                    TargetPathDir = VespucciPathDir
                Case itemNC2044.Text
                    TargetPathDir = NorthConker2044Dir
                Case itemHA2862.Text
                    TargetPathDir = HillcrestAve2862Dir
                Case itemHA2868.Text
                    TargetPathDir = HillcrestAve2868Dir
                Case itemWO3655.Text
                    TargetPathDir = WildOats3655Dir
                Case itemNC2045.Text
                    TargetPathDir = NorthConker2045Dir
                Case itemMR2117.Text
                    TargetPathDir = MiltonRoad2117Dir
                Case itemHA2874.Text
                    TargetPathDir = HillcrestAve2874Dir
                Case itemWD3677.Text
                    TargetPathDir = Whispymound3677Dir
                Case itemMW2113.Text
                    TargetPathDir = MadWayne2113Dri
                Case itemETP1.Text
                    TargetPathDir = EclipseP1PathDir
                Case itemETP2.Text
                    TargetPathDir = EclipseP2PathDir
                Case itemETP3.Text
                    TargetPathDir = EclipseP3PathDir
                Case itemBCA.Text
                    TargetPathDir = BayCityAveDir
                Case itemBDP.Text
                    TargetPathDir = BlvdDelPerroDir
                Case itemCA.Text
                    TargetPathDir = CougarAveDir
                Case itemHA.Text
                    TargetPathDir = HangmanAveDir
                Case itemLLB0604.Text
                    TargetPathDir = LasLagunas0604Dir
                Case itemLLB2143.Text
                    TargetPathDir = LasLagunas2143Dir
                Case itemMR0184.Text
                    TargetPathDir = MiltonRd0184Dir
                Case itemPower.Text
                    TargetPathDir = PowerStDir
                Case itemPD4401.Text
                    TargetPathDir = ProcopioDr4401Dir
                Case itemPD4584.Text
                    TargetPathDir = ProcopioDr4584Dir
                Case itemProsperity.Text
                    TargetPathDir = ProsperityStDir
                Case itemSVS.Text
                    TargetPathDir = SanVitasStDir
                Case itemSMMD.Text
                    TargetPathDir = SouthMoMiltonDir
                Case itemSRD0325.Text
                    TargetPathDir = SouthRockford0325Dir
                Case itemSA.Text
                    TargetPathDir = SpanishAveDir
                Case itemSR.Text
                    TargetPathDir = SustanciaRdDir
                Case itemTR.Text
                    TargetPathDir = TheRoyaleDir
                Case itemGA.Text
                    TargetPathDir = GrapeseedAveDir
                Case itemPB.Text
                    TargetPathDir = PaletoBlvdDir
                Case itemSRD0112.Text
                    TargetPathDir = SouthRockford0012Dir
                Case itemZA.Text
                    TargetPathDir = ZancudoAveDir
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
                    sender.Visible = False
                    GarageMenu.Visible = True
                Else
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
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
    End Sub

    Public Shared Sub PegasusConfirmItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If selectedItem.Text = PegasusDeliver Then
            Dim VehicleModel As String = ReadCfgValue("VehicleModel", PegasusSelectedVehicleFile)
            Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", PegasusSelectedVehicleFile)

            If playerName = "Michael" Then
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
                SetBlipName(MPV10.FriendlyName, MPV10.CurrentBlip)
                Mechanic2.SetModKit(MPV10, PegasusSelectedVehicleFile)
                If Not (MPV10.ClassType = VehicleClass.Boats Or MPV10.ClassType = VehicleClass.Helicopters Or MPV10.ClassType = VehicleClass.Planes) Then
                    Mechanic2.CreateMechanicInVehicle(MPV10)
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
            ElseIf playerName = "Franklin" Then
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
                SetBlipName(FPV10.FriendlyName, FPV10.CurrentBlip)
                Mechanic2.SetModKit(FPV10, PegasusSelectedVehicleFile)
                If Not (FPV10.ClassType = VehicleClass.Boats Or FPV10.ClassType = VehicleClass.Helicopters Or FPV10.ClassType = VehicleClass.Planes) Then
                    Mechanic2.CreateMechanicInVehicle(FPV10)
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
            ElseIf playerName = “Trevor" Then
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
                SetBlipName(TPV10.FriendlyName, TPV10.CurrentBlip)
                Mechanic2.SetModKit(TPV10, PegasusSelectedVehicleFile)
                If Not (TPV10.ClassType = VehicleClass.Boats Or TPV10.ClassType = VehicleClass.Helicopters Or TPV10.ClassType = VehicleClass.Planes) Then
                    Mechanic2.CreateMechanicInVehicle(TPV10)
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
            ElseIf playerName = "Player3" Then
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
                SetBlipName(PPV10.FriendlyName, PPV10.CurrentBlip)
                Mechanic2.SetModKit(PPV10, PegasusSelectedVehicleFile)
                If Not (PPV10.ClassType = VehicleClass.Boats Or PPV10.ClassType = VehicleClass.Helicopters Or PPV10.ClassType = VehicleClass.Planes) Then
                    Mechanic2.CreateMechanicInVehicle(PPV10)
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
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRemoveAndDrive Then
                If SelectedGarage = "Ten" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        Dim tempVeh As Vehicle
                        playerPed.Position = TenCarGarage.lastLocationGarageOutVector
                        tempVeh = CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), TenCarGarage.lastLocationGarageOutVector, TenCarGarage.lastLocationGarageOutHeading)
                        Mechanic2.SetModKit(tempVeh, Path & GarageMenuSelectedFile)
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
                        Wait(&H3E8)
                        Dim tempVeh As Vehicle
                        playerPed.Position = SixCarGarage.lastLocationGarageOutVector
                        tempVeh = CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), SixCarGarage.lastLocationGarageOutVector, SixCarGarage.lastLocationGarageOutHeading)
                        Mechanic2.SetModKit(tempVeh, Path & GarageMenuSelectedFile)
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
                End If
            ElseIf selectedItem.Text = GrgSell Then
                Dim VehModel As String = ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile)
                Dim VehPrice As Integer = GetVehiclePrice(Path & GarageMenuSelectedFile)
                If VehPrice = 0 Then
                    UI.ShowSubtitle(GrgTooHot)
                Else
                    Select Case GarageMenuSelectedFile
                        Case "vehicle_0.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh0.Delete() Else SixCarGarage.veh0.Delete()
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh1.Delete() Else SixCarGarage.veh1.Delete()
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh2.Delete() Else SixCarGarage.veh2.Delete()
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh3.Delete() Else SixCarGarage.veh3.Delete()
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh4.Delete() Else SixCarGarage.veh4.Delete()
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh5.Delete() Else SixCarGarage.veh5.Delete()
                        Case "vehicle_6.cfg"
                            TenCarGarage.veh6.Delete()
                        Case "vehicle_7.cfg"
                            TenCarGarage.veh7.Delete()
                        Case "vehicle_8.cfg"
                            TenCarGarage.veh8.Delete()
                        Case "vehicle_9.cfg"
                            TenCarGarage.veh9.Delete()
                    End Select
                    SinglePlayerApartment.player.Money = (playerCash + VehPrice)
                    CreateGarageMenu(Path)
                    IO.File.Delete(Path & GarageMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
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
                            Else
                                SixCarGarage.veh0.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh0.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh1.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh1.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh1.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh2.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh2.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh2.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh3.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh3.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh3.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh4.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh4.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh4.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then
                                TenCarGarage.veh5.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", TenCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                            Else
                                SixCarGarage.veh5.NumberPlate = VehPlate
                                WriteCfgValue("PlateNumber", SixCarGarage.veh5.NumberPlate, Path & GarageMenuSelectedFile)
                            End If
                        Case "vehicle_6.cfg"
                            TenCarGarage.veh6.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh6.NumberPlate, Path & GarageMenuSelectedFile)
                        Case "vehicle_7.cfg"
                            TenCarGarage.veh7.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh7.NumberPlate, Path & GarageMenuSelectedFile)
                        Case "vehicle_8.cfg"
                            TenCarGarage.veh8.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh8.NumberPlate, Path & GarageMenuSelectedFile)
                        Case "vehicle_9.cfg"
                            TenCarGarage.veh9.NumberPlate = VehPlate
                            WriteCfgValue("PlateNumber", TenCarGarage.veh9.NumberPlate, Path & GarageMenuSelectedFile)
                    End Select
                End If
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRename Then
                Dim VehName As String = Game.GetUserInput(ReadCfgValue("VehicleNick", Path & GarageMenuSelectedFile), 29)
                If VehName <> "" Then
                    WriteCfgValue("VehicleNick", VehName, Path & GarageMenuSelectedFile)
                End If
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
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

    Public Shared Sub ItemSelectHandler6CarGarage(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If Not selectedItem.Text = "Empty" Then
                Select Case selectedItem.SubString1
                    Case "vehicle_0.cfg"
                        SixCarGarage.veh0.Delete()
                    Case "vehicle_1.cfg"
                        SixCarGarage.veh1.Delete()
                    Case "vehicle_2.cfg"
                        SixCarGarage.veh2.Delete()
                    Case "vehicle_3.cfg"
                        SixCarGarage.veh3.Delete()
                    Case "vehicle_4.cfg"
                        SixCarGarage.veh4.Delete()
                    Case "vehicle_5.cfg"
                        SixCarGarage.veh5.Delete()
                End Select
                IO.File.Delete(Path & selectedItem.SubString1)
                selectedItem.Text = "Empty"
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

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

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
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
            End If
        Catch ex As Exception
            If Not ex.StackTrace.Contains("MoveNext") Then logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Call_Mechanic()
        AS3 = ReadCfgValue("3ASowner", saveFile)
        IW4 = ReadCfgValue("4IWowner", saveFile)
        IW4HL = ReadCfgValue("4IWHLowner", saveFile)
        DPH = ReadCfgValue("DPHwoner", saveFile)
        DPHHL = ReadCfgValue("DPHHLowner", saveFile)
        DT = ReadCfgValue("SSowner", saveFile)
        ET = ReadCfgValue("ETowner", saveFile)
        ETHL = ReadCfgValue("ETHLowner", saveFile)
        RM = ReadCfgValue("RMowner", saveFile)
        RMHL = ReadCfgValue("RMHLowner", saveFile)
        TT = ReadCfgValue("TTowner", saveFile)
        TTHL = ReadCfgValue("TTHLowner", saveFile)
        WP = ReadCfgValue("WPowner", saveFile)
        VB = ReadCfgValue("VPBowner", saveFile)
        NC2044 = ReadCfgValue("2044NCowner", saveFile)
        HA2862 = ReadCfgValue("2862HAowner", saveFile)
        HA2868 = ReadCfgValue("2868HAowner", saveFile)
        WO3655 = ReadCfgValue("3655WODowner", saveFile)
        NC2045 = ReadCfgValue("2045NCowner", saveFile)
        MR2117 = ReadCfgValue("2117MRowner", saveFile)
        HA2874 = ReadCfgValue("2874HAowner", saveFile)
        WD3677 = ReadCfgValue("3677WMDowner", saveFile)
        MW2113 = ReadCfgValue("2113MWTowner", saveFile)
        ETP1 = ReadCfgValue("ETP1owner", saveFile)
        ETP2 = ReadCfgValue("ETP2owner", saveFile)
        ETP3 = ReadCfgValue("ETP3owner", saveFile)
        BCA = ReadCfgValue("BCAowner", saveFile)
        BDP = ReadCfgValue("BDPowner", saveFile)
        CA = ReadCfgValue("CAowner", saveFile)
        HA = ReadCfgValue("HAowner", saveFile)
        LLB0604 = ReadCfgValue("0604LLBowner", saveFile)
        LLB2143 = ReadCfgValue("2143LLBowner", saveFile)
        MR0184 = ReadCfgValue("0184MRowner", saveFile)
        POWER = ReadCfgValue("PSowner", saveFile)
        PD4401 = ReadCfgValue("4401PDowner", saveFile)
        PD4584 = ReadCfgValue("4584PDowner", saveFile)
        PPS = ReadCfgValue("PPSowner", saveFile)
        SVS = ReadCfgValue("SVSowner", saveFile)
        SMMD = ReadCfgValue("SMMowner", saveFile)
        SRD0325 = ReadCfgValue("0325SRDowner", saveFile)
        SA = ReadCfgValue("SAonwer", saveFile)
        SR = ReadCfgValue("SRowner", saveFile)
        TR = ReadCfgValue("TRowner", saveFile)
        GA = ReadCfgValue("GAowner", saveFile)
        PB = ReadCfgValue("PBowner", saveFile)
        SRD0112 = ReadCfgValue("0112SRDowner", saveFile)
        ZA = ReadCfgValue("ZAowner", saveFile)

        ReadMenuItems()

        CreateMechanicMenu()
        CreateVehMenuApartments(AS3Menu, itemAS3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\")
        CreateVehMenuApartments(DTMenu, itemDT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\")
        CreateVehMenuApartments(ETMenu, itemET, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\")
        CreateVehMenuApartments(ETHLMenu, itemETHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\")
        CreateVehMenuApartments(IW4Menu, itemIW4, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\")
        CreateVehMenuApartments(IW4HLMenu, itemIW4HL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\")
        CreateVehMenuApartments(DPHMenu, itemDPH, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\")
        CreateVehMenuApartments(DPHHLMenu, itemDPHHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\")
        CreateVehMenuApartments(RMMenu, itemRM, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\")
        CreateVehMenuApartments(RMHLMenu, itemRMHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\")
        CreateVehMenuApartments(TTMenu, itemTT, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\")
        CreateVehMenuApartments(TTHLMenu, itemTTHL, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\")
        CreateVehMenuApartments(WPMenu, itemWP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\")
        CreateVehMenuApartments(NC2044Menu, itemNC2044, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\")
        CreateVehMenuApartments(HA2862Menu, itemHA2862, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\")
        CreateVehMenuApartments(HA2868Menu, itemHA2868, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcreast_ave\")
        CreateVehMenuApartments(WO3655Menu, itemWO3655, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\")
        CreateVehMenuApartments(NC2045Menu, itemNC2045, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\")
        CreateVehMenuApartments(MR2117Menu, itemMR2117, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\")
        CreateVehMenuApartments(HA2874Menu, itemHA2874, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\")
        CreateVehMenuApartments(WD3677Menu, itemWD3677, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
        CreateVehMenuApartments(MW2113Menu, itemMW2113, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\")
        CreateVehMenuApartments(ETP1Menu, itemETP1, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\")
        CreateVehMenuApartments(ETP2Menu, itemETP2, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\")
        CreateVehMenuApartments(ETP3Menu, itemETP3, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\")
        CreateVehMenuApartments(BCAMenu, itemBCA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\bay_city_ave\")
        CreateVehMenuApartments(BDPMenu, itemBDP, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\blvd_del_perro\")
        CreateVehMenuApartments(CAMenu, itemCA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\cougar_ave\")
        CreateVehMenuApartments(HAMenu, itemHA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\hangman_ave\")
        CreateVehMenuApartments(LLB0604Menu, itemLLB0604, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0604_las_lagunas_blvd\")
        CreateVehMenuApartments(LLB2143Menu, itemLLB2143, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2143_las_lagunas_blvd\")
        CreateVehMenuApartments(MR0184Menu, itemMR0184, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0184_milton_road\")
        CreateVehMenuApartments(PowerMenu, itemPower, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\power_st\")
        CreateVehMenuApartments(PD4401Menu, itemPD4401, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4401_procopio_dr\")
        CreateVehMenuApartments(PD4584Menu, itemPD4584, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4584_procopio_dr\")
        CreateVehMenuApartments(ProsperityMenu, itemProsperity, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\prosperity_st\")
        CreateVehMenuApartments(SVSMenu, itemSVS, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\san_vitas_st\")
        CreateVehMenuApartments(SMMDMenu, itemSMMD, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\south_mo_milton_dr\")
        CreateVehMenuApartments(SRD0325Menu, itemSRD0325, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0325_south_rockford_dr\")
        CreateVehMenuApartments(SAMenu, itemSA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\spanish_ave\")
        CreateVehMenuApartments(SRMenu, itemSR, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\sustancia_rd\")
        CreateVehMenuApartments(TRMenu, itemTR, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\the_royale\")
        CreateVehMenuApartments6(VBMenu, itemVB, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\")
        CreateVehMenuApartments6(GAMenu, itemGA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\grapeseed_ave\")
        CreateVehMenuApartments6(PBMenu, itemPB, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\paleto_blvd\")
        CreateVehMenuApartments6(SRD0112Menu, itemSRD0112, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\")
        CreateVehMenuApartments6(ZAMenu, itemZA, Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\zancudo_ave\")

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
            Select Case playerName
                Case "Michael"
                    CreateMPegasusMenu()
                    MichaelPegasusMenu.Visible = True
                Case "Franklin"
                    CreateFPegasusMenu()
                    FranklinPegasusMenu.Visible = True
                Case "Trevor"
                    CreateTPegasusMenu()
                    TrevorPegasusMenu.Visible = True
                Case "Player3"
                    CreatePPegasusMenu()
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
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        If e.KeyCode = My.Settings.Mechanic AndAlso Not _menuPool.IsAnyMenuOpen() AndAlso Not Website._menuPool.IsAnyMenuOpen() Then
            PhoneMenu.Visible = Not PhoneMenu.Visible
        End If
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
        Catch ex As Exception
        End Try
    End Sub
End Class
