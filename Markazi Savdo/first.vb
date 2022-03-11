Imports System.Threading

Public Class first

    Public path As String
    Dim bol As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hw As New cls
        'If hw.GetProcessorId = "BFEBFBFF000406E3" And hw.GetVolumeSerial = "FECA3E8D" And hw.GetMotherBoardID = "NBGDW11004627189B07600" And hw.getMD5Hash("id") = "b80bb7740288fda1f201890375a60c8f" Then
        If TextBox1.Text <> "" Then
            If TextBox1.Text = "123" Then
                path = "shop.db"
                Form1.Show()
                Me.Close()
            ElseIf TextBox1.Text = "456" Then
                path = "shop2.db"
                Form1.Show()
                Me.Close()
            Else
                MsgBox("Паролро хато ворид кардед!")
            End If
        Else
            MsgBox("Паролро дохил кунед!!!")
        End If
        'Else
        '    MsgBox("Ошибка при выбора данных", MsgBoxStyle.Information, "Error")
        '    Me.Close()
        'End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If (TextBox1.Text = "Парол") Then
            TextBox1.PasswordChar = "*"
        End If
    End Sub

    Private Sub first_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        ' Define a handler for unhandled exceptions.
        AddHandler currentDomain.UnhandledException, AddressOf MYExnHandler
        ' Define a handler for unhandled exceptions for threads behind forms.
        AddHandler Application.ThreadException, AddressOf MYThreadHandler
        If DateTime.Now > New DateTime(2019, 9, 1) Then
            'Form1.AutoDelete()
        End If
    End Sub

    Private Sub MYThreadHandler(sender As Object, e As ThreadExceptionEventArgs)
        WriteLogToWindowsEventViewer(e.Exception)
    End Sub

    Private Sub MYExnHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        WriteLogToWindowsEventViewer(e.ExceptionObject)
    End Sub

    Sub WriteLogToWindowsEventViewer(ByVal ex As Exception)
        MsgBox(ex.Message)
        If EventLog.SourceExists(Application.ProductName) <> True Then
            EventLog.CreateEventSource(Application.ProductName, "AppLog")
        End If
        EventLog.WriteEntry(Application.ProductName, ex.Message, EventLogEntryType.Error, 1000)
        Process.GetCurrentProcess().Kill()
    End Sub
End Class