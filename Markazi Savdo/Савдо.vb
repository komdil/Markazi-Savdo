Imports System.Data.SQLite
Public Class Савдо
    Private Sub Савдо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub
    Dim qarz As Long
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Form1.bor_del()
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And IsNumeric(TextBox1.Text) = True And IsNumeric(TextBox2.Text) = True And IsNumeric(TextBox3.Text) = True And max >= Integer.Parse(TextBox1.Text) And Integer.Parse(TextBox1.Text) > 0 And Integer.Parse(TextBox2.Text) > 0 And Integer.Parse(TextBox3.Text) >= 0 And Integer.Parse(TextBox4.Text) > 0 And Integer.Parse(TextBox3.Text) <= Integer.Parse(TextBox4.Text) And Integer.Parse(TextBox3.Text) <= Integer.Parse(TextBox1.Text) * Integer.Parse(TextBox2.Text) And Integer.Parse(TextBox4.Text) <= Integer.Parse(TextBox1.Text) * Integer.Parse(TextBox2.Text) And Form1.combo(ComboBox1) And Form1.combo(ComboBox2) Then
            Dim sql As String = "insert into savdo values(null,(select id_klient from klient where fio='" & ComboBox1.Text & "'),'" & ComboBox2.Text & "'," & TextBox1.Text & ", " & TextBox2.Text & "," & TextBox3.Text & "," & TextBox4.Text - narhi_kuhn * TextBox1.Text & ",'" & DateTimePicker1.Text & "', " & TextBox4.Text & ")"
            Form1.insert(sql)
            ListBox1.Items.Add("Ба Мизоҷ " & ComboBox1.Text)
            ListBox1.Items.Add("Бори " & ComboBox2.Text)
            ListBox1.Items.Add("Ба миқдори " & TextBox1.Text)
            ListBox1.Items.Add("Ба нархи " & TextBox2.Text & " фурӯхта шуд!!!")
            Dim qarz As Long
            qarz = TextBox4.Text - TextBox3.Text
            If qarz > 0 Then
                Form1.qarzi_klient(ComboBox1.Text, qarz)
                ListBox1.Items.Add("Мизоҷ " & TextBox3.Text & " пул супорид ва ")
                ListBox1.Items.Add("ба миқдори " & qarz & " қарздор шуд")
                ListBox1.Items.Add("Ин қарз дар ҷадвали қарздорон сабт карда шуд!!!")
            Else
                qarz = 0
            End If
            sql = "update bor set shtuk=shtuk-" & TextBox1.Text & " where nom='" & ComboBox2.Text & "'"
            Form1.ForKassa2(Long.Parse(TextBox3.Text))
            Form1.insert(sql)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            ComboBox2.Text = ""
            Form1.bor_del()
            sql = "select distinct nom from bor"
            Form1.connection(sql, ComboBox2, 0)
        Else
            MsgBox("Маълумотҳоро дуруст дохил кунед!!!")
            End If


    End Sub
    Private Sub Савдо_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.bor_del()
        Dim sql As String = "select  distinct fio from klient"
        Form1.connection(sql, ComboBox1, 0)
        sql = "select distinct nom from bor"
        Form1.connection(sql, ComboBox2, 0)
    End Sub
    Dim max As Integer
    Dim narhi_kuhn As Long
   

    Private Sub ComboBox2_ImeModeChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        Dim sql As String = "select shtuk from bor where nom='" & ComboBox2.Text & "'"
        max = Form1.miq_karobka(ComboBox2.Text)
        Label7.Text = Form1.narh(ComboBox2.Text) & " Нархи бор"
        narhi_kuhn = Form1.narh(ComboBox2.Text)
        Label10.Text = "На зиёд аз " & max & " штук"
        TextBox1.Enabled = True
    End Sub

   

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        Try
            Label9.Text = "Нархи умумӣ " & TextBox1.Text * TextBox2.Text
            TextBox4.Text = TextBox1.Text * TextBox2.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class