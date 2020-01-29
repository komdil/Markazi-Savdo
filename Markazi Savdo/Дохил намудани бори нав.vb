Public Class Дохил_намудани_бори_нав
    Public summa As Long
    Public qarz As Long
    Private Sub Дохил_намудани_бори_нав_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Амалҳо_бо_борҳо.Enabled = True
        Амалҳо_бо_борҳо.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ListBox1.Items.Clear()
            If TextBox4.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And ComboBox1.Text <> "" And IsNumeric(TextBox3.Text) = True And IsNumeric(TextBox4.Text) = True And IsNumeric(TextBox5.Text) = True And IsNumeric(TextBox6.Text) = True And Double.Parse(TextBox4.Text) * Double.Parse(TextBox3.Text) * Double.Parse(TextBox5.Text) >= Double.Parse(TextBox6.Text) And Double.Parse(TextBox3.Text) > 0 And Double.Parse(TextBox5.Text) > 0 And Double.Parse(TextBox6.Text) >= 0 And Form1.combo(ComboBox1) Then
                Dim sql As String = "insert into borho values(null, (select id_borovaranda from borovaranda where fio=" & "'" & ComboBox1.Text & "'),'" & TextBox2.Text & "'," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text & "," & TextBox6.Text & ",'" & DateTimePicker1.Text & "')"
                Form1.insert(sql)
                Form1.for_bor(TextBox2.Text, TextBox3.Text * TextBox4.Text)
                ListBox1.Visible = True
                ListBox1.Items.Clear()
                ListBox1.Items.Add("Бор аз номи таҳвилгари " & ComboBox1.Text)
                ListBox1.Items.Add("бо номи " & TextBox2.Text)
                ListBox1.Items.Add("бо миқдори қуттии " & TextBox3.Text)
                ListBox1.Items.Add("миқдор дар як қуттӣ  " & TextBox4.Text)
                ListBox1.Items.Add("нархи як дона  " & TextBox5.Text)
                ListBox1.Items.Add("пули пардохтшуда  " & TextBox6.Text)
                ListBox1.Items.Add("дар санаи  " & DateTimePicker1.Text)
                ListBox1.Items.Add("дохил карда шуд!!!")
                If summa > Double.Parse(TextBox6.Text) Then
                    qarz = summa - Double.Parse(TextBox6.Text)
                    qarz = Math.Round(qarz, 2)
                    Form1.qarzs(ComboBox1.Text, qarz)
                    ListBox1.Items.Add("Бояд, ки пули пардохтшуда ба " & summa & " баробар мешуд")
                    ListBox1.Items.Add("лекин  " & Double.Parse(TextBox6.Text) & " супорида шуд")
                    ListBox1.Items.Add("Шумо ба маблағи   " & qarz)
                    ListBox1.Items.Add("аз таҳвилгари " & ComboBox1.Text & " қарздор шудед!!!")
                    ListBox1.Items.Add("ин қарз дар ҷадвали қарзҳои ман сабт шуд!!!")
                End If
                '  Form1.ForKassa(Long.Parse(TextBox6.Text))
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                summa = 0
                qarz = 0
            Else
                MsgBox("Сатрҳоро дуруст  пур кунед!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Дохил_намудани_бори_нав_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "Select distinct  fio  from borovaranda"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

  
    Private Sub TextBox5_LostFocus(sender As Object, e As EventArgs) Handles TextBox5.LostFocus
        If TextBox4.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox5.Text <> "" And IsNumeric(TextBox3.Text) = True And IsNumeric(TextBox4.Text) = True And IsNumeric(TextBox5.Text) = True Then
            summa = TextBox3.Text * TextBox4.Text * Double.Parse(TextBox5.Text)
            Label8.Text = "Пули пардохтшуда бояд ба " & summa & vbCrLf & "баробар шавад"
        Else
            MsgBox("Аввал номи таҳвилгар, номи бор, миқдори қуттӣ ва миқдори бор дар қуттиро дохил кунед!!! ")
        End If
    End Sub

   
End Class