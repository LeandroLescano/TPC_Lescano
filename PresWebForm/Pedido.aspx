<%@ Page Title="Hace tu pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="PresWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Elegí la picada que más te guste</h3>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://upload.wikimedia.org/wikipedia/commons/1/1b/Square_200x200.png" class="d-block w-1" alt="Prueba1">
            </div>
            <div class="carousel-item">
                <img src="..." class="d-block w-1" alt="Prueba2">
            </div>
            <div class="carousel-item">
                <img src="..." class="d-block w-1" alt="Prueba3">
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <p>Descripción:</p>
    <p>Precio: </p>
    <p>La podrás retirar en:  días</p>
    <p>Observaciones:  </p>
    <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" class="form-control" Width="300px" TextMode="MultiLine" placeholder="Algo que desees cambiar..."></asp:TextBox>
    <br />
    <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Enviar pedido" />
</asp:Content>
