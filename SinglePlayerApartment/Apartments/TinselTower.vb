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

Public Class TinselTower
    Inherits Script

    Public Shared tinselOwner As String = ReadCfgValue("TTowner", saveFile)
    Public Shared tinselCost As Integer = 492000
    Public Shared tinselBlip As Blip
    Public Shared tinselTower As Vector3 = New Vector3(-614.7656, 37.9, 43.5895)
    Public Shared tinselTowerSave As Vector3 = New Vector3(-583.2249, 44.9624, 87.4188)
    Public Shared tinselTowerTeleport As Vector3 = New Vector3(-598.9042, 41.8059, 93.6261)
    Public Shared tinselTowerTeleport2 As Vector3 = New Vector3(-617.9388, 35.7848, 43.5558)
    Public Shared tinselTowerExit As Vector3 = New Vector3(-601.8906, 42.3395, 93.6261)
    Public Shared tinselDoorDistance As Single
    Public Shared tinselSaveDistance As Single
    Public Shared tinselExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateTinselTower()
        tinselBlip = World.CreateBlip(tinselTower)
        If tinselOwner = "Michael" Then
            tinselBlip.Sprite = BlipSprite.Safehouse
            tinselBlip.Color = BlipColor.Blue
            tinselBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 俗華大樓公寓29", tinselBlip)
            Else
                SetBlipName("Property: Tinsel Tower Apartment 29", tinselBlip)
            End If
        ElseIf tinselOwner = "Franklin" Then
            tinselBlip.Sprite = BlipSprite.Safehouse
            tinselBlip.Color = BlipColor.Green
            tinselBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 俗華大樓公寓29", tinselBlip)
            Else
                SetBlipName("Property: Tinsel Tower Apartment 29", tinselBlip)
            End If
        ElseIf tinselOwner = "Trevor" Then
            tinselBlip.Sprite = BlipSprite.Safehouse
            tinselBlip.Color = 17
            tinselBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 俗華大樓公寓29", tinselBlip)
            Else
                SetBlipName("Property: Tinsel Tower Apartment 29", tinselBlip)
            End If
        Else
            tinselBlip.Sprite = BlipSprite.SafehouseForSale
            tinselBlip.Color = BlipColor.White
            tinselBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", tinselBlip)
            Else
                SetBlipName("Property For Sale", tinselBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            tinselDoorDistance = World.GetDistance(playerPed.Position, tinselTower)
            tinselSaveDistance = World.GetDistance(playerPed.Position, tinselTowerSave)
            tinselExitDistance = World.GetDistance(playerPed.Position, tinselTowerExit)

            'Enter tinsel Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso tinselDoorDistance < 3.0 AndAlso tinselOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 492000 元買俗華大樓公寓29。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Tinsel Tower Apartment 29 for $492,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso tinselDoorDistance < 2.0 AndAlso tinselOwner = playerName Then
                SetInteriorActive2(-575.305, 42.3233, 92.2236) 'tinsel tower 29
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = tinselTowerTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso tinselSaveDistance < 3.0 AndAlso tinselOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso tinselExitDistance < 2.0 AndAlso tinselOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 離開公寓, 按 ~INPUT_DETONATE~ 出售產業。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Exit Apartment, Press ~INPUT_DETONATE~ to Sell Property.")
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso tinselDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso tinselOwner = "None" Then
                'Press E on tinsel Door
                If playerCash > tinselCost Then
                    WriteCfgValue("TTowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - tinselCost)
                    tinselOwner = playerName
                    tinselBlip.Remove()
                    CreateTinselTower()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~俗華大樓公寓29"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Tinsel Tower Apartment 29"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso tinselSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso tinselOwner = playerName Then
                'Press E on tinsel Bed
                playerMap = "Tinsel"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso tinselExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso tinselOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = tinselTowerTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso tinselExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso tinselOwner = playerName Then
                WriteCfgValue("TTowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + tinselCost)
                tinselOwner = "None"
                tinselBlip.Remove()
                CreateTinselTower()
                Game.Player.Character.Position = tinselTowerTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try
                tinselBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
