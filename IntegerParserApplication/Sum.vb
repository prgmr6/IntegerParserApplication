
Public Class Sum
    Public Property minValue() As Integer
        Get
            Return m_minValue
        End Get
        Set(value As Integer)
            m_minValue = Value
        End Set
    End Property
    Private m_minValue As Integer
    Public Property maxValue() As Integer
        Get
            Return m_maxValue
        End Get
        Set(value As Integer)
            m_maxValue = Value
        End Set
    End Property
    Private m_maxValue As Integer
    Public Sub New(i As Integer, p As Integer)
        minValue = If(i > p, p, i)
        maxValue = If(i > p, i, p)
    End Sub
    Public Function Add() As Integer
        Return minValue + maxValue
    End Function
    Public Overrides Function ToString() As String
        Return minValue + " : " + maxValue
    End Function
End Class
