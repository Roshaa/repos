Module Module1

    Sub Main()

        Dim array() As String = {"John Smith", "Jane Smith", "Philip Burton", "Fred Bloggs"}

        For i As Integer = 0 To array.Length - 1
            Console.WriteLine(array(i))
        Next
        Dim names(,) As String = {{"John", "Doe"}, {"Jane", "Doe"}, {"Alice", "Smith"}, {"Bob", "Johnson"}}

        For i As Integer = 0 To names.GetUpperBound(0)
            For j As Integer = 0 To names.GetUpperBound(1)
                Console.WriteLine(names(i, j) & " ")
            Next
            Console.WriteLine()
        Next


    End Sub

End Module
