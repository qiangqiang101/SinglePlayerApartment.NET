Imports GTA

Public Class Timer
#Region "Public Variables"
    Private m_enabled As Boolean
    Public Property Enabled() As Boolean
        Get
            Return m_enabled
        End Get
        Set
            m_enabled = Value
        End Set
    End Property

    Private m_interval As Integer
    Public Property Interval() As Integer
        Get
            Return m_interval
        End Get
        Set
            Me.m_interval = Value
        End Set
    End Property
#End Region

    Private m_waiter As Integer
    Public Property Waiter() As Integer
        Get
            Return m_waiter
        End Get
        Set
            Me.m_waiter = Value
        End Set
    End Property

    Public Sub New(interval As Integer)
        Me.m_interval = interval
        Me.m_waiter = 0
        Me.m_enabled = False
    End Sub

    Public Sub New()
        Me.m_interval = 0
        Me.m_waiter = 0
        Me.m_enabled = False
    End Sub

    Public Sub Start()
        Me.m_waiter = Game.GameTime + m_interval
        Me.m_enabled = True
    End Sub

    Public Sub Reset()
        Me.m_waiter = Game.GameTime + m_interval
    End Sub

End Class