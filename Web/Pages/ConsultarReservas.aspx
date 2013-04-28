<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarReservas.aspx.cs" Inherits="Web.Pages.ConsultarReservas" %>
<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMessagem" Titulo="Consultar Reservas" runat="server" />
    <div class="conteudoPrincipal">
    
    <div runat="server" id="divConteudo" style="overflow:auto; width:720px; height:300px">
        <asp:GridView ID="grdAgendamentos" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" Width="700px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Recurso" DataField="Recurso" />
                <asp:BoundField HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" DataField="Data" />
                <asp:BoundField HeaderText="Morador" DataField="Usuario" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                            CommandName="" CommandArgument='<%# Bind("ID") %>' onclick="LinkButton1_Click" OnClientClick="javascript:return confirm('Dejeja realmente cancelar a reserva?');" Text="Cancelar Reserva"></asp:LinkButton>
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
        <asp:HyperLink ID="LinkCadastrar" NavigateUrl="~/Pages/ReservarRecurso.aspx" runat="server">Fazer nova reserva</asp:HyperLink>
    </p>
    </div>
</asp:Content>
