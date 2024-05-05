Module Module1

    Sub Main()


        Dim mood As String = "happy"
        Dim typeofactivity As String = "fun"



        If mood = "happy" And typeofactivity = "fun" Then
            Console.WriteLine("I am happy and I am having fun")
        ElseIf mood = "happy" And typeofactivity = "boring" Then
            Console.WriteLine("I am happy but I am bored")
        ElseIf mood = "sad" And typeofactivity = "fun" Then
            Console.WriteLine("I am sad but I am having fun")
        ElseIf mood = "sad" And typeofactivity = "boring" Then
            Console.WriteLine("I am sad and I am bored")
        End If

        Select Case mood & "/" & typeofactivity


            Case "happy/fun"
                Console.WriteLine("happy/fun")
            Case "sad/fun"
                Console.WriteLine("sad/fun")
            Case Else
                Console.WriteLine("error")

        End Select




    End Sub

End Module
