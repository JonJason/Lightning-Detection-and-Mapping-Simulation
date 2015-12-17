Public Class Form1
    Class SimData
        Public CalcMode As Integer
        Public firstLat As Decimal = -7.5
        Public firstLon As Decimal = 105.5
        Public lastLat As Decimal = -6
        Public lastLon As Decimal = 108.5
        Public nIteration As Integer = 1
        Public xDelta As Single = 0.01
        Public yDelta As Single = 0.01
        Public errorTOA As Decimal = 0.000001
        Public c As Decimal = 300000000
        Public R As Decimal = 6367000
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim simulation As New SimData
        Dim calc As New Calculate
        Dim dataSet As Array
        Dim arcDistance As Decimal
        simulation.CalcMode = 1   'Linear Spherical Method

        Dim stations = {
            {1, -6.9867, 106.5558, vbNull},
            {2, -7.3259, 107.7953, vbNull},
            {3, -6.1647, 107.2979, vbNull},
            {4, -6.7588, 108.4802, vbNull},
            {5, -6.127, 106.2472, vbNull}
        }

        For iIteration = 1 To simulation.nIteration
            For iStation = 0 To stations.GetLength(0) - 1
                arcDistance = calc.Busur(stations(iStation, 1), stations(iStation, 2), -7.5, 105.5)
                stations(iStation, 3) = arcDistance / simulation.c
            Next
            dataSet = calc.DTOAFilter(stations, simulation.CalcMode)
            calc.print2D(dataSet)

        Next
        For Each item In stations
            'Console.WriteLine(item)
        Next
    End Sub

End Class
