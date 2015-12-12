Imports System.Environment
Public Class Form1
    Dim extensionspath As String = GetFolderPath(SpecialFolder.LocalApplicationData) + "\Google\Chrome\User Data\Default\Extensions"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.MinimumSize = Me.MaximumSize

        CheckForUpdates()

        If Not My.Computer.FileSystem.DirectoryExists(extensionspath) Then
            MessageBox.Show("Chrome installation not found! Exiting...", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If

        RichTextBox1.Text = extensionspath
    End Sub
    Public Sub CheckForUpdates()
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://hgcommunity.net/programs/chrome_extension_uninstaller/version.txt")

            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = System.Windows.Forms.Application.ProductVersion
            If newestversion.Contains(currentversion) Then

            Else
                Try
                    MessageBox.Show("A newer version has been found! Opening download page...", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    System.Diagnostics.Process.Start("http://hgcsrt.cf/Ehg4A")
                    End
                Catch ex As Exception

                End Try

                End
            End If
        Catch ex As Exception
            MessageBox.Show("Error while contacting HGCommunity server :(", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(extensionspath + "\" + TextBox1.Text) Then
                Shell("taskkill /F /IM chrome.exe")
                Try
                    My.Computer.FileSystem.DeleteDirectory(extensionspath + "\" + TextBox1.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    MessageBox.Show("Extension successfully deleted!", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Extension not found!", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Extension not found!", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Extension not found!", "Chrome Extension Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
