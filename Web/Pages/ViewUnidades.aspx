<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUnidades.aspx.cs" Inherits="Web.Pages.ViewUnidades" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unidades</title>
    <script language="javascript" type="text/javascript">

        function EnviarUnidade(id, texto) {
            window.opener.preencherUnidade(id, texto);
            window.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="overflow:auto; width:400px; height:400px;">
    
            <asp:GridView ID="grdUnidades" AutoGenerateColumns="False" runat="server" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="380px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Número">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" OnClientClick='<%# String.Format("EnviarUnidade({0}, \"{1}\")", Eval("ID"), Eval("Numero")) %>'                            
                             runat="server" Text='<%# Bind("Numero") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Piso" HeaderText="Andar" />
                    <asp:BoundField DataField="Torre" HeaderText="Torre" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    
    </div>
    </form>
</body>
</html>
