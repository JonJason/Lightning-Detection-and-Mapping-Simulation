Public Class myKML
    Public XMLTag As String = "<?xml version=""1.0"" encoding=""UTF-8""?>"

    Dim _kmlTag As New tag()
    Public ReadOnly Property kmlTag() As tag
        Get
            _kmlTag.header = vbCrLf & "<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"" xmlns:kml=""http://www.opengis.net/kml/2.2"" xmlns:atom=""http://www.w3.org/2005/Atom"">"
            _kmlTag.footer = vbCrLf & "</kml>"
            Return _kmlTag
        End Get
    End Property

    Dim _document As New tag()
    Public ReadOnly Property document(ByVal level As Integer) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _document.header = vbCrLf & tab & "<Document>"
            _document.footer = vbCrLf & tab & "</Document>"
            Return _document
        End Get
    End Property

    Dim _placemark As New tag()
    Public ReadOnly Property placemark(ByVal level As Integer) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _placemark.header = vbCrLf & tab & "<Placemark>"
            _placemark.footer = vbCrLf & tab & "</Placemark>"
            Return _placemark
        End Get
    End Property

    Dim _name As New tag()
    Public ReadOnly Property name(ByVal level As Integer, ByVal id As String) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _name.header = vbCrLf & tab & "<name>"
            _name.footer = vbCrLf & tab & "</name>"
            _name.oneline = vbCrLf & tab & "<name>" & id & "</name>"
            Return _name
        End Get
    End Property

    Dim _MultiGeometry As New tag()
    Public ReadOnly Property MultiGeometry(ByVal level As Integer) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _MultiGeometry.header = vbCrLf & tab & "<MultiGeometry>"
            _MultiGeometry.footer = vbCrLf & tab & "</MultiGeometry>"
            Return _MultiGeometry
        End Get
    End Property

    Dim _coordinates As New crdnt()

    Public ReadOnly Property coordinates(ByVal level As Integer, ByVal point As DataFormat.finalResultData, ByVal setting As Form1.SimData) As crdnt
        Get
            Dim tagTab = ""
            addTabTo(tagTab, level)
            Dim crdntTab = ""
            addTabTo(crdntTab, level + 1)

            _coordinates.text = vbCrLf & tagTab & _coordinates.header
            _coordinates.text += vbCrLf & crdntTab & point.Longitude - setting.deltaLon / 2 & "," & point.Latitude + setting.deltaLat / 2 & ",2000"
            _coordinates.text += vbCrLf & crdntTab & point.Longitude + setting.deltaLon / 2 & "," & point.Latitude + setting.deltaLat / 2 & ",2000"
            _coordinates.text += vbCrLf & crdntTab & point.Longitude + setting.deltaLon / 2 & "," & point.Latitude - setting.deltaLat / 2 & ",2000"
            _coordinates.text += vbCrLf & crdntTab & point.Longitude - setting.deltaLon / 2 & "," & point.Latitude - setting.deltaLat / 2 & ",2000"
            _coordinates.text += vbCrLf & tagTab & _coordinates.footer
            Return _coordinates
        End Get
    End Property

    Dim _LinearRing As New tag()

    Public ReadOnly Property LinearRing(ByVal level As Integer) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _LinearRing.header = vbCrLf & tab & "<LinearRing>"
            _LinearRing.footer = vbCrLf & tab & "</LinearRing>"

            Return _LinearRing
        End Get
    End Property

    Dim _outerBoundaryIs As New OBI()

    Public ReadOnly Property outerBoundaryIs(ByVal level As Integer) As OBI
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _outerBoundaryIs.header = vbCrLf & tab & "<outerBoundaryIs>"
            _outerBoundaryIs.footer = vbCrLf & tab & "</outerBoundaryIs>"

            Return _outerBoundaryIs
        End Get
    End Property

    Public ReadOnly Property altitudeMode(ByVal level As Integer, ByVal mode As String) As String
        Get
            Dim altText As String = vbCrLf
            addTabTo(altText, level)
            altText += "<altitudeMode>" & mode & "</altitudeMode>"
            Return altText
        End Get
    End Property

    Public ReadOnly Property Extrude(ByVal level As Integer) As String
        Get
            Dim extrudeText As String = vbCrLf
            addTabTo(extrudeText, level)
            extrudeText += "<extrude>1</extrude>"
            Return extrudeText
        End Get
    End Property

    Dim _plgn As New polygon()

    Public ReadOnly Property plgn(ByVal level As Integer) As polygon
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _plgn.header = vbCrLf & tab & "<Polygon>"
            _plgn.footer = vbCrLf & tab & "</Polygon>"

            Return _plgn
        End Get
    End Property

    Public Class crdnt
        Public header As String = "<coordinates>"
        Public footer As String = "</coordinates>"
        Public text As String
    End Class

    Public Class tag
        Public header As String
        Public footer As String
        Public oneline As String
    End Class

    Public Class OBI
            Public header = "<outerBoundaryIs>"
            Public footer = "</outerBoundaryIs>"
        End Class

    Public Class polygon
        Public header = "<Polygon>"
        Public footer = "</Polygon>"
    End Class

    Public Class style
        Public Sub New(ByVal id As String, ByVal lineWidth As Integer, ByVal color As String)
            _id = id
            _lineWidth = lineWidth
            _color = color
        End Sub
        Dim _id, _lineWidth, _color
        Dim kml As String
        Dim header As String = "<Style>"
        Dim footer As String = "</Style>"

        Public ReadOnly Property KMLText(ByVal level As Integer) As String
            Get
                kml = vbCrLf
                addTabTo(kml, level)
                kml += header
                If Not IsNothing(_id) Then
                    kml = kml.Substring(0, kml.IndexOf(">"))
                    kml += " id=""" & _id & """>"
                End If
                If Not IsNothing(_lineWidth) Then
                    kml += vbCrLf
                    addTabTo(kml, level + 1)
                    kml += "<LineStyle>"
                    kml += vbCrLf
                    addTabTo(kml, level + 2)
                    kml += "<width>" & _lineWidth & "</width>"
                    kml += vbCrLf
                    addTabTo(kml, level + 1)
                    kml += "</LineStyle>"
                End If
                If Not IsNothing(_color) Then
                    kml += vbCrLf
                    addTabTo(kml, level + 1)
                    kml += "<PolyStyle>"
                    kml += vbCrLf
                    addTabTo(kml, level + 2)
                    kml += "<color>" & _color & "</color>"
                    kml += vbCrLf
                    addTabTo(kml, level + 1)
                    kml += "</PolyStyle>"
                End If
                kml += vbCrLf
                addTabTo(kml, level)
                kml += footer
                Return kml
            End Get
        End Property
        Public ReadOnly Property styleUrl(ByVal level As String) As String
            Get
                Dim styleUrlText = vbCrLf
                addTabTo(styleUrlText, level)
                styleUrlText += "<styleUrl>#" & _id & "</styleUrl>"
                Return styleUrlText
            End Get
        End Property
    End Class

    Shared Sub addTabTo(ByRef text As String, ByVal count As Integer)
        For index = 1 To count
            text += vbTab
        Next
    End Sub
End Class
