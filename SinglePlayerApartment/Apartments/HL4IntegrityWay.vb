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

Public Class HL4IntegrityWay
    Inherits Script

    Public Shared hl4integrityOwner As String = ReadCfgValue("4IWHLowner", saveFile)
    Public Shared hl4integrityCost As Integer = 952000
    Public Shared hl4integrityBlip As Blip
    Public Shared hl4integrityWay As Vector3 = New Vector3(-48.0058, -587.9324, 37.9529)
    Public Shared hl4integrityWaySave As Vector3 = New Vector3(-36.3656, -583.9371, 78.8302)
    Public Shared hl4integrityWayTeleport As Vector3 = New Vector3(-21.5202, -598.4841, 80.0662)
    Public Shared hl4integrityWayTeleport2 As Vector3 = New Vector3(-49.3243, -583.1716, 37.0333)
    Public Shared hl4integrityWayExit As Vector3 = New Vector3(-24.4089, -597.69, 80.0311)
    Public Shared hl4integrityDoorDistance As Single
    Public Shared hl4integritySaveDistance As Single
    Public Shared hl4integrityExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateHL4IntegrityWay()
        hl4integrityBlip = World.CreateBlip(hl4integrityWay)
        If hl4integrityOwner = "Michael" Then
            hl4integrityBlip.Sprite = BlipSprite.Safehouse
            hl4integrityBlip.Color = BlipColor.Blue
            hl4integrityBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 統合小道4號公寓28", hl4integrityBlip)
            Else
                SetBlipName("Property: 4 Integrity Way 28", hl4integrityBlip)
            End If
        ElseIf hl4integrityOwner = "Franklin" Then
            hl4integrityBlip.Sprite = BlipSprite.Safehouse
            hl4integrityBlip.Color = BlipColor.Green
            hl4integrityBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 統合小道4號公寓28", hl4integrityBlip)
            Else
                SetBlipName("Property: 4 Integrity Way 28", hl4integrityBlip)
            End If
        ElseIf hl4integrityOwner = "Trevor" Then
            hl4integrityBlip.Sprite = BlipSprite.Safehouse
            hl4integrityBlip.Color = 17
            hl4integrityBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 統合小道4號公寓28", hl4integrityBlip)
            Else
                SetBlipName("Property: 4 Integrity Way 28", hl4integrityBlip)
            End If
        Else
            hl4integrityBlip.Sprite = BlipSprite.SafehouseForSale
            hl4integrityBlip.Color = BlipColor.White
            hl4integrityBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", hl4integrityBlip)
            Else
                SetBlipName("Property For Sale", hl4integrityBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            hl4integrityDoorDistance = World.GetDistance(playerPed.Position, hl4integrityWay)
            hl4integritySaveDistance = World.GetDistance(playerPed.Position, hl4integrityWaySave)
            hl4integrityExitDistance = World.GetDistance(playerPed.Position, hl4integrityWayExit)

            'Enter hl4integrity Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hl4integrityDoorDistance < 3.0 AndAlso hl4integrityOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 952000 元買統合小道4號公寓28。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase 4 Integrity Way Apartment 28 for $952,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hl4integrityDoorDistance < 2.0 AndAlso hl4integrityOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hl4integrityWayTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hl4integritySaveDistance < 3.0 AndAlso hl4integrityOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hl4integrityExitDistance < 2.0 AndAlso hl4integrityOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hl4integrityDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hl4integrityOwner = "None" Then
                'Press E on hl4integrity Door
                If playerCash > hl4integrityCost Then
                    WriteCfgValue("4IWHLowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - hl4integrityCost)
                    hl4integrityOwner = playerName
                    hl4integrityBlip.Remove()
                    CreateHL4IntegrityWay()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~統合小道4號公寓28"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~4 Integrity Way Apartment 28"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hl4integritySaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hl4integrityOwner = playerName Then
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

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hl4integrityExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hl4integrityOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hl4integrityWayTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso hl4integrityExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hl4integrityOwner = playerName Then
                WriteCfgValue("4IWHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + hl4integrityCost)
                hl4integrityOwner = "None"
                hl4integrityBlip.Remove()
                CreateHL4IntegrityWay()
                Game.Player.Character.Position = hl4integrityWayTeleport2
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
                hl4integrityBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
