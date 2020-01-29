Public Class Ивази_бороваранда

    Private Sub Ивази_бороваранда_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Рӯйхати_боровардагон.Enabled = True
        Рӯйхати_боровардагон.Select()
    End Sub

    Private Sub Ивази_бороваранда_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Рӯйхати_боровардагон.ComboBox1.Text
        Dim sql As String = "select telefon from borovaranda where fio='" & TextBox1.Text & "'"
        TextBox2.Text = Form1.ret(sql)
        sql = "select suroga from borovaranda where fio='" & TextBox1.Text & "'"
        TextBox3.Text = Form1.ret(sql)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                Dim sql As String = "update borovaranda set fio='" & TextBox1.Text & "', telefon='" & TextBox2.Text & "', suroga='" & TextBox3.Text & "' where fio='" & Рӯйхати_боровардагон.ComboBox1.Text & "'"
                Form1.insert(sql)
                sql = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from borovaranda"
                Form1.GridView(sql, Рӯйхати_боровардагон.DataGridView1)
                sql = "select distinct fio from borovaranda"
                Рӯйхати_боровардагон.ComboBox1.Text = ""
                Form1.connection(sql, Рӯйхати_боровардагон.ComboBox1, 0)
                Рӯйхати_боровардагон.Enabled = True
                Рӯйхати_боровардагон.Select()
                Me.Close()
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
End Class