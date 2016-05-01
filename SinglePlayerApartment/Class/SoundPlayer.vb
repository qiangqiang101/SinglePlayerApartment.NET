Imports System
Imports System.IO

Class WaveStream
    Inherits Stream

    Public Overrides ReadOnly Property CanSeek As Boolean
        Get
            ' シークはサポートしない
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property CanRead As Boolean
        Get
            Return Not IsClosed
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            ' 書き込みはサポートしない
            Return False
        End Get
    End Property

    Private ReadOnly Property IsClosed As Boolean
        Get
            Return reader Is Nothing
        End Get
    End Property

    Public Overrides Property Position As Long
        Get
            CheckDisposed()
            Throw New NotSupportedException()
        End Get
        Set(ByVal value As Long)
            CheckDisposed()
            Throw New NotSupportedException()
        End Set
    End Property

    Public Overrides ReadOnly Property Length As Long
        Get
            CheckDisposed()
            Throw New NotSupportedException()
        End Get
    End Property

    Public Property Volume As Integer
        Get
            CheckDisposed()
            Return _volume
        End Get
        Set(ByVal value As Integer)
            CheckDisposed()

            If value < 0 OrElse MaxVolume < value Then
                Throw New ArgumentOutOfRangeException("Volume",
                                                      value,
                                                      String.Format("0から{0}の範囲の値を指定してください", MaxVolume))
            End If

            _volume = value
        End Set
    End Property

    Public Sub New(ByVal baseStream As Stream)
        If baseStream Is Nothing Then Throw New ArgumentNullException("baseStream")
        If Not baseStream.CanRead Then Throw New ArgumentException("読み込み可能なストリームを指定してください", "baseStream")

        reader = New BinaryReader(baseStream)

        ReadHeader()
    End Sub

    Public Overrides Sub Close()
        If Not reader Is Nothing Then
            reader.Close()
            reader = Nothing
        End If
    End Sub

    ' dataチャンクまでのヘッダブロックの内容をバッファに読み込んでおく
    ' WAVEFORMAT等のヘッダ内容のチェックは省略
    Private Sub ReadHeader()
        Using headerStream As New MemoryStream()
            Dim writer As New BinaryWriter(headerStream)

            ' RIFFヘッダ
            Dim riffHeader() As Byte = reader.ReadBytes(12)

            writer.Write(riffHeader)

            ' dataチャンクまでの内容をwriterに書き写す
            Do
                Dim chunkHeader() As Byte = reader.ReadBytes(8)

                writer.Write(chunkHeader)

                Dim fourcc As Integer = BitConverter.ToInt32(chunkHeader, 0)
                Dim size As Integer = BitConverter.ToInt32(chunkHeader, 4)

                If fourcc = &H61746164 Then Exit Do 'data'

                writer.Write(reader.ReadBytes(size))
            Loop

            writer.Close()

            header = headerStream.ToArray()
        End Using
    End Sub

    Public Overrides Function Read(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
        CheckDisposed()

        If buffer Is Nothing Then Throw New ArgumentNullException("buffer")
        If offset < 0 Then Throw New ArgumentOutOfRangeException("offset", offset, "0以上の値を指定してください")
        If count < 0 Then Throw New ArgumentOutOfRangeException("count", count, "0以上の値を指定してください")
        If buffer.Length - count < offset Then Throw New ArgumentException("配列の範囲を超えてアクセスしようとしました", "offset")

        If header Is Nothing Then
            ' dataチャンクの読み込み
            ' WAVEサンプルを読み込み、音量を適用して返す
            ' ストリームは16ビット(1サンプル2バイト)と仮定

            ' countバイト以下となるよう読み込むサンプル数を決定する
            Dim samplesToRead As Integer = count \ 2
            Dim bytesToRead As Integer = samplesToRead * 2
            Dim len As Integer = reader.Read(buffer, offset, bytesToRead)

            If len = 0 Then Return 0 ' 終端まで読み込んだ

            ' 読み込んだサンプル1つずつにボリュームを適用する
            For sample As Integer = 0 To samplesToRead - 1
                Dim s As Short = CShort(buffer(offset)) Or (CShort(buffer(offset + 1)) << 8)

                s = CShort((CInt(s) * _volume) \ MaxVolume)

                buffer(offset) = CByte(s And &HFF)
                buffer(offset + 1) = CByte((s >> 8) And &HFF)

                offset += 2
            Next

            Return len
        Else
            ' ヘッダブロックの読み込み
            ' バッファに読み込んでおいた内容をそのままコピーする
            Dim bytesToRead As Integer = Math.Min(header.Length - headerOffset, count)

            System.Buffer.BlockCopy(header, headerOffset, buffer, offset, bytesToRead)

            headerOffset += bytesToRead

            If headerOffset = header.Length Then
                ' ヘッダブロックを全て読み込んだ
                ' (不要になったヘッダのバッファを解放し、以降はdataチャンクの読み込みに移る)
                header = Nothing
            End If

            Return bytesToRead
        End If
    End Function

    Public Overrides Sub SetLength(ByVal value As Long)
        CheckDisposed()

        Throw New NotSupportedException()
    End Sub

    Public Overrides Function Seek(ByVal offset As Long, ByVal origin As SeekOrigin) As Long
        CheckDisposed()

        Throw New NotSupportedException()
    End Function

    Public Overrides Sub Flush()
        CheckDisposed()

        Throw New NotSupportedException()
    End Sub

    Public Overrides Sub Write(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer)
        CheckDisposed()

        Throw New NotSupportedException()
    End Sub

    Private Sub CheckDisposed()
        If IsClosed Then Throw New ObjectDisposedException(Me.GetType().FullName)
    End Sub

    Private reader As BinaryReader
    Private header() As Byte
    Private headerOffset As Integer = 0
    Private _volume As Integer = MaxVolume
    Private Const MaxVolume As Integer = 100
End Class