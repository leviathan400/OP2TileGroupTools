<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.btnOpenMap = New System.Windows.Forms.Button()
        Me.btnExportTileGroups = New System.Windows.Forms.Button()
        Me.btnCreateMap = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtConsole
        '
        Me.txtConsole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConsole.BackColor = System.Drawing.Color.White
        Me.txtConsole.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsole.Location = New System.Drawing.Point(12, 54)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ReadOnly = True
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConsole.Size = New System.Drawing.Size(740, 539)
        Me.txtConsole.TabIndex = 5
        Me.txtConsole.WordWrap = False
        '
        'btnOpenMap
        '
        Me.btnOpenMap.Location = New System.Drawing.Point(12, 12)
        Me.btnOpenMap.Name = "btnOpenMap"
        Me.btnOpenMap.Size = New System.Drawing.Size(121, 32)
        Me.btnOpenMap.TabIndex = 1
        Me.btnOpenMap.Text = "Open Map File"
        Me.btnOpenMap.UseVisualStyleBackColor = True
        '
        'btnExportTileGroups
        '
        Me.btnExportTileGroups.Location = New System.Drawing.Point(139, 12)
        Me.btnExportTileGroups.Name = "btnExportTileGroups"
        Me.btnExportTileGroups.Size = New System.Drawing.Size(121, 32)
        Me.btnExportTileGroups.TabIndex = 2
        Me.btnExportTileGroups.Text = "Export Tile Groups"
        Me.btnExportTileGroups.UseVisualStyleBackColor = True
        '
        'btnCreateMap
        '
        Me.btnCreateMap.Location = New System.Drawing.Point(324, 12)
        Me.btnCreateMap.Name = "btnCreateMap"
        Me.btnCreateMap.Size = New System.Drawing.Size(121, 32)
        Me.btnCreateMap.TabIndex = 3
        Me.btnCreateMap.Text = "CreateTile Group Map"
        Me.btnCreateMap.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(653, 12)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(99, 32)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'fMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 605)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnCreateMap)
        Me.Controls.Add(Me.btnExportTileGroups)
        Me.Controls.Add(Me.btnOpenMap)
        Me.Controls.Add(Me.txtConsole)
        Me.MaximizeBox = False
        Me.Name = "fMain"
        Me.Text = "Outpost 2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtConsole As TextBox
    Friend WithEvents btnOpenMap As Button
    Friend WithEvents btnExportTileGroups As Button
    Friend WithEvents btnCreateMap As Button
    Friend WithEvents btnSettings As Button
End Class
