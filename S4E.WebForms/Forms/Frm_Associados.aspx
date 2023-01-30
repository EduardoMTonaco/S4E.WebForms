<%@ Page Title="Index" Language="vb" AutoEventWireup="false" MasterPageFile="~/Forms/PaginaMaster.Master" CodeBehind="Frm_Associados.aspx.vb" Inherits="S4E.WebForms.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p1 style="text-align:center">Lista de Associados<br /></p1>
    <asp:Table ID="Tbl_Tabela" runat="server" BorderStyle="Solid" GridLines="Both" CellPadding="5" CellSpacing="1" >
         <asp:TableRow>
            <asp:TableCell>
                ID
            </asp:TableCell>
            <asp:TableCell>
                Nome
            </asp:TableCell>
            <asp:TableCell>
                CPF
            </asp:TableCell>
            <asp:TableCell>
                Data de Nascimento
            </asp:TableCell>
            <asp:TableCell>
                Empresas
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    &nbsp;


</asp:Content>
