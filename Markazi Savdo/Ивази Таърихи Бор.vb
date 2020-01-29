Public Class Ивази_Таърихи_Бор

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "Update borho set sana='" & DateTimePicker1.Text & "' where id_bor=" & Таърихи_борҳо.TextBox1.Text
        Form1.insert(sql)
        Me.Close()
      
    End Sub

    Private Sub Ивази_Таърихи_Бор_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Таърихи_борҳо.Enabled = True
        Таърихи_борҳо.Select()
    End Sub
End Class