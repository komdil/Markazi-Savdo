Public Class Ҳисоботи_қарзҳои_Мизоҷон

    Private Sub Ҳисоботи_қарзҳои_Мизоҷон_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳо.Enabled = True
        Қарзҳо.Select()
    End Sub

    Private Sub Ҳисоботи_қарзҳои_Мизоҷон_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана] from his_qarzi_klient, klient where klient.id_klient=his_qarzi_klient.id_klient"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from klient,his_qarzi_klient where his_qarzi_klient.id_klient=klient.id_klient"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio  as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана] from his_qarzi_klient,klient where klient.id_klient=his_qarzi_klient.id_klient and fio='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана] from his_qarzi_klient, klient where klient.id_klient=his_qarzi_klient.id_klient and sana='" & FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate) & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql As String = "select fio as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана] from his_qarzi_klient, klient where klient.id_klient=his_qarzi_klient.id_klient"
        Form1.GridView(sql, DataGridView1)
    End Sub
End Class