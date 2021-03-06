﻿Imports System.IO

Public Class Calculate
    Dim sim As New Form1.SimData

    Private Sub swap(ByRef A, ByRef B)
        Dim temp
        temp = A
        A = B
        B = temp
    End Sub

    Private Sub printArray(ByVal array)
        Dim text As String = ""
        Console.WriteLine("---------")
        For i = 0 To array.GetLength(0) - 1
            text += array(i) & "|"
            Console.WriteLine(text)
            text = ""
        Next
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
        'Console.WriteLine("-----")
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
            Case 4
                While (Not sorted)
                    sorted = True
                    For i = 1 To array.Length - 1
                        If array(i).rFromCenter < array(i - 1).rFromCenter Then
                            swap(array(i), array(i - 1))
                            sorted = False
                        End If
                    Next
                End While
            Case Else

        End Select
    End Sub

    Public Function middleCombination(ByVal dataStation As Array, ByVal calcMode As Integer) As Array
        'printStation(dataStation)
        bubbleSort(dataStation, 3)
        'printStation(dataStation)
        Dim dataCount As Integer
        Select Case calcMode
            Case 0
                dataCount = 2
            Case 1
                dataCount = 4
            Case 2
                dataCount = 3
            Case Else
                Return {}
        End Select
        If dataStation.GetLength(0) < dataCount Then
            Return Nothing
        End If
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
        'Condition: V Z X Y W
        For i = 2 To dataStation.GetLength(0) - 1
            'Console.WriteLine(i + 1)
            'Console.WriteLine(minDiff & "||" & dataStation(i).TOA - dataStation(i - 1).TOA)
            If minDiff > dataStation(i).TOA - dataStation(i - 1).TOA Then     'MinDiff > DTOA stasiun i - (i-1)
                'Console.WriteLine("MULAI")
                minDiff = dataStation(i).TOA - dataStation(i - 1).TOA
                If i = dataStation.Length - 1 Then
                    'Console.WriteLine("AKHIR")
                    iData(0) = i - 1
                    For j = 1 To dataCount - 1
                        If j < dataCount - 1 Then
                            iData(j) = i - dataCount + j
                        Else
                            iData(j) = i + 1 - dataCount + j
                        End If
                    Next
                    'printArray(iData)
                Else
                    If dataCount = 2 Then
                        iData(0) = i
                        iData(1) = i - 1
                    End If
                    If dataCount = 3 Then
                        If dataStation(i + 1).TOA - dataStation(i).TOA > dataStation(i - 1).TOA - dataStation(i - 2).TOA Then          ' 1 2 3 4-> 4-3 > 2-1
                            'Console.WriteLine("Y>Z")
                            iData(0) = i - 1
                            iData(1) = i - 2
                            iData(2) = i
                        Else
                            'Console.WriteLine("Z>Y")
                            iData(0) = i
                            iData(1) = i - 1
                            iData(2) = i + 1
                        End If
                    End If
                    If dataCount = 4 Then
                        If dataStation(i + 1).TOA - dataStation(i).TOA > dataStation(i - 1).TOA - dataStation(i - 2).TOA Then           ' 1 2 3 4-> 4-3 > 2-1
                            'Console.WriteLine("Y>Z")
                            iData(0) = i - 1
                            iData(1) = i - 2
                            iData(2) = i
                            If i >= dataCount - 1 Then
                                If dataStation(i + 1).TOA - dataStation(i).TOA < dataStation(i - 2).TOA - dataStation(i - 3).TOA Then
                                    'Console.WriteLine("V>Y")
                                    iData(3) = i + 1
                                Else
                                    'Console.WriteLine("Y>V")
                                    iData(3) = i - 3
                                End If
                            Else
                                'Console.WriteLine("MENTOK BAWAH")
                                iData(3) = i + 1
                            End If
                        Else
                            'Console.WriteLine("Z>Y")
                            iData(0) = i
                            iData(1) = i - 1
                            iData(2) = i + 1
                            If i < dataStation.Length - 2 Then
                                If dataStation(i + 2).TOA - dataStation(i + 1).TOA > dataStation(i - 1).TOA - dataStation(i - 2).TOA Then
                                    'Console.WriteLine("W>Z")
                                    iData(3) = i - 2
                                Else
                                    'Console.WriteLine("Z>W")
                                    iData(3) = i + 2
                                End If
                            Else
                                'Console.WriteLine("MENTOK ATAS")
                                iData(3) = i - 2
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Dim FilteredArray(iData.Length - 1)
        For i = 0 To FilteredArray.Length - 1
            FilteredArray(i) = dataStation(iData(i))
        Next
        'Console.WriteLine(iData(0) & "," & iData(1) & "," & iData(2) & "," & iData(3))
        bubbleSort(dataStation, 0)
        'printStation(dataStation)
        Return FilteredArray
    End Function

    Public Function nearestCombination1(ByVal dataStation As Array, ByVal calcMode As Integer) As Array
        'printStation(dataStation)
        bubbleSort(dataStation, 3)
        'printStation(dataStation)
        Dim dataCount As Integer
        Select Case calcMode
            Case 1
                dataCount = 4
            Case 2
                dataCount = 3
            Case Else
                Return {}
        End Select
        If dataStation.GetLength(0) < dataCount Then
            Return Nothing
        End If

        Dim FilteredArray(dataCount - 1)
        For i = 0 To FilteredArray.Length - 1
            FilteredArray(i) = dataStation(i)
        Next
        'printStation(FilteredArray)
        bubbleSort(dataStation, 0)
        'printStation(dataStation)
        Return FilteredArray
    End Function

    Public Function nearestCombination2(ByVal dataStation As Array, ByVal calcMode As Integer) As Array
        'printStation(dataStation)
        bubbleSort(dataStation, 3)
        'printStation(dataStation)
        Dim dataCount As Integer
        Select Case calcMode
            Case 1
                dataCount = 4
            Case 2
                dataCount = 3
            Case Else
                Return {}
        End Select
        If dataStation.GetLength(0) < dataCount Then
            Return Nothing
        End If

        For index = 0 To dataStation.Length - 1
            dataStation(index).rFromCenter = Busur(dataStation(0).Latitude, dataStation(0).Longitude, dataStation(index).Latitude, dataStation(index).Longitude)
        Next

        bubbleSort(dataStation, 4)

        Dim FilteredArray(dataCount - 1)
        For i = 0 To FilteredArray.Length - 1
            FilteredArray(i) = dataStation(i)
        Next
        'printStation(FilteredArray)
        bubbleSort(dataStation, 0)
        'printStation(dataStation)
        Return FilteredArray
    End Function

    Public Function nearestCombination3(ByVal dataStation As Array, ByVal calcMode As Integer) As Array
        'printStation(dataStation)
        bubbleSort(dataStation, 3)
        'printStation(dataStation)
        Dim dataCount As Integer
        Select Case calcMode
            Case 1
                dataCount = 4
            Case 2
                dataCount = 3
            Case Else
                Return {}
        End Select
        If dataStation.GetLength(0) < dataCount Then
            Return Nothing
        End If

        Dim iData(dataCount - 1) As Integer
        Dim temporary(dataStation.Length - 2)
        For index = 1 To dataStation.Length - 1
            temporary(index - 1) = dataStation(index)
        Next
        Dim secondaryStation(dataCount - 2)
        Select Case dataCount
            Case 3
                secondaryStation = middleCombination(temporary, 0)
            Case 4
                secondaryStation = middleCombination(temporary, 2)
            Case Else
                Return Nothing
        End Select

        Dim FilteredArray(iData.Length - 1)
        FilteredArray(0) = dataStation(0)
        For index = 1 To dataCount - 1
            FilteredArray(index) = secondaryStation(index - 1)
        Next

        'printStation(FilteredArray)
        bubbleSort(dataStation, 0)
        'printStation(dataStation)
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

    Public Function Locate(ByVal dataSet As Array, ByVal locateMode As Integer, ByVal dataStation As Array) As DataFormat.result
        Dim Result As New DataFormat.result
        'printStation(dataSet)
        bubbleSort(dataStation, 3)
        'printStation(dataStation)
        Select Case locateMode
            Case 1
                Result = LinearSpherical(dataSet)
                'printStation(dataSet)
                'printStation(dataStation)
                'Console.WriteLine(Result.Latitude & ", " & Result.Longitude)
            Case 2
                Result = QuadraticPlanar(dataSet)
                'printStation(dataSet)
                'printStation(dataStation)
                'Console.WriteLine(Result.Latitude & ", " & Result.Longitude)
            Case Else
        End Select
        Return Result
    End Function

    Private Function QuadraticPlanar(ByVal dataSet As Array) As DataFormat.result

        Dim c As Decimal = sim.c / 1000
        Dim R As Decimal = sim.R / 1000
        Dim qa(dataSet.Length - 1) As Decimal
        Dim q1 As Decimal
        Dim q2 As Decimal
        Dim ri2(dataSet.Length - 1) As Decimal
        Dim x(dataSet.Length - 1) As Decimal
        Dim y(dataSet.Length - 1) As Decimal
        Dim dTOA(dataSet.Length - 1) As Decimal
        Dim result As New DataFormat.result()
        Dim lightningR As Decimal
        Dim lightningx As Decimal
        Dim lightningy As Decimal

        For i = 0 To dataSet.Length - 1
            dTOA(i) = (dataSet(i).TOA - dataSet(0).TOA)
            x(i) = latLonToXY(dataSet(0).Latitude, dataSet(0).Longitude, dataSet(i).Latitude, dataSet(i).Longitude)(0) / 1000
            y(i) = latLonToXY(dataSet(0).Latitude, dataSet(0).Longitude, dataSet(i).Latitude, dataSet(i).Longitude)(1) / 1000
            ri2(i) = (x(i) * x(i) + y(i) * y(i))
            qa(i) = (ri2(i) - c * c * dTOA(i) * dTOA(i)) / 2
            'Console.WriteLine("----------------" & vbCrLf & x(i) & ", " & y(i) & vbCrLf & dTOA(i) & vbCrLf & ri2(i) & vbCrLf & qa(i))
        Next

        Dim fA As Decimal = c * c * (ri2(2) * dTOA(1) * dTOA(1) - 2 * (x(1) * x(2) + y(1) * y(2)) * dTOA(1) * dTOA(2) + ri2(1) * dTOA(2) * dTOA(2)) - (x(1) * y(2) - y(1) * x(2)) * (x(1) * y(2) - y(1) * x(2))
        Dim fB As Decimal = 2 * c * (-ri2(2) * qa(1) * dTOA(1) + (x(1) * x(2) + y(1) * y(2)) * (qa(1) * dTOA(2) + qa(2) * dTOA(1)) - ri2(1) * qa(2) * dTOA(2))
        Dim fC As Decimal = ri2(2) * qa(1) * qa(1) - 2 * (x(1) * x(2) + y(1) * y(2)) * qa(1) * qa(2) + ri2(1) * qa(2) * qa(2)
        Dim fD As Decimal = fB * fB - 4 * fA * fC

        'Console.WriteLine("---------------" & vbCrLf & fA & vbCrLf & fB & vbCrLf & fC & vbCrLf & fD & vbCrLf)

        Dim r1 = (-fB + Math.Sqrt(fD)) / 2 / fA
        Dim r2 = (-fB - Math.Sqrt(fD)) / 2 / fA
        'Console.WriteLine(r1 & ", " & r2)

        If Not (r1 < 0 And r2 < 0) Then
            If r1 < 0 Then
                lightningR = r2
            ElseIf r2 < 0 Then
                lightningR = r1
            Else
                'Console.WriteLine("Shit Happened: " & r1 & ", " & r2)
                Return result
            End If
            q1 = qa(1) - c * dTOA(1) * lightningR
            q2 = qa(2) - c * dTOA(2) * lightningR

            lightningx = (y(2) * q1 - y(1) * q2) / (x(1) * y(2) - y(1) * x(2)) * 1000
            lightningy = (x(1) * q2 - x(2) * q1) / (x(1) * y(2) - y(1) * x(2)) * 1000

            result.Latitude = xyToLatLon(dataSet(0).Latitude, dataSet(0).Longitude, lightningx, lightningy)(0)
            result.Longitude = xyToLatLon(dataSet(0).Latitude, dataSet(0).Longitude, lightningx, lightningy)(1)
            result.TimeOfOccurence = dataSet(0).TOA - lightningR / c

            result.Latitude = Decimal.Round(result.Latitude, 3)
            result.Longitude = Decimal.Round(result.Longitude, 3)
            'Console.WriteLine("Result: " & result.Latitude & ", " & result.Longitude & vbCrLf & result.TimeOfOccurence)
            'Console.WriteLine(result.Latitude & ", " & result.Longitude)
        End If
        Return result
    End Function

    Private Function LinearSpherical(ByVal dataSet As Array) As DataFormat.result
        Dim c As Decimal = sim.c
        Dim R As Decimal = sim.R
        Dim K(dataSet.Length - 1, 3) As Decimal
        Dim Ri(dataSet.Length - 1, 2) As Decimal
        Dim result As New DataFormat.result()
        For i = 0 To K.GetLength(0) - 1
            K(i, 0) = (Math.Cos(dataSet(i).Latitude * Math.PI / 180) * Math.Cos(dataSet(i).Longitude * Math.PI / 180))
            K(i, 1) = (Math.Cos(dataSet(i).Latitude * Math.PI / 180) * Math.Sin(dataSet(i).Longitude * Math.PI / 180))
            K(i, 2) = (Math.Sin(dataSet(i).Latitude * Math.PI / 180))
            K(i, 3) = (-Math.Cos((c * dataSet(i).TOA) / R))
            Ri(i, 0) = K(i, 0)
            Ri(i, 1) = K(i, 1)
            Ri(i, 2) = K(i, 2)
        Next
        'Console.WriteLine("K")
        'print2D(K)
        Dim rotatedMatrix = Rotate(Ri, -dataSet(0).Longitude, 3)
        rotatedMatrix = Rotate(rotatedMatrix, dataSet(0).Latitude, 2)
        'Console.WriteLine("RM")
        'print2D(rotatedMatrix)
        Dim L(rotatedMatrix.getLength(0) - 2, rotatedMatrix.getLength(1) - 1) As Decimal
        Dim a(rotatedMatrix.getLength(0) - 2, 0) As Decimal
        For i = 0 To L.GetLength(0) - 1
            a(i, 0) = Math.Sin(c * (dataSet(i + 1).TOA - dataSet(0).TOA) / R)
            For j = 0 To L.GetLength(1) - 1
                L(i, j) = rotatedMatrix(i + 1, j)
                If j = 0 Then
                    L(i, j) += -Math.Cos(c * (dataSet(i + 1).TOA - dataSet(0).TOA) / R)
                End If
            Next
        Next

        'Console.WriteLine("L")
        'print2D(L)
        'Console.WriteLine("a")
        'print2D(a)
        Dim inversedL = inverseMatrix(L)
        'Console.WriteLine("iL")
        'print2D(inversedL)
        Dim h = multiplyMatrix(inversedL, a)
        Dim lo_ = Math.Atan2(h(1, 0), h(0, 0))
        Dim la_ = Math.Atan2(h(2, 0) * Math.Cos(lo_), h(0, 0))
        result.TimeOfOccurence = dataSet(0).TOA - R / c * Math.Acos(Math.Cos(la_) * Math.Cos(lo_))

        result.Latitude = Math.Asin(K(0, 2) * Math.Cos(la_) * Math.Cos(lo_) + Math.Cos(dataSet(0).Latitude * Math.PI / 180) * Math.Sin(la_)) * 180 / Math.PI
        Dim LonY = K(0, 1) * Math.Cos(la_) * Math.Cos(lo_) + Math.Cos(dataSet(0).Longitude * Math.PI / 180) * Math.Cos(la_) * Math.Sin(lo_) - K(0, 2) * Math.Sin(dataSet(0).Longitude * Math.PI / 180) * Math.Sin(la_)
        Dim LonX = K(0, 0) * Math.Cos(la_) * Math.Cos(lo_) - Math.Sin(dataSet(0).Longitude * Math.PI / 180) * Math.Cos(la_) * Math.Sin(lo_) - K(0, 2) * Math.Cos(dataSet(0).Longitude * Math.PI / 180) * Math.Sin(la_)
        result.Longitude = Math.Atan2(LonY, LonX) * 180 / Math.PI

        result.Latitude = Decimal.Round(result.Latitude, 3)
        result.Longitude = Decimal.Round(result.Longitude, 3)
        'Console.WriteLine("result: " & result.Latitude & ", " & result.Longitude & ", " & result.TimeOfOccurence)
        Return result
    End Function

    Private Function LinearSphericalTrace(ByVal dataSet As Array) As DataFormat.result
        Dim c As Decimal = sim.c
        Dim R As Decimal = sim.R
        Dim K(dataSet.Length - 1, 3) As Decimal
        Dim Ri(dataSet.Length - 1, 2) As Decimal
        Dim result As New DataFormat.result()
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
        Dim rotatedMatrix = Rotate(Ri, -dataSet(0).Longitude, 3)
        rotatedMatrix = Rotate(rotatedMatrix, dataSet(0).Latitude, 2)
        Console.WriteLine("RM")
        print2D(rotatedMatrix)
        Dim L(rotatedMatrix.getLength(0) - 2, rotatedMatrix.getLength(1) - 1) As Decimal
        Dim a(rotatedMatrix.getLength(0) - 2, 0) As Decimal
        For i = 0 To L.GetLength(0) - 1
            a(i, 0) = Math.Sin(c * (dataSet(i + 1).TOA - dataSet(0).TOA) / R)
            For j = 0 To L.GetLength(1) - 1
                L(i, j) = rotatedMatrix(i + 1, j)
                If j = 0 Then
                    L(i, j) += -Math.Cos(c * (dataSet(i + 1).TOA - dataSet(0).TOA) / R)
                End If
            Next
        Next

        Console.WriteLine("L")
        print2D(L)
        Console.WriteLine("a")
        print2D(a)
        Dim inversedL = inverseMatrix(L)
        Console.WriteLine("iL")
        print2D(inversedL)
        Dim h = multiplyMatrix(inversedL, a)
        Dim lo_ = Math.Atan2(h(1, 0), h(0, 0))
        Dim la_ = Math.Atan2(h(2, 0) * Math.Cos(lo_), h(0, 0))
        result.TimeOfOccurence = dataSet(0).TOA - R / c * Math.Acos(Math.Cos(la_) * Math.Cos(lo_))

        result.Latitude = Math.Asin(K(0, 2) * Math.Cos(la_) * Math.Cos(lo_) + Math.Cos(dataSet(0).Latitude * Math.PI / 180) * Math.Sin(la_)) * 180 / Math.PI
        Dim LonY = K(0, 1) * Math.Cos(la_) * Math.Cos(lo_) + Math.Cos(dataSet(0).Longitude * Math.PI / 180) * Math.Cos(la_) * Math.Sin(lo_) - K(0, 2) * Math.Sin(dataSet(0).Longitude * Math.PI / 180) * Math.Sin(la_)
        Dim LonX = K(0, 0) * Math.Cos(la_) * Math.Cos(lo_) - Math.Sin(dataSet(0).Longitude * Math.PI / 180) * Math.Cos(la_) * Math.Sin(lo_) - K(0, 2) * Math.Cos(dataSet(0).Longitude * Math.PI / 180) * Math.Sin(la_)
        result.Longitude = Math.Atan2(LonY, LonX) * 180 / Math.PI

        result.Latitude = Decimal.Round(result.Latitude, 3)
        result.Longitude = Decimal.Round(result.Longitude, 3)
        Console.WriteLine("result: " & result.Latitude & ", " & result.Longitude & ", " & result.TimeOfOccurence)
        Return result
    End Function

    Public Function anotherCombination(ByVal dataSet As Array, ByVal dataStation As Array) As DataFormat.result
        Dim result As New DataFormat.result()

        Dim newDataSet(dataSet.Length - 1)
        Select Case dataSet.Length
            Case 3
                For i = 0 To dataStation.Length - 3
                    For j = i + 1 To dataStation.Length - 2
                        For k = j + 1 To dataStation.Length - 1
                            newDataSet(0) = dataStation(j)
                            newDataSet(1) = dataStation(i)
                            newDataSet(2) = dataStation(k)
                            result = QuadraticPlanar(newDataSet)
                            If Not (result.Latitude = 0 And result.Longitude = 0 And result.TimeOfOccurence = 0) Then
                                Return result
                            End If
                        Next
                    Next
                Next
            Case 4
                Return result
            Case Else
                Return result
        End Select
        Return result
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
        Dim transposedRi = transposeMatrix(matrix)
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
        Return transposedMatrix
    End Function

    Private Function multiplyMatrix(ByVal A As Array, ByVal B As Array) As Array
        Dim C(A.GetLength(0) - 1, B.GetLength(1) - 1)
        If A.GetLength(1) = B.GetLength(0) Then
            For i = 0 To C.GetLength(0) - 1
                For j = 0 To C.GetLength(1) - 1
                    C(i, j) = 0
                    For k = 0 To A.GetLength(1) - 1
                        C(i, j) += A(i, k) * B(k, j)
                    Next
                Next
            Next
            Return C
        Else
            Return {}
        End If
    End Function

    Private Function inverseMatrix(ByVal X As Array) As Array
        Dim Inv(X.GetLength(0) - 1, X.GetLength(1) - 1)
        If X.GetLength(0) = 4 Then
            Dim X00 = X(0, 0), X01 = X(0, 1), X02 = X(0, 2), X03 = X(0, 3),
                X10 = X(1, 0), X11 = X(1, 1), X12 = X(1, 2), X13 = X(1, 3),
                X20 = X(2, 0), X21 = X(2, 1), X22 = X(2, 2), X23 = X(2, 3),
                X30 = X(3, 0), X31 = X(3, 1), X32 = X(3, 2), X33 = X(3, 3),
                b00 = (X00 * X11 - X01 * X10), b01 = (X00 * X12 - X02 * X10), b02 = (X00 * X13 - X03 * X10),
                b03 = (X01 * X12 - X02 * X11), b04 = (X01 * X13 - X03 * X11), b05 = (X02 * X13 - X03 * X12),
                b06 = (X20 * X31 - X21 * X30), b07 = (X20 * X32 - X22 * X30), b08 = (X20 * X33 - X23 * X30),
                b09 = (X21 * X32 - X22 * X31), b10 = (X21 * X33 - X23 * X31), b11 = (X22 * X33 - X23 * X32),
                det = b00 * b11 - b01 * b10 + b02 * b09 + b03 * b08 - b04 * b07 + b05 * b06
            If Not det Then
                Return {}
            End If
            det = 1.0 / det
            Inv(0, 0) = (X11 * b11 - X12 * b10 + X13 * b09) * det
            Inv(0, 1) = (X02 * b10 - X01 * b11 - X03 * b09) * det
            Inv(0, 2) = (X31 * b05 - X32 * b04 + X33 * b03) * det
            Inv(0, 3) = (X22 * b04 - X21 * b05 - X23 * b03) * det

            Inv(1, 0) = (X12 * b08 - X10 * b11 - X13 * b07) * det
            Inv(1, 1) = (X00 * b11 - X02 * b08 + X03 * b07) * det
            Inv(1, 2) = (X32 * b02 - X30 * b05 - X33 * b01) * det
            Inv(1, 3) = (X20 * b05 - X22 * b02 + X23 * b01) * det

            Inv(2, 0) = (X10 * b10 - X11 * b08 + X13 * b06) * det
            Inv(2, 1) = (X01 * b08 - X00 * b10 - X03 * b06) * det
            Inv(2, 2) = (X30 * b04 - X31 * b02 + X33 * b00) * det
            Inv(2, 3) = (X21 * b02 - X20 * b04 - X23 * b00) * det

            Inv(3, 0) = (X11 * b07 - X10 * b09 - X12 * b06) * det
            Inv(3, 1) = (X00 * b09 - X01 * b07 + X02 * b06) * det
            Inv(3, 2) = (X31 * b01 - X30 * b03 - X32 * b00) * det
            Inv(3, 3) = (X20 * b03 - X21 * b01 + X22 * b00) * det

        ElseIf X.GetLength(0) = 3 Then
            Dim X0 = X(0, 0), X01 = X(0, 1), X02 = X(0, 2),
                X10 = X(1, 0), X1 = X(1, 1), X12 = X(1, 2),
                X20 = X(2, 0), X21 = X(2, 1), X2 = X(2, 2)

            Dim det = X0 * (X1 * X2 - X21 * X12) - (X10) * (X01 * X2 - X21 * X02) + X20 * (X01 * X12 - X1 * X02)
            Inv(0, 0) = (X1 * X2 - X12 * X21) / det
            Inv(1, 0) = -(X10 * X2 - X12 * X20) / det
            Inv(2, 0) = (X10 * X21 - X1 * X20) / det
            Inv(0, 1) = -(X01 * X2 - X02 * X21) / det
            Inv(1, 1) = (X0 * X2 - X02 * X20) / det
            Inv(2, 1) = -(X0 * X21 - X01 * X20) / det
            Inv(0, 2) = (X01 * X12 - X02 * X1) / det
            Inv(1, 2) = -(X0 * X12 - X02 * X10) / det
            Inv(2, 2) = (X0 * X1 - X01 * X10) / det
        End If

        Return Inv
    End Function
End Class
