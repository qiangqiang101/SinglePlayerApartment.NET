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

Public Class WeazelPlaza
    Inherits Script

    Public Shared weazelOwner As String = ReadCfgValue("WPowner", saveFile)
    Public Shared weazelCost As Integer = 335000
    Public Shared weazelBlip As Blip
    Public Shared weazelPlaza As Vector3 = New Vector3(-916.162, -450.4095, 39.5998)
    Public Shared weazelPlazaSave As Vector3 = New Vector3(-913.0292, -440.8677, 115.3998)
    Public Shared weazelPlazaTeleport As Vector3 = New Vector3(-900.6082, -431.0182, 121.607)
    Public Shared weazelPlazaTeleport2 As Vector3 = New Vector3(-914.3189, -455.2902, 39.5998)
    Public Shared weazelPlazaExit As Vector3 = New Vector3(-897.3925, -430.1651, 121.607)
    Public Shared weazelDoorDistance As Single
    Public Shared weazelSaveDistance As Single
    Public Shared weazelExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateWeazelPlaza()
        weazelBlip = World.CreateBlip(weazelPlaza)
        If weazelOwner = "Michael" Then
            weazelBlip.Sprite = BlipSprite.Safehouse
            weazelBlip.Color = BlipColor.Blue
            weazelBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 威索廣場公寓70", weazelBlip)
            Else
                SetBlipName("Property: Weazel Plaza Apartment 70", weazelBlip)
            End If
        ElseIf weazelOwner = "Franklin" Then
            weazelBlip.Sprite = BlipSprite.Safehouse
            weazelBlip.Color = BlipColor.Green
            weazelBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 威索廣場公寓70", weazelBlip)
            Else
                SetBlipName("Property: Weazel Plaza Apartment 70", weazelBlip)
            End If
        ElseIf weazelOwner = "Trevor" Then
            weazelBlip.Sprite = BlipSprite.Safehouse
            weazelBlip.Color = 17
            weazelBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 威索廣場公寓70", weazelBlip)
            Else
                SetBlipName("Property: Weazel Plaza Apartment 70", weazelBlip)
            End If
        Else
            weazelBlip.Sprite = BlipSprite.SafehouseForSale
            weazelBlip.Color = BlipColor.White
            weazelBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", weazelBlip)
            Else
                SetBlipName("Property For Sale", weazelBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            weazelDoorDistance = World.GetDistance(playerPed.Position, weazelPlaza)
            weazelSaveDistance = World.GetDistance(playerPed.Position, weazelPlazaSave)
            weazelExitDistance = World.GetDistance(playerPed.Position, weazelPlazaExit)

            'Enter weazel Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso weazelDoorDistance < 3.0 AndAlso weazelOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 335000 元買威索廣場公寓70。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Weazel Plaza Apartment 70 for $335,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso weazelDoorDistance < 2.0 AndAlso weazelOwner = playerName Then
                SetInteriorActive2(-909.054, -441.466, 120.205) 'weazel plaza 70
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = weazelPlazaTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso weazelSaveDistance < 3.0 AndAlso weazelOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso weazelExitDistance < 2.0 AndAlso weazelOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso weazelDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso weazelOwner = "None" Then
                'Press E on weazel Door
                If playerCash > weazelCost Then
                    WriteCfgValue("WPowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - weazelCost)
                    weazelOwner = playerName
                    weazelBlip.Remove()
                    CreateWeazelPlaza()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~威索廣場公寓70"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Weazel Plaza Apartment 70"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso weazelSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso weazelOwner = playerName Then
                'Press E on weazel Bed
                playerMap = "Weazel"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso weazelExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso weazelOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = weazelPlazaTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso weazelExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso weazelOwner = playerName Then
                WriteCfgValue("WPowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + weazelCost)
                weazelOwner = "None"
                weazelBlip.Remove()
                CreateWeazelPlaza()
                Game.Player.Character.Position = weazelPlazaTeleport2
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
                weazelBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
