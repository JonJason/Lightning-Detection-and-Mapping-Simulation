Public Class Calculate
    Dim sim As New Form1.SimData

    Private Sub swap(ByRef A, ByRef B)
        Dim temp
        temp = A
        A = B
        B = temp
    End Sub

    Public Sub printStation(ByVal array)
        Dim text As String = ""
        Console.WriteLine("---------")
        For i = 0 To array.Length - 1
            text = array(i).id & "|" & array(i).Latitude & "|" & array(i).Longitude & "|" & array(i).TOA
            Console.WriteLine(text)
        Next
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
        Dim indexer(array.Length - 1)
        Select Case sortCol
            Case 0
                While (Not sorted)
                    sorted = True
                    For i = 1 To array.Length - 1
                        If array(i).id < array(i - 1).id Then
                            swap(array(i), array(i - 1))
                            sorted = False
                        End If
                    Next
                End While
            Case 1

            Case 2

            Case 3
                While (Not sorted)
                    sorted = True
                    For i = 1 To array.Length - 1
                        If array(i).TOA < array(i - 1).TOA Then
                            swap(array(i), array(i - 1))
                            sorted = False
                        End If
                    Next
                End While
            Case Else

        End Select
    End Sub

    Public Function DTOAFilter(ByVal dataStation As Array, ByVal calcMode As Integer) As Array
        printStation(dataStation)
        bubbleSort(dataStation, 3)
        printStation(dataStation)
        Dim dataCount As Integer
        Select Case calcMode
            Case 1
                dataCount = 4
            Case 2
                dataCount = 3
            Case Else
                Return {}
        End Select
        Dim minDiff As Decimal = dataStation(1).TOA - dataStation(0).TOA
        Dim iData(dataCount - 1) As Integer
        iData(0) = 1
        For i = 1 To dataCount - 1
            If i <= 1 Then
                iData(i) = i - 1
            Else
                iData(i) = i
            End If
        Next
        For i = 2 To dataStation.GetLength(0) - 1
            Console.WriteLine(i + 1)
            Console.WriteLine(minDiff & "||" & dataStation(i).TOA - dataStation(i - 1).TOA)
            If minDiff > dataStation(i).TOA - dataStation(i - 1).TOA Then     'MinDiff > DTOA stasiun i - (i-1)
                Console.WriteLine("MULAI")
                minDiff = dataStation(i).TOA - dataStation(i - 1).TOA
                If i = dataStation.Length - 1 Then
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
                        If dataStation(i + 1).TOA - dataStation(i).TOA > dataStation(i - 1).TOA - dataStation(i - 2).TOA Then           ' 1 2 3 4-> 4-3 > 2-1
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
                        If dataStation(i + 1).TOA - dataStation(i).TOA > dataStation(i - 1).TOA - dataStation(i - 2).TOA Then           ' 1 2 3 4-> 4-3 > 2-1
                            Console.WriteLine("Y>Z")
                            iData(0) = i - 1
                            iData(1) = i - 2
                            iData(2) = i
                            If i < dataCount - 1 Or dataStation(i + 1).TOA - dataStation(i).TOA < dataStation(i - 2).TOA - dataStation(i - 3).TOA Then
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
                            If i < dataStation.Length - 2 Or dataStation(i + 2).TOA - dataStation(i + 1).TOA > dataStation(i - 1).TOA - dataStation(i - 2).TOA Then
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
        printStation(dataStation)
        Dim FilteredArray(iData.Length - 1)
        For i = 0 To FilteredArray.Length - 1
            FilteredArray(i) = dataStation(iData(i))
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

    Private Function LinearSpherical(ByVal dataSet As Array) As Array

        Dim arrData(dataSet.GetLength(0) - 1)
        For i = 0 To arrData.Length - 1
            arrData(i) = New DataFormat.dataSets()
            arrData(i).Latitude = dataSet(i, 1)
            arrData(i).Longitude = dataSet(i, 2)
            arrData(i).TOA = dataSet(i, 3)
            MsgBox("Location " & i + 1 & " : " & arrData(i).Latitude & "," & arrData(i).Latitude & vbCrLf & "time: " & arrData(i).TOA)
        Next
        Dim K(dataSet.GetLength(0) - 1, 3)
        'For i = 0 To K.GetLength(0) - 1
        'K(i, 0) = (Math.Cos(dataSet(i, 1) * Math.PI / 180) * Math.Cos(dataSet(i,) / 360 * 2 * Math.PI));
        'K(i, 0) = (Math.Cos(lat[i]/360*2*Math.PI) * Math.Sin(lon[i]/360*2*Math.PI));
        'K(i, 0) = (Math.Sin(lat[i]/360*2*Math.PI));
        'K(i, 0) = (-Math.Cos((c * t_i[i]) / R));
        'Next
        Return {}
    End Function

End Class
