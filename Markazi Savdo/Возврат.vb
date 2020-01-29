Public Class Возврат
    Dim max As Integer
    Private Sub Возврат_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Кор_бо_возврат.Enabled = True
        Кор_бо_возврат.Select()
    End Sub

    Private Sub Возврат_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio from klient where id_klient in(select id_klient from savdo)"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Form1.combo(ComboBox1) And Form1.combo(ComboBox2) And IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And TextBox1.Text > 0 And TextBox2.Text > 0 And TextBox3.Text > 0 And TextBox1.Text <= max Then
                Dim sql As String
                ListBox1.Items.Clear()
                Dim azqarz As Integer
                If RadioButton1.Checked Then
                    azqarz = 0
                Else
                    azqarz = 1
                End If
                sql = "insert into vozvrat values(null, (select id_klient from klient where fio='" & ComboBox1.Text & "'),'" & ComboBox2.Text & "'," & TextBox1.Text & "," & TextBox2.Text & "," & TextBox3.Text & ",'" & DateTimePicker1.Text & "'," & azqarz & ")"
                Form1.insert(sql)
                Form1.for_bor(ComboBox2.Text, TextBox1.Text)
                If RadioButton2.Checked Then
                    Form1.qarzi_klient(ComboBox1.Text, -TextBox3.Text)
                End If
                ListBox1.Items.Add("Мизоҷ " & ComboBox1.Text)
                ListBox1.Items.Add("бори " & ComboBox2.Text & " -ро")
                ListBox1.Items.Add("ба миқдори " & TextBox1.Text)
                ListBox1.Items.Add("бо нархи " & TextBox2.Text & " оварда шуд")
                ListBox1.Items.Add(TextBox3.Text & " пул ба Мизоҷ дода шуд!")
            Else
                MsgBox("Сатрҳоро дуруст пур кунед!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox2.Text = ""
        Dim sql As String = "select distinct nomi_bor from savdo where id_klient=(select id_klient from klient where fio='" & ComboBox1.Text & "')"
        Form1.connection(sql, ComboBox2, 0)
    End Sub

    Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Dim sql As String = "select sum(shtuk) from savdo where id_klient=(select id_klient from klient where fio='" & ComboBox1.Text & "') and nomi_bor='" & ComboBox2.Text & "'"
        max = Form1.ret(sql)
        TextBox1.Text = max
        Label5.Text = "Миқдори максималии штук " & max
        sql = "select avg(narhi_furuht) from savdo where id_klient=(select id_klient from klient where fio='" & ComboBox1.Text & "') and nomi_bor='" & ComboBox2.Text & "'"
        TextBox2.Text = Int(Form1.ret(sql))
        TextBox2.Text = TextBox2.Text
        TextBox3.Text = TextBox1.Text * TextBox2.Text
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        Try
            TextBox3.Text = TextBox1.Text * TextBox2.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox3.Enabled = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox3.Enabled = True
    End Sub
End Class