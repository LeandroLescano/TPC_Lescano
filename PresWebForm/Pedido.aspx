<%@ Page Title="Hace tu pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="PresWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var combosJs;
        $(document).ready(function () {

            $("#carousel").carousel("pause");

            <% var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); %>
            combosJs = <%= serializer.Serialize(combos)%>;

            function cargarDesc() {
                var id = $('.active').find('img').attr('id');
                id = id.substring(3, id.length);
                document.getElementById("<%=lblDescripcion.ClientID%>").innerText = "Descripción: " + combosJs[id].Descripcion;
                document.getElementById("<%=lblPrecio.ClientID%>").innerText = "Precio: $" + combosJs[id].Precio;
                document.getElementById("<%=lblDias.ClientID%>").innerText = "La podrás retirar en: " + combosJs[id].DiasAnticipo + " días";
            }

            $('#carousel').on('slid.bs.carousel', function () {
                cargarDesc();
            })

            window.onload = cargarDesc();
        });

    </script>
    <div class="container">

        <h2><%: Title %></h2>
        <h3>Elegí la picada que más te guste</h3>

        <div id="carousel" class="carousel slide" data-ride="carousel" style="width: 500px;" >
            <!-- Indicators -->
            <ul class="carousel-indicators" style="filter: invert(100%)">
                <li data-target="#carousel" data-slide-to="0" class="active" runat="server" id="Indicador"></li>
            </ul>
            <!-- The slideshow -->
            <div id="ContenedorImg" class="carousel-inner" runat="server">
            </div>
            <!-- Left and right controls -->
            <a class="carousel-control-prev" href="#carousel" data-slide="prev">
                <span class="carousel-control-prev-icon" style="filter: invert(100%)"></span>
            </a>
            <a class="carousel-control-next" href="#carousel" data-slide="next">
                <span class="carousel-control-next-icon" style="filter: invert(100%)"></span>
            </a>

        </div>
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
        <br />
        <asp:Label ID="lblPrecio" runat="server" Text="Precio: $"></asp:Label>
        <br />
        <asp:Label ID="lblDias" runat="server" Text="La podrás retirar en:"></asp:Label>
        <br />
        <asp:Label ID="lblObservacion" runat="server" Text="Observaciones:"></asp:Label>
        <br />
        <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" class="form-control" Width="300px" TextMode="MultiLine" placeholder="Algo que desees cambiar..."></asp:TextBox>
        <br />
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Enviar pedido" />
    </div>
</asp:Content>
