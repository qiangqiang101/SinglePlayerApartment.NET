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
    Public Shared GarageMenu, MechanicMenu, AS3Menu, IW4Menu, IW4HLMenu, DPHMenu, DPHHLMenu, DTMenu, ETMenu, ETHLMenu, RMMenu, RMHLMenu, TTMenu, TTHLMenu, WPMenu, VBMenu As UIMenu
    Public Shared NC2044Menu, HA2862Menu, HA2868Menu, WO3655Menu, NC2045Menu, MR2117Menu, HA2874Menu, WD3677Menu, MW2113Menu, ETP1Menu, ETP2Menu, ETP3Menu As UIMenu
    Public Shared _menuPool As MenuPool
    Public Shared AS3, IW4, IW4HL, DPH, DPHHL, DT, ET, ETHL, RM, RMHL, TT, TTHL, WP, VB As String
    Public Shared NC2044, HA2862, HA2868, WO3655, NC2045, MR2117, HA2874, WD3677, MW2113, ETP1, ETP2, ETP3 As String
    Public Shared MPV0, MPV1, MPV2, MPV3, MPV4, MPV5, MPV6, MPV7, MPV8, MPV9 As Vehicle
    Public Shared FPV0, FPV1, FPV2, FPV3, FPV4, FPV5, FPV6, FPV7, FPV8, FPV9 As Vehicle
    Public Shared TPV0, TPV1, TPV2, TPV3, TPV4, TPV5, TPV6, TPV7, TPV8, TPV9 As Vehicle
    Public Shared itemAS3, itemIW4, itemIW4HL, itemDPH, itemDPHHL, itemDT, itemET, itemETHL, itemRM, itemRMHL, itemTT, itemTTHL, itemWP, itemVB As UIMenuItem
    Public Shared itemNC2044, itemHA2862, itemHA2868, itemWO3655, itemNC2045, itemMR2117, itemHA2874, itemWD3677, itemMW2113, itemETP1, itemETP2, itemETP3 As UIMenuItem

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
            VB = ReadCfgValue("VPBowner", saveFile2)
            NC2044 = ReadCfgValue("2044NCowner", saveFile2)
            HA2862 = ReadCfgValue("2862HAowner", saveFile2)
            HA2868 = ReadCfgValue("2868HAowner", saveFile2)
            WO3655 = ReadCfgValue("3655WODowner", saveFile2)
            NC2045 = ReadCfgValue("2045NCowner", saveFile2)
            MR2117 = ReadCfgValue("2117MRowner", saveFile2)
            HA2874 = ReadCfgValue("2874HAowner", saveFile2)
            WD3677 = ReadCfgValue("3677WDowner", saveFile2)
            MW2113 = ReadCfgValue("2113MWowner", saveFile2)
            ETP1 = ReadCfgValue("ETP1owner", saveFile2)
            ETP2 = ReadCfgValue("ETP2owner", saveFile2)
            ETP3 = ReadCfgValue("ETP3owner", saveFile2)

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
            itemVB = New UIMenuItem(VespucciBlvd._Name & VespucciBlvd.Unit)
            itemNC2044 = New UIMenuItem(NorthConker2044._Name & NorthConker2044.Unit)
            itemHA2862 = New UIMenuItem(HillcrestAve2862._Name & HillcrestAve2862.Unit)
            itemHA2868 = New UIMenuItem(HillcrestAve2868._Name & HillcrestAve2868.Unit)
            itemWO3655 = New UIMenuItem(WildOats3655._Name & WildOats3655.Unit)
            itemNC2045 = New UIMenuItem(NorthConker2045._Name & NorthConker2045.Unit)
            itemMR2117 = New UIMenuItem(MiltonRd2117._Name & MiltonRd2117.Unit)
            itemHA2874 = New UIMenuItem(HillcrestAve2874._Name & HillcrestAve2874.Unit)
            itemWD3677 = New UIMenuItem(Whispymound3677._Name & Whispymound3677.Unit)
            itemMW2113 = New UIMenuItem(MadWayne2113._Name & MadWayne2113.Unit)
            itemETP1 = New UIMenuItem(EclipseTowerPS1._Name & EclipseTowerPS1.Unit)
            itemETP2 = New UIMenuItem(EclipseTowerPS2._Name & EclipseTowerPS2.Unit)
            itemETP3 = New UIMenuItem(EclipseTowerPS3._Name & EclipseTowerPS3.Unit)

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            My.Settings.Mechanic = [Enum].Parse(GetType(Keys), ReadCfgValue("Mechanic", settingFile), False)
            My.Settings.GetHash = [Enum].Parse(GetType(Keys), ReadCfgValue("GetHash", settingFile), False)
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
            CreateVehMenuVespucciBlvd()
            CreateNorthConker2044()
            CreateHillcrestAve2862()
            CreateHillcrestAve2868()
            CreateWildOats3655()
            CreateNorthConker2045()
            CreateMiltonRoad2117()
            CreateHillcrestAve2874()
            CreateWhispymound3677()
            CreateMadWayne2113()
            CreateEclipsePenthouse1()
            CreateEclipsePenthouse2()
            CreateEclipsePenthouse3()

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
            Dim VespucciPathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
            Dim NorthConker2044Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\"
            Dim HillcrestAve2862Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\"
            Dim HillcrestAve2868Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcreast_ave\"
            Dim WildOats3655Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\"
            Dim NorthConker2045Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\"
            Dim MiltonRoad2117Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\"
            Dim HillcrestAve2874Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\"
            Dim Whispymound3677Dir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
            Dim MadWayne2113Dri As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\"
            Dim EclipseP1PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
            Dim EclipseP2PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
            Dim EclipseP3PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"

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
            Dim Vespucci As Integer = IO.Directory.GetFiles(VespucciPathDir, "*.cfg").Count
            Dim NConker2044 As Integer = IO.Directory.GetFiles(NorthConker2044Dir, "*.cfg").Count
            Dim Hillcrest2862 As Integer = IO.Directory.GetFiles(HillcrestAve2862Dir, "*.cfg").Count
            Dim Hillcrest2868 As Integer = IO.Directory.GetFiles(HillcrestAve2868Dir, "*.cfg").Count
            Dim Wild3655 As Integer = IO.Directory.GetFiles(WildOats3655Dir, "*.cfg").Count
            Dim NConker2045 As Integer = IO.Directory.GetFiles(NorthConker2045Dir, "*.cfg").Count
            Dim MiltonR2117 As Integer = IO.Directory.GetFiles(MiltonRoad2117Dir, "*.cfg").Count
            Dim Hillcrest2874 As Integer = IO.Directory.GetFiles(HillcrestAve2874Dir, "*.cfg").Count
            Dim Whispymound3677 As Integer = IO.Directory.GetFiles(Whispymound3677Dir, "*.cfg").Count
            Dim MadWayne2113 As Integer = IO.Directory.GetFiles(MadWayne2113Dri, "*.cfg").Count
            Dim EclipseP1 As Integer = IO.Directory.GetFiles(EclipseP1PathDir, "*.cfg").Count
            Dim EclipseP2 As Integer = IO.Directory.GetFiles(EclipseP2PathDir, "*.cfg").Count
            Dim EclipseP3 As Integer = IO.Directory.GetFiles(EclipseP3PathDir, "*.cfg").Count

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
            If VB = playerName AndAlso Not Vespucci = 0 Then MechanicMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 0 Then MechanicMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 0 Then MechanicMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 0 Then MechanicMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 0 Then MechanicMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 0 Then MechanicMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 0 Then MechanicMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 0 Then MechanicMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not Whispymound3677 = 0 Then MechanicMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not MadWayne2113 = 0 Then MechanicMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 0 Then MechanicMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 0 Then MechanicMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 0 Then MechanicMenu.AddItem(itemETP3)
            MechanicMenu.RefreshIndex()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

#Region "Create Apartment"
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                AS3Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                IW4Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                IW4HLMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                DPHMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                DPHHLMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                DTMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                ETMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                ETHLMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                RMMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                RMHLMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                TTMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                TTHLMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
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
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
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
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
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
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
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
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
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
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
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
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
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
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
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
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                WPMenu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
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

    Public Sub CreateVehMenuVespucciBlvd()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
            VBMenu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            VBMenu.SetBannerType(Rectangle)
            _menuPool.Add(VBMenu)
            VBMenu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                VBMenu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            VBMenu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            VBMenu.RefreshIndex()
            MechanicMenu.BindMenuToItem(VBMenu, itemVB)
            AddHandler VBMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateNorthConker2044()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\"
            NC2044Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            NC2044Menu.SetBannerType(Rectangle)
            _menuPool.Add(NC2044Menu)
            NC2044Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                NC2044Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            NC2044Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            NC2044Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(NC2044Menu, itemNC2044)
            AddHandler NC2044Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateHillcrestAve2862()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\"
            HA2862Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            HA2862Menu.SetBannerType(Rectangle)
            _menuPool.Add(HA2862Menu)
            HA2862Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                HA2862Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            HA2862Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            HA2862Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(HA2862Menu, itemHA2862)
            AddHandler HA2862Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateHillcrestAve2868()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcrest_ave\"
            HA2868Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            HA2868Menu.SetBannerType(Rectangle)
            _menuPool.Add(HA2868Menu)
            HA2868Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                HA2868Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            HA2868Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            HA2868Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(HA2868Menu, itemHA2868)
            AddHandler HA2868Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateWildOats3655()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\"
            WO3655Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            WO3655Menu.SetBannerType(Rectangle)
            _menuPool.Add(WO3655Menu)
            WO3655Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                WO3655Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            WO3655Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            WO3655Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(WO3655Menu, itemWO3655)
            AddHandler WO3655Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateMiltonRoad2117()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\"
            MR2117Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MR2117Menu.SetBannerType(Rectangle)
            _menuPool.Add(MR2117Menu)
            MR2117Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                MR2117Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            MR2117Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            MR2117Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(MR2117Menu, itemMR2117)
            AddHandler MR2117Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateHillcrestAve2874()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\"
            HA2874Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            HA2874Menu.SetBannerType(Rectangle)
            _menuPool.Add(HA2874Menu)
            HA2874Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                HA2874Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            HA2874Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            HA2874Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(HA2874Menu, itemHA2874)
            AddHandler HA2874Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateNorthConker2045()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\"
            NC2045Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            NC2045Menu.SetBannerType(Rectangle)
            _menuPool.Add(NC2045Menu)
            NC2045Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                NC2045Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            NC2045Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            NC2045Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(NC2045Menu, itemNC2045)
            AddHandler NC2045Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateWhispymound3677()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
            WD3677Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            WD3677Menu.SetBannerType(Rectangle)
            _menuPool.Add(WD3677Menu)
            WD3677Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                WD3677Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            WD3677Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            WD3677Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(WD3677Menu, itemWD3677)
            AddHandler WD3677Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateMadWayne2113()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\"
            MW2113Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MW2113Menu.SetBannerType(Rectangle)
            _menuPool.Add(MW2113Menu)
            MW2113Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                MW2113Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            MW2113Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            MW2113Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(MW2113Menu, itemMW2113)
            AddHandler MW2113Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateEclipsePenthouse1()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
            ETP1Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ETP1Menu.SetBannerType(Rectangle)
            _menuPool.Add(ETP1Menu)
            ETP1Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                ETP1Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            ETP1Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            ETP1Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(ETP1Menu, itemETP1)
            AddHandler ETP1Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateEclipsePenthouse2()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
            ETP2Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ETP2Menu.SetBannerType(Rectangle)
            _menuPool.Add(ETP2Menu)
            ETP2Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                ETP2Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            ETP2Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            ETP2Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(ETP2Menu, itemETP2)
            AddHandler ETP2Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateEclipsePenthouse3()
        Try
            Dim PathDir As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"
            ETP3Menu = New UIMenu("", ChooseVeh, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            ETP3Menu.SetBannerType(Rectangle)
            _menuPool.Add(ETP3Menu)
            ETP3Menu.MenuItems.Clear()
            Dim item(10) As UIMenuItem
            If IO.File.Exists(PathDir & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_0.cfg")
                item(0) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_0.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(0))
                With item(0)
                    .Car = PathDir & "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_1.cfg")
                item(1) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_1.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(1))
                With item(1)
                    .Car = PathDir & "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_2.cfg")
                item(2) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_2.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(2))
                With item(2)
                    .Car = PathDir & "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_3.cfg")
                item(3) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_3.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(3))
                With item(3)
                    .Car = PathDir & "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_4.cfg")
                item(4) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_4.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(4))
                With item(4)
                    .Car = PathDir & "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_5.cfg")
                item(5) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_5.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(5))
                With item(5)
                    .Car = PathDir & "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_6.cfg")
                item(6) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_6.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(6))
                With item(6)
                    .Car = PathDir & "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_7.cfg")
                item(7) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_7.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(7))
                With item(7)
                    .Car = PathDir & "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_8.cfg")
                item(8) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_8.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(8))
                With item(8)
                    .Car = PathDir & "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            If IO.File.Exists(PathDir & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", PathDir & "vehicle_9.cfg")
                item(9) = New UIMenuItem(ReadCfgValue("VehicleName", PathDir & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", PathDir & "vehicle_9.cfg") & ")", ChooseVehDesc)
                ETP3Menu.AddItem(item(9))
                With item(9)
                    .Car = PathDir & "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            End If
            Dim ReturnVehItem As New UIMenuItem(ReturnVeh)
            ETP3Menu.AddItem(ReturnVehItem)
            With ReturnVehItem
                .Car = PathDir
            End With
            ETP3Menu.RefreshIndex()
            MechanicMenu.BindMenuToItem(ETP3Menu, itemETP3)
            AddHandler ETP3Menu.OnItemSelect, AddressOf CategoryItemSelectHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
#End Region

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

                If playerPed.IsInVehicle Then
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    If IO.File.Exists(PathDir & "vehicle_0.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_0.cfg")
                    If IO.File.Exists(PathDir & "vehicle_1.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_1.cfg")
                    If IO.File.Exists(PathDir & "vehicle_2.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_2.cfg")
                    If IO.File.Exists(PathDir & "vehicle_3.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_3.cfg")
                    If IO.File.Exists(PathDir & "vehicle_4.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_4.cfg")
                    If IO.File.Exists(PathDir & "vehicle_5.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_5.cfg")
                    If IO.File.Exists(PathDir & "vehicle_6.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_6.cfg")
                    If IO.File.Exists(PathDir & "vehicle_7.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_7.cfg")
                    If IO.File.Exists(PathDir & "vehicle_8.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_8.cfg")
                    If IO.File.Exists(PathDir & "vehicle_9.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_9.cfg")
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                Else
                    Game.FadeScreenOut(500)
                    Script.Wait(&H3E8)
                    If IO.File.Exists(PathDir & "vehicle_0.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_0.cfg")
                    If IO.File.Exists(PathDir & "vehicle_1.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_1.cfg")
                    If IO.File.Exists(PathDir & "vehicle_2.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_2.cfg")
                    If IO.File.Exists(PathDir & "vehicle_3.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_3.cfg")
                    If IO.File.Exists(PathDir & "vehicle_4.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_4.cfg")
                    If IO.File.Exists(PathDir & "vehicle_5.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_5.cfg")
                    If IO.File.Exists(PathDir & "vehicle_6.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_6.cfg")
                    If IO.File.Exists(PathDir & "vehicle_7.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_7.cfg")
                    If IO.File.Exists(PathDir & "vehicle_8.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_8.cfg")
                    If IO.File.Exists(PathDir & "vehicle_9.cfg") Then WriteCfgValue("Active", "False", PathDir & "vehicle_9.cfg")
                    Script.Wait(500)
                    Game.FadeScreenIn(500)
                End If

                If playerName = "Michael" Then
                    If Not MPV0 = Nothing Then MPV0.Delete()
                    If Not MPV1 = Nothing Then MPV1.Delete()
                    If Not MPV2 = Nothing Then MPV2.Delete()
                    If Not MPV3 = Nothing Then MPV3.Delete()
                    If Not MPV4 = Nothing Then MPV4.Delete()
                    If Not MPV5 = Nothing Then MPV5.Delete()
                    If Not MPV6 = Nothing Then MPV6.Delete()
                    If Not MPV7 = Nothing Then MPV7.Delete()
                    If Not MPV8 = Nothing Then MPV8.Delete()
                    If Not MPV9 = Nothing Then MPV9.Delete()
                ElseIf playerName = "Franklin" Then
                    If Not FPV0 = Nothing Then FPV0.Delete()
                    If Not FPV1 = Nothing Then FPV1.Delete()
                    If Not FPV2 = Nothing Then FPV2.Delete()
                    If Not FPV3 = Nothing Then FPV3.Delete()
                    If Not FPV4 = Nothing Then FPV4.Delete()
                    If Not FPV5 = Nothing Then FPV5.Delete()
                    If Not FPV6 = Nothing Then FPV6.Delete()
                    If Not FPV7 = Nothing Then FPV7.Delete()
                    If Not FPV8 = Nothing Then FPV8.Delete()
                    If Not FPV9 = Nothing Then FPV9.Delete()
                ElseIf playerName = "Trevor" Then
                    If Not TPV0 = Nothing Then TPV0.Delete()
                    If Not TPV1 = Nothing Then TPV1.Delete()
                    If Not TPV2 = Nothing Then TPV2.Delete()
                    If Not TPV3 = Nothing Then TPV3.Delete()
                    If Not TPV4 = Nothing Then TPV4.Delete()
                    If Not TPV5 = Nothing Then TPV5.Delete()
                    If Not TPV6 = Nothing Then TPV6.Delete()
                    If Not TPV7 = Nothing Then TPV7.Delete()
                    If Not TPV8 = Nothing Then TPV8.Delete()
                    If Not TPV9 = Nothing Then TPV9.Delete()
                End If
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
                'Add on v1.2.1
                Dim FrontTireVariation As String = ReadCfgValue("FrontTireVariation", selectedItem.Car)
                Dim BackTireVariation As String = ReadCfgValue("BackTireVariation", selectedItem.Car)
                Dim TwentyFive As String = ReadCfgValue("TwentyFive", selectedItem.Car)
                Dim TwentySix As String = ReadCfgValue("TwentySix", selectedItem.Car)
                Dim TwentySeven As String = ReadCfgValue("TwentySeven", selectedItem.Car)
                Dim TwentyEight As String = ReadCfgValue("TwentyEight", selectedItem.Car)
                Dim TwentyNine As String = ReadCfgValue("TwentyNine", selectedItem.Car)
                Dim Thirty As String = ReadCfgValue("Thirty", selectedItem.Car)
                Dim ThirtyOne As String = ReadCfgValue("ThirtyOne", selectedItem.Car)
                Dim ThirtyTwo As String = ReadCfgValue("ThirtyTwo", selectedItem.Car)
                Dim ThirtyThree As String = ReadCfgValue("ThirtyThree", selectedItem.Car)
                Dim ThirtyFour As String = ReadCfgValue("ThirtyFour", selectedItem.Car)
                Dim ThirtyFive As String = ReadCfgValue("ThirtyFive", selectedItem.Car)
                Dim ThirtySix As String = ReadCfgValue("ThirtySix", selectedItem.Car)
                Dim ThirtySeven As String = ReadCfgValue("ThirtySeven", selectedItem.Car)
                Dim ThirtyEight As String = ReadCfgValue("ThirtyEight", selectedItem.Car)
                Dim ThirtyNine As String = ReadCfgValue("ThirtyNine", selectedItem.Car)
                Dim Forthy As String = ReadCfgValue("Forthy", selectedItem.Car)
                Dim ForthyOne As String = ReadCfgValue("ForthyOne", selectedItem.Car)
                Dim ForthyTwo As String = ReadCfgValue("ForthyTwo", selectedItem.Car)
                Dim ForthyThree As String = ReadCfgValue("ForthyThree", selectedItem.Car)
                Dim ForthyFour As String = ReadCfgValue("ForthyFour", selectedItem.Car)
                Dim ForthyFive As String = ReadCfgValue("ForthyFive", selectedItem.Car)
                Dim ForthySix As String = ReadCfgValue("ForthySix", selectedItem.Car)
                Dim ForthySeven As String = ReadCfgValue("ForthySeven", selectedItem.Car)
                Dim ForthyEight As String = ReadCfgValue("ForthyEight", selectedItem.Car)

                If playerName = "Michael" AndAlso Active = "False" Then
                    If MPV1 = Nothing Then
                        MPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        MPV1.AddBlip()
                        MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        MPV1.CurrentBlip.Color = BlipColor.Blue
                        MPV1.CurrentBlip.IsShortRange = True
                        SetBlipName(MPV1.FriendlyName, MPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                        SetModKit(MPV1, selectedItem.Car)
                    Else
                        If MPV2 = Nothing Then
                            MPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            MPV2.AddBlip()
                            MPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            MPV2.CurrentBlip.Color = BlipColor.Blue
                            MPV2.CurrentBlip.IsShortRange = True
                            SetBlipName(MPV2.FriendlyName, MPV2.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", selectedItem.Car)
                            SetModKit(MPV2, selectedItem.Car)
                        Else
                            If MPV3 = Nothing Then
                                MPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                MPV3.AddBlip()
                                MPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                MPV3.CurrentBlip.Color = BlipColor.Blue
                                MPV3.CurrentBlip.IsShortRange = True
                                SetBlipName(MPV3.FriendlyName, MPV3.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", selectedItem.Car)
                                SetModKit(MPV3, selectedItem.Car)
                            Else
                                If MPV4 = Nothing Then
                                    MPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    MPV4.AddBlip()
                                    MPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    MPV4.CurrentBlip.Color = BlipColor.Blue
                                    MPV4.CurrentBlip.IsShortRange = True
                                    SetBlipName(MPV4.FriendlyName, MPV4.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                    SetModKit(MPV4, selectedItem.Car)
                                Else
                                    If MPV5 = Nothing Then
                                        MPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        MPV5.AddBlip()
                                        MPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        MPV5.CurrentBlip.Color = BlipColor.Blue
                                        MPV5.CurrentBlip.IsShortRange = True
                                        SetBlipName(MPV5.FriendlyName, MPV5.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                        SetModKit(MPV5, selectedItem.Car)
                                    Else
                                        If MPV6 = Nothing Then
                                            MPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            MPV6.AddBlip()
                                            MPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            MPV6.CurrentBlip.Color = BlipColor.Blue
                                            MPV6.CurrentBlip.IsShortRange = True
                                            SetBlipName(MPV6.FriendlyName, MPV6.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                            SetModKit(MPV6, selectedItem.Car)
                                        Else
                                            If MPV7 = Nothing Then
                                                MPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                MPV7.AddBlip()
                                                MPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                MPV7.CurrentBlip.Color = BlipColor.Blue
                                                MPV7.CurrentBlip.IsShortRange = True
                                                SetBlipName(MPV7.FriendlyName, MPV7.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", selectedItem.Car)
                                                SetModKit(MPV7, selectedItem.Car)
                                            Else
                                                If MPV8 = Nothing Then
                                                    MPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                    MPV8.AddBlip()
                                                    MPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    MPV8.CurrentBlip.Color = BlipColor.Blue
                                                    MPV8.CurrentBlip.IsShortRange = True
                                                    SetBlipName(MPV8.FriendlyName, MPV8.CurrentBlip)
                                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                                    SetModKit(MPV8, selectedItem.Car)
                                                Else
                                                    If MPV9 = Nothing Then
                                                        MPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                        MPV9.AddBlip()
                                                        MPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        MPV9.CurrentBlip.Color = BlipColor.Blue
                                                        MPV9.CurrentBlip.IsShortRange = True
                                                        SetBlipName(MPV9.FriendlyName, MPV9.CurrentBlip)
                                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                                        SetModKit(MPV9, selectedItem.Car)
                                                    Else
                                                        If MPV0 = Nothing Then
                                                            MPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                            MPV0.AddBlip()
                                                            MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                            MPV0.CurrentBlip.Color = BlipColor.Blue
                                                            MPV0.CurrentBlip.IsShortRange = True
                                                            SetBlipName(MPV0.FriendlyName, MPV0.CurrentBlip)
                                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                                            SetModKit(MPV0, selectedItem.Car)
                                                        Else
                                                            sender.Visible = False
                                                            If uiLanguage = "Chinese" Then
                                                                UI.ShowSubtitle("您已达到车辆交付的最大数量。")
                                                            Else
                                                                UI.ShowSubtitle("You have reached the maximum number of vehicle delivery.")
                                                            End If
                                                            Exit Sub
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf playerName = "Franklin" AndAlso Active = "False" Then
                    If FPV1 = Nothing Then
                        FPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        FPV1.AddBlip()
                        FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        FPV1.CurrentBlip.Color = BlipColor.Green
                        FPV1.CurrentBlip.IsShortRange = True
                        SetBlipName(FPV1.FriendlyName, FPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                        SetModKit(FPV1, selectedItem.Car)
                    Else
                        If FPV2 = Nothing Then
                            FPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            FPV2.AddBlip()
                            FPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            FPV2.CurrentBlip.Color = BlipColor.Green
                            FPV2.CurrentBlip.IsShortRange = True
                            SetBlipName(FPV2.FriendlyName, FPV2.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", selectedItem.Car)
                            SetModKit(FPV2, selectedItem.Car)
                        Else
                            If FPV3 = Nothing Then
                                FPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                FPV3.AddBlip()
                                FPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                FPV3.CurrentBlip.Color = BlipColor.Green
                                FPV3.CurrentBlip.IsShortRange = True
                                SetBlipName(FPV3.FriendlyName, FPV3.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", selectedItem.Car)
                                SetModKit(FPV3, selectedItem.Car)
                            Else
                                If FPV4 = Nothing Then
                                    FPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    FPV4.AddBlip()
                                    FPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    FPV4.CurrentBlip.Color = BlipColor.Green
                                    FPV4.CurrentBlip.IsShortRange = True
                                    SetBlipName(FPV4.FriendlyName, FPV4.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                    SetModKit(FPV4, selectedItem.Car)
                                Else
                                    If FPV5 = Nothing Then
                                        FPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        FPV5.AddBlip()
                                        FPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        FPV5.CurrentBlip.Color = BlipColor.Green
                                        FPV5.CurrentBlip.IsShortRange = True
                                        SetBlipName(FPV5.FriendlyName, FPV5.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                        SetModKit(FPV5, selectedItem.Car)
                                    Else
                                        If FPV6 = Nothing Then
                                            FPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            FPV6.AddBlip()
                                            FPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            FPV6.CurrentBlip.Color = BlipColor.Green
                                            FPV6.CurrentBlip.IsShortRange = True
                                            SetBlipName(FPV6.FriendlyName, FPV6.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                            SetModKit(FPV6, selectedItem.Car)
                                        Else
                                            If FPV7 = Nothing Then
                                                FPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                FPV7.AddBlip()
                                                FPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                FPV7.CurrentBlip.Color = BlipColor.Green
                                                FPV7.CurrentBlip.IsShortRange = True
                                                SetBlipName(FPV7.FriendlyName, FPV7.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", selectedItem.Car)
                                                SetModKit(FPV7, selectedItem.Car)
                                            Else
                                                If FPV8 = Nothing Then
                                                    FPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                    FPV8.AddBlip()
                                                    FPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    FPV8.CurrentBlip.Color = BlipColor.Green
                                                    FPV8.CurrentBlip.IsShortRange = True
                                                    SetBlipName(FPV8.FriendlyName, FPV8.CurrentBlip)
                                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                                    SetModKit(FPV8, selectedItem.Car)
                                                Else
                                                    If FPV9 = Nothing Then
                                                        FPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                        FPV9.AddBlip()
                                                        FPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        FPV9.CurrentBlip.Color = BlipColor.Green
                                                        FPV9.CurrentBlip.IsShortRange = True
                                                        SetBlipName(FPV9.FriendlyName, FPV9.CurrentBlip)
                                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                                        SetModKit(FPV9, selectedItem.Car)
                                                    Else
                                                        If FPV0 = Nothing Then
                                                            FPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                            FPV0.AddBlip()
                                                            FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                            FPV0.CurrentBlip.Color = BlipColor.Green
                                                            FPV0.CurrentBlip.IsShortRange = True
                                                            SetBlipName(FPV0.FriendlyName, FPV0.CurrentBlip)
                                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                                            SetModKit(FPV0, selectedItem.Car)
                                                        Else
                                                            sender.Visible = False
                                                            If uiLanguage = "Chinese" Then
                                                                UI.ShowSubtitle("您已达到车辆交付的最大数量。")
                                                            Else
                                                                UI.ShowSubtitle("You have reached the maximum number of vehicle delivery.")
                                                            End If
                                                            Exit Sub
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf playerName = “Trevor" AndAlso Active = "False" Then
                    If TPV1 = Nothing Then
                        TPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        TPV1.AddBlip()
                        TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        TPV1.CurrentBlip.Color = 17
                        TPV1.CurrentBlip.IsShortRange = True
                        SetBlipName(TPV1.FriendlyName, TPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                        SetModKit(TPV1, selectedItem.Car)
                    Else
                        If TPV2 = Nothing Then
                            TPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            TPV2.AddBlip()
                            TPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            TPV2.CurrentBlip.Color = 17
                            TPV2.CurrentBlip.IsShortRange = True
                            SetBlipName(TPV2.FriendlyName, TPV2.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", selectedItem.Car)
                            SetModKit(TPV2, selectedItem.Car)
                        Else
                            If TPV3 = Nothing Then
                                TPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                TPV3.AddBlip()
                                TPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                TPV3.CurrentBlip.Color = 17
                                TPV3.CurrentBlip.IsShortRange = True
                                SetBlipName(TPV3.FriendlyName, TPV3.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", selectedItem.Car)
                                SetModKit(TPV3, selectedItem.Car)
                            Else
                                If TPV4 = Nothing Then
                                    TPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    TPV4.AddBlip()
                                    TPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    TPV4.CurrentBlip.Color = 17
                                    TPV4.CurrentBlip.IsShortRange = True
                                    SetBlipName(TPV4.FriendlyName, TPV4.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                    SetModKit(TPV4, selectedItem.Car)
                                Else
                                    If TPV5 = Nothing Then
                                        TPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        TPV5.AddBlip()
                                        TPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        TPV5.CurrentBlip.Color = 17
                                        TPV5.CurrentBlip.IsShortRange = True
                                        SetBlipName(TPV5.FriendlyName, TPV5.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                        SetModKit(TPV5, selectedItem.Car)
                                    Else
                                        If TPV6 = Nothing Then
                                            TPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            TPV6.AddBlip()
                                            TPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            TPV6.CurrentBlip.Color = 17
                                            TPV6.CurrentBlip.IsShortRange = True
                                            SetBlipName(TPV6.FriendlyName, TPV6.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                            SetModKit(TPV6, selectedItem.Car)
                                        Else
                                            If TPV7 = Nothing Then
                                                TPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                TPV7.AddBlip()
                                                TPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                TPV7.CurrentBlip.Color = 17
                                                TPV7.CurrentBlip.IsShortRange = True
                                                SetBlipName(TPV7.FriendlyName, TPV7.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", selectedItem.Car)
                                                SetModKit(TPV7, selectedItem.Car)
                                            Else
                                                If TPV8 = Nothing Then
                                                    TPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                    TPV8.AddBlip()
                                                    TPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    TPV8.CurrentBlip.Color = 17
                                                    TPV8.CurrentBlip.IsShortRange = True
                                                    SetBlipName(TPV8.FriendlyName, TPV8.CurrentBlip)
                                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                                    SetModKit(TPV8, selectedItem.Car)
                                                Else
                                                    If TPV9 = Nothing Then
                                                        TPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                        TPV9.AddBlip()
                                                        TPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        TPV9.CurrentBlip.Color = 17
                                                        TPV9.CurrentBlip.IsShortRange = True
                                                        SetBlipName(TPV9.FriendlyName, TPV9.CurrentBlip)
                                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                                        SetModKit(TPV9, selectedItem.Car)
                                                    Else
                                                        If TPV0 = Nothing Then
                                                            TPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                            TPV0.AddBlip()
                                                            TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                            TPV0.CurrentBlip.Color = 17
                                                            TPV0.CurrentBlip.IsShortRange = True
                                                            SetBlipName(TPV0.FriendlyName, TPV0.CurrentBlip)
                                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                                            SetModKit(TPV0, selectedItem.Car)
                                                        Else
                                                            sender.Visible = False
                                                            If uiLanguage = "Chinese" Then
                                                                UI.ShowSubtitle("您已达到车辆交付的最大数量。")
                                                            Else
                                                                UI.ShowSubtitle("You have reached the maximum number of vehicle delivery.")
                                                            End If
                                                            Exit Sub
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            sender.Visible = False
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String)
        Dim VehicleModel As String = ReadCfgValue("VehicleModel", VehicleCfgFile)
        Dim PrimaryColor As String = ReadCfgValue("PrimaryColor", VehicleCfgFile)
        Dim SecondaryColor As String = ReadCfgValue("SecondaryColor", VehicleCfgFile)
        Dim PearlescentColor As String = ReadCfgValue("PearlescentColor", VehicleCfgFile)
        Dim HasCustomPriColor As String = ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile)
        Dim HasCustomSecColor As String = ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile)
        Dim CustomPriColorRed As String = ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile)
        Dim CustomPriColorGreen As String = ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile)
        Dim CustomPriColorBlue As String = ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile)
        Dim CustomSecColorRed As String = ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile)
        Dim CustomSecColorGreen As String = ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile)
        Dim CustomSecColorBlue As String = ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile)
        Dim RimColor As String = ReadCfgValue("RimColor", VehicleCfgFile)
        Dim HasNeonLightBack As String = ReadCfgValue("HasNeonLightBack", VehicleCfgFile)
        Dim HasNeonLightFront As String = ReadCfgValue("HasNeonLightFront", VehicleCfgFile)
        Dim HasNeonLightLeft As String = ReadCfgValue("HasNeonLightLeft", VehicleCfgFile)
        Dim HasNeonLightRight As String = ReadCfgValue("HasNeonLightRight", VehicleCfgFile)
        Dim NeonColorRed As String = ReadCfgValue("NeonColorRed", VehicleCfgFile)
        Dim NeonColorGreen As String = ReadCfgValue("NeonColorGreen", VehicleCfgFile)
        Dim NeonColorBlue As String = ReadCfgValue("NeonColorBlue", VehicleCfgFile)
        Dim TyreSmokeColorRed As String = ReadCfgValue("TyreSmokeColorRed", VehicleCfgFile)
        Dim TyreSmokeColorGreen As String = ReadCfgValue("TyreSmokeColorGreen", VehicleCfgFile)
        Dim TyreSmokeColorBlue As String = ReadCfgValue("TyreSmokeColorBlue", VehicleCfgFile)
        Dim WheelType As String = ReadCfgValue("WheelType", VehicleCfgFile)
        Dim Livery As String = ReadCfgValue("Livery", VehicleCfgFile)
        Dim PlateType As String = ReadCfgValue("PlateType", VehicleCfgFile)
        Dim PlateNumber As String = ReadCfgValue("PlateNumber", VehicleCfgFile)
        Dim WindowTint As String = ReadCfgValue("WindowTint", VehicleCfgFile)
        Dim Spoiler As String = ReadCfgValue("Spoiler", VehicleCfgFile)
        Dim FrontBumper As String = ReadCfgValue("FrontBumper", VehicleCfgFile)
        Dim RearBumper As String = ReadCfgValue("RearBumper", VehicleCfgFile)
        Dim SideSkirt As String = ReadCfgValue("SideSkirt", VehicleCfgFile)
        Dim Frame As String = ReadCfgValue("Frame", VehicleCfgFile)
        Dim Grille As String = ReadCfgValue("Grille", VehicleCfgFile)
        Dim Hood As String = ReadCfgValue("Hood", VehicleCfgFile)
        Dim Fender As String = ReadCfgValue("Fender", VehicleCfgFile)
        Dim RightFender As String = ReadCfgValue("RightFender", VehicleCfgFile)
        Dim Roof As String = ReadCfgValue("Roof", VehicleCfgFile)
        Dim Exhaust As String = ReadCfgValue("Exhaust", VehicleCfgFile)
        Dim FrontWheels As String = ReadCfgValue("FrontWheels", VehicleCfgFile)
        Dim BackWheels As String = ReadCfgValue("BackWheels", VehicleCfgFile)
        Dim Suspension As String = ReadCfgValue("Suspension", VehicleCfgFile)
        Dim Engine As String = ReadCfgValue("Engine", VehicleCfgFile)
        Dim Brakes As String = ReadCfgValue("Brakes", VehicleCfgFile)
        Dim Transmission As String = ReadCfgValue("Transmission", VehicleCfgFile)
        Dim Armor As String = ReadCfgValue("Armor", VehicleCfgFile)
        Dim XenonHeadlights As String = ReadCfgValue("XenonHeadlights", VehicleCfgFile)
        Dim Turbo As String = ReadCfgValue("Turbo", VehicleCfgFile)
        Dim Horn As String = ReadCfgValue("Horn", VehicleCfgFile)
        Dim BulletproofTyres As String = ReadCfgValue("BulletproofTyres", VehicleCfgFile)
        Dim Active As String = ReadCfgValue("Active", VehicleCfgFile)
        'Add on v1.2.1
        Dim FrontTireVariation As String = ReadCfgValue("FrontTireVariation", VehicleCfgFile)
        Dim BackTireVariation As String = ReadCfgValue("BackTireVariation", VehicleCfgFile)
        Dim TwentyFive As String = ReadCfgValue("TwentyFive", VehicleCfgFile)
        Dim TwentySix As String = ReadCfgValue("TwentySix", VehicleCfgFile)
        Dim TwentySeven As String = ReadCfgValue("TwentySeven", VehicleCfgFile)
        Dim TwentyEight As String = ReadCfgValue("TwentyEight", VehicleCfgFile)
        Dim TwentyNine As String = ReadCfgValue("TwentyNine", VehicleCfgFile)
        Dim Thirty As String = ReadCfgValue("Thirty", VehicleCfgFile)
        Dim ThirtyOne As String = ReadCfgValue("ThirtyOne", VehicleCfgFile)
        Dim ThirtyTwo As String = ReadCfgValue("ThirtyTwo", VehicleCfgFile)
        Dim ThirtyThree As String = ReadCfgValue("ThirtyThree", VehicleCfgFile)
        Dim ThirtyFour As String = ReadCfgValue("ThirtyFour", VehicleCfgFile)
        Dim ThirtyFive As String = ReadCfgValue("ThirtyFive", VehicleCfgFile)
        Dim ThirtySix As String = ReadCfgValue("ThirtySix", VehicleCfgFile)
        Dim ThirtySeven As String = ReadCfgValue("ThirtySeven", VehicleCfgFile)
        Dim ThirtyEight As String = ReadCfgValue("ThirtyEight", VehicleCfgFile)
        Dim ThirtyNine As String = ReadCfgValue("ThirtyNine", VehicleCfgFile)
        Dim Forthy As String = ReadCfgValue("Forthy", VehicleCfgFile)
        Dim ForthyOne As String = ReadCfgValue("ForthyOne", VehicleCfgFile)
        Dim ForthyTwo As String = ReadCfgValue("ForthyTwo", VehicleCfgFile)
        Dim ForthyThree As String = ReadCfgValue("ForthyThree", VehicleCfgFile)
        Dim ForthyFour As String = ReadCfgValue("ForthyFour", VehicleCfgFile)
        Dim ForthyFive As String = ReadCfgValue("ForthyFive", VehicleCfgFile)
        Dim ForthySix As String = ReadCfgValue("ForthySix", VehicleCfgFile)
        Dim ForthySeven As String = ReadCfgValue("ForthySeven", VehicleCfgFile)
        Dim ForthyEight As String = ReadCfgValue("ForthyEight", VehicleCfgFile)

        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = PrimaryColor
        _Vehicle.SecondaryColor = SecondaryColor
        _Vehicle.PearlescentColor = PearlescentColor
        If HasCustomPriColor = "True" Then _Vehicle.CustomPrimaryColor = Color.FromArgb(CustomPriColorRed, CustomPriColorGreen, CustomPriColorBlue)
        If HasCustomSecColor = "True" Then _Vehicle.CustomSecondaryColor = Color.FromArgb(CustomSecColorRed, CustomSecColorGreen, CustomSecColorBlue)
        _Vehicle.RimColor = RimColor
        If HasNeonLightBack = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Back, True)
        If HasNeonLightFront = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Front, True)
        If HasNeonLightLeft = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Left, True)
        If HasNeonLightRight = "True" Then _Vehicle.SetNeonLightsOn(VehicleNeonLight.Right, True)
        _Vehicle.NeonLightsColor = Color.FromArgb(NeonColorRed, NeonColorGreen, NeonColorBlue)
        _Vehicle.TireSmokeColor = Color.FromArgb(CInt(TyreSmokeColorRed), CInt(TyreSmokeColorGreen), CInt(TyreSmokeColorBlue))
        _Vehicle.WheelType = WheelType
        _Vehicle.Livery = Livery
        Native.Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, _Vehicle, CInt(PlateType))
        _Vehicle.NumberPlate = PlateNumber
        _Vehicle.WindowTint = WindowTint
        _Vehicle.SetMod(VehicleMod.Spoilers, Spoiler, True)
        _Vehicle.SetMod(VehicleMod.FrontBumper, FrontBumper, True)
        _Vehicle.SetMod(VehicleMod.RearBumper, RearBumper, True)
        _Vehicle.SetMod(VehicleMod.SideSkirt, SideSkirt, True)
        _Vehicle.SetMod(VehicleMod.Frame, Frame, True)
        _Vehicle.SetMod(VehicleMod.Grille, Grille, True)
        _Vehicle.SetMod(VehicleMod.Hood, Hood, True)
        _Vehicle.SetMod(VehicleMod.Fender, Fender, True)
        _Vehicle.SetMod(VehicleMod.RightFender, RightFender, True)
        _Vehicle.SetMod(VehicleMod.Roof, Roof, True)
        _Vehicle.SetMod(VehicleMod.Exhaust, Exhaust, True)
        'Edited on v1.2.1
        If FrontTireVariation = "True" Then _Vehicle.SetMod(VehicleMod.FrontWheels, FrontWheels, True) Else _Vehicle.SetMod(VehicleMod.FrontWheels, FrontWheels, False)
        If BackTireVariation = "True" Then _Vehicle.SetMod(VehicleMod.BackWheels, BackWheels, True) Else _Vehicle.SetMod(VehicleMod.BackWheels, BackWheels, False)
        '=======================================================================================================================================================
        _Vehicle.SetMod(VehicleMod.Suspension, Suspension, True)
        _Vehicle.SetMod(VehicleMod.Engine, Engine, True)
        _Vehicle.SetMod(VehicleMod.Brakes, Brakes, True)
        _Vehicle.SetMod(VehicleMod.Transmission, Transmission, True)
        _Vehicle.SetMod(VehicleMod.Armor, Armor, True)
        'Added on v1.2.1
        _Vehicle.SetMod(25, TwentyFive, True)
        _Vehicle.SetMod(26, TwentySix, True)
        _Vehicle.SetMod(27, TwentySeven, True)
        _Vehicle.SetMod(28, TwentyEight, True)
        _Vehicle.SetMod(29, TwentyNine, True)
        _Vehicle.SetMod(30, Thirty, True)
        _Vehicle.SetMod(31, ThirtyOne, True)
        _Vehicle.SetMod(32, ThirtyTwo, True)
        _Vehicle.SetMod(33, ThirtyThree, True)
        _Vehicle.SetMod(34, ThirtyFour, True)
        _Vehicle.SetMod(35, ThirtyFive, True)
        _Vehicle.SetMod(36, ThirtySix, True)
        _Vehicle.SetMod(37, ThirtySeven, True)
        _Vehicle.SetMod(38, ThirtyEight, True)
        _Vehicle.SetMod(39, ThirtyNine, True)
        _Vehicle.SetMod(40, Forthy, True)
        _Vehicle.SetMod(41, ForthyOne, True)
        _Vehicle.SetMod(42, ForthyTwo, True)
        _Vehicle.SetMod(43, ForthyThree, True)
        _Vehicle.SetMod(44, ForthyFour, True)
        _Vehicle.SetMod(45, ForthyFive, True)
        _Vehicle.SetMod(46, ForthySix, True)
        _Vehicle.SetMod(47, ForthySeven, True)
        _Vehicle.SetMod(48, ForthyEight, True)
        '=================================
        If XenonHeadlights = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
        If Turbo = "True" Then _Vehicle.ToggleMod(VehicleToggleMod.Turbo, True)
        _Vehicle.SetMod(VehicleMod.Horns, Horn, True)
        If BulletproofTyres = "False" Then Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, _Vehicle, False)
        _Vehicle.MarkAsNoLongerNeeded()
        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, _Vehicle, True, False)
    End Sub

    Public Shared Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If Not selectedItem.Text = "Empty" Then
                Select Case selectedItem.Car
                    Case "vehicle_0.cfg"
                        TenCarGarage.veh0.Delete()
                    Case "vehicle_1.cfg"
                        TenCarGarage.veh1.Delete()
                    Case "vehicle_2.cfg"
                        TenCarGarage.veh2.Delete()
                    Case "vehicle_3.cfg"
                        TenCarGarage.veh3.Delete()
                    Case "vehicle_4.cfg"
                        TenCarGarage.veh4.Delete()
                    Case "vehicle_5.cfg"
                        TenCarGarage.veh5.Delete()
                    Case "vehicle_6.cfg"
                        TenCarGarage.veh6.Delete()
                    Case "vehicle_7.cfg"
                        TenCarGarage.veh7.Delete()
                    Case "vehicle_8.cfg"
                        TenCarGarage.veh8.Delete()
                    Case "vehicle_9.cfg"
                        TenCarGarage.veh9.Delete()
                End Select
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
                'If Not playerPed.CurrentVehicle.CurrentBlip Is Nothing Then playerPed.CurrentVehicle.CurrentBlip.Remove()
                If Not playerPed.CurrentVehicle.CurrentBlip Is Nothing Then playerPed.CurrentVehicle.CurrentBlip.Alpha = 0
            Else
                If Not MPV0 = Nothing AndAlso MPV0.CurrentBlip.Alpha = 0 Then
                    MPV0.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV0) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV0, True, False)
                End If
                If Not MPV1 = Nothing AndAlso MPV1.CurrentBlip.Alpha = 0 Then
                    MPV1.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV1) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV1, True, False)
                End If
                If Not MPV2 = Nothing AndAlso MPV2.CurrentBlip.Alpha = 0 Then
                    MPV2.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV2) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV2, True, False)
                End If
                If Not MPV3 = Nothing AndAlso MPV3.CurrentBlip.Alpha = 0 Then
                    MPV3.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV3) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV3, True, False)
                End If
                If Not MPV4 = Nothing AndAlso MPV4.CurrentBlip.Alpha = 0 Then
                    MPV4.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV4) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV4, True, False)
                End If
                If Not MPV5 = Nothing AndAlso MPV5.CurrentBlip.Alpha = 0 Then
                    MPV5.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV5) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV5, True, False)
                End If
                If Not MPV6 = Nothing AndAlso MPV6.CurrentBlip.Alpha = 0 Then
                    MPV6.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV6) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV6, True, False)
                End If
                If Not MPV7 = Nothing AndAlso MPV7.CurrentBlip.Alpha = 0 Then
                    MPV7.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV7) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV7, True, False)
                End If
                If Not MPV8 = Nothing AndAlso MPV8.CurrentBlip.Alpha = 0 Then
                    MPV8.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV8) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV8, True, False)
                End If
                If Not MPV9 = Nothing AndAlso MPV9.CurrentBlip.Alpha = 0 Then
                    MPV9.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, MPV9) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, MPV9, True, False)
                End If
                If Not FPV0 = Nothing AndAlso FPV0.CurrentBlip.Alpha = 0 Then
                    FPV0.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV0) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV0, True, False)
                End If
                If Not FPV1 = Nothing AndAlso FPV1.CurrentBlip.Alpha = 0 Then
                    FPV1.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV1) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV1, True, False)
                End If
                If Not FPV2 = Nothing AndAlso FPV2.CurrentBlip.Alpha = 0 Then
                    FPV2.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV2) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV2, True, False)
                End If
                If Not FPV3 = Nothing AndAlso FPV3.CurrentBlip.Alpha = 0 Then
                    FPV3.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV3) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV3, True, False)
                End If
                If Not FPV4 = Nothing AndAlso FPV4.CurrentBlip.Alpha = 0 Then
                    FPV4.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV4) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV4, True, False)
                End If
                If Not FPV5 = Nothing AndAlso FPV5.CurrentBlip.Alpha = 0 Then
                    FPV5.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV5) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV5, True, False)
                End If
                If Not FPV6 = Nothing AndAlso FPV6.CurrentBlip.Alpha = 0 Then
                    FPV6.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV6) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV6, True, False)
                End If
                If Not FPV7 = Nothing AndAlso FPV7.CurrentBlip.Alpha = 0 Then
                    FPV7.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV7) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV7, True, False)
                End If
                If Not FPV8 = Nothing AndAlso FPV8.CurrentBlip.Alpha = 0 Then
                    FPV8.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV8) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV8, True, False)
                End If
                If Not FPV9 = Nothing AndAlso FPV9.CurrentBlip.Alpha = 0 Then
                    FPV9.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, FPV9) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, FPV9, True, False)
                End If
                If Not TPV0 = Nothing AndAlso TPV0.CurrentBlip.Alpha = 0 Then
                    TPV0.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV0) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV0, True, False)
                End If
                If Not TPV1 = Nothing AndAlso TPV1.CurrentBlip.Alpha = 0 Then
                    TPV1.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV1) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV1, True, False)
                End If
                If Not TPV2 = Nothing AndAlso TPV2.CurrentBlip.Alpha = 0 Then
                    TPV2.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV2) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV2, True, False)
                End If
                If Not TPV3 = Nothing AndAlso TPV3.CurrentBlip.Alpha = 0 Then
                    TPV3.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV3) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV3, True, False)
                End If
                If Not TPV4 = Nothing AndAlso TPV4.CurrentBlip.Alpha = 0 Then
                    TPV4.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV4) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV4, True, False)
                End If
                If Not TPV5 = Nothing AndAlso TPV5.CurrentBlip.Alpha = 0 Then
                    TPV5.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV5) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV5, True, False)
                End If
                If Not TPV6 = Nothing AndAlso TPV6.CurrentBlip.Alpha = 0 Then
                    TPV6.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV6) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV6, True, False)
                End If
                If Not TPV7 = Nothing AndAlso TPV7.CurrentBlip.Alpha = 0 Then
                    TPV7.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV7) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV7, True, False)
                End If
                If Not TPV8 = Nothing AndAlso TPV8.CurrentBlip.Alpha = 0 Then
                    TPV8.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV8) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV8, True, False)
                End If
                If Not TPV9 = Nothing AndAlso TPV9.CurrentBlip.Alpha = 0 Then
                    TPV9.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, TPV9) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, TPV9, True, False)
                End If
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
            VB = ReadCfgValue("VPBowner", saveFile2)
            NC2044 = ReadCfgValue("2044NCowner", saveFile2)
            HA2862 = ReadCfgValue("2862HAowner", saveFile2)
            HA2868 = ReadCfgValue("2868HAowner", saveFile2)
            WO3655 = ReadCfgValue("3655WODowner", saveFile2)
            NC2045 = ReadCfgValue("2045NCowner", saveFile2)
            MR2117 = ReadCfgValue("2117MRowner", saveFile2)
            HA2874 = ReadCfgValue("2874HAowner", saveFile2)
            WD3677 = ReadCfgValue("3677WDowner", saveFile2)
            MW2113 = ReadCfgValue("2113MWowner", saveFile2)
            ETP1 = ReadCfgValue("ETP1owner", saveFile2)
            ETP2 = ReadCfgValue("ETP2owner", saveFile2)
            ETP3 = ReadCfgValue("ETP3owner", saveFile2)

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
            itemVB = New UIMenuItem(VespucciBlvd._Name & VespucciBlvd.Unit)
            itemNC2044 = New UIMenuItem(NorthConker2044._Name & NorthConker2044.Unit)
            itemHA2862 = New UIMenuItem(HillcrestAve2862._Name & HillcrestAve2862.Unit)
            itemHA2868 = New UIMenuItem(HillcrestAve2868._Name & HillcrestAve2868.Unit)
            itemWO3655 = New UIMenuItem(WildOats3655._Name & WildOats3655.Unit)
            itemNC2045 = New UIMenuItem(NorthConker2045._Name & NorthConker2045.Unit)
            itemMR2117 = New UIMenuItem(MiltonRd2117._Name & MiltonRd2117.Unit)
            itemHA2874 = New UIMenuItem(HillcrestAve2874._Name & HillcrestAve2874.Unit)
            itemWD3677 = New UIMenuItem(Whispymound3677._Name & Whispymound3677.Unit)
            itemMW2113 = New UIMenuItem(MadWayne2113._Name & MadWayne2113.Unit)
            itemETP1 = New UIMenuItem(EclipseTowerPS1._Name & EclipseTowerPS1.Unit)
            itemETP2 = New UIMenuItem(EclipseTowerPS2._Name & EclipseTowerPS2.Unit)
            itemETP3 = New UIMenuItem(EclipseTowerPS3._Name & EclipseTowerPS3.Unit)

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
            CreateVehMenuVespucciBlvd()
            CreateNorthConker2044()
            CreateHillcrestAve2862()
            CreateHillcrestAve2868()
            CreateWildOats3655()
            CreateNorthConker2045()
            CreateMiltonRoad2117()
            CreateHillcrestAve2874()
            CreateWhispymound3677()
            CreateMadWayne2113()
            CreateEclipsePenthouse1()
            CreateEclipsePenthouse2()
            CreateEclipsePenthouse3()
            MechanicMenu.Visible = Not MechanicMenu.Visible
        ElseIf e.KeyCode = My.Settings.GetHash Then
            DisplayNotificationThisFrame("I'm Not MentaL", "", "Hash: " & playerPed.CurrentVehicle.Model.GetHashCode(), "CHAR_LAMAR", True, IconType.RightJumpingArrow)
        End If
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try
                If Not MPV0 = Nothing Then MPV0.Delete()
                If Not MPV1 = Nothing Then MPV1.Delete()
                If Not MPV2 = Nothing Then MPV2.Delete()
                If Not MPV3 = Nothing Then MPV3.Delete()
                If Not MPV4 = Nothing Then MPV4.Delete()
                If Not MPV5 = Nothing Then MPV5.Delete()
                If Not MPV6 = Nothing Then MPV6.Delete()
                If Not MPV7 = Nothing Then MPV7.Delete()
                If Not MPV8 = Nothing Then MPV8.Delete()
                If Not MPV9 = Nothing Then MPV9.Delete()
                If Not FPV0 = Nothing Then FPV0.Delete()
                If Not FPV1 = Nothing Then FPV1.Delete()
                If Not FPV2 = Nothing Then FPV2.Delete()
                If Not FPV3 = Nothing Then FPV3.Delete()
                If Not FPV4 = Nothing Then FPV4.Delete()
                If Not FPV5 = Nothing Then FPV5.Delete()
                If Not FPV6 = Nothing Then FPV6.Delete()
                If Not FPV7 = Nothing Then FPV7.Delete()
                If Not FPV8 = Nothing Then FPV8.Delete()
                If Not FPV9 = Nothing Then FPV9.Delete()
                If Not TPV0 = Nothing Then TPV0.Delete()
                If Not TPV1 = Nothing Then TPV1.Delete()
                If Not TPV2 = Nothing Then TPV2.Delete()
                If Not TPV3 = Nothing Then TPV3.Delete()
                If Not TPV4 = Nothing Then TPV4.Delete()
                If Not TPV5 = Nothing Then TPV5.Delete()
                If Not TPV6 = Nothing Then TPV6.Delete()
                If Not TPV7 = Nothing Then TPV7.Delete()
                If Not TPV8 = Nothing Then TPV8.Delete()
                If Not TPV9 = Nothing Then TPV9.Delete()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
