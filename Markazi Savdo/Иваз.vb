Public Class Иваз

    Private Sub Иваз_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Маълумот_оиди_Мизоҷон.Enabled = True
        Маълумот_оиди_Мизоҷон.Select()
    End Sub

    Private Sub Иваз_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Маълумот_оиди_Мизоҷон.ComboBox1.Text
        Dim sql As String = "select suroga from klient where fio='" & TextBox1.Text & "'"
        TextBox2.Text = Form1.ret(sql)
        sql = "select telefon from klient where fio='" & TextBox1.Text & "'"
        TextBox3.Text = Form1.ret(sql)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                Маълумот_оиди_Мизоҷон.Enabled = True
                Маълумот_оиди_Мизоҷон.Select()
                Dim sql As String = "update klient set fio='" & TextBox1.Text & "', " & "suroga='" & TextBox2.Text & "', " & "telefon='" & TextBox3.Text & "' where fio='" & Маълумот_оиди_Мизоҷон.ComboBox1.Text & "'"
                Form1.insert(sql)
                Me.Close()
                sql = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from klient"
                Form1.GridView(sql, Маълумот_оиди_Мизоҷон.DataGridView1)
                sql = "Select distinct fio from klient"
                Маълумот_оиди_Мизоҷон.ComboBox1.Text = ""
                Form1.connection(sql, Маълумот_оиди_Мизоҷон.ComboBox1, 0)
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
End Class