<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFCoordinate = New System.Windows.Forms.Label()
        Me.lblC = New System.Windows.Forms.Label()
        Me.lblLCoordinate = New System.Windows.Forms.Label()
        Me.lblR = New System.Windows.Forms.Label()
        Me.txtFLat = New System.Windows.Forms.TextBox()
        Me.txtFlon = New System.Windows.Forms.TextBox()
        Me.txtC = New System.Windows.Forms.TextBox()
        Me.txtR = New System.Windows.Forms.TextBox()
        Me.txtN = New System.Windows.Forms.TextBox()
        Me.txtDLat = New System.Windows.Forms.TextBox()
        Me.txtLastLat = New System.Windows.Forms.TextBox()
        Me.txtLastLon = New System.Windows.Forms.TextBox()
        Me.txtDLon = New System.Windows.Forms.TextBox()
        Me.lblNIteration = New System.Windows.Forms.Label()
        Me.lblDelta = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.txtErrorMean = New System.Windows.Forms.TextBox()
        Me.txtErrorSigma = New System.Windows.Forms.TextBox()
        Me.txtCalcMode = New System.Windows.Forms.TextBox()
        Me.lblCalcMode = New System.Windows.Forms.Label()
        Me.startButton = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblRemainingTime = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Setting = New System.Windows.Forms.TabPage()
        Me.Result = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Latitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Longitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accuracy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCalcModeHint = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Setting.SuspendLayout()
        Me.Result.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoScrollMargin = New System.Drawing.Size(0, 500)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 319)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblFCoordinate, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblC, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLCoordinate, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblR, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txtFLat, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtFlon, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtC, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtR, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txtN, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDLat, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtLastLat, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtLastLon, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDLon, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNIteration, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDelta, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblError, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtErrorMean, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtErrorSigma, 2, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCalcMode, 1, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCalcMode, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 2, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCalcModeHint, 2, 11)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 12
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(311, 319)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'lblFCoordinate
        '
        Me.lblFCoordinate.AutoSize = True
        Me.lblFCoordinate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFCoordinate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCoordinate.Location = New System.Drawing.Point(3, 20)
        Me.lblFCoordinate.Name = "lblFCoordinate"
        Me.lblFCoordinate.Size = New System.Drawing.Size(158, 30)
        Me.lblFCoordinate.TabIndex = 0
        Me.lblFCoordinate.Text = "First Coordinate"
        Me.lblFCoordinate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblC
        '
        Me.lblC.AutoSize = True
        Me.lblC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblC.Location = New System.Drawing.Point(3, 160)
        Me.lblC.Name = "lblC"
        Me.lblC.Size = New System.Drawing.Size(158, 30)
        Me.lblC.TabIndex = 4
        Me.lblC.Text = "Speed of Light"
        Me.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLCoordinate
        '
        Me.lblLCoordinate.AutoSize = True
        Me.lblLCoordinate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLCoordinate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLCoordinate.Location = New System.Drawing.Point(3, 50)
        Me.lblLCoordinate.Name = "lblLCoordinate"
        Me.lblLCoordinate.Size = New System.Drawing.Size(158, 30)
        Me.lblLCoordinate.TabIndex = 1
        Me.lblLCoordinate.Text = "Last Coordinate"
        Me.lblLCoordinate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblR
        '
        Me.lblR.AutoSize = True
        Me.lblR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblR.Location = New System.Drawing.Point(3, 190)
        Me.lblR.Name = "lblR"
        Me.lblR.Size = New System.Drawing.Size(158, 30)
        Me.lblR.TabIndex = 5
        Me.lblR.Text = "Earth Radius"
        Me.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFLat
        '
        Me.txtFLat.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtFLat.Location = New System.Drawing.Point(167, 23)
        Me.txtFLat.Name = "txtFLat"
        Me.txtFLat.Size = New System.Drawing.Size(67, 20)
        Me.txtFLat.TabIndex = 6
        '
        'txtFlon
        '
        Me.txtFlon.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtFlon.Location = New System.Drawing.Point(240, 23)
        Me.txtFlon.Name = "txtFlon"
        Me.txtFlon.Size = New System.Drawing.Size(67, 20)
        Me.txtFlon.TabIndex = 7
        '
        'txtC
        '
        Me.txtC.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtC.Location = New System.Drawing.Point(167, 163)
        Me.txtC.Name = "txtC"
        Me.txtC.Size = New System.Drawing.Size(67, 20)
        Me.txtC.TabIndex = 9
        '
        'txtR
        '
        Me.txtR.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtR.Location = New System.Drawing.Point(167, 193)
        Me.txtR.Name = "txtR"
        Me.txtR.Size = New System.Drawing.Size(67, 20)
        Me.txtR.TabIndex = 8
        '
        'txtN
        '
        Me.txtN.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtN.Location = New System.Drawing.Point(167, 133)
        Me.txtN.Name = "txtN"
        Me.txtN.Size = New System.Drawing.Size(67, 20)
        Me.txtN.TabIndex = 10
        '
        'txtDLat
        '
        Me.txtDLat.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtDLat.Location = New System.Drawing.Point(167, 83)
        Me.txtDLat.Name = "txtDLat"
        Me.txtDLat.Size = New System.Drawing.Size(67, 20)
        Me.txtDLat.TabIndex = 12
        '
        'txtLastLat
        '
        Me.txtLastLat.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtLastLat.Location = New System.Drawing.Point(167, 53)
        Me.txtLastLat.Name = "txtLastLat"
        Me.txtLastLat.Size = New System.Drawing.Size(67, 20)
        Me.txtLastLat.TabIndex = 14
        '
        'txtLastLon
        '
        Me.txtLastLon.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtLastLon.Location = New System.Drawing.Point(240, 53)
        Me.txtLastLon.Name = "txtLastLon"
        Me.txtLastLon.Size = New System.Drawing.Size(67, 20)
        Me.txtLastLon.TabIndex = 15
        '
        'txtDLon
        '
        Me.txtDLon.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtDLon.Location = New System.Drawing.Point(240, 83)
        Me.txtDLon.Name = "txtDLon"
        Me.txtDLon.Size = New System.Drawing.Size(67, 20)
        Me.txtDLon.TabIndex = 11
        '
        'lblNIteration
        '
        Me.lblNIteration.AutoSize = True
        Me.lblNIteration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNIteration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNIteration.Location = New System.Drawing.Point(3, 130)
        Me.lblNIteration.Name = "lblNIteration"
        Me.lblNIteration.Size = New System.Drawing.Size(158, 30)
        Me.lblNIteration.TabIndex = 2
        Me.lblNIteration.Text = "N of Iteration"
        Me.lblNIteration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDelta
        '
        Me.lblDelta.AutoSize = True
        Me.lblDelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDelta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelta.Location = New System.Drawing.Point(3, 80)
        Me.lblDelta.Name = "lblDelta"
        Me.lblDelta.Size = New System.Drawing.Size(158, 30)
        Me.lblDelta.TabIndex = 3
        Me.lblDelta.Text = "Distance between Point"
        Me.lblDelta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.Location = New System.Drawing.Point(3, 240)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(158, 30)
        Me.lblError.TabIndex = 16
        Me.lblError.Text = "Time of Arrival Error"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtErrorMean
        '
        Me.txtErrorMean.Location = New System.Drawing.Point(167, 243)
        Me.txtErrorMean.Name = "txtErrorMean"
        Me.txtErrorMean.Size = New System.Drawing.Size(67, 20)
        Me.txtErrorMean.TabIndex = 17
        '
        'txtErrorSigma
        '
        Me.txtErrorSigma.Location = New System.Drawing.Point(240, 243)
        Me.txtErrorSigma.Name = "txtErrorSigma"
        Me.txtErrorSigma.Size = New System.Drawing.Size(67, 20)
        Me.txtErrorSigma.TabIndex = 18
        '
        'txtCalcMode
        '
        Me.txtCalcMode.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCalcMode.Location = New System.Drawing.Point(167, 293)
        Me.txtCalcMode.Name = "txtCalcMode"
        Me.txtCalcMode.Size = New System.Drawing.Size(67, 20)
        Me.txtCalcMode.TabIndex = 19
        '
        'lblCalcMode
        '
        Me.lblCalcMode.AutoSize = True
        Me.lblCalcMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCalcMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalcMode.Location = New System.Drawing.Point(3, 290)
        Me.lblCalcMode.Name = "lblCalcMode"
        Me.lblCalcMode.Size = New System.Drawing.Size(158, 29)
        Me.lblCalcMode.TabIndex = 20
        Me.lblCalcMode.Text = "Method"
        Me.lblCalcMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'startButton
        '
        Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startButton.Location = New System.Drawing.Point(448, 354)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(75, 23)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 325)
        Me.ProgressBar1.MarqueeAnimationSpeed = 1000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(519, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.BackColor = System.Drawing.SystemColors.Control
        Me.lblProgress.Location = New System.Drawing.Point(149, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(140, 23)
        Me.lblProgress.TabIndex = 3
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Location = New System.Drawing.Point(3, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(140, 23)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemainingTime
        '
        Me.lblRemainingTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemainingTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRemainingTime.Location = New System.Drawing.Point(295, 0)
        Me.lblRemainingTime.Name = "lblRemainingTime"
        Me.lblRemainingTime.Size = New System.Drawing.Size(140, 23)
        Me.lblRemainingTime.TabIndex = 5
        Me.lblRemainingTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblRemainingTime, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProgress, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 354)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(438, 23)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.Setting)
        Me.TabControl1.Controls.Add(Me.Result)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(534, 409)
        Me.TabControl1.TabIndex = 7
        '
        'Setting
        '
        Me.Setting.Controls.Add(Me.Panel1)
        Me.Setting.Controls.Add(Me.TableLayoutPanel1)
        Me.Setting.Controls.Add(Me.ProgressBar1)
        Me.Setting.Controls.Add(Me.startButton)
        Me.Setting.Location = New System.Drawing.Point(4, 22)
        Me.Setting.Name = "Setting"
        Me.Setting.Padding = New System.Windows.Forms.Padding(3)
        Me.Setting.Size = New System.Drawing.Size(526, 383)
        Me.Setting.TabIndex = 0
        Me.Setting.Text = "Setting"
        Me.Setting.UseVisualStyleBackColor = True
        '
        'Result
        '
        Me.Result.Controls.Add(Me.DataGridView1)
        Me.Result.Location = New System.Drawing.Point(4, 22)
        Me.Result.Name = "Result"
        Me.Result.Padding = New System.Windows.Forms.Padding(3)
        Me.Result.Size = New System.Drawing.Size(526, 303)
        Me.Result.TabIndex = 1
        Me.Result.Text = "Result"
        Me.Result.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Latitude, Me.Longitude, Me.Accuracy})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(520, 297)
        Me.DataGridView1.TabIndex = 1
        '
        'id
        '
        Me.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'Latitude
        '
        Me.Latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Latitude.HeaderText = "Latitude"
        Me.Latitude.Name = "Latitude"
        Me.Latitude.ReadOnly = True
        '
        'Longitude
        '
        Me.Longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Longitude.HeaderText = "Longitude"
        Me.Longitude.Name = "Longitude"
        Me.Longitude.ReadOnly = True
        '
        'Accuracy
        '
        Me.Accuracy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Accuracy.DefaultCellStyle = DataGridViewCellStyle2
        Me.Accuracy.HeaderText = "Accuracy (m)"
        Me.Accuracy.Name = "Accuracy"
        Me.Accuracy.ReadOnly = True
        Me.Accuracy.ToolTipText = "Error distance"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.textBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(526, 303)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'textBox1
        '
        Me.textBox1.AcceptsReturn = True
        Me.textBox1.AcceptsTab = True
        Me.textBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBox1.BackColor = System.Drawing.SystemColors.Window
        Me.textBox1.Location = New System.Drawing.Point(3, 3)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textBox1.Size = New System.Drawing.Size(353, 238)
        Me.textBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(167, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Latitude"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(240, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Longitude"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(167, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Value"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(167, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 20)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Mean"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(240, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Sigma"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(167, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Mode"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCalcModeHint
        '
        Me.btnCalcModeHint.Location = New System.Drawing.Point(240, 293)
        Me.btnCalcModeHint.Name = "btnCalcModeHint"
        Me.btnCalcModeHint.Size = New System.Drawing.Size(37, 20)
        Me.btnCalcModeHint.TabIndex = 27
        Me.btnCalcModeHint.Text = "hint"
        Me.btnCalcModeHint.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 412)
        Me.Controls.Add(Me.TabControl1)
        Me.MinimumSize = New System.Drawing.Size(550, 39)
        Me.Name = "Form1"
        Me.Text = "Lightning Simulation"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.Setting.ResumeLayout(False)
        Me.Result.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents startButton As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblRemainingTime As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Setting As TabPage
    Friend WithEvents Result As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Latitude As DataGridViewTextBoxColumn
    Friend WithEvents Longitude As DataGridViewTextBoxColumn
    Friend WithEvents Accuracy As DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As TabPage
    Public WithEvents textBox1 As TextBox
    Friend WithEvents lblR As Label
    Friend WithEvents lblC As Label
    Friend WithEvents lblDelta As Label
    Friend WithEvents lblNIteration As Label
    Friend WithEvents lblLCoordinate As Label
    Friend WithEvents lblFCoordinate As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtFLat As TextBox
    Friend WithEvents txtFlon As TextBox
    Friend WithEvents txtC As TextBox
    Friend WithEvents txtR As TextBox
    Friend WithEvents txtN As TextBox
    Friend WithEvents txtDLat As TextBox
    Friend WithEvents txtLastLat As TextBox
    Friend WithEvents txtLastLon As TextBox
    Friend WithEvents txtDLon As TextBox
    Friend WithEvents lblError As Label
    Friend WithEvents txtErrorMean As TextBox
    Friend WithEvents txtErrorSigma As TextBox
    Friend WithEvents txtCalcMode As TextBox
    Friend WithEvents lblCalcMode As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCalcModeHint As Button
End Class
