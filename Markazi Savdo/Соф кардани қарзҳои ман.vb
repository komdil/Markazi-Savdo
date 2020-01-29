Public Class Соф_кардани_қарзҳои_ман

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.qarz_delete()
        Try

       
        If ComboBox1.Text <> "" And TextBox1.Text <> "" And IsNumeric(TextBox1.Text) = True And TextBox1.Text > 0 And Form1.combo(ComboBox1) Then
            If TextBox1.Text <= Form1.prover_qarz(ComboBox1.Text) Then
                Dim sql As String
                    sql = "insert into his_qarzi_man values(null,(select id_borovaranda from borovaranda where fio='" & ComboBox1.Text & "'),(select miq_qarz from qarzi_man where id_borovaranda=(select id_borovaranda from borovaranda where fio='" & ComboBox1.Text & "'))," & TextBox1.Text & ",(select miq_qarz from qarzi_man where id_borovaranda=(select id_borovaranda from borovaranda where fio='" & ComboBox1.Text & "'))-" & TextBox1.Text & ",'" & DateTimePicker1.Text & "')"
                    Form1.insert(sql)
                    sql = "update qarzi_man set miq_qarz=miq_qarz- " & TextBox1.Text & " where id_borovaranda=(select id_borovaranda from borovaranda where fio= '" & ComboBox1.Text & "')"
                Form1.insert(sql)
                sql = "select fio  as [Номи бороваранда],miq_qarz as [Миқдори қарз] from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda "
                    Form1.GridView(sql, DataGridView1)
                    Form1.ForKassa(Long.Parse(TextBox1.Text))
                    TextBox1.Clear()
                ComboBox1.Items.Clear()
                    sql = "select distinct fio  from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda  "
                Form1.connection(sql, ComboBox1, 0)
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!!!")
            End If
        Else
            MsgBox("Сатрҳоро дуруст пур кунед!!!")
        End If
        Form1.qarz_delete()
        Dim sql2 As String
        sql2 = "select fio  as [Номи бороваранда],miq_qarz as [Миқдори қарз] from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda "
        Form1.GridView(sql2, DataGridView1)
        sql2 = "select distinct fio  from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda  "
        Form1.connection(sql2, ComboBox1, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Соф_кардани_қарзҳои_ман_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Соф_кардани_қарзҳо.Enabled = True
        Соф_кардани_қарзҳо.Select()
    End Sub

    Private Sub Соф_кардани_қарзҳои_ман_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.qarz_delete()
        Dim sql As String = "select fio  as [Номи бороваранда],miq_qarz as [Миқдори қарз] from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda "
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio  from  borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda  "
        Form1.connection(sql, ComboBox1, 0)

    End Sub
End Class