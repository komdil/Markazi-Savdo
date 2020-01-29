Public Class Маълумот_оиди_Мизоҷон

    Private Sub Маълумот_оиди_Мизоҷон_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Амалҳо_бо_Мизоҷон.Enabled = True
        Амалҳо_бо_Мизоҷон.Select()
    End Sub

    Private Sub Маълумот_оиди_Мизоҷон_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sql As String = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from klient"
        Form1.GridView(sql, DataGridView1)
        sql = "Select distinct fio from klient"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from klient where fio= '" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from klient"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text <> "" And Form1.combo(ComboBox1) Then
            Иваз.Show()
            Me.Enabled = False
        End If
    End Sub

End Class