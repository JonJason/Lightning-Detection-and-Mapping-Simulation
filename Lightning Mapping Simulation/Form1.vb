﻿Imports System.IO
Imports System.Text

Public Class Form1
    Private tSimulation As Threading.Thread
    Private tRemainingTime As Threading.Thread
    Private suspended As Boolean = True
    Dim stationsData = New List(Of DataFormat.StationsData)
    Dim finalResultData = New List(Of DataFormat.finalResultData)
    Dim event_1 As New Threading.AutoResetEvent(False)
    Dim event_2 As New Threading.AutoResetEvent(False)
    Dim textTemp As String = ""
    Dim altitudeTopLimit As Decimal
    Dim altitudeBottomLimit As Decimal
    Dim simulation As New SimData
    Dim totalPoint As Integer
    Dim simLat, simLon, nPencilan

    Dim stopWatch As New Stopwatch()
    Private Delegate Sub createContourKMLFileDelegate(ByVal path As String, ByVal Points As List(Of DataFormat.finalResultData), ByVal limits As Array, ByVal setting As Form1.SimData, ByVal stationsData As List(Of DataFormat.StationsData))
    Private Delegate Sub drawDataDelegate()
    Private Delegate Sub createTxtKMLFileDelegate(ByVal path As String, ByVal Points As List(Of DataFormat.finalResultData))

    Class SimData
        Public Property CalcMode As Integer = 1
        Public Property filterMode As Integer = 1
        Public Property firstLat As Decimal = -7.8
        'Public Property firstLat As Decimal = -9.05
        Public Property firstLon As Decimal = 105.15
        Public Property lastLat As Decimal = -5.9 '-6.7549
        Public Property lastLon As Decimal = 108.5 '107.4192
        'Public Property lastLon As Decimal = 115.85
        Public Property nIteration As Integer = 1 '1000
        Public Property deltaLat As Decimal = 0.025
        Public Property deltaLon As Decimal = 0.025
        Public Property errorTOAMean As Decimal = 0
        Public Property errorTOASigma As Decimal = 0.00000025
        Public Property c As Decimal = 300000000
        Public Property R As Decimal = 6367000
    End Class


    Private Function BoxMullerRandom(ByVal mean, ByVal sigma) As Decimal
        Randomize()
        Dim r1 = Rnd()
        Dim r2 = Rnd()
        Dim randomResult = mean + sigma * Math.Sqrt(-2 * Math.Log(r1)) * Math.Cos(2 * Math.PI * r2)
        Return randomResult
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'simulation.firstLat = -10
        'simulation.lastLat = -3
        'simulation.firstLon = 103
        'simulation.lastLon = 112
        'simulation.nIteration = 100
        'simulation.deltaLat = 0.1
        'simulation.deltaLon = 0.1

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
        txtFilterMode.DataBindings.Add("Text", simulation, "filterMode")

        stationsData.Add(New DataFormat.StationsData(1, -6.9867, 106.5558))
        stationsData.Add(New DataFormat.StationsData(2, -6.7047, 108.506))
        stationsData.Add(New DataFormat.StationsData(3, -6.8895, 107.6113))
        stationsData.Add(New DataFormat.StationsData(4, -6.1646, 107.298))
        stationsData.Add(New DataFormat.StationsData(5, -6.127, 106.2472))
        stationsData.Add(New DataFormat.StationsData(6, -7.3259, 107.7953))
        'stationsData.Add(New DataFormat.StationsData(7, -6.5508, 106.745))
        'stationsData.Add(New DataFormat.StationsData(7, -6.5274, 106.8304))
        'stationsData.Add(New DataFormat.StationsData(7, -6.7076, 105.8071))
        'stationsData.Add(New DataFormat.StationsData(8, -6.7076, 110.8071))


        'stationsData.Add(New DataFormat.StationsData(1, -6.7924, 107.6045))
        'stationsData.Add(New DataFormat.StationsData(2, -6.1646, 107.298))
        'stationsData.Add(New DataFormat.StationsData(3, -6.7047, 108.506))
        'stationsData.Add(New DataFormat.StationsData(4, -7.4641, 107.3392))

        'stationsData.Add(New DataFormat.StationsData(1, -6.8154, 106.5499))
        'stationsData.Add(New DataFormat.StationsData(2, -6.1646, 107.298))
        'stationsData.Add(New DataFormat.StationsData(3, -6.7047, 108.506))
        'stationsData.Add(New DataFormat.StationsData(4, -7.4641, 107.3392))

        'stasiun pa syarif
        'stationsData.Add(New DataFormat.StationsData(1, -5.8111, 105.7684))
        'stationsData.Add(New DataFormat.StationsData(2, -6.5314, 105.7187))
        'stationsData.Add(New DataFormat.StationsData(3, -5.7271, 106.6232))
        'stationsData.Add(New DataFormat.StationsData(4, -6.9639, 106.3928))
        'stationsData.Add(New DataFormat.StationsData(5, -6.2173, 107.6244))
        'stationsData.Add(New DataFormat.StationsData(6, -6.4875, 108.5331))
        'stationsData.Add(New DataFormat.StationsData(7, -6.8895, 107.6113))
        'stationsData.Add(New DataFormat.StationsData(8, -7.6722, 108.6542))
        'stationsData.Add(New DataFormat.StationsData(9, -6.8704, 109.7117))
        'stationsData.Add(New DataFormat.StationsData(10, -7.8674, 110.0393))
        'stationsData.Add(New DataFormat.StationsData(11, -6.4841, 110.7321))
        'stationsData.Add(New DataFormat.StationsData(12, -7.6357, 111.528))
        'stationsData.Add(New DataFormat.StationsData(13, -6.8896, 112.2854))
        'stationsData.Add(New DataFormat.StationsData(14, -7.5598, 112.7066))
        'stationsData.Add(New DataFormat.StationsData(15, -8.311, 112.1648))
        'stationsData.Add(New DataFormat.StationsData(16, -8.3399, 114.1343))
        'stationsData.Add(New DataFormat.StationsData(17, -8.8401, 115.1659))
        'stationsData.Add(New DataFormat.StationsData(18, -8.0765, 115.2229))
        'stationsData.Add(New DataFormat.StationsData(19, -7.7035, 113.9469))
        'stationsData.Add(New DataFormat.StationsData(20, -6.8848, 113.6628))
        'stationsData.Add(New DataFormat.StationsData(21, -5.8356, 112.6882))

        'stasiun pa syarif 2
        'stationsData.Add(New DataFormat.StationsData(1, -5.8111, 105.7684))
        'stationsData.Add(New DataFormat.StationsData(2, -6.5314, 105.7187))
        'stationsData.Add(New DataFormat.StationsData(3, -5.7271, 106.6232))
        'stationsData.Add(New DataFormat.StationsData(4, -6.9483, 106.4719))
        'stationsData.Add(New DataFormat.StationsData(5, -5.9971, 107.3357))
        'stationsData.Add(New DataFormat.StationsData(6, -7.4722, 107.2142))
        'stationsData.Add(New DataFormat.StationsData(7, -6.8895, 107.6113))
        'stationsData.Add(New DataFormat.StationsData(8, -6.3484, 108.3806))
        'stationsData.Add(New DataFormat.StationsData(9, -7.6722, 108.6542))
        'stationsData.Add(New DataFormat.StationsData(10, -6.8471, 109.5252))
        'stationsData.Add(New DataFormat.StationsData(11, -7.9852, 110.2823))
        'stationsData.Add(New DataFormat.StationsData(12, -6.4841, 110.7321))
        'stationsData.Add(New DataFormat.StationsData(13, -6.8896, 112.2854))
        'stationsData.Add(New DataFormat.StationsData(14, -8.2573, 111.8945))
        'stationsData.Add(New DataFormat.StationsData(15, -7.6544, 112.8426))
        'stationsData.Add(New DataFormat.StationsData(16, -7.0071, 113.9865))
        'stationsData.Add(New DataFormat.StationsData(17, -8.5584, 113.9059))
        'stationsData.Add(New DataFormat.StationsData(18, -7.4035, 111.1654))
        'stationsData.Add(New DataFormat.StationsData(19, -8.8401, 115.1659))
        'stationsData.Add(New DataFormat.StationsData(20, -8.0765, 115.2229))
        'stationsData.Add(New DataFormat.StationsData(21, -5.8356, 112.6882))

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
        txtC.ReadOnly = True
        txtR.ReadOnly = True
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        If tSimulation Is Nothing Then tSimulation = New Threading.Thread(AddressOf startSimulation)

        If tSimulation.IsAlive Then
            If suspended Then
                suspended = Not suspended
                tRemainingTime.Resume()
                tSimulation.Resume()
                stopWatch.Start()
                btnStop.Visible = False
                btnToKmlFile.Enabled = False
                startButton.Text = "Pause"
                lblStatus.Text = "Status: Resuming. . ."
            Else
                suspended = Not suspended
                tRemainingTime.Suspend()
                tSimulation.Suspend()
                stopWatch.Stop()
                btnStop.Visible = True
                startButton.Text = "Resume"
                lblStatus.Text = "Status: Paused. . ."
            End If

        Else

            tSimulation = New Threading.Thread(AddressOf startSimulation)
            tSimulation.IsBackground = True

            tRemainingTime = New Threading.Thread(AddressOf startPredictTime)
            tRemainingTime.IsBackground = True

            tSimulation.Start()
            tRemainingTime.Start()

            suspended = False
        End If
    End Sub

    Private Sub startSimulation()
        finalResultData.Clear()
        totalPoint = (Math.Floor((simulation.lastLat - simulation.firstLat) / simulation.deltaLat) + 1) * (Math.Floor((simulation.lastLon - simulation.firstLon) / simulation.deltaLon) + 1)
        Me.Invoke(New MethodInvoker(Sub()
                                        Me.finalResultDataBindingSource.ResetBindings(False)
                                        With ProgressBar1
                                            .Style = ProgressBarStyle.Blocks
                                            .Step = 1
                                            .Minimum = 0
                                            .Maximum = simulation.nIteration * totalPoint
                                            .Value = 0
                                            .Visible = True
                                        End With
                                        With lblProgress
                                            .Text = ""
                                            .Visible = True
                                        End With
                                        With lblStatus
                                            .Text = "Status: Starting. . ."
                                            .Visible = True
                                        End With

                                        btnToKmlFile.Enabled = False
                                        startButton.Text = "Pause"
                                    End Sub))

        Dim calc As New Calculate
        Dim dataSet As Array
        Dim arcDistance As Decimal
        Dim result As DataFormat.result
        Dim arrayResult(simulation.nIteration - 1) As DataFormat.result
        Dim arrayAccuracy(totalPoint - 1, 2) As Decimal 'lat, lon, accuracy
        Dim resultId As Integer = 0
        Dim stations_list = New List(Of DataFormat.Station)

        'setting up stations array
        Dim stations(stationsData.count - 1)
        For i = 0 To stations.Length - 1
            stations(i) = New DataFormat.Station()
            stations(i).id = stationsData(i).id
            stations(i).Latitude = stationsData(i).Latitude
            stations(i).Longitude = stationsData(i).Longitude
            stations(i).TOA = vbNull
            stations(i).rFromCenter = vbNull
        Next
        event_1.Set()
        Me.Invoke(New MethodInvoker(Sub() Me.lblStatus.Text = "Status: Running..."))
        For simLat = simulation.firstLat To simulation.lastLat
            For simLon = simulation.firstLon To simulation.lastLon
                nPencilan = 0
                arrayAccuracy(resultId, 2) = 0
                'Me.Invoke(New MethodInvoker(Sub() Me.lblStatus.Text = "Status: " & simLat & ", " & simLon))
                For iIteration = 1 To simulation.nIteration
                    stations_list.Clear()
                    For iStation = 0 To stations.Length - 1
                        arcDistance = calc.Busur(stations(iStation).Latitude, stations(iStation).Longitude, simLat, simLon)
                        stations(iStation).TOA = arcDistance / simulation.c + BoxMullerRandom(simulation.errorTOAMean, simulation.errorTOASigma)
                        Me.Invoke(New MethodInvoker(Sub()
                                                        'Console.WriteLine(simLat & ", " & simLon & ", " & stations(iStation).id & ", " & stations(iStation).TOA)
                                                    End Sub))
                        If stations(iStation).TOA > 0.002 Then
                            'Console.WriteLine(simLat & ", " & simLon & ", " & stations(iStation).id & ", " & stations(iStation).TOA)
                            stations(iStation).TOA = -1
                            'Console.WriteLine(simLat & ", " & simLon & ", " & stations(iStation).id & ", " & stations(iStation).TOA)
                        Else
                            stations_list.Add(stations(iStation))
                        End If
                    Next
                    Me.Invoke(New MethodInvoker(Sub()
                                                    Me.ProgressBar1.Increment(1)
                                                    'Me.lblProgress.Text = "Process: " & Me.ProgressBar1.Value & "/" & Me.ProgressBar1.Maximum
                                                End Sub))
                    'For xxx = 1 To 4
                    Select Case simulation.filterMode
                        Case 1
                            dataSet = calc.middleCombination(stations_list.ToArray(), simulation.CalcMode)
                        Case 2
                            dataSet = calc.nearestCombination1(stations_list.ToArray(), simulation.CalcMode)
                        Case 3
                            dataSet = calc.nearestCombination2(stations_list.ToArray(), simulation.CalcMode)
                        Case 4
                            dataSet = calc.nearestCombination3(stations_list.ToArray(), simulation.CalcMode)
                        Case 5
                            dataSet = stations_list.ToArray()
                        Case Else
                            dataSet = Nothing
                    End Select
                    If False Then 'Not dataSet Is Nothing Then
                        Me.Invoke(New MethodInvoker(Sub()
                                                        'Console.WriteLine(xxx)
                                                        printStation(dataSet)
                                                    End Sub))
                    End If
                    'Next
                    If dataSet Is Nothing Then
                        nPencilan += 1
                        Console.WriteLine(nPencilan)
                    Else
                        result = calc.Locate(dataSet, simulation.CalcMode, stations)

                        If result.Latitude = 0 And result.Longitude = 0 And result.TimeOfOccurence = 0 Then
                            'Console.WriteLine("Another try")
                            result = calc.anotherCombination(dataSet, stations)
                        End If
                        result.Accuracy = calc.Busur(result.Latitude, result.Longitude, simLat, simLon)
                        arrayResult(iIteration - 1) = result
                        arrayAccuracy(resultId, 2) += arrayResult(iIteration - 1).Accuracy
                    End If
                Next
                arrayAccuracy(resultId, 0) = simLat
                arrayAccuracy(resultId, 1) = simLon
                If simulation.nIteration <= nPencilan Then
                    arrayAccuracy(resultId, 2) = -2
                Else
                    arrayAccuracy(resultId, 2) /= (simulation.nIteration - nPencilan)
                End If

                finalResultData.add(New DataFormat.finalResultData(resultId + 1, arrayAccuracy(resultId, 0), arrayAccuracy(resultId, 1), Decimal.Round(arrayAccuracy(resultId, 2), 2)))
                Me.Invoke(New MethodInvoker(Sub() Me.finalResultDataBindingSource.ResetBindings(False)))

                resultId += 1
                simLon += simulation.deltaLon - 1
            Next simLon
            simLat += simulation.deltaLat - 1
        Next simLat
        event_2.WaitOne()
        event_2.Reset()
        Me.Invoke(New MethodInvoker(Sub()
                                        Me.lblStatus.Text = "Status: Creating kml File"
                                        Me.startButton.Enabled = False
                                        Me.lblProgress.Visible = False
                                        Me.ProgressBar1.Visible = False
                                        Me.textBox1.Text = ""
                                        Me.textBox1.Text += textTemp
                                        event_2.Set()
                                    End Sub))
        event_2.WaitOne()
        drawData()

        Me.Invoke(New MethodInvoker(Sub()
                                        Me.startButton.Text = "Start"
                                        Me.lblStatus.Visible = False
                                        Me.btnToKmlFile.Enabled = True
                                        Me.startButton.Enabled = True
                                    End Sub))
        suspended = True
        event_2.Reset()
        MsgBox("kml File Created")
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(1) Then
            DirectCast(sender, TextBox).SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub startPredictTime()
        event_1.WaitOne()
        Me.Invoke(New MethodInvoker(Sub()
                                        With Me.lblRemainingTime
                                            .Text = "Unknown. . ."
                                            .Visible = True
                                        End With
                                    End Sub))

        Dim remainingTime As Integer = 0
        Dim progress As Double = 0
        Dim speed As Double
        Dim finish As Double = ProgressBar1.Maximum
        stopWatch.Reset()
        stopWatch.Start()

        Do
            progress = ProgressBar1.Value
            speed = progress / stopWatch.ElapsedMilliseconds * 1000
            'Console.WriteLine("speed: " & progress & ", " & stopWatch.ElapsedMilliseconds & ", " & speed)
            If speed = 0 Or Double.IsNaN(speed) Then
                Me.Invoke(New MethodInvoker(Sub() Me.lblRemainingTime.Text = "Time Left: Infinity..."))
            Else
                remainingTime = (finish - progress) / speed
                Me.Invoke(New MethodInvoker(Sub() Me.lblRemainingTime.Text = "Time Left: " & StoHMS(remainingTime)))
            End If
            Threading.Thread.Sleep(1000)
        Loop Until ProgressBar_at_Max()
        Me.Invoke(New MethodInvoker(Sub() Me.lblRemainingTime.Visible = False))
        event_1.Reset()
        event_2.Set()
        stopWatch.Stop()
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
                minute = Math.Floor(second / 60)
                second = second Mod 60
                hms = minute & " m " & second & " s"
            Else
                hour = Math.Floor(second / 3600)
                minute = Math.Floor((second Mod 3600) / 60)
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

    Private Sub DataGridStations_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridStations.CellMouseUp
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
                stationsData.Add(New DataFormat.StationsData(2, -6.7047, 108.506))
                stationsData.Add(New DataFormat.StationsData(3, -6.8895, 107.6113))
                stationsData.Add(New DataFormat.StationsData(4, -6.1646, 107.298))
                stationsData.Add(New DataFormat.StationsData(5, -6.127, 106.2472))
                stationsData.Add(New DataFormat.StationsData(6, -7.3259, 107.7953))
                stationsDataBindingSource.ResetBindings(False)
            Case Else

        End Select
    End Sub

    Private Sub btnToKmlFile_Click(sender As Object, e As EventArgs) Handles btnToKmlFile.Click
        drawData()
    End Sub

    Private Sub drawData()
        If Me.InvokeRequired Then
            Me.Invoke(New drawDataDelegate(AddressOf drawData))
        Else
            Dim limits = {100, 1000, 2000, 5000, 10000}
            Dim fileName = ""
            Dim filtMethod = ""
            Select Case simulation.CalcMode
                Case 1
                    fileName = "LSM"
                Case 2
                    fileName = "QPM"
                Case Else

            End Select
            Dim _now = Now
            Dim folderPath = txtKMLPath.Text & Format(_now, "d-MMM-yyyy")
            Dim answer As DialogResult
            answer = MessageBox.Show("do you want to create KML file on:" & vbCrLf & vbCrLf & folderPath, "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = vbYes Then
                If (Not Directory.Exists(folderPath)) Then
                    Directory.CreateDirectory(folderPath)
                End If
                Dim filePath = folderPath & "\" & fileName & " (" & Format(_now, "d-MMM-yyyy H.mm.ss") & ")" & " M" & simulation.filterMode
                'MsgBox(filePath)
                createTxtFile(filePath & ".txt", finalResultData)
                createContourKMLFile(filePath & ".kml", finalResultData, limits, simulation, stationsData)
            End If
        End If
    End Sub

    Public Sub printInTextbox1(ByVal text)
        textBox1 += text
    End Sub

    Private Sub btnCalcModeHint_Click_1(sender As Object, e As EventArgs) Handles btnCalcModeHint.Click
        MsgBox("Calc Mode:" & vbCrLf &
               "1. Lightning Spherical Method" & vbCrLf &
               "2. Quadratic Planar Method" &
               vbCrLf & vbCrLf & "Filter Mode:" &
               vbCrLf & "1. Lightning in the Middle" &
               vbCrLf & "2. nearest Station to the lightning" &
               vbCrLf & "3. nearest as the center, secondaries are nearest to the center" &
               vbCrLf & "4. nearest as the center, secondaries picked by method 1." &
               vbCrLf & vbCrLf & "Latitude Longitude" &
               vbCrLf & "First:-7.8, 105.15" &
               vbCrLf & "Last : -5.9, 108.5")
    End Sub

    Private Sub printStationtoTextbox(ByVal array)
        textBox1.Text += vbCrLf & " - --------------------------------------------------------------"
        For i = 0 To array.Length - 1
            textBox1.Text += vbCrLf & array(i).id & vbTab & array(i).Latitude & vbTab & array(i).Longitude & vbTab & vbTab & array(i).TOA
        Next
    End Sub

    Private Sub printStation(ByVal array)
        Console.WriteLine(" - --------------------------------------------------------------")
        For i = 0 To array.Length - 1
            Console.WriteLine(array(i).id & vbTab & array(i).Latitude & vbTab & array(i).Longitude & vbTab & vbTab & array(i).TOA)
        Next
        Console.WriteLine(" - --------------------------------------------------------------")
    End Sub

    Public Function getContourLine(ByVal altitude As Decimal, ByVal data As List(Of DataFormat.finalResultData), ByVal simulation As Form1.SimData) As List(Of DataFormat.finalResultData)
        altitudeTopLimit = altitude

        Dim lineList As New List(Of DataFormat.finalResultData)

        Dim filteredList = data.FindAll(AddressOf findUnderLimit)
        Dim maxLat = filteredList.Max(Function(FRD As DataFormat.finalResultData) FRD.Latitude)
        Dim minLat = filteredList.Min(Function(FRD As DataFormat.finalResultData) FRD.Latitude)
        Dim maxLon = filteredList.Max(Function(FRD As DataFormat.finalResultData) FRD.Longitude)
        Dim minLon = filteredList.Min(Function(FRD As DataFormat.finalResultData) FRD.Longitude)

        'MsgBox(maxLat & ", " & minLat & vbCrLf & maxLon & ", " & minLon)

        Dim currentPoint = filteredList.FindLast(Function(FRD As DataFormat.finalResultData) FRD.Latitude = maxLat)
        Dim firstPoint = currentPoint
        Dim lastDirection As Integer = 1 '0 top, 1 right, 2 bottom, 3 left

        Do
            lineList.Add(currentPoint)
            currentPoint = findNextPoint(filteredList, currentPoint, simulation, lastDirection)
        Loop Until currentPoint Is firstPoint Or IsNothing(currentPoint)

        Return lineList
    End Function

    Private Function findBetweenLimit(ByVal FRD As DataFormat.finalResultData) As Boolean
        If FRD.Accuracy <= altitudeTopLimit And FRD.Accuracy > altitudeBottomLimit Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function findAboveLimit(ByVal FRD As DataFormat.finalResultData) As Boolean
        If FRD.Accuracy > altitudeTopLimit Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function findUnderLimit(ByVal FRD As DataFormat.finalResultData) As Boolean
        If FRD.Accuracy < altitudeTopLimit Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function findNextPoint(ByVal Points As List(Of DataFormat.finalResultData), ByVal currentPoint As DataFormat.finalResultData, ByVal simulation As Form1.SimData, ByRef lastDirection As Integer) As DataFormat.finalResultData
        Dim direction(3)
        Dim topPoint = Points.Find(Function(FRD As DataFormat.finalResultData) FRD.Latitude = currentPoint.Latitude + simulation.deltaLat And FRD.Longitude = currentPoint.Longitude)
        Dim rightPoint = Points.Find(Function(FRD As DataFormat.finalResultData) FRD.Latitude = currentPoint.Latitude And FRD.Longitude = currentPoint.Longitude + simulation.deltaLon)
        Dim bottomPoint = Points.Find(Function(FRD As DataFormat.finalResultData) FRD.Latitude = currentPoint.Latitude - simulation.deltaLat And FRD.Longitude = currentPoint.Longitude)
        Dim leftPoint = Points.Find(Function(FRD As DataFormat.finalResultData) FRD.Latitude = currentPoint.Latitude And FRD.Longitude = currentPoint.Longitude - simulation.deltaLon)

        direction(0) = topPoint
        direction(1) = rightPoint
        direction(2) = bottomPoint
        direction(3) = leftPoint

        For d = lastDirection + 3 To lastDirection + 5
            If d >= 4 Then
                d = d Mod 4
            End If
            'MsgBox(d)
            If Not IsNothing(direction(d)) Then
                'Select Case d : Case 0 : MsgBox("top") : Case 1 : MsgBox("right") : Case 2 : MsgBox("bottom") : Case 3 : MsgBox("left") : Case Else : MsgBox("error:   " & d) : End Select
                lastDirection = d
                Return direction(d)
            End If
        Next
        'MsgBox("ga ada temen")
        Return Nothing
    End Function

    Private Sub createContourKMLFile(ByVal path As String, ByVal Points As List(Of DataFormat.finalResultData), ByVal limits As Array, ByVal setting As Form1.SimData, ByVal stationsData As List(Of DataFormat.StationsData))
        If Me.InvokeRequired Then
            Me.Invoke(New createContourKMLFileDelegate(AddressOf createContourKMLFile), New Object() {path, Points, limits, setting, stationsData})
        Else
            Dim fs As FileStream = File.Create(path)
            Dim info As Byte()

            Console.WriteLine("[TRACE] Creating Kml Text")
            altitudeTopLimit = -1
            Dim kml As New myKML()
            Dim cameraLat = (setting.firstLat + setting.lastLat) / 2
            Dim cameraLon = (setting.firstLon + setting.lastLon) / 2
            Dim cameraAlt = Math.Max((setting.lastLat - setting.firstLat) * 2, setting.lastLon - setting.firstLon) * 150000

            Dim styles(5)
            styles(0) = New myKML.style("style" & limits(0), 0, "77ff0000")
            styles(1) = New myKML.style("style" & limits(1), 0, "77ffff00")
            styles(2) = New myKML.style("style" & limits(2), 0, "7700ff00")
            styles(3) = New myKML.style("style" & limits(3), 0, "7700ffff")
            styles(4) = New myKML.style("style" & limits(4), 0, "770000ff")
            styles(5) = New myKML.style("style > " & limits(4), 0, "77ff00ff")
            Dim StationStyle = New myKML.iconStyle("stationStyle", "http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png", "aaffffff")

            info = New UTF8Encoding(True).GetBytes(kml.XMLTag) : fs.Write(info, 0, info.Length)
            info = New UTF8Encoding(True).GetBytes(kml.kmlTag.header) : fs.Write(info, 0, info.Length)
            info = New UTF8Encoding(True).GetBytes(kml.document(1).header) : fs.Write(info, 0, info.Length)
            For index = 0 To limits.Length
                info = New UTF8Encoding(True).GetBytes(styles(index).KMLText(2)) : fs.Write(info, 0, info.Length)
            Next
            info = New UTF8Encoding(True).GetBytes(StationStyle.KMLText(2)) : fs.Write(info, 0, info.Length)
            Console.WriteLine("[TRACE] Wrote Styles")

            For index = 0 To stationsData.Count - 1
                info = New UTF8Encoding(True).GetBytes(kml.point(2, stationsData(index).Id, stationsData(index).Latitude, stationsData(index).Longitude, 2000, style:=StationStyle)) : fs.Write(info, 0, info.Length)
            Next

            Console.WriteLine("[TRACE] Wrote Stations Coordinates")
            info = New UTF8Encoding(True).GetBytes(kml.camera(2, cameraLat, cameraLon, cameraAlt, 0, 0, 0)) : fs.Write(info, 0, info.Length)

            Console.WriteLine("[TRACE] Wrote Camera Position")
            For index = 0 To limits.Length - 1
                Console.WriteLine("[TRACE] data limit " & index + 1)
                altitudeBottomLimit = altitudeTopLimit
                altitudeTopLimit = limits(index)
                Dim filteredPoints = Points.FindAll(AddressOf findBetweenLimit)
                If filteredPoints IsNot Nothing Then
                    Console.WriteLine("[TRACE] points count: " & filteredPoints.Count)
                    info = New UTF8Encoding(True).GetBytes(kml.placemark(2).header) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.name(3, index + 1 & ". Under " & limits(index)).oneline) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(styles(index).styleUrl(3)) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.MultiGeometry(3).header) : fs.Write(info, 0, info.Length)

                    For Each point In filteredPoints
                        info = New UTF8Encoding(True).GetBytes(kml.plgn(4).header) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.Extrude(5)) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.altitudeMode(5, "absolute")) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.outerBoundaryIs(5).header) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.LinearRing(6).header) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.coordinates(7, point, 3000, setting).text) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.LinearRing(6).footer) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.outerBoundaryIs(5).footer) : fs.Write(info, 0, info.Length)
                        info = New UTF8Encoding(True).GetBytes(kml.plgn(4).footer) : fs.Write(info, 0, info.Length)
                    Next

                    info = New UTF8Encoding(True).GetBytes(kml.MultiGeometry(3).footer) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.placemark(2).footer) : fs.Write(info, 0, info.Length)
                End If
                Console.WriteLine("[TRACE] finish data limit " & index + 1)
            Next
            Dim BadPoints = Points.FindAll(AddressOf findAboveLimit)
            If BadPoints IsNot Nothing Then
                Console.WriteLine("[TRACE] data limit " & limits.Length + 1)
                Console.WriteLine("[TRACE] points count: " & BadPoints.Count)
                info = New UTF8Encoding(True).GetBytes(kml.placemark(2).header) : fs.Write(info, 0, info.Length)
                info = New UTF8Encoding(True).GetBytes(kml.name(3, limits.Length + 1 & ". Above " & limits(4)).oneline) : fs.Write(info, 0, info.Length)
                info = New UTF8Encoding(True).GetBytes(styles(5).styleUrl(3)) : fs.Write(info, 0, info.Length)
                info = New UTF8Encoding(True).GetBytes(kml.MultiGeometry(3).header) : fs.Write(info, 0, info.Length)

                For Each point In BadPoints
                    info = New UTF8Encoding(True).GetBytes(kml.plgn(4).header) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.Extrude(5)) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.altitudeMode(5, "absolute")) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.outerBoundaryIs(5).header) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.LinearRing(6).header) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.coordinates(7, point, 3000, setting).text) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.LinearRing(6).footer) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.outerBoundaryIs(5).footer) : fs.Write(info, 0, info.Length)
                    info = New UTF8Encoding(True).GetBytes(kml.plgn(4).footer) : fs.Write(info, 0, info.Length)
                Next
                info = New UTF8Encoding(True).GetBytes(kml.MultiGeometry(3).footer) : fs.Write(info, 0, info.Length)
                info = New UTF8Encoding(True).GetBytes(kml.placemark(2).footer) : fs.Write(info, 0, info.Length)
                info = New UTF8Encoding(True).GetBytes(kml.document(1).footer) : fs.Write(info, 0, info.Length)
                info = New UTF8Encoding(True).GetBytes(kml.kmlTag.footer) : fs.Write(info, 0, info.Length)
                Console.WriteLine("[TRACE] finish data limit " & limits.Length + 1)
            End If
            fs.Close()
            Console.WriteLine("[TRACE] Closed file: " & path)
        End If
    End Sub

    Private Sub createTxtFile(ByVal path As String, ByVal Points As List(Of DataFormat.finalResultData))
        If Me.InvokeRequired Then
            Me.Invoke(New createTxtKMLFileDelegate(AddressOf createTxtFile), New Object() {path, Points})
        Else
            Dim fs As FileStream = File.Create(path)
            For Each item In Points
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(item.Id & vbTab & item.Latitude & vbTab & item.Longitude & vbTab & item.Accuracy & vbCrLf)
                fs.Write(info, 0, info.Length)
            Next
            fs.Close()
        End If
    End Sub

End Class
