<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastrarComunicado.aspx.cs" Inherits="Web.Pages.CadastrarComunicado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc2" %>
<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:PainelMensagem ID="pnlMensagem" Titulo="Cadastrar Comunicado" runat="server" />
    <div style="height:700px" class="conteudoPrincipal">
        <table class="formulario">
        <tr>
        <td>
         <asp:Label ID="Label1" runat="server" Text="Título" />  
        </td>
        <td>
        <asp:TextBox ID="txtTitulo" CssClass="textbox" MaxLength="100" Width="400px" runat="server"> </asp:TextBox>
        <span class="campoObrigatorio">*</span>
        </td>
        <td>
            <asp:RequiredFieldValidator CssClass="validator" SetFocusOnError="true" ControlToValidate="txtTitulo" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="O título é obrigatório"></asp:RequiredFieldValidator>
            </td>
        </tr>
        </table>   
        <br />      
        <cc2:Editor ID="Editor1" Width="1000" ClientIDMode="AutoID" Height="500" runat="server" />
        <br />
        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </p>

    </div>
</asp:Content>
