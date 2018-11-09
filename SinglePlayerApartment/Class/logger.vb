Imports System.Windows.Forms

Public NotInheritable Class logger

    Private Sub New()

    End Sub

    Public Shared Sub Log(message As Object)
        If ReadCfgValue("ErrorLogs", Application.StartupPath & "\scripts\SinglePlayerApartment\setting.cfg") = "True" Then System.IO.File.AppendAllText(".\SPA.log", String.Format("[{0}] {1}{2}", DateTime.Now, message, Environment.NewLine))
    End Sub

    Public Shared Sub PinPoint(message As GTA.Math.Vector3)
        System.IO.File.AppendAllText(".\PinPoint.log", String.Format("{0}:{1},{2},{3}{4}", DateTime.Now, message.X, message.Y, message.Z, Environment.NewLine))
        GTA.UI.Notify(String.Format("{0}:Position Saved.", DateTime.Now))
    End Sub

End Class