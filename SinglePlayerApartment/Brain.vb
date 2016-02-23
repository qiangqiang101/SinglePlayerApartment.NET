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

Public Class Brain
    'Inherits Script

    Public Shared Seat As Prop
    Public Shared SeatEntryCoords As Vector3
    Public Shared SeatModels As List(Of Model) = New List(Of Model) From {-1631057904, -171943901, &H6BA514AC, -403891623, &H1A117FD1, &H115D9EA5, &H8C198E9, -741944541}
    Public Shared SitAttachOffset As Single
    Public Shared SitDrink As Prop
    Public Shared SitDrinkTask As TaskSequence
    Public Shared SitEat As Prop
    Public Shared SitEatTask As TaskSequence
    Public Shared SittingAnimIndex As Integer
    Public Shared SittingTaskScriptStatus As Integer = -1

    Public Sub New()
        'AddHandler Tick, AddressOf OnTick
    End Sub

    Public Shared Sub InitTaskSequences()
        Native.Function.Call(Hash._0xD3BD40951412FEF6, New InputArgument() {"amb@prop_human_seat_chair_drink@male@generic@base"})
        Native.Function.Call(Hash._0xD3BD40951412FEF6, New InputArgument() {"amb@prop_human_seat_chair_drink@male@generic@idle_a"})
        Native.Function.Call(Hash._0xD3BD40951412FEF6, New InputArgument() {"amb@prop_human_seat_chair_food@male@base"})
        Native.Function.Call(Hash._0xD3BD40951412FEF6, New InputArgument() {"amb@prop_human_seat_chair_food@male@idle_a"})
        SitDrinkTask = New TaskSequence
        Native.Function.Call(Hash._0xEA47FE3719165B94, New InputArgument() {0, "amb@prop_human_seat_chair_drink@male@generic@base", "base", 8.0!, -4.0!, &H7D0, 9, 0!, 0, 0, 0})
        Native.Function.Call(Hash._0xEA47FE3719165B94, New InputArgument() {0, "amb@prop_human_seat_chair_drink@male@generic@idle_a", "idle_a", 8.0!, -4.0!, -1, 8, 0!, 0, 0, 0})
        SitDrinkTask.Close(True)
        SitEatTask = New TaskSequence
        Native.Function.Call(Hash._0xEA47FE3719165B94, New InputArgument() {0, "amb@prop_human_seat_chair_food@male@base", "base", 8.0!, -4.0!, &H7D0, 9, 0!, 0, 0, 0})
        Native.Function.Call(Hash._0xEA47FE3719165B94, New InputArgument() {0, "amb@prop_human_seat_chair_food@male@idle_a", "idle_a", 8.0!, -4.0!, -1, 8, 0!, 0, 0, 0})
        SitEatTask.Close(True)
    End Sub

    Public Shared Sub ChairOnTick()
        Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 25.0!)
        Dim i As Integer
        For i = 0 To nearbyProps.Length - 1
            If ((((SittingTaskScriptStatus = -1) AndAlso Not Game.Player.Character.IsInVehicle) AndAlso (Game.Player.WantedLevel = 0)) AndAlso (SeatModels.Contains(nearbyProps(i).Model) AndAlso (Game.Player.Character.Position.DistanceTo(nearbyProps(i).Position) <= 2.0!))) Then
                DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to sit down.")
                If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                    Seat = nearbyProps(i)
                    SittingTaskScriptStatus = 0
                End If
            End If
        Next i
        Select Case SittingTaskScriptStatus
            Case 0
                SeatEntryCoords = (Seat.Position + (Seat.ForwardVector * -0.9))
                Native.Function.Call(Hash._0xD76B57B44F1E6F8B, New InputArgument() {Game.Player.Character, SeatEntryCoords.X, SeatEntryCoords.Y, SeatEntryCoords.Z, 1, &H4E20, (Seat.Heading - 180.0!), 0.1})
                SittingTaskScriptStatus = 1
                GoTo Label_04C7
            Case 1
                If Native.Function.Call(Of Boolean)(Hash._0x20B60995556D004F, New InputArgument() {Game.Player.Character, SeatEntryCoords.X, SeatEntryCoords.Y, SeatEntryCoords.Z, 2, 2, 2, 0, 1, 0}) Then
                    Script.Wait(&H7D0)
                    Game.Player.Character.Heading = (Seat.Heading - 180.0!)
                    Resources.TaskPlayAnim(Game.Player.Character, "amb@prop_human_seat_chair@male@generic@enter", "enter_forward", -1)
                    SittingTaskScriptStatus = 2
                End If
                GoTo Label_04C7
            Case 2
                Dim hash As Integer = Seat.Model.Hash
                Select Case hash.ToString
                    Case "-1631057904"
                        SitAttachOffset = 0.48!
                        GoTo Label_0446
                    Case "-171943901"
                        SitAttachOffset = 0.04!
                        GoTo Label_0446
                    Case "1805980844"
                        SitAttachOffset = 0.5!
                        GoTo Label_0446
                    Case "-403891623"
                        SitAttachOffset = 0.5!
                        GoTo Label_0446
                    Case "437354449"
                        SitAttachOffset = 0.5!
                        GoTo Label_0446
                    Case "291348133"
                        SitAttachOffset = 0.05!
                        GoTo Label_0446
                    Case "146905321"
                        SitAttachOffset = 0.5!
                        GoTo Label_0446
                    Case "-741944541"
                        SitAttachOffset = 0.5!
                        GoTo Label_0446
                End Select
                Exit Select
            Case 3
                Script.Wait(500)
                Resources.TaskPlayAnimLoop(Game.Player.Character, "amb@prop_human_seat_chair@male@generic@base", "base", -1)
                SittingTaskScriptStatus = 4
                GoTo Label_04C7
            Case Else
                GoTo Label_04C7
        End Select
Label_0446:
        Script.Wait(&H3E8)
        Game.Player.Character.AttachTo(Seat, 0, New Vector3(0!, 0!, SitAttachOffset), New Vector3(0!, 0!, -180.0!))
        SittingTaskScriptStatus = 3
Label_04C7:
        If (SittingTaskScriptStatus <> 4) Then
            Return
        End If
        DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to cycle animations.~n~Press ~INPUT_CONTEXT~ to get up.")
        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
            If (SittingAnimIndex = 5) Then
                SitDrink.Delete()
            End If
            If (SittingAnimIndex = 6) Then
                SitEat.Delete()
            End If
            Resources.TaskPlayAnim(Game.Player.Character, "amb@prop_human_seat_chair@male@generic@exit", "exit_forward", -1)
            Script.Wait(800)
            Game.Player.Character.Detach()
            SittingAnimIndex = 0
            SittingTaskScriptStatus = -1
        End If
        If Game.IsControlJustPressed(0, GTA.Control.Cover) Then
            SittingAnimIndex += 1
            If (SittingAnimIndex = 7) Then
                SittingAnimIndex = 0
            End If
            Select Case SittingAnimIndex
                Case 0
                    SitEat.Delete()
                    Resources.TaskPlayAnimLoop(Game.Player.Character, "amb@prop_human_seat_chair@male@generic@base", "base", -1)
                    Exit Select
                Case 1
                    Resources.TaskPlayAnimLoop(Game.Player.Character, "amb@prop_human_seat_chair@male@left_elbow_on_knee@base", "base", -1)
                    Exit Select
                Case 2
                    Resources.TaskPlayAnimLoop(Game.Player.Character, "amb@prop_human_seat_chair@male@right_foot_out@base", "base", -1)
                    Exit Select
                Case 3
                    Resources.TaskPlayAnimLoop(Game.Player.Character, "amb@prop_human_seat_chair@male@recline_b@base_b", "base_b", -1)
                    Exit Select
                Case 4
                    Resources.TaskPlayAnimLoop(Game.Player.Character, "amb@prop_human_seat_chair@male@elbows_on_knees@base", "base", -1)
                    Exit Select
                Case 5
                    SitDrink = World.CreateProp("prop_ld_can_01b", Game.Player.Character.Position, True, True)
                    Native.Function.Call(Hash._0x6B9BBD38AB0796DF, New InputArgument() {SitDrink, Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 2, 1})
                    Game.Player.Character.Task.PerformSequence(SitDrinkTask)
                    Exit Select
                Case 6
                    SitDrink.Delete()
                    SitEat = World.CreateProp("p_amb_bagel_01", Game.Player.Character.Position, True, True)
                    Native.Function.Call(Hash._0x6B9BBD38AB0796DF, New InputArgument() {SitEat, Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 2, 1})
                    Game.Player.Character.Task.PerformSequence(SitEatTask)
                    Exit Select
            End Select
        End If
        If (Game.Player.IsDead OrElse Game.Player.Character.IsRagdoll) Then
            Game.Player.Character.Detach()
            SittingAnimIndex = 0
            SittingTaskScriptStatus = -1
        End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        ChairOnTick()
    End Sub

End Class
