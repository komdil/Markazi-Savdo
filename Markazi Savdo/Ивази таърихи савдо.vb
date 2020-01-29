Public Class Ивази_таърихи_савдо

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "update savdo set sana='" & DateTimePicker1.Text & "' where id_savdo=" & Таърихи_савдо.TextBox1.Text
        Form1.insert(sql)
      
        Me.Close()
    End Sub

    Private Sub Ивази_таърихи_савдо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Таърихи_савдо.Enabled = True
        Таърихи_савдо.Select()
    End Sub
End Class