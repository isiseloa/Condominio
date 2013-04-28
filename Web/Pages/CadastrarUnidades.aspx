<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarUnidades.aspx.cs" Inherits="Web.Pages.CadastrarUnidades" %>
<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Cadastrar Unidade" runat="server" />
<div class="conteudoPrincipal">
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Número"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNumero" CssClass="textbox" MaxLength="10" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtNumero" ErrorMessage="O Numero é obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Andar"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAndar" CssClass="textbox" MaxLength="2" runat="server"></asp:TextBox>
                     <asp:MaskedEditExtender Mask="99" ID="txtAndar_MaskedEditExtender" runat="server" 
                        TargetControlID="txtAndar" PromptCharacter="">
                    </asp:MaskedEditExtender>
                     <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtAndar" ErrorMessage="O Andar é obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Torre"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTorre" MaxLength="10" CssClass="textbox" runat="server"></asp:TextBox>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
          
        </table>
        <p>
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
            <asp:HiddenField ID="hddId" runat="server" />
            <br />
        </p>
    </div>
</asp:Content>
