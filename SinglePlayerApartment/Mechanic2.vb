Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.Mechanic
Imports INMNativeUI
Imports SinglePlayerApartment.Resources

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
    Public BayCityAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\bay_city_ave\"
    Public BlvdDelPerroPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\blvd_del_perro\"
    Public CougarAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\cougar_ave\"
    Public HangmanAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\hangman_ave\"
    Public LasLagunas0604Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0604_las_lagunas_blvd\"
    Public LasLagunas2143Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2143_las_lagunas_blvd\"
    Public MiltonRd0184Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0184_milton_road\"
    Public PowerStPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\power_st\"
    Public ProcopioDr4401Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4401_procopio_dr\"
    Public ProcopioDr4584Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4584_procopio_dr\"
    Public ProsperityStPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\prosperity_st\"
    Public SanVitasStPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\san_vitas_st\"
    Public SouthMoMiltonPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\south_mo_milton_dr\"
    Public SouthRockford0325Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0325_south_rockford_dr\"
    Public SpanishAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\spanish_ave\"
    Public SustanciaRdPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\sustancia_rd\"
    Public TheRoyalePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\the_royale\"
    Public GrapeseedAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\grapeseed_ave\"
    Public PaletoBlvdPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\paleto_blvd\"
    Public SouthRockford0012Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\"
    Public ZancudoAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\zancudo_ave\"
    Public Shared MechanicPed As Ped

    Public Sub New()
        'New Language
        Reach10 = ReadCfgValue("Reach10", langFile)
        MechanicBill = ReadCfgValue("MechanicBill", langFile)
        'End Language

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
        ReturnAllVehiclesToGarage(BayCityAvePath)
        ReturnAllVehiclesToGarage(BlvdDelPerroPath)
        ReturnAllVehiclesToGarage(CougarAvePath)
        ReturnAllVehiclesToGarage(HangmanAvePath)
        ReturnAllVehiclesToGarage(LasLagunas0604Path)
        ReturnAllVehiclesToGarage(LasLagunas2143Path)
        ReturnAllVehiclesToGarage(MiltonRd0184Path)
        ReturnAllVehiclesToGarage(PowerStPath)
        ReturnAllVehiclesToGarage(ProcopioDr4401Path)
        ReturnAllVehiclesToGarage(ProcopioDr4584Path)
        ReturnAllVehiclesToGarage(ProsperityStPath)
        ReturnAllVehiclesToGarage(SanVitasStPath)
        ReturnAllVehiclesToGarage(SouthMoMiltonPath)
        ReturnAllVehiclesToGarage(SouthRockford0325Path)
        ReturnAllVehiclesToGarage(SpanishAvePath)
        ReturnAllVehiclesToGarage(SustanciaRdPath)
        ReturnAllVehiclesToGarage(TheRoyalePath)
        ReturnAllVehiclesToGarage(GrapeseedAvePath)
        ReturnAllVehiclesToGarage(PaletoBlvdPath)
        ReturnAllVehiclesToGarage(SouthRockford0012Path)
        ReturnAllVehiclesToGarage(ZancudoAvePath)

        AddHandler Tick, AddressOf OnTick
    End Sub

    Public Shared Sub CreateMechanicInVehicle(Vehicle As Vehicle)
        If My.Settings.VehicleSpawn = 1 Then
            MechanicPed = Vehicle.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Autoshop01SMM)
            MechanicPed.AlwaysKeepTask = True
            MechanicPed.Task.DriveTo(Vehicle, playerPed.Position, 20.0, 15.0)
            MechanicPed.DrivingStyle = DrivingStyle.Normal
        Else
            Vehicle.Position = World.GetNextPositionOnStreet(playerPed.Position)
        End If
    End Sub

    Public Shared Sub Michael_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If MPV1 = Nothing Then
            MPV1 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            MPV1.AddBlip()
            MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            MPV1.CurrentBlip.Color = BlipColor.Blue
            MPV1.CurrentBlip.IsShortRange = True
            SetBlipName(MPV1.FriendlyName, MPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(MPV1, SelectedItem_Car)
            CreateMechanicInVehicle(MPV1)
        Else
            If MPV2 = Nothing Then
                MPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                MPV2.AddBlip()
                MPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                MPV2.CurrentBlip.Color = BlipColor.Blue
                MPV2.CurrentBlip.IsShortRange = True
                SetBlipName(MPV2.FriendlyName, MPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(MPV2, SelectedItem_Car)
                CreateMechanicInVehicle(MPV2)
            Else
                If MPV3 = Nothing Then
                    MPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    MPV3.AddBlip()
                    MPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    MPV3.CurrentBlip.Color = BlipColor.Blue
                    MPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(MPV3.FriendlyName, MPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(MPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(MPV3)
                Else
                    If MPV4 = Nothing Then
                        MPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        MPV4.AddBlip()
                        MPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        MPV4.CurrentBlip.Color = BlipColor.Blue
                        MPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(MPV4.FriendlyName, MPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(MPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(MPV4)
                    Else
                        If MPV5 = Nothing Then
                            MPV5 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            MPV5.AddBlip()
                            MPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            MPV5.CurrentBlip.Color = BlipColor.Blue
                            MPV5.CurrentBlip.IsShortRange = True
                            SetBlipName(MPV5.FriendlyName, MPV5.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(MPV5, SelectedItem_Car)
                            CreateMechanicInVehicle(MPV5)
                        Else
                            If MPV6 = Nothing Then
                                MPV6 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                MPV6.AddBlip()
                                MPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                MPV6.CurrentBlip.Color = BlipColor.Blue
                                MPV6.CurrentBlip.IsShortRange = True
                                SetBlipName(MPV6.FriendlyName, MPV6.CurrentBlip)
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                SetModKit(MPV6, SelectedItem_Car)
                                CreateMechanicInVehicle(MPV6)
                            Else
                                If MPV7 = Nothing Then
                                    MPV7 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                    MPV7.AddBlip()
                                    MPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    MPV7.CurrentBlip.Color = BlipColor.Blue
                                    MPV7.CurrentBlip.IsShortRange = True
                                    SetBlipName(MPV7.FriendlyName, MPV7.CurrentBlip)
                                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", SelectedItem_Car)
                                    SetModKit(MPV7, SelectedItem_Car)
                                    CreateMechanicInVehicle(MPV7)
                                Else
                                    If MPV8 = Nothing Then
                                        MPV8 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                        MPV8.AddBlip()
                                        MPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        MPV8.CurrentBlip.Color = BlipColor.Blue
                                        MPV8.CurrentBlip.IsShortRange = True
                                        SetBlipName(MPV8.FriendlyName, MPV8.CurrentBlip)
                                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", SelectedItem_Car)
                                        SetModKit(MPV8, SelectedItem_Car)
                                        CreateMechanicInVehicle(MPV8)
                                    Else
                                        If MPV9 = Nothing Then
                                            MPV9 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                            MPV9.AddBlip()
                                            MPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            MPV9.CurrentBlip.Color = BlipColor.Blue
                                            MPV9.CurrentBlip.IsShortRange = True
                                            SetBlipName(MPV9.FriendlyName, MPV9.CurrentBlip)
                                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", SelectedItem_Car)
                                            SetModKit(MPV9, SelectedItem_Car)
                                            CreateMechanicInVehicle(MPV9)
                                        Else
                                            If MPV0 = Nothing Then
                                                MPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                                MPV0.AddBlip()
                                                MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                MPV0.CurrentBlip.Color = BlipColor.Blue
                                                MPV0.CurrentBlip.IsShortRange = True
                                                SetBlipName(MPV0.FriendlyName, MPV0.CurrentBlip)
                                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                                SetModKit(MPV0, SelectedItem_Car)
                                                CreateMechanicInVehicle(MPV0)
                                            Else
                                                sender.Visible = False
                                                UI.ShowSubtitle(Reach10)
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

    Public Shared Sub Franklin_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If FPV1 = Nothing Then
            FPV1 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            FPV1.AddBlip()
            FPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            FPV1.CurrentBlip.Color = BlipColor.Green
            FPV1.CurrentBlip.IsShortRange = True
            SetBlipName(FPV1.FriendlyName, FPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(FPV1, SelectedItem_Car)
            CreateMechanicInVehicle(FPV1)
        Else
            If FPV2 = Nothing Then
                FPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                FPV2.AddBlip()
                FPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                FPV2.CurrentBlip.Color = BlipColor.Green
                FPV2.CurrentBlip.IsShortRange = True
                SetBlipName(FPV2.FriendlyName, FPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(FPV2, SelectedItem_Car)
                CreateMechanicInVehicle(FPV2)
            Else
                If FPV3 = Nothing Then
                    FPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    FPV3.AddBlip()
                    FPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    FPV3.CurrentBlip.Color = BlipColor.Green
                    FPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(FPV3.FriendlyName, FPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(FPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(FPV3)
                Else
                    If FPV4 = Nothing Then
                        FPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        FPV4.AddBlip()
                        FPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        FPV4.CurrentBlip.Color = BlipColor.Green
                        FPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(FPV4.FriendlyName, FPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(FPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(FPV4)
                    Else
                        If FPV5 = Nothing Then
                            FPV5 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            FPV5.AddBlip()
                            FPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            FPV5.CurrentBlip.Color = BlipColor.Green
                            FPV5.CurrentBlip.IsShortRange = True
                            SetBlipName(FPV5.FriendlyName, FPV5.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(FPV5, SelectedItem_Car)
                            CreateMechanicInVehicle(FPV5)
                        Else
                            If FPV6 = Nothing Then
                                FPV6 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                FPV6.AddBlip()
                                FPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                FPV6.CurrentBlip.Color = BlipColor.Green
                                FPV6.CurrentBlip.IsShortRange = True
                                SetBlipName(FPV6.FriendlyName, FPV6.CurrentBlip)
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                SetModKit(FPV6, SelectedItem_Car)
                                CreateMechanicInVehicle(FPV6)
                            Else
                                If FPV7 = Nothing Then
                                    FPV7 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                    FPV7.AddBlip()
                                    FPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    FPV7.CurrentBlip.Color = BlipColor.Green
                                    FPV7.CurrentBlip.IsShortRange = True
                                    SetBlipName(FPV7.FriendlyName, FPV7.CurrentBlip)
                                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", SelectedItem_Car)
                                    SetModKit(FPV7, SelectedItem_Car)
                                    CreateMechanicInVehicle(FPV7)
                                Else
                                    If FPV8 = Nothing Then
                                        FPV8 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                        FPV8.AddBlip()
                                        FPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        FPV8.CurrentBlip.Color = BlipColor.Green
                                        FPV8.CurrentBlip.IsShortRange = True
                                        SetBlipName(FPV8.FriendlyName, FPV8.CurrentBlip)
                                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", SelectedItem_Car)
                                        SetModKit(FPV8, SelectedItem_Car)
                                        CreateMechanicInVehicle(FPV8)
                                    Else
                                        If FPV9 = Nothing Then
                                            FPV9 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                            FPV9.AddBlip()
                                            FPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            FPV9.CurrentBlip.Color = BlipColor.Green
                                            FPV9.CurrentBlip.IsShortRange = True
                                            SetBlipName(FPV9.FriendlyName, FPV9.CurrentBlip)
                                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", SelectedItem_Car)
                                            SetModKit(FPV9, SelectedItem_Car)
                                            CreateMechanicInVehicle(FPV9)
                                        Else
                                            If FPV0 = Nothing Then
                                                FPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                                FPV0.AddBlip()
                                                FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                FPV0.CurrentBlip.Color = BlipColor.Green
                                                FPV0.CurrentBlip.IsShortRange = True
                                                SetBlipName(FPV0.FriendlyName, FPV0.CurrentBlip)
                                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                                SetModKit(FPV0, SelectedItem_Car)
                                                CreateMechanicInVehicle(FPV0)
                                            Else
                                                sender.Visible = False
                                                UI.ShowSubtitle(Reach10)
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

    Public Shared Sub Trevor_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If TPV1 = Nothing Then
            TPV1 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            TPV1.AddBlip()
            TPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            TPV1.CurrentBlip.Color = 17
            TPV1.CurrentBlip.IsShortRange = True
            SetBlipName(TPV1.FriendlyName, TPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(TPV1, SelectedItem_Car)
            CreateMechanicInVehicle(TPV1)
        Else
            If TPV2 = Nothing Then
                TPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                TPV2.AddBlip()
                TPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                TPV2.CurrentBlip.Color = 17
                TPV2.CurrentBlip.IsShortRange = True
                SetBlipName(TPV2.FriendlyName, TPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(TPV2, SelectedItem_Car)
                CreateMechanicInVehicle(TPV2)
            Else
                If TPV3 = Nothing Then
                    TPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    TPV3.AddBlip()
                    TPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    TPV3.CurrentBlip.Color = 17
                    TPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(TPV3.FriendlyName, TPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(TPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(TPV3)
                Else
                    If TPV4 = Nothing Then
                        TPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        TPV4.AddBlip()
                        TPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        TPV4.CurrentBlip.Color = 17
                        TPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(TPV4.FriendlyName, TPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(TPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(TPV4)
                    Else
                        If TPV5 = Nothing Then
                            TPV5 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            TPV5.AddBlip()
                            TPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            TPV5.CurrentBlip.Color = 17
                            TPV5.CurrentBlip.IsShortRange = True
                            SetBlipName(TPV5.FriendlyName, TPV5.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(TPV5, SelectedItem_Car)
                            CreateMechanicInVehicle(TPV5)
                        Else
                            If TPV6 = Nothing Then
                                TPV6 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                TPV6.AddBlip()
                                TPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                TPV6.CurrentBlip.Color = 17
                                TPV6.CurrentBlip.IsShortRange = True
                                SetBlipName(TPV6.FriendlyName, TPV6.CurrentBlip)
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                SetModKit(TPV6, SelectedItem_Car)
                                CreateMechanicInVehicle(TPV6)
                            Else
                                If TPV7 = Nothing Then
                                    TPV7 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                    TPV7.AddBlip()
                                    TPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    TPV7.CurrentBlip.Color = 17
                                    TPV7.CurrentBlip.IsShortRange = True
                                    SetBlipName(TPV7.FriendlyName, TPV7.CurrentBlip)
                                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", SelectedItem_Car)
                                    SetModKit(TPV7, SelectedItem_Car)
                                    CreateMechanicInVehicle(TPV7)
                                Else
                                    If TPV8 = Nothing Then
                                        TPV8 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                        TPV8.AddBlip()
                                        TPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        TPV8.CurrentBlip.Color = 17
                                        TPV8.CurrentBlip.IsShortRange = True
                                        SetBlipName(TPV8.FriendlyName, TPV8.CurrentBlip)
                                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", SelectedItem_Car)
                                        SetModKit(TPV8, SelectedItem_Car)
                                        CreateMechanicInVehicle(TPV8)
                                    Else
                                        If TPV9 = Nothing Then
                                            TPV9 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                            TPV9.AddBlip()
                                            TPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            TPV9.CurrentBlip.Color = 17
                                            TPV9.CurrentBlip.IsShortRange = True
                                            SetBlipName(TPV9.FriendlyName, TPV9.CurrentBlip)
                                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", SelectedItem_Car)
                                            SetModKit(TPV9, SelectedItem_Car)
                                            CreateMechanicInVehicle(TPV9)
                                        Else
                                            If TPV0 = Nothing Then
                                                TPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                                TPV0.AddBlip()
                                                TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                TPV0.CurrentBlip.Color = 17
                                                TPV0.CurrentBlip.IsShortRange = True
                                                SetBlipName(TPV0.FriendlyName, TPV0.CurrentBlip)
                                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                                SetModKit(TPV0, SelectedItem_Car)
                                                CreateMechanicInVehicle(TPV0)
                                            Else
                                                sender.Visible = False
                                                UI.ShowSubtitle(Reach10)
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

    Public Shared Sub Player3_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If PPV1 = Nothing Then
            PPV1 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            PPV1.AddBlip()
            PPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            PPV1.CurrentBlip.Color = BlipColor.Yellow
            PPV1.CurrentBlip.IsShortRange = True
            SetBlipName(PPV1.FriendlyName, PPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(PPV1, SelectedItem_Car)
            CreateMechanicInVehicle(PPV1)
        Else
            If PPV2 = Nothing Then
                PPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                PPV2.AddBlip()
                PPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                PPV2.CurrentBlip.Color = BlipColor.Yellow
                PPV2.CurrentBlip.IsShortRange = True
                SetBlipName(PPV2.FriendlyName, PPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(PPV2, SelectedItem_Car)
                CreateMechanicInVehicle(PPV2)
            Else
                If PPV3 = Nothing Then
                    PPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    PPV3.AddBlip()
                    PPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    PPV3.CurrentBlip.Color = BlipColor.Yellow
                    PPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(PPV3.FriendlyName, PPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(PPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(PPV3)
                Else
                    If PPV4 = Nothing Then
                        PPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        PPV4.AddBlip()
                        PPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        PPV4.CurrentBlip.Color = BlipColor.Yellow
                        PPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(PPV4.FriendlyName, PPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(PPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(PPV4)
                    Else
                        If PPV5 = Nothing Then
                            PPV5 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            PPV5.AddBlip()
                            PPV5.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            PPV5.CurrentBlip.Color = BlipColor.Yellow
                            PPV5.CurrentBlip.IsShortRange = True
                            SetBlipName(PPV5.FriendlyName, PPV5.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(PPV5, SelectedItem_Car)
                            CreateMechanicInVehicle(PPV5)
                        Else
                            If PPV6 = Nothing Then
                                PPV6 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                PPV6.AddBlip()
                                PPV6.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                PPV6.CurrentBlip.Color = BlipColor.Yellow
                                PPV6.CurrentBlip.IsShortRange = True
                                SetBlipName(PPV6.FriendlyName, PPV6.CurrentBlip)
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                SetModKit(PPV6, SelectedItem_Car)
                                CreateMechanicInVehicle(PPV6)
                            Else
                                If PPV7 = Nothing Then
                                    PPV7 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                    PPV7.AddBlip()
                                    PPV7.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                    PPV7.CurrentBlip.Color = BlipColor.Yellow
                                    PPV7.CurrentBlip.IsShortRange = True
                                    SetBlipName(PPV7.FriendlyName, PPV7.CurrentBlip)
                                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                    WriteCfgValue("Active", "True", SelectedItem_Car)
                                    SetModKit(PPV7, SelectedItem_Car)
                                    CreateMechanicInVehicle(PPV7)
                                Else
                                    If PPV8 = Nothing Then
                                        PPV8 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                        PPV8.AddBlip()
                                        PPV8.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                        PPV8.CurrentBlip.Color = BlipColor.Yellow
                                        PPV8.CurrentBlip.IsShortRange = True
                                        SetBlipName(PPV8.FriendlyName, PPV8.CurrentBlip)
                                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                        WriteCfgValue("Active", "True", SelectedItem_Car)
                                        SetModKit(PPV8, SelectedItem_Car)
                                        CreateMechanicInVehicle(PPV8)
                                    Else
                                        If PPV9 = Nothing Then
                                            PPV9 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                            PPV9.AddBlip()
                                            PPV9.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                            PPV9.CurrentBlip.Color = BlipColor.Yellow
                                            PPV9.CurrentBlip.IsShortRange = True
                                            SetBlipName(PPV9.FriendlyName, PPV9.CurrentBlip)
                                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                            WriteCfgValue("Active", "True", SelectedItem_Car)
                                            SetModKit(PPV9, SelectedItem_Car)
                                            CreateMechanicInVehicle(PPV9)
                                        Else
                                            If PPV0 = Nothing Then
                                                PPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                                                PPV0.AddBlip()
                                                PPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                                                PPV0.CurrentBlip.Color = BlipColor.Yellow
                                                PPV0.CurrentBlip.IsShortRange = True
                                                SetBlipName(PPV0.FriendlyName, PPV0.CurrentBlip)
                                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                                WriteCfgValue("Active", "True", SelectedItem_Car)
                                                SetModKit(PPV0, SelectedItem_Car)
                                                CreateMechanicInVehicle(PPV0)
                                            Else
                                                sender.Visible = False
                                                UI.ShowSubtitle(Reach10)
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
        Wait(&H3E8)
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
        Wait(500)
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
            MPV0 = Nothing
            MPV1 = Nothing
            MPV2 = Nothing
            MPV3 = Nothing
            MPV4 = Nothing
            MPV5 = Nothing
            MPV6 = Nothing
            MPV7 = Nothing
            MPV8 = Nothing
            MPV9 = Nothing
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
            FPV0 = Nothing
            FPV1 = Nothing
            FPV2 = Nothing
            FPV3 = Nothing
            FPV4 = Nothing
            FPV5 = Nothing
            FPV6 = Nothing
            FPV7 = Nothing
            FPV8 = Nothing
            FPV9 = Nothing
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
            TPV0 = Nothing
            TPV1 = Nothing
            TPV2 = Nothing
            TPV3 = Nothing
            TPV4 = Nothing
            TPV5 = Nothing
            TPV6 = Nothing
            TPV7 = Nothing
            TPV8 = Nothing
            TPV9 = Nothing
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
            PPV0 = Nothing
            PPV1 = Nothing
            PPV2 = Nothing
            PPV3 = Nothing
            PPV4 = Nothing
            PPV5 = Nothing
            PPV6 = Nothing
            PPV7 = Nothing
            PPV8 = Nothing
            PPV9 = Nothing
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
        _Vehicle.SetMod(VehicleMod.Engine, ReadCfgValue("Engine", VehicleCfgFile), False)
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
        'Added on v1.3.4
        'Fixed on v1.3.4.2
        If My.Settings.HasLowriderUpdate = True Then Native.Function.Call(&H6089CDF6A57F326C, _Vehicle.Handle, CInt(ReadCfgValue("DashboardColor", VehicleCfgFile)))
        If My.Settings.HasLowriderUpdate = True Then Native.Function.Call(&HF40DD601A65F7F19UL, _Vehicle.Handle, CInt(ReadCfgValue("TrimColor", VehicleCfgFile)))
        'End of Added on v1.3.4
        _Vehicle.IsPersistent = True
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
                    If MPV0.IsPersistent = False Then MPV0.IsPersistent = True
                End If
                If Not MPV1 = Nothing AndAlso MPV1.CurrentBlip.Alpha = 0 Then
                    MPV1.CurrentBlip.Alpha = 255
                    If MPV1.IsPersistent = False Then MPV1.IsPersistent = True
                End If
                If Not MPV2 = Nothing AndAlso MPV2.CurrentBlip.Alpha = 0 Then
                    MPV2.CurrentBlip.Alpha = 255
                    If MPV2.IsPersistent = False Then MPV2.IsPersistent = True
                End If
                If Not MPV3 = Nothing AndAlso MPV3.CurrentBlip.Alpha = 0 Then
                    MPV3.CurrentBlip.Alpha = 255
                    If MPV3.IsPersistent = False Then MPV3.IsPersistent = True
                End If
                If Not MPV4 = Nothing AndAlso MPV4.CurrentBlip.Alpha = 0 Then
                    MPV4.CurrentBlip.Alpha = 255
                    If MPV4.IsPersistent = False Then MPV4.IsPersistent = True
                End If
                If Not MPV5 = Nothing AndAlso MPV5.CurrentBlip.Alpha = 0 Then
                    MPV5.CurrentBlip.Alpha = 255
                    If MPV5.IsPersistent = False Then MPV5.IsPersistent = True
                End If
                If Not MPV6 = Nothing AndAlso MPV6.CurrentBlip.Alpha = 0 Then
                    MPV6.CurrentBlip.Alpha = 255
                    If MPV6.IsPersistent = False Then MPV6.IsPersistent = True
                End If
                If Not MPV7 = Nothing AndAlso MPV7.CurrentBlip.Alpha = 0 Then
                    MPV7.CurrentBlip.Alpha = 255
                    If MPV7.IsPersistent = False Then MPV7.IsPersistent = True
                End If
                If Not MPV8 = Nothing AndAlso MPV8.CurrentBlip.Alpha = 0 Then
                    MPV8.CurrentBlip.Alpha = 255
                    If MPV8.IsPersistent = False Then MPV8.IsPersistent = True
                End If
                If Not MPV9 = Nothing AndAlso MPV9.CurrentBlip.Alpha = 0 Then
                    MPV9.CurrentBlip.Alpha = 255
                    If MPV9.IsPersistent = False Then MPV9.IsPersistent = True
                End If
                If Not MPV = Nothing AndAlso MPV.CurrentBlip.Alpha = 0 Then
                    MPV.CurrentBlip.Alpha = 255
                    If MPV.IsPersistent = False Then MPV9.IsPersistent = True
                End If
                If Not FPV0 = Nothing AndAlso FPV0.CurrentBlip.Alpha = 0 Then
                    FPV0.CurrentBlip.Alpha = 255
                    If FPV0.IsPersistent = False Then FPV0.IsPersistent = True
                End If
                If Not FPV1 = Nothing AndAlso FPV1.CurrentBlip.Alpha = 0 Then
                    FPV1.CurrentBlip.Alpha = 255
                    If FPV1.IsPersistent = False Then FPV1.IsPersistent = True
                End If
                If Not FPV2 = Nothing AndAlso FPV2.CurrentBlip.Alpha = 0 Then
                    FPV2.CurrentBlip.Alpha = 255
                    If FPV2.IsPersistent = False Then FPV2.IsPersistent = True
                End If
                If Not FPV3 = Nothing AndAlso FPV3.CurrentBlip.Alpha = 0 Then
                    FPV3.CurrentBlip.Alpha = 255
                    If FPV3.IsPersistent = False Then FPV3.IsPersistent = True
                End If
                If Not FPV4 = Nothing AndAlso FPV4.CurrentBlip.Alpha = 0 Then
                    FPV4.CurrentBlip.Alpha = 255
                    If FPV4.IsPersistent = False Then FPV4.IsPersistent = True
                End If
                If Not FPV5 = Nothing AndAlso FPV5.CurrentBlip.Alpha = 0 Then
                    FPV5.CurrentBlip.Alpha = 255
                    If FPV5.IsPersistent = False Then FPV5.IsPersistent = True
                End If
                If Not FPV6 = Nothing AndAlso FPV6.CurrentBlip.Alpha = 0 Then
                    FPV6.CurrentBlip.Alpha = 255
                    If FPV6.IsPersistent = False Then FPV6.IsPersistent = True
                End If
                If Not FPV7 = Nothing AndAlso FPV7.CurrentBlip.Alpha = 0 Then
                    FPV7.CurrentBlip.Alpha = 255
                    If FPV7.IsPersistent = False Then FPV7.IsPersistent = True
                End If
                If Not FPV8 = Nothing AndAlso FPV8.CurrentBlip.Alpha = 0 Then
                    FPV8.CurrentBlip.Alpha = 255
                    If FPV8.IsPersistent = False Then FPV8.IsPersistent = True
                End If
                If Not FPV9 = Nothing AndAlso FPV9.CurrentBlip.Alpha = 0 Then
                    FPV9.CurrentBlip.Alpha = 255
                    If FPV9.IsPersistent = False Then FPV9.IsPersistent = True
                End If
                If Not FPV = Nothing AndAlso FPV.CurrentBlip.Alpha = 0 Then
                    FPV.CurrentBlip.Alpha = 255
                    If FPV.IsPersistent = False Then FPV.IsPersistent = True
                End If
                If Not TPV0 = Nothing AndAlso TPV0.CurrentBlip.Alpha = 0 Then
                    TPV0.CurrentBlip.Alpha = 255
                    If TPV0.IsPersistent = False Then TPV0.IsPersistent = True
                End If
                If Not TPV1 = Nothing AndAlso TPV1.CurrentBlip.Alpha = 0 Then
                    TPV1.CurrentBlip.Alpha = 255
                    If TPV1.IsPersistent = False Then TPV1.IsPersistent = True
                End If
                If Not TPV2 = Nothing AndAlso TPV2.CurrentBlip.Alpha = 0 Then
                    TPV2.CurrentBlip.Alpha = 255
                    If TPV2.IsPersistent = False Then TPV2.IsPersistent = True
                End If
                If Not TPV3 = Nothing AndAlso TPV3.CurrentBlip.Alpha = 0 Then
                    TPV3.CurrentBlip.Alpha = 255
                    If TPV3.IsPersistent = False Then TPV3.IsPersistent = True
                End If
                If Not TPV4 = Nothing AndAlso TPV4.CurrentBlip.Alpha = 0 Then
                    TPV4.CurrentBlip.Alpha = 255
                    If TPV4.IsPersistent = False Then TPV4.IsPersistent = True
                End If
                If Not TPV5 = Nothing AndAlso TPV5.CurrentBlip.Alpha = 0 Then
                    TPV5.CurrentBlip.Alpha = 255
                    If TPV5.IsPersistent = False Then TPV5.IsPersistent = True
                End If
                If Not TPV6 = Nothing AndAlso TPV6.CurrentBlip.Alpha = 0 Then
                    TPV6.CurrentBlip.Alpha = 255
                    If TPV6.IsPersistent = False Then TPV6.IsPersistent = True
                End If
                If Not TPV7 = Nothing AndAlso TPV7.CurrentBlip.Alpha = 0 Then
                    TPV7.CurrentBlip.Alpha = 255
                    If TPV7.IsPersistent = False Then TPV7.IsPersistent = True
                End If
                If Not TPV8 = Nothing AndAlso TPV8.CurrentBlip.Alpha = 0 Then
                    TPV8.CurrentBlip.Alpha = 255
                    If TPV8.IsPersistent = False Then TPV8.IsPersistent = True
                End If
                If Not TPV9 = Nothing AndAlso TPV9.CurrentBlip.Alpha = 0 Then
                    TPV9.CurrentBlip.Alpha = 255
                    If TPV9.IsPersistent = False Then TPV9.IsPersistent = True
                End If
                If Not TPV = Nothing AndAlso TPV.CurrentBlip.Alpha = 0 Then
                    TPV.CurrentBlip.Alpha = 255
                    If TPV.IsPersistent = False Then TPV.IsPersistent = True
                End If
                If Not PPV0 = Nothing AndAlso PPV0.CurrentBlip.Alpha = 0 Then
                    PPV0.CurrentBlip.Alpha = 255
                    If PPV0.IsPersistent = False Then PPV0.IsPersistent = True
                End If
                If Not PPV1 = Nothing AndAlso PPV1.CurrentBlip.Alpha = 0 Then
                    PPV1.CurrentBlip.Alpha = 255
                    If PPV1.IsPersistent = False Then PPV1.IsPersistent = True
                End If
                If Not PPV2 = Nothing AndAlso PPV2.CurrentBlip.Alpha = 0 Then
                    PPV2.CurrentBlip.Alpha = 255
                    If PPV2.IsPersistent = False Then PPV2.IsPersistent = True
                End If
                If Not PPV3 = Nothing AndAlso PPV3.CurrentBlip.Alpha = 0 Then
                    PPV3.CurrentBlip.Alpha = 255
                    If PPV3.IsPersistent = False Then PPV3.IsPersistent = True
                End If
                If Not PPV4 = Nothing AndAlso PPV4.CurrentBlip.Alpha = 0 Then
                    PPV4.CurrentBlip.Alpha = 255
                    If PPV4.IsPersistent = False Then PPV4.IsPersistent = True
                End If
                If Not PPV5 = Nothing AndAlso PPV5.CurrentBlip.Alpha = 0 Then
                    PPV5.CurrentBlip.Alpha = 255
                    If PPV5.IsPersistent = False Then PPV5.IsPersistent = True
                End If
                If Not PPV6 = Nothing AndAlso PPV6.CurrentBlip.Alpha = 0 Then
                    PPV6.CurrentBlip.Alpha = 255
                    If PPV6.IsPersistent = False Then PPV6.IsPersistent = True
                End If
                If Not PPV7 = Nothing AndAlso PPV7.CurrentBlip.Alpha = 0 Then
                    PPV7.CurrentBlip.Alpha = 255
                    If PPV7.IsPersistent = False Then PPV7.IsPersistent = True
                End If
                If Not PPV8 = Nothing AndAlso PPV8.CurrentBlip.Alpha = 0 Then
                    PPV8.CurrentBlip.Alpha = 255
                    If PPV8.IsPersistent = False Then PPV8.IsPersistent = True
                End If
                If Not PPV9 = Nothing AndAlso PPV9.CurrentBlip.Alpha = 0 Then
                    PPV9.CurrentBlip.Alpha = 255
                    If PPV9.IsPersistent = False Then PPV9.IsPersistent = True
                End If
                If Not PPV = Nothing AndAlso PPV.CurrentBlip.Alpha = 0 Then
                    PPV.CurrentBlip.Alpha = 255
                    If PPV.IsPersistent = False Then PPV.IsPersistent = True
                End If
                If Not MPV = Nothing AndAlso MPV.CurrentBlip.Sprite = BlipSprite.Standard Then

                    If MPV.ClassType = VehicleClass.Boats Then
                        MPV.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf MPV.ClassType = VehicleClass.Helicopters Then
                        MPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf MPV.ClassType = VehicleClass.Utility
                        MPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf MPV.ClassType = VehicleClass.Planes Then
                        MPV.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf MPV.ClassType = VehicleClass.Military Then
                        MPV.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        MPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    MPV.CurrentBlip.Color = BlipColor.Blue
                    SetBlipName(MPV.FriendlyName, MPV.CurrentBlip)
                End If
                If Not FPV = Nothing AndAlso FPV.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If FPV.ClassType = VehicleClass.Boats Then
                        FPV.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf FPV.ClassType = VehicleClass.Helicopters Then
                        FPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf FPV.ClassType = VehicleClass.Utility
                        FPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf FPV.ClassType = VehicleClass.Planes Then
                        FPV.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf FPV.ClassType = VehicleClass.Military Then
                        FPV.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        FPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    FPV.CurrentBlip.Color = BlipColor.Green
                    SetBlipName(FPV.FriendlyName, FPV.CurrentBlip)
                End If
                If Not TPV = Nothing AndAlso TPV.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If TPV.ClassType = VehicleClass.Boats Then
                        TPV.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf TPV.ClassType = VehicleClass.Helicopters Then
                        TPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf TPV.ClassType = VehicleClass.Utility
                        TPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf TPV.ClassType = VehicleClass.Planes Then
                        TPV.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf TPV.ClassType = VehicleClass.Military Then
                        TPV.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        TPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    TPV.CurrentBlip.Color = 17
                    SetBlipName(TPV.FriendlyName, TPV.CurrentBlip)
                End If
                If Not PPV = Nothing AndAlso PPV.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If PPV.ClassType = VehicleClass.Boats Then
                        PPV.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf PPV.ClassType = VehicleClass.Helicopters Then
                        PPV.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf PPV.ClassType = VehicleClass.Utility
                        PPV.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf PPV.ClassType = VehicleClass.Planes Then
                        PPV.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf PPV.ClassType = VehicleClass.Military Then
                        PPV.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        PPV.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    PPV.CurrentBlip.Color = BlipColor.Yellow
                    SetBlipName(PPV.FriendlyName, PPV.CurrentBlip)
                End If
            End If
            If Not MPV = Nothing AndAlso World.GetDistance(playerPed.Position, MPV.Position) < 50.0 Then
                MPV.FreezePosition = False
            ElseIf Not MPV = Nothing AndAlso World.GetDistance(playerPed.Position, MPV.Position) > 50.0 Then
                MPV.FreezePosition = True
            End If
            If Not FPV = Nothing AndAlso World.GetDistance(playerPed.Position, FPV.Position) < 50.0 Then
                FPV.FreezePosition = False
            ElseIf Not FPV = Nothing AndAlso World.GetDistance(playerPed.Position, FPV.Position) > 50.0 Then
                FPV.FreezePosition = True
            End If
            If Not TPV = Nothing AndAlso World.GetDistance(playerPed.Position, TPV.Position) < 50.0 Then
                TPV.FreezePosition = False
            ElseIf Not TPV = Nothing AndAlso World.GetDistance(playerPed.Position, TPV.Position) > 50.0 Then
                TPV.FreezePosition = True
            End If
            If Not PPV = Nothing AndAlso World.GetDistance(playerPed.Position, PPV.Position) < 50.0 Then
                PPV.FreezePosition = False
            ElseIf Not PPV = Nothing AndAlso World.GetDistance(playerPed.Position, PPV.Position) > 50.0 Then
                PPV.FreezePosition = True
            End If

            If Native.Function.Call(Of Integer)(Hash.GET_CLOCK_HOURS) = 2 AndAlso Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MINUTES) = 0 AndAlso Native.Function.Call(Of Integer)(Hash.GET_CLOCK_SECONDS) = 0 Then
                SinglePlayerApartment.player.Money = (playerCash - 100)
                UI.Notify(MechanicBill)
            End If

            If Not MechanicPed = Nothing AndAlso My.Settings.VehicleSpawn = 1 Then
                If MechanicPed.Position.DistanceTo(playerPed.Position) < 5.0 AndAlso MechanicPed.IsInVehicle Then
                    MechanicPed.Task.LeaveVehicle()
                    MechanicPed.AlwaysKeepTask = False
                ElseIf MechanicPed.Position.DistanceTo(playerPed.Position) < 10.0 AndAlso Not MechanicPed.IsInVehicle Then
                    MechanicPed.Task.RunTo(World.GetNextPositionOnSidewalk(playerPed.Position.Around(100.0)))
                ElseIf MechanicPed.Position.DistanceTo(playerPed.Position) > 500.0 Then
                    MechanicPed.Delete()
                End If
            End If

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub Dispose(A_0 As Boolean)
        If (A_0) Then
            Try
                If Not MechanicPed = Nothing Then MechanicPed.Delete()
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
