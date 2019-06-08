<%@ Page Title="Hace tu pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="PresWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#demo").carousel("pause");
        });
    </script>

    <div class="container">

        <h2><%: Title %></h2>
        <h3>Elegí la picada que más te guste</h3>

        <div id="demo" class="carousel slide" data-ride="carousel" style="width: 500px;">
            <!-- Indicators -->
            <ul class="carousel-indicators">
                <li data-target="#demo" data-slide-to="0" class="active"></li>
                <li data-target="#demo" data-slide-to="1"></li>
                <li data-target="#demo" data-slide-to="2"></li>
            </ul>

            <!-- The slideshow -->
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="https://dummyimage.com/600x400/000/fff" alt="Los Angeles" class="mx-auto d-block img-fluid">
                </div>
                <div class="carousel-item">
                    <img src="https://www.calliaweb.co.uk/wp-content/uploads/2015/10/450x300.jpg" alt="Chicago" class="mx-auto d-block img-fluid">
                    <div class="carousel-caption">
                        <h3>Los Angeles</h3>
                        <p>We had such a great time in LA!</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="https://mariabarcelona.com/wp-content/uploads/2014/02/placehold.it-1280x7201.gif" alt="New York" class="mx-auto d-block img-fluid">
                    <div class="carousel-caption">
                        <h3>Los Angeles</h3>
                        <p>We had such a great time in LA!</p>
                    </div>
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="carousel-control-prev" href="#demo" data-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </a>
            <a class="carousel-control-next" href="#demo" data-slide="next">
                <span class="carousel-control-next-icon"></span>
            </a>

        </div>

        <p>Descripción:</p>
        <p>Precio: </p>
        <p>La podrás retirar en:  días</p>
        <p>Observaciones:  </p>
        <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" class="form-control" Width="300px" TextMode="MultiLine" placeholder="Algo que desees cambiar..."></asp:TextBox>
        <br />
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Enviar pedido" />
    </div>
</asp:Content>
