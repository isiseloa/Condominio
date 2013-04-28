<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarOcorrencia.aspx.cs" Inherits="Web.Pages.CadastrarOcorrencia" %>
<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="PainelMensagem1" runat="server" Titulo="Registro de Ocorrências" />
    <div class="conteudoPrincipal">    
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" CssClass="textbox" Width="300px" MaxLength="20" runat="server" ReadOnly="true"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Tipo de Ocorrência"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" Width="305px" ID="ddlTipoOcorencia" runat="server">
                        <asp:ListItem Value="2">Reclamação</asp:ListItem>
                        <asp:ListItem Value="1">Manutenção</asp:ListItem>
                        <asp:ListItem>Pedido de revisão de contas</asp:ListItem>
                        <asp:ListItem>Crítica</asp:ListItem>
                        <asp:ListItem>Sugestão</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Detalhes"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDetalhes" CssClass="textbox" Width="300px" MaxLength="2000" 
                        runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>     
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtDetalhes" ErrorMessage="O Detalhe é Obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>               
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                onclick="btnSalvar_Click" />
            <br />
        </p>
    </div>
</asp:Content>
