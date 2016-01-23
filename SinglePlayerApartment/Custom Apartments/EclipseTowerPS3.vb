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

Public Class EclipseTowerPS3
    Inherits Script

    Public Shared IPL As String = ReadCfgValue("ETP3ipl", saveFile2)
    Public Shared LastIPL As String = IPL
    Public Shared Owner As String = ReadCfgValue("ETP3owner", saveFile2)
    Public Shared _Name As String = "Eclipse Tower, Penthouse Suite "
    Public Shared Desc As String = "Let's face it: we had you at the price tag. The fact that this happens to be one of the most decadent living spaces for hundreds of miles doesn't really matter. Just like its new owner, something this expensive doesn't need to be 'nice' or 'useful'... Access to our same-day redecorating service included as standard. Includes a 10-car garage."
    Public Shared Unit As String = "3"
    Public Shared Cost As Integer = 1100000
    Public Shared Save As Vector3 = New Vector3(-797.7316, 337.315, 190.7134)
    Public Shared Teleport As Vector3 = New Vector3(-784.0712, 320.7265, 187.7136)
    Public Shared Teleport2 As Vector3 = New Vector3(-773.282, 312.275, 84.698)
    Public Shared _Exit As Vector3 = New Vector3(-781.9078, 318.1647, 187.9138)
    Public Shared Wardrobe As Vector3 = New Vector3(-796.9515, 328.2715, 190.7134)
    Public Shared WardrobeDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single
    Public Shared WardrobeHeading As Single = 359.5432
    Public Shared StyleCameraPos As Vector3 = New Vector3(-786.7924, 343.3035, 187.8668)
    Public Shared StyleCameraRot As Vector3 = New Vector3(-1.956791, 0, -163.332)
    Public Shared StyleCameraFov As Single = 50.0

    Public Shared ExitMenu, StyleMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then
                uiLanguage = Game.Language.ToString

                If uiLanguage = "Chinese" Then
                    _Name = "日蝕大樓，閣樓套房 "
                    Desc = "面對真相吧：價格才是重中之重。這棟公寓剛 ~n~ 好是方圓百里內最奢華墮落的生活空間，不過 ~n~ 這完全不是重點。昂貴並不代表一定要 ~n~ 『美觀』或是『有用處』，這點和他的新主人 ~n~ 可是如出一轍。而你就是成為新主人的最佳人 ~n~ 選。還有什麼好猶豫的呢？我們提供當日翻修 ~n~ 服務作為購物標準配備。 ~n~ 包括可容納十輛車的車庫。"
                Else
                    _Name = "Eclipse Tower, Penthouse Suite "
                    Desc = "Let's face it: we had you at the price tag. The fact that this happens to be one of the most decadent living spaces for hundreds of miles doesn't really matter. Just like its new owner, something this expensive doesn't need to be 'nice' or 'useful'... Access to our same-day redecorating service included as standard. Includes a 10-car garage."
                End If

                AddHandler Tick, AddressOf OnTick
                AddHandler KeyDown, AddressOf OnKeyDown

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
            If uiLanguage = "Chinese" Then
                AptStyle = "公寓樣式"
                ModernStyle = "現代"
                MoodyStyle = "暗色系"
                VibrantStyle = "亮色系"
                SharpStyle = "時髦"
                MonochromeStyle = "黑白"
                SeductiveStyle = "誘惑"
                RegalStyle = "莊嚴"
                AquaStyle = "水彩"
            Else
                AptStyle = "Apartment Style"
                ModernStyle = "Modern"
                MoodyStyle = "Moody"
                VibrantStyle = "Vibrant"
                SharpStyle = "Sharp"
                MonochromeStyle = "Monochrome"
                SeductiveStyle = "Seductive"
                RegalStyle = "Regal"
                AquaStyle = "Aqua"
            End If

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
            If uiLanguage = "Chinese" Then
                ExitApt = "离開公寓"
                SellApt = "出售產業"
                EnterGarage = "進入車庫"
                AptOptions = "公寓選項"
                AptStyle = "公寓樣式"
            Else
                ExitApt = "Exit Apartment"
                SellApt = "Sell Property"
                EnterGarage = "Enter Garage"
                AptOptions = "APARTMENT OPTIONS"
                AptStyle = "Apartment Style"
            End If

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
                Script.Wait(&H3E8)
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                UnLoadMPDLCMap()
                EclipseTower.IsAtHome = False
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("ETP3owner", "None", saveFile2)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                EclipseTower._Blip.Remove()
                If Not EclipseTower.Blip2 Is Nothing Then EclipseTower.Blip2.Remove()
                EclipseTower.CreateEclipseTower()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                EclipseTower.RefreshMenu()
                EclipseTower.RefreshGarageMenu()
                UnLoadMPDLCMap()
                EclipseTower.IsAtHome = False
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                TenCarGarage.isInGarage = True
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = EclipseTower._Garage
                TenCarGarage.lastLocationGarageOutVector = EclipseTower.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = EclipseTower.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"
                ExitMenu.Visible = False
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = AptStyle Then
                ExitMenu.Visible = False
                StyleMenu.Visible = True
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                World.RenderingCamera = World.CreateCamera(StyleCameraPos, StyleCameraRot, StyleCameraFov)
                hideHud = True
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If selectedItem.Text = ModernStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_01_c", saveFile2)
                IPL = "apa_v_mp_h_01_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_02_c", saveFile2)
                IPL = "apa_v_mp_h_02_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_03_c", saveFile2)
                IPL = "apa_v_mp_h_03_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_04_c", saveFile2)
                IPL = "apa_v_mp_h_04_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_05_c", saveFile2)
                IPL = "apa_v_mp_h_05_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_06_c", saveFile2)
                IPL = "apa_v_mp_h_06_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_07_c", saveFile2)
                IPL = "apa_v_mp_h_07_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
                StyleMenu.Visible = False
                hideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
            ElseIf selectedItem.Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                WriteCfgValue("ETP3ipl", "apa_v_mp_h_08_c", saveFile2)
                IPL = "apa_v_mp_h_08_c"
                Script.Wait(500)
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
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_01_c")
                LastIPL = "apa_v_mp_h_01_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MoodyStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_02_c")
                LastIPL = "apa_v_mp_h_02_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = VibrantStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_03_c")
                LastIPL = "apa_v_mp_h_03_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SharpStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_04_c")
                LastIPL = "apa_v_mp_h_04_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = MonochromeStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_05_c")
                LastIPL = "apa_v_mp_h_05_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = SeductiveStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_06_c")
                LastIPL = "apa_v_mp_h_06_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = RegalStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_07_c")
                LastIPL = "apa_v_mp_h_07_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf sender.MenuItems(index).Text = AquaStyle Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                ChangeIPL(LastIPL, "apa_v_mp_h_08_c")
                LastIPL = "apa_v_mp_h_08_c"
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If
            IPL = LastIPL
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then
                SaveDistance = World.GetDistance(playerPed.Position, Save)
                ExitDistance = World.GetDistance(playerPed.Position, _Exit)
                WardrobeDistance = World.GetDistance(playerPed.Position, Wardrobe)

                'Save Game
                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso SaveDistance < 3.0 AndAlso Owner = playerName Then
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

                'Controls
                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso ExitDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead Then
                    ExitMenu.Visible = True
                End If

                If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso SaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                    'Press E on hleclipse Bed
                    playerMap = "EclipsePS3"
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    TimeLapse(8)
                    Game.ShowSaveMenu()
                    SavePosition()
                    WriteCfgValue("ETP3ipl", IPL, saveFile2)
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
                'End Controls

                _menuPool.ProcessMenus()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
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

            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
