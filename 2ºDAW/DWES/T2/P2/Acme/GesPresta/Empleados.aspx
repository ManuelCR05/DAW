<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.Empleados" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="CssEmpleados.css" type="text/css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Cabecera ID="Cabecera1" runat="server" />
        </div>

        <h2>DATOS DE LOS EMPLEADOS</h2>

        <br />

        <table>
            <tr>
                <td class="columna1">
                    Código Empleado
                </td>
                 <td class="columna2">
                      <asp:TextBox ID="txtCodEmp" runat="server" Width="200px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="columna1">
                    NIF
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtNifEmp" runat="server" Width="200px"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                 <td class="columna1">
                     Apellidos y Nombre
                 </td>
                 <td class="columna2">
                     <asp:TextBox ID="txtNomEmp" runat="server" Width="500px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="columna1">
                    Dirección
                </td>
                <td class="columna2">
                     <asp:TextBox ID="txtDirEmp" runat="server" Width="550px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="columna1">
                    Ciudad
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtCiuEmp" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr>
               <td class="columna1">
                   Teléfonos
               </td>
                <td class="columna2">
                    <asp:TextBox ID="txtTelEmp" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Fecha de Nacimiento
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Fecha de Ingreso
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Sexo
                </td>
                <td class="columna2">
                    <asp:RadioButtonList ID="rblSexEmp" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Hombre</asp:ListItem>
                        <asp:ListItem>Mujer</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Departamento
                </td>
                <td class="columna2">
                    <asp:DropDownList ID="ddlDepEmp" runat="server">
                        <asp:ListItem>Investigació</asp:ListItem>
                        <asp:ListItem>Desarrollo</asp:ListItem>
                        <asp:ListItem>Innovación</asp:ListItem>
                        <asp:ListItem>Administración</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <br />

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar"/>
    </form>
</body>
</html>
