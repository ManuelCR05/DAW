<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpleadosCalendar.aspx.cs" Inherits="GesPresta.EmpleadosCalendar" %>

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

        <div id="contenedor">
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
                            <asp:ListItem>Investigación</asp:ListItem>
                            <asp:ListItem>Desarrollo</asp:ListItem>
                            <asp:ListItem>Innovación</asp:ListItem>
                            <asp:ListItem>Administración</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

            <br />
            <br />

          <table>
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <asp:Label ID="lblFechaNacimiento" runat="server">Fecha de Nacimiento</asp:Label>
                        <br />
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" OnTextChanged="txtFechaNacimiento_TextChanged"></asp:TextBox>
                    </td>
                    <td style="padding-right: 80px">
                        <asp:Calendar ID="cFechaNacimiento" runat="server" OnSelectionChanged="cFechaNacimiento_SelectionChanged"></asp:Calendar>
                    </td>
                    <td style="vertical-align: top; text-align: right">
                        <asp:Label ID="lblFechaIngreso" runat="server">Fecha de Ingreso</asp:Label>
                        <br />
                        <asp:TextBox ID="txtFechIngreso" runat="server" OnTextChanged="txtFechIngreso_TextChanged"></asp:TextBox>
                    </td>
                    <td style="padding-right: 80px">
                        <asp:Calendar ID="cFechaIngreso" runat="server" OnSelectionChanged="cFechaIngreso_SelectionChanged"></asp:Calendar>
                    </td>
                    <td style="vertical-align: top; text-align: left">
                        <asp:Label ID="lblAntiguedad" runat="server">Antiguedad:</asp:Label>
                        <br />
                        <br />
                        <div  style="text-align: left">
                            <asp:TextBox ID="txtAnyo" runat="server" Width="60px" style="margin-right: 10px"></asp:TextBox>
                            <asp:Label ID="lblAnyo" runat="server">Años</asp:Label>
                        </div>
                        <br />
                        <div  style="text-align: left">
                            <asp:TextBox ID="txtMes" runat="server" Width="60px" style="margin-right: 10px"></asp:TextBox>
                            <asp:Label ID="lblMes" runat="server">Meses</asp:Label>
                        </div>
                        <br />
                        <div  style="text-align: left">
                            <asp:TextBox ID="txtDia" runat="server" Width="60px" style="margin-right: 10px"></asp:TextBox>
                            <asp:Label ID="lblDia" runat="server">Dias</asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />
        <br />

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"/>

        <br />
        <br />

        <asp:Label ID="lblValores" runat="server" BackColor="#66FFFF" Width="60%" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="lblError1" runat="server" ForeColor="Red" Visible="False">La fecha de ingreso no puede ser inferiro a la fecha de nacimiento</asp:Label>
        <br />
        <asp:Label ID="lblError2" runat="server" ForeColor="Red" Visible="false">La fecha de ingreso no puede ser mayor a la fecha actual</asp:Label>
        <br />
        <asp:Label ID="lblError3" runat="server" ForeColor="Red" Visible="false">La fecha de nacimiento no puede ser mayor a la fehca actual</asp:Label>

    </form>
</body>
</html>
