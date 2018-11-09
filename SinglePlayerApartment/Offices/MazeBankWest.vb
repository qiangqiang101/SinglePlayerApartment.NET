'Imports System.Drawing
'Imports GTA
'Imports GTA.Native
'Imports GTA.Math
'Imports System.Windows.Forms
'Imports SinglePlayerApartment.SinglePlayerApartment
'Imports INMNativeUI
'Imports SinglePlayerApartment.Wardrobe
'Imports SinglePlayerApartment.INMNative

'Public Class MazeBankWest

'    Public Shared Apartment As Apartment
'    Public Shared BuyMenu, ExitMenu, GarageMenu, StyleMenu As UIMenu
'    Public Shared _menuPool As MenuPool

'    Public Sub New()
'        Try
'            Apartment = New Apartment("Maze Bank West", "", 7300000) '/
'            Apartment.Name = ReadCfgValue("MazeBankWestName", langFile) '/
'            Apartment.Description = ReadCfgValue("MazeBankWestDesc", langFile) '/
'            Apartment.Owner = ReadCfgValue("MBWowner", saveFile) '/
'            Apartment.Entrance = New Vector3(-1370.334, -503.0047, 33.15739) '/
'            Apartment.Save = New Vector3(-1381.335, -464.4873, 72.04095)  '/
'            Apartment.TeleportInside = New Vector3(-1386.939, -478.6686, 71.04206) '/
'            Apartment.TeleportOutside = New Vector3(-1374.719, -507.18, 33.15739) '/
'            Apartment.TeleportHelipad = New Vector3(-1368.406, -471.0786, 83.44697)
'            Apartment.ApartmentExit = New Vector3(-1394.197, -479.7351, 72.04206)  '/
'            Apartment.Wardrobe = New Vector3(-1381.067, -471.002, 72.04206) '/
'            Apartment.GarageEntrance = New Vector3(-1362.143, -471.9992, 31.12832)  '/
'            Apartment.GarageOutside = New Vector3(-1380.679, -475.1819, 31.12212)  '/
'            Apartment.GarageOutHeading = 101.4345  '/
'            Apartment.CameraPosition = New Vector3(-1321.7, -531.7924, 35.66116) '/
'            Apartment.CameraRotation = New Vector3(19.04649, 1.3806443, 39.66655) '/
'            Apartment.CameraFOV = 50.0
'            Apartment.Interior = New Vector3(-1382.3, -477.9, 72.03836)  '/
'            Apartment.WardrobeHeading = 299.8581  '/
'            Apartment.ApartmentStyleCameraPosition = New Vector3(-1367.114, -480.3311, 72.04215)
'            Apartment.ApartmentStyleCameraRotation = New Vector3(-5.396699, 0, 45.76079)
'            Apartment.ApartmentStyleCameraFOV = 50.0
'            Apartment.IsAtHome = False
'            Apartment.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\maze_bank_west\" '/
'            Apartment.SaveFile = "MBWowner"  '/
'            Apartment.PlayerMap = "MazeBankWest"  '/
'            Apartment.IPL = ReadCfgValue("MBWipl", saveFile) '/
'            Apartment.LastIPL = Apartment.IPL  '/
'            Apartment.Enabled = True
'            ToggleIPL(ReadCfgValue("MBWipl", saveFile))
'            Apartment.InteriorID = Apartment.GetInteriorID(Apartment.Interior)
'            If Not Apartment.InteriorID = 0 Then If Not Apartment.InteriorID = 0 Then InteriorIDList.Add(Apartment.InteriorID)
'            RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'            Apartment.AssistantPosition = New Vector3(-1379.698, -477.5231, 71.0375)
'            Apartment.AssistantHeading = 277.4893
'            Apartment.GarageElevator = New Vector3(-1395.882, -480.5163, 56.10049) '/
'            Apartment.GarageMenuActivator = New Vector3(-1395.049, -476.1217, 56.10049)  '/
'            Apartment.GarageVeh0Pos = New Vector3(-1370.5, -482.9, 56.4) '//
'            Apartment.GarageVeh1Pos = New Vector3(-1370.4, -477.6, 56.4) '//
'            Apartment.GarageVeh2Pos = New Vector3(-1373.5, -473.0, 56.4) '//
'            Apartment.GarageVeh3Pos = New Vector3(-1378.3, -471.3, 56.4) '//
'            Apartment.GarageVeh4Pos = New Vector3(-1383.2, -471.8, 56.4) '//
'            Apartment.GarageVeh5Pos = New Vector3(-1387.8, -473.2, 56.4) '//
'            Apartment.GarageVeh6Pos = New Vector3(-1370.5, -482.9, 61.8) '//
'            Apartment.GarageVeh7Pos = New Vector3(-1370.4, -477.6, 61.8) '//
'            Apartment.GarageVeh8Pos = New Vector3(-1373.5, -473.0, 61.8) '//
'            Apartment.GarageVeh9Pos = New Vector3(-1378.3, -471.3, 61.8) '//
'            Apartment.GarageVeh10Pos = New Vector3(-1383.2, -471.8, 61.8) '//
'            Apartment.GarageVeh11Pos = New Vector3(-1387.8, -473.2, 61.8) '//
'            Apartment.GarageVeh12Pos = New Vector3(-1391.9, -475.1, 61.8) '//
'            Apartment.GarageVeh13Pos = New Vector3(-1370.5, -482.9, 67.1) '//
'            Apartment.GarageVeh14Pos = New Vector3(-1370.4, -477.6, 67.1) '//
'            Apartment.GarageVeh15Pos = New Vector3(-1373.5, -473.0, 67.1) '//
'            Apartment.GarageVeh16Pos = New Vector3(-1378.3, -471.3, 67.1) '//
'            Apartment.GarageVeh17Pos = New Vector3(-1383.2, -471.8, 67.1) '//
'            Apartment.GarageVeh18Pos = New Vector3(-1387.8, -473.2, 67.1) '//
'            Apartment.GarageVeh19Pos = New Vector3(-1391.9, -475.1, 67.1) '//
'            Apartment.GarageVeh0613Rot = New Vector3(0, 0, 76.5) '//
'            Apartment.GarageVeh1714Rot = New Vector3(0, 0, 106.0) '//
'            Apartment.GarageVeh2815Rot = New Vector3(0, 0, 143.1) '//
'            Apartment.GarageVeh3916Rot = New Vector3(0, 0, 175.0) '//
'            Apartment.GarageVeh41017Rot = New Vector3(0, 0, 199.5) '//
'            Apartment.GarageVeh51118Rot = New Vector3(0, 0, 202.5) '//
'            Apartment.GarageVeh1219Rot = New Vector3(0, 0, 204.8) '//
'            Apartment.GarageIPL = "imp_sm_15_cargarage_a"
'            Apartment.GarageIPL2 = "imp_sm_15_cargarage_b"
'            Apartment.GarageIPL3 = "imp_sm_15_cargarage_c"
'            Apartment.GarageWall1 = ReadCfgValue("MBWG1Wall", saveFile)
'            Apartment.GarageWall2 = ReadCfgValue("MBWG2Wall", saveFile)
'            Apartment.GarageWall3 = ReadCfgValue("MBWG3Wall", saveFile)
'            Apartment.GarageLight1 = ReadCfgValue("MBWG1Light", saveFile)
'            Apartment.GarageLight2 = ReadCfgValue("MBWG2Light", saveFile)
'            Apartment.GarageLight3 = ReadCfgValue("MBWG3Light", saveFile)
'            Apartment.GarageNumber1 = ReadCfgValue("MBWG1Number", saveFile)
'            Apartment.GarageNumber2 = ReadCfgValue("MBWG2Number", saveFile)
'            Apartment.GarageNumber3 = ReadCfgValue("MBWG3Number", saveFile)
'            Apartment.GarageWallText1 = "MBWG1Wall"
'            Apartment.GarageWallText2 = "MBWG2Wall"
'            Apartment.GarageWallText3 = "MBWG3Wall"
'            Apartment.GarageLightText1 = "MBWG1Light"
'            Apartment.GarageLightText2 = "MBWG2Light"
'            Apartment.GarageLightText3 = "MBWG3Light"
'            Apartment.GarageNumberText1 = "MBWG1Number"
'            Apartment.GarageNumberText2 = "MBWG2Number"
'            Apartment.GarageNumberText3 = "MBWG3Number"

'            Apartment.CamPos1F = New Vector3(-1396.66, -481.3375, 59.11948)
'            Apartment.CamPos2F = New Vector3(-1396.66, -481.3375, 64.51948)
'            Apartment.CamPos3F = New Vector3(-1396.66, -481.3375, 69.91948)
'            Apartment.CamRot1F = New Vector3(-18.82641, 0, -73.41509)
'            Apartment.CamRot2F = New Vector3(-18.82641, 0, -73.41509)
'            Apartment.CamRot3F = New Vector3(-18.82641, 0, -73.41509)

'            If ReadCfgValue("MazeBankWest", settingFile) = "Enable" Then
'                Translate()
'                _menuPool = New MenuPool()
'                CreateBuyMenu()
'                CreateExitMenu()
'                CreateAptStyleMenu()
'                CreateGarageMenu()

'                AddHandler BuyMenu.OnMenuClose, AddressOf MenuCloseHandler
'                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
'                AddHandler BuyMenu.OnItemSelect, AddressOf BuyItemSelectHandler
'                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
'                AddHandler GarageMenu.OnItemSelect, AddressOf GarageItemSelectHandler
'                AddHandler StyleMenu.OnMenuClose, AddressOf MenuCloseHandler
'                AddHandler StyleMenu.OnItemSelect, AddressOf ItemSelectHandler
'                AddHandler StyleMenu.OnIndexChange, AddressOf IndexChangeHandler
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateBuyMenu()
'        Try
'            BuyMenu = New UIMenu("", OfficeOptions, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            BuyMenu.SetBannerType(Rectangle)
'            _menuPool.Add(BuyMenu)
'            Dim item As New UIMenuItem(Apartment.Name & Apartment.Unit, Apartment.Description)
'            With item
'                If Apartment.Owner = "Michael" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'                ElseIf Apartment.Owner = "Franklin" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'                ElseIf Apartment.Owner = "Trevor" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'                ElseIf Apartment.Owner = "Player3" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'                Else
'                    .SetRightLabel("$" & Apartment.Cost.ToString("N"))
'                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
'                End If
'            End With
'            BuyMenu.AddItem(item)
'            BuyMenu.RefreshIndex()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub RefreshMenu()
'        BuyMenu.MenuItems.Clear()
'        Dim item As New UIMenuItem(Apartment.Name & Apartment.Unit, Apartment.Description)
'        With item
'            If Apartment.Owner = "Michael" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'            ElseIf Apartment.Owner = "Franklin" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'            ElseIf Apartment.Owner = "Trevor" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'            ElseIf Apartment.Owner = "Player3" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'            Else
'                .SetRightLabel("$" & Apartment.Cost.ToString("N"))
'                .SetRightBadge(UIMenuItem.BadgeStyle.None)
'            End If
'        End With
'        BuyMenu.AddItem(item)
'        BuyMenu.RefreshIndex()
'    End Sub

'    Public Shared Sub RefreshGarageMenu()
'        GarageMenu.MenuItems.Clear()
'        Dim Garage1 As New UIMenuItem(OfficeGarage1)
'        With Garage1
'            If Apartment.Owner = "Michael" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'            ElseIf Apartment.Owner = "Franklin" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'            ElseIf Apartment.Owner = "Trevor" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'            ElseIf Apartment.Owner = "Player3" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'            Else
'                .SetRightBadge(UIMenuItem.BadgeStyle.None)
'            End If
'        End With
'        GarageMenu.AddItem(Garage1)
'        Dim Garage2 As New UIMenuItem(OfficeGarage2)
'        With Garage2
'            If Apartment.Owner = "Michael" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'            ElseIf Apartment.Owner = "Franklin" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'            ElseIf Apartment.Owner = "Trevor" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'            ElseIf Apartment.Owner = "Player3" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'            Else
'                .SetRightBadge(UIMenuItem.BadgeStyle.None)
'            End If
'        End With
'        GarageMenu.AddItem(Garage2)
'        Dim Garage3 As New UIMenuItem(OfficeGarage3)
'        With Garage3
'            If Apartment.Owner = "Michael" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'            ElseIf Apartment.Owner = "Franklin" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'            ElseIf Apartment.Owner = "Trevor" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'            ElseIf Apartment.Owner = "Player3" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'            Else
'                .SetRightBadge(UIMenuItem.BadgeStyle.None)
'            End If
'        End With
'        GarageMenu.AddItem(Garage3)
'        Dim AutoShop As New UIMenuItem(OfficeAutoShop)
'        With AutoShop
'            If Apartment.Owner = "Michael" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'            ElseIf Apartment.Owner = "Franklin" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'            ElseIf Apartment.Owner = "Trevor" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'            ElseIf Apartment.Owner = "Player3" Then
'                .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'            Else
'                .SetRightBadge(UIMenuItem.BadgeStyle.None)
'            End If
'        End With
'        GarageMenu.AddItem(AutoShop)
'        GarageMenu.RefreshIndex()
'    End Sub

'    Public Shared Sub CreateAptStyleMenu()
'        Try
'            StyleMenu = New UIMenu("", OfficeStyle.ToUpper, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            StyleMenu.SetBannerType(Rectangle)
'            _menuPool.Add(StyleMenu)
'            StyleMenu.AddItem(New UIMenuItem(ExecRich))
'            StyleMenu.AddItem(New UIMenuItem(ExecCool))
'            StyleMenu.AddItem(New UIMenuItem(ExecContrast))
'            StyleMenu.AddItem(New UIMenuItem(OldSpiClassical))
'            StyleMenu.AddItem(New UIMenuItem(OldSpiVintage))
'            StyleMenu.AddItem(New UIMenuItem(OldSpiWarms))
'            StyleMenu.AddItem(New UIMenuItem(PowBrkConservative))
'            StyleMenu.AddItem(New UIMenuItem(PowBrkPolished))
'            StyleMenu.AddItem(New UIMenuItem(PowBrkIce))
'            StyleMenu.RefreshIndex()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateExitMenu()
'        Try
'            ExitMenu = New UIMenu("", OfficeOptions, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            ExitMenu.SetBannerType(Rectangle)
'            _menuPool.Add(ExitMenu)
'            ExitMenu.AddItem(New UIMenuItem(ExitOfficeGround))
'            ExitMenu.AddItem(New UIMenuItem(ExitOfficeRoof))
'            ExitMenu.AddItem(New UIMenuItem(OfficeGarage1))
'            ExitMenu.AddItem(New UIMenuItem(OfficeGarage2))
'            ExitMenu.AddItem(New UIMenuItem(OfficeGarage3))
'            ExitMenu.AddItem(New UIMenuItem(OfficeAutoShop))
'            ExitMenu.AddItem(New UIMenuItem(SellApt))
'            ExitMenu.AddItem(New UIMenuItem(OfficeStyle))
'            ExitMenu.RefreshIndex()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateGarageMenu()
'        Try
'            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            GarageMenu.SetBannerType(Rectangle)
'            _menuPool.Add(GarageMenu)
'            Dim Garage1 As New UIMenuItem(OfficeGarage1)
'            With Garage1
'                If Apartment.Owner = "Michael" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'                ElseIf Apartment.Owner = "Franklin" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'                ElseIf Apartment.Owner = "Trevor" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'                ElseIf Apartment.Owner = "Player3" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'                Else
'                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
'                End If
'            End With
'            GarageMenu.AddItem(Garage1)
'            Dim Garage2 As New UIMenuItem(OfficeGarage2)
'            With Garage2
'                If Apartment.Owner = "Michael" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'                ElseIf Apartment.Owner = "Franklin" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'                ElseIf Apartment.Owner = "Trevor" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'                ElseIf Apartment.Owner = "Player3" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'                Else
'                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
'                End If
'            End With
'            GarageMenu.AddItem(Garage2)
'            Dim Garage3 As New UIMenuItem(OfficeGarage3)
'            With Garage3
'                If Apartment.Owner = "Michael" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'                ElseIf Apartment.Owner = "Franklin" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'                ElseIf Apartment.Owner = "Trevor" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'                ElseIf Apartment.Owner = "Player3" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'                Else
'                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
'                End If
'            End With
'            GarageMenu.AddItem(Garage3)
'            Dim AutoShop As New UIMenuItem(OfficeAutoShop)
'            With AutoShop
'                If Apartment.Owner = "Michael" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'                ElseIf Apartment.Owner = "Franklin" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'                ElseIf Apartment.Owner = "Trevor" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'                ElseIf Apartment.Owner = "Player3" Then
'                    .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'                Else
'                    .SetRightBadge(UIMenuItem.BadgeStyle.None)
'                End If
'            End With
'            GarageMenu.AddItem(AutoShop)
'            GarageMenu.RefreshIndex()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateMazeBankWest()
'        Apartment.CreateOffice(Apartment)
'    End Sub

'    Public Sub MenuCloseHandler(sender As UIMenu)
'        Try
'            hideHud = False
'            World.DestroyAllCameras()
'            World.RenderingCamera = Nothing
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
'        Try
'            If selectedItem.Text = ExitOfficeGround Then
'                'Exit Apt
'                ExitMenu.Visible = False
'                Game.FadeScreenOut(500)
'                Wait(500)
'                Brain.TVOn = False
'                Game.Player.Character.Position = Apartment.TeleportOutside
'                RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf selectedItem.Text = ExitOfficeRoof Then
'                ExitMenu.Visible = False
'                Game.FadeScreenOut(500)
'                Wait(500)
'                Brain.TVOn = False
'                Game.Player.Character.Position = Apartment.TeleportHelipad
'                RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf selectedItem.Text = SellApt Then
'                'Sell Apt
'                ExitMenu.Visible = False
'                WriteCfgValue(Apartment.SaveFile, "None", saveFile)
'                SavePosition2()
'                Game.FadeScreenOut(500)
'                Wait(500)
'                SinglePlayerApartment.player.Money = (playerCash + Apartment.Cost)
'                Apartment.Owner = "None"
'                Apartment.AptBlip.Remove()
'                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
'                CreateMazeBankWest()
'                Brain.TVOn = False
'                Game.Player.Character.Position = Apartment.TeleportOutside
'                RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'                Wait(500)
'                Game.FadeScreenIn(500)
'                RefreshMenu()
'                RefreshGarageMenu()
'            ElseIf selectedItem.Text = OfficeStyle Then
'                ExitMenu.Visible = False
'                StyleMenu.Visible = True
'                Game.FadeScreenOut(500)
'                Wait(500)
'                World.RenderingCamera = World.CreateCamera(Apartment.ApartmentStyleCameraPosition, Apartment.ApartmentStyleCameraRotation, Apartment.ApartmentStyleCameraFOV)
'                hideHud = True
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf selectedItem.Text = OfficeGarage1
'                'Teleport to Garage
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'                ToggleIPL(Apartment.GarageIPL)
'                TwentyCarGarage.Apartment = Apartment
'                TwentyCarGarage.LastIPL = Apartment.GarageIPL
'                TwentyCarGarage.WallText = Apartment.GarageWallText1
'                TwentyCarGarage.LightText = Apartment.GarageLightText1
'                TwentyCarGarage.NumberText = Apartment.GarageNumberText1
'                TwentyCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
'                TwentyCarGarage.lastLocationVector = Apartment.ApartmentExit
'                TwentyCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
'                TwentyCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
'                TwentyCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                TwentyCarGarage.CurrentPath = Apartment.GaragePath
'                TwentyCarGarage.Elevator = Apartment.GarageElevator
'                ToggleOfficeGarageDecor(Apartment.GarageWall1, Apartment.GarageLight1, Apartment.GarageNumber1, INMNative.Apartment.GetInteriorID(TwentyCarGarage.Elevator))
'                TwentyCarGarage.MenuActivator = Apartment.GarageMenuActivator
'                TwentyCarGarage.ElevatorDistance = Apartment.GarageElevatorDistance
'                TwentyCarGarage.GarageMarkerDistance = Apartment.GarageMenuActivatorDistance
'                TwentyCarGarage.veh0Pos = Apartment.GarageVeh0Pos
'                TwentyCarGarage.veh1Pos = Apartment.GarageVeh1Pos
'                TwentyCarGarage.veh2Pos = Apartment.GarageVeh2Pos
'                TwentyCarGarage.veh3Pos = Apartment.GarageVeh3Pos
'                TwentyCarGarage.veh4Pos = Apartment.GarageVeh4Pos
'                TwentyCarGarage.veh5Pos = Apartment.GarageVeh5Pos
'                TwentyCarGarage.veh6Pos = Apartment.GarageVeh6Pos
'                TwentyCarGarage.veh7Pos = Apartment.GarageVeh7Pos
'                TwentyCarGarage.veh8Pos = Apartment.GarageVeh8Pos
'                TwentyCarGarage.veh9Pos = Apartment.GarageVeh9Pos
'                TwentyCarGarage.veh10Pos = Apartment.GarageVeh10Pos
'                TwentyCarGarage.veh11Pos = Apartment.GarageVeh11Pos
'                TwentyCarGarage.veh12Pos = Apartment.GarageVeh12Pos
'                TwentyCarGarage.veh13Pos = Apartment.GarageVeh13Pos
'                TwentyCarGarage.veh14Pos = Apartment.GarageVeh14Pos
'                TwentyCarGarage.veh15Pos = Apartment.GarageVeh15Pos
'                TwentyCarGarage.veh16Pos = Apartment.GarageVeh16Pos
'                TwentyCarGarage.veh17Pos = Apartment.GarageVeh17Pos
'                TwentyCarGarage.veh18Pos = Apartment.GarageVeh18Pos
'                TwentyCarGarage.veh19Pos = Apartment.GarageVeh19Pos
'                TwentyCarGarage.vehRot0613 = Apartment.GarageVeh0613Rot
'                TwentyCarGarage.vehRot1714 = Apartment.GarageVeh1714Rot
'                TwentyCarGarage.vehRot2815 = Apartment.GarageVeh2815Rot
'                TwentyCarGarage.vehRot3916 = Apartment.GarageVeh3916Rot
'                TwentyCarGarage.vehRot41017 = Apartment.GarageVeh41017Rot
'                TwentyCarGarage.vehRot51118 = Apartment.GarageVeh51118Rot
'                TwentyCarGarage.vehRot1219 = Apartment.GarageVeh1219Rot
'                TwentyCarGarage.Floor1CamPos = Apartment.CamPos1F
'                TwentyCarGarage.Floor2CamPos = Apartment.CamPos2F
'                TwentyCarGarage.Floor3CamPos = Apartment.CamPos3F
'                TwentyCarGarage.Floor1CamRot = Apartment.CamRot1F
'                TwentyCarGarage.Floor2CamRot = Apartment.CamRot2F
'                TwentyCarGarage.Floor3CamRot = Apartment.CamRot3F
'                playerPed.Position = TwentyCarGarage.Elevator
'                ExitMenu.Visible = False
'                Wait(500)
'                Game.FadeScreenIn(500)
'            End If

'            If selectedItem.Text = OldSpiWarms Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_01a", saveFile)
'                Apartment.IPL = "ex_sm_15_office_01a"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = OldSpiClassical Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_01b", saveFile)
'                Apartment.IPL = "ex_sm_15_office_01b"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = OldSpiVintage Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_01c", saveFile)
'                Apartment.IPL = "ex_sm_15_office_01c"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = ExecContrast Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_02a", saveFile)
'                Apartment.IPL = "ex_sm_15_office_02a"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = ExecRich Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_02b", saveFile)
'                Apartment.IPL = "ex_sm_15_office_02b"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = ExecCool Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_02c", saveFile)
'                Apartment.IPL = "ex_sm_15_office_02c"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = PowBrkIce Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_03a", saveFile)
'                Apartment.IPL = "ex_sm_15_office_03a"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = PowBrkConservative Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_03b", saveFile)
'                Apartment.IPL = "ex_sm_15_office_03b"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            ElseIf selectedItem.Text = PowBrkPolished Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue("MBWipl", "ex_sm_15_office_03c", saveFile)
'                Apartment.IPL = "ex_sm_15_office_03c"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'                StyleMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub IndexChangeHandler(sender As UIMenu, index As Integer)
'        Try
'            If sender.MenuItems(index).Text = OldSpiWarms Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_01a", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_01a"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = OldSpiClassical Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_01b", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_01b"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = OldSpiVintage Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_01c", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_01c"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = ExecContrast Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_02a", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_02a"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = ExecRich Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_02b", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_02b"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = ExecCool Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_02c", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_02c"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = PowBrkIce Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_03a", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_03a"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = PowBrkConservative Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_03b", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_03b"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf sender.MenuItems(index).Text = PowBrkPolished Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                ChangeIPL(Apartment.LastIPL, "ex_sm_15_office_03c", Apartment.Interior)
'                Apartment.LastIPL = "ex_sm_15_office_03c"
'                RefreshOfficeProps()
'                Wait(500)
'                Game.FadeScreenIn(500)
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub BuyItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
'        Try
'            If selectedItem.Text = Apartment.Name & Apartment.Unit AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso selectedItem.RightLabel = "$" & Apartment.Cost.ToString("N") AndAlso Apartment.Owner = "None" Then
'                'Buy Apartment
'                If playerCash > Apartment.Cost Then
'                    WriteCfgValue(Apartment.SaveFile, GetPlayerName(), saveFile)
'                    Game.FadeScreenOut(500)
'                    Wait(500)
'                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - Apartment.Cost)
'                    Apartment.Owner = GetPlayerName()
'                    Apartment.AptBlip.Remove()
'                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
'                    CreateMazeBankWest()
'                    RefreshGarageMenu()
'                    Mechanic.CreateMechanicMenu()
'                    Wait(500)
'                    Game.FadeScreenIn(500)
'                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
'                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & PropPurchased, "~w~" & Apartment.Name & Apartment.Unit, Nothing)
'                    If GetPlayerName() = "Michael" Then
'                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
'                    ElseIf GetPlayerName() = "Franklin" Then
'                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
'                    ElseIf GetPlayerName() = "Trevor" Then
'                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
'                    ElseIf GetPlayerName() = "Player3" Then
'                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
'                    End If
'                    selectedItem.SetRightLabel("")
'                Else
'                    If GetPlayerName() = "Michael" Then
'                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
'                    ElseIf GetPlayerName() = "Franklin" Then
'                        DisplayNotificationThisFrame(Fleeca, "", InsFundApartment, "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
'                    ElseIf GetPlayerName() = "Trevor" Then
'                        DisplayNotificationThisFrame(BOL, "", InsFundApartment, "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
'                    ElseIf GetPlayerName() = "Player3" Then
'                        DisplayNotificationThisFrame(Maze, "", InsFundApartment, "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
'                    End If
'                End If
'            ElseIf selectedItem.Text = Apartment.Name & Apartment.Unit AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Apartment.Owner = GetPlayerName() Then
'                'Enter Apartment
'                BuyMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'                If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
'                ToggleIPL(ReadCfgValue("MBWipl", saveFile))
'                EnableOfficeProp()

'                Apartment.SetInteriorActive()
'                Apartment.InteriorID = Apartment.GetInteriorID(Apartment.Interior)
'                Game.FadeScreenOut(500)
'                Wait(500)
'                Game.Player.Character.Position = Apartment.TeleportInside
'                If Website.merryChristmas Then ShowXmasTree(New Vector3(-285.6369, -950.2663, 91.10831))
'                Wait(500)
'                Game.FadeScreenIn(500)
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub GarageItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
'        If selectedItem.Text = OfficeGarage1 AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso Not playerPed.IsInVehicle Then
'            'Teleport to Garage
'            Game.FadeScreenOut(500)
'            Wait(500)
'            RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'            ToggleIPL(Apartment.GarageIPL)
'            TwentyCarGarage.Apartment = Apartment
'            TwentyCarGarage.LastIPL = Apartment.GarageIPL
'            TwentyCarGarage.WallText = Apartment.GarageWallText1
'            TwentyCarGarage.LightText = Apartment.GarageLightText1
'            TwentyCarGarage.NumberText = Apartment.GarageNumberText1
'            TwentyCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
'            TwentyCarGarage.lastLocationVector = Apartment.ApartmentExit
'            TwentyCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
'            TwentyCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
'            TwentyCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
'            TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'            TwentyCarGarage.CurrentPath = Apartment.GaragePath
'            TwentyCarGarage.Elevator = Apartment.GarageElevator
'            ToggleOfficeGarageDecor(Apartment.GarageWall1, Apartment.GarageLight1, Apartment.GarageNumber1, INMNative.Apartment.GetInteriorID(TwentyCarGarage.Elevator))
'            TwentyCarGarage.MenuActivator = Apartment.GarageMenuActivator
'            TwentyCarGarage.ElevatorDistance = Apartment.GarageElevatorDistance
'            TwentyCarGarage.GarageMarkerDistance = Apartment.GarageMenuActivatorDistance
'            TwentyCarGarage.veh0Pos = Apartment.GarageVeh0Pos
'            TwentyCarGarage.veh1Pos = Apartment.GarageVeh1Pos
'            TwentyCarGarage.veh2Pos = Apartment.GarageVeh2Pos
'            TwentyCarGarage.veh3Pos = Apartment.GarageVeh3Pos
'            TwentyCarGarage.veh4Pos = Apartment.GarageVeh4Pos
'            TwentyCarGarage.veh5Pos = Apartment.GarageVeh5Pos
'            TwentyCarGarage.veh6Pos = Apartment.GarageVeh6Pos
'            TwentyCarGarage.veh7Pos = Apartment.GarageVeh7Pos
'            TwentyCarGarage.veh8Pos = Apartment.GarageVeh8Pos
'            TwentyCarGarage.veh9Pos = Apartment.GarageVeh9Pos
'            TwentyCarGarage.veh10Pos = Apartment.GarageVeh10Pos
'            TwentyCarGarage.veh11Pos = Apartment.GarageVeh11Pos
'            TwentyCarGarage.veh12Pos = Apartment.GarageVeh12Pos
'            TwentyCarGarage.veh13Pos = Apartment.GarageVeh13Pos
'            TwentyCarGarage.veh14Pos = Apartment.GarageVeh14Pos
'            TwentyCarGarage.veh15Pos = Apartment.GarageVeh15Pos
'            TwentyCarGarage.veh16Pos = Apartment.GarageVeh16Pos
'            TwentyCarGarage.veh17Pos = Apartment.GarageVeh17Pos
'            TwentyCarGarage.veh18Pos = Apartment.GarageVeh18Pos
'            TwentyCarGarage.veh19Pos = Apartment.GarageVeh19Pos
'            TwentyCarGarage.vehRot0613 = Apartment.GarageVeh0613Rot
'            TwentyCarGarage.vehRot1714 = Apartment.GarageVeh1714Rot
'            TwentyCarGarage.vehRot2815 = Apartment.GarageVeh2815Rot
'            TwentyCarGarage.vehRot3916 = Apartment.GarageVeh3916Rot
'            TwentyCarGarage.vehRot41017 = Apartment.GarageVeh41017Rot
'            TwentyCarGarage.vehRot51118 = Apartment.GarageVeh51118Rot
'            TwentyCarGarage.vehRot1219 = Apartment.GarageVeh1219Rot
'            TwentyCarGarage.Floor1CamPos = Apartment.CamPos1F
'            TwentyCarGarage.Floor2CamPos = Apartment.CamPos2F
'            TwentyCarGarage.Floor3CamPos = Apartment.CamPos3F
'            TwentyCarGarage.Floor1CamRot = Apartment.CamRot1F
'            TwentyCarGarage.Floor2CamRot = Apartment.CamRot2F
'            TwentyCarGarage.Floor3CamRot = Apartment.CamRot3F
'            playerPed.Position = TwentyCarGarage.Elevator
'            GarageMenu.Visible = False
'            Wait(500)
'            Game.FadeScreenIn(500)
'        ElseIf selectedItem.Text = OfficeGarage1 AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle Then
'            On Error Resume Next
'            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5, VehPlate6, VehPlate7, VehPlate8, VehPlate9, VehPlate10, VehPlate11, VehPlate12, VehPlate13, VehPlate14, VehPlate15, VehPlate16, VehPlate17, VehPlate18, VehPlate19 As String
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_6.cfg") Then VehPlate6 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_6.cfg") Else VehPlate6 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_7.cfg") Then VehPlate7 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_7.cfg") Else VehPlate7 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_8.cfg") Then VehPlate8 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_8.cfg") Else VehPlate8 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_9.cfg") Then VehPlate9 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_9.cfg") Else VehPlate9 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_10.cfg") Then VehPlate10 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_10.cfg") Else VehPlate10 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_11.cfg") Then VehPlate11 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_11.cfg") Else VehPlate11 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_12.cfg") Then VehPlate12 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_12.cfg") Else VehPlate12 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_13.cfg") Then VehPlate13 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_13.cfg") Else VehPlate13 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_14.cfg") Then VehPlate14 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_14.cfg") Else VehPlate14 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_15.cfg") Then VehPlate15 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_15.cfg") Else VehPlate15 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_16.cfg") Then VehPlate16 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_16.cfg") Else VehPlate16 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_17.cfg") Then VehPlate17 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_17.cfg") Else VehPlate17 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_18.cfg") Then VehPlate18 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_18.cfg") Else VehPlate18 = "0"
'            If IO.File.Exists(Apartment.GaragePath & "vehicle_19.cfg") Then VehPlate19 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_19.cfg") Else VehPlate19 = "0"

'            RemoveIPL(ReadCfgValue("MBWipl", saveFile))
'            ToggleIPL(Apartment.GarageIPL)
'            TwentyCarGarage.Apartment = Apartment
'            TwentyCarGarage.LastIPL = Apartment.GarageIPL
'            TwentyCarGarage.WallText = Apartment.GarageWallText1
'            TwentyCarGarage.LightText = Apartment.GarageLightText1
'            TwentyCarGarage.NumberText = Apartment.GarageNumberText1
'            TwentyCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
'            TwentyCarGarage.lastLocationVector = Apartment.ApartmentExit
'            TwentyCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
'            TwentyCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
'            TwentyCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
'            TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'            TwentyCarGarage.CurrentPath = Apartment.GaragePath
'            TwentyCarGarage.Elevator = Apartment.GarageElevator
'            ToggleOfficeGarageDecor(Apartment.GarageWall1, Apartment.GarageLight1, Apartment.GarageNumber1, INMNative.Apartment.GetInteriorID(TwentyCarGarage.Elevator))
'            TwentyCarGarage.MenuActivator = Apartment.GarageMenuActivator
'            TwentyCarGarage.ElevatorDistance = Apartment.GarageElevatorDistance
'            TwentyCarGarage.GarageMarkerDistance = Apartment.GarageMenuActivatorDistance
'            TwentyCarGarage.veh0Pos = Apartment.GarageVeh0Pos
'            TwentyCarGarage.veh1Pos = Apartment.GarageVeh1Pos
'            TwentyCarGarage.veh2Pos = Apartment.GarageVeh2Pos
'            TwentyCarGarage.veh3Pos = Apartment.GarageVeh3Pos
'            TwentyCarGarage.veh4Pos = Apartment.GarageVeh4Pos
'            TwentyCarGarage.veh5Pos = Apartment.GarageVeh5Pos
'            TwentyCarGarage.veh6Pos = Apartment.GarageVeh6Pos
'            TwentyCarGarage.veh7Pos = Apartment.GarageVeh7Pos
'            TwentyCarGarage.veh8Pos = Apartment.GarageVeh8Pos
'            TwentyCarGarage.veh9Pos = Apartment.GarageVeh9Pos
'            TwentyCarGarage.veh10Pos = Apartment.GarageVeh10Pos
'            TwentyCarGarage.veh11Pos = Apartment.GarageVeh11Pos
'            TwentyCarGarage.veh12Pos = Apartment.GarageVeh12Pos
'            TwentyCarGarage.veh13Pos = Apartment.GarageVeh13Pos
'            TwentyCarGarage.veh14Pos = Apartment.GarageVeh14Pos
'            TwentyCarGarage.veh15Pos = Apartment.GarageVeh15Pos
'            TwentyCarGarage.veh16Pos = Apartment.GarageVeh16Pos
'            TwentyCarGarage.veh17Pos = Apartment.GarageVeh17Pos
'            TwentyCarGarage.veh18Pos = Apartment.GarageVeh18Pos
'            TwentyCarGarage.veh19Pos = Apartment.GarageVeh19Pos
'            TwentyCarGarage.vehRot0613 = Apartment.GarageVeh0613Rot
'            TwentyCarGarage.vehRot1714 = Apartment.GarageVeh1714Rot
'            TwentyCarGarage.vehRot2815 = Apartment.GarageVeh2815Rot
'            TwentyCarGarage.vehRot3916 = Apartment.GarageVeh3916Rot
'            TwentyCarGarage.vehRot41017 = Apartment.GarageVeh41017Rot
'            TwentyCarGarage.vehRot51118 = Apartment.GarageVeh51118Rot
'            TwentyCarGarage.vehRot1219 = Apartment.GarageVeh1219Rot
'            TwentyCarGarage.Floor1CamPos = Apartment.CamPos1F
'            TwentyCarGarage.Floor2CamPos = Apartment.CamPos2F
'            TwentyCarGarage.Floor3CamPos = Apartment.CamPos3F
'            TwentyCarGarage.Floor1CamRot = Apartment.CamRot1F
'            TwentyCarGarage.Floor2CamRot = Apartment.CamRot2F
'            TwentyCarGarage.Floor3CamRot = Apartment.CamRot3F
'            GarageMenu.Visible = False

'            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_0.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh0, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_1.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh1, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_2.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh2, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_3.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh3, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_4.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh4, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_5.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh5, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate6 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_6.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh6, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate7 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_7.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh7, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate8 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_8.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh8, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate9 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_9.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh9, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate10 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_10.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh10, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate11 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_11.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh11, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate12 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_12.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh12, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate13 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_13.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh13, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate14 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_14.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh14, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate15 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_15.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh15, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate16 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_16.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh16, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate17 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_17.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh17, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate18 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_18.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh18, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate19 Then
'                Game.FadeScreenOut(500)
'                Wait(500)
'                TwentyCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_19.cfg", "False")
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                playerPed.CurrentVehicle.Delete()
'                playerPed.Position = TwentyCarGarage.Elevator
'                SetIntoVehicle(playerPed, TwentyCarGarage.veh19, VehicleSeat.Driver)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Else
'                TwentyCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                TwentyCarGarage.SaveGarageVehicle(Apartment.GaragePath)
'            End If
'        End If
'    End Sub

'    Public Sub OnTick()
'        Try
'            If Not Game.IsLoading Then
'                If My.Settings.MazeBankWest = "Enable" Then
'                    'Enter Apartment
'                    If (Not BuyMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso (Apartment.EntranceDistance < 3.0 Or Apartment.RoofDistance < 3.0) Then
'                        DisplayHelpTextThisFrame(EnterApartment & Apartment.Name)
'                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                            Game.FadeScreenOut(500)
'                            Wait(500)
'                            BuyMenu.Visible = True
'                            World.RenderingCamera = World.CreateCamera(Apartment.CameraPosition, Apartment.CameraRotation, Apartment.CameraFOV)
'                            hideHud = True
'                            Wait(500)
'                            Game.FadeScreenIn(500)
'                        End If
'                    End If

'                    'Save Game
'                    If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.SaveDistance < 3.0 Then
'                        DisplayHelpTextThisFrame(SaveGame)
'                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                            playerMap = Apartment.PlayerMap
'                            Game.FadeScreenOut(500)
'                            Wait(500)
'                            TimeLapse(8)
'                            Game.ShowSaveMenu()
'                            SavePosition()
'                            Wait(500)
'                            Game.FadeScreenIn(500)
'                        End If
'                    End If

'                    'Exit Apartment
'                    If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.ExitDistance < 2.0 Then
'                        DisplayHelpTextThisFrame(ExitApartment & Apartment.Name & Apartment.Unit)
'                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                            ExitMenu.Visible = True
'                        End If
'                    End If

'                    'Wardrobe
'                    If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.WardrobeDistance < 1.0 Then
'                        DisplayHelpTextThisFrame(ChangeClothes)
'                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                            WardrobeVector = Apartment.Wardrobe
'                            WardrobeHead = Apartment.WardrobeHeading
'                            WardrobeScriptStatus = 0
'                            If GetPlayerName() = "Michael" Then
'                                Player0W.Visible = True
'                                MakeACamera()
'                            ElseIf GetPlayerName() = "Franklin" Then
'                                Player1W.Visible = True
'                                MakeACamera()
'                            ElseIf GetPlayerName() = “Trevor"
'                                Player2W.Visible = True
'                                MakeACamera()
'                            ElseIf GetPlayerName() = "Player3" Then
'                                If Game.Player.Character.Model.GetHashCode = 1885233650 Then
'                                    Player3_MW.Visible = True
'                                    MakeACamera()
'                                ElseIf Game.Player.Character.Model.GetHashCode = -1667301416 Then
'                                    Player3_FW.Visible = True
'                                    MakeACamera()
'                                End If
'                            End If
'                        End If
'                    End If

'                    'Enter Garage
'                    If (Not playerPed.IsDead AndAlso Apartment.Owner = GetPlayerName()) AndAlso Apartment.GarageDistance < 5.0 Then
'                        If Not playerPed.IsInVehicle AndAlso (Not GarageMenu.Visible) Then
'                            DisplayHelpTextThisFrame(_EnterGarage & Garage)
'                            If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                                GarageMenu.Visible = True
'                            End If
'                        ElseIf playerPed.IsInVehicle Then
'                            If Resources.GetVehicleClass(playerPed.CurrentVehicle) = "Pegasus" Then
'                                DisplayHelpTextThisFrame(CannotStore)
'                            ElseIf playerPed.IsInVehicle AndAlso (Not GarageMenu.Visible) Then
'                                DisplayHelpTextThisFrame(_EnterGarage & Garage)
'                                If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                                    GarageMenu.Visible = True
'                                End If
'                            End If
'                        End If
'                    End If

'                    'If playerInterior = Apartment.InteriorID Then Apartment.IsAtHome = True Else Apartment.IsAtHome = False

'                    Select Case playerInterior
'                        Case Apartment.InteriorID
'                            Apartment.IsAtHome = True
'                            HIDE_MAP_OBJECT_THIS_FRAME()
'                            CreateOfficeAssistant()
'                        Case Else
'                            Apartment.IsAtHome = False
'                    End Select

'                    If Apartment.IsAtHome Then
'                        HIDE_MAP_OBJECT_THIS_FRAME()
'                        CreateOfficeAssistant()
'                    End If

'                    _menuPool.ProcessMenus()
'                End If
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub HIDE_MAP_OBJECT_THIS_FRAME()
'        Native.Function.Call(Hash._0x4B5CFC83122DF602)
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_dtl"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "hei_sm_15_bld2"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_LOD"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_dtl3"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld1_dtl3"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_bld2_railing"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_emissive"))
'        Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, "sm_15_emissive_LOD"))
'        Native.Function.Call(Hash._0x3669F1B198DCAA4F)
'    End Sub

'    Public Shared Sub EnableOfficeProp()
'        EnableInteriotProp(Apartment.InteriorID, "office_chairs")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_01")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_02")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_03")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_04")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_05")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_06")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_07")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_08")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_09")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_10")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_11")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_12")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_13")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_14")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_15")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_16")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_17")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_18")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_19")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_20")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_21")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_22")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_23")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_24")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Silver")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Silver2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Silver3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Pills")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Pills2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Pills3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Med")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Med2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Med3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_JewelWatch")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_JewelWatch2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_JewelWatch3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Ivory")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Ivory2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Ivory3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Guns")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Guns2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Guns3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Gems")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Gems2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Gems3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Furcoats")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Furcoats2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Furcoats3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_electronic")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_electronic2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_electronic3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugStatue")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugStatue2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugStatue3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugBags")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugBags2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugBags3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Counterfeit")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Counterfeit2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Counterfeit3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Booze_cigs")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Booze_cigs2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Booze_cigs3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Art")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Art2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Art3")
'        EnableInteriotProp(Apartment.InteriorID, "Office_Booze")
'        EnableInteriotProp(Apartment.InteriorID, "Gun_Locker")
'        EnableInteriotProp(Apartment.InteriorID, "Mod_Booth")
'    End Sub

'    Public Sub CreateOfficeAssistant()
'        If Apartment.AssistantChair = Nothing Then
'            Apartment.AssistantChair = World.CreateProp(1580642483, Apartment.AssistantPosition, False, False)
'            Apartment.AssistantChair.Heading = Apartment.AssistantHeading
'            Apartment.AssistantChair.FreezePosition = True
'            Apartment.AssistantChair.IsInvincible = True
'        End If
'        If Apartment.OfficeAssistant = Nothing Then
'            Apartment.OfficeAssistant = World.CreatePed(PedHash.ExecutivePAFemale02, Apartment.AssistantPosition)
'            Apartment.OfficeAssistant.AttachTo(Apartment.AssistantChair, 0, New Vector3(0, -0.1, 0.43), New Vector3(0, 180, 0))
'            Apartment.OfficeAssistant.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8.0, -1, True, -1.0)
'            Apartment.OfficeAssistant.Heading = Apartment.AssistantHeading - 180
'            Apartment.OfficeAssistant.FreezePosition = True
'            Apartment.OfficeAssistant.IsInvincible = True
'            Apartment.OfficeAssistant.RelationshipGroup = &H6F0783F5
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 0, 1, 3, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 2, 2, 0, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 3, 2, 0, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 4, 1, 2, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 6, 2, 2, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 7, 2, 0, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 8, 0, 0, 0)
'            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 11, 1, 2, 0)
'        End If
'    End Sub

'    Public Sub RefreshOfficeProps()
'        Apartment.AssistantChair.Delete()
'        Apartment.AssistantChair = World.CreateProp(1580642483, Apartment.AssistantPosition, False, False)
'        Apartment.AssistantChair.Heading = Apartment.AssistantHeading
'        Apartment.AssistantChair.FreezePosition = True
'        Apartment.AssistantChair.IsInvincible = True

'        Apartment.OfficeAssistant.Delete()
'        Apartment.OfficeAssistant = World.CreatePed(PedHash.ExecutivePAFemale02, Apartment.AssistantPosition)
'        Apartment.OfficeAssistant.AttachTo(Apartment.AssistantChair, 0, New Vector3(0, -0.1, 0.43), New Vector3(0, 180, 0))
'        Apartment.OfficeAssistant.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8.0, -1, True, -1.0)
'        Apartment.OfficeAssistant.Heading = Apartment.AssistantHeading - 180
'        Apartment.OfficeAssistant.FreezePosition = True
'        Apartment.OfficeAssistant.IsInvincible = True
'        Apartment.OfficeAssistant.RelationshipGroup = &H6F0783F5
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 0, 1, 3, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 2, 2, 0, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 3, 2, 0, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 4, 1, 2, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 6, 2, 2, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 7, 2, 0, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 8, 0, 0, 0)
'        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Apartment.OfficeAssistant, 11, 1, 2, 0)

'        EnableOfficeProp()
'    End Sub

'    Public Sub OnAborted() 'Handles MyBase.Aborted
'        Try
'            If Not Apartment.AptBlip Is Nothing Then Apartment.AptBlip.Remove()
'            If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
'            If Not Apartment.OfficeAssistant = Nothing Then Apartment.OfficeAssistant.Delete()
'            If Not Apartment.AssistantChair = Nothing Then Apartment.AssistantChair.Delete()
'        Catch ex As Exception
'        End Try
'    End Sub
'End Class
