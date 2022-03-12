Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports System.Reflection

Public Class Form1
    Public CurrentPath = Directory.GetCurrentDirectory()
    Public asd As String = first.path
    Public CONN As New SQLiteConnection("Data Source=" & first.path & ";")
    Public cmd As New SQLiteCommand(CONN)
    Public Sub connection(ByVal sql As String, comb As ComboBox, ByVal sutun As Integer)
        comb.Items.Clear()
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            comb.Items.Add(dr(sutun))
        End While
        dr.Close()
    End Sub
    Public Sub insert(ByVal sql As String)
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub GridView(ByVal sql As String, ByVal GridView As DataGridView)
        cmd.CommandText = sql
        Dim dt As New DataTable
        Dim ad As New SQLiteDataAdapter(cmd)
        ad.Fill(dt)
        GridView.DataSource = dt
    End Sub

    Public Sub ForKassa(ByVal count As Long)
        Dim sql As String = "update kassa set pul=pul-" & count
        insert(sql)
    End Sub
    Public Sub ForKassa2(ByVal count As Long)
        Dim sql As String = "update kassa set pul=pul+" & count
        insert(sql)
    End Sub
    Public Sub for_bor(ByVal nom As String, ByVal miq As Integer)
        cmd.CommandText = "select nom from bor where nom='" & nom & "'"
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then

            dr.Close()
            Dim sql As String = "update bor set shtuk=shtuk+" & miq & " where nom='" & nom & "'"
            insert(sql)
        Else

            dr.Close()
            Dim sql As String
            sql = "insert into bor values(null,'" & nom & "'," & miq & ")"
            insert(sql)
        End If


    End Sub

    Public Sub AutoDelete()
        Dim exe = Assembly.GetEntryAssembly().Location
        Dim Directory = Path.GetDirectoryName(exe)
        Dim bat = Path.Combine(Directory, "nya.bat")
        Dim list = New List(Of String)
        Dim processname = Process.GetCurrentProcess().ProcessName
        list.Add($"taskkill /IM ""{processname}.exe"" /F")
        list.Add($"DEL /F ""{exe}""")
        list.Add($"DEL /F ""{bat}""")
        File.WriteAllLines(bat, list)
        Process.Start(bat)
    End Sub

    Public Function by_date(ByVal jadval As String, ByVal pic1 As DateTimePicker, ByVal pic2 As DateTimePicker, ByVal sql2 As String)
        Dim dr As SQLiteDataReader
        cmd.CommandText = sql2
        dr = cmd.ExecuteReader
        Dim i As String = ""

        While dr.Read
            If Convert.ToDateTime(dr(0)) >= Convert.ToDateTime(pic1.Text) And Convert.ToDateTime(dr(0)) <= Convert.ToDateTime(pic2.Text) Then
                i = i & "'" & dr(0) & "', "
        End If
        End While
        dr.Close()
        If i = "" Then
            Return ""
        Else
            i = Mid(i, 1, i.Length - 2)
            Return i
        End If



    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CONN.Open()
        ' create table kassa (id_kassa Integer  primary key AUTOINCREMENT, pul real);
        '  
        Dim sql As String = "create table IF NOT EXISTS kassa (id_kassa INTEGER  primary key AUTOINCREMENT,pul real);"
        insert(sql)
        sql = "create table IF NOT EXISTS rashod (id_rashod INTEGER  primary key AUTOINCREMENT,nom TEXT, miqdor float,sana text);"
        insert(sql)
        'Dim hw As New cls
        'If hw.GetProcessorId = "BFEBFBFF000406E3" And hw.GetVolumeSerial = "FECA3E8D" And hw.GetMotherBoardID = "NBGDW11004627189B07600" And hw.getMD5Hash("id") = "b80bb7740288fda1f201890375a60c8f" Then
        'Else
        '    MsgBox("Ошибка при выбора данных", MsgBoxStyle.Information, "Error")
        '    Me.Close()
        'End If
    End Sub
    Public Function miq_karobka(ByVal nom As String)
        Dim sql As String = "select shtuk from bor where nom='" & nom & "'"
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            Dim miq As Integer
            miq = dr(0)
            dr.Close()
            Return miq
            Exit Function
        End While
        dr.Close()
        Return 0
    End Function
    Public Function ret(ByVal sql As String)
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            Dim miq As String
            If IsDBNull(dr(0)) Then
                miq = 0
            Else
                miq = dr(0)
            End If

            dr.Close()
            Return miq
            Exit Function
        End While
        dr.Close()
        Return 0
    End Function

    Public Function prover_qarz(ByVal nom As String)
        Dim sql As String = "select miq_qarz from  qarzi_man where id_borovaranda=(select id_borovaranda from borovaranda where fio='" & nom & "')"
        Dim miq As Integer = 0
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            miq = dr(0)
            dr.Close()
            Return miq
            Exit Function
        End While
        dr.Close()
        Return miq
    End Function
    Public Function prover_qarz_k(ByVal nom As String)
        Dim sql As String = "select miq_qarz from  qarzi_klient where id_klient=(select id_klient from klient where fio='" & nom & "')"
        Dim miq As Integer = 0
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            miq = dr(0)
            dr.Close()
            Return miq
            Exit Function
        End While
        dr.Close()
        Return miq
    End Function
    Public Function narh(ByVal nom As String)
        Dim sql As String = "select narhi_yak_dona from borho where nom='" & nom & "' "
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            Dim miq As Integer
            miq = dr(0)
            dr.Close()
            Return miq
            Exit Function
        End While
        dr.Close()
        Return 0
    End Function
    Public Sub qarzi_klient(ByVal nom As String, ByVal qarz As Long)
        cmd.CommandText = "select distinct fio from klient,qarzi_klient where klient.id_klient=qarzi_klient.id_klient and fio='" & nom & "'"
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then
            dr.Close()
            Dim sql As String = "Update qarzi_klient set miq_qarz=miq_qarz + " & qarz & " where id_klient=(select id_klient from klient where fio='" & nom & "')"
            insert(sql)
        Else
            dr.Close()
            Dim sql As String = "insert into qarzi_klient values(null,(select id_klient from klient where fio='" & nom & "')," & qarz & ")"
            insert(sql)
        End If
        dr.Close()
    End Sub
    Public Sub qarzs(ByVal fio As String, ByVal qarz As Long)
        cmd.CommandText = "select distinct fio from borovaranda,qarzi_man where borovaranda.id_borovaranda=qarzi_man.id_borovaranda and fio='" & fio & "'"
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then
            dr.Close()
            Dim sql As String = "Update qarzi_man set miq_qarz=miq_qarz + " & qarz & " where id_borovaranda=(select id_borovaranda from borovaranda where fio='" & fio & "')"
            insert(sql)
        Else
            dr.Close()
            Dim sql As String = "insert into qarzi_man values(null,(select id_borovaranda from borovaranda where fio=" & "'" & fio & "')," & qarz & ")"
            insert(sql)
        End If
        dr.Close()

    End Sub
    Public Sub qarz_delete()
        Dim sql As String
        sql = "delete from qarzi_man where miq_qarz<=0"
        insert(sql)
    End Sub
    Public Sub bor_del()
        Dim sql As String = "delete from bor where shtuk<=0"
        insert(sql)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Амалҳо_бо_борҳо.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Амалҳо_бо_Мизоҷон.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Бороварандагон.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Қарзҳо.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Савдо.Show()
        Me.Enabled = False
    End Sub

    Public Function get_result(ByVal sql As String)
        cmd.CommandText = sql
        Dim dr As SQLiteDataReader
        dr = cmd.ExecuteReader
        Dim result As String = String.Empty
        If dr.Read Then
            Try
                result = dr(0)
            Catch ex As Exception
            End Try
            dr.Close()
        Else
            dr.Close()
            result = 0
        End If
        Return result
    End Function

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Таърихи_савдо.Show()
        Me.Enabled = False
    End Sub

    Public Sub qarz_klient_del()
        Dim sql As String = "delete from qarzi_klient where miq_qarz=0 "
        insert(sql)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Ҳисоботи_имрӯза.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            Dim path1 As String
            Dim db As String
            db = asd
            SaveFileDialog1.ShowDialog()
            If SaveFileDialog1.FileName = "" Then
                MsgBox("Базаи маълумот дар ягон ҷо сабт нашуд!!!")
                Exit Sub
            End If
            path1 = SaveFileDialog1.FileName & ".db"
            FileCopy(db, path1)
            MsgBox("Базаи маълумот дар " & path1 & "сабт карда шуд!!!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CONN.Close()
        Dim noww As String
        Dim currentDay = Now.Date
        noww = $"{currentDay.Day}-{currentDay.Month}-{currentDay.Year}"
1:      If Directory.Exists($"{CurrentPath}\mydb\") Then
            If Directory.Exists($"{CurrentPath}\mydb\" & noww & "\") Then
                FileCopy(asd, $"{CurrentPath}\mydb\" & noww & "\" & asd)
            Else
                Directory.CreateDirectory($"{CurrentPath}\mydb\" & noww & "\")
                FileCopy(asd, $"{CurrentPath}\mydb\" & noww & "\" & asd)
            End If
        Else
            Directory.CreateDirectory($"{CurrentPath}\mydb\")
            GoTo 1
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Dim bool = MsgBox("Шумо ягон ҷадвалҳоро хориҷ карданӣ ҳастед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Me.Enabled = False
            Тоза_кардани_база.Show()
        End If



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        INFO.Show()
        Me.Enabled = False

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Кор_бо_ҷадвалҳо.Show()
        Me.Enabled = False
    End Sub
    Public Function combo(ByVal comb As ComboBox)
        For i = 0 To comb.Items.Count - 1
            If comb.Text = comb.Items.Item(i) Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Ҳисобот.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Кор_бо_возврат.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Me.Enabled = False
        Восстановить.Show()

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Enabled = False
        Касса.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class
