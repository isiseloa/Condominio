<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarDespesa.aspx.cs" Inherits="Web.Pages.CadastrarDespesa" %>
<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Cadastrar Despesa" runat="server" />
    <div class="conteudoPrincipal" style="height:400px">
    <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Descrição"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescricao" CssClass="textbox"  TextMode="MultiLine" 
                        MaxLength="1000" runat="server" Width="250px" Height="70px"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtDescricao" ErrorMessage="A Descrição é obrigatória" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Valor"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtValor" CssClass="textbox" Width="250px" MaxLength="9" runat="server"></asp:TextBox>
                     <asp:MaskedEditExtender ID="txtAndar_MaskedEditExender" runat="server" 
                        TargetControlID="txtValor" Mask="99999.99" MaskType="Number">
                    </asp:MaskedEditExtender>
                     <span class="campoObrigatorio">*</span>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtValor" ErrorMessage="O Valor é obrigatório" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Data"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtData" Width="206px" MaxLength="10" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtData_CalendarExtender" PopupButtonID="img1" runat="server" 
                        TargetControlID="txtData">
                    </asp:CalendarExtender>
                    <asp:MaskedEditExtender ID="txtData_MaskedEditExtender" runat="server" 
                        Mask="99/99/9999" MaskType="Date" TargetControlID="txtData" 
                        UserDateFormat="DayMonthYear">
                    </asp:MaskedEditExtender>
                    &nbsp;<asp:ImageButton ID="img1" CausesValidation="false" style="vertical-align:bottom" runat="server" 
                        ImageUrl="~/Images/btn_off_Cal.gif" />
                    <span class="campoObrigatorio">*</span></td>
                <td>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtData" ErrorMessage="A Data é obrigatória" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator CssClass="validator" Display="Dynamic" 
                        ID="CustomValidator1" runat="server" 
                        ErrorMessage="Data Inválida" 
                        onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
          
        </table>
        <p>        
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                onclick="btnSalvar_Click" />
        </p>
    </div>
    
</asp:Content>
