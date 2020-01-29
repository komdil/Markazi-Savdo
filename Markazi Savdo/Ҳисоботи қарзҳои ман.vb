Public Class Ҳисоботи_қарзҳои_ман

    
    Private Sub Ҳисоботи_қарзҳои_ман_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳо.Enabled = True
        Қарзҳо.Select()
    End Sub

    Private Sub Ҳисоботи_қарзҳои_ман_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio as [Номи бороваранда], qarz as [Қарзе, ки буд], pard as [Пуле, ки пардохт шуд], boqi as [Миқдоре, ки боқи монд], sana as [Сана] from his_qarzi_man,borovaranda where  his_qarzi_man.id_borovaranda=borovaranda.id_borovaranda"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from borovaranda,his_qarzi_man where borovaranda.id_borovaranda=his_qarzi_man.id_borovaranda"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql As String = "select fio as [Номи бороваранда], qarz as [Қарзе, ки буд], pard as [Пуле, ки пардохт шуд], boqi as [Миқдоре, ки боқи монд], sana as [Сана] from his_qarzi_man, borovaranda where  his_qarzi_man.id_borovaranda=borovaranda.id_borovaranda"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select fio as [Номи бороваранда], qarz as [Қарзе, ки буд], pard as [Пуле, ки пардохт шуд], boqi as [Миқдоре, ки боқи монд], sana as [Сана] from his_qarzi_man,borovaranda where  his_qarzi_man.id_borovaranda=borovaranda.id_borovaranda and sana='" & FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate) & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio as [Номи бороваранда], qarz as [Қарзе, ки буд], pard as [Пуле, ки пардохт шуд], boqi as [Миқдоре, ки боқи монд], sana as [Сана] from his_qarzi_man,borovaranda where  his_qarzi_man.id_borovaranda=borovaranda.id_borovaranda and fio='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub
End Class