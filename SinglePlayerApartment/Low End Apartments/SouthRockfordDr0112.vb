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

Public Class SouthRockfordDr0112

    Public Shared Apartment As Apartment
    Public Shared BuyMenu, ExitMenu, GarageMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            Apartment = New Apartment("0112 South Rockford Drive Apt. ", "13", 80000)
            Apartment.Name = ReadCfgValue("0112SouthRockfordName", langFile)
            Apartment.Description = ReadCfgValue("0112SouthRockfordDesc", langFile)
            Apartment.Owner = ReadCfgValue("0112SRDowner", saveFile)
            Apartment.Entrance = New Vector3(-812.3849, -980.3691, 14.26866)
            Apartment.Save = New Vector3(262.9082, -1003.095, -99.0086)
            Apartment.TeleportInside = New Vector3(265.3285, -1002.7042, -99.0085)
            Apartment.TeleportOutside = New Vector3(-814.8087, -984.2986, 14.03712)
            Apartment.ApartmentExit = New Vector3(266.1321, -1007.5136, -101.0085)
            Apartment.Wardrobe = New Vector3(260.0521, -1004.1469, -99.0085)
            Apartment.GarageEntrance = New Vector3(-812.1517, -954.1611, 15.22835)
            Apartment.GarageOutside = New Vector3(-822.1036, -955.2672, 15.24641)
            Apartment.GarageOutHeading = 99.68565
            Apartment.CameraPosition = New Vector3(-835.3129, -1003.118, 16.48207)
            Apartment.CameraRotation = New Vector3(3.313114, 0, -32.55415)
            Apartment.CameraFOV = 50.0
            Apartment.WardrobeHeading = 359.818
            Apartment.GaragePath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\"
            Apartment.SaveFile = "0112SRDowner"
            Apartment.PlayerMap = "0112SouthRockfordDr"
            Apartment.Interior = New Vector3(263.86999, -998.78002, -99.010002)
            Apartment.Enabled = True

            If ReadCfgValue("0112SouthRockfordDr", settingFile) = "Enable" Then
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
            GarageMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Create0112SouthRockfordDr()
        Apartment.Create(Apartment)
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
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Script.Wait(500)
                Game.FadeScreenIn(500)
                LowEndLastLocationName = Nothing
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue(Apartment.SaveFile, "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Apartment.Cost)
                Apartment.Owner = "None"
                Apartment.AptBlip.Remove()
                If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                Create0112SouthRockfordDr()
                Brain.TVOn = False
                Game.Player.Character.Position = Apartment.TeleportOutside
                Script.Wait(500)
                Game.FadeScreenIn(500)
                RefreshMenu()
                RefreshGarageMenu()
                LowEndLastLocationName = Nothing
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(193.9493, -1004.425, -99.99999) '6 car garage
                Brain.TVOn = False
                playerPed.Position = SixCarGarage.Elevator
                SixCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
                SixCarGarage.lastLocationVector = Apartment.ApartmentExit
                SixCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
                SixCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
                SixCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                SixCarGarage.CurrentPath = Apartment.GaragePath
                ExitMenu.Visible = False
                Script.Wait(500)
                Game.FadeScreenIn(500)
                LowEndLastLocationName = Apartment.Name & Apartment.Unit
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
                    Script.Wait(&H3E8)
                    If Website.freeRealEstate = False Then SinglePlayerApartment.player.Money = (playerCash - Apartment.Cost)
                    Apartment.Owner = playerName
                    Apartment.AptBlip.Remove()
                    If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
                    Create0112SouthRockfordDr()
                    RefreshGarageMenu()
                    Mechanic.CreateMechanicMenu()
                    Script.Wait(500)
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
                LowEndLastLocationName = Apartment.Name & Apartment.Unit

                Apartment.SetInteriorActive()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = Apartment.TeleportInside
                If Website.merryChristmas Then ShowXmasTree(New Vector3(260.0096, -999.2469, -99.00863))
                Script.Wait(500)
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
            Script.Wait(&H3E8)
            SetInteriorActive2(193.9493, -1004.425, -99.99999) '6 car garage
            SetInteriorActive2(263.86999, -998.78002, -99.010002) 'vespucci blvd
            playerPed.Position = SixCarGarage.GarageDoorL
            SixCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
            SixCarGarage.lastLocationVector = Apartment.ApartmentExit
            SixCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            SixCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            SixCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
            SixCarGarage.CurrentPath = Apartment.GaragePath
            GarageMenu.Visible = False
            Script.Wait(500)
            Game.FadeScreenIn(500)
            LowEndLastLocationName = Apartment.Name & Apartment.Unit
        ElseIf selectedItem.Text = Apartment.Name & Apartment.Unit & Garage AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso playerPed.IsInVehicle Then
            On Error Resume Next
            Dim VehPlate0, VehPlate1, VehPlate2, VehPlate3, VehPlate4, VehPlate5 As String
            If IO.File.Exists(Apartment.GaragePath & "vehicle_0.cfg") Then VehPlate0 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_0.cfg") Else VehPlate0 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_1.cfg") Then VehPlate1 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_1.cfg") Else VehPlate1 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_2.cfg") Then VehPlate2 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_2.cfg") Else VehPlate2 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_3.cfg") Then VehPlate3 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_3.cfg") Else VehPlate3 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_4.cfg") Then VehPlate4 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_4.cfg") Else VehPlate4 = "0"
            If IO.File.Exists(Apartment.GaragePath & "vehicle_5.cfg") Then VehPlate5 = ReadCfgValue("PlateNumber", Apartment.GaragePath & "vehicle_5.cfg") Else VehPlate5 = "0"

            LowEndLastLocationName = Apartment.Name & Apartment.Unit
            SetInteriorActive2(193.9493, -1004.425, -99.99999) '6 car garage
            Apartment.SetInteriorActive()
            SixCarGarage.CurrentPath = Apartment.GaragePath
            SixCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
            SixCarGarage.lastLocationVector = Apartment.ApartmentExit
            SixCarGarage.lastLocationGarageVector = Apartment.GarageEntrance
            SixCarGarage.lastLocationGarageOutVector = Apartment.GarageOutside
            SixCarGarage.lastLocationGarageOutHeading = Apartment.GarageOutHeading
            GarageMenu.Visible = False

            If playerPed.CurrentVehicle.NumberPlate = VehPlate0 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SixCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_0.cfg", "False")
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = SixCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, SixCarGarage.veh0, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate1 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SixCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_1.cfg", "False")
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = SixCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, SixCarGarage.veh1, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate2 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SixCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_2.cfg", "False")
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = SixCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, SixCarGarage.veh2, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate3 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SixCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_3.cfg", "False")
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = SixCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, SixCarGarage.veh3, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate4 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SixCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_4.cfg", "False")
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = SixCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, SixCarGarage.veh4, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf playerPed.CurrentVehicle.NumberPlate = VehPlate5 Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SixCarGarage.UpdateGarageVehicle(Apartment.GaragePath & "vehicle_5.cfg", "False")
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                playerPed.CurrentVehicle.Delete()
                playerPed.Position = SixCarGarage.GarageDoorL
                SetIntoVehicle(playerPed, SixCarGarage.veh5, VehicleSeat.Driver)
                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
                Script.Wait(500)
                Game.FadeScreenIn(500)
            Else
                SixCarGarage.LoadGarageVechicles(Apartment.GaragePath)
                SixCarGarage.SaveGarageVehicle(Apartment.GaragePath)
            End If
        End If
    End Sub

    Public Sub OnTick()
        Try
            If My.Settings.SouthRockfordDr0112 = "Enable" Then
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
                If (LowEndLastLocationName = (Apartment.Name & Apartment.Unit) AndAlso ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.SaveDistance < 1.0) Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = Apartment.PlayerMap
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        TimeLapse(8)
                        Game.ShowSaveMenu()
                        SavePosition()
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                    End If
                End If

                'Exit Apartment
                If (LowEndLastLocationName = (Apartment.Name & Apartment.Unit) AndAlso ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.ExitDistance < 2.0) Then
                    DisplayHelpTextThisFrame(ExitApartment & Apartment.Name & Apartment.Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If

                'Wardrobe
                If (LowEndLastLocationName = (Apartment.Name & Apartment.Unit) AndAlso ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.WardrobeDistance < 1.0) Then
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

                'Enter Garage
                If (Not playerPed.IsDead AndAlso Apartment.Owner = playerName) AndAlso Apartment.GarageDistance < 5.0 Then
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

                _menuPool.ProcessMenus()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnAborted() 'Handles MyBase.Aborted
        Try
            If Not Apartment.AptBlip Is Nothing Then Apartment.AptBlip.Remove()
            If Not Apartment.GrgBlip Is Nothing Then Apartment.GrgBlip.Remove()
        Catch ex As Exception
        End Try
    End Sub
End Class
