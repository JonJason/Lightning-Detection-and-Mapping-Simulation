Imports System.IO

Public Class Form1
    Private tSimulation As Threading.Thread
    Private tRemainingTime As Threading.Thread
    Private suspended As Boolean = True
    Dim stationsData = New List(Of DataFormat.StationsData)
    Dim finalResultData = New List(Of DataFormat.finalResultData)

    Class SimData
        Public Property CalcMode As Integer = 1
        Public Property firstLat As Decimal = -7.5
        Public Property firstLon As Decimal = 105.5
        Public Property lastLat As Decimal = -6
        Public Property lastLon As Decimal = 108.5
        Public Property nIteration As Integer = 1000
        Public Property deltaLat As Decimal = 0.05
        Public Property deltaLon As Decimal = 0.05
        Public Property errorTOAMean As Decimal = 0
        Public Property errorTOASigma As Decimal = 0.00000025
        Public Property c As Decimal = 300000000
        Public Property R As Decimal = 6367000
    End Class

    Dim simulation As New SimData
    Dim calc As New Calculate
    Dim totalPoint As Integer

    Private Function BoxMullerRandom(ByVal mean, ByVal sigma) As Decimal
        Randomize()
        Dim r1 = Rnd()
        Dim r2 = Rnd()
        Dim randomResult = mean + sigma * Math.Sqrt(-2 * Math.Log(r1)) * Math.Sin(2 * Math.PI * r2)
        Return randomResult
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set binding
        txtFLat.DataBindings.Add("Text", simulation, "firstLat")
        txtFlon.DataBindings.Add("Text", simulation, "firstLon")
        txtLastLat.DataBindings.Add("Text", simulation, "lastLat")
        txtLastLon.DataBindings.Add("Text", simulation, "lastLon")
        txtDLat.DataBindings.Add("Text", simulation, "deltaLat")
        txtDLon.DataBindings.Add("Text", simulation, "deltaLon")
        txtN.DataBindings.Add("Text", simulation, "nIteration")
        txtC.DataBindings.Add("Text", simulation, "c")
        txtR.DataBindings.Add("Text", simulation, "R")
        txtErrorMean.DataBindings.Add("Text", simulation, "errorTOAMean")
        txtErrorSigma.DataBindings.Add("Text", simulation, "errorTOASigma")
        txtCalcMode.DataBindings.Add("Text", simulation, "CalcMode")

        stationsData.Add(New DataFormat.StationsData(1, -6.9867, 106.5558))
        stationsData.Add(New DataFormat.StationsData(2, -7.3259, 107.7953))
        stationsData.Add(New DataFormat.StationsData(3, -6.1647, 107.2979))
        stationsData.Add(New DataFormat.StationsData(4, -6.7588, 108.4802))
        stationsData.Add(New DataFormat.StationsData(5, -6.127, 106.2472))

        'setup stationsData gridView
        stationsDataBindingSource.DataSource = stationsData
        DataGridStations.DataSource = stationsDataBindingSource

        Dim columnId As DataGridViewColumn = DataGridStations.Columns(0)
        columnId.Width = 20
        columnId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim columnLat As DataGridViewColumn = DataGridStations.Columns(1)
        columnLat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim columnLon As DataGridViewColumn = DataGridStations.Columns(2)
        columnLon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'setup final result data gridView
        finalResultDataBindingSource.DataSource = finalResultData
        DataGridViewFinalResult.DataSource = finalResultDataBindingSource

        Dim resultcolumnId As DataGridViewColumn = DataGridViewFinalResult.Columns(0)
        With resultcolumnId
            .Width = 40
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim resultcolumnLat As DataGridViewColumn = DataGridViewFinalResult.Columns(1)
        With resultcolumnLat
            .HeaderText = "Latitude"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Dim resultcolumnLon As DataGridViewColumn = DataGridViewFinalResult.Columns(2)
        With resultcolumnLon
            .HeaderText = "Longitude"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Dim resultcolumnLAcc As DataGridViewColumn = DataGridViewFinalResult.Columns(3)
        With resultcolumnLAcc
            .HeaderText = "Accuracy (m)"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        ProgressBar1.Visible = False
        lblProgress.Visible = False
        lblRemainingTime.Visible = False
        lblStatus.Visible = False
        lblProgress.BackColor = Color.Transparent
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        totalPoint = (Math.Floor((simulation.lastLat - simulation.firstLat) / simulation.deltaLat) + 1) * (Math.Floor((simulation.lastLon - simulation.firstLon) / simulation.deltaLon) + 1)
        If tSimulation Is Nothing Then tSimulation = New Threading.Thread(AddressOf startSimulation)

        If tSimulation.IsAlive Then
            If suspended Then
                suspended = Not suspended
                tRemainingTime.Resume()
                tSimulation.Resume()
                btnStop.Visible = False
                btnToKmlFile.Enabled = False
                startButton.Text = "Pause"
                lblStatus.Text = "Status: Resuming. . ."
            Else
                suspended = Not suspended
                tRemainingTime.Suspend()
                tSimulation.Suspend()
                btnStop.Visible = True
                startButton.Text = "Resume"
                lblStatus.Text = "Status: Paused. . ."
            End If

        Else
            With ProgressBar1
                .Style = ProgressBarStyle.Blocks
                .Step = 1
                .Minimum = 0
                .Maximum = simulation.nIteration * totalPoint
                .Value = 0
                .Visible = True
            End With
            With lblProgress
                .Text = "0/" & ProgressBar1.Maximum
                .Visible = True
            End With
            With lblStatus
                .Text = "Status: Starting. . ."
                .Visible = True
            End With
            With lblRemainingTime
                .Text = "Unknown. . ."
                .Visible = True
            End With

            tSimulation = New Threading.Thread(AddressOf startSimulation)
            tSimulation.IsBackground = True

            tRemainingTime = New Threading.Thread(AddressOf startPredictTime)
            tRemainingTime.IsBackground = True
            tSimulation.Start()
            tRemainingTime.Start()

            btnToKmlFile.Enabled = False
            startButton.Text = "Pause"

            suspended = False
        End If
    End Sub

    Private Sub startSimulation()
        finalResultData.Clear()

        Me.Invoke(New MethodInvoker(Sub() Me.finalResultDataBindingSource.ResetBindings(False)))
        Dim dataSet As Array
        Dim arcDistance As Decimal
        Dim result As DataFormat.result
        Dim arrayResult(simulation.nIteration - 1) As DataFormat.result
        Dim arrayAccuracy(totalPoint - 1, 2) As Decimal 'lat, lon, accuracy
        Dim resultId As Integer = 0

        Dim stations(stationsData.count - 1)
        For i = 0 To stations.Length - 1
            stations(i) = New DataFormat.Station()
            stations(i).id = stationsData(i).id
            stations(i).Latitude = stationsData(i).Latitude
            stations(i).Longitude = stationsData(i).Longitude
            stations(i).TOA = vbNull
        Next
        For simLat = simulation.firstLat To simulation.lastLat
            For simLon = simulation.firstLon To simulation.lastLon
                arrayAccuracy(resultId, 2) = 0
                Me.Invoke(New MethodInvoker(Sub() Me.lblStatus.Text = "Status: " & simLat & ", " & simLon))
                For iIteration = 1 To simulation.nIteration
                    For iStation = 0 To stations.Length - 1
                        arcDistance = calc.Busur(stations(iStation).Latitude, stations(iStation).Longitude, simLat, simLon)
                        stations(iStation).TOA = arcDistance / simulation.c + BoxMullerRandom(simulation.errorTOAMean, simulation.errorTOASigma)
                    Next
                    Me.Invoke(New MethodInvoker(Sub() Me.ProgressBar1.Increment(1)))
                    Me.Invoke(New MethodInvoker(Sub() Me.lblProgress.Text = "Process: " & Me.ProgressBar1.Value & "/" & Me.ProgressBar1.Maximum))
                    dataSet = calc.DTOAFilter(stations, simulation.CalcMode)
                    'calc.printStation(dataSet)
                    result = calc.Locate(dataSet, simulation.CalcMode, stations)
                    If result.Latitude = 0 And result.Longitude = 0 And result.TimeOfOccurence = 0 Then
                        'Console.WriteLine(result.Latitude & ", " & result.Longitude & ", " & result.TimeOfOccurence)
                        result = calc.anotherCombination(dataSet, stations)
                    End If
                    'If Not (result.Latitude = 0 And result.Longitude = 0 And result.TimeOfOccurence = 0) Then
                    'Console.WriteLine(result.Latitude & ", " & result.Longitude)
                    'End If
                    result.Accuracy = calc.Busur(result.Latitude, result.Longitude, simLat, simLon)
                    arrayResult(iIteration - 1) = result
                    arrayAccuracy(resultId, 2) += arrayResult(iIteration - 1).Accuracy
                Next
                arrayAccuracy(resultId, 0) = simLat
                arrayAccuracy(resultId, 1) = simLon
                arrayAccuracy(resultId, 2) /= simulation.nIteration
                'Me.Invoke(New MethodInvoker(Sub() Me.textBox1.Text += "-------------------------------------------------------" & vbCrLf))
                'Me.Invoke(New MethodInvoker(Sub() Me.textBox1.Text += "Lightning Simulation  : " & arrayAccuracy(resultId, 0) & ", " & arrayAccuracy(resultId, 1) & vbCrLf))
                'Me.Invoke(New MethodInvoker(Sub() Me.textBox1.Text += "Accuracy  : " & arrayAccuracy(resultId, 2) & vbCrLf))
                'Me.Invoke(New MethodInvoker(Sub() Me.textBox1.Text += arrayAccuracy(resultId, 1) & "," & arrayAccuracy(resultId, 0) & "," & Decimal.Round(arrayAccuracy(resultId, 2), 2) & vbCrLf))

                finalResultData.add(New DataFormat.finalResultData(resultId + 1, arrayAccuracy(resultId, 0), arrayAccuracy(resultId, 1), Decimal.Round(arrayAccuracy(resultId, 2), 2)))
                Me.Invoke(New MethodInvoker(Sub() Me.finalResultDataBindingSource.ResetBindings(False)))

                resultId += 1
                simLon += simulation.deltaLon - 1
            Next simLon
            simLat += simulation.deltaLat - 1
        Next simLat
        drawData()

        Me.Invoke(New MethodInvoker(Sub() Me.startButton.Text = "Start"))
        Me.Invoke(New MethodInvoker(Sub() Me.ProgressBar1.Visible = False))
        Me.Invoke(New MethodInvoker(Sub() Me.lblProgress.Visible = False))
        Me.Invoke(New MethodInvoker(Sub() Me.lblRemainingTime.Visible = False))
        Me.Invoke(New MethodInvoker(Sub() Me.lblStatus.Visible = False))
        Me.Invoke(New MethodInvoker(Sub() Me.btnToKmlFile.Enabled = True))
        suspended = True
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(1) Then
            DirectCast(sender, TextBox).SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub startPredictTime()
        Threading.Thread.Sleep(200)
        Dim remainingTime As Integer = 0
        Dim progress As Double = 0
        Dim lastProgress As Double = progress
        Dim speed As Double
        Dim finish As Double = ProgressBar1.Maximum
        Dim tick As Integer = 1000
        Do
            progress = ProgressBar1.Value
            speed = (progress - lastProgress) / tick * 1000
            If speed = 0 Then
                Me.Invoke(New MethodInvoker(Sub() Me.lblRemainingTime.Text = "Remaining Time: Infinity..."))
            Else
                remainingTime = (finish - progress) / speed
                Me.Invoke(New MethodInvoker(Sub() Me.lblRemainingTime.Text = "Remaining Time: " & StoHMS(remainingTime)))
            End If
            lastProgress = progress
            Threading.Thread.Sleep(tick)
        Loop Until ProgressBar_at_Max()
    End Sub

    Private Function ProgressBar_at_Max() As Boolean
        ProgressBar_at_Max = False
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            ProgressBar_at_Max = True
        Else
            ProgressBar_at_Max = False
        End If

    End Function

    Private Function StoHMS(ByVal second) As String
        Dim hms As String
        Dim minute As Integer
        Dim hour As Integer
        If second < 60 Then
            hms = second & " s"
        Else
            If second < 3600 Then
                minute = second / 60
                second = second Mod 60
                hms = minute & " m " & second & " s"
            Else
                hour = second / 3600
                minute = (second Mod 3600) / 60
                second = second Mod 60
                hms = hour & " h " & minute & " m " '& second & " s "
            End If
        End If
        Return hms
    End Function

    Private Sub btnCalcModeHint_Click(sender As Object, e As EventArgs)
        MsgBox("Mode:" & vbCrLf & "1. Lightning Sperical Method" & vbCrLf & "2. Quadratic Planar Method",, "Method hint")
        'MsgBox(stationsData.count)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not suspended Then
            e.Cancel = True
            Beep()
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        tRemainingTime.Resume()
        tRemainingTime.Abort()
        tSimulation.Resume()
        tSimulation.Abort()
        btnStop.Visible = False
        startButton.Text = "Start"
        ProgressBar1.Visible = False
        lblProgress.Visible = False
        lblRemainingTime.Visible = False
        lblStatus.Visible = False
        btnToKmlFile.Enabled = True

    End Sub

    Private Sub DataGridStations_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Right
                If e.RowIndex > -1 Then
                    Me.DataGridStations.Rows(e.RowIndex).Selected = True
                    Me.DataGridStations.CurrentCell = Me.DataGridStations.Rows(e.RowIndex).Cells(1)
                End If
                DGStationCMS.Show(Cursor.Position)
            Case MouseButtons.Left
                If e.RowIndex = -1 And e.ColumnIndex > -1 Then
                    DataGridStations.ClearSelection()
                End If
            Case Else

        End Select
    End Sub

    Private Sub DGStationCMS_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles DGStationCMS.ItemClicked
        Select Case e.ClickedItem.Text
            Case "Add New Station"
                stationsData.add(New DataFormat.StationsData(stationsData.count + 1, 0, 0))
                stationsDataBindingSource.ResetBindings(False)
            Case "Delete Selected Station"
                For Each rows In DataGridStations.SelectedRows
                    stationsData.removeat(rows.index)
                    stationsDataBindingSource.ResetBindings(False)
                Next
            Case "Reset Stations"
                'For Each item In stationsData
                'MsgBox(item.id & "," & item.Latitude & "," & item.Longitude)
                'Next
                stationsData.clear()
                stationsData.Add(New DataFormat.StationsData(1, -6.9867, 106.5558))
                stationsData.Add(New DataFormat.StationsData(2, -7.3259, 107.7953))
                stationsData.Add(New DataFormat.StationsData(3, -6.1647, 107.2979))
                stationsData.Add(New DataFormat.StationsData(4, -6.7588, 108.4802))
                stationsData.Add(New DataFormat.StationsData(5, -6.127, 106.2472))
                stationsDataBindingSource.ResetBindings(False)
            Case Else

        End Select
    End Sub

    Private Sub btnToKmlFile_Click(sender As Object, e As EventArgs) Handles btnToKmlFile.Click
        drawData()
    End Sub

    Public Sub drawData()
        Dim limits = {100, 1000, 2000, 5000, 10000}
        Dim fileName = ""
        Select Case simulation.CalcMode
            Case 1
                fileName = "LSM.kml"
            Case 2
                fileName = "QPM.kml"
            Case Else

        End Select
        Dim filePath = "E:\Kuliah\Semester 8\TA 2\Google Earth\" & fileName
        calc.createContourKMLFile(filePath, finalResultData, limits, simulation, stationsData)
    End Sub

    Public Sub printInTextbox1(ByVal text)
        textBox1 += text
    End Sub

    Private Sub btnCalcModeHint_Click_1(sender As Object, e As EventArgs) Handles btnCalcModeHint.Click
        MsgBox("Calc Mode:" & vbCrLf & "1. Lightning Spherical Method" & vbCrLf & "2. Quadratic Planar Method")
    End Sub
End Class
