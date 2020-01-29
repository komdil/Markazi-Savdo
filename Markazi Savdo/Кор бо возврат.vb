Public Class Кор_бо_возврат

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Возврат.Show()
        Me.Enabled = False
    End Sub

    Private Sub Кор_бо_возврат_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Отчети_возврат.Show()
        Me.Enabled = False
    End Sub
End Class