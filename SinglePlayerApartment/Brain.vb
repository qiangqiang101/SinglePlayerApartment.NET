Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports SinglePlayerApartment.SinglePlayerApartment

Public Class Brain
    Inherits Script

    Public Shared Bong, Whiskey, WhiskeyGlass, Wine, WineGlass, Wheat, Shower, TV, OrgNameProp As Prop
    Public Shared BongPosition, WhiskeyPosition, WhiskeyGlassPosition, WinePosition, WineGlassPosition, WheatPosition, ShowerPosition As Vector3
    Public Shared BongRotation, WhiskeyRotation, WhiskeyGlassRotation, WineRotation, WineGlassRotation, WheatRotation, ShowerRotation As Vector3
    Public Shared DrunkStage As Integer = 1

    Public Shared OrgNameModels As List(Of Model) = New List(Of Model) From {-2082168399}
    '<-- TV -->
    Public Shared TVModels As List(Of Model) = New List(Of Model) From {1036195894, 777010715, -1073182005, 1653710254, 170618079, -897601557, -1546399138, -1223496606, -1820646534, 608950395}
    Public Shared rendertargetid, ex_rendertargetid, rendertargetid2 As Integer
    Public Shared TVOn As Boolean = False, SubtitleOn As Boolean = False
    Public Shared TV_Volume As Integer = 0
    Public Shared TV_Channel As Integer
    Public Shared TVChannelList As List(Of Integer) = New List(Of Integer) From {0, 1}
    Public Shared TVCamera As Camera
    '<-- TV -->
    '<-- Radio -->
    Public Shared RadioModels As List(Of Model) = New List(Of Model) From {2079380440, -627813781, 1729911864, -1999188639}
    Public Shared RadioRoomsList As List(Of String) = New List(Of String) From {
        "SE_DLC_APT_Stilts_A_Bedroom", "SE_DLC_APT_Stilts_A_Heist_Room", "SE_DLC_APT_Stilts_A_Living_Room", "SE_DLC_APT_Stilts_B_Bedroom", "SE_DLC_APT_Stilts_B_Heist_Room", "SE_DLC_APT_Stilts_B_Living_Room",
        "SE_DLC_APT_Custom_Bedroom", "SE_DLC_APT_Custom_Heist_Room", "SE_DLC_APT_Custom_Living_Room", "SE_MP_GARAGE_L_RADIO", "SE_MP_AP_RAD_v_studio_lo_living", "SE_MP_AP_RAD_v_apart_midspaz_lounge", "SE_MP_APT_1_1",
        "SE_MP_APT_1_2", "SE_MP_APT_1_3", "SE_MP_APT_2_1", "SE_MP_APT_2_2", "SE_MP_APT_2_3", "SE_MP_APT_3_1", "SE_MP_APT_3_2", "SE_MP_APT_3_3", "SE_MP_APT_4_1", "SE_MP_APT_4_2", "SE_MP_APT_4_3", "SE_MP_APT_NEW_4_1",
        "SE_MP_APT_NEW_4_2", "SE_MP_APT_NEW_4_3", "SE_MP_APT_5_1", "SE_MP_APT_5_2", "SE_MP_APT_5_3", "SE_MP_APT_6_1", "SE_MP_APT_6_2", "SE_MP_APT_6_3", "SE_MP_APT_7_1", "SE_MP_APT_7_2", "SE_MP_APT_7_3", "SE_MP_APT_8_1",
        "SE_MP_APT_8_2", "SE_MP_APT_8_3", "SE_MP_APT_NEW_1_1", "SE_MP_APT_NEW_1_2", "SE_MP_APT_NEW_1_3", "SE_MP_APT_9_1", "SE_MP_APT_9_2", "SE_MP_APT_9_3", "SE_MP_APT_10_1", "SE_MP_APT_10_2", "SE_MP_APT_10_3",
        "SE_MP_APT_11_1", "SE_MP_APT_11_2", "SE_MP_APT_11_3", "SE_MP_APT_12_1", "SE_MP_APT_12_2", "SE_MP_APT_12_3", "SE_MP_APT_13_1", "SE_MP_APT_13_2", "SE_MP_APT_13_3", "SE_MP_APT_NEW_5_1", "SE_MP_APT_NEW_5_2",
        "SE_MP_APT_NEW_5_3", "SE_MP_APT_14_1", "SE_MP_APT_14_2", "SE_MP_APT_14_3", "SE_MP_APT_15_1", "SE_MP_APT_15_2", "SE_MP_APT_15_3", "SE_MP_APT_NEW_2_1", "SE_MP_APT_NEW_2_2", "SE_MP_APT_NEW_2_3", "SE_MP_APT_16_1",
        "SE_MP_APT_16_2", "SE_MP_APT_16_3", "SE_MP_APT_17_1", "SE_MP_APT_17_2", "SE_MP_APT_17_3", "SE_MP_APT_NEW_3_1", "SE_MP_APT_NEW_3_2", "SE_MP_APT_NEW_3_3", "SE_MP_GARAGE_M_RADIO"}
    'prop_mp3_dock  -627813781
    Public Shared RadioTaskScriptStatus As Integer = -1
    Public Shared RadioOn As Boolean = True
    '<-- Radio -->
    '<-- Bong -->
    Public Shared BongModels As List(Of Model) = New List(Of Model) From {-257549932}
    '                                                                     prop_bong_01
    Public Shared BongTaskScriptStatus As Integer = -1
    Public Shared BongStage As Integer = 1
    '<-- Bong -->
    '<-- Whiskey -->
    Public Shared WhiskeyModels As List(Of Model) = New List(Of Model) From {488156118}
    '                                                                    p_whiskey_bottle_s
    Public Shared WhiskeyGlassModels As List(Of Model) = New List(Of Model) From {-1533900808, 1480049515}
    '                                                                       p_tumbler_cs2_s, p_tumbler_01_s
    Public Shared WhiskeyTaskScriptStatus As Integer = -1
    '<-- Whiskey -->
    '<-- Wine -->
    Public Shared WineModels As List(Of Model) = New List(Of Model) From {21833643}
    '                                                                    prop_wine_bot_01
    Public Shared WineGlassModels As List(Of Model) = New List(Of Model) From {-35679191}
    '                                                                         p_wine_glass_s
    Public Shared WineTaskScriptStatus As Integer = -1
    '<-- Wine -->
    '<-- Wheat -->
    Public Shared WheatModels As List(Of Model) = New List(Of Model) From {469594741}
    '                                                                     p_w_grass_gls_s
    Public Shared WheatTaskScriptStatus As Integer = -1
    '<-- Wheat -->
    '<-- Shower -->
    Public Shared ShowerModels As List(Of Model) = New List(Of Model) From {1358716892, 1924030334}
    Public Shared ShowerTaskScriptStatus As Integer = -1
    '<-- Shower -->

    'Translate
    Public Shared _Bong, _Whiskey, _Wine, _Wheat, _Shower, _TVOn, _TVOff, _RadioSwitchStation, _TVChannel As String

    Public Shared a_d0, a_d1, a_d2, a_d3, a_d4, a_d5, a_d6, a_d7, a_d8, a_d9, a_d10, a_d11, a_t0, a_t1, a_t2, a_t3, a_t4, a_t5, a_t6, a_t7, a_t8, a_t9, a_t10, a_t11, b_d0, b_d1, b_d2, b_t0, b_t1, b_t2 As Integer
    Public Shared drunkTimer As Timer

    Public Shared MichaelHouseVector As Vector3 = New Vector3(-802.9922, 180.6833, 72.60551)
    Public Shared FranklinHouseVector As Vector3 = New Vector3(1.441366, 529.3953, 174.628)
    Public Shared MichaelHouseDistance As Single
    Public Shared FranklinHouseDistance As Single

    Public Sub New()
        Try
            Translate()
            drunkTimer = New Timer(60000)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GetPlayerClothes()
        a_d0 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_FACE)
        a_d1 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_HEAD)
        a_d2 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_HAIR)
        a_d3 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_TORSO)
        a_d4 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_LEGS)
        a_d5 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_HANDS)
        a_d6 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_FEET)
        a_d7 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_EYES)
        a_d8 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_ACCESSORIES)
        a_d9 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_TASKS)
        a_d10 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_TEXTURES)
        a_d11 = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, PedComponentsVars.COMPONET_TORSO2)
        a_t0 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_FACE)
        a_t1 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_HEAD)
        a_t2 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_HAIR)
        a_t3 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_TORSO)
        a_t4 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_LEGS)
        a_t5 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_HANDS)
        a_t6 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_FEET)
        a_t7 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_EYES)
        a_t8 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_ACCESSORIES)
        a_t9 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_TASKS)
        a_t10 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_TEXTURES)
        a_t11 = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, PedComponentsVars.COMPONET_TORSO2)
        b_d0 = Native.Function.Call(Of Integer)(Hash.GET_PED_PROP_INDEX, playerPed, PedPropsVars.PROP_HATS)
        b_d1 = Native.Function.Call(Of Integer)(Hash.GET_PED_PROP_INDEX, playerPed, PedPropsVars.PROP_GLASSES)
        b_d2 = Native.Function.Call(Of Integer)(Hash.GET_PED_PROP_INDEX, playerPed, PedPropsVars.PROP_EARS)
        b_t0 = Native.Function.Call(Of Integer)(Hash.GET_PED_PROP_TEXTURE_INDEX, playerPed, PedPropsVars.PROP_HATS)
        b_t1 = Native.Function.Call(Of Integer)(Hash.GET_PED_PROP_TEXTURE_INDEX, playerPed, PedPropsVars.PROP_GLASSES)
        b_t2 = Native.Function.Call(Of Integer)(Hash.GET_PED_PROP_TEXTURE_INDEX, playerPed, PedPropsVars.PROP_EARS)
    End Sub

    Public Shared Sub Drunked(amplitude As Single, drunkLevel As Integer, plusminus As String)
        Try
            GameplayCamera.Shake(CameraShake.Drunk, amplitude)
            Native.Function.Call(Hash.SET_PED_IS_DRUNK, playerPed.Handle, True)
            Select Case drunkLevel
                Case 1
                    If Not Native.Function.Call(Of Boolean)(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@slightlydrunk") Then
                        Native.Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@slightlydrunk")
                    End If
                    Native.Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, playerPed.Handle, "move_m@drunk@slightlydrunk", 1.0)
                Case 2
                    If Not Native.Function.Call(Of Boolean)(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk") Then
                        Native.Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@moderatedrunk")
                    End If
                    Native.Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, playerPed.Handle, "move_m@drunk@moderatedrunk", 1.0)
                Case 3
                    If Not Native.Function.Call(Of Boolean)(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@verydrunk") Then
                        Native.Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@verydrunk")
                    End If
                    Native.Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, playerPed.Handle, "move_m@drunk@verydrunk", 1.0)
            End Select
            If plusminus = "plus" Then
                DrunkStage = DrunkStage + 1
                drunkTimer.Start()
            ElseIf plusminus = "minus" Then
                DrunkStage = DrunkStage - 1
            End If
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub WineOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            Dim nearbyWineGlass As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((WineTaskScriptStatus = -1) AndAlso Not playerPed.IsInVehicle) AndAlso (WineModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 1.0)))) Then
                    DisplayHelpTextThisFrame(_Wine)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Wine = nearbyProps(i)
                        WineTaskScriptStatus = 0
                    End If
                End If
            Next i
            Select Case WineTaskScriptStatus
                Case 0
                    'playerPed.Heading = Wine.Heading - 90
                    WineTaskScriptStatus = 1
                Case 1
                    WinePosition = Wine.Position
                    WineRotation = Wine.Rotation
                    WineTaskScriptStatus = 2
                Case 2
                    For i As Integer = 0 To nearbyWineGlass.Length - 1
                        If WineGlassModels.Contains(nearbyWineGlass(i).Model) Then
                            WineGlass = nearbyWineGlass(i)
                        End If
                    Next
                    TaskPlayAnim(playerPed, "mp_safehousewine@", "drinking_wine", -1)
                    Wait(1000)
                    Wine.AttachTo(playerPed, playerPed.GetBoneIndex(Bone.PH_R_Hand), New Vector3(0.13, -0.1, -0.12), New Vector3(-60, 0, 0))
                    WineTaskScriptStatus = 3
                Case 3
                    If Wine.IsAttachedTo(playerPed) Then
                        WineGlassPosition = WineGlass.Position
                        WineGlassRotation = WineGlass.Rotation
                        Wait(500)
                        WineGlass.AttachTo(playerPed, playerPed.GetBoneIndex(Bone.PH_L_Hand), New Vector3(0.1, -0.09, 0.05), New Vector3(-100, 10, 0))
                        WineTaskScriptStatus = 4
                    End If
                Case 4
                    If WineGlass.IsAttachedTo(playerPed) Then
                        Wait(5000)
                        Wine.Detach()
                        Wine.Position = WinePosition
                        Wine.Rotation = WineRotation
                        Wait(9000)
                        WineGlass.Detach()
                        WineGlass.Position = WineGlassPosition
                        WineGlass.Rotation = WineGlassRotation
                        WineTaskScriptStatus = 5
                    End If
                Case 5
                    If DrunkStage = 1 Then
                        DrunkStage = DrunkStage + 1
                    ElseIf DrunkStage = 2 Then
                        Drunked(0.2, 1, "plus")
                    ElseIf DrunkStage = 3 Then
                        Drunked(0.4, 1, "plus")
                    ElseIf DrunkStage = 4 Then
                        Drunked(0.6, 2, "plus")
                    ElseIf DrunkStage = 5 Then
                        Drunked(0.8, 2, "plus")
                    ElseIf DrunkStage = 6 Then
                        Drunked(1.0, 3, "plus")
                    ElseIf DrunkStage = 7 Then
                        Drunked(1.2, 3, "plus")
                    ElseIf DrunkStage = 8 Then
                        Drunked(1.4, 3, "plus")
                    ElseIf DrunkStage = 9 Then
                        'drunked
                        Native.Function.Call(Hash.SET_PED_TO_RAGDOLL, playerPed, 650, 650, 1, 1, 1, 0)
                        Wait(2000)
                        Game.FadeScreenOut(500)
                        Wait(500)
                        TimeLapse(8)
                        GameplayCamera.StopShaking()
                        Native.Function.Call(Hash.SET_PED_IS_DRUNK, playerPed.Handle, False)
                        Native.Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, playerPed.Handle, 0.0)
                        DrunkStage = 1
                        Wait(500)
                        Game.FadeScreenIn(500)
                        Native.Function.Call(Hash.SET_PED_TO_RAGDOLL, playerPed, -1, -1, 0, 1, 1, 0)
                    End If
                    WineTaskScriptStatus = -1
            End Select

            If (Game.Player.IsDead OrElse Game.Player.Character.IsRagdoll) Then
                Wine.Detach()
                WineGlass.Detach()
                Wine.Position = WinePosition
                Wine.Rotation = WineRotation
                WineGlass.Position = WineGlassPosition
                WineGlass.Rotation = WineGlassRotation
                WineTaskScriptStatus = -1
            End If
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub WhiskeyOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            Dim nearbyWhiskeyGlass As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((WhiskeyTaskScriptStatus = -1) AndAlso Not playerPed.IsInVehicle) AndAlso (WhiskeyModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 1.0)))) Then
                    DisplayHelpTextThisFrame(_Whiskey)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Whiskey = nearbyProps(i)
                        WhiskeyTaskScriptStatus = 0
                    End If
                End If
            Next i
            Select Case WhiskeyTaskScriptStatus
                Case 0
                    'playerPed.Heading = Whiskey.Heading
                    WhiskeyTaskScriptStatus = 1
                Case 1
                    WhiskeyPosition = Whiskey.Position
                    WhiskeyRotation = Whiskey.Rotation
                    WhiskeyTaskScriptStatus = 2
                Case 2
                    For i As Integer = 0 To nearbyWhiskeyGlass.Length - 1
                        If WhiskeyGlassModels.Contains(nearbyWhiskeyGlass(i).Model) Then
                            WhiskeyGlass = nearbyWhiskeyGlass(i)
                        End If
                    Next
                    TaskPlayAnim(playerPed, "mp_safehousewhiskey@", "enter", -1)
                    Wait(1500)
                    Whiskey.AttachTo(playerPed, playerPed.GetBoneIndex(Bone.PH_R_Hand), New Vector3(0.06, -0.04, -0.06), New Vector3(-60, 0, 0))
                    WhiskeyTaskScriptStatus = 3
                Case 3
                    If Whiskey.IsAttachedTo(playerPed) Then
                        WhiskeyGlassPosition = WhiskeyGlass.Position
                        WhiskeyGlassRotation = WhiskeyGlass.Rotation
                        Wait(5000)
                        WhiskeyGlass.AttachTo(playerPed, playerPed.GetBoneIndex(Bone.IK_L_Hand), New Vector3(0.1, 0, 0.04), New Vector3(-100, 10, 0))
                        Whiskey.Detach()
                        Whiskey.Position = WhiskeyPosition
                        Whiskey.Rotation = WhiskeyRotation
                        WhiskeyTaskScriptStatus = 4
                    End If
                Case 4
                    If WhiskeyGlass.IsAttachedTo(playerPed) Then
                        Wait(4000)
                        WhiskeyGlass.Detach()
                        WhiskeyGlass.Position = WhiskeyGlassPosition
                        WhiskeyGlass.Rotation = WhiskeyGlassRotation
                        WhiskeyTaskScriptStatus = 5
                    End If
                Case 5
                    If DrunkStage = 1 Then
                        DrunkStage = DrunkStage + 1
                    ElseIf DrunkStage = 2 Then
                        Drunked(0.2, 1, "plus")
                    ElseIf DrunkStage = 3 Then
                        Drunked(0.4, 1, "plus")
                    ElseIf DrunkStage = 4 Then
                        Drunked(0.6, 2, "plus")
                    ElseIf DrunkStage = 5 Then
                        Drunked(0.8, 2, "plus")
                    ElseIf DrunkStage = 6 Then
                        Drunked(1.0, 3, "plus")
                    ElseIf DrunkStage = 7 Then
                        Drunked(1.2, 3, "plus")
                    ElseIf DrunkStage = 8 Then
                        Drunked(1.4, 3, "plus")
                    ElseIf DrunkStage = 9 Then
                        'drunked
                        Native.Function.Call(Hash.SET_PED_TO_RAGDOLL, playerPed, 650, 650, 1, 1, 1, 0)
                        Wait(2000)
                        Game.FadeScreenOut(500)
                        Wait(500)
                        TimeLapse(8)
                        GameplayCamera.StopShaking()
                        Native.Function.Call(Hash.SET_PED_IS_DRUNK, playerPed.Handle, False)
                        Native.Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, playerPed.Handle, 0.0)
                        DrunkStage = 1
                        Wait(500)
                        Game.FadeScreenIn(500)
                        Native.Function.Call(Hash.SET_PED_TO_RAGDOLL, playerPed, -1, -1, 0, 1, 1, 0)
                    End If
                    WhiskeyTaskScriptStatus = -1
            End Select

            If (Game.Player.IsDead OrElse Game.Player.Character.IsRagdoll) Then
                Whiskey.Detach()
                WhiskeyGlass.Detach()
                Whiskey.Position = WhiskeyPosition
                Whiskey.Rotation = WhiskeyRotation
                WhiskeyGlass.Position = WhiskeyGlassPosition
                WhiskeyGlass.Rotation = WhiskeyGlassRotation
                WhiskeyTaskScriptStatus = -1
            End If
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ShowerOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((ShowerTaskScriptStatus = -1) AndAlso Not playerPed.IsInVehicle) AndAlso (ShowerModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 1.0)))) Then
                    DisplayHelpTextThisFrame(_Shower)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Shower = nearbyProps(i)
                        ShowerTaskScriptStatus = 0
                    End If
                End If
            Next i

            Select Case ShowerTaskScriptStatus
                Case 0
                    If GetPlayerName() = "Michael" Then
                        GetPlayerClothes()

                        Game.FadeScreenOut(500)
                        Wait(500)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, 26, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, 18, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, 2, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, -1, -1, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, -1, -1, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, -1, -1, 2)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_undress_&_turn_on_water", -1)
                        Wait(500)
                        Game.FadeScreenIn(500)
                        Wait(7000)
                        '
                        'Need Help Here I can't find the Asset for "ent_amb_shower" and "ent_amb_shower_steam".
                        PlayPTFXLoop("core", "ent_amb_shower", -60, 0, Shower.Position)
                        PlayPTFXLoop("core", "ent_amb_shower_steam", -60, 0, Shower.Position)
                        '
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_enter_into_idle", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_a", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_b", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_c", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_d", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_towel_dry_to_get_dressed", -1)
                        Wait(9000)
                    ElseIf GetPlayerName() = "Franklin" Then
                        GetPlayerClothes()

                        Game.FadeScreenOut(500)
                        Wait(500)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, 26, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, 18, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, 5, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 14, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, -1, -1, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, -1, -1, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, -1, -1, 2)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_undress_&_turn_on_water", -1)
                        Wait(500)
                        Game.FadeScreenIn(500)
                        Wait(7000)
                        '
                        'Need Help Here I can't find the Asset for "ent_amb_shower" and "ent_amb_shower_steam".
                        PlayPTFXLoop("core", "ent_amb_shower", -60, 0, Shower.Position)
                        PlayPTFXLoop("core", "ent_amb_shower_steam", -60, 0, Shower.Position)
                        '
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_enter_into_idle", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_a", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_b", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_c", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_d", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_towel_dry_to_get_dressed", -1)
                    ElseIf GetPlayerName() = “Trevor"
                        GetPlayerClothes()

                        Game.FadeScreenOut(500)
                        Wait(500)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, 16, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, 22, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, 1, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, -1, -1, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, -1, -1, 2)
                        Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, -1, -1, 2)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
                        Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_undress_&_turn_on_water", -1)
                        Wait(500)
                        Game.FadeScreenIn(500)
                        Wait(7000)
                        '
                        'Need Help Here I can't find the Asset for "ent_amb_shower" and "ent_amb_shower_steam".
                        PlayPTFXLoop("core", "ent_amb_shower", -60, 0, Shower.Position)
                        PlayPTFXLoop("core", "ent_amb_shower_steam", -60, 0, Shower.Position)
                        '
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_enter_into_idle", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_a", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_b", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_c", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_d", -1)
                        Wait(9000)
                        TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_towel_dry_to_get_dressed", -1)
                        Wait(9000)
                    ElseIf GetPlayerName() = "Player3" Then
                        If Game.Player.Character.Model.GetHashCode = 1885233650 Then
                            GetPlayerClothes()

                            Game.FadeScreenOut(500)
                            Wait(500)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, 14, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, 0, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, 5, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2)
                            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, -1, -1, 2)
                            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, -1, -1, 2)
                            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, -1, -1, 2)
                            Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
                            Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
                            Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_undress_&_turn_on_water", -1)
                            Wait(500)
                            Game.FadeScreenIn(500)
                            Wait(7000)
                            '
                            'Need Help Here I can't find the Asset for "ent_amb_shower" and "ent_amb_shower_steam".
                            PlayPTFXLoop("core", "ent_amb_shower", -60, 0, Shower.Position)
                            PlayPTFXLoop("core", "ent_amb_shower_steam", -60, 0, Shower.Position)
                            '
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_enter_into_idle", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_a", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_b", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_c", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_idle_d", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@male@", "male_shower_towel_dry_to_get_dressed", -1)
                            Wait(9000)
                        ElseIf Game.Player.Character.Model.GetHashCode = -1667301416 Then
                            GetPlayerClothes()

                            Game.FadeScreenOut(500)
                            Wait(500)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, 0, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, 5, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 15, 0, 2)
                            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2)
                            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, -1, -1, 2)
                            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, -1, -1, 2)
                            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, -1, -1, 2)
                            Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
                            Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
                            Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_undress_&_turn_on_water", -1)
                            Wait(500)
                            Game.FadeScreenIn(500)
                            Wait(7000)
                            '
                            'Need Help Here I can't find the Asset for "ent_amb_shower" and "ent_amb_shower_steam".
                            PlayPTFXLoop("core", "ent_amb_shower", -60, 0, Shower.Position)
                            PlayPTFXLoop("core", "ent_amb_shower_steam", -60, 0, Shower.Position)
                            '
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_enter_into_idle", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_idle_a", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_idle_b", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_idle_c", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_idle_d", -1)
                            Wait(9000)
                            TaskPlayAnim(playerPed, "mp_safehouseshower@female@", "shower_towel_dry_to_get_dressed", -1)
                            Wait(9000)
                        End If
                    End If
                    ShowerTaskScriptStatus = 1
                Case 1
                    Game.FadeScreenOut(500)
                    Wait(500)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 0, a_d0, a_t0, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 1, a_d1, a_t1, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 2, a_d2, a_t2, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, a_d3, a_t3, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, a_d4, a_t4, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, a_d5, a_t5, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, a_d6, a_t6, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 7, a_d7, a_t7, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, a_d8, a_t8, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 9, a_d9, a_t9, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, a_d11, a_t11, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, a_d10, a_t10, 2)
                    Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, b_d0, b_t0, 2)
                    Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, b_d1, b_t1, 2)
                    Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, b_d2, b_t2, 2)
                    playerPed.ClearBloodDamage()
                    Wait(500)
                    Game.FadeScreenIn(500)
                    ShowerTaskScriptStatus = -1
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub WheatOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((WheatTaskScriptStatus = -1) AndAlso Not playerPed.IsInVehicle) AndAlso (WheatModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 1.0)))) Then
                    DisplayHelpTextThisFrame(_Wheat)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Wheat = nearbyProps(i)
                        WheatTaskScriptStatus = 0
                    End If
                End If
            Next i
            Select Case WheatTaskScriptStatus
                Case 0
                    'playerPed.Heading = Wheat.Heading - 180
                    WheatTaskScriptStatus = 1
                Case 1
                    WheatPosition = Wheat.Position
                    WheatRotation = Wheat.Rotation
                    WheatTaskScriptStatus = 2
                Case 2
                    TaskPlayAnim(playerPed, "mp_safehousewheatgrass@", "ig_2_wheatgrassdrink_michael", -1)
                    Wait(1500)
                    Wheat.AttachTo(playerPed, playerPed.GetBoneIndex(Bone.PH_R_Hand), Vector3.Zero, Vector3.Zero)
                    WheatTaskScriptStatus = 3
                Case 3
                    If Wheat.IsAttachedTo(playerPed) Then
                        Wait(5000)
                        Wheat.Detach()
                        Wheat.Position = WheatPosition
                        Wheat.Rotation = WheatRotation
                        WheatTaskScriptStatus = 4
                    End If
                Case 4
                    If DrunkStage = 2 Then
                        GameplayCamera.StopShaking()
                        Native.Function.Call(Hash.SET_PED_IS_DRUNK, playerPed.Handle, False)
                        Native.Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, playerPed.Handle, 0.0)
                        DrunkStage = 1
                    ElseIf DrunkStage = 3 Then
                        Drunked(0.2, 1, "minus")
                    ElseIf DrunkStage = 4 Then
                        Drunked(0.4, 1, "minus")
                    ElseIf DrunkStage = 5 Then
                        Drunked(0.6, 2, "minus")
                    ElseIf DrunkStage = 6 Then
                        Drunked(0.8, 2, "minus")
                    ElseIf DrunkStage = 7 Then
                        Drunked(1.0, 3, "minus")
                    ElseIf DrunkStage = 8 Then
                        Drunked(1.2, 3, "minus")
                    End If
                    WheatTaskScriptStatus = -1
            End Select

            If (Game.Player.IsDead OrElse Game.Player.Character.IsRagdoll) Then
                Wheat.Detach()
                Wheat.Position = WheatPosition
                Wheat.Rotation = WheatRotation
                WheatTaskScriptStatus = -1
            End If
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub RadioOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((RadioTaskScriptStatus = -1) AndAlso Not playerPed.IsInVehicle) AndAlso (RadioModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 1.5)))) Then
                    DisplayHelpTextThisFrame(_RadioSwitchStation)
                    If Game.IsControlJustPressed(0, GTA.Control.VehicleRadioWheel) Then
                        RadioTaskScriptStatus = 0
                    ElseIf Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        'Dim tempAPA As INMNative.Apartment = GetPlayerCurrentApartment()
                        'If tempAPA.BedRoomRadio = Nothing Then tempAPA.BedRoomRadio = CreatePropNoOffset("prop_boombox_01", tempAPA.BedRoomRadioPosition, False)
                        'If tempAPA.LivingRoomRadio = Nothing Then tempAPA.LivingRoomRadio = CreatePropNoOffset("prop_boombox_01", tempAPA.LivingRoomRadioPosition, False)
                        'If tempAPA.HeistRoomRadio = Nothing Then tempAPA.HeistRoomRadio = CreatePropNoOffset("prop_boombox_01", tempAPA.HeistRoomRadioPosition, False)
                        'If RadioOn Then
                        '    TurnOffRadio(tempAPA.BedRoomRadio, tempAPA.HeistRoomRadio, tempAPA.LivingRoomRadio, tempAPA.BedRoomEmitter, tempAPA.HeistRoomEmitter, tempAPA.LivingRoomEmitter)
                        'Else
                        '    TurnOnRadio(tempAPA.BedRoomRadio, tempAPA.HeistRoomRadio, tempAPA.LivingRoomRadio, tempAPA.BedRoomEmitter, tempAPA.HeistRoomEmitter, tempAPA.LivingRoomEmitter)
                        'End If
                        RadioOn = Not RadioOn
                    End If
                End If
            Next i
            Select Case RadioTaskScriptStatus
                Case 0
                    If Game.IsControlJustReleased(0, GTA.Control.VehicleRadioWheel) Then
                        RadioTaskScriptStatus = -1
                    End If
            End Select
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub TVOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((TVOn = False) AndAlso Not playerPed.IsInVehicle) AndAlso (TVModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 2.0)))) Then
                    DisplayHelpTextThisFrame(_TVOn)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        TV = nearbyProps(i)
                        Native.Function.Call(Hash.ATTACH_TV_AUDIO_TO_ENTITY, TV)
                        If Not Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "tvscreen") Then
                            Native.Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "tvscreen", False)
                        End If
                        If Not Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ex_tvscreen") Then
                            Native.Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "ex_tvscreen", False)
                        End If
                        If Not Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_LINKED, TV.Model) Then
                            Native.Function.Call(Hash.LINK_NAMED_RENDERTARGET, TV.Model)
                            rendertargetid = Native.Function.Call(Of Integer)(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "tvscreen")
                            ex_rendertargetid = Native.Function.Call(Of Integer)(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "ex_tvscreen")
                        End If
                        Dim r As Random = New Random()
                        TV_Channel = r.Next(2)
                        Native.Function.Call(Hash.SET_TV_CHANNEL, TV_Channel)
                        Native.Function.Call(Hash.SET_TV_VOLUME, TV_Volume)
                        TVOn = True
                    End If
                ElseIf ((((TVOn = True) AndAlso Not playerPed.IsInVehicle) AndAlso (TVModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 2.0)))) Then
                    DisplayHelpTextThisFrame(_TVChannel)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Wait(1000)
                        If Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "tvscreen") Then
                            Native.Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "tvscreen")
                        End If
                        If Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "ex_tvscreen") Then
                            Native.Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, "ex_tvscreen")
                        End If
                        TVOn = False
                    ElseIf Game.IsControlJustPressed(0, GTA.Control.VehicleRadioWheel) Then
                        Select Case TV_Channel
                            Case 0
                                TV_Channel = 1
                            Case 1
                                TV_Channel = 0
                        End Select
                        Native.Function.Call(Hash.SET_TV_CHANNEL, TV_Channel)
                        TVOn = True
                    ElseIf Game.IsControlJustPressed(0, GTA.Control.Jump) AndAlso SubtitleOn = False Then
                        Native.Function.Call(Hash.ENABLE_MOVIE_SUBTITLES, True)
                        SubtitleOn = True
                    ElseIf Game.IsControlJustPressed(0, GTA.Control.Jump) AndAlso SubtitleOn = True Then
                        Native.Function.Call(Hash.ENABLE_MOVIE_SUBTITLES, False)
                        SubtitleOn = False
                    End If
                End If
            Next i
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub OrganisationNameOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If (((OrgNameModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 10.0)))) Then
                    OrgNameProp = nearbyProps(i)
                    Native.Function.Call(Hash.ATTACH_TV_AUDIO_TO_ENTITY, OrgNameProp)
                    Native.Function.Call(&H67D02A194A2FC2BD, "ORGANISATION_NAME")

                    If Not Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, "prop_ex_office_text") Then
                        Native.Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, "prop_ex_office_text", False)
                    End If
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_LINKED, OrgNameProp.Model) Then
                        Native.Function.Call(Hash.LINK_NAMED_RENDERTARGET, OrgNameProp.Model)
                        rendertargetid2 = Native.Function.Call(Of Integer)(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, "prop_ex_office_text")
                        Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, rendertargetid2, "SET_ORGANISATION_NAME")
                    End If
                    Dim r As Random = New Random()


                    Native.Function.Call(Hash.SET_TEXT_RENDER_ID, rendertargetid2)
                    Native.Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, rendertargetid2, "SET_ORGANISATION_NAME")
                    Native.Function.Call(&H77FE3402004CD1B0, "SPA")
                    Native.Function.Call(Hash.SET_TV_CHANNEL, -1)
                    Native.Function.Call(Hash.DRAW_TV_CHANNEL, 0.5, 0.5, 1.0, 1.0, 0.0, 255, 255, 255, 255)
                    Native.Function.Call(Hash.SET_TEXT_RENDER_ID, Native.Function.Call(Of Integer)(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID))
                End If
            Next i
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub BongOnTick()
        Try
            Dim nearbyProps As Prop() = World.GetNearbyProps(Game.Player.Character.Position, 3.0)
            For i As Integer = 0 To nearbyProps.Length - 1
                If ((((BongTaskScriptStatus = -1) AndAlso Not playerPed.IsInVehicle) AndAlso (BongModels.Contains(nearbyProps(i).Model) AndAlso (playerPed.Position.DistanceTo(nearbyProps(i).Position) <= 1.0)))) Then
                    DisplayHelpTextThisFrame(_Bong)
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        Bong = nearbyProps(i)
                        BongTaskScriptStatus = 0
                    End If
                End If
            Next i
            Select Case BongTaskScriptStatus
                Case 0
                    'playerPed.Heading = Bong.Heading
                    BongTaskScriptStatus = 1
                Case 1
                    BongPosition = Bong.Position
                    BongRotation = Bong.Rotation
                    BongTaskScriptStatus = 2
                Case 2
                    If BongStage = 1 Then
                        TaskPlayAnim(playerPed, "anim@safehouse@bong", "bong_stage1", -1)
                        BongStage = BongStage + 1
                    ElseIf BongStage = 2 Then
                        TaskPlayAnim(playerPed, "anim@safehouse@bong", "bong_stage2", -1)
                        BongStage = BongStage + 1
                    ElseIf BongStage = 3 Then
                        TaskPlayAnim(playerPed, "anim@safehouse@bong", "bong_stage3", -1)
                        BongStage = BongStage + 1
                    ElseIf BongStage = 4 Then
                        TaskPlayAnim(playerPed, "anim@safehouse@bong", "bong_stage4", -1)
                        BongStage = 1
                    End If
                    Wait(1500)
                    Bong.AttachTo(playerPed, playerPed.GetBoneIndex(Bone.PH_L_Hand), Vector3.Zero, Vector3.Zero)
                    BongTaskScriptStatus = 3
                Case 3
                    If Bong.IsAttachedTo(playerPed) Then
                        Wait(7000)
                        'PlayPTFX(playerPed, "scr_sh_bong_smoke", "scr_apartment_mp", playerPed.GetBoneCoord(Bone.SKEL_Head, Vector3.Zero), Shower.Rotation)
                        Wait(2000)
                        Bong.Detach()
                        Bong.Position = BongPosition
                        Bong.Rotation = BongRotation
                        BongTaskScriptStatus = 4
                    End If
                Case 4
                    Native.Function.Call(Hash._START_SCREEN_EFFECT, New InputArgument() {"DrugsDrivingIn", 5000, False})
                    Wait(5000)
                    Native.Function.Call(Hash._STOP_SCREEN_EFFECT, New InputArgument() {"DrugsDrivingIn"})
                    Native.Function.Call(Hash._START_SCREEN_EFFECT, New InputArgument() {"DrugsDrivingOut", 5000, False})
                    Wait(5000)
                    Native.Function.Call(Hash._STOP_SCREEN_EFFECT, New InputArgument() {"DrugsDrivingOut"})
                    BongTaskScriptStatus = -1
            End Select

            If (Game.Player.IsDead OrElse Game.Player.Character.IsRagdoll) Then
                Bong.Detach()
                Bong.Position = BongPosition
                Bong.Rotation = BongRotation
                BongTaskScriptStatus = -1
            End If
        Catch ex As Exception
            'logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            If Not Game.IsLoading Then
                MichaelHouseDistance = World.GetDistance(playerPed.Position, MichaelHouseVector)
                FranklinHouseDistance = World.GetDistance(playerPed.Position, FranklinHouseVector)

                If (MichaelHouseDistance > 50.0 AndAlso FranklinHouseDistance > 50.0) AndAlso InteriorIDList.Contains(playerInterior) Then
                    BongOnTick()
                    WhiskeyOnTick()
                    WineOnTick()
                    WheatOnTick()
                    ShowerOnTick()
                    TVOnTick()
                    RadioOnTick()
                    OrganisationNameOnTick()
                End If

                If drunkTimer.Enabled Then

                    If Game.GameTime > drunkTimer.Waiter Then
                        drunkTimer.Enabled = False
                        GameplayCamera.StopShaking()
                        Native.Function.Call(Hash.SET_PED_IS_DRUNK, playerPed.Handle, False)
                        Native.Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, playerPed.Handle, 0.0)
                        DrunkStage = 1
                    End If
                End If

                If TVOn Then
                    Native.Function.Call(Hash.SET_TEXT_RENDER_ID, rendertargetid)
                    Native.Function.Call(Hash.DRAW_TV_CHANNEL, 0.5, 0.5, 1.0, 1.0, 0.0, 255, 255, 255, 255)
                    Native.Function.Call(Hash.SET_TEXT_RENDER_ID, Native.Function.Call(Of Integer)(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID))

                    Native.Function.Call(Hash.SET_TEXT_RENDER_ID, ex_rendertargetid)
                    Native.Function.Call(Hash.DRAW_TV_CHANNEL, 0.5, 0.5, 1.0, 1.0, 0.0, 255, 255, 255, 255)
                    Native.Function.Call(Hash.SET_TEXT_RENDER_ID, Native.Function.Call(Of Integer)(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID))
                End If



            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
