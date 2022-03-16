Imports System.IO

Public Class Form1
    Public Property Names As String = String.Empty
    Public Property Path As String = String.Empty
    Public Property Description As String = String.Empty

    Dim list As New List(Of String)
    Dim buttonCounter As Integer = 0
    Dim LocationList As List(Of KeyValuePair(Of Integer, Integer)) = New List(Of KeyValuePair(Of Integer, Integer))


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

        Dim r As StreamReader = New StreamReader("f:/dataLauncher.txt")
        Dim line As String
        line = r.ReadLine

        Dim ini As New IniFile
        ini.Load("f:\dataLauncher.txt")

        While Not line Is Nothing
            Dim hasil As IniFile.IniSection
            hasil = ini.GetSection(line)
            Label1.Text = CStr(hasil)
            Exit While

        End While







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

        If buttonCounter <= 8 And Names <> String.Empty Then
            Dim newButton As Button = New Button
            Dim pair As KeyValuePair(Of Integer, Integer) = LocationList.ElementAt(buttonCounter)
            newButton.Width = 92
            newButton.Height = 82
            newButton.Location = New Point(pair.Key, pair.Value)
            newButton.Visible = True
            newButton.Text = Names
            newButton.ImageList = ImageList1
            newButton.Image = Image.FromFile(Path)
            newButton.ImageAlign = ContentAlignment.TopCenter

            Panel1.Controls.Add(newButton)
            buttonCounter += 1
        ElseIf buttonCounter > 8 Then
            MessageBox.Show("Shortcut maksimal hanya 9")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub


End Class
