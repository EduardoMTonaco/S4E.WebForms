<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Forms/PaginaMaster.Master" CodeBehind="Frm_AdicionarEmpresa.aspx.vb" Inherits="S4E.WebForms.Frm_AdicionarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p1>
<asp:Label ID="Lbl_Nome" runat="server" Text="Lbl_Nome"></asp:Label>
</p1>
<br />&nbsp;<asp:TextBox ID="Txt_Nome" runat="server"></asp:TextBox>
        &nbsp;<br />
<p1>
<asp:Label ID="Lbl_Cnpj" runat="server" Text="Lbl_Cnpj"></asp:Label>
<br />
</p1>
<asp:TextBox ID="Txt_Cnpj" runat="server"></asp:TextBox>
<br />
<p1>
<asp:Label ID="Lbl_Associados" runat="server" Text="Lbl_Associados"></asp:Label>
<br />
</p1>
<asp:TextBox ID="Txt_Associados" runat="server"></asp:TextBox>
<br />
<asp:Button ID="Btn_Adicionar" runat="server" Text="Btn_Adicionar" Width="96px" />
&nbsp;&nbsp;&nbsp;
    <br />
<asp:Label ID="Lbl_Msg" runat="server" Text="Lbl_Msg"></asp:Label>
<br />
<asp:Table ID="Tbl_Empresa" runat="server" CellPadding="5" CellSpacing="5" GridLines="Both">
</asp:Table>
</asp:Content>
