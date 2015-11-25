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
Imports SinglePlayerApartment.SinglePlayerApartment
Imports PDMCarShopGUI

Public Class Mechanic
    Inherits Script

    Public Shared Path As String
    Public Shared playerHash As String
    Public Shared GarageMenu, MechanicMenu, AS3Menu, IW4Menu, IW4HLMenu, DPHMenu, DPHHLMenu, DTMenu, ETMenu, ETHLMenu, RMMenu, RMHLMenu, TTMenu, TTHLMenu, WPMenu As UIMenu
    Public Shared _menuPool As MenuPool
    Public Shared AS3, IW4, IW4HL, DPH, DPHHL, DT, ET, ETHL, RM, RMHL, TT, TTHL, WP As String
    Public Shared MPV1, FPV1, TPV1 As Vehicle
    Public Shared itemAS3, itemIW4, itemIW4HL, itemDPH, itemDPHHL, itemDT, itemET, itemETHL, itemRM, itemRMHL, itemTT, itemTTHL, itemWP As UIMenuItem

    Public Sub New()
        Try
            uiLanguage = Game.Language.ToString
            If uiLanguage = "Chinese" Then
                Garage = "車庫"
                _Mechanic = "機械師"
                GrgOptions = "刪除車輛"
                ReturnVeh = "返回所有車輛"
            Else
                Garage = " Garage"
                _Mechanic = "Mechanic"
                GrgOptions = "REMOVE VEHICLE"
                ReturnVeh = "Return all Vehicles"
            End If

            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            Else
                playerName = "None"
            End If

            AS3 = ReadCfgValue("3ASowner", saveFile)
            IW4 = ReadCfgValue("4IWowner", saveFile)
            IW4HL = ReadCfgValue("4IWHLowner", saveFile)
            DPH = ReadCfgValue("DPHwoner", saveFile)
            DPHHL = ReadCfgValue("DPHHLowner", saveFile)
            DT = ReadCfgValue("SSowner", saveFile)
            ET = ReadCfgValue("ETowner", saveFile)
            ETHL = ReadCfgValue("ETHLowner", saveFile)
            RM = ReadCfgValue("RMowner", saveFile)
            RMHL = ReadCfgValue("RMHLowner", saveFile)
            TT = ReadCfgValue("TTowner", saveFile)
            TTHL = ReadCfgValue("TTHLowner", saveFile)
            WP = ReadCfgValue("WPowner", saveFile)

            itemAS3 = New UIMenuItem(_3AltaStreet._Name & _3AltaStreet.Unit)
            itemIW4 = New UIMenuItem(_4IntegrityWay._Name & _4IntegrityWay.Unit)
            itemIW4HL = New UIMenuItem(HL4IntegrityWay._Name & HL4IntegrityWay.Unit)
            itemDPH = New UIMenuItem(DelPerroHeight._Name & DelPerroHeight.Unit)
            itemDPHHL = New UIMenuItem(HLDelPerro._Name & HLDelPerro.Unit)
            itemDT = New UIMenuItem(DreamTower._Name & DreamTower.Unit)
            itemET = New UIMenuItem(EclipseTower._Name & EclipseTower.Unit)
            itemETHL = New UIMenuItem(HLEclipseTower._Name & HLEclipseTower.Unit)
            itemRM = New UIMenuItem(RichardMajestic._Name & RichardMajestic.Unit)
            itemRMHL = New UIMenuItem(HLRichardMajestic._Name & HLRichardMajestic.Unit)
            itemTT = New UIMenuItem(TinselTower._Name & TinselTower.Unit)
            itemTTHL = New UIMenuItem(HLTinselTower._Name & HLTinselTower.Unit)
            itemWP = New UIMenuItem(WeazelPlaza._Name & WeazelPlaza.Unit)

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            My.Settings.Mechanic = [Enum].Parse(GetType(Keys), ReadCfgValue("Mechanic", saveFile), False)
            My.Settings.Save()

            _menuPool = New MenuPool()
            'CreateGarageMenu("")
            CreateMechanicMenu()
            CreateVehMenuAlta()
            CreateVehMenuDream()
            CreateVehMenuEclipse()
            CreateVehMenuEclipseHL()
            CreateVehMenuIntegrity()
            CreateVehMenuIntegrityHL()
            CreateVehMenuPerro()
            CreateVehMenuPerroHL()
            CreateVehMenuRichard()
            CreateVehMenuRichardHL()
            CreateVehMenuTinsel()
            CreateVehMenuTinselHL()
            CreateVehMenuWeazel()

            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateMechanicMenu()
        Try
            Dim AltaPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\"
            Dim IntegrityPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\"
            Dim Integrity2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
            Dim PerroPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\"
            Dim Perro2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
            Dim DreamPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\"
            Dim EclipsePathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
            Dim Eclipse2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
            Dim RichardPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\"
            Dim Richard2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\"
            Dim TinselPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
            Dim Tinsel2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
            Dim WeazelPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\"

            Dim Alta As Integer = IO.Directory.GetFiles(AltaPathDir, "*.cfg").Count
            Dim Integrity As Integer = IO.Directory.GetFiles(IntegrityPathDir, "*.cfg").Count
            Dim Integrity2 As Integer = IO.Directory.GetFiles(Integrity2PathDir, "*.cfg").Count
            Dim Perro As Integer = IO.Directory.GetFiles(PerroPathDir, "*.cfg").Count
            Dim Perro2 As Integer = IO.Directory.GetFiles(Perro2PathDir, "*.cfg").Count
            Dim Dream As Integer = IO.Directory.GetFiles(DreamPathDir, "*.cfg").Count
            Dim Eclipse As Integer = IO.Directory.GetFiles(EclipsePathDir, "*.cfg").Count
            Dim Eclipse2 As Integer = IO.Directory.GetFiles(Eclipse2PathDir, "*.cfg").Count
            Dim Richard As Integer = IO.Directory.GetFiles(RichardPathDir, "*.cfg").Count
            Dim Richard2 As Integer = IO.Directory.GetFiles(Richard2PathDir, "*.cfg").Count
            Dim Tinsel As Integer = IO.Directory.GetFiles(TinselPathDir, "*.cfg").Count
            Dim Tinsel2 As Integer = IO.Directory.GetFiles(Tinsel2PathDir, "*.cfg").Count
            Dim Weazel As Integer = IO.Directory.GetFiles(WeazelPathDir, "*.cfg").Count

            MechanicMenu = New UIMenu("", ChooseApt, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MechanicMenu.SetBannerType(Rectangle)
            _menuPool.Add(MechanicMenu)
            MechanicMenu.MenuItems.Clear()
            If AS3 = playerName AndAlso Not Alta = 0 Then MechanicMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 0 Then MechanicMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 0 Then MechanicMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 0 Then MechanicMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 0 Then MechanicMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 0 Then MechanicMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 0 Then MechanicMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 0 Then MechanicMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 0 Then MechanicMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 0 Then MechanicMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 0 Then MechanicMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 0 Then MechanicMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 0 Then MechanicMenu.AddItem(itemWP)
            MechanicMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuAlta()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\"
            AS3Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            AS3Menu.SetBannerType(Rectangle)
            _menuPool.Add(AS3Menu)
            AS3Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                AS3Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                AS3Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                AS3Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                AS3Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                AS3Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                AS3Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                AS3Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                AS3Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                AS3Menu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                AS3Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            AS3Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            AS3Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(AS3Menu, itemAS3)
            AddHandler AS3Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuIntegrity()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\"
            IW4Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            IW4Menu.SetBannerType(Rectangle)
            _menuPool.Add(IW4Menu)
            IW4Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                IW4Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                IW4Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                IW4Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                IW4Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                IW4Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                IW4Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                IW4Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                IW4Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                IW4Menu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                IW4Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            IW4Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            IW4Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(IW4Menu, itemIW4)
            AddHandler IW4Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuIntegrityHL()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
            IW4HLMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            IW4HLMenu.SetBannerType(Rectangle)
            _menuPool.Add(IW4HLMenu)
            IW4HLMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                IW4HLMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                IW4HLMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                IW4HLMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                IW4HLMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                IW4HLMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                IW4HLMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                IW4HLMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                IW4HLMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                IW4HLMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                IW4HLMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            IW4HLMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            IW4HLMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(IW4HLMenu, itemIW4HL)
            AddHandler IW4HLMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuPerro()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\"
            DPHMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            DPHMenu.SetBannerType(Rectangle)
            _menuPool.Add(DPHMenu)
            DPHMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                DPHMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                DPHMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                DPHMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                DPHMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                DPHMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                DPHMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                DPHMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                DPHMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                DPHMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                DPHMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            DPHMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            DPHMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(DPHMenu, itemDPH)
            AddHandler DPHMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuPerroHL()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
            DPHHLMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            DPHHLMenu.SetBannerType(Rectangle)
            _menuPool.Add(DPHHLMenu)
            DPHHLMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                DPHHLMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                DPHHLMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                DPHHLMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                DPHHLMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                DPHHLMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                DPHHLMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                DPHHLMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                DPHHLMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                DPHHLMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                DPHHLMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            DPHHLMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            DPHHLMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(DPHHLMenu, itemDPHHL)
            AddHandler DPHHLMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuDream()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\"
            DTMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            DTMenu.SetBannerType(Rectangle)
            _menuPool.Add(DTMenu)
            DTMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                DTMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                DTMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                DTMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                DTMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                DTMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                DTMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                DTMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                DTMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                DTMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                DTMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            DTMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            DTMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(DTMenu, itemDT)
            AddHandler DTMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuEclipse()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
            ETMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ETMenu.SetBannerType(Rectangle)
            _menuPool.Add(ETMenu)
            ETMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                ETMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                ETMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                ETMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                ETMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                ETMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                ETMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                ETMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                ETMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                ETMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                ETMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            ETMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            ETMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(ETMenu, itemET)
            AddHandler ETMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuEclipseHL()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
            ETHLMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ETHLMenu.SetBannerType(Rectangle)
            _menuPool.Add(ETHLMenu)
            ETHLMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                ETHLMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                ETHLMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                ETHLMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                ETHLMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                ETHLMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                ETHLMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                ETHLMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                ETHLMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                ETHLMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                ETHLMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            ETHLMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            ETHLMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(ETHLMenu, itemETHL)
            AddHandler ETHLMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuRichard()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\"
            RMMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            RMMenu.SetBannerType(Rectangle)
            _menuPool.Add(RMMenu)
            RMMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                RMMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                RMMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                RMMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                RMMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                RMMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                RMMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                RMMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                RMMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                RMMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                RMMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            RMMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            RMMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(RMMenu, itemRM)
            AddHandler RMMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuRichardHL()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\"
            RMHLMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            RMHLMenu.SetBannerType(Rectangle)
            _menuPool.Add(RMHLMenu)
            RMHLMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                RMHLMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                RMHLMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                RMHLMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                RMHLMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                RMHLMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                RMHLMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                RMHLMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                RMHLMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                RMHLMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                RMHLMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            RMHLMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            RMHLMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(RMHLMenu, itemRMHL)
            AddHandler RMHLMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuTinsel()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
            TTMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            TTMenu.SetBannerType(Rectangle)
            _menuPool.Add(TTMenu)
            TTMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                TTMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                TTMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                TTMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                TTMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                TTMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                TTMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                TTMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                TTMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                TTMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                TTMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            TTMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            TTMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(TTMenu, itemTT)
            AddHandler TTMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuTinselHL()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
            TTHLMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            TTHLMenu.SetBannerType(Rectangle)
            _menuPool.Add(TTHLMenu)
            TTHLMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                TTHLMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                TTHLMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                TTHLMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                TTHLMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                TTHLMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                TTHLMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                TTHLMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                TTHLMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                TTHLMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                TTHLMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            TTHLMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            TTHLMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(TTHLMenu, itemTTHL)
            AddHandler TTHLMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehMenuWeazel()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\"
            WPMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            WPMenu.SetBannerType(Rectangle)
            _menuPool.Add(WPMenu)
            WPMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")")
                WPMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")")
                WPMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")")
                WPMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")")
                WPMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")")
                WPMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")")
                WPMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")")
                WPMenu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")")
                WPMenu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")")
                WPMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")")
                WPMenu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            WPMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            WPMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(WPMenu, itemWP)
            AddHandler WPMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu(file As String)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")")
                GarageMenu.AddItem(item(0))
                With item(0)
                    .Car = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(0))
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")")
                GarageMenu.AddItem(item(1))
                With item(1)
                    .Car = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(1))
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")")
                GarageMenu.AddItem(item(2))
                With item(2)
                    .Car = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(2))
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")")
                GarageMenu.AddItem(item(3))
                With item(3)
                    .Car = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(3))
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")")
                GarageMenu.AddItem(item(4))
                With item(4)
                    .Car = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(4))
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")")
                GarageMenu.AddItem(item(5))
                With item(5)
                    .Car = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(5))
            End If
            If IO.File.Exists(file & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")")
                GarageMenu.AddItem(item(6))
                With item(6)
                    .Car = "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(6) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(6))
            End If
            If IO.File.Exists(file & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")")
                GarageMenu.AddItem(item(7))
                With item(7)
                    .Car = "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(7) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(7))
            End If
            If IO.File.Exists(file & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")")
                GarageMenu.AddItem(item(8))
                With item(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(8) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(8))
            End If
            If IO.File.Exists(file & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")")
                GarageMenu.AddItem(item(9))
                With item(9)
                    .Car = "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                item(9) = New UIMenuItem("Empty")
                GarageMenu.AddItem(item(9))
            End If
            GarageMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CategoryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ReturnVeh Then
                Dim PathDir As String = selectedItem.Car
                If IO.File.Exists(PathDir & "vehicle_0.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_0.cfg")
                If IO.File.Exists(PathDir & "vehicle_1.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_1.cfg")
                If IO.File.Exists(PathDir & "vehicle_2.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_2.cfg")
                If IO.File.Exists(PathDir & "vehicle_3.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_3.cfg")
                If IO.File.Exists(PathDir & "vehicle_4.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_4.cfg")
                If IO.File.Exists(PathDir & "vehicle_5.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_5.cfg")
                If IO.File.Exists(PathDir & "vehicle_6.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_6.cfg")
                If IO.File.Exists(PathDir & "vehicle_7.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_7.cfg")
                If IO.File.Exists(PathDir & "vehicle_8.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_8.cfg")

                If Not MPV1 = Nothing Then MPV1.Delete()
                If Not FPV1 = Nothing Then FPV1.Delete()
                If Not TPV1 = Nothing Then TPV1.Delete()
            ElseIf selectedItem.LeftBadge = UIMenuItem.BadgeStyle.Car Then
                'Nothing
            Else
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", selectedItem.Car)
                Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", selectedItem.Car)
                Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", selectedItem.Car)
                Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", selectedItem.Car)
                Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", selectedItem.Car)
                Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", selectedItem.Car)
                Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", selectedItem.Car)
                Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", selectedItem.Car)
                Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", selectedItem.Car)
                Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", selectedItem.Car)
                Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", selectedItem.Car)
                Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", selectedItem.Car)
                Dim RimColor As String = ReadCfgValue("RimColor", selectedItem.Car)
                Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", selectedItem.Car)
                Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", selectedItem.Car)
                Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", selectedItem.Car)
                Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", selectedItem.Car)
                Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", selectedItem.Car)
                Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", selectedItem.Car)
                Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", selectedItem.Car)
                Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", selectedItem.Car)
                Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", selectedItem.Car)
                Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", selectedItem.Car)
                Dim WheelType As String = ReadCfgValue("WheelType", selectedItem.Car)
                Dim Livery As String = ReadCfgValue("Livery", selectedItem.Car)
                Dim PlateType As String = ReadCfgValue("PlateType", selectedItem.Car)
                Dim PlateNumber As String = ReadCfgValue("PlateNumber", selectedItem.Car)
                Dim WindowTint As String = ReadCfgValue("WindowTint", selectedItem.Car)
                Dim Spoiler As String = ReadCfgValue("Spoiler", selectedItem.Car)
                Dim FrontBumper As String = ReadCfgValue("FrontBumper", selectedItem.Car)
                Dim RearBumper As String = ReadCfgValue("RearBumper", selectedItem.Car)
                Dim SideSkirt As String = ReadCfgValue("SideSkirt", selectedItem.Car)
                Dim Frame As String = ReadCfgValue("Frame", selectedItem.Car)
                Dim Grille As String = ReadCfgValue("Grille", selectedItem.Car)
                Dim Hood As String = ReadCfgValue("Hood", selectedItem.Car)
                Dim Fender As String = ReadCfgValue("Fender", selectedItem.Car)
                Dim RightFender As String = ReadCfgValue("RightFender", selectedItem.Car)
                Dim Roof As String = ReadCfgValue("Roof", selectedItem.Car)
                Dim Exhaust As String = ReadCfgValue("Exhaust", selectedItem.Car)
                Dim FrontWheels As String = ReadCfgValue("FrontWheels", selectedItem.Car)
                Dim BackWheels As String = ReadCfgValue("BackWheels", selectedItem.Car)
                Dim Suspension As String = ReadCfgValue("Suspension", selectedItem.Car)
                Dim Engine As String = ReadCfgValue("Engine", selectedItem.Car)
                Dim Brakes As String = ReadCfgValue("Brakes", selectedItem.Car)
                Dim Transmission As String = ReadCfgValue("Transmission", selectedItem.Car)
                Dim Armor As String = ReadCfgValue("Armor", selectedItem.Car)
                Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", selectedItem.Car)
                Dim Turbo As String = ReadCfgValue("Turbo", selectedItem.Car)
                Dim Horn As String = ReadCfgValue("Horn", selectedItem.Car)
                Dim BulletproofTyres As String = ReadCfgValue("BulletproofTyres", selectedItem.Car)
                Dim Active As String = ReadCfgValue("Active", selectedItem.Car)
                'Dim PlateHolder As String = ReadCfgValue("PlateHolder", selectedItem.Car)
                'Dim Unknown1 As String = ReadCfgValue("Unknown1", selectedItem.Car)
                'Dim TrimDesign As String = ReadCfgValue("TrimDesign", selectedItem.Car)
                'Dim Ornaments As String = ReadCfgValue("Ornaments", selectedItem.Car)
                'Dim Unknown2 As String = ReadCfgValue("Unknown2", selectedItem.Car)
                'Dim DialDesign As String = ReadCfgValue("DialDesign", selectedItem.Car)
                'Dim Unknown3 As String = ReadCfgValue("Unknown3", selectedItem.Car)
                'Dim Unknown4 As String = ReadCfgValue("Unknown4", selectedItem.Car)
                'Dim Steering As String = ReadCfgValue("Steering", selectedItem.Car)
                'Dim Shifter As String = ReadCfgValue("Shifter", selectedItem.Car)
                'Dim Plaques As String = ReadCfgValue("Plaques", selectedItem.Car)
                'Dim Unknown5 As String = ReadCfgValue("Unknown5", selectedItem.Car)
                'Dim Unknown6 As String = ReadCfgValue("Unknown6", selectedItem.Car)
                'Dim Hydraulics As String = ReadCfgValue("Hydraulics", selectedItem.Car)
                'Dim Unknown7 As String = ReadCfgValue("Unknown7", selectedItem.Car)
                'Dim Unknown8 As String = ReadCfgValue("Unknown8", selectedItem.Car)
                'Dim Unknown9 As String = ReadCfgValue("Unknown9", selectedItem.Car)
                'Dim Unknown10 As String = ReadCfgValue("UnknownA", selectedItem.Car)
                'Dim Unknown11 As String = ReadCfgValue("UnknownB", selectedItem.Car)
                'Dim Unknown12 As String = ReadCfgValue("UnknownC", selectedItem.Car)
                'Dim Unknown13 As String = ReadCfgValue("UnknownD", selectedItem.Car)
                'Dim Unknown14 As String = ReadCfgValue("UnknownE", selectedItem.Car)
                'Dim Unknown15 As String = ReadCfgValue("UnknownF", selectedItem.Car)
                'Dim Unknown16 As String = ReadCfgValue("UnknownG", selectedItem.Car)
                'Dim Unknown17 As String = ReadCfgValue("UnknownH", selectedItem.Car)

                If playerName = "Michael" AndAlso Active = "False" Then
                    If MPV1 = Nothing Then
                        MPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        MPV1.AddBlip()
                        MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        MPV1.CurrentBlip.Color = BlipColor.Blue
                        SetBlipName(MPV1.FriendlyName, MPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                    Else
                        MPV1.CurrentBlip.Remove()
                        MPV1.Delete()
                        MPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        MPV1.AddBlip()
                        MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        MPV1.CurrentBlip.Color = BlipColor.Blue
                        SetBlipName(MPV1.FriendlyName, MPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                    End If
                    Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, MPV1, 0)
                    MPV1.DirtLevel = 0F
                    MPV1.PrimaryColor = PrimaryColor
                    MPV1.SecondaryColor = SecondaryColor
                    MPV1.PearlescentColor = PearlescentColor
                    If HasCustomPriColor = "True" Then MPV1.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
                    If HasCustomSecColor = "True" Then MPV1.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
                    MPV1.RimColor = RimColor
                    If HasNeonLightBack = "True" Then MPV1.SetNeonLightsOn(VehicleNeonLight.Back, True)
                    If HasNeonLightFront = "True" Then MPV1.SetNeonLightsOn(VehicleNeonLight.Front, True)
                    If HasNeonLightLeft = "True" Then MPV1.SetNeonLightsOn(VehicleNeonLight.Left, True)
                    If HasNeonLightRight = "True" Then MPV1.SetNeonLightsOn(VehicleNeonLight.Right, True)
                    MPV1.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
                    MPV1.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
                    MPV1.WheelType = WheelType
                    MPV1.Livery = Livery
                    Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, MPV1, PlateType)
                    MPV1.NumberPlate = PlateNumber
                    MPV1.WindowTint = WindowTint
                    MPV1.SetMod(VehicleMod.Spoilers, Spoiler, True)
                    MPV1.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
                    MPV1.SetMod(VehicleMod.RearBumper, RearBumper, True)
                    MPV1.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
                    MPV1.SetMod(VehicleMod.Frame, Frame, True)
                    MPV1.SetMod(VehicleMod.Grille, Grille, True)
                    MPV1.SetMod(VehicleMod.Hood, Hood, True)
                    MPV1.SetMod(VehicleMod.Fender, Fender, True)
                    MPV1.SetMod(VehicleMod.RightFender, RightFender, True)
                    MPV1.SetMod(VehicleMod.Roof, Roof, True)
                    MPV1.SetMod(VehicleMod.Exhaust, Exhaust, True)
                    MPV1.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
                    MPV1.SetMod(VehicleMod.BackWheels, BackWheels, True)
                    MPV1.SetMod(VehicleMod.Suspension, Suspension, True)
                    MPV1.SetMod(VehicleMod.Engine, Engine, True)
                    MPV1.SetMod(VehicleMod.Brakes, Brakes, True)
                    MPV1.SetMod(VehicleMod.Transmission, Transmission, True)
                    MPV1.SetMod(VehicleMod.Armor, Armor, True)
                    If XenonHeadlights = "True" Then MPV1.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
                    If Turbo = "True" Then MPV1.ToggleMod(VehicleToggleMod.Turbo, True)
                    MPV1.SetMod(VehicleMod.Horns, Horn, True)
                    If BulletproofTyres = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, MPV1, False)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, MPV1, 0)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 25, PlateHolder, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 26, Unknown1, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 27, TrimDesign, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 28, Ornaments, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 29, Unknown2, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 30, DialDesign, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 31, Unknown3, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 32, Unknown4, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 33, Steering, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 34, Shifter, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 35, Plaques, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 36, Unknown5, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 37, Unknown6, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 38, Hydraulics, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 39, Unknown7, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 40, Unknown8, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 19, Unknown9, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 20, Unknown10, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 21, Unknown11, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 22, Unknown12, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 50, Unknown13, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 51, Unknown14, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 52, Unknown15, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 48, Unknown16, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, MPV1, 53, Unknown17, True)
                    MPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV1, True, True)
                ElseIf playerName = "Franklin" AndAlso Active = "False" Then
                    If FPV1 = Nothing Then
                        FPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        FPV1.AddBlip()
                        FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        FPV1.CurrentBlip.Color = BlipColor.Green
                        SetBlipName(FPV1.FriendlyName, FPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                    Else
                        FPV1.CurrentBlip.Remove()
                        FPV1.Delete()
                        FPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        FPV1.AddBlip()
                        FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        FPV1.CurrentBlip.Color = BlipColor.Green
                        SetBlipName(FPV1.FriendlyName, FPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                    End If
                    Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, FPV1, 0)
                    FPV1.DirtLevel = 0F
                    FPV1.PrimaryColor = PrimaryColor
                    FPV1.SecondaryColor = SecondaryColor
                    FPV1.PearlescentColor = PearlescentColor
                    If HasCustomPriColor = "True" Then FPV1.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
                    If HasCustomSecColor = "True" Then FPV1.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
                    FPV1.RimColor = RimColor
                    If HasNeonLightBack = "True" Then FPV1.SetNeonLightsOn(VehicleNeonLight.Back, True)
                    If HasNeonLightFront = "True" Then FPV1.SetNeonLightsOn(VehicleNeonLight.Front, True)
                    If HasNeonLightLeft = "True" Then FPV1.SetNeonLightsOn(VehicleNeonLight.Left, True)
                    If HasNeonLightRight = "True" Then FPV1.SetNeonLightsOn(VehicleNeonLight.Right, True)
                    FPV1.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
                    FPV1.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
                    FPV1.WheelType = WheelType
                    FPV1.Livery = Livery
                    Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, FPV1, PlateType)
                    FPV1.NumberPlate = PlateNumber
                    FPV1.WindowTint = WindowTint
                    FPV1.SetMod(VehicleMod.Spoilers, Spoiler, True)
                    FPV1.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
                    FPV1.SetMod(VehicleMod.RearBumper, RearBumper, True)
                    FPV1.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
                    FPV1.SetMod(VehicleMod.Frame, Frame, True)
                    FPV1.SetMod(VehicleMod.Grille, Grille, True)
                    FPV1.SetMod(VehicleMod.Hood, Hood, True)
                    FPV1.SetMod(VehicleMod.Fender, Fender, True)
                    FPV1.SetMod(VehicleMod.RightFender, RightFender, True)
                    FPV1.SetMod(VehicleMod.Roof, Roof, True)
                    FPV1.SetMod(VehicleMod.Exhaust, Exhaust, True)
                    FPV1.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
                    FPV1.SetMod(VehicleMod.BackWheels, BackWheels, True)
                    FPV1.SetMod(VehicleMod.Suspension, Suspension, True)
                    FPV1.SetMod(VehicleMod.Engine, Engine, True)
                    FPV1.SetMod(VehicleMod.Brakes, Brakes, True)
                    FPV1.SetMod(VehicleMod.Transmission, Transmission, True)
                    FPV1.SetMod(VehicleMod.Armor, Armor, True)
                    If XenonHeadlights = "True" Then FPV1.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
                    If Turbo = "True" Then FPV1.ToggleMod(VehicleToggleMod.Turbo, True)
                    FPV1.SetMod(VehicleMod.Horns, Horn, True)
                    If BulletproofTyres = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, FPV1, False)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, FPV1, 0)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 25, PlateHolder, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 26, Unknown1, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 27, TrimDesign, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 28, Ornaments, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 29, Unknown2, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 30, DialDesign, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 31, Unknown3, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 32, Unknown4, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 33, Steering, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 34, Shifter, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 35, Plaques, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 36, Unknown5, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 37, Unknown6, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 38, Hydraulics, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 39, Unknown7, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 40, Unknown8, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 19, Unknown9, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 20, Unknown10, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 21, Unknown11, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 22, Unknown12, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 50, Unknown13, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 51, Unknown14, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 52, Unknown15, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 48, Unknown16, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, FPV1, 53, Unknown17, True)
                    FPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV1, True, True)
                ElseIf playerName = “Trevor" AndAlso Active = "False" Then
                    If TPV1 = Nothing Then
                        TPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        TPV1.AddBlip()
                        TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        TPV1.CurrentBlip.Color = 17
                        SetBlipName(TPV1.FriendlyName, TPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                    Else
                        TPV1.CurrentBlip.Remove()
                        TPV1.Delete()
                        TPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        TPV1.AddBlip()
                        TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        TPV1.CurrentBlip.Color = 17
                        SetBlipName(TPV1.FriendlyName, TPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                    End If
                    Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, TPV1, 0)
                    TPV1.DirtLevel = 0F
                    TPV1.PrimaryColor = PrimaryColor
                    TPV1.SecondaryColor = SecondaryColor
                    TPV1.PearlescentColor = PearlescentColor
                    If HasCustomPriColor = "True" Then TPV1.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
                    If HasCustomSecColor = "True" Then TPV1.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
                    TPV1.RimColor = RimColor
                    If HasNeonLightBack = "True" Then TPV1.SetNeonLightsOn(VehicleNeonLight.Back, True)
                    If HasNeonLightFront = "True" Then TPV1.SetNeonLightsOn(VehicleNeonLight.Front, True)
                    If HasNeonLightLeft = "True" Then TPV1.SetNeonLightsOn(VehicleNeonLight.Left, True)
                    If HasNeonLightRight = "True" Then TPV1.SetNeonLightsOn(VehicleNeonLight.Right, True)
                    TPV1.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
                    TPV1.TireSmokeColor = Color.FromArgb(TyreSmokeColorRed, TyreSmokeColorGreen, TyreSmokeColorBlue)
                    TPV1.WheelType = WheelType
                    TPV1.Livery = Livery
                    Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, TPV1, PlateType)
                    TPV1.NumberPlate = PlateNumber
                    TPV1.WindowTint = WindowTint
                    TPV1.SetMod(VehicleMod.Spoilers, Spoiler, True)
                    TPV1.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
                    TPV1.SetMod(VehicleMod.RearBumper, RearBumper, True)
                    TPV1.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
                    TPV1.SetMod(VehicleMod.Frame, Frame, True)
                    TPV1.SetMod(VehicleMod.Grille, Grille, True)
                    TPV1.SetMod(VehicleMod.Hood, Hood, True)
                    TPV1.SetMod(VehicleMod.Fender, Fender, True)
                    TPV1.SetMod(VehicleMod.RightFender, RightFender, True)
                    TPV1.SetMod(VehicleMod.Roof, Roof, True)
                    TPV1.SetMod(VehicleMod.Exhaust, Exhaust, True)
                    TPV1.SetMod(VehicleMod.FrontWheels, FrontWheels, True)
                    TPV1.SetMod(VehicleMod.BackWheels, BackWheels, True)
                    TPV1.SetMod(VehicleMod.Suspension, Suspension, True)
                    TPV1.SetMod(VehicleMod.Engine, Engine, True)
                    TPV1.SetMod(VehicleMod.Brakes, Brakes, True)
                    TPV1.SetMod(VehicleMod.Transmission, Transmission, True)
                    TPV1.SetMod(VehicleMod.Armor, Armor, True)
                    If XenonHeadlights = "True" Then TPV1.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
                    If Turbo = "True" Then TPV1.ToggleMod(VehicleToggleMod.Turbo, True)
                    TPV1.SetMod(VehicleMod.Horns, Horn, True)
                    If BulletproofTyres = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, TPV1, False)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, TPV1, 0)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 25, PlateHolder, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 26, Unknown1, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 27, TrimDesign, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 28, Ornaments, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 29, Unknown2, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 30, DialDesign, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 31, Unknown3, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 32, Unknown4, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 33, Steering, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 34, Shifter, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 35, Plaques, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 36, Unknown5, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 37, Unknown6, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 38, Hydraulics, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 39, Unknown7, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 40, Unknown8, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 19, Unknown9, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 20, Unknown10, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 21, Unknown11, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 22, Unknown12, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 50, Unknown13, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 51, Unknown14, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 52, Unknown15, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 48, Unknown16, True)
                    'Native.Function.Call(Hash.SET_VEHICLE_MOD, TPV1, 53, Unknown17, True)
                    TPV1.MarkAsNoLongerNeeded()
                    Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV1, True, True)
                End If
            End If
            sender.Visible = False
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If Not selectedItem.Text = "Empty" Then
                IO.File.Delete(Path & selectedItem.Car)
                selectedItem.Text = "Empty"
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If playerPed.IsInVehicle Then
                If Not playerPed.CurrentVehicle.CurrentBlip Is Nothing Then playerPed.CurrentVehicle.CurrentBlip.Remove()
            End If

            _menuPool.ProcessMenus()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        If e.KeyCode = My.Settings.Mechanic Then
            AS3 = ReadCfgValue("3ASowner", saveFile)
            IW4 = ReadCfgValue("4IWowner", saveFile)
            IW4HL = ReadCfgValue("4IWHLowner", saveFile)
            DPH = ReadCfgValue("DPHwoner", saveFile)
            DPHHL = ReadCfgValue("DPHHLowner", saveFile)
            DT = ReadCfgValue("SSowner", saveFile)
            ET = ReadCfgValue("ETowner", saveFile)
            ETHL = ReadCfgValue("ETHLowner", saveFile)
            RM = ReadCfgValue("RMowner", saveFile)
            RMHL = ReadCfgValue("RMHLowner", saveFile)
            TT = ReadCfgValue("TTowner", saveFile)
            TTHL = ReadCfgValue("TTHLowner", saveFile)
            WP = ReadCfgValue("WPowner", saveFile)

            itemAS3 = New UIMenuItem(_3AltaStreet._Name & _3AltaStreet.Unit)
            itemIW4 = New UIMenuItem(_4IntegrityWay._Name & _4IntegrityWay.Unit)
            itemIW4HL = New UIMenuItem(HL4IntegrityWay._Name & HL4IntegrityWay.Unit)
            itemDPH = New UIMenuItem(DelPerroHeight._Name & DelPerroHeight.Unit)
            itemDPHHL = New UIMenuItem(HLDelPerro._Name & HLDelPerro.Unit)
            itemDT = New UIMenuItem(DreamTower._Name & DreamTower.Unit)
            itemET = New UIMenuItem(EclipseTower._Name & EclipseTower.Unit)
            itemETHL = New UIMenuItem(HLEclipseTower._Name & HLEclipseTower.Unit)
            itemRM = New UIMenuItem(RichardMajestic._Name & RichardMajestic.Unit)
            itemRMHL = New UIMenuItem(HLRichardMajestic._Name & HLRichardMajestic.Unit)
            itemTT = New UIMenuItem(TinselTower._Name & TinselTower.Unit)
            itemTTHL = New UIMenuItem(HLTinselTower._Name & HLTinselTower.Unit)
            itemWP = New UIMenuItem(WeazelPlaza._Name & WeazelPlaza.Unit)

            CreateMechanicMenu()
            CreateVehMenuAlta()
            CreateVehMenuDream()
            CreateVehMenuEclipse()
            CreateVehMenuEclipseHL()
            CreateVehMenuIntegrity()
            CreateVehMenuIntegrityHL()
            CreateVehMenuPerro()
            CreateVehMenuPerroHL()
            CreateVehMenuRichard()
            CreateVehMenuRichardHL()
            CreateVehMenuTinsel()
            CreateVehMenuTinselHL()
            CreateVehMenuWeazel()
            MechanicMenu.Visible = Not MechanicMenu.Visible
        End If
    End Sub
End Class
