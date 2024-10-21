<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MPEmpleados.aspx.cs" Inherits="GesPresta.MPEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <link rel="stylesheet" href="CssEmpleados.css" type="text/css"/>

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
                      <asp:RegularExpressionValidator ID="regTxtCodEmp" runat="server" ControlToValidate="txtCodEmp" ErrorMessage="El Formato debe ser:  a12345" ForeColor="Red" ValidationExpression="\w\d{5}">*</asp:RegularExpressionValidator>
                      <asp:RequiredFieldValidator ID="rqdTxtCodEmp" runat="server" ControlToValidate="txtCodEmp" ErrorMessage="El código del empleado es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td class="columna1">
                    NIF
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtNifEmp" runat="server" Width="200px"></asp:TextBox> 
                    <asp:RegularExpressionValidator ID="regTxtNifEmp" runat="server" ControlToValidate="txtNifEmp" ErrorMessage="El Formato debe ser:  11111111-A" ForeColor="Red" ValidationExpression="\d{8}-\w">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqdTxtNifEmp" runat="server" ControlToValidate="txtNifEmp" ErrorMessage="El NIF del empleado es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                 <td class="auto-style2">
                     Apellidos y Nombre
                 </td>
                 <td class="auto-style2">
                     <asp:TextBox ID="txtNomEmp" runat="server" Width="500px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rqdTxtNomEmp" runat="server" ControlToValidate="txtNomEmp" ErrorMessage="El Nombre y Apellidos del empleado son obligatorios" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                <td class="auto-style1">
                    Ciudad
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtCiuEmp" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr>
               <td class="columna1">
                   Teléfonos
               </td>
                <td class="columna2">
                    <asp:TextBox ID="txtTelEmp" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqdTxtTelEmp" runat="server" ControlToValidate="txtTelEmp" ErrorMessage="El Teléfono del empleado es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Fecha de Nacimiento
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regTxtFnaEmp" runat="server" ControlToValidate="txtFnaEmp" ErrorMessage="El Formato debe ser:  dd/mm/aaaa" ForeColor="Red" ValidationExpression="\d\d\/\d\d\/\d\d\d\d">*</asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="cmpTxtFnaEmp" runat="server" ControlToCompare="txtFinEmp" ControlToValidate="txtFnaEmp" ErrorMessage="La fecha de ingreso debe ser mayor a la de nacimiento" ForeColor="Red" Operator="LessThan" Type="Date">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Fecha de Ingreso
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regTxtFinEmp" runat="server" ControlToValidate="txtFinEmp" ErrorMessage="El Formato debe ser:  dd/mm/aaaa" ForeColor="Red" ValidationExpression="\d\d\/\d\d\/\d\d\d\d">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqdTxtFinEmp" runat="server" ControlToValidate="txtFinEmp" ErrorMessage="La Fecha de Ingrso del empleado es obligatoria" ForeColor="Red">*</asp:RequiredFieldValidator>
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
    </div>

    <br />

    <asp:Button ID="btnEnviar" runat="server" Text="Enviar"/>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" />
</asp:Content>
