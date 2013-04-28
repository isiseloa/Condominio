<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="Web.Pages.ConsultarUsuarios" %>

<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:PainelMensagem ID="pnlMensagem" Titulo="Consultar Usuários" runat="server" />
    <div class="conteudoPrincipal">        
        
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtPesquisa" CssClass="textbox" Width="300px" runat="server"></asp:TextBox>                    
                </td>
                <td>
                    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                </td>
                <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                <asp:CheckBox ID="chkSomenteAtivos" Checked="true" Text="Somente Ativos" runat="server" />
                </td>
            </tr>
        </table>   
        <br />     
        <div runat="server" id="divConteudo" style="overflow:auto; width:920px; height:300px;">
            <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="Vertical" Width="900px" 
                onrowcreated="grdUsuarios_RowCreated">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# String.Format("CadastrarUsuario.aspx?id={0}", Eval("ID"))  %>'
                                runat="server"><%#String.Format("{0} {1}", Eval("Nome"), Eval("Sobrenome"))  %> </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Unidade" HeaderText="Unidade" />
                    <asp:BoundField DataField="NomeUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="DescricaoTipoUsuario" HeaderText="Tipo do Usuário" />
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
        <asp:HyperLink ID="linkCadastrar" runat="server" NavigateUrl="~/Pages/CadastrarUsuario.aspx">Cadastrar Novo Usuário</asp:HyperLink>
    </div>
</asp:Content>
