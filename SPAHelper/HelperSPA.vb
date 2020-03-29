'Imports System.IO
'Imports System.Windows.Forms
'Imports GTA

'Public Class SPAHelper
'    Inherits Script
'    ' Methods
'    Public Sub New()
'        If Not File.Exists((Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg")) Then
'            Dim path As String = (Application.StartupPath & "\scripts\SinglePlayerApartment\MySave.cfg")
'            Dim str2 As String = (Application.StartupPath & "\scripts\SinglePlayerApartment\save.cfg")
'            Dim str3 As String = (Application.StartupPath & "\scripts\SinglePlayerApartment\save2.cfg")
'            Dim str4 As String = (Application.StartupPath & "\scripts\SinglePlayerApartment\save3.cfg")
'            File.WriteAllText(path, My.Resources.MySave)
'            If File.Exists(str2) Then
'                WriteCfgValue("3ASowner", ReadCfgValue("3ASowner", str2), path)
'                WriteCfgValue("4IWowner", ReadCfgValue("4IWowner", str2), path)
'                WriteCfgValue("DPHwoner", ReadCfgValue("DPHwoner", str2), path)
'                WriteCfgValue("DPHHLowner", ReadCfgValue("DPHHLowner", str2), path)
'                WriteCfgValue("ETowner", ReadCfgValue("ETowner", str2), path)
'                WriteCfgValue("4IWHLowner", ReadCfgValue("4IWHLowner", str2), path)
'                WriteCfgValue("ETHLowner", ReadCfgValue("ETHLowner", str2), path)
'                WriteCfgValue("RMHLowner", ReadCfgValue("RMHLowner", str2), path)
'                WriteCfgValue("TTHLowner", ReadCfgValue("TTHLowner", str2), path)
'                WriteCfgValue("RMowner", ReadCfgValue("RMowner", str2), path)
'                WriteCfgValue("SSowner", ReadCfgValue("SSowner", str2), path)
'                WriteCfgValue("TTowner", ReadCfgValue("TTowner", str2), path)
'                WriteCfgValue("WPowner", ReadCfgValue("WPowner", str2), path)
'                WriteCfgValue("MlastInterior", ReadCfgValue("MlastInterior", str2), path)
'                WriteCfgValue("MlastPosX", ReadCfgValue("MlastPosX", str2), path)
'                WriteCfgValue("MlastPosY", ReadCfgValue("MlastPosY", str2), path)
'                WriteCfgValue("MlastPosZ", ReadCfgValue("MlastPosZ", str2), path)
'                WriteCfgValue("FlastInterior", ReadCfgValue("FlastInterior", str2), path)
'                WriteCfgValue("FlastPosX", ReadCfgValue("FlastPosX", str2), path)
'                WriteCfgValue("FlastPosY", ReadCfgValue("FlastPosY", str2), path)
'                WriteCfgValue("FlastPosZ", ReadCfgValue("FlastPosZ", str2), path)
'                WriteCfgValue("TlastInterior", ReadCfgValue("TlastInterior", str2), path)
'                WriteCfgValue("TlastPosX", ReadCfgValue("TlastPosX", str2), path)
'                WriteCfgValue("TlastPosY", ReadCfgValue("TlastPosY", str2), path)
'                WriteCfgValue("TlastPosZ", ReadCfgValue("TlastPosZ", str2), path)
'                WriteCfgValue("3lastInterior", ReadCfgValue("3lastInterior", str2), path)
'                WriteCfgValue("3lastPosX", ReadCfgValue("3lastPosX", str2), path)
'                WriteCfgValue("3lastPosY", ReadCfgValue("3lastPosY", str2), path)
'                WriteCfgValue("3lastPosZ", ReadCfgValue("3lastPosZ", str2), path)
'                File.Delete(str2)
'            End If
'            If File.Exists(str3) Then
'                WriteCfgValue("VPBowner", ReadCfgValue("VPBowner", str3), path)
'                WriteCfgValue("2044NCowner", ReadCfgValue("2044NCowner", str3), path)
'                WriteCfgValue("2862HAowner", ReadCfgValue("2862HAowner", str3), path)
'                WriteCfgValue("2868HAowner", ReadCfgValue("2868HAowner", str3), path)
'                WriteCfgValue("3655WODowner", ReadCfgValue("3655WODowner", str3), path)
'                WriteCfgValue("2045NCowner", ReadCfgValue("2045NCowner", str3), path)
'                WriteCfgValue("2117MRowner", ReadCfgValue("2117MRowner", str3), path)
'                WriteCfgValue("2874HAowner", ReadCfgValue("2874HAowner", str3), path)
'                WriteCfgValue("3677WMDowner", ReadCfgValue("3677WMDowner", str3), path)
'                WriteCfgValue("2113MWTowner", ReadCfgValue("2113MWTowner", str3), path)
'                WriteCfgValue("ETP1owner", ReadCfgValue("ETP1owner", str3), path)
'                WriteCfgValue("ETP2owner", ReadCfgValue("ETP2owner", str3), path)
'                WriteCfgValue("ETP3owner", ReadCfgValue("ETP3owner", str3), path)
'                WriteCfgValue("ETP1ipl", ReadCfgValue("ETP1ipl", str3), path)
'                WriteCfgValue("ETP2ipl", ReadCfgValue("ETP2ipl", str3), path)
'                WriteCfgValue("ETP3ipl", ReadCfgValue("ETP3ipl", str3), path)
'                File.Delete(str3)
'            End If
'            If File.Exists(str4) Then
'                WriteCfgValue("CAowner", ReadCfgValue("CAowner", str4), path)
'                WriteCfgValue("BCAowner", ReadCfgValue("BCAowner", str4), path)
'                WriteCfgValue("0184MRowner", ReadCfgValue("0184MRowner", str4), path)
'                WriteCfgValue("0325SRDowner", ReadCfgValue("0325SRDowner", str4), path)
'                WriteCfgValue("SMMowner", ReadCfgValue("SMMowner", str4), path)
'                WriteCfgValue("0604LLBowner", ReadCfgValue("0604LLBowner", str4), path)
'                WriteCfgValue("SAonwer", ReadCfgValue("SAonwer", str4), path)
'                WriteCfgValue("BDPowner", ReadCfgValue("BDPowner", str4), path)
'                WriteCfgValue("PSowner", ReadCfgValue("PSowner", str4), path)
'                WriteCfgValue("PPSowner", ReadCfgValue("PPSowner", str4), path)
'                WriteCfgValue("SVSowner", ReadCfgValue("SVSowner", str4), path)
'                WriteCfgValue("2143LLBowner", ReadCfgValue("2143LLBowner", str4), path)
'                WriteCfgValue("TRowner", ReadCfgValue("TRowner", str4), path)
'                WriteCfgValue("HAowner", ReadCfgValue("HAowner", str4), path)
'                WriteCfgValue("SRowner", ReadCfgValue("SRowner", str4), path)
'                WriteCfgValue("4401PDowner", ReadCfgValue("4401PDowner", str4), path)
'                WriteCfgValue("4584PDowner", ReadCfgValue("4584PDowner", str4), path)
'                WriteCfgValue("0112SRDowner", ReadCfgValue("0112SRDowner", str4), path)
'                WriteCfgValue("ZAowner", ReadCfgValue("ZAowner", str4), path)
'                WriteCfgValue("PBowner", ReadCfgValue("PBowner", str4), path)
'                WriteCfgValue("GAowner", ReadCfgValue("GAowner", str4), path)
'                File.Delete(str4)
'            End If
'            File.Delete((Application.StartupPath & "\scripts\HelperSPA.dll"))
'        Else
'            File.Delete((Application.StartupPath & "\scripts\HelperSPA.dll"))
'        End If
'    End Sub
'End Class

'Public Module CFGread
'    Public Function ReadCfgValue(ByVal key As String, ByVal file As String) As String
'        Dim lines As String() = IO.File.ReadAllLines(file)
'        Dim temp As String = Nothing
'        Dim value As String = Nothing

'        For Each l As String In lines
'            If l.StartsWith(key) Then
'                temp = l.Substring(key.Length + 1)
'                value = temp.Replace(Chr(34), "")
'                Exit For
'            End If
'        Next
'        Return value
'    End Function

'    Public Sub WriteCfgValue(ByVal key As String, ByVal value As String, ByVal file__1 As String)
'        Dim getext As String = file__1.Substring(file__1.LastIndexOf("."c))
'        Dim tmp As String = file__1.Replace(getext, ".tmp")
'        Using sr = New IO.StreamReader(file__1)
'            Using wr = New IO.StreamWriter(tmp)
'                Dim line As String
'                Dim check As Boolean = False
'                Do
'                    line = sr.ReadLine()
'                    If line Is Nothing Then Exit Do 'Check if line is null then Exit Loop

'                    If line.StartsWith(key) Then
'                        line = String.Format("{0} ""{1}""", key, value)
'                        check = True
'                    End If
'                    wr.WriteLine(line)
'                Loop
'                If Not check Then
'                    wr.WriteLine(String.Format("{0} ""{1}""", key, value))
'                End If
'                sr.Close()
'                wr.Close()
'            End Using
'        End Using
'        IO.File.Delete(file__1)
'        IO.File.Move(tmp, file__1)
'    End Sub
'End Module

