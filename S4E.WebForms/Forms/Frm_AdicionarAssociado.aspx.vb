Imports S4E.WebForms.Models
Imports S4E.WebForms.Models.Dto.AssociadoDto
Imports S4E.WebForms.Services

Public Class Frm_AdicionarAssociado
    Inherits System.Web.UI.Page
    Private Property _associado As Associado
    Private Property _associadoService As AssociadoService
    Public Sub New()
        _associadoService = New AssociadoService
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Lbl_Nome.Text = "Nome"
        Lbl_Cpf.Text = "CPF"
        Lbl_DataDeNascimento.Text = "Data de Nascimento"
        Lbl_Empresas.Text = "Empresas relacioandas (Coloque o id das empresas separados por virgula. Ex: 1,2,3...)"
        Btn_Adicionar.Text = "Adicionar"
        Lbl_Msg.Text = ""
    End Sub

    Protected Sub Btn_Adicionar_Click(sender As Object, e As EventArgs) Handles Btn_Adicionar.Click
        Dim associadoDto As New CreateAssociadoDto

        Dim nome As String = Txt_Nome.Text
        Dim cpf As String = Txt_Cpf.Text
        Dim dataDeNascimento As String = Txt_DataDeNascimento.Text

        If String.IsNullOrEmpty(Txt_Nome.Text) Then
            Lbl_Msg.Text = "O campo nome não pode estar vazio"
            Return
        End If
        If String.IsNullOrEmpty(Txt_Cpf.Text) Then
            Lbl_Msg.Text = "O campo CPF não pode estar vazio"
            Return
        End If
        If Not String.IsNullOrEmpty(Txt_Empresas.Text) Then
            Dim empresas As New HashSet(Of Integer)
            Dim empresasId = Txt_Empresas.Text.Replace(" ", "").Split(",")
            For Each empresa In empresasId
                empresas.Add(empresa)
            Next
            associadoDto.EmpresasId = empresas
        End If
        associadoDto.Nome = nome
        associadoDto.Cpf = cpf
        associadoDto.DataDeNascimento = dataDeNascimento
        _associado = _associadoService.AdicionaAssociado(associadoDto)
        Lbl_Msg.Text = "Associado adicinado com sucesso."
        PreenchendoCabecalhoTabela()
        PreencheTabelaComAssociado()
    End Sub

    Private Sub PreenchendoCabecalhoTabela()
        Tbl_Associado.Rows.Clear()
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
        Tbl_Associado.Rows.Add(cabecalho)
    End Sub

    Private Sub PreencheTabelaComAssociado()
        Dim row As New TableRow()
        Dim AssociadoId As New TableCell()
        Dim AssociadoNome As New TableCell()
        Dim AssociadoCpf As New TableCell()
        Dim AsssociadoDataDeNascimento As New TableCell()
        Dim AssociadoEmpresa As New TableCell()


        AssociadoId.Controls.Add(New LiteralControl(_associado.Id.ToString))
        AssociadoCpf.Controls.Add(New LiteralControl(_associado.Nome))
        AssociadoNome.Controls.Add(New LiteralControl(_associado.Cpf))
        AsssociadoDataDeNascimento.Controls.Add(New LiteralControl(_associado.DataDeNascimento))

        Dim listaDeEmpresas As String = ""
        For Each empresa In _associado.Empresas
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
        Tbl_Associado.Rows.Add(row)
    End Sub
End Class