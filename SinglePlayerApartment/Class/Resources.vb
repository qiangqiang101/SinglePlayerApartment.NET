Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Text
Imports System.Media
Imports SinglePlayerApartment.SinglePlayerApartment

Public Module Resources

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

    Public Sub ShowXmasTree(Location As Vector3)
        If Not Website.PropXmasTree = Nothing Then
            Website.PropXmasTree.Delete()
            Website.PropXmasTree = World.CreateProp("prop_xmas_tree_int", New Vector3(Location.X, Location.Y, Location.Z - 1), False, False)
        Else
            Website.PropXmasTree = World.CreateProp("prop_xmas_tree_int", New Vector3(Location.X, Location.Y, Location.Z - 1), False, False)
        End If
    End Sub

    Public Function GetHashKey(ByVal s As String) As Integer
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

    Public Function GetVehicleStats(ByVal v As Vehicle) As VehicleStats
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

    Public Function GetVehiclePrice(file As String) As Integer
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

    Public Sub DrawText(ByVal [Text] As String, ByVal Position As PointF, ByVal Scale As Single, ByVal color As Color, ByVal Font As GTAFont, ByVal Alignment As GTAFontAlign, ByVal Options As GTAFontStyleOptions)
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

    Public Sub PushBigString(ByVal [Text] As String)
        Dim strArray As String() = SplitStringEveryNth([Text], &H63)
        Dim i As Integer
        For i = 0 To strArray.Length - 1
            Dim arguments As InputArgument() = New InputArgument() {[Text].Substring((i * &H63), strArray(i).Length)}
            Native.Function.Call(Hash._0x6C188BE134E074AA, arguments)
        Next i
    End Sub

    Private Function SplitStringEveryNth(ByVal [text] As String, ByVal Nth As Integer) As String()
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

    Public Function GetModelFromHash(Vehicle As Vehicle) As String
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

    Public Function GetVehicleClass(Vehicle As Vehicle) As String
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
            DisplayHelpTextThisFrame("Update your fucking ScriptHookV.NET!!!")
        End Try
        Return Result
    End Function

    Public Sub TaskPlayAnim(ByVal ped As Ped, ByVal animDict As String, ByVal animFile As String, ByVal duration As Integer)
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

    Public Sub TaskPlayAnimLoop(ByVal ped As Ped, ByVal animDict As String, ByVal animFile As String, ByVal duration As Integer)
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

    Public Sub Disable_Weapons()
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

    Public Sub Disable_Switch_Characters()
        Game.DisableControlThisFrame(0, GTA.Control.CharacterWheel)
    End Sub

    Public Sub Disable_Controls()
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

    Public Function GetCurrentWeaponPedUsing() As Integer
        Dim arg As New OutputArgument()
        Native.Function.Call(Hash.GET_CURRENT_PED_WEAPON, Game.Player.Character, arg, True)
        Return arg.GetResult(Of Integer)()
    End Function

    Public Function GetPlayerZoneForPlane(PlayerPed As Ped) As Vector3
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

    Public Enum Nodetype
        AnyRoad
        Road
        Offroad
        Water
    End Enum

    Function GenerateSpawnPos(desiredPos As Vector3, roadtype As Nodetype, sidewalk As Boolean) As Vector3
        Dim finalpos As Vector3 = Vector3.Zero

        Try
            Dim ForceOffroad As Boolean = False

            Dim outArgA As New OutputArgument()
            Dim NodeNumber As Integer = 1
            Dim type As Integer = 0

            If roadtype = Nodetype.AnyRoad Then
                type = 1
            End If
            If roadtype = Nodetype.Road Then
                type = 0
            End If
            If roadtype = Nodetype.Offroad Then
                type = 1
                ForceOffroad = True
            End If
            If roadtype = Nodetype.Water Then
                type = 3
            End If

            Dim NodeID As Integer = [Function].[Call](Of Integer)(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_ID, desiredPos.X, desiredPos.Y, desiredPos.Z, NodeNumber, type,
            300.0F, 300.0F)
            If ForceOffroad Then
                While Not [Function].[Call](Of Boolean)(Hash._GET_IS_SLOW_ROAD_FLAG, NodeID) AndAlso NodeNumber < 500
                    NodeNumber += 1
                    NodeID = [Function].[Call](Of Integer)(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_ID, desiredPos.X, desiredPos.Y, desiredPos.Z, NodeNumber, type,
                    300.0F, 300.0F)
                End While
            End If
            [Function].[Call](Hash.GET_VEHICLE_NODE_POSITION, NodeID, outArgA)
            finalpos = outArgA.GetResult(Of Vector3)()

            If sidewalk Then
                finalpos = World.GetNextPositionOnSidewalk(finalpos)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try

        Return finalpos
    End Function

    Public Function GetPlayerZoneForBoat(PlayerPed As Ped) As Vector3
        Return GenerateSpawnPos(PlayerPed.Position, Nodetype.Water, False)
    End Function

    Public Function GetPlayerZoneForHeli(PlayerPed As Ped) As Vector3
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

    Public Sub CreateFile(vehFileName As String)
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

    Public Sub DriveTo(ped As Ped, vehicle As Vehicle, target As Vector3, radius As Single, speed As Single, Optional drivingstyle As Integer = 0)
        Native.Function.Call(Hash.TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE, ped.Handle, vehicle.Handle, target.X, target.Y, target.Z, speed, drivingstyle, radius)
    End Sub

    Public Sub SetIntoVehicle(ped As Ped, vehicle As Vehicle, seat As VehicleSeat)
        Native.Function.Call(Hash.SET_PED_INTO_VEHICLE, ped, vehicle.Handle, seat)
    End Sub

    Public Function WorldCreateVehicle(model As Model, position As Vector3, Optional heading As Single = 0F) As Vehicle
        If Not model.IsVehicle OrElse Not model.Request(1000) Then
            Return Nothing
        End If

        Return New Vehicle([Function].[Call](Of Integer)(Hash.CREATE_VEHICLE, model.Hash, position.X, position.Y, position.Z, heading,
        False, False))
    End Function

    Public Function CreateVehicle(VehicleModel As String, VehicleHash As Integer, Position As Vector3, Optional Heading As Single = 0) As Vehicle
        Dim Result As Vehicle = Nothing
        If VehicleModel = "" Then
            Dim model = New Model(VehicleHash)
            model.Request(250)
            If model.IsInCdImage AndAlso model.IsValid Then
                While Not model.IsLoaded
                    Script.Wait(0)
                End While
                Result = WorldCreateVehicle(model, Position, Heading)
            End If
            model.MarkAsNoLongerNeeded()
        Else
            Dim model = New Model(VehicleModel)
            model.Request(250)
            If model.IsInCdImage AndAlso model.IsValid Then
                While Not model.IsLoaded
                    Script.Wait(0)
                End While
                Result = WorldCreateVehicle(model, Position, Heading)
            End If
            model.MarkAsNoLongerNeeded()
        End If
        Return Result
    End Function

    Public Function CreateProp(PropHash As Integer, Position As Vector3, Rotation As Vector3, Optional Heading As Single = 0) As Prop
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

    Public Function IsInGarageVehicle(PlayerPed As Ped) As Boolean
        Dim Result As Boolean
        Select Case PlayerPed.CurrentVehicle
            Case TenCarGarage.veh0, TenCarGarage.veh1, TenCarGarage.veh2, TenCarGarage.veh3, TenCarGarage.veh4, TenCarGarage.veh5, TenCarGarage.veh6, TenCarGarage.veh7, TenCarGarage.veh8, TenCarGarage.veh9
                Result = True
            Case SixCarGarage.veh0, SixCarGarage.veh1, SixCarGarage.veh2, SixCarGarage.veh3, SixCarGarage.veh4, SixCarGarage.veh5
                Result = True
            Case MazeBankWestGarage1.veh0, MazeBankWestGarage1.veh1, MazeBankWestGarage1.veh2, MazeBankWestGarage1.veh3, MazeBankWestGarage1.veh4, MazeBankWestGarage1.veh5, MazeBankWestGarage1.veh6, MazeBankWestGarage1.veh7, MazeBankWestGarage1.veh8, MazeBankWestGarage1.veh9, MazeBankWestGarage1.veh10, MazeBankWestGarage1.veh11, MazeBankWestGarage1.veh12, MazeBankWestGarage1.veh13, MazeBankWestGarage1.veh14, MazeBankWestGarage1.veh15, MazeBankWestGarage1.veh16, MazeBankWestGarage1.veh17, MazeBankWestGarage1.veh18, MazeBankWestGarage1.veh19
                Result = True
            Case Else
                Result = False
        End Select
        Return Result
    End Function

    Public Sub ptfx_triggerOnEntity(ByVal ent As Entity, ByVal sPTFX As String, ByVal sAsset As String, ByVal Optional offset As Vector3 = Nothing, ByVal Optional rot As Vector3 = Nothing, ByVal Optional size As Double = 1)
        If (sAsset <> "") Then
            Native.Function.Call(Hash._0x6C38AF3693A69A91, New InputArgument() {sAsset})
        End If
        Native.Function.Call(Hash._0x0D53A3B8DA0809D2, New InputArgument() {sPTFX, ent, offset.X, offset.Y, offset.Z, rot.X, rot.Y, rot.Z, size, 0, 0, 0})
    End Sub

    Public Sub PlayPTFX(Entity As Entity, PTFX As String, Asset As String, Offset As Vector3, Rotation As Vector3)
        Native.Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, Asset)
        Native.Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, Asset)
        Native.Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, PTFX, Entity, Offset.X, Offset.Y, Offset.Z, Rotation.X, Rotation.Y, Rotation.Z, False, False, False)
    End Sub

    Public Sub PlayPTFXLoop(ptfx As String, effectname As String, heading As Single, pitch As Single, offset As Vector3)
        If Native.Function.Call(Of Boolean)(Hash.HAS_NAMED_PTFX_ASSET_LOADED, ptfx) Then
            Native.Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, ptfx)
            Native.Function.Call(Of Integer)(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, effectname, offset.X, offset.Y, offset.Z, 0, pitch, heading - 90, 1, False, False, False)
        Else
            Native.Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, ptfx)
        End If
    End Sub

    Public Function Decode(String2Decode As String) As String
        Dim decodedBytes As Byte()
        decodedBytes = Convert.FromBase64String(String2Decode)
        Return Encoding.UTF8.GetString(decodedBytes)
    End Function

    Public Sub SoundPlayer(waveFile As String)
        Using stream As New WaveStream(IO.File.OpenRead(waveFile))
            stream.Volume = My.Settings.Volume
            Using player As New SoundPlayer(stream)
                player.Play()
            End Using
        End Using
    End Sub

    Public Function GetPlayerCurrentRadioStation() As String
        Dim RadioID As Integer = Native.Function.Call(Of Integer)(Hash.GET_PLAYER_RADIO_STATION_INDEX)
        Return Native.Function.Call(Of String)(Hash.GET_RADIO_STATION_NAME, RadioID)
    End Function

    'Public Function GetPlayerCurrentApartment() As INMNative.Apartment
    '    Dim result As INMNative.Apartment = Nothing
    '    Select Case playerInterior
    '        Case _3AltaStreet.Apartment.InteriorID
    '            result = _3AltaStreet.Apartment
    '        Case _4IntegrityWay.Apartment.InteriorID
    '            result = _4IntegrityWay.Apartment
    '        Case _4IntegrityWay.ApartmentHL.InteriorID
    '            result = _4IntegrityWay.ApartmentHL
    '        Case DelPerroHeight.Apartment.InteriorID
    '            result = DelPerroHeight.Apartment
    '        Case DelPerroHeight.ApartmentHL.InteriorID
    '            result = DelPerroHeight.ApartmentHL
    '        Case EclipseTower.Apartment.InteriorID
    '            result = EclipseTower.Apartment
    '        Case EclipseTower.ApartmentHL.InteriorID
    '            result = EclipseTower.ApartmentHL
    '        Case EclipseTower.ApartmentPS1.InteriorID
    '            result = EclipseTower.ApartmentPS1
    '        Case EclipseTower.ApartmentPS2.InteriorID
    '            result = EclipseTower.ApartmentPS2
    '        Case EclipseTower.ApartmentPS3.InteriorID
    '            result = EclipseTower.ApartmentPS3
    '        Case RichardMajestic.Apartment.InteriorID
    '            result = RichardMajestic.Apartment
    '        Case RichardMajestic.ApartmentHL.InteriorID
    '            result = RichardMajestic.ApartmentHL
    '        Case TinselTower.Apartment.InteriorID
    '            result = TinselTower.Apartment
    '        Case TinselTower.ApartmentHL.InteriorID
    '            result = TinselTower.ApartmentHL
    '        Case WeazelPlaza.Apartment.InteriorID
    '            result = WeazelPlaza.Apartment
    '        Case HillcrestAve2862.Apartment.InteriorID
    '            result = HillcrestAve2862.Apartment
    '        Case HillcrestAve2868.Apartment.InteriorID
    '            result = HillcrestAve2868.Apartment
    '        Case HillcrestAve2874._Apartment.InteriorID
    '            result = HillcrestAve2874._Apartment
    '        Case MadWayne2113.Apartment.InteriorID
    '            result = MadWayne2113.Apartment
    '        Case MiltonRd2117.Apartment.InteriorID
    '            result = MiltonRd2117.Apartment
    '        Case NorthConker2044.Apartment.InteriorID
    '            result = NorthConker2044.Apartment
    '        Case NorthConker2045.Apartment.InteriorID
    '            result = NorthConker2045.Apartment
    '        Case Whispymound3677.Apartment.InteriorID
    '            result = Whispymound3677.Apartment
    '        Case WildOats3655.Apartment.InteriorID
    '            result = WildOats3655.Apartment
    '        Case TenCarGarage.InteriorID
    '            result = New INMNative.Apartment("TenCarGarage", Nothing, 0, Nothing) With {.InteriorID = TenCarGarage.InteriorID}
    '        Case SixCarGarage.InteriorID
    '            result = New INMNative.Apartment("SixCarGarage", Nothing, 0, Nothing) With {.InteriorID = SixCarGarage.InteriorID}
    '        Case INMNative.Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)) 'Low End Apartment
    '            result = GrapeseedAve.Apartment
    '        Case INMNative.Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)) 'Medium End Apartment
    '            result = BayCityAve.Apartment
    '    End Select
    '    Return result
    'End Function

    'Public Sub TurnOnRadio(ByVal BedRoomRadio As Prop, ByVal HeistRoomRadio As Prop, ByVal LivingRoomProp As Prop, BedRoomEmitter As String, HeistRoomEmitter As String, LivingRoomEmitter As String)
    '    Native.Function.Call(&H0E0CD610D5EB6C85, BedRoomEmitter, BedRoomRadio)
    '    SetRadioProperties(BedRoomRadio)
    '    Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, BedRoomEmitter, True)
    '    Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, BedRoomEmitter, "RADIO_01_CLASS_ROCK")

    '    Native.Function.Call(&H0E0CD610D5EB6C85, HeistRoomEmitter, HeistRoomRadio)
    '    SetRadioProperties(HeistRoomRadio)
    '    Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, HeistRoomEmitter, True)
    '    Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, HeistRoomEmitter, "RADIO_01_CLASS_ROCK")

    '    Native.Function.Call(&H0E0CD610D5EB6C85, LivingRoomEmitter, LivingRoomProp)
    '    SetRadioProperties(LivingRoomProp)
    '    Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, LivingRoomEmitter, True)
    '    Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, LivingRoomEmitter, "RADIO_01_CLASS_ROCK")
    'End Sub

    'Public Sub TurnOffRadio(ByVal BedRoomRadio As Prop, ByVal HeistRoomRadio As Prop, ByVal LivingRoomProp As Prop, BedRoomEmitter As String, HeistRoomEmitter As String, LivingRoomEmitter As String)
    '    Native.Function.Call(&H0E0CD610D5EB6C85, BedRoomEmitter, BedRoomRadio)
    '    SetRadioProperties(BedRoomRadio)
    '    Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, BedRoomEmitter, False)
    '    Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, BedRoomEmitter, "RADIO_01_CLASS_ROCK")

    '    Native.Function.Call(&H0E0CD610D5EB6C85, HeistRoomEmitter, HeistRoomRadio)
    '    SetRadioProperties(HeistRoomRadio)
    '    Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, HeistRoomEmitter, False)
    '    Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, HeistRoomEmitter, "RADIO_01_CLASS_ROCK")

    '    Native.Function.Call(&H0E0CD610D5EB6C85, LivingRoomEmitter, LivingRoomProp)
    '    SetRadioProperties(LivingRoomProp)
    '    Native.Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, LivingRoomEmitter, False)
    '    Native.Function.Call(Hash.SET_EMITTER_RADIO_STATION, LivingRoomEmitter, "RADIO_01_CLASS_ROCK")
    'End Sub

    'Public Sub SetRadioProperties(ByVal Radio As Prop)
    '    Radio.IsInvincible = True
    '    Radio.FreezePosition = True
    '    Radio.HasCollision = False
    '    Radio.IsVisible = False
    '    Native.Function.Call(Hash._0xF1CA12B18AEF5298, Radio, True)
    'End Sub

    'Public Function CreatePropNoOffset(PropModel As String, Position As Vector3, Dynamic As Boolean) As Prop
    '    Dim result As Prop = Nothing

    '    Dim model = New Model(PropModel)
    '    model.Request(250)
    '    If model.IsInCdImage AndAlso model.IsValid Then
    '        While Not model.IsLoaded
    '            Script.Wait(50)
    '        End While
    '        result = Native.Function.Call(Of Prop)(Hash.CREATE_OBJECT_NO_OFFSET, Game.GenerateHash(PropModel), Position.X, Position.Y, Position.Z, True, True, Dynamic)
    '    End If
    '    model.MarkAsNoLongerNeeded()
    '    Return result
    'End Function

    Public Function MD5Gen(strText As String) As String
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

    Public Function DecorIsRegisteredAsType(decorator As String, type As eDecorType) As Boolean
        Return Native.Function.Call(Of Boolean)(Hash.DECOR_IS_REGISTERED_AS_TYPE, decorator, type)
    End Function

    Public Function GetPlayerName() As String
        Dim Name As String = "Player3"
        Select Case Game.Player.Character.Model.GetHashCode
            Case 225514697
                Name = "Michael"
            Case -1692214353
                Name = "Franklin"
            Case -1686040670
                Name = "Trevor"
            Case Else
                Name = "Player3"
        End Select
        Return Name
    End Function

    Public Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String, EngineRunning As Boolean)
        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = ReadCfgValue("PrimaryColor", VehicleCfgFile)
        _Vehicle.SecondaryColor = ReadCfgValue("SecondaryColor", VehicleCfgFile)
        _Vehicle.PearlescentColor = ReadCfgValue("PearlescentColor", VehicleCfgFile)
        If ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomPrimaryColor = Drawing.Color.FromArgb(ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile))
        If ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomSecondaryColor = Drawing.Color.FromArgb(ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile))
        _Vehicle.RimColor = ReadCfgValue("RimColor", VehicleCfgFile)
        If ReadCfgValue("HasNeonLightBack", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Back, True)
        If ReadCfgValue("HasNeonLightFront", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Front, True)
        If ReadCfgValue("HasNeonLightLeft", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Left, True)
        If ReadCfgValue("HasNeonLightRight", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Right, True)
        _Vehicle.NeonLightsColor = Drawing.Color.FromArgb(ReadCfgValue("NeonColorRed", VehicleCfgFile), ReadCfgValue("NeonColorGreen", VehicleCfgFile), ReadCfgValue("NeonColorBlue", VehicleCfgFile))
        _Vehicle.WheelType = ReadCfgValue("WheelType", VehicleCfgFile)
        _Vehicle.Livery = ReadCfgValue("Livery", VehicleCfgFile)
        Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, _Vehicle, CInt(ReadCfgValue("PlateType", VehicleCfgFile)))
        _Vehicle.NumberPlate = ReadCfgValue("PlateNumber", VehicleCfgFile)
        _Vehicle.WindowTint = ReadCfgValue("WindowTint", VehicleCfgFile)
        _Vehicle.SetMod(VehicleMod.Spoilers, ReadCfgValue("Spoiler", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.FrontBumper, ReadCfgValue("FrontBumper", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.RearBumper, ReadCfgValue("RearBumper", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.SideSkirt, ReadCfgValue("SideSkirt", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Frame, ReadCfgValue("Frame", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Grille, ReadCfgValue("Grille", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Hood, ReadCfgValue("Hood", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Fender, ReadCfgValue("Fender", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.RightFender, ReadCfgValue("RightFender", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Roof, ReadCfgValue("Roof", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Exhaust, ReadCfgValue("Exhaust", VehicleCfgFile), True)
        If ReadCfgValue("FrontTireVariation", VehicleCfgFile) = "True" Then _Vehicle.SetMod(VehicleMod.FrontWheels, ReadCfgValue("FrontWheels", VehicleCfgFile), True) Else _Vehicle.SetMod(VehicleMod.FrontWheels, ReadCfgValue("FrontWheels", VehicleCfgFile), False)
        If ReadCfgValue("BackTireVariation", VehicleCfgFile) = "True" Then _Vehicle.SetMod(VehicleMod.BackWheels, ReadCfgValue("BackWheels", VehicleCfgFile), True) Else _Vehicle.SetMod(VehicleMod.BackWheels, ReadCfgValue("BackWheels", VehicleCfgFile), False)
        _Vehicle.SetMod(VehicleMod.Suspension, ReadCfgValue("Suspension", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), False)
        _Vehicle.SetMod(VehicleMod.Brakes, ReadCfgValue("Brakes", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Transmission, ReadCfgValue("Transmission", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Armor, ReadCfgValue("Armor", VehicleCfgFile), True)
        _Vehicle.SetMod(25, ReadCfgValue("TwentyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(26, ReadCfgValue("TwentySix", VehicleCfgFile), True)
        _Vehicle.SetMod(27, ReadCfgValue("TwentySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(28, ReadCfgValue("TwentyEight", VehicleCfgFile), True)
        _Vehicle.SetMod(29, ReadCfgValue("TwentyNine", VehicleCfgFile), True)
        _Vehicle.SetMod(30, ReadCfgValue("ThirtyZero", VehicleCfgFile), True)
        _Vehicle.SetMod(31, ReadCfgValue("ThirtyOne", VehicleCfgFile), True)
        _Vehicle.SetMod(32, ReadCfgValue("ThirtyTwo", VehicleCfgFile), True)
        _Vehicle.SetMod(33, ReadCfgValue("ThirtyThree", VehicleCfgFile), True)
        _Vehicle.SetMod(34, ReadCfgValue("ThirtyFour", VehicleCfgFile), True)
        _Vehicle.SetMod(35, ReadCfgValue("ThirtyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(36, ReadCfgValue("ThirtySix", VehicleCfgFile), True)
        _Vehicle.SetMod(37, ReadCfgValue("ThirtySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(38, ReadCfgValue("ThirtyEight", VehicleCfgFile), True)
        _Vehicle.SetMod(39, ReadCfgValue("ThirtyNine", VehicleCfgFile), True)
        _Vehicle.SetMod(40, ReadCfgValue("ForthyZero", VehicleCfgFile), True)
        _Vehicle.SetMod(41, ReadCfgValue("ForthyOne", VehicleCfgFile), True)
        _Vehicle.SetMod(42, ReadCfgValue("ForthyTwo", VehicleCfgFile), True)
        _Vehicle.SetMod(43, ReadCfgValue("ForthyThree", VehicleCfgFile), True)
        _Vehicle.SetMod(44, ReadCfgValue("ForthyFour", VehicleCfgFile), True)
        _Vehicle.SetMod(45, ReadCfgValue("ForthyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(46, ReadCfgValue("ForthySix", VehicleCfgFile), True)
        _Vehicle.SetMod(47, ReadCfgValue("ForthySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(48, ReadCfgValue("ForthyEight", VehicleCfgFile), True)
        If ReadCfgValue("XenonHeadlights", VehicleCfgFile) = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
        If ReadCfgValue("Turbo", VehicleCfgFile) = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.Turbo, True)
        _Vehicle.ToggleMod(VehicleToggleMod.TireSmoke, True)
        _Vehicle.TireSmokeColor = Drawing.Color.FromArgb(ReadCfgValue("TyreSmokeColorRed", VehicleCfgFile), ReadCfgValue("TyreSmokeColorGreen", VehicleCfgFile), ReadCfgValue("TyreSmokeColorBlue", VehicleCfgFile))
        _Vehicle.SetMod(VehicleMod.Horns, ReadCfgValue("Horn", VehicleCfgFile), True)
        If ReadCfgValue("BulletproofTyres", VehicleCfgFile) = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, _Vehicle, False)
        'Added on v1.3.4
        'Fixed on v1.3.4.2
        'Updated on v1.9.2
        _Vehicle.DashboardColor = ReadCfgValue("DashboardColor", VehicleCfgFile)
        _Vehicle.TrimColor = ReadCfgValue("TrimColor", VehicleCfgFile)
        'End of Added on v1.3.4
        _Vehicle.RoofState = CInt(ReadCfgValue("VehicleRoof", VehicleCfgFile))
        'Added on v1.3.3
        If ReadCfgValue("ExtraOne", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 1, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 1, -1)
        If ReadCfgValue("ExtraTwo", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 2, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 2, -1)
        If ReadCfgValue("ExtraThree", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 3, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 3, -1)
        If ReadCfgValue("ExtraFour", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 4, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 4, -1)
        If ReadCfgValue("ExtraFive", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 5, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 5, -1)
        If ReadCfgValue("ExtraSix", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 6, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 6, -1)
        If ReadCfgValue("ExtraSeven", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 7, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 7, -1)
        If ReadCfgValue("ExtraEight", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 8, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 8, -1)
        If ReadCfgValue("ExtraNine", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 9, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 9, -1)
        If EngineRunning = True Then _Vehicle.EngineRunning = True
        'Added on v1.9.2
        If ReadCfgValue("ExtraTen", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 10, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 10, -1)
        SetTornadoCustomRoof(_Vehicle, ReadCfgValue("CustomRoof", VehicleCfgFile))
        'Make sure it is set to correct Engine
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), False)
    End Sub

    Public Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String)
        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = CInt(ReadCfgValue("PrimaryColor", VehicleCfgFile))
        _Vehicle.SecondaryColor = CInt(ReadCfgValue("SecondaryColor", VehicleCfgFile))
        _Vehicle.PearlescentColor = CInt(ReadCfgValue("PearlescentColor", VehicleCfgFile))
        If ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomPrimaryColor = Color.FromArgb(ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile))
        If ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomSecondaryColor = Color.FromArgb(ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile))
        _Vehicle.RimColor = CInt(ReadCfgValue("RimColor", VehicleCfgFile))
        If ReadCfgValue("HasNeonLightBack", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Back, True)
        If ReadCfgValue("HasNeonLightFront", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Front, True)
        If ReadCfgValue("HasNeonLightLeft", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Left, True)
        If ReadCfgValue("HasNeonLightRight", VehicleCfgFile) = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Right, True)
        _Vehicle.NeonLightsColor = Color.FromArgb(ReadCfgValue("NeonColorRed", VehicleCfgFile), ReadCfgValue("NeonColorGreen", VehicleCfgFile), ReadCfgValue("NeonColorBlue", VehicleCfgFile))
        _Vehicle.WheelType = ReadCfgValue("WheelType", VehicleCfgFile)
        _Vehicle.Livery = ReadCfgValue("Livery", VehicleCfgFile)
        Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, _Vehicle, CInt(ReadCfgValue("PlateType", VehicleCfgFile)))
        _Vehicle.NumberPlate = ReadCfgValue("PlateNumber", VehicleCfgFile)
        _Vehicle.WindowTint = ReadCfgValue("WindowTint", VehicleCfgFile)
        _Vehicle.SetMod(VehicleMod.Spoilers, ReadCfgValue("Spoiler", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.FrontBumper, ReadCfgValue("FrontBumper", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.RearBumper, ReadCfgValue("RearBumper", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.SideSkirt, ReadCfgValue("SideSkirt", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Frame, ReadCfgValue("Frame", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Grille, ReadCfgValue("Grille", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Hood, ReadCfgValue("Hood", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Fender, ReadCfgValue("Fender", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.RightFender, ReadCfgValue("RightFender", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Roof, ReadCfgValue("Roof", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Exhaust, ReadCfgValue("Exhaust", VehicleCfgFile), True)
        If ReadCfgValue("FrontTireVariation", VehicleCfgFile) = "True" Then _Vehicle.SetMod(VehicleMod.FrontWheels, ReadCfgValue("FrontWheels", VehicleCfgFile), True) Else _Vehicle.SetMod(VehicleMod.FrontWheels, ReadCfgValue("FrontWheels", VehicleCfgFile), False)
        If ReadCfgValue("BackTireVariation", VehicleCfgFile) = "True" Then _Vehicle.SetMod(VehicleMod.BackWheels, ReadCfgValue("BackWheels", VehicleCfgFile), True) Else _Vehicle.SetMod(VehicleMod.BackWheels, ReadCfgValue("BackWheels", VehicleCfgFile), False)
        _Vehicle.SetMod(VehicleMod.Suspension, ReadCfgValue("Suspension", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), False)
        _Vehicle.SetMod(VehicleMod.Brakes, ReadCfgValue("Brakes", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Transmission, ReadCfgValue("Transmission", VehicleCfgFile), True)
        _Vehicle.SetMod(VehicleMod.Armor, ReadCfgValue("Armor", VehicleCfgFile), True)
        _Vehicle.SetMod(25, ReadCfgValue("TwentyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(26, ReadCfgValue("TwentySix", VehicleCfgFile), True)
        _Vehicle.SetMod(27, ReadCfgValue("TwentySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(28, ReadCfgValue("TwentyEight", VehicleCfgFile), True)
        _Vehicle.SetMod(29, ReadCfgValue("TwentyNine", VehicleCfgFile), True)
        _Vehicle.SetMod(30, ReadCfgValue("ThirtyZero", VehicleCfgFile), True)
        _Vehicle.SetMod(31, ReadCfgValue("ThirtyOne", VehicleCfgFile), True)
        _Vehicle.SetMod(32, ReadCfgValue("ThirtyTwo", VehicleCfgFile), True)
        _Vehicle.SetMod(33, ReadCfgValue("ThirtyThree", VehicleCfgFile), True)
        _Vehicle.SetMod(34, ReadCfgValue("ThirtyFour", VehicleCfgFile), True)
        _Vehicle.SetMod(35, ReadCfgValue("ThirtyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(36, ReadCfgValue("ThirtySix", VehicleCfgFile), True)
        _Vehicle.SetMod(37, ReadCfgValue("ThirtySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(38, ReadCfgValue("ThirtyEight", VehicleCfgFile), True)
        _Vehicle.SetMod(39, ReadCfgValue("ThirtyNine", VehicleCfgFile), True)
        _Vehicle.SetMod(40, ReadCfgValue("ForthyZero", VehicleCfgFile), True)
        _Vehicle.SetMod(41, ReadCfgValue("ForthyOne", VehicleCfgFile), True)
        _Vehicle.SetMod(42, ReadCfgValue("ForthyTwo", VehicleCfgFile), True)
        _Vehicle.SetMod(43, ReadCfgValue("ForthyThree", VehicleCfgFile), True)
        _Vehicle.SetMod(44, ReadCfgValue("ForthyFour", VehicleCfgFile), True)
        _Vehicle.SetMod(45, ReadCfgValue("ForthyFive", VehicleCfgFile), True)
        _Vehicle.SetMod(46, ReadCfgValue("ForthySix", VehicleCfgFile), True)
        _Vehicle.SetMod(47, ReadCfgValue("ForthySeven", VehicleCfgFile), True)
        _Vehicle.SetMod(48, ReadCfgValue("ForthyEight", VehicleCfgFile), True)
        If ReadCfgValue("XenonHeadlights", VehicleCfgFile) = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
        If ReadCfgValue("Turbo", VehicleCfgFile) = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.Turbo, True)
        _Vehicle.ToggleMod(VehicleToggleMod.TireSmoke, True)
        _Vehicle.TireSmokeColor = Color.FromArgb(CInt(ReadCfgValue("TyreSmokeColorRed", VehicleCfgFile)), CInt(ReadCfgValue("TyreSmokeColorGreen", VehicleCfgFile)), CInt(ReadCfgValue("TyreSmokeColorBlue", VehicleCfgFile)))
        _Vehicle.SetMod(VehicleMod.Horns, ReadCfgValue("Horn", VehicleCfgFile), True)
        If ReadCfgValue("BulletproofTyres", VehicleCfgFile) = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, _Vehicle, False)
        'Added on v1.3.4
        'Fixed on v1.3.4.2
        'Updated on v1.9.2
        _Vehicle.DashboardColor = ReadCfgValue("DashboardColor", VehicleCfgFile)
        _Vehicle.TrimColor = ReadCfgValue("TrimColor", VehicleCfgFile)
        'End of Added on v1.3.4
        _Vehicle.IsPersistent = True
        _Vehicle.RoofState = CInt(ReadCfgValue("VehicleRoof", VehicleCfgFile))
        'Added on v1.3.3
        If ReadCfgValue("ExtraOne", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 1, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 1, -1)
        If ReadCfgValue("ExtraTwo", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 2, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 2, -1)
        If ReadCfgValue("ExtraThree", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 3, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 3, -1)
        If ReadCfgValue("ExtraFour", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 4, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 4, -1)
        If ReadCfgValue("ExtraFive", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 5, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 5, -1)
        If ReadCfgValue("ExtraSix", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 6, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 6, -1)
        If ReadCfgValue("ExtraSeven", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 7, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 7, -1)
        If ReadCfgValue("ExtraEight", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 8, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 8, -1)
        If ReadCfgValue("ExtraNine", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 9, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 9, -1)
        'Added on v1.9.2
        If ReadCfgValue("ExtraTen", VehicleCfgFile) = "True" Then Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 10, 0) Else Native.Function.Call(Hash.SET_VEHICLE_EXTRA, _Vehicle, 10, -1)
        SetTornadoCustomRoof(_Vehicle, ReadCfgValue("CustomRoof", VehicleCfgFile))
    End Sub

    Public Function GetTornadoCustomRoof(veh As Vehicle) As Integer
        Return Native.Function.Call(Of Integer)(DirectCast(&H60190048C0764A26UL, Hash), veh.Handle)
    End Function

    Public Sub SetTornadoCustomRoof(veh As Vehicle, liv As Integer)
        Native.Function.Call(DirectCast(&HA6D3A8750DC73270UL, Hash), veh.Handle, liv)
    End Sub

    Public Sub Translate()
        Website.BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
        Website.DockTease = ReadCfgValue("DockTease", langFile)
        Website.LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
        Website.ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
        Website.PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
        Website.SouthernSA = ReadCfgValue("SouthernSA", langFile)
        Website.WarstockCache = ReadCfgValue("WarstockCache", langFile)
        Website.YourNew = ReadCfgValue("YourNew", langFile)
        Website.IsConfirm = ReadCfgValue("IsConfirm", langFile)
        Website.InsFundVehicle = ReadCfgValue("InsFundVehicle", langFile)
        ExitApt = ReadCfgValue("ExitApt", langFile)
        SellApt = ReadCfgValue("SellApt", langFile)
        EnterGarage = ReadCfgValue("EnterGarage", langFile)
        AptOptions = ReadCfgValue("AptOptions", langFile)
        Garage = ReadCfgValue("Garage", langFile)
        GrgOptions = ReadCfgValue("GrgOptions", langFile)
        GrgRemove = ReadCfgValue("GrgRemove", langFile)
        GrgRemoveAndDrive = ReadCfgValue("GrgRemoveAndDrive", langFile)
        GrgMove = ReadCfgValue("GrgMove", langFile)
        GrgSell = ReadCfgValue("GrgSell", langFile)
        GrgSelectVeh = ReadCfgValue("GrgSelectVeh", langFile)
        GrgTooHot = ReadCfgValue("GrgTooHot", langFile)
        GrgPlate = ReadCfgValue("GrgPlate", langFile)
        GrgRename = ReadCfgValue("GrgRename", langFile)
        GrgTransfer = ReadCfgValue("GrgTransfer", langFile)
        _Mechanic = ReadCfgValue("_Mechanic", langFile)
        _Pegasus = ReadCfgValue("_Pegasus", langFile)
        PegasusDeliver = ReadCfgValue("PegasusDeliver", langFile)
        PegasusDelete = ReadCfgValue("PegasusDelete", langFile)
        _Phone = ReadCfgValue("_Phone", langFile)
        ChooseApt = ReadCfgValue("ChooseApt", langFile)
        ChooseVeh = ReadCfgValue("ChooseVeh", langFile)
        ChooseVehDesc = ReadCfgValue("ChooseVehDesc", langFile)
        ReturnVeh = ReadCfgValue("ReturnVeh", langFile)
        AptStyle = ReadCfgValue("AptStyle", langFile)
        MechanicBill = ReadCfgValue("MechanicBill", langFile)
        GrgFull = ReadCfgValue("GrgFull", langFile)
        EnterElevator = ReadCfgValue("EnterElevator", langFile)
        ExitGarage = ReadCfgValue("ExitGarage", langFile)
        ManageGarage = ReadCfgValue("ManageGarage", langFile)
        Maze = ReadCfgValue("Maze", langFile)
        Insurance1 = ReadCfgValue("InsuranceLineOne", langFile)
        Insurance2 = ReadCfgValue("InsuranceLineTwo", langFile)
        Insurance3 = ReadCfgValue("InsuranceLineThree", langFile)
        Insurance4 = ReadCfgValue("InsuranceLineFour", langFile)
        MorsMutual = ReadCfgValue("MorsMutual", langFile)
        Fleeca = ReadCfgValue("Fleeca", langFile)
        BOL = ReadCfgValue("BOL", langFile)
        ForSale = ReadCfgValue("ForSale", langFile)
        PropPurchased = ReadCfgValue("PropPurchased", langFile)
        InsFundApartment = ReadCfgValue("InsFundApartment", langFile)
        EnterApartment = ReadCfgValue("EnterApartment", langFile)
        SaveGame = ReadCfgValue("SaveGame", langFile)
        ExitApartment = ReadCfgValue("ExitApartment", langFile)
        ChangeClothes = ReadCfgValue("ChangeClothes", langFile)
        _EnterGarage = ReadCfgValue("_EnterGarage", langFile)
        CannotStore = ReadCfgValue("CannotStore", langFile)
        Brain._TVOn = ReadCfgValue("TVOn", langFile)
        Brain._TVOff = ReadCfgValue("TVOff", langFile)
        Brain._TVChannel = Brain._TVOff & "~n~" & ReadCfgValue("TVChannel", langFile)
        Brain._Bong = ReadCfgValue("Bong", langFile)
        Brain._Whiskey = ReadCfgValue("Whiskey", langFile)
        Brain._Wine = ReadCfgValue("Wine", langFile)
        Brain._Wheat = ReadCfgValue("Wheat", langFile)
        Brain._Shower = ReadCfgValue("Shower", langFile)
        Brain._RadioSwitchStation = ReadCfgValue("Radio", langFile)
        Wardrobe.__Clothing = ReadCfgValue("__Clothing", langFile)
        Wardrobe.__Outfits = ReadCfgValue("__Outfits", langFile)
        Wardrobe._Outfits.Text = ReadCfgValue("_Outfits", langFile)
        Wardrobe.__FullSuit = ReadCfgValue("__FullSuit", langFile)
        Wardrobe._FullSuits.Text = ReadCfgValue("_FullSuits", langFile)
        Wardrobe.__SuitJacket = ReadCfgValue("__SuitJacket", langFile)
        Wardrobe._SuitJackets.Text = ReadCfgValue("_SuitJackets", langFile)
        Wardrobe.__SuitPants = ReadCfgValue("__SuitPants", langFile)
        Wardrobe._SuitPants.Text = ReadCfgValue("_SuitPants", langFile)
        Wardrobe.__Glasses = ReadCfgValue("__Glasses", langFile)
        Wardrobe._Glasses.Text = ReadCfgValue("_Glasses", langFile)
        Wardrobe._Glass.Text = ReadCfgValue("_Glass", langFile)
        Wardrobe.__SuitVest = ReadCfgValue("__SuitVest", langFile)
        Wardrobe._SuitVests.Text = ReadCfgValue("_SuitVests", langFile)
        Wardrobe.__Suits = ReadCfgValue("__Suits", langFile)
        Wardrobe._Suits.Text = ReadCfgValue("_Suits", langFile)
        Wardrobe.__SportsShades = ReadCfgValue("__SportsShades", langFile)
        Wardrobe._SportsShades.Text = ReadCfgValue("_SportsShades", langFile)
        Wardrobe.__StreetShades = ReadCfgValue("__StreetShades", langFile)
        Wardrobe._StreetShades.Text = ReadCfgValue("_StreetShades", langFile)
        Wardrobe.__Hoodies = ReadCfgValue("__Hoodies", langFile)
        Wardrobe._Hoodies.Text = ReadCfgValue("_Hoodies", langFile)
        Wardrobe.__Jackets = ReadCfgValue("__Jackets", langFile)
        Wardrobe._Jackets.Text = ReadCfgValue("_Jackets", langFile)
        Wardrobe._CasualJacketJackets.Text = ReadCfgValue("_CasualJacketJackets", langFile)
        Wardrobe.__Pants = ReadCfgValue("__Pants", langFile)
        Wardrobe._Pants.Text = ReadCfgValue("_Pants", langFile)
        Wardrobe.__PoloShirts = ReadCfgValue("__PoloShirts", langFile)
        Wardrobe._PoloShirt.Text = ReadCfgValue("_PoloShirt", langFile)
        Wardrobe.__Shoes = ReadCfgValue("__Shoes", langFile)
        Wardrobe._Shoes.Text = ReadCfgValue("_Shoes", langFile)
        Wardrobe.__Shirts = ReadCfgValue("__Shirts", langFile)
        Wardrobe._Shirt.Text = ReadCfgValue("_Shirt", langFile)
        Wardrobe._CasualJacketShirts.Text = ReadCfgValue("_CasualJacketShirts", langFile)
        Wardrobe.__TShirts = ReadCfgValue("__TShirts", langFile)
        Wardrobe._TShirt.Text = ReadCfgValue("_TShirt", langFile)
        Wardrobe._CasualJacketTShirts.Text = ReadCfgValue("_CasualJacketTShirts", langFile)
        Wardrobe.__Shorts = ReadCfgValue("__Shorts", langFile)
        Wardrobe._Shorts.Text = ReadCfgValue("_Shorts", langFile)
        Wardrobe.__TankTops = ReadCfgValue("__TankTops", langFile)
        Wardrobe._TankTops.Text = ReadCfgValue("_TankTops", langFile)
        Wardrobe.__Tops = ReadCfgValue("__Tops", langFile)
        Wardrobe._Tops.Text = ReadCfgValue("_Tops", langFile)
        Wardrobe.__SuitJacketbuttoned = ReadCfgValue("__SuitJacketbuttoned", langFile)
        Wardrobe._SuitJacketsButtoned.Text = ReadCfgValue("_SuitJacketsButtoned", langFile)
        Wardrobe.__Ties = ReadCfgValue("__Ties", langFile)
        Wardrobe._SuitTies.Text = ReadCfgValue("_SuitTies", langFile)
        Wardrobe.__Earrings = ReadCfgValue("__Earrings", langFile)
        Wardrobe._Earrings.Text = ReadCfgValue("_Earrings", langFile)
        Wardrobe.__Hats = ReadCfgValue("__Hats", langFile)
        Wardrobe._Hats.Text = ReadCfgValue("_Hats", langFile)
        Wardrobe._HatsTrevor.Text = ReadCfgValue("_HatsTrevor", langFile)
        Wardrobe.__CapsForward = ReadCfgValue("__CapsForward", langFile)
        Wardrobe._CapsForward.Text = ReadCfgValue("_CapsForward", langFile)
        Wardrobe.__CapsBackward = ReadCfgValue("__CapsBackward", langFile)
        Wardrobe._CapsBackward.Text = ReadCfgValue("_CapsBackward", langFile)
        Wardrobe.__SmartShoes = ReadCfgValue("__SmartShoes", langFile)
        Wardrobe._SmartShoes.Text = ReadCfgValue("_SmartShoes", langFile)
        Wardrobe.__Vests = ReadCfgValue("__Vests", langFile)
        Wardrobe._Vests.Text = ReadCfgValue("_Vests", langFile)
        Wardrobe.__OpenShirts = ReadCfgValue("__OpenShirts", langFile)
        Wardrobe._OpenShirts.Text = ReadCfgValue("_OpenShirts", langFile)
        Wardrobe.__CasualJackets = ReadCfgValue("__CasualJackets", langFile)
        Wardrobe._CasualJackets.Text = ReadCfgValue("_CasualJackets", langFile)
        Wardrobe._Chains.Text = ReadCfgValue("_Chains", langFile)
        Wardrobe.__Chains = ReadCfgValue("__Chains", langFile)
        ModernStyle = ReadCfgValue("ModernStyle", langFile)
        MoodyStyle = ReadCfgValue("MoodyStyle", langFile)
        VibrantStyle = ReadCfgValue("VibrantStyle", langFile)
        SharpStyle = ReadCfgValue("SharpStyle", langFile)
        MonochromeStyle = ReadCfgValue("MonochromeStyle", langFile)
        SeductiveStyle = ReadCfgValue("SeductiveStyle", langFile)
        RegalStyle = ReadCfgValue("RegalStyle", langFile)
        AquaStyle = ReadCfgValue("AquaStyle", langFile)
        ExecRich = ReadCfgValue("ExecRich", langFile)
        ExecCool = ReadCfgValue("ExecCool", langFile)
        ExecContrast = ReadCfgValue("ExecContrast", langFile)
        OldSpiClassical = ReadCfgValue("OldSpiClassical", langFile)
        OldSpiVintage = ReadCfgValue("OldSpiVintage", langFile)
        OldSpiWarms = ReadCfgValue("OldSpiWarms", langFile)
        PowBrkConservative = ReadCfgValue("PowBrkConservative", langFile)
        PowBrkPolished = ReadCfgValue("PowBrkPolished", langFile)
        PowBrkIce = ReadCfgValue("PowBrkIce", langFile)
        OfficeGarage1 = ReadCfgValue("OfficeGarage1", langFile)
        OfficeGarage2 = ReadCfgValue("OfficeGarage2", langFile)
        OfficeGarage3 = ReadCfgValue("OfficeGarage3", langFile)
        OfficeAutoShop = ReadCfgValue("OfficeAutoShop", langFile)
    End Sub

    Public Enum BlipSprite2
        Destination = 0
        Standard
        BigBlip
        PoliceOfficer
        PoliceArea
        Square
        Player
        North
        Waypoint
        BigCircle
        BigCircleOutline = 10
        ArrowUpOutlined
        ArrowDownOutlined
        ArrowUp
        ArrowDown
        PoliceHelicopterAnimated
        Jet
        Number1
        Number2
        Number3
        Number4 = 20
        Number5
        Number6
        Number7
        Number8
        Number9
        Number10
        GTAOCrew
        GTAOFriendly
        CableCar = 36
        RaceFinish = 38
        Safehouse = 40
        PoliceOfficer2
        PoliceCarDotAnimated
        PoliceHelicopter
        ChatBubble = 47
        Garage2 = 50
        Drugs
        Store
        PoliceCar = 56
        PolicePlayer
        CriminalWanted
        StoreHeist
        PoliceStation = 60
        Hospital
        Helicopter = 64
        StrangersAndFreaks = 66
        ArmoredTruck
        TowTruck
        Barber = 71
        LosSantosCustoms
        Clothes
        TattooParlor = 75
        Simeon
        Lester
        Michael
        Trevor
        Heist = 80
        Rampage = 84
        VinewoodTours
        LamarF
        Franklin = 88
        Chinese
        Airport = 90
        Bar = 93
        BaseJump
        Heist2 = 96
        CarWash = 100
        ComedyClub = 102
        Dart
        Heist3
        Heist4
        FIB
        Heist5
        DollarSign
        Golf
        AmmuNation = 110
        Exile = 112
        CutHeist
        Heist6 = 118
        ShootingRange = 119
        Solomon
        StripClub
        Tennis
        Exile2
        Michael2
        Triathlon = 126
        OffRoadRaceFinish
        GangPolice
        GangMexican
        GangBikers = 130
        ChatBubble2 = 133
        Key
        MovieTheater
        Music
        PoliceStation2
        Marijuana = 140
        Hunting
        ArmsTraffickingGround = 147
        Circle
        Nigel
        AssaultRifle = 150
        Bat
        Grenade
        Health
        Knife
        Molotov
        Pistol
        RPG
        Shotgun
        SMG
        Sniper = 160
        SonicWave
        PointOfInterest
        GTAOPassive
        GTAOUsingMenu
        Link = 171
        Minigun = 173
        GrenadeLauncher
        Armor
        Castle
        Link2
        Link3
        Castle2 = 181
        Castle3
        Castle4
        Camera
        Player2
        Key2
        Key3
        Handcuffs
        Handcuffs2
        Yoga = 197
        Cab
        Number11
        Number12 = 200
        Number13
        Number14
        Number15
        Number16
        Shrink
        Epsilon
        DollarSign2
        Trevor2
        Trevor3
        Franklin2 = 210
        Franklin3
        FranklinC = 214
        PersonalVehicleCar = 225
        PersonalVehicleBike
        PersonalVehicleCar2
        GunCar = 229
        Link4 = 233
        Custody = 237
        Custody2
        RedSquareNumber1 = 240
        RedSquareNumber2
        RedSquareNumber3
        RedSquareNumber4
        RedSquareNumber5
        ArmsTraffickingAir = 251
        Handcuff3
        Custody3
        Key4 = 255
        Link5
        Fairground = 266
        PropertyManagement
        Link6
        Altruist = 269
        Enemy = 270
        GTAOOnMission
        CashPickup
        Chop
        Dead
        CashPickup2 = 276
        CashPickup3
        CashPickup4
        Hooker
        [Friend] = 280
        CustodyDropoff = 285
        Garage3 = 289
        Garage4 = 290
        Garage5
        SimeonFamily = 293
        BountyHit = 303
        GTAOMission
        GTAOSurvival
        CrateDrop
        PlaneDrop
        Submarine
        Race
        Deathmatch = 310
        ArmWrestling
        AmmuNationShootingRange = 313
        RaceAir
        RaceCar
        RaceSea
        Towtruck2
        GarbageTruck
        GetawayCar = 326
        PersonalVehicleBike2 = 348
        SafehouseForSale = 350
        Package
        MartinMadrazo
        EnemyHelicopter
        Boost
        Devin
        Marina
        Garage
        GolfFlag
        Hangar
        Helipad = 360
        JerryCan
        Masks
        HeistSetup
        Incapacitated
        PickupSpawn
        BoilerSuit
        Completed
        Rockets
        GarageForSale
        HelipadForSale = 370
        MarinaForSale
        HangarForSale
        Circle2
        Business
        BusinessForSale
        RaceBike
        Parachute
        TeamDeathmatch
        RaceFoot
        VehicleDeathmatch = 380
        Barry
        Dom
        MaryAnn
        Cletus
        Josh
        Minute
        Omega
        Tonya
        Paparazzo
        Crosshair = 390
        CrateDropBackground
        GreenObjectiveOutlinedRed
        GreenObjectiveOutlinedPurple
        GreenObjectiveOutlinedPink
        GreenObjectiveOutlinedBlue
        EnemyOutlined
        EnemyOutlined2
        Creator
        CreatorDirection
        Abigail = 400
        Blimp
        Repair
        Testosterone
        Dinghy
        Fanatic
        Information = 407
        CaptureBriefcase
        LastTeamStanding
        Boat = 410
        CaptureHouse
        GTAOCrew2
        CaptureBackground
        Capture
        JerryCan2
        RP
        GTAOPlayerSafehouse
        GTAOPlayerSafehouseDead
        CaptureAmericanFlag
        CaptureFlag = 420
        Tank
        HelicopterAnimated
        Plane
        Jet2
        PlayerNoColor = 425
        AmouredGunCar
        Speedboat
        Heist7
        Stopwatch = 430
        DollarSignCircled
        Crosshair2
        Crosshair3
        DollarSignSquared
        'SHVDN until here
        StuntRace
        HotProperty
        KillListCompetitive
        Castle5
        King
        DeadDrop = 440
        PennedIn
        Beast
        CrossTheLinePointer
        CrossTheLine
        LamarD
        Bennys
        LamarDNumber1
        LamarDNumber2
        LamarDNumber3
        LamarDNumber4 = 450
        LamarDNumber5
        LamarDNumber6
        LamarDNumber7
        LamarDNumber8
        Yacht
        FindersKeepers
        Briefcase2
        ExecutiveSearch
        Wifi
        TurretedLimo = 460
        AssetRecovery
        YachtLocation
        Beasted
        Loading
        SlowTime = 466
        Flip
        ThermalVision
        Doped
        Railgun = 470
        Seashark
        Blind
        Warehouse
        WarehouseForSale
        Office
        OfficeForSale
        Truck
        SpecialCargo
        Trailer
        VIP = 480
        Cargobob
        AreaCutline
        Jammed
        Ghost
        Detonator
        Bomb
        Shield
        Stunt
        Heart
        StuntPremium = 490
        Adversary
        BikerClubhouse
        CagedIn
        TurfWar
        Joust
        Weed
        Cocaine
        IdentityCard
        Meth
        DollarBill = 500
        Package2
        Capture1
        Capture2
        Capture3
        Capture4
        Capture5
        Capture6
        Capture7
        Capture8
        Capture9 = 510
        Capture10
        Quadbike
        Bus
        DrugPackage
        Hop
        Adversary4
        Adversary8
        Adversary10
        Adversary12
        Adversary16 = 520
        Laptop
        Motorcycle
        SportsCar
        VehicleWarehouse
        Document
        PoliceStationInverted
        Junkyard
        PhantomWedge
        ArmoredBoxville
        Ruiner2000 = 530
        RampBuggy
        Wastelander
        RocketVoltic
        TechnicalAqua
        TargetA
        TargetB
        TargetC
        TargetD
        TargetE
        TargetF = 540
        TargetG
        TargetH
        Juggernaut
        Repair2
        SteeringWheel
        Cup
        RocketBoost
        Rocket
        MachineGun
        Parachute2 = 550
        FiveSeconds
        TenSeconds
        FifteenSeconds
        TwentySeconds
        ThirtySeconds
        WeaponSupplies
        Bunker
        APC
        Oppressor
        HalfTrack = 560
        DuneFAV
        WeaponizedTampa
        WeaponizedTrailer
        MobileOperationsCenter
        AdversaryBunker
        BunkerVehicleWorkshop
        WeaponWorkshop
        Cargo
        GTAOHangar
        TransformCheckpoint = 570
        TransformRace
        AlphaZ1
        Bombushka
        Havok
        HowardNX25
        Hunter
        Ultralight
        Mogul
        V65Molotok
        P45Nokota = 580
        Pyro
        Rogue
        Starling
        Seabreeze
        Tula
    End Enum

    Public Sub ToggleOfficeGarageDecor(Wall As String, Light As String, Number As String, interiorID As Integer)
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, interiorID, Wall)
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, interiorID, Light)
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, interiorID, Number)
        Native.Function.Call(Hash.REFRESH_INTERIOR, interiorID)
        If Not InteriorIDList.Contains(interiorID) AndAlso Not interiorID = 0 Then InteriorIDList.Add(interiorID)
    End Sub

    Public Sub EnableInteriotProp(interiorID As Integer, Prop As String)
        If Not Native.Function.Call(Of Boolean)(Hash._IS_INTERIOR_PROP_ENABLED, interiorID, Prop) Then Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, interiorID, Prop)
        Native.Function.Call(Hash.REFRESH_INTERIOR, interiorID)
    End Sub

    Public Sub DisplayHelpTextThisFrame(helpText As String, Optional Shape As Integer = -1)
        Native.Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "CELL_EMAIL_BCON")
        Const maxStringLength As Integer = 99

        Dim i As Integer = 0
        While i < helpText.Length
            Native.Function.Call(Hash._0x6C188BE134E074AA, helpText.Substring(i, System.Math.Min(maxStringLength, helpText.Length - i)))
            i += maxStringLength
        End While
        Native.Function.Call(Hash._DISPLAY_HELP_TEXT_FROM_STRING_LABEL, 0, 0, 1, Shape)
    End Sub

    Public Sub TimeLapse(ByVal SleepHour As Integer)
        Try
            Dim hour As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_HOURS)
            Dim minute As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MINUTES)
            Dim second As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_SECONDS)
            Dim day As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_DAY_OF_MONTH)
            Dim month As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MONTH)
            Dim year As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_YEAR)
            Dim sleep As Integer = hour + SleepHour
            Native.Function.Call(Hash.ADD_TO_CLOCK_TIME, sleep, minute, second)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadMPDLCMap()
        Try
            If My.Settings.NeverEnableMPMaps = False Then
                Native.Function.Call(Hash._LOAD_MP_DLC_MAPS)
                LoadMPDLCMapMissingObjects()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadMPDLCMapMissingObjects()
        Dim TID2 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -1155.31005, -1518.5699, 10.6300001) 'Floyd Apartment
        Dim MID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -802.31097, 175.05599, 72.84459) 'Michael House
        Dim FID1 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -9.96562, -1438.54003, 31.101499) 'Franklin Aunt House
        Dim FID2 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, 0.91675, 528.48498, 174.628005) 'Franklin House

        Dim WODID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -172.983001, 494.032989, 137.654006) '3655 Wild Oats
        Dim NCAID1 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, 340.941009, 437.17999, 149.389999) '2044 North Conker
        Dim NCAID2 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, 373.0230102, 416.1050109, 145.70100402) '2045 North Conker
        Dim HCAID1 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -676.1270141, 588.6119995, 145.16999816) '2862 Hillcrest Avenue
        Dim HCAID2 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -763.10699462, 615.90600585, 144.139999) '2868 Hillcrest Avenue
        Dim HCAID3 As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -857.79797363, 682.56298828, 152.6529998) '2874 Hillcrest Avenue
        Dim MRID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -572.60998535, 653.13000488, 145.63000488) '2117 Milton Road
        Dim WMDID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, 120.5, 549.952026367, 184.09700012207) '3677 Whispymound Drive
        Dim MWTDID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, -1288, 440.74798583, 97.694602966) '2113 Mad Wayne Thunder Drive

        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID1, "V_57_FranklinStuff")

        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, TID2, "swap_clean_apt")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, TID2, "layer_whiskey")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, TID2, "layer_sextoys_a")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, TID2, "swap_mrJam_A")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, TID2, "swap_sofa_A")

        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "V_Michael_bed_tidy")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "V_Michael_L_Items")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "V_Michael_S_Items")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "V_Michael_D_Items")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "V_Michael_M_Items")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "Michael_premier")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MID, "V_Michael_plane_ticket")

        'Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "showhome_only")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "franklin_settled")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "franklin_unpacking")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "bong_and_wine")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "progress_flyer")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "progress_tshirt")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "progress_tux")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, FID2, "unlocked")

        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, WODID, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, NCAID1, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, NCAID2, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, HCAID1, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, HCAID2, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, HCAID3, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MRID, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, WMDID, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._ENABLE_INTERIOR_PROP, MWTDID, "Stilts_Kitchen_Window")

        Native.Function.Call(Hash.REFRESH_INTERIOR, FID1)
        Native.Function.Call(Hash.REFRESH_INTERIOR, TID2)
        Native.Function.Call(Hash.REFRESH_INTERIOR, MID)
        Native.Function.Call(Hash.REFRESH_INTERIOR, FID2)

        Native.Function.Call(Hash.REFRESH_INTERIOR, WODID)
        Native.Function.Call(Hash.REFRESH_INTERIOR, NCAID1)
        Native.Function.Call(Hash.REFRESH_INTERIOR, NCAID2)
        Native.Function.Call(Hash.REFRESH_INTERIOR, HCAID1)
        Native.Function.Call(Hash.REFRESH_INTERIOR, HCAID2)
        Native.Function.Call(Hash.REFRESH_INTERIOR, HCAID3)
        Native.Function.Call(Hash.REFRESH_INTERIOR, MRID)
        Native.Function.Call(Hash.REFRESH_INTERIOR, WMDID)
        Native.Function.Call(Hash.REFRESH_INTERIOR, MWTDID)
    End Sub

    Public Sub UnLoadMPDLCMap()
        Try
            If My.Settings.NeverEnableMPMaps = False Then
                If My.Settings.AlwaysEnableMPMaps = False Then
                    Native.Function.Call(Hash._LOAD_SP_DLC_MAPS)
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SetInteriorActive2(X As Single, Y As Single, Z As Single)
        Try
            Dim interiorID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, X, Y, Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {interiorID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, interiorID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, interiorID, False)
            If Not interiorID = 0 AndAlso Not InteriorIDList.Contains(interiorID) Then InteriorIDList.Add(interiorID)
            ClearArea(X, Y, Z)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ClearArea(X As Single, Y As Single, Z As Single)
        Dim arguments As InputArgument() = New InputArgument() {X, Y, Z, 100, True, False, False, False}
        Native.Function.Call(Hash.CLEAR_AREA, arguments)
        Dim arguments2 As InputArgument() = New InputArgument() {X, Y, Z, 100, True, True, True, True, True}
    End Sub

    Public Sub ToggleIPL(iplName As String, Optional Vector3 As Vector3 = Nothing)
        If Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, New InputArgument() {iplName}) Then
            Native.Function.Call(Hash.REMOVE_IPL, New InputArgument() {iplName})
            Native.Function.Call(Hash.REQUEST_IPL, New InputArgument() {iplName})
        Else
            Native.Function.Call(Hash.REQUEST_IPL, New InputArgument() {iplName})
        End If
        If Not Vector3 = Nothing Then
            Dim intID As Integer = INMNative.Apartment.GetInteriorID(Vector3)
            If Not InteriorIDList.Contains(intID) AndAlso Not intID = 0 Then InteriorIDList.Add(intID)
        End If
    End Sub

    Public Function IsIPLActive(iplName As String) As Boolean
        Return Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, iplName)
    End Function

    Public Sub RemoveIPL(iplName As String)
        If Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, New InputArgument() {iplName}) Then
            Native.Function.Call(Hash.REMOVE_IPL, New InputArgument() {iplName})
        End If
    End Sub

    Public Sub ChangeIPL(LastIplName As String, NewIplName As String, Optional Vector3 As Vector3 = Nothing)
        On Error Resume Next
        Native.Function.Call(Hash.REMOVE_IPL, New InputArgument() {LastIplName})
        Native.Function.Call(Hash.REQUEST_IPL, New InputArgument() {NewIplName})
        If Not Vector3 = Nothing Then
            Dim intID As Integer = INMNative.Apartment.GetInteriorID(Vector3)
            If Not InteriorIDList.Contains(intID) AndAlso Not intID = 0 Then InteriorIDList.Add(intID)
        End If
    End Sub

    Enum IconType
        ChatBox = 1
        Email = 2
        AddFriendRequest = 3
        Nothing4 = 4
        Nothing5 = 5
        Nothing6 = 6
        RightJumpingArrow = 7
        RPIcon = 8
        DollarSignIcon = 9
    End Enum

    ''' CHAR_DEFAULT : Default profile pic
    ''' CHAR_FACEBOOK: Facebook
    ''' CHAR_SOCIAL_CLUB: Social Club Star
    ''' CHAR_CARSITE2: Super Auto San Andreas Car Site
    ''' CHAR_BOATSITE: Boat Site Anchor
    ''' CHAR_BANK_MAZE: Maze Bank Logo
    ''' CHAR_BANK_FLEECA: Fleeca Bank
    ''' CHAR_BANK_BOL: Bank Bell Icon
    ''' CHAR_MINOTAUR: Minotaur Icon
    ''' CHAR_EPSILON: Epsilon E
    ''' CHAR_MILSITE: Warstock W
    ''' CHAR_CARSITE: Legendary Motorsports Icon
    ''' CHAR_DR_FRIEDLANDER: Dr Freidlander Face
    ''' CHAR_BIKESITE: P and M Logo
    ''' CHAR_LIFEINVADER: Liveinvader
    ''' CHAR_PLANESITE: Plane Site E
    ''' CHAR_MICHAEL: Michael's Face
    ''' CHAR_FRANKLIN: Franklin's Face
    ''' CHAR_TREVOR: Trevor's Face
    ''' CHAR_SIMEON: Simeon's Face
    ''' CHAR_RON: Ron's Face
    ''' CHAR_JIMMY: Jimmy's Face
    ''' CHAR_LESTER: Lester's Shadowed Face
    ''' CHAR_DAVE: Dave Norton 's Face
    ''' CHAR_LAMAR: Chop's Face
    ''' CHAR_DEVIN: Devin Weston 's Face
    ''' CHAR_AMANDA: Amanda's Face
    ''' CHAR_TRACEY: Tracey's Face
    ''' CHAR_STRETCH: Stretch's Face
    ''' CHAR_WADE: Wade's Face
    ''' CHAR_MARTIN: Martin Madrazo 's Face
    ''' CHAR_ACTING_UP: Acting Icon
    Public Sub DisplayNotificationThisFrame(Sender As String, Subject As String, Message As String, Icon As String, Flash As Boolean, Type As IconType)
        Native.Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "CELL_EMAIL_BCON")
        Native.Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, Message)
        Native.Function.Call(Hash._SET_NOTIFICATION_MESSAGE, Icon, Icon, Flash, Type, Sender, Subject)
        Native.Function.Call(Hash._DRAW_NOTIFICATION, False, True)
    End Sub
End Module
