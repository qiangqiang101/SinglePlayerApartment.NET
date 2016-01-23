Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports PDMCarShopGUI
Imports SinglePlayerApartment.Wardrobe

Public Class Whispymound3677
    Inherits Script

    Public Shared Owner As String = ReadCfgValue("3677WMDowner", saveFile2)
    Public Shared _Name As String = "Whispymound Drive "
    Public Shared Desc As String = "The saps driving through downtown Vinewood on their morning commute need something to aspire to. They don't want to look up and see green, peaceful hills. They want to gaze through your floor-length windows and see you in nothing but snakeskin posing pouch injecting cold press kale juice with your tantric yoga instructor... Includes 10-car garage."
    Public Shared Unit As String = "3677"
    Public Shared Cost As Integer = 478000
    Public Shared _Blip As Blip
    Public Shared Blip2 As Blip
    Public Shared Entrance As Vector3 = New Vector3(119.3083, 564.0632, 183.9594)
    Public Shared Save As Vector3 = New Vector3(126.1813, 545.9031, 180.5226)
    Public Shared Teleport As Vector3 = New Vector3(117.5057, 557.3167, 184.3022)
    Public Shared Teleport2 As Vector3 = New Vector3(118.8673, 567.283, 183.1295)
    Public Shared _Exit As Vector3 = New Vector3(117.2371, 560.0856, 184.3048)
    Public Shared Wardrobe As Vector3 = New Vector3(122.0242, 548.9013, 180.4972)
    Public Shared _Garage As Vector3 = New Vector3(131.7664, 568.0024, 183.1025)
    Public Shared GarageOut As Vector3 = New Vector3(132.723, 568.142, 183.099)
    Public Shared GarageOutHeading As Single = 335.12
    Public Shared GarageDistance As String
    Public Shared DoorDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single
    Public Shared WardrobeDistance As Single
    Public Shared CameraPos As Vector3 = New Vector3(112.5791, 574.6387, 190.8119)
    Public Shared CameraRot As Vector3 = New Vector3(-21.01317, 0, -144.2139)
    Public Shared CameraFov As Single = 50.0
    Public Shared WardrobeHeading As Single = 182.3311
    Public Shared IsAtHome As Boolean = False

    Public Shared BuyMenu, ExitMenu, GarageMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            If ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then
                uiLanguage = Game.Language.ToString

                If uiLanguage = "Chinese" Then
                    _Name = "威斯皮蒙車道 "
                    Desc = "好麥塢市區的早晨時分，開車通勤的可憐上 ~n~ 班族都需要點精神慰籍。他們可不想抬頭看 ~n~ 見平靜祥和的翠綠山丘，而是想將視線投向 ~n~ 您的落地窗，看您只穿著一件蛇皮製串珠內 ~n~ 褲，為您的火辣瑜伽教練倒杯冷壓式羽衣甘 ~n~ 藍果汁。這種舉動只有富豪人家才辦得到， ~n~ 所以儘管大錢去實現吧。 ~n~ 包括可容納十輛車的車庫。"
                    Garage = "車庫"
                Else
                    _Name = "Whispymound Drive "
                    Desc = "The saps driving through downtown Vinewood on their morning commute need something to aspire to. They don't want to look up and see green, peaceful hills. They want to gaze through your floor-length windows and see you in nothing but snakeskin posing pouch injecting cold press kale juice with your tantric yoga instructor... Includes 10-car garage."
                    Garage = " Garage"
                End If

                AddHandler Tick, AddressOf OnTick
                AddHandler KeyDown, AddressOf OnKeyDown

                _menuPool = New MenuPool()
                CreateBuyMenu()
                CreateExitMenu()
                CreateGarageMenu()

                AddHandler BuyMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler BuyMenu.OnItemSelect, AddressOf BuyItemSelectHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler GarageMenu.OnItemSelect, AddressOf GarageItemSelectHandler
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateBuyMenu()
        Try
            If uiLanguage = "Chinese" Then
                AptOptions = "公寓選項"
            Else
                AptOptions = "APARTMENT OPTIONS"
            End If

            BuyMenu = New UIMenu("", AptOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            BuyMenu.SetBannerType(Rectangle)
            _menuPool.Add(BuyMenu)
            Dim item As New UIMenuItem(_Name & Unit, Desc)
            With item
                If Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightLabel("$" & Cost.ToString("N"))
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
        Dim item As New UIMenuItem(_Name & Unit, Desc)
        With item
            If Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightLabel("$" & Cost.ToString("N"))
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        BuyMenu.AddItem(item)
        BuyMenu.RefreshIndex()
    End Sub

    Public Shared Sub RefreshGarageMenu()
        GarageMenu.MenuItems.Clear()
        Dim item As New UIMenuItem(_Name & Unit & Garage)
        With item
            If Owner = "Michael" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
            ElseIf Owner = "Franklin" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
            ElseIf Owner = "Trevor" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
            ElseIf Owner = "Player3" Then
                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
            Else
                .SetRightBadge(UIMenuItem.BadgeStyle.None)
            End If
        End With
        GarageMenu.AddItem(item)
        GarageMenu.RefreshIndex()
    End Sub

    Public Shared Sub CreateExitMenu()
        Try
            If uiLanguage = "Chinese" Then
                ExitApt = "离開公寓"
                SellApt = "出售產業"
                EnterGarage = "進入車庫"
                AptOptions = "公寓選項"
            Else
                ExitApt = "Exit Apartment"
                SellApt = "Sell Property"
                EnterGarage = "Enter Garage"
                AptOptions = "APARTMENT OPTIONS"
            End If

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

    Public Shared Sub CreateGarageMenu()
        Try
            If uiLanguage = "Chinese" Then
                Garage = "車庫"
                GrgOptions = "車庫選項"
            Else
                Garage = " Garage"
                GrgOptions = "GARAGE OPTIONS"
            End If

            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            Dim item As New UIMenuItem(_Name & Unit & Garage)
            With item
                If Owner = "Michael" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                ElseIf Owner = "Franklin" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                ElseIf Owner = "Trevor" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                ElseIf Owner = "Player3" Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                Else
                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
                End If
            End With
            GarageMenu.AddItem(item)
            GarageMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateWhispymound3677()
        _Blip = World.CreateBlip(Entrance)
        If Owner = "Michael" Then
            _Blip.Sprite = BlipSprite.Safehouse
            _Blip.Color = BlipColor.Blue
            _Blip.IsShortRange = True
            SetBlipName(_Name & Unit, _Blip)
            Blip2 = World.CreateBlip(_Garage)
            Blip2.Sprite = BlipSprite.Garage
            Blip2.Color = BlipColor.Blue
            Blip2.IsShortRange = True
            SetBlipName(_Name & Unit & Garage, Blip2)
        ElseIf Owner = "Franklin" Then
            _Blip.Sprite = BlipSprite.Safehouse
            _Blip.Color = BlipColor.Green
            _Blip.IsShortRange = True
            SetBlipName(_Name & Unit, _Blip)
            Blip2 = World.CreateBlip(_Garage)
            Blip2.Sprite = BlipSprite.Garage
            Blip2.Color = BlipColor.Green
            Blip2.IsShortRange = True
            SetBlipName(_Name & Unit & Garage, Blip2)
        ElseIf Owner = "Trevor" Then
            _Blip.Sprite = BlipSprite.Safehouse
            _Blip.Color = 17
            _Blip.IsShortRange = True
            SetBlipName(_Name & Unit, _Blip)
            Blip2 = World.CreateBlip(_Garage)
            Blip2.Sprite = BlipSprite.Garage
            Blip2.Color = 17
            Blip2.IsShortRange = True
            SetBlipName(_Name & Unit & Garage, Blip2)
        ElseIf Owner = "Player3" Then
            _Blip.Sprite = BlipSprite.Safehouse
            _Blip.Color = BlipColor.Yellow
            _Blip.IsShortRange = True
            SetBlipName(_Name, _Blip)
            Blip2 = World.CreateBlip(_Garage)
            Blip2.Sprite = BlipSprite.Garage
            Blip2.Color = BlipColor.Yellow
            Blip2.IsShortRange = True
            SetBlipName(_Name & Garage, Blip2)
        Else
            _Blip.Sprite = BlipSprite.SafehouseForSale
            _Blip.Color = BlipColor.White
            _Blip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", _Blip)
            Else
                SetBlipName("Property For Sale", _Blip)
            End If
        End If
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
                Script.Wait(&H3E8)
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
                IsAtHome = False
                RemoveIPL("apa_stilt_ch2_05c_ext1")
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("3677WMDowner", "None", saveFile2)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                _Blip.Remove()
                If Not Blip2 Is Nothing Then Blip2.Remove()
                CreateWhispymound3677()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
                UnLoadMPDLCMap()
                IsAtHome = False
                RemoveIPL("apa_stilt_ch2_05c_ext1")
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                TenCarGarage.isInGarage = True
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = _Garage
                TenCarGarage.lastLocationGarageOutVector = GarageOut
                TenCarGarage.lastLocationGarageOutHeading = GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
                ExitMenu.Visible = False
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub BuyItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = _Name & Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & Cost.ToString("N") AndAlso Owner = "None" Then
                'Buy Apartment
                If playerCash > Cost Then
                    WriteCfgValue("3677WMDowner", playerName, saveFile2)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - Cost)
                    Owner = playerName
                    _Blip.Remove()
                    If Not Blip2 Is Nothing Then Blip2.Remove()
                    CreateWhispymound3677()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~" & _Name & Unit), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~" & _Name & Unit), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
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
                        If uiLanguage = "Chinese" Then
                            DisplayNotificationThisFrame("Maze Bank", "資金不足", "您沒有足夠的資金購買該產業。", "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                        Else
                            DisplayNotificationThisFrame("Maze Bank", "Insufficient Funds", "You have insufficient funds to purchase this property.", "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                        End If
                    ElseIf playerName = "Franklin" Then
                        If uiLanguage = "Chinese" Then
                            DisplayNotificationThisFrame("Fleeca Bank", "資金不足", "您沒有足夠的資金購買該產業。", "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                        Else
                            DisplayNotificationThisFrame("Fleeca Bank", "Insufficient Funds", "You have insufficient funds to purchase this property.", "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                        End If
                    ElseIf playerName = "Trevor" Then
                        If uiLanguage = "Chinese" Then
                            DisplayNotificationThisFrame("Bank of Liberty", "資金不足", "您沒有足夠的資金購買該產業。", "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                        Else
                            DisplayNotificationThisFrame("Bank of Liberty", "Insufficient Funds", "You have insufficient funds to purchase this property.", "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                        End If
                    ElseIf playerName = "Player3" Then
                        If uiLanguage = "Chinese" Then
                            DisplayNotificationThisFrame("Maze Bank", "資金不足", "您沒有足夠的資金購買該產業。", "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                        Else
                            DisplayNotificationThisFrame("Maze Bank", "Insufficient Funds", "You have insufficient funds to purchase this property.", "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                        End If
                    End If
                End If
            ElseIf selectedItem.Text = _Name & Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Owner = playerName Then
                'Enter Apartment
                BuyMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                IsAtHome = True
                ToggleIPL("apa_stilt_ch2_05c_ext1")

                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = Teleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub GarageItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If selectedItem.Text = _Name & Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle Then
            'Teleport to Garage
            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            IsAtHome = True
            ToggleIPL("apa_stilt_ch2_05c_ext1")

            Game.FadeScreenOut(500)
            Script.Wait(&H3E8)
            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            TenCarGarage.isInGarage = True
            playerPed.Position = TenCarGarage.GarageDoorL
            TenCarGarage.LastLocationName = _Name & Unit
            TenCarGarage.lastLocationVector = _Exit
            TenCarGarage.lastLocationGarageVector = _Garage
            TenCarGarage.lastLocationGarageOutVector = GarageOut
            TenCarGarage.lastLocationGarageOutHeading = GarageOutHeading
            TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
            TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
            GarageMenu.Visible = False
            Script.Wait(500)
            Game.FadeScreenIn(500)
        ElseIf selectedItem.Text = _Name & Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9 As String
            Dim path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
            If IO.File.Exists(path & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", path & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(path & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", path & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(path & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", path & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(path & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", path & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(path & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", path & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(path & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", path & "vehicle_5.cfg") Else VehPlate5 = "0"
            If IO.File.Exists(path & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", path & "vehicle_6.cfg") Else VehPlate6 = "0"
            If IO.File.Exists(path & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", path & "vehicle_7.cfg") Else VehPlate7 = "0"
            If IO.File.Exists(path & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", path & "vehicle_8.cfg") Else VehPlate8 = "0"
            If IO.File.Exists(path & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", path & "vehicle_9.cfg") Else VehPlate9 = "0"

            If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
            IsAtHome = True
            ToggleIPL("apa_stilt_ch2_05c_ext1")

            SetInteriorActive2(222.592, -968.1, -99) '10 car garage
            TenCarGarage.isInGarage = True
            TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
            TenCarGarage.LastLocationName = _Name & Unit
            TenCarGarage.lastLocationVector = _Exit
            TenCarGarage.lastLocationGarageVector = _Garage
            TenCarGarage.lastLocationGarageOutVector = GarageOut
            TenCarGarage.lastLocationGarageOutHeading = GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_0.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_1.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_2.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_3.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_4.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_5.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_6.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh6, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_7.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh7, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_8.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh8, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TenCarGarage.UpdateGarageVehicle(path & "vehicle_9.cfg", "False")
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = TenCarGarage.GarageDoorL
                playerPed.SetIntoVehicle(TenCarGarage.veh9, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            Else
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
                TenCarGarage.SaveGarageVehicle(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\")
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then
                DoorDistance = World.GetDistance(playerPed.Position, Entrance)
                SaveDistance = World.GetDistance(playerPed.Position, Save)
                ExitDistance = World.GetDistance(playerPed.Position, _Exit)
                WardrobeDistance = World.GetDistance(playerPed.Position, Wardrobe)
                GarageDistance = World.GetDistance(playerPed.Position, _Garage)

                'Enter _3alta Tower
                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso DoorDistance < 2.0 Then
                    If uiLanguage = "Chinese" Then
                        DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 進入" & _Name & Unit & "。")
                    Else
                        DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " & _Name & Unit)
                    End If
                End If

                'Save Game
                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso SaveDistance < 1.0 AndAlso Owner = playerName Then
                    If uiLanguage = "Chinese" Then
                        DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                    Else
                        DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                    End If
                End If

                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso ExitDistance < 2.0 AndAlso Owner = playerName Then
                    If uiLanguage = "Chinese" Then
                        DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 離開" & _Name & Unit & "。")
                    Else
                        DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to exit " & _Name & Unit & ".")
                    End If
                End If

                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso WardrobeDistance < 1.0 AndAlso Owner = playerName Then
                    If uiLanguage = "Chinese" Then
                        DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 更換服裝。")
                    Else
                        DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to change clothes.")
                    End If
                End If

                If Not playerPed.IsDead AndAlso GarageDistance < 3.0 AndAlso Owner = playerName Then
                    If uiLanguage = "Chinese" Then
                        DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 進入" & Garage & "。")
                    Else
                        DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " & Garage & ".")
                    End If
                End If

                ' Controls
                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso DoorDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead Then
                    'Press E on Vespucci Blvd Door
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    BuyMenu.Visible = True
                    World.RenderingCamera = World.CreateCamera(CameraPos, CameraRot, CameraFov)
                    hideHud = True
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                End If

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso ExitDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead Then
                    ExitMenu.Visible = True
                End If

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso SaveDistance < 1.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                    'Press E on vespucci blvd Bed
                    playerMap = "Whispy3677"
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    TimeLapse(8)
                    Game.ShowSaveMenu()
                    SavePosition()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                End If

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso WardrobeDistance < 1.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                    WardrobeVector = Wardrobe
                    WardrobeHead = WardrobeHeading
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

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso GarageDistance < 3.0 AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                    GarageMenu.Visible = True
                End If
                'End Control

                If IsAtHome = True Then
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
        Native.Function.Call(Hash._0xA97F257D0151A6AB, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "apa_ch2_05c_b4"))
        Native.Function.Call(Hash._0xA97F257D0151A6AB, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ch2_05c_emissive_07"))
        Native.Function.Call(Hash._0xA97F257D0151A6AB, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ch2_05c_decals_05"))
        Native.Function.Call(Hash._0xA97F257D0151A6AB, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "ch2_05c_B4_LOD"))
        Native.Function.Call(Hash._0x3669F1B198DCAA4F)
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try
                If Not _Blip Is Nothing Then _Blip.Remove()
                If Not Blip2 Is Nothing Then Blip2.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
