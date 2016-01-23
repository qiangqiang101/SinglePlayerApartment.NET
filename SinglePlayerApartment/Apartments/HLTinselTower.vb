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

Public Class HLTinselTower
    Inherits Script

    Public Shared Owner As String = ReadCfgValue("TTHLowner", saveFile)
    Public Shared _Name As String = "Tinsel Tower Apt. "
    Public Shared Desc As String = "A picture-perfect lateral living experience in one of Los Santos' most sought-after tower blocks. These gorgeous lateral apartments only become available when hedgefunder residents have massive drug-induced heart attacks or get arrested for killing hookers. Includes a 10-car garage."
    Public Shared Unit As String = "42"
    Public Shared Cost As Integer = 984000
    Public Shared Save As Vector3 = New Vector3(-594.5658, 50.1804, 96.9996)
    Public Shared Teleport As Vector3 = New Vector3(-614.032, 58.9435, 98.2355)
    Public Shared Teleport2 As Vector3 = New Vector3(-617.9388, 35.7848, 43.5558)
    Public Shared _Exit As Vector3 = New Vector3(-610.6395, 58.8867, 98.2004)
    Public Shared Wardrobe As Vector3 = New Vector3(-594.8418, 55.761, 96.9996)
    Public Shared WardrobeDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single
    Public Shared WardrobeHeading As Single = 173.2113

    Public Shared ExitMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            If ReadCfgValue("TinselTower", settingFile) = "Enable" Then
                uiLanguage = Game.Language.ToString

                If uiLanguage = "Chinese" Then
                    _Name = "俗華大樓公寓"
                    Desc = "在洛聖最搶手的高樓中的一個圖片完美橫向的 ~n~ 生活體驗。這些華麗的橫向公寓只有變得可 ~n~ 用時，對沖基金的居民有大量的藥物引起的心 ~n~ 臟發作或被捕殺害妓女。 ~n~ 包括可容納十輛車的車庫。"
                Else
                    _Name = "Tinsel Tower Apt. "
                    Desc = "A picture-perfect lateral living experience in one of Los Santos' most sought-after tower blocks. These gorgeous lateral apartments only become available when hedgefunder residents have massive drug-induced heart attacks or get arrested for killing hookers. Includes a 10-car garage."
                End If

                AddHandler Tick, AddressOf OnTick
                AddHandler KeyDown, AddressOf OnKeyDown

                _menuPool = New MenuPool()
                CreateExitMenu()
                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
            End If
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
                TinselTower.IsAtHome = False
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("TTHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                TinselTower._Blip.Remove()
                If Not TinselTower.Blip2 Is Nothing Then TinselTower.Blip2.Remove()
                TinselTower.CreateTinselTower()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                TinselTower.RefreshMenu()
                TinselTower.RefreshGarageMenu()
                UnLoadMPDLCMap()
                TinselTower.IsAtHome = False
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                TenCarGarage.isInGarage = True
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = TinselTower._Garage
                TenCarGarage.lastLocationGarageOutVector = TinselTower.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = TinselTower.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
                ExitMenu.Visible = False
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If ReadCfgValue("TinselTower", settingFile) = "Enable" Then
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
                    'Press E on hltinsel Bed
                    playerMap = "TinselHL"
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
