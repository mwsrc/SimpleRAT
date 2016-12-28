Imports System.IO
Public Class Form5
    Dim Stub, text1, text2 As String
    Const spl = "abccba"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As New SaveFileDialog

        s.ShowDialog()
        If s.FileName > "" Then
            text1 = TextBox1.Text
            text2 = TextBox2.Text
            FileOpen(1, Application.StartupPath & "\Stub.exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
            Stub = Space(LOF(1))
            FileGet(1, Stub)
            FileClose(1)
            FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
            FilePut(1, Stub & spl & text1 & spl & text2 & spl & TextBox5.Text & spl & CheckBox1.CheckState & spl & TextBox4.Text & spl & CheckBox2.CheckState & spl & TextBox6.Text & spl & CheckBox3.CheckState & spl & TextBox7.Text)
            FileClose(1)
            MsgBox("Done")

        End If
    End Sub
End Class