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

    Private teleported As Boolean = False
    Private franklinSafeHouse As Vector3 = New Vector3(7.1190319061279, 536.61511230469, 176.02365112305)
    Private michaelSafeHouse As Vector3 = New Vector3(-813.60302734375, 179.47380065918, 72.158325195313)
    Private trevorSafeHouse As Vector3 = New Vector3(1972.6002197266, 3817.0407714844, 33.426822662354)
    Private trevorSafeHouse2 As Vector3 = New Vector3(96.154197692871, -1290.7312011719, 29.266660690308)
    Private franklinSafeHouseDist, michaelSafeHouseDist, trevorSafeHouseDist, trevorSafeHouseDist2 As Single

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

            Dim update1 As String = ReadCfgValue("Update1", saveFile)
            If update1 = "0" Then
                UpgradeFromOldVersion()
            Else
                EclipseTower.CreateEclipseTower()
                HLEclipseTower.CreateHLEclipseTower()
                _3AltaStreet.Create3AltaStreet()
                _4IntegrityWay.Create4IntegrityWay()
                HL4IntegrityWay.CreateHL4IntegrityWay()
                DelPerroHeight.CreateDelPerroHeight()
                RichardMajestic.CreateRichardsMajestic()
                HLRichardMajestic.CreateHLRichardsMajestic()
                TinselTower.CreateTinselTower()
                HLTinselTower.CreateHLTinselTower()
                WeazelPlaza.CreateWeazelPlaza()
                SinnerSt.CreateSinnerSt()
                RichmanMansion.CreateRichmanMansion()
            End If

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

    Public Shared Sub ToggleIPL(iplName As String)
        If Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, New InputArgument() {iplName}) Then
            Native.Function.Call(Hash.REMOVE_IPL, New InputArgument() {iplName})
        Else
            Native.Function.Call(Hash.REQUEST_IPL, New InputArgument() {iplName})
        End If
    End Sub

    Public Shared Sub PlayAnimation(ByVal AnimationSet As String, ByVal AnimationName As String)
        Game.Player.Character.Task.PlayAnimation(AnimationSet, AnimationName, 8.0F, -1, True, 4.0F)
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

    Private Sub UpgradeFromOldVersion()
        Try
            Dim path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\"
            Dim check As Integer
            Dim strError As String
            Dim files(13) As String
            files(0) = "3_alta_street.cfg"
            files(1) = "4_integrity_way.cfg"
            files(2) = "4_integrity_way_hl.cfg"
            files(3) = "1102_sinner_st.cfg"
            files(4) = "del_perro_heights.cfg"
            files(5) = "eclipse_towers.cfg"
            files(6) = "eclipse_towers_hl.cfg"
            files(7) = "richards_majestic.cfg"
            files(8) = "richards_majestic_hl.cfg"
            files(9) = "richman_mansion.cfg"
            files(10) = "tinsel_towers.cfg"
            files(11) = "tinsel_towers_hl.cfg"
            files(12) = "weazel_plaza.cfg"

            For i = 0 To 12
                Do
                    If UCase(Dir$(path & files(i))) = UCase(files(i)) Then
                        Dim tempOwner As String = ReadCfgValue("owner", path & files(i))
                        Select Case files(i)
                            Case files(0)
                                WriteCfgValue("3ASowner", tempOwner, saveFile)
                            Case files(1)
                                WriteCfgValue("4IWowner", tempOwner, saveFile)
                            Case files(2)
                                WriteCfgValue("4IWHLowner", tempOwner, saveFile)
                            Case files(3)
                                WriteCfgValue("SSowner", tempOwner, saveFile)
                            Case files(4)
                                WriteCfgValue("DPHwoner", tempOwner, saveFile)
                            Case files(5)
                                WriteCfgValue("ETowner", tempOwner, saveFile)
                            Case files(6)
                                WriteCfgValue("ETHLowner", tempOwner, saveFile)
                            Case files(7)
                                WriteCfgValue("RMowner", tempOwner, saveFile)
                            Case files(8)
                                WriteCfgValue("RMHLowner", tempOwner, saveFile)
                            Case files(9)
                                WriteCfgValue("RMMowner", tempOwner, saveFile)
                            Case files(10)
                                WriteCfgValue("TTowner", tempOwner, saveFile)
                            Case files(11)
                                WriteCfgValue("TTHLowner", tempOwner, saveFile)
                            Case files(12)
                                WriteCfgValue("WPowner", tempOwner, saveFile)
                        End Select
                        If System.IO.File.Exists(path & files(i)) = True Then
                            System.IO.File.Delete(path & files(i))
                        End If
                        check = check + 1
                    Else
                        strError = strError & files(i) & vbCrLf
                    End If
                    i = i + 1
                Loop Until i > 12
            Next
            If check = 13 Then
                WriteCfgValue("Update1", "1", saveFile)
                If uiLanguage = "Chinese" Then
                    UI.ShowSubtitle("單人公寓(SPA)升級完成，請重新開始遊戲或者按'插入'鍵(Insert)來應用變化。", 600000)
                Else
                    UI.ShowSubtitle("Single Player Apartment Update Completed Successfully, Please Restart the Game to Apply Changes.", 600000)
                End If
            Else
                logger.Log("The Following Files(s) are Missing From " & vbCrLf & path & vbCrLf & strError)
            End If
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
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        Try
            If Game.IsControlJustPressed(0, GTA.Control.MoveUp) AndAlso teleported = False Then
                teleported = True
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
