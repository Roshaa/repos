Module Module1

    Sub Main()

        Dim item = New computer("laptop")
        AddHandler item.iamtyping, AddressOf iamtyping_eventhandler

        Dim type As String
        type = item.Type()
        Console.WriteLine("dim type= " & type & "typeofcomputer is :" & item.typeofcomputer)
        item.sound()


        Dim item2 = New computer("desktop")
        type = item2.Type()
        Console.WriteLine("dim type= " & type & "typeofcomputer is :" & item2.typeofcomputer)
        item2.sound()


        Dim item3 = New computer("motorbike")
        type = item3.Type()
        Console.WriteLine("dim type= " & type & "typeofcomputer is :" & item3.typeofcomputer)
        item3.sound()


        Console.WriteLine(grandtotal(9))
    End Sub

    Dim runningtotal As Integer
    Function grandtotal(startwith As Integer)
        runningtotal = 0
        Return addup(startwith)
    End Function

    Function addup(addnumber As Integer)
        runningtotal += addnumber
        If addnumber <= 0 Then
            Return runningtotal
        End If
        Return addup(addnumber - 1)
    End Function

    Sub iamtyping_eventhandler()
        Console.WriteLine("Typing event")
    End Sub

End Module



Class computer

    Public Event iamtyping()

    Public Sub New()
        Console.WriteLine("Constructor")
    End Sub
    Public Sub New(strtypeofcomputer As String)
        Me.New()
        typeofcomputer = strtypeofcomputer
    End Sub
    Private _typeofcomputer As String
    Public Property typeofcomputer As String

        Get
            Select Case _typeofcomputer
                Case "laptop"
                    Return "is a laptop"

                Case "desktop"
                    Return "is a desktop"

                Case Else
                    Return "is unknown"

            End Select
        End Get

        Set(value As String)
            Select Case value

                Case "laptop"
                    _typeofcomputer = value
                Case "desktop"
                    _typeofcomputer = value
                Case Else
                    _typeofcomputer = "unknown"
            End Select

        End Set
    End Property

    Function Type() As String
        'Console.WriteLine("Hello World")
        RaiseEvent iamtyping()
        Return "class type "
    End Function

    Sub sound()
        Console.WriteLine("Sound")
    End Sub

End Class
