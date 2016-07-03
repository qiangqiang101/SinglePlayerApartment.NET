Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.Mechanic
Imports INMNativeUI
Imports SinglePlayerApartment.Resources
Imports GTA.Math
Imports SinglePlayerApartment.INMNative

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
        Insurance1 = ReadCfgValue("InsuranceLineOne", langFile)
        Insurance2 = ReadCfgValue("InsuranceLineTwo", langFile)
        Insurance3 = ReadCfgValue("InsuranceLineThree", langFile)
        Insurance4 = ReadCfgValue("InsuranceLineFour", langFile)
        MorsMutual = ReadCfgValue("MorsMutual", langFile)
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
            'MechanicPed.AlwaysKeepTask = True
            DriveTo(MechanicPed, Vehicle, playerPed.Position, 20.0, 15.0)
            MechanicPed.DrivingStyle = DrivingStyle.Normal
        Else
            Wait(5000)
            Vehicle.Position = World.GetNextPositionOnStreet(playerPed.Position)
        End If
    End Sub

    Public Shared Sub Michael_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
        If MPV1 = Nothing Then
            MPV1 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
            MPV1.AddBlip()
            MPV1.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
            MPV1.CurrentBlip.Color = BlipColor2.Michael
            MPV1.CurrentBlip.IsShortRange = True
            SetBlipName(MPV1.FriendlyName, MPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(MPV1, SelectedItem_Car)
            CreateMechanicInVehicle(MPV1)
            MVDict.Add(MD5Gen(MPV1.DisplayName & MPV1.NumberPlate), SelectedItem_Car)
        Else
            If MPV2 = Nothing Then
                MPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                MPV2.AddBlip()
                MPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                MPV2.CurrentBlip.Color = BlipColor2.Michael
                MPV2.CurrentBlip.IsShortRange = True
                SetBlipName(MPV2.FriendlyName, MPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(MPV2, SelectedItem_Car)
                CreateMechanicInVehicle(MPV2)
                MVDict.Add(MD5Gen(MPV2.DisplayName & MPV2.NumberPlate), SelectedItem_Car)
            Else
                If MPV3 = Nothing Then
                    MPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    MPV3.AddBlip()
                    MPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    MPV3.CurrentBlip.Color = BlipColor2.Michael
                    MPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(MPV3.FriendlyName, MPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(MPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(MPV3)
                    MVDict.Add(MD5Gen(MPV3.DisplayName & MPV3.NumberPlate), SelectedItem_Car)
                Else
                    If MPV4 = Nothing Then
                        MPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        MPV4.AddBlip()
                        MPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        MPV4.CurrentBlip.Color = BlipColor2.Michael
                        MPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(MPV4.FriendlyName, MPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(MPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(MPV4)
                        MVDict.Add(MD5Gen(MPV4.DisplayName & MPV4.NumberPlate), SelectedItem_Car)
                    Else
                        If MPV0 = Nothing Then
                            MPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            MPV0.AddBlip()
                            MPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            MPV0.CurrentBlip.Color = BlipColor2.Michael
                            MPV0.CurrentBlip.IsShortRange = True
                            SetBlipName(MPV0.FriendlyName, MPV0.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(MPV0, SelectedItem_Car)
                            CreateMechanicInVehicle(MPV0)
                            MVDict.Add(MD5Gen(MPV0.DisplayName & MPV0.NumberPlate), SelectedItem_Car)
                        Else
                            sender.Visible = False
                            UI.ShowSubtitle(Reach10)
                            Exit Sub
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
            FPV1.CurrentBlip.Color = BlipColor2.Franklin
            FPV1.CurrentBlip.IsShortRange = True
            SetBlipName(FPV1.FriendlyName, FPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(FPV1, SelectedItem_Car)
            CreateMechanicInVehicle(FPV1)
            FVDict.Add(MD5Gen(FPV1.DisplayName & FPV1.NumberPlate), SelectedItem_Car)
        Else
            If FPV2 = Nothing Then
                FPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                FPV2.AddBlip()
                FPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                FPV2.CurrentBlip.Color = BlipColor2.Franklin
                FPV2.CurrentBlip.IsShortRange = True
                SetBlipName(FPV2.FriendlyName, FPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(FPV2, SelectedItem_Car)
                CreateMechanicInVehicle(FPV2)
                FVDict.Add(MD5Gen(FPV2.DisplayName & FPV2.NumberPlate), SelectedItem_Car)
            Else
                If FPV3 = Nothing Then
                    FPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    FPV3.AddBlip()
                    FPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    FPV3.CurrentBlip.Color = BlipColor2.Franklin
                    FPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(FPV3.FriendlyName, FPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(FPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(FPV3)
                    FVDict.Add(MD5Gen(FPV3.DisplayName & FPV3.NumberPlate), SelectedItem_Car)
                Else
                    If FPV4 = Nothing Then
                        FPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        FPV4.AddBlip()
                        FPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        FPV4.CurrentBlip.Color = BlipColor2.Franklin
                        FPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(FPV4.FriendlyName, FPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(FPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(FPV4)
                        FVDict.Add(MD5Gen(FPV4.DisplayName & FPV4.NumberPlate), SelectedItem_Car)
                    Else
                        If FPV0 = Nothing Then
                            FPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            FPV0.AddBlip()
                            FPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            FPV0.CurrentBlip.Color = BlipColor2.Franklin
                            FPV0.CurrentBlip.IsShortRange = True
                            SetBlipName(FPV0.FriendlyName, FPV0.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(FPV0, SelectedItem_Car)
                            CreateMechanicInVehicle(FPV0)
                            FVDict.Add(MD5Gen(FPV0.DisplayName & FPV0.NumberPlate), SelectedItem_Car)
                        Else
                            sender.Visible = False
                            UI.ShowSubtitle(Reach10)
                            Exit Sub
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
            TPV1.CurrentBlip.Color = BlipColor2.Trevor
            TPV1.CurrentBlip.IsShortRange = True
            SetBlipName(TPV1.FriendlyName, TPV1.CurrentBlip)
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            WriteCfgValue("Active", "True", SelectedItem_Car)
            SetModKit(TPV1, SelectedItem_Car)
            CreateMechanicInVehicle(TPV1)
            TVDict.Add(MD5Gen(TPV1.DisplayName & TPV1.NumberPlate), SelectedItem_Car)
        Else
            If TPV2 = Nothing Then
                TPV2 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                TPV2.AddBlip()
                TPV2.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                TPV2.CurrentBlip.Color = BlipColor2.Trevor
                TPV2.CurrentBlip.IsShortRange = True
                SetBlipName(TPV2.FriendlyName, TPV2.CurrentBlip)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                WriteCfgValue("Active", "True", SelectedItem_Car)
                SetModKit(TPV2, SelectedItem_Car)
                CreateMechanicInVehicle(TPV2)
                TVDict.Add(MD5Gen(TPV2.DisplayName & TPV2.NumberPlate), SelectedItem_Car)
            Else
                If TPV3 = Nothing Then
                    TPV3 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                    TPV3.AddBlip()
                    TPV3.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    TPV3.CurrentBlip.Color = BlipColor2.Trevor
                    TPV3.CurrentBlip.IsShortRange = True
                    SetBlipName(TPV3.FriendlyName, TPV3.CurrentBlip)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    WriteCfgValue("Active", "True", SelectedItem_Car)
                    SetModKit(TPV3, SelectedItem_Car)
                    CreateMechanicInVehicle(TPV3)
                    TVDict.Add(MD5Gen(TPV3.DisplayName & TPV3.NumberPlate), SelectedItem_Car)
                Else
                    If TPV4 = Nothing Then
                        TPV4 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                        TPV4.AddBlip()
                        TPV4.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        TPV4.CurrentBlip.Color = BlipColor2.Trevor
                        TPV4.CurrentBlip.IsShortRange = True
                        SetBlipName(TPV4.FriendlyName, TPV4.CurrentBlip)
                        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        WriteCfgValue("Active", "True", SelectedItem_Car)
                        SetModKit(TPV4, SelectedItem_Car)
                        CreateMechanicInVehicle(TPV4)
                        TVDict.Add(MD5Gen(TPV4.DisplayName & TPV4.NumberPlate), SelectedItem_Car)
                    Else
                        If TPV0 = Nothing Then
                            TPV0 = CreateVehicle(VehicleModel, VehicleHash, World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)))
                            TPV0.AddBlip()
                            TPV0.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                            TPV0.CurrentBlip.Color = BlipColor2.Trevor
                            TPV0.CurrentBlip.IsShortRange = True
                            SetBlipName(TPV0.FriendlyName, TPV0.CurrentBlip)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            WriteCfgValue("Active", "True", SelectedItem_Car)
                            SetModKit(TPV0, SelectedItem_Car)
                            CreateMechanicInVehicle(TPV0)
                            TVDict.Add(MD5Gen(TPV0.DisplayName & TPV0.NumberPlate), SelectedItem_Car)
                        Else
                            sender.Visible = False
                            UI.ShowSubtitle(Reach10)
                            Exit Sub
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
            PVDict.Add(MD5Gen(PPV1.DisplayName & PPV1.NumberPlate), SelectedItem_Car)
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
                PVDict.Add(MD5Gen(PPV2.DisplayName & PPV2.NumberPlate), SelectedItem_Car)
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
                    PVDict.Add(MD5Gen(PPV3.DisplayName & PPV3.NumberPlate), SelectedItem_Car)
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
                        PVDict.Add(MD5Gen(PPV4.DisplayName & PPV4.NumberPlate), SelectedItem_Car)
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
                            PVDict.Add(MD5Gen(PPV0.DisplayName & PPV0.NumberPlate), SelectedItem_Car)
                        Else
                            sender.Visible = False
                            UI.ShowSubtitle(Reach10)
                            Exit Sub
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
            MPV0 = Nothing
            MPV1 = Nothing
            MPV2 = Nothing
            MPV3 = Nothing
            MPV4 = Nothing
            MVDict.Clear()
        ElseIf playerName = "Franklin" Then
            If Not FPV0 = Nothing Then FPV0.Delete()
            If Not FPV1 = Nothing Then FPV1.Delete()
            If Not FPV2 = Nothing Then FPV2.Delete()
            If Not FPV3 = Nothing Then FPV3.Delete()
            If Not FPV4 = Nothing Then FPV4.Delete()
            FPV0 = Nothing
            FPV1 = Nothing
            FPV2 = Nothing
            FPV3 = Nothing
            FPV4 = Nothing
            FVDict.Clear()
        ElseIf playerName = "Trevor" Then
            If Not TPV0 = Nothing Then TPV0.Delete()
            If Not TPV1 = Nothing Then TPV1.Delete()
            If Not TPV2 = Nothing Then TPV2.Delete()
            If Not TPV3 = Nothing Then TPV3.Delete()
            If Not TPV4 = Nothing Then TPV4.Delete()
            TPV0 = Nothing
            TPV1 = Nothing
            TPV2 = Nothing
            TPV3 = Nothing
            TPV4 = Nothing
            TVDict.Clear()
        ElseIf playerName = "Player3" Then
            If Not PPV0 = Nothing Then PPV0.Delete()
            If Not PPV1 = Nothing Then PPV1.Delete()
            If Not PPV2 = Nothing Then PPV2.Delete()
            If Not PPV3 = Nothing Then PPV3.Delete()
            If Not PPV4 = Nothing Then PPV4.Delete()
            PPV0 = Nothing
            PPV1 = Nothing
            PPV2 = Nothing
            PPV3 = Nothing
            PPV4 = Nothing
            PVDict.Clear()
        End If
    End Sub

    Public Shared Sub SetModKit(_Vehicle As Vehicle, VehicleCfgFile As String)
        Native.Function.Call(Hash.SET_VEHICLE_MOD_KIT, _Vehicle, 0)
        _Vehicle.DirtLevel = 0F
        _Vehicle.PrimaryColor = CInt(ReadCfgValue("PrimaryColor", VehicleCfgFile))
        _Vehicle.SecondaryColor = CInt(ReadCfgValue("SecondaryColor", VehicleCfgFile))
        _Vehicle.PearlescentColor = CInt(ReadCfgValue("PearlescentColor", VehicleCfgFile))
        If ReadCfgValue("HasCustomPrimaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomPrimaryColor = Color.FromArgb(ReadCfgValue("CustomPrimaryColorRed", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomPrimaryColorBlue", VehicleCfgFile))
        If ReadCfgValue("HasCustomSecondaryColor", VehicleCfgFile) = "True" Then _Vehicle.CustomSecondaryColor = Color.FromArgb(ReadCfgValue("CustomSecondaryColorRed", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorGreen", VehicleCfgFile), ReadCfgValue("CustomSecondaryColorBlue", VehicleCfgFile))
        _Vehicle.RimColor = CInt(ReadCfgValue("RimColor", VehicleCfgFile))
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

    Public Shared Sub ReturnVehicleIfDead(vehicle As Vehicle)
        Select Case playerName
            Case "Michael"
                If MVDict.ContainsKey(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)) Then
                    If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                    Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                    DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                    WriteCfgValue("Active", "False", MVDict.Item(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)))
                    MVDict.Remove(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate))
                End If
            Case "Franklin"
                If FVDict.ContainsKey(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)) Then
                    If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                    Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                    DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                    WriteCfgValue("Active", "False", MVDict.Item(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)))
                    FVDict.Remove(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate))
                End If
            Case "Trevor"
                If TVDict.ContainsKey(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)) Then
                    If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                    Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                    DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                    WriteCfgValue("Active", "False", MVDict.Item(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)))
                    TVDict.Remove(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate))
                End If
            Case "Player3"
                If PVDict.ContainsKey(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)) Then
                    If Not vehicle.CurrentBlip Is Nothing Then vehicle.CurrentBlip.Remove()
                    Dim strArray As String() = New String() {Insurance1, Insurance2, Insurance3}
                    DisplayNotificationThisFrame(MorsMutual, "", (strArray(New Random().Next(0, strArray.Length)) & Insurance4), "CHAR_MP_MORS_MUTUAL", True, IconType.RightJumpingArrow)
                    WriteCfgValue("Active", "False", MVDict.Item(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate)))
                    PVDict.Remove(MD5Gen(vehicle.DisplayName & vehicle.NumberPlate))
                End If
        End Select

    End Sub

    Public Shared Function IsAlive(vehicle As Vehicle) As Boolean
        If vehicle.EngineHealth < 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If playerPed.IsInVehicle Then
                If Not playerPed.CurrentVehicle.CurrentBlip Is Nothing Then playerPed.CurrentVehicle.CurrentBlip.Alpha = 0
            Else
                If Not MPV0 = Nothing AndAlso MPV0.CurrentBlip.Alpha = 0 Then
                    MPV0.CurrentBlip.Alpha = 255
                    MPV0.IsPersistent = IsAlive(MPV0)
                    If Not IsAlive(MPV0) Then ReturnVehicleIfDead(MPV0)
                End If
                If Not MPV1 = Nothing AndAlso MPV1.CurrentBlip.Alpha = 0 Then
                    MPV1.CurrentBlip.Alpha = 255
                    MPV1.IsPersistent = IsAlive(MPV1)
                    If Not IsAlive(MPV1) Then ReturnVehicleIfDead(MPV1)
                End If
                If Not MPV2 = Nothing AndAlso MPV2.CurrentBlip.Alpha = 0 Then
                    MPV2.CurrentBlip.Alpha = 255
                    MPV2.IsPersistent = IsAlive(MPV2)
                    If Not IsAlive(MPV2) Then ReturnVehicleIfDead(MPV2)
                End If
                If Not MPV3 = Nothing AndAlso MPV3.CurrentBlip.Alpha = 0 Then
                    MPV3.CurrentBlip.Alpha = 255
                    MPV3.IsPersistent = IsAlive(MPV3)
                    If Not IsAlive(MPV3) Then ReturnVehicleIfDead(MPV3)
                End If
                If Not MPV4 = Nothing AndAlso MPV4.CurrentBlip.Alpha = 0 Then
                    MPV4.CurrentBlip.Alpha = 255
                    MPV4.IsPersistent = IsAlive(MPV4)
                    If Not IsAlive(MPV4) Then ReturnVehicleIfDead(MPV4)
                End If
                If Not MPV10 = Nothing AndAlso MPV10.CurrentBlip.Alpha = 0 Then
                    MPV10.CurrentBlip.Alpha = 255
                    MPV10.IsPersistent = IsAlive(MPV10)
                End If
                If Not MPV11 = Nothing AndAlso MPV11.CurrentBlip.Alpha = 0 Then
                    MPV11.CurrentBlip.Alpha = 255
                    MPV11.IsPersistent = IsAlive(MPV11)
                End If
                If Not FPV0 = Nothing AndAlso FPV0.CurrentBlip.Alpha = 0 Then
                    FPV0.CurrentBlip.Alpha = 255
                    FPV0.IsPersistent = IsAlive(FPV0)
                    If Not IsAlive(FPV0) Then ReturnVehicleIfDead(FPV0)
                End If
                If Not FPV1 = Nothing AndAlso FPV1.CurrentBlip.Alpha = 0 Then
                    FPV1.CurrentBlip.Alpha = 255
                    FPV1.IsPersistent = IsAlive(FPV1)
                    If Not IsAlive(FPV1) Then ReturnVehicleIfDead(FPV1)
                End If
                If Not FPV2 = Nothing AndAlso FPV2.CurrentBlip.Alpha = 0 Then
                    FPV2.CurrentBlip.Alpha = 255
                    FPV2.IsPersistent = IsAlive(FPV2)
                    If Not IsAlive(FPV2) Then ReturnVehicleIfDead(FPV2)
                End If
                If Not FPV3 = Nothing AndAlso FPV3.CurrentBlip.Alpha = 0 Then
                    FPV3.CurrentBlip.Alpha = 255
                    FPV3.IsPersistent = IsAlive(FPV3)
                    If Not IsAlive(FPV3) Then ReturnVehicleIfDead(FPV3)
                End If
                If Not FPV4 = Nothing AndAlso FPV4.CurrentBlip.Alpha = 0 Then
                    FPV4.CurrentBlip.Alpha = 255
                    FPV4.IsPersistent = IsAlive(FPV4)
                    If Not IsAlive(FPV4) Then ReturnVehicleIfDead(FPV4)
                End If
                If Not FPV10 = Nothing AndAlso FPV10.CurrentBlip.Alpha = 0 Then
                    FPV10.CurrentBlip.Alpha = 255
                    FPV10.IsPersistent = IsAlive(FPV10)
                End If
                If Not FPV11 = Nothing AndAlso FPV11.CurrentBlip.Alpha = 0 Then
                    FPV11.CurrentBlip.Alpha = 255
                    FPV11.IsPersistent = IsAlive(FPV11)
                End If
                If Not TPV0 = Nothing AndAlso TPV0.CurrentBlip.Alpha = 0 Then
                    TPV0.CurrentBlip.Alpha = 255
                    TPV0.IsPersistent = IsAlive(TPV0)
                    If Not IsAlive(TPV0) Then ReturnVehicleIfDead(TPV0)
                End If
                If Not TPV1 = Nothing AndAlso TPV1.CurrentBlip.Alpha = 0 Then
                    TPV1.CurrentBlip.Alpha = 255
                    TPV1.IsPersistent = IsAlive(TPV1)
                    If Not IsAlive(TPV1) Then ReturnVehicleIfDead(TPV1)
                End If
                If Not TPV2 = Nothing AndAlso TPV2.CurrentBlip.Alpha = 0 Then
                    TPV2.CurrentBlip.Alpha = 255
                    TPV2.IsPersistent = IsAlive(TPV2)
                    If Not IsAlive(TPV2) Then ReturnVehicleIfDead(TPV2)
                End If
                If Not TPV3 = Nothing AndAlso TPV3.CurrentBlip.Alpha = 0 Then
                    TPV3.CurrentBlip.Alpha = 255
                    TPV3.IsPersistent = IsAlive(TPV3)
                    If Not IsAlive(TPV3) Then ReturnVehicleIfDead(TPV3)
                End If
                If Not TPV4 = Nothing AndAlso TPV4.CurrentBlip.Alpha = 0 Then
                    TPV4.CurrentBlip.Alpha = 255
                    TPV4.IsPersistent = IsAlive(TPV4)
                    If Not IsAlive(TPV4) Then ReturnVehicleIfDead(TPV4)
                End If
                If Not TPV10 = Nothing AndAlso TPV10.CurrentBlip.Alpha = 0 Then
                    TPV10.CurrentBlip.Alpha = 255
                    TPV10.IsPersistent = IsAlive(TPV10)
                End If
                If Not TPV11 = Nothing AndAlso TPV11.CurrentBlip.Alpha = 0 Then
                    TPV11.CurrentBlip.Alpha = 255
                    TPV11.IsPersistent = IsAlive(TPV11)
                End If
                If Not PPV0 = Nothing AndAlso PPV0.CurrentBlip.Alpha = 0 Then
                    PPV0.CurrentBlip.Alpha = 255
                    PPV0.IsPersistent = IsAlive(PPV0)
                    If Not IsAlive(PPV0) Then ReturnVehicleIfDead(PPV0)
                End If
                If Not PPV1 = Nothing AndAlso PPV1.CurrentBlip.Alpha = 0 Then
                    PPV1.CurrentBlip.Alpha = 255
                    PPV1.IsPersistent = IsAlive(PPV1)
                    If Not IsAlive(PPV1) Then ReturnVehicleIfDead(PPV1)
                End If
                If Not PPV2 = Nothing AndAlso PPV2.CurrentBlip.Alpha = 0 Then
                    PPV2.CurrentBlip.Alpha = 255
                    PPV2.IsPersistent = IsAlive(PPV2)
                    If Not IsAlive(PPV2) Then ReturnVehicleIfDead(PPV2)
                End If
                If Not PPV3 = Nothing AndAlso PPV3.CurrentBlip.Alpha = 0 Then
                    PPV3.CurrentBlip.Alpha = 255
                    PPV3.IsPersistent = IsAlive(PPV3)
                    If Not IsAlive(PPV3) Then ReturnVehicleIfDead(PPV3)
                End If
                If Not PPV4 = Nothing AndAlso PPV4.CurrentBlip.Alpha = 0 Then
                    PPV4.CurrentBlip.Alpha = 255
                    PPV4.IsPersistent = IsAlive(PPV4)
                    If Not IsAlive(PPV4) Then ReturnVehicleIfDead(PPV4)
                End If
                If Not PPV10 = Nothing AndAlso PPV10.CurrentBlip.Alpha = 0 Then
                    PPV10.CurrentBlip.Alpha = 255
                    PPV10.IsPersistent = IsAlive(PPV10)
                End If
                If Not PPV11 = Nothing AndAlso PPV11.CurrentBlip.Alpha = 0 Then
                    PPV11.CurrentBlip.Alpha = 255
                    PPV11.IsPersistent = IsAlive(PPV11)
                End If
                If Not MPV10 = Nothing AndAlso MPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If MPV10.ClassType = VehicleClass.Boats Then
                        MPV10.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf MPV10.ClassType = VehicleClass.Helicopters Then
                        MPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf MPV10.ClassType = VehicleClass.Utility
                        MPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf MPV10.ClassType = VehicleClass.Planes Then
                        MPV10.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf MPV10.ClassType = VehicleClass.Military Then
                        MPV10.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        MPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    MPV10.CurrentBlip.Color = BlipColor2.Michael
                    SetBlipName(MPV10.FriendlyName, MPV10.CurrentBlip)
                End If
                If Not FPV10 = Nothing AndAlso FPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If FPV10.ClassType = VehicleClass.Boats Then
                        FPV10.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf FPV10.ClassType = VehicleClass.Helicopters Then
                        FPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf FPV10.ClassType = VehicleClass.Utility
                        FPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf FPV10.ClassType = VehicleClass.Planes Then
                        FPV10.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf FPV10.ClassType = VehicleClass.Military Then
                        FPV10.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        FPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    FPV10.CurrentBlip.Color = BlipColor2.Franklin
                    SetBlipName(FPV10.FriendlyName, FPV10.CurrentBlip)
                End If
                If Not TPV10 = Nothing AndAlso TPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If TPV10.ClassType = VehicleClass.Boats Then
                        TPV10.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf TPV10.ClassType = VehicleClass.Helicopters Then
                        TPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf TPV10.ClassType = VehicleClass.Utility
                        TPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf TPV10.ClassType = VehicleClass.Planes Then
                        TPV10.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf TPV10.ClassType = VehicleClass.Military Then
                        TPV10.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        TPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    TPV10.CurrentBlip.Color = BlipColor2.Trevor
                    SetBlipName(TPV10.FriendlyName, TPV10.CurrentBlip)
                End If
                If Not PPV10 = Nothing AndAlso PPV10.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If PPV10.ClassType = VehicleClass.Boats Then
                        PPV10.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf PPV10.ClassType = VehicleClass.Helicopters Then
                        PPV10.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf PPV10.ClassType = VehicleClass.Utility
                        PPV10.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf PPV10.ClassType = VehicleClass.Planes Then
                        PPV10.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf PPV10.ClassType = VehicleClass.Military Then
                        PPV10.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        PPV10.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    PPV10.CurrentBlip.Color = BlipColor.Yellow
                    SetBlipName(PPV10.FriendlyName, PPV10.CurrentBlip)
                End If
                If Not MPV11 = Nothing AndAlso MPV11.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If MPV11.ClassType = VehicleClass.Boats Then
                        MPV11.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf MPV11.ClassType = VehicleClass.Helicopters Then
                        MPV11.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf MPV11.ClassType = VehicleClass.Utility
                        MPV11.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf MPV11.ClassType = VehicleClass.Planes Then
                        MPV11.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf MPV11.ClassType = VehicleClass.Military Then
                        MPV11.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        MPV11.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    MPV11.CurrentBlip.Color = BlipColor2.Michael
                    SetBlipName(MPV11.FriendlyName, MPV11.CurrentBlip)
                End If
                If Not FPV11 = Nothing AndAlso FPV11.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If FPV11.ClassType = VehicleClass.Boats Then
                        FPV11.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf FPV11.ClassType = VehicleClass.Helicopters Then
                        FPV11.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf FPV11.ClassType = VehicleClass.Utility
                        FPV11.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf FPV11.ClassType = VehicleClass.Planes Then
                        FPV11.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf FPV11.ClassType = VehicleClass.Military Then
                        FPV11.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        FPV11.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    FPV11.CurrentBlip.Color = BlipColor2.Franklin
                    SetBlipName(FPV11.FriendlyName, FPV11.CurrentBlip)
                End If
                If Not TPV11 = Nothing AndAlso TPV11.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If TPV11.ClassType = VehicleClass.Boats Then
                        TPV11.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf TPV11.ClassType = VehicleClass.Helicopters Then
                        TPV11.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf TPV11.ClassType = VehicleClass.Utility
                        TPV11.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf TPV11.ClassType = VehicleClass.Planes Then
                        TPV11.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf TPV11.ClassType = VehicleClass.Military Then
                        TPV11.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        TPV11.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    TPV11.CurrentBlip.Color = BlipColor2.Trevor
                    SetBlipName(TPV11.FriendlyName, TPV11.CurrentBlip)
                End If
                If Not PPV11 = Nothing AndAlso PPV11.CurrentBlip.Sprite = BlipSprite.Standard Then
                    If PPV11.ClassType = VehicleClass.Boats Then
                        PPV11.CurrentBlip.Sprite = BlipSprite.Boat
                    ElseIf PPV11.ClassType = VehicleClass.Helicopters Then
                        PPV11.CurrentBlip.Sprite = BlipSprite.Helicopter
                    ElseIf PPV11.ClassType = VehicleClass.Utility
                        PPV11.CurrentBlip.Sprite = BlipSprite.ArmoredTruck
                    ElseIf PPV11.ClassType = VehicleClass.Planes Then
                        PPV11.CurrentBlip.Sprite = BlipSprite.Plane
                    ElseIf PPV11.ClassType = VehicleClass.Military Then
                        PPV11.CurrentBlip.Sprite = BlipSprite.Tank
                    Else
                        PPV11.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                    End If
                    PPV11.CurrentBlip.Color = BlipColor.Yellow
                    SetBlipName(PPV11.FriendlyName, PPV11.CurrentBlip)
                End If
            End If

            If (Not MPV0 = Nothing AndAlso (Not IsAlive(MPV0) AndAlso World.GetDistance(playerPed.Position, MPV0.Position) > 50.0)) Then MPV0.Delete()
            If (Not MPV1 = Nothing AndAlso (Not IsAlive(MPV1) AndAlso World.GetDistance(playerPed.Position, MPV1.Position) > 50.0)) Then MPV1.Delete()
            If (Not MPV2 = Nothing AndAlso (Not IsAlive(MPV2) AndAlso World.GetDistance(playerPed.Position, MPV2.Position) > 50.0)) Then MPV2.Delete()
            If (Not MPV3 = Nothing AndAlso (Not IsAlive(MPV3) AndAlso World.GetDistance(playerPed.Position, MPV3.Position) > 50.0)) Then MPV3.Delete()
            If (Not MPV4 = Nothing AndAlso (Not IsAlive(MPV4) AndAlso World.GetDistance(playerPed.Position, MPV4.Position) > 50.0)) Then MPV4.Delete()
            If (Not FPV0 = Nothing AndAlso (Not IsAlive(FPV0) AndAlso World.GetDistance(playerPed.Position, FPV0.Position) > 50.0)) Then FPV0.Delete()
            If (Not FPV1 = Nothing AndAlso (Not IsAlive(FPV1) AndAlso World.GetDistance(playerPed.Position, FPV1.Position) > 50.0)) Then FPV1.Delete()
            If (Not FPV2 = Nothing AndAlso (Not IsAlive(FPV2) AndAlso World.GetDistance(playerPed.Position, FPV2.Position) > 50.0)) Then FPV2.Delete()
            If (Not FPV3 = Nothing AndAlso (Not IsAlive(FPV3) AndAlso World.GetDistance(playerPed.Position, FPV3.Position) > 50.0)) Then FPV3.Delete()
            If (Not FPV4 = Nothing AndAlso (Not IsAlive(FPV4) AndAlso World.GetDistance(playerPed.Position, FPV4.Position) > 50.0)) Then FPV4.Delete()
            If (Not TPV0 = Nothing AndAlso (Not IsAlive(TPV0) AndAlso World.GetDistance(playerPed.Position, TPV0.Position) > 50.0)) Then TPV0.Delete()
            If (Not TPV1 = Nothing AndAlso (Not IsAlive(TPV1) AndAlso World.GetDistance(playerPed.Position, TPV1.Position) > 50.0)) Then TPV1.Delete()
            If (Not TPV2 = Nothing AndAlso (Not IsAlive(TPV2) AndAlso World.GetDistance(playerPed.Position, TPV2.Position) > 50.0)) Then TPV2.Delete()
            If (Not TPV3 = Nothing AndAlso (Not IsAlive(TPV3) AndAlso World.GetDistance(playerPed.Position, TPV3.Position) > 50.0)) Then TPV3.Delete()
            If (Not TPV4 = Nothing AndAlso (Not IsAlive(TPV4) AndAlso World.GetDistance(playerPed.Position, TPV4.Position) > 50.0)) Then TPV4.Delete()
            If (Not PPV0 = Nothing AndAlso (Not IsAlive(PPV0) AndAlso World.GetDistance(playerPed.Position, PPV0.Position) > 50.0)) Then PPV0.Delete()
            If (Not PPV1 = Nothing AndAlso (Not IsAlive(PPV1) AndAlso World.GetDistance(playerPed.Position, PPV1.Position) > 50.0)) Then PPV1.Delete()
            If (Not PPV2 = Nothing AndAlso (Not IsAlive(PPV2) AndAlso World.GetDistance(playerPed.Position, PPV2.Position) > 50.0)) Then PPV2.Delete()
            If (Not PPV3 = Nothing AndAlso (Not IsAlive(PPV3) AndAlso World.GetDistance(playerPed.Position, PPV3.Position) > 50.0)) Then PPV3.Delete()
            If (Not PPV4 = Nothing AndAlso (Not IsAlive(PPV4) AndAlso World.GetDistance(playerPed.Position, PPV4.Position) > 50.0)) Then PPV4.Delete()

            If Not MPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, MPVV10) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", MPVF10)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", MPVF10)
                MPV10 = CreateVehicle(VehicleModel, VehicleHash, MPVV10)
                MPV10.PlaceOnGround()
                MPV10.AddBlip()
                MPV10.CurrentBlip.Sprite = MPVVB10.Sprite
                MPV10.CurrentBlip.Color = BlipColor2.Michael
                MPV10.CurrentBlip.Name = MPV10.FriendlyName
                SetModKit(MPV10, MPVF10)
                MPVVB10.Remove()
                MPVF10 = Nothing
            End If
            If Not FPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, FPVV10) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", FPVF10)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", FPVF10)
                FPV10 = CreateVehicle(VehicleModel, VehicleHash, FPVV10)
                FPV10.PlaceOnGround()
                FPV10.AddBlip()
                FPV10.CurrentBlip.Sprite = FPVVB10.Sprite
                FPV10.CurrentBlip.Color = BlipColor2.Franklin
                FPV10.CurrentBlip.Name = FPV10.FriendlyName
                SetModKit(FPV10, FPVF10)
                FPVVB10.Remove()
                FPVF10 = Nothing
            End If
            If Not TPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, TPVV10) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", TPVF10)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", TPVF10)
                TPV10 = CreateVehicle(VehicleModel, VehicleHash, TPVV10)
                TPV10.PlaceOnGround()
                TPV10.AddBlip()
                TPV10.CurrentBlip.Sprite = TPVVB10.Sprite
                TPV10.CurrentBlip.Color = BlipColor2.Trevor
                TPV10.CurrentBlip.Name = TPV10.FriendlyName
                SetModKit(TPV10, TPVF10)
                TPVVB10.Remove()
                TPVF10 = Nothing
            End If
            If Not PPVVB10 = Nothing AndAlso World.GetDistance(playerPed.Position, PPVV10) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", PPVF10)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", PPVF10)
                PPV10 = CreateVehicle(VehicleModel, VehicleHash, PPVV10)
                PPV10.PlaceOnGround()
                PPV10.AddBlip()
                PPV10.CurrentBlip.Sprite = PPVVB10.Sprite
                PPV10.CurrentBlip.Color = BlipColor.Yellow
                PPV10.CurrentBlip.Name = PPV10.FriendlyName
                SetModKit(PPV10, PPVF10)
                PPVVB10.Remove()
                PPVF10 = Nothing
            End If
            If Not MPVVB11 = Nothing AndAlso World.GetDistance(playerPed.Position, MPVV11) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", MPVF11)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", MPVF11)
                MPV11 = CreateVehicle(VehicleModel, VehicleHash, MPVV11)
                MPV11.PlaceOnGround()
                MPV11.AddBlip()
                MPV11.CurrentBlip.Sprite = MPVVB11.Sprite
                MPV11.CurrentBlip.Color = BlipColor2.Michael
                MPV11.CurrentBlip.Name = MPV11.FriendlyName
                SetModKit(MPV11, MPVF11)
                MPVVB11.Remove()
                MPVF11 = Nothing
            End If
            If Not FPVVB11 = Nothing AndAlso World.GetDistance(playerPed.Position, FPVV11) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", FPVF11)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", FPVF11)
                FPV11 = CreateVehicle(VehicleModel, VehicleHash, FPVV11)
                FPV11.PlaceOnGround()
                FPV11.AddBlip()
                FPV11.CurrentBlip.Sprite = FPVVB11.Sprite
                FPV11.CurrentBlip.Color = BlipColor2.Franklin
                FPV11.CurrentBlip.Name = FPV11.FriendlyName
                SetModKit(FPV11, FPVF11)
                FPVVB11.Remove()
                FPVF11 = Nothing
            End If
            If Not TPVVB11 = Nothing AndAlso World.GetDistance(playerPed.Position, TPVV11) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", TPVF11)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", TPVF11)
                TPV11 = CreateVehicle(VehicleModel, VehicleHash, TPVV11)
                TPV11.PlaceOnGround()
                TPV11.AddBlip()
                TPV11.CurrentBlip.Sprite = TPVVB11.Sprite
                TPV11.CurrentBlip.Color = BlipColor2.Trevor
                TPV11.CurrentBlip.Name = TPV11.FriendlyName
                SetModKit(TPV11, TPVF11)
                TPVVB11.Remove()
                TPVF11 = Nothing
            End If
            If Not PPVVB11 = Nothing AndAlso World.GetDistance(playerPed.Position, PPVV11) < 50.0 Then
                Dim VehicleModel As String = ReadCfgValue("VehicleModel", PPVF11)
                Dim VehicleHash As Integer = ReadCfgValue("VehicleHash", PPVF11)
                PPV11 = CreateVehicle(VehicleModel, VehicleHash, PPVV11)
                PPV11.PlaceOnGround()
                PPV11.AddBlip()
                PPV11.CurrentBlip.Sprite = PPVVB11.Sprite
                PPV11.CurrentBlip.Color = BlipColor.Yellow
                PPV11.CurrentBlip.Name = PPV11.FriendlyName
                SetModKit(PPV11, PPVF11)
                PPVVB11.Remove()
                PPVF11 = Nothing
            End If

            If Native.Function.Call(Of Integer)(Hash.GET_CLOCK_HOURS) = 2 AndAlso Native.Function.Call(Of Integer)(Hash.GET_CLOCK_MINUTES) = 0 AndAlso Native.Function.Call(Of Integer)(Hash.GET_CLOCK_SECONDS) = 0 Then
                SinglePlayerApartment.player.Money = (playerCash - 100)
                UI.Notify(MechanicBill)
            End If

            If Not MechanicPed = Nothing AndAlso My.Settings.VehicleSpawn = 1 Then
                If MechanicPed.Position.DistanceTo(playerPed.Position) < 5.0 Then
                    If MechanicPed.IsInVehicle Then
                        MechanicPed.Task.LeaveVehicle()
                    Else
                        MechanicPed.Task.RunTo(World.GetNextPositionOnStreet(playerPed.Position.Around(100.0)), False)
                        If MechanicPed.Position.DistanceTo(playerPed.Position) > 100.0 Then MechanicPed.Delete()
                    End If
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        Try
            If Not MechanicPed = Nothing Then MechanicPed.Delete()
        Catch ex As Exception
        End Try
    End Sub
End Class
