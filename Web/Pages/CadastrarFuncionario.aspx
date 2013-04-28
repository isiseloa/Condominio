<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastrarFuncionario.aspx.cs" Inherits="Web.Pages.CadastrarFuncionario" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/funcionario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" ViewStateMode="Enabled" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Cadastro de Funcionário" runat="server" />
    <div class="conteudoPrincipal">
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" MaxLength="100" Width="300px" CssClass="textbox" 
                        runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validator" runat="server"
                        ControlToValidate="txtNome" ErrorMessage="O Nome é obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndereco" CssClass="textbox" Width="300px" MaxLength="200" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validator" runat="server"
                        ControlToValidate="txtEndereco" ErrorMessage="O Endereço é obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="CPF"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCpf" MaxLength="20" Width="300px" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtCpf_MaskedEditExtender" runat="server" Mask="999\.999\.999\-99"
                        TargetControlID="txtCpf" ClearMaskOnLostFocus="False" CultureName="pt-BR" MaskType="Number">
                    </asp:MaskedEditExtender>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validator" runat="server"
                        ControlToValidate="txtCpf" Display="Dynamic" ErrorMessage="O CPF é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="RG"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRG" CssClass="textbox" Width="300px" MaxLength="20" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtRG" Display="Dynamic" ErrorMessage="O RG é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Telefone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefone" CssClass="textbox" MaxLength="20" Width="300px" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="txtTelefone" Display="Dynamic" ErrorMessage="O Telefone é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Data de Nascimento"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDataNascimento" Width="260px" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtDataNascimento_MaskedEditExtender" runat="server"
                        Mask="99/99/9999" MaskType="Date" TargetControlID="txtDataNascimento" UserDateFormat="DayMonthYear">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender PopupButtonID="img1" ID="txtSenha_CalendarExtender" runat="server"
                        TargetControlID="txtDataNascimento">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="img1" Style="vertical-align: bottom" CausesValidation="false"
                        ImageUrl="~/Images/btn_off_Cal.gif" runat="server" />
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="txtDataNascimento" Display="Dynamic" ErrorMessage="A Data de Nascimento é obrigatória"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="validator" ErrorMessage="Data Inválida"
                        OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Data de Admissão"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDataContratacao" Width="260px" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtDataContratacao_MaskedEditExtender" runat="server"
                        Mask="99/99/9999" MaskType="Date" TargetControlID="txtDataContratacao" UserDateFormat="DayMonthYear">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender PopupButtonID="img2" ID="txtDataContratacao_CalendarExtender"
                        runat="server" TargetControlID="txtDataContratacao">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="img2" Style="vertical-align: bottom" CausesValidation="false"
                        ImageUrl="~/Images/btn_off_Cal.gif" runat="server" />
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="txtDataContratacao" Display="Dynamic" ErrorMessage="A Data de Admissão é obrigatória"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="validator" ErrorMessage="Data Inválida"
                        OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Nº Cateira de Trabalho"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCarteiratrabalho" CssClass="textbox" MaxLength="25" Width="300px"
                        runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator8" runat="server"
                        ControlToValidate="txtCarteiratrabalho" Display="Dynamic" ErrorMessage="A Carteira de Trabalho é obrigatória"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Cargo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCargo" CssClass="textbox" MaxLength="25" Width="300px" runat="server"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator9" runat="server"
                        ControlToValidate="txtCargo" Display="Dynamic" ErrorMessage="O Cargo é obrigatório"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <b>
                        <asp:Label ID="Label10" runat="server" Text="Salário"></asp:Label></b>
                </td>
                <td>
                    <asp:TextBox ID="txtSalario" CssClass="textbox" MaxLength="13" Width="300px" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtSalario_MaskedEditExtender" runat="server" 
                        ClearMaskOnLostFocus="False" Mask="9999.99" MaskType="Number" 
                        TargetControlID="txtSalario">
                    </asp:MaskedEditExtender>
                   <%-- <asp:MaskedEditExtender ID="txtSalário_MaskedEditExtender" runat="server" 
                        TargetControlID="txtSalario" CultureName="pt-BR" DisplayMoney="Left"
                        Mask="9999,99" MaskType="Number" ClearMaskOnLostFocus="False"
                        PromptCharacter="_">
                    </asp:MaskedEditExtender>--%>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
        <br />
        <asp:HiddenField ID="hddId" runat="server" />
    </div>
</asp:Content>
