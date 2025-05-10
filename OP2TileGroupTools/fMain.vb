Imports OP2UtilityDotNet
Imports OP2UtilityDotNet.OP2Map
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms.AxHost

' OP2TileGroupTools
' https://github.com/leviathan400/OP2TileGroupTools
'
' Simple app to open original .map file and export the tile groups to .json files.
' Also can create a .map file containing all of the tile groups.
' Maybe add other tools later..
'
'
' Outpost 2: Divided Destiny is a real-time strategy video game released in 1997.

Public Class fMain
    Public ApplicationName As String = "OP2TileGroupTools"
    Public Version As String = "0.3.4"
    Public Build As String = "0034"

#Region "Class Variables and Constants"

    'This is the list of the original 218 tile groups. They are contained in
    'all original map files. However they do not need to be.
    '
    'They give us some usefull tile groups to work with for OP2Mapper etc.
    'The data also helps us categorize all of the tiles.
    '
    '
    'Tile Groups: 218
    'BLUE (1x1), mudbas1 (4x4), mudbas2 (4x4), mudcrk1 (2x3), mudcrk10 (1x1), 
    'mudcrk2 (2x3), mudcrk3 (3x2), mudcrk4 (2x3), mudcrk5 (2x2), mudcrk6 (2x2), 
    'mudcrk7 (1x1), mudcrk8 (2x1), mudcrk9 (1x1), muddoz (1x1), mudlavw (16x1), 
    'mudmes00 (3x6), mudmes01 (2x3), mudmes02 (3x3), mudmes03 (3x3), mudmes04 (3x3), 
    'mudmes05 (3x3), mudmes06 (3x3), mudmes07 (3x3), mudmes08 (3x3), mudmes09 (3x1), 
    'mudmes10 (3x1), mudmes11 (4x6), mudmes12 (3x3), mudmes13 (3x3), mudmes14 (3x3), 
    'mudmes15 (3x3), mudmes16 (2x5), mudmes17 (2x5), mudmicw (16x1), mudpln01 (2x2), 
    'mudpln02 (2x2), mudpln03 (2x2), mudpln04 (1x1), mudpln05 (1x1), mudpln06 (1x1), 
    'mudpln07 (1x1), mudpln08 (1x1), mudpln09 (1x1), mudpln10 (1x1), mudpln11 (1x1), 
    'mudpln12 (1x1), mudrock1 (2x2), mudrock2 (3x3), mudrock3 (1x1), mudrock4 (1x1), 
    'mudrock5 (2x3), mudrock6 (2x3), mudrub01 (2x2), mudrub02 (2x2), mudtubes (6x1), 
    'mudwall1 (16x1), mudwall2 (16x1), mudwall3 (16x1), mudwrk01 (1x1), mudwrk02 (2x1), 
    'mudwrk03 (2x2), mudwrk04 (2x2), mudwrk05 (1x1), mudwrk06 (2x2), mudwrk07 (1x1), 
    'mudwrk08 (1x1), mudwrk09 (1x1), mudwrk10 (1x1), mudwrk11 (1x1), mudwrk12 (1x1), 
    'mudwrk13 (3x2), mudwrk14 (1x1), mudwrk15 (1x1), rocbas1 (4x4), rocbas2 (4x4), 
    'rocbas3 (4x4), rocbas4 (3x3), rocbas5 (3x3), roccrac1 (2x5), roccrac2 (1x2), 
    'roccrac3 (2x1), roccrac4 (2x1), roccrac5 (2x8), rocdoz (1x1), roclavw (16x1), 
    'rocmicw (16x1), rocroc1 (3x3), rocroc2 (4x1), rocroc3 (3x3), rocroc4 (2x3), 
    'rocrub01 (2x2), rocrub02 (2x2), roctola3 (6x8), roctomud (6x8), roctubes (6x1), 
    'rocvent1 (1x1), rocvolc1 (6x6), rocvolc2 (3x3), rocvolc3 (6x6), rocvolc4 (10x10), 
    'rocwall1 (16x1), rocwall2 (16x1), rocwall3 (16x1), rocwrk01 (1x1), rocwrk02 (1x1), 
    'rocwrk03 (1x1), rocwrk04 (1x1), rocwrk05 (1x1), rocwrk06 (1x1), rocwrk07 (1x1), 
    'rocwrk08 (1x1), rocwrk09 (1x1), rocwrk10 (1x1), rocwrk11 (1x1), rocwrk12 (1x1), 
    'rocwrk13 (1x1), rocwrk14 (1x1), rocwrk15 (1x1), rocwrk16 (1x2), rocwrk17 (1x1), 
    'rocwrk18 (2x2), rocwrk19 (2x2), rocwrk20 (3x3), roczlav (16x6), sanbas1 (4x4), 
    'sanbas2 (4x4), sanbas3 (4x4), sanbas4 (4x4), sanbas5 (4x4), sancrat1 (5x2), 
    'sancrat2 (2x2), sancrat3 (4x4), sancratx1 (3x1), sancratx2 (2x2), sancratx3 (2x4), 
    'sancratx4 (2x2), sancratx5 (3x1), sancratx6 (2x2), sancratx7 (2x4), sancratx8 (2x2), 
    'sandoz (1x1), sanlavw (16x1), sanmes00 (3x1), sanmes01 (3x1), sanmes02 (3x1), 
    'sanmes03 (3x3), sanmes04 (3x3), sanmes05 (3x4), sanmes06 (3x3), sanmes07 (3x4), 
    'sanmes08 (3x3), sanmes09 (3x3), sanmes10 (3x3), sanmes11 (3x3), sanmes12 (3x3), 
    'sanmes13 (3x3), sanmes14 (3x4), sanmes15 (3x4), sanmes16 (3x3), sanmicw (16x1), 
    'sanrok01 (3x3), sanrok02 (3x3), sanrok03 (2x3), sanrok04 (2x3), sanrok05 (2x2), 
    'sanrok06 (2x2), sanrok07 (2x2), sanrok08 (2x2), sanrub01 (2x2), sanrub02 (2x2), 
    'santomud (6x8), santoroc (6x8), santube (6x1), sanwall1 (16x1), sanwall2 (16x1), 
    'sanwall3 (16x1), sanwrk01 (1x1), sanwrk02 (1x1), sanwrk03 (1x1), sanwrk04 (1x1), 
    'sanwrk05 (1x1), sanwrk06 (1x1), sanwrk07 (1x1), sanwrk08 (1x1), sanwrk09 (1x1), 
    'sanwrk10 (1x1), sanwrk11 (1x1), sanwrk12 (1x1), sanwrk13 (1x1), sanwrk14 (1x1), 
    'sanwrk15 (1x1), sanwrk16 (1x1), sanwrk17 (4x2), sanwrk18 (1x1), sanwrk19 (2x2), 
    'snowroc1 (6x3), snowroc2 (6x3), snowroc3 (6x3), snowroc4 (6x3), snowroc5 (6x3), 
    'snowroc6 (6x3), snowroc7 (6x3), snowroc8 (6x3), snowroc9 (2x3), snwtran1 (6x6), 
    'snwtran2 (6x6), muddoz2 (8x1), mudtube2 (16x1), rocdoz2 (8x1), roctube2 (16x1), 
    'sandoz2 (8x1), santube2 (16x1), LEFT_LAVA (12x4), midd_lava (12x2), RIGHT_LAVA (12x4), 
    'mudburn (3x2), rocburn (3x3), sanburn (3x2)

    Private currentMap As Map = Nothing         ' Current loaded map
    Private currentMapPath As String = Nothing  ' File path of map opened

    Private TileSetPrefix As String = Nothing   ' Tileset prefix eg "well00"

    'Private tileGroupFolder As String = "D:\TileGroupExports"
    'Private outputPath As String = "D:\TileGroupExports"
    'Private BlankMapsPath As String = "D:\blankmaps"

    'Private tileGroupFolder As String = Application.StartupPath & "\TileGroupExports"
    'Private outputPath As String = Application.StartupPath
    Private BlankMapsPath As String = Application.StartupPath
    Private outputFileName As String = "tile_groups_map.map"

    'Private MapViewerPath As String = "D:\opu\build\OP2MapViewer.exe"   'OP2MapViewer
    'Private JsonMapViewerPath As String = "D:\opu\build\OP2MapViewerJson.exe"  'OP2MapViewerJson

    ' For use in loading tile groups from json files
    Private currentTileGroupData As JObject = Nothing
    Private TileGroupTiles As JArray = Nothing
    Private TileGroupWidth As Integer = 0
    Private TileGroupHeight As Integer = 0

    ' For use in tile group map creation
    ' Set map dimensions to load - 128x128 - Plenty of space for all the tile groups
    Private mapWidth As Integer = 128
    Private mapHeight As Integer = 128
    ' We have blank_128x128.map in My.Resources
    Private blankMapFileName As String = "blank_" & mapWidth & "x" & mapHeight & ".map"     ' Blank map file name

#End Region

#Region "Form Initialization and UI Events"

    ''' <summary>
    ''' Form load event handler. Initializes the application.
    ''' </summary>
    ''' <param name="sender">The sender object</param>
    ''' <param name="e">Event arguments</param>
    Private Sub fMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("--- " & ApplicationName & " Started ---")
        'Debug.WriteLine(Application.StartupPath)
        'Debug.WriteLine(Environment.CurrentDirectory)

        Me.Icon = My.Resources.warehouse
        Me.Text = "Outpost 2 Tile Group Tools"

        ' Disable export button until a map is loaded
        btnExportTileGroups.Enabled = False

        ' Only set default paths if settings are blank (first run)
        If String.IsNullOrWhiteSpace(My.Settings.MapViewerPath) Then
            Debug.WriteLine("First Run")

            'My.Settings.MapViewerPath = "D:\opu\build\OP2MapViewer.exe"
            My.Settings.MapViewerPath = Application.StartupPath & "\OP2MapViewer.exe"

        End If
        If String.IsNullOrWhiteSpace(My.Settings.JsonMapViewerPath) Then
            'My.Settings.JsonMapViewerPath = Application.StartupPath & "\OP2MapViewerJson.exe"  'Not currently used

        End If
        If String.IsNullOrWhiteSpace(My.Settings.tileGroupFolder) Then
            My.Settings.tileGroupFolder = Application.StartupPath & "\TileGroupExports"

        End If
        My.Settings.Save()

    End Sub

    ''' <summary>
    ''' Event handler for the Open Map button click. Opens an Outpost 2 map file.
    ''' </summary>
    ''' <param name="sender">The sender object</param>
    ''' <param name="e">Event arguments</param>
    Private Sub btnOpenMap_Click(sender As Object, e As EventArgs) Handles btnOpenMap.Click
        Try
            ' Set up OpenFileDialog
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Outpost 2 Map Files (*.map)|*.map|All files (*.*)|*.*"
            openFileDialog.Title = "Select an Outpost 2 Map File"

            ' Show the dialog and check if user clicked OK
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                txtConsole.Clear()

                OpenMapFile(openFileDialog.FileName, True)

                If currentMap.tileGroups.Count = 0 Then
                    AppendToConsole("The map contains no tile groups.")
                    btnExportTileGroups.Enabled = False
                Else
                    ' Check the map if it has corrupt tile group names - OP2Mapper2 would corrupt them
                    If HasCorruptTileGroupNames() = True Then
                        AppendToConsole("The map's tile group names are corrupt. Export disabled.")
                        AppendToConsole("This is likely because the map was opened with OP2Mapper2. ")
                        btnExportTileGroups.Enabled = False

                    Else
                        AppendToConsole("You can now export the tile groups.")
                        ' Update UI state to reflect that a map is loaded and as we have tile groups, let the user export them
                        btnExportTileGroups.Enabled = True

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Error opening file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'AppendToConsole("currentMapPath: " & currentMapPath)

        'ShowTileGroups()

        'ShowTileGroupInfo("snowroc7")          ' Show info for snowroc7
        'ShowTileGroupInfo("mudbas1")           ' Show info for mudbas1

    End Sub

    ''' <summary>
    ''' Event handler for the Export Tile Groups button click. 
    ''' Exports all tile groups from the current map to JSON files.
    ''' </summary>
    ''' <param name="sender">The sender object</param>
    ''' <param name="e">Event arguments</param>
    Private Sub btnExportTileGroups_Click(sender As Object, e As EventArgs) Handles btnExportTileGroups.Click
        btnExportTileGroups.Enabled = False

        ExportAllTileGroups()

        btnExportTileGroups.Enabled = True
    End Sub

    ''' <summary>
    ''' Event handler for the Create Map button click.
    ''' Creates a map file containing all tile groups found in the tile group folder.
    ''' </summary>
    ''' <param name="sender">The sender object</param>
    ''' <param name="e">Event arguments</param>
    Private Sub btnCreateMap_Click(sender As Object, e As EventArgs) Handles btnCreateMap.Click
        ' Create a map file containing all of the tile groups

        txtConsole.Clear()

        ' Check for the blank map file
        Dim blankMapPath As String = Path.Combine(BlankMapsPath, blankMapFileName)
        If File.Exists(blankMapFileName) = True Then
            'Debug.WriteLine("File Exists True - " & blankMapPath)
        Else
            ' Copy the blank map from My.Resources if its the first time we are exporting tile groups
            'Debug.WriteLine("File Exists False - " & blankMapPath)
            Debug.WriteLine("Cant find blank map. Copy the blank map to file system.")

            Try
                Dim fileBytes() As Byte = My.Resources.blank_128x128
                File.WriteAllBytes(blankMapPath, fileBytes)
            Catch ex As Exception
                Debug.WriteLine("Cant create the blank map.")
            End Try
        End If

        Try
            AppendToConsole("Creating map with all tile groups from: " & My.Settings.tileGroupFolder)
            CreateTileGroupMapFile(outputFileName)

        Catch ex As Exception
            AppendToConsole("Error creating tile group map: " & ex.Message)
            MessageBox.Show("Error creating tile group map: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Event handler for the Settings button click.
    ''' Opens the settings form.
    ''' </summary>
    ''' <param name="sender">The sender object</param>
    ''' <param name="e">Event arguments</param>
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        fSettings.Show()
    End Sub

#End Region

#Region "Form Display"

    ''' <summary>
    ''' Appends text to the console TextBox with a newline and scrolls to the latest text.
    ''' </summary>
    ''' <param name="text">The text to append to the console</param>
    Private Sub AppendToConsole(text As String)
        ' Append text to the console with a newline
        txtConsole.AppendText(text & vbCrLf)

        ' Scroll to the end of the text
        txtConsole.SelectionStart = txtConsole.Text.Length
        txtConsole.ScrollToCaret()
    End Sub

#End Region

#Region "Map File Operations"

    ''' <summary>
    ''' Opens and analyzes a map file
    ''' </summary>
    ''' <param name="filePath">Path to the map file to open</param>
    ''' <param name="ShowOutput">Show information on the console</param>
    Private Sub OpenMapFile(filePath As String, ShowOutput As Boolean)
        Try
            Debug.WriteLine("Opening map file: " & filePath)
            If ShowOutput = True Then
                AppendToConsole("Opening map file: " & filePath & vbCrLf)
            End If

            currentMapPath = filePath

            ' Check file extension to determine if it's a map or saved game
            If Path.GetExtension(filePath).ToLower() = ".map" Then
                currentMap = Map.ReadMap(filePath)
                If ShowOutput = True Then
                    AppendToConsole("File type: Standard map file")
                End If
            Else
                currentMap = Map.ReadSavedGame(filePath)
                If ShowOutput = True Then
                    AppendToConsole("File type: Saved game file")
                End If
            End If

            If ShowOutput = True Then
                ' Display map properties
                AppendToConsole("Map size: " & currentMap.WidthInTiles() & " x " & currentMap.HeightInTiles())
                'AppendToConsole("Version tag: 0x" & currentMap.GetVersionTag().ToString("X4"))
                'AppendToConsole("Is saved game: " & currentMap.IsSavedGame())
                'AppendToConsole("Number of tile sets: " & currentMap.tilesetSources.Count)
                'AppendToConsole("Number of tiles: " & currentMap.TileCount())

                ' Display information about each tileset source (non-empty ones only)
                'AppendToConsole(vbCrLf & "Tileset Sources (non-empty only):")
                Dim TileSetCount As Int16 = 0

                For i As Integer = 0 To currentMap.tilesetSources.Count - 1
                    Dim source As TilesetSource = currentMap.tilesetSources(i)
                    ' Only show sources with at least 1 tile
                    If source.numTiles > 0 Then
                        TileSetPrefix = Mid(source.tilesetFilename, 1, 6)
                        'AppendToConsole("  " & i & ": " & source.tilesetFilename & " (" & source.numTiles & " tiles)")
                        TileSetCount = TileSetCount + 1
                    End If
                Next
                AppendToConsole("Tile Set Name: " & TileSetPrefix)
                'AppendToConsole("Tile Sets: " & TileSetCount)

                ' Display information about terrain types
                'AppendToConsole("Terrain Types: " & currentMap.terrainTypes.Count)

                ' Display information about tile groups
                AppendToConsole("Tile Groups: " & currentMap.tileGroups.Count)

                AppendToConsole(vbCrLf & "Map loaded successfully." & vbCrLf)

            End If

        Catch ex As Exception
            AppendToConsole("Error reading map file: " & ex.Message)
            MessageBox.Show("Error reading map file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            currentMap = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' Displays all tile groups in the current map to the console
    ''' </summary>
    Private Sub ShowTileGroups()
        ' List tile groups in the map
        Try
            AppendToConsole("Listing Tile Groups: " & currentMap.tileGroups.Count)

            Dim tileGroupsText As New System.Text.StringBuilder()

            For i As Integer = 0 To currentMap.tileGroups.Count - 1
                Dim group As TileGroup = currentMap.tileGroups(i)
                tileGroupsText.Append(group.name & " (" & group.tileWidth & "x" & group.tileHeight & ")")

                ' Add comma if not the last item
                If i < currentMap.tileGroups.Count - 1 Then
                    tileGroupsText.Append(", ")
                End If

                ' Add line breaks periodically to avoid extremely long lines
                If (i + 1) Mod 5 = 0 Then
                    tileGroupsText.Append(vbCrLf & "  ")
                End If
            Next

            AppendToConsole("  " & tileGroupsText.ToString())
            AppendToConsole(vbCrLf)

        Catch ex As Exception
            AppendToConsole("ShowTileGroups Error: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Export Tile Groups"

    ''' <summary>
    ''' Exports all tile groups from the loaded map to JSON files
    ''' </summary>
    Private Sub ExportAllTileGroups()
        ' Export tile groups from the loaded map into json format
        AppendToConsole("")

        ' Create a directory for exports if it doesn't exist
        If Not Directory.Exists(My.Settings.tileGroupFolder) Then
            Directory.CreateDirectory(My.Settings.tileGroupFolder)
        End If

        Try
            AppendToConsole("Exporting " & currentMap.tileGroups.Count & " tile groups.")
            AppendToConsole("")
            AppendToConsole("Export Folder: " & My.Settings.tileGroupFolder)

            ' Display information about tile groups in a comma-separated format
            'AppendToConsole(vbCrLf & "Tile Groups: " & currentMap.tileGroups.Count)
            AppendToConsole(vbCrLf & "Tile Groups List:")
            Dim tileGroupsText As New System.Text.StringBuilder()

            For tileGrp As Integer = 0 To currentMap.tileGroups.Count - 1
                Dim group As TileGroup = currentMap.tileGroups(tileGrp)
                tileGroupsText.Append(group.name & " (" & group.tileWidth & "x" & group.tileHeight & ")")

                ' Add comma if not the last item
                If tileGrp < currentMap.tileGroups.Count - 1 Then
                    tileGroupsText.Append(", ")
                End If

                ' Add line breaks periodically to avoid extremely long lines
                If (tileGrp + 1) Mod 5 = 0 Then
                    tileGroupsText.Append(vbCrLf & "  ")
                End If
            Next
            AppendToConsole("  " & tileGroupsText.ToString())

            Dim i As Integer
            For i = 0 To currentMap.tileGroups.Count - 1
                Dim group As TileGroup = currentMap.tileGroups(i)

                'AppendToConsole(" " & i & " - " & group.name)

                'Export this tile group to JSON
                ExportSingleTileGroup(i, group.name)
            Next

            AppendToConsole("")
            AppendToConsole("Exported all tile groups from map. " & i & " tile groups in total.")

            ' Open the export 
            Process.Start(My.Settings.tileGroupFolder)

        Catch ex As Exception
            AppendToConsole("ExportAllTileGroups Error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Exports a single tile group by name from the current map
    ''' </summary>
    ''' <param name="groupName">Name of the tile group to export</param>
    Public Sub ExportSingleTileGroupByName(groupName As String)
        ' Find the tile group
        Dim groupIndex As Int16 = FindTileGroup(currentMap, groupName)

        ExportSingleTileGroup(groupIndex, groupName)
    End Sub

    ''' <summary>
    ''' Exports a single tile group from the loaded map into JSON format
    ''' </summary>
    ''' <param name="groupIndex">Index of the tile group in the map's tileGroups collection</param>
    ''' <param name="groupName">Name of the tile group to export</param>
    Public Sub ExportSingleTileGroup(groupIndex As Int16, groupName As String)
        ' Export a single tile group from the loaded map into JSON format

        Try
            'AppendToConsole("Exporting Tile Group: " & groupName)

            If groupIndex < 0 Then
                AppendToConsole("  Error: Tile group '" & groupName & "' not found.")
                Return
            End If

            ' Create the tile group object
            Dim group As TileGroup = currentMap.tileGroups(groupIndex)

            ' Create the JSON object
            Dim jsonObject As New JObject()

            ' Add header information
            Dim header As New JObject()
            header.Add("width", group.tileWidth)
            header.Add("height", group.tileHeight)
            header.Add("tileset", TileSetPrefix)
            header.Add("name", group.name)
            header.Add("bmp", "")       ' Empty for now 
            header.Add("notes", "")     ' Empty for now 
            jsonObject.Add("header", header)

            ' Add tiles as 2D array
            Dim tilesArray As New JArray()
            For y As Integer = 0 To group.tileHeight - 1
                Dim rowArray As New JArray()
                For x As Integer = 0 To group.tileWidth - 1
                    Dim index As Integer = y * group.tileWidth + x
                    If index < group.mappingIndices.Count Then
                        rowArray.Add(group.mappingIndices(index))
                    Else
                        rowArray.Add(0)
                    End If
                Next
                tilesArray.Add(rowArray)
            Next
            jsonObject.Add("tiles", tilesArray)

            ' Save to file
            Dim filePath As String = Path.Combine(My.Settings.tileGroupFolder, group.name & ".json")
            File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented))

            ' Read the file and format it nicely with padded numbers
            Dim fileContent As String = File.ReadAllText(filePath)
            Dim processedContent As String = FormatJsonArrays(fileContent, True)
            File.WriteAllText(filePath, processedContent)

            'AppendToConsole("Exported tile group to: " & filePath)

        Catch ex As Exception
            AppendToConsole("ExportSingleTileGroup Error exporting: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Formats JSON array content with proper commas between elements
    ''' </summary>
    ''' <param name="jsonContent">The JSON content to format</param>
    ''' <param name="padNumbers">Whether to pad numbers for alignment</param>
    ''' <returns>Formatted JSON string with proper commas</returns>
    Private Function FormatJsonArrays(jsonContent As String, padNumbers As Boolean) As String
        Dim lines As String() = jsonContent.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        Dim result As New List(Of String)

        Dim inTilesSection As Boolean = False
        Dim inArrayRow As Boolean = False
        Dim currentRow As String = ""

        For i As Integer = 0 To lines.Length - 1
            Dim line As String = lines(i).TrimEnd()

            ' Check if we're entering the tiles section
            If line.Contains("""tiles""") Then
                inTilesSection = True
                result.Add(line)
                Continue For
            End If

            ' Check if we're at the end of the tiles section
            If inTilesSection AndAlso line = "}" Then
                inTilesSection = False
                result.Add(line)
                Continue For
            End If

            ' Handle lines within the tiles section
            If inTilesSection Then
                ' Start of an array row
                If line.TrimStart().StartsWith("[") AndAlso Not line.TrimEnd().EndsWith("]") Then
                    inArrayRow = True
                    currentRow = line.TrimEnd()

                    ' End of an array row
                ElseIf inArrayRow AndAlso (line.TrimEnd().EndsWith("],") OrElse line.TrimEnd().EndsWith("]")) Then
                    currentRow += " " + line.Trim()

                    ' Apply padding if requested
                    If padNumbers Then
                        currentRow = PadNumbersInRow(currentRow)
                    End If

                    result.Add(currentRow)
                    inArrayRow = False
                    currentRow = ""

                    ' Middle of an array row
                ElseIf inArrayRow Then
                    currentRow += " " + line.Trim()

                    ' Regular line in the tiles section (not part of an array row)
                Else
                    result.Add(line)
                End If

                ' Lines outside the tiles section
            Else
                result.Add(line)
            End If
        Next

        Return String.Join(Environment.NewLine, result)
    End Function

    ''' <summary>
    ''' Pads numbers in a JSON array row for alignment while ensuring commas are preserved
    ''' </summary>
    ''' <param name="rowLine">The row line to pad</param>
    ''' <returns>A string with properly padded numbers and commas</returns>
    Private Function PadNumbersInRow(rowLine As String) As String
        ' Extract the beginning bracket part
        Dim startBracketIndex As Integer = rowLine.IndexOf("[")
        Dim prefix As String = rowLine.Substring(0, startBracketIndex + 1)

        ' Extract the end bracket part
        Dim endBracketIndex As Integer = rowLine.LastIndexOf("]")
        Dim suffix As String = rowLine.Substring(endBracketIndex)

        ' Extract the content between brackets
        Dim content As String = rowLine.Substring(startBracketIndex + 1, endBracketIndex - startBracketIndex - 1).Trim()

        ' Split by commas to get individual numbers
        Dim numberParts As String() = content.Split(","c)

        ' Trim and collect all numbers
        Dim trimmedNumbers As New List(Of String)
        For Each part As String In numberParts
            trimmedNumbers.Add(part.Trim())
        Next

        ' Find the maximum width needed for padding
        Dim maxWidth As Integer = 4 ' Default minimum width
        For Each numStr As String In trimmedNumbers
            If numStr.Length > maxWidth Then
                maxWidth = numStr.Length
            End If
        Next

        ' Pad each number to the maximum width
        Dim paddedNumbers As New List(Of String)
        For Each numStr As String In trimmedNumbers
            paddedNumbers.Add(numStr.PadLeft(maxWidth))
        Next

        ' Reconstruct the row with padded numbers and proper commas
        Return prefix & " " & String.Join(", ", paddedNumbers) & " " & suffix
    End Function

#End Region

#Region "Tile Groups"

    ''' <summary>
    ''' Checks if the map has corrupted tile group names by examining only the first tile group
    ''' </summary>
    ''' <returns>True if corruption is detected, False if names appear valid</returns>
    Private Function HasCorruptTileGroupNames() As Boolean
        ' Make sure we have at least one tile group
        If currentMap Is Nothing OrElse currentMap.tileGroups Is Nothing OrElse currentMap.tileGroups.Count = 0 Then
            Return False
        End If

        ' Get the first tile group
        Dim group As TileGroup = currentMap.tileGroups(0)

        ' Check if name is null or empty
        If group Is Nothing OrElse String.IsNullOrEmpty(group.name) Then
            Return False
        End If

        ' Check for control characters (most common corruption)
        For i As Integer = 0 To group.name.Length - 1
            Dim c As Char = group.name(i)

            ' If we find ANY control characters, the name is corrupt
            If AscW(c) < 32 Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Displays information about a tile group on the console
    ''' </summary>
    ''' <param name="groupName">Name of the tile group to display</param>
    Public Sub ShowTileGroupInfo(groupName As String)
        Dim groupIndex As Integer = FindTileGroup(currentMap, groupName)

        If groupIndex >= 0 Then
            AppendToConsole(GetTileGroupInfo(currentMap, groupIndex))
        Else
            AppendToConsole("Tile group '" & groupName & "' not found in the current map.")
        End If
    End Sub

    ''' <summary>
    ''' Finds a tile group by name (case insensitive)
    ''' </summary>
    ''' <param name="map">The map containing the tile groups</param>
    ''' <param name="groupName">Name of the tile group to find</param>
    ''' <returns>Index of the found group, or -1 if not found</returns>
    Private Function FindTileGroup(map As Map, groupName As String) As Integer
        For i As Integer = 0 To map.tileGroups.Count - 1
            If String.Compare(map.tileGroups(i).name, groupName, True) = 0 Then
                Return i
            End If
        Next

        Return -1
    End Function

    ''' <summary>
    ''' Gets detailed information about a specific tile group by index
    ''' </summary>
    ''' <param name="map">The map containing the tile groups</param>
    ''' <param name="groupIndex">Zero-based index of the tile group</param>
    ''' <returns>Formatted string with tile group details</returns>
    Private Function GetTileGroupInfo(map As Map, groupIndex As Integer) As String
        If groupIndex >= map.tileGroups.Count Then
            Return "Error: Tile group index out of range"
        End If

        Dim result As New System.Text.StringBuilder()
        Dim group As TileGroup = map.tileGroups(groupIndex)

        result.AppendLine("Detailed information for tile group " & groupIndex & " (" & group.name & "):")
        result.AppendLine("  Name: " & group.name)
        result.AppendLine("  Dimensions: " & group.tileWidth & " x " & group.tileHeight & " tiles")
        result.AppendLine("  Total tiles in group: " & group.mappingIndices.Count)

        ' Display all mapping indices
        result.AppendLine("  Tile mapping indices:")
        Dim indicesText As New System.Text.StringBuilder()
        For i As Integer = 0 To group.mappingIndices.Count - 1
            indicesText.Append(group.mappingIndices(i))

            ' Add comma if not the last item
            If i < group.mappingIndices.Count - 1 Then
                indicesText.Append(", ")
            End If

            ' Add line breaks periodically
            If (i + 1) Mod 10 = 0 AndAlso i < group.mappingIndices.Count - 1 Then
                indicesText.Append(vbCrLf & "    ")
            End If
        Next
        result.AppendLine("    " & indicesText.ToString())

        '' Try to get information about each tile in the group
        'If map.tileMappings.Count > 0 Then
        '    result.AppendLine(vbCrLf & "  Tile details:")
        '    For i As Integer = 0 To group.mappingIndices.Count - 1 ' Show all tiles, not just the first 10
        '        Dim index As UInteger = group.mappingIndices(i)
        '        If index < map.tileMappings.Count Then
        '            Dim mapping As TileMapping = map.tileMappings(index)
        '            result.AppendLine(String.Format("    Tile {0}: Tileset {1}, Graphic {2}, Animation count {3}, Animation delay {4}",
        '                                i, mapping.tilesetIndex, mapping.tileGraphicIndex, mapping.animationCount, mapping.animationDelay))
        '        End If
        '    Next

        'End If

        Return result.ToString()
    End Function

#End Region

#Region "Map Creation"

    ''' <summary>
    ''' Imports a single tile group from a JSON file
    ''' </summary>
    ''' <param name="jsonFilePath">Path to the JSON file containing the tile group</param>
    Private Sub ImportSingleTileGroup(jsonFilePath As String)
        ' Load a single tile group
        Try
            ' Reset global variables
            currentTileGroupData = Nothing
            TileGroupTiles = Nothing
            TileGroupWidth = 0
            TileGroupHeight = 0

            ' Read JSON file
            Dim jsonText As String = File.ReadAllText(jsonFilePath)
            Dim fileName As String = Path.GetFileNameWithoutExtension(jsonFilePath)

            ' Parse JSON
            currentTileGroupData = JObject.Parse(jsonText)

            ' Extract header information
            If currentTileGroupData.ContainsKey("header") Then
                Dim header = currentTileGroupData("header")
                TileGroupWidth = header("width").Value(Of Integer)()
                TileGroupHeight = header("height").Value(Of Integer)()
            Else
                AppendToConsole($"  Error: No header found in tile group JSON: {fileName}")
                Return
            End If

            ' Store the tiles data
            If currentTileGroupData.ContainsKey("tiles") Then
                Dim tilesData = currentTileGroupData("tiles")

                ' Check if tiles is an array of arrays (perRow format)
                If tilesData.Type = JTokenType.Array AndAlso
               tilesData.Count > 0 AndAlso
               tilesData(0).Type = JTokenType.Array Then

                    ' It's in perRow format
                    TileGroupTiles = DirectCast(tilesData, JArray)

                    ' Verify dimensions from the actual data
                    If TileGroupHeight <> tilesData.Count Then
                        TileGroupHeight = tilesData.Count
                    End If

                    If TileGroupWidth <> tilesData(0).Count Then
                        TileGroupWidth = tilesData(0).Count
                    End If
                Else
                    AppendToConsole($"  Error: JSON file '{fileName}' is not in the expected per-row format")
                    Return
                End If
            Else
                AppendToConsole($"  Error: No tiles found in JSON: {fileName}")
                Return
            End If
        Catch ex As Exception
            AppendToConsole("  Error importing tile group: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds a tile group to the current map at the specified coordinates
    ''' </summary>
    ''' <param name="startX">X coordinate to place the tile group</param>
    ''' <param name="startY">Y coordinate to place the tile group</param>
    ''' <param name="groupName">Name of the tile group being added</param>
    Private Sub AddTileGroupToMap(startX As Integer, startY As Integer, groupName As String)
        ' Add the tile group data onto our currentMap

        Try
            ' Check if we have valid tile group data
            If TileGroupTiles Is Nothing OrElse TileGroupWidth = 0 OrElse TileGroupHeight = 0 Then
                AppendToConsole($"  Error: No valid tile group data for '{groupName}'")
                Return
            End If

            ' Place the tile group onto the map
            For y As Integer = 0 To TileGroupHeight - 1
                Dim row As JArray = TileGroupTiles(y)
                For x As Integer = 0 To TileGroupWidth - 1
                    Dim tileIndex As Integer = row(x).Value(Of Integer)()

                    ' Calculate the position on the map
                    Dim mapX As Integer = startX + x
                    Dim mapY As Integer = startY + y

                    ' Check if position is within map bounds
                    If mapX >= 0 AndAlso mapX < currentMap.WidthInTiles() AndAlso
                   mapY >= 0 AndAlso mapY < currentMap.HeightInTiles() Then
                        ' Set the tile on the map
                        currentMap.SetTileMappingIndex(mapX, mapY, tileIndex)

                    End If
                Next
            Next
            'AppendToConsole($"  Added tile group '{groupName}' at position ({startX}, {startY})")

        Catch ex As Exception
            AppendToConsole($"  Error adding tile group '{groupName}' to map: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Creates a map file containing all tile groups found in the tile group folder
    ''' </summary>
    ''' <param name="outputFileName">Name of the output map file</param>
    Private Sub CreateTileGroupMapFile(outputFileName As String)
        Dim blankMapPath As String = Path.Combine(BlankMapsPath, blankMapFileName)

        'List of blank maps (and Outpost 2 map sizes):
        'blank_64x64.map
        'blank_64x128.map
        'blank_64x256.map
        'blank_128x64.map
        'blank_128x128.map
        'blank_128x256.map
        'blank_256x128.map
        'blank_256x256.map
        'blank_512x256.map

        ' Find all JSON files in the tile group folder
        Dim jsonFiles As String() = Directory.GetFiles(My.Settings.tileGroupFolder, "*.json")
        'AppendToConsole($"Finding tile group files in: {tileGroupFolder}")

        ' If no tile groups found then dont create a map file
        If jsonFiles.Length = 0 Then
            AppendToConsole("")
            AppendToConsole("There are no JSON tile groups in the folder: " & My.Settings.tileGroupFolder)
            Debug.Write("No tile groups in the folder: " & My.Settings.tileGroupFolder)

        Else
            ' Load the blank map using the OpenMapFile function
            'AppendToConsole("CreateTileSetMapFile - Loading blank map: " & blankMapPath)
            OpenMapFile(blankMapPath, False)

            ' Check if map loaded successfully
            If currentMap Is Nothing Then
                AppendToConsole("Failed to load blank map.")
                MessageBox.Show("Failed to load blank map.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            AppendToConsole("")
            AppendToConsole($"Found {jsonFiles.Length} tile group JSON files.")

            ' Calculate placement positions
            Dim currentX As Integer = 2 ' Start with a 2-tile margin
            Dim currentY As Integer = 2
            Dim maxHeightInRow As Integer = 0
            Dim tilesPlaced As Integer = 0

            ' Process each JSON tile group file
            For Each jsonFile As String In jsonFiles
                ' Get the file name without extension to use as tile group name
                Dim fileName As String = Path.GetFileNameWithoutExtension(jsonFile)
                'AppendToConsole($"Processing tile group: {fileName}")

                ' Import the tile group from the JSON file
                ImportSingleTileGroup(jsonFile)

                ' Check if tile group data was loaded successfully
                If TileGroupTiles IsNot Nothing Then
                    ' Add the tile group to the map
                    AddTileGroupToMap(currentX, currentY, fileName)

                    ' Update position for next tile group with reduced spacing
                    currentX += TileGroupWidth + 1 ' 1-tile spacing between groups

                    ' Keep track of the maximum height in the current row
                    If TileGroupHeight > maxHeightInRow Then
                        maxHeightInRow = TileGroupHeight
                    End If

                    ' Move to the next row if we're too close to the right edge
                    If currentX + 10 >= currentMap.WidthInTiles() Then
                        currentX = 1
                        currentY += maxHeightInRow + 1 ' 1-tile spacing between rows
                        maxHeightInRow = 0
                    End If

                    tilesPlaced += 1
                End If
            Next

            ' Set all cell types to a MediumPassible1
            For y As Integer = 0 To mapHeight - 1
                For x As Integer = 0 To mapWidth - 1
                    currentMap.SetCellType(CellType.MediumPassible1, x, y)
                Next
            Next

            ' Add a single tile group as metadata of how many tile groups the map contains
            currentMap.tileGroups.Clear()
            Dim tileGroup As New TileGroup()
            tileGroup.name = tilesPlaced.ToString & "_tile_groups"
            tileGroup.tileWidth = 1
            tileGroup.tileHeight = 1
            ' Add the tile mapping index 0 to the group
            tileGroup.mappingIndices.Add(0)
            ' Add the tile group to the map
            currentMap.tileGroups.Add(tileGroup)

            ' Save the map to disk
            Dim outputFilePath As String = Path.Combine(My.Settings.tileGroupFolder, outputFileName)

            'AppendToConsole($"Saving map with {tilesPlaced} tile groups to: {outputFilePath}")
            currentMap.Write(outputFilePath)

            '' ADD CODE TO EXPORT THE .MAP TO .JSON (VIA ANOTHER APP - OP2JsonMap) ''

            AppendToConsole("")
            AppendToConsole($"Successfully placed {tilesPlaced} tile groups on the map.")
            AppendToConsole("")
            AppendToConsole($"Map saved to: {outputFilePath}")
            Debug.WriteLine("Generated tile group map: " & outputFilePath)

            ' After we have exported the tile groups map we need to clear / reset the currently loaded map
            currentMap = Nothing
            btnExportTileGroups.Enabled = False

            MessageBox.Show($"Successfully created map with {tilesPlaced} tile groups.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadMapViewer(outputFilePath)
        End If
    End Sub

    ''' <summary>
    ''' Launches OP2MapViewer with the specified map file
    ''' </summary>
    ''' <param name="GenerateMapFiletPath">Path to the map file to open in the viewer</param>
    Private Sub LoadMapViewer(GenerateMapFiletPath As String)
        AppendToConsole(vbNewLine & "Loading OP2MapViewer: " & GenerateMapFiletPath)
        Debug.WriteLine("Loading OP2MapViewer: " & GenerateMapFiletPath)

        Try
            ' Load the viewer
            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = My.Settings.MapViewerPath  ' Path to the viewer
            startInfo.Arguments = GenerateMapFiletPath      ' Command-line arguments

            ' Start the process
            Process.Start(startInfo)
        Catch ex As Exception
            Debug.WriteLine(" -- Error loading map viewer: " & ex.Message)

        End Try
    End Sub

#End Region

End Class