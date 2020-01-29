Public Class Отчети_возврат

    Private Sub Отчети_возврат_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Кор_бо_возврат.Enabled = True
        Кор_бо_возврат.Select()
    End Sub

    Private Sub Отчети_возврат_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio as [Номи Мизоҷ], id_borho as [Номи бор], miq as [Миқдор], puli_s as [Пули супорида], sana as [сана] from vozvrat,klient  where klient.id_klient= vozvrat.id_klient"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from klient,vozvrat where klient.id_klient= vozvrat.id_klient"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio as [Номи Мизоҷ], id_borho as [Номи бор], miq as [Миқдор], puli_s as [Пули супорида], sana as [сана] from  vozvrat,klient  where klient.id_klient= vozvrat.id_klient and  fio='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql As String = "select fio as [Номи Мизоҷ], id_borho as [Номи бор], miq as [Миқдор], puli_s as [Пули супорида], sana as [сана] from vozvrat,klient  where klient.id_klient= vozvrat.id_klient"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from klient,vozvrat where klient.id_klient= vozvrat.id_klient"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql2 As String = "select distinct sana from vozvrat"
        Dim sql As String = "select fio as [Номи Мизоҷ], id_borho as [Номи бор], miq as [Миқдор], puli_s as [Пули супорида], sana as [сана] from vozvrat,klient  where klient.id_klient= vozvrat.id_klient and sana in(" & Form1.by_date("vozvrat", DateTimePicker1, DateTimePicker2, sql2) & ")"
        Form1.GridView(sql, DataGridView1)
    End Sub
End Class