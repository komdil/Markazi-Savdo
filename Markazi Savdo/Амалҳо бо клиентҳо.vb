Public Class Амалҳо_бо_Мизоҷон

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Дохил_кардани_Мизоҷи_нав.Show()
        Me.Enabled = False
    End Sub

    Private Sub Амалҳо_бо_Мизоҷон_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

 
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Маълумот_оиди_Мизоҷон.Show()
        Me.Enabled = False
    End Sub
End Class