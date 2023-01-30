Imports System.Net.Http
Imports S4E.WebForms.Models
Imports S4E.WebForms.Services

Public Class index
    Inherits System.Web.UI.Page


    Private Property _associadoService As AssociadoService

    Public Sub New()
        _associadoService = New AssociadoService
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Tbl_Tabela.HorizontalAlign = HorizontalAlign.Center

        Dim nome As String = Request("nome")
        If Not String.IsNullOrEmpty(nome) Then
            nome = nome.Replace("-", " ")
            PreencheTabela(_associadoService.RecuperaAssociadosPorNome(nome))
        Else
            PreencheTabela(_associadoService.RecuperaAssociados)
        End If
    End Sub

    Private Sub PreencheTabela(associados As IEnumerable(Of Associado))

        Tbl_Tabela.Rows.Clear()

        PreenchendoCabecalhoTabela()

        For Each associado In associados

            Dim row As New TableRow()
            Dim AssociadoId As New TableCell()
            Dim AssociadoNome As New TableCell()
            Dim AssociadoCpf As New TableCell()
            Dim AsssociadoDataDeNascimento As New TableCell()
            Dim AssociadoEmpresa As New TableCell()

            Dim VerEditar As TableCell = GerarButtonVerEditar(associado)
            Dim ExcluirCell As TableCell = GerarButtonExcluir(associado)


            AssociadoId.Controls.Add(New LiteralControl(associado.Id.ToString))
            AssociadoCpf.Controls.Add(New LiteralControl(associado.Nome))
            AssociadoNome.Controls.Add(New LiteralControl(associado.Cpf))
            AsssociadoDataDeNascimento.Controls.Add(New LiteralControl(associado.DataDeNascimento))

            Dim listaDeEmpresas As String = ""
            For Each empresa In associado.Empresas
                listaDeEmpresas += empresa.Id.ToString + ", "
            Next
            If Not String.IsNullOrEmpty(listaDeEmpresas) Then
                listaDeEmpresas = listaDeEmpresas.Remove(listaDeEmpresas.LastIndexOf(","))
            End If

            AssociadoEmpresa.Controls.Add(New LiteralControl(listaDeEmpresas))

            row.Cells.Add(AssociadoId)
            row.Cells.Add(AssociadoNome)
            row.Cells.Add(AssociadoCpf)
            row.Cells.Add(AsssociadoDataDeNascimento)
            row.Cells.Add(AssociadoEmpresa)
            row.Cells.Add(VerEditar)
            row.Cells.Add(ExcluirCell)

            Tbl_Tabela.Rows.Add(row)

        Next
    End Sub

    Private Sub PreenchendoCabecalhoTabela()
        Dim cabecalho As New TableRow()
        Dim CabecalhoId As New TableCell()
        CabecalhoId.Controls.Add(New LiteralControl("ID"))
        Dim CabecalhoNome As New TableCell()
        CabecalhoNome.Controls.Add(New LiteralControl("Nome"))
        Dim CabecalhoCpf As New TableCell()
        CabecalhoCpf.Controls.Add(New LiteralControl("CPF"))
        Dim CabecalhoDataDeNascimento As New TableCell()
        CabecalhoDataDeNascimento.Controls.Add(New LiteralControl("Data de Nascimento"))
        Dim CabecalhoEmpresas As New TableCell()
        CabecalhoEmpresas.Controls.Add(New LiteralControl("Empresas(ID)"))
        cabecalho.Cells.Add(CabecalhoId)
        cabecalho.Cells.Add(CabecalhoNome)
        cabecalho.Cells.Add(CabecalhoCpf)
        cabecalho.Cells.Add(CabecalhoDataDeNascimento)
        cabecalho.Cells.Add(CabecalhoEmpresas)
        Tbl_Tabela.Rows.Add(cabecalho)
    End Sub

    Protected Sub Excluir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = sender.ID.Remove(0, sender.id.indexof("_") + 1)
        _associadoService.DeletaAssociado(id)
        PreencheTabela(_associadoService.RecuperaAssociados())
    End Sub

    Protected Sub EditarVer_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = sender.ID.Remove(0, sender.id.indexof("_") + 1)
        Response.Redirect("https://localhost:44336/Forms/Frm_Associado.aspx?id=" + id.ToString)
    End Sub

    Private Function GerarButtonExcluir(associado As Associado) As TableCell

        Dim excluir As New Button()
        excluir.Text = "Excluir"
        excluir.Enabled = True
        excluir.ID = "Excluir_" + associado.Id.ToString
        AddHandler excluir.Click, New System.EventHandler(AddressOf Me.Excluir_Click)
        Dim excluirCell As New TableCell()
        excluirCell.Controls.Add(excluir)
        Return excluirCell
    End Function

    Private Function GerarButtonVerEditar(associado As Associado) As TableCell

        Dim excluir As New Button()
        excluir.Text = "Ver/Editar"
        excluir.Enabled = True
        excluir.ID = "VerEditar_" + associado.Id.ToString
        AddHandler excluir.Click, New System.EventHandler(AddressOf Me.EditarVer_Click)
        Dim verEditar As New TableCell()
        verEditar.Controls.Add(excluir)
        Return verEditar
    End Function

End Class