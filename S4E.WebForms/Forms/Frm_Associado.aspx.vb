Imports System.Net.Http
Imports System.Threading.Tasks
Imports S4E.WebForms.Models
Imports S4E.WebForms.Models.Dto
Imports S4E.WebForms.Models.Dto.AssociadoDto
Imports S4E.WebForms.Models.Dto.EmpresaDto
Imports S4E.WebForms.Services

Public Class Frm_Associado
    Inherits System.Web.UI.Page

    Private Property _associado As Associado
    Private Property _associadoService As AssociadoService
    Public Sub New()
        _associadoService = New AssociadoService
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Lbl_Id.Text = "ID do Associado: "
            Lbl_Nome.Text = "Nome"
            Lbl_Cpf.Text = "CPF"
            Lbl_DataDeNascimento.Text = "Data de Nascimento"
            Lbl_Empresas.Text = "Empresas relacioandas (Coloque o id das empresas separados por virgula. Ex: 1,2,3...)"
            Btn_Atualizar.Text = "Atualizar"
            Btn_Excluir.Text = "Excluir"
            PreencheCabecalhoTabelaEmpresas()

            Dim idAssociado As String = Request("id")
            Dim cpfAssociado As String = Request("cpf")
            If Not String.IsNullOrEmpty(idAssociado) Then
                _associado = _associadoService.RecuperaAssociadoPorId(idAssociado)
                If _associado.Id > 0 Then
                    PreencheDadosAssociado(_associado)
                Else
                    Lbl_Id.Text = "Associado não encontrado "
                End If
            Else
                _associado = _associadoService.RecuperaAssociadoPorCPF(cpfAssociado)
                If _associado.Id > 0 Then
                    PreencheDadosAssociado(_associado)
                Else
                    Lbl_Id.Text = "Associado não encontrado "
                End If
            End If

            Lbl_Msg.Text = ""
        End If
    End Sub

    Private Sub PreencheDadosAssociado(associado As Associado)
        Tbl_Empresas.HorizontalAlign = HorizontalAlign.Center
        Lbl_Id.Text = "ID do Associado: " + associado.Id.ToString
        Txt_Nome.Text = associado.Nome
        Txt_Cpf.Text = associado.Cpf
        Txt_DataDeNascimento.Text = associado.DataDeNascimento.ToString
        Txt_Empresas.Text = ""
        For Each empresa In associado.Empresas
            Txt_Empresas.Text += $"{empresa.Id}, "
            PreenceTabelaEmpresas(empresa)
        Next
    End Sub

    Private Sub PreencheCabecalhoTabelaEmpresas()
        Dim cabecalho As New TableRow()
        Dim CabecalhoEmpresas As New TableCell()
        CabecalhoEmpresas.Controls.Add(New LiteralControl("Empresas(ID)"))
        Dim CabecalhoNome As New TableCell()
        CabecalhoNome.Controls.Add(New LiteralControl("Nome"))
        Dim CabecalhoCnpj As New TableCell()
        CabecalhoCnpj.Controls.Add(New LiteralControl("CNPJ"))

        cabecalho.Cells.Add(CabecalhoEmpresas)
        cabecalho.Cells.Add(CabecalhoNome)
        cabecalho.Cells.Add(CabecalhoCnpj)

        Tbl_Empresas.Rows.Add(cabecalho)
    End Sub

    Private Sub PreenceTabelaEmpresas(empresas As ReadEmpresaDto)
        Dim row As New TableRow()
        Dim empresaId As New TableCell()
        Dim empresaNome As New TableCell()
        Dim empresaCnpj As New TableCell()
        empresaId.Controls.Add(New LiteralControl(empresas.Id.ToString))
        empresaNome.Controls.Add(New LiteralControl(empresas.Nome))
        empresaCnpj.Controls.Add(New LiteralControl(empresas.Cnpj))

        row.Cells.Add(empresaId)
        row.Cells.Add(empresaNome)
        row.Cells.Add(empresaCnpj)

        Tbl_Empresas.Rows.Add(row)
    End Sub

    Protected Sub Btn_Atualizar_Click(sender As Object, e As EventArgs) Handles Btn_Atualizar.Click
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
        Dim id As Integer = Val(Lbl_Id.Text.Replace("ID do Associado: ", ""))
        _associadoService.AtualizaAssociado(id, associadoDto)
        _associado = _associadoService.RecuperaAssociadoPorId(id)
        PreencheDadosAssociado(_associado)
        Lbl_Msg.Text = "Associado atualizado com sucesso."
    End Sub

    Protected Sub Btn_Excluir_Click(sender As Object, e As EventArgs) Handles Btn_Excluir.Click
        Dim id As Integer = Val(Lbl_Id.Text.Replace("ID do Associado: ", ""))
        _associadoService.DeletaAssociado(id)
        Response.Redirect("https://localhost:44336/Forms/Frm_Associados.aspx")
    End Sub
End Class