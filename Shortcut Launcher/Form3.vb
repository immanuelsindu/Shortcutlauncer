Imports System.IO

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtName.Text = Form1.Names
        txtPath.Text = Form1.Path
        txtDescription.Text = Form1.Description
        PictureBox1.Image = Form1.ImageList1.Images(Form1.ButtonNameForExt)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For Each c As Control In Form1.MyControls
            If c.Name = ("btn" & Form1.Names) Then
                Form1.Controls.Remove(c)
                c.Dispose()
                Form1.buttonCounter -= 1
            End If
        Next

        Form1.Names = txtName.Text
        Form1.Path = txtPath.Text
        Form1.Description = txtDescription.Text

        'membuat button di Form1
        Form1.buatButton()

        'mengosongkan textBox sebelum form edit di tutup 
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
    End Sub
End Class