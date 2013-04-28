<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" runat="server" />
    <div class="conteudoPrincipal">
    <br />    
    <table>
    <tr>
    <td><b><asp:Label ID="lblMensagens" runat="server" Text="Mensagens"></asp:Label></b></td>        
    <td><b><asp:Label ID="lblOcorrencias" runat="server" Text="Ocorrências"></asp:Label></b></td>        
    <td></td>
    </tr>
    <tr>
        <td style="width:500px">
        <div runat="server" id="divMensagens" style="width:490px; height:200px; overflow:auto;">

            <asp:GridView Width="470px" ID="grdMensagens" AutoGenerateColumns="False" 
                runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Enviada Por" DataField="Usuario" />
                    <asp:BoundField HeaderText="Mensagem" DataField="Detalhe" />
                      <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                            CommandName="" CommandArgument='<%# Bind("ID") %>' Text="Excluir" 
                            onclick="LinkButton1_Click"></asp:LinkButton>
                    </ItemTemplate>
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
        </td>
        <td style="width:500px">
        <asp:Image ID="imgFundo" runat="server" Width="480px" Height="200px" ImageUrl="~/Images/ico_cond.jpg" />
        <div runat="server" id="divOcorrencias" style="width:490px; height:200px; overflow:auto;">            
            <asp:GridView Width="470px" ID="grdOcorrencia" AutoGenerateColumns="False" 
                runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Enviada Por" DataField="Usuario" >
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tipo" DataField="TipoOcorrencia" >
                      <ItemStyle Width="200px" />
                    </asp:BoundField>
                      <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkAnalisar" runat="server" CausesValidation="false" 
                            CommandName="" CommandArgument='<%# Bind("ID") %>' Text="Analisar" onclick="lnkAnalisar_Click" 
                            ></asp:LinkButton>
                    </ItemTemplate>
                          <ItemStyle Width="60px" />
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
        </td>

        </tr>
        <tr>
        <td>
            <br />
            <br />
            Clique<a href="boleto.htm"> aqui </a>para visualizar o boleto do condomínio deste mês
            </td>
        <td></td>
        
        </tr>
    </table>

    </div>
</asp:Content>
