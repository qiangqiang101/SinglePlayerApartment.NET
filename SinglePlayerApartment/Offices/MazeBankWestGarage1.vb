Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports SinglePlayerApartment.SinglePlayerApartment
Imports SinglePlayerApartment.INMNative

Public Class MazeBankWestGarage1
    Inherits Script

    Public Shared InteriorID As Integer
    Public Shared CurrentPath As String
    Public Shared veh0, veh1, veh2, veh3, veh4, veh5, veh6, veh7, veh8, veh9, veh10, veh11, veh12, veh13, veh14, veh15, veh16, veh17, veh18, veh19 As Vehicle
    Public Shared LastLocationName As String
    Public Shared lastLocationVector As Vector3
    Public Shared lastLocationGarageVector As Vector3
    Public Shared lastLocationGarageOutVector As Vector3
    Public Shared lastLocationGarageOutHeading As Single
    Public Shared Elevator As Vector3 = New Vector3(238.7097, -1004.8488, -98.9999)
    Public Shared GarageDoorL As Vector3 = New Vector3(231.9013, -1006.686, -98.9999)
    Public Shared GarageDoorR As Vector3 = New Vector3(224.4288, -1006.6892, -98.9999)
    Public Shared GarageMiddle As Vector3 = New Vector3(228.7026, -989.8284, -98.9999)
    Public Shared MenuActivator As Vector3 = New Vector3(226.5738, -975.5375, -99.9999)
    Public Shared ElevatorDistance As Single
    Public Shared GarageDoorLDistance As Single
    Public Shared GarageDoorRDistance As Single
    Public Shared GarageMarkerDistance As Single
    Public Shared veh0Pos As Vector3 = New Vector3(223.4, -1001, -99.0)
    Public Shared veh1Pos As Vector3 = New Vector3(223.4, -996, -99.0)
    Public Shared veh2Pos As Vector3 = New Vector3(223.4, -991, -99.0)
    Public Shared veh3Pos As Vector3 = New Vector3(223.4, -986, -99.0)
    Public Shared veh4Pos As Vector3 = New Vector3(223.4, -981, -99.0)
    Public Shared veh5Pos As Vector3 = New Vector3(232.7, -1001, -99.0)
    Public Shared veh6Pos As Vector3 = New Vector3(232.7, -996, -99.0)
    Public Shared veh7Pos As Vector3 = New Vector3(232.7, -991, -99.0)
    Public Shared veh8Pos As Vector3 = New Vector3(232.7, -986, -99.0)
    Public Shared veh9Pos As Vector3 = New Vector3(232.7, -981, -99.0)
    Public Shared vehRot04 As Vector3 = New Vector3(0, 0, 241.3)
    Public Shared vehRot59 As Vector3 = New Vector3(0, 0, 116.3)

End Class
