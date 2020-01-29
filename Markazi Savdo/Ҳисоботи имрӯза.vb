Public Class Ҳисоботи_имрӯза
    Private Sub Ҳисоботи_имрӯза_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub
    Private Sub Ҳисоботи_имрӯза_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Now.Date
        ListBox1.Items.Clear()
        Dim miq_qutii_bor, puli_bor, foida As Long
        Dim sql As String = "select sum(miqdori_qutti*miq_bori_qutti) from borho where sana='" & DateTimePicker1.Text & "'"
        miq_qutii_bor = Form1.get_result(sql)
        sql = "select sum(puli_paddohtshuda) from borho where sana='" & DateTimePicker1.Text & "'"
        puli_bor = Form1.get_result(sql)
        Dim miq_furush, puli_furush As Long
        sql = "select sum(shtuk) from savdo where sana='" & DateTimePicker1.Text & "'"
        miq_furush = Form1.get_result(sql)
        sql = "select sum(puli_pardoht) from savdo where sana='" & DateTimePicker1.Text & "'"
        puli_furush = Form1.get_result(sql)
        sql = "select sum(foida) from savdo where sana='" & DateTimePicker1.Text & "'"
        foida = Form1.get_result(sql)
        Dim rashod As Integer

        sql = "select sum(miqdor) from rashod where sana = '" & DateTimePicker1.Text & "'"
        rashod = Form1.get_result(sql)
        ListBox1.Items.Add("Рӯзи " & DateTimePicker1.Text)
        ListBox1.Items.Add(miq_qutii_bor & " -адад  бор омад")
        ListBox1.Items.Add(puli_bor & " -миқдор пул ба бори омада дода шуд")
        ListBox1.Items.Add(miq_furush & " -адад бор фурухта шуд")
        ListBox1.Items.Add(rashod & " - миқдор пул хароҷот карда шуд")
        ListBox1.Items.Add(puli_furush & " -миқдор пул аз тарафи Мизоҷ дода шуд")
        ListBox1.Items.Add(foida & " -миқдор бояд фоида гирифта шавад")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim miq_qutii_bor, puli_bor, foida As Long
        Dim sqll As String = "select distinct sana from borho"
        Dim sql As String = "select sum(miqdori_qutti) from borho where sana in (" & Form1.by_date("borho", DateTimePicker1, DateTimePicker2, sqll) & ")"
        miq_qutii_bor = Form1.get_result(sql)
        sql = "select sum(puli_paddohtshuda) from borho where sana in (" & Form1.by_date("borho", DateTimePicker1, DateTimePicker2, sqll) & ")"
        puli_bor = Form1.get_result(sql)
        Dim miq_furush, puli_furush As Long
        sqll = "select distinct sana from savdo"
        sql = "select sum(shtuk) from savdo where sana in (" & Form1.by_date("savdo", DateTimePicker1, DateTimePicker2, sqll) & ")"
        miq_furush = Form1.get_result(sql)
        sql = "select sum(puli_pardoht) from savdo where sana in (" & Form1.by_date("savdo", DateTimePicker1, DateTimePicker2, sqll) & ")"
        puli_furush = Form1.get_result(sql)
        sql = "select sum(foida) from savdo where sana in (" & Form1.by_date("savdo", DateTimePicker1, DateTimePicker2, sqll) & ")"
        foida = Form1.get_result(sql)
        Dim rashod As Integer
        sqll = "select distinct sana from rashod"
        sql = "select sum(miqdor) from rashod where sana in (" & Form1.by_date("rashod", DateTimePicker1, DateTimePicker2, sqll) & ") "
        rashod = Form1.get_result(sql)
        ListBox1.Items.Add("Аз рӯзи " & DateTimePicker1.Text & " то " & DateTimePicker2.Text)
        ListBox1.Items.Add(miq_qutii_bor & " -адад каробка бор омад")
        ListBox1.Items.Add(puli_bor & " -миқдор пул ба бори омада дода шуд")
        ListBox1.Items.Add(miq_furush & " -адад бор фурухта шуд")
        ListBox1.Items.Add(puli_furush & " -миқдор пул аз тарафи Мизоҷ дода шуд")
        ListBox1.Items.Add(rashod & " - миқдор пул хароҷот карда шуд")
        ListBox1.Items.Add(foida & " -миқдор бояд фоида гирифта шавад")
    End Sub
End Class