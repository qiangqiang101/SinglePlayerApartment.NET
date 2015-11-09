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

Public Class RichardMajestic
    Inherits Script

    Public Shared richardOwner As String = ReadCfgValue("RMowner", saveFile)
    Public Shared richardCost As Integer = 484000
    Public Shared richardBlip As Blip
    Public Shared richardMajestic As Vector3 = New Vector3(-935.4753, -378.6128, 38.9613)
    Public Shared richardMajesticSave As Vector3 = New Vector3(-900.8789, -374.416, -79.2731)
    Public Shared richardMajesticTeleport As Vector3 = New Vector3(-913.1502, -384.5727, 85.4804)
    Public Shared richardMajesticTeleport2 As Vector3 = New Vector3(-933.4771, -383.6144, 38.9613)
    Public Shared richardMajesticExit As Vector3 = New Vector3(-916.3039, -384.9148, 85.4804)
    Public Shared richardDoorDistance As Single
    Public Shared richardSaveDistance As Single
    Public Shared richardExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateRichardsMajestic()
        richardBlip = World.CreateBlip(richardMajestic)
        If richardOwner = "Michael" Then
            richardBlip.Sprite = BlipSprite.Safehouse
            richardBlip.Color = BlipColor.Blue
            richardBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 李察尊爵公寓4", richardBlip)
            Else
                SetBlipName("Property: Richards Majestic Apartment 4", richardBlip)
            End If
        ElseIf richardOwner = "Franklin" Then
            richardBlip.Sprite = BlipSprite.Safehouse
            richardBlip.Color = BlipColor.Green
            richardBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 李察尊爵公寓4", richardBlip)
            Else
                SetBlipName("Property: Richards Majestic Apartment 4", richardBlip)
            End If
        ElseIf richardOwner = "Trevor" Then
            richardBlip.Sprite = BlipSprite.Safehouse
            richardBlip.Color = 17
            richardBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 李察尊爵公寓4", richardBlip)
            Else
                SetBlipName("Property: Richards Majestic Apartment 4", richardBlip)
            End If
        Else
            richardBlip.Sprite = BlipSprite.SafehouseForSale
            richardBlip.Color = BlipColor.White
            richardBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", richardBlip)
            Else
                SetBlipName("Property For Sale", richardBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            richardDoorDistance = World.GetDistance(playerPed.Position, richardMajestic)
            richardSaveDistance = World.GetDistance(playerPed.Position, richardMajesticSave)
            richardExitDistance = World.GetDistance(playerPed.Position, richardMajesticExit)

            'Enter richard Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso richardDoorDistance < 3.0 AndAlso richardOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 484000 元買李察尊爵公寓4。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Richards Majestic Apartment 4 for $484,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso richardDoorDistance < 2.0 AndAlso richardOwner = playerName Then
                SetInteriorActive2(-897.197, -369.246, 84.0779) 'richards majestic 4
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = richardMajesticTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso richardSaveDistance < 3.0 AndAlso richardOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso richardExitDistance < 2.0 AndAlso richardOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso richardDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richardOwner = "None" Then
                'Press E on richard Door
                If playerCash > richardCost Then
                    WriteCfgValue("RMowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - richardCost)
                    richardOwner = playerName
                    richardBlip.Remove()
                    CreateRichardsMajestic()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~李察尊爵公寓4"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Richards Majestic Apartment 4"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso richardSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richardOwner = playerName Then
                'Press E on richard Bed
                playerMap = "Richard"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso richardExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richardOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = richardMajesticTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso richardExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richardOwner = playerName Then
                WriteCfgValue("RMowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + richardCost)
                richardOwner = "None"
                richardBlip.Remove()
                CreateRichardsMajestic()
                Game.Player.Character.Position = richardMajesticTeleport2
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
                richardBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
