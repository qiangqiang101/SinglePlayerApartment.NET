Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.INMNative

Public Class SinglePlayerApartment
    Inherits Script

    Public Shared player As Player
    Public Shared playerPed As Ped
    Public Shared playerInterior As Integer
    Public Shared playerCash As Integer
    Public Shared playerName As String
    Public Shared playerHash As String
    Public Shared saveFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg"
    Public Shared settingFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\setting.cfg"
    Public Shared langFile As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Languages\" & Game.Language.ToString & ".cfg"
    Public Shared playerMap As String
    Public Shared MediumEndLastLocationName As String = Nothing
    Public Shared LowEndLastLocationName As String = Nothing
    Public Shared InteriorIDList As List(Of Integer) = New List(Of Integer)

    'Translate
    Public Shared ExitApt, SellApt, EnterGarage, AptOptions, Garage, GrgOptions, GrgRemove, GrgRemoveAndDrive, GrgMove, GrgSell, GrgSelectVeh, GrgTooHot, GrgPlate, GrgRename, GrgTransfer, _Mechanic, _Pegasus, ChooseApt As String
    Public Shared ModernStyle, MoodyStyle, VibrantStyle, SharpStyle, MonochromeStyle, SeductiveStyle, RegalStyle, AquaStyle, ChooseVeh, ChooseVehDesc, ReturnVeh, AptStyle, _Phone, PegasusDeliver, PegasusDelete, CannotStore As String
    Public Shared GrgFull, Reach10, MechanicBill, EnterElevator, ExitGarage, ManageGarage, Maze, Fleeca, BOL, ForSale, PropPurchased, InsFundApartment, EnterApartment, SaveGame, ExitApartment, ChangeClothes, _EnterGarage As String
    Public Shared Insurance1, Insurance2, Insurance3, Insurance4, MorsMutual As String

    Private teleported As Boolean = False
    Private michaelSafeHouse, franklinAuntSafeHouse, franklinSafeHouse, trevorTrailerSafeHouse, trevorPubSafeHouse, floydSafeHouse As Integer

    Public Shared hideHud As Boolean = False

    Public Sub New()
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            playerHash = player.Character.Model.GetHashCode().ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "Player3" 'None
            End If
            If playerName = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = player.Money
            End If

            michaelSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-813.60302734375, 179.47380065918, 72.158325195313))
            franklinAuntSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-9.96562, -1438.54, 31.10151))
            franklinSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(7.1190319061279, 536.61511230469, 176.02365112305))
            trevorTrailerSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(1972.6002197266, 3817.0407714844, 33.426822662354))
            trevorPubSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(96.154197692871, -1290.7312011719, 29.266660690308))
            floydSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-1155.31, -1518.57, 10.63135))

            'New Language
            Website.BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
            Website.DockTease = ReadCfgValue("DockTease", langFile)
            Website.LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
            Website.ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
            Website.PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
            Website.SouthernSA = ReadCfgValue("SouthernSA", langFile)
            Website.WarstockCache = ReadCfgValue("WarstockCache", langFile)
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
            Reach10 = ReadCfgValue("Reach10", langFile)
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
            'End Language

            AddHandler Tick, AddressOf OnTick

            LoadSettingFromCFG()
            If My.Settings.AlwaysEnableMPMaps = True Then LoadMPDLCMap()
            If Not Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)) = 0 Then InteriorIDList.Add(Apartment.GetInteriorID(New Vector3(263.86999, -998.78002, -99.010002)))
            If Not Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)) = 0 Then InteriorIDList.Add(Apartment.GetInteriorID(New Vector3(343.85, -999.08, -99.198)))
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

    Public Shared Sub DisplayHelpTextThisFrame(helpText As String, Optional Shape As Integer = -1)
        Native.Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "CELL_EMAIL_BCON")
        Const maxStringLength As Integer = 99

        Dim i As Integer = 0
        While i < helpText.Length
            Native.Function.Call(Hash._0x6C188BE134E074AA, helpText.Substring(i, System.Math.Min(maxStringLength, helpText.Length - i)))
            i += maxStringLength
        End While
        Native.Function.Call(Hash._DISPLAY_HELP_TEXT_FROM_STRING_LABEL, 0, 0, 1, Shape)
    End Sub

    'Public Shared Sub DisplayHelpTextThisFrame(ByVal [text] As String, Optional Shape As Integer = -1)
    '    Try
    '        Dim arguments As InputArgument() = New InputArgument() {"STRING"} 'STRING
    '        Native.Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, arguments)
    '        Dim argumentArray2 As InputArgument() = New InputArgument() {[text]}
    '        Native.Function.Call(Hash._0x6C188BE134E074AA, argumentArray2)
    '        'Const maxStringLength As Integer = 99
    '        'Dim i As Integer = 0
    '        'While i < text.Length
    '        '    Native.Function.Call(Hash._0x6C188BE134E074AA, text.Substring(i, System.Math.Min(maxStringLength, text.Length)))
    '        '    i += maxStringLength
    '        'End While
    '        Dim argumentArray3 As InputArgument() = New InputArgument() {0, 0, 1, Shape}
    '        Native.Function.Call(Hash._DISPLAY_HELP_TEXT_FROM_STRING_LABEL, argumentArray3)
    '    Catch ex As Exception
    '        logger.Log(ex.Message & " " & ex.StackTrace)
    '    End Try
    'End Sub

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
            If My.Settings.NeverEnableMPMaps = False Then
                Native.Function.Call(Hash._LOAD_MP_DLC_MAPS)
                LoadMPDLCMapMissingObjects()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub LoadMPDLCMapMissingObjects()
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

        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID1, "V_57_FranklinStuff")

        Native.Function.Call(Hash._0x55E86AF2712B36A1, TID2, "swap_clean_apt")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, TID2, "layer_whiskey")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, TID2, "layer_sextoys_a")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, TID2, "swap_mrJam_A")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, TID2, "swap_sofa_A")

        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "V_Michael_bed_tidy")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "V_Michael_L_Items")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "V_Michael_S_Items")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "V_Michael_D_Items")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "V_Michael_M_Items")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "Michael_premier")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MID, "V_Michael_plane_ticket")

        'Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "showhome_only")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "franklin_settled")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "franklin_unpacking")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "bong_and_wine")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "progress_flyer")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "progress_tshirt")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "progress_tux")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, FID2, "unlocked")

        Native.Function.Call(Hash._0x55E86AF2712B36A1, WODID, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, NCAID1, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, NCAID2, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, HCAID1, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, HCAID2, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, HCAID3, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MRID, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, WMDID, "Stilts_Kitchen_Window")
        Native.Function.Call(Hash._0x55E86AF2712B36A1, MWTDID, "Stilts_Kitchen_Window")

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

    Public Shared Sub UnLoadMPDLCMap()
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

    Public Shared Sub SetInteriorActive2(X As Single, Y As Single, Z As Single)
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

    Public Shared Sub ClearArea(X As Single, Y As Single, Z As Single)
        Dim arguments As InputArgument() = New InputArgument() {X, Y, Z, 100, True, False, False, False}
        Native.Function.Call(Hash.CLEAR_AREA, arguments)
        Dim arguments2 As InputArgument() = New InputArgument() {X, Y, Z, 100, True, True, True, True, True}
    End Sub

    Public Shared Sub ToggleIPL(iplName As String, Optional Vector3 As Vector3 = Nothing)
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

    Public Shared Sub RemoveIPL(iplName As String)
        If Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, New InputArgument() {iplName}) Then
            Native.Function.Call(Hash.REMOVE_IPL, New InputArgument() {iplName})
        End If
    End Sub

    Public Shared Sub ChangeIPL(LastIplName As String, NewIplName As String, Optional Vector3 As Vector3 = Nothing)
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
    Public Shared Sub DisplayNotificationThisFrame(Sender As String, Subject As String, Message As String, Icon As String, Flash As Boolean, Type As IconType)
        Native.Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "CELL_EMAIL_BCON")
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
            ElseIf playerName = "Player3" Then
                WriteCfgValue("3lastInterior", playerMap, saveFile)
                WriteCfgValue("3lastPosX", playerPed.Position.X.ToString, saveFile)
                WriteCfgValue("3lastPosY", playerPed.Position.Y.ToString, saveFile)
                WriteCfgValue("3lastPosZ", playerPed.Position.Z.ToString, saveFile)
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
            ElseIf playerName = "Player3" Then
                WriteCfgValue("3lastInterior", "None", saveFile)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadSettingFromCFG()
        Try
            My.Settings.CreateFileMethod = ReadCfgValue("CreateFileMethod", settingFile)
            My.Settings.MlastPosX = Convert.ToSingle(ReadCfgValue("MlastPosX", saveFile))
            My.Settings.MlastPosY = Convert.ToSingle(ReadCfgValue("MlastPosY", saveFile))
            My.Settings.MlastPosZ = Convert.ToSingle(ReadCfgValue("MlastPosZ", saveFile))
            My.Settings.FlastPosX = Convert.ToSingle(ReadCfgValue("FlastPosX", saveFile))
            My.Settings.FlastPosY = Convert.ToSingle(ReadCfgValue("FlastPosY", saveFile))
            My.Settings.FlastPosZ = Convert.ToSingle(ReadCfgValue("FlastPosZ", saveFile))
            My.Settings.TlastPosX = Convert.ToSingle(ReadCfgValue("TlastPosX", saveFile))
            My.Settings.TlastPosY = Convert.ToSingle(ReadCfgValue("TlastPosY", saveFile))
            My.Settings.TlastPosZ = Convert.ToSingle(ReadCfgValue("TlastPosZ", saveFile))
            Dim AlwaysEnableMPMaps As String = ReadCfgValue("AlwaysEnableMPMaps", settingFile)
            If AlwaysEnableMPMaps = "True" Then
                My.Settings.AlwaysEnableMPMaps = True
            Else
                My.Settings.AlwaysEnableMPMaps = False
            End If
            Dim HasLowriderUpdate As Integer = Game.Version
            If HasLowriderUpdate < 13 Then
                My.Settings.HasLowriderUpdate = False
            Else
                My.Settings.HasLowriderUpdate = True
            End If
            Dim NeverEnableMPMaps As String = ReadCfgValue("NeverEnableMPMaps", settingFile)
            If NeverEnableMPMaps = "True" Then
                My.Settings.NeverEnableMPMaps = True
            Else
                My.Settings.NeverEnableMPMaps = False
            End If
            My.Settings.VehicleSpawn = ReadCfgValue("VehicleSpawn", settingFile)
            My.Settings.Volume = ReadCfgValue("Volume", settingFile)
            My.Settings.PreviewPointX = ReadCfgValue("PointX", settingFile)
            My.Settings.PreviewPointY = ReadCfgValue("PointY", settingFile)
            My.Settings.ThreeAltaStreet = ReadCfgValue("3AltaStreet", settingFile)
            My.Settings.FourIntegrityWay = ReadCfgValue("4IntegrityWay", settingFile)
            My.Settings.DelPerroHeight = ReadCfgValue("DelPerroHeights", settingFile)
            My.Settings.DreamTower = ReadCfgValue("DreamTower", settingFile)
            My.Settings.EclipseTower = ReadCfgValue("EclipseTower", settingFile)
            My.Settings.RichardMajestic = ReadCfgValue("RichardMajestic", settingFile)
            My.Settings.TinselTower = ReadCfgValue("TinselTower", settingFile)
            My.Settings.VespucciBlvd = ReadCfgValue("VespucciBlvd", settingFile)
            My.Settings.WeazelPlaza = ReadCfgValue("WeazelPlaza", settingFile)
            My.Settings.Hillcrest2862 = ReadCfgValue("2862Hillcrest", settingFile)
            My.Settings.Hillcrest2868 = ReadCfgValue("2868Hillcrest", settingFile)
            My.Settings.Hillcrest2874 = ReadCfgValue("2874Hillcrest", settingFile)
            My.Settings.MadWayne2113 = ReadCfgValue("2113MadWayne", settingFile)
            My.Settings.MiltonRd2117 = ReadCfgValue("2117MiltonRd", settingFile)
            My.Settings.NorthConker2044 = ReadCfgValue("2044NorthConker", settingFile)
            My.Settings.NorthConker2045 = ReadCfgValue("2045NorthConker", settingFile)
            My.Settings.Whispymound3677 = ReadCfgValue("3677Whispymound", settingFile)
            My.Settings.WildOats3655 = ReadCfgValue("3655WildOats", settingFile)
            My.Settings.CougarAve = ReadCfgValue("CougarAve", settingFile)
            My.Settings.BayCityAve = ReadCfgValue("BayCityAve", settingFile)
            My.Settings.MiltonRd0184 = ReadCfgValue("0184MiltonRd", settingFile)
            My.Settings.SouthRockfordDr0325 = ReadCfgValue("0325SouthRockfordDr", settingFile)
            My.Settings.SouthMoMiltonDr = ReadCfgValue("SouthMoMiltonDr", settingFile)
            My.Settings.LasLagunasBlvd0604 = ReadCfgValue("0604LasLagunasBlvd", settingFile)
            My.Settings.SpanishAve = ReadCfgValue("SpanishAve", settingFile)
            My.Settings.BlvdDelPerro = ReadCfgValue("BlvdDelPerro", settingFile)
            My.Settings.PowerSt = ReadCfgValue("PowerSt", settingFile)
            My.Settings.ProsperitySt = ReadCfgValue("ProsperitySt", settingFile)
            My.Settings.SanVitasSt = ReadCfgValue("SanVitasSt", settingFile)
            My.Settings.LasLagunasBlvd2143 = ReadCfgValue("2143LasLagunasBlvd", settingFile)
            My.Settings.TheRoyale = ReadCfgValue("TheRoyale", settingFile)
            My.Settings.HangmanAve = ReadCfgValue("HangmanAve", settingFile)
            My.Settings.SustanciaRd = ReadCfgValue("SustanciaRd", settingFile)
            My.Settings.ProcopioDr4401 = ReadCfgValue("4401ProcopioDr", settingFile)
            My.Settings.ProcopioDr4584 = ReadCfgValue("4584ProcopioDr", settingFile)
            My.Settings.SouthRockfordDr0112 = ReadCfgValue("0112SouthRockfordDr", settingFile)
            My.Settings.ZancudoAve = ReadCfgValue("ZancudoAve", settingFile)
            My.Settings.PaletoBlvd = ReadCfgValue("PaletoBlvd", settingFile)
            My.Settings.GrapeseedAve = ReadCfgValue("GrapeseedAve", settingFile)
            My.Settings.MechanicPad = ReadCfgValue("PadMechanic", settingFile)
            My.Settings.SecondMechanicPad = ReadCfgValue("SecondPadMechanic", settingFile)
            My.Settings.RefreshGrgVehs = ReadCfgValue("RefreshGarageVehicles", settingFile)
            My.Settings.Save()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadPosition()
        Try
            Dim lastInterior As String = Nothing
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
            ElseIf playerName = "Player3" Then
                lastInterior = ReadCfgValue("3lastInterior", saveFile)
                lastPosX = My.Settings.TlastPosX
                lastPosY = My.Settings.TlastPosY
                lastPosZ = My.Settings.TlastPosZ
            End If
            Select Case lastInterior
                Case "3Alta"
                    SetInteriorActive2(-280.74, -961.5, 91.11) '3 alta street 57
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    _3AltaStreet.Apartment.IsAtHome = True
                Case "4Integrity"
                    SetInteriorActive2(-37.41, -582.82, 88.71) '4 integrity way 30
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    _4IntegrityWay.Apartment.IsAtHome = True
                Case "DelPerro"
                    SetInteriorActive2(-1477.14, -538.75, 55.5264) 'del perro 7
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    DelPerroHeight.Apartment.IsAtHome = True
                Case "Eclipse"
                    SetInteriorActive2(-795.04, 342.37, 206.22) 'eclipse tower 5
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "4IntegrityHL"
                    SetInteriorActive2(_4IntegrityWay.ApartmentHL.Interior.X, _4IntegrityWay.ApartmentHL.Interior.Y, _4IntegrityWay.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    _4IntegrityWay.Apartment.IsAtHome = True
                Case "DelPerroHL"
                    SetInteriorActive2(DelPerroHeight.ApartmentHL.Interior.X, DelPerroHeight.ApartmentHL.Interior.Y, DelPerroHeight.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    DelPerroHeight.Apartment.IsAtHome = True
                Case "EclipseHL"
                    SetInteriorActive2(EclipseTower.ApartmentHL.Interior.X, EclipseTower.ApartmentHL.Interior.Y, EclipseTower.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "RichardHL"
                    SetInteriorActive2(RichardMajestic.ApartmentHL.Interior.X, RichardMajestic.ApartmentHL.Interior.Y, RichardMajestic.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    RichardMajestic.Apartment.IsAtHome = True
                Case "TinselHL"
                    SetInteriorActive2(TinselTower.ApartmentHL.Interior.X, TinselTower.ApartmentHL.Interior.Y, TinselTower.ApartmentHL.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    TinselTower.Apartment.IsAtHome = True
                Case "Richard"
                    SetInteriorActive2(-897.197, -369.246, 84.0779) 'richards majestic 4
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    RichardMajestic.Apartment.IsAtHome = True
                'Case "Richman"
                '    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "SinnerSt", "CougarAve", "BayCityAve", "0184MiltonRd", "0325SouthRockfordDr", "SouthMoMiltonDr", "0604LasLagunasBlvd", "SpanishAve", "BlvdDelPerro", "PowerSt", "ProsperitySt", "SanVitasSt", "2143LasLagunasBlvd", "TheRoyale", "HangmanAve", "SustanciaRd", "4401ProcopioDr", "4584ProcopioDr"
                    SetInteriorActive2(343.85, -999.08, -99.198) 'midrange apartment
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "Tinsel"
                    SetInteriorActive2(-575.305, 42.3233, 92.2236) 'tinsel tower 29
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    TinselTower.Apartment.IsAtHome = True
                Case "Weazel"
                    SetInteriorActive2(-909.054, -441.466, 120.205) 'weazel plaza 70
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    WeazelPlaza.Apartment.IsAtHome = True
                Case "VespucciBlvd", "0112SouthRockfordDr", "ZancudoAve", "PaletoBlvd", "GrapeseedAve"
                    SetInteriorActive2(263.86999, -998.78002, -99.010002) 'low end apartment
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                Case "NConker2044"
                    SetInteriorActive2(NorthConker2044.Apartment.Interior.X, NorthConker2044.Apartment.Interior.Y, NorthConker2044.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    NorthConker2044.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_04_ext1")
                Case "HillcrestA2862"
                    SetInteriorActive2(HillcrestAve2862.Apartment.Interior.X, HillcrestAve2862.Apartment.Interior.Y, HillcrestAve2862.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    HillcrestAve2862.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09c_ext2")
                Case "HillcrestA2868"
                    SetInteriorActive2(HillcrestAve2868.Apartment.Interior.X, HillcrestAve2868.Apartment.Interior.Y, HillcrestAve2868.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    HillcrestAve2868.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09b_ext3")
                Case "WildOats3655"
                    SetInteriorActive2(WildOats3655.Apartment.Interior.X, WildOats3655.Apartment.Interior.Y, WildOats3655.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    WildOats3655.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_05e_ext1")
                Case "NConker2045"
                    SetInteriorActive2(NorthConker2045.Apartment.Interior.X, NorthConker2045.Apartment.Interior.Y, NorthConker2045.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    NorthConker2045.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_04_ext2")
                Case "MiltonR2117"
                    SetInteriorActive2(MiltonRd2117.Apartment.Interior.X, MiltonRd2117.Apartment.Interior.Y, MiltonRd2117.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    MiltonRd2117.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09c_ext3")
                Case "HillcrestA2874"
                    SetInteriorActive2(HillcrestAve2874._Apartment.Interior.X, HillcrestAve2874._Apartment.Interior.Y, HillcrestAve2874._Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    HillcrestAve2874._Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_09b_ext2")
                Case "Whispy3677"
                    SetInteriorActive2(Whispymound3677.Apartment.Interior.X, Whispymound3677.Apartment.Interior.Y, Whispymound3677.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    Whispymound3677.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_05c_ext1")
                Case "MadWayne2113"
                    SetInteriorActive2(MadWayne2113.Apartment.Interior.X, MadWayne2113.Apartment.Interior.Y, MadWayne2113.Apartment.Interior.Z)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    MadWayne2113.Apartment.IsAtHome = True
                    ToggleIPL("apa_stilt_ch2_12b_ext1")
                Case "EclipsePS1"
                    SetInteriorActive2(EclipseTower.ApartmentPS1.Interior.X, EclipseTower.ApartmentPS1.Interior.Y, EclipseTower.ApartmentPS1.Interior.Z)
                    ToggleIPL(ReadCfgValue("ETP1ipl", saveFile), EclipseTower.ApartmentPS1.Interior)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "EclipsePS2"
                    SetInteriorActive2(EclipseTower.ApartmentPS2.Interior.X, EclipseTower.ApartmentPS2.Interior.Y, EclipseTower.ApartmentPS2.Interior.Z)
                    ToggleIPL(ReadCfgValue("ETP2ipl", saveFile), EclipseTower.ApartmentPS2.Interior)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                Case "EclipsePS3"
                    SetInteriorActive2(EclipseTower.ApartmentPS3.Interior.X, EclipseTower.ApartmentPS3.Interior.Y, EclipseTower.ApartmentPS3.Interior.Z)
                    ToggleIPL(ReadCfgValue("ETP3ipl", saveFile), EclipseTower.ApartmentPS3.Interior)
                    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
                    EclipseTower.Apartment.IsAtHome = True
                    'Case Else
                    '    SetInteriorActive2(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z)
                    '    If My.Settings.AlwaysEnableMPMaps = False Then LoadMPDLCMap()
                    '    Game.Player.Character.Position = New Vector3(lastPosX, lastPosY, lastPosZ)
            End Select

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            player = Game.Player
            playerPed = Game.Player.Character
            playerInterior = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_FROM_ENTITY, Game.Player.Character)
            playerHash = player.Character.Model.GetHashCode().ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "Player3" '"None"
            End If
            If playerName = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = player.Money
            End If

            michaelSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-813.60302734375, 179.47380065918, 72.158325195313))
            franklinAuntSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-9.96562, -1438.54, 31.10151))
            franklinSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(7.1190319061279, 536.61511230469, 176.02365112305))
            trevorTrailerSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(1972.6002197266, 3817.0407714844, 33.426822662354))
            trevorPubSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(96.154197692871, -1290.7312011719, 29.266660690308))
            floydSafeHouse = INMNative.Apartment.GetInteriorID(New Vector3(-1155.31, -1518.57, 10.63135))

            Dim Safehouses As List(Of Integer) = New List(Of Integer)() From {michaelSafeHouse, franklinAuntSafeHouse, franklinSafeHouse, trevorTrailerSafeHouse, trevorPubSafeHouse, floydSafeHouse}
            If Safehouses.Contains(playerInterior) Then
                If Not teleported Then LoadPosition()
            End If

            If InteriorIDList.Contains(playerInterior) Then
                teleported = Not teleported
            End If

            If hideHud Then
                Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
            End If

            If Not playerInterior = 0 AndAlso InteriorIDList.Contains(playerInterior) AndAlso Not Game.MissionFlag AndAlso Not player.WantedLevel > 0 Then
                Resources.Disable_Switch_Characters()
                Resources.Disable_Weapons()
                Resources.Disable_Controls()
                If Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, True) Else Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
                If Brain.RadioOn Then Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, True) Else Native.Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, False)
            ElseIf Not playerInterior = 0 AndAlso InteriorIDList.Contains(playerInterior) AndAlso Not Game.MissionFlag AndAlso player.WantedLevel > 0 Then
                Resources.Disable_Switch_Characters()
            Else
                Native.Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, False)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
End Class
