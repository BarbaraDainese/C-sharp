<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Representantes.aspx.cs" Inherits="Projeto3.Representantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-60">
        <div class="col-6">
            <div class="box border margin-right-20">
                <h2>Cadastro de representante</h2>
                <br />

                <asp:Label ID="Mensagem" ForeColor="red" Font-Size="16px" runat="server"></asp:Label>
                <br />
                <asp:Label ID="RepresentanteId" Font-Bold="true" Font-Size="20px" runat="server"></asp:Label>
                <br />
                <label>NOME</label>
                <asp:TextBox ID="Nome" MaxLength="255" runat="server"></asp:TextBox>

                <label>E-MAIL</label>
                <asp:TextBox ID="Email" MaxLenght="255" runat="server"></asp:TextBox>

                <label>NOME DE ACESSO</label>
                <asp:TextBox ID="NomeAcesso" runat="server"></asp:TextBox>

                <label>SENHA</label>
                <asp:TextBox ID="Senha" MaxLength="255" runat="server"></asp:TextBox>

                <asp:Button ID="Inserir" OnClick="Inserir_Click" runat="server" Text="Inserir" />
                <asp:Button ID="Excluir" OnClick="Excluir_Click" visible="false" runat="server" Text="Excluir" />
            </div>
        </div>
        <div class ="col-6">
            <div class="box border">
                <asp:GridView ID="ExibirRepresentantes" AutoGenerateColumns="true" OnSelectedIndexChanged="ExibirRepresentantes_SelectedIndexChanged" width="100%" AutoGenerateSelectButton="true" CellPadding="8" BorderColor="#c0" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
