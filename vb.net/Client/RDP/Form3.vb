Public Class Form3
    Public sock As Integer

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        Form1.S.Send(sock, "GetProcesses")
    End Sub

    Private Sub KillProcesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillProcesToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        Form1.S.Send(sock, "KillProcess" & Form1.Yy & allprocess)
        RefreshToolStripMenuItem.PerformClick()
    End Sub
End Class