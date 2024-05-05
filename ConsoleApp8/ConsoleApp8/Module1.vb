Module Module1

    Sub Main()
        Console.WriteLine("this is a computer: ")
        Dim item As New computer()
        Console.WriteLine(item.hardware())
        item.typeofcomputer = "a generic computer"
        Console.WriteLine(item.hardware())
        Console.WriteLine(item.typeofcomputer)
        Console.WriteLine() '


        Console.WriteLine("this is a laptop: ")
        Dim item2 As New laptop()
        Console.WriteLine(item2.hardware())
        item2.typeofcomputer = "a laptop"
        Console.WriteLine(item2.hardware())
        Console.WriteLine(item2.typeofcomputer)
        Console.WriteLine(item2.amimobile)
        Console.WriteLine()

        Console.WriteLine("this is a desktop: ")
        Dim item3 As New desktop()
        Console.WriteLine(item3.hardware())
        item3.typeofcomputer = "a laptop"
        Console.WriteLine(item3.hardware())
        Console.WriteLine(item3.typeofcomputer)
        Console.WriteLine(item3.amimobile)
        Console.WriteLine()
    End Sub

End Module

Class computer 'base class

    Public Property typeofcomputer As String

    Function hardware()
        Return "hardware "
    End Function

    Overridable Function amimobile()
        Return "i dont know"
    End Function
End Class

Class laptop 'derived class
    Inherits computer

    Overrides Function amimobile()
        Return "yes i am mobile "
    End Function
End Class


Class desktop
    Inherits computer

    Overrides Function amimobile()
        Return "no i am not mobile "
    End Function
End Class