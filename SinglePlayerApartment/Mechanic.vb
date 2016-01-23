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
    Public Shared GarageMenu, GarageMenu2, GrgMoveMenu, MechanicMenu, AS3Menu, IW4Menu, IW4HLMenu, DPHMenu, DPHHLMenu, DTMenu, ETMenu, ETHLMenu, RMMenu, RMHLMenu, TTMenu, TTHLMenu, WPMenu, VBMenu As UIMenu
    Public Shared NC2044Menu, HA2862Menu, HA2868Menu, WO3655Menu, NC2045Menu, MR2117Menu, HA2874Menu, WD3677Menu, MW2113Menu, ETP1Menu, ETP2Menu, ETP3Menu As UIMenu
    Public Shared _menuPool As MenuPool
    Public Shared AS3, IW4, IW4HL, DPH, DPHHL, DT, ET, ETHL, RM, RMHL, TT, TTHL, WP, VB As String
    Public Shared NC2044, HA2862, HA2868, WO3655, NC2045, MR2117, HA2874, WD3677, MW2113, ETP1, ETP2, ETP3 As String
    Public Shared MPV0, MPV1, MPV2, MPV3, MPV4, MPV5, MPV6, MPV7, MPV8, MPV9 As Vehicle
    Public Shared FPV0, FPV1, FPV2, FPV3, FPV4, FPV5, FPV6, FPV7, FPV8, FPV9 As Vehicle
    Public Shared TPV0, TPV1, TPV2, TPV3, TPV4, TPV5, TPV6, TPV7, TPV8, TPV9 As Vehicle
    Public Shared PPV0, PPV1, PPV2, PPV3, PPV4, PPV5, PPV6, PPV7, PPV8, PPV9 As Vehicle
    Public Shared itemAS3, itemIW4, itemIW4HL, itemDPH, itemDPHHL, itemDT, itemET, itemETHL, itemRM, itemRMHL, itemTT, itemTTHL, itemWP, itemVB As UIMenuItem
    Public Shared itemNC2044, itemHA2862, itemHA2868, itemWO3655, itemNC2045, itemMR2117, itemHA2874, itemWD3677, itemMW2113, itemETP1, itemETP2, itemETP3 As UIMenuItem
    Public Shared GarageMenuItem(10) As UIMenuItem
    Public Shared GrgMoveMenuItem(10) As UIMenuItem
    Public Shared GarageMenuSelectedItem, GarageMenuSelectedFile, MoveMenuSelectedItem, MoveMenuSelectedFile, MoveMenuSelectedIndex, SelectedGarage As String

    Public Sub New()
        Try
            uiLanguage = Game.Language.ToString
            If uiLanguage = "Chinese" Then
                Garage = "車庫"
                _Mechanic = "機械師"
                GrgOptions = "管理車輛"
                GrgRemove = "刪除車輛"
                GrgRemoveAndDrive = "刪除並且駕駛離開"
                GrgMove = "重新排序"
                GrgSell = "出售車輛給改車王"
                GrgSelectVeh = "選擇車輛"
                GrgTooHot = "我們暫時不需要這輛車。"
                ReturnVeh = "返回所有車輛"
            Else
                Garage = " Garage"
                _Mechanic = "Mechanic"
                GrgOptions = "MANAGE VEHICLES"
                GrgRemove = "Remove Vehicle"
                GrgRemoveAndDrive = "Remove and exit Garage"
                GrgMove = "Rearrange Vehicle"
                GrgSell = "Sell Vehicle to LSC"
                GrgSelectVeh = "Select vehicle."
                GrgTooHot = "This vehicle is too hot to sell."
                ReturnVeh = "Return all Vehicles"
            End If

            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
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
            My.Settings.Save()

            _menuPool = New MenuPool()
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
            If AS3 = playerName AndAlso Not Alta = 0 AndAlso ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then MechanicMenu.AddItem(itemAS3)
            If IW4 = playerName AndAlso Not Integrity = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4)
            If IW4HL = playerName AndAlso Not Integrity2 = 0 AndAlso ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then MechanicMenu.AddItem(itemIW4HL)
            If DPH = playerName AndAlso Not Perro = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPH)
            If DPHHL = playerName AndAlso Not Perro2 = 0 AndAlso ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDPHHL)
            If DT = playerName AndAlso Not Dream = 0 AndAlso ReadCfgValue("DreamTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemDT)
            If ET = playerName AndAlso Not Eclipse = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemET)
            If ETHL = playerName AndAlso Not Eclipse2 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETHL)
            If RM = playerName AndAlso Not Richard = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRM)
            If RMHL = playerName AndAlso Not Richard2 = 0 AndAlso ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then MechanicMenu.AddItem(itemRMHL)
            If TT = playerName AndAlso Not Tinsel = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTT)
            If TTHL = playerName AndAlso Not Tinsel2 = 0 AndAlso ReadCfgValue("TinselTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemTTHL)
            If WP = playerName AndAlso Not Weazel = 0 AndAlso ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWP)
            If VB = playerName AndAlso Not Vespucci = 0 AndAlso ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemVB)
            If NC2044 = playerName AndAlso Not NConker2044 = 0 AndAlso ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2044)
            If HA2862 = playerName AndAlso Not Hillcrest2862 = 0 AndAlso ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2862)
            If HA2868 = playerName AndAlso Not Hillcrest2868 = 0 AndAlso ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2868)
            If WO3655 = playerName AndAlso Not Wild3655 = 0 AndAlso ReadCfgValue("3655WildOats", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWO3655)
            If NC2045 = playerName AndAlso Not NConker2045 = 0 AndAlso ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then MechanicMenu.AddItem(itemNC2045)
            If MR2117 = playerName AndAlso Not MiltonR2117 = 0 AndAlso ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMR2117)
            If HA2874 = playerName AndAlso Not Hillcrest2874 = 0 AndAlso ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then MechanicMenu.AddItem(itemHA2874)
            If WD3677 = playerName AndAlso Not Whispymound3677 = 0 AndAlso ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then MechanicMenu.AddItem(itemWD3677)
            If MW2113 = playerName AndAlso Not MadWayne2113 = 0 AndAlso ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then MechanicMenu.AddItem(itemMW2113)
            If ETP1 = playerName AndAlso Not EclipseP1 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP1)
            If ETP2 = playerName AndAlso Not EclipseP2 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP2)
            If ETP3 = playerName AndAlso Not EclipseP3 = 0 AndAlso ReadCfgValue("EclipseTower", settingFile) = "Enable" Then MechanicMenu.AddItem(itemETP3)
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

    Public Shared Sub CreateMoveMenu(file As String, SixOrTen As String)
        Try
            GrgMoveMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GrgMoveMenu.SetBannerType(Rectangle)
            _menuPool.Add(GrgMoveMenu)
            GrgMoveMenu.MenuItems.Clear()
            If SixOrTen = "Ten" Then
                If IO.File.Exists(file & "vehicle_0.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                    GrgMoveMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(0) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_1.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                    GrgMoveMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(1) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_2.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                    GrgMoveMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(2) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_3.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                    GrgMoveMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(3) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_4.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                    GrgMoveMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(4) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_5.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                    GrgMoveMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(5) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_6.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                    GrgMoveMenuItem(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(6))
                    With GrgMoveMenuItem(6)
                        .Car = "vehicle_6.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(6) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(6))
                    With GrgMoveMenuItem(6)
                        .Car = "vehicle_6.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_7.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                    GrgMoveMenuItem(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(7))
                    With GrgMoveMenuItem(7)
                        .Car = "vehicle_7.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(7) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(7))
                    With GrgMoveMenuItem(7)
                        .Car = "vehicle_7.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_8.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                    GrgMoveMenuItem(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(8))
                    With GrgMoveMenuItem(8)
                        .Car = "vehicle_8.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(8) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(8))
                    With GrgMoveMenuItem(8)
                        .Car = "vehicle_8.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_9.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                    GrgMoveMenuItem(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(9))
                    With GrgMoveMenuItem(9)
                        .Car = "vehicle_9.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(9) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(9))
                    With GrgMoveMenuItem(9)
                        .Car = "vehicle_9.cfg"
                    End With
                End If
            ElseIf SelectedGarage = "Six"
                If IO.File.Exists(file & "vehicle_0.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                    GrgMoveMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(0) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(0))
                    With GrgMoveMenuItem(0)
                        .Car = "vehicle_0.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_1.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                    GrgMoveMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(1) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(1))
                    With GrgMoveMenuItem(1)
                        .Car = "vehicle_1.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_2.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                    GrgMoveMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(2) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(2))
                    With GrgMoveMenuItem(2)
                        .Car = "vehicle_2.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_3.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                    GrgMoveMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(3) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(3))
                    With GrgMoveMenuItem(3)
                        .Car = "vehicle_3.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_4.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                    GrgMoveMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(4) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(4))
                    With GrgMoveMenuItem(4)
                        .Car = "vehicle_4.cfg"
                    End With
                End If
                If IO.File.Exists(file & "vehicle_5.cfg") Then
                    Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                    GrgMoveMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                        If Active = "True" Then
                            .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                Else
                    GrgMoveMenuItem(5) = New UIMenuItem("Empty")
                    GrgMoveMenu.AddItem(GrgMoveMenuItem(5))
                    With GrgMoveMenuItem(5)
                        .Car = "vehicle_5.cfg"
                    End With
                End If
            End If
            GrgMoveMenu.RefreshIndex()
            AddHandler GrgMoveMenu.OnItemSelect, AddressOf GrgMoveItemSelectHandler
            AddHandler GrgMoveMenu.OnMenuClose, AddressOf GrgMoveMenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu2(SixOrTen As String)
        Try
            GarageMenu2 = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu2.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu2)
            GarageMenu2.AddItem(New UIMenuItem(GrgRemove))
            GarageMenu2.AddItem(New UIMenuItem(GrgRemoveAndDrive))
            GarageMenu2.AddItem(New UIMenuItem(GrgSell))
            GarageMenu2.AddItem(New UIMenuItem(GrgMove))
            GarageMenu2.RefreshIndex()
            If SixOrTen = "Ten" Then
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(6))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(7))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(8))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(9))
                SelectedGarage = "Ten"
            Else
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(0))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(1))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(2))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(3))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(4))
                GarageMenu.BindMenuToItem(GarageMenu2, GarageMenuItem(5))
                SelectedGarage = "Six"
            End If
            AddHandler GarageMenu2.OnItemSelect, AddressOf ItemSelectHandler
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
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                GarageMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                GarageMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                GarageMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                GarageMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                GarageMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                GarageMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_6.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_6.cfg")
                GarageMenuItem(6) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_6.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_6.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(6))
                With GarageMenuItem(6)
                    .Car = "vehicle_6.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(6) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(6))
                With GarageMenuItem(6)
                    .Car = "vehicle_6.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_7.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_7.cfg")
                GarageMenuItem(7) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_7.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_7.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(7))
                With GarageMenuItem(7)
                    .Car = "vehicle_7.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(7) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(7))
                With GarageMenuItem(7)
                    .Car = "vehicle_7.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_8.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_8.cfg")
                GarageMenuItem(8) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_8.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_8.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(8))
                With GarageMenuItem(8)
                    .Car = "vehicle_8.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(8) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(8))
                With GarageMenuItem(8)
                    .Car = "vehicle_8.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_9.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_9.cfg")
                GarageMenuItem(9) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_9.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_9.cfg") & ")", GrgSelectVeh)
                GarageMenu.AddItem(GarageMenuItem(9))
                With GarageMenuItem(9)
                    .Car = "vehicle_9.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(9) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(9))
                With GarageMenuItem(9)
                    .Car = "vehicle_9.cfg"
                End With
            End If
            GarageMenu.RefreshIndex()
            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler GarageMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub CreateGarageMenu6CarGarage(file As String)
        Try
            GarageMenu = New UIMenu("", GrgOptions, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            GarageMenu.SetBannerType(Rectangle)
            _menuPool.Add(GarageMenu)
            GarageMenu.MenuItems.Clear()
            If IO.File.Exists(file & "vehicle_0.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_0.cfg")
                GarageMenuItem(0) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_0.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_0.cfg") & ")")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(0) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(0))
                With GarageMenuItem(0)
                    .Car = "vehicle_0.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_1.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_1.cfg")
                GarageMenuItem(1) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_1.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_1.cfg") & ")")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(1) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(1))
                With GarageMenuItem(1)
                    .Car = "vehicle_1.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_2.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_2.cfg")
                GarageMenuItem(2) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_2.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_2.cfg") & ")")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(2) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(2))
                With GarageMenuItem(2)
                    .Car = "vehicle_2.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_3.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_3.cfg")
                GarageMenuItem(3) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_3.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_3.cfg") & ")")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(3) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(3))
                With GarageMenuItem(3)
                    .Car = "vehicle_3.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_4.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_4.cfg")
                GarageMenuItem(4) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_4.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_4.cfg") & ")")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(4) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(4))
                With GarageMenuItem(4)
                    .Car = "vehicle_4.cfg"
                End With
            End If
            If IO.File.Exists(file & "vehicle_5.cfg") Then
                Dim Active As String = ReadCfgValue("Active", file & "vehicle_5.cfg")
                GarageMenuItem(5) = New UIMenuItem(ReadCfgValue("VehicleName", file & "vehicle_5.cfg") & " (" & ReadCfgValue("PlateNumber", file & "vehicle_5.cfg") & ")")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                    If Active = "True" Then
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
            Else
                GarageMenuItem(5) = New UIMenuItem("Empty")
                GarageMenu.AddItem(GarageMenuItem(5))
                With GarageMenuItem(5)
                    .Car = "vehicle_5.cfg"
                End With
            End If
            GarageMenu.RefreshIndex()
            AddHandler GarageMenu.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler GarageMenu.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CategoryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = ReturnVeh Then
                Mechanic2.ReturnVeh(selectedItem.Car)
            ElseIf Not selectedItem.LeftBadge = UIMenuItem.BadgeStyle.Car AndAlso Not selectedItem.Text = ReturnVeh Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", selectedItem.Car)
                Dim Active As String = ReadCfgValue("Active", selectedItem.Car)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", selectedItem.Car)

                If playerName = "Michael" AndAlso Active = "False" Then
                    If MPV1 = Nothing Then
                        If VehicleModel = "" Then
                            MPV1 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                        Else
                            MPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        End If
                        MPV1.AddBlip()
                        MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        MPV1.CurrentBlip.Color = BlipColor.Blue
                        MPV1.CurrentBlip.IsShortRange = True
                        SetBlipName(MPV1.FriendlyName, MPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                        Mechanic2.SetModKit(MPV1, selectedItem.Car)
                    Else
                        If MPV2 = Nothing Then
                            If VehicleModel = "" Then
                                MPV2 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                            Else
                                MPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            End If
                            MPV2.AddBlip()
                            MPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            MPV2.CurrentBlip.Color = BlipColor.Blue
                            MPV2.CurrentBlip.IsShortRange = True
                            SetBlipName(MPV2.FriendlyName, MPV2.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", selectedItem.Car)
                            Mechanic2.SetModKit(MPV2, selectedItem.Car)
                        Else
                            If MPV3 = Nothing Then
                                If VehicleModel = "" Then
                                    MPV3 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                Else
                                    MPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                End If
                                MPV3.AddBlip()
                                MPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                MPV3.CurrentBlip.Color = BlipColor.Blue
                                MPV3.CurrentBlip.IsShortRange = True
                                SetBlipName(MPV3.FriendlyName, MPV3.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", selectedItem.Car)
                                Mechanic2.SetModKit(MPV3, selectedItem.Car)
                            Else
                                If MPV4 = Nothing Then
                                    If VehicleModel = "" Then
                                        MPV4 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                    Else
                                        MPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    End If
                                    MPV4.AddBlip()
                                    MPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    MPV4.CurrentBlip.Color = BlipColor.Blue
                                    MPV4.CurrentBlip.IsShortRange = True
                                    SetBlipName(MPV4.FriendlyName, MPV4.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                    Mechanic2.SetModKit(MPV4, selectedItem.Car)
                                Else
                                    If MPV5 = Nothing Then
                                        If VehicleModel = "" Then
                                            MPV5 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                        Else
                                            MPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        End If
                                        MPV5.AddBlip()
                                        MPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        MPV5.CurrentBlip.Color = BlipColor.Blue
                                        MPV5.CurrentBlip.IsShortRange = True
                                        SetBlipName(MPV5.FriendlyName, MPV5.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                        Mechanic2.SetModKit(MPV5, selectedItem.Car)
                                    Else
                                        If MPV6 = Nothing Then
                                            If VehicleModel = "" Then
                                                MPV6 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                            Else
                                                MPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            End If
                                            MPV6.AddBlip()
                                            MPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            MPV6.CurrentBlip.Color = BlipColor.Blue
                                            MPV6.CurrentBlip.IsShortRange = True
                                            SetBlipName(MPV6.FriendlyName, MPV6.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                            Mechanic2.SetModKit(MPV6, selectedItem.Car)
                                        Else
                                            If MPV7 = Nothing Then
                                                If VehicleModel = "" Then
                                                    MPV7 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                Else
                                                    MPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                End If
                                                MPV7.AddBlip()
                                                MPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                MPV7.CurrentBlip.Color = BlipColor.Blue
                                                MPV7.CurrentBlip.IsShortRange = True
                                                SetBlipName(MPV7.FriendlyName, MPV7.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", selectedItem.Car)
                                                Mechanic2.SetModKit(MPV7, selectedItem.Car)
                                            Else
                                                If MPV8 = Nothing Then
                                                    If VehicleModel = "" Then
                                                        MPV8 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                    Else
                                                        MPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                    End If
                                                    MPV8.AddBlip()
                                                    MPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    MPV8.CurrentBlip.Color = BlipColor.Blue
                                                    MPV8.CurrentBlip.IsShortRange = True
                                                    SetBlipName(MPV8.FriendlyName, MPV8.CurrentBlip)
                                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                                    Mechanic2.SetModKit(MPV8, selectedItem.Car)
                                                Else
                                                    If MPV9 = Nothing Then
                                                        If VehicleModel = "" Then
                                                            MPV9 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                        Else
                                                            MPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                        End If
                                                        MPV9.AddBlip()
                                                        MPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        MPV9.CurrentBlip.Color = BlipColor.Blue
                                                        MPV9.CurrentBlip.IsShortRange = True
                                                        SetBlipName(MPV9.FriendlyName, MPV9.CurrentBlip)
                                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                                        Mechanic2.SetModKit(MPV9, selectedItem.Car)
                                                    Else
                                                        If MPV0 = Nothing Then
                                                            If VehicleModel = "" Then
                                                                MPV0 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                            Else
                                                                MPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                            End If
                                                            MPV0.AddBlip()
                                                            MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                            MPV0.CurrentBlip.Color = BlipColor.Blue
                                                            MPV0.CurrentBlip.IsShortRange = True
                                                            SetBlipName(MPV0.FriendlyName, MPV0.CurrentBlip)
                                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                                            Mechanic2.SetModKit(MPV0, selectedItem.Car)
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
                        If VehicleModel = "" Then
                            FPV1 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                        Else
                            FPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        End If
                        FPV1.AddBlip()
                        FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        FPV1.CurrentBlip.Color = BlipColor.Green
                        FPV1.CurrentBlip.IsShortRange = True
                        SetBlipName(FPV1.FriendlyName, FPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                        Mechanic2.SetModKit(FPV1, selectedItem.Car)
                    Else
                        If FPV2 = Nothing Then
                            If VehicleModel = "" Then
                                FPV2 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                            Else
                                FPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            End If
                            FPV2.AddBlip()
                            FPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            FPV2.CurrentBlip.Color = BlipColor.Green
                            FPV2.CurrentBlip.IsShortRange = True
                            SetBlipName(FPV2.FriendlyName, FPV2.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", selectedItem.Car)
                            Mechanic2.SetModKit(FPV2, selectedItem.Car)
                        Else
                            If FPV3 = Nothing Then
                                If VehicleModel = "" Then
                                    FPV3 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                Else
                                    FPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                End If
                                FPV3.AddBlip()
                                FPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                FPV3.CurrentBlip.Color = BlipColor.Green
                                FPV3.CurrentBlip.IsShortRange = True
                                SetBlipName(FPV3.FriendlyName, FPV3.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", selectedItem.Car)
                                Mechanic2.SetModKit(FPV3, selectedItem.Car)
                            Else
                                If FPV4 = Nothing Then
                                    If VehicleModel = "" Then
                                        FPV4 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                    Else
                                        FPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    End If
                                    FPV4.AddBlip()
                                    FPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    FPV4.CurrentBlip.Color = BlipColor.Green
                                    FPV4.CurrentBlip.IsShortRange = True
                                    SetBlipName(FPV4.FriendlyName, FPV4.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                    Mechanic2.SetModKit(FPV4, selectedItem.Car)
                                Else
                                    If FPV5 = Nothing Then
                                        If VehicleModel = "" Then
                                            FPV5 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                        Else
                                            FPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        End If
                                        FPV5.AddBlip()
                                        FPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        FPV5.CurrentBlip.Color = BlipColor.Green
                                        FPV5.CurrentBlip.IsShortRange = True
                                        SetBlipName(FPV5.FriendlyName, FPV5.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                        Mechanic2.SetModKit(FPV5, selectedItem.Car)
                                    Else
                                        If FPV6 = Nothing Then
                                            If VehicleModel = "" Then
                                                FPV6 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                            Else
                                                FPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            End If
                                            FPV6.AddBlip()
                                            FPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            FPV6.CurrentBlip.Color = BlipColor.Green
                                            FPV6.CurrentBlip.IsShortRange = True
                                            SetBlipName(FPV6.FriendlyName, FPV6.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                            Mechanic2.SetModKit(FPV6, selectedItem.Car)
                                        Else
                                            If FPV7 = Nothing Then
                                                If VehicleModel = "" Then
                                                    FPV7 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                Else
                                                    FPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                End If
                                                FPV7.AddBlip()
                                                FPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                FPV7.CurrentBlip.Color = BlipColor.Green
                                                FPV7.CurrentBlip.IsShortRange = True
                                                SetBlipName(FPV7.FriendlyName, FPV7.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", selectedItem.Car)
                                                Mechanic2.SetModKit(FPV7, selectedItem.Car)
                                            Else
                                                If FPV8 = Nothing Then
                                                    If VehicleModel = "" Then
                                                        FPV8 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                    Else
                                                        FPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                    End If
                                                    FPV8.AddBlip()
                                                    FPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    FPV8.CurrentBlip.Color = BlipColor.Green
                                                    FPV8.CurrentBlip.IsShortRange = True
                                                    SetBlipName(FPV8.FriendlyName, FPV8.CurrentBlip)
                                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                                    Mechanic2.SetModKit(FPV8, selectedItem.Car)
                                                Else
                                                    If FPV9 = Nothing Then
                                                        If VehicleModel = "" Then
                                                            FPV9 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                        Else
                                                            FPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                        End If
                                                        FPV9.AddBlip()
                                                        FPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        FPV9.CurrentBlip.Color = BlipColor.Green
                                                        FPV9.CurrentBlip.IsShortRange = True
                                                        SetBlipName(FPV9.FriendlyName, FPV9.CurrentBlip)
                                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                                        Mechanic2.SetModKit(FPV9, selectedItem.Car)
                                                    Else
                                                        If FPV0 = Nothing Then
                                                            If VehicleModel = "" Then
                                                                FPV0 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                            Else
                                                                FPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                            End If
                                                            FPV0.AddBlip()
                                                            FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                            FPV0.CurrentBlip.Color = BlipColor.Green
                                                            FPV0.CurrentBlip.IsShortRange = True
                                                            SetBlipName(FPV0.FriendlyName, FPV0.CurrentBlip)
                                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                                            Mechanic2.SetModKit(FPV0, selectedItem.Car)
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
                        If VehicleModel = "" Then
                            TPV1 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                        Else
                            TPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        End If
                        TPV1.AddBlip()
                        TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        TPV1.CurrentBlip.Color = 17
                        TPV1.CurrentBlip.IsShortRange = True
                        SetBlipName(TPV1.FriendlyName, TPV1.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", selectedItem.Car)
                        Mechanic2.SetModKit(TPV1, selectedItem.Car)
                    Else
                        If TPV2 = Nothing Then
                            If VehicleModel = "" Then
                                TPV2 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                            Else
                                TPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            End If
                            TPV2.AddBlip()
                            TPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            TPV2.CurrentBlip.Color = 17
                            TPV2.CurrentBlip.IsShortRange = True
                            SetBlipName(TPV2.FriendlyName, TPV2.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", selectedItem.Car)
                            Mechanic2.SetModKit(TPV2, selectedItem.Car)
                        Else
                            If TPV3 = Nothing Then
                                If VehicleModel = "" Then
                                    TPV3 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                Else
                                    TPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                End If
                                TPV3.AddBlip()
                                TPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                TPV3.CurrentBlip.Color = 17
                                TPV3.CurrentBlip.IsShortRange = True
                                SetBlipName(TPV3.FriendlyName, TPV3.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", selectedItem.Car)
                                Mechanic2.SetModKit(TPV3, selectedItem.Car)
                            Else
                                If TPV4 = Nothing Then
                                    If VehicleModel = "" Then
                                        TPV4 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                    Else
                                        TPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    End If
                                    TPV4.AddBlip()
                                    TPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    TPV4.CurrentBlip.Color = 17
                                    TPV4.CurrentBlip.IsShortRange = True
                                    SetBlipName(TPV4.FriendlyName, TPV4.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                    Mechanic2.SetModKit(TPV4, selectedItem.Car)
                                Else
                                    If TPV5 = Nothing Then
                                        If VehicleModel = "" Then
                                            TPV5 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                        Else
                                            TPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        End If
                                        TPV5.AddBlip()
                                        TPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        TPV5.CurrentBlip.Color = 17
                                        TPV5.CurrentBlip.IsShortRange = True
                                        SetBlipName(TPV5.FriendlyName, TPV5.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                        Mechanic2.SetModKit(TPV5, selectedItem.Car)
                                    Else
                                        If TPV6 = Nothing Then
                                            If VehicleModel = "" Then
                                                TPV6 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                            Else
                                                TPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            End If
                                            TPV6.AddBlip()
                                            TPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            TPV6.CurrentBlip.Color = 17
                                            TPV6.CurrentBlip.IsShortRange = True
                                            SetBlipName(TPV6.FriendlyName, TPV6.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                            Mechanic2.SetModKit(TPV6, selectedItem.Car)
                                        Else
                                            If TPV7 = Nothing Then
                                                If VehicleModel = "" Then
                                                    TPV7 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                Else
                                                    TPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                End If
                                                TPV7.AddBlip()
                                                TPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                TPV7.CurrentBlip.Color = 17
                                                TPV7.CurrentBlip.IsShortRange = True
                                                SetBlipName(TPV7.FriendlyName, TPV7.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", selectedItem.Car)
                                                Mechanic2.SetModKit(TPV7, selectedItem.Car)
                                            Else
                                                If TPV8 = Nothing Then
                                                    If VehicleModel = "" Then
                                                        TPV8 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                    Else
                                                        TPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                    End If
                                                    TPV8.AddBlip()
                                                    TPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                    TPV8.CurrentBlip.Color = 17
                                                    TPV8.CurrentBlip.IsShortRange = True
                                                    SetBlipName(TPV8.FriendlyName, TPV8.CurrentBlip)
                                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                    WriteCfgValue("Active", "True", selectedItem.Car)
                                                    Mechanic2.SetModKit(TPV8, selectedItem.Car)
                                                Else
                                                    If TPV9 = Nothing Then
                                                        If VehicleModel = "" Then
                                                            TPV9 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                        Else
                                                            TPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                        End If
                                                        TPV9.AddBlip()
                                                        TPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                        TPV9.CurrentBlip.Color = 17
                                                        TPV9.CurrentBlip.IsShortRange = True
                                                        SetBlipName(TPV9.FriendlyName, TPV9.CurrentBlip)
                                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                        WriteCfgValue("Active", "True", selectedItem.Car)
                                                        Mechanic2.SetModKit(TPV9, selectedItem.Car)
                                                    Else
                                                        If TPV0 = Nothing Then
                                                            If VehicleModel = "" Then
                                                                TPV0 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                            Else
                                                                TPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                            End If
                                                            TPV0.AddBlip()
                                                            TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                            TPV0.CurrentBlip.Color = 17
                                                            TPV0.CurrentBlip.IsShortRange = True
                                                            SetBlipName(TPV0.FriendlyName, TPV0.CurrentBlip)
                                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                            WriteCfgValue("Active", "True", selectedItem.Car)
                                                            Mechanic2.SetModKit(TPV0, selectedItem.Car)
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
                ElseIf playerName = "Player3" AndAlso Active = "False" Then
                    Mechanic2.Player3_SendVehicle(selectedItem.Car, VehicleModel, VehicleHash, selectedItem, sender)
                End If
            End If
            sender.Visible = False
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GrgMoveItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            MoveMenuSelectedItem = selectedItem.Text
            MoveMenuSelectedFile = selectedItem.Car
            MoveMenuSelectedIndex = index

            If selectedItem.Text <> GarageMenuSelectedItem Then
                If IO.File.Exists(Path & GarageMenuSelectedFile) = True AndAlso IO.File.Exists(Path & MoveMenuSelectedFile) = True Then
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & "vehicle.cfg")
                    IO.File.Move(Path & MoveMenuSelectedFile, Path & GarageMenuSelectedFile)
                    IO.File.Move(Path & "vehicle.cfg", Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                Else
                    IO.File.Move(Path & GarageMenuSelectedFile, Path & MoveMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                End If
            Else
                sender.Visible = False
                GarageMenu.Visible = True
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If sender Is GarageMenu AndAlso Not selectedItem.Text = "Empty" Then
                GarageMenuSelectedItem = selectedItem.Text
                GarageMenuSelectedFile = selectedItem.Car
            End If

            If selectedItem.Text = GrgRemove Then
                Select Case GarageMenuSelectedFile
                    Case "vehicle_0.cfg"
                        If SelectedGarage = "Ten" Then TenCarGarage.veh0.Delete() Else SixCarGarage.veh0.Delete()
                    Case "vehicle_1.cfg"
                        If SelectedGarage = "Ten" Then TenCarGarage.veh1.Delete() Else SixCarGarage.veh1.Delete()
                    Case "vehicle_2.cfg"
                        If SelectedGarage = "Ten" Then TenCarGarage.veh2.Delete() Else SixCarGarage.veh2.Delete()
                    Case "vehicle_3.cfg"
                        If SelectedGarage = "Ten" Then TenCarGarage.veh3.Delete() Else SixCarGarage.veh3.Delete()
                    Case "vehicle_4.cfg"
                        If SelectedGarage = "Ten" Then TenCarGarage.veh4.Delete() Else SixCarGarage.veh4.Delete()
                    Case "vehicle_5.cfg"
                        If SelectedGarage = "Ten" Then TenCarGarage.veh5.Delete() Else SixCarGarage.veh5.Delete()
                    Case "vehicle_6.cfg"
                        TenCarGarage.veh6.Delete()
                    Case "vehicle_7.cfg"
                        TenCarGarage.veh7.Delete()
                    Case "vehicle_8.cfg"
                        TenCarGarage.veh8.Delete()
                    Case "vehicle_9.cfg"
                        TenCarGarage.veh9.Delete()
                End Select
                IO.File.Delete(Path & GarageMenuSelectedFile)
                If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                sender.Visible = False
                GarageMenu.Visible = True
            ElseIf selectedItem.Text = GrgRemoveAndDrive Then
                If SelectedGarage = "Ten" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        Dim tempVeh As Vehicle
                        playerPed.Position = TenCarGarage.lastLocationGarageOutVector
                        If ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile) = "" Then
                            tempVeh = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), TenCarGarage.lastLocationGarageOutVector.X, TenCarGarage.lastLocationGarageOutVector.Y, TenCarGarage.lastLocationGarageOutVector.Z, TenCarGarage.lastLocationGarageOutHeading, False, False)
                        Else
                            tempVeh = World.CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), TenCarGarage.lastLocationGarageOutVector)
                        End If
                        tempVeh.Heading = TenCarGarage.lastLocationGarageOutHeading
                        Mechanic2.SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                        tempVeh.MarkAsNoLongerNeeded()
                        playerPed.SetIntoVehicle(tempVeh, VehicleSeat.Driver)
                        IO.File.Delete(Path & GarageMenuSelectedFile)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        sender.Visible = False
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                        TenCarGarage.isInGarage = False
                        TenCarGarage.ShowAllHiddenMapObject()
                        UnLoadMPDLCMap()
                    End If
                ElseIf SelectedGarage = "Six" Then
                    If IO.File.Exists(Path & GarageMenuSelectedFile) Then
                        Game.FadeScreenOut(500)
                        Script.Wait(&H3E8)
                        Dim tempVeh As Vehicle
                        playerPed.Position = SixCarGarage.lastLocationGarageOutVector
                        If ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile) = "" Then
                            tempVeh = Resources.Create_Vehicle(ReadCfgValue("VehicleHash", Path & GarageMenuSelectedFile), SixCarGarage.lastLocationGarageOutVector.X, SixCarGarage.lastLocationGarageOutVector.Y, SixCarGarage.lastLocationGarageOutVector.Z, SixCarGarage.lastLocationGarageOutHeading, False, False)
                        Else
                            tempVeh = World.CreateVehicle(ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile), SixCarGarage.lastLocationGarageOutVector)
                        End If
                        tempVeh.Heading = SixCarGarage.lastLocationGarageOutHeading
                        Mechanic2.SetModKit(tempVeh, Path & GarageMenuSelectedFile)
                        tempVeh.MarkAsNoLongerNeeded()
                        playerPed.SetIntoVehicle(tempVeh, VehicleSeat.Driver)
                        IO.File.Delete(Path & GarageMenuSelectedFile)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        sender.Visible = False
                        Script.Wait(500)
                        Game.FadeScreenIn(500)
                        SixCarGarage.isInGarage = False
                        UnLoadMPDLCMap()
                    End If
                End If
            ElseIf selectedItem.Text = GrgSell Then
                Dim VehModel As String = ReadCfgValue("VehicleModel", Path & GarageMenuSelectedFile)
                Dim VehPrice As Integer = Resources.GetVehiclePrice(Path & GarageMenuSelectedFile)
                If VehPrice = 0 Then
                    UI.ShowSubtitle(GrgTooHot)
                Else
                    Select Case GarageMenuSelectedFile
                        Case "vehicle_0.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh0.Delete() Else SixCarGarage.veh0.Delete()
                        Case "vehicle_1.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh1.Delete() Else SixCarGarage.veh1.Delete()
                        Case "vehicle_2.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh2.Delete() Else SixCarGarage.veh2.Delete()
                        Case "vehicle_3.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh3.Delete() Else SixCarGarage.veh3.Delete()
                        Case "vehicle_4.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh4.Delete() Else SixCarGarage.veh4.Delete()
                        Case "vehicle_5.cfg"
                            If SelectedGarage = "Ten" Then TenCarGarage.veh5.Delete() Else SixCarGarage.veh5.Delete()
                        Case "vehicle_6.cfg"
                            TenCarGarage.veh6.Delete()
                        Case "vehicle_7.cfg"
                            TenCarGarage.veh7.Delete()
                        Case "vehicle_8.cfg"
                            TenCarGarage.veh8.Delete()
                        Case "vehicle_9.cfg"
                            TenCarGarage.veh9.Delete()
                    End Select
                    SinglePlayerApartment.player.Money = (playerCash + VehPrice)
                    CreateGarageMenu(Path)
                    IO.File.Delete(Path & GarageMenuSelectedFile)
                    If SelectedGarage = "Ten" Then TenCarGarage.LoadGarageVechicles(Path)
                    If SelectedGarage = "Six" Then SixCarGarage.LoadGarageVechicles(Path)
                    sender.Visible = False
                    GarageMenu.Visible = True
                End If
            ElseIf selectedItem.Text = GrgMove Then
                CreateMoveMenu(Path, SelectedGarage)
                sender.Visible = False
                GrgMoveMenu.Visible = True
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ItemSelectHandler6CarGarage(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If Not selectedItem.Text = "Empty" Then
                Select Case selectedItem.Car
                    Case "vehicle_0.cfg"
                        SixCarGarage.veh0.Delete()
                    Case "vehicle_1.cfg"
                        SixCarGarage.veh1.Delete()
                    Case "vehicle_2.cfg"
                        SixCarGarage.veh2.Delete()
                    Case "vehicle_3.cfg"
                        SixCarGarage.veh3.Delete()
                    Case "vehicle_4.cfg"
                        SixCarGarage.veh4.Delete()
                    Case "vehicle_5.cfg"
                        SixCarGarage.veh5.Delete()
                End Select
                IO.File.Delete(Path & selectedItem.Car)
                selectedItem.Text = "Empty"
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub GrgMoveMenuCloseHandler(sender As UIMenu)
        GarageMenu2.Visible = True
    End Sub

    Public Shared Sub MenuCloseHandler(sender As UIMenu)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
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
                If Not PPV0 = Nothing Then PPV0.Delete()
                If Not PPV1 = Nothing Then PPV1.Delete()
                If Not PPV2 = Nothing Then PPV2.Delete()
                If Not PPV3 = Nothing Then PPV3.Delete()
                If Not PPV4 = Nothing Then PPV4.Delete()
                If Not PPV5 = Nothing Then PPV5.Delete()
                If Not PPV6 = Nothing Then PPV6.Delete()
                If Not PPV7 = Nothing Then PPV7.Delete()
                If Not PPV8 = Nothing Then PPV8.Delete()
                If Not PPV9 = Nothing Then PPV9.Delete()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
