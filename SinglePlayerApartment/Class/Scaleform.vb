Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class Scaleform

    Public Shared mHandle As Integer

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure SFArgSprite
        Public name As String
        Public Sub New(ByVal s As String)
            Me.name = s
        End Sub
    End Structure

    Public Shared Sub CallFunction(ByVal func As String, ByVal ParamArray arguments As Object())
        Dim argumentArray1 As InputArgument() = New InputArgument() {mHandle, func}
        Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, argumentArray1)
        Dim obj2 As Object
        For Each obj2 In arguments
            If TypeOf obj2 Is Integer Then
                Dim argumentArray2 As InputArgument() = New InputArgument() {CInt(obj2)}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, argumentArray2)
            ElseIf TypeOf obj2 Is String Then
                Dim argumentArray3 As InputArgument() = New InputArgument() {"STRING"}
                Native.Function.Call(Hash._BEGIN_TEXT_COMPONENT, argumentArray3)
                Dim argumentArray4 As InputArgument() = New InputArgument() {CStr(obj2)}
                Native.Function.Call(Hash._0x6C188BE134E074AA, argumentArray4)
                Native.Function.Call(Hash._END_TEXT_COMPONENT, New InputArgument(0 - 1) {})
            ElseIf TypeOf obj2 Is Char Then
                Dim argumentArray5 As InputArgument() = New InputArgument() {"STRING"}
                Native.Function.Call(Hash._BEGIN_TEXT_COMPONENT, argumentArray5)
                Dim argumentArray6 As InputArgument() = New InputArgument() {DirectCast(obj2, Char).ToString}
                Native.Function.Call(Hash._0x6C188BE134E074AA, argumentArray6)
                Native.Function.Call(Hash._END_TEXT_COMPONENT, New InputArgument(0 - 1) {})
            ElseIf TypeOf obj2 Is Single Then
                Dim argumentArray7 As InputArgument() = New InputArgument() {CSng(obj2)}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, argumentArray7)
            ElseIf TypeOf obj2 Is Double Then
                Dim argumentArray8 As InputArgument() = New InputArgument() {CSng(CDbl(obj2))}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, argumentArray8)
            ElseIf TypeOf obj2 Is Boolean Then
                Dim argumentArray9 As InputArgument() = New InputArgument() {CBool(obj2)}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL, argumentArray9)
            Else
                If Not TypeOf obj2 Is SFArgSprite Then
                    Throw New Exception(String.Format("Unknown argument type {0} passed", obj2.GetType.Name))
                End If
                Dim argumentArray10 As InputArgument() = New InputArgument() {DirectCast(obj2, SFArgSprite).name}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING, argumentArray10)
            End If
        Next
        Native.Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID, New InputArgument(0 - 1) {})
    End Sub

    Public Shared Function CallFunction(Of T)(ByVal func As String, ByVal ParamArray arguments As Object()) As T
        Dim argumentArray1 As InputArgument() = New InputArgument() {mHandle, func}
        Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, argumentArray1)
        Dim obj2 As Object
        For Each obj2 In arguments
            If TypeOf obj2 Is Integer Then
                Dim argumentArray2 As InputArgument() = New InputArgument() {CInt(obj2)}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, argumentArray2)
            ElseIf TypeOf obj2 Is String Then
                Dim argumentArray3 As InputArgument() = New InputArgument() {"STRING"}
                Native.Function.Call(Hash._BEGIN_TEXT_COMPONENT, argumentArray3)
                Dim argumentArray4 As InputArgument() = New InputArgument() {CStr(obj2)}
                Native.Function.Call(Hash._0x6C188BE134E074AA, argumentArray4)
                Native.Function.Call(Hash._END_TEXT_COMPONENT, New InputArgument(0 - 1) {})
            ElseIf TypeOf obj2 Is Char Then
                Dim argumentArray5 As InputArgument() = New InputArgument() {"STRING"}
                Native.Function.Call(Hash._BEGIN_TEXT_COMPONENT, argumentArray5)
                Dim argumentArray6 As InputArgument() = New InputArgument() {DirectCast(obj2, Char).ToString}
                Native.Function.Call(Hash._0x6C188BE134E074AA, argumentArray6)
                Native.Function.Call(Hash._END_TEXT_COMPONENT, New InputArgument(0 - 1) {})
            ElseIf TypeOf obj2 Is Single Then
                Dim argumentArray7 As InputArgument() = New InputArgument() {CSng(obj2)}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, argumentArray7)
            ElseIf TypeOf obj2 Is Double Then
                Dim argumentArray8 As InputArgument() = New InputArgument() {CSng(CDbl(obj2))}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, argumentArray8)
            ElseIf TypeOf obj2 Is Boolean Then
                Dim argumentArray9 As InputArgument() = New InputArgument() {CBool(obj2)}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL, argumentArray9)
            Else
                If Not TypeOf obj2 Is SFArgSprite Then
                    Throw New Exception(String.Format("Unknown argument type {0} passed", obj2.GetType.Name))
                End If
                Dim argumentArray10 As InputArgument() = New InputArgument() {DirectCast(obj2, SFArgSprite).name}
                Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING, argumentArray10)
            End If
        Next
        Return Native.Function.Call(Of T)(Hash._POP_SCALEFORM_MOVIE_FUNCTION, New InputArgument(0 - 1) {})
    End Function

    Public Sub DestroyScaleform()
        If (mHandle <> 0) Then
            Dim numRef As Integer = mHandle
            Dim arguments As InputArgument() = New InputArgument() {numRef}
            If Native.Function.Call(Of Boolean)(Hash.HAS_SCALEFORM_MOVIE_LOADED, arguments) Then
                Native.Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, arguments)
            End If
        End If
    End Sub

    Public Function LoadScaleform(ByVal Scaleform As String) As Boolean
        DestroyScaleform()
        Dim arguments As InputArgument() = New InputArgument() {Scaleform}
        mHandle = Native.Function.Call(Of Integer)(Hash.REQUEST_SCALEFORM_MOVIE, arguments)
        If (mHandle = 0) Then
            Return False
        End If
        Return True
    End Function

    Public Sub Render2D()
        Dim arguments As InputArgument() = New InputArgument() {mHandle, &HFF, &HFF, &HFF, &HFF}
        Native.Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN_MASKED, arguments)
    End Sub

    Public Sub Render2DScreenSpace(ByVal offset As PointF, ByVal size As PointF)
        Dim arguments As InputArgument() = New InputArgument() {mHandle, ((offset.X / 1280.0) + ((size.X / 1280.0) / 2.0)), ((offset.Y / 1280.0) + ((size.Y / 1280.0) / 2.0)), (size.X / 1280.0), (size.Y / 1280.0), &HFF, &HFF, &HFF, &HFF}
        Native.Function.Call(Hash.DRAW_SCALEFORM_MOVIE, arguments)
    End Sub

    Public Shared Sub Render3D(ByVal pos As Vector3, ByVal rot As Vector3, ByVal scale As Vector3, ByVal Optional textureSize As Single = 1.0)
        Dim num As Single = 2.8
        Dim position As Vector3 = GameplayCamera.Position
        If (World.RenderingCamera.Handle <> -1) Then
            position = World.RenderingCamera.Position
        End If
        Dim num2 As Single = Clamp((num - (pos.DistanceTo(position) / num)), 0.05, 1.0)
        Dim num3 As Single = ((Math.Max(scale.X, scale.Y) * num2) * textureSize)
        Dim num4 As Single = ((Math.Max(scale.X, scale.Y) * num2) * textureSize)
        Dim arguments As InputArgument() = New InputArgument() {mHandle, pos.X, pos.Y, pos.Z, rot.X, rot.Y, rot.Z, num3, num4, 1.0, scale.X, scale.Y, scale.Z, 2}
        Native.Function.Call(Hash._DRAW_SCALEFORM_MOVIE_3D_NON_ADDITIVE, arguments)
    End Sub

    Public Shared Sub Render3DAdditive(ByVal pos As Vector3, ByVal rot As Vector3, ByVal scale As Vector3, ByVal Optional textureQuality As Single = 1.0, ByVal Optional vectorArtQuality As Single = 1.0)
        Dim arguments As InputArgument() = New InputArgument() {mHandle, pos.X, pos.Y, pos.Z, rot.X, rot.Y, rot.Z, textureQuality, vectorArtQuality, 0, scale.X, scale.Y, scale.Z, 2}
        Native.Function.Call(Hash.DRAW_SCALEFORM_MOVIE_3D, arguments)
    End Sub

    Public Shared Function Clamp(ByVal value As Single, ByVal min As Single, ByVal max As Single) As Single
        If (value < min) Then
            value = min
            Return value
        End If
        If (value > max) Then
            value = max
        End If
        Return value
    End Function

    Public Shared Function LookAtCamera(ByVal from As Vector3) As Vector3
        Dim position As Vector3 = GameplayCamera.Position
        If (World.RenderingCamera.Handle <> -1) Then
            position = World.RenderingCamera.Position
        End If
        Dim num As Single = CSng(Math.Atan2(CDbl((position.Y - from.Y)), CDbl((position.X - from.X))))
        Return New Vector3(0, (RadToDeg((-num - 90.0)) + 38.0), 0)
    End Function

    Public Shared Function RadToDeg(ByVal radians As Single) As Single
        Return (radians * 57.29578)
    End Function

    Public Shared Sub CreateVehicleStats(Veh As Vehicle, Scaleforms As Scaleform)
        Dim handle As Vehicle = Veh
        Dim str As String = "MPCarHUD"
        Dim vehBrand As String = ""
        Dim label As String = ""
        Dim vehicleStats As Resources.VehicleStats = Resources.GetVehicleStats(handle)
        Dim arguments As Object() = New Object() {handle.FriendlyName, label, str, vehBrand, Game.GetGXTEntry("FMMC_VEHST_0"), Game.GetGXTEntry("FMMC_VEHST_1"), Game.GetGXTEntry("FMMC_VEHST_2"), Game.GetGXTEntry("FMMC_VEHST_3"), vehicleStats.TopSpeed * 100, vehicleStats.Acceleration * 100, vehicleStats.Braking * 100, vehicleStats.Traction * 100}
        CallFunction("SET_VEHICLE_INFOR_AND_STATS", arguments)
        Dim pos As Vector3 = (handle.Position + New Vector3(0, 0, 3))
        If handle.IsOnScreen Then
            Render3D(pos, LookAtCamera(pos), New Vector3(6, 3.5, 1), 1)
        End If
    End Sub

End Class
