Public Class Касса
    Private Sub Касса_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

    Private Sub Касса_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        sql = "select pul from kassa"
        Label2.Text = Form1.ret(sql)
        sql = "select  id_rashod as [Индекс] , nom as [Ном] , miqdor as [Миқдори хароҷот] , sana as [Сана] from rashod"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct nom as [Ном]  from rashod"
        Form1.connection(sql, ComboBox1, 0)
        sql = "select  sum(miqdor) from rashod"

        Label8.Text = "Хароҷоти умумӣ: " & Form1.ret(sql)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim s As Long = Long.Parse(InputBox("Миқдори пулро дохил кунед!"))
            Dim sql As String = "Update kassa set pul=" & s
            If s >= 0 Then
                Form1.insert(sql)
                sql = "select pul from kassa"
                Label2.Text = Form1.ret(sql)
            Else
                MsgBox("Маълумотро дуруст ворид кунед!")
            End If

        Catch ex As Exception
            MsgBox("Маълумотро дуруст ворид кунед!")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If RichTextBox1.Text <> "" And IsNumeric(TextBox2.Text) And Long.Parse(TextBox2.Text) > 0 Then
                Dim sql As String = "insert into rashod values(null, '" & RichTextBox1.Text & "' , " & TextBox2.Text & " , '" & DateTimePicker1.Text & "' )"
                Form1.ret(sql)
                sql = "update kassa set pul=pul-" & Long.Parse(TextBox2.Text)
                Form1.insert(sql)
                MsgBox("Дохил карда шуд!")
                sql = "select pul from kassa"
                Label2.Text = Form1.ret(sql)
                sql = "select  id_rashod as [Индекс] , nom as [Ном] , miqdor as [Миқдори хароҷот] , sana as [Сана] from rashod"
                Form1.GridView(sql, DataGridView1)
                sql = "select sum(miqdor) from rashod"
                Label8.Text = "хароҷоти умумӣ: " & Form1.ret(sql)
                sql = "select distinct nom as [Ном]  from rashod"
                Form1.connection(sql, ComboBox1, 0)
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Form1.combo(ComboBox1) Then
            Dim sql As String
            sql = "select  id_rashod as [Индекс] , nom as [Ном] , miqdor as [Миқдори хароҷот] , sana as [Сана] from rashod where nom like '%" & Mid(ComboBox1.Text, 1, 3) & "%' "
            Form1.GridView(sql, DataGridView1)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql As String
        sql = "select  id_rashod as [Индекс] , nom as [Ном] , miqdor as [Миқдори хароҷот] , sana as [Сана] from rashod where sana='" & DateTimePicker2.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class