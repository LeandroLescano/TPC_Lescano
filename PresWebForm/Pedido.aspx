<%@ Page Title="Hace tu pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="PresWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Elegí la picada que más te guste</h3>
    <p> Picadas: <asp:DropDownList runat="server"></asp:DropDownList></p>
    <p>Descripción:</p>
    <p>Precio: </p>
    <p>La podrás retirar en:  días</p>
    <p>Observaciones:  </p> 
    <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Enviar pedido"/>
</asp:Content>
