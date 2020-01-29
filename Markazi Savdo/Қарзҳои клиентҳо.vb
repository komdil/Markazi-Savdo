Public Class Қарзҳои_Мизоҷон

    Private Sub Қарзҳои_Мизоҷон_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳо.Enabled = True
        Қарзҳо.Select()
    End Sub

    Private Sub Қарзҳои_Мизоҷон_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Миқдори қарз] from qarzi_klient,klient where klient.id_klient=qarzi_klient.id_klient"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from qarzi_klient,klient where klient.id_klient=qarzi_klient.id_klient"
        Form1.connection(sql, ComboBox1, 0)
        sql = "select sum(miq_qarz) from qarzi_klient"
        Label2.Text = Label2.Text & "  " & Form1.ret(sql)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Миқдори қарз] from qarzi_klient, klient where klient.id_klient=qarzi_klient.id_klient and  fio='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Миқдори қарз] from qarzi_klient,klient where klient.id_klient=qarzi_klient.id_klient"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Form1.combo(ComboBox1) And ComboBox1.Text <> "") Then
            Me.Enabled = False
            Ивази_қарзи_Мизоҷ.Show()
        End If
    End Sub
End Class