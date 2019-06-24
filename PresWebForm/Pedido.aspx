<%@ Page Title="Hace tu pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="PresWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var id = $(<%=ClienteID.ClientID%>).val();
            if (id != "") {
                nombreCliente(id);
            }


            var combosJs;
            $('#carousel').on('slid.bs.carousel', function () {
                cargarDesc();
            });

            $('.carousel').each(function () {
                $(this).carousel({
                    interval: false
                });
            });

            var btnP = document.getElementById("MainContent_btnPedido")
            btnP.disabled = true;

            <% var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); %>
            combosJs = <%= serializer.Serialize(combos)%>;

            function cargarDesc() {
                var id = $('.active').find('img').attr('id');
                id = id.substring(3, id.length);
                document.getElementById("<%=lblDescripcion.ClientID%>").innerText = combosJs[id].Descripcion;
                document.getElementById("<%=lblPrecio.ClientID%>").innerText = "Precio: $" + combosJs[id].Precio;
                document.getElementById("<%=lblDias.ClientID%>").innerText = "La podrás retirar en: " + combosJs[id].DiasAnticipo + " días";
                document.getElementById("<%=ComboID.ClientID%>").value = id;

                var hoy = new Date();
                var dd = String(hoy.getDate()).padStart(2, '0');
                var mm = String(hoy.getMonth() + 1).padStart(2, '0');
                var yyyy = hoy.getFullYear();
                var diasAnticipo = Number(combosJs[id].DiasAnticipo);

                dd = String(Number(dd) + diasAnticipo);

                hoy = dd + '/' + mm + '/' + yyyy;

                $('#MainContent_dtpFechaEntrega').datepicker('destroy');

                $('#MainContent_dtpFechaEntrega').datepicker({
                    language: "es",
                    daysOfWeekDisabled: "0",
                    startDate: hoy
                });

            };

            window.onload = cargarDesc();
        });
    </script>
    <div class="container">
        <asp:HiddenField ID="ComboID" runat="server" />
        <asp:HiddenField ID="ClienteID" runat="server" />
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
                <table style="height: 50px;">
                    <tbody>
                        <tr>
                            <td class="align-middle">
                                <h4 style="margin-bottom: 0px;">Lo retiro el: </h4>
                            </td>
                            <td>
                                <asp:TextBox ID="dtpFechaEntrega" runat="server" class="form-control" placeholder="DD/MM/YYYY" onchange="habilitarPedido()"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
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
            <asp:Button CssClass="btn" ID="btnPedido" runat="server" Text="Enviar pedido" OnClick="btnPedido_Click" value="" />
        </div>
    </div>
</asp:Content>
