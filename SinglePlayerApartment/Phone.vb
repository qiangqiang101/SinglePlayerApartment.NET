Imports GTA
Imports SinglePlayerApartment.SinglePlayerApartment
Imports iFruitAddon2
Imports SinglePlayerApartment.Mechanic
Imports SinglePlayerApartment.Website

Public Class Phone
    Inherits Script

    Public Shared ifruit As New CustomiFruit()
    Public Shared Contact(9) As iFruitContact

    Public Sub New()
        AddPhoneContacts()
    End Sub

    Public Shared Sub AddPhoneContacts()
        Contact(0) = New iFruitContact(_Mechanic)
        AddHandler Contact(0).Answered, AddressOf Call_Mechanic
        Contact(0).DialTimeout = 5000
        Contact(0).Active = True
        Contact(0).Icon = ContactIcon.LSCustoms
        ifruit.Contacts.Add(Contact(0))

        Contact(1) = New iFruitContact(_Pegasus)
        AddHandler Contact(1).Answered, AddressOf Call_Pegasus2
        Contact(1).DialTimeout = 5000
        Contact(1).Active = True
        Contact(1).Icon = New ContactIcon("char_pegasus_delivery")
        ifruit.Contacts.Add(Contact(1))

        Contact(2) = New iFruitContact(WarstockCache)
        AddHandler Contact(2).Answered, AddressOf Call_Warstock
        Contact(2).DialTimeout = 5000
        Contact(2).Active = True
        Contact(2).Icon = New ContactIcon("char_milsite")
        ifruit.Contacts.Add(Contact(2))

        Contact(3) = New iFruitContact(DockTease)
        AddHandler Contact(3).Answered, AddressOf Call_DockTease
        Contact(3).DialTimeout = 5000
        Contact(3).Active = True
        Contact(3).Icon = ContactIcon.Boatsite
        ifruit.Contacts.Add(Contact(3))

        Contact(4) = New iFruitContact(LegendaryMotorsport)
        AddHandler Contact(4).Answered, AddressOf Call_Legendary
        Contact(4).DialTimeout = 5000
        Contact(4).Active = True
        Contact(4).Icon = ContactIcon.LegendaryMotorsport
        ifruit.Contacts.Add(Contact(4))

        Contact(5) = New iFruitContact(ElitasTravel)
        AddHandler Contact(5).Answered, AddressOf Call_ElitasTravel
        Contact(5).DialTimeout = 5000
        Contact(5).Active = True
        Contact(5).Icon = New ContactIcon("char_planesite")
        ifruit.Contacts.Add(Contact(5))

        Contact(6) = New iFruitContact(PedalToMetal)
        AddHandler Contact(6).Answered, AddressOf Call_PedalToMetal
        Contact(6).DialTimeout = 5000
        Contact(6).Active = True
        Contact(6).Icon = ContactIcon.Bikesite
        ifruit.Contacts.Add(Contact(6))

        Contact(7) = New iFruitContact(SouthernSA)
        AddHandler Contact(7).Answered, AddressOf Call_SouthernSA
        Contact(7).DialTimeout = 5000
        Contact(7).Active = True
        Contact(7).Icon = ContactIcon.SSASuperAutos
        ifruit.Contacts.Add(Contact(7))

        Contact(8) = New iFruitContact(BennysOriginal)
        AddHandler Contact(8).Answered, AddressOf Call_Benny
        Contact(8).DialTimeout = 5000
        Contact(8).Active = True
        Contact(8).Icon = New ContactIcon("char_carsite3")
        ifruit.Contacts.Add(Contact(8))
    End Sub

    Public Shared Sub Call_Pegasus2()
        Call_Pegasus(True)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            If Not Game.IsLoading Then
                ifruit.Update()
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        Try
            For i As Integer = 0 To Contact(9).Index - 1
                Contact(i).EndCall()
            Next
            ifruit.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class
