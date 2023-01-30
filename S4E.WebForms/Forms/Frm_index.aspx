<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Forms/PaginaMaster.Master" CodeBehind="Frm_index.aspx.vb" Inherits="S4E.WebForms.Frm_index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <asp:Label ID="Lbl_BuscaAssocaidoPorId" runat="server" Text="Lbl_BuscaAssocaidoPorId"></asp:Label>
</p>
<asp:TextBox ID="Txt_AssociadoId" runat="server" Width="36px"></asp:TextBox>
<asp:Button ID="Btn_BuscarAssociadoPorID" runat="server" Text="Btn_BuscarAssociadoPorID" Width="75px" />
<p>
    <asp:Label ID="Lbl_BuscaAssocaidosPorNome" runat="server" Text="Lbl_BuscaAssocaidosPorNome"></asp:Label>
</p>
<asp:TextBox ID="Txt_AssociadosPorNome" runat="server" Width="284px"></asp:TextBox>
<asp:Button ID="Btn_BuscarAssociadosPorNome" runat="server" Text="Btn_BuscarAssociadosPorNome" Width="75px" />
<p>
    <asp:Label ID="Lbl_BuscaAssocaidoPorCPF" runat="server" Text="Lbl_BuscaAssocaidoPorCPF"></asp:Label>
</p>
<asp:TextBox ID="Txt_AssociadoPorCpf" runat="server" Width="284px"></asp:TextBox>
<asp:Button ID="Btn_BuscarAssociadoPorCpf" runat="server" Text="Btn_BuscarAssociadoPorID" Width="75px" />
<p>
    <asp:Label ID="Lbl_BuscaEmpresaPorId" runat="server" Text="Lbl_BuscaEmpresaPorId"></asp:Label>
</p>
<asp:TextBox ID="Txt_EmpresaId" runat="server" Width="36px"></asp:TextBox>
<asp:Button ID="Btn_BuscarEmpresaPorID" runat="server" Text="Btn_BuscarEmpresaPorID" Width="75px" />
<p>
    <asp:Label ID="Lbl_BuscaEmpresasPorNome" runat="server" Text="Lbl_BuscaEmpresasPorNome"></asp:Label>
</p>
<asp:TextBox ID="Txt_EmpresasPorNome" runat="server" Width="284px"></asp:TextBox>
<asp:Button ID="Btn_BuscarEmpresasPorNome" runat="server" Text="Btn_BuscarAssociadosPorNome" Width="75px" />
<p>
    <asp:Label ID="Lbl_BuscaEmpresaPorCnpj" runat="server" Text="Lbl_BuscaAssocaidoPorCPF"></asp:Label>
</p>
<asp:TextBox ID="Txt_EmpresaPorCnpj" runat="server" Width="284px"></asp:TextBox>
<asp:Button ID="Btn_BuscarEmpresaPorCnpj" runat="server" Text="Btn_BuscarEmpresaPorCnpj" Width="75px" />
<p>
</p>
<p>
</p>
</asp:Content>
