Module Module1

    Sub Main()

        Dim animal As New wildanimal("lion")
        AddHandler animal.Soundcalled, AddressOf Soundcalled_eventhandler
        Console.WriteLine("Animal class output :" & animal.typeofmammal)
        Console.WriteLine("soundevent :" & animal.Soundevent)
        Console.WriteLine(animal.amiwild)

        Dim animal3 As New tameanimal("cat")
        AddHandler animal3.Soundcalled, AddressOf Soundcalled_eventhandler
        Console.WriteLine("Animal class output :" & animal3.typeofmammal)
        Console.WriteLine("soundevent :" & animal3.Soundevent)
        Console.WriteLine(animal3.amiwild)

        Dim animal2 As New tameanimal("fish")
        AddHandler animal2.Soundcalled, AddressOf Soundcalled_eventhandler
        Console.WriteLine("Animal class output :" & animal2.typeofmammal)
        Console.WriteLine("soundevent :" & animal2.Soundevent)
        Console.WriteLine(animal2.amiwild)

        Dim animal4 As New Mammal("elephant")
        AddHandler animal4.Soundcalled, AddressOf Soundcalled_eventhandler
        Console.WriteLine("Animal class output :" & animal4.typeofmammal)
        Console.WriteLine("soundevent :" & animal4.Soundevent)
        Console.WriteLine(animal4.amiwild)



    End Sub
    Sub Soundcalled_eventhandler()
        Console.WriteLine("Sound was called")
    End Sub
End Module



Public Class Mammal

    Private _typeofmammal As String
    Public Sub New(strtypeofcomputer As String)
        typeofmammal = strtypeofcomputer
    End Sub
    Public Property typeofmammal As String

        Get
            Return _typeofmammal
        End Get

        Set(value As String)

            If value = "fish" Then
                _typeofmammal = "not a mammal"
            Else
                _typeofmammal = value
            End If
        End Set
    End Property
    Public Event Soundcalled()
    Function Soundevent() As String
        RaiseEvent Soundcalled()
        Select Case typeofmammal
            Case _typeofmammal = "lion"
                Return "roar"
            Case _typeofmammal = "dog"
                Return "bark"
            Case _typeofmammal = "fish"
                Return "not a mammal"
            Case Else
                Return "noise"
        End Select
    End Function

    Overridable Function amiwild()
        Return "i dont know"
    End Function

End Class


Public Class wildanimal
    Inherits Mammal
    Public Sub New(strtypeofanimal As String)
        MyBase.New(strtypeofanimal)
    End Sub
    Overrides Function amiwild()
        Return "I am a wild animal"
    End Function
End Class

Public Class tameanimal
    Inherits Mammal
    Public Sub New(strtypeofanimal As String)
        MyBase.New(strtypeofanimal)
    End Sub

    Overrides Function amiwild()
        Return "I am a tame animal"
    End Function
End Class