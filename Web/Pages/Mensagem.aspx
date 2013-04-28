<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Mensagem.aspx.cs" Inherits="Web.Pages.Mensagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conteudoPrincipal" style="padding-top:30px">
    <table>
    <tr>
    <td><asp:Image ID="imgMensagem" Width="50px" Height="50px" runat="server" /></td>        
    <td><asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label></td>
        
    </tr>
    </table>
</div>
</asp:Content>
