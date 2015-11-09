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

Public Class RichmanMansion
    Inherits Script

    Public Shared richmanOwner As String = ReadCfgValue("RMMowner", saveFile)
    Public Shared richmanCost As Integer = 58000000
    Public Shared richmanBlip As Blip
    Public Shared richmanMansion As Vector3 = New Vector3(-1614.335, 77.1975, 61.5621)
    Public Shared richmanMansionSave As Vector3 = New Vector3(-1536.981, 130.6087, 57.3713)
    Public Shared richmanDoorDistance As Single
    Public Shared richmanSaveDistance As Single

    Public Sub New()
        Try
            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateRichmanMansion()
        richmanBlip = World.CreateBlip(richmanMansion)
        If richmanOwner = "Michael" Then
            richmanBlip.Sprite = BlipSprite.Safehouse
            richmanBlip.Color = BlipColor.Blue
            richmanBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 利金漫豪宅", richmanBlip)
            Else
                SetBlipName("Property: Richman Mansion", richmanBlip)
            End If
        ElseIf richmanOwner = "Franklin" Then
            richmanBlip.Sprite = BlipSprite.Safehouse
            richmanBlip.Color = BlipColor.Green
            richmanBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 利金漫豪宅", richmanBlip)
            Else
                SetBlipName("Property: Richman Mansion", richmanBlip)
            End If
        ElseIf richmanOwner = "Trevor" Then
            richmanBlip.Sprite = BlipSprite.Safehouse
            richmanBlip.Color = 17
            richmanBlip.IsShortRange = False
            If uiLanguage = "Chinese" Then
                SetBlipName("產業: 利金漫豪宅", richmanBlip)
            Else
                SetBlipName("Property: Richman Mansion", richmanBlip)
            End If
        Else
            richmanBlip.Sprite = BlipSprite.SafehouseForSale
            richmanBlip.Color = BlipColor.White
            richmanBlip.IsShortRange = True
            If uiLanguage = "Chinese" Then
                SetBlipName("產業求售", richmanBlip)
            Else
                SetBlipName("Property For Sale", richmanBlip)
            End If
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            richmanDoorDistance = World.GetDistance(playerPed.Position, richmanMansion)
            richmanSaveDistance = World.GetDistance(playerPed.Position, richmanMansionSave)

            'Enter richman Tower
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso richmanDoorDistance < 3.0 AndAlso richmanOwner = "None" Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 花 10000000 元買利金漫豪宅。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Richman Mansion for $10,000,000.")
                End If
            End If

            'Save Game & sell property
            If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso richmanSaveDistance < 3.0 AndAlso richmanOwner = playerName Then
                If uiLanguage = "Chinese" Then
                    DisplayHelpTextThisFrame("按 ~INPUT_CONTEXT~ 儲存遊戲, 按 ~INPUT_DETONATE~ 出售產業。")
                Else
                    DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get into bed, Press ~INPUT_DETONATE~ to Sell Property.")
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try
            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso richmanDoorDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richmanOwner = "None" Then
                'Press E on richman Door
                If playerCash > richmanCost Then
                    WriteCfgValue("RMMowner", playerName, saveFile)
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    SinglePlayerApartment.player.Money = (playerCash - richmanCost)
                    richmanOwner = playerName
                    richmanBlip.Remove()
                    CreateRichmanMansion()
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    If uiLanguage = "Chinese" Then
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("已購買" & vbLf & "~w~利金漫豪宅"), "", 100, True, 0, True)
                    Else
                        _scaleform.CallFunction("SHOW_MISSION_PASSED_MESSAGE", String.Format("Property Purchased" & vbLf & "~w~Richman Mansion"), "", 100, True, 0, True)
                    End If
                    _displayTimer.Start()
                Else
                    UI.Notify("You have insufficient funds to purchase this property.", True)
                End If
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso richmanSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richmanOwner = playerName Then
                'Press E on richman Bed
                playerMap = "Richman"
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                TimeLapse(8)
                Game.ShowSaveMenu()
                SavePosition()
                Script.Wait(500)
                Game.FadeScreenIn(500)
            ElseIf Game.IsControlJustPressed(0, GTA.Control.Detonate) AndAlso richmanSaveDistance < 3.0 AndAlso Not playerPed.IsInVehicle AndAlso Not SinglePlayerApartment.player.IsDead AndAlso richmanOwner = playerName Then
                WriteCfgValue("RMMowner", "None", saveFile)
                SavePosition2()
                Game.FadeScreenOut(500)
                Script.Wait(&H3E8)
                SinglePlayerApartment.player.Money = (playerCash + richmanCost)
                richmanOwner = "None"
                richmanBlip.Remove()
                CreateRichmanMansion()
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
                richmanBlip.Remove()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
