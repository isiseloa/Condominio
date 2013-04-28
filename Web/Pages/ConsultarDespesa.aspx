<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarDespesa.aspx.cs" Inherits="Web.Pages.ConsultarDespesa" %>
<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:PainelMensagem ID="pnlMensagem" runat="server" Titulo="Consultar Despesas" />
    <div class="conteudoPrincipal">
    <table>
            <tr>
                <td><asp:TextBox CssClass="textbox" ID="txtDataInicio" MaxLength="10" Width="150px" runat="server"></asp:TextBox>

                    <asp:CalendarExtender ID="txtDataInicio_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDataInicio" Format="dd/MM/yyyy"  PopupButtonID="img1">
                    </asp:CalendarExtender>
                </td>
                <td style="width:60px"><asp:ImageButton 
                        ID="img1" runat="server" ImageUrl="~/Images/btn_off_Cal.gif" />
                </td>
                <td><asp:TextBox ID="txtDataFim" CssClass="textbox" MaxLength="10" Width="150px" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtDataFim_CalendarExtender"  Format="dd/MM/yyyy" runat="server" PopupButtonID="img2"
                        TargetControlID="txtDataFim">
                    </asp:CalendarExtender>
                </td>
                <td style="width:60px">&nbsp;<asp:ImageButton 
                        ID="img2" runat="server" ImageUrl="~/Images/btn_off_Cal.gif" />
                </td>
                <td><asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></td>
            </tr>
        </table>
        <br />
    
    <div runat="server" id="divConteudo" style="overflow:auto; width:1020px; height:300px">
        <asp:GridView ID="grdDespesas" Width="1000px" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="Vertical" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="Valor" DataFormatString="{0:F2}" 
                    HeaderText="Valor" />
                <asp:BoundField DataField="Data" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" />
                    <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                            CommandName="" CommandArgument='<%# Bind("ID") %>' 
                            OnClientClick="javascript:return confirm('Dejeja realmente excluir a despesa?');" 
                            Text="Excluir Despesa" onclick="LinkButton1_Click"></asp:LinkButton>
                    </ItemTemplate>
                        <ItemStyle Width="150px" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
    <p>
    <asp:HyperLink ID="LinkCadastrarDespesa" NavigateUrl="~/Pages/CadastrarDespesa.aspx" runat="server">Cadastrar Nova Despesa</asp:HyperLink>
    </p>
        
    </div>

</asp:Content>
