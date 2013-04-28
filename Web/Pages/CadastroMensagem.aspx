<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CadastroMensagem.aspx.cs" Inherits="Web.Pages.CadastroMensagem" %>
<%@ Register src="PainelMensagem.ascx" tagname="PainelMensagem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PainelMensagem ID="pnlMensagem" runat="server" Titulo="Envio de Mensagens" />
    <div class="conteudoPrincipal">   
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" CssClass="textbox" Width="300px" MaxLength="20" runat="server" ReadOnly="true"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>                    
                </td>
                <td style="width:500px">                    
                    <asp:CheckBox AutoPostBack="true" ID="chkTodos" Text="Enviar Para Todos os Moradores" 
                        runat="server" oncheckedchanged="chkTodos_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mensagem"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMensagem" CssClass="textbox" Width="300px" MaxLength="2000" 
                        runat="server" Rows="4" TextMode="MultiLine" Height="120px"></asp:TextBox>
                    <span class="campoObrigatorio">*</span>
                </td>
                <td>     
                    &nbsp;</td>
                <td rowspan="2">   
                <div style="overflow:auto; width:480px; height:180px;">                 
            <asp:GridView ID="grdUsuarios" AutoGenerateColumns="False" runat="server" 
                        CellPadding="4" ForeColor="#333333" 
                GridLines="Vertical" Width="460px" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox AutoPostBack="true" ID="chkMarcar" runat="server" 
                                oncheckedchanged="chkMarcar_CheckedChanged" />
                        </ItemTemplate>                        
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Nome" DataField="Nome" />
                    <asp:BoundField HeaderText="Unidade" DataField="Unidade" />
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
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtMensagem" ErrorMessage="A Mensagem é Obrigatória" SetFocusOnError="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>               
                    
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                    <td>                    
                </td>
            </tr>
        </table>

        
        <p>
            <asp:Button ID="btnSalvar" runat="server" Text="Enviar" onclick="btnSalvar_Click1" 
                 />
            <br />
            <asp:HiddenField ID="hddId" runat="server" />
        </p>
    </div>
</asp:Content>
