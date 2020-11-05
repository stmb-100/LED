Public Class LED
    Private _LEDVersion As String
    Private _LEDColorOn As Color
    Private _LEDColorOff As Color
    Private _LEDValue As Boolean
    Private _LEDBlink As Boolean
    Private _LEDBlinkInterval As Integer
    Private _LEDOnOff As Integer

    Public Enum LEDForms
        Rund
        Eckig
    End Enum

    Private _LEDForm As LEDForms
    Private Sub LED_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _LEDColorOn = Color.White
        _LEDColorOff = Color.Gray
        _LEDValue = False

        _LEDForm = LEDForms.Rund
        _LEDBlinkInterval = 500
        _LEDBlink = False

        _LEDVersion = "V 1.1"

        Me.Height = 21
        Me.Width = 21

        OvalShape1.FillStyle = PowerPacks.FillStyle.Solid
        RectangleShape1.FillStyle = PowerPacks.FillStyle.Solid
        OvalShape1.FillColor = Color.Silver
        RectangleShape1.FillColor = Color.Silver

        OvalShape1.Height = 20
        OvalShape1.Width = 20

        RectangleShape1.Height = 20
        RectangleShape1.Width = 20

        Me.LEDForm = _LEDForm
        Me.LEDColorOff = _LEDColorOff
        Me.LEDColorOn = _LEDColorOn

        Timer1.Interval = _LEDBlinkInterval

    End Sub

    Public Property LEDBlink As Boolean

        Get
            Return _LEDBlink
        End Get
        Set(value As Boolean)
            _LEDBlink = value

            If _LEDBlink = True Then
                Timer1.Enabled = True
                Timer1.Start()
            Else
                Timer1.Enabled = False
                Timer1.Stop()
            End If
        End Set
    End Property

    Public Property LEDBlinkInterval() As Integer

        Get
            Return _LEDBlinkInterval
        End Get

        Set(value As Integer)
            _LEDBlinkInterval = value
            Timer1.Interval = _LEDBlinkInterval
        End Set

    End Property


    Public ReadOnly Property LEDVersion() As String
        Get
            Return _LEDVersion
        End Get
    End Property

    Public Property LEDForm() As LEDForms

        Get
            Return _LEDForm
        End Get

        Set(value As LEDForms)
            _LEDForm = value

            If _LEDForm = LEDForms.Rund Then
                OvalShape1.Visible = True
                RectangleShape1.Visible = False
            End If

            If _LEDForm = LEDForms.Eckig Then
                OvalShape1.Visible = False
                RectangleShape1.Visible = True
            End If

        End Set
    End Property

    Public Property LEDValue() As Boolean
        Get
            Return _LEDValue
        End Get
        Set(value As Boolean)
            _LEDValue = value

            If _LEDValue = True Then
                OvalShape1.FillColor = _LEDColorOn
                RectangleShape1.FillColor = _LEDColorOn
            Else
                OvalShape1.FillColor = _LEDColorOff
                RectangleShape1.FillColor = _LEDColorOff
            End If

        End Set
    End Property

    Public Property LEDOnOff() As Integer
        Get
            Return _LEDOnOff
        End Get

        Set(value As Integer)
            _LEDOnOff = value

            If _LEDOnOff = 1 Then
                OvalShape1.FillColor = _LEDColorOn
                RectangleShape1.FillColor = _LEDColorOn
            Else
                OvalShape1.FillColor = _LEDColorOff
                RectangleShape1.FillColor = _LEDColorOff
            End If

        End Set
    End Property

    Public Property LEDColorOn() As Color
        Get
            Return _LEDColorOn
        End Get
        Set(value As Color)
            _LEDColorOn = value
        End Set
    End Property

    Public Property LEDColorOff() As Color
        Get
            Return _LEDColorOff
        End Get
        Set(value As Color)
            _LEDColorOff = value
        End Set
    End Property

    Private Sub LED_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        OvalShape1.Height = Me.Height - 1
        OvalShape1.Width = Me.Width - 1
        RectangleShape1.Height = Me.Height - 1
        RectangleShape1.Width = Me.Width - 1

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        LEDValue = Not LEDValue

    End Sub
End Class