Public Class Рӯйхати_боровардагон

    Private Sub Рӯйхати_боровардагон_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Бороварандагон.Enabled = True
        Бороварандагон.Select()
    End Sub

    Private Sub Рӯйхати_боровардагон_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from borovaranda"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from borovaranda"
        Form1.connection(sql, ComboBox1, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from borovaranda where fio= '" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text <> "" And Form1.combo(ComboBox1) Then
            Ивази_бороваранда.Show()
            Me.Enabled = False
        End If
       
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql As String = "select fio as [Ном ва насаб] , telefon as [Телефон], suroga as [Суроға] from borovaranda"
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct fio from borovaranda"
        Form1.connection(sql, ComboBox1, 0)
    End Sub
End Class