Public Class Таърихи_савдо

    Private Sub Таърихи_савдо_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form1.Select()
    End Sub

    Private Sub Таърихи_савдо_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select id_savdo as [Индекс] ,fio as [Номи Мизоҷ], nomi_bor as [Номи бор], shtuk as [Миқдори бор], narhi_furuht as [Нархи фурӯхт] , puli_dog as [Нархи умумии шартнома], puli_pardoht as [Пули пардохтшуда], (puli_dog-puli_pardoht) as [Қарзе, ки монд],foida as [Фоидае, ки бояд монад], sana as [Сана] from savdo, klient where klient.id_klient=savdo.id_klient "
        Form1.GridView(sql, DataGridView1)
        sql = "select distinct klient.fio from klient,savdo where klient.id_klient=savdo.id_klient"
        Form1.connection(sql, ComboBox1, 0)
        sql = "select distinct nomi_bor from savdo "
        Form1.connection(sql, ComboBox2, 0)
       
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql As String = "select id_savdo as [Индекс] , fio as [Номи Мизоҷ], nomi_bor as [Номи бор], shtuk as [Миқдори бор], narhi_furuht as [Нархи фурӯхт] , puli_dog as [Нархи умумии шартнома], puli_pardoht as [Пули пардохтшуда], (puli_dog-puli_pardoht) as [Қарзе, ки монд],foida as [Фоидае, ки бояд монад], sana as [Сана] from savdo,klient where  klient.id_klient=savdo.id_klient  "
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "select id_savdo as [Индекс] , fio as [Номи Мизоҷ], nomi_bor as [Номи бор], shtuk as [Миқдори бор], narhi_furuht as [Нархи фурӯхт] , puli_dog as [Нархи умумии шартнома], puli_pardoht as [Пули пардохтшуда], (puli_dog-puli_pardoht) as [Қарзе, ки монд],foida as [Фоидае, ки бояд монад], sana as [Сана] from savdo,klient   where   klient.id_klient=savdo.id_klient and  fio='" & ComboBox1.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "select id_savdo as [Индекс] , fio as [Номи Мизоҷ], nomi_bor as [Номи бор], shtuk as [Миқдори бор], narhi_furuht as [Нархи фурӯхт] , puli_dog as [Нархи умумии шартнома], puli_pardoht as [Пули пардохтшуда], (puli_dog-puli_pardoht) as [Қарзе, ки монд],foida as [Фоидае, ки бояд монад], sana as [Сана] from savdo ,klient where  klient.id_klient=savdo.id_klient and nomi_bor='" & ComboBox2.Text & "'"
        Form1.GridView(sql, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql2 As String = "select distinct sana from savdo"
        Dim sql As String = "select id_savdo as [Индекс] , fio as [Номи Мизоҷ], nomi_bor as [Номи бор], shtuk as [Миқдори бор], narhi_furuht as [Нархи фурӯхт] , puli_dog as [Нархи умумии шартнома], puli_pardoht as [Пули пардохтшуда], (puli_dog-puli_pardoht) as [Қарзе, ки монд],foida as [Фоидае, ки бояд монад], sana as [Сана] from savdo,klient  where klient.id_klient=savdo.id_klient and  sana in(" & Form1.by_date("savdo", DateTimePicker1, DateTimePicker2, sql2) & ") "



        Form1.GridView(sql, DataGridView1)

    End Sub
  
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If TextBox1.Text <> "" And IsNumeric(TextBox1.Text) Then
                Me.Enabled = False
                Ивази_таърихи_савдо.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub
End Class