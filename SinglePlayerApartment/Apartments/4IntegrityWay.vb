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

Public Class _4IntegrityWay
    Inherits Script

    Public Shared _4integrityOwner As String = ReadCfgValue("4IWowner", saveFile)
    Public Shared _4integrityCost As Integer = 476000
    Public Shared _4integrityBlip As Blip
    Public Shared _4integrityWay As Vector3 = New Vector3(-58.8814, -614.9837, 37.3567)
    Public Shared _4integrityWaySave As Vector3 = New Vector3(-36.6321, -578.1332, 83.9075)
    Public Shared _4integrityWayTeleport As Vector3 = New Vector3(-21.0966, -580.4884, 90.1148)
    Public Shared _4integrityWayTeleport2 As Vector3 = New Vector3(-62.3748, -617.7246, 36.2693)
    Public Shared _4integrityWayExit As Vector3 = New Vector3(-18.0797, -582.1524, 90.1148)
    Public Shared _4integrityDoorDistance As Single
    Public Shared _4integritySaveDistance As Single
    Public Shared _4integrityExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub Create4IntegrityWay()
        _4integrityBlip = World.CreateBlip(_4integrityWay)
        If _4integrityOwner = "Michael" Then
            _4integrityBlip.Sprite = BlipSprite.Safehouse
            _4integrityBlip.Color = BlipColor.Blue
            _4integrityBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 統合小道4號公寓30", _4integrityBlip)
            Else
                SetBlipName("Property: 4 Integrity Way 30", _4integrityBlip)
            End If
        ElseIf _4integrityOwner = "Franklin" Then
            _4integrityBlip.Sprite = BlipSprite.Safehouse
            _4integrityBlip.Color = BlipColor.Green
            _4integrityBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 統合小道4號公寓30", _4integrityBlip)
            Else
                SetBlipName("Property: 4 Integrity Way 30", _4integrityBlip)
            End If
        ElseIf _4integrityOwner = "Trevor" Then
            _4integrityBlip.Sprite = BlipSprite.Safehouse
            _4integrityBlip.Color = 17
            _4integrityBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 統合小道4號公寓30", _4integrityBlip)
            Else
                SetBlipName("Property: 4 Integrity Way 30", _4integrityBlip)
            End If
        Else
            _4integrityBlip.Sprite = BlipSprite.SafehouseForSale
            _4integrityBlip.Color = BlipColor.White
            _4integrityBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", _4integrityBlip)
            Else
                SetBlipName("Property For Sale", _4integrityBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            _4integrityDoorDistance = World.GetDistance(playerPed.Position, _4integrityWay)
            _4integritySaveDistance = World.GetDistance(playerPed.Position, _4integrityWaySave)
            _4integrityExitDistance = World.GetDistance(playerPed.Position, _4integrityWayExit)

            'Enter _4integrity Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _4integrityDoorDistance < 3.0 AndAlso _4integrityOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 476000 元買統合小道4號公寓30。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase 4 Integrity Way Apartment 30 for $476,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _4integrityDoorDistance < 2.0 AndAlso _4integrityOwner = playerName Then
                SetInteriorActive2(-37.41, -582.82, 88.71) '4 integrity way 30
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = _4integrityWayTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _4integritySaveDistance < 3.0 AndAlso _4integrityOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso _4integrityExitDistance < 2.0 AndAlso _4integrityOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso _4integrityDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _4integrityOwner = "None" Then
                'Press E on _4integrity Door
                If playerCash > _4integrityCost Then
                    WriteCfgValue("4IWowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - _4integrityCost)
                    _4integrityOwner = playerName
                    _4integrityBlip.Remove()
                    Create4IntegrityWay()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~統合小道4號公寓30"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~4 Integrity Way Apartment 30"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso _4integritySaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _4integrityOwner = playerName Then
                'Press E on _4integrity Bed
                playerMap = "4Integrity"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso _4integrityExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _4integrityOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = _4integrityWayTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso _4integrityExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso _4integrityOwner = playerName Then
                WriteCfgValue("4IWowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + _4integrityCost)
                _4integrityOwner = "None"
                _4integrityBlip.Remove()
                Create4IntegrityWay()
                Game.Player.Character.Position = _4integrityWayTeleport2
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
                _4integrityBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
