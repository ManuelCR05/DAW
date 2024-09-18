<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cabecera.ascx.cs" Inherits="GesPresta.Cabecera" %>

<link rel="stylesheet" href="CssCabcera.css" type="text/css"/>

<div>
    <asp:LinkButton ID="LinkButton1" runat="server" style="margin:10px" PostBackUrl="~/Default.aspx">Inicio</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" style="margin:10px" PostBackUrl="~/Empleados.aspx">Empleados</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" style="margin:10px" PostBackUrl="~/Prestaciones.aspx">Prestaciones</asp:LinkButton>
</div>
<div>
    <h1>
        ACME INNOCACIÓN, S. FIG.
    </h1>
</div>
<div>
    Gestión de Prestaciones Sociales
</div>
<hr />