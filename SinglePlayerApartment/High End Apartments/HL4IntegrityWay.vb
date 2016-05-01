'Imports System.Drawing
'Imports GTA
'Imports GTA.Native
'Imports GTA.Math
'Imports System.Windows.Forms
'Imports SinglePlayerApartment.SinglePlayerApartment
'Imports INMNativeUI
'Imports SinglePlayerApartment.Wardrobe
'Imports SinglePlayerApartment.INMNative

'Public Class HL4IntegrityWay
'    Inherits Script

'    Public Shared Apartment As Apartment
'    Public Shared ExitMenu As UIMenu
'    Public Shared _menuPool As MenuPool

'    Public Sub New()
'        Try
'            If ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then
'                Garage = ReadCfgValue("Garage", langFile)
'                AptOptions = ReadCfgValue("AptOptions", langFile)
'                ExitApt = ReadCfgValue("ExitApt", langFile)
'                SellApt = ReadCfgValue("SellApt", langFile)
'                EnterGarage = ReadCfgValue("EnterGarage", langFile)
'                GrgOptions = ReadCfgValue("GrgOptions", langFile)
'                ForSale = ReadCfgValue("ForSale", langFile)
'                PropPurchased = ReadCfgValue("PropPurchased", langFile)
'                Maze = ReadCfgValue("Maze", langFile)
'                Fleeca = ReadCfgValue("Fleeca", langFile)
'                BOL = ReadCfgValue("BOL", langFile)
'                InsFundApartment = ReadCfgValue("InsFundApartment", langFile)
'                EnterApartment = ReadCfgValue("EnterApartment", langFile)
'                SaveGame = ReadCfgValue("SaveGame", langFile)
'                ExitApartment = ReadCfgValue("ExitApartment", langFile)
'                ChangeClothes = ReadCfgValue("ChangeClothes", langFile)
'                _EnterGarage = ReadCfgValue("_EnterGarage", langFile)
'                CannotStore = ReadCfgValue("CannotStore", langFile)

'                AddHandler Tick, AddressOf OnTick

'                _menuPool = New MenuPool()
'                CreateExitMenu()
'                AddHandler ExitMenu.OnMenuClose, AddressOf MenuCloseHandler
'                AddHandler ExitMenu.OnItemSelect, AddressOf ItemSelectHandler
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Shared Sub CreateExitMenu()
'        Try
'            ExitMenu = New UIMenu("", AptOptions, New Point(0, -107))
'            Dim Rectangle = New UIResRectangle()
'            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
'            ExitMenu.SetBannerType(Rectangle)
'            _menuPool.Add(ExitMenu)
'            ExitMenu.AddItem(New UIMenuItem(ExitApt))
'            ExitMenu.AddItem(New UIMenuItem(EnterGarage))
'            ExitMenu.AddItem(New UIMenuItem(SellApt))
'            ExitMenu.RefreshIndex()
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub MenuCloseHandler(sender As UIMenu)
'        Try
'            hideHud = False
'            World.DestroyAllCameras()
'            World.RenderingCamera = Nothing
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
'        Try
'            If selectedItem.Text = ExitApt Then
'                'Exit Apt
'                ExitMenu.Visible = False
'                Game.FadeScreenOut(500)
'                Wait(&H3E8)
'                Game.Player.Character.Position = Apartment.TeleportOutside
'                Wait(500)
'                Game.FadeScreenIn(500)
'                UnLoadMPDLCMap()
'                _4IntegrityWay.Apartment.IsAtHome = False
'            ElseIf selectedItem.Text = SellApt Then
'                'Sell Apt
'                ExitMenu.Visible = False
'                WriteCfgValue("4IWHLowner", "None", saveFile)
'                SavePosition2()
'                Game.FadeScreenOut(500)
'                Wait(&H3E8)
'                SinglePlayerApartment.player.Money = (playerCash + Apartment.Cost)
'                Apartment.Owner = "None"
'                _4IntegrityWay.Apartment.AptBlip.Remove()
'                If Not _4IntegrityWay.Apartment.GrgBlip Is Nothing Then _4IntegrityWay.Apartment.GrgBlip.Remove()
'                _4IntegrityWay.Create4IntegrityWay()
'                Game.Player.Character.Position = Apartment.TeleportOutside
'                Wait(500)
'                Game.FadeScreenIn(500)
'                _4IntegrityWay.RefreshMenu()
'                _4IntegrityWay.RefreshGarageMenu()
'                UnLoadMPDLCMap()
'                _4IntegrityWay.Apartment.IsAtHome = False
'            ElseIf selectedItem.Text = EnterGarage Then
'                'Enter Garage
'                Game.FadeScreenOut(500)
'                Wait(&H3E8)
'                SetInteriorActive2(222.592, -968.1, -99) '10 car garage
'                playerPed.Position = TenCarGarage.Elevator
'                TenCarGarage.LastLocationName = Apartment.Name & Apartment.Unit
'                TenCarGarage.lastLocationVector = Apartment.ApartmentExit
'                TenCarGarage.lastLocationGarageVector = _4IntegrityWay.Apartment.GarageEntrance
'                TenCarGarage.lastLocationGarageOutVector = _4IntegrityWay.Apartment.GarageOutside
'                TenCarGarage.lastLocationGarageOutHeading = _4IntegrityWay.Apartment.GarageOutHeading
'                TenCarGarage.LoadGarageVechicles(Apartment.GaragePath)
'                TenCarGarage.CurrentPath = Apartment.GaragePath
'                ExitMenu.Visible = False
'                Wait(500)
'                Game.FadeScreenIn(500)
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub

'    Public Sub OnTick(o As Object, e As EventArgs)
'        Try
'            If My.Settings.FourIntegrityWay = "Enable" Then

'                'Save Game
'                If ((Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.SaveDistance < 3.0 Then
'                    DisplayHelpTextThisFrame(SaveGame)
'                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                        playerMap = "4IntegrityHL"
'                        Game.FadeScreenOut(500)
'                        Wait(&H3E8)
'                        TimeLapse(8)
'                        Game.ShowSaveMenu()
'                        SavePosition()
'                        Wait(500)
'                        Game.FadeScreenIn(500)
'                    End If
'                End If

'                'Exit Apartment
'                If ((Not ExitMenu.Visible AndAlso Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso Apartment.ExitDistance < 2.0 Then
'                    DisplayHelpTextThisFrame(ExitApartment & Apartment.Name & Apartment.Unit)
'                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                        ExitMenu.Visible = True
'                    End If
'                End If

'                'Wardrobe
'                If ((WardrobeScriptStatus = -1) AndAlso (Not playerPed.IsInVehicle AndAlso Not playerPed.IsDead) AndAlso Apartment.Owner = playerName) AndAlso WardrobeDistance < 1.0 Then
'                    DisplayHelpTextThisFrame(ChangeClothes)
'                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
'                        WardrobeVector = Apartment.Wardrobe
'                        WardrobeHead = Apartment.WardrobeHeading
'                        WardrobeScriptStatus = 0
'                        If playerName = "Michael" Then
'                            Player0W.Visible = True
'                            MakeACamera()
'                        ElseIf playerName = "Franklin" Then
'                            Player1W.Visible = True
'                            MakeACamera()
'                        ElseIf playerName = “Trevor"
'                            Player2W.Visible = True
'                            MakeACamera()
'                        ElseIf playerName = "Player3" Then
'                            If playerHash = "1885233650" Then
'                                Player3_MW.Visible = True
'                                MakeACamera()
'                            ElseIf playerHash = "-1667301416" Then
'                                Player3_FW.Visible = True
'                                MakeACamera()
'                            End If
'                        End If
'                    End If
'                End If

'                _menuPool.ProcessMenus()
'            End If
'        Catch ex As Exception
'            logger.Log(ex.Message & " " & ex.StackTrace)
'        End Try
'    End Sub
'End Class
