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

Public Class ReturnAllVehicles
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

    End Sub
End Class
