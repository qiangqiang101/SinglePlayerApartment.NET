Module Helper

    Public Function TextToImage(ByVal txt As String, ByVal fontname As String, ByVal fontsize As Integer, ByVal brush As Brush) As Bitmap
        Dim bmp As Bitmap = New Bitmap(1, 1)
        Dim graphics As Graphics = Graphics.FromImage(bmp)
        Dim font As Font = New Font(fontname, fontsize)
        Dim stringSize As SizeF = graphics.MeasureString(txt, font)
        bmp = New Bitmap(bmp, CInt(stringSize.Width), CInt(stringSize.Height))
        graphics = Graphics.FromImage(bmp)
        graphics.DrawString(txt, font, brush, 0, 0)
        font.Dispose()
        graphics.Flush()
        graphics.Dispose()
        Return bmp
    End Function

End Module
