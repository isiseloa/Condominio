<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="VisualizarComunicado.aspx.cs" Inherits="Web.Pages.VisualizarComunicado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Master.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 800px" class="conteudoPrincipal">
        <br />
        <asp:Label ID="lblTituloComunicado" runat="server" Text=""></asp:Label>
        <p>
            <asp:Label ID="lblIndetificacao" runat="server" Text=""></asp:Label>
        </p>
        <br />
        <div style="overflow: auto; height: 670px;">
            <div runat="server" style="padding-right:50px" id="conteudo">
            </div>
        </div>
    </div>
</asp:Content>
