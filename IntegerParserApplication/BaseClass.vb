Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Public Class BaseClass
    ''' <summary>
    ''' ctor
    ''' </summary>

    Public Sub New()
    End Sub
    Private _ts As TimeSpan = DateTime.Now.TimeOfDay

    Private _errorString As String = String.Empty

    Public Property ErrorString() As String
        Get
            Return _errorString
        End Get
        Set(value As String)
            _errorString = value
        End Set
    End Property

    Public Function RunTime() As [String]
        Return DateTime.Now.TimeOfDay.Subtract(_ts).ToString()
    End Function
    ''' <summary>
    ''' Make sure that the string is parseable using delimiters and the values are ints.
    ''' </summary>
    ''' <param name="stringOfNumbers"></param>
    ''' <returns></returns>
    Public Function CheckNumbers(stringOfNumbers As String, ByRef newList As List(Of String)) As Boolean

        Dim mylist As List(Of String) = stringOfNumbers.Split(","c).ToList()
        Dim stringArray As String() = New String(mylist.Count - 1) {}
        mylist.CopyTo(stringArray)
        For Each str As String In stringArray
            Dim i As Integer = Integer.MinValue
            If Integer.TryParse(str, i) = False Then
                If str.Trim() = "" Then
                    mylist.Remove(str)
                Else
                    _errorString = "Value " + str.Trim() + " is not in correct integer form."
                    newList = mylist
                    Return False
                End If
            End If
        Next
        newList = mylist
        Return True
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RetrieveIndexOfTopSum(source As IEnumerable(Of Integer)) As Sum
        Dim tempList As New List(Of Integer)(source)
        tempList.Sort()
        Return New Sum(tempList(tempList.Count - 2), tempList(tempList.Count - 1))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="sum"></param>
    ''' <remarks></remarks>
    Public Sub RetrieveIndexOfTopSum(source As IEnumerable(Of Integer), ByRef sum As Sum)
        Dim keepTrack As Integer = Integer.MinValue
        Dim localCopy As List(Of Integer) = source.ToList()
        sum = New Sum(Integer.MinValue, Integer.MinValue)
        For Each i As Integer In source
            Dim currentSum As Integer = Integer.MinValue
            For Each p As Integer In localCopy
                If i <> p Then
                    currentSum = i + p
                    If currentSum > keepTrack Then
                        sum = New Sum(p, i)
                        keepTrack = currentSum
                    End If
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="sums"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RetrieveIndexOfTopSum(source As IEnumerable(Of Integer), sums As IEnumerable(Of Sum)) As Sum
        Dim localCopy As List(Of Integer) = source.ToList()
        Dim sum As New Sum(Integer.MinValue, Integer.MinValue)
        sums =
            From c In localCopy
            From p In source
            Where c <> p
            Select New Sum(c, p)

        sum = sums.OrderByDescending(Function(t) t.Add()).First()
        Return sum
    End Function
End Class
