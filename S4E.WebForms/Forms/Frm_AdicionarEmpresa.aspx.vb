Imports S4E.WebForms.Models
Imports S4E.WebForms.Models.Dto.AssociadoDto
Imports S4E.WebForms.Models.Dto.EmpresaDto
Imports S4E.WebForms.Services

Public Class Frm_AdicionarEmpresa
    Inherits System.Web.UI.Page

    Private Property _empresa As Empresa
    Private Property _empresaService As EmpresaService
    Public Sub New()
        _empresaService = New EmpresaService
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Lbl_Nome.Text = "Nome"
        Lbl_Cnpj.Text = "CNPJ"
        Lbl_Associados.Text = "Associados relacioandos (Coloque o id dos associados separados por virgula. Ex: 1,2,3...)"
        Btn_Adicionar.Text = "Adicionar"
        Lbl_Msg.Text = ""
    End Sub

    Protected Sub Btn_Adicionar_Click(sender As Object, e As EventArgs) Handles Btn_Adicionar.Click
        Dim empresaDto As New CreateEmpresaDto

        Dim nome As String = Txt_Nome.Text
        Dim cnpj As String = Txt_Cnpj.Text

        If String.IsNullOrEmpty(Txt_Nome.Text) Then
            Lbl_Msg.Text = "O campo nome não pode estar vazio"
            Return
        End If
        If String.IsNullOrEmpty(Txt_Cnpj.Text) Then
            Lbl_Msg.Text = "O campo CNPJ não pode estar vazio"
            Return
        End If
        If Not String.IsNullOrEmpty(Txt_Associados.Text) Then
            Dim empresas As New HashSet(Of Integer)
            Dim associadosId = Txt_Associados.Text.Replace(" ", "").Split(",")
            For Each associado In associadosId
                empresas.Add(associado)
            Next
            empresaDto.Associados = empresas
        End If
        empresaDto.Nome = nome
        empresaDto.Cnpj = cnpj
        _empresa = _empresaService.AdicionaEmpresa(empresaDto)
        Lbl_Msg.Text = "Associado adicinado com sucesso."
        PreenchendoCabecalhoTabela()
        PreencheTabelaComAssociado()
    End Sub

    Private Sub PreenchendoCabecalhoTabela()
        Tbl_Empresa.Rows.Clear()
        Dim cabecalho As New TableRow()
        Dim CabecalhoId As New TableCell()
        CabecalhoId.Controls.Add(New LiteralControl("ID"))
        Dim CabecalhoNome As New TableCell()
        CabecalhoNome.Controls.Add(New LiteralControl("Nome"))
        Dim CabecalhoCpf As New TableCell()
        CabecalhoCpf.Controls.Add(New LiteralControl("CPF"))
        Dim CabecalhoEmpresas As New TableCell()
        CabecalhoEmpresas.Controls.Add(New LiteralControl("Empresas(ID)"))
        cabecalho.Cells.Add(CabecalhoId)
        cabecalho.Cells.Add(CabecalhoNome)
        cabecalho.Cells.Add(CabecalhoCpf)
        cabecalho.Cells.Add(CabecalhoEmpresas)
        Tbl_Empresa.Rows.Add(cabecalho)
    End Sub

    Private Sub PreencheTabelaComAssociado()
        Dim row As New TableRow()
        Dim EmpresaId As New TableCell()
        Dim EmpresaNome As New TableCell()
        Dim EmpresaCnpj As New TableCell()
        Dim AssociadoEmpresa As New TableCell()


        EmpresaId.Controls.Add(New LiteralControl(_empresa.Id.ToString))
        EmpresaCnpj.Controls.Add(New LiteralControl(_empresa.Nome))
        EmpresaNome.Controls.Add(New LiteralControl(_empresa.Cnpj))

        Dim ListaDeAssociados As String = ""
        For Each associado In _empresa.Associados
            ListaDeAssociados += associado.Id.ToString + ", "
        Next
        If Not String.IsNullOrEmpty(ListaDeAssociados) Then
            ListaDeAssociados = ListaDeAssociados.Remove(ListaDeAssociados.LastIndexOf(","))
        End If

        AssociadoEmpresa.Controls.Add(New LiteralControl(ListaDeAssociados))

        row.Cells.Add(EmpresaId)
        row.Cells.Add(EmpresaNome)
        row.Cells.Add(EmpresaCnpj)
        row.Cells.Add(AssociadoEmpresa)
        Tbl_Empresa.Rows.Add(row)
    End Sub

End Class