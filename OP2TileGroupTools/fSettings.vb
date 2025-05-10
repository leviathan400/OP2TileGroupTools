Imports System.IO

' OP2TileGroupTools
' Settings Form

Public Class fSettings
    Private Sub fSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.warehouse
        Me.Text = "Outpost 2 Tile Group Tools - Settings"
        lblBuild.Text = "Version " & fMain.Version

        panelBanner.BackgroundImage = My.Resources.banner01_620x100

        ' Load the current values from My.Settings into the text boxes
        txtMapViewerPath.Text = My.Settings.MapViewerPath
        txtJsonMapViewerPath.Text = My.Settings.JsonMapViewerPath
        txtOP2Path.Text = My.Settings.OP2Path
        txtTileGroupFolder.Text = My.Settings.tileGroupFolder
    End Sub

    Private Sub btnBrowseMapViewer_Click(sender As Object, e As EventArgs) Handles btnBrowseMapViewer.Click
        ' Open a file dialog to select the Map Viewer executable
        Using fileDialog As New OpenFileDialog()
            fileDialog.Title = "Select Map Viewer Executable"
            ' Add specific filter for OP2MapViewer.exe
            fileDialog.Filter = "Viewer|OP2MapViewer.exe|Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"

            ' Set initial directory with proper validation
            If Not String.IsNullOrWhiteSpace(txtMapViewerPath.Text) AndAlso
           Path.IsPathRooted(txtMapViewerPath.Text) AndAlso
           Directory.Exists(Path.GetDirectoryName(txtMapViewerPath.Text)) Then
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtMapViewerPath.Text)
            Else
                ' Default to Program Files if the path is invalid
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            End If

            If fileDialog.ShowDialog() = DialogResult.OK Then
                txtMapViewerPath.Text = fileDialog.FileName
            End If
        End Using
    End Sub

    Private Sub btnBrowseJsonMapViewer_Click(sender As Object, e As EventArgs) Handles btnBrowseJsonMapViewer.Click
        ' Open a file dialog to select the JSON Map Viewer executable
        Using fileDialog As New OpenFileDialog()
            fileDialog.Title = "Select JSON Map Viewer Executable"
            ' Add specific filter for OP2MapViewerJson.exe
            fileDialog.Filter = "Viewer|OP2MapViewerJson.exe|Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"

            ' Set initial directory with proper validation
            If Not String.IsNullOrWhiteSpace(txtJsonMapViewerPath.Text) AndAlso
           Path.IsPathRooted(txtJsonMapViewerPath.Text) AndAlso
           Directory.Exists(Path.GetDirectoryName(txtJsonMapViewerPath.Text)) Then
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtJsonMapViewerPath.Text)
            Else
                ' Default to Program Files if the path is invalid
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            End If

            If fileDialog.ShowDialog() = DialogResult.OK Then
                txtJsonMapViewerPath.Text = fileDialog.FileName
            End If
        End Using
    End Sub

    Private Sub btnBrowseOP2Path_Click(sender As Object, e As EventArgs) Handles btnBrowseOP2Path.Click
        ' Open a folder dialog to select the Outpost 2 game directory
        Using folderDialog As New FolderBrowserDialog()
            folderDialog.Description = "Select Outpost 2 Game Directory"
            folderDialog.ShowNewFolderButton = False

            ' Set initial directory with proper validation
            If Not String.IsNullOrWhiteSpace(txtOP2Path.Text) AndAlso
           Directory.Exists(txtOP2Path.Text) Then
                folderDialog.SelectedPath = txtOP2Path.Text
            Else
                ' Default to Program Files if the path is invalid
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            End If

            ' Keep showing the dialog until user selects a valid directory or cancels
            Dim dialogResult As DialogResult
            Dim validDirectorySelected As Boolean = False

            Do
                dialogResult = folderDialog.ShowDialog()

                If dialogResult = DialogResult.OK Then
                    Dim selectedPath As String = folderDialog.SelectedPath

                    ' Validate the Outpost 2 directory using our validation function
                    If IsValidOP2Directory(selectedPath) Then
                        ' Valid Outpost 2 v1.4.1 directory found
                        txtOP2Path.Text = selectedPath
                        validDirectorySelected = True
                    Else
                        ' Display an error message with specific validation requirements
                        MessageBox.Show(
                        "The selected directory is not a valid Outpost 2 v1.4.1 installation." & vbCrLf & vbCrLf &
                        "Please ensure:" & vbCrLf &
                        "- Outpost2.exe exists in the main directory" & vbCrLf &
                        "- OPULauncher.exe exists in the /OPU subfolder",
                        "Invalid Outpost 2 Directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                    End If
                Else
                    ' User canceled the dialog
                    validDirectorySelected = True  ' Exit the loop
                End If
            Loop Until validDirectorySelected
        End Using
    End Sub

    Private Sub btnBrowseTileGroupFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseTileGroupFolder.Click
        ' Open a folder dialog to select the Tile Group exports directory
        Using folderDialog As New FolderBrowserDialog()
            folderDialog.Description = "Select Tile Group Exports Directory"
            folderDialog.ShowNewFolderButton = True

            ' Set initial directory with proper validation
            If Not String.IsNullOrWhiteSpace(txtTileGroupFolder.Text) AndAlso
           Directory.Exists(txtTileGroupFolder.Text) Then
                folderDialog.SelectedPath = txtTileGroupFolder.Text
            Else
                ' Default to Documents folder if the path is invalid
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If

            If folderDialog.ShowDialog() = DialogResult.OK Then
                txtTileGroupFolder.Text = folderDialog.SelectedPath
            End If
        End Using
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Store the values directly to My.Settings
        My.Settings.MapViewerPath = txtMapViewerPath.Text
        My.Settings.JsonMapViewerPath = txtJsonMapViewerPath.Text
        My.Settings.OP2Path = txtOP2Path.Text
        My.Settings.tileGroupFolder = txtTileGroupFolder.Text

        ' Save the settings
        My.Settings.Save()

        ' Close the form
        Me.DialogResult = DialogResult.OK
        Me.Close()

        fMain.WindowState = FormWindowState.Normal
        fMain.BringToFront()
        fMain.Activate()
        fMain.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Just close the form without saving
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' Validates whether a path is a valid Outpost 2 1.4.1 installation directory
    ''' </summary>
    ''' <param name="directoryPath">The directory to validate</param>
    ''' <returns>True if valid, False otherwise</returns>
    Private Function IsValidOP2Directory(directoryPath As String) As Boolean
        ' Check if the directory exists
        If Not Directory.Exists(directoryPath) Then
            Return False
        End If

        ' Check for Outpost2.exe in the main directory
        Dim outpost2ExePath As String = Path.Combine(directoryPath, "Outpost2.exe")
        If Not File.Exists(outpost2ExePath) Then
            Return False
        End If

        ' Check for OPULauncher.exe in the OPU subfolder
        Dim opuSubfolderPath As String = Path.Combine(directoryPath, "OPU")
        Dim opuLauncherPath As String = Path.Combine(opuSubfolderPath, "OPULauncher.exe")

        ' Check if both the OPU subfolder exists and contains OPULauncher.exe
        Return Directory.Exists(opuSubfolderPath) AndAlso File.Exists(opuLauncherPath)
    End Function

End Class