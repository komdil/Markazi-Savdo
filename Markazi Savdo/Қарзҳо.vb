Public Class Қарзҳо

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Қарзҳои_ман.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Қарзҳои_Мизоҷон.Show()
        Me.Enabled = False
    End Sub

    Private Sub Қарзҳо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Ҳисоботи_қарзҳои_ман.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Ҳисоботи_қарзҳои_Мизоҷон.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Соф_кардани_қарзҳо.Show()
        Me.Enabled = False
    End Sub

    Private Sub Қарзҳо_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.qarz_klient_del()
    End Sub
End Class