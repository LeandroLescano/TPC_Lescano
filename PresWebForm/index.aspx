<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PresWebForm.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="ClienteID" runat="server" />
    <h1>Bienvenido!</h1>
    <h2 href="/pedido">Hacé tu pedido</h2>
</asp:Content>
