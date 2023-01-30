<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Forms/PaginaMaster.Master" CodeBehind="Frm_Associado.aspx.vb" Inherits="S4E.WebForms.Frm_Associado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p1><asp:Label ID="Lbl_Id" runat="server" Text="Lbl_Id"></asp:Label>&nbsp;<br />
    <br />
    <asp:Label ID="Lbl_Nome" runat="server" Text="Lbl_Nome"></asp:Label></p1><br />
    &nbsp;<asp:TextBox ID="Txt_Nome" runat="server"></asp:TextBox>
        &nbsp;<br />

    <p1><asp:Label ID="Lbl_Cpf" runat="server" Text="Lbl_Cpf"></asp:Label>
    <br />
    </p1><asp:TextBox ID="Txt_Cpf" runat="server"></asp:TextBox>
        <br />

    <p1><asp:Label ID="Lbl_DataDeNascimento" runat="server" Text="Lbl_DataDeNascimento"></asp:Label>
    <br />
    </p1><asp:TextBox ID="Txt_DataDeNascimento" runat="server"></asp:TextBox>
        <br />

    <p1><asp:Label ID="Lbl_Empresas" runat="server" Text="Lbl_Empresas"></asp:Label>
    <br />
    </p1><asp:TextBox ID="Txt_Empresas" runat="server"></asp:TextBox>
        <br />
    <asp:Button ID="Btn_Atualizar" runat="server" Text="Btn_Atualizar" Width="96px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Btn_Excluir" runat="server" Text="Btn_Excluir" Width="96px" />
    <br />
    <asp:Label ID="Lbl_Msg" runat="server" Text="Lbl_Msg"></asp:Label>
        <br />
    <asp:Table ID="Tbl_Empresas" runat="server" CellPadding="5" CellSpacing="5" GridLines="Both">
    </asp:Table>
    <p1>
    <br />
    </p1>
    <br />
&nbsp;

    
    
</asp:Content>
