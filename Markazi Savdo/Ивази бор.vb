Public Class Ивази_бор

    Private Sub Ивази_бор_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Борҳои_мавҷудбуда.Enabled = True
        Борҳои_мавҷудбуда.Select()
      
        
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" And IsNumeric(TextBox2.Text) And TextBox2.Text > 0 Then
                Dim sql As String = "Update bor set nom='" & TextBox1.Text & "', shtuk=" & TextBox2.Text & " where nom='" & Борҳои_мавҷудбуда.ComboBox1.Text & "'"
                Form1.insert(sql)
                sql = "update borho set nom='" & TextBox1.Text & "' where nom='" & Борҳои_мавҷудбуда.ComboBox1.Text & "'"
                Form1.insert(sql)
                MsgBox("Бор иваз карда шуд!!!")

                sql = "select nom as [Номи бор], shtuk as [Миқдори бор]  from bor"
                Form1.GridView(sql, Борҳои_мавҷудбуда.DataGridView1)
                sql = "select nom from bor"
                Form1.connection(sql, Борҳои_мавҷудбуда.ComboBox1, 0)

                Борҳои_мавҷудбуда.ComboBox1.Text = ""

                Me.Close()
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub Ивази_бор_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        sql = "select nom from bor where nom='" & Борҳои_мавҷудбуда.ComboBox1.Text & "'"
        TextBox1.Text = Form1.ret(sql)
        sql = "select shtuk from bor where nom='" & Борҳои_мавҷудбуда.ComboBox1.Text & "'"
        TextBox2.Text = Form1.ret(sql)
    End Sub
End Class