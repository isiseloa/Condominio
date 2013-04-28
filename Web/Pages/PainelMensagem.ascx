<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PainelMensagem.ascx.cs"
    Inherits="Web.Pages.PainelMensagem" %>
<div id="cabecalho" class="cabecalho">    
    <table>
    <tr>
        <td>
        <asp:Label ID="lblTitulo" runat="server" CssClass="tituloCabecalho" 
                Font-Strikeout="False" Font-Underline="True"></asp:Label>
        </td>
    </tr>
     <tr>
        <td>
        <asp:Label ID="lblMensagem" CssClass="mensagemCabecalho" runat="server" Text=""></asp:Label>

        </td>
    </tr>
    </table>
</div>
