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
        Public Property TOA As Decimal
    End Class

    Public Class StationsData
        Public Sub New(ByVal id As Integer, ByVal lat As Decimal, ByVal lon As Decimal)
            _id = id
            _lat = lat
            _lon = lon
        End Sub

        Private _id As Integer
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Private _lat As Decimal
        Public Property Latitude() As Decimal
            Get
                Return _lat
            End Get
            Set(ByVal value As Decimal)
                _lat = value
            End Set
        End Property

        Private _lon As Decimal
        Public Property Longitude() As Decimal
            Get
                Return _lon
            End Get
            Set(ByVal value As Decimal)
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

        Private _id As Integer
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Private _lat As Decimal
        Public Property Latitude() As Decimal
            Get
                Return _lat
            End Get
            Set(ByVal value As Decimal)
                _lat = value
            End Set
        End Property

        Private _lon As Decimal
        Public Property Longitude() As Decimal
            Get
                Return _lon
            End Get
            Set(ByVal value As Decimal)
                _lon = value
            End Set
        End Property

        Private _acc As Decimal
        Public Property Accuracy() As Decimal
            Get
                Return _acc
            End Get
            Set(ByVal value As Decimal)
                _acc = value
            End Set
        End Property
    End Class

    Public Class SphericalCoord
        Dim _latitude As Decimal
        Dim _longitude As Decimal
        Dim _altitude As Decimal
        Public Property Latitude() As Decimal
            Get
                Return _latitude
            End Get
            Set(value As Decimal)
                _latitude = value
            End Set
        End Property
        Public Property Longitude() As Decimal
            Get
                Return _longitude
            End Get
            Set(value As Decimal)
                _longitude = value
            End Set
        End Property
        Public Property altitude() As Decimal
            Get
                Return _altitude
            End Get
            Set(value As Decimal)
                _altitude = value
            End Set
        End Property
    End Class
End Class
