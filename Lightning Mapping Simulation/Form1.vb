Public Class Form1
    Class SimData
        Public CalcMode As Integer
        Public firstLat As Decimal = -7.5
        Public firstLon As Decimal = 105.5
        Public lastLat As Decimal = -6
        Public lastLon As Decimal = 108.5
        Public nIteration As Integer = 1
        Public deltaLat As Decimal = 0.5
        Public deltaLon As Decimal = 0.5
        Public errorTOA As Decimal = 0.000001
        Public c As Decimal = 300000000
        Public R As Decimal = 6367000
    End Class



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        Dim simulation As New SimData
        Dim calc As New Calculate
        Dim dataSet As Array
        Dim arcDistance As Decimal
        Dim result As DataFormat.result
        simulation.CalcMode = 1   '1 Linear Spherical Method    2 Quadratic Planar Method

        Dim arrayStation = {
            {1, -6.9867, 106.5558, vbNull},
            {2, -7.3259, 107.7953, vbNull},
            {3, -6.1647, 107.2979, vbNull},
            {4, -6.7588, 108.4802, vbNull},
            {5, -6.127, 106.2472, vbNull}
        }

        Dim stations(arrayStation.GetLength(0) - 1)
        For i = 0 To stations.Length - 1
            stations(i) = New DataFormat.Station()
            stations(i).id = arrayStation(i, 0)
            stations(i).Latitude = arrayStation(i, 1)
            stations(i).Longitude = arrayStation(i, 2)
            stations(i).TOA = arrayStation(i, 3)
        Next
        For simLat = simulation.firstLat To simulation.lastLat
            For simLon = simulation.firstLon To simulation.lastLon
                For iIteration = 1 To simulation.nIteration
                    For iStation = 0 To stations.Length - 1
                        arcDistance = calc.Busur(stations(iStation).Latitude, stations(iStation).Longitude, simLat, simLon)
                        stations(iStation).TOA = arcDistance / simulation.c
                    Next
                    dataSet = calc.DTOAFilter(stations, simulation.CalcMode)
                    calc.printStation(dataSet)
                    result = calc.Locate(dataSet, simulation.CalcMode)
                    MsgBox(result.Latitude & ", " & result.Longitude & vbCrLf & result.TimeOfOccurence)
                Next
                simLon += simulation.deltaLon - 1
            Next simLon
            simLat += simulation.deltaLat - 1
        Next simLat
    End Sub
End Class
