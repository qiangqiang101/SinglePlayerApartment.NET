Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Text
Imports System.Media
Imports SinglePlayerApartment.INMNative

Public Class Resources

    Public Enum BlipColor2
        Franklin = 43
        Michael = 42
        Trevor = 44
    End Enum

    Public Enum PedComponentsVars
        COMPONET_FACE = 0
        COMPONET_HEAD = 1
        COMPONET_HAIR = 2
        COMPONET_TORSO = 3
        COMPONET_LEGS = 4
        COMPONET_HANDS = 5
        COMPONET_FEET = 6
        COMPONET_EYES = 7
        COMPONET_ACCESSORIES = 8
        COMPONET_TASKS = 9
        COMPONET_TEXTURES = 10
        COMPONET_TORSO2 = 11
    End Enum

    Public Enum PedPropsVars
        PROP_HATS = 0
        PROP_GLASSES = 1
        PROP_EARS = 2
    End Enum

    Public Shared Sub ShowXmasTree(Location As Vector3)
        If Not Website.PropXmasTree = Nothing Then
            Website.PropXmasTree.Delete()
            Website.PropXmasTree = World.CreateProp("prop_xmas_tree_int", New Vector3(Location.X, Location.Y, Location.Z - 1), False, False)
        Else
            Website.PropXmasTree = World.CreateProp("prop_xmas_tree_int", New Vector3(Location.X, Location.Y, Location.Z - 1), False, False)
        End If
    End Sub

    Public Shared Function GetHashKey(ByVal s As String) As Integer
        Dim Args As InputArgument() = New InputArgument() {s}
        Return Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, Args)
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure VehicleStats
        Public TopSpeed As Single
        Public Acceleration As Single
        Public Braking As Single
        Public Traction As Single
    End Structure

    Public Shared Function GetVehicleStats(ByVal v As Vehicle) As VehicleStats
        Dim num As Single = 1.0!
        Dim stats As New VehicleStats
        Dim arguments As InputArgument() = New InputArgument() {v}
        stats.TopSpeed = Native.Function.Call(Of Single)(Hash._0x53AF99BAA671CA47, arguments)
        Dim argumentArray2 As InputArgument() = New InputArgument() {v}
        stats.Braking = Native.Function.Call(Of Single)(Hash._0xAD7E85FC227197C4, argumentArray2)
        Dim argumentArray3 As InputArgument() = New InputArgument() {v}
        stats.Acceleration = Native.Function.Call(Of Single)(Hash._0x5DD35C8D074E57AE, argumentArray3)
        Dim argumentArray4 As InputArgument() = New InputArgument() {v}
        stats.Traction = (Native.Function.Call(Of Single)(Hash._0xA132FB5370554DB0, argumentArray4) * num)
        Return stats
    End Function

    Public Shared Function GetVehiclePrice(file As String) As Integer
        Dim VehHash As Integer = CInt(ReadCfgValue("VehicleHash", file))
        Dim VehPrice As Integer
        Select Case VehHash
            '0 - 900
            Case GetHashKey("bmx"), GetHashKey("cruiser")
                VehPrice = 800
            '1k - 9k
            Case GetHashKey("scorcher")
                VehPrice = 2000
            Case GetHashKey("rebel")
                VehPrice = 3000
            Case GetHashKey("voodoo2"), GetHashKey("faggio2")
                VehPrice = 5000
            Case GetHashKey("ratloader")
                VehPrice = 6000
            Case GetHashKey("sanchez")
                VehPrice = 7000
            Case GetHashKey("regina"), GetHashKey("blazer"), GetHashKey("sanchez2")
                VehPrice = 8000
            Case GetHashKey("primo"), GetHashKey("picador"), GetHashKey("rancherxl"), GetHashKey("ingot"), GetHashKey("vader"), GetHashKey("pcj"), GetHashKey("akuma")
                VehPrice = 9000
            '10k - 90k
            Case GetHashKey("sabregt"), GetHashKey("sultan"), GetHashKey("tribike"), GetHashKey("tribike2"), GetHashKey("tribike3"), GetHashKey("issi2"), GetHashKey("surfer"), GetHashKey("youga"), GetHashKey("bfinjection"), GetHashKey("rumpo"), GetHashKey("asea"), GetHashKey("intruder"), GetHashKey("premier"), GetHashKey("stanier"), GetHashKey("stratum"), GetHashKey("washington"), GetHashKey("bati"), GetHashKey("nemesis"), GetHashKey("bati2")
                VehPrice = 10000
            Case GetHashKey("ruffian"), GetHashKey("double"), GetHashKey("hexer"), GetHashKey("journey")
                VehPrice = 10000
            Case GetHashKey("buccaneer"), GetHashKey("paradise"), GetHashKey("vigero"), GetHashKey("penumbra"), GetHashKey("bodhi2"), GetHashKey("dune"), GetHashKey("rebel2"), GetHashKey("fugitive"), GetHashKey("dilettante"), GetHashKey("asterope"), GetHashKey("gresley"), GetHashKey("bobcatxl")
                VehPrice = 20000
            Case GetHashKey("tornado"), GetHashKey("minivan"), GetHashKey("moonbeam"), GetHashKey("faction"), GetHashKey("ratloader2"), GetHashKey("gauntlet"), GetHashKey("dominator"), GetHashKey("fusilade"), GetHashKey("seminole"), GetHashKey("sandking2"), GetHashKey("bison"), GetHashKey("sadler"), GetHashKey("surge"), GetHashKey("granger"), GetHashKey("minivan"), GetHashKey("radi"), GetHashKey("buffalo"), GetHashKey("stretch")
                VehPrice = 30000
            Case GetHashKey("slamvan"), GetHashKey("carbonrs"), GetHashKey("faggio"), GetHashKey("ratbike"), GetHashKey("enduro"), GetHashKey("slamvan"), GetHashKey("kalahari"), GetHashKey("sandking"), GetHashKey("boxville3")
                VehPrice = 40000
            Case GetHashKey("faggio3"), GetHashKey("tailgater"), GetHashKey("landstalker")
                VehPrice = 50000
            Case GetHashKey("manchez"), GetHashKey("gburrito2"), GetHashKey("zion"), GetHashKey("zion2"), GetHashKey("sentinel"), GetHashKey("jackal"), GetHashKey("schafter2"), GetHashKey("cavalcade"), GetHashKey("blazer3")
                VehPrice = 60000
            Case GetHashKey("thrust"), GetHashKey("bifta"), GetHashKey("cavalcade2")
                VehPrice = 70000
            Case GetHashKey("blazer4"), GetHashKey("panto"), GetHashKey("schwarzer"), GetHashKey("f620"), GetHashKey("oracle"), GetHashKey("rocoto"), GetHashKey("oracle2"), GetHashKey("hakuchou"), GetHashKey("mesa3")
                VehPrice = 80000
            Case GetHashKey("hotknife"), GetHashKey("wolfsbane"), GetHashKey("zombiea"), GetHashKey("bf400"), GetHashKey("kuruma"), GetHashKey("sentinel2"), GetHashKey("buffalo2"), GetHashKey("baller"), GetHashKey("felon"), GetHashKey("felon2"), GetHashKey("innovation")
                VehPrice = 90000
            '100k - 900k
            Case GetHashKey("fcr"), GetHashKey("diablous"), GetHashKey("virgo3"), GetHashKey("banshee"), GetHashKey("comet2"), GetHashKey("cog55"), GetHashKey("baller3"), GetHashKey("schafter3"), GetHashKey("virgo"), GetHashKey("huntley"), GetHashKey("alpha"), GetHashKey("khamelion"), GetHashKey("cogcabrio"), GetHashKey("bullet"), GetHashKey("carbonizzare"), GetHashKey("coquette"), GetHashKey("feltzer2"), GetHashKey("ninef"), GetHashKey("ninef2")
                VehPrice = 100000
            Case GetHashKey("rapidgt"), GetHashKey("rapidgt2"), GetHashKey("voltic"), GetHashKey("surano"), GetHashKey("avarus"), GetHashKey("nightblade"), GetHashKey("zombieb"), GetHashKey("daemon2"), GetHashKey("brioso"), GetHashKey("gargoyle"), GetHashKey("rumpo3"), GetHashKey("blade"), GetHashKey("warrener"), GetHashKey("rhapsody")
                VehPrice = 100000
            Case GetHashKey("chino"), GetHashKey("xls"), GetHashKey("cognoscenti"), GetHashKey("baller4"), GetHashKey("schafter4"), GetHashKey("chino"), GetHashKey("massacro"), GetHashKey("jester"), GetHashKey("vacca"), GetHashKey("exemplar"), GetHashKey("superd"), GetHashKey("chimera"), GetHashKey("contender"), GetHashKey("cliffhanger"), GetHashKey("glendale"), GetHashKey("dubsta3")
                VehPrice = 200000
            Case GetHashKey("fcr2"), GetHashKey("faction2"), GetHashKey("faction3"), GetHashKey("cog552"), GetHashKey("baller5"), GetHashKey("schafter5"), GetHashKey("jb700"), GetHashKey("vortex"), GetHashKey("tornado6"), GetHashKey("tampa"), GetHashKey("massacro2"), GetHashKey("jester2")
                VehPrice = 300000
            Case GetHashKey("diablous2"), GetHashKey("buccaneer2"), GetHashKey("chino2"), GetHashKey("moonbeam2"), GetHashKey("primo2"), GetHashKey("slamvan3"), GetHashKey("virgo2"), GetHashKey("voodoo"), GetHashKey("schafter6"), GetHashKey("furoregt"), GetHashKey("monroe"), GetHashKey("infernus"), GetHashKey("defiler"), GetHashKey("guardian"), GetHashKey("pigalle")
                VehPrice = 400000
            Case GetHashKey("minivan2"), GetHashKey("sabregt2"), GetHashKey("tornado5"), GetHashKey("xls2"), GetHashKey("nightshade"), GetHashKey("cognoscenti2"), GetHashKey("baller6"), GetHashKey("turismor"), GetHashKey("trophytruck"), GetHashKey("kuruma2")
                VehPrice = 500000
            Case GetHashKey("specter"), GetHashKey("banshee2"), GetHashKey("raptor"), GetHashKey("bestiagts"), GetHashKey("verlierer2"), GetHashKey("coquette3"), GetHashKey("vindicator"), GetHashKey("casco"), GetHashKey("coquette2"), GetHashKey("cheetah"), GetHashKey("trophytruck2"), GetHashKey("insurgent2")
                VehPrice = 600000
            Case GetHashKey("comet3"), GetHashKey("brawler"), GetHashKey("lectro"), GetHashKey("zentorno"), GetHashKey("entityxf"), GetHashKey("omnis")
                VehPrice = 700000
            Case GetHashKey("specter2"), GetHashKey("sultanrs"), GetHashKey("penetrator"), GetHashKey("windsor"), GetHashKey("stinger"), GetHashKey("stingergt"), GetHashKey("tropos")
                VehPrice = 800000
            Case GetHashKey("elegy"), GetHashKey("hakuchou2"), GetHashKey("windsor2"), GetHashKey("seven70"), GetHashKey("btype3"), GetHashKey("mamba"), GetHashKey("feltzer3"), GetHashKey("ztype"), GetHashKey("tampa2"), GetHashKey("technical")
                VehPrice = 900000
            '1 million
            Case GetHashKey("adder")
                VehPrice = 1000000
            Case GetHashKey("italigtb")
                VehPrice = 1100000
            Case GetHashKey("tempesta"), GetHashKey("rallytruck"), GetHashKey("insurgent")
                VehPrice = 1300000
            Case GetHashKey("nero"), GetHashKey("technical2")
                VehPrice = 1400000
            Case GetHashKey("reaper")
                VehPrice = 1500000
            Case GetHashKey("italigtb2"), GetHashKey("limo2")
                VehPrice = 1600000
            Case GetHashKey("lynx"), GetHashKey("fmj"), GetHashKey("blazer5")
                VehPrice = 1700000
            Case GetHashKey("sheava"), GetHashKey("osiris"), GetHashKey("sanctus")
                VehPrice = 1900000
            '2 million
            Case GetHashKey("nero2")
                VehPrice = 2000000
            Case GetHashKey("shotaro"), GetHashKey("t20")
                VehPrice = 2200000
            Case GetHashKey("le7b")
                VehPrice = 2400000
            Case GetHashKey("tyrus")
                VehPrice = 2500000
            Case GetHashKey("pfister811")
                VehPrice = 2700000
            Case GetHashKey("boxville5")
                VehPrice = 2900000
            '3 million
            Case GetHashKey("dune4"), GetHashKey("dune5")
                VehPrice = 3100000
            Case GetHashKey("prototipo")
                VehPrice = 3700000
            Case GetHashKey("voltic2")
                VehPrice = 3800000
            '5 million
            Case GetHashKey("ruiner2")
                VehPrice = 5700000
            Case Else
                VehPrice = 0
        End Select
        Return VehPrice / 2
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
    End Function

    Public Shared Function GetVehicleInteriorTrimColor2(Vehicle As Vehicle) As Integer
        Dim arg As New OutputArgument()
        If My.Settings.HasLowriderUpdate = True Then
            Native.Function.Call(&H7D1464D472D32136L, Vehicle.Handle, arg)
        Else
            Return 0
        End If
        Return arg.GetResult(Of Integer)()
    End Function

    Public Shared Function GetVehicleInteriorDashboardColor2(Vehicle As Vehicle) As Integer
        Dim arg As New OutputArgument()
        If My.Settings.HasLowriderUpdate = True Then
            Native.Function.Call(&HB7635E80A5C31BFFUL, Vehicle.Handle, arg)
        Else
            Return 0
        End If
        Return arg.GetResult(Of Integer)()
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
        Try
            Select Case Vehicle.ClassType
                Case VehicleClass.Boats, VehicleClass.Helicopters, VehicleClass.Planes, VehicleClass.Military, VehicleClass.Service, VehicleClass.Industrial, VehicleClass.Commercial
                    Result = "Pegasus"
                Case VehicleClass.Cycles
                    Result = "BikeRack"
                Case VehicleClass.Utility, VehicleClass.Vans, VehicleClass.OffRoad, VehicleClass.Motorcycles, VehicleClass.Emergency, VehicleClass.Super, VehicleClass.SUVs, VehicleClass.Compacts, VehicleClass.Coupes, VehicleClass.Muscle, VehicleClass.Sedans, VehicleClass.SportsClassics, VehicleClass.Sports
                    Result = "Garage"
            End Select
        Catch ex As Exception
            SinglePlayerApartment.DisplayHelpTextThisFrame("Update your fucking ScriptHookV.NET!!!")
        End Try
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

    Public Shared Sub Disable_Weapons()
        Game.DisableControlThisFrame(0, GTA.Control.NextWeapon)
        Game.DisableControlThisFrame(0, GTA.Control.PrevWeapon)
        Game.DisableControlThisFrame(0, GTA.Control.MeleeAttack1)
        Game.DisableControlThisFrame(0, GTA.Control.MeleeAttack2)
        Game.DisableControlThisFrame(0, GTA.Control.MeleeAttackAlternate)
        Game.DisableControlThisFrame(0, GTA.Control.MeleeAttackHeavy)
        Game.DisableControlThisFrame(0, GTA.Control.MeleeAttackLight)
        Game.DisableControlThisFrame(0, GTA.Control.SelectWeapon)
        Select Case GetCurrentWeaponPedUsing()
            Case Game.GenerateHash(WeaponHash.Unarmed), 966099553
            Case Else
                Native.Function.Call(Hash.SET_CURRENT_PED_WEAPON, Game.Player.Character, WeaponHash.Unarmed, True)
        End Select
    End Sub

    Public Shared Sub Disable_Switch_Characters()
        Game.DisableControlThisFrame(0, GTA.Control.CharacterWheel)
    End Sub

    Public Shared Sub Disable_Controls()
        Game.DisableControlThisFrame(0, GTA.Control.Jump)
        Game.DisableControlThisFrame(0, GTA.Control.Attack)
        Game.DisableControlThisFrame(0, GTA.Control.Attack2)
        Game.DisableControlThisFrame(0, GTA.Control.Aim)
        Game.DisableControlThisFrame(0, GTA.Control.Cover)
        If Not Game.Player.Character.IsInVehicle AndAlso Not Brain.RadioTaskScriptStatus = 0 Then
            Game.DisableControlThisFrame(0, GTA.Control.VehicleRadioWheel)
            Game.DisableControlThisFrame(0, GTA.Control.VehicleNextRadio)
            Game.DisableControlThisFrame(0, GTA.Control.VehiclePrevRadio)
            Game.DisableControlThisFrame(0, GTA.Control.VehicleNextRadioTrack)
            Game.DisableControlThisFrame(0, GTA.Control.VehiclePrevRadioTrack)
        End If
    End Sub

    Public Shared Function GetCurrentWeaponPedUsing() As Integer
        Dim arg As New OutputArgument()
        Native.Function.Call(Hash.GET_CURRENT_PED_WEAPON, Game.Player.Character, arg, True)
        Return arg.GetResult(Of Integer)()
    End Function

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

    Public Shared Sub DriveTo(ped As Ped, vehicle As Vehicle, target As Vector3, radius As Single, speed As Single, Optional drivingstyle As Integer = 0)
        Native.Function.Call(Hash.TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE, ped.Handle, vehicle.Handle, target.X, target.Y, target.Z, speed, drivingstyle, radius)
    End Sub

    Public Shared Sub SetIntoVehicle(ped As Ped, vehicle As Vehicle, seat As VehicleSeat)
        Native.Function.Call(Hash.SET_PED_INTO_VEHICLE, ped, vehicle.Handle, seat)
    End Sub

    Public Shared Function WorldCreateVehicle(model As Model, position As Vector3, Optional heading As Single = 0F) As Vehicle
        If Not model.IsVehicle OrElse Not model.Request(1000) Then
            Return Nothing
        End If

        Return New Vehicle([Function].[Call](Of Integer)(Hash.CREATE_VEHICLE, model.Hash, position.X, position.Y, position.Z, heading,
        False, False))
    End Function

    Public Shared Function CreateVehicle(VehicleModel As String, VehicleHash As Integer, Position As Vector3, Optional Heading As Single = 0) As Vehicle
        Dim Result As Vehicle = Nothing
        If VehicleModel = "" Then
            Dim model = New Model(VehicleHash)
            model.Request(250)
            If model.IsInCdImage AndAlso model.IsValid Then
                While Not model.IsLoaded
                    Script.Wait(50)
                End While
                Result = WorldCreateVehicle(model, Position, Heading)
            End If
            model.MarkAsNoLongerNeeded()
        Else
            Dim model = New Model(VehicleModel)
            model.Request(250)
            If model.IsInCdImage AndAlso model.IsValid Then
                While Not model.IsLoaded
                    Script.Wait(50)
                End While
                Result = WorldCreateVehicle(model, Position, Heading)
            End If
            model.MarkAsNoLongerNeeded()
        End If
        Return Result
    End Function

    Public Shared Function CreateProp(PropHash As Integer, Position As Vector3, Rotation As Vector3, Optional Heading As Single = 0) As Prop
        Dim Result As Prop = Nothing
        Dim model = New Model(PropHash)
        model.Request(250)
        If model.IsInCdImage AndAlso model.IsValid Then
            While Not model.IsLoaded
                Script.Wait(50)
            End While
            Result = World.CreateProp(model, Position, Rotation, True, True)
            Result.Heading = Heading
        End If
        model.MarkAsNoLongerNeeded()
        Return Result
    End Function

    Public Shared Function IsInGarageVehicle(PlayerPed As Ped) As Boolean
        Dim Result As Boolean
        Select Case PlayerPed.CurrentVehicle
            Case TenCarGarage.veh0, TenCarGarage.veh1, TenCarGarage.veh2, TenCarGarage.veh3, TenCarGarage.veh4, TenCarGarage.veh5, TenCarGarage.veh6, TenCarGarage.veh7, TenCarGarage.veh8, TenCarGarage.veh9
                Result = True
            Case SixCarGarage.veh0, SixCarGarage.veh1, SixCarGarage.veh2, SixCarGarage.veh3, SixCarGarage.veh4, SixCarGarage.veh5
                Result = True
            Case Else
                Result = False
        End Select
        Return Result
    End Function

    Public Shared Sub ptfx_triggerOnEntity(ByVal ent As Entity, ByVal sPTFX As String, ByVal sAsset As String, ByVal Optional offset As Vector3 = Nothing, ByVal Optional rot As Vector3 = Nothing, ByVal Optional size As Double = 1)
        If (sAsset <> "") Then
            Native.Function.Call(Hash._0x6C38AF3693A69A91, New InputArgument() {sAsset})
        End If
        Native.Function.Call(Hash._0x0D53A3B8DA0809D2, New InputArgument() {sPTFX, ent, offset.X, offset.Y, offset.Z, rot.X, rot.Y, rot.Z, size, 0, 0, 0})
    End Sub

    Public Shared Sub PlayPTFX(Entity As Entity, PTFX As String, Asset As String, Offset As Vector3, Rotation As Vector3)
        Native.Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, Asset)
        Native.Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, Asset)
        Native.Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, PTFX, Entity, Offset.X, Offset.Y, Offset.Z, Rotation.X, Rotation.Y, Rotation.Z, False, False, False)
    End Sub

    Public Shared Sub PlayPTFXLoop(ptfx As String, effectname As String, heading As Single, pitch As Single, offset As Vector3)
        If Native.Function.Call(Of Boolean)(Hash.HAS_NAMED_PTFX_ASSET_LOADED, ptfx) Then
            Native.Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, ptfx)
            Native.Function.Call(Of Integer)(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, effectname, offset.X, offset.Y, offset.Z, 0, pitch, heading - 90, 1, False, False, False)
        Else
            Native.Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, ptfx)
        End If
    End Sub

    Public Shared Function Decode(String2Decode As String) As String
        Dim decodedBytes As Byte()
        decodedBytes = Convert.FromBase64String(String2Decode)
        Return Encoding.UTF8.GetString(decodedBytes)
    End Function

    Public Shared Sub SoundPlayer(waveFile As String)
        Using stream As New WaveStream(IO.File.OpenRead(waveFile))
            stream.Volume = My.Settings.Volume
            Using player As New SoundPlayer(stream)
                player.Play()
            End Using
        End Using
    End Sub

    Public Shared Function GetPlayerCurrentRadioStation() As String
        Dim RadioID As Integer = Native.Function.Call(Of Integer)(Hash.GET_PLAYER_RADIO_STATION_INDEX)
        Return Native.Function.Call(Of String)(Hash.GET_RADIO_STATION_NAME, RadioID)
    End Function

    Public Enum AptType
        OldApartment
        StiltsApartment
        CustomApartment
        Office
    End Enum

    Public Shared Sub RadioPlayer(type As AptType)
        Select Case type
            Case AptType.OldApartment
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Yacht_Bedroom", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Yacht_Bedroom", GetPlayerCurrentRadioStation())
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Yacht_Bedroom_02", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Yacht_Bedroom_02", GetPlayerCurrentRadioStation())
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Yacht_Bedroom_03", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Yacht_Bedroom_03", GetPlayerCurrentRadioStation())
            Case AptType.StiltsApartment
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Stilts_A_Living_Room", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Stilts_A_Living_Room", GetPlayerCurrentRadioStation())
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Stilts_A_Bedroom", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Stilts_A_Bedroom", GetPlayerCurrentRadioStation())
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Stilts_A_Heist_Room", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Stilts_A_Heist_Room", GetPlayerCurrentRadioStation())
            Case AptType.CustomApartment, AptType.Office
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Custom_Living_Room", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Custom_Living_Room", GetPlayerCurrentRadioStation())
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Custom_Bedroom", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Custom_Bedroom", GetPlayerCurrentRadioStation())
                Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "SE_DLC_APT_Custom_Heist_Room", True)
                Native.Function.Call(&H409501D338C02053, "SE_DLC_APT_Custom_Heist_Room", GetPlayerCurrentRadioStation())
        End Select
        'Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, Room, True)
        'Native.Function.Call(&HE0CD610D5EB6C85L, Room, Prop)
        'Native.Function.Call(Hash._0xF1CA12B18AEF5298, Prop, True)
        'Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, Room, GetPlayerCurrentRadioStation())
    End Sub

    Public Shared Function CreatePropNoOffset(PropModel As String, Position As Vector3, Dynamic As Boolean) As Prop
        Dim result As Prop = Nothing

        Dim model = New Model(PropModel)
        model.Request(250)
        If model.IsInCdImage AndAlso model.IsValid Then
            While Not model.IsLoaded
                Script.Wait(50)
            End While
            result = Native.Function.Call(Of Prop)(Hash.CREATE_OBJECT_NO_OFFSET, Game.GenerateHash(PropModel), Position.X, Position.Y, Position.Z, True, True, Dynamic)
        End If
        model.MarkAsNoLongerNeeded()
        Return result
    End Function

    Public Shared Function MD5Gen(strText As String) As String
        Dim MD5Service As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim Bytes() As Byte = MD5Service.ComputeHash(System.Text.Encoding.ASCII.GetBytes(strText))
        Dim s As String = Nothing
        For Each By As Byte In Bytes
            s += By.ToString("x2")
        Next
        Return s
    End Function

    Enum eDecorType
        DECOR_TYPE_FLOAT = 1
        DECOR_TYPE_BOOL
        DECOR_TYPE_INT
        DECOR_TYPE_UNK
        DECOR_TYPE_TIME
    End Enum

    Public Shared Function DecorIsRegisteredAsType(decorator As String, type As eDecorType) As Boolean
        Return Native.Function.Call(Of Boolean)(Hash.DECOR_IS_REGISTERED_AS_TYPE, decorator, type)
    End Function
End Class
