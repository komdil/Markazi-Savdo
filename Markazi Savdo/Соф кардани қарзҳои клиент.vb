Public Class Соф_кардани_қарзҳои_Мизоҷ

    Private Sub Соф_кардани_қарзҳои_Мизоҷ_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Соф_кардани_қарзҳо.Enabled = True
        Соф_кардани_қарзҳо.Select()
    End Sub

    Private Sub Соф_кардани_қарзҳои_Мизоҷ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Миқдори қарз] from qarzi_klient, klient where miq_qarz>0 and klient.id_klient=qarzi_klient.id_klient"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from klient, qarzi_klient where miq_qarz>0 and klient.id_klient=qarzi_klient.id_klient"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text <> "" And TextBox1.Text <> "" And IsNumeric(TextBox1.Text) = True And TextBox1.Text > 0 And Form1.combo(ComboBox1) Then
                If TextBox1.Text <= Form1.prover_qarz_k(ComboBox1.Text) Then
                    Dim sql As String
                    sql = "insert into his_qarzi_klient values(null,(select id_klient from klient where fio='" & ComboBox1.Text & "'),(select miq_qarz from qarzi_klient where id_klient=(select id_klient from klient where fio='" & ComboBox1.Text & "'))," & TextBox1.Text & ",(select miq_qarz from qarzi_klient where id_klient=(select id_klient from klient where fio='" & ComboBox1.Text & "'))-" & TextBox1.Text & ",'" & DateTimePicker1.Text & "')"
                    Form1.insert(sql)
                    sql = "update qarzi_klient set miq_qarz=miq_qarz-" & TextBox1.Text & " where id_klient=(select id_klient from klient where fio='" & ComboBox1.Text & "')"
                    Form1.insert(sql)
                    Form1.ForKassa2(Long.Parse(TextBox1.Text))
                Else
                    MsgBox("Сатрҳоро дуруст пур кунед!!!")
                End If
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!!!")
            End If
            Dim sql2 As String = "select fio as [Номи Мизоҷ], miq_qarz as [Миқдори қарз] from qarzi_klient, klient where miq_qarz>0 and klient.id_klient=qarzi_klient.id_klient"
            Form1.GridView(sql2, DataGridView1)
            sql2 = "select distinct fio from klient,qarzi_klient   where miq_qarz>0 and klient.id_klient=qarzi_klient.id_klient"
            Form1.connection(sql2, ComboBox1, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
      
      
    End Sub
End Class