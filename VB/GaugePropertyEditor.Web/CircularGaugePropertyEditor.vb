﻿Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGauges.Core.Model
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Web.ASPxGauges
Imports DevExpress.Web.ASPxGauges.Gauges.Circular
Imports DevExpress.XtraGauges.Base

<PropertyEditor(GetType(System.Single))> _
 Public Class CircularGaugePropertyEditor
    Inherits WebGaugePropertyEditorBase
    Public Sub New(ByVal objectType As Type, ByVal info As DictionaryNode)
        MyBase.New(objectType, info)
    End Sub
    Public Overrides Sub SetupGaugeCore(ByVal gaugeContainer As ASPxGaugeControl)
        Dim circularGauge As CircularGauge = CType(gaugeContainer.AddGauge(GaugeType.Circular), CircularGauge)
        ' Add the default elements (a scale, background layer, needle and spindle cap).
        circularGauge.AddDefaultElements()
        ' Change the background layer's paint style.
        Dim backgroundCircular As ArcScaleBackgroundLayer = circularGauge.BackgroundLayers(0)
        backgroundCircular.ShapeType = BackgroundLayerShapeType.CircularFull_Style3
        ' Customize the scale's settings.
        Dim scaleCircular As ArcScaleComponent = circularGauge.Scales(0)
        BindableComponent = scaleCircular
        scaleCircular.MinValue = 0
        scaleCircular.MaxValue = 100
        scaleCircular.Value = 0
        scaleCircular.MajorTickCount = 6
        scaleCircular.MajorTickmark.FormatString = "{0:F0}"
        scaleCircular.MajorTickmark.ShapeType = TickmarkShapeType.Circular_Style2_2
        scaleCircular.MajorTickmark.ShapeOffset = -9
        scaleCircular.MajorTickmark.AllowTickOverlap = True
        scaleCircular.MinorTickCount = 3
        scaleCircular.MinorTickmark.ShapeType = TickmarkShapeType.Circular_Style2_1
        ' Change the needle's paint style.
        Dim needle As ArcScaleNeedleComponent = circularGauge.Needles(0)
        needle.ShapeType = NeedleShapeType.CircularFull_Style3
    End Sub
    Protected Overrides Function GetControlValueCore() As Object
        Return (CType(BindableComponent, ArcScaleComponent)).Value
    End Function
    Protected Overrides Sub ReadValueCore()
        CType(BindableComponent, ArcScaleComponent).Value = Convert.ToSingle(PropertyValue)
    End Sub
End Class