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

Public Class _3AltaStreet
    Inherits Script

    Public Shared _3altaOwner As String = ReadCfgValue("3ASowner", saveFile)
    Public Shared _3altaCost As Integer = 223000
    Public Shared _3altaBlip As Blip
    Public Shared _3altaStreet As Vector3 = New Vector3(-261.768, -970.4873, 31.2199)
    Public Shared _3altaStreetSave As Vector3 = New Vector3(-283.0112, -958.7992, 86.3036)
    Public Shared _3altaStreetTeleport As Vector3 = New Vector3(-281.0908, -943.2817, 92.5108)
    Public Shared _3altaStreetTeleport2 As Vector3 = New Vector3(-258.1236, -969.0657, 31.2199)
    Public Shared _3altaStreetExit As Vector3 = New Vector3(-279.2097, -940.9369, 92.5108)
    Public Shared _3altaDoorDistance As Single
    Public Shared _3altaSaveDistance As Single
    Public Shared _3altaExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Create3AltaStreet()
        _3altaBlip = World.CreateBlip(_3altaStreet)
        If _3altaOwner = "Michael" Then
            _3altaBlip.Sprite = BlipSprite.Safehouse
            _3altaBlip.Color = BlipColor.Blue
            _3altaBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 艾爾塔街3號公寓57", _3altaBlip)
            Else
                SetBlipName("Property: 3 Alta Street Apartment 57", _3altaBlip)
            End If
        ElseIf _3altaOwner = "Franklin" Then
            _3altaBlip.Sprite = BlipSprite.Safehouse
            _3altaBlip.Color = BlipColor.Green
            _3altaBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 艾爾塔街3號公寓57", _3altaBlip)
            Else
                SetBlipName("Property: 3 Alta Street Apartment 57", _3altaBlip)
            End If
        ElseIf _3altaOwner = "Trevor" Then
            _3altaBlip.Sprite = BlipSprite.Safehouse
            _3altaBlip.Color = 17
            _3altaBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 艾爾塔街3號公寓57", _3altaBlip)
            Else
                SetBlipName("Property: 3 Alta Street Apartment 57", _3altaBlip)
            End If
        Else
            _3altaBlip.Sprite = BlipSprite.SafehouseForSale
            _3altaBlip.Color = BlipColor.White
            _3altaBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", _3altaBlip)
            Else
                SetBlipName("Property For Sale", _3altaBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            _3altaDoorDistance = World.GetDistance(playerPed.Position, _3altaStreet)
            _3altaSaveDistance = World.GetDistance(playerPed.Position, _3altaStreetSave)
            _3altaExitDistance = World.GetDistance(playerPed.Position, _3altaStreetExit)

            'Enter _3alta Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _3altaDoorDistance < 3.0 AndAlso _3altaOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 223000 元買艾爾塔街3號公寓57。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase 3 Alta Street Apartment 57 for $223,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _3altaDoorDistance < 2.0 AndAlso _3altaOwner = playerName Then
                SetInteriorActive2(-280.74, -961.5, 91.11) '3 alta street 57
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = _3altaStreetTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _3altaSaveDistance < 3.0 AndAlso _3altaOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _3altaExitDistance < 2.0 AndAlso _3altaOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso _3altaDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _3altaOwner = "None" Then
                'Press E on _3alta Door
                If playerCash > _3altaCost Then
                    WriteCfgValue("3ASowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - _3altaCost)
                    _3altaOwner = playerName
                    _3altaBlip.Remove()
                    Create3AltaStreet()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~艾爾塔街3號公寓57"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~3 Alta Street Apartment 57"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso _3altaSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _3altaOwner = playerName Then
                'Press E on _3alta Bed
                playerMap = "3Alta"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso _3altaExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _3altaOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = _3altaStreetTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso _3altaExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _3altaOwner = playerName Then
                WriteCfgValue("3ASowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + _3altaCost)
                _3altaOwner = "None"
                _3altaBlip.Remove()
                Create3AltaStreet()
                Game.Player.Character.Position = _3altaStreetTeleport2
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
                _3altaBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
