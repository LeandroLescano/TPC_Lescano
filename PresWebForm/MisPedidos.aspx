<%@ Page Title="Mis pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="misPedidos.aspx.cs" Inherits="PresWebForm.MisPedidos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var id = $(<%=ClienteID.ClientID%>).val();
            if (id != "") {
                nombreCliente(id);
            }
            else {
                document.getElementById("sinCliente").innerHTML = "Ingrese o registrese para visualizar sus pedidos."
            }

            $('#alto').height($(window).height());

        });

    </script>
    <asp:HiddenField ID="ClienteID" runat="server" />
    <h2>Mis pedidos</h2>
    <table class="table table-hover">
        <thead>
            <tr>
                <th class="thID" scope="col">Nro</th>
                <th scope="col">Combo</th>
                <th scope="col">Observación</th>
                <th class="thFecha" scope="col">Fecha de entrega</th>
                <th class="thFecha" scope="col">Fecha de solicitud</th>
                <th scope="col">Precio</th>
                <th scope="col">Estado</th>
            </tr>
        </thead>
        <tbody id="grilla">

        </tbody>
    </table>
    <br />
    <h2 id="sinCliente"></h2>

    <div id="alto"></div>

</asp:Content>
