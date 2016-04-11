Imports System.Drawing
Imports System.Windows.Forms
Imports GTA
Imports GTA.Native
Imports INMNativeUI
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.Mechanic

Public Class Website
    Inherits Script

    'Public Shared Player As Player
    'Public Shared PlayerPed As Ped
    'Public Shared PlayerCash As Integer
    Public Shared VehiclePrice As Integer
    Public Shared SelectedVehicle As String
    Public Shared VehPreview As Vehicle
    Public Shared Price As Decimal = 0
    Public Shared Category As String = Nothing

    Public Shared BennysOriginal, DockTease, ElitasTravel, LegendaryMotorsport, PedalToMetal, SouthernSA, WarstockCache, YourNew, IsConfirm, InsFundVehicle As String
    Public Shared BennyMenu, DockMenu, ElitasMenu, LegendaryMenu, PedalMenu, SouthernMenu, WarstockMenu, DeliveryMenu As UIMenu
    Public Shared GarageMenu As UIMenu

    Public Shared BennyFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\bennysoriginalmotorworks.cfg"
    Public Shared DockFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\docktease.cfg"
    Public Shared ElitasFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\elitastravel.cfg"
    Public Shared LegendaryFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\legendarymotorsport.cfg"
    Public Shared PedalFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\padmcycles.cfg"
    Public Shared SouthernFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\southernsanandreassuperautos.cfg"
    Public Shared WarstockFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\warstock-cache-and-carry.cfg"
    Public Shared Parameters As String() = {"[name]", "[price]", "[model]", "[category]", "[desc]"}
    Public Shared ImagePathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\Images\"
    Public Shared Caller, CallerImg, Subtitle As String
    Public Shared image As String = ""
    Public Shared pointX As Integer
    Public Shared pointY As Integer

    Public Shared _menuPool As MenuPool

    Public Sub New()
        'Player = Game.Player
        'PlayerPed = Game.Player.Character
        'PlayerCash = SinglePlayerApartment.playerCash

        'New Language
        ChooseApt = ReadCfgValue("ChooseApt", langFile)
        BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
        DockTease = ReadCfgValue("DockTease", langFile)
        LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
        ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
        PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
        SouthernSA = ReadCfgValue("SouthernSA", langFile)
        WarstockCache = ReadCfgValue("WarstockCache", langFile)
        YourNew = ReadCfgValue("YourNew", langFile)
        IsConfirm = ReadCfgValue("IsConfirm", langFile)
        Maze = ReadCfgValue("Maze", langFile)
        Fleeca = ReadCfgValue("Fleeca", langFile)
        BOL = ReadCfgValue("BOL", langFile)
        InsFundVehicle = ReadCfgValue("InsFundVehicle", langFile)
        'End Language

        AddHandler Tick, AddressOf OnTick

        _menuPool = New MenuPool()

        ReadBenny()
        ReadDockTease()
        ReadElitasTravel()
        ReadLegendary()
        ReadPedalToMetal()
        ReadSouthernSA()
        ReadWarstock()
        CreateDeliveryMenu()
    End Sub

    Public Shared Sub ReadWarstock()
        Try
            Dim Format As New Reader(WarstockFile, Parameters)
            WarstockMenu = New UIMenu("", WarstockCache.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            WarstockMenu.SetBannerType(Rectangle)
            _menuPool.Add(WarstockMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                WarstockMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            WarstockMenu.RefreshIndex()
            AddHandler WarstockMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler WarstockMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler WarstockMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadSouthernSA()
        Try
            Dim Format As New Reader(SouthernFile, Parameters)
            SouthernMenu = New UIMenu("", SouthernSA.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            SouthernMenu.SetBannerType(Rectangle)
            _menuPool.Add(SouthernMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                SouthernMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            SouthernMenu.RefreshIndex()
            AddHandler SouthernMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler SouthernMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler SouthernMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadPedalToMetal()
        Try
            Dim Format As New Reader(PedalFile, Parameters)
            PedalMenu = New UIMenu("", PedalToMetal.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            PedalMenu.SetBannerType(Rectangle)
            _menuPool.Add(PedalMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                PedalMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            PedalMenu.RefreshIndex()
            AddHandler PedalMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler PedalMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler PedalMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadLegendary()
        Try
            Dim Format As New Reader(LegendaryFile, Parameters)
            LegendaryMenu = New UIMenu("", LegendaryMotorsport.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            LegendaryMenu.SetBannerType(Rectangle)
            _menuPool.Add(LegendaryMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                LegendaryMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            LegendaryMenu.RefreshIndex()
            AddHandler LegendaryMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler LegendaryMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler LegendaryMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadElitasTravel()
        Try
            Dim Format As New Reader(ElitasFile, Parameters)
            ElitasMenu = New UIMenu("", ElitasTravel.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ElitasMenu.SetBannerType(Rectangle)
            _menuPool.Add(ElitasMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                ElitasMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            ElitasMenu.RefreshIndex()
            AddHandler ElitasMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler ElitasMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler ElitasMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadDockTease()
        Try
            Dim Format As New Reader(DockFile, Parameters)
            DockMenu = New UIMenu("", DockTease.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            DockMenu.SetBannerType(Rectangle)
            _menuPool.Add(DockMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                DockMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            DockMenu.RefreshIndex()
            AddHandler DockMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler DockMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler DockMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ReadBenny()
        Try
            Dim Format As New Reader(BennyFile, Parameters)
            BennyMenu = New UIMenu("", BennysOriginal.ToUpper(), New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            BennyMenu.SetBannerType(Rectangle)
            _menuPool.Add(BennyMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Format(i)("name"), Format(i)("desc"))
                BennyMenu.AddItem(item)
                With item
                    .SetRightLabel("$" & Price.ToString("N"))
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Format(i)("category")
                End With
            Next
            BennyMenu.RefreshIndex()
            AddHandler BennyMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler BennyMenu.OnIndexChange, AddressOf VehicleIndexChangeHandler
            AddHandler BennyMenu.OnMenuClose, AddressOf VehicleMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateDeliveryMenu()
        Try
            DeliveryMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            DeliveryMenu.SetBannerType(Rectangle)
            _menuPool.Add(DeliveryMenu)
            DeliveryMenu.RefreshIndex()
            AddHandler DeliveryMenu.OnItemSelect, AddressOf DeliveryItemSelectHandler
            AddHandler DeliveryMenu.OnMenuClose, AddressOf DeliveryMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub UpdateDeliveryMenu()
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

            DeliveryMenu.MenuItems.Clear()

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
            VB = ReadCfgValue("VPBowner", saveFile2)
            NC2044 = ReadCfgValue("2044NCowner", saveFile2)
            HA2862 = ReadCfgValue("2862HAowner", saveFile2)
            HA2868 = ReadCfgValue("2868HAowner", saveFile2)
            WO3655 = ReadCfgValue("3655WODowner", saveFile2)
            NC2045 = ReadCfgValue("2045NCowner", saveFile2)
            MR2117 = ReadCfgValue("2117MRowner", saveFile2)
            HA2874 = ReadCfgValue("2874HAowner", saveFile2)
            WD3677 = ReadCfgValue("3677WMDowner", saveFile2)
            MW2113 = ReadCfgValue("2113MWTowner", saveFile2)
            ETP1 = ReadCfgValue("ETP1owner", saveFile2)
            ETP2 = ReadCfgValue("ETP2owner", saveFile2)
            ETP3 = ReadCfgValue("ETP3owner", saveFile2)
            BCA = ReadCfgValue("BCAowner", saveFile3)
            BDP = ReadCfgValue("BDPowner", saveFile3)
            CA = ReadCfgValue("CAowner", saveFile3)
            HA = ReadCfgValue("HAowner", saveFile3)
            LLB0604 = ReadCfgValue("0604LLBowner", saveFile3)
            LLB2143 = ReadCfgValue("2143LLBowner", saveFile3)
            MR0184 = ReadCfgValue("0184MRowner", saveFile3)
            POWER = ReadCfgValue("PSowner", saveFile3)
            PD4401 = ReadCfgValue("4401PDowner", saveFile3)
            PD4584 = ReadCfgValue("4584PDowner", saveFile3)
            PPS = ReadCfgValue("PPSowner", saveFile3)
            SVS = ReadCfgValue("SVSowner", saveFile3)
            SMMD = ReadCfgValue("SMMowner", saveFile3)
            SRD0325 = ReadCfgValue("0325SRDowner", saveFile3)
            SA = ReadCfgValue("SAonwer", saveFile3)
            SR = ReadCfgValue("SRowner", saveFile3)
            TR = ReadCfgValue("TRowner", saveFile3)
            GA = ReadCfgValue("GAowner", saveFile3)
            PB = ReadCfgValue("PBowner", saveFile3)
            SRD0112 = ReadCfgValue("0112SRDowner", saveFile3)
            ZA = ReadCfgValue("ZAowner", saveFile3)

            If AS3 = playerName AndAlso Not Alta = 10 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 10 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 10 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemWP)
            If VB = playerName AndAlso Not Vespucci = 6 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 10 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 10 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 10 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 10 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 10 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 10 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 10 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not Whispymound3677 = 10 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not MadWayne2113 = 10 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETP3)
            If BCA = playerName AndAlso Not BayCity = 10 AndAlso ReadCfgValue("BayCityAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemBCA)
            If BDP = playerName AndAlso Not BlvdDP = 10 AndAlso ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemBDP)
            If CA = playerName AndAlso Not Cougar = 10 AndAlso ReadCfgValue("CougarAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemCA)
            If HA = playerName AndAlso Not Hangman = 10 AndAlso ReadCfgValue("HangmanAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA)
            If LLB0604 = playerName AndAlso Not Lagunas0604 = 10 AndAlso ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemLLB0604)
            If LLB2143 = playerName AndAlso Not Lagunas2143 = 10 AndAlso ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemLLB2143)
            If MR0184 = playerName AndAlso Not MiltonR0184 = 10 AndAlso ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMR0184)
            If POWER = playerName AndAlso Not PowerSt = 10 AndAlso ReadCfgValue("PowerSt", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPower)
            If PD4401 = playerName AndAlso Not Procopio4401 = 10 AndAlso ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPD4401)
            If PD4584 = playerName AndAlso Not Procopio4584 = 10 AndAlso ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPD4584)
            If PPS = playerName AndAlso Not Prosperity = 10 AndAlso ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemProsperity)
            If SVS = playerName AndAlso Not SanVitas = 10 AndAlso ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSVS)
            If SMMD = playerName AndAlso Not SouthMo = 10 AndAlso ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSMMD)
            If SRD0325 = playerName AndAlso Not Rockford0325 = 10 AndAlso ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSRD0325)
            If SA = playerName AndAlso Not Spanish = 10 AndAlso ReadCfgValue("SpanishAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSA)
            If SR = playerName AndAlso Not Sustancia = 10 AndAlso ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSR)
            If TR = playerName AndAlso Not Royale = 10 AndAlso ReadCfgValue("TheRoyale", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemTR)
            If GA = playerName AndAlso Not Grapeseed = 6 AndAlso ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemGA)
            If PB = playerName AndAlso Not PaletoBlvd = 6 AndAlso ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPB)
            If SRD0112 = playerName AndAlso Not Rockford0112 = 6 AndAlso ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSRD0112)
            If ZA = playerName AndAlso Not Zancudo = 6 AndAlso ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemZA)

            DeliveryMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub DeliveryMenuCloseHandler(sender As UIMenu)
        Try
            If Not VehPreview = Nothing Then VehPreview.Delete()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub VehicleMenuCloseHandler(sender As UIMenu)
        Try
            image = ""
            If Not DeliveryMenu.Visible = True Then
                If Not VehPreview = Nothing Then VehPreview.Delete()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub DeliveryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
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
                Game.Player.Money = (playerCash - VehiclePrice)
                Resources.CreateFile(TargetPathDir & "vehicle_0.cfg")
                SavePegasusVehicle(TargetPathDir & "vehicle_0.cfg")
                VehPreview.Delete()
                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
            Else
                If IO.File.Exists(TargetPathDir & "vehicle_1.cfg") = False Then
                    Game.Player.Money = (playerCash - VehiclePrice)
                    Resources.CreateFile(TargetPathDir & "vehicle_1.cfg")
                    SavePegasusVehicle(TargetPathDir & "vehicle_1.cfg")
                    VehPreview.Delete()
                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                Else
                    If IO.File.Exists(TargetPathDir & "vehicle_2.cfg") = False Then
                        Game.Player.Money = (playerCash - VehiclePrice)
                        Resources.CreateFile(TargetPathDir & "vehicle_2.cfg")
                        SavePegasusVehicle(TargetPathDir & "vehicle_2.cfg")
                        VehPreview.Delete()
                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                    Else
                        If IO.File.Exists(TargetPathDir & "vehicle_3.cfg") = False Then
                            Game.Player.Money = (playerCash - VehiclePrice)
                            Resources.CreateFile(TargetPathDir & "vehicle_3.cfg")
                            SavePegasusVehicle(TargetPathDir & "vehicle_3.cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                        Else
                            If IO.File.Exists(TargetPathDir & "vehicle_4.cfg") = False Then
                                Game.Player.Money = (playerCash - VehiclePrice)
                                Resources.CreateFile(TargetPathDir & "vehicle_4.cfg")
                                SavePegasusVehicle(TargetPathDir & "vehicle_4.cfg")
                                VehPreview.Delete()
                                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            Else
                                If IO.File.Exists(TargetPathDir & "vehicle_5.cfg") = False Then
                                    Game.Player.Money = (playerCash - VehiclePrice)
                                    Resources.CreateFile(TargetPathDir & "vehicle_5.cfg")
                                    SavePegasusVehicle(TargetPathDir & "vehicle_5.cfg")
                                    VehPreview.Delete()
                                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                Else
                                    If IO.File.Exists(TargetPathDir & "vehicle_6.cfg") = False Then
                                        Game.Player.Money = (playerCash - VehiclePrice)
                                        Resources.CreateFile(TargetPathDir & "vehicle_6.cfg")
                                        SavePegasusVehicle(TargetPathDir & "vehicle_6.cfg")
                                        VehPreview.Delete()
                                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                    Else
                                        If IO.File.Exists(TargetPathDir & "vehicle_7.cfg") = False Then
                                            Game.Player.Money = (playerCash - VehiclePrice)
                                            Resources.CreateFile(TargetPathDir & "vehicle_7.cfg")
                                            SavePegasusVehicle(TargetPathDir & "vehicle_7.cfg")
                                            VehPreview.Delete()
                                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                        Else
                                            If IO.File.Exists(TargetPathDir & "vehicle_8.cfg") = False Then
                                                Game.Player.Money = (playerCash - VehiclePrice)
                                                Resources.CreateFile(TargetPathDir & "vehicle_8.cfg")
                                                SavePegasusVehicle(TargetPathDir & "vehicle_8.cfg")
                                                VehPreview.Delete()
                                                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                            Else
                                                If IO.File.Exists(TargetPathDir & "vehicle_9.cfg") = False Then
                                                    Game.Player.Money = (playerCash - VehiclePrice)
                                                    Resources.CreateFile(TargetPathDir & "vehicle_9.cfg")
                                                    SavePegasusVehicle(TargetPathDir & "vehicle_9.cfg")
                                                    VehPreview.Delete()
                                                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
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

    Public Shared Sub VehicleIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            image = sender.MenuItems(index).SubString1 & ".jpg"
            pointX = sender.MenuItems(index).Offset.X + My.Settings.PreviewPointX
            pointY = sender.MenuItems(index).Offset.Y + My.Settings.PreviewPointY
            'UI.DrawTexture(ImagePathDir & image, 0, 0, 2000, New Point(290, 0), New Size(600, 333), 0.0, Color.White)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub DrawTexture()
        If Not image = "" Then
            UI.DrawTexture(ImagePathDir & image, 0, 0, 60, New Point(pointX, pointY), New Size(300, 166), 0.0, Color.White)
        End If
    End Sub

    Public Shared Sub VehicleSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        image = ""
        Subtitle = sender.Subtitle.Caption
        Select Case Subtitle
            Case BennysOriginal.ToUpper()
                Caller = BennysOriginal
                CallerImg = "char_carsite3"
            Case DockTease.ToUpper()
                Caller = DockTease
                CallerImg = "char_boatsite"
            Case ElitasTravel.ToUpper()
                Caller = ElitasTravel
                CallerImg = "char_planesite"
            Case LegendaryMotorsport.ToUpper()
                Caller = LegendaryMotorsport
                CallerImg = "char_carsite"
            Case PedalToMetal.ToUpper()
                Caller = PedalToMetal
                CallerImg = "char_bikesite"
            Case SouthernSA.ToUpper()
                Caller = SouthernSA
                CallerImg = "char_carsite2"
            Case WarstockCache.ToUpper()
                Caller = WarstockCache
                CallerImg = "char_milsite"
        End Select

        VehiclePrice = selectedItem.SubInteger1
        If VehPreview = Nothing Then
            VehPreview = Resources.CreateVehicle(selectedItem.SubString1, Nothing, playerPed.Position, playerPed.Heading)
        Else
            VehPreview.Delete()
            VehPreview = Resources.CreateVehicle(selectedItem.SubString1, Nothing, playerPed.Position, playerPed.Heading)
        End If
        SelectedVehicle = VehPreview.FriendlyName
        VehPreview.Alpha = 0
        VehPreview.HasCollision = False
        Category = selectedItem.SubString2
        If Category = "Pegasus" Then
            Select Case playerName
                Case "Michael"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(MichaelPathDir & VehPreview.NumberPlate & ".cfg") Then
                            Game.Player.Money = (playerCash - VehiclePrice)
                            Resources.CreateFile(MichaelPathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(MichaelPathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                        End If
                    Else
                        DisplayNotificationThisFrame(Maze, "", InsFundVehicle, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                Case "Franklin"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(FranklinPathDir & VehPreview.NumberPlate & ".cfg") Then
                            Game.Player.Money = (playerCash - VehiclePrice)
                            Resources.CreateFile(FranklinPathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(FranklinPathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                        End If
                    Else
                        DisplayNotificationThisFrame(Fleeca, "", InsFundVehicle, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    End If
                Case "Trevor"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(TrevorPathDir & VehPreview.NumberPlate & ".cfg") Then
                            Game.Player.Money = (playerCash - VehiclePrice)
                            Resources.CreateFile(TrevorPathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(TrevorPathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                        End If
                    Else
                        DisplayNotificationThisFrame(BOL, "", InsFundVehicle, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    End If
                Case "Player3"
                    If PlayerCash > VehiclePrice Then
                        If Not IO.File.Exists(Player3PathDir & VehPreview.NumberPlate & ".cfg") Then
                            Resources.CreateFile(Player3PathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(Player3PathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                        End If
                    Else
                        DisplayNotificationThisFrame(Maze, "", InsFundVehicle, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
            End Select
        Else
            If PlayerCash > VehiclePrice Then
                UpdateDeliveryMenu()
                DeliveryMenu.Visible = Not DeliveryMenu.Visible
                sender.Visible = False
            Else
                Select Case playerName
                    Case "Michael"
                        DisplayNotificationThisFrame(Maze, "", InsFundVehicle, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    Case "Franklin"
                        DisplayNotificationThisFrame(Fleeca, "", InsFundVehicle, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    Case "Trevor"
                        DisplayNotificationThisFrame(BOL, "", InsFundVehicle, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    Case "Player3"
                        DisplayNotificationThisFrame(Maze, "", InsFundVehicle, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                End Select
            End If
        End If
    End Sub

    Public Shared Sub OnTick(o As Object, e As EventArgs)
        Try
            _menuPool.ProcessMenus()
            DrawTexture()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Call_Benny()
        BennyMenu.Visible = Not BennyMenu.Visible
    End Sub

    Public Shared Sub Call_DockTease()
        DockMenu.Visible = Not DockMenu.Visible
    End Sub

    Public Shared Sub Call_Legendary()
        LegendaryMenu.Visible = Not LegendaryMenu.Visible
    End Sub

    Public Shared Sub Call_SouthernSA()
        SouthernMenu.Visible = Not SouthernMenu.Visible
    End Sub

    Public Shared Sub Call_PedalToMetal()
        PedalMenu.Visible = Not PedalMenu.Visible
    End Sub

    Public Shared Sub Call_Warstock()
        WarstockMenu.Visible = Not WarstockMenu.Visible
    End Sub

    Public Shared Sub Call_ElitasTravel()
        ElitasMenu.Visible = Not ElitasMenu.Visible
    End Sub

    Public Shared Sub SavePegasusVehicle(file As String)
        Try
            WriteCfgValue("VehicleName", VehPreview.FriendlyName, file)
            'WriteCfgValue("VehicleModel", Resources.GetModelFromHash(VehPreview), file)
            WriteCfgValue("PrimaryColor", VehPreview.PrimaryColor, file)
            WriteCfgValue("SecondaryColor", VehPreview.SecondaryColor, file)
            WriteCfgValue("PearlescentColor", VehPreview.PearlescentColor, file)
            WriteCfgValue("HasCustomPrimaryColor", VehPreview.IsPrimaryColorCustom, file)
            WriteCfgValue("HasCustomSecondaryColor", VehPreview.IsSecondaryColorCustom, file)
            WriteCfgValue("CustomPrimaryColorRed", VehPreview.CustomPrimaryColor.R, file)
            WriteCfgValue("CustomPrimaryColorGreen", VehPreview.CustomPrimaryColor.G, file)
            WriteCfgValue("CustomPrimaryColorBlue", VehPreview.CustomPrimaryColor.B, file)
            WriteCfgValue("CustomSecondaryColorRed", VehPreview.CustomSecondaryColor.R, file)
            WriteCfgValue("CustomSecondaryColorGreen", VehPreview.CustomSecondaryColor.G, file)
            WriteCfgValue("CustomSecondaryColorBlue", VehPreview.CustomSecondaryColor.B, file)
            WriteCfgValue("RimColor", VehPreview.RimColor, file)
            WriteCfgValue("HasNeonLightBack", VehPreview.IsNeonLightsOn(VehicleNeonLight.Back), file)
            WriteCfgValue("HasNeonLightFront", VehPreview.IsNeonLightsOn(VehicleNeonLight.Front), file)
            WriteCfgValue("HasNeonLightLeft", VehPreview.IsNeonLightsOn(VehicleNeonLight.Left), file)
            WriteCfgValue("HasNeonLightRight", VehPreview.IsNeonLightsOn(VehicleNeonLight.Right), file)
            WriteCfgValue("NeonColorRed", VehPreview.NeonLightsColor.R, file)
            WriteCfgValue("NeonColorGreen", VehPreview.NeonLightsColor.G, file)
            WriteCfgValue("NeonColorBlue", VehPreview.NeonLightsColor.B, file)
            WriteCfgValue("TyreSmokeColorRed", VehPreview.TireSmokeColor.R, file)
            WriteCfgValue("TyreSmokeColorGreen", VehPreview.TireSmokeColor.G, file)
            WriteCfgValue("TyreSmokeColorBlue", VehPreview.TireSmokeColor.B, file)
            WriteCfgValue("WheelType", VehPreview.WheelType, file)
            WriteCfgValue("Livery", VehPreview.Livery, file)
            WriteCfgValue("PlateType", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, VehPreview), file)
            WriteCfgValue("PlateNumber", VehPreview.NumberPlate, file)
            WriteCfgValue("WindowTint", VehPreview.WindowTint, file)
            WriteCfgValue("Spoiler", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 0), file)
            WriteCfgValue("FrontBumper", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 1), file)
            WriteCfgValue("RearBumper", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 2), file)
            WriteCfgValue("SideSkirt", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 3), file)
            WriteCfgValue("Frame", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 5), file)
            WriteCfgValue("Grille", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 6), file)
            WriteCfgValue("Hood", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 7), file)
            WriteCfgValue("Fender", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 8), file)
            WriteCfgValue("RightFender", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 9), file)
            WriteCfgValue("Roof", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 10), file)
            WriteCfgValue("Exhaust", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 4), file)
            WriteCfgValue("FrontWheels", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 23), file)
            WriteCfgValue("BackWheels", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 24), file)
            WriteCfgValue("Suspension", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 15), file)
            WriteCfgValue("Engine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 11), file)
            WriteCfgValue("Brakes", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 12), file)
            WriteCfgValue("Transmission", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 13), file)
            WriteCfgValue("Armor", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 16), file)
            WriteCfgValue("XenonHeadlights", Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, VehPreview, 22), file)
            WriteCfgValue("Turbo", Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, VehPreview, 18), file)
            'Added on v1.1.3
            WriteCfgValue("Horn", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 14), file)
            WriteCfgValue("BulletproofTyres", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_TYRES_CAN_BURST, VehPreview), file)
            WriteCfgValue("Active", "False", file)
            'Added on v1.2.1
            WriteCfgValue("FrontTireVariation", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, VehPreview, 23), file)
            WriteCfgValue("BackTireVariation", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, VehPreview, 24), file)
            WriteCfgValue("TwentyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 25), file)
            WriteCfgValue("TwentySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 26), file)
            WriteCfgValue("TwentySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 27), file)
            WriteCfgValue("TwentyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 28), file)
            WriteCfgValue("TwentyNine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 29), file)
            WriteCfgValue("ThirtyZero", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 30), file)
            WriteCfgValue("ThirtyOne", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 31), file)
            WriteCfgValue("ThirtyTwo", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 32), file)
            WriteCfgValue("ThirtyThree", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 33), file)
            WriteCfgValue("ThirtyFour", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 34), file)
            WriteCfgValue("ThirtyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 35), file)
            WriteCfgValue("ThirtySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 36), file)
            WriteCfgValue("ThirtySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 37), file)
            WriteCfgValue("ThirtyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 38), file)
            WriteCfgValue("ThirtyNine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 39), file)
            WriteCfgValue("ForthyZero", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 40), file)
            WriteCfgValue("ForthyOne", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 41), file)
            WriteCfgValue("ForthyTwo", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 42), file)
            WriteCfgValue("ForthyThree", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 43), file)
            WriteCfgValue("ForthyFour", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 44), file)
            WriteCfgValue("ForthyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 45), file)
            WriteCfgValue("ForthySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 46), file)
            WriteCfgValue("ForthySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 47), file)
            WriteCfgValue("ForthyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, VehPreview, 48), file)
            'Added on v1.3.1
            WriteCfgValue("VehicleHash", VehPreview.Model.GetHashCode().ToString, file)
            WriteCfgValue("VehicleRoof", Native.Function.Call(Of Integer)(Hash.GET_CONVERTIBLE_ROOF_STATE, VehPreview), file)
            'Added on v1.3.3
            WriteCfgValue("ExtraOne", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 1), file)
            WriteCfgValue("ExtraTwo", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 2), file)
            WriteCfgValue("ExtraThree", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 3), file)
            WriteCfgValue("ExtraFour", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 4), file)
            WriteCfgValue("ExtraFive", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 5), file)
            WriteCfgValue("ExtraSix", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 6), file)
            WriteCfgValue("ExtraSeven", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 7), file)
            WriteCfgValue("ExtraEight", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 8), file)
            WriteCfgValue("ExtraNine", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 9), file)
            'Added on v1.3.4
            WriteCfgValue("TrimColor", Resources.GetVehicleInteriorTrimColor(VehPreview), file)
            WriteCfgValue("DashboardColor", Resources.GetVehicleInteriorDashboardColor(VehPreview), file)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
End Class
