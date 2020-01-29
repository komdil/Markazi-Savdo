Imports System.Data.SQLite

Public Class Дохил_кардани_Мизоҷи_нав

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                Dim sql As String = "insert into klient values(null,'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                Dim copy As String = "select fio from klient"
                Form1.cmd.CommandText = copy
                Dim dr As SQLiteDataReader
                dr = Form1.cmd.ExecuteReader
                While dr.Read
                    If dr(0) = TextBox1.Text Then
                        MsgBox("Чунин Мизоҷ вуҷуд дорад!!!")
                        dr.Close()
                        Exit Sub
                    End If
                End While
                dr.Close()
                Form1.insert(sql)
                ListBox1.Visible = True
                ListBox1.Items.Clear()
                ListBox1.Items.Add("Мизоҷ бо номи " & TextBox1.Text)
                ListBox1.Items.Add("бо бо суроғаи " & TextBox2.Text)
                ListBox1.Items.Add("ва телефони " & TextBox3.Text)
                ListBox1.Items.Add("дохил карда шуд!!!")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()

            Else
                MsgBox("Сатрҳоро дуруст  пур кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       


    End Sub

    Private Sub Дохил_кардани_Мизоҷи_нав_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Амалҳо_бо_Мизоҷон.Enabled = True
        Амалҳо_бо_Мизоҷон.Select()
    End Sub
End Class