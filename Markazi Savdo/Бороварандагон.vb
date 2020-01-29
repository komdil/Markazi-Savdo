Public Class Бороварандагон

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Бороварандаи_нав.Show()
        Me.Enabled = False
    End Sub

    Private Sub Бороварандагон_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Рӯйхати_боровардагон.Show()
        Me.Enabled = False
    End Sub

    Private Sub Бороварандагон_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class