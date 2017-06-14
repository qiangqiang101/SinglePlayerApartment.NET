Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI
Imports SinglePlayerApartment.Wardrobe
Imports SinglePlayerApartment.INMNative
Imports SinglePlayerApartment.Resources

Public Class EclipseTower

    Public Shared Apartment, ApartmentHL, ApartmentPS1, ApartmentPS2, ApartmentPS3 As Apartment
    Public Shared BuyMenu, ExitMenu, ExitMenuHL, ExitMenuPS1, ExitMenuPS2, ExitMenuPS3, StyleMenuPS1, StyleMenuPS2, StyleMenuPS3, GarageMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            Apartment = New Apartment("Eclipse Tower Apt. ", "8", 400000)
            Apartment.Name = ReadCfgValue("EclipseName", langFile)
            Apartment.Description = ReadCfgValue("EclipseDesc", langFile)
            Apartment.Owner = ReadCfgValue("ETowner", saveFile)
            Apartment.Entrance = New Vector3(-770.258, 313.033, 85.6981)
            Apartment.Save = New Vector3(-795.527, 337.415, 201.413)
            Apartment.TeleportInside = New Vector3(-780.152, 340.443, 207.621)
            Apartment.TeleportOutside = New Vector3(-773.282, 312.275, 84.698)
            Apartment.ApartmentExit = New Vector3(-777.584, 340.172, 207.621)
            Apartment.Wardrobe = New Vector3(-795.0659, 331.7157, 201.4243)
            Apartment.GarageEntrance = New Vector3(-796.1685, 311.4121, 85.7088)
            Apartment.GarageOutside = New Vector3(-796.2648, 302.5102, 85.1543)
            Apartment.GarageOutHeading = 179.532
            Apartment.CameraPosition = New Vector3(-881.4312, 214.6852, 91.3971)
            Apartment.CameraRotation = New Vector3(25.6109, 0, -39.32376)
            Apartment.CameraFOV = 50.0
            Apartment.Interior = New Vector3(-795.04, 342.37, 206.22)
            Apartment.WardrobeHeading = 268.5623
            Apartment.IsAtHome = False
            Apartment.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
            Apartment.SaveFile = "ETowner"
            Apartment.PlayerMap = "Eclipse"
            Apartment.Enabled = True
            Apartment.InteriorID = Apartment.GetInteriorID(Apartment.Interior)
            If Not Apartment.InteriorID = 0 Then InteriorIDList.Add(Apartment.InteriorID)

            ApartmentHL = New Apartment("Eclipse Tower Apt. ", "3", 800000)
            ApartmentHL.Name = ReadCfgValue("EclipseHLName", langFile)
            ApartmentHL.Description = ReadCfgValue("EclipseHLDesc", langFile)
            ApartmentHL.Owner = ReadCfgValue("ETHLowner", saveFile)
            ApartmentHL.Save = New Vector3(-793.2186, 332.4132, 210.7966)
            ApartmentHL.TeleportInside = New Vector3(-774.3142, 323.8076, 212.0325)
            ApartmentHL.TeleportOutside = New Vector3(-773.282, 312.275, 84.698)
            ApartmentHL.ApartmentExit = New Vector3(-777.6211, 323.5111, 211.9974)
            ApartmentHL.Wardrobe = New Vector3(-793.4239, 326.7805, 210.7966)
            ApartmentHL.Interior = New Vector3(-773.8549, 331.5905, 211.4325)
            ApartmentHL.WardrobeHeading = 356.4841
            ApartmentHL.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
            ApartmentHL.SaveFile = "ETHLowner"
            ApartmentHL.PlayerMap = "EclipseHL"
            ApartmentHL.Enabled = True
            ApartmentHL.InteriorID = Apartment.GetInteriorID(ApartmentHL.Interior)
            If Not ApartmentHL.InteriorID = 0 Then InteriorIDList.Add(ApartmentHL.InteriorID)

            ApartmentPS1 = New Apartment("Eclipse, Penthouse Suite ", "1", 985000)
            ApartmentPS1.Name = ReadCfgValue("EclipsePS1Name", langFile)
            ApartmentPS1.Description = ReadCfgValue("EclipsePS1Desc", langFile)
            ApartmentPS1.Owner = ReadCfgValue("ETP1owner", saveFile)
            ApartmentPS1.Save = New Vector3(-797.7579, 337.3798, 220.4384)
            ApartmentPS1.TeleportInside = New Vector3(-784.0423, 320.9214, 217.439)
            ApartmentPS1.TeleportOutside = New Vector3(-773.282, 312.275, 84.698)
            ApartmentPS1.ApartmentExit = New Vector3(-781.851, 318.094, 217.6388)
            ApartmentPS1.Wardrobe = New Vector3(-796.9515, 328.2715, 220.4384)
            ApartmentPS1.Interior = New Vector3(-787.8102, 326.0671, 217.0382)
            ApartmentPS1.WardrobeHeading = 359.5432
            ApartmentPS1.ApartmentStyleCameraPosition = New Vector3(-786.6251, 343.8772, 218.0287)
            ApartmentPS1.ApartmentStyleCameraRotation = New Vector3(-7.585561, 0, -163.3333)
            ApartmentPS1.ApartmentStyleCameraFOV = 50.0
            ApartmentPS1.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
            ApartmentPS1.SaveFile = "ETP1owner"
            ApartmentPS1.PlayerMap = "EclipsePS1"
            ApartmentPS1.IPL = ReadCfgValue("ETP1ipl", saveFile)
            ApartmentPS1.LastIPL = ApartmentPS1.IPL
            ApartmentPS1.Enabled = True
            ApartmentPS1.InteriorID = Apartment.GetInteriorID(ApartmentPS1.Interior)
            If Not ApartmentPS1.InteriorID = 0 Then InteriorIDList.Add(ApartmentPS1.InteriorID)

            ApartmentPS2 = New Apartment("Eclipse, Penthouse Suite ", "2", 905000)
            ApartmentPS2.Name = ReadCfgValue("EclipsePS2Name", langFile)
            ApartmentPS2.Description = ReadCfgValue("EclipsePS1Desc", langFile)
            ApartmentPS2.Owner = ReadCfgValue("ETP2owner", saveFile)
            ApartmentPS2.Save = New Vector3(-763.3478, 320.4298, 199.4861)
            ApartmentPS2.TeleportInside = New Vector3(-776.9169, 336.887, 196.4864)
            ApartmentPS2.TeleportOutside = New Vector3(-773.282, 312.275, 84.698)
            ApartmentPS2.ApartmentExit = New Vector3(-779.2371, 339.6224, 196.6866)
            ApartmentPS2.Wardrobe = New Vector3(-763.9934, 329.6285, 199.4863)
            ApartmentPS2.Interior = New Vector3(-775.0426, 329.8042, 196.086)
            ApartmentPS2.WardrobeHeading = 178.7236
            ApartmentPS2.ApartmentStyleCameraPosition = New Vector3(-774.2443, 314.4292, 196.6641)
            ApartmentPS2.ApartmentStyleCameraRotation = New Vector3(-2.762131, 0, 16.02366)
            ApartmentPS2.ApartmentStyleCameraFOV = 50.0
            ApartmentPS2.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
            ApartmentPS2.SaveFile = "ETP2owner"
            ApartmentPS2.PlayerMap = "EclipsePS2"
            ApartmentPS2.IPL = ReadCfgValue("ETP2ipl", saveFile)
            ApartmentPS2.LastIPL = ApartmentPS2.IPL
            ApartmentPS2.Enabled = True
            ApartmentPS2.InteriorID = Apartment.GetInteriorID(ApartmentPS2.Interior)
            If Not ApartmentPS2.InteriorID = 0 Then InteriorIDList.Add(ApartmentPS2.InteriorID)

            ApartmentPS3 = New Apartment("Eclipse, Penthouse Suite ", "3", 1100000)
            ApartmentPS3.Name = ReadCfgValue("EclipsePS3Name", langFile)
            ApartmentPS3.Description = ReadCfgValue("EclipsePS3Desc", langFile)
            ApartmentPS3.Owner = ReadCfgValue("ETP3owner", saveFile)
            ApartmentPS3.Save = New Vector3(-797.7316, 337.315, 190.7134)
            ApartmentPS3.TeleportInside = New Vector3(-784.0712, 320.7265, 187.7136)
            ApartmentPS3.TeleportOutside = New Vector3(-773.282, 312.275, 84.698)
            ApartmentPS3.ApartmentExit = New Vector3(-781.9078, 318.1647, 187.9138)
            ApartmentPS3.Wardrobe = New Vector3(-796.9515, 328.2715, 190.7134)
            ApartmentPS3.Interior = New Vector3(-788.7599, 325.535, 187.3132)
            ApartmentPS3.WardrobeHeading = 359.5432
            ApartmentPS3.ApartmentStyleCameraPosition = New Vector3(-786.7924, 343.3035, 187.8668)
            ApartmentPS3.ApartmentStyleCameraRotation = New Vector3(-1.956791, 0, -163.332)
            ApartmentPS3.ApartmentStyleCameraFOV = 50.0
            ApartmentPS3.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"
            ApartmentPS3.SaveFile = "ETP3owner"
            ApartmentPS3.PlayerMap = "EclipsePS3"
            ApartmentPS3.IPL = ReadCfgValue("ETP3ipl", saveFile)
            ApartmentPS3.LastIPL = ApartmentPS3.IPL
            ApartmentPS3.Enabled = True
            ApartmentPS3.InteriorID = Apartment.GetInteriorID(ApartmentPS3.Interior)
            If Not ApartmentPS3.InteriorID = 0 Then InteriorIDList.Add(ApartmentPS3.InteriorID)

            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then
                Garage = ReadCfgValue("Garage", langFile)
                AptOptions = ReadCfgValue("AptOptions", langFile)
                ExitApt = ReadCfgValue("ExitApt", langFile)
                SellApt = ReadCfgValue("SellApt", langFile)
                EnterGarage = ReadCfgValue("EnterGarage", langFile)
                GrgOptions = ReadCfgValue("GrgOptions", langFile)
                ForSale = ReadCfgValue("ForSale", langFile)
                PropPurchased = ReadCfgValue("PropPurchased", langFile)
                Maze = ReadCfgValue("Maze", langFile)
                Fleeca = ReadCfgValue("Fleeca", langFile)
                BOL = ReadCfgValue("BOL", langFile)
                InsFundApartment = ReadCfgValue("InsFundApartment", langFile)
                EnterApartment = ReadCfgValue("EnterApartment", langFile)
                SaveGame = ReadCfgValue("SaveGame", langFile)
                ExitApartment = ReadCfgValue("ExitApartment", langFile)
                ChangeClothes = ReadCfgValue("ChangeClothes", langFile)
                _EnterGarage = ReadCfgValue("_EnterGarage", langFile)
                CannotStore = ReadCfgValue("CannotStore", langFile)
                AptStyle = ReadCfgValue("AptStyle", langFile)
                ModernStyle = ReadCfgValue("ModernStyle", langFile)
                MoodyStyle = ReadCfgValue("MoodyStyle", langFile)
                VibrantStyle = ReadCfgValue("VibrantStyle", langFile)
                SharpStyle = ReadCfgValue("SharpStyle", langFile)
                MonochromeStyle = ReadCfgValue("MonochromeStyle", langFile)
                SeductiveStyle = ReadCfgValue("SeductiveStyle", langFile)
                RegalStyle = ReadCfgValue("RegalStyle", langFile)
                AquaStyle = ReadCfgValue("AquaStyle", langFile)

                _menuPool = New MenuPool()
                CreateBuyMenu()
                CreateExitMenu()
                CreateExitMenuHL()
                CreateExitMenuPS1()
                CreateExitMenuPS2()
                CreateExitMenuPS3()
                CreateAptStyleMenuPS1()
                CreateAptStyleMenuPS2()
                CreateAptStyleMenuPS3()
                CreateGarageMenu()

                AddHandler BuyMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler BuyMenu.OnItemSelect, AddressOf BuyItemSelectHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler GarageMenu.OnItemSelect, AddressOf GarageItemSelectHandler
                AddHandler ExitMenuHL.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenuHL.OnItemSelect, AddressOf HLItemSelectHandler
                AddHandler ExitMenuPS1.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenuPS1.OnItemSelect, AddressOf PS1ItemSelectHandler
                AddHandler ExitMenuPS2.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenuPS2.OnItemSelect, AddressOf PS2ItemSelectHandler
                AddHandler ExitMenuPS3.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenuPS3.OnItemSelect, AddressOf PS3ItemSelectHandler
                AddHandler StyleMenuPS1.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler StyleMenuPS1.OnItemSelect, AddressOf PS1ItemSelectHandler
                AddHandler StyleMenuPS1.OnIndexChange, AddressOf PS1IndexChangeHandler
                AddHandler StyleMenuPS2.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler StyleMenuPS2.OnItemSelect, AddressOf PS2ItemSelectHandler
                AddHandler StyleMenuPS2.OnIndexChange, AddressOf PS2IndexChangeHandler
                AddHandler StyleMenuPS3.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler StyleMenuPS3.OnItemSelect, AddressOf PS3ItemSelectHandler
                AddHandler StyleMenuPS3.OnIndexChange, AddressOf PS3IndexChangeHandler
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateBuyMenu()
        Try
            BuyMenu = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            BuyMenu.SetBannerType(Rectangle)
            _menuPool.Add(BuyMenu)
            Dim item As New UIMenuItem(Apartment.Name & Apartment.Unit, Apartment.Description)
            With item
                If Apartment.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf Apartment.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf Apartment.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf Apartment.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & Apartment.Cost.ToString("N"))
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            BuyMenu.AddItem(item)
            Dim item2 As New UIMenuItem(ApartmentHL.Name & ApartmentHL.Unit, ApartmentHL.Description)
            With item2
                If ApartmentHL.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentHL.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentHL.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentHL.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & ApartmentHL.Cost.ToString("N"))
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            BuyMenu.AddItem(item2)
            Dim item3 As New UIMenuItem(ApartmentPS1.Name & ApartmentPS1.Unit, ApartmentPS1.Description)
            With item3
                If ApartmentPS1.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentPS1.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentPS1.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentPS1.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & ApartmentPS1.Cost.ToString("N"))
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            BuyMenu.AddItem(item3)
            Dim item4 As New UIMenuItem(ApartmentPS2.Name & ApartmentPS2.Unit, ApartmentPS2.Description)
            With item4
                If ApartmentPS2.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentPS2.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentPS2.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentPS2.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & ApartmentPS2.Cost.ToString("N"))
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            BuyMenu.AddItem(item4)
            Dim item5 As New UIMenuItem(ApartmentPS3.Name & ApartmentPS3.Unit, ApartmentPS3.Description)
            With item5
                If ApartmentPS3.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentPS3.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentPS3.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentPS3.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & ApartmentPS3.Cost.ToString("N"))
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            BuyMenu.AddItem(item5)
            BuyMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub RefreshMenu()
        BuyMenu.MenuItems.Clear()
        Dim item As New UIMenuItem(Apartment.Name & Apartment.Unit, Apartment.Description)
        With item
            If Apartment.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf Apartment.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf Apartment.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf Apartment.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & Apartment.Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item)
        Dim item2 As New UIMenuItem(ApartmentHL.Name & ApartmentHL.Unit, ApartmentHL.Description)
        With item2
            If ApartmentHL.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentHL.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentHL.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentHL.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & ApartmentHL.Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item2)
        Dim item3 As New UIMenuItem(ApartmentPS1.Name & ApartmentPS1.Unit, ApartmentPS1.Description)
        With item3
            If ApartmentPS1.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentPS1.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentPS1.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentPS1.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & ApartmentPS1.Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item3)
        Dim item4 As New UIMenuItem(ApartmentPS2.Name & ApartmentPS2.Unit, ApartmentPS2.Description)
        With item4
            If ApartmentPS2.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentPS2.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentPS2.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentPS2.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & ApartmentPS2.Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item4)
        Dim item5 As New UIMenuItem(ApartmentPS3.Name & ApartmentPS3.Unit, ApartmentPS3.Description)
        With item5
            If ApartmentPS3.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentPS3.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentPS3.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentPS3.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & ApartmentPS3.Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item5)
        BuyMenu.RefreshIndex()
    End Sub

    Public Shared Sub RefreshGarageMenu()
        GarageMenu.MenuItems.Clear()
        Dim item As New UIMenuItem(Apartment.Name & Apartment.Unit & Garage)
        With item
            If Apartment.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf Apartment.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf Apartment.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf Apartment.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        GarageMenu.AddItem(item)
        Dim item2 As New UIMenuItem(ApartmentHL.Name & ApartmentHL.Unit & Garage)
        With item2
            If ApartmentHL.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentHL.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentHL.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentHL.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        GarageMenu.AddItem(item2)
        Dim item3 As New UIMenuItem(ApartmentPS1.Name & ApartmentPS1.Unit & Garage)
        With item3
            If ApartmentPS1.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentPS1.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentPS1.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentPS1.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        GarageMenu.AddItem(item3)
        Dim item4 As New UIMenuItem(ApartmentPS2.Name & ApartmentPS2.Unit & Garage)
        With item4
            If ApartmentPS2.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentPS2.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentPS2.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentPS2.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        GarageMenu.AddItem(item4)
        Dim item5 As New UIMenuItem(ApartmentPS3.Name & ApartmentPS3.Unit & Garage)
        With item5
            If ApartmentPS3.Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf ApartmentPS3.Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf ApartmentPS3.Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf ApartmentPS3.Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        GarageMenu.AddItem(item5)
        GarageMenu.RefreshIndex()
    End Sub

    Public Shared Sub CreateAptStyleMenuPS1()
        Try
            StyleMenuPS1 = New UIMenu("", AptStyle.ToUpper, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            StyleMenuPS1.SetBannerType(Rectangle)
            _menuPool.Add(StyleMenuPS1)
            StyleMenuPS1.AddItem(New UIMenuItem(ModernStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(MoodyStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(VibrantStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(SharpStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(MonochromeStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(SeductiveStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(RegalStyle))
            StyleMenuPS1.AddItem(New UIMenuItem(AquaStyle))
            StyleMenuPS1.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateAptStyleMenuPS2()
        Try
            StyleMenuPS2 = New UIMenu("", AptStyle.ToUpper, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            StyleMenuPS2.SetBannerType(Rectangle)
            _menuPool.Add(StyleMenuPS2)
            StyleMenuPS2.AddItem(New UIMenuItem(ModernStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(MoodyStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(VibrantStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(SharpStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(MonochromeStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(SeductiveStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(RegalStyle))
            StyleMenuPS2.AddItem(New UIMenuItem(AquaStyle))
            StyleMenuPS2.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateAptStyleMenuPS3()
        Try
            StyleMenuPS3 = New UIMenu("", AptStyle.ToUpper, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            StyleMenuPS3.SetBannerType(Rectangle)
            _menuPool.Add(StyleMenuPS3)
            StyleMenuPS3.AddItem(New UIMenuItem(ModernStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(MoodyStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(VibrantStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(SharpStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(MonochromeStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(SeductiveStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(RegalStyle))
            StyleMenuPS3.AddItem(New UIMenuItem(AquaStyle))
            StyleMenuPS3.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateExitMenu()
        Try
            ExitMenu = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenu.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenu)
            ExitMenu.AddItem(New UIMenuItem(ExitApt))
            ExitMenu.AddItem(New UIMenuItem(EnterGarage))
            ExitMenu.AddItem(New UIMenuItem(SellApt))
            ExitMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateExitMenuHL()
        Try
            ExitMenuHL = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenuHL.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenuHL)
            ExitMenuHL.AddItem(New UIMenuItem(ExitApt))
            ExitMenuHL.AddItem(New UIMenuItem(EnterGarage))
            ExitMenuHL.AddItem(New UIMenuItem(SellApt))
            ExitMenuHL.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateExitMenuPS1()
        Try
            ExitMenuPS1 = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenuPS1.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenuPS1)
            ExitMenuPS1.AddItem(New UIMenuItem(ExitApt))
            ExitMenuPS1.AddItem(New UIMenuItem(EnterGarage))
            ExitMenuPS1.AddItem(New UIMenuItem(SellApt))
            ExitMenuPS1.AddItem(New UIMenuItem(AptStyle))
            ExitMenuPS1.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateExitMenuPS2()
        Try
            ExitMenuPS2 = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenuPS2.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenuPS2)
            ExitMenuPS2.AddItem(New UIMenuItem(ExitApt))
            ExitMenuPS2.AddItem(New UIMenuItem(EnterGarage))
            ExitMenuPS2.AddItem(New UIMenuItem(SellApt))
            ExitMenuPS2.AddItem(New UIMenuItem(AptStyle))
            ExitMenuPS2.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateExitMenuPS3()
        Try
            ExitMenuPS3 = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ExitMenuPS3.SetBannerType(Rectangle)
            _menuPool.Add(ExitMenuPS3)
            ExitMenuPS3.AddItem(New UIMenuItem(ExitApt))
            ExitMenuPS3.AddItem(New UIMenuItem(EnterGarage))
            ExitMenuPS3.AddItem(New UIMenuItem(SellApt))
            ExitMenuPS3.AddItem(New UIMenuItem(AptStyle))
            ExitMenuPS3.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu()
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            Dim item As New UIMenuItem(Apartment.Name & Apartment.Unit & Garage)
            With item
                If Apartment.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf Apartment.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf Apartment.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf Apartment.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            GarageMenu.AddItem(item)
            Dim item2 As New UIMenuItem(ApartmentHL.Name & ApartmentHL.Unit & Garage)
            With item2
                If ApartmentHL.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentHL.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentHL.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentHL.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            GarageMenu.AddItem(item2)
            Dim item3 As New UIMenuItem(ApartmentPS1.Name & ApartmentPS1.Unit & Garage)
            With item3
                If ApartmentPS1.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentPS1.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentPS1.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentPS1.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            GarageMenu.AddItem(item3)
            Dim item4 As New UIMenuItem(ApartmentPS2.Name & ApartmentPS2.Unit & Garage)
            With item4
                If ApartmentPS2.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentPS2.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentPS2.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentPS2.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            GarageMenu.AddItem(item4)
            Dim item5 As New UIMenuItem(ApartmentPS3.Name & ApartmentPS3.Unit & Garage)
            With item5
                If ApartmentPS3.Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf ApartmentPS3.Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf ApartmentPS3.Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf ApartmentPS3.Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            GarageMenu.AddItem(item5)
            GarageMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateEclipseTower()
        Apartment.Create5(Apartment, ApartmentHL, ApartmentPS1, ApartmentPS2, ApartmentPS3)
    End Sub

    Public Sub MenuCloseHandler(sender As UIMenu)
        Try
            hideHud = False
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitApt Then
                'Exit Apt
                ExitMenu.Visible = False
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue(Apartment.SaveFile, "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Apartment.Cost)
                Apartment.Owner = "None"
                Apartment.AptBlip.Remove()
                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                CreateEclipseTower()
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                Brain.TVOn = False
                TenCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
                TenCarGarage.lastLocationVector = Apartment.ApartmentExit
                TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
                TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
                TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                TenCarGarage.CurrentPath = Apartment.GaragePath
                playerPed.Position = TenCarGarage.Elevator
                ExitMenu.Visible = False
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub HLItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitApt Then
                'Exit Apt
                ExitMenuHL.Visible = False
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Brain.TVOn = False
                Game.Player.Character.Position = ApartmentHL.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenuHL.Visible = False
                WriteCfgValue(ApartmentHL.SaveFile, "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + ApartmentHL.Cost)
                ApartmentHL.Owner = "None"
                Apartment.AptBlip.Remove()
                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                CreateEclipseTower()
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                Brain.TVOn = False
                TenCarGarage.LastLocationName = ApartmentHL.Name & ApartmentHL.Unit
                TenCarGarage.lastLocationVector = ApartmentHL.ApartmentExit
                TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
                TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
                TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                TenCarGarage.CurrentPath = ApartmentHL.GaragePath
                playerPed.Position = TenCarGarage.Elevator
                ExitMenuHL.Visible = False
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PS1ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitApt Then
                'Exit Apt
                ExitMenuPS1.Visible = False
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Brain.TVOn = False
                Game.Player.Character.Position = ApartmentPS1.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenuPS1.Visible = False
                WriteCfgValue(ApartmentPS1.SaveFile, "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + ApartmentPS1.Cost)
                ApartmentPS1.Owner = "None"
                Apartment.AptBlip.Remove()
                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                CreateEclipseTower()
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                Brain.TVOn = False
                TenCarGarage.LastLocationName = ApartmentPS1.Name & ApartmentPS1.Unit
                TenCarGarage.lastLocationVector = ApartmentPS1.ApartmentExit
                TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
                TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
                TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                TenCarGarage.CurrentPath = ApartmentPS1.GaragePath
                playerPed.Position = TenCarGarage.Elevator
                ExitMenuPS1.Visible = False
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = AptStyle Then
                ExitMenuPS1.Visible = False
                StyleMenuPS1.Visible = True
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                World.RenderingCamera = World.CreateCamera(ApartmentPS1.ApartmentStyleCameraPosition, ApartmentPS1.ApartmentStyleCameraRotation, ApartmentPS1.ApartmentStyleCameraFOV)
                hideHud = True
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            If selectedItem.Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_01_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_01_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_02_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_02_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_03_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_03_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_04_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_04_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_05_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_05_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_06_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_06_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_07_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_07_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP1ipl", "apa_v_mp_h_08_a", saveFile)
                ApartmentPS1.IPL = "apa_v_mp_h_08_a"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS1.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PS2ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitApt Then
                'Exit Apt
                ExitMenuPS2.Visible = False
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Brain.TVOn = False
                Game.Player.Character.Position = ApartmentPS2.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenuPS2.Visible = False
                WriteCfgValue(ApartmentPS2.SaveFile, "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + ApartmentPS2.Cost)
                ApartmentPS2.Owner = "None"
                Apartment.AptBlip.Remove()
                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                CreateEclipseTower()
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                Brain.TVOn = False
                TenCarGarage.LastLocationName = ApartmentPS2.Name & ApartmentPS2.Unit
                TenCarGarage.lastLocationVector = ApartmentPS2.ApartmentExit
                TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
                TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
                TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                TenCarGarage.CurrentPath = ApartmentPS2.GaragePath
                playerPed.Position = TenCarGarage.Elevator
                ExitMenuPS2.Visible = False
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = AptStyle Then
                ExitMenuPS2.Visible = False
                StyleMenuPS2.Visible = True
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                World.RenderingCamera = World.CreateCamera(ApartmentPS2.ApartmentStyleCameraPosition, ApartmentPS2.ApartmentStyleCameraRotation, ApartmentPS2.ApartmentStyleCameraFOV)
                hideHud = True
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            If selectedItem.Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_01_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_01_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_02_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_02_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_03_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_03_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_04_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_04_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_05_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_05_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_06_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_06_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_07_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_07_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_08_b", saveFile)
                ApartmentPS2.IPL = "apa_v_mp_h_08_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS2.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PS3ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ExitApt Then
                'Exit Apt
                ExitMenuPS3.Visible = False
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Brain.TVOn = False
                Game.Player.Character.Position = ApartmentPS3.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenuPS3.Visible = False
                WriteCfgValue(ApartmentPS3.SaveFile, "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + ApartmentPS3.Cost)
                ApartmentPS3.Owner = "None"
                Apartment.AptBlip.Remove()
                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                CreateEclipseTower()
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                Brain.TVOn = False
                TenCarGarage.LastLocationName = ApartmentPS3.Name & ApartmentPS3.Unit
                TenCarGarage.lastLocationVector = ApartmentPS3.ApartmentExit
                TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
                TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
                TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                TenCarGarage.CurrentPath = ApartmentPS3.GaragePath
                playerPed.Position = TenCarGarage.Elevator
                ExitMenuPS3.Visible = False
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = AptStyle Then
                ExitMenuPS3.Visible = False
                StyleMenuPS3.Visible = True
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                World.RenderingCamera = World.CreateCamera(ApartmentPS3.ApartmentStyleCameraPosition, ApartmentPS3.ApartmentStyleCameraRotation, ApartmentPS3.ApartmentStyleCameraFOV)
                hideHud = True
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            If selectedItem.Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_01_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_01_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_02_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_02_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_03_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_03_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_04_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_04_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_05_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_05_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_06_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_06_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_07_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_07_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_08_c", saveFile)
                ApartmentPS3.IPL = "apa_v_mp_h_08_c"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenuPS3.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PS1IndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If sender.MenuItems(index).Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_01_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_01_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_02_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_02_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_03_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_03_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_04_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_04_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_05_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_05_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_06_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_06_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_07_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_07_a"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS1.LastIPL, "apa_v_mp_h_08_a", ApartmentPS1.Interior)
                ApartmentPS1.LastIPL = "apa_v_mp_h_08_a"
                Wait(500)
                Game.FadeScreenIn(500)
            End If
            ApartmentPS1.IPL = ApartmentPS1.LastIPL
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PS2IndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If sender.MenuItems(index).Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_01_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_01_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_02_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_02_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_03_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_03_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_04_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_04_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_05_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_05_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_06_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_06_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_07_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_07_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS2.LastIPL, "apa_v_mp_h_08_b", ApartmentPS2.Interior)
                ApartmentPS2.LastIPL = "apa_v_mp_h_08_b"
                Wait(500)
                Game.FadeScreenIn(500)
            End If
            ApartmentPS2.IPL = ApartmentPS2.LastIPL
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PS3IndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If sender.MenuItems(index).Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_01_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_01_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_02_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_02_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_03_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_03_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_04_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_04_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_05_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_05_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_06_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_06_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_07_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_07_c"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(ApartmentPS3.LastIPL, "apa_v_mp_h_08_c", ApartmentPS3.Interior)
                ApartmentPS3.LastIPL = "apa_v_mp_h_08_c"
                Wait(500)
                Game.FadeScreenIn(500)
            End If
            ApartmentPS3.IPL = ApartmentPS3.LastIPL
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub BuyItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            'Eclipse Tower
            If selectedItem.Text = Apartment.Name & Apartment.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & Apartment.Cost.ToString("N") AndAlso Apartment.Owner = "None" Then
                'Buy Apartment
                If playerCash > Apartment.Cost Then
                    WriteCfgValue(Apartment.SaveFile, playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - Apartment.Cost)
                    Apartment.Owner = playerName
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    CreateEclipseTower()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & Apartment.Name & Apartment.Unit, Nothing)
                    If playerName = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf playerName = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf playerName = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf playerName = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If playerName = "Michael" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Franklin" Then
                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Trevor" Then
                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Player3" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = Apartment.Name & Apartment.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Apartment.Owner = playerName Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing

                Apartment.SetInteriorActive()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Game.Player.Character.Position = Apartment.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-787.8336, 342.3493, 206.2184))
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            '4 Integrity Way HL
            If selectedItem.Text = ApartmentHL.Name & ApartmentHL.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & ApartmentHL.Cost.ToString("N") AndAlso ApartmentHL.Owner = "None" Then
                'Buy Apartment
                If playerCash > ApartmentHL.Cost Then
                    WriteCfgValue(ApartmentHL.SaveFile, playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - ApartmentHL.Cost)
                    ApartmentHL.Owner = playerName
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    CreateEclipseTower()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & ApartmentHL.Name & ApartmentHL.Unit, Nothing)
                    If playerName = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf playerName = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf playerName = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf playerName = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If playerName = "Michael" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Franklin" Then
                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Trevor" Then
                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Player3" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = ApartmentHL.Name & ApartmentHL.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso ApartmentHL.Owner = playerName Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()

                ApartmentHL.SetInteriorActive()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Game.Player.Character.Position = ApartmentHL.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-769.3657, 324.1958, 211.9971))
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Eclipse Tower Penthouse 1
            If selectedItem.Text = ApartmentPS1.Name & ApartmentPS1.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & ApartmentPS1.Cost.ToString("N") AndAlso ApartmentPS1.Owner = "None" Then
                'Buy Apartment
                If playerCash > ApartmentPS1.Cost Then
                    WriteCfgValue(ApartmentPS1.SaveFile, playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - ApartmentPS1.Cost)
                    ApartmentPS1.Owner = playerName
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    CreateEclipseTower()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & ApartmentPS1.Name & ApartmentPS1.Unit, Nothing)
                    If playerName = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf playerName = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf playerName = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf playerName = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If playerName = "Michael" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Franklin" Then
                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Trevor" Then
                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Player3" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = ApartmentPS1.Name & ApartmentPS1.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso ApartmentPS1.Owner = playerName Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                ToggleIPL(ReadCfgValue("ETP1ipl", saveFile))

                ApartmentPS1.SetInteriorActive()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Game.Player.Character.Position = ApartmentPS1.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-788.0755, 319.9557, 217.0382))
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Eclipse Tower Penthouse 2
            If selectedItem.Text = ApartmentPS2.Name & ApartmentPS2.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & ApartmentPS2.Cost.ToString("N") AndAlso ApartmentPS2.Owner = "None" Then
                'Buy Apartment
                If playerCash > ApartmentPS2.Cost Then
                    WriteCfgValue(ApartmentPS2.SaveFile, playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - ApartmentPS2.Cost)
                    ApartmentPS2.Owner = playerName
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    CreateEclipseTower()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & ApartmentPS2.Name & ApartmentPS2.Unit, Nothing)
                    If playerName = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf playerName = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf playerName = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf playerName = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If playerName = "Michael" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Franklin" Then
                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Trevor" Then
                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Player3" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = ApartmentPS2.Name & ApartmentPS2.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso ApartmentPS2.Owner = playerName Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                ToggleIPL(ReadCfgValue("ETP2ipl", saveFile))

                ApartmentPS2.SetInteriorActive()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Game.Player.Character.Position = ApartmentPS2.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-772.9551, 337.914, 196.086))
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Eclipse Tower Penthouse 3
            If selectedItem.Text = ApartmentPS3.Name & ApartmentPS3.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & ApartmentPS3.Cost.ToString("N") AndAlso ApartmentPS3.Owner = "None" Then
                'Buy Apartment
                If playerCash > ApartmentPS3.Cost Then
                    WriteCfgValue(ApartmentPS3.SaveFile, playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - ApartmentPS3.Cost)
                    ApartmentPS3.Owner = playerName
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    CreateEclipseTower()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & ApartmentPS3.Name & ApartmentPS3.Unit, Nothing)
                    If playerName = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf playerName = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf playerName = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf playerName = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If playerName = "Michael" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Franklin" Then
                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Trevor" Then
                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    ElseIf playerName = "Player3" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = ApartmentPS3.Name & ApartmentPS3.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso ApartmentPS3.Owner = playerName Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                ToggleIPL(ReadCfgValue("ETP3ipl", saveFile))

                ApartmentPS3.SetInteriorActive()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Game.Player.Character.Position = ApartmentPS3.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-788.2332, 319.9676, 187.3132))
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub GarageItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        'Eclipse Tower On Foot
        If selectedItem.Text = Apartment.Name & Apartment.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle AndAlso Apartment.Owner = playerName Then
            'Teleport to Garage

            Game.FadeScreenOut(500)
            Wait(&H3E8)
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            Apartment.SetInteriorActive()
            TenCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
            TenCarGarage.lastLocationVector = Apartment.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
            TenCarGarage.CurrentPath = Apartment.GaragePath
            playerPed.Position = TenCarGarage.GarageDoorL
            GarageMenu.Visible = False
            Wait(500)
            Game.FadeScreenIn(500)
            'Eclipse Tower On Vehicle
        ElseIf selectedItem.Text = Apartment.Name & Apartment.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle AndAlso Apartment.Owner = playerName Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9 As String
            If IO.File.Exists(Apartment.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_6.cfg") Else VehPlate6 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_7.cfg") Else VehPlate7 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_8.cfg") Else VehPlate8 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_9.cfg") Else VehPlate9 = "0"

            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            Apartment.SetInteriorActive()
            TenCarGarage.CurrentPath = Apartment.GaragePath
            TenCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
            TenCarGarage.lastLocationVector = Apartment.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_0.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_1.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_2.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_3.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_4.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_5.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_6.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh6, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_7.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh7, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_8.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh8, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_9.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh9, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            Else
                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                TenCarGarage.SaveGarageVehicle(Apartment.GaragePath)
            End If

            'Eclipse Tower HL On Foot
        ElseIf selectedItem.Text = ApartmentHL.Name & ApartmentHL.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle AndAlso ApartmentHL.Owner = playerName Then
            'Teleport to Garage
            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()

            Game.FadeScreenOut(500)
            Wait(&H3E8)
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentHL.SetInteriorActive()
            TenCarGarage.LastLocationName = ApartmentHL.Name & ApartmentHL.Unit
            TenCarGarage.lastLocationVector = ApartmentHL.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
            TenCarGarage.CurrentPath = ApartmentHL.GaragePath
            playerPed.Position = TenCarGarage.GarageDoorL
            GarageMenu.Visible = False
            Wait(500)
            Game.FadeScreenIn(500)

            'Eclipse Tower HL On Vehicle
        ElseIf selectedItem.Text = ApartmentHL.Name & ApartmentHL.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle AndAlso ApartmentHL.Owner = playerName Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9 As String
            Dim path As String = ApartmentHL.GaragePath
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_6.cfg") Else VehPlate6 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_7.cfg") Else VehPlate7 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_8.cfg") Else VehPlate8 = "0"
            If IO.File.Exists(ApartmentHL.GaragePath & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", ApartmentHL.GaragePath & "vehicle_9.cfg") Else VehPlate9 = "0"

            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()

            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentHL.SetInteriorActive()
            TenCarGarage.CurrentPath = ApartmentHL.GaragePath
            TenCarGarage.LastLocationName = ApartmentHL.Name & ApartmentHL.Unit
            TenCarGarage.lastLocationVector = ApartmentHL.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_0.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_1.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_2.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_3.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_4.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_5.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_6.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh6, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_7.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh7, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_8.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh8, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentHL.GaragePath & "vehicle_9.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh9, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            Else
                TenCarGarage.LoadGarageVechicles(ApartmentHL.GaragePath)
                TenCarGarage.SaveGarageVehicle(ApartmentHL.GaragePath)
            End If

            'Eclipse Tower Penthouse 1 On Foot
        ElseIf selectedItem.Text = ApartmentPS1.Name & ApartmentPS1.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle AndAlso ApartmentPS1.Owner = playerName Then
            'Teleport to Garage
            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            ToggleIPL(ReadCfgValue("ETP1ipl", saveFile))
            Game.FadeScreenOut(500)
            Wait(&H3E8)
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentPS1.SetInteriorActive()
            TenCarGarage.LastLocationName = ApartmentPS1.Name & ApartmentPS1.Unit
            TenCarGarage.lastLocationVector = ApartmentPS1.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
            TenCarGarage.CurrentPath = ApartmentPS1.GaragePath
            playerPed.Position = TenCarGarage.GarageDoorL
            GarageMenu.Visible = False
            Wait(500)
            Game.FadeScreenIn(500)
            'Eclipse Tower Penthouse 1 On Vehicle
        ElseIf selectedItem.Text = ApartmentPS1.Name & ApartmentPS1.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle AndAlso ApartmentPS1.Owner = playerName Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9 As String
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_6.cfg") Else VehPlate6 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_7.cfg") Else VehPlate7 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_8.cfg") Else VehPlate8 = "0"
            If IO.File.Exists(ApartmentPS1.GaragePath & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", ApartmentPS1.GaragePath & "vehicle_9.cfg") Else VehPlate9 = "0"

            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            ToggleIPL(ReadCfgValue("ETP1ipl", saveFile))
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentPS1.SetInteriorActive()
            TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
            TenCarGarage.CurrentPath = ApartmentPS1.GaragePath
            TenCarGarage.LastLocationName = ApartmentPS1.Name & ApartmentPS1.Unit
            TenCarGarage.lastLocationVector = ApartmentPS1.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_0.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_1.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_2.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_3.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_4.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_5.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_6.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh6, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_7.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh7, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_8.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh8, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS1.GaragePath & "vehicle_9.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh9, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            Else
                TenCarGarage.LoadGarageVechicles(ApartmentPS1.GaragePath)
                TenCarGarage.SaveGarageVehicle(ApartmentPS1.GaragePath)
            End If

            'Eclipse Tower Penthouse 2 On Foot
        ElseIf selectedItem.Text = ApartmentPS2.Name & ApartmentPS2.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle AndAlso ApartmentPS2.Owner = playerName Then
            'Teleport to Garage
            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            ToggleIPL(ReadCfgValue("ETP2ipl", saveFile))
            Game.FadeScreenOut(500)
            Wait(&H3E8)
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentPS2.SetInteriorActive()
            TenCarGarage.LastLocationName = ApartmentPS2.Name & ApartmentPS2.Unit
            TenCarGarage.lastLocationVector = ApartmentPS2.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
            TenCarGarage.CurrentPath = ApartmentPS2.GaragePath
            playerPed.Position = TenCarGarage.GarageDoorL
            GarageMenu.Visible = False
            Wait(500)
            Game.FadeScreenIn(500)
            'Eclipse Tower Penthouse 2 On Vehicle
        ElseIf selectedItem.Text = ApartmentPS2.Name & ApartmentPS2.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle AndAlso ApartmentPS2.Owner = playerName Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9 As String
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_6.cfg") Else VehPlate6 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_7.cfg") Else VehPlate7 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_8.cfg") Else VehPlate8 = "0"
            If IO.File.Exists(ApartmentPS2.GaragePath & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", ApartmentPS2.GaragePath & "vehicle_9.cfg") Else VehPlate9 = "0"

            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            ToggleIPL(ReadCfgValue("ETP2ipl", saveFile))
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentPS2.SetInteriorActive()
            TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
            TenCarGarage.CurrentPath = ApartmentPS2.GaragePath
            TenCarGarage.LastLocationName = ApartmentPS2.Name & ApartmentPS2.Unit
            TenCarGarage.lastLocationVector = ApartmentPS2.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_0.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_1.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_2.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_3.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_4.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_5.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_6.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh6, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_7.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh7, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_8.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh8, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS2.GaragePath & "vehicle_9.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh9, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            Else
                TenCarGarage.LoadGarageVechicles(ApartmentPS2.GaragePath)
                TenCarGarage.SaveGarageVehicle(ApartmentPS2.GaragePath)
            End If

            'Eclipse Tower Penthouse 3 On Foot
        ElseIf selectedItem.Text = ApartmentPS3.Name & ApartmentPS3.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle AndAlso ApartmentPS3.Owner = playerName Then
            'Teleport to Garage
            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            ToggleIPL(ReadCfgValue("ETP3ipl", saveFile))
            Game.FadeScreenOut(500)
            Wait(&H3E8)
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentPS3.SetInteriorActive()
            TenCarGarage.LastLocationName = ApartmentPS3.Name & ApartmentPS3.Unit
            TenCarGarage.lastLocationVector = ApartmentPS3.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
            TenCarGarage.CurrentPath = ApartmentPS3.GaragePath
            playerPed.Position = TenCarGarage.GarageDoorL
            GarageMenu.Visible = False
            Wait(500)
            Game.FadeScreenIn(500)
            'Eclipse Tower Penthouse 3 On Vehicle
        ElseIf selectedItem.Text = ApartmentPS3.Name & ApartmentPS3.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle AndAlso ApartmentPS3.Owner = playerName Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9 As String
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_6.cfg") Else VehPlate6 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_7.cfg") Else VehPlate7 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_8.cfg") Else VehPlate8 = "0"
            If IO.File.Exists(ApartmentPS3.GaragePath & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", ApartmentPS3.GaragePath & "vehicle_9.cfg") Else VehPlate9 = "0"

            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            ToggleIPL(ReadCfgValue("ETP3ipl", saveFile))
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            ApartmentPS3.SetInteriorActive()
            TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
            TenCarGarage.CurrentPath = ApartmentPS3.GaragePath
            TenCarGarage.LastLocationName = ApartmentPS3.Name & ApartmentPS3.Unit
            TenCarGarage.lastLocationVector = ApartmentPS3.ApartmentExit
            TenCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            TenCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            TenCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_0.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_1.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_2.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_3.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_4.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_5.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_6.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh6, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_7.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh7, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_8.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh8, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(ApartmentPS3.GaragePath & "vehicle_9.cfg", "False")
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, TenCarGarage.veh9, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Wait(500)
                Game.FadeScreenIn(500)
            Else
                TenCarGarage.LoadGarageVechicles(ApartmentPS3.GaragePath)
                TenCarGarage.SaveGarageVehicle(ApartmentPS3.GaragePath)
            End If
        End If
    End Sub

    Public Sub OnTick()
        Try
            If My.Settings.EclipseTower = "Enable" Then
                'Enter Apartment
                If (Not BuyMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.EntranceDistance < 3.0 Then
                    DisplayHelpTextThisFrame(EnterApartment & Apartment.Name)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        BuyMenu.Visible = True
                        World.RenderingCamera = World.CreateCamera(Apartment.CameraPosition, Apartment.CameraRotation, Apartment.CameraFOV)
                        hideHud = True
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If

                'Save Game
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.SaveDistance < 3.0 Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = Apartment.PlayerMap
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        TimeLapse(8)
                        Game.ShowSaveMenu()
                        SavePosition()
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentHL.Owner = playerName) AndAlso ApartmentHL.SaveDistance < 3.0 Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = ApartmentHL.PlayerMap
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        TimeLapse(8)
                        Game.ShowSaveMenu()
                        SavePosition()
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS1.Owner = playerName) AndAlso ApartmentPS1.SaveDistance < 3.0 Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = ApartmentPS1.PlayerMap
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        TimeLapse(8)
                        Game.ShowSaveMenu()
                        SavePosition()
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS2.Owner = playerName) AndAlso ApartmentPS2.SaveDistance < 3.0 Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = ApartmentPS2.PlayerMap
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        TimeLapse(8)
                        Game.ShowSaveMenu()
                        SavePosition()
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS3.Owner = playerName) AndAlso ApartmentPS3.SaveDistance < 3.0 Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = ApartmentPS3.PlayerMap
                        Game.FadeScreenOut(500)
                        Wait(&H3E8)
                        TimeLapse(8)
                        Game.ShowSaveMenu()
                        SavePosition()
                        Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If

                'Exit Apartment
                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.ExitDistance < 2.0 Then
                    DisplayHelpTextThisFrame(ExitApartment & Apartment.Name & Apartment.Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If
                If ((Not ExitMenuHL.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentHL.Owner = playerName) AndAlso ApartmentHL.ExitDistance < 2.0 Then
                    DisplayHelpTextThisFrame(ExitApartment & ApartmentHL.Name & ApartmentHL.Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenuHL.Visible = True
                    End If
                End If
                If ((Not ExitMenuPS1.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS1.Owner = playerName) AndAlso ApartmentPS1.ExitDistance < 2.0 Then
                    DisplayHelpTextThisFrame(ExitApartment & ApartmentPS1.Name & ApartmentPS1.Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenuPS1.Visible = True
                    End If
                End If
                If ((Not ExitMenuPS2.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS2.Owner = playerName) AndAlso ApartmentPS2.ExitDistance < 2.0 Then
                    DisplayHelpTextThisFrame(ExitApartment & ApartmentPS2.Name & ApartmentPS2.Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenuPS2.Visible = True
                    End If
                End If
                If ((Not ExitMenuPS3.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS3.Owner = playerName) AndAlso ApartmentPS3.ExitDistance < 2.0 Then
                    DisplayHelpTextThisFrame(ExitApartment & ApartmentPS3.Name & ApartmentPS3.Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenuPS3.Visible = True
                    End If
                End If

                'Wardrobe
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.WardrobeDistance < 1.0 Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = Apartment.Wardrobe
                        WardrobeHead = Apartment.WardrobeHeading
                        WardrobeScriptStatus = 0
                        If playerName = "Michael" Then
                            Player0W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Franklin" Then
                            Player1W.Visible = True
                            MakeACamera()
                        ElseIf playerName = “Trevor"
                            Player2W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Player3" Then
                            If playerHash = "1885233650" Then
                                Player3_MW.Visible = True
                                MakeACamera()
                            ElseIf playerHash = "-1667301416" Then
                                Player3_FW.Visible = True
                                MakeACamera()
                            End If
                        End If
                    End If
                End If
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentHL.Owner = playerName) AndAlso ApartmentHL.WardrobeDistance < 1.0 Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = ApartmentHL.Wardrobe
                        WardrobeHead = ApartmentHL.WardrobeHeading
                        WardrobeScriptStatus = 0
                        If playerName = "Michael" Then
                            Player0W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Franklin" Then
                            Player1W.Visible = True
                            MakeACamera()
                        ElseIf playerName = “Trevor"
                            Player2W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Player3" Then
                            If playerHash = "1885233650" Then
                                Player3_MW.Visible = True
                                MakeACamera()
                            ElseIf playerHash = "-1667301416" Then
                                Player3_FW.Visible = True
                                MakeACamera()
                            End If
                        End If
                    End If
                End If
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS1.Owner = playerName) AndAlso ApartmentPS1.WardrobeDistance < 1.0 Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = ApartmentPS1.Wardrobe
                        WardrobeHead = ApartmentPS1.WardrobeHeading
                        WardrobeScriptStatus = 0
                        If playerName = "Michael" Then
                            Player0W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Franklin" Then
                            Player1W.Visible = True
                            MakeACamera()
                        ElseIf playerName = “Trevor"
                            Player2W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Player3" Then
                            If playerHash = "1885233650" Then
                                Player3_MW.Visible = True
                                MakeACamera()
                            ElseIf playerHash = "-1667301416" Then
                                Player3_FW.Visible = True
                                MakeACamera()
                            End If
                        End If
                    End If
                End If
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS2.Owner = playerName) AndAlso ApartmentPS2.WardrobeDistance < 1.0 Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = ApartmentPS2.Wardrobe
                        WardrobeHead = ApartmentPS2.WardrobeHeading
                        WardrobeScriptStatus = 0
                        If playerName = "Michael" Then
                            Player0W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Franklin" Then
                            Player1W.Visible = True
                            MakeACamera()
                        ElseIf playerName = “Trevor"
                            Player2W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Player3" Then
                            If playerHash = "1885233650" Then
                                Player3_MW.Visible = True
                                MakeACamera()
                            ElseIf playerHash = "-1667301416" Then
                                Player3_FW.Visible = True
                                MakeACamera()
                            End If
                        End If
                    End If
                End If
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso ApartmentPS3.Owner = playerName) AndAlso ApartmentPS3.WardrobeDistance < 1.0 Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = ApartmentPS3.Wardrobe
                        WardrobeHead = ApartmentPS3.WardrobeHeading
                        WardrobeScriptStatus = 0
                        If playerName = "Michael" Then
                            Player0W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Franklin" Then
                            Player1W.Visible = True
                            MakeACamera()
                        ElseIf playerName = “Trevor"
                            Player2W.Visible = True
                            MakeACamera()
                        ElseIf playerName = "Player3" Then
                            If playerHash = "1885233650" Then
                                Player3_MW.Visible = True
                                MakeACamera()
                            ElseIf playerHash = "-1667301416" Then
                                Player3_FW.Visible = True
                                MakeACamera()
                            End If
                        End If
                    End If
                End If

                'Enter Garage
                If (Not playerPed.IsDead AndAlso (Apartment.Owner = playerName Or ApartmentHL.Owner = playerName Or ApartmentPS1.Owner = playerName Or ApartmentPS2.Owner = playerName Or ApartmentPS3.Owner = playerName)) AndAlso Apartment.GarageDistance < 5.0 Then
                    If Not playerPed.IsInVehicle AndAlso (Not GarageMenu.Visible) Then
                        DisplayHelpTextThisFrame(_EnterGarage & Garage)
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            GarageMenu.Visible = True
                        End If
                    ElseIf playerPed.IsInVehicle Then
                        If Resources.GetVehicleClass(playerPed.CurrentVehicle) = "Pegasus" Then
                            DisplayHelpTextThisFrame(CannotStore)
                        ElseIf playerPed.IsInVehicle AndAlso (Not GarageMenu.Visible) Then
                            DisplayHelpTextThisFrame(_EnterGarage & Garage)
                            If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                                GarageMenu.Visible = True
                            End If
                        End If
                    End If
                End If

                'If playerInterior = Apartment.InteriorID Then Apartment.IsAtHome = True Else Apartment.IsAtHome = False
                'If playerInterior = ApartmentHL.InteriorID Then Apartment.IsAtHome = True Else Apartment.IsAtHome = False
                'If playerInterior = ApartmentPS1.InteriorID Then Apartment.IsAtHome = True Else Apartment.IsAtHome = False
                'If playerInterior = ApartmentPS2.InteriorID Then Apartment.IsAtHome = True Else Apartment.IsAtHome = False
                'If playerInterior = ApartmentPS3.InteriorID Then Apartment.IsAtHome = True Else Apartment.IsAtHome = False

                Select Case playerInterior
                    Case Apartment.InteriorID, ApartmentHL.InteriorID, ApartmentPS1.InteriorID, ApartmentPS2.InteriorID, ApartmentPS3.InteriorID
                        Apartment.IsAtHome = True
                        HIDE_MAP_OBJECT_THIS_FRAME()
                    Case Else
                        Apartment.IsAtHome = False
                End Select

                If Apartment.IsAtHome Then
                    HIDE_MAP_OBJECT_THIS_FRAME()
                End If

                _menuPool.ProcessMenus()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub HIDE_MAP_OBJECT_THIS_FRAME()
        Native.Function.Call(Hash._0x4B5CFC83122DF602)
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "apa_ss1_11_flats"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ss1_11_ss1_emissive_a"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ss1_11_detail01b"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ss1_11_Flats_LOD"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "SS1_02_Building01_LOD"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "SS1_LOD_01_02_08_09_10_11"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "SS1_02_SLOD1"))
        Native.Function.Call(Hash._0x3669F1B198DCAA4F)
    End Sub

    Public Sub OnAborted() ' Handles MyBase.Aborted
        Try
            If Not Apartment.AptBlip Is Nothing Then Apartment.AptBlip.Remove()
            If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
        Catch ex As Exception
        End Try
    End Sub
End Class
