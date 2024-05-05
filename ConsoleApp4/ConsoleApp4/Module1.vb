Module Module1

    Sub Main()


        For index = 1 To 10
            Console.WriteLine(index)
        Next

        For index = 10 To 1 Step -1
            Console.WriteLine(index)
        Next

        Console.WriteLine("Enter a number")
        Dim userinput As String
        Dim val2 As Double
        userinput = Console.ReadLine


        Try
            val2 = CDbl(userinput)
            Console.WriteLine(val2)
        Catch ex As FormatException
            Console.WriteLine("Format exception")
        Catch ex As Exception
            Console.WriteLine("Invalid number")
        Finally
            Console.WriteLine("End of try catch")
        End Try


        While val2 < 20
            Console.WriteLine(val2)
            val2 += 1
        End While

    End Sub

End Module
