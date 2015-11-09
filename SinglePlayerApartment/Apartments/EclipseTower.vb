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

Public Class EclipseTower
    Inherits Script

    Public Shared eclipseOwner As String = ReadCfgValue("ETowner", saveFile)
    Public Shared eclipseCost As Integer = 400000
    Public Shared eclipseBlip As Blip
    Public Shared eclipseTower As Vector3 = New Vector3(-770.258, 313.033, 85.6981)
    Public Shared eclipseTowerSave As Vector3 = New Vector3(-795.527, 337.415, 201.413)
    Public Shared eclipseTowerTeleport As Vector3 = New Vector3(-780.152, 340.443, 207.621)
    Public Shared eclipseTowerTeleport2 As Vector3 = New Vector3(-773.282, 312.275, 84.698)
    Public Shared eclipseTowerExit As Vector3 = New Vector3(-777.584, 340.172, 207.621)
    Public Shared eclipseDoorDistance As Single
    Public Shared eclipseSaveDistance As Single
    Public Shared eclipseExitDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateEclipseTower()
        eclipseBlip = World.CreateBlip(eclipseTower)
        If eclipseOwner = "Michael" Then
            eclipseBlip.Sprite = BlipSprite.Safehouse
            eclipseBlip.Color = BlipColor.Blue
            eclipseBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 日蝕大樓公寓8", eclipseBlip)
            Else
                SetBlipName("Property: Eclipse Tower Apartment 8", eclipseBlip)
            End If
        ElseIf eclipseOwner = "Franklin" Then
            eclipseBlip.Sprite = BlipSprite.Safehouse
            eclipseBlip.Color = BlipColor.Green
            eclipseBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 日蝕大樓公寓8", eclipseBlip)
            Else
                SetBlipName("Property: Eclipse Tower Apartment 8", eclipseBlip)
            End If
        ElseIf eclipseOwner = "Trevor" Then
            eclipseBlip.Sprite = BlipSprite.Safehouse
            eclipseBlip.Color = 17
            eclipseBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 日蝕大樓公寓8", eclipseBlip)
            Else
                SetBlipName("Property: Eclipse Tower Apartment 8", eclipseBlip)
            End If
        Else
            eclipseBlip.Sprite = BlipSprite.SafehouseForSale
            eclipseBlip.Color = BlipColor.White
            eclipseBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", eclipseBlip)
            Else
                SetBlipName("Property For Sale", eclipseBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            eclipseDoorDistance = World.GetDistance(playerPed.Position, eclipseTower)
            eclipseSaveDistance = World.GetDistance(playerPed.Position, eclipseTowerSave)
            eclipseExitDistance = World.GetDistance(playerPed.Position, eclipseTowerExit)

            'Enter Eclipse Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso eclipseDoorDistance < 3.0 AndAlso eclipseOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 400000 元買日蝕大樓公寓8。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Eclipse Tower Apartment 8 for $400,000.")
                End If
            ElseIf Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso eclipseDoorDistance < 2.0 AndAlso eclipseOwner = playerName Then
                SetInteriorActive2(-795.04, 342.37, 206.22) 'eclipse tower 5
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = eclipseTowerTeleport
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            'Save Game
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso eclipseSaveDistance < 3.0 AndAlso eclipseOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed.")
                End If
            End If

            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso eclipseExitDistance < 2.0 AndAlso eclipseOwner = playerName Then
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
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso eclipseDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso eclipseOwner = "None" Then
                'Press E on Eclipse Door
                If playerCash > eclipseCost Then
                    WriteCfgValue("ETowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - eclipseCost)
                    eclipseOwner = playerName
                    eclipseBlip.Remove()
                    CreateEclipseTower()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~日蝕大樓公寓8"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Eclipse Tower Apartment 8"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)

                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso eclipseSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso eclipseOwner = playerName Then
                'Press E on Eclipse Bed
                playerMap = "Eclipse"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso eclipseExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso eclipseOwner = playerName Then
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                Game.Player.Character.Position = eclipseTowerTeleport2
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso eclipseExitDistance < 2.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso eclipseOwner = playerName Then
                WriteCfgValue("ETowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + eclipseCost)
                eclipseOwner = "None"
                eclipseBlip.Remove()
                CreateEclipseTower()
                Game.Player.Character.Position = eclipseTowerTeleport2
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
                eclipseBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
