Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports GTA
Imports GTA.Native
Imports GTA.Math

Public Class Resources

    Public Shared Function GetHashKey(ByVal s As String) As Integer
        Dim Args As InputArgument() = New InputArgument() {s}
        Return Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, Args)
    End Function

    Public Shared Function Create_Vehicle(vh As Integer, x As Single, y As Single, z As Single, h As Single, retNetHandle As Boolean, retHandle As Boolean) As Vehicle
        Dim vhModel = New Model(vh)
        vhModel.Request(500)
        If (vhModel.IsInCdImage AndAlso vhModel.IsValid) Then
            While (Not vhModel.IsLoaded)
                Script.Wait(100)
            End While
            Return Native.Function.Call(Of Vehicle)(Hash.CREATE_VEHICLE, vhModel.Hash, x, y, z, h, retNetHandle, retHandle)
        End If
        vhModel.MarkAsNoLongerNeeded()
    End Function

    Public Shared Function GetVehiclePrice(file As String) As Integer
        Dim VehModel As String = ReadCfgValue("VehicleModel", file)
        Dim VehPrice As Integer
        Select Case VehModel
            Case "Dukes2", "Vacca", "Dukes", "Dubsta3", "Marshall", "Cognoscenti", "Superd", "Massacro", "Jester", "Baller4"
                VehPrice = 139500
            Case "Guardian", "Baller5", "Coquette2", "Faction2", "Tampa", "Massacro2", "Jester2"
                VehPrice = 187500
            Case "Kuruma2"
                VehPrice = 262500
            Case "Insurgent2", "Casco", "Cheetah", "Vindicator", "Lurcher", "Coquette3", "Brawler"
                VehPrice = 337500
            Case "Schafter5"
                VehPrice = 162500
            Case "Schafter6", "Infernus", "Voodoo", "Furoregt"
                VehPrice = 219000
            Case "Cognoscenti2", "Btype2", "Nightshade"
                VehPrice = 279000
            Case "Baller6", "Monroe", "Jb700", "Turismor"
                VehPrice = 256500
            Case "Limo2"
                VehPrice = 825000
            Case "Mamba", "Feltzer3"
                VehPrice = 497500
            Case "Pigalle", "Buccaneer2", "Chino2", "Moonbeam2", "Primo2"
                VehPrice = 200000
            Case "Btype", "Entityxf", "Zentorno", "Lectro", "Monster", "Verlierer2"
                VehPrice = 375000
            Case "Ztype"
                VehPrice = 5000000
            Case "Stingergt", "Stinger", "Adder"
                VehPrice = 550000
            Case "Blista2", "Blista3", "Carbonrs", "Enduro", "Slamvan", "Kalahari", "Paradise", "Boxville2"
                VehPrice = 21000
            Case "Rhapsody", "Bullet", "Voltic", "Blade", "Cog55", "Alpha", "Rapidgt2", "Rapidgt", "Feltzer2", "Coquette", "Baller3"
                VehPrice = 70000
            Case "Panto", "F620", "Innovation", "Hakuchou", "Buffalo3", "Hotknife", "Kuruma", "Surano", "Banshee", "Baller2"
                VehPrice = 42500
            Case "Cogcabrio", "Virgo", "Carbonizzare", "Huntley"
                VehPrice = 92500
            Case "Exemplar", "Chino", "Glendale", "Schafter4"
                VehPrice = 102500
            Case "Windsor"
                VehPrice = 422500
            Case "Osiris"
                VehPrice = 975000
            Case "T20"
                VehPrice = 1100000
            Case "Thrust", "Stalion2", "Stalion", "Bifta", "Blazer3", "Schafter2", "Gburrito2"
                VehPrice = 37500
            Case "Sovereign", "Warrener", "Schafter3", "ninef2", "ninef"
                VehPrice = 60000
            Case "Faction", "Ratloader2", "Moonbeam"
                VehPrice = 18000
            Case "Bodhi2", "Romero", "Stretch"
                VehPrice = 12500
            Case "Khamelion", "Comet2", "Buffalo2"
                VehPrice = 50000
            Case "Dubsta2"
                VehPrice = 82500
            Case "Felon2", "Sentinel2", "Dune", "Camper"
                VehPrice = 9500
            Case "Baller", "Felon"
                VehPrice = 9000
            Case "Mesa3", "Rocoto"
                VehPrice = 8500
            Case "Oracle"
                VehPrice = 8200
            Case "Oracle2", "Schwarzer", "F620"
                VehPrice = 8000
            Case "Cavalcade", "Dubsta", "Bati2", "Hexer", "Dloader", "Calvlcade2", "Journey", "Burrito3"
                VehPrice = 7000
            Case "Schafter", "Zion2", "Pony"
                VehPrice = 6500
            Case "Zion"
                VehPrice = 6200
            Case "Serrano", "Jackal", "Sentinel", "Double"
                VehPrice = 6000
            Case "Landstalker"
                VehPrice = 5800
            Case "Tailgater"
                VehPrice = 5500
            Case "Fq2", "Patriot", "Bati"
                VehPrice = 5000
            Case "Sandking2", "Sandking", "Akuma"
                VehPrice = 4500
            Case "Habanero"
                VehPrice = 4200
            Case "Surge"
                VehPrice = 3800
            Case "Fusilade"
                VehPrice = 3600
            Case "Buffalo", "Granger", "Dominator", "Sadler", "Dominator2"
                VehPrice = 3500
            Case "Gauntlet", "Gauntlet2", "Radius", "Radi"
                VehPrice = 3200
            Case "Bison", "Mesa", "Seminole", "Tornado", "Minivan", "Tornado2"
                VehPrice = 3000
            Case "Gresley"
                VehPrice = 2900
            Case "Buccaneer"
                VehPrice = 2800
            Case "BJXL"
                VehPrice = 2700
            Case "Asterope"
                VehPrice = 2600
            Case "Prairie", "Dilettante", "Voodoo2", "Caddy2"
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
            Case "Primo", "Picador", "RancherXL", "Futo", "PCJ", "Vader", "Ingot", "Blazer2"
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

    <StructLayout(LayoutKind.Explicit)>
    Public Structure UnionInt32
        <FieldOffset(0)>
        Public IntValue As Int32
        <FieldOffset(0)>
        Public UIntValue As UInt32
    End Structure

    Public Shared Function GetModelFromHash(Vehicle As Vehicle) As String
        Try
            Dim Result As String = Nothing
            Dim VhNames As Array = GTA.Native.VehicleHash.GetNames(GetType(VehicleHash))
            Dim VhHash As Array = GTA.Native.VehicleHash.GetValues(GetType(VehicleHash))
            Dim tmpUint As UnionInt32
            tmpUint.IntValue = Game.Player.Character.CurrentVehicle.Model.Hash
            Dim UIntVal As UInt32 = tmpUint.UIntValue

            For i = 0 To UBound(VhHash)
                If VhHash(i) = UIntVal Then
                    Result = VhNames(i)
                    Exit For
                End If
            Next
            Return Result
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Function

    Public Shared Function GetVehicleInteriorTrimColor(Vehicle As Vehicle) As Integer
        Dim arg As New OutputArgument()
        If My.Settings.HasLowriderUpdate = True Then
            Native.Function.Call(&H7D1464D472D32136L, Vehicle.Handle, arg)
        Else
            Return 0
        End If
        Return arg.GetResult(Of Integer)()
    End Function

    Public Shared Function GetVehicleInteriorDashboardColor(Vehicle As Vehicle) As Integer
        Dim arg As New OutputArgument()
        If My.Settings.HasLowriderUpdate = True Then
            Native.Function.Call(&HB7635E80A5C31BFFUL, Vehicle.Handle, arg)
        Else
            Return 0
        End If
        Return arg.GetResult(Of Integer)()
    End Function

    Public Shared Function GetVehicleClass(Vehicle As Vehicle) As String
        Dim Result As String = Nothing
        Select Case Vehicle.ClassType
            Case VehicleClass.Boats, VehicleClass.Helicopters, VehicleClass.Planes, VehicleClass.Military, VehicleClass.Service, VehicleClass.Industrial, VehicleClass.Commercial
                Result = "Pegasus"
            Case VehicleClass.Cycles
                Result = "BikeRack"
            Case VehicleClass.Utility, VehicleClass.Vans, VehicleClass.OffRoad, VehicleClass.Motorcycles, VehicleClass.Emergency, VehicleClass.Super, VehicleClass.SUVs, VehicleClass.Compacts, VehicleClass.Coupes, VehicleClass.Muscle, VehicleClass.Sedans, VehicleClass.SportsClassics, VehicleClass.Sports
                Result = "Garage"
        End Select
        Return Result
    End Function

    Public Shared Sub TaskPlayAnim(ByVal ped As Ped, ByVal animDict As String, ByVal animFile As String, ByVal duration As Integer)
        Native.Function.Call(Hash._0xD3BD40951412FEF6, New InputArgument() {animDict})
        Dim time As DateTime = (DateTime.Now + New TimeSpan(0, 0, 0, 0, &H3E8))
Label_005C:
        If Not Native.Function.Call(Of Boolean)(Hash._0xD031A9162D01088C, New InputArgument() {animDict}) Then
            Script.Yield()

            If (DateTime.Now >= time) Then
                Return
            End If
            GoTo Label_005C
        End If
        Native.Function.Call(Hash._0xEA47FE3719165B94, New InputArgument() {ped, animDict, animFile, 8.0, -4.0, duration, 8, 0, 0, 0, 0})
    End Sub

    Public Shared Sub TaskPlayAnimLoop(ByVal ped As Ped, ByVal animDict As String, ByVal animFile As String, ByVal duration As Integer)
        Native.Function.Call(Hash._0xD3BD40951412FEF6, New InputArgument() {animDict})
        Dim time As DateTime = (DateTime.Now + New TimeSpan(0, 0, 0, 0, &H3E8))
Label_005C:
        If Not Native.Function.Call(Of Boolean)(Hash._0xD031A9162D01088C, New InputArgument() {animDict}) Then
            Script.Yield()

            If (DateTime.Now >= time) Then
                Return
            End If
            GoTo Label_005C
        End If
        Native.Function.Call(Hash._0xEA47FE3719165B94, New InputArgument() {ped, animDict, animFile, 8.0, -4.0, duration, 9, 0, 0, 0, 0})
    End Sub

    Public Shared Sub Disable_Controls(Yes As Boolean)
        If Yes = True Then
            Game.DisableControl(0, GTA.Control.Jump)
            Game.DisableControl(0, GTA.Control.Attack)
            Game.DisableControl(0, GTA.Control.Attack2)
            Game.DisableControl(0, GTA.Control.Aim)
            Game.DisableControl(0, GTA.Control.NextWeapon)
            Game.DisableControl(0, GTA.Control.PrevWeapon)
            Game.DisableControl(0, GTA.Control.MeleeAttack1)
            Game.DisableControl(0, GTA.Control.MeleeAttack2)
            Game.DisableControl(0, GTA.Control.MeleeAttackAlternate)
            Game.DisableControl(0, GTA.Control.MeleeAttackHeavy)
            Game.DisableControl(0, GTA.Control.MeleeAttackLight)
            SinglePlayerApartment.playerPed.CanSwitchWeapons = False
        Else
            SinglePlayerApartment.playerPed.CanSwitchWeapons = True
        End If
    End Sub

    Public Shared Function GetPlayerZoneForPlane(PlayerPed As Ped) As Vector3
        Dim ZoneID As String = Native.Function.Call(Of String)(Hash.GET_NAME_OF_ZONE, PlayerPed.Position.X, PlayerPed.Position.Y, PlayerPed.Position.Z)
        Dim result As Vector3
        Select Case ZoneID
            'LSIA
            Case "AIRP", "ALTA", "BANHAMC", "BANNING", "BEACH", "BHAMCA", "BURTON", "CHAMH", "CHU", "CYPRE", "DAVIS", "DELBE", "DELPE", "DELSOL", "DOWNT", "DTVINE", "EAST_V",
                 "EBURO", "ELYSIAN", "golf", "HAWICK", "KOREAT", "LEGSQU", "LMESA", "LOSPUER", "MORN", "MOVIE", "MURRI", "OCEANA", "PALHIGH", "PBLUFF", "PBOX", "RANCHO", "RGLEN",
                 "RICHM", "ROCKF", "SKID", "STAD", "STRAW", "TERMINA", "TEXTI", "VCANA", "VESP", "VINE", "WVINE", "ZP_ORT"
                result = New Vector3(-1654.722, -3146.974, 13.75746)
            'Grapeseed
            Case "ALAMO", "GRAPES", "BRADP", "BRADT", "CMSW", "ELGORL", "GALFISH", "HUMLAB", "MTCHIL", "MTGORDO", "PALCOV", "PALETO", "PALFOR", "PROCOB", "SanAnd"
                result = New Vector3(2121.428, 4801.944, 40.12399)
            'Grand Senora Desert
            Case "DESRT", "CALAFB", "CANNY", "CCREAK", "CHIL", "ARMYB", "GREATC", "HARMO", "HORS", "JAIL", "LACT", "LAGO", "LDAM", "MIRR", "MTJOSE", "NCHU", "NOOSE", "PALMPOW",
                 "RTRAK", "SANCHIA", "SANDY", "SLAB", "TATAMO", "TONGVAH", "TONGVAV", "WINDF", "ZANCUDO", "ZQ_UAR"
                result = New Vector3(1696.547, 3250.32, 41.91827)
            Case Else
                result = PlayerPed.Position
        End Select
        Return result
    End Function

    Public Shared Function GetPlayerZoneForBoat(PlayerPed As Ped) As Vector3
        Dim ZoneID As String = Native.Function.Call(Of String)(Hash.GET_NAME_OF_ZONE, PlayerPed.Position.X, PlayerPed.Position.Y, PlayerPed.Position.Z)
        Dim result As Vector3
        Select Case ZoneID
            'Puerto Del Sol Marina
            Case "AIRP", "ALTA", "DOWNT", "DTVINE", "PBOX", "TEXTI", "SKID", "VINE", "HAWICK", "HORS", "LEGSQU", "LMESA", "OCEANA", "WVINE", "DELSOL"
                result = New Vector3(-806.1055, -1418.486, 0.05737)
            'Galilee/Alamo Sea
            Case "ALAMO", "GALFISH", "CALAFB", "SLAB", "SANDY", "GRAPES", "DESRT", "HARMO", "HUMLAB", "RTRAK", "SANCHIA"
                result = New Vector3(1309.472, 4220.357, 30.59586)
            'Fort Zancudo
            Case "ARMYB", "GREATC", "LAGO", "ZANCUDO"
                result = New Vector3(-2793.24, 2993.928, 0.325136)
            'Chumash
            Case "BANHAMC", "BHAMCA", "CHU", "RGLEN", "TONGVAH", "TONGVAV"
                result = New Vector3(-3426.098, 946.6072, 0.265534)
            'Banning
            Case "BANNING", "RANCHO", "DAVIS", "STAD"
                result = New Vector3(-71.40706, -2278.731, -1.8116798)
            'Vespucci Beach
            Case "BEACH", "LOSPUER", "VCANA", "KOREAT", "CHAMH", "STRAW", "VESP"
                result = New Vector3(-1455.539, -1582.167, 2.106417)
            'Procopio Beach
            Case "BRADP", "PROCOB", "MTGORDO", "ELGORL", "MTCHIL", "BRADT", "SanAnd"
                result = New Vector3(1530.962, 6669.952, 1.560777)
            'Del Perro Beach
            Case "DELBE", "BURTON", "DELPE", "MOVIE", "MORN", "ROCKF", "EAST_V"
                result = New Vector3(-1964.126, -769.2186, 0.857546)
            'Cassidy Creek
            Case "CCREAK", "CANNY"
                result = New Vector3(-227.2128, 4347.626, 29.81935)
            'Pacific Bluffs
            Case "CHIL", "PBLUFF", "RICHM", "golf"
                result = New Vector3(-2409.3, -361.9779, 0.422128)
            'Paleto Cove
            Case "CMSW", "PALCOV", "PALFOR"
                result = New Vector3(-1594.215, 5242.16, 0.055142)
            'Cypress Flats
            Case "EBURO", "CYPRE", "MURRI"
                result = New Vector3(652.9036, -1845.649, 8.01015)
            'Elysian Island
            Case "ELYSIAN", "TERMINA", "ZP_ORT"
                result = New Vector3(-87.24967, -2758.894, 0.025953)
            'Tataviam Mountains
            Case "TATAMO", "JAIL", "LACT", "PALMPOW", "WINDF", "ZQ_UAR", "LDAM", "NOOSE", "MIRR"
                result = New Vector3(2964.583, 652.6611, 0.759929)
            'North Chumash
            Case "MTJOSE", "NCHU"
                result = New Vector3(-2111.801, 4636.586, -1.9802314)
            'Paleto Bay
            Case "PALETO"
                result = New Vector3(-288.9354, 6621.431, 0.910775)
            'Palomino Highlands
            Case "PALHIGH"
                result = New Vector3(2322.33, -2155.006, 0.389739)
            Case Else
                result = PlayerPed.Position
        End Select
        Return result
    End Function

    Public Shared Function GetPlayerZoneForHeli(PlayerPed As Ped) As Vector3
        Dim ZoneID As String = Native.Function.Call(Of String)(Hash.GET_NAME_OF_ZONE, PlayerPed.Position.X, PlayerPed.Position.Y, PlayerPed.Position.Z)
        Dim result As Vector3
        Select Case ZoneID
            'LSIA
            Case "AIRP", "ELYSIAN", "OCEANA", "TERMINA", "ZP_ORT"
                result = New Vector3(-1178.293, -2845.899, 12.94576)
            'Vespucci Heli Pad
            Case "BANNING", "BEACH", "CHAMH", "CHU", "DELBE", "DELPE", "DELSOL", "golf", "KOREAT", "LOSPUER", "MORN", "MOVIE", "PBLUFF", "RGLEN", "RICHM", "STAD", "TONGVAH", "TONGVAV", "VCANA", "VESP"
                result = New Vector3(-722.3428, -1472.542, 4.000524)
            'Hospital @ Davis
            Case "CYPRE", "DAVIS", "EBURO", "MURRI", "PBOX", "RANCHO", "SKID", "STRAW"
                result = New Vector3(313.2356, -1465.333, 45.5095)
            'Police Station @ Downtown Vinewood
            Case "ALTA", "CHIL", "DTVINE", "EAST_V", "HAWICK", "HORS", "VINE", "WVINE"
                result = New Vector3(579.8596, 12.57191, 102.2336)
            'NOOSE
            Case "LACT", "LDAM", "NOOSE", "PALHIGH", "PALMPOW", "TATAMO"
                result = New Vector3(2511.164, -426.7032, 117.1887)
            'Sandy Shores Airfield @ Grand Serona Desert
            Case "ARMYB", "CALAFB", "CANNY", "CCREAK", "DESRT", "GREATC", "HARMO", "JAIL", "MTJOSE", "RTRAK", "SANDY", "SLAB", "WINDF", "ZANCUDO", "ZQ_UAR"
                result = New Vector3(1770.233, 3239.768, 41.125)
            'McKenzie Airfield @ Grapeseed
            Case "ALAMO", "BRADP", "BRADT", "ELGORL", "GALFISH", "GRAPES", "HUMLAB", "MTGORDO", "SanAnd", "SANCHIA"
                result = New Vector3(2141.6, 4823.045, 40.26807)
            'Hospital @ Paleto Forest
            Case "BANHAMC", "BHAMCA", "CMSW", "LAGO", "MTCHIL", "NCHU", "PALCOV", "PALETO", "PALFOR", "PROCOB"
                result = New Vector3(-475.2378, 5988.641, 30.3367)
            'Davis Globe International @ Downtown
            Case "BURTON", "DOWNT", "LEGSQU", "LMESA", "MIRR", "ROCKF", "TEXTI"
                result = New Vector3(-286.2998, -618.0687, 49.33288)
            Case Else
                result = PlayerPed.Position
        End Select
        Return result
    End Function

    Public Shared Sub CreateFile(vehFileName As String)
        Select Case My.Settings.CreateFileMethod
            Case 1
                IO.File.WriteAllText(vehFileName, My.Resources.vehicle)
            Case 2
                Dim Cfile = IO.File.Create(vehFileName)
                Cfile.Close()
            Case 3
                IO.File.Copy(Application.StartupPath & "\scripts\SinglePlayerApartment\vehicle.cfg", vehFileName)
            Case Else
                IO.File.WriteAllText(vehFileName, My.Resources.vehicle)
        End Select
    End Sub
End Class
