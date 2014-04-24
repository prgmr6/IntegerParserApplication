Public Class DefaultForm

    Private Sub btnOne_Click(sender As Object, e As EventArgs) Handles btnOne.Click

        lblErrorOutput.Text = ""
        Dim bc As New BaseClass()
        Dim splitArray As New List(Of String)()
        If bc.CheckNumbers(textBox1.Text, splitArray) = False Then
            lblErrorOutput.Text = bc.ErrorString
            Return
        End If
        Dim mylist As List(Of Integer) = splitArray.[Select](Function(n) Integer.Parse(n)).ToList()
        Dim sum As Sum = bc.RetrieveIndexOfTopSum(mylist)
        lblMethodOneTime.Text = bc.RunTime()
        lblMethodOneAnswer.Text = sum.minValue.ToString()

    End Sub

    Private Sub btnTwo_Click(sender As Object, e As EventArgs) Handles btnTwo.Click

        lblErrorOutput.Text = ""
        Dim bc As New BaseClass()
        Dim splitArray As New List(Of String)()
        If bc.CheckNumbers(textBox1.Text, splitArray) = False Then
            lblErrorOutput.Text = bc.ErrorString
            Return
        End If
        Dim mylist As List(Of Integer) = splitArray.[Select](Function(n) Integer.Parse(n)).ToList()
        Dim sum As New Sum(Integer.MinValue, Integer.MinValue)
        bc.RetrieveIndexOfTopSum(mylist, sum)
        lblMethodTwoTime.Text = bc.RunTime()
        lblMethodTwoAnswer.Text = sum.minValue.ToString()

    End Sub

    Private Sub btnThree_Click(sender As Object, e As EventArgs) Handles btnThree.Click

        lblErrorOutput.Text = ""
        Dim bc As New BaseClass()
        Dim splitArray As New List(Of String)()
        If bc.CheckNumbers(textBox1.Text, splitArray) = False Then
            lblErrorOutput.Text = bc.ErrorString
            Return
        End If
        Dim mylist As List(Of Integer) = splitArray.[Select](Function(n) Integer.Parse(n)).ToList()
        Dim sums As IEnumerable(Of Sum) = New List(Of Sum)()
        Dim sum As Sum = bc.RetrieveIndexOfTopSum(mylist, sums)
        lblMethodThreeTime.Text = bc.RunTime()
        lblMethodThreeAnswer.Text = sum.minValue.ToString()

    End Sub
End Class
