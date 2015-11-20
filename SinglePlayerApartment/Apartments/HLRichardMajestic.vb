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

Public Class HLRichardMajestic
    Inherits Script

    Public Shared Owner As String = ReadCfgValue("RMHLowner", saveFile)
    Public Shared _Name As String = "Richards Majestic Apt. "
    Public Shared Desc As String = "Own a piece of glamorous old Vinewood, albeit a very small and expensive piece that's been made to look just like the other super-rich corners of Los Santos. A contemporary lateral living experience with one foot in the past. Includes a 10-car garage."
    Public Shared Unit As String = "2"
    Public Shared Cost As Integer = 968000
    Public Shared Save As Vector3 = New Vector3(-901.0586, -369.1378, 113.0741)
    Public Shared Teleport As Vector3 = New Vector3(-922.1152, -370.0627, 114.3101)
    Public Shared Teleport2 As Vector3 = New Vector3(-933.4771, -383.6144, 38.9613)
    Public Shared _Exit As Vector3 = New Vector3(-919.3095, -368.5584, 114.275)
    Public Shared Wardrobe As Vector3 = New Vector3(-903.3266, -364.2998, 113.074)
    Public Shared WardrobeDistance As Single
    Public Shared SaveDistance As Single
    Public Shared ExitDistance As Single

    Public Shared ExitMenu As UIMenu
    Public Shared _menuPool As MenuPool

    Public Sub New()
        Try
            uiLanguage = Game.Language.ToString

            If uiLanguage = "Chinese" Then
                _Name = "李察尊爵公寓"
                Desc = "擁有一塊美艷舊Vinewood，儘管這是被做看起來就像洛斯桑托斯的其他超級富豪的角落一個非常小的和昂貴的。與以往一隻腳一個現代的橫向的生活體驗。包括可容納十輛車的車庫。"
            Else
                _Name = "Richards Majestic Apt. "
                Desc = "Own a piece of glamorous old Vinewood, albeit a very small and expensive piece that's been made to look just like the other super-rich corners of Los Santos. A contemporary lateral living experience with one foot in the past. Includes a 10-car garage."
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
            ElseIf selectedItem.Text = SellApt Then
                'Sell Apt
                ExitMenu.Visible = False
                WriteCfgValue("RMHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + Cost)
                Owner = "None"
                RichardMajestic._Blip.Remove()
                If Not RichardMajestic.Blip2 Is Nothing Then RichardMajestic.Blip2.Remove()
                RichardMajestic.CreateRichardsMajestic()
                Game.Player.Character.Position = Teleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
                RichardMajestic.RefreshMenu()
                RichardMajestic.RefreshGarageMenu()
            ElseIf selectedItem.Text = EnterGarage Then
                'Enter Garage
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
                TenCarGarage.isInGarage = True
                playerPed.Position = TenCarGarage.Elevator
                TenCarGarage.LastLocationName = _Name & Unit
                TenCarGarage.lastLocationVector = _Exit
                TenCarGarage.lastLocationGarageVector = RichardMajestic._Garage
                TenCarGarage.lastLocationGarageOutVector = RichardMajestic.GarageOut
                TenCarGarage.lastLocationGarageOutHeading = RichardMajestic.GarageOutHeading
                TenCarGarage.LoadGarageVechicles(Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\")
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

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso WardrobeDistance < 2.0 AndAlso Owner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 更換服裝。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to change clothes.")
                End If
            End If

            _menuPool.ProcessMenus()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso ExitDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead Then
                ExitMenu.Visible = True
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso SaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
                'Press E on hlrichard Bed
                playerMap = "RichardHL"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso WardrobeDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso Owner = playerName Then
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
