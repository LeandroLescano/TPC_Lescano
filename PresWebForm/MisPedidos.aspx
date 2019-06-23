<%@ Page Title="Mis pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="misPedidos.aspx.cs" Inherits="PresWebForm.MisPedidos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var id = $(<%=ClienteID.ClientID%>).val();
            if (id != "") {
                nombreCliente(id);
            }
        });

    </script>
    <asp:HiddenField ID="ClienteID" runat="server"/>
    <br />
    <asp:GridView ID="dgvPedidos" runat="server" CssClass="table"></asp:GridView>

</asp:Content>
