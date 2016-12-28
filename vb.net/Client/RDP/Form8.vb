Imports System.IO
Public Class Form8

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       
        Try
            Dim aa As String() = Split(File.ReadAllText(Application.StartupPath & "\Settings.ini"), "|")
            If aa(0) = "true" Then CheckBox3.Checked = True Else CheckBox3.Checked = False
            NumericUpDown1.Value = aa(1)
            TextBox1.Text = aa(2)
            '// If aa(3) = "true" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
            '  If aa(3) = "true" Then Form1.SkinCrafter1.SkinFile = Application.StartupPath & "\skins\" & aa(4)
        Catch : End Try
    End Sub









    

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Start" Then
            Button1.Text = "Stop"
            Try

                Form1.S = New SocketServer
                Form1.S.Start(NumericUpDown1.Value)
                
                'Button1.Enabled = False

            Catch : End Try
            Form1.lbl1.Text = "Listening On Port : " & NumericUpDown1.Value.ToString

        Else
            Form1.lbl1.Text = "Listening On Port : ----"

            Button1.Text = "Start"
            For Each x As ListViewItem In Form1.L1.Items
                Form1.S.Disconnect(x.ToolTipText)
            Next
            Form1.S.stops()
        End If
    End Sub




    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If File.Exists(Application.StartupPath & "\Settings.ini") Then File.Delete(Application.StartupPath & "\Settings.ini")
            Dim a As String
            If CheckBox3.Checked = True Then a += "true|" Else a += "false|"
            a += NumericUpDown1.Value & "|"
            a += TextBox1.Text & "|"
            ' If CheckBox2.Checked = True Then a += "true|" Else a += "false|"
            '// If CheckBox1.Checked = True Then a += "true|" Else a += "false|"
            '// a += ListBox1.SelectedItem.ToString & "|"
            File.WriteAllText(Application.StartupPath & "\settings.ini", a)
            Form1.pw = TextBox1.Text
        Catch : End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    
End Class