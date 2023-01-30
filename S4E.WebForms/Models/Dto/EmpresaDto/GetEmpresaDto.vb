﻿Imports System.ComponentModel.DataAnnotations

Namespace Models.Dto.EmpresaDto


    Public Class GetEmpresaDto

        <Required>
        Public Property Id As Integer

        <Required>
        <MaxLength(200, ErrorMessage:="O nome não pode ter mais de 200 caracteres")>
        Public Property Nome As String
        <Required>
        <StringLength(14, ErrorMessage:="O CNPJ deve ter 14 caracteres")>
        Public Property Cnpj As String

        Public Property Associados As ICollection(Of Integer)

        Public Sub New()
            Associados = New HashSet(Of Integer)
        End Sub
    End Class
End Namespace