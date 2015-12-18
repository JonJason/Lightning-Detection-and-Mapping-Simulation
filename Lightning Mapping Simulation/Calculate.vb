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
        Dim c As Decimal = sim.c
        Dim R As Decimal = sim.R
        Dim K(dataSet.Length - 1, 3) As Decimal
        Dim Ri(dataSet.Length - 1, 2) As Decimal
        For i = 0 To K.GetLength(0) - 1
            K(i, 0) = (Math.Cos(dataSet(i).Latitude * Math.PI / 180) * Math.Cos(dataSet(i).Longitude * Math.PI / 180))
            K(i, 1) = (Math.Cos(dataSet(i).Latitude * Math.PI / 180) * Math.Sin(dataSet(i).Longitude * Math.PI / 180))
            K(i, 2) = (Math.Sin(dataSet(i).Latitude * Math.PI / 180))
            K(i, 3) = (-Math.Cos((c * dataSet(i).TOA) / R))
            Ri(i, 0) = K(i, 0)
            Ri(i, 1) = K(i, 1)
            Ri(i, 2) = K(i, 2)
        Next
        Console.WriteLine("K")
        print2D(K)
        Console.WriteLine("Ri")
        print2D(Ri)
        Dim rotatedMatrix = Rotate(Ri, -dataSet(0).Longitude, 3)
        Console.WriteLine("rotated")
        print2D(rotatedMatrix)
        rotatedMatrix = Rotate(rotatedMatrix, dataSet(0).Latitude, 2)
        Return {}
    End Function

    Private Function Rotate(ByVal matrix As Array, ByVal angle As Decimal, ByVal axis As Integer)
        angle = angle * Math.PI / 180
        Dim rotateMatrix(2, 2) As Decimal
        For i = 0 To rotateMatrix.GetLength(0) - 1
            For j = 0 To rotateMatrix.GetLength(1) - 1
                rotateMatrix(i, j) = 0
            Next
        Next
        If axis = 1 Then
            rotateMatrix(0, 0) = 1
            rotateMatrix(1, 1) = Math.Cos(angle)
            rotateMatrix(2, 2) = Math.Cos(angle)
            rotateMatrix(1, 2) = -Math.Sin(angle)
            rotateMatrix(2, 1) = Math.Sin(angle)
        ElseIf axis = 2 Then
            rotateMatrix(1, 1) = 1
            rotateMatrix(2, 2) = Math.Cos(angle)
            rotateMatrix(0, 0) = Math.Cos(angle)
            rotateMatrix(2, 0) = -Math.Sin(angle)
            rotateMatrix(0, 2) = Math.Sin(angle)
        ElseIf axis = 3 Then
            rotateMatrix(2, 2) = 1
            rotateMatrix(0, 0) = Math.Cos(angle)
            rotateMatrix(1, 1) = Math.Cos(angle)
            rotateMatrix(0, 1) = -Math.Sin(angle)
            rotateMatrix(1, 0) = Math.Sin(angle)
        Else
            MsgBox("axis Invalid")
        End If
        Console.WriteLine("rotateMatrix")
        print2D(rotateMatrix)
        Dim transposedRi = transposeMatrix(matrix)
        print2D(transposedRi)
        Dim Rxr = multiplyMatrix(rotateMatrix, transposedRi)
        Dim rotatedMatrix = transposeMatrix(Rxr)
        Return rotatedMatrix
    End Function

    Private Function transposeMatrix(ByVal matrix As Array) As Array
        Dim transposedMatrix(matrix.GetLength(1) - 1, matrix.GetLength(0) - 1)
        For i = 0 To matrix.GetLength(0) - 1
            For j = 0 To matrix.GetLength(1) - 1
                transposedMatrix(j, i) = matrix(i, j)
            Next
        Next
        print2D(matrix)
        print2D(transposedMatrix)
        Return transposedMatrix
    End Function

    Private Function multiplyMatrix(ByVal A As Array, ByVal B As Array) As Array
        Dim C(A.GetLength(0) - 1, B.GetLength(1) - 1)
        Console.WriteLine("A")
        print2D(A)
        Console.WriteLine("B")
        print2D(B)
        Console.WriteLine("C")
        print2D(C)
        If A.GetLength(1) = B.GetLength(0) Then
            For i = 0 To C.GetLength(0) - 1
                For j = 0 To C.GetLength(1) - 1
                    C(i, j) = 0
                    For k = 0 To A.GetLength(1) - 1
                        Console.WriteLine("i :" & i & vbCrLf & "j :" & j & vbCrLf & "k :" & k)
                        C(i, j) += A(i, k) * B(k, j)
                        Console.WriteLine(A(i, k))
                        Console.WriteLine(B(k, j))
                        Console.WriteLine(C(i, j))
                    Next
                Next
            Next
            Return C
        Else
            Return {}
        End If
    End Function
End Class
