﻿Public Class Default_Vb
#Region "radcolorpicker-howto-custom-tooltip_2"
	Public Class ColorModel
		Inherits ViewModelBase
		Private currColor As Color
		Public Property CustomColor() As Color
			Get
				Return Me.currColor
			End Get
			Set(value As Color)
				If Me.currColor <> value Then
					Me.currColor = value
					Me.OnPropertyChanged("CustomColor")
				End If
			End Set
		End Property

		Public Property ToolTipString() As String
			Get
				Return m_ToolTipString
			End Get
			Set(value As String)
				m_ToolTipString = Value
			End Set
		End Property
		Private m_ToolTipString As String
	End Class
#End Region
#Region "radcolorpicker-howto-custom-tooltip_4"
	Public Class MainViewModel
		Inherits ViewModelBase
#Region "PrivateFilds"
		Private m_mainPaletteColors As ObservableCollection(Of ColorModel)
		Private m_headerPaletteColors As ObservableCollection(Of ColorModel)
		Private m_standardPaletteColors As ObservableCollection(Of ColorModel)
#End Region

#Region "Constructor"
		Public Sub New()
			m_mainPaletteColors = New ObservableCollection(Of ColorModel)()
			m_headerPaletteColors = New ObservableCollection(Of ColorModel)()
			m_standardPaletteColors = New ObservableCollection(Of ColorModel)()

			GenerateSampleData()
		End Sub
#End Region

#Region "GenerateSampleData"
		Private Sub GenerateSampleData()
			Dim rand As New Random()
			For i As Integer = 0 To 49
				Dim color__1 As New ColorModel() With {
			  .CustomColor = Color.FromArgb(255, CByte(rand.[Next](0, 255)), CByte(rand.[Next](0, 255)), CByte(rand.[Next](0, 255))), _
			  .ToolTipString = "Custom ToolTip " + i
			 }
				Me.m_mainPaletteColors.Add(color_1)
			Next

			For i As Integer = 0 To 9
				Dim color__1 As New ColorModel() With {
			  .CustomColor = Color.FromArgb(255, CByte(rand.[Next](0, 255)), CByte(rand.[Next](0, 255)), CByte(rand.[Next](0, 255))), _
			  .ToolTipString = "Custom ToolTip " + i
			 }
				Me.m_headerPaletteColors.Add(color_1)
			Next

			For i As Integer = 0 To 9
				Dim color__1 As New ColorModel() With {
			  .CustomColor = Color.FromArgb(255, CByte(rand.[Next](0, 255)), CByte(rand.[Next](0, 255)), CByte(rand.[Next](0, 255))), _
			  .ToolTipString = "Custom ToolTip " + i
			 }
				Me.m_standardPaletteColors.Add(color_1)
			Next
		End Sub
#End Region

#Region "Properties"
		Public Property MainPaletteColors() As ObservableCollection(Of ColorModel)
			Get
				Return Me.m_mainPaletteColors
			End Get
			Set(value As ObservableCollection(Of ColorModel))
				If Me.m_mainPaletteColors <> value Then
					Me.m_mainPaletteColors = value
					Me.OnPropertyChanged("MainPaletteColors")
				End If
			End Set
		End Property

		Public Property StandardPaletteColors() As ObservableCollection(Of ColorModel)
			Get
				Return Me.m_standardPaletteColors
			End Get
			Set(value As ObservableCollection(Of ColorModel))
				If Me.m_standardPaletteColors <> value Then
					Me.m_standardPaletteColors = value
					Me.OnPropertyChanged("StandardPaletteColors")
				End If
			End Set
		End Property

		Public Property HeaderPaletteColors() As ObservableCollection(Of ColorModel)
			Get
				Return Me.m_headerPaletteColors
			End Get
			Set(value As ObservableCollection(Of ColorModel))
				If Me.m_headerPaletteColors <> value Then
					Me.m_headerPaletteColors = value
					Me.OnPropertyChanged("HeaderPaletteColors")
				End If
			End Set
		End Property
#End Region
	End Class
#End Region
End Class
