Imports System.Drawing
Imports System.Windows.Forms
Imports GTA
Imports GTA.Native
Imports INMNativeUI
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.Mechanic
Imports SinglePlayerApartment.INMNative
Imports GTA.Math

Public Class Website
    Inherits Script

    Public Shared PropXmasTree As Prop
    Public Shared VehiclePrice As Integer
    Public Shared SelectedVehicle As String
    Public Shared VehPreview As Vehicle
    Public Shared Price As Decimal = 0
    Public Shared Category As String = Nothing

    Public Shared BennysOriginal, DockTease, ElitasTravel, LegendaryMotorsport, PedalToMetal, SouthernSA, WarstockCache, YourNew, IsConfirm, InsFundVehicle As String
    Public Shared BennyMenu, DockMenu, ElitasMenu, LegendaryMenu, PedalMenu, SouthernMenu, WarstockMenu, DeliveryMenu As UIMenu

    Public Shared BennyFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\bennysoriginalmotorworks.cfg"
    Public Shared DockFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\docktease.cfg"
    Public Shared ElitasFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\elitastravel.cfg"
    Public Shared LegendaryFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\legendarymotorsport.cfg"
    Public Shared PedalFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\padmcycles.cfg"
    Public Shared SouthernFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\southernsanandreassuperautos.cfg"
    Public Shared WarstockFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\warstock-cache-and-carry.cfg"
    Public Shared Parameters As String() = {"[name]", "[price]", "[model]", "[gxt]", "[make]", "[category]", "[desc]"}
    Public Shared ImagePathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Shopping\Images\"
    Public Shared Caller, CallerImg, Subtitle As String
    Public Shared WebsiteCam As Camera
    Public Shared SpinHeading As Single = 314.2483

    Public Shared _menuPool As MenuPool

    Public Shared freeRealEstate As Boolean = False
    Public Shared merryChristmas As Boolean = False
    Public Shared freeWheels As Boolean = False
    Public Shared iWillGetThereAsSoonAsICan As Boolean = False
    Public Shared Rectangle As UIResRectangle = New UIResRectangle()

    Public Sub New()
        Translate()

        _menuPool = New MenuPool()

        Rectangle.Color = Color.FromArgb(0, 0, 0, 0)

        ReadBenny()
        ReadDockTease()
        ReadElitasTravel()
        ReadLegendary()
        ReadPedalToMetal()
        ReadSouthernSA()
        ReadWarstock()
        CreateDeliveryMenu()

        If Now.Month = 12 Then merryChristmas = True
    End Sub

    Public Shared Sub ReadWarstock()
        Try
            Dim Format As New Reader(WarstockFile, Parameters)
            WarstockMenu = New UIMenu("", WarstockCache.ToUpper(), New Point(0, 107))
            WarstockMenu.SetBannerType(Rectangle)
            WarstockMenu.MouseEdgeEnabled = False
            _menuPool.Add(WarstockMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                WarstockMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            SouthernMenu = New UIMenu("", SouthernSA.ToUpper(), New Point(0, 107))
            SouthernMenu.SetBannerType(Rectangle)
            SouthernMenu.MouseEdgeEnabled = False
            _menuPool.Add(SouthernMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                SouthernMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            PedalMenu = New UIMenu("", PedalToMetal.ToUpper(), New Point(0, 107))
            PedalMenu.SetBannerType(Rectangle)
            PedalMenu.MouseEdgeEnabled = False
            _menuPool.Add(PedalMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                PedalMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            LegendaryMenu = New UIMenu("", LegendaryMotorsport.ToUpper(), New Point(0, 107))
            LegendaryMenu.SetBannerType(Rectangle)
            LegendaryMenu.MouseEdgeEnabled = False
            _menuPool.Add(LegendaryMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                LegendaryMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            ElitasMenu = New UIMenu("", ElitasTravel.ToUpper(), New Point(0, 107))
            ElitasMenu.SetBannerType(Rectangle)
            ElitasMenu.MouseEdgeEnabled = False
            _menuPool.Add(ElitasMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                ElitasMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            DockMenu = New UIMenu("", DockTease.ToUpper(), New Point(0, 107))
            DockMenu.SetBannerType(Rectangle)
            DockMenu.MouseEdgeEnabled = False
            _menuPool.Add(DockMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                DockMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            BennyMenu = New UIMenu("", BennysOriginal.ToUpper(), New Point(0, 107))
            BennyMenu.SetBannerType(Rectangle)
            BennyMenu.MouseEdgeEnabled = False
            _menuPool.Add(BennyMenu)
            For i As Integer = 0 To Format.Count - 1
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")), Format(i)("desc"))
                BennyMenu.AddItem(item)
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
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
            DeliveryMenu = New UIMenu("", ChooseApt, New Point(0, 107))
            DeliveryMenu.SetBannerType(Rectangle)
            DeliveryMenu.MouseEdgeEnabled = False
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
            DeliveryMenu.MenuItems.Clear()
            ReadMenuItems()
            If _3AltaStreet.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(_3AltaStreet.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemAS3)
            If _4IntegrityWay.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(_4IntegrityWay.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemIW4)
            If _4IntegrityWay.ApartmentHL.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(_4IntegrityWay.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemIW4HL)
            If DelPerroHeight.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(DelPerroHeight.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemDPH)
            If DelPerroHeight.ApartmentHL.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(DelPerroHeight.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemDPHHL)
            If DreamTower.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(DreamTower.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemDT)
            If EclipseTower.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(EclipseTower.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemET)
            If EclipseTower.ApartmentHL.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(EclipseTower.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETHL)
            If RichardMajestic.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(RichardMajestic.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemRM)
            If RichardMajestic.ApartmentHL.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(RichardMajestic.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemRMHL)
            If TinselTower.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(TinselTower.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemTT)
            If TinselTower.ApartmentHL.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(TinselTower.ApartmentHL.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemTTHL)
            If WeazelPlaza.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(WeazelPlaza.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemWP)
            If VespucciBlvd.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(VespucciBlvd.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemVB)
            If NorthConker2044.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(NorthConker2044.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemNC2044)
            If HillcrestAve2862.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(HillcrestAve2862.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA2862)
            If HillcrestAve2868.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(HillcrestAve2868.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA2868)
            If WildOats3655.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(WildOats3655.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemWO3655)
            If NorthConker2045.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(NorthConker2045.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemNC2045)
            If MiltonRd2117.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(MiltonRd2117.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMR2117)
            If HillcrestAve2874._Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(HillcrestAve2874._Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA2874)
            If Whispymound3677.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(Whispymound3677.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemWD3677)
            If MadWayne2113.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(MadWayne2113.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMW2113)
            If EclipseTower.ApartmentPS1.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(EclipseTower.ApartmentPS1.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETP1)
            If EclipseTower.ApartmentPS2.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(EclipseTower.ApartmentPS2.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETP2)
            If EclipseTower.ApartmentPS3.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(EclipseTower.ApartmentPS3.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemETP3)
            If BayCityAve.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(BayCityAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("BayCityAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemBCA)
            If BlvdDelPerro.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(BlvdDelPerro.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("BlvdDelPerro", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemBDP)
            If CougarAve.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(CougarAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("CougarAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemCA)
            If HangmanAve.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(HangmanAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("HangmanAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemHA)
            If LasLagunasBlvd0604.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(LasLagunasBlvd0604.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("0604LasLagunasBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemLLB0604)
            If LasLagunasBlvd2143.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(LasLagunasBlvd2143.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("2143LasLagunasBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemLLB2143)
            If MiltonRd0184.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(MiltonRd0184.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("0184MiltonRd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMR0184)
            If PowerSt.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(PowerSt.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("PowerSt", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPower)
            If ProcopioDr4401.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(ProcopioDr4401.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4401ProcopioDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPD4401)
            If ProcopioDr4584.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(ProcopioDr4584.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("4584ProcopioDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPD4584)
            If ProsperitySt.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(ProsperitySt.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("ProsperitySt", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemProsperity)
            If SanVitasSt.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(SanVitasSt.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SanVitasSt", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSVS)
            If SouthMoMiltonDr.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(SouthMoMiltonDr.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SouthMoMiltonDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSMMD)
            If SouthRockfordDrive0325.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(SouthRockfordDrive0325.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("0325SouthRockfordDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSRD0325)
            If SpanishAve.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(SpanishAve.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SpanishAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSA)
            If SustanciaRd.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(SustanciaRd.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("SustanciaRd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSR)
            If TheRoyale.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(TheRoyale.Apartment.GaragePath, "*.cfg").Count = 10 AndAlso ReadCfgValue("TheRoyale", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemTR)
            If GrapeseedAve.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(GrapeseedAve.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("GrapeseedAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemGA)
            If PaletoBlvd.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(PaletoBlvd.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("PaletoBlvd", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemPB)
            If SouthRockfordDr0112.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(SouthRockfordDr0112.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemSRD0112)
            If ZancudoAve.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(ZancudoAve.Apartment.GaragePath, "*.cfg").Count = 6 AndAlso ReadCfgValue("ZancudoAve", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemZA)
            '1.10 update
            If MazeBankWest.Apartment.Owner = GetPlayerName() AndAlso Not IO.Directory.GetFiles(MazeBankWest.Apartment.GaragePath, "*.cfg").Count = 20 AndAlso ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then DeliveryMenu.AddItem(itemMBW)

            DeliveryMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub DeliveryMenuCloseHandler(sender As UIMenu)
        Try
            If Not VehPreview = Nothing Then VehPreview.Delete()
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing
            hideHud = False
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub VehicleMenuCloseHandler(sender As UIMenu)
        Try
            If Not DeliveryMenu.Visible = True Then
                If Not VehPreview = Nothing Then VehPreview.Delete()
            End If
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing
            hideHud = False
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub DeliveryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
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
                Case itemMBW.Text '1.10 update
                    TargetPathDir = MazeBankWest.Apartment.GaragePath
            End Select

            If IO.File.Exists(TargetPathDir & "vehicle_0.cfg") = False Then
                If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                CreateFile(TargetPathDir & "vehicle_0.cfg")
                SavePegasusVehicle(TargetPathDir & "vehicle_0.cfg")
                VehPreview.Delete()
                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
            Else
                If IO.File.Exists(TargetPathDir & "vehicle_1.cfg") = False Then
                    If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                    CreateFile(TargetPathDir & "vehicle_1.cfg")
                    SavePegasusVehicle(TargetPathDir & "vehicle_1.cfg")
                    VehPreview.Delete()
                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                Else
                    If IO.File.Exists(TargetPathDir & "vehicle_2.cfg") = False Then
                        If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                        CreateFile(TargetPathDir & "vehicle_2.cfg")
                        SavePegasusVehicle(TargetPathDir & "vehicle_2.cfg")
                        VehPreview.Delete()
                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                    Else
                        If IO.File.Exists(TargetPathDir & "vehicle_3.cfg") = False Then
                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                            CreateFile(TargetPathDir & "vehicle_3.cfg")
                            SavePegasusVehicle(TargetPathDir & "vehicle_3.cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                        Else
                            If IO.File.Exists(TargetPathDir & "vehicle_4.cfg") = False Then
                                If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                CreateFile(TargetPathDir & "vehicle_4.cfg")
                                SavePegasusVehicle(TargetPathDir & "vehicle_4.cfg")
                                VehPreview.Delete()
                                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            Else
                                If IO.File.Exists(TargetPathDir & "vehicle_5.cfg") = False Then
                                    If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                    CreateFile(TargetPathDir & "vehicle_5.cfg")
                                    SavePegasusVehicle(TargetPathDir & "vehicle_5.cfg")
                                    VehPreview.Delete()
                                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                Else
                                    If IO.File.Exists(TargetPathDir & "vehicle_6.cfg") = False Then
                                        If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                        CreateFile(TargetPathDir & "vehicle_6.cfg")
                                        SavePegasusVehicle(TargetPathDir & "vehicle_6.cfg")
                                        VehPreview.Delete()
                                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                    Else
                                        If IO.File.Exists(TargetPathDir & "vehicle_7.cfg") = False Then
                                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                            CreateFile(TargetPathDir & "vehicle_7.cfg")
                                            SavePegasusVehicle(TargetPathDir & "vehicle_7.cfg")
                                            VehPreview.Delete()
                                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                        Else
                                            If IO.File.Exists(TargetPathDir & "vehicle_8.cfg") = False Then
                                                If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                CreateFile(TargetPathDir & "vehicle_8.cfg")
                                                SavePegasusVehicle(TargetPathDir & "vehicle_8.cfg")
                                                VehPreview.Delete()
                                                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                            Else
                                                If IO.File.Exists(TargetPathDir & "vehicle_9.cfg") = False Then
                                                    If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                    CreateFile(TargetPathDir & "vehicle_9.cfg")
                                                    SavePegasusVehicle(TargetPathDir & "vehicle_9.cfg")
                                                    VehPreview.Delete()
                                                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                Else
                                                    If IO.File.Exists(TargetPathDir & "vehicle_10.cfg") = False Then
                                                        If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                        CreateFile(TargetPathDir & "vehicle_10.cfg")
                                                        SavePegasusVehicle(TargetPathDir & "vehicle_10.cfg")
                                                        VehPreview.Delete()
                                                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                    Else
                                                        If IO.File.Exists(TargetPathDir & "vehicle_11.cfg") = False Then
                                                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                            CreateFile(TargetPathDir & "vehicle_11.cfg")
                                                            SavePegasusVehicle(TargetPathDir & "vehicle_11.cfg")
                                                            VehPreview.Delete()
                                                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                        Else
                                                            If IO.File.Exists(TargetPathDir & "vehicle_12.cfg") = False Then
                                                                If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                CreateFile(TargetPathDir & "vehicle_12.cfg")
                                                                SavePegasusVehicle(TargetPathDir & "vehicle_12.cfg")
                                                                VehPreview.Delete()
                                                                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                            Else
                                                                If IO.File.Exists(TargetPathDir & "vehicle_13.cfg") = False Then
                                                                    If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                    CreateFile(TargetPathDir & "vehicle_13.cfg")
                                                                    SavePegasusVehicle(TargetPathDir & "vehicle_13.cfg")
                                                                    VehPreview.Delete()
                                                                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                                Else
                                                                    If IO.File.Exists(TargetPathDir & "vehicle_14.cfg") = False Then
                                                                        If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                        CreateFile(TargetPathDir & "vehicle_14.cfg")
                                                                        SavePegasusVehicle(TargetPathDir & "vehicle_14.cfg")
                                                                        VehPreview.Delete()
                                                                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                                    Else
                                                                        If IO.File.Exists(TargetPathDir & "vehicle_15.cfg") = False Then
                                                                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                            CreateFile(TargetPathDir & "vehicle_15.cfg")
                                                                            SavePegasusVehicle(TargetPathDir & "vehicle_15.cfg")
                                                                            VehPreview.Delete()
                                                                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                                        Else
                                                                            If IO.File.Exists(TargetPathDir & "vehicle_16.cfg") = False Then
                                                                                If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                                CreateFile(TargetPathDir & "vehicle_16.cfg")
                                                                                SavePegasusVehicle(TargetPathDir & "vehicle_16.cfg")
                                                                                VehPreview.Delete()
                                                                                DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                                            Else
                                                                                If IO.File.Exists(TargetPathDir & "vehicle_17.cfg") = False Then
                                                                                    If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                                    CreateFile(TargetPathDir & "vehicle_17.cfg")
                                                                                    SavePegasusVehicle(TargetPathDir & "vehicle_17.cfg")
                                                                                    VehPreview.Delete()
                                                                                    DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                                                Else
                                                                                    If IO.File.Exists(TargetPathDir & "vehicle_18.cfg") = False Then
                                                                                        If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                                        CreateFile(TargetPathDir & "vehicle_18.cfg")
                                                                                        SavePegasusVehicle(TargetPathDir & "vehicle_18.cfg")
                                                                                        VehPreview.Delete()
                                                                                        DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                                                                                    Else
                                                                                        If IO.File.Exists(TargetPathDir & "vehicle_19.cfg") = False Then
                                                                                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                                                                                            CreateFile(TargetPathDir & "vehicle_19.cfg")
                                                                                            SavePegasusVehicle(TargetPathDir & "vehicle_19.cfg")
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
            If SelectedGarage = "Twenty" Then TwentyCarGarage.LoadGarageVechicles(Path)
            sender.Visible = False
            'The Camera would not reset for me and stayed pointing at the Vinewood sign, so I replaced these two lines
            'World.DestroyAllCameras()
            'World.RenderingCamera = Nothing
            GTA.Native.Function.Call(Hash.RENDER_SCRIPT_CAMS, False, False, WebsiteCam.Handle, True, True)
            WebsiteCam.Destroy()
            hideHud = False
            GarageMenu.Visible = True
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub VehicleIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If VehPreview = Nothing Then
                VehPreview = CreateVehicle(sender.MenuItems(index).SubString1, Nothing, New Vector3(457.6332, 1006.618, 327.0871), SpinHeading)
            Else
                VehPreview.Delete()
                VehPreview = CreateVehicle(sender.MenuItems(index).SubString1, Nothing, New Vector3(457.6332, 1006.618, 327.0871), SpinHeading)
            End If
            SelectedVehicle = VehPreview.FriendlyName
            VehPreview.FreezePosition = True
            VehPreview.HasCollision = False
            WebsiteCam.PointAt(VehPreview)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub VehicleSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        'image = ""
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
            VehPreview = CreateVehicle(selectedItem.SubString1, Nothing, New Vector3(457.6332, 1006.618, 327.0871), SpinHeading) ' playerPed.Position, playerPed.Heading)
        End If
        SelectedVehicle = VehPreview.FriendlyName
        'VehPreview.Alpha = 0
        VehPreview.FreezePosition = True
        VehPreview.HasCollision = False
        WebsiteCam.PointAt(VehPreview)
        Category = selectedItem.SubString2
        If Category = "Pegasus" Then
            Select Case GetPlayerName()
                Case "Michael"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(MichaelPathDir & VehPreview.NumberPlate & ".cfg") Then
                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                            CreateFile(MichaelPathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(MichaelPathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                            GTA.Native.Function.Call(Hash.RENDER_SCRIPT_CAMS, False, False, WebsiteCam.Handle, True, True)
                            WebsiteCam.Destroy()
                        End If
                    Else
                        DisplayNotificationThisFrame(Maze, "", InsFundVehicle, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                Case "Franklin"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(FranklinPathDir & VehPreview.NumberPlate & ".cfg") Then
                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                            CreateFile(FranklinPathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(FranklinPathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                            GTA.Native.Function.Call(Hash.RENDER_SCRIPT_CAMS, False, False, WebsiteCam.Handle, True, True)
                            WebsiteCam.Destroy()
                        End If
                    Else
                        DisplayNotificationThisFrame(Fleeca, "", InsFundVehicle, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    End If
                Case "Trevor"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(TrevorPathDir & VehPreview.NumberPlate & ".cfg") Then
                            If freeWheels = False Then Game.Player.Money = (playerCash - VehiclePrice)
                            CreateFile(TrevorPathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(TrevorPathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                            GTA.Native.Function.Call(Hash.RENDER_SCRIPT_CAMS, False, False, WebsiteCam.Handle, True, True)
                            WebsiteCam.Destroy()
                        End If
                    Else
                        DisplayNotificationThisFrame(BOL, "", InsFundVehicle, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    End If
                Case "Player3"
                    If playerCash > VehiclePrice Then
                        If Not IO.File.Exists(Player3PathDir & VehPreview.NumberPlate & ".cfg") Then
                            CreateFile(Player3PathDir & VehPreview.NumberPlate & ".cfg")
                            SavePegasusVehicle(Player3PathDir & VehPreview.NumberPlate & ".cfg")
                            VehPreview.Delete()
                            DisplayNotificationThisFrame(Caller, "", YourNew & SelectedVehicle & IsConfirm, CallerImg, True, IconType.RightJumpingArrow)
                            sender.Visible = False
                            GTA.Native.Function.Call(Hash.RENDER_SCRIPT_CAMS, False, False, WebsiteCam.Handle, True, True)
                            WebsiteCam.Destroy()
                        End If
                    Else
                        DisplayNotificationThisFrame(Maze, "", InsFundVehicle, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
            End Select
        Else
            If playerCash > VehiclePrice Then
                UpdateDeliveryMenu()
                DeliveryMenu.Visible = Not DeliveryMenu.Visible
                sender.Visible = False
            Else
                Select Case GetPlayerName()
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

    Public Shared Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            If Not Game.IsLoading Then
                _menuPool.ProcessMenus()
                If BennyMenu.Visible Or DockMenu.Visible Or ElitasMenu.Visible Or LegendaryMenu.Visible Or PedalMenu.Visible Or SouthernMenu.Visible Or WarstockMenu.Visible Or DeliveryMenu.Visible Then
                    SpinHeading += 0.3
                    VehPreview.Heading = SpinHeading
                End If

                If Cheating("FREEREALESTATE") Then
                    freeRealEstate = Not freeRealEstate
                    If freeRealEstate Then UI.Notify("Cheat activated: ~n~Free Apartment.") Else UI.Notify("Cheat deactivated: ~n~Free Apartment.")
                End If

                If Cheating("FREEWHEELS") Then
                    freeWheels = Not freeWheels
                    If freeWheels Then UI.Notify("Cheat activated: ~n~Free Vehicles.") Else UI.Notify("Cheat deactivated: ~n~Free Vehicles.")
                End If

                If Cheating("MERRYCHRISTMAS") Then
                    merryChristmas = Not merryChristmas
                    If merryChristmas Then
                        UI.Notify("Cheat activated: ~n~Christmas Tree.")
                    Else
                        UI.Notify("Cheat deactivated: ~n~Christmas Tree.")
                        If Not PropXmasTree = Nothing Then PropXmasTree.Delete()
                    End If
                End If

                If Cheating("IWILLGETTHEREASSOONASICAN") Then
                    iWillGetThereAsSoonAsICan = Not iWillGetThereAsSoonAsICan
                    If iWillGetThereAsSoonAsICan Then
                        UI.Notify("Cheat activated: ~n~Disable Restrict to Call Mechanic when you too close to your vehicle.")
                    Else
                        UI.Notify("Cheat deactivated: ~n~Disable Restrict to Call Mechanic when you too close to your vehicle.")
                    End If
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Function Cheating(Cheat As String) As Boolean
        Return Native.Function.Call(Of Boolean)(Hash._0x557E43C447E700A8, Game.GenerateHash(Cheat))
    End Function

    Public Shared Sub Call_Benny()
        BennyMenu.Visible = Not BennyMenu.Visible
        MakeACamera()
    End Sub

    Public Shared Sub Call_DockTease()
        DockMenu.Visible = Not DockMenu.Visible
        MakeACamera()
    End Sub

    Public Shared Sub Call_Legendary()
        LegendaryMenu.Visible = Not LegendaryMenu.Visible
        MakeACamera()
    End Sub

    Public Shared Sub Call_SouthernSA()
        SouthernMenu.Visible = Not SouthernMenu.Visible
        MakeACamera()
    End Sub

    Public Shared Sub Call_PedalToMetal()
        PedalMenu.Visible = Not PedalMenu.Visible
        MakeACamera()
    End Sub

    Public Shared Sub Call_Warstock()
        WarstockMenu.Visible = Not WarstockMenu.Visible
        MakeACamera()
    End Sub

    Public Shared Sub Call_ElitasTravel()
        ElitasMenu.Visible = Not ElitasMenu.Visible
        MakeACamera()
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
            'Updated on v1.9.2
            WriteCfgValue("TrimColor", VehPreview.TrimColor, file)
            WriteCfgValue("DashboardColor", VehPreview.DashboardColor, file)
            'Added on v1.9.2
            WriteCfgValue("ExtraTen", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, VehPreview, 10), file)
            WriteCfgValue("CustomRoof", GetTornadoCustomRoof(VehPreview), file)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub MakeACamera()
        SetInteriorActive2(404.2812, -963.2419, -99.00419) 'Underground Parking
        WebsiteCam = New Camera(1)
        WebsiteCam = World.CreateCamera(New Vector3(450.6018, 1000.792, 329.5135), New Vector3(-7.764421, 0, -50.35685), 50)
        If VehPreview = Nothing Then
            VehPreview = CreateVehicle("adder", Nothing, New Vector3(457.6332, 1006.618, 327.0871), SpinHeading)
        Else
            VehPreview.Delete()
            VehPreview = CreateVehicle("adder", Nothing, New Vector3(457.6332, 1006.618, 327.0871), SpinHeading)
        End If
        SelectedVehicle = VehPreview.FriendlyName
        VehPreview.FreezePosition = True
        VehPreview.HasCollision = False
        WebsiteCam.PointAt(VehPreview)
        World.RenderingCamera = WebsiteCam
        hideHud = True
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        Try
            If Not PropXmasTree = Nothing Then PropXmasTree.Delete()
        Catch ex As Exception
        End Try
    End Sub
End Class
