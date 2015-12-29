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
    Inherits Script

    'Public IPLtoRemove As String
    'Public CurrentLine As String

    Public Sub New()

        AddHandler KeyDown, AddressOf OnKeyDown
        AddHandler Tick, AddressOf OnTick
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.F11 Then
        'IPLtoRemove = Game.GetUserInput(IPLtoRemove, 100)
        'If IPLtoRemove <> "" Then
        'Native.Function.Call(Hash.REMOVE_IPL, IPLtoRemove)
        'UI.ShowSubtitle(IPLtoRemove & " Removed")
        'End If
        'End If

        'If e.KeyCode = Keys.F5 Then
        'Dim IPLReader As IO.StreamReader = New IO.StreamReader(Application.StartupPath & "\scripts\SinglePlayerApartment\interior.txt")
        '
        'Dim strLine As String = IPLReader.ReadLine()
        'Do Until strLine Is Nothing
        'strLine = IPLReader.ReadLine()
        'Native.Function.Call(Hash.REMOVE_IPL, strLine)
        'UI.ShowSubtitle(strLine & " Removed")
        'Script.Wait(500)
        'Loop
        'IPLReader.Close()
        'End If
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_tv", 777010715, 100, 15.0, -1, 1) 'tv
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_tv", 1923965997, 100, 20.0, -1, 1) 'maybe channel

        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_bong", -342360182, 100, 4.0, -1, 1) 'bong
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_bong", 1874679314, 100, 4.0, -1, 1) 'another bong
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_franklin_wine", 757668998, 100, 10.0, -1, 1) 'red wine
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_wheatgrass", 469594741, 100, 4.0, -1, 1) 'green juice
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_drinking_shots", 2079380440, 100, 4.0, -1, 1) 'radio
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_mp_shower_med", 1924030334, 100, 4.0, -1, 1) 'shower

        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_sofa_michael", 3.0, 1)
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_sofa_franklin", 3.0, 1)
        'Native.Function.Call(Hash.REGISTER_OBJECT_SCRIPT_BRAIN, "ob_franklin_tv", 3.0, 1)
        'Native.Function.Call(Hash.REGISTER_WORLD_POINT_SCRIPT_BRAIN, "AM_MP_PROPERTY_EXT", 120.0, 8)


    End Sub

End Class
