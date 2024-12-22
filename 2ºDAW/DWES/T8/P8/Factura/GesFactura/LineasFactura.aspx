<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineasFactura.aspx.cs" Inherits="GesFactura.LineasFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="style.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="20pt" Text="Uso de Servicio Web - Cálculos factura de un artículo"></asp:Label>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server">Cantidad</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCantidad"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Precio</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPrecio"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td>
                        <asp:Label runat="server">Descuento (%)</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescuento"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td>
                        <asp:Label runat="server">Tipo de IVA (%)</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTipoIVA"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button runat="server" text="Enviar" ID="btnEnviar" OnClick="btnEnviar_Click"/>
            <br />
            <br />
            <asp:Label runat="server">Resultado de los cálculos:</asp:Label>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server">Bruto</asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server">Descuento</asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server">Base imponible</asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server">IVA</asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server">Total</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblBruto"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblDescuento"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblBaseImponible"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblIva"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
