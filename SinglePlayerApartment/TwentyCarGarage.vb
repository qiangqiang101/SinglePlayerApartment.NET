'Imports GTA
'Imports GTA.Native
'Imports GTA.Math
'Imports SinglePlayerApartment.SinglePlayerApartment
'Imports SinglePlayerApartment.INMNative
'Imports INMNativeUI
'Imports System.Drawing

'Public Class TwentyCarGarage
'    Inherits Script

'    Public Shared Apartment As Apartment
'    Public Shared LastIPL As String
'    Public Shared WallText, LightText, NumberText As String
'    Public Shared InteriorID As Integer
'    Public Shared CurrentPath As String
'    Public Shared veh0, veh1, veh2, veh3, veh4, veh5, veh6, veh7, veh8, veh9, veh10, veh11, veh12, veh13, veh14, veh15, veh16, veh17, veh18, veh19 As Vehicle
'    Public Shared LastLocationName As String
'    Public Shared lastLocationVector As Vector3
'    Public Shared lastLocationGarageVector As Vector3
'    Public Shared lastLocationGarageOutVector As Vector3
'    Public Shared lastLocationGarageOutHeading As Single
'    Public Shared Elevator As Vector3
'    Public Shared MenuActivator As Vector3
'    Public Shared ElevatorDistance As Single
'    Public Shared GarageMarkerDistance As Single
'    Public Shared veh0Pos, veh1Pos, veh2Pos, veh3Pos, veh4Pos, veh5Pos, veh6Pos, veh7Pos, veh8Pos, veh9Pos, veh10Pos, veh11Pos, veh12Pos, veh13Pos, veh14Pos, veh15Pos, veh16Pos, veh17Pos, veh18Pos, veh19Pos As Vector3
'    Public Shared vehRot0613, vehRot1714, vehRot2815, vehRot3916, vehRot41017, vehRot51118, vehRot1219 As Vector3
'    Public Shared Floor1CamPos, Floor2CamPos, Floor3CamPos, Floor1CamRot, Floor2CamRot, Floor3CamRot As Vector3
'    Public Shared ExitMenu, StyleMenu, WallMenu, LightMenu, NumberMenu As UIMenu
'    Public Shared itemWall, itemLight, itemNumber, itemStyle As UIMenuItem
'    Public Shared _menuPool As MenuPool

'    Public Sub New()
'        Try
'            Translate()
'            _menuPool = New MenuPool()
'            itemWall = New UIMenuItem(InteriorText)
'            itemLight = New UIMenuItem(LightingText)
'            itemNumber = New UIMenuItem(SignageText)
'            itemStyle = New UIMenuItem(GarageStyle)

'            CreateExitMenu()
'            CreateGarageStyleMenu()
'            CreateGarageInteriorMenu()
'            CreateGarageLightingMenu()
'            CreateGarageSignageMenu()

'            AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
'            AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
'            AddHandler StyleMenu.OnItemSelect, AddressOf ItemSelectHandler
'            AddHandler WallMenu.OnItemSelect, AddressOf ItemSelectHandler
'            AddHandler LightMenu.OnItemSelect, AddressOf ItemSelectHandler
'            AddHandler NumberMenu.OnItemSelect, AddressOf ItemSelectHandler
'            AddHandler WallMenu.OnIndexChange, AddressOf IndexChangeHandler
'            AddHandler LightMenu.OnIndexChange, AddressOf IndexChangeHandler
'            AddHandler NumberMenu.OnIndexChange, AddressOf IndexChangeHandler
'            AddHandler WallMenu.OnMenuClose, AddressOf MenuCloseHandler
'            AddHandler LightMenu.OnMenuClose, AddressOf MenuCloseHandler
'            AddHandler NumberMenu.OnMenuClose, AddressOf MenuCloseHandler
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateExitMenu()
'        Try
'            ExitMenu = New UIMenu("", OfficeOptions, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            ExitMenu.SetBannerType(Rectangle)
'            _menuPool.Add(ExitMenu)
'            ExitMenu.AddItem(New UIMenuItem(EnterOffice))
'            ExitMenu.AddItem(New UIMenuItem(OfficeGarage1))
'            ExitMenu.AddItem(New UIMenuItem(OfficeGarage2))
'            ExitMenu.AddItem(New UIMenuItem(OfficeGarage3))
'            ExitMenu.AddItem(New UIMenuItem(OfficeAutoShop))
'            ExitMenu.AddItem(itemStyle)
'            ExitMenu.RefreshIndex()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateGarageStyleMenu()
'        Try
'            StyleMenu = New UIMenu("", GarageStyle.ToUpper, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            StyleMenu.SetBannerType(Rectangle)
'            _menuPool.Add(StyleMenu)
'            StyleMenu.AddItem(itemWall)
'            StyleMenu.AddItem(itemLight)
'            StyleMenu.AddItem(itemNumber)
'            StyleMenu.RefreshIndex()
'            ExitMenu.BindMenuToItem(StyleMenu, itemStyle)
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateGarageInteriorMenu()
'        Try
'            WallMenu = New UIMenu("", InteriorText.ToUpper, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            WallMenu.SetBannerType(Rectangle)
'            _menuPool.Add(WallMenu)
'            WallMenu.AddItem(New UIMenuItem(Interior1))
'            WallMenu.AddItem(New UIMenuItem(Interior2))
'            WallMenu.AddItem(New UIMenuItem(Interior3))
'            WallMenu.AddItem(New UIMenuItem(Interior4))
'            WallMenu.RefreshIndex()
'            StyleMenu.BindMenuToItem(WallMenu, itemWall)
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateGarageLightingMenu()
'        Try
'            LightMenu = New UIMenu("", LightingText.ToUpper, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            LightMenu.SetBannerType(Rectangle)
'            _menuPool.Add(LightMenu)
'            LightMenu.AddItem(New UIMenuItem(Lighting1))
'            LightMenu.AddItem(New UIMenuItem(Lighting2))
'            LightMenu.AddItem(New UIMenuItem(Lighting3))
'            LightMenu.AddItem(New UIMenuItem(Lighting4))
'            LightMenu.AddItem(New UIMenuItem(Lighting5))
'            LightMenu.AddItem(New UIMenuItem(Lighting6))
'            LightMenu.AddItem(New UIMenuItem(Lighting7))
'            LightMenu.AddItem(New UIMenuItem(Lighting8))
'            LightMenu.AddItem(New UIMenuItem(Lighting9))
'            LightMenu.RefreshIndex()
'            StyleMenu.BindMenuToItem(LightMenu, itemLight)
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateGarageSignageMenu()
'        Try
'            NumberMenu = New UIMenu("", SignageText.ToUpper, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            NumberMenu.SetBannerType(Rectangle)
'            _menuPool.Add(NumberMenu)
'            NumberMenu.AddItem(New UIMenuItem(Signage1))
'            NumberMenu.AddItem(New UIMenuItem(Signage2))
'            NumberMenu.AddItem(New UIMenuItem(Signage3))
'            NumberMenu.AddItem(New UIMenuItem(Signage4))
'            NumberMenu.AddItem(New UIMenuItem(Signage5))
'            NumberMenu.AddItem(New UIMenuItem(Signage6))
'            NumberMenu.AddItem(New UIMenuItem(Signage7))
'            NumberMenu.AddItem(New UIMenuItem(Signage8))
'            NumberMenu.AddItem(New UIMenuItem(Signage9))
'            NumberMenu.RefreshIndex()
'            StyleMenu.BindMenuToItem(NumberMenu, itemNumber)
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub MenuCloseHandler(sender As UIMenu)
'        Try
'            hideHud = False
'            World.DestroyAllCameras()
'            World.RenderingCamera = Nothing
'            RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.All)
'            ToggleOfficeGarageDecor(Apartment.GarageWall1, Apartment.GarageLight1, Apartment.GarageNumber1, InteriorID)
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
'        If selectedItem.Text = EnterOffice Then
'            Game.FadeScreenOut(500)
'            Wait(500)
'            RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.All)
'            RemoveIPL(LastIPL)
'            ToggleIPL(Apartment.IPL)
'            EnableOfficeProp()
'            playerPed.Position = lastLocationVector
'            SinglePlayerApartment.player.LastVehicle.Delete()
'            ExitMenu.Visible = False
'            Wait(500)
'            Game.FadeScreenIn(500)
'        ElseIf selectedItem.Text = OfficeGarage1 Then
'            Game.FadeScreenOut(500)
'            Wait(500)
'            RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.All)
'            RemoveIPL(LastIPL)
'            ToggleIPL(Apartment.GarageIPL)
'            LastIPL = Apartment.GarageIPL
'            LastLocationName = Apartment.Name
'            lastLocationVector = Apartment.ApartmentExit
'            lastLocationGarageVector = Apartment.GarageEntrance
'            lastLocationGarageOutVector = Apartment.GarageOutside
'            lastLocationGarageOutHeading = Apartment.GarageOutHeading
'            LoadGarageVechicles(Apartment.GaragePath)
'            CurrentPath = Apartment.GaragePath
'            Elevator = Apartment.GarageElevator
'            ToggleOfficeGarageDecor(Apartment.GarageWall1, Apartment.GarageLight1, Apartment.GarageNumber1, INMNative.Apartment.GetInteriorID(TwentyCarGarage.Elevator))
'            MenuActivator = Apartment.GarageMenuActivator
'            ElevatorDistance = Apartment.GarageElevatorDistance
'            GarageMarkerDistance = Apartment.GarageMenuActivatorDistance
'            veh0Pos = Apartment.GarageVeh0Pos
'            veh1Pos = Apartment.GarageVeh1Pos
'            veh2Pos = Apartment.GarageVeh2Pos
'            veh3Pos = Apartment.GarageVeh3Pos
'            veh4Pos = Apartment.GarageVeh4Pos
'            veh5Pos = Apartment.GarageVeh5Pos
'            veh6Pos = Apartment.GarageVeh6Pos
'            veh7Pos = Apartment.GarageVeh7Pos
'            veh8Pos = Apartment.GarageVeh8Pos
'            veh9Pos = Apartment.GarageVeh9Pos
'            veh10Pos = Apartment.GarageVeh10Pos
'            veh11Pos = Apartment.GarageVeh11Pos
'            veh12Pos = Apartment.GarageVeh12Pos
'            veh13Pos = Apartment.GarageVeh13Pos
'            veh14Pos = Apartment.GarageVeh14Pos
'            veh15Pos = Apartment.GarageVeh15Pos
'            veh16Pos = Apartment.GarageVeh16Pos
'            veh17Pos = Apartment.GarageVeh17Pos
'            veh18Pos = Apartment.GarageVeh18Pos
'            veh19Pos = Apartment.GarageVeh19Pos
'            vehRot0613 = Apartment.GarageVeh0613Rot
'            vehRot1714 = Apartment.GarageVeh1714Rot
'            vehRot2815 = Apartment.GarageVeh2815Rot
'            vehRot3916 = Apartment.GarageVeh3916Rot
'            vehRot41017 = Apartment.GarageVeh41017Rot
'            vehRot51118 = Apartment.GarageVeh51118Rot
'            vehRot1219 = Apartment.GarageVeh1219Rot
'            Floor1CamPos = Apartment.CamPos1F
'            Floor2CamPos = Apartment.CamPos2F
'            Floor3CamPos = Apartment.CamPos3F
'            Floor1CamRot = Apartment.CamRot1F
'            Floor2CamRot = Apartment.CamRot2F
'            Floor3CamRot = Apartment.CamRot3F
'            playerPed.Position = Elevator
'            ExitMenu.Visible = False
'            Wait(500)
'            Game.FadeScreenIn(500)
'        ElseIf selectedItem.Text = OfficeGarage2 Then
'        ElseIf selectedItem.Text = OfficeGarage3 Then
'        ElseIf selectedItem.Text = OfficeAutoShop Then
'        End If

'        Select Case selectedItem.Text
'            Case InteriorText, LightingText, SignageText
'                Game.FadeScreenOut(500)
'                Wait(500)
'                World.RenderingCamera = World.CreateCamera(Apartment.CamPos1F, Apartment.CamRot1F, 50)
'                hideHud = True
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Interior1
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(WallText, "garage_decor_01", saveFile)
'                If WallText.Contains("1") Then Apartment.GarageWall1 = "garage_decor_01"
'                If WallText.Contains("2") Then Apartment.GarageWall2 = "garage_decor_01"
'                If WallText.Contains("3") Then Apartment.GarageWall3 = "garage_decor_01"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_01")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                WallMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Interior2
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(WallText, "garage_decor_02", saveFile)
'                If WallText.Contains("1") Then Apartment.GarageWall1 = "garage_decor_02"
'                If WallText.Contains("2") Then Apartment.GarageWall2 = "garage_decor_02"
'                If WallText.Contains("3") Then Apartment.GarageWall3 = "garage_decor_02"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_02")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                WallMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Interior3
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(WallText, "garage_decor_03", saveFile)
'                If WallText.Contains("1") Then Apartment.GarageWall1 = "garage_decor_03"
'                If WallText.Contains("2") Then Apartment.GarageWall2 = "garage_decor_03"
'                If WallText.Contains("3") Then Apartment.GarageWall3 = "garage_decor_03"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_03")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                WallMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Interior4
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(WallText, "garage_decor_04", saveFile)
'                If WallText.Contains("1") Then Apartment.GarageWall1 = "garage_decor_04"
'                If WallText.Contains("2") Then Apartment.GarageWall2 = "garage_decor_04"
'                If WallText.Contains("3") Then Apartment.GarageWall3 = "garage_decor_04"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_04")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                WallMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting1
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option01", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option01"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option01"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option01"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option01")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting2
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option02", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option02"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option02"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option02"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option02")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting3
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option03", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option03"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option03"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option03"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option03")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting4
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option04", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option04"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option04"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option04"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option04")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting5
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option05", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option05"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option05"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option05"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option05")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting6
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option06", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option06"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option06"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option06"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option06")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting7
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option07", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option07"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option07"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option07"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option07")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting8
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option08", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option08"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option08"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option08"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option08")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Lighting9
'                Game.FadeScreenOut(500)
'                Wait(500)
'                WriteCfgValue(LightText, "lighting_option09", saveFile)
'                If LightText.Contains("1") Then Apartment.GarageLight1 = "lighting_option09"
'                If LightText.Contains("2") Then Apartment.GarageLight2 = "lighting_option09"
'                If LightText.Contains("3") Then Apartment.GarageLight3 = "lighting_option09"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option09")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                LightMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage1
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style01_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style01_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style01_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style01_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style01_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style01_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style01_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style01_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style01_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage2
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style02_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style02_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style02_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style02_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style02_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style02_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style02_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style02_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style02_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage3
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style03_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style03_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style03_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style03_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style03_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style03_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style03_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style03_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style03_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage4
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style04_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style04_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style04_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style04_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style04_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style04_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style04_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style04_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style04_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage5
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style05_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style05_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style05_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style05_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style05_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style05_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style05_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style05_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style05_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage6
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style06_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style06_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style06_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style06_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style06_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style06_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style06_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style06_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style06_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage7
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style07_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style07_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style07_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style07_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style07_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style07_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style07_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style07_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style07_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage8
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style08_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style08_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style08_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style08_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style08_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style08_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style08_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style08_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style08_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'            Case Signage9
'                Game.FadeScreenOut(500)
'                Wait(500)
'                If NumberText.Contains("1") Then WriteCfgValue(NumberText, "numbering_style09_n1", saveFile)
'                If NumberText.Contains("2") Then WriteCfgValue(NumberText, "numbering_style09_n2", saveFile)
'                If NumberText.Contains("3") Then WriteCfgValue(NumberText, "numbering_style09_n3", saveFile)
'                If NumberText.Contains("1") Then Apartment.GarageNumber1 = "numbering_style09_n1"
'                If NumberText.Contains("2") Then Apartment.GarageNumber2 = "numbering_style09_n2"
'                If NumberText.Contains("3") Then Apartment.GarageNumber3 = "numbering_style09_n3"
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style09_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style09_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style09_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'                NumberMenu.Visible = False
'                hideHud = False
'                World.DestroyAllCameras()
'                World.RenderingCamera = Nothing
'        End Select
'    End Sub

'    Public Sub IndexChangeHandler(sender As UIMenu, index As Integer)
'        Select Case sender.MenuItems(index).Text
'            Case Interior1
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_01")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Interior2
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_02")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Interior3
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_03")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Interior4
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Wall)
'                EnableInteriotProp(InteriorID, "garage_decor_04")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting1
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option01")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting2
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option02")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting3
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option03")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting4
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option04")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting5
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option05")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting6
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option06")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting7
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option07")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting8
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option08")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Lighting9
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Lighting)
'                EnableInteriotProp(InteriorID, "lighting_option09")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage1
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style01_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style01_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style01_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage2
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style02_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style02_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style02_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage3
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style03_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style03_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style03_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage4
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style04_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style04_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style04_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage5
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style05_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style05_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style05_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage6
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style06_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style06_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style06_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage7
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style07_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style07_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style07_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage8
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style08_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style08_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style08_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'            Case Signage9
'                Game.FadeScreenOut(500)
'                Wait(500)
'                RemoveAllOfficeGarageDecor(InteriorID, GarageDecorType.Signage)
'                If NumberText.Contains("1") Then EnableInteriotProp(InteriorID, "numbering_style09_n1")
'                If NumberText.Contains("2") Then EnableInteriotProp(InteriorID, "numbering_style09_n2")
'                If NumberText.Contains("3") Then EnableInteriotProp(InteriorID, "numbering_style09_n3")
'                Wait(500)
'                Game.FadeScreenIn(500)
'        End Select

'    End Sub

'    Public Shared Sub LoadGarageVehicle(ByRef veh As Vehicle, file As String, pos As Vector3, rot As Vector3, head As Single)
'        Try
'            If veh = Nothing Then
'                veh = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
'            Else
'                veh.Delete()
'                veh = CreateVehicle(ReadCfgValue("VehicleModel", file), ReadCfgValue("VehicleHash", file), pos, head)
'            End If

'            SetModKit(veh, file, False)
'            veh.Rotation = rot
'            If ReadCfgValue("Active", file) = "True" Then veh.Delete()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub LoadGarageVechicles(file As String)
'        Try
'            If Not veh0 = Nothing Then veh0.Delete()
'            If Not veh1 = Nothing Then veh1.Delete()
'            If Not veh2 = Nothing Then veh2.Delete()
'            If Not veh3 = Nothing Then veh3.Delete()
'            If Not veh4 = Nothing Then veh4.Delete()
'            If Not veh5 = Nothing Then veh5.Delete()
'            If Not veh6 = Nothing Then veh6.Delete()
'            If Not veh7 = Nothing Then veh7.Delete()
'            If Not veh8 = Nothing Then veh8.Delete()
'            If Not veh9 = Nothing Then veh9.Delete()
'            If Not veh10 = Nothing Then veh10.Delete()
'            If Not veh11 = Nothing Then veh11.Delete()
'            If Not veh12 = Nothing Then veh12.Delete()
'            If Not veh13 = Nothing Then veh13.Delete()
'            If Not veh14 = Nothing Then veh14.Delete()
'            If Not veh15 = Nothing Then veh15.Delete()
'            If Not veh16 = Nothing Then veh16.Delete()
'            If Not veh17 = Nothing Then veh17.Delete()
'            If Not veh18 = Nothing Then veh18.Delete()
'            If Not veh19 = Nothing Then veh19.Delete()

'            If IO.File.Exists(file & "Vehicle_0.cfg") Then LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot0613, -60)
'            If IO.File.Exists(file & "Vehicle_1.cfg") Then LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot1714, -60)
'            If IO.File.Exists(file & "Vehicle_2.cfg") Then LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot2815, -60)
'            If IO.File.Exists(file & "Vehicle_3.cfg") Then LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot3916, -60)
'            If IO.File.Exists(file & "Vehicle_4.cfg") Then LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot41017, -60)
'            If IO.File.Exists(file & "Vehicle_5.cfg") Then LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot51118, -60)
'            If IO.File.Exists(file & "Vehicle_6.cfg") Then LoadGarageVehicle(veh6, file & "vehicle_6.cfg", veh6Pos, vehRot0613, -60)
'            If IO.File.Exists(file & "Vehicle_7.cfg") Then LoadGarageVehicle(veh7, file & "vehicle_7.cfg", veh7Pos, vehRot1714, -60)
'            If IO.File.Exists(file & "Vehicle_8.cfg") Then LoadGarageVehicle(veh8, file & "vehicle_8.cfg", veh8Pos, vehRot2815, -60)
'            If IO.File.Exists(file & "Vehicle_9.cfg") Then LoadGarageVehicle(veh9, file & "vehicle_9.cfg", veh9Pos, vehRot3916, -60)
'            If IO.File.Exists(file & "Vehicle_10.cfg") Then LoadGarageVehicle(veh10, file & "vehicle_10.cfg", veh10Pos, vehRot41017, -60)
'            If IO.File.Exists(file & "Vehicle_11.cfg") Then LoadGarageVehicle(veh11, file & "vehicle_11.cfg", veh11Pos, vehRot51118, -60)
'            If IO.File.Exists(file & "Vehicle_12.cfg") Then LoadGarageVehicle(veh12, file & "vehicle_12.cfg", veh12Pos, vehRot1219, -60)
'            If IO.File.Exists(file & "Vehicle_13.cfg") Then LoadGarageVehicle(veh13, file & "vehicle_13.cfg", veh13Pos, vehRot0613, -60)
'            If IO.File.Exists(file & "Vehicle_14.cfg") Then LoadGarageVehicle(veh14, file & "vehicle_14.cfg", veh14Pos, vehRot1714, -60)
'            If IO.File.Exists(file & "Vehicle_15.cfg") Then LoadGarageVehicle(veh15, file & "vehicle_15.cfg", veh15Pos, vehRot2815, -60)
'            If IO.File.Exists(file & "Vehicle_16.cfg") Then LoadGarageVehicle(veh16, file & "vehicle_16.cfg", veh16Pos, vehRot3916, -60)
'            If IO.File.Exists(file & "Vehicle_17.cfg") Then LoadGarageVehicle(veh17, file & "vehicle_17.cfg", veh17Pos, vehRot41017, -60)
'            If IO.File.Exists(file & "Vehicle_18.cfg") Then LoadGarageVehicle(veh18, file & "vehicle_18.cfg", veh18Pos, vehRot51118, -60)
'            If IO.File.Exists(file & "Vehicle_19.cfg") Then LoadGarageVehicle(veh19, file & "vehicle_19.cfg", veh19Pos, vehRot1219, -60)

'            Mechanic.Path = file
'            Mechanic.CreateGarageMenu(file, True)
'            Mechanic.CreateGarageMenu2("Twenty")

'            veh0.MarkAsNoLongerNeeded()
'            veh1.MarkAsNoLongerNeeded()
'            veh2.MarkAsNoLongerNeeded()
'            veh3.MarkAsNoLongerNeeded()
'            veh4.MarkAsNoLongerNeeded()
'            veh5.MarkAsNoLongerNeeded()
'            veh6.MarkAsNoLongerNeeded()
'            veh7.MarkAsNoLongerNeeded()
'            veh8.MarkAsNoLongerNeeded()
'            veh9.MarkAsNoLongerNeeded()
'            veh10.MarkAsNoLongerNeeded()
'            veh11.MarkAsNoLongerNeeded()
'            veh12.MarkAsNoLongerNeeded()
'            veh13.MarkAsNoLongerNeeded()
'            veh14.MarkAsNoLongerNeeded()
'            veh15.MarkAsNoLongerNeeded()
'            veh16.MarkAsNoLongerNeeded()
'            veh17.MarkAsNoLongerNeeded()
'            veh18.MarkAsNoLongerNeeded()
'            veh19.MarkAsNoLongerNeeded()

'            IfReturnedVehicle()
'        Catch ex As Exception
'            'logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub RefreshGarageVehicles(file As String)
'        Try
'            If Not Game.Player.Character.IsInVehicle Then
'                If IO.File.Exists(file & "vehicle_0.cfg") Then If ReadCfgValue("Active", file & "vehicle_0.cfg") = "False" AndAlso Not veh0.Exists Then LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot0613, -60)
'                If IO.File.Exists(file & "vehicle_1.cfg") Then If ReadCfgValue("Active", file & "vehicle_1.cfg") = "False" AndAlso Not veh1.Exists Then LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot1714, -60)
'                If IO.File.Exists(file & "vehicle_2.cfg") Then If ReadCfgValue("Active", file & "vehicle_2.cfg") = "False" AndAlso Not veh2.Exists Then LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot2815, -60)
'                If IO.File.Exists(file & "vehicle_3.cfg") Then If ReadCfgValue("Active", file & "vehicle_3.cfg") = "False" AndAlso Not veh3.Exists Then LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot3916, -60)
'                If IO.File.Exists(file & "vehicle_4.cfg") Then If ReadCfgValue("Active", file & "vehicle_4.cfg") = "False" AndAlso Not veh4.Exists Then LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot41017, -60)
'                If IO.File.Exists(file & "vehicle_5.cfg") Then If ReadCfgValue("Active", file & "vehicle_5.cfg") = "False" AndAlso Not veh5.Exists Then LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot51118, -60)
'                If IO.File.Exists(file & "vehicle_6.cfg") Then If ReadCfgValue("Active", file & "vehicle_6.cfg") = "False" AndAlso Not veh6.Exists Then LoadGarageVehicle(veh6, file & "vehicle_6.cfg", veh6Pos, vehRot0613, -60)
'                If IO.File.Exists(file & "vehicle_7.cfg") Then If ReadCfgValue("Active", file & "vehicle_7.cfg") = "False" AndAlso Not veh7.Exists Then LoadGarageVehicle(veh7, file & "vehicle_7.cfg", veh7Pos, vehRot1714, -60)
'                If IO.File.Exists(file & "vehicle_8.cfg") Then If ReadCfgValue("Active", file & "vehicle_8.cfg") = "False" AndAlso Not veh8.Exists Then LoadGarageVehicle(veh8, file & "vehicle_8.cfg", veh8Pos, vehRot2815, -60)
'                If IO.File.Exists(file & "vehicle_9.cfg") Then If ReadCfgValue("Active", file & "vehicle_9.cfg") = "False" AndAlso Not veh9.Exists Then LoadGarageVehicle(veh9, file & "vehicle_9.cfg", veh9Pos, vehRot3916, -60)
'                If IO.File.Exists(file & "vehicle_10.cfg") Then If ReadCfgValue("Active", file & "vehicle_10.cfg") = "False" AndAlso Not veh10.Exists Then LoadGarageVehicle(veh10, file & "vehicle_10.cfg", veh10Pos, vehRot41017, -60)
'                If IO.File.Exists(file & "vehicle_11.cfg") Then If ReadCfgValue("Active", file & "vehicle_11.cfg") = "False" AndAlso Not veh11.Exists Then LoadGarageVehicle(veh11, file & "vehicle_11.cfg", veh11Pos, vehRot51118, -60)
'                If IO.File.Exists(file & "vehicle_12.cfg") Then If ReadCfgValue("Active", file & "vehicle_12.cfg") = "False" AndAlso Not veh12.Exists Then LoadGarageVehicle(veh12, file & "vehicle_12.cfg", veh12Pos, vehRot1219, -60)
'                If IO.File.Exists(file & "vehicle_13.cfg") Then If ReadCfgValue("Active", file & "vehicle_13.cfg") = "False" AndAlso Not veh13.Exists Then LoadGarageVehicle(veh13, file & "vehicle_13.cfg", veh13Pos, vehRot0613, -60)
'                If IO.File.Exists(file & "vehicle_14.cfg") Then If ReadCfgValue("Active", file & "vehicle_14.cfg") = "False" AndAlso Not veh14.Exists Then LoadGarageVehicle(veh14, file & "vehicle_14.cfg", veh14Pos, vehRot1714, -60)
'                If IO.File.Exists(file & "vehicle_15.cfg") Then If ReadCfgValue("Active", file & "vehicle_15.cfg") = "False" AndAlso Not veh15.Exists Then LoadGarageVehicle(veh15, file & "vehicle_15.cfg", veh15Pos, vehRot2815, -60)
'                If IO.File.Exists(file & "vehicle_16.cfg") Then If ReadCfgValue("Active", file & "vehicle_16.cfg") = "False" AndAlso Not veh16.Exists Then LoadGarageVehicle(veh16, file & "vehicle_16.cfg", veh16Pos, vehRot3916, -60)
'                If IO.File.Exists(file & "vehicle_17.cfg") Then If ReadCfgValue("Active", file & "vehicle_17.cfg") = "False" AndAlso Not veh17.Exists Then LoadGarageVehicle(veh17, file & "vehicle_17.cfg", veh17Pos, vehRot41017, -60)
'                If IO.File.Exists(file & "vehicle_18.cfg") Then If ReadCfgValue("Active", file & "vehicle_18.cfg") = "False" AndAlso Not veh18.Exists Then LoadGarageVehicle(veh18, file & "vehicle_18.cfg", veh18Pos, vehRot51118, -60)
'                If IO.File.Exists(file & "vehicle_19.cfg") Then If ReadCfgValue("Active", file & "vehicle_19.cfg") = "False" AndAlso Not veh19.Exists Then LoadGarageVehicle(veh19, file & "vehicle_19.cfg", veh19Pos, vehRot1219, -60)
'                veh0.MarkAsNoLongerNeeded()
'                veh1.MarkAsNoLongerNeeded()
'                veh2.MarkAsNoLongerNeeded()
'                veh3.MarkAsNoLongerNeeded()
'                veh4.MarkAsNoLongerNeeded()
'                veh5.MarkAsNoLongerNeeded()
'                veh6.MarkAsNoLongerNeeded()
'                veh7.MarkAsNoLongerNeeded()
'                veh8.MarkAsNoLongerNeeded()
'                veh9.MarkAsNoLongerNeeded()
'                veh10.MarkAsNoLongerNeeded()
'                veh11.MarkAsNoLongerNeeded()
'                veh12.MarkAsNoLongerNeeded()
'                veh13.MarkAsNoLongerNeeded()
'                veh14.MarkAsNoLongerNeeded()
'                veh15.MarkAsNoLongerNeeded()
'                veh16.MarkAsNoLongerNeeded()
'                veh17.MarkAsNoLongerNeeded()
'                veh18.MarkAsNoLongerNeeded()
'                veh19.MarkAsNoLongerNeeded()
'            End If
'        Catch ex As Exception
'            'logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub IfReturnedVehicle()
'        If playerPed.IsInVehicle Then
'            Select Case GetPlayerName()
'                Case "Michael"
'                    If Mechanic.MPersVeh.Exist Then Mechanic.MPersVeh.Delete()
'                Case "Franklin"
'                    If Mechanic.FPersVeh.Exist Then Mechanic.FPersVeh.Delete()
'                Case "Trevor"
'                    If Mechanic.TPersVeh.Exist Then Mechanic.TPersVeh.Delete()
'                Case "Player3"
'                    If Mechanic.PPersVeh.Exist Then Mechanic.FPersVeh.Delete()
'            End Select
'        End If
'    End Sub

'    Public Shared Sub IfTransferVehicle()
'        Select Case GetPlayerName()
'            Case "Michael"
'                If Mechanic.MPersVeh.Exist Then
'                    IO.File.Delete(Mechanic.MPersVeh.FilePath)
'                    Mechanic.MPersVeh.Delete()
'                End If
'            Case "Franklin"
'                If Mechanic.FPersVeh.Exist Then
'                    IO.File.Delete(Mechanic.FPersVeh.FilePath)
'                    Mechanic.FPersVeh.Delete()
'                End If
'            Case "Trevor"
'                If Mechanic.TPersVeh.Exist Then
'                    IO.File.Delete(Mechanic.TPersVeh.FilePath)
'                    Mechanic.TPersVeh.Delete()
'                End If
'            Case "Player3"
'                If Mechanic.PPersVeh.Exist Then
'                    IO.File.Delete(Mechanic.PPersVeh.FilePath)
'                    Mechanic.FPersVeh.Delete()
'                End If
'        End Select
'    End Sub

'    Public Shared Sub SaveGarageVehicle(file As String)
'        Try
'            If Not IO.File.Exists(file & "vehicle_0.cfg") Then
'                CreateFile(file & "vehicle_0.cfg")
'                UpdateGarageVehicle(file & "vehicle_0.cfg", "False")
'                LoadGarageVehicle(veh0, file & "vehicle_0.cfg", veh0Pos, vehRot0613, -60)
'                IfTransferVehicle()
'                Game.FadeScreenOut(500)
'                Wait(500)
'                playerPed.CurrentVehicle.Delete()
'                If Not veh0 = Nothing Then
'                    playerPed.Position = veh0Pos
'                    SetIntoVehicle(playerPed, veh0, VehicleSeat.Driver)
'                Else
'                    playerPed.Position = veh0Pos
'                End If
'                Wait(500)
'                Game.FadeScreenIn(500)
'                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'            Else
'                If Not IO.File.Exists(file & "vehicle_1.cfg") Then
'                    CreateFile(file & "vehicle_1.cfg")
'                    UpdateGarageVehicle(file & "vehicle_1.cfg", "False")
'                    LoadGarageVehicle(veh1, file & "vehicle_1.cfg", veh1Pos, vehRot1714, -60)
'                    IfTransferVehicle()
'                    Game.FadeScreenOut(500)
'                    Wait(500)
'                    playerPed.CurrentVehicle.Delete()
'                    If Not veh1 = Nothing Then
'                        playerPed.Position = veh1Pos
'                        SetIntoVehicle(playerPed, veh1, VehicleSeat.Driver)
'                    Else
'                        playerPed.Position = veh1Pos
'                    End If
'                    Wait(500)
'                    Game.FadeScreenIn(500)
'                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                Else
'                    If Not IO.File.Exists(file & "vehicle_2.cfg") Then
'                        CreateFile(file & "vehicle_2.cfg")
'                        UpdateGarageVehicle(file & "vehicle_2.cfg", "False")
'                        LoadGarageVehicle(veh2, file & "vehicle_2.cfg", veh2Pos, vehRot2815, -60)
'                        IfTransferVehicle()
'                        Game.FadeScreenOut(500)
'                        Wait(500)
'                        playerPed.CurrentVehicle.Delete()
'                        If Not veh2 = Nothing Then
'                            playerPed.Position = veh2Pos
'                            SetIntoVehicle(playerPed, veh2, VehicleSeat.Driver)
'                        Else
'                            playerPed.Position = veh2Pos
'                        End If
'                        Wait(500)
'                        Game.FadeScreenIn(500)
'                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                    Else
'                        If Not IO.File.Exists(file & "vehicle_3.cfg") Then
'                            CreateFile(file & "vehicle_3.cfg")
'                            UpdateGarageVehicle(file & "vehicle_3.cfg", "False")
'                            LoadGarageVehicle(veh3, file & "vehicle_3.cfg", veh3Pos, vehRot3916, -60)
'                            IfTransferVehicle()
'                            Game.FadeScreenOut(500)
'                            Wait(500)
'                            playerPed.CurrentVehicle.Delete()
'                            If Not veh3 = Nothing Then
'                                playerPed.Position = veh3Pos
'                                SetIntoVehicle(playerPed, veh3, VehicleSeat.Driver)
'                            Else
'                                playerPed.Position = veh3Pos
'                            End If
'                            Wait(500)
'                            Game.FadeScreenIn(500)
'                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                        Else
'                            If Not IO.File.Exists(file & "vehicle_4.cfg") Then
'                                CreateFile(file & "vehicle_4.cfg")
'                                UpdateGarageVehicle(file & "vehicle_4.cfg", "False")
'                                LoadGarageVehicle(veh4, file & "vehicle_4.cfg", veh4Pos, vehRot41017, -60)
'                                IfTransferVehicle()
'                                Game.FadeScreenOut(500)
'                                Wait(500)
'                                playerPed.CurrentVehicle.Delete()
'                                If Not veh4 = Nothing Then
'                                    playerPed.Position = veh4Pos
'                                    SetIntoVehicle(playerPed, veh4, VehicleSeat.Driver)
'                                Else
'                                    playerPed.Position = veh4Pos
'                                End If
'                                Wait(500)
'                                Game.FadeScreenIn(500)
'                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                            Else
'                                If Not IO.File.Exists(file & "vehicle_5.cfg") Then
'                                    CreateFile(file & "vehicle_5.cfg")
'                                    UpdateGarageVehicle(file & "vehicle_5.cfg", "False")
'                                    LoadGarageVehicle(veh5, file & "vehicle_5.cfg", veh5Pos, vehRot51118, -60)
'                                    IfTransferVehicle()
'                                    Game.FadeScreenOut(500)
'                                    Wait(500)
'                                    playerPed.CurrentVehicle.Delete()
'                                    If Not veh5 = Nothing Then
'                                        playerPed.Position = veh5Pos
'                                        SetIntoVehicle(playerPed, veh5, VehicleSeat.Driver)
'                                    Else
'                                        playerPed.Position = veh5Pos
'                                    End If
'                                    Wait(500)
'                                    Game.FadeScreenIn(500)
'                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                Else
'                                    If Not IO.File.Exists(file & "vehicle_6.cfg") Then
'                                        CreateFile(file & "vehicle_6.cfg")
'                                        UpdateGarageVehicle(file & "vehicle_6.cfg", "False")
'                                        LoadGarageVehicle(veh6, file & "vehicle_6.cfg", veh6Pos, vehRot0613, -60)
'                                        IfTransferVehicle()
'                                        Game.FadeScreenOut(500)
'                                        Wait(500)
'                                        playerPed.CurrentVehicle.Delete()
'                                        If Not veh6 = Nothing Then
'                                            playerPed.Position = veh6Pos
'                                            SetIntoVehicle(playerPed, veh6, VehicleSeat.Driver)
'                                        Else
'                                            playerPed.Position = veh6Pos
'                                        End If
'                                        Wait(500)
'                                        Game.FadeScreenIn(500)
'                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                    Else
'                                        If Not IO.File.Exists(file & "vehicle_7.cfg") Then
'                                            CreateFile(file & "vehicle_7.cfg")
'                                            UpdateGarageVehicle(file & "vehicle_7.cfg", "False")
'                                            LoadGarageVehicle(veh7, file & "vehicle_7.cfg", veh7Pos, vehRot1714, -60)
'                                            IfTransferVehicle()
'                                            Game.FadeScreenOut(500)
'                                            Wait(500)
'                                            playerPed.CurrentVehicle.Delete()
'                                            If Not veh7 = Nothing Then
'                                                playerPed.Position = veh7Pos
'                                                SetIntoVehicle(playerPed, veh7, VehicleSeat.Driver)
'                                            Else
'                                                playerPed.Position = veh7Pos
'                                            End If
'                                            Wait(500)
'                                            Game.FadeScreenIn(500)
'                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                        Else
'                                            If Not IO.File.Exists(file & "vehicle_8.cfg") Then
'                                                CreateFile(file & "vehicle_8.cfg")
'                                                UpdateGarageVehicle(file & "vehicle_8.cfg", "False")
'                                                LoadGarageVehicle(veh8, file & "vehicle_8.cfg", veh8Pos, vehRot2815, -60)
'                                                IfTransferVehicle()
'                                                Game.FadeScreenOut(500)
'                                                Wait(500)
'                                                playerPed.CurrentVehicle.Delete()
'                                                If Not veh8 = Nothing Then
'                                                    playerPed.Position = veh8Pos
'                                                    SetIntoVehicle(playerPed, veh8, VehicleSeat.Driver)
'                                                Else
'                                                    playerPed.Position = veh8Pos
'                                                End If
'                                                Wait(500)
'                                                Game.FadeScreenIn(500)
'                                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                            Else
'                                                If Not IO.File.Exists(file & "vehicle_9.cfg") Then
'                                                    CreateFile(file & "vehicle_9.cfg")
'                                                    UpdateGarageVehicle(file & "vehicle_9.cfg", "False")
'                                                    LoadGarageVehicle(veh9, file & "vehicle_9.cfg", veh9Pos, vehRot3916, -60)
'                                                    IfTransferVehicle()
'                                                    Game.FadeScreenOut(500)
'                                                    Wait(500)
'                                                    playerPed.CurrentVehicle.Delete()
'                                                    If Not veh9 = Nothing Then
'                                                        playerPed.Position = veh9Pos
'                                                        SetIntoVehicle(playerPed, veh9, VehicleSeat.Driver)
'                                                    Else
'                                                        playerPed.Position = veh9Pos
'                                                    End If
'                                                    Wait(500)
'                                                    Game.FadeScreenIn(500)
'                                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                Else
'                                                    If Not IO.File.Exists(file & "vehicle_10.cfg") Then
'                                                        CreateFile(file & "vehicle_10.cfg")
'                                                        UpdateGarageVehicle(file & "vehicle_10.cfg", "False")
'                                                        LoadGarageVehicle(veh10, file & "vehicle_10.cfg", veh10Pos, vehRot41017, -60)
'                                                        IfTransferVehicle()
'                                                        Game.FadeScreenOut(500)
'                                                        Wait(500)
'                                                        playerPed.CurrentVehicle.Delete()
'                                                        If Not veh10 = Nothing Then
'                                                            playerPed.Position = veh10Pos
'                                                            SetIntoVehicle(playerPed, veh10, VehicleSeat.Driver)
'                                                        Else
'                                                            playerPed.Position = veh10Pos
'                                                        End If
'                                                        Wait(500)
'                                                        Game.FadeScreenIn(500)
'                                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                    Else
'                                                        If Not IO.File.Exists(file & "vehicle_11.cfg") Then
'                                                            CreateFile(file & "vehicle_11.cfg")
'                                                            UpdateGarageVehicle(file & "vehicle_11.cfg", "False")
'                                                            LoadGarageVehicle(veh11, file & "vehicle_11.cfg", veh11Pos, vehRot51118, -60)
'                                                            IfTransferVehicle()
'                                                            Game.FadeScreenOut(500)
'                                                            Wait(500)
'                                                            playerPed.CurrentVehicle.Delete()
'                                                            If Not veh11 = Nothing Then
'                                                                playerPed.Position = veh11Pos
'                                                                SetIntoVehicle(playerPed, veh11, VehicleSeat.Driver)
'                                                            Else
'                                                                playerPed.Position = veh11Pos
'                                                            End If
'                                                            Wait(500)
'                                                            Game.FadeScreenIn(500)
'                                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                        Else
'                                                            If Not IO.File.Exists(file & "vehicle_12.cfg") Then
'                                                                CreateFile(file & "vehicle_12.cfg")
'                                                                UpdateGarageVehicle(file & "vehicle_12.cfg", "False")
'                                                                LoadGarageVehicle(veh12, file & "vehicle_12.cfg", veh12Pos, vehRot1219, -60)
'                                                                IfTransferVehicle()
'                                                                Game.FadeScreenOut(500)
'                                                                Wait(500)
'                                                                playerPed.CurrentVehicle.Delete()
'                                                                If Not veh12 = Nothing Then
'                                                                    playerPed.Position = veh12Pos
'                                                                    SetIntoVehicle(playerPed, veh12, VehicleSeat.Driver)
'                                                                Else
'                                                                    playerPed.Position = veh12Pos
'                                                                End If
'                                                                Wait(500)
'                                                                Game.FadeScreenIn(500)
'                                                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                            Else
'                                                                If Not IO.File.Exists(file & "vehicle_13.cfg") Then
'                                                                    CreateFile(file & "vehicle_13.cfg")
'                                                                    UpdateGarageVehicle(file & "vehicle_13.cfg", "False")
'                                                                    LoadGarageVehicle(veh13, file & "vehicle_13.cfg", veh13Pos, vehRot0613, -60)
'                                                                    IfTransferVehicle()
'                                                                    Game.FadeScreenOut(500)
'                                                                    Wait(500)
'                                                                    playerPed.CurrentVehicle.Delete()
'                                                                    If Not veh13 = Nothing Then
'                                                                        playerPed.Position = veh13Pos
'                                                                        SetIntoVehicle(playerPed, veh13, VehicleSeat.Driver)
'                                                                    Else
'                                                                        playerPed.Position = veh13Pos
'                                                                    End If
'                                                                    Wait(500)
'                                                                    Game.FadeScreenIn(500)
'                                                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                Else
'                                                                    If Not IO.File.Exists(file & "vehicle_14.cfg") Then
'                                                                        CreateFile(file & "vehicle_14.cfg")
'                                                                        UpdateGarageVehicle(file & "vehicle_14.cfg", "False")
'                                                                        LoadGarageVehicle(veh14, file & "vehicle_14.cfg", veh14Pos, vehRot1714, -60)
'                                                                        IfTransferVehicle()
'                                                                        Game.FadeScreenOut(500)
'                                                                        Wait(500)
'                                                                        playerPed.CurrentVehicle.Delete()
'                                                                        If Not veh14 = Nothing Then
'                                                                            playerPed.Position = veh14Pos
'                                                                            SetIntoVehicle(playerPed, veh14, VehicleSeat.Driver)
'                                                                        Else
'                                                                            playerPed.Position = veh14Pos
'                                                                        End If
'                                                                        Wait(500)
'                                                                        Game.FadeScreenIn(500)
'                                                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                    Else
'                                                                        If Not IO.File.Exists(file & "vehicle_15.cfg") Then
'                                                                            CreateFile(file & "vehicle_15.cfg")
'                                                                            UpdateGarageVehicle(file & "vehicle_15.cfg", "False")
'                                                                            LoadGarageVehicle(veh15, file & "vehicle_15.cfg", veh15Pos, vehRot2815, -60)
'                                                                            IfTransferVehicle()
'                                                                            Game.FadeScreenOut(500)
'                                                                            Wait(500)
'                                                                            playerPed.CurrentVehicle.Delete()
'                                                                            If Not veh15 = Nothing Then
'                                                                                playerPed.Position = veh15Pos
'                                                                                SetIntoVehicle(playerPed, veh15, VehicleSeat.Driver)
'                                                                            Else
'                                                                                playerPed.Position = veh15Pos
'                                                                            End If
'                                                                            Wait(500)
'                                                                            Game.FadeScreenIn(500)
'                                                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                        Else
'                                                                            If Not IO.File.Exists(file & "vehicle_16.cfg") Then
'                                                                                CreateFile(file & "vehicle_16.cfg")
'                                                                                UpdateGarageVehicle(file & "vehicle_16.cfg", "False")
'                                                                                LoadGarageVehicle(veh16, file & "vehicle_16.cfg", veh16Pos, vehRot3916, -60)
'                                                                                IfTransferVehicle()
'                                                                                Game.FadeScreenOut(500)
'                                                                                Wait(500)
'                                                                                playerPed.CurrentVehicle.Delete()
'                                                                                If Not veh16 = Nothing Then
'                                                                                    playerPed.Position = veh16Pos
'                                                                                    SetIntoVehicle(playerPed, veh16, VehicleSeat.Driver)
'                                                                                Else
'                                                                                    playerPed.Position = veh16Pos
'                                                                                End If
'                                                                                Wait(500)
'                                                                                Game.FadeScreenIn(500)
'                                                                                playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                            Else
'                                                                                If Not IO.File.Exists(file & "vehicle_17.cfg") Then
'                                                                                    CreateFile(file & "vehicle_17.cfg")
'                                                                                    UpdateGarageVehicle(file & "vehicle_17.cfg", "False")
'                                                                                    LoadGarageVehicle(veh17, file & "vehicle_17.cfg", veh17Pos, vehRot41017, -60)
'                                                                                    IfTransferVehicle()
'                                                                                    Game.FadeScreenOut(500)
'                                                                                    Wait(500)
'                                                                                    playerPed.CurrentVehicle.Delete()
'                                                                                    If Not veh17 = Nothing Then
'                                                                                        playerPed.Position = veh17Pos
'                                                                                        SetIntoVehicle(playerPed, veh17, VehicleSeat.Driver)
'                                                                                    Else
'                                                                                        playerPed.Position = veh17Pos
'                                                                                    End If
'                                                                                    Wait(500)
'                                                                                    Game.FadeScreenIn(500)
'                                                                                    playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                                Else
'                                                                                    If Not IO.File.Exists(file & "vehicle_18.cfg") Then
'                                                                                        CreateFile(file & "vehicle_18.cfg")
'                                                                                        UpdateGarageVehicle(file & "vehicle_18.cfg", "False")
'                                                                                        LoadGarageVehicle(veh18, file & "vehicle_18.cfg", veh18Pos, vehRot51118, -60)
'                                                                                        IfTransferVehicle()
'                                                                                        Game.FadeScreenOut(500)
'                                                                                        Wait(500)
'                                                                                        playerPed.CurrentVehicle.Delete()
'                                                                                        If Not veh18 = Nothing Then
'                                                                                            playerPed.Position = veh18Pos
'                                                                                            SetIntoVehicle(playerPed, veh18, VehicleSeat.Driver)
'                                                                                        Else
'                                                                                            playerPed.Position = veh18Pos
'                                                                                        End If
'                                                                                        Wait(500)
'                                                                                        Game.FadeScreenIn(500)
'                                                                                        playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                                    Else
'                                                                                        If Not IO.File.Exists(file & "vehicle_19.cfg") Then
'                                                                                            CreateFile(file & "vehicle_19.cfg")
'                                                                                            UpdateGarageVehicle(file & "vehicle_19.cfg", "False")
'                                                                                            LoadGarageVehicle(veh19, file & "vehicle_19.cfg", veh19Pos, vehRot1219, -60)
'                                                                                            IfTransferVehicle()
'                                                                                            Game.FadeScreenOut(500)
'                                                                                            Wait(500)
'                                                                                            playerPed.CurrentVehicle.Delete()
'                                                                                            If Not veh19 = Nothing Then
'                                                                                                playerPed.Position = veh19Pos
'                                                                                                SetIntoVehicle(playerPed, veh19, VehicleSeat.Driver)
'                                                                                            Else
'                                                                                                playerPed.Position = veh19Pos
'                                                                                            End If
'                                                                                            Wait(500)
'                                                                                            Game.FadeScreenIn(500)
'                                                                                            playerPed.Task.LeaveVehicle(playerPed.CurrentVehicle, True)
'                                                                                        Else
'                                                                                            UI.ShowSubtitle(GrgFull)
'                                                                                        End If
'                                                                                    End If
'                                                                                End If
'                                                                            End If
'                                                                        End If
'                                                                    End If
'                                                                End If
'                                                            End If
'                                                        End If
'                                                    End If
'                                                End If
'                                            End If
'                                        End If
'                                    End If
'                                End If
'                            End If
'                        End If
'                    End If
'                End If
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub UpdateGarageVehicle(file As String, Active As String)
'        WriteCfgValue("VehicleName", playerPed.CurrentVehicle.FriendlyName, file)
'        'WriteCfgValue("VehicleModel", GetModelFromHash(playerPed.CurrentVehicle), file)
'        WriteCfgValue("PrimaryColor", playerPed.CurrentVehicle.PrimaryColor, file)
'        WriteCfgValue("SecondaryColor", playerPed.CurrentVehicle.SecondaryColor, file)
'        WriteCfgValue("PearlescentColor", playerPed.CurrentVehicle.PearlescentColor, file)
'        WriteCfgValue("HasCustomPrimaryColor", playerPed.CurrentVehicle.IsPrimaryColorCustom, file)
'        WriteCfgValue("HasCustomSecondaryColor", playerPed.CurrentVehicle.IsSecondaryColorCustom, file)
'        WriteCfgValue("CustomPrimaryColorRed", playerPed.CurrentVehicle.CustomPrimaryColor.R, file)
'        WriteCfgValue("CustomPrimaryColorGreen", playerPed.CurrentVehicle.CustomPrimaryColor.G, file)
'        WriteCfgValue("CustomPrimaryColorBlue", playerPed.CurrentVehicle.CustomPrimaryColor.B, file)
'        WriteCfgValue("CustomSecondaryColorRed", playerPed.CurrentVehicle.CustomSecondaryColor.R, file)
'        WriteCfgValue("CustomSecondaryColorGreen", playerPed.CurrentVehicle.CustomSecondaryColor.G, file)
'        WriteCfgValue("CustomSecondaryColorBlue", playerPed.CurrentVehicle.CustomSecondaryColor.B, file)
'        WriteCfgValue("RimColor", playerPed.CurrentVehicle.RimColor, file)
'        WriteCfgValue("HasNeonLightBack", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Back), file)
'        WriteCfgValue("HasNeonLightFront", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Front), file)
'        WriteCfgValue("HasNeonLightLeft", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Left), file)
'        WriteCfgValue("HasNeonLightRight", playerPed.CurrentVehicle.IsNeonLightsOn(VehicleNeonLight.Right), file)
'        WriteCfgValue("NeonColorRed", playerPed.CurrentVehicle.NeonLightsColor.R, file)
'        WriteCfgValue("NeonColorGreen", playerPed.CurrentVehicle.NeonLightsColor.G, file)
'        WriteCfgValue("NeonColorBlue", playerPed.CurrentVehicle.NeonLightsColor.B, file)
'        WriteCfgValue("TyreSmokeColorRed", playerPed.CurrentVehicle.TireSmokeColor.R, file)
'        WriteCfgValue("TyreSmokeColorGreen", playerPed.CurrentVehicle.TireSmokeColor.G, file)
'        WriteCfgValue("TyreSmokeColorBlue", playerPed.CurrentVehicle.TireSmokeColor.B, file)
'        WriteCfgValue("WheelType", playerPed.CurrentVehicle.WheelType, file)
'        WriteCfgValue("Livery", playerPed.CurrentVehicle.Livery, file)
'        WriteCfgValue("PlateType", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, playerPed.CurrentVehicle), file)
'        WriteCfgValue("PlateNumber", playerPed.CurrentVehicle.NumberPlate, file)
'        WriteCfgValue("WindowTint", playerPed.CurrentVehicle.WindowTint, file)
'        WriteCfgValue("Spoiler", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 0), file)
'        WriteCfgValue("FrontBumper", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 1), file)
'        WriteCfgValue("RearBumper", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 2), file)
'        WriteCfgValue("SideSkirt", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 3), file)
'        WriteCfgValue("Frame", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 5), file)
'        WriteCfgValue("Grille", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 6), file)
'        WriteCfgValue("Hood", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 7), file)
'        WriteCfgValue("Fender", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 8), file)
'        WriteCfgValue("RightFender", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 9), file)
'        WriteCfgValue("Roof", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 10), file)
'        WriteCfgValue("Exhaust", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 4), file)
'        WriteCfgValue("FrontWheels", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 23), file)
'        WriteCfgValue("BackWheels", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 24), file)
'        WriteCfgValue("Suspension", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 15), file)
'        WriteCfgValue("Engine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 11), file)
'        WriteCfgValue("Brakes", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 12), file)
'        WriteCfgValue("Transmission", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 13), file)
'        WriteCfgValue("Armor", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 16), file)
'        WriteCfgValue("XenonHeadlights", Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, playerPed.CurrentVehicle, 22), file)
'        WriteCfgValue("Turbo", Native.Function.Call(Of Boolean)(Hash.IS_TOGGLE_MOD_ON, playerPed.CurrentVehicle, 18), file)
'        'Added on v1.1.3
'        WriteCfgValue("Horn", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 14), file)
'        WriteCfgValue("BulletproofTyres", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_TYRES_CAN_BURST, playerPed.CurrentVehicle), file)
'        WriteCfgValue("Active", Active, file)
'        'Added on v1.2.1
'        WriteCfgValue("FrontTireVariation", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, playerPed.CurrentVehicle, 23), file)
'        WriteCfgValue("BackTireVariation", Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, playerPed.CurrentVehicle, 24), file)
'        WriteCfgValue("TwentyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 25), file)
'        WriteCfgValue("TwentySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 26), file)
'        WriteCfgValue("TwentySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 27), file)
'        WriteCfgValue("TwentyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 28), file)
'        WriteCfgValue("TwentyNine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 29), file)
'        WriteCfgValue("ThirtyZero", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 30), file)
'        WriteCfgValue("ThirtyOne", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 31), file)
'        WriteCfgValue("ThirtyTwo", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 32), file)
'        WriteCfgValue("ThirtyThree", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 33), file)
'        WriteCfgValue("ThirtyFour", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 34), file)
'        WriteCfgValue("ThirtyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 35), file)
'        WriteCfgValue("ThirtySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 36), file)
'        WriteCfgValue("ThirtySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 37), file)
'        WriteCfgValue("ThirtyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 38), file)
'        WriteCfgValue("ThirtyNine", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 39), file)
'        WriteCfgValue("ForthyZero", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 40), file)
'        WriteCfgValue("ForthyOne", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 41), file)
'        WriteCfgValue("ForthyTwo", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 42), file)
'        WriteCfgValue("ForthyThree", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 43), file)
'        WriteCfgValue("ForthyFour", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 44), file)
'        WriteCfgValue("ForthyFive", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 45), file)
'        WriteCfgValue("ForthySix", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 46), file)
'        WriteCfgValue("ForthySeven", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 47), file)
'        WriteCfgValue("ForthyEight", Native.Function.Call(Of Integer)(Hash.GET_VEHICLE_MOD, playerPed.CurrentVehicle, 48), file)
'        'Added on v1.3.1
'        WriteCfgValue("VehicleHash", playerPed.CurrentVehicle.Model.GetHashCode().ToString, file)
'        WriteCfgValue("VehicleRoof", Native.Function.Call(Of Integer)(Hash.GET_CONVERTIBLE_ROOF_STATE, playerPed.CurrentVehicle), file)
'        'Added on v1.3.3
'        WriteCfgValue("ExtraOne", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 1), file)
'        WriteCfgValue("ExtraTwo", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 2), file)
'        WriteCfgValue("ExtraThree", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 3), file)
'        WriteCfgValue("ExtraFour", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 4), file)
'        WriteCfgValue("ExtraFive", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 5), file)
'        WriteCfgValue("ExtraSix", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 6), file)
'        WriteCfgValue("ExtraSeven", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 7), file)
'        WriteCfgValue("ExtraEight", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 8), file)
'        WriteCfgValue("ExtraNine", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 9), file)
'        'Added on v1.3.4
'        'Updated on v1.9.2
'        WriteCfgValue("TrimColor", playerPed.CurrentVehicle.TrimColor, file)
'        WriteCfgValue("DashboardColor", playerPed.CurrentVehicle.DashboardColor, file)
'        'Added on v1.9.2
'        WriteCfgValue("ExtraTen", Native.Function.Call(Of Boolean)(Hash.IS_VEHICLE_EXTRA_TURNED_ON, playerPed.CurrentVehicle, 10), file)
'        WriteCfgValue("CustomRoof", GetTornadoCustomRoof(playerPed.CurrentVehicle), file)
'    End Sub

'    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
'        Try
'            If Not Game.IsLoading Then
'                ElevatorDistance = World.GetDistance(playerPed.Position, Elevator)
'                GarageMarkerDistance = World.GetDistance(playerPed.Position, MenuActivator)

'                If IsIPLActive(Apartment.GarageIPL) Then
'                    InteriorID = INMNative.Apartment.GetInteriorID(New Vector3(-1395.882, -480.5163, 56.10049))
'                    If Not InteriorID = 0 AndAlso Not InteriorIDList.Contains(InteriorID) Then InteriorIDList.Add(InteriorID)
'                End If

'                If InteriorID = playerInterior Then
'                    World.DrawMarker(MarkerType.VerticalCylinder, MenuActivator, Vector3.Zero, Vector3.Zero, New Vector3(1.0, 1.0, 1.0), Drawing.Color.LightBlue)
'                    If My.Settings.RefreshGrgVehs = True Then RefreshGarageVehicles(CurrentPath)
'                Else
'                    If Not Game.Player.Character.IsInVehicle Then
'                        If Not veh0 = Nothing Then veh0.Delete()
'                        If Not veh1 = Nothing Then veh1.Delete()
'                        If Not veh2 = Nothing Then veh2.Delete()
'                        If Not veh3 = Nothing Then veh3.Delete()
'                        If Not veh4 = Nothing Then veh4.Delete()
'                        If Not veh5 = Nothing Then veh5.Delete()
'                        If Not veh6 = Nothing Then veh6.Delete()
'                        If Not veh7 = Nothing Then veh7.Delete()
'                        If Not veh8 = Nothing Then veh8.Delete()
'                        If Not veh9 = Nothing Then veh9.Delete()
'                        If Not veh10 = Nothing Then veh0.Delete()
'                        If Not veh11 = Nothing Then veh11.Delete()
'                        If Not veh12 = Nothing Then veh12.Delete()
'                        If Not veh13 = Nothing Then veh13.Delete()
'                        If Not veh14 = Nothing Then veh14.Delete()
'                        If Not veh15 = Nothing Then veh15.Delete()
'                        If Not veh16 = Nothing Then veh16.Delete()
'                        If Not veh17 = Nothing Then veh17.Delete()
'                        If Not veh18 = Nothing Then veh18.Delete()
'                        If Not veh19 = Nothing Then veh19.Delete()
'                    End If
'                End If

'                If Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead AndAlso ElevatorDistance < 3.0 Then
'                    DisplayHelpTextThisFrame(EnterElevator & LastLocationName)
'                End If

'                If Not playerPed.IsDead AndAlso GarageMarkerDistance < 1.5 Then
'                    DisplayHelpTextThisFrame(ManageGarage)
'                End If

'                ControlsKeyDown()

'                _menuPool.ProcessMenus()
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub ControlsKeyDown()
'        On Error Resume Next

'        If playerPed.IsInVehicle AndAlso playerPed.CurrentVehicle.Speed > 1.5 AndAlso InteriorID = playerInterior AndAlso IsInGarageVehicle(playerPed) = True Then
'            Dim PPCV As Integer = -1
'            If playerPed.CurrentVehicle = veh0 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_0.cfg")
'                PPCV = 0
'            ElseIf playerPed.CurrentVehicle = veh1 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_1.cfg")
'                PPCV = 1
'            ElseIf playerPed.CurrentVehicle = veh2 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_2.cfg")
'                PPCV = 2
'            ElseIf playerPed.CurrentVehicle = veh3 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_3.cfg")
'                PPCV = 3
'            ElseIf playerPed.CurrentVehicle = veh4 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_4.cfg")
'                PPCV = 4
'            ElseIf playerPed.CurrentVehicle = veh5 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_5.cfg")
'                PPCV = 5
'            ElseIf playerPed.CurrentVehicle = veh6 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_6.cfg")
'                PPCV = 6
'            ElseIf playerPed.CurrentVehicle = veh7 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_7.cfg")
'                PPCV = 7
'            ElseIf playerPed.CurrentVehicle = veh8 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_8.cfg")
'                PPCV = 8
'            ElseIf playerPed.CurrentVehicle = veh9 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_9.cfg")
'                PPCV = 9
'            ElseIf playerPed.CurrentVehicle = veh10 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_10.cfg")
'                PPCV = 10
'            ElseIf playerPed.CurrentVehicle = veh11 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_11.cfg")
'                PPCV = 11
'            ElseIf playerPed.CurrentVehicle = veh12 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_12.cfg")
'                PPCV = 12
'            ElseIf playerPed.CurrentVehicle = veh13 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_13.cfg")
'                PPCV = 13
'            ElseIf playerPed.CurrentVehicle = veh14 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_14.cfg")
'                PPCV = 14
'            ElseIf playerPed.CurrentVehicle = veh15 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_15.cfg")
'                PPCV = 15
'            ElseIf playerPed.CurrentVehicle = veh16 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_16.cfg")
'                PPCV = 16
'            ElseIf playerPed.CurrentVehicle = veh17 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_17.cfg")
'                PPCV = 17
'            ElseIf playerPed.CurrentVehicle = veh18 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_18.cfg")
'                PPCV = 18
'            ElseIf playerPed.CurrentVehicle = veh19 Then
'                WriteCfgValue("Active", "True", CurrentPath & "vehicle_19.cfg")
'                PPCV = 19
'            End If

'            Game.FadeScreenOut(500)
'            Wait(500)

'            playerPed.CurrentVehicle.Delete()
'            If GetPlayerName() = "Michael" Then
'                If Mechanic.MPV0 = Nothing Then
'                    Mechanic.MPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.MPV0.IsPersistent = True
'                    Mechanic.MPV0.AddBlip()
'                    Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.MPV0.CurrentBlip.Color = BlipColor2.Michael
'                    Mechanic.MPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.MPV0.CurrentBlip.Name = Mechanic.MPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.MPV0, VehicleSeat.Driver)
'                    Mechanic.MPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.MPV0)
'                Else
'                    Mechanic.MPV0.Delete()
'                    Mechanic.MPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.MPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.MPV0.IsPersistent = True
'                    Mechanic.MPV0.AddBlip()
'                    Mechanic.MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.MPV0.CurrentBlip.Color = BlipColor2.Michael
'                    Mechanic.MPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.MPV0.CurrentBlip.Name = Mechanic.MPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.MPV0, VehicleSeat.Driver)
'                    Mechanic.MPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.MPV0)
'                End If
'            ElseIf GetPlayerName() = "Franklin" Then
'                If Mechanic.FPV0 = Nothing Then
'                    Mechanic.FPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.FPV0.IsPersistent = True
'                    Mechanic.FPV0.AddBlip()
'                    Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.FPV0.CurrentBlip.Color = BlipColor2.Franklin
'                    Mechanic.FPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.FPV0.CurrentBlip.Name = Mechanic.FPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.FPV0, VehicleSeat.Driver)
'                    Mechanic.FPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.FPV0)
'                Else
'                    Mechanic.FPV0.Delete()
'                    Mechanic.FPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.FPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.FPV0.IsPersistent = True
'                    Mechanic.FPV0.AddBlip()
'                    Mechanic.FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.FPV0.CurrentBlip.Color = BlipColor2.Franklin
'                    Mechanic.FPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.FPV0.CurrentBlip.Name = Mechanic.FPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.FPV0, VehicleSeat.Driver)
'                    Mechanic.FPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.FPV0)
'                End If
'            ElseIf GetPlayerName() = "Trevor" Then
'                If Mechanic.TPV0 = Nothing Then
'                    Mechanic.TPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.TPV0.IsPersistent = True
'                    Mechanic.TPV0.AddBlip()
'                    Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.TPV0.CurrentBlip.Color = BlipColor2.Trevor
'                    Mechanic.TPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.TPV0.CurrentBlip.Name = Mechanic.TPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.TPV0, VehicleSeat.Driver)
'                    Mechanic.TPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.TPV0)
'                Else
'                    Mechanic.TPV0.Delete()
'                    Mechanic.TPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.TPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.TPV0.IsPersistent = True
'                    Mechanic.TPV0.AddBlip()
'                    Mechanic.TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.TPV0.CurrentBlip.Color = BlipColor2.Trevor
'                    Mechanic.TPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.TPV0.CurrentBlip.Name = Mechanic.TPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.TPV0, VehicleSeat.Driver)
'                    Mechanic.TPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.TPV0)
'                End If
'            ElseIf GetPlayerName() = "Player3" Then
'                If Mechanic.PPV0 = Nothing Then
'                    Mechanic.PPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.PPV0.IsPersistent = True
'                    Mechanic.PPV0.AddBlip()
'                    Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
'                    Mechanic.PPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.PPV0.CurrentBlip.Name = Mechanic.PPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.PPV0, VehicleSeat.Driver)
'                    Mechanic.PPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.PPV0)
'                Else
'                    Mechanic.PPV0.Delete()
'                    Mechanic.PPV0 = CreateVehicle(ReadCfgValue("VehicleModel", CurrentPath & "vehicle_" & PPCV & ".cfg"), ReadCfgValue("VehicleHash", CurrentPath & "vehicle_" & PPCV & ".cfg"), lastLocationGarageOutVector, lastLocationGarageOutHeading)
'                    SetModKit(Mechanic.PPV0, CurrentPath & "vehicle_" & PPCV & ".cfg", True)
'                    Mechanic.PPV0.IsPersistent = True
'                    Mechanic.PPV0.AddBlip()
'                    Mechanic.PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
'                    Mechanic.PPV0.CurrentBlip.Color = BlipColor.Yellow
'                    Mechanic.PPV0.CurrentBlip.IsShortRange = True
'                    Mechanic.PPV0.CurrentBlip.Name = Mechanic.PPV0.FriendlyName
'                    SetIntoVehicle(playerPed, Mechanic.PPV0, VehicleSeat.Driver)
'                    Mechanic.PPersVeh = New PersonalVehicle(GetPlayerName(), CurrentPath & "vehicle_" & PPCV & ".cfg", Mechanic.PPV0)
'                End If
'            End If

'            Brain.TVOn = False
'            playerPed.CurrentVehicle.Repair()
'            playerPed.CurrentVehicle.Position = lastLocationGarageOutVector
'            playerPed.CurrentVehicle.Heading = lastLocationGarageOutHeading
'            Wait(500)
'            Game.FadeScreenIn(500)
'            
'        End If

'        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso Not playerPed.IsInVehicle AndAlso ElevatorDistance < 3.0 Then
'            ExitMenu.Visible = True
'        End If

'        If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso GarageMarkerDistance < 1.5 AndAlso Not Mechanic._menuPool.IsAnyMenuOpen Then
'            Mechanic.CreateGarageMenu(CurrentPath, True)
'            Mechanic.CreateGarageMenu2("Twenty")
'            Mechanic.GarageMenu.Visible = True
'            World.RenderingCamera = World.CreateCamera(New Vector3(-1396.66, -481.3375, 59.11948), New Vector3(-18.82641, 0, -73.41509), 50)
'        End If
'    End Sub

'    Public Shared Sub EnableOfficeProp()
'        EnableInteriotProp(Apartment.InteriorID, "office_chairs")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_01")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_02")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_03")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_04")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_05")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_06")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_07")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_08")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_09")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_10")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_11")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_12")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_13")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_14")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_15")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_16")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_17")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_18")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_19")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_20")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_21")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_22")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_23")
'        EnableInteriotProp(Apartment.InteriorID, "Cash_Set_24")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Silver")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Silver2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Silver3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Pills")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Pills2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Pills3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Med")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Med2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Med3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_JewelWatch")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_JewelWatch2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_JewelWatch3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Ivory")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Ivory2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Ivory3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Guns")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Guns2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Guns3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Gems")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Gems2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Gems3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Furcoats")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Furcoats2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Furcoats3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_electronic")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_electronic2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_electronic3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugStatue")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugStatue2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugStatue3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugBags")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugBags2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_DrugBags3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Counterfeit")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Counterfeit2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Counterfeit3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Booze_cigs")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Booze_cigs2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Booze_cigs3")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Art")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Art2")
'        EnableInteriotProp(Apartment.InteriorID, "Swag_Art3")
'        EnableInteriotProp(Apartment.InteriorID, "Office_Booze")
'        EnableInteriotProp(Apartment.InteriorID, "Gun_Locker")
'        EnableInteriotProp(Apartment.InteriorID, "Mod_Booth")
'    End Sub

'    Public Sub OnAborted() Handles MyBase.Aborted
'        Try
'            If Not veh0 = Nothing Then veh0.Delete()
'            If Not veh1 = Nothing Then veh1.Delete()
'            If Not veh2 = Nothing Then veh2.Delete()
'            If Not veh3 = Nothing Then veh3.Delete()
'            If Not veh4 = Nothing Then veh4.Delete()
'            If Not veh5 = Nothing Then veh5.Delete()
'            If Not veh6 = Nothing Then veh6.Delete()
'            If Not veh7 = Nothing Then veh7.Delete()
'            If Not veh8 = Nothing Then veh8.Delete()
'            If Not veh9 = Nothing Then veh9.Delete()
'            If Not veh10 = Nothing Then veh10.Delete()
'            If Not veh11 = Nothing Then veh11.Delete()
'            If Not veh12 = Nothing Then veh12.Delete()
'            If Not veh13 = Nothing Then veh13.Delete()
'            If Not veh14 = Nothing Then veh14.Delete()
'            If Not veh15 = Nothing Then veh15.Delete()
'            If Not veh16 = Nothing Then veh16.Delete()
'            If Not veh17 = Nothing Then veh17.Delete()
'            If Not veh18 = Nothing Then veh18.Delete()
'            If Not veh19 = Nothing Then veh19.Delete()
'        Catch ex As Exception
'        End Try
'    End Sub
'End Class
