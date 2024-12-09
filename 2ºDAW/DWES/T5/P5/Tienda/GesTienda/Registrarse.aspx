<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="GesTienda.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="~/Estilos/HojaEstilo.css" rel="stylesheet" type="text/css" />
<title></title>
<style>
    td:first-child {
        text-align: right;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="cabecera">
                <div id="cabecera1">
                    <br />
                    comerciodaw.com &nbsp;
                </div>
                <div id="cabecera2">
                    <br />
                    &nbsp;&nbsp;TIENDA ONLINE - SHOPPING DAW<br />
                    <br />
            </div>

            <h1 style="display: flex; align-items: center; justify-content: center;">GesTienda</h1>
            <h3 style="display: flex; align-items: center; justify-content: center;">Registro de Usuario</h3>

            <table style="display: flex; align-items: center; justify-content: center;">
                <tr>
                    <td><asp:Label ID="lblEmail" runat="server">Correo Electrónico</asp:Label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblContraseña" runat="server">Contraseña</asp:Label></td>
                    <td><asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblContraseña2" runat="server">Introduzca nuevamente la Contraseña</asp:Label></td>
                    <td><asp:TextBox ID="txtContraseña2" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNIE" runat="server">NIF/NIE/CIF</asp:Label></td>
                    <td><asp:TextBox ID="txtNIE" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNomRaz" runat="server">Nombre/Razón Social</asp:Label></td>
                    <td><asp:TextBox ID="txtNomRaz" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDireccion" runat="server">Dirección</asp:Label></td>
                    <td><asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPoblacion" runat="server">Población</asp:Label></td>
                    <td><asp:TextBox ID="txtPoblacion" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCodPostal" runat="server">Código Postal</asp:Label></td>
                    <td><asp:TextBox ID="txtCodPostal" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTelefono" runat="server">Teléfono</asp:Label></td>
                    <td><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
                </tr>
            </table>

            <br />

            <div style="display: flex; align-items: center; justify-content: center;">
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click"/>
            </div>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx"  style="display: flex; align-items: center; justify-content: center;">Ir a Inicio</asp:LinkButton>
            <br />
            <asp:Label ID="lblMensajes" runat="server"></asp:Label>

            <div id="pie">
                <br />
                <br />
                © Desarrollo de Aplicaciones Web interactivas con Acceso a Datos
                <br />
                IES Mare Nostrum (Alicante)
            </div>
        </div>
    </form>
</body>
</html>
