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

Public Class HLTinselTower
    Inherits Script

    Public Shared hltinselOwner As String = ReadCfgValue("TTHLowner", saveFile)
    Public Shared hltinselCost As Integer = 984000
    Public Shared hltinselBlip As Blip
    Public Shared hltinselTower As Vector3 = New Vector3(-621.3374, 37.8696, 43.5958)
    Public Shared hltinselTowerSave As Vector3 = New Vector3(-594.5658, 50.1804, 96.9996)
    Public Shared hltinselTowerTeleport As Vector3 = New Vector3(-614.032, 58.9435, 98.2355)
    Public Shared hltinselTowerTeleport2 As Vector3 = New Vector3(-617.9388, 35.7848, 43.5558)
    Public Shared hltinselTowerExit As Vector3 = New Vector3(-610.6395, 58.8867, 98.2004)
    Public Shared hltinselDoorDistance As Single
    Public Shared hltinselSaveDistance As Single
    Public Shared hltinselExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateHLTinselTower()
        hltinselBlip = World.CreateBlip(hltinselTower)
        If hltinselOwner = "Michael" Then
            hltinselBlip.Sprite = BlipSprite.Safehouse
            hltinselBlip.Color = BlipColor.Blue
            hltinselBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 俗華大樓公寓42", hltinselBlip)
            Else
                SetBlipName("Property: Tinsel Tower Apartment 42", hltinselBlip)
            End If
        ElseIf hltinselOwner = "Franklin" Then
            hltinselBlip.Sprite = BlipSprite.Safehouse
            hltinselBlip.Color = BlipColor.Green
            hltinselBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 俗華大樓公寓42", hltinselBlip)
            Else
                SetBlipName("Property: Tinsel Tower Apartment 42", hltinselBlip)
            End If
        ElseIf hltinselOwner = "Trevor" Then
            hltinselBlip.Sprite = BlipSprite.Safehouse
            hltinselBlip.Color = 17
            hltinselBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 俗華大樓公寓42", hltinselBlip)
            Else
                SetBlipName("Property: Tinsel Tower Apartment 42", hltinselBlip)
            End If
        Else
            hltinselBlip.Sprite = BlipSprite.SafehouseForSale
            hltinselBlip.Color = BlipColor.White
            hltinselBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", hltinselBlip)
            Else
                SetBlipName("Property For Sale", hltinselBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            hltinselDoorDistance = World.GetDistance(playerPed.Position, hltinselTower)
            hltinselSaveDistance = World.GetDistance(playerPed.Position, hltinselTowerSave)
            hltinselExitDistance = World.GetDistance(playerPed.Position, hltinselTowerExit)

            'Enter hltinsel Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hltinselDoorDistance < 3.0 AndAlso hltinselOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 984000 元買俗華大樓公寓42。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Tinsel Tower Apartment 42 for $984,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hltinselDoorDistance < 2.0 AndAlso hltinselOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hltinselTowerTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hltinselSaveDistance < 3.0 AndAlso hltinselOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hltinselExitDistance < 2.0 AndAlso hltinselOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hltinselDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hltinselOwner = "None" Then
                'Press E on hltinsel Door
                If playerCash > hltinselCost Then
                    WriteCfgValue("TTHLowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - hltinselCost)
                    hltinselOwner = playerName
                    hltinselBlip.Remove()
                    CreateHLTinselTower()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~俗華大樓公寓42"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Tinsel Tower Apartment 42"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hltinselSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hltinselOwner = playerName Then
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

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hltinselExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hltinselOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hltinselTowerTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso hltinselExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hltinselOwner = playerName Then
                WriteCfgValue("TTHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + hltinselCost)
                hltinselOwner = "None"
                hltinselBlip.Remove()
                CreateHLTinselTower()
                Game.Player.Character.Position = hltinselTowerTeleport2
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
                hltinselBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
