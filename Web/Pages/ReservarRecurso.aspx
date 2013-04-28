<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="ReservarRecurso.aspx.cs" Inherits="Web.Pages.ReservarRecurso" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="PainelMensagem1" Titulo="Reservar recurso do condomínio"
        runat="server" />
    <div class="conteudoPrincipal">
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Usuário"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" CssClass="textbox" Width="300px" MaxLength="20" 
                        runat="server" ReadOnly="True"></asp:TextBox>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Recurso"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRecurso" CausesValidation="false" AutoPostBack="true" 
                        CssClass="textbox" Width="300px" runat="server" 
                        onselectedindexchanged="ddlRecurso_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Salão de jogos</asp:ListItem>
                        <asp:ListItem>Salão de Festas</asp:ListItem>
                        <asp:ListItem>Churrasqueira</asp:ListItem>
                        <asp:ListItem>Home Theater</asp:ListItem>
                        <asp:ListItem>Auditório</asp:ListItem>
                    </asp:DropDownList>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ddlRecurso" Display="Dynamic" ErrorMessage="O Recurso é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Data"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlData" CssClass="textbox" Width="300px" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="ddlData" Display="Dynamic" ErrorMessage="A Data é obrigatória"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </p>
    </div>
</asp:Content>
