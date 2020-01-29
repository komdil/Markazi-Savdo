Public Class Қарзҳои_ман
    Private Sub Қарзҳои_ман_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳо.Enabled = True
        Қарзҳо.Select()
    End Sub

    Private Sub Қарзҳои_ман_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.qarz_delete()
        Dim sql As String = "select fio  as [Номи бороваранда],miq_qarz as [Миқдори қарз] from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda "
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio  from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda  "
        Form1.connection(sql, ComboBox1, 0)
        sql = "select sum(miq_qarz) from qarzi_man"
        Label2.Text = Label2.Text & "  " & Form1.ret(sql)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio  as [Номи бороваранда],miq_qarz as [Миқдори қарз] from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda and fio='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select fio  as [Номи бороваранда],miq_qarz as [Миқдори қарз] from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda "
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Form1.combo(ComboBox1) And ComboBox1.Text <> "") Then
            Me.Enabled = False
            Ивази_қарз.Show()
        End If
    End Sub
End Class