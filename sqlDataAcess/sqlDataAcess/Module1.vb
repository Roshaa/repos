Module Module1

    Dim sqCon As New SqlClient.SqlConnection("Server=PC1;;Database=AdventureWorks2022; Trusted_Connection=Yes;")
    Dim sqCmd As New SqlClient.SqlCommand
    Dim sdrRow As SqlClient.SqlDataReader


    Sub Main()
        While True
            Console.WriteLine("Enter a command:")
            Dim command As String = Console.ReadLine()

            If command.ToLower() = "exit" Then
                Exit While
            End If

            'switch case menu
            Select Case command.ToLower()

                Case "insert"

                    insertData()

                Case "select"

                    console.writeline("last addresses -> Choose the number of values to display: ")
                    Dim a As Integer = console.readline()
                    SelectData(a)

                Case "selectspecific"

                    console.writeline("Enter the AddressID: ")
                    Dim b As Integer = console.readline()
                    SelectSpecific(b)

                Case "updatespecific"

                    console.writeLine("Enter the AddressID: ")
                    Dim c As Integer = console.readline()
                    updatespecific(c)

                Case "delete"
                    console.writeline("Enter the AddressID: ")
                    Dim d As Integer = console.readline()
                    delete(d)

                Case Else
                    Console.WriteLine("Invalid command")
            End Select

        End While
    End Sub

    Sub insertData()
        sqCon.Open()
        Dim Address = GetAddressInput()

        Dim checkduplicate As String = "select * from Person.Address where AddressLine1 = @addressline1 and AddressLine2 = @addressline2 and City = @city and StateProvinceID = @stateprovinceid and PostalCode = @postalcode"
        Dim sqlquerycmdcheck As New SqlClient.SqlCommand(checkduplicate, sqCon)

        sqlquerycmdcheck.Parameters.AddWithValue("@addressline1", Address.AddressLine1)
        sqlquerycmdcheck.Parameters.AddWithValue("@addressline2", Address.AddressLine2)
        sqlquerycmdcheck.Parameters.AddWithValue("@city", Address.City)
        sqlquerycmdcheck.Parameters.AddWithValue("@stateprovinceid", Address.StateProvinceID)
        sqlquerycmdcheck.Parameters.AddWithValue("@postalcode", Address.PostalCode)

        Dim sdrRowcheck As SqlClient.SqlDataReader = sqlquerycmdcheck.ExecuteReader()

        If Not sdrRowcheck.HasRows Then

            sdrRowcheck.Close()
            Dim query As String = "INSERT INTO Person.Address (AddressLine1, AddressLine2,City,StateProvinceID,PostalCode)
VALUES (@inputaddressline1, @inputaddressline2, @inputcity, @inputstateprovinceid,@inputpostalcode)"
            Dim sqlquerycmd As New SqlClient.SqlCommand(query, sqCon)

            sqlquerycmd.Parameters.AddWithValue("@inputaddressline1", Address.AddressLine1)
            sqlquerycmd.Parameters.AddWithValue("@inputaddressline2", Address.AddressLine2)
            sqlquerycmd.Parameters.AddWithValue("@inputcity", Address.City)
            sqlquerycmd.Parameters.AddWithValue("@inputstateprovinceid", Address.StateProvinceID)
            sqlquerycmd.Parameters.AddWithValue("@inputpostalcode", Address.PostalCode)

            sqlquerycmd.ExecuteNonQuery()
        Else
            Console.Writeline("Data already exists")
        End If
        sdrRowcheck.Close()
        sqCon.Close()
    End Sub

    Sub SelectData(a)
        sqCon.Open()
        sqCmd.Connection = sqCon
        sqCmd.CommandText = String.Format("select top {0} * from Person.Address order by AddressID desc", a)


        sqCmd.ExecuteNonQuery()
        sdrRow = sqCmd.ExecuteReader()

        For Each itm In sdrRow
            Console.WriteLine("{0} {1} {2}", sdrRow.GetValue(0), sdrRow.GetValue(1), sdrRow.GetValue(2))
        Next

        sdrRow.Close()
        sqCon.Close()
    End Sub

    Sub SelectSpecific(b)
        sqCon.Open()
        sqCmd.Connection = sqCon
        sqCmd.CommandText = String.format("select * from person.address where AddressID = {0}", b)

        sqCmd.executeNonQuery()
        sdrRow = sqCmd.ExecuteReader()
        For Each item In sdrRow
            Console.Writeline("{0} {1} {2} {3}", sdrRow.getvalue(0), sdrRow.getvalue(1), sdrRow.getvalue(2), sdrRow.getvalue(3))
        Next


        sdrRow.Close()
        sqCon.Close()
    End Sub

    Sub updatespecific(c)
        sqCon.Open()
        sqCmd.Connection = sqCon


        Dim newAddress = GetAddressInput()

        Dim query As String = "update Person.Address set AddressLine1 = @newaddressline1, AddressLine2 = @newaddressline2, City = @newcity, StateProvinceID = @newstateprovinceid, PostalCode = @newpostalcode where AddressID = @c"
        Dim sqlquerycmd As New SqlClient.SqlCommand(query, sqCon)

        sqlquerycmd.Parameters.AddWithValue("@newaddressline1", newAddress.AddressLine1)
        sqlquerycmd.Parameters.AddWithValue("@newaddressline2", newAddress.AddressLine2)
        sqlquerycmd.Parameters.AddWithValue("@newcity", newAddress.City)
        sqlquerycmd.Parameters.AddWithValue("@newstateprovinceid", newAddress.StateProvinceID)
        sqlquerycmd.Parameters.AddWithValue("@newpostalcode", newAddress.PostalCode)
        sqlquerycmd.Parameters.AddWithValue("@c", c)

        sqlquerycmd.ExecuteNonQuery()


        sqCmd.CommandText = String.format("select * from person.address where AddressID = {0}", c)
        sqCmd.executeNonQuery()
        sdrRow = sqCmd.ExecuteReader()

        console.writeline("Updated Data")
        For Each item In sdrRow
            Console.Writeline("{0} {1} {2} {3} {4} {5}", sdrRow.getvalue(0), sdrRow.getvalue(1), sdrRow.getvalue(2), sdrRow.getvalue(3), sdrRow.getvalue(4), sdrRow.getvalue(5))
        Next

        sdrRow.Close()
        sqCon.Close()
    End Sub

    Sub delete(d)
        sqCon.Open()
        sqCmd.Connection = sqCon

        Dim query As String = "delete from Person.Address where AddressID = @d"
        Dim sqlquerycmd As New SqlClient.SqlCommand(query, sqCon)


        sqlquerycmd.Parameters.AddWithValue("@d", d)
        sqlquerycmd.executeNonQuery()

        console.writeline("Data Deleted")

        sqCon.Close()

    End Sub




    'Function to get the input from the user, avoids code duplication
    'AddressInput is a structure that holds the input values which is global to the module

    Function GetAddressInput() As AddressInput

        Console.WriteLine("Enter the new AddressLine1")
        Dim newaddressline1 As String = Console.ReadLine()
        Console.WriteLine("Enter the new AddressLine2")
        Dim newaddressline2 As String = Console.ReadLine()
        Console.WriteLine("Enter the new City")
        Dim newcity As String = Console.ReadLine()
        Console.WriteLine("Enter the new StateProvinceID")
        Dim newstateprovinceid As Integer = Console.ReadLine()
        Console.WriteLine("Enter the new PostalCode")
        Dim newpostalcode As Integer = Console.ReadLine()

        Return New AddressInput With {.AddressLine1 = newaddressline1, .AddressLine2 = newaddressline2, .City = newcity, .StateProvinceID = newstateprovinceid, .PostalCode = newpostalcode}
    End Function

    Structure AddressInput
        Public AddressLine1 As String
        Public AddressLine2 As String
        Public City As String
        Public StateProvinceID As Integer
        Public PostalCode As Integer
    End Structure

End Module
