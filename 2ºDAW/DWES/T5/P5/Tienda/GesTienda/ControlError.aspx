<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlError.aspx.cs" Inherits="GesTienda.ControlError" %>
<%@ OutputCache Duration="1" VaryByParam="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            <h1>Aplicación Web GesTienda</h1>

            <h3>Error en tiempo de ejecución</h3>
        </div>

        <div style="border: solid black 2px; text-align: left; width: 420px">
            <asp:Label ID="lblTextASP" runat="server">Erro ASP.NET:</asp:Label>
            <br />
            <asp:Label ID="lblErrorASP" runat="server" ForeColor="Red"></asp:Label>

            <br />
            <br />

            <asp:Label ID="lblTextADO" runat="server">Erro ADO.NET:</asp:Label>
            <br />
            <asp:Label ID="lblErrorADO" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
