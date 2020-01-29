Public Class Ивази_қарзи_Мизоҷ

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If (TextBox1.Text > 0) Then
                Dim sql As String = "update qarzi_klient set miq_qarz=" & TextBox1.Text & " where id_klient =(select id_klient from klient where fio='" & Қарзҳои_Мизоҷон.ComboBox1.Text & "')"
                Form1.insert(sql)
              
                Me.Close()
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub Ивази_қарзи_Мизоҷ_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Қарзҳои_Мизоҷон.Enabled = True
        Қарзҳои_Мизоҷон.Select()
    End Sub
End Class