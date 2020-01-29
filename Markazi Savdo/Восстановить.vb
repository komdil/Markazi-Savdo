Public Class Восстановить
    Dim mas() As String
    Private Sub Восстановить_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub
    Private Sub Восстановить_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mas = IO.Directory.GetFileSystemEntries($"{Form1.CurrentPath}\mydb\")
        For Each a In mas
            Dim result = a.Split("\")
            ComboBox1.Items.Add(result.Last())
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан восстановить кардан мехоҳед? Дар ҳолати восстановить кардан базаи ҳозир буда тоза мешавад!", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            For Each a In mas
                If (a.Substring(22, a.Length - 22) = ComboBox1.Text) Then
                    FileCopy(a & "\" & Form1.asd, Form1.asd)
                End If
            Next
            Dim noww As String
            Dim currentDay = Now.Date
            noww = $"{currentDay.Day}-{currentDay.Month}-{currentDay.Year}"
1:          If IO.Directory.Exists($"{Form1.CurrentPath}\mydb\") Then
                If IO.Directory.Exists($"{Form1.CurrentPath}\mydb\" & noww & "\") Then
                    FileCopy(Form1.asd, $"{Form1.CurrentPath}\mydb\" & noww & "\" & Form1.asd)
                Else
                    IO.Directory.CreateDirectory($"{Form1.CurrentPath}\mydb\" & noww & "\")
                    FileCopy(Form1.asd, $"{Form1.CurrentPath}\mydb\" & noww & "\" & Form1.asd)
                End If
            Else
                IO.Directory.CreateDirectory($"{Form1.CurrentPath}\mydb\")
                GoTo 1
            End If
            MessageBox.Show("База восстановлено!")
            Me.Close()
        End If
    End Sub
End Class