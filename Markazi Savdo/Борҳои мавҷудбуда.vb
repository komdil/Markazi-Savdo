Public Class Борҳои_мавҷудбуда

    Private Sub Борҳои_мавҷудбуда_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Амалҳо_бо_борҳо.Enabled = True
        Амалҳо_бо_борҳо.Select()
    End Sub

    Private Sub Борҳои_мавҷудбуда_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select nom as [Номи бор], shtuk as [Миқдори бор]  from bor"
        Form1.GridView(sql, DataGridView1)
        sql = "select nom from bor"
        Form1.connection(sql, ComboBox1, 0)
        sql = "select sum(shtuk) from bor"
        Dim borcount As Integer = Form1.ret(sql)
        Label2.Text = "Миқдори борҳои мавҷудбуда: "
        Label2.Text &= borcount
        sql = "select  sum(narhi_yak_dona*shtuk) from borho , bor where borho.nom=bor.nom"
        Dim summa As Integer = Form1.ret(sql)
        Label3.Text = "Нархи борҳои мавҷудбуда: "
        Label3.Text &= summa
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select nom as [Номи бор], shtuk as [Миқдори бор]  from bor where nom='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select nom as [Номи бор], shtuk as [Миқдори бор]  from bor"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Form1.combo(ComboBox1) Then
            Ивази_бор.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bool = MsgBox("Шумо дар ҳақиқатан хориҷ кардан мехоҳед???", MsgBoxStyle.OkCancel, "ОГОҲӢ!!!")

        If bool = MsgBoxResult.Ok Then
            Dim sql As String = "delete from bor where nom ='" & ComboBox1.Text & "'"
            Form1.insert(sql)
            sql = "select nom as [Номи бор], shtuk as [Миқдори бор]  from bor"
            Form1.GridView(sql, DataGridView1)
            sql = "select nom from bor"
            Form1.connection(sql, ComboBox1, 0)
            sql = "select sum(shtuk) from bor"
            Dim borcount As Integer = Form1.ret(sql)
            Label2.Text = "Миқдори борҳои мавҷудбуда: "
            Label2.Text &= borcount
            sql = "select  sum(narhi_yak_dona*shtuk) from borho , bor where borho.nom=bor.nom"
            Dim summa As Integer = Form1.ret(sql)
            Label3.Text = "Нархи борҳои мавҷудбуда: "
            Label3.Text &= summa
        End If




    End Sub
End Class