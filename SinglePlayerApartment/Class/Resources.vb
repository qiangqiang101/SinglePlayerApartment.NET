Imports System.Drawing
Imports System.Windows.Forms
Imports GTA
Imports GTA.Native

Public Class Resources

    Public Shared Function GetHashKey(ByVal s As String) As Integer
        Dim Args As InputArgument() = New InputArgument() {s}
        Return Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, Args)
    End Function

    Public Shared Function Create_Vehicle(vh As Integer, x As Single, y As Single, z As Single, h As Single, retNetHandle As Boolean, retHandle As Boolean) As Vehicle
        Return Native.Function.Call(Of Vehicle)(Hash.CREATE_VEHICLE, vh, x, y, z, h, retNetHandle, retHandle)
    End Function

    Public Shared Function GetVehiclePrice(file As String) As Integer
        Dim VehModel As String = ReadCfgValue("VehicleModel", file)
        Dim VehPrice As Integer
        Select Case VehModel
            Case "Felon2", "Sentinel2"
                VehPrice = 9500
            Case "Baller", "Felon"
                VehPrice = 9000
            Case "Mesa3", "Rocoto"
                VehPrice = 8500
            Case "Oracle"
                VehPrice = 8200
            Case "Oracle2", "Schwarzer", "F620"
                VehPrice = 8000
            Case "Cavalcade", "Dubsta"
                VehPrice = 7000
            Case "Schafter", "Zion2"
                VehPrice = 6500
            Case "Zion"
                VehPrice = 6200
            Case "Serrano", "Jackal", "Sentinel"
                VehPrice = 6000
            Case "Landstalker"
                VehPrice = 5800
            Case "Tailgater"
                VehPrice = 5500
            Case "Fq2", "Patriot"
                VehPrice = 5000
            Case "Sandking2", "Sandking"
                VehPrice = 4500
            Case "Habanero"
                VehPrice = 4200
            Case "Surge"
                VehPrice = 3800
            Case "Fusilade"
                VehPrice = 3600
            Case "Buffalo", "Granger", "Dominator", "Sadler"
                VehPrice = 3500
            Case "Gauntlet", "Radius"
                VehPrice = 3200
            Case "Bison", "Mesa", "Seminole", "Tornado", "Minivan"
                VehPrice = 3000
            Case "Gresley"
                VehPrice = 2900
            Case "Buccaneer"
                VehPrice = 2800
            Case "BJXL"
                VehPrice = 2700
            Case "Asterope"
                VehPrice = 2600
            Case "Prairie", "Dilettante"
                VehPrice = 2500
            Case "Fugitive", "Penumbra"
                VehPrice = 2400
            Case "BobcatXL"
                VehPrice = 2300
            Case "Vigero"
                VehPrice = 2100
            Case "Phoenix", "Daemon"
                VehPrice = 2000
            Case "Issi2"
                VehPrice = 1800
            Case "BfInjection", "Youga", "Blista", "Intruder", "Bagger"
                VehPrice = 1600
            Case "Washington", "Duneloader", "SabreGT", "Speedo"
                VehPrice = 1500
            Case "Rumpo"
                VehPrice = 1300
            Case "Asea", "Sultan", "Nemesis", "Peyote"
                VehPrice = 1200
            Case "Premier", "Ruiner", "Ruffian", "Stanier", "Stratum"
                VehPrice = 1000
            Case "Primo", "Picador", "RancherXL", "Futo", "PCJ", "Vader", "Ingot"
                VehPrice = 900
            Case "Blazer", "Emperor", "Manana", "Regina"
                VehPrice = 800
            Case "Rebel", "Sanchez", "Sanchez2"
                VehPrice = 700
            Case "Surfer", "Voodoo", "Faggio"
                VehPrice = 500
            Case Else
                VehPrice = 0
        End Select
        Return VehPrice
    End Function

    Public Enum GTAFont
        ' Fields
        Pricedown = 7
        Script = 1
        Symbols = 3
        Symbols2 = 5
        Title = 4
        Title2 = 6
        TitleWSymbols = 2
        UIDefault = 0
    End Enum

    Public Enum GTAFontAlign
        ' Fields
        Center = 1
        Left = 0
        Right = 2
    End Enum

    Public Enum GTAFontStyleOptions
        ' Fields
        DropShadow = 1
        None = 0
        Outline = 2
    End Enum

    Public Shared Sub DrawText(ByVal [Text] As String, ByVal Position As PointF, ByVal Scale As Single, ByVal color As Color, ByVal Font As GTAFont, ByVal Alignment As GTAFontAlign, ByVal Options As GTAFontStyleOptions)
        Dim arguments As InputArgument() = New InputArgument() {Font}
        Native.Function.Call(Hash._0x66E0276CC5F6B9DA, arguments)
        Dim argumentArray2 As InputArgument() = New InputArgument() {1.0!, Scale}
        Native.Function.Call(Hash._0x07C837F9A01C34C9, argumentArray2)
        Dim argumentArray3 As InputArgument() = New InputArgument() {color.R, color.G, color.B, color.A}
        Native.Function.Call(Hash._0xBE6B23FFA53FB442, argumentArray3)
        If Options.HasFlag(GTAFontStyleOptions.DropShadow) Then
            Native.Function.Call(Hash._0x1CA3E9EAC9D93E5E, New InputArgument(0 - 1) {})
        End If
        If Options.HasFlag(GTAFontStyleOptions.Outline) Then
            Native.Function.Call(Hash._0x2513DFB0FB8400FE, New InputArgument(0 - 1) {})
        End If
        If Alignment.HasFlag(GTAFontAlign.Center) Then
            Dim argumentArray4 As InputArgument() = New InputArgument() {1}
            Native.Function.Call(Hash._0xC02F4DBFB51D988B, argumentArray4)
        ElseIf Alignment.HasFlag(GTAFontAlign.Right) Then
            Dim argumentArray5 As InputArgument() = New InputArgument() {1}
            Native.Function.Call(Hash._0x6B3C4650BC8BEE47, argumentArray5)
        End If
        Dim argumentArray6 As InputArgument() = New InputArgument() {"jamyfafi"}
        Native.Function.Call(Hash._0x25FBB336DF1804CB, argumentArray6)
        PushBigString([Text])
        Dim argumentArray7 As InputArgument() = New InputArgument() {(Position.X / 1280.0!), (Position.Y / 720.0!)}
        Native.Function.Call(Hash._0xCD015E5BB0D96A57, argumentArray7)
    End Sub

    Public Shared Sub PushBigString(ByVal [Text] As String)
        Dim strArray As String() = SplitStringEveryNth([Text], &H63)
        Dim i As Integer
        For i = 0 To strArray.Length - 1
            Dim arguments As InputArgument() = New InputArgument() {[Text].Substring((i * &H63), strArray(i).Length)}
            Native.Function.Call(Hash._0x6C188BE134E074AA, arguments)
        Next i
    End Sub

    Private Shared Function SplitStringEveryNth(ByVal [text] As String, ByVal Nth As Integer) As String()
        Dim list As New List(Of String)
        Dim item As String = ""
        Dim num As Integer = 0
        Dim i As Integer
        For i = 0 To [text].Length - 1
            item = (item & [text].Chars(i).ToString)
            num += 1
            If ((i <> 0) AndAlso (num = Nth)) Then
                list.Add(item)
                item = ""
                num = 0
            End If
        Next i
        If (item <> "") Then
            list.Add(item)
        End If
        Return list.ToArray
    End Function

End Class
