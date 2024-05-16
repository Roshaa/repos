Imports System.Net.Mime.MediaTypeNames
Imports System.Security

Module Module1

    Sub Main()
        '''''''''''''''''''''''''''''''''''
        '' OBJETIVO
        '' preencher armazem nas linhas conforme tipo de Documento Selecionar para Faturas Recibo e Balcão
        ''
        '' CRIADO POR
        '' 2021.12.29 | anturio | Sandro Pinto
        ''
        '' REGISTO ALTERAÇÕES

        '' START
        ''

        ' declaração variaveis
        Dim _mform As Mainform = mpage
        Dim _ndoc As Integer = 0
        Dim ftr As Data.DataRow = mainformdataset.tables("eft").rows(0)
        Dim ft2r As Data.DataRow = mainformdataset.tables("eft2").rows(0)
        Dim fi As DataTable = mainformdataset.tables("efi")


        _ndoc = _mform.PropTipoDocumento



        ' 'Preenche o armazém do cab e das linhas com base no campo u_armazem (combobox)
        Dim nrarmazem As Integer = cdata.getumvalorinteger("armazem", "TD", "ndoc=" + _ndoc.ToString)


        If ftr("ndoc") = 3 Or ftr("ndoc") = 13 Or ftr("ndoc") = 18 Or ftr("ndoc") = 19 Or ftr("ndoc") = 20 Or ftr("ndoc") = 21 Then
            If nrarmazem = 0 Then
                xcutil.alerta(mpage, "Não encontrei o armazém referente:")
            Else
                For Each fir In fi.Rows()

                    fir("armazem") = nrarmazem

                Next
                Return nrarmazem
            End If

        End If
        Return nrarmazem
    End Sub

End Module
