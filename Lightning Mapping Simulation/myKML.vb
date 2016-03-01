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

    Public ReadOnly Property camera(ByVal level As Integer, ByVal latitude As Decimal, ByVal longitude As Decimal, ByVal altitude As Double, ByVal heading As Double, ByVal tilt As Double, ByVal roll As Double) As String
        Get
            Dim tab As String = ""
            addTabTo(tab, level)
            Dim childTab As String = ""
            addTabTo(childTab, level + 1)

            Dim header = "<Camera>"
            Dim footer = "</Camera>"
            Dim kmlTag = ""

            kmlTag += vbCrLf & tab & header
            kmlTag += vbCrLf & childTab & "<longitude>" & longitude & "</longitude>"
            kmlTag += vbCrLf & childTab & "<latitude>" & latitude & "</latitude>"
            kmlTag += vbCrLf & childTab & "<altitude>" & altitude & "</altitude>"
            kmlTag += vbCrLf & childTab & "<heading>" & heading & "</heading>"
            kmlTag += vbCrLf & childTab & "<tilt>" & tilt & "</tilt>"
            kmlTag += vbCrLf & childTab & "<roll>" & roll & "</roll>"
            kmlTag += Me.altitudeMode(level + 1, "absolute")
            kmlTag += vbCrLf & tab & footer
            Return kmlTag
        End Get
    End Property

    Dim _placemark As New tag()
    Public ReadOnly Property placemark(ByVal level As Integer) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _placemark.header = vbCrLf & tab & " <Placemark> "
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

    Dim _description As New tag()
    Public ReadOnly Property description(ByVal level As Integer, ByVal text As String) As tag
        Get
            Dim tab = ""
            addTabTo(tab, level)
            _name.header = vbCrLf & tab & "<description>"
            _name.footer = vbCrLf & tab & "</description>"
            _name.oneline = vbCrLf & tab & "<description>" & text & "</description>"
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
    Public ReadOnly Property coordinates(ByVal level As Integer, ByVal point As DataFormat.finalResultData, ByVal altitude As Double, ByVal setting As Form1.SimData) As crdnt
        Get
            Dim tagTab = ""
            addTabTo(tagTab, level)
            Dim crdntTab = ""
            addTabTo(crdntTab, level + 1)

            _coordinates.text = vbCrLf & tagTab & _coordinates.header
            _coordinates.text += vbCrLf & crdntTab & point.Longitude - setting.deltaLon / 2 & "," & point.Latitude + setting.deltaLat / 2 & "," & altitude
            _coordinates.text += vbCrLf & crdntTab & point.Longitude + setting.deltaLon / 2 & "," & point.Latitude + setting.deltaLat / 2 & "," & altitude
            _coordinates.text += vbCrLf & crdntTab & point.Longitude + setting.deltaLon / 2 & "," & point.Latitude - setting.deltaLat / 2 & "," & altitude
            _coordinates.text += vbCrLf & crdntTab & point.Longitude - setting.deltaLon / 2 & "," & point.Latitude - setting.deltaLat / 2 & "," & altitude
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

    Public ReadOnly Property point(ByVal level As Integer, ByVal name As String, ByVal latitude As Decimal, ByVal longitude As Decimal, ByVal altitude As Decimal, Optional ByVal description As String = "", Optional ByVal style As iconStyle = Nothing) As String
        Get
            Dim pointTab = ""
            addTabTo(pointTab, level + 1)
            Dim coordTab = ""
            addTabTo(coordTab, level + 2)
            Dim locTab = ""
            addTabTo(locTab, level + 3)

            Dim header = "<Point>"
            Dim footer = "</Point>"
            Dim kmlTag = ""
            kmlTag += Me.placemark(level).header
            kmlTag += Me.name(level + 1, name).oneline
            If description IsNot Nothing Then
                kmlTag += Me.description(level + 1, description).oneline
            End If
            If style IsNot Nothing Then
                kmlTag += style.styleUrl(level + 1)
            End If
            kmlTag += vbCrLf & pointTab & header
            kmlTag += vbCrLf & coordTab & "<coordinates>"
            kmlTag += vbCrLf & locTab & longitude & "," & latitude & "," & altitude
            kmlTag += vbCrLf & coordTab & "</coordinates>"
            kmlTag += vbCrLf & pointTab & footer
            kmlTag += Me.placemark(level).footer
            Return kmlTag
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

    Public Class iconStyle
        Public Sub New(ByVal id As String, ByVal iconUrl As String, Optional ByVal color As String = "99ffffff")
            _id = id
            _iconUrl = iconUrl
            _color = color
        End Sub
        Dim _id, _iconUrl, _color
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
                    kml += " id=""" & _id & """>" & vbCrLf
                End If
                addTabTo(kml, level + 1)
                kml += "<LabelStyle>" & vbCrLf
                addTabTo(kml, level + 2)
                kml += "<color>" & _color & "</color>" & vbCrLf
                addTabTo(kml, level + 2)
                kml += "<colorMode>normal</colorMode>" & vbCrLf
                addTabTo(kml, level + 2)
                kml += "<scale>0.75</scale>" & vbCrLf
                addTabTo(kml, level + 1)
                kml += "</LabelStyle>" & vbCrLf
                addTabTo(kml, level + 1)
                kml += "<IconStyle>" & vbCrLf
                addTabTo(kml, level + 2)
                kml += "<color>" & _color & "</color>" & vbCrLf
                addTabTo(kml, level + 2)
                kml += "<Icon>" & vbCrLf
                addTabTo(kml, level + 3)
                kml += "<href>" & _iconUrl & "</href>" & vbCrLf
                addTabTo(kml, level + 2)
                kml += "</Icon>" & vbCrLf
                addTabTo(kml, level + 1)
                kml += "</IconStyle>" & vbCrLf
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

    Public Class points
        Public header As String = "<Point>"
        Public footer As String = "</Point>"
        Public name As String
        Public latitude As Decimal
        Public longitude As Decimal
        Public description As String
        Public style As String
    End Class

    Shared Sub addTabTo(ByRef text As String, ByVal count As Integer)
        For index = 1 To count
            text += vbTab
        Next
    End Sub
End Class
