<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultarFuncionario.aspx.cs" Inherits="Web.Pages.ConsultarFuncionario" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Consultar Funcionários" runat="server" />
    <div class="conteudoPrincipal">
    <p>
        <asp:TextBox ID="txtPesquisa" MaxLength="100" CssClass="textbox" runat="server" Width="324px"></asp:TextBox>
        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
            onclick="btnPesquisar_Click" style="margin-bottom: 0px" />
            </p>
        <div runat="server" id="divConteudo" style="overflow:auto; height:280px; width:1020px">
            <asp:GridView ID="grdFuncionarios" Width="1000px" AutoGenerateColumns="False" 
                runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                     <asp:HyperLinkField DataNavigateUrlFormatString="CadastrarFuncionario.aspx?id={0}"
                    HeaderText="Nome" DataTextField="Nome" DataNavigateUrlFields="ID" />
                   
                    <asp:BoundField HeaderText="Endereço" DataField="Endereco" />
                    <asp:BoundField HeaderText="CPF" DataField="CPF" />
                    <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
                    <asp:BoundField DataField="DataAdmissao" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderText="Data de Admissão" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center"/>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>


        </div>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" PostBackUrl="~/Pages/CadastrarFuncionario.aspx" runat="server">Cadastrar Novo Funcionário</asp:LinkButton>
    </div>
</asp:Content>
