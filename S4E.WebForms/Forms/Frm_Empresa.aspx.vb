Imports S4E.WebForms.Models
Imports S4E.WebForms.Models.Dto.AssociadoDto
Imports S4E.WebForms.Models.Dto.EmpresaDto
Imports S4E.WebForms.Services

Public Class Frm_Empresa
    Inherits System.Web.UI.Page

    Private Property _empresaService As EmpresaService
    Private Property _empresa As Empresa

    Public Sub New()
        _empresaService = New EmpresaService
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Lbl_Id.Text = "ID da Empresa: "
            Lbl_Nome.Text = "Nome"
            Lbl_Cnpj.Text = "CNPJ"
            Lbl_Associados.Text = "Associados relacioandos (Coloque o id dos associados separados por virgula. Ex: 1,2,3...)"
            Btn_Atualizar.Text = "Atualizar"
            Btn_Excluir.Text = "Excluir"
            PreencheCabecalhoTabelaEmpresas()

            Dim idEmpresa As String = Request("id")
            Dim cnpjEmpresa As String = Request("cpf")
            If Not String.IsNullOrEmpty(idEmpresa) Then
                _empresa = _empresaService.RecuperaEmpresaPorId(idEmpresa)
                If _empresa.Id > 0 Then
                    PreencheDadosAssociado(_empresa)
                Else
                    Lbl_Id.Text = "Associado não encontrado "
                End If
            Else
                _empresa = _empresaService.RecuperaEmpresaPorCnpj(cnpjEmpresa)
                If _empresa.Id > 0 Then
                    PreencheDadosAssociado(_empresa)
                Else
                    Lbl_Id.Text = "Associado não encontrado "
                End If
            End If

            Lbl_Msg.Text = ""
        End If
    End Sub

    Private Sub PreencheDadosAssociado(empresa As Empresa)
        Tbl_Associados.HorizontalAlign = HorizontalAlign.Center
        Lbl_Id.Text = "ID da Empresa: " + empresa.Id.ToString
        Txt_Nome.Text = empresa.Nome
        Txt_Cnpj.Text = empresa.Cnpj
        Txt_Associados.Text = ""
        For Each associado In empresa.Associados
            Txt_Associados.Text += $"{associado.Id}, "
            PreenceTabelaEmpresas(associado)
        Next
    End Sub

    Private Sub PreencheCabecalhoTabelaEmpresas()
        Dim cabecalho As New TableRow()
        Dim CabecalhoEmpresas As New TableCell()
        CabecalhoEmpresas.Controls.Add(New LiteralControl("Associado(ID)"))
        Dim CabecalhoNome As New TableCell()
        CabecalhoNome.Controls.Add(New LiteralControl("Nome"))
        Dim CabecalhoCnpj As New TableCell()
        CabecalhoCnpj.Controls.Add(New LiteralControl("CPF"))

        cabecalho.Cells.Add(CabecalhoEmpresas)
        cabecalho.Cells.Add(CabecalhoNome)
        cabecalho.Cells.Add(CabecalhoCnpj)

        Tbl_Associados.Rows.Add(cabecalho)
    End Sub

    Private Sub PreenceTabelaEmpresas(associado As ReadAssociadoDto)
        Dim row As New TableRow()
        Dim associadoId As New TableCell()
        Dim associadoNome As New TableCell()
        Dim associadoCpf As New TableCell()
        associadoId.Controls.Add(New LiteralControl(associado.Id.ToString))
        associadoNome.Controls.Add(New LiteralControl(associado.Nome))
        associadoCpf.Controls.Add(New LiteralControl(associado.Cpf))

        row.Cells.Add(associadoId)
        row.Cells.Add(associadoNome)
        row.Cells.Add(associadoCpf)

        Tbl_Associados.Rows.Add(row)
    End Sub

    Protected Sub Btn_Atualizar_Click(sender As Object, e As EventArgs) Handles Btn_Atualizar.Click
        Dim empresaDto As New CreateEmpresaDto

        Dim nome As String = Txt_Nome.Text
        Dim cpf As String = Txt_Cnpj.Text

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
            Dim associadoId = Txt_Associados.Text.Replace(" ", "").Split(",")
            For Each associado In associadoId
                empresas.Add(associado)
            Next
            empresaDto.Associados = empresas
        End If
        empresaDto.Nome = nome
        empresaDto.Cnpj = cpf
        Dim id As Integer = Val(Lbl_Id.Text.Replace("ID da Empresa: ", ""))
        _empresaService.AtualizaEmpresa(id, empresaDto)
        _empresa = _empresaService.RecuperaEmpresaPorId(id)
        PreencheDadosAssociado(_empresa)
        Lbl_Msg.Text = "Empresa atualizada com sucesso."
    End Sub

    Protected Sub Btn_Excluir_Click(sender As Object, e As EventArgs) Handles Btn_Excluir.Click
        Dim id As Integer = Val(Lbl_Id.Text.Replace("ID da Empresa: ", ""))
        _empresaService.DeletaEmpresa(id)
        Response.Redirect("https://localhost:44336/Forms/Frm_Associados.aspx")
    End Sub
End Class