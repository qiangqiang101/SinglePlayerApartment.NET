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

    Public Shared _3AltaStreetPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3_alta_street\"
    Public Shared _4IntegrityPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way\"
    Public Shared HL4IntegrityPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4_integrity_way_hl\"
    Public Shared NtConker2044Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2044_north_conker\"
    Public Shared NtConker2045Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2045_north_conker\"
    Public Shared MadWayne2113Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2113_mad_wayne\"
    Public Shared MiltonRd2117Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2117_milton_road\"
    Public Shared Hillcreast2862Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2862_hillcreast_ave\"
    Public Shared Hillcreast2868Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2868_hillcreast_ave\"
    Public Shared Hillcreast2874Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2874_hillcreast_ave\"
    Public Shared WildOats3655Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3655_wild_oats\"
    Public Shared Whispymound3677Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\3677_whispymound\"
    Public Shared DelPerroPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights\"
    Public Shared HLDelPerroPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\del_perro_heights_hl\"
    Public Shared DreamTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\dream_tower\"
    Public Shared EclipseTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower\"
    Public Shared HPEclipseTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_hl\"
    Public Shared EclipseTowerPS1Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps1\"
    Public Shared EclipseTowerPS2Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps2\"
    Public Shared EclipseTowerPS3Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\eclipse_tower_ps3\"
    Public Shared RichardMajesticPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic\"
    Public Shared HLRichardMajesticPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\richard_majestic_hl\"
    Public Shared TinselTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower\"
    Public Shared HLTinselTowerPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\tinsel_tower_hl\"
    Public Shared VespucciBlvdPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\vespucci_blvd\"
    Public Shared WeazelPlazaPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\weazel_plaza\"
    Public Shared BayCityAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\bay_city_ave\"
    Public Shared BlvdDelPerroPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\blvd_del_perro\"
    Public Shared CougarAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\cougar_ave\"
    Public Shared HangmanAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\hangman_ave\"
    Public Shared LasLagunas0604Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0604_las_lagunas_blvd\"
    Public Shared LasLagunas2143Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\2143_las_lagunas_blvd\"
    Public Shared MiltonRd0184Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0184_milton_road\"
    Public Shared PowerStPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\power_st\"
    Public Shared ProcopioDr4401Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4401_procopio_dr\"
    Public Shared ProcopioDr4584Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\4584_procopio_dr\"
    Public Shared ProsperityStPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\prosperity_st\"
    Public Shared SanVitasStPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\san_vitas_st\"
    Public Shared SouthMoMiltonPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\south_mo_milton_dr\"
    Public Shared SouthRockford0325Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0325_south_rockford_dr\"
    Public Shared SpanishAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\spanish_ave\"
    Public Shared SustanciaRdPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\sustancia_rd\"
    Public Shared TheRoyalePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\the_royale\"
    Public Shared GrapeseedAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\grapeseed_ave\"
    Public Shared PaletoBlvdPath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\paleto_blvd\"
    Public Shared SouthRockford0012Path As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\0112_south_rockford_dr\"
    Public Shared ZancudoAvePath As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Garage\zancudo_ave\"
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

        ReturnAllVehiclesToGarageNEW()

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

    Public Shared Sub ReturnAllVehiclesToGarageNEW()
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
    End Sub

    Public Shared Sub Michael_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)
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
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If MPVD >= 30 Then
                    MPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
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
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    UI.ShowSubtitle(Reach10)
                End If
            Else
                MPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
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
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub Franklin_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)

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
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If FPVD >= 30 Then
                    FPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
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
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    UI.ShowSubtitle(Reach10)
                End If
            Else
                FPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
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
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub Trevor_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)

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
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If TPVD >= 30 Then
                    TPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
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
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    UI.ShowSubtitle(Reach10)
                End If
            Else
                TPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
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
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
            End If
        End If
    End Sub

    Public Shared Sub Player3_SendVehicle(ByVal SelectedItem_Car As String, VehicleModel As String, VehicleHash As String, selectedItem As UIMenuItem, sender As UIMenu)

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
            SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
        Else
            If Not Website.iWillGetThereAsSoonAsICan Then
                If PPVD >= 30 Then
                    PPV0.Delete()
                    ReturnAllVehiclesToGarageNEW()
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
                    SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
                Else
                    UI.ShowSubtitle(Reach10)
                End If
            Else
                PPV0.Delete()
                ReturnAllVehiclesToGarageNEW()
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
                SoundPlayer(SoundPathDir & "mechanic_get_there_as_soon_as_i_can.wav")
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
            MPV0 = Nothing
            MVDict.Clear()
        ElseIf playerName = "Franklin" Then
            If Not FPV0 = Nothing Then FPV0.Delete()
            FPV0 = Nothing
            FVDict.Clear()
        ElseIf playerName = "Trevor" Then
            If Not TPV0 = Nothing Then TPV0.Delete()
            TPV0 = Nothing
            TVDict.Clear()
        ElseIf playerName = "Player3" Then
            If Not PPV0 = Nothing Then PPV0.Delete()
            PPV0 = Nothing
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

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If playerPed.IsInVehicle Then
                If Not playerPed.CurrentVehicle.CurrentBlip Is Nothing Then playerPed.CurrentVehicle.CurrentBlip.Alpha = 0
            Else
                If Not MPV0 = Nothing AndAlso MPV0.CurrentBlip.Alpha = 0 Then
                    MPV0.CurrentBlip.Alpha = 255
                    MPV0.IsPersistent = MPV0.IsAlive
                    If Not MPV0.IsAlive Then ReturnVehicleIfDead(MPV0)
                End If
                If Not MPV10 = Nothing AndAlso MPV10.CurrentBlip.Alpha = 0 Then
                    MPV10.CurrentBlip.Alpha = 255
                    MPV10.IsPersistent = MPV10.IsAlive
                End If
                If Not FPV0 = Nothing AndAlso FPV0.CurrentBlip.Alpha = 0 Then
                    FPV0.CurrentBlip.Alpha = 255
                    FPV0.IsPersistent = FPV0.IsAlive
                    If Not FPV0.IsAlive Then ReturnVehicleIfDead(FPV0)
                End If
                If Not FPV10 = Nothing AndAlso FPV10.CurrentBlip.Alpha = 0 Then
                    FPV10.CurrentBlip.Alpha = 255
                    FPV10.IsPersistent = FPV10.IsAlive
                End If
                If Not TPV0 = Nothing AndAlso TPV0.CurrentBlip.Alpha = 0 Then
                    TPV0.CurrentBlip.Alpha = 255
                    TPV0.IsPersistent = TPV0.IsAlive
                    If Not TPV0.IsAlive Then ReturnVehicleIfDead(TPV0)
                End If
                If Not TPV10 = Nothing AndAlso TPV10.CurrentBlip.Alpha = 0 Then
                    TPV10.CurrentBlip.Alpha = 255
                    TPV10.IsPersistent = TPV10.IsAlive
                End If
                If Not PPV0 = Nothing AndAlso PPV0.CurrentBlip.Alpha = 0 Then
                    PPV0.CurrentBlip.Alpha = 255
                    PPV0.IsPersistent = PPV0.IsAlive
                    If Not PPV0.IsAlive Then ReturnVehicleIfDead(PPV0)
                End If
                If Not PPV10 = Nothing AndAlso PPV10.CurrentBlip.Alpha = 0 Then
                    PPV10.CurrentBlip.Alpha = 255
                    PPV10.IsPersistent = PPV10.IsAlive
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
            End If

            If (Not MPV0 = Nothing AndAlso (Not MPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, MPV0.Position) > 50.0)) Then MPV0.Delete()
            If (Not FPV0 = Nothing AndAlso (Not FPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, FPV0.Position) > 50.0)) Then FPV0.Delete()
            If (Not TPV0 = Nothing AndAlso (Not TPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, TPV0.Position) > 50.0)) Then TPV0.Delete()
            If (Not PPV0 = Nothing AndAlso (Not PPV0.IsAlive AndAlso World.GetDistance(playerPed.Position, PPV0.Position) > 50.0)) Then PPV0.Delete()

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
