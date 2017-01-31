Imports GTA
Imports SinglePlayerApartment.SinglePlayerApartment
Imports iFruitAddon
Imports SinglePlayerApartment.Mechanic
Imports SinglePlayerApartment.Website

Public Class Phone
    Inherits Script

    Public Shared ifruit As CustomiFruit
    Public Shared Contact(9) As iFruitContact
    Public Shared pHash As String
    Public Shared phoneContact As String = ReadCfgValue("PhoneContact", settingFile)
    Public Shared FIndex As Integer = CInt(ReadCfgValue("FranklinPhoneIndex", settingFile))
    Public Shared MIndex As Integer = CInt(ReadCfgValue("MichaelPhoneIndex", settingFile))
    Public Shared TIndex As Integer = CInt(ReadCfgValue("TrevorPhoneIndex", settingFile))

    Public Sub New()
        Try
            'New Language
            BennysOriginal = ReadCfgValue("BennysOriginal", langFile)
            DockTease = ReadCfgValue("DockTease", langFile)
            LegendaryMotorsport = ReadCfgValue("LegendaryMotorsport", langFile)
            ElitasTravel = ReadCfgValue("ElitasTravel", langFile)
            PedalToMetal = ReadCfgValue("PedalToMetal", langFile)
            SouthernSA = ReadCfgValue("SouthernSA", langFile)
            WarstockCache = ReadCfgValue("WarstockCache", langFile)
            _Mechanic = ReadCfgValue("_Mechanic", langFile)
            _Pegasus = ReadCfgValue("_Pegasus", langFile)
            'End Language

            ifruit = New CustomiFruit()

            AddHandler Tick, AddressOf OnTick
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub AddPhoneContacts(index As Integer)
        Contact(0) = New iFruitContact("Mechanic", index)
        AddHandler Contact(0).Answered, AddressOf Call_Mechanic
        Contact(0).DialTimeout = 5000
        Contact(0).Active = True
        Contact(0).Icon = ContactIcon.LSCustoms
        ifruit.Contacts.Add(Contact(0))

        Contact(1) = New iFruitContact("Pegasus", index + 1)
        AddHandler Contact(1).Answered, AddressOf Call_Pegasus2
        Contact(1).DialTimeout = 5000
        Contact(1).Active = True
        Contact(1).Icon = New ContactIcon("char_pegasus_delivery")
        ifruit.Contacts.Add(Contact(1))

        Contact(2) = New iFruitContact("Warstock Cache & Carry", index + 2)
        AddHandler Contact(2).Answered, AddressOf Call_Warstock
        Contact(2).DialTimeout = 5000
        Contact(2).Active = True
        Contact(2).Icon = New ContactIcon("char_milsite")
        ifruit.Contacts.Add(Contact(2))

        Contact(3) = New iFruitContact("Dock Tease", index + 3)
        AddHandler Contact(3).Answered, AddressOf Call_DockTease
        Contact(3).DialTimeout = 5000
        Contact(3).Active = True
        Contact(3).Icon = ContactIcon.BoatSite
        ifruit.Contacts.Add(Contact(3))

        Contact(4) = New iFruitContact("Legendary Motorsport", index + 4)
        AddHandler Contact(4).Answered, AddressOf Call_Legendary
        Contact(4).DialTimeout = 5000
        Contact(4).Active = True
        Contact(4).Icon = ContactIcon.LegendaryMotorsport
        ifruit.Contacts.Add(Contact(4))

        Contact(5) = New iFruitContact("Elitas Travel", index + 5)
        AddHandler Contact(5).Answered, AddressOf Call_ElitasTravel
        Contact(5).DialTimeout = 5000
        Contact(5).Active = True
        Contact(5).Icon = New ContactIcon("char_planesite")
        ifruit.Contacts.Add(Contact(5))

        Contact(6) = New iFruitContact("Pedal to Metal", index + 6)
        AddHandler Contact(6).Answered, AddressOf Call_PedalToMetal
        Contact(6).DialTimeout = 5000
        Contact(6).Active = True
        Contact(6).Icon = ContactIcon.BikeSite
        ifruit.Contacts.Add(Contact(6))

        Contact(7) = New iFruitContact("Southern SA SuperAutos", index + 7)
        AddHandler Contact(7).Answered, AddressOf Call_SouthernSA
        Contact(7).DialTimeout = 5000
        Contact(7).Active = True
        Contact(7).Icon = ContactIcon.SSASuperAutos
        ifruit.Contacts.Add(Contact(7))

        Contact(8) = New iFruitContact("Benny's Original Motorworks", index + 8)
        AddHandler Contact(8).Answered, AddressOf Call_Benny
        Contact(8).DialTimeout = 5000
        Contact(8).Active = True
        Contact(8).Icon = New ContactIcon("char_carsite3")
        ifruit.Contacts.Add(Contact(8))
    End Sub

    Public Shared Sub Call_Pegasus2()
        Call_Pegasus(True)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        Try
            If phoneContact = "True" Then
                ifruit.Update()

                If Game.IsControlJustPressed(0, GTA.Control.Phone) Then
                    ifruit.Contacts.Clear()

                    Select Case playerName
                        Case "Franklin"
                            AddPhoneContacts(FIndex)
                        Case "Michael"
                            AddPhoneContacts(MIndex)
                        Case "Trevor"
                            AddPhoneContacts(TIndex)
                        Case "Player3"
                            AddPhoneContacts(1)
                    End Select
                End If
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
        Catch ex As Exception
        End Try
    End Sub
End Class
