Public Class Calculate
    Dim sim As New Form1.SimData

    Private Sub swap(ByRef A, ByRef B)
        Dim temp
        temp = A
        A = B
        B = temp
    End Sub

    Public Sub print2D(ByVal array)
        Dim text As String = ""
        Console.WriteLine("---------")
        For i = 0 To array.GetLength(0) - 1
            For j = 0 To array.GetLength(1) - 1
                text += array(i, j) & "|"
            Next
            Console.WriteLine(text)
            text = ""
        Next
    End Sub

    Private Sub bubbleSort(ByRef array As Array, ByVal sortCol As Integer)
        Dim sorted As Boolean = False
        Dim newIndex(array.GetLength(0)) As Integer
        While (Not sorted)
            sorted = True
            For i = 1 To array.GetLength(0) - 1
                If array(i, sortCol) < array(i - 1, sortCol) Then
                    For j = 0 To array.GetLength(1) - 1
                        swap(array(i, j), array(i - 1, j))
                    Next
                    sorted = False
                End If
            Next
        End While
    End Sub

    Public Function DTOAFilter(ByVal dataStation As Array, ByVal calcMode As Integer) As Array
        bubbleSort(dataStation, 3)
        Dim dataCount As Integer
        Select Case calcMode
            Case 1
                dataCount = 4
            Case 2
                dataCount = 3
            Case Else
                Return {}
        End Select
        Dim minDiff As Decimal = dataStation(1, 3) - dataStation(0, 3)
        Dim iData(dataCount - 1) As Integer
        iData(0) = 1
        For i = 1 To dataCount - 1
            If i <= 1 Then
                iData(i) = i - 1
            Else
                iData(i) = i
            End If
        Next
        print2D(dataStation)
        Console.WriteLine(minDiff)
        For i = 2 To dataStation.GetLength(0) - 1
            Console.WriteLine(minDiff & "||" & dataStation(i, 3) - dataStation(i - 1, 3))
            Console.WriteLine(i + 1)
            If minDiff > dataStation(i, 3) - dataStation(i - 1, 3) Then     'MinDiff > DTOA stasiun i - (i-1)
                Console.WriteLine("MULAI")
                minDiff = dataStation(i, 3) - dataStation(i - 1, 3)
                If i = dataStation.GetLength(0) - 1 Then
                    Console.WriteLine("AKHIR")
                    iData(0) = i - 1
                    For j = 1 To dataCount - 1
                        If j < dataCount - 1 Then
                            iData(j) = i - dataCount + j
                        Else
                            iData(j) = i + 1 - dataCount + j
                        End If
                    Next
                Else
                    If dataCount = 3 Then
                        If dataStation(i + 1, 3) - dataStation(i, 3) > dataStation(i - 1, 3) - dataStation(i - 2, 3) Then           ' 1 2 3 4-> 4-3 > 2-1
                            iData(0) = i - 1
                            iData(1) = i - 2
                            iData(2) = i
                        Else
                            iData(0) = i
                            iData(1) = i - 1
                            iData(2) = i + 1
                        End If
                    End If
                    If dataCount = 4 Then
                        If dataStation(i + 1, 3) - dataStation(i, 3) > dataStation(i - 1, 3) - dataStation(i - 2, 3) Then           ' 1 2 3 4-> 4-3 > 2-1
                            Console.WriteLine("Y>Z")
                            iData(0) = i - 1
                            iData(1) = i - 2
                            iData(2) = i
                            If i < dataCount - 1 Or dataStation(i + 1, 3) - dataStation(i, 3) < dataStation(i - 2, 3) - dataStation(i - 3, 3) Then
                                Console.WriteLine("V>Y")
                                iData(3) = i + 1
                            Else
                                Console.WriteLine("Y>V")
                                iData(3) = i - 3
                            End If
                        Else
                            Console.WriteLine("Z>Y")
                            iData(0) = i
                            iData(1) = i - 1
                            iData(2) = i + 1
                            If i < dataStation.GetLength(0) - 2 Or dataStation(i + 2, 3) - dataStation(i + 1, 3) > dataStation(i - 1, 3) - dataStation(i - 2, 3) Then
                                Console.WriteLine("W>Z")
                                iData(3) = i - 2
                            Else
                                Console.WriteLine("Z>W")
                                iData(3) = i + 2
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Console.WriteLine(iData(0) & "," & iData(1) & "," & iData(2) & "," & iData(3))
        bubbleSort(dataStation, 0)
        print2D(dataStation)
        Dim FilteredArray(iData.Length - 1, dataStation.GetLength(1) - 1)
        For i = 0 To FilteredArray.GetLength(0) - 1
            For j = 0 To FilteredArray.GetLength(1) - 1
                FilteredArray(i, j) = dataStation(iData(i), j)
            Next
        Next
        Return FilteredArray
    End Function

    Public Function xyToLatLon(ByVal lat1 As Decimal, ByVal lon1 As Decimal, ByVal x As Decimal, ByVal y As Decimal) As Array
        Dim R = sim.R

        Dim Lat As Decimal = lat1 + y * 180 / (Math.PI * R)
        Dim Lon As Decimal = lon1 + x * 180 / (Math.PI * R * Math.Cos(lat1 * Math.PI / 180))
        Return {Lat, Lon}
    End Function

    Public Function latLonToXY(ByVal lat1 As Decimal, ByVal lon1 As Decimal, ByVal lat As Decimal, ByVal lon As Decimal) As Array
        Dim R = sim.R
        Dim x = (lon - lon1) * Math.Cos(lat1 * Math.PI / 180) * Math.PI * R / 180
        Dim y = (lat - lat1) * Math.PI * R / 180
        Return {x, y}
    End Function

    Public Function Busur(ByVal lat1 As Decimal, ByVal lon1 As Decimal, ByVal lat2 As Decimal, ByVal lon2 As Decimal) As Decimal
        Dim R = sim.R
        Dim c = sim.c

        Dim Teta = (Math.Sin(lat1 * Math.PI / 180) * Math.Sin(lat2 * Math.PI / 180) + Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) * Math.Cos((lon2 - lon1) * Math.PI / 180))
        If (Teta > 1.0) Then Teta = 1.0
        If (Teta < -1.0) Then Teta = -1.0

        Return Math.Acos(Teta) * R

    End Function

    Public Function Locate(ByVal dataSet As Array, ByVal locateMode As Integer) As Array
        Dim Result As Array
        Select Case locateMode
            Case 1
                Result = LinearSpherical(dataSet)
            Case 2
                Result = QuadraticPlanar(dataSet)
            Case Else
                Result = {}
        End Select
        Return Result
    End Function

    Private Function QuadraticPlanar() As Array

        Return {}
    End Function

    Private Function LinearSpherical() As Array
        Return {}
    End Function
End Class
