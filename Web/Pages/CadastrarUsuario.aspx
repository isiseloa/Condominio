<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastrarUsuario.aspx.cs" Inherits="Web.Pages.CadastrarUsuario" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/jscript">

        function preencherUnidade(id, texto) {

            document.getElementById('<% =hddIdUnidade.ClientID %>').value = id;
            document.getElementById('<% =txtUnidade.ClientID %>').value = texto;
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ClientIDMode="Static" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Cadastrar Usuário" runat="server" />
    <div class="conteudoPrincipal">
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" ClientIDMode="Predictable" CssClass="textbox" Width="300px" MaxLength="20" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtNome" ErrorMessage="O Nome é obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Sobrenome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSobrenome" ClientIDMode="Static" CssClass="textbox" MaxLength="50" runat="server" 
                    Width="300px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" Width="300px" MaxLength="100" CssClass="textbox" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="O Email é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator CssClass="validator" ID="RegularExpressionValidator1"
                        runat="server" ErrorMessage="Digite um email válido" ControlToValidate="txtEmail"
                        Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:CustomValidator CssClass="validator" ID="EmailUnicoValidator" runat="server"
                        ErrorMessage="Já existe um usuário cadastrado com este email" ControlToValidate="txtEmail"
                        Display="Dynamic" SetFocusOnError="True" OnServerValidate="EmailUnicoValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" Width="300px" MaxLength="100" CssClass="textbox" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="O Usuários é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CustomValidator CssClass="validator" ID="UsuarioUnicoValidator" runat="server"
                        ErrorMessage="Já existe um usuário cadastrado com esta identificação" ControlToValidate="txtUsuario"
                        Display="Dynamic" OnServerValidate="UsuarioUnicoValidator_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Unidade"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUnidade" Width="260px" ReadOnly="true" CssClass="textbox" runat="server"></asp:TextBox>
                    
                    <asp:Image ID="Image1" onclick="window.open('ViewUnidades.aspx', 'unidades', 'menubar=0,resizable=0,width=405,height=405');" style="cursor:hand;vertical-align:bottom" ImageUrl="~/Images/qfind.gif" runat="server" />
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:CustomValidator CssClass="validator" ID="unidadeValidator" runat="server"
                        ErrorMessage="A Unidade é Obrigatória"  ControlToValidate="txtUnidade"
                        Display="Dynamic" SetFocusOnError="True" onservervalidate="unidadeValidator_ServerValidate" 
                       ></asp:CustomValidator>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtUnidade" Display="Dynamic" ErrorMessage="A Unidade é obrigatória"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Senha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSenha" MaxLength="20" TextMode="Password" Width="300px" CssClass="textbox" runat="server"></asp:TextBox>
               <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="validator_senha" runat="server"
                        ControlToValidate="txtSenha" Display="Dynamic" ErrorMessage="A Senha é obrigatória"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Tipo do Usuario"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" Width="305px" ID="ddlTipoUsuario" runat="server">
                        <asp:ListItem Value="0">Administrador do Condominio</asp:ListItem>
                        <asp:ListItem Value="1">Responsável pela Unidade</asp:ListItem>
                        <asp:ListItem Value="2">Usuario Comum</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Status"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="textbox" Width="305px" ID="ddlStatusUsuario" runat="server">
                        <asp:ListItem Value="0">Ativo</asp:ListItem>                       
                        <asp:ListItem Value="2">Inativo</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
            <br />
            <asp:HiddenField ID="hddId" runat="server" />
            <asp:HiddenField ID="hddIdUnidade" runat="server" />
        </p>
    </div>
</asp:Content>
