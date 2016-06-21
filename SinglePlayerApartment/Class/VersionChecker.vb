Imports GTA
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class VersionChecker
    Inherits Script

    Public Shared Checker As Timer
    Public Shared Version As String

    Public Sub New()
        GetMD5()
        Checker = New Timer(300000)
        Checker.Start()
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles MyBase.Tick
        Try
            If Checker.Enabled Then
                If Game.GameTime > Checker.Waiter Then
                    Checker.Enabled = False
                    Select Case Version
                        Case "2.9", "2.8", "2.7", "2.6.2", "2.6.1", "2.6", "2.5.1", "2.5", "2.4", "2.3", "2.2", "2.1", "2.0", "1.1", "1.0", "0.9", "0.8", "0.6", "0.5"
                            SinglePlayerApartment.DisplayNotificationThisFrame("Single Player Apartment", "", "Your Community Script Hook V.NET version is Out of Date, Some Features will be disabled.", "CHAR_SOCIAL_CLUB", True, SinglePlayerApartment.IconType.RightJumpingArrow)
                            Checker.Start()
                        Case Else
                            Checker.Enabled = False
                    End Select
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub GetMD5()
        Try
            Dim rd As FileStream = New FileStream(Application.StartupPath & "\ScriptHookVDotNet.asi", FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
            md5.ComputeHash(rd)
            rd.Close()

            Dim hash As Byte() = md5.Hash
            Dim sb As StringBuilder = New StringBuilder
            Dim hb As Byte
            For Each hb In hash
                sb.Append(String.Format("{0:X1}", hb))
            Next

            Select Case sb.ToString.ToLower
                Case "de9fe83108d5dfcb93e5242a67123432"
                    Version = "2.9.2"
                Case "d41d8cd98f00b204e9800998ecf8427e"
                    Version = "2.9"
                Case "0d2b5ae54b1fe18536d1071433e37f75"
                    Version = "2.8"
                Case "0abc625ef888fd470bed7ac346923edf"
                    Version = "2.7"
                Case "379c82bb2b6630d82275adf4369edb1a"
                    Version = "2.6.2"
                Case "fd8892e99ddcc43fb09cbb8a2be85f4b"
                    Version = "2.6.1"
                Case "fa69c0cecff82733556a59529aa32d1e"
                    Version = "2.6"
                Case "ef28844c9e78639c217627dc302698f9"
                    Version = "2.5.1"
                Case "af7a279c1163dfa6f2d902360829beb8"
                    Version = "2.5"
                Case "c3515b96a44bfab448e104da8e8bee54"
                    Version = "2.4"
                Case "3d3e25c48f03546b5820d157c190ef1f"
                    Version = "2.3"
                Case "fe5281bacb2c737dd60bf817b58fe380"
                    Version = "2.2"
                Case "2616cf250ea63b4dee66755d511ab547"
                    Version = "2.1"
                Case "8a5077b1f7335337b27c0254b898add5"
                    Version = "2.0"
                Case "68bf4bf432f95c1c18a6d290c8241c71"
                    Version = "1.1"
                Case "a0a8185857a6fcdd8efec9413bc36ed7"
                    Version = "1.0"
                Case "580736df3ce70058f5bbad70a32ee7ac"
                    Version = "0.9"
                Case "a3b4f4f092a2e9cdd3aed778232da54d"
                    Version = "0.8"
                Case "76b4002ebdb12cb5c8d6bc15aac107a0"
                    Version = "0.6"
                Case "0746308b8eb9a2ad06404fd0bb3b7271"
                    Version = "0.5"
                Case Else
                    Version = "Unknown"
            End Select
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
End Class
