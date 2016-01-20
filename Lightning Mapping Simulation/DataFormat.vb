Public Class DataFormat

    Public Class dataSets
        Public Latitude As Decimal
        Public Longitude As Decimal
        Public TOA As Decimal
    End Class

    Public Class Station
        Public Property id As Integer
        Public Property Latitude As Decimal
        Public Property Longitude As Decimal
        Public TOA As Decimal
    End Class

    Public Class StationsData
        Public Sub New(ByVal id As Integer, ByVal lat As Decimal, ByVal lon As Decimal)
            _id = id
            _lat = lat
            _lon = lon
        End Sub

        Private _id As String
        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Private _lat As Decimal
        Public Property Latitude() As String
            Get
                Return _lat
            End Get
            Set(ByVal value As String)
                _lat = value
            End Set
        End Property

        Private _lon As Decimal
        Public Property Longitude() As String
            Get
                Return _lon
            End Get
            Set(ByVal value As String)
                _lon = value
            End Set
        End Property
    End Class

    Public Class result
        Public Latitude As Decimal
        Public Longitude As Decimal
        Public TimeOfOccurence As Decimal
        Public Accuracy As Decimal
    End Class

    Public Class finalResultData
        Public Sub New(ByVal id As Integer, ByVal lat As Decimal, ByVal lon As Decimal, ByVal acc As Decimal)
            _id = id
            _lat = lat
            _lon = lon
            _acc = acc
        End Sub

        Private _id As String
        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Private _lat As Decimal
        Public Property Latitude() As String
            Get
                Return _lat
            End Get
            Set(ByVal value As String)
                _lat = value
            End Set
        End Property

        Private _lon As Decimal
        Public Property Longitude() As String
            Get
                Return _lon
            End Get
            Set(ByVal value As String)
                _lon = value
            End Set
        End Property

        Private _acc As Decimal
        Public Property Accuracy() As String
            Get
                Return _acc
            End Get
            Set(ByVal value As String)
                _acc = value
            End Set
        End Property
    End Class

End Class
