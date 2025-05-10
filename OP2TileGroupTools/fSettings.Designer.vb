<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBoxPaths = New System.Windows.Forms.GroupBox()
        Me.btnBrowseTileGroupFolder = New System.Windows.Forms.Button()
        Me.txtTileGroupFolder = New System.Windows.Forms.TextBox()
        Me.lblTileGroupFolder = New System.Windows.Forms.Label()
        Me.btnBrowseOP2Path = New System.Windows.Forms.Button()
        Me.txtOP2Path = New System.Windows.Forms.TextBox()
        Me.lblOP2Path = New System.Windows.Forms.Label()
        Me.btnBrowseJsonMapViewer = New System.Windows.Forms.Button()
        Me.txtJsonMapViewerPath = New System.Windows.Forms.TextBox()
        Me.lblJsonMapViewerPath = New System.Windows.Forms.Label()
        Me.btnBrowseMapViewer = New System.Windows.Forms.Button()
        Me.txtMapViewerPath = New System.Windows.Forms.TextBox()
        Me.lblMapViewerPath = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblBuild = New System.Windows.Forms.Label()
        Me.panelBanner = New System.Windows.Forms.Panel()
        Me.GroupBoxPaths.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxPaths
        '
        Me.GroupBoxPaths.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxPaths.Controls.Add(Me.btnBrowseTileGroupFolder)
        Me.GroupBoxPaths.Controls.Add(Me.txtTileGroupFolder)
        Me.GroupBoxPaths.Controls.Add(Me.lblTileGroupFolder)
        Me.GroupBoxPaths.Controls.Add(Me.btnBrowseOP2Path)
        Me.GroupBoxPaths.Controls.Add(Me.txtOP2Path)
        Me.GroupBoxPaths.Controls.Add(Me.lblOP2Path)
        Me.GroupBoxPaths.Controls.Add(Me.btnBrowseJsonMapViewer)
        Me.GroupBoxPaths.Controls.Add(Me.txtJsonMapViewerPath)
        Me.GroupBoxPaths.Controls.Add(Me.lblJsonMapViewerPath)
        Me.GroupBoxPaths.Controls.Add(Me.btnBrowseMapViewer)
        Me.GroupBoxPaths.Controls.Add(Me.txtMapViewerPath)
        Me.GroupBoxPaths.Controls.Add(Me.lblMapViewerPath)
        Me.GroupBoxPaths.Location = New System.Drawing.Point(20, 140)
        Me.GroupBoxPaths.Name = "GroupBoxPaths"
        Me.GroupBoxPaths.Size = New System.Drawing.Size(620, 290)
        Me.GroupBoxPaths.TabIndex = 0
        Me.GroupBoxPaths.TabStop = False
        Me.GroupBoxPaths.Text = "Paths"
        '
        'btnBrowseTileGroupFolder
        '
        Me.btnBrowseTileGroupFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseTileGroupFolder.Location = New System.Drawing.Point(525, 236)
        Me.btnBrowseTileGroupFolder.Name = "btnBrowseTileGroupFolder"
        Me.btnBrowseTileGroupFolder.Size = New System.Drawing.Size(80, 26)
        Me.btnBrowseTileGroupFolder.TabIndex = 11
        Me.btnBrowseTileGroupFolder.Text = "Browse..."
        Me.btnBrowseTileGroupFolder.UseVisualStyleBackColor = True
        '
        'txtTileGroupFolder
        '
        Me.txtTileGroupFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTileGroupFolder.Location = New System.Drawing.Point(15, 237)
        Me.txtTileGroupFolder.Name = "txtTileGroupFolder"
        Me.txtTileGroupFolder.Size = New System.Drawing.Size(504, 22)
        Me.txtTileGroupFolder.TabIndex = 10
        '
        'lblTileGroupFolder
        '
        Me.lblTileGroupFolder.AutoSize = True
        Me.lblTileGroupFolder.Location = New System.Drawing.Point(15, 217)
        Me.lblTileGroupFolder.Name = "lblTileGroupFolder"
        Me.lblTileGroupFolder.Size = New System.Drawing.Size(153, 13)
        Me.lblTileGroupFolder.TabIndex = 9
        Me.lblTileGroupFolder.Text = "Tile Group Exports Directory:"
        '
        'btnBrowseOP2Path
        '
        Me.btnBrowseOP2Path.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseOP2Path.Location = New System.Drawing.Point(525, 174)
        Me.btnBrowseOP2Path.Name = "btnBrowseOP2Path"
        Me.btnBrowseOP2Path.Size = New System.Drawing.Size(80, 26)
        Me.btnBrowseOP2Path.TabIndex = 8
        Me.btnBrowseOP2Path.Text = "Browse..."
        Me.btnBrowseOP2Path.UseVisualStyleBackColor = True
        '
        'txtOP2Path
        '
        Me.txtOP2Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOP2Path.Location = New System.Drawing.Point(15, 175)
        Me.txtOP2Path.Name = "txtOP2Path"
        Me.txtOP2Path.Size = New System.Drawing.Size(504, 22)
        Me.txtOP2Path.TabIndex = 7
        '
        'lblOP2Path
        '
        Me.lblOP2Path.AutoSize = True
        Me.lblOP2Path.Location = New System.Drawing.Point(15, 155)
        Me.lblOP2Path.Name = "lblOP2Path"
        Me.lblOP2Path.Size = New System.Drawing.Size(176, 13)
        Me.lblOP2Path.TabIndex = 6
        Me.lblOP2Path.Text = "Outpost 2 Game Directory (1.4.1):"
        '
        'btnBrowseJsonMapViewer
        '
        Me.btnBrowseJsonMapViewer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseJsonMapViewer.Location = New System.Drawing.Point(525, 112)
        Me.btnBrowseJsonMapViewer.Name = "btnBrowseJsonMapViewer"
        Me.btnBrowseJsonMapViewer.Size = New System.Drawing.Size(80, 26)
        Me.btnBrowseJsonMapViewer.TabIndex = 5
        Me.btnBrowseJsonMapViewer.Text = "Browse..."
        Me.btnBrowseJsonMapViewer.UseVisualStyleBackColor = True
        '
        'txtJsonMapViewerPath
        '
        Me.txtJsonMapViewerPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJsonMapViewerPath.Location = New System.Drawing.Point(15, 113)
        Me.txtJsonMapViewerPath.Name = "txtJsonMapViewerPath"
        Me.txtJsonMapViewerPath.Size = New System.Drawing.Size(504, 22)
        Me.txtJsonMapViewerPath.TabIndex = 4
        '
        'lblJsonMapViewerPath
        '
        Me.lblJsonMapViewerPath.AutoSize = True
        Me.lblJsonMapViewerPath.Location = New System.Drawing.Point(15, 93)
        Me.lblJsonMapViewerPath.Name = "lblJsonMapViewerPath"
        Me.lblJsonMapViewerPath.Size = New System.Drawing.Size(127, 13)
        Me.lblJsonMapViewerPath.TabIndex = 3
        Me.lblJsonMapViewerPath.Text = "JSON Map Viewer Path:"
        '
        'btnBrowseMapViewer
        '
        Me.btnBrowseMapViewer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseMapViewer.Location = New System.Drawing.Point(525, 50)
        Me.btnBrowseMapViewer.Name = "btnBrowseMapViewer"
        Me.btnBrowseMapViewer.Size = New System.Drawing.Size(80, 26)
        Me.btnBrowseMapViewer.TabIndex = 2
        Me.btnBrowseMapViewer.Text = "Browse..."
        Me.btnBrowseMapViewer.UseVisualStyleBackColor = True
        '
        'txtMapViewerPath
        '
        Me.txtMapViewerPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMapViewerPath.Location = New System.Drawing.Point(15, 51)
        Me.txtMapViewerPath.Name = "txtMapViewerPath"
        Me.txtMapViewerPath.Size = New System.Drawing.Size(504, 22)
        Me.txtMapViewerPath.TabIndex = 1
        '
        'lblMapViewerPath
        '
        Me.lblMapViewerPath.AutoSize = True
        Me.lblMapViewerPath.Location = New System.Drawing.Point(15, 31)
        Me.lblMapViewerPath.Name = "lblMapViewerPath"
        Me.lblMapViewerPath.Size = New System.Drawing.Size(97, 13)
        Me.lblMapViewerPath.TabIndex = 0
        Me.lblMapViewerPath.Text = "Map Viewer Path:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(470, 445)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 30)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(560, 445)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.Location = New System.Drawing.Point(17, 454)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(45, 13)
        Me.lblBuild.TabIndex = 3
        Me.lblBuild.Text = "Version"
        '
        'panelBanner
        '
        Me.panelBanner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelBanner.BackColor = System.Drawing.Color.SteelBlue
        Me.panelBanner.Location = New System.Drawing.Point(20, 20)
        Me.panelBanner.Name = "panelBanner"
        Me.panelBanner.Size = New System.Drawing.Size(620, 100)
        Me.panelBanner.TabIndex = 4
        '
        'fSettings
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(664, 495)
        Me.Controls.Add(Me.panelBanner)
        Me.Controls.Add(Me.lblBuild)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBoxPaths)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OP2TileGroupTools Settings"
        Me.GroupBoxPaths.ResumeLayout(False)
        Me.GroupBoxPaths.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBoxPaths As GroupBox
    Friend WithEvents btnBrowseMapViewer As Button
    Friend WithEvents txtMapViewerPath As TextBox
    Friend WithEvents lblMapViewerPath As Label
    Friend WithEvents btnBrowseJsonMapViewer As Button
    Friend WithEvents txtJsonMapViewerPath As TextBox
    Friend WithEvents lblJsonMapViewerPath As Label
    Friend WithEvents btnBrowseOP2Path As Button
    Friend WithEvents txtOP2Path As TextBox
    Friend WithEvents lblOP2Path As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblBuild As Label
    Friend WithEvents panelBanner As Panel
    Friend WithEvents btnBrowseTileGroupFolder As Button
    Friend WithEvents txtTileGroupFolder As TextBox
    Friend WithEvents lblTileGroupFolder As Label
End Class