<%@ Page Title="Hace tu pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="PresWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var combosJs;

            $('#carousel').carousel('pause');

            $('#carousel').on('slid.bs.carousel', function () {
                cargarDesc();
            });

            <% var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); %>
            combosJs = <%= serializer.Serialize(combos)%>;

            function cargarDesc() {
                var id = $('.active').find('img').attr('id');
                id = id.substring(3, id.length);
                document.getElementById("<%=lblDescripcion.ClientID%>").innerText = combosJs[id].Descripcion;
                document.getElementById("<%=lblPrecio.ClientID%>").innerText = "Precio: $" + combosJs[id].Precio;
                document.getElementById("<%=lblDias.ClientID%>").innerText = "La podrás retirar en: " + combosJs[id].DiasAnticipo + " días";
            };

            window.onload = cargarDesc();
        });
    </script>
    <div class="container">
        <h3>Elegí la picada que más te guste</h3>

        <div class="row">
            <div id="carousel" class="carousel slide col-sm-12" data-ride="carousel" style="width: 500px;">
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
        </div>

        <div class="row">
            <div class="col-sm-8" style="margin: auto;">
                <h4>Descripción</h4>
                <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblDias" runat="server" Text="La podrás retirar en:"></asp:Label>
                <br />
                <h4>Lo retiro el día</h4>
            </div>
            <div class="col-sm-4 text-center align-middle" style="margin: auto;">
                <asp:Label ID="lblPrecio" class="btn btn-success" runat="server" Text="Precio: $"></asp:Label>
            </div>
        </div>
        <br />
        <asp:Label ID="lblObservacion" runat="server" Text="Observaciones:"></asp:Label>
        <br />
        <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" class="form-control" TextMode="MultiLine" placeholder="Algo que desees cambiar..."></asp:TextBox>
        <br />
        <div class="col align-items-center text-right" style="padding-right: 0px;">
            <asp:Button class="btn" ID="btnPedido" runat="server" Text="Enviar pedido" OnClick="btnPedido_Click" />
        </div>
    </div>
</asp:Content>
