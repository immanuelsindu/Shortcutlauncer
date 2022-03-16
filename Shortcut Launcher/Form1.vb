Imports System.IO

Public Class Form1
    Public Property Names As String = String.Empty
    Public Property Path As String = String.Empty
    Public Property Description As String = String.Empty

    Public Property ButtonNameForExt As String = String.Empty

    'Untuk menampung list Controls
    Public Property MyControls As List(Of Control) = New List(Of Control)

    Public Property LocationList As List(Of KeyValuePair(Of Integer, Integer)) = New List(Of KeyValuePair(Of Integer, Integer))
    Public Property buttonCounter As Integer = 0

    Dim list As New List(Of String)

    Public Sub buatButton()
        If buttonCounter <= 8 And Names <> String.Empty Then
            'membuat button secara dinamis di dalam panel
            Dim newButton As Button = New Button
            Dim pair As KeyValuePair(Of Integer, Integer) = LocationList.ElementAt(buttonCounter)
            newButton.Width = 92
            newButton.Height = 82
            newButton.Location = New Point(pair.Key, pair.Value)
            newButton.Visible = True
            newButton.Text = Names
            newButton.ImageList = ImageList1
            newButton.Image = ImageList1.Images(ButtonNameForExt)
            newButton.ImageAlign = ContentAlignment.TopCenter
            newButton.BackgroundImageLayout = ImageLayout.Stretch
            newButton.Name = "btn" & Names
            newButton.ContextMenuStrip = ContextMenuStrip1

            'untuk menambahkan tooltip (hint informasi)
            Dim mytooltip As ToolTip = New ToolTip
            mytooltip.ToolTipIcon = ToolTipIcon.Info
            mytooltip.ToolTipTitle = "Shortcut Launcer Tip"
            mytooltip.SetToolTip(newButton, Description)

            'untuk menambahkan button ke panel secara dinamis
            Panel1.Controls.Add(newButton)
            AddHandler newButton.Click, AddressOf Me.Button_Click
            buttonCounter += 1

            'untuk menambahkan button ke dalam list Controls
            'Me.Controls.Add(newButton) 'error yang di sini 
            MyControls.Add(newButton)

        ElseIf buttonCounter > 8 Then
            MessageBox.Show("Shortcut maksimal hanya 9")
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(14, 13))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(128, 13))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(242, 13))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(14, 115))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(128, 115))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(242, 115))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(14, 214))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(128, 214))
        LocationList.Add(New KeyValuePair(Of Integer, Integer)(242, 214))



        'Dim r As StreamReader = New StreamReader("\dataLauncher.txt")
        'Dim line As String
        'line = r.ReadLine

        'Dim ini As New IniFile
        'ini.Load("\dataLauncher.txt")


        ' Store contents in this String.

        'Dim hasil As List(Of String)

        ' Read first line.


        'While Not r Is Nothing
        'hasil.Add(CStr(r.ReadLine))
        'End While


        'TextBox1.Text = hasil.ElementAt(0)
        'End Using
    End Sub

    Private Sub AddNewShortcutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewShortcutToolStripMenuItem.Click
        Form2.ShowDialog()
        Me.Refresh()

        buatButton()
    End Sub

    Private Sub EditShortcutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditShortcutToolStripMenuItem.Click
        Form3.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start(Path)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'ini kemungkinan masih bug / error
        Me.Controls.Clear() 'menghapus semua controls yang ada di form
        InitializeComponent() 'load semua controls lagi 
        Form1_Load(e, e) 'load semuanya di form, load event juga 
    End Sub
End Class
