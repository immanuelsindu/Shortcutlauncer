Imports System.IO
Imports iniFileVB


Public Class Form2

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Form1.Names = txtName.Text
        Form1.Path = txtPath.Text
        Form1.Description = txtDescription.Text

        Dim ini As New IniFile
        ini.Load("f:\dataLauncher.txt")
        ini.AddSection(txtPath.Text).AddKey("Path").Value = txtPath.Text
        ini.AddSection(txtPath.Text).AddKey("Name").Value = txtName.Text
        ini.AddSection(txtPath.Text).AddKey("Description").Value = txtDescription.Text
        ini.Save("f:\dataLauncher.txt")

        'Dim file As System.IO.StreamWriter
        'ile = My.Computer.FileSystem.OpenTextFileWriter("f:\dataLauncher.txt", True)
        'File.WriteLine("[" & txtPath.Text & "]" & Environment.NewLine & txtPath.Text & Environment.NewLine & txtName.Text & Environment.NewLine & txtDescription.Text)
        'File.Close()

        txtName.Text = String.Empty
        txtPath.Text = String.Empty
        txtDescription.Text = String.Empty
        Me.Close()
    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        OpenFileDialog1.ShowDialog()
        txtPath.Text = OpenFileDialog1.FileName
        Dim iconForFile As Icon = SystemIcons.WinLogo
        Dim ext As String = Path.GetExtension(OpenFileDialog1.FileName)
        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(OpenFileDialog1.FileName)
        Form1.ImageList1.Images.Add(ext, iconForFile)
        Form1.ButtonNameForExt = ext

        PictureBox1.Image = Form1.ImageList1.Images(ext)
        'PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)



        'Dim sExtension As String = Path.GetExtension(OpenFileDialog1.FileName)
        'sExtension = sExtension.ToLower

        'Dim iconForFile As Icon
        'iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(txtPath.Text)
        'Form1.ImageList1.Images.Add(sExtension, iconForFile)

    End Sub
End Class