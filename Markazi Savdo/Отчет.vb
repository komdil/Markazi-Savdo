Public Class Ҳисобот

    Private Sub Отчет_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        conn.Close()
        conn2.Close()
        Form1.Enabled = True
        Form1.Select()
        Form1.CONN.Open()
    End Sub
    Dim conn As New SQLite.SQLiteConnection("Data Source=shop.db;")
    Dim conn2 As New SQLite.SQLiteConnection("Data Source=shop2.db;")
    Dim cmd As New SQLite.SQLiteCommand(conn)
    Dim cmd2 As New SQLite.SQLiteCommand(conn2)
    Private Sub Отчет_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.CONN.Close()
        conn.Open()
        conn2.Open()
        Dim sql As String = "select  fio  as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана], (select 'Ф') as [База] from his_qarzi_klient, klient where his_qarzi_klient.id_klient=klient.id_klient"
        Dim sql2 As String = "select  fio    as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана], (select 'АБ') as [База] from his_qarzi_klient,klient where his_qarzi_klient.id_klient=klient.id_klient"
        cmd.CommandText = sql
        cmd2.CommandText = sql2
        Dim dt As New DataTable
        Dim ad As New SQLite.SQLiteDataAdapter(cmd)
        ad.Fill(dt)
        ad = New SQLite.SQLiteDataAdapter(cmd2)
        ad.Fill(dt)
        DataGridView1.DataSource = dt
        sql = "select distinct fio from klient"
        cmd.CommandText = sql
        cmd2.CommandText = sql
        ComboBox1.Items.Clear()
        Dim dr As SQLite.SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr(0))
        End While
        dr.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select  fio   as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана], (select 'Ф') as [База] from his_qarzi_klient,klient where  his_qarzi_klient.id_klient=klient.id_klient and fio='" & ComboBox1.Text & "' "
        Dim sql2 As String = "select  fio    as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана], (select 'Ф') as [База] from his_qarzi_klient ,klient where his_qarzi_klient.id_klient=klient.id_klient and fio='" & ComboBox1.Text & "' "
        cmd.CommandText = sql
        cmd2.CommandText = sql2
        Dim dt As New DataTable
        Dim ad As New SQLite.SQLiteDataAdapter(cmd)
        ad.Fill(dt)
        ad = New SQLite.SQLiteDataAdapter(cmd2)
        ad.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select  fio  as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана], (select 'Ф') as [База] from his_qarzi_klient, klient where his_qarzi_klient.id_klient=klient.id_klient"
        Dim sql2 As String = "select  fio    as [Номи Мизоҷ], miq_qarz as [Қарзе, ки мавҷуд буд], pard as [Пули супоридашуда], boqi as [Пули боқимонда], sana as [Сана], (select 'АБ') as [База] from his_qarzi_klient,klient where his_qarzi_klient.id_klient=klient.id_klient"
        cmd.CommandText = sql
        cmd2.CommandText = sql2
        Dim dt As New DataTable
        Dim ad As New SQLite.SQLiteDataAdapter(cmd)
        ad.Fill(dt)
        ad = New SQLite.SQLiteDataAdapter(cmd2)
        ad.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
End Class