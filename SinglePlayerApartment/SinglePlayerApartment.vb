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

Public Class SinglePlayerApartment
    Inherits Script

    Public Shared player As Player
    Public Shared playerPed As Ped
    Public Shared playerCash As Integer
    Public Shared playerName As String
    Public Shared playerHash As String
    Public Shared saveFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\save.cfg"
    Public Shared uiLanguage As String
    Public Shared playerMap As String

    'Translate
    Public Shared ExitApt, SellApt, EnterGarage, AptOptions, Garage, GrgOptions, _Mechanic, ChooseApt, ChooseVeh As String

    Private teleported As Boolean = False
    Private franklinSafeHouse As Vector3 = New Vector3(7.1190319061279, 536.61511230469, 176.02365112305)
    Private michaelSafeHouse As Vector3 = New Vector3(-813.60302734375, 179.47380065918, 72.158325195313)
    Private trevorSafeHouse As Vector3 = New Vector3(1972.6002197266, 3817.0407714844, 33.426822662354)
    Private trevorSafeHouse2 As Vector3 = New Vector3(96.154197692871, -1290.7312011719, 29.266660690308)
    Private franklinSafeHouseDist, michaelSafeHouseDist, trevorSafeHouseDist, trevorSafeHouseDist2 As Single

    'Public Shared _menuPool As MenuPool
    Public Shared hideHud As Boolean = False
    Public Shared _scaleform As Scaleform
    Public Shared _displayTimer As Timer
    Public Shared _fadeTimer As Timer

    Public Sub New()
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            playerCash = player.Money
            playerHash = player.Character.Model.Hash.ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            Else
                playerName = "None"
            End If
            uiLanguage = Game.Language.ToString

            If uiLanguage = "Chinese" Then
                ExitApt = "离开公寓"
                SellApt = "出售產業"
                EnterGarage = "進入車庫"
                AptOptions = "公寓選項"
                Garage = "車庫"
                GrgOptions = "車庫選項"
                _Mechanic = "機械師"
                ChooseApt = "選擇公寓"
                ChooseVeh = "選擇車輛"
            Else
                ExitApt = "Exit Apartment"
                SellApt = "Sell Property"
                EnterGarage = "Enter Garage"
                AptOptions = "APARTMENT OPTIONS"
                Garage = " Garage"
                GrgOptions = "GARAGE OPTIONS"
                _Mechanic = "Mechanic"
                ChooseApt = "CHOOSE APARTMENT"
                ChooseVeh = "CHOOSE VEHICLE"
            End If

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            LoadSettingFromCFG()
            LoadMPDLCMap()

            'SetInteriorActive2(-280.74, -961.5, 91.11) '3 alta street 57
            'SetInteriorActive2(-909.054, -441.466, 120.205) 'weazel plaza 70
            'SetInteriorActive2(-897.197, -369.246, 84.0779) 'richards majestic 4
            'SetInteriorActive2(-575.305, 42.3233, 92.2236) 'tinsel tower 29
            'SetInteriorActive2(-795.04, 342.37, 206.22) 'eclipse tower 5
            'SetInteriorActive2(-37.41, -582.82, 88.71) '4 integrity way 30
            'SetInteriorActive2(-1477.14, -538.75, 55.5264) 'del perro 7
            'SetInteriorActive2(343.85, -999.08, -99.198) 'midrange apartment
            'SetInteriorActive2(222.592, -968.1, -99) '10 car garage

            EclipseTower.CreateEclipseTower()
            _3AltaStreet.Create3AltaStreet()
            _4IntegrityWay.Create4IntegrityWay()
            DelPerroHeight.CreateDelPerroHeight()
            RichardMajestic.CreateRichardsMajestic()
            TinselTower.CreateTinselTower()
            WeazelPlaza.CreateWeazelPlaza()
            DreamTower.CreateDreamTower()

            _displayTimer = New Timer(2200)
            _fadeTimer = New Timer(2000)
            _scaleform = New Scaleform([Function].[Call](Of Integer)(Hash.REQUEST_SCALEFORM_MOVIE, "MP_BIG_MESSAGE_FREEMODE"))
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetBlipName(ByVal BlipString As String, ByVal BlipName As Blip)
        Try
            Dim arguments As InputArgument() = New InputArgument() {"STRING"}
            Native.Function.Call(Hash._0xF9113A30DE5C6670, arguments)
            Native.Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, BlipString)
            Native.Function.Call(Hash._0xBC38B49BCB83BC9B, BlipName)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub DisplayHelpTextThisFrame(ByVal [text] As String)
        Try
            Dim arguments As InputArgument() = New InputArgument() {"STRING"}
            Native.Function.Call(Hash._0x8509B634FBE7DA11, arguments)
            Dim argumentArray2 As InputArgument() = New InputArgument() {[text]}
            Native.Function.Call(Hash._0x6C188BE134E074AA, argumentArray2)
            Dim argumentArray3 As InputArgument() = New InputArgument() {0, 0, 1, -1}
            Native.Function.Call(Hash._0x238FFE5C7B0498A6, argumentArray3)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub TimeLapse(ByVal SleepHour As Integer)
        Try
            Dim hour As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_HOURS)
            Dim minute As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MINUTES)
            Dim second As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_SECONDS)
            Dim day As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_DAY_OF_MONTH)
            Dim month As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MONTH)
            Dim year As Integer = Native.Function.Call(Of Integer)(Hash.GET_CLOCK_YEAR)
            Native.Function.Call(Hash.ADD_TO_CLOCK_TIME, hour + SleepHour, minute, second)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadMPDLCMap()
        Try
            Native.Function.Call(Hash._LOAD_MP_DLC_MAPS)
            Native.Function.Call(Hash._ENABLE_MP_DLC_MAPS, New Native.InputArgument() {1})
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetInteriorActive2(X As Single, Y As Single, Z As Single)
        Try
            Dim interiorID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, X, Y, Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {interiorID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, interiorID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, interiorID, False)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetInteriorInActive(X As Single, Y As Single, Z As Single)
        Try
            Dim interiorID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, X, Y, Z)
            Native.Function.Call(Hash.DISABLE_INTERIOR, interiorID, True)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ToggleIPL(iplName As String)
        If Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, New InputArgument() {iplName}) Then
            Native.Function.Call(Hash.REMOVE_IPL, New InputArgument() {iplName})
        Else
            Native.Function.Call(Hash.REQUEST_IPL, New InputArgument() {iplName})
        End If
    End Sub

    Enum TelevisionModel
        HighLifeAptTV = 777010715
        HighEndAptTV = 1036195894
        TrevorTV = 1434219911
        'LowEndAptTV = 3397365739
    End Enum

    Public Shared Sub TurnOnTV(X As Single, Y As Single, Z As Single, Model As TelevisionModel)
        Dim TV As Entity = Native.Function.Call(Of Entity)(Hash.CREATE_OBJECT, Model, X, Y, Z, True, True, False)
        Native.Function.Call(Hash.ATTACH_TV_AUDIO_TO_ENTITY, TV)
        Dim tvScreen As String = Native.Function.Call(Of String)(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID)
        If Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, tvScreen) Then
            Native.Function.Call(Hash.REGISTER_NAMED_RENDERTARGET, tvScreen, 0)
        End If

        Dim renderTargetID As Integer
        Dim tvModel As String = Native.Function.Call(Of String)(Hash.GET_ENTITY_MODEL, TV)
        If Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_LINKED, tvModel) Then
            Native.Function.Call(Hash.LINK_NAMED_RENDERTARGET, tvModel)
            renderTargetID = Native.Function.Call(Of Integer)(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, tvScreen)
        End If

        Native.Function.Call(Hash.SET_TV_CHANNEL, 0) 'TV Channel 0 or 1
        Native.Function.Call(Hash.SET_TV_VOLUME, 0) 'TV Volume Float in range from -22.5 till 0

        If Native.Function.Call(Of Boolean)(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_ANY_PED, TV) Then
            Native.Function.Call(Hash.SET_TEXT_RENDER_ID, renderTargetID)
            Native.Function.Call(Hash._0x61BB1D9B3A95D802, 4)
            Native.Function.Call(Hash._0xC6372ECD45D73BCD, 1)
            Dim tvBright As Integer = 255 'TV Bright in range from 0 to 255
            Native.Function.Call(Hash.DRAW_TV_CHANNEL, 0.5, 0.5, 1, 1, 0, 255, 255, 255, tvBright)
            'Native.Function.Call(Hash.SET_TEXT_RENDER_ID, Native.Function.Call(Of Integer)(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID))
        End If

        If Native.Function.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, tvScreen) Then
            Native.Function.Call(Hash.RELEASE_NAMED_RENDERTARGET, tvScreen)
        End If
    End Sub

    Public Shared Sub PlayAnimation(ByVal AnimationSet As String, ByVal AnimationName As String)
        Game.Player.Character.Task.PlayAnimation(AnimationSet, AnimationName, 8.0F, -1, True, 4.0F)
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

    ''' <summary>
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
    ''' CHAR_BIKESITE: P&M Logo
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
    ''' </summary>
    Public Shared Sub DisplayNotificationThisFrame(Sender As String, Subject As String, Message As String, Icon As String, Flash As Boolean, Type As IconType)
        Native.Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "STRING")
        Native.Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, Message)
        Native.Function.Call(Hash._SET_NOTIFICATION_MESSAGE, Icon, Icon, Flash, Type, Sender, Subject)
        Native.Function.Call(Hash._DRAW_NOTIFICATION, False, True)
    End Sub

    Public Shared Sub SavePosition()
        Try
            If playerName = "Michael" Then
                WriteCfgValue("MlastInterior", playerMap, saveFile)
                WriteCfgValue("MlastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("MlastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("MlastPosZ", playerPed.Position.Z.ToString, saveFile)
            ElseIf playerName = "Franklin" Then
                WriteCfgValue("FlastInterior", playerMap, saveFile)
                WriteCfgValue("FlastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("FlastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("FlastPosZ", playerPed.Position.Z.ToString, saveFile)
            ElseIf playerName = "Trevor" Then
                WriteCfgValue("TlastInterior", playerMap, saveFile)
                WriteCfgValue("TlastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("TlastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("TlastPosZ", playerPed.Position.Z.ToString, saveFile)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SavePosition2()
        Try
            If playerName = "Michael" Then
                WriteCfgValue("MlastInterior", "None", saveFile)
            ElseIf playerName = "Franklin" Then
                WriteCfgValue("FlastInterior", "None", saveFile)
            ElseIf playerName = "Trevor" Then
                WriteCfgValue("TlastInterior", "None", saveFile)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadSettingFromCFG()
        Try
            My.Settings.MlastPosX = Convert.ToSingle(ReadCfgValue("MlastPosX", saveFile))
            My.Settings.MlastPosY = Convert.ToSingle(ReadCfgValue("MlastPosY", saveFile))
            My.Settings.MlastPosZ = Convert.ToSingle(ReadCfgValue("MlastPosZ", saveFile))
            My.Settings.FlastPosX = Convert.ToSingle(ReadCfgValue("FlastPosX", saveFile))
            My.Settings.FlastPosY = Convert.ToSingle(ReadCfgValue("FlastPosY", saveFile))
            My.Settings.FlastPosZ = Convert.ToSingle(ReadCfgValue("FlastPosZ", saveFile))
            My.Settings.TlastPosX = Convert.ToSingle(ReadCfgValue("TlastPosX", saveFile))
            My.Settings.TlastPosY = Convert.ToSingle(ReadCfgValue("TlastPosY", saveFile))
            My.Settings.TlastPosZ = Convert.ToSingle(ReadCfgValue("TlastPosZ", saveFile))
            My.Settings.Save()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String
            Dim lastPosX, lastPosY, lastPosZ As Single
            If playerName = "Michael" Then
                lastInterior = ReadCfgValue("MlastInterior", saveFile)
                lastPosX = My.Settings.MlastPosX
                lastPosY = My.Settings.MlastPosY
                lastPosZ = My.Settings.MlastPosZ
            ElseIf playerName = "Franklin" Then
                lastInterior = ReadCfgValue("FlastInterior", saveFile)
                lastPosX = My.Settings.FlastPosX
                lastPosY = My.Settings.FlastPosY
                lastPosZ = My.Settings.FlastPosZ
            ElseIf playerName = "Trevor" Then
                lastInterior = ReadCfgValue("TlastInterior", saveFile)
                lastPosX = My.Settings.TlastPosX
                lastPosY = My.Settings.TlastPosY
                lastPosZ = My.Settings.TlastPosZ
            End If
            Select Case lastInterior
                Case "3Alta"
                    SetInteriorActive2(-280.74, -961.5, 91.11) '3 alta street 57
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "4Integrity"
                    SetInteriorActive2(-37.41, -582.82, 88.71) '4 integrity way 30
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "DelPerro"
                    SetInteriorActive2(-1477.14, -538.75, 55.5264) 'del perro 7
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Eclipse"
                    SetInteriorActive2(-795.04, 342.37, 206.22) 'eclipse tower 5
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "4IntegrityHL"
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "DelPerroHL"
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "EclipseHL"
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "RichardHL"
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "TinselHL"
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Richard"
                    SetInteriorActive2(-897.197, -369.246, 84.0779) 'richards majestic 4
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Richman"
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "SinnerSt"
                    SetInteriorActive2(343.85, -999.08, -99.198) 'midrange apartment
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Tinsel"
                    SetInteriorActive2(-575.305, 42.3233, 92.2236) 'tinsel tower 29
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Weazel"
                    SetInteriorActive2(-909.054, -441.466, 120.205) 'weazel plaza 70
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            playerCash = player.Money
            playerHash = player.Character.Model.Hash.ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            Else
                playerName = "None"
            End If

            If uiLanguage = "Chinese" Then
                ExitApt = "离开公寓"
                SellApt = "出售產業"
                EnterGarage = "進入車庫"
                AptOptions = "公寓選項"
            Else
                ExitApt = "Exit Apartment"
                SellApt = "Sell Property"
                EnterGarage = "Enter Garage"
                AptOptions = "APARTMENT OPTIONS"
            End If

            If _displayTimer.Enabled Then
                _scaleform.Render2D()

                If Game.GameTime > _displayTimer.Waiter Then
                    _scaleform.CallFunction("TRANSITION_OUT")
                    _displayTimer.Enabled = False
                    _fadeTimer.Start()
                End If
            End If

            If _fadeTimer.Enabled Then
                _scaleform.Render2D()

                If Game.GameTime > _fadeTimer.Waiter Then
                    _fadeTimer.Enabled = False
                End If
            End If

            If hideHud Then
                Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
            End If

            franklinSafeHouseDist = World.GetDistance(playerPed.Position, franklinSafeHouse)
            michaelSafeHouseDist = World.GetDistance(playerPed.Position, michaelSafeHouse)
            trevorSafeHouseDist = World.GetDistance(playerPed.Position, trevorSafeHouse)
            trevorSafeHouseDist2 = World.GetDistance(playerPed.Position, trevorSafeHouse2)
            If franklinSafeHouseDist < 0.1 AndAlso teleported = False Then
                LoadPosition()
                teleported = True
            ElseIf michaelSafeHouseDist < 0.1 AndAlso teleported = False Then
                LoadPosition()
                teleported = True
            ElseIf trevorSafeHouseDist < 0.1 AndAlso teleported = False Then
                LoadPosition()
                teleported = True
            ElseIf trevorSafeHouseDist2 < 0.1 AndAlso teleported = False Then
                LoadPosition()
                teleported = True
            End If

            'UI.ShowSubtitle("Position X: " & GameplayCamera.Position.X & " Y: " & GameplayCamera.Position.Y & " Z: " & GameplayCamera.Position.Z & Environment.NewLine & "Rotation X: " & GameplayCamera.Rotation.X & " Y: " & GameplayCamera.Rotation.Y & " Z: " & GameplayCamera.Rotation.Z)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try
            If Game.IsControlJustPressed(0, GTA.Control.MoveUp) AndAlso teleported = False Then
                teleported = True
            End If

            If Game.IsControlJustPressed(0, GTA.Control.VehicleDuck) Then
                'If playerName = "Michael" Then
                'Wardrobe.Player0W.Visible = True
                'ElseIf playerName = "Franklin" Then
                'Wardrobe.Player1W.Visible = True
                'ElseIf playerName = “Trevor"
                'Wardrobe.Player2W.Visible = True
                'End If

                'TurnOnTV(playerPed.Position.X, playerPed.Position.Y, playerPed.Position.Z, TelevisionModel.HighLifeAptTV)
                'DisplayNotificationThisFrame("I'm Not MentaL", "Single Player Apartment", "Thanks for Downloading my Mod. If you enjoy playing this Mod, Please Like, Rate, Comment and Subscribe, also Donate. :)", "CHAR_MINOTAUR", True, IconType.DollarSignIcon)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then

        End If
    End Sub

End Class
