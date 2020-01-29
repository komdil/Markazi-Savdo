Public Class Ивази_қарз

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text > 0) Then
            Dim sql As String = "update qarzi_man set miq_qarz=" & TextBox1.Text & " where qarzi_man.id_borovaranda=(select id_borovaranda from borovaranda where fio='" & Қарзҳои_ман.ComboBox1.Text & "')"
            Form1.insert(sql)
           
            Me.Close()
        End If
    End Sub

 
    Private Sub Ивази_қарз_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳои_ман.Enabled = True
        Қарзҳои_ман.Select()
    End Sub
End Class