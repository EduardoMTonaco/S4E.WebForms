Imports S4E.WebForms.Models
Imports S4E.WebForms.Services

Public Class Frm_Empresas
    Inherits System.Web.UI.Page

    Private Property _empresaService As EmpresaService

    Public Sub New()
        _empresaService = New EmpresaService
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Tbl_Tabela.HorizontalAlign = HorizontalAlign.Center

        Dim nome As String = Request("nome")
        If Not String.IsNullOrEmpty(nome) Then
            nome = nome.Replace("-", " ")
            PreencheTabela(_empresaService.RecuperaEmpresasPorNome(nome))
        Else
            PreencheTabela(_empresaService.RecuperaEmpresas)
        End If
    End Sub


    Private Sub PreencheTabela(empresas As IEnumerable(Of Empresa))

        Tbl_Tabela.Rows.Clear()

        PreenchendoCabecalhoTabela()

        For Each empresa In empresas

            Dim row As New TableRow()
            Dim EmpresaId As New TableCell()
            Dim EmpresaNome As New TableCell()
            Dim EmpresaCnpj As New TableCell()
            Dim AssociadoEmpresa As New TableCell()

            Dim VerEditar As TableCell = GerarButtonVerEditar(empresa)
            Dim ExcluirCell As TableCell = GerarButtonExcluir(empresa)


            EmpresaId.Controls.Add(New LiteralControl(empresa.Id.ToString))
            EmpresaCnpj.Controls.Add(New LiteralControl(empresa.Nome))
            EmpresaNome.Controls.Add(New LiteralControl(empresa.Cnpj))

            Dim listaDeEmpresas As String = ""
            For Each associado In empresa.Associados
                listaDeEmpresas += associado.Id.ToString + ", "
            Next
            If Not String.IsNullOrEmpty(listaDeEmpresas) Then
                listaDeEmpresas = listaDeEmpresas.Remove(listaDeEmpresas.LastIndexOf(","))
            End If

            AssociadoEmpresa.Controls.Add(New LiteralControl(listaDeEmpresas))

            row.Cells.Add(EmpresaId)
            row.Cells.Add(EmpresaNome)
            row.Cells.Add(EmpresaCnpj)
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
        Dim CabecalhoCnpj As New TableCell()
        CabecalhoCnpj.Controls.Add(New LiteralControl("CNPJ"))
        Dim CabecalhoAssociados As New TableCell()
        CabecalhoAssociados.Controls.Add(New LiteralControl("Associados(ID)"))
        cabecalho.Cells.Add(CabecalhoId)
        cabecalho.Cells.Add(CabecalhoNome)
        cabecalho.Cells.Add(CabecalhoCnpj)
        cabecalho.Cells.Add(CabecalhoAssociados)
        Tbl_Tabela.Rows.Add(cabecalho)
    End Sub

    Protected Sub Excluir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = sender.ID.Remove(0, sender.id.indexof("_") + 1)
        _empresaService.DeletaEmpresa(id)
        PreencheTabela(_empresaService.RecuperaEmpresas())
    End Sub

    Protected Sub EditarVer_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Integer = sender.ID.Remove(0, sender.id.indexof("_") + 1)
        Response.Redirect("https://localhost:44336/Forms/Frm_Empresa.aspx?id=" + id.ToString)
    End Sub

    Private Function GerarButtonExcluir(empresa As Empresa) As TableCell

        Dim excluir As New Button()
        excluir.Text = "Excluir"
        excluir.Enabled = True
        excluir.ID = "Excluir_" + empresa.Id.ToString
        AddHandler excluir.Click, New System.EventHandler(AddressOf Me.Excluir_Click)
        Dim excluirCell As New TableCell()
        excluirCell.Controls.Add(excluir)
        Return excluirCell
    End Function

    Private Function GerarButtonVerEditar(empresa As Empresa) As TableCell

        Dim excluir As New Button()
        excluir.Text = "Ver/Editar"
        excluir.Enabled = True
        excluir.ID = "VerEditar_" + empresa.Id.ToString
        AddHandler excluir.Click, New System.EventHandler(AddressOf Me.EditarVer_Click)
        Dim verEditar As New TableCell()
        verEditar.Controls.Add(excluir)
        Return verEditar
    End Function


End Class