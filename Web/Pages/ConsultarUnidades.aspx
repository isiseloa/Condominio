<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultarUnidades.aspx.cs" Inherits="Web.Pages.ConsultarUnidades" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Unidades" runat="server" />
    <div class="conteudoPrincipal">
        <div id="divConteudo" runat="server" style="overflow: auto; height: 350px; width:520px">
            <asp:GridView ID="grdUnidades" AutoGenerateColumns="false" runat="server" CellPadding="4"
                ForeColor="#333333" GridLines="Vertical" Width="500px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFormatString="CadastrarUnidades.aspx?id={0}" HeaderText="Número"
                        DataTextField="Numero" DataNavigateUrlFields="ID" />
                    <asp:BoundField DataField="Piso" HeaderText="Andar" />
                    <asp:BoundField DataField="Torre" HeaderText="Torre" />
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
       <br />
            <asp:HyperLink ID="linkCadastro" NavigateUrl="~/Pages/CadastrarUnidades.aspx" runat="server">Cadastrar Nova Unidade</asp:HyperLink>
        
       
    </div>
</asp:Content>
