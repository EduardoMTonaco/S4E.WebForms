Public Class Frm_index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Lbl_BuscaAssocaidoPorId.Text = "Buscar Associado Por ID"
        Lbl_BuscaAssocaidoPorCPF.Text = "Buscar Associado Por CPF"
        Lbl_BuscaAssocaidosPorNome.Text = "Buscar Associados Por Nome"
        Lbl_BuscaEmpresaPorId.Text = "Buscar Empresa por ID"
        Lbl_BuscaEmpresaPorCnpj.Text = "Buscar empresa por CNPJ"
        Lbl_BuscaEmpresasPorNome.Text = "Buscar Empresas por Nome"

        Dim buscar As String = "Buscar"
        Btn_BuscarAssociadoPorID.Text = buscar
        Btn_BuscarAssociadoPorCpf.Text = buscar
        Btn_BuscarAssociadosPorNome.Text = buscar

        Btn_BuscarEmpresaPorID.Text = buscar
        Btn_BuscarEmpresaPorCnpj.Text = buscar
        Btn_BuscarEmpresasPorNome.Text = buscar
    End Sub

    Protected Sub Btn_BuscarAssociadoPorID_Click(sender As Object, e As EventArgs) Handles Btn_BuscarAssociadoPorID.Click

        Dim id As Integer = Val(Txt_AssociadoId.Text)
        Response.Redirect("https://localhost:44336/Forms/Frm_Associado.aspx?id=" + id.ToString)
    End Sub

    Protected Sub Btn_BuscarAssociadosPorNome_Click(sender As Object, e As EventArgs) Handles Btn_BuscarAssociadosPorNome.Click
        Dim nome As String = Txt_AssociadosPorNome.Text
        nome = nome.Replace(" ", "-")
        Response.Redirect("https://localhost:44336/Forms/Frm_Associados.aspx?nome=" + nome.ToString)
    End Sub
    Protected Sub Btn_BuscarAssociadoPorCpf_Click(sender As Object, e As EventArgs) Handles Btn_BuscarAssociadoPorCpf.Click
        Dim cpf As Integer = Val(Txt_AssociadoPorCpf)
        Response.Redirect("https://localhost:44336/Forms/Frm_Associado.aspx?cpf=" + cpf.ToString)
    End Sub

    Protected Sub Btn_BuscarEmpresaPorID_Click(sender As Object, e As EventArgs) Handles Btn_BuscarEmpresaPorID.Click
        Dim id As Integer = Val(Txt_EmpresaId.Text)
        Response.Redirect("https://localhost:44336/Forms/Frm_Empresa.aspx?id=" + id.ToString)
    End Sub

    Protected Sub Btn_BuscarEmpresasPorNome_Click(sender As Object, e As EventArgs) Handles Btn_BuscarEmpresasPorNome.Click
        Dim nome As String = Txt_EmpresasPorNome.Text
        nome = nome.Replace(" ", "-")
        Response.Redirect("https://localhost:44336/Forms/Frm_Empresas.aspx?nome=" + nome.ToString)
    End Sub

    Protected Sub Btn_BuscarEmpresaPorCnpj_Click(sender As Object, e As EventArgs) Handles Btn_BuscarEmpresaPorCnpj.Click
        Dim cnpj As Integer = Val(Txt_EmpresaPorCnpj.Text)
        Response.Redirect("https://localhost:44336/Forms/Frm_Empresa.aspx?cnpj=" + cnpj.ToString)
    End Sub
End Class