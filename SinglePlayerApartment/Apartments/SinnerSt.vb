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

Public Class SinnerSt
    Inherits Script

    Public Shared sinnerOwner As String = ReadCfgValue("SSowner", saveFile)
    Public Shared sinnerCost As Integer = 112000
    Public Shared sinnerBlip As Blip
    Public Shared sinnerSt As Vector3 = New Vector3(386.8984, -973.9644, 29.6169)
    Public Shared sinnerStSave As Vector3 = New Vector3(349.9618, -997.4911, -99.1962)
    Public Shared sinnerStTeleport As Vector3 = New Vector3(346.5235, -1002.9012, -99.1962)
    Public Shared sinnerStTeleport2 As Vector3 = New Vector3(391.614, -973.8656, 29.4369)
    Public Shared sinnerStExit As Vector3 = New Vector3(346.3732, -1013.137, -99.1962)
    Public Shared sinnerDoorDistance As Single
    Public Shared sinnerSaveDistance As Single
    Public Shared sinnerExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateSinnerSt()
        sinnerBlip = World.CreateBlip(sinnerSt)
        If sinnerOwner = "Michael" Then
            sinnerBlip.Sprite = BlipSprite.Safehouse
            sinnerBlip.Color = BlipColor.Blue
            sinnerBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 罪人街1102號公寓12", sinnerBlip)
            Else
                SetBlipName("Property: 1102 Sinner Street Apartment 12", sinnerBlip)
            End If
        ElseIf sinnerOwner = "Franklin" Then
            sinnerBlip.Sprite = BlipSprite.Safehouse
            sinnerBlip.Color = BlipColor.Green
            sinnerBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 罪人街1102號公寓12", sinnerBlip)
            Else
                SetBlipName("Property: 1102 Sinner Street Apartment 12", sinnerBlip)
            End If
        ElseIf sinnerOwner = "Trevor" Then
            sinnerBlip.Sprite = BlipSprite.Safehouse
            sinnerBlip.Color = 17
            sinnerBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 罪人街1102號公寓12", sinnerBlip)
            Else
                SetBlipName("Property: 1102 Sinner Street Apartment 12", sinnerBlip)
            End If
        Else
            sinnerBlip.Sprite = BlipSprite.SafehouseForSale
            sinnerBlip.Color = BlipColor.White
            sinnerBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", sinnerBlip)
            Else
                SetBlipName("Property For Sale", sinnerBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            sinnerDoorDistance = World.GetDistance(playerPed.Position, sinnerSt)
            sinnerSaveDistance = World.GetDistance(playerPed.Position, sinnerStSave)
            sinnerExitDistance = World.GetDistance(playerPed.Position, sinnerStExit)

            'Enter sinner Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso sinnerDoorDistance < 3.0 AndAlso sinnerOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 112000 元買罪人街1102號公寓12。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase 1102 Sinner Street Apartment 12 for $112,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso sinnerDoorDistance < 2.0 AndAlso sinnerOwner = playerName Then
                SetInteriorActive2(343.85, -999.08, -99.198) 'midrange apartment
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = sinnerStTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso sinnerSaveDistance < 3.0 AndAlso sinnerOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso sinnerExitDistance < 2.0 AndAlso sinnerOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso sinnerDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso sinnerOwner = "None" Then
                'Press E on sinner Door
                If playerCash > sinnerCost Then
                    WriteCfgValue("SSowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - sinnerCost)
                    sinnerOwner = playerName
                    sinnerBlip.Remove()
                    CreateSinnerSt()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~罪人街1102號公寓12"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~1102 Sinner Street Apartment 12"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso sinnerSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso sinnerOwner = playerName Then
                'Press E on sinner Bed
                playerMap = "SinnerSt"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso sinnerExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso sinnerOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = sinnerStTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso sinnerExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso sinnerOwner = playerName Then
                WriteCfgValue("SSowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + sinnerCost)
                sinnerOwner = "None"
                sinnerBlip.Remove()
                CreateSinnerSt()
                Game.Player.Character.Position = sinnerStTeleport2
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
                sinnerBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
