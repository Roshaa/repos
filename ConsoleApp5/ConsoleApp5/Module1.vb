Module Module1

    Sub Main()

        Dim number As Double
        Dim number2 As Double

        Console.WriteLine("Enter the number of numbers you want to multiply: ")
        Dim numberofnumbers As Integer = Console.ReadLine

        Dim counter As Integer = 1
        Do While counter <= numberofnumbers

            Try
                Dim input As String = Console.ReadLine()
                Dim success As Boolean = Double.TryParse(input, number)
                number = input

                If Not success Then
                    Console.WriteLine("Invalid input. Please enter a number.")
                    Continue Do
                End If
            Catch ex As Exception
                Console.WriteLine("An error occurred: " & ex.Message)
                Continue Do
            End Try




            If number = 0 Then
                Exit Do
            End If
            If number2 < 1 Then
                number2 = number
            Else
                number2 *= number
            End If
            counter = counter + 1

        Loop

        'For index = 1 To 5
        'number = Console.ReadLine()
        'If number2 < 1 Then
        'number2 = number
        'Else
        ' number2 *= number
        'End If

        'Cons'ole.WriteLine("The product of the numbers is: " & number2)
        'Next
        Console.WriteLine("The output is:" & number2)



    End Sub

End Module
