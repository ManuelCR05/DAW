<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones1.aspx.cs" Inherits="GesPresta.Prestaciones1" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CssPrestaciones.css" type="text/css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Cabecera ID="Cabecera1" runat="server" />
        </div>

        <h2>DATOS DE LAS PRESTACIONES</h2>

        <br />

        <table>
            <tr>
                <td class="columna1">
                    Código Prestación
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Descripción
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtDesPre" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Importe Fijo
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtImpPre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Porcentaje del Importe
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Tipo de Prestación
                </td>
                <td class="columna2">
                    <asp:DropDownList ID="ddlTipPre" runat="server">
                        <asp:ListItem>Dentaria</asp:ListItem>
                        <asp:ListItem>Familiar</asp:ListItem>
                        <asp:ListItem Selected="True">Ocular</asp:ListItem>
                        <asp:ListItem>Otras</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <br />

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" PostBackUrl="~/Prestaciones1Respuesta.aspx"/>
    </form>
</body>
</html>
