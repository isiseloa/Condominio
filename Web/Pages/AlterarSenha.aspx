<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="Web.Pages.AlterarSenha" %>

<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Alterar Senha" runat="server" />
<div class="conteudoPrincipal">
    <table class="formulario">
    <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Senha Atual"></asp:Label>
            
        </td>
        <td><asp:TextBox ID="txtSenhaAtual" TextMode="Password" CssClass="textbox" Width="200px" MaxLength="10" runat="server"></asp:TextBox>
        <span class="campoObrigatorio">*</span>
        </td>
        <td>
            <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Sanha Atual é obrigatória" Display="Dynamic" ControlToValidate="txtSenhaAtual"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" CssClass="validator" runat="server" 
                ErrorMessage="Senha Atual incorreta" ControlToValidate="txtSenhaAtual" 
                Display="Dynamic" onservervalidate="CustomValidator1_ServerValidate" 
                SetFocusOnError="True"></asp:CustomValidator>
        </td>
    </tr>
     <tr>
        <td><asp:Label ID="Label2" runat="server" Text="Nova senha"></asp:Label></td>
        <td><asp:TextBox ID="txtNovaSenha" CssClass="textbox" Width="200px" MaxLength="10" runat="server" 
                TextMode="Password"></asp:TextBox>
                <span class="campoObrigatorio">*</span>
                </td>
        
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Nova Senha obrigatória" CssClass="validator" ControlToValidate="txtNovaSenha" 
                Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
         </td>
    </tr>
     <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Repita a nova senha"></asp:Label></td>
        <td><asp:TextBox ID="txtRepeteNovaSenha" Width="200px" CssClass="textbox" MaxLength="10" runat="server" 
                TextMode="Password"></asp:TextBox>
        <span class="campoObrigatorio">*</span>
        </td>
           <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="Repita a nova senha" CssClass="validator" ControlToValidate="txtRepeteNovaSenha" 
                   Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                   ControlToCompare="txtNovaSenha" ControlToValidate="txtRepeteNovaSenha" 
                   Display="Dynamic" ErrorMessage="Nova Senha Incorreta " CssClass="validator" SetFocusOnError="True"></asp:CompareValidator>
               <asp:CompareValidator ID="CompareValidator2" CssClass="validator" runat="server" 
                   ControlToCompare="txtSenhaAtual" ControlToValidate="txtRepeteNovaSenha" 
                   Display="Dynamic" ErrorMessage="Nova Senha não pode ser igual a senha atual" 
                   Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
         </td>
    </tr>
    </table>
    <p> <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" Text="Salvar" /></p>
   
        

  
   
        

</div>
</asp:Content>
