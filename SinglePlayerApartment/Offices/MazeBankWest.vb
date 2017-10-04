Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI
Imports SinglePlayerApartment.Wardrobe
Imports SinglePlayerApartment.INMNative

Public Class MazeBankWest

    Public Shared Apartment As Apartment
    Public Shared BuyMenu, ExitMenu, GarageMenu, StyleMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            Apartment = New Apartment("Maze Bank West", "", 7300000) '/
            Apartment.Name = ReadCfgValue("MazeBankWestName", langFile) '/
            Apartment.Description = ReadCfgValue("MazeBankWestDesc", langFile) '/
            Apartment.Owner = ReadCfgValue("MBWowner", saveFile) '/
            Apartment.Entrance = New Vector3(-1370.334, -503.0047, 33.15739) '/
            Apartment.Save = New Vector3(-1381.335, -464.4873, 72.04095)  '/
            Apartment.TeleportInside = New Vector3(-1386.939, -478.6686, 72.04206) '/
            Apartment.TeleportOutside = New Vector3(-1374.719, -507.18, 33.15739) '/
            Apartment.ApartmentExit = New Vector3(-1394.197, -479.7351, 72.04206)  '/
            Apartment.Wardrobe = New Vector3(-1381.067, -471.002, 72.04206) '/
            Apartment.GarageEntrance = New Vector3(-1362.143, -471.9992, 31.12832)  '/
            Apartment.GarageOutside = New Vector3(-1380.679, -475.1819, 31.12212)  '/
            Apartment.GarageOutHeading = 101.4345  '/
            Apartment.CameraPosition = New Vector3(-1321.7, -531.7924, 35.66116) '/
            Apartment.CameraRotation = New Vector3(19.04649, 1.3806443, 39.66655) '/
            Apartment.CameraFOV = 50.0
            Apartment.Interior = New Vector3(-1382.3, -477.9, 72.03836)  '/
            Apartment.WardrobeHeading = 299.8581  '/
            Apartment.ApartmentStyleCameraPosition = New Vector3(-1367.114, -480.3311, 72.04215)
            Apartment.ApartmentStyleCameraRotation = New Vector3(-5.396699, 0, 45.76079)
            Apartment.ApartmentStyleCameraFOV = 50.0
            Apartment.IsAtHome = False
            Apartment.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\maze_bank_west\" '/
            Apartment.SaveFile = "MBWowner"  '/
            Apartment.PlayerMap = "MazeBankWest"  '/
            Apartment.IPL = ReadCfgValue("MBWipl", saveFile) '/
            Apartment.LastIPL = Apartment.IPL  '/
            Apartment.Enabled = True
            Apartment.InteriorID = Apartment.GetInteriorID(Apartment.Interior)
            If Not Apartment.InteriorID = 0 Then If Not Apartment.InteriorID = 0 Then InteriorIDList.Add(Apartment.InteriorID)
            Apartment.AssistantPosition = New Vector3(-1379.698, -477.5231, 71.0375)
            Apartment.AssistantHeading = 277.4893
            Apartment.CEOPosition = New Vector3(-1372.387, -464.3324, 71.04401)
            Apartment.CEOHeading = 9.861806

            If ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then
                Translate()
                _menuPool = New MenuPool()
                CreateBuyMenu()
                CreateExitMenu()
                CreateAptStyleMenu()
                CreateGarageMenu()

                AddHandler BuyMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler BuyMenu.OnItemSelect, AddressOf BuyItemSelectHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler GarageMenu.OnItemSelect, AddressOf GarageItemSelectHandler
                AddHandler StyleMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler StyleMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler StyleMenu.OnIndexChange, AddressOf IndexChangeHandler
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
        BuyMenu.RefreshIndex()
    End Sub

    Public Shared Sub RefreshGarageMenu()
        GarageMenu.MenuItems.Clear()
        Dim Garage1 As New UIMenuItem(OfficeGarage1)
        With Garage1
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
        GarageMenu.AddItem(Garage1)
        Dim Garage2 As New UIMenuItem(OfficeGarage2)
        With Garage2
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
        GarageMenu.AddItem(Garage2)
        Dim Garage3 As New UIMenuItem(OfficeGarage3)
        With Garage3
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
        GarageMenu.AddItem(Garage3)
        Dim AutoShop As New UIMenuItem(OfficeAutoShop)
        With AutoShop
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
        GarageMenu.AddItem(AutoShop)
        GarageMenu.RefreshIndex()
    End Sub

    Public Shared Sub CreateAptStyleMenu()
        Try
            StyleMenu = New UIMenu("", AptStyle.ToUpper, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            StyleMenu.SetBannerType(Rectangle)
            _menuPool.Add(StyleMenu)
            StyleMenu.AddItem(New UIMenuItem(ExecRich))
            StyleMenu.AddItem(New UIMenuItem(ExecCool))
            StyleMenu.AddItem(New UIMenuItem(ExecContrast))
            StyleMenu.AddItem(New UIMenuItem(OldSpiClassical))
            StyleMenu.AddItem(New UIMenuItem(OldSpiVintage))
            StyleMenu.AddItem(New UIMenuItem(OldSpiWarms))
            StyleMenu.AddItem(New UIMenuItem(PowBrkConservative))
            StyleMenu.AddItem(New UIMenuItem(PowBrkPolished))
            StyleMenu.AddItem(New UIMenuItem(PowBrkIce))
            StyleMenu.RefreshIndex()
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
            ExitMenu.AddItem(New UIMenuItem(OfficeGarage1))
            ExitMenu.AddItem(New UIMenuItem(OfficeGarage2))
            ExitMenu.AddItem(New UIMenuItem(OfficeGarage3))
            ExitMenu.AddItem(New UIMenuItem(OfficeAutoShop))
            ExitMenu.AddItem(New UIMenuItem(SellApt))
            ExitMenu.AddItem(New UIMenuItem(AptStyle))
            ExitMenu.RefreshIndex()
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
            Dim Garage1 As New UIMenuItem(OfficeGarage1)
            With Garage1
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
            GarageMenu.AddItem(Garage1)
            Dim Garage2 As New UIMenuItem(OfficeGarage2)
            With Garage2
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
            GarageMenu.AddItem(Garage2)
            Dim Garage3 As New UIMenuItem(OfficeGarage3)
            With Garage3
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
            GarageMenu.AddItem(Garage3)
            Dim AutoShop As New UIMenuItem(OfficeAutoShop)
            With AutoShop
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
            GarageMenu.AddItem(AutoShop)
            GarageMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateMazeBankWest()
        Apartment.CreateOffice(Apartment)
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
                CreateMazeBankWest()
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
            ElseIf selectedItem.Text = AptStyle Then
                ExitMenu.Visible = False
                StyleMenu.Visible = True
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                World.RenderingCamera = World.CreateCamera(Apartment.ApartmentStyleCameraPosition, Apartment.ApartmentStyleCameraRotation, Apartment.ApartmentStyleCameraFOV)
                hideHud = True
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            If selectedItem.Text = OldSpiWarms Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_01a", saveFile)
                Apartment.IPL = "ex_sm_15_office_01a"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = OldSpiClassical Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_01b", saveFile)
                Apartment.IPL = "ex_sm_15_office_01b"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = OldSpiVintage Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_01c", saveFile)
                Apartment.IPL = "ex_sm_15_office_01c"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = ExecContrast Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_02a", saveFile)
                Apartment.IPL = "ex_sm_15_office_02a"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = ExecRich Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_02b", saveFile)
                Apartment.IPL = "ex_sm_15_office_02b"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = ExecCool Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_02c", saveFile)
                Apartment.IPL = "ex_sm_15_office_02c"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = PowBrkice Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_03a", saveFile)
                Apartment.IPL = "ex_sm_15_office_03a"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = PowBrkConservative Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_03b", saveFile)
                Apartment.IPL = "ex_sm_15_office_03b"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = PowBrkPolished Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("MBWipl", "ex_sm_15_office_03c", saveFile)
                Apartment.IPL = "ex_sm_15_office_03c"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub IndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If sender.MenuItems(index).Text = OldSpiWarms Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_01a", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_01a"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = OldSpiClassical Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_01b", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_01b"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = OldSpiVintage Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_01c", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_01c"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = ExecContrast Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_02a", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_02a"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = Execrich Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_02b", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_02b"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = ExecCool Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_02c", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_02c"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = PowBrkIce Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_03a", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_03a"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = PowBrkConservative Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_03b", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_03b"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = PowBrkPolished Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_03c", Apartment.Interior)
                Apartment.LastIPL = "ex_sm_15_office_03c"
                RefreshOfficeProps()
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub BuyItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = Apartment.Name & Apartment.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & Apartment.Cost.ToString("N") AndAlso Apartment.Owner = "None" Then
                'Buy Apartment
                If playerCash > Apartment.Cost Then
                    WriteCfgValue(Apartment.SaveFile, GetPlayerName(), saveFile)
                    Game.FadeScreenOut(500)
                    Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - Apartment.Cost)
                    Apartment.Owner = GetPlayerName()
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    CreateMazeBankWest()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & Apartment.Name & Apartment.Unit, Nothing)
                    If GetPlayerName() = "Michael" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    ElseIf GetPlayerName() = "Franklin" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    ElseIf GetPlayerName() = "Trevor" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    ElseIf GetPlayerName() = "Player3" Then
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End If
                    selectedItem.SetRightLabel("")
                Else
                    If GetPlayerName() = "Michael" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    ElseIf GetPlayerName() = "Franklin" Then
                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf GetPlayerName() = "Trevor" Then
                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    ElseIf GetPlayerName() = "Player3" Then
                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = Apartment.Name & Apartment.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Apartment.Owner = GetPlayerName() Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                ToggleIPL(ReadCfgValue("MBWipl", saveFile))

                Apartment.SetInteriorActive()
                Apartment.InteriorID = Apartment.GetInteriorID(Apartment.Interior)
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                Game.Player.Character.Position = Apartment.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-285.6369, -950.2663, 91.10831))
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub GarageItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If selectedItem.Text = Apartment.Name & Apartment.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle Then
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
        ElseIf selectedItem.Text = Apartment.Name & Apartment.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle Then
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
        End If
    End Sub

    Public Sub OnTick()
        Try
            If Not Game.IsLoading Then
                If My.Settings.MazeBankWest = "Enable" Then
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
                    If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.SaveDistance < 3.0 Then
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

                    'Exit Apartment
                    If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.ExitDistance < 2.0 Then
                        DisplayHelpTextThisFrame(ExitApartment & Apartment.Name & Apartment.Unit)
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            ExitMenu.Visible = True
                        End If
                    End If

                    'Wardrobe
                    If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.WardrobeDistance < 1.0 Then
                        DisplayHelpTextThisFrame(ChangeClothes)
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            WardrobeVector = Apartment.Wardrobe
                            WardrobeHead = Apartment.WardrobeHeading
                            WardrobeScriptStatus = 0
                            If GetPlayerName() = "Michael" Then
                                Player0W.Visible = True
                                MakeACamera()
                            ElseIf GetPlayerName() = "Franklin" Then
                                Player1W.Visible = True
                                MakeACamera()
                            ElseIf GetPlayerName() = “Trevor"
                                Player2W.Visible = True
                                MakeACamera()
                            ElseIf GetPlayerName() = "Player3" Then
                                If Game.Player.Character.Model.GetHashCode = 1885233650 Then
                                    Player3_MW.Visible = True
                                    MakeACamera()
                                ElseIf Game.Player.Character.Model.GetHashCode = -1667301416 Then
                                    Player3_FW.Visible = True
                                    MakeACamera()
                                End If
                            End If
                        End If
                    End If

                    'Enter Garage
                    If (Not playerPed.IsDead AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.GarageDistance < 5.0 Then
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

                    Select Case playerInterior
                        Case Apartment.InteriorID
                            Apartment.IsAtHome = True
                            HIDE_MAP_OBJECT_THIS_FRAME()
                            CreateOfficeAssistant()
                        Case Else
                            Apartment.IsAtHome = False
                    End Select

                    If Apartment.IsAtHome Then
                        HIDE_MAP_OBJECT_THIS_FRAME()
                        CreateOfficeAssistant()
                    End If

                    _menuPool.ProcessMenus()
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub HIDE_MAP_OBJECT_THIS_FRAME()
        Native.Function.Call(Hash._0x4B5CFC83122DF602)
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_dtl"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "hei_sm_15_bld2"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_LOD"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_dtl3"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld1_dtl3"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_railing"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_emissive"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_emissive_LOD"))
        Native.Function.Call(Hash._0x3669F1B198DCAA4F)
    End Sub

    Public Sub CreateOfficeAssistant()
        If Apartment.AssistantChair = Nothing Then
            Apartment.AssistantChair = World.CreateProp(1580642483, Apartment.AssistantPosition, False, False)
            Apartment.AssistantChair.Heading = Apartment.AssistantHeading
            Apartment.AssistantChair.FreezePosition = True
            Apartment.AssistantChair.IsInvincible = True
        End If
        If Apartment.OfficeAssistant = Nothing Then
            Apartment.OfficeAssistant = World.CreatePed(PedHash.ExecutivePAFemale02, Apartment.AssistantPosition)
            Apartment.OfficeAssistant.AttachTo(Apartment.AssistantChair, 0, New Vector3(0, -0.1, 0.43), New Vector3(0, 180, 0))
            Apartment.OfficeAssistant.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8.0, -1, True, -1.0)
            Apartment.OfficeAssistant.Heading = Apartment.AssistantHeading - 180
            Apartment.OfficeAssistant.FreezePosition = True
            Apartment.OfficeAssistant.IsInvincible = True
            Apartment.OfficeAssistant.RelationshipGroup = &H6F0783F5
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 0, 1, 3, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 2, 2, 0, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 3, 2, 0, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 4, 1, 2, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 6, 2, 2, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 7, 2, 0, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 8, 0, 0, 0)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 11, 1, 2, 0)
        End If
        If Apartment.CEOChair = Nothing Then
            Apartment.CEOChair = World.CreateProp(-853526657, Apartment.CEOPosition, False, False)
            Apartment.CEOChair.Heading = Apartment.CEOHeading
            Apartment.CEOChair.FreezePosition = True
            Apartment.CEOChair.IsInvincible = True
        End If
    End Sub

    Public Sub RefreshOfficeProps()
        Apartment.AssistantChair.Delete()
        Apartment.AssistantChair = World.CreateProp(1580642483, Apartment.AssistantPosition, False, False)
        Apartment.AssistantChair.Heading = Apartment.AssistantHeading
        Apartment.AssistantChair.FreezePosition = True
        Apartment.AssistantChair.IsInvincible = True

        Apartment.OfficeAssistant.Delete()
        Apartment.OfficeAssistant = World.CreatePed(PedHash.ExecutivePAFemale02, Apartment.AssistantPosition)
        Apartment.OfficeAssistant.AttachTo(Apartment.AssistantChair, 0, New Vector3(0, -0.1, 0.43), New Vector3(0, 180, 0))
        Apartment.OfficeAssistant.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8.0, -1, True, -1.0)
        Apartment.OfficeAssistant.Heading = Apartment.AssistantHeading - 180
        Apartment.OfficeAssistant.FreezePosition = True
        Apartment.OfficeAssistant.IsInvincible = True
        Apartment.OfficeAssistant.RelationshipGroup = &H6F0783F5
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 0, 1, 3, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 2, 2, 0, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 3, 2, 0, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 4, 1, 2, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 6, 2, 2, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 7, 2, 0, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 8, 0, 0, 0)
        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 11, 1, 2, 0)

        Apartment.CEOChair.Delete()
        Apartment.CEOChair = World.CreateProp(-853526657, Apartment.CEOPosition, False, False)
        Apartment.CEOChair.Heading = Apartment.CEOHeading
        Apartment.CEOChair.FreezePosition = True
        Apartment.CEOChair.IsInvincible = True
    End Sub

    Public Sub OnAborted() 'Handles MyBase.Aborted
        Try
            If Not Apartment.AptBlip Is Nothing Then Apartment.AptBlip.Remove()
            If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
            If Not Apartment.OfficeAssistant = Nothing Then Apartment.OfficeAssistant.Delete()
            If Not Apartment.AssistantChair = Nothing Then Apartment.AssistantChair.Delete()
            If Not Apartment.CEOChair = Nothing Then Apartment.CEOChair.Delete()
        Catch ex As Exception
        End Try
    End Sub
End Class
