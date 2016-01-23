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
Imports SinglePlayerApartment.Mechanic
Imports PDMCarShopGUI

Public Class Mechanic2
    Inherits Script

    Public _3AltaStreetPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\"
    Public _4IntegrityPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\"
    Public HL4IntegrityPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
    Public NtConker2044Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\"
    Public NtConker2045Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\"
    Public MadWayne2113Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\"
    Public MiltonRd2117Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\"
    Public Hillcreast2862Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\"
    Public Hillcreast2868Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcreast_ave\"
    Public Hillcreast2874Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\"
    Public WildOats3655Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\"
    Public Whispymound3677Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
    Public DelPerroPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\"
    Public HLDelPerroPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
    Public DreamTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\"
    Public EclipseTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
    Public HPEclipseTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
    Public EclipseTowerPS1Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
    Public EclipseTowerPS2Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
    Public EclipseTowerPS3Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"
    Public RichardMajesticPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\"
    Public HLRichardMajesticPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\"
    Public TinselTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
    Public HLTinselTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
    Public VespucciBlvdPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
    Public WeazelPlazaPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\"

    Public Sub New()
        ReturnAllVehiclesToGarage(_3AltaStreetPath)
        ReturnAllVehiclesToGarage(_4IntegrityPath)
        ReturnAllVehiclesToGarage(HL4IntegrityPath)
        ReturnAllVehiclesToGarage(NtConker2044Path)
        ReturnAllVehiclesToGarage(NtConker2045Path)
        ReturnAllVehiclesToGarage(MadWayne2113Path)
        ReturnAllVehiclesToGarage(MiltonRd2117Path)
        ReturnAllVehiclesToGarage(Hillcreast2862Path)
        ReturnAllVehiclesToGarage(Hillcreast2868Path)
        ReturnAllVehiclesToGarage(Hillcreast2874Path)
        ReturnAllVehiclesToGarage(WildOats3655Path)
        ReturnAllVehiclesToGarage(Whispymound3677Path)
        ReturnAllVehiclesToGarage(DelPerroPath)
        ReturnAllVehiclesToGarage(HLDelPerroPath)
        ReturnAllVehiclesToGarage(DreamTowerPath)
        ReturnAllVehiclesToGarage(EclipseTowerPath)
        ReturnAllVehiclesToGarage(HPEclipseTowerPath)
        ReturnAllVehiclesToGarage(EclipseTowerPS1Path)
        ReturnAllVehiclesToGarage(EclipseTowerPS2Path)
        ReturnAllVehiclesToGarage(EclipseTowerPS3Path)
        ReturnAllVehiclesToGarage(RichardMajesticPath)
        ReturnAllVehiclesToGarage(HLRichardMajesticPath)
        ReturnAllVehiclesToGarage(TinselTowerPath)
        ReturnAllVehiclesToGarage(HLTinselTowerPath)
        ReturnAllVehiclesToGarage(VespucciBlvdPath)
        ReturnAllVehiclesToGarage(WeazelPlazaPath)

        AddHandler Tick, AddressOf OnTick
    End Sub

    Public Shared Sub Player3_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If PPV1 = Nothing Then
            If VehicleModel = "" Then
                PPV1 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
            Else
                PPV1 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
            End If
            PPV1.AddBlip()
            PPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            PPV1.CurrentBlip.Color = BlipColor.Yellow
            PPV1.CurrentBlip.IsShortRange = True
            SetBlipName(PPV1.FriendlyName, PPV1.CurrentBlip)
            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            Mechanic2.SetModKit(PPV1, SelectedItem_Car)
        Else
            If PPV2 = Nothing Then
                If VehicleModel = "" Then
                    PPV2 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                Else
                    PPV2 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                End If
                PPV2.AddBlip()
                PPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                PPV2.CurrentBlip.Color = BlipColor.Yellow
                PPV2.CurrentBlip.IsShortRange = True
                SetBlipName(PPV2.FriendlyName, PPV2.CurrentBlip)
                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                Mechanic2.SetModKit(PPV2, SelectedItem_Car)
            Else
                If PPV3 = Nothing Then
                    If VehicleModel = "" Then
                        PPV3 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                    Else
                        PPV3 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                    End If
                    PPV3.AddBlip()
                    PPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    PPV3.CurrentBlip.Color = BlipColor.Yellow
                    PPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(PPV3.FriendlyName, PPV3.CurrentBlip)
                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    Mechanic2.SetModKit(PPV3, SelectedItem_Car)
                Else
                    If PPV4 = Nothing Then
                        If VehicleModel = "" Then
                            PPV4 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                        Else
                            PPV4 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                        End If
                        PPV4.AddBlip()
                        PPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        PPV4.CurrentBlip.Color = BlipColor.Yellow
                        PPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(PPV4.FriendlyName, PPV4.CurrentBlip)
                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        Mechanic2.SetModKit(PPV4, SelectedItem_Car)
                    Else
                        If PPV5 = Nothing Then
                            If VehicleModel = "" Then
                                PPV5 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                            Else
                                PPV5 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                            End If
                            PPV5.AddBlip()
                            PPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            PPV5.CurrentBlip.Color = BlipColor.Yellow
                            PPV5.CurrentBlip.IsShortRange = True
                            SetBlipName(PPV5.FriendlyName, PPV5.CurrentBlip)
                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            Mechanic2.SetModKit(PPV5, SelectedItem_Car)
                        Else
                            If PPV6 = Nothing Then
                                If VehicleModel = "" Then
                                    PPV6 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                Else
                                    PPV6 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                End If
                                PPV6.AddBlip()
                                PPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                PPV6.CurrentBlip.Color = BlipColor.Yellow
                                PPV6.CurrentBlip.IsShortRange = True
                                SetBlipName(PPV6.FriendlyName, PPV6.CurrentBlip)
                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                Mechanic2.SetModKit(PPV6, SelectedItem_Car)
                            Else
                                If PPV7 = Nothing Then
                                    If VehicleModel = "" Then
                                        PPV7 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                    Else
                                        PPV7 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                    End If
                                    PPV7.AddBlip()
                                    PPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    PPV7.CurrentBlip.Color = BlipColor.Yellow
                                    PPV7.CurrentBlip.IsShortRange = True
                                    SetBlipName(PPV7.FriendlyName, PPV7.CurrentBlip)
                                    selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", SelectedItem_Car)
                                    Mechanic2.SetModKit(PPV7, SelectedItem_Car)
                                Else
                                    If PPV8 = Nothing Then
                                        If VehicleModel = "" Then
                                            PPV8 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                        Else
                                            PPV8 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                        End If
                                        PPV8.AddBlip()
                                        PPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        PPV8.CurrentBlip.Color = BlipColor.Yellow
                                        PPV8.CurrentBlip.IsShortRange = True
                                        SetBlipName(PPV8.FriendlyName, PPV8.CurrentBlip)
                                        selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", SelectedItem_Car)
                                        Mechanic2.SetModKit(PPV8, SelectedItem_Car)
                                    Else
                                        If PPV9 = Nothing Then
                                            If VehicleModel = "" Then
                                                PPV9 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                            Else
                                                PPV9 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                            End If
                                            PPV9.AddBlip()
                                            PPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            PPV9.CurrentBlip.Color = BlipColor.Yellow
                                            PPV9.CurrentBlip.IsShortRange = True
                                            SetBlipName(PPV9.FriendlyName, PPV9.CurrentBlip)
                                            selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", SelectedItem_Car)
                                            Mechanic2.SetModKit(PPV9, SelectedItem_Car)
                                        Else
                                            If PPV0 = Nothing Then
                                                If VehicleModel = "" Then
                                                    PPV0 = World.CreateVehicle(CInt(VehicleHash), World.GetNextPositionOnStreet(playerPed.Position))
                                                Else
                                                    PPV0 = World.CreateVehicle(VehicleModel, World.GetNextPositionOnStreet(playerPed.Position))
                                                End If
                                                PPV0.AddBlip()
                                                PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                PPV0.CurrentBlip.Color = BlipColor.Yellow
                                                PPV0.CurrentBlip.IsShortRange = True
                                                SetBlipName(PPV0.FriendlyName, PPV0.CurrentBlip)
                                                selectedItem.SetLeftBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                                Mechanic2.SetModKit(PPV0, SelectedItem_Car)
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
    End Sub

    Public Shared Sub ReturnVeh(PathDir As String)
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
        ElseIf playerName = "Player3" Then
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
        End If
    End Sub

    Public Shared Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String)
        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = ReadCfgValue("PrimaryColor", VehicleCfgFile)
        _Vehicle.SecondaryColor = ReadCfgValue("SecondaryColor", VehicleCfgFile)
        _Vehicle.PearlescentColor = ReadCfgValue("PearlescentColor", VehicleCfgFile)
        If ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomPrimaryColor = Color.FromArgb(ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile))
        If ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomSecondaryColor = Color.FromArgb(ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile))
        _Vehicle.RimColor = ReadCfgValue("RimColor", VehicleCfgFile)
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
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), True)
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
        _Vehicle.MarkAsNoLongerNeeded()
        Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, _Vehicle, True, False)
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
    End Sub

    Public Shared Sub ReturnAllVehiclesToGarage(PathDir As String)
        Try
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
        Catch ex As Exception
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If playerPed.IsInVehicle Then
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
                If Not PPV0 = Nothing AndAlso PPV0.CurrentBlip.Alpha = 0 Then
                    PPV0.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV0) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV0, True, False)
                End If
                If Not PPV1 = Nothing AndAlso PPV1.CurrentBlip.Alpha = 0 Then
                    PPV1.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV1) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV1, True, False)
                End If
                If Not PPV2 = Nothing AndAlso PPV2.CurrentBlip.Alpha = 0 Then
                    PPV2.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV2) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV2, True, False)
                End If
                If Not PPV3 = Nothing AndAlso PPV3.CurrentBlip.Alpha = 0 Then
                    PPV3.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV3) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV3, True, False)
                End If
                If Not PPV4 = Nothing AndAlso PPV4.CurrentBlip.Alpha = 0 Then
                    PPV4.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV4) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV4, True, False)
                End If
                If Not PPV5 = Nothing AndAlso PPV5.CurrentBlip.Alpha = 0 Then
                    PPV5.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV5) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV5, True, False)
                End If
                If Not PPV6 = Nothing AndAlso PPV6.CurrentBlip.Alpha = 0 Then
                    PPV6.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV6) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV6, True, False)
                End If
                If Not PPV7 = Nothing AndAlso PPV7.CurrentBlip.Alpha = 0 Then
                    PPV7.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV7) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV7, True, False)
                End If
                If Not PPV8 = Nothing AndAlso PPV8.CurrentBlip.Alpha = 0 Then
                    PPV8.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV8) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV8, True, False)
                End If
                If Not PPV9 = Nothing AndAlso PPV9.CurrentBlip.Alpha = 0 Then
                    PPV9.CurrentBlip.Alpha = 255
                    If Not Native.Function.Call(Of Boolean)(Hash.IS_ENTITY_A_MISSION_ENTITY, PPV9) Then Native.Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, PPV9, True, False)
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
End Class
