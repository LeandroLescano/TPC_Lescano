<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PresWebForm.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">       
        $(document).ready(function () {

            $('#alto').height($(window).height());

        });
    </script>
    <asp:HiddenField ID="ClienteID" runat="server" />
    <h1 style="text-align:center;">Bienvenido!</h1>
    <h2 ><a href="/pedido">Hacé tu pedido</a></h2>
    <div id="alto"></div>
</asp:Content>
