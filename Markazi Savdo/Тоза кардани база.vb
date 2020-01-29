Public Class Тоза_кардани_база

    Private Sub Тоза_кардани_база_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from borho"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from savdo"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from bor"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from qarzi_klient"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from qarzi_man"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from vozvrat"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from his_qarzi_klient"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from his_qarzi_man"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from klient"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from borovaranda"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан базаро тоза кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")
        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from rashod"
            Form1.insert(sql)
            MsgBox("База тоза карда шуд!", MsgBoxStyle.Information)
        End If
    End Sub
End Class