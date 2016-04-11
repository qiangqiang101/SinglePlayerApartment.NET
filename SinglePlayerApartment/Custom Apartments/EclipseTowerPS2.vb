Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI
Imports SinglePlayerApartment.Wardrobe

Public Class EclipseTowerPS2
    Inherits Script

    Public Shared IPL As String = ReadCfgValue("ETP2ipl", saveFile2)
    Public Shared LastIPL As String = IPL
    Public Shared Owner As String = ReadCfgValue("ETP2owner", saveFile2)
    Public Shared _Name As String = "Eclipse Tower, Penthouse Suite "
    Public Shared Desc As String = "Penthouse living isn't just about mindless luxury. It's about knowing that when you flush a dump you're literally crapping through every single one of the $500K hovels beneath you - and that's something that only money can buy. Access to our same-day redecorating service included as standard. Includes a 10-car garage."
    Public Shared Unit As String = "2"
    Public Shared Cost As Integer = 905000
    Public Shared Save As Vector3 = New Vector3(-763.3478, 320.4298, 199.4861)
    Public Shared Teleport As Vector3 = New Vector3(-776.9169, 336.887, 196.4864)
    Public Shared Teleport2 As Vector3 = New Vector3(-773.282, 312.275, 84.698)
    Public Shared _Exit As Vector3 = New Vector3(-779.2371, 339.6224, 196.6866)
    Public Shared Wardrobe As Vector3 = New Vector3(-763.9934, 329.6285, 199.4863)
    Public Shared WardrobeDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single
    Public Shared WardrobeHeading As Single = 178.7236 '/
    Public Shared StyleCameraPos As Vector3 = New Vector3(-774.2443, 314.4292, 196.6641)
    Public Shared StyleCameraRot As Vector3 = New Vector3(-2.762131, 0, 16.02366)
    Public Shared StyleCameraFov As Single = 50.0

    Public Shared ExitMenu, StyleMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then
                _Name = ReadCfgValue("EclipsePS2Name", langFile)
                Desc = ReadCfgValue("EclipsePS2Desc", langFile)
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

                AddHandler Tick, AddressOf OnTick

                _menuPool = New MenuPool()
                CreateExitMenu()
                CreateAptStyleMenu()
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler StyleMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler StyleMenu.OnItemSelect, AddressOf ItemSelectHandler
                AddHandler StyleMenu.OnIndexChange, AddressOf IndexChangeHandler
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateAptStyleMenu()
        Try
            StyleMenu = New UIMenu("", AptStyle.ToUpper, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            StyleMenu.SetBannerType(Rectangle)
            _menuPool.Add(StyleMenu)
            StyleMenu.AddItem(New UIMenuItem(ModernStyle))
            StyleMenu.AddItem(New UIMenuItem(MoodyStyle))
            StyleMenu.AddItem(New UIMenuItem(VibrantStyle))
            StyleMenu.AddItem(New UIMenuItem(SharpStyle))
            StyleMenu.AddItem(New UIMenuItem(MonochromeStyle))
            StyleMenu.AddItem(New UIMenuItem(SeductiveStyle))
            StyleMenu.AddItem(New UIMenuItem(RegalStyle))
            StyleMenu.AddItem(New UIMenuItem(AquaStyle))
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
            ExitMenu.AddItem(New UIMenuItem(EnterGarage))
            ExitMenu.AddItem(New UIMenuItem(SellApt))
            ExitMenu.AddItem(New UIMenuItem(AptStyle))
            ExitMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
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
                Game.Player.Character.Position = Teleport2
                Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
                EclipseTower.IsAtHome = False
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("ETP2owner", "None", saveFile2)
                SavePosition2()
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                EclipseTower._Blip.Remove()
                If Not EclipseTower.Blip2 Is Nothing Then EclipseTower.Blip2.Remove()
                EclipseTower.CreateEclipseTower()
                Game.Player.Character.Position = Teleport2
                Wait(500)
                Game.FadeScreenIn(500)
                EclipseTower.RefreshMenu()
                EclipseTower.RefreshGarageMenu()
                UnLoadMPDLCMap()
                EclipseTower.IsAtHome = False
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = EclipseTower._Garage
                TenCarGarage.lastLocationGarageOutVector = EclipseTower.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = EclipseTower.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
                ExitMenu.Visible = False
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = AptStyle Then
                ExitMenu.Visible = False
                StyleMenu.Visible = True
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                World.RenderingCamera = World.CreateCamera(StyleCameraPos, StyleCameraRot, StyleCameraFov)
                hideHud = True
                Wait(500)
                Game.FadeScreenIn(500)
            End If

            If selectedItem.Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_01_b", saveFile2)
                IPL = "apa_v_mp_h_01_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_02_b", saveFile2)
                IPL = "apa_v_mp_h_02_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_03_b", saveFile2)
                IPL = "apa_v_mp_h_03_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_04_b", saveFile2)
                IPL = "apa_v_mp_h_04_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_05_b", saveFile2)
                IPL = "apa_v_mp_h_05_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_06_b", saveFile2)
                IPL = "apa_v_mp_h_06_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_07_b", saveFile2)
                IPL = "apa_v_mp_h_07_b"
                Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                WriteCfgValue("ETP2ipl", "apa_v_mp_h_08_b", saveFile2)
                IPL = "apa_v_mp_h_08_b"
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
            If sender.MenuItems(index).Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_01_b")
                LastIPL = "apa_v_mp_h_01_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_02_b")
                LastIPL = "apa_v_mp_h_02_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_03_b")
                LastIPL = "apa_v_mp_h_03_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_04_b")
                LastIPL = "apa_v_mp_h_04_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_05_b")
                LastIPL = "apa_v_mp_h_05_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_06_b")
                LastIPL = "apa_v_mp_h_06_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_07_b")
                LastIPL = "apa_v_mp_h_07_b"
                Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_08_b")
                LastIPL = "apa_v_mp_h_08_b"
                Wait(500)
                Game.FadeScreenIn(500)
            End If
            IPL = LastIPL
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If My.Settings.EclipseTower = "Enable" Then
                SaveDistance = World.GetDistance(playerPed.Position, Save)
                ExitDistance = World.GetDistance(playerPed.Position, _Exit)
                WardrobeDistance = World.GetDistance(playerPed.Position, Wardrobe)

                'Save Game
                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Owner = playerName) AndAlso SaveDistance < 3.0 Then
                    DisplayHelpTextThisFrame(SaveGame)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        playerMap = "EclipsePS2"
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
                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Owner = playerName) AndAlso ExitDistance < 2.0 Then
                    DisplayHelpTextThisFrame(ExitApartment & _Name & Unit)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        ExitMenu.Visible = True
                    End If
                End If

                'Wardrobe
                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Owner = playerName) AndAlso WardrobeDistance < 1.0 Then
                    DisplayHelpTextThisFrame(ChangeClothes)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        WardrobeVector = Wardrobe
                        WardrobeHead = WardrobeHeading
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

                _menuPool.ProcessMenus()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
End Class
