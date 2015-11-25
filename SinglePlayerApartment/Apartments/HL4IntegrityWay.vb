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

Public Class HL4IntegrityWay
    Inherits Script

    Public Shared Owner As String = ReadCfgValue("4IWHLowner", saveFile)
    Public Shared _Name As String = "4 Integrity Way Apt. "
    Public Shared Desc As String = "Live in the clouds while your bank balance hits the floor. An apartment so conspicuosly expansive all your friends will immediately know how much you paid for it. The downtown lateral living experience for people who secretly want to be LC based. Includes a 10-car garage."
    Public Shared Unit As String = "28"
    Public Shared Cost As Integer = 952000
    Public Shared Save As Vector3 = New Vector3(-36.3656, -583.9371, 78.8302)
    Public Shared Teleport As Vector3 = New Vector3(-21.5202, -598.4841, 80.0662)
    Public Shared Teleport2 As Vector3 = New Vector3(-49.3243, -583.1716, 37.0333)
    Public Shared _Exit As Vector3 = New Vector3(-24.4089, -597.69, 80.0311)
    Public Shared Wardrobe As Vector3 = New Vector3(-38.1595, -589.3992, 78.8302)
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single
    Public Shared WardrobeDistance As Single

    Public Shared ExitMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            uiLanguage = Game.Language.ToString

            If uiLanguage = "Chinese" Then
                _Name = "統合小道4號公寓"
                Desc = "住在雲端，而你的銀行存款餘額撒在地板上。 ~n~ 公寓這樣明顯擴張你所有的朋友都會立刻知道 ~n~ 你多少報酬。要基於LC的人誰偷偷想鬧橫向的 ~n~ 生活體驗。包括可容納十輛車的車庫。"
            Else
                _Name = "4 Integrity Way Apt. "
                Desc = "Live in the clouds while your bank balance hits the floor. An apartment so conspicuosly expansive all your friends will immediately know how much you paid for it. The downtown lateral living experience for people who secretly want to be LC based. Includes a 10-car garage."
            End If

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            _menuPool = New MenuPool()
            CreateExitMenu()
            AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
            AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateExitMenu()
        Try
            If uiLanguage = "Chinese" Then
                ExitApt = "离开公寓"
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
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("4IWHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                _4IntegrityWay._Blip.Remove()
                If Not _4IntegrityWay.Blip2 Is Nothing Then _4IntegrityWay.Blip2.Remove()
                _4IntegrityWay.Create4IntegrityWay()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                _4IntegrityWay.RefreshMenu()
                _4IntegrityWay.RefreshGarageMenu()
                UnLoadMPDLCMap()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                TenCarGarage.isInGarage = True
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = _4IntegrityWay._Garage
                TenCarGarage.lastLocationGarageOutVector = _4IntegrityWay.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = _4IntegrityWay.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
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
                'Press E on hl4integrity Bed
                playerMap = "4IntegrityHL"
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
                If playerName = "Michael" Then
                    Player0W.Visible = True
                    MakeACamera()
                ElseIf playerName = "Franklin" Then
                    Player1W.Visible = True
                    MakeACamera()
                ElseIf playerName = “Trevor"
                    Player2W.Visible = True
                    MakeACamera()
                End If
            End If
            'End Controls

            _menuPool.ProcessMenus()
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
