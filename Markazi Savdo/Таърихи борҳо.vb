Public Class Таърихи_борҳо
    Dim sql2 As String
    Private Sub Таърихи_борҳо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Амалҳо_бо_борҳо.Enabled = True
        Амалҳо_бо_борҳо.Select()
    End Sub

    Private Sub Таърихи_борҳо_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select distinct  fio  from borovaranda"
        Form1.connection(sql, ComboBox3, 0)
        sql = "select distinct  nom from borho "
        Form1.connection(sql, ComboBox4, 0)
        sql2 = "select borho.id_bor as [Индекс], borovaranda.fio as [Номи бороваранда],borho.nom  as [Номи бор],borho.miqdori_qutti  as [Миқдори қуттӣ],borho.miq_bori_qutti as [Миқдори бор дар як қуттӣ],"
        sql2 = sql2 & " borho.narhi_yak_dona as [Нархи як дона бор], (select borho.miqdori_qutti*borho.miq_bori_qutti*borho.narhi_yak_dona) as [Пули умумӣ],"
        sql2 = sql2 & " borho.puli_paddohtshuda as [Пули пардохтшуда],(select (select borho.miqdori_qutti*borho.miq_bori_qutti*borho.narhi_yak_dona)-  borho.puli_paddohtshuda) as [Қарзи монда], borho.sana as [Сана] from borho,borovaranda where "
        sql2 = sql2 & "borovaranda.id_borovaranda=borho.id_borovaranda "
        Form1.GridView(sql2, DataGridView1)
    End Sub
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql3 As String
        Dim sql4 As String = "select distinct sana from borho"
        sql3 = sql2 & "and borho.sana in (" & Form1.by_date("borho", DateTimePicker1, DateTimePicker2, sql4) & ")"
        Form1.GridView(sql3, DataGridView1)
        sql3 = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql3 As String
        sql3 = sql2 & "and borovaranda.fio= '" & ComboBox3.Text & "'"
        Form1.GridView(sql3, DataGridView1)
        sql3 = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql3 As String
        sql3 = sql2 & "and borho.nom= '" & ComboBox4.Text & "' "
        Form1.GridView(sql3, DataGridView1)
        sql3 = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.GridView(sql2, DataGridView1)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If IsNumeric(TextBox1.Text) Then
                Ивази_Таърихи_Бор.Show()
                Me.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class