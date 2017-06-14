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

Public Class TinselTower

    Public Shared Apartment, ApartmentHL As Apartment
    Public Shared BuyMenu, ExitMenu, ExitMenuHL, GarageMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            Apartment = New Apartment("Tinsel Tower Apt. ", "29", 492000)
            Apartment.Name = ReadCfgValue("TinselName", langFile)
            Apartment.Description = ReadCfgValue("TinselDesc", langFile)
            Apartment.Owner = ReadCfgValue("TTowner", saveFile)
            Apartment.Entrance = New Vector3(-614.7656, 37.9, 43.5895)
            Apartment.Save = New Vector3(-583.2249, 44.9624, 87.4188)
            Apartment.TeleportInside = New Vector3(-598.9042, 41.8059, 93.6261)
            Apartment.TeleportOutside = New Vector3(-617.9388, 35.7848, 43.5558)
            Apartment.ApartmentExit = New Vector3(-601.8906, 42.3395, 93.6261)
            Apartment.Wardrobe = New Vector3(-583.9974, 50.5919, 87.4296)
            Apartment.GarageEntrance = New Vector3(-634.3952, 56.0859, 43.7127)
            Apartment.GarageOutside = New Vector3(-641.8661, 57.0499, 43.4129)
            Apartment.GarageOutHeading = 84.922
            Apartment.CameraPosition = New Vector3(-678.4925, -30.95172, 48.26074)
            Apartment.CameraRotation = New Vector3(16.23258, 0, -43.18668)
            Apartment.CameraFOV = 50.0
            Apartment.Interior = New Vector3(-575.305, 42.3233, 92.2236)
            Apartment.WardrobeHeading = 79.9632
            Apartment.IsAtHome = False
            Apartment.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
            Apartment.SaveFile = "TTowner"
            Apartment.PlayerMap = "Tinsel"
            Apartment.Enabled = True
            Apartment.InteriorID = Apartment.GetInteriorID(Apartment.Interior)
            If Not Apartment.InteriorID = 0 Then InteriorIDList.Add(Apartment.InteriorID)

            ApartmentHL = New Apartment("Tinsel Tower Apt. ", "42", 984000)
            ApartmentHL.Name = ReadCfgValue("TinselHLName", langFile)
            ApartmentHL.Description = ReadCfgValue("TinselHLDesc", langFile)
            ApartmentHL.Owner = ReadCfgValue("TTHLowner", saveFile)
            ApartmentHL.Save = New Vector3(-594.5658, 50.1804, 96.9996)
            ApartmentHL.TeleportInside = New Vector3(-614.032, 58.9435, 98.2355)
            ApartmentHL.TeleportOutside = New Vector3(-617.9388, 35.7848, 43.5558)
            ApartmentHL.ApartmentExit = New Vector3(-610.6395, 58.8867, 98.2004)
            ApartmentHL.Wardrobe = New Vector3(-594.8418, 55.761, 96.9996)
            ApartmentHL.Interior = New Vector3(-613.2578, 50.58982, 97.63541)
            ApartmentHL.WardrobeHeading = 173.2113
            ApartmentHL.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
            ApartmentHL.SaveFile = "TTHLowner"
            ApartmentHL.PlayerMap = "TinselHL"
            ApartmentHL.Enabled = True
            ApartmentHL.InteriorID = Apartment.GetInteriorID(ApartmentHL.Interior)
            If Not ApartmentHL.InteriorID = 0 Then InteriorIDList.Add(ApartmentHL.InteriorID)

            If ReadCfgValue("TinselTower", settingFile) = "Enable" Then
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

                _menuPool = New MenuPool()
                CreateBuyMenu()
                CreateExitMenu()
                CreateExitMenuHL()
                CreateGarageMenu()

                AddHandler BuyMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler BuyMenu.OnItemSelect, AddressOf BuyItemSelectHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler GarageMenu.OnItemSelect, AddressOf GarageItemSelectHandler
                AddHandler ExitMenuHL.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenuHL.OnItemSelect, AddressOf HLItemSelectHandler
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
        GarageMenu.RefreshIndex()
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
            GarageMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateTinselTower()
        Apartment.Create(Apartment, ApartmentHL)
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
                CreateTinselTower()
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
                CreateTinselTower()
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

    Public Sub BuyItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
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
                    CreateTinselTower()
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
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-591.1595, 39.91172, 92.22356))
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
                    CreateTinselTower()
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
                If Website.merryChristmas Then ShowXmasTree(New Vector3(-618.6377, 58.32537, 98.19994))
                Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub GarageItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
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
        End If
    End Sub

    Public Sub OnTick()
        Try
            If My.Settings.TinselTower = "Enable" Then
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

                'Enter Garage
                If (Not playerPed.IsDead AndAlso (Apartment.Owner = playerName Or ApartmentHL.Owner = playerName)) AndAlso Apartment.GarageDistance < 5.0 Then
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

                Select Case playerInterior
                    Case Apartment.InteriorID, ApartmentHL.InteriorID
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
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "apa_ss1_02_building01"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "SS1_Emissive_SS1_02a_LOD"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ss1_02_ss1_emissive_ss1_02"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "apa_ss1_02_building01"))
        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "SS1_02_Building01_LOD"))
        Native.Function.Call(Hash._0x3669F1B198DCAA4F)
    End Sub

    Public Sub OnAborted() 'Handles MyBase.Aborted
        Try
            If Not Apartment.AptBlip Is Nothing Then Apartment.AptBlip.Remove()
            If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
        Catch ex As Exception
        End Try
    End Sub
End Class
