<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="AnalisarOcorrencia.aspx.cs" Inherits="Web.Pages.AnalisarOcorrencia" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Analisar Ocorrência" runat="server" />
    <div class="conteudoPrincipal">
        <table>
            <tr>
                <td style="width:500px">
                <table>
                <tr>
                <td>Usuário</td><td>
                    <asp:TextBox ID="txtUsuario" ReadOnly="true" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
                
                </td>
                </tr>
                <tr>
                <td>Tipo</td><td>
                <asp:TextBox ID="txtTipo" ReadOnly="true" CssClass="textbox" runat="server" Width="350px"></asp:TextBox></td></tr>
                <tr><td>Descrição</td>
                <td><asp:TextBox ID="txtDescricao" TextMode="MultiLine" ReadOnly="true" 
                        CssClass="textbox" runat="server" Width="350px" Height="100px"></asp:TextBox></td></tr>
                <tr><td>Status</td><td>

                    <asp:DropDownList ID="ddlStatus" Width="353px" runat="server">
                        <asp:ListItem Value="0">Aberta</asp:ListItem>
                        <asp:ListItem Value="1">Em Andamento</asp:ListItem>
                        <asp:ListItem Value="2">Resolvida</asp:ListItem>
                    </asp:DropDownList>
                    </td></tr>
                    <tr>
                        
                    <td><asp:Button ID="btnAtualizar" CausesValidation="false" runat="server" Text="Atualizar" 
                            onclick="btnAtualizar_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblMensagem" ForeColor="Green" runat="server" Font-Bold="true" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                </td>
                <td style="width:500px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                               <b>Enviar Mensagem para o morador da ocorrência</b> </td>
                        </tr>
                        
                        <tr>
                            <td>
                                Mensagem</td>
                            <td>
                                <asp:TextBox ID="txtMensagem" runat="server" CssClass="textbox" 
                                    Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator CssClass="validator" ControlToValidate="txtMensagem" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="A Mensagem é obrigatória"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnEnviarMensagem" runat="server" 
                                    Text="Enviar Mensagem" onclick="btnEnviarMensagem_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
