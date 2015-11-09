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

Public Class HLRichardMajestic
    Inherits Script

    Public Shared hlrichardOwner As String = ReadCfgValue("RMHLowner", saveFile)
    Public Shared hlrichardCost As Integer = 968000
    Public Shared hlrichardBlip As Blip
    Public Shared hlrichardMajestic As Vector3 = New Vector3(-909.0057, -380.716, 38.9613)
    Public Shared hlrichardMajesticSave As Vector3 = New Vector3(-901.0586, -369.1378, 113.0741)
    Public Shared hlrichardMajesticTeleport As Vector3 = New Vector3(-922.1152, -370.0627, 114.3101)
    Public Shared hlrichardMajesticTeleport2 As Vector3 = New Vector3(-933.4771, -383.6144, 38.9613)
    Public Shared hlrichardMajesticExit As Vector3 = New Vector3(-919.3095, -368.5584, 114.275)
    Public Shared hlrichardDoorDistance As Single
    Public Shared hlrichardSaveDistance As Single
    Public Shared hlrichardExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateHLRichardsMajestic()
        hlrichardBlip = World.CreateBlip(hlrichardMajestic)
        If hlrichardOwner = "Michael" Then
            hlrichardBlip.Sprite = BlipSprite.Safehouse
            hlrichardBlip.Color = BlipColor.Blue
            hlrichardBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 李察尊爵公寓2", hlrichardBlip)
            Else
                SetBlipName("Property: Richards Majestic Apartment 2", hlrichardBlip)
            End If
        ElseIf hlrichardOwner = "Franklin" Then
            hlrichardBlip.Sprite = BlipSprite.Safehouse
            hlrichardBlip.Color = BlipColor.Green
            hlrichardBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 李察尊爵公寓2", hlrichardBlip)
            Else
                SetBlipName("Property: Richards Majestic Apartment 2", hlrichardBlip)
            End If
        ElseIf hlrichardOwner = "Trevor" Then
            hlrichardBlip.Sprite = BlipSprite.Safehouse
            hlrichardBlip.Color = 17
            hlrichardBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 李察尊爵公寓2", hlrichardBlip)
            Else
                SetBlipName("Property: Richards Majestic Apartment 2", hlrichardBlip)
            End If
        Else
            hlrichardBlip.Sprite = BlipSprite.SafehouseForSale
            hlrichardBlip.Color = BlipColor.White
            hlrichardBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", hlrichardBlip)
            Else
                SetBlipName("Property For Sale", hlrichardBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            hlrichardDoorDistance = World.GetDistance(playerPed.Position, hlrichardMajestic)
            hlrichardSaveDistance = World.GetDistance(playerPed.Position, hlrichardMajesticSave)
            hlrichardExitDistance = World.GetDistance(playerPed.Position, hlrichardMajesticExit)

            'Enter hlrichard Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hlrichardDoorDistance < 3.0 AndAlso hlrichardOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 968000 元買李察尊爵公寓2。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Richards Majestic Apartment 2 for $968,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hlrichardDoorDistance < 2.0 AndAlso hlrichardOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hlrichardMajesticTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hlrichardSaveDistance < 3.0 AndAlso hlrichardOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hlrichardExitDistance < 2.0 AndAlso hlrichardOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hlrichardDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hlrichardOwner = "None" Then
                'Press E on hlrichard Door
                If playerCash > hlrichardCost Then
                    WriteCfgValue("RMHLowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - hlrichardCost)
                    hlrichardOwner = playerName
                    hlrichardBlip.Remove()
                    CreateHLRichardsMajestic()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~李察尊爵公寓2"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Richards Majestic Apartment 2"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hlrichardSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hlrichardOwner = playerName Then
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

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hlrichardExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hlrichardOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hlrichardMajesticTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso hlrichardExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hlrichardOwner = playerName Then
                WriteCfgValue("RMHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + hlrichardCost)
                hlrichardOwner = "None"
                hlrichardBlip.Remove()
                CreateHLRichardsMajestic()
                Game.Player.Character.Position = hlrichardMajesticTeleport2
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
                hlrichardBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
