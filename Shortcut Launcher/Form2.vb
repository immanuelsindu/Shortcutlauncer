Imports System.IO

Public Class Form2

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Form1.Names = txtName.Text
        Form1.Path = txtPath.Text
        Form1.Description = txtDescription.Text

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("f:\dataLauncher.txt", True)
        file.WriteLine("[" & txtPath.Text & "]" & Environment.NewLine & txtPath.Text & Environment.NewLine & txtName.Text & Environment.NewLine & txtDescription.Text & Environment.NewLine)
        'file.WriteLine(txtPath.Text)
        'file.WriteLine(txtName.Text)
        'file.WriteLine(txtDescription.Text)
        file.Close()

        txtName.Text = String.Empty
        txtPath.Text = String.Empty
        txtDescription.Text = String.Empty



        Me.Close()
    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        OpenFileDialog1.ShowDialog()
        txtPath.Text = OpenFileDialog1.FileName
        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)



        'Dim sExtension As String = Path.GetExtension(OpenFileDialog1.FileName)
        'sExtension = sExtension.ToLower

        'Dim iconForFile As Icon
        'iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(txtPath.Text)
        'Form1.ImageList1.Images.Add(sExtension, iconForFile)

    End Sub
End Class