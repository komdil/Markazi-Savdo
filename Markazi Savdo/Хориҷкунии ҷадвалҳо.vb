Public Class Тағйирдиҳии_ҷадвалҳо
    Public jadval As String
    Private Sub Тағйирдиҳии_ҷадвалҳо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Кор_бо_ҷадвалҳо.Enabled = True
        Кор_бо_ҷадвалҳо.Select()
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim sql As String
        Button2.Enabled = True
        If ComboBox1.Text = "Борҳо" Then
            sql = "select id_bor as [Индекс] , nom as [Ном], shtuk as [Штук] from bor"
            Form1.GridView(sql, DataGridView1)
            jadval = "bor"
        ElseIf ComboBox1.Text = "Таърихи борҳо" Then
            sql = "select id_bor as [Индекс], fio as [Номи бороваранда], nom as [Номи бор], miqdori_qutti as [Миқдори каробка], miq_bori_qutti as [Миқдори бори қуттӣ], narhi_yak_dona as [Нархи як дона бор], puli_paddohtshuda as [Пули пардохтшуда], sana as [Сана] from borho,borovaranda where borho.id_borovaranda=borovaranda.id_borovaranda"
            Form1.GridView(sql, DataGridView1)
            jadval = "borho"
        ElseIf ComboBox1.Text = "Таърихи Савдо" Then
            sql = "select id_savdo as [Индекс], (select fio from klient,savdo where klient.id_klient=savdo.id_klient) as [Номи Мизоҷ], nomi_bor as [Номи бор], shtuk as [Штук], narhi_furuht as [Нархи фурӯхт], puli_pardoht as [Пули пардохт], foida as [Фоида], sana as [Сана] from savdo"
            Form1.GridView(sql, DataGridView1)
            jadval = "savdo"
        ElseIf ComboBox1.Text = "Ҳисоботи қарзи Мизоҷ" Then
            sql = "select (select id_his_qarzi_klient) as [Индекс],(select fio from klient,his_qarzi_klient where his_qarzi_klient.id_klient=klient.id_klient) as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана] from his_qarzi_klient"
            Form1.GridView(sql, DataGridView1)
            jadval = "his_qarzi_klient"
        ElseIf ComboBox1.Text = "Ҳисоботи қарзи ман" Then
            sql = "select  id_his_qarzi_man as [Индекс],fio as [Номи бороваранда], qarz as [Қарзе, ки буд], pard as [Пуле, ки пардохт шуд], boqi as [Миқдоре, ки боқи монд], sana as [Сана] from his_qarzi_man,borovaranda where his_qarzi_man.id_borovaranda=borovaranda.id_borovaranda"
            Form1.GridView(sql, DataGridView1)
            jadval = "his_qarzi_man"
        ElseIf ComboBox1.Text = "Возврат" Then
            sql = "select id_vozvrat as [Индекс] , id_borho as [Номи бор], miq as [Миқдори бор], narh as [Нарх], puli_s as [Пули супорида], sana as [Сана] from vozvrat"
            jadval = "vozvrat"
            Form1.GridView(sql, DataGridView1)
        ElseIf ComboBox1.Text = "хароҷот" Then
            sql = "select id_rashod as [Индекс] , nom as [Ном], miqdor as [Миқдори хароҷот] , sana as [Сана] from rashod"
            jadval = "rashod"
            Form1.GridView(sql, DataGridView1)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim sql As String
            If ComboBox1.Text <> "" And IsNumeric(TextBox1.Text) = True Then
                If jadval = "borho" Then
                    sql = "select puli_paddohtshuda from borho where id_bor=" & TextBox1.Text
                    Dim kas As String = Form1.ret(sql)

                    If Integer.Parse(kas) > 0 Then
                        '   Form1.ForKassa2(kas)
                    End If
                    sql = "select nom from borho where  borho.id_bor=" & TextBox1.Text
                    Dim nom As String = Form1.ret(sql)

                    sql = "select miq_bori_qutti*miqdori_qutti from borho where id_bor=" & TextBox1.Text
                    Dim miq As Integer = Form1.ret(sql)
                    Form1.for_bor(nom, -miq)
                    sql = "select miqdori_qutti*miq_bori_qutti*narhi_yak_dona -puli_paddohtshuda from borho where id_bor=" & TextBox1.Text
                    Dim pul As Long = Form1.ret(sql)
                    sql = "select fio from borovaranda,borho where borho.id_borovaranda=borovaranda.id_borovaranda and  id_bor=" & TextBox1.Text
                    Dim fio As String = Form1.ret(sql)
                    Form1.qarzs(fio, -pul)
                    sql = "delete from borho where id_bor=" & TextBox1.Text
                    Form1.insert(sql)
                    Button2.Enabled = False
                ElseIf jadval = "rashod" Then
                    sql = "select miqdor from rashod where id_rashod=" & TextBox1.Text
                    Form1.ForKassa2(Form1.ret(sql))
                    sql = "delete from rashod where id_rashod =" & TextBox1.Text
                    Form1.insert(sql)
                    Button2.Enabled = False
                ElseIf jadval = "savdo" Then
                    sql = "select puli_pardoht from savdo where id_savdo=" & TextBox1.Text
                    Form1.ForKassa(Form1.ret(sql))
                    sql = "select nomi_bor from savdo where id_savdo =" & TextBox1.Text
                    Dim bor As String
                    bor = Form1.ret(sql)
                    sql = "select shtuk from savdo where id_savdo =" & TextBox1.Text
                    Dim shtuk As Integer = Form1.ret(sql)
                    sql = "select puli_dog-puli_pardoht from savdo where id_savdo =" & TextBox1.Text
                    Dim qarz As Long = Form1.ret(sql)
                    sql = "select id_klient from savdo where id_savdo =" & TextBox1.Text
                    Dim id As Integer = Form1.ret(sql)
                    sql = "select fio from klient where id_klient=" & id
                    Dim fio As String = Form1.ret(sql)
                    Form1.for_bor(bor, shtuk)
                    Form1.qarzi_klient(fio, -qarz)
                    sql = "delete from savdo where id_savdo=" & TextBox1.Text
                    Form1.insert(sql)
                    Button2.Enabled = False
                ElseIf jadval = "his_qarzi_man" Then
                    sql = "select pard from his_qarzi_man where id_his_qarzi_man=" & TextBox1.Text
                    Form1.ForKassa2(Form1.ret(sql))
                    sql = "select id_borovaranda from his_qarzi_man where id_his_qarzi_man=" & TextBox1.Text
                    Dim id As Integer = Form1.ret(sql)
                    sql = "select pard from his_qarzi_man where id_his_qarzi_man=" & TextBox1.Text
                    Dim qarz As Long = Form1.ret(sql)
                    Dim nom As String
                    sql = "select fio from borovaranda where id_borovaranda=" & id
                    nom = Form1.ret(sql)
                    Form1.qarzs(nom, qarz)
                    sql = "delete from his_qarzi_man where  id_his_qarzi_man=" & TextBox1.Text
                    Form1.insert(sql)
                    Button2.Enabled = False
                ElseIf jadval = "his_qarzi_klient" Then
                    sql = "select pard from his_qarzi_klient where id_his_qarzi_klient=" & TextBox1.Text
                    Form1.ForKassa(Form1.ret(sql))
                    sql = "select id_klient from his_qarzi_klient where id_his_qarzi_klient=" & TextBox1.Text
                    Dim id As Integer = Form1.ret(sql)
                    sql = "select pard from his_qarzi_klient where id_his_qarzi_klient=" & TextBox1.Text
                    Dim qarz As Long = Form1.ret(sql)
                    Dim nom As String
                    sql = "select fio from klient where id_klient=" & id
                    nom = Form1.ret(sql)
                    Form1.qarzi_klient(nom, qarz)
                    sql = "delete from his_qarzi_klient where id_his_qarzi_klient=" & TextBox1.Text
                    Form1.insert(sql)
                    Button2.Enabled = False
                ElseIf jadval = "vozvrat" Then
                    Dim nom As String
                    sql = "select id_borho from vozvrat  where id_vozvrat=" & TextBox1.Text
                    nom = Form1.ret(sql)
                    sql = "select miq from vozvrat where id_vozvrat=" & TextBox1.Text
                    Dim miq As Double = Form1.ret(sql)
                    Form1.for_bor(nom, -miq)
                    sql = "select puli_s from vozvrat where id_vozvrat=" & TextBox1.Text
                    Form1.ForKassa2(Form1.ret(sql))
                    sql = "select azqarz from vozvrat where id_vozvrat=" & TextBox1.Text
                    Dim azqarz As Integer = Form1.ret(sql)
                    If azqarz = 1 Then
                        sql = "select fio from klient,vozvrat where klient.id_klient=vozvrat.id_klient and id_vozvrat=" & TextBox1.Text
                        Dim nomik As String = Form1.ret(sql)
                        Dim qars As Integer
                        sql = "select puli_s from vozvrat where id_vozvrat=" & TextBox1.Text
                        qars = Form1.ret(sql)
                        Form1.qarzs(nomik, qars)
                    End If
                    sql = "delete from vozvrat  where id_vozvrat=" & TextBox1.Text
                    Form1.insert(sql)
                Else
                        sql = "delete from vozvrat where id_vozvrat=" & TextBox1.Text
                    Form1.insert(sql)


                End If
                MsgBox("Маълумот аз ҷадвал хориҷ карда шуд!!!")
            Else
                MsgBox("Сатрҳоро дуруст интихоб кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      
    End Sub
End Class