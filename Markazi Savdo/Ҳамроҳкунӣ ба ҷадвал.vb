Public Class Ҳамроҳкунӣ_ба_ҷадвал
    '    Бор
    'Қарзи ман
    'Қарзи Мизоҷ
    Dim jadval As String
    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Button1.Enabled = True
        Dim sql As String
        If ComboBox1.Text = "Бор" Then
            ComboBox2.Visible = False
            sql = "select nom as [Номи бор], shtuk as [Штук] from bor"
            Form1.GridView(sql, DataGridView1)
            jadval = "bor"
            TextBox1.Visible = True
            TextBox1.Enabled = True

        ElseIf ComboBox1.Text = "Қарзи ман" Then
            sql = "select  fio as [Номи бороваранда], miq_qarz as [Миқдори қарз] from qarzi_man, borovaranda where borovaranda.id_borovaranda=qarzi_man.id_borovaranda"
            Form1.GridView(sql, DataGridView1)
            sql = "select fio from borovaranda"
            Form1.connection(sql, ComboBox2, 0)
            TextBox1.Enabled = False
            TextBox1.Visible = False
            ComboBox2.Visible = True
            jadval = "qarzi_man"
        ElseIf ComboBox1.Text = "Қарзи Мизоҷ" Then
            sql = "select  fio as [Ном], miq_qarz as [Миқдори қарз] from qarzi_klient, klient where klient.id_klient=qarzi_klient.id_klient"
            Form1.GridView(sql, DataGridView1)
            sql = "select fio from klient"
            Form1.connection(sql, ComboBox2, 0)
            TextBox1.Enabled = False
            TextBox1.Visible = False
            ComboBox2.Visible = True
            jadval = "qarzi_klient"
        End If
    End Sub

    Private Sub Ҳамроҳкунӣ_ба_ҷадвал_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Кор_бо_ҷадвалҳо.Enabled = True
        Кор_бо_ҷадвалҳо.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text <> "" And TextBox3.Text <> "" And IsNumeric(TextBox3.Text) = True Then
                If jadval = "bor" And TextBox1.Text <> "" Then
                    Form1.for_bor(TextBox1.Text, TextBox3.Text)
                    TextBox1.Enabled = False
                    MsgBox("Бор дохил карда шуд!!!")
                    Button1.Enabled = False
                ElseIf jadval = "qarzi_man" And ComboBox2.Text <> "" Then
                    Form1.qarzs(ComboBox2.Text, TextBox3.Text)
                    MsgBox("Қарз дохил карда шуд!!!")
                    Button1.Enabled = False
                ElseIf jadval = "qarzi_klient" And ComboBox2.Text <> "" And Form1.combo(ComboBox2) Then
                    Form1.qarzi_klient(ComboBox2.Text, TextBox3.Text)
                    MsgBox("Қарз дохил карда шуд!!!")
                    Button1.Enabled = False
                Else
                    MsgBox("Сатрҳоро дуруст пур кунед!!!")
                End If
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      
    End Sub
End Class