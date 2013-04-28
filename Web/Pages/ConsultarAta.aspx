<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarAta.aspx.cs" Inherits="Web.Pages.ConsultarAta" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:PainelMensagem ID="pnlMensagem" runat="server" Titulo="Pesquisar Atas de Reunião" />
    <div id="principal" class="conteudoPrincipal">
        <div id="filtro">
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
                <td><asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
                        OnClick="btnPesquisar_Click" style="height: 26px" /></td>
            </tr>
        </table>
        </div>        
        <div style="overflow:auto; width:1020px; height:320px" runat="server" id="divConteudo">
        <asp:GridView Width="1000px" ID="grdAtas" AutoGenerateColumns="False" 
            runat="server" CellPadding="4" ForeColor="#333333" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString="VisualizarComunicado.aspx?id={0}"
                    HeaderText="Título" DataTextField="Titulo" DataNavigateUrlFields="ID" />
                <asp:BoundField DataField="DataCriacao" HeaderText="Data de Publicação" DataFormatString="{0:dd/MM/yyyy}">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Usuario" HeaderText="Publicado Por">
                    <ItemStyle Width="350px" />
                </asp:BoundField>
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
        <asp:HyperLink ID="linkCadastro" runat="server" 
            NavigateUrl="~/Pages/CadastrarAta.aspx">Cadastrar Nova Ata de Reunião</asp:HyperLink>
    </div>


</asp:Content>
