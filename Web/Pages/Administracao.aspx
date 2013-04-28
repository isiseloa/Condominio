<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Administracao.aspx.cs" Inherits="Web.Pages.Administracao" %>

<%@ Register Src="PainelMensagem.ascx" TagName="PainelMensagem" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" Titulo="Administração" runat="server" />
    <div class="conteudoPrincipal">
        <br />
        <table>
            <tr>
                <td style="width: 500px">
                    <div style="width: 490px; height: 200px; overflow: auto;">
                        <asp:GridView Width="470px" ID="grdDespesas" AutoGenerateColumns="False" runat="server"
                            CellPadding="4" ForeColor="#333333" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Despesa" DataField="Descricao" />
                                <asp:BoundField HeaderText="Valor" DataField="Valor" DataFormatString="{0:F2}" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName=""
                                            CommandArgument='<%# Bind("ID") %>' Text="Excluir" OnClick="LinkButton1_Click"></asp:LinkButton>
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
                    <br />
                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular total das despesas" 
                        onclick="btnCalcular_Click" />
                </td>
                <td style="width: 500px">
                    <div style="width: 490px; height: 200px; overflow: auto;">
                        <asp:GridView Width="470px" ID="grdFuncionario" AutoGenerateColumns="False" runat="server"
                            CellPadding="4" ForeColor="#333333" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" 
                                            oncheckedchanged="CheckBox1_CheckedChanged" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Funcionário" DataField="Nome" />
                                <asp:BoundField HeaderText="Salario" DataField="SalarioVigente" />
                              
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                              
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
                    <asp:Button ID="btnConverter" runat="server" 
                        Text="Transformar o salário dos funcionários em despesas" 
                        onclick="btnConverter_Click" />
                </td>
            </tr>
            <tr>
            <td></td>
            <td></td>            
            </tr>
             <tr>
            <td>
                <br />
                <br />
                 </td>
            <td></td>            
            </tr>


             <tr>
            <td>
                 <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
            <td></td>            
            </tr>
            <tr>
            <td>
                 <asp:Label ID="lblTotalPorUnidade" runat="server" Font-Bold="True" 
                     Font-Size="Medium"></asp:Label></td>
            <td>
                <asp:Button ID="btnGerarBoleto" Visible="false" runat="server" 
                    Text="Gerar Boletos e enviar mensagem aos moradores" 
                    onclick="btnGerarBoleto_Click" />
                </td>            
            </tr>
        </table>
    </div>
</asp:Content>
