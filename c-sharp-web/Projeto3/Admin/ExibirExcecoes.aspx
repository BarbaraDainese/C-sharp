<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="ExibirExcecoes.aspx.cs" Inherits="Projeto3.ExibirExcecoes1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <asp:Label ID="Excecoes" runat="server"></asp:Label>
        <hr />
        <asp:Button ID="Limpar" CssClass="botao-delete" runat="server" OnClick="Limpar_Click" Text="Button" />
    </div>
</asp:Content>