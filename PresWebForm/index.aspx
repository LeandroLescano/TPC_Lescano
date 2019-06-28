<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PresWebForm.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">       
        $(document).ready(function () {

            var id = $(<%=ClienteID.ClientID%>).val();
            if (id != "") {
                nombreCliente(id);
            }

            $('#alto').height(window.innerHeight);
        });
    </script>
    <asp:HiddenField ID="ClienteID" runat="server" />
    <div id="Bienvenido">
        <h1 style="text-align: center;">Bienvenido!</h1>
        <h2 style="text-align: center;"><a href="/pedido">Hacé tu pedido</a></h2>
    </div>
    <div id="alto"></div>
</asp:Content>
