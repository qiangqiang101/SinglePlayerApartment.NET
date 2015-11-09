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

Public Class DelPerroHeight
    Inherits Script

    Public Shared delperroOwner As String = ReadCfgValue("DPHwoner", saveFile)
    Public Shared delperroCost As Integer = 468000
    Public Shared delperroBlip As Blip
    Public Shared delperroHeight As Vector3 = New Vector3(-1443.0578, -544.7794, 34.7418)
    Public Shared delperroHeightSave As Vector3 = New Vector3(-1471.4473, -533.1909, 50.7216)
    Public Shared delperroHeightTeleport As Vector3 = New Vector3(-1460.3659, -522.0636, 56.929)
    Public Shared delperroHeightTeleport2 As Vector3 = New Vector3(-1439.5905, -550.6906, 34.7418)
    Public Shared delperroHeightExit As Vector3 = New Vector3(-1457.5853, -520.3571, 56.929)
    Public Shared delperroDoorDistance As Single
    Public Shared delperroSaveDistance As Single
    Public Shared delperroExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateDelPerroHeight()
        delperroBlip = World.CreateBlip(delperroHeight)
        If delperroOwner = "Michael" Then
            delperroBlip.Sprite = BlipSprite.Safehouse
            delperroBlip.Color = BlipColor.Blue
            delperroBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 佩羅高地公寓7", delperroBlip)
            Else
                SetBlipName("Property: Del Perro Heights Apartment 7", delperroBlip)
            End If
        ElseIf delperroOwner = "Franklin" Then
            delperroBlip.Sprite = BlipSprite.Safehouse
            delperroBlip.Color = BlipColor.Green
            delperroBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 佩羅高地公寓7", delperroBlip)
            Else
                SetBlipName("Property: Del Perro Heights Apartment 7", delperroBlip)
            End If
        ElseIf delperroOwner = "Trevor" Then
            delperroBlip.Sprite = BlipSprite.Safehouse
            delperroBlip.Color = 17
            delperroBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 佩羅高地公寓7", delperroBlip)
            Else
                SetBlipName("Property: Del Perro Heights Apartment 7", delperroBlip)
            End If
        Else
            delperroBlip.Sprite = BlipSprite.SafehouseForSale
            delperroBlip.Color = BlipColor.White
            delperroBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", delperroBlip)
            Else
                SetBlipName("Property For Sale", delperroBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            delperroDoorDistance = World.GetDistance(playerPed.Position, delperroHeight)
            delperroSaveDistance = World.GetDistance(playerPed.Position, delperroHeightSave)
            delperroExitDistance = World.GetDistance(playerPed.Position, delperroHeightExit)

            'Enter delperro Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso delperroDoorDistance < 3.0 AndAlso delperroOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 468000 元買佩羅高地公寓7。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Del Perro Heights Apartment 7 for $468,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso delperroDoorDistance < 2.0 AndAlso delperroOwner = playerName Then
                SetInteriorActive2(-1477.14, -538.75, 55.5264) 'del perro 7
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = delperroHeightTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso delperroSaveDistance < 3.0 AndAlso delperroOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso delperroExitDistance < 2.0 AndAlso delperroOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso delperroDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso delperroOwner = "None" Then
                'Press E on delperro Door
                If playerCash > delperroCost Then
                    WriteCfgValue("DPHwoner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - delperroCost)
                    delperroOwner = playerName
                    delperroBlip.Remove()
                    CreateDelPerroHeight()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~佩羅高地公寓7"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Del Perro Heights Apartment 7"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso delperroSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso delperroOwner = playerName Then
                'Press E on delperro Bed
                playerMap = "DelPerro"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso delperroExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso delperroOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = delperroHeightTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso delperroExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso delperroOwner = playerName Then
                WriteCfgValue("DPHwoner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + delperroCost)
                delperroOwner = "None"
                delperroBlip.Remove()
                CreateDelPerroHeight()
                Game.Player.Character.Position = delperroHeightTeleport2
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
                delperroBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
