<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrar</title>
    <link href="Styles/Login.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <div style="width: 600px; margin-left: auto; margin-right: auto; height: 227px;">
        <table class="blocoLogin">
            <tr>
            <td rowspan= "4">
            <img src="Images/cadeado.png" alt="" style="height: 170px" />
            </td>
                <td colspan="2">
                    
                   
                        <span style="font-family: 'Helvetica Neue', 'Cooper Black', 'Segoe UI'; font-size: x-large;
                            font-weight: bold; color:Navy">LOGIN - Management Solutions </span>
                        <br />
                        <br />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="label" ID="Label1" runat="server" Text="Usuário"></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="318px" Style="border: 1px solid #ccc;" ID="TxtUsuario" runat="server"
                        MaxLength="20" Height="30px"></asp:TextBox> &nbsp; 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUsuario"
                        CssClass="mensagem" ErrorMessage= "Campo Obrigatório"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
               
                <td>
                    <asp:Label CssClass="label" ID="Label2" runat="server" Text="Senha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="318px" Style="border: 1px solid #ccc;" ID="TxtSenha" runat="server"
                        TextMode="Password" MaxLength="10" Height="30px"></asp:TextBox> &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtSenha"
                        CssClass="mensagem" ErrorMessage="Campo Obrigatório"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                
                <td>
                    <asp:Button CssClass="button" ID="BtnEntrar" runat="server" Text="Entrar"
                        OnClick="BtnEntrar_Click" Height="34px" Width="89px" />
                </td>
                <td>
                    <asp:Label CssClass="mensagem" ID="lblMensagem" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
