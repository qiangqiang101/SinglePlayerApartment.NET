Public NotInheritable Class logger

    Private Sub New()

    End Sub

    Public Shared Sub Log(message As Object)
        System.IO.File.AppendAllText(".\SPA-" & Now.Month & "-" & Now.Day & "-" & Now.Year & ".log", DateTime.Now & ":" & message & Environment.NewLine)
    End Sub

End Class