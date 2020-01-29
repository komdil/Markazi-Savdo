Public Class Соф_кардани_қарзҳо

    Private Sub Соф_кардани_қарзҳо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳо.Enabled = True
        Қарзҳо.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Соф_кардани_қарзҳои_ман.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Соф_кардани_қарзҳои_Мизоҷ.Show()
        Me.Enabled = False
    End Sub
End Class