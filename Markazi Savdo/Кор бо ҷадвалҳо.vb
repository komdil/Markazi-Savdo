Public Class Кор_бо_ҷадвалҳо

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Тағйирдиҳии_ҷадвалҳо.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Ҳамроҳкунӣ_ба_ҷадвал.Show()
        Me.Enabled = False
    End Sub

    Private Sub Кор_бо_ҷадвалҳо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

End Class