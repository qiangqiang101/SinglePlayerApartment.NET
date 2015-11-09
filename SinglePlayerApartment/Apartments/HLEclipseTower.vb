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

Public Class HLEclipseTower
    Inherits Script

    Public Shared hleclipseOwner As String = ReadCfgValue("ETHLowner", saveFile)
    Public Shared hleclipseCost As Integer = 800000
    Public Shared hleclipseBlip As Blip
    Public Shared hleclipseTower As Vector3 = New Vector3(-775.323, 313.1424, 85.6981)
    Public Shared hleclipseTowerSave As Vector3 = New Vector3(-793.2186, 332.4132, 210.7966)
    Public Shared hleclipseTowerTeleport As Vector3 = New Vector3(-774.3142, 323.8076, 212.0325)
    Public Shared hleclipseTowerTeleport2 As Vector3 = New Vector3(-773.282, 312.275, 84.698)
    Public Shared hleclipseTowerExit As Vector3 = New Vector3(-777.6211, 323.5111, 211.9974)
    Public Shared hleclipseDoorDistance As Single
    Public Shared hleclipseSaveDistance As Single
    Public Shared hleclipseExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateHLEclipseTower()
        hleclipseBlip = World.CreateBlip(hleclipseTower)
        If hleclipseOwner = "Michael" Then
            hleclipseBlip.Sprite = BlipSprite.Safehouse
            hleclipseBlip.Color = BlipColor.Blue
            hleclipseBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 日蝕大樓公寓3", hleclipseBlip)
            Else
                SetBlipName("Property: Eclipse Tower Apartment 3", hleclipseBlip)
            End If
        ElseIf hleclipseOwner = "Franklin" Then
            hleclipseBlip.Sprite = BlipSprite.Safehouse
            hleclipseBlip.Color = BlipColor.Green
            hleclipseBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 日蝕大樓公寓3", hleclipseBlip)
            Else
                SetBlipName("Property: Eclipse Tower Apartment 3", hleclipseBlip)
            End If
        ElseIf hleclipseOwner = "Trevor" Then
            hleclipseBlip.Sprite = BlipSprite.Safehouse
            hleclipseBlip.Color = 17
            hleclipseBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 日蝕大樓公寓3", hleclipseBlip)
            Else
                SetBlipName("Property: Eclipse Tower Apartment 3", hleclipseBlip)
            End If
        Else
            hleclipseBlip.Sprite = BlipSprite.SafehouseForSale
            hleclipseBlip.Color = BlipColor.White
            hleclipseBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", hleclipseBlip)
            Else
                SetBlipName("Property For Sale", hleclipseBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            hleclipseDoorDistance = World.GetDistance(playerPed.Position, hleclipseTower)
            hleclipseSaveDistance = World.GetDistance(playerPed.Position, hleclipseTowerSave)
            hleclipseExitDistance = World.GetDistance(playerPed.Position, hleclipseTowerExit)

            'Enter hleclipse Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hleclipseDoorDistance < 3.0 AndAlso hleclipseOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 800000 元買日蝕大樓公寓3。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Eclipse Tower Apartment 3 for $800,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hleclipseDoorDistance < 2.0 AndAlso hleclipseOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hleclipseTowerTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hleclipseSaveDistance < 3.0 AndAlso hleclipseOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso hleclipseExitDistance < 2.0 AndAlso hleclipseOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hleclipseDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hleclipseOwner = "None" Then
                'Press E on hleclipse Door
                If playerCash > hleclipseCost Then
                    WriteCfgValue("ETHLowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - hleclipseCost)
                    hleclipseOwner = playerName
                    hleclipseBlip.Remove()
                    CreateHLEclipseTower()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~日蝕大樓公寓3"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Eclipse Tower Apartment 3"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hleclipseSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hleclipseOwner = playerName Then
                'Press E on hleclipse Bed
                playerMap = "EclipseHL"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso hleclipseExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hleclipseOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = hleclipseTowerTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso hleclipseExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso hleclipseOwner = playerName Then
                WriteCfgValue("ETHLowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + hleclipseCost)
                hleclipseOwner = "None"
                hleclipseBlip.Remove()
                CreateHLEclipseTower()
                Game.Player.Character.Position = hleclipseTowerTeleport2
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
                hleclipseBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
