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

Public Class HLDelPerro
    Inherits Script

    Public Shared Owner As String = ReadCfgValue("DPHHLowner", saveFile)
    Public Shared _Name As String = "Del Perro Heights Apt. "
    Public Shared Desc As String = "Enjoy ocean views far away from tourists and bums on Del Perro Beach with this lateral living opportunity for the super rich. If we can overpay for something, we have, and we're passing the expanse on down to you. Includes a 10-car garage."
    Public Shared Unit As String = "4"
    Public Shared Cost As Integer = 936000
    Public Shared Save As Vector3 = New Vector3(-1454.6335, -552.5497, 72.8437)
    Public Shared Teleport As Vector3 = New Vector3(-1458.6523, -531.4198, 74.0796)
    Public Shared Teleport2 As Vector3 = New Vector3(-1439.5905, -550.6906, 34.7418)
    Public Shared _Exit As Vector3 = New Vector3(-1456.5989, -534.5363, 74.0445)
    Public Shared Wardrobe As Vector3 = New Vector3(-1449.6384, -549.0426, 72.8437)
    Public Shared WardrobeDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single

    Public Shared ExitMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            uiLanguage = Game.Language.ToString

            If uiLanguage = "Chinese" Then
                _Name = "佩羅高地公寓"
                Desc = "欣賞海景，遠離對德爾佩羅海灘遊客和燒傷與 ~n~ 超級富豪這個橫向的生活的機會。如果我們能 ~n~ 多付的東西，我們已經和我們傳遞了廣闊下來 ~n~ 給你。包括可容納十輛車的車庫。"
            Else
                _Name = "Del Perro Heights Apt. "
                Desc = "Enjoy ocean views far away from tourists and bums on Del Perro Beach with this lateral living opportunity for the super rich. If we can overpay for something, we have, and we're passing the expanse on down to you. Includes a 10-car garage."
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
                UnLoadMPDLCMap()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("DPHHLowner", "None", saveFile)
                SavePosition2()
                UnLoadMPDLCMap()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                DelPerroHeight._Blip.Remove()
                If Not DelPerroHeight.Blip2 Is Nothing Then DelPerroHeight.Blip2.Remove()
                DelPerroHeight.CreateDelPerroHeight()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                DelPerroHeight.RefreshMenu()
                DelPerroHeight.RefreshGarageMenu()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                TenCarGarage.isInGarage = True
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = DelPerroHeight._Garage
                TenCarGarage.lastLocationGarageOutVector = DelPerroHeight.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = DelPerroHeight.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\")
                TenCarGarage.CurrentPath = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
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
                playerMap = "DelPerroHL"
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
