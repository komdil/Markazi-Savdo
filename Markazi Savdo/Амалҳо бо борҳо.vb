Public Class Амалҳо_бо_борҳо

    Private Sub Амалҳо_бо_борҳо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Show()
        Form1.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Дохил_намудани_бори_нав.Show()
        Me.Enabled = False
    End Sub

    

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Таърихи_борҳо.Show()
        Me.Enabled = False
    End Sub

    Private Sub Амалҳо_бо_борҳо_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Борҳои_мавҷудбуда.Show()
        Me.Enabled = False
    End Sub
End Class