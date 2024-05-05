Module Module1

    Sub Main()
        Dim items As Integer() = {1, 2, 3, 4, 5}

        For index = 0 To 4

            Console.WriteLine(items(index))
            If items(index) = 2 Then
                Console.WriteLine("found 2")
            End If

        Next
        Console.Write("loop finished")

        For Each itm As Integer In items
            Console.WriteLine(itm)


        Next
        Console.WriteLine("the length of items is: " & items.Length)

        For x As Integer = 0 To items.Length - 1
            Console.WriteLine(items(x))
        Next

    End Sub

End Module
