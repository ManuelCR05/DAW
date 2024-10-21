<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones.aspx.cs" Inherits="GesPresta.Prestaciones" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<%@ Register src="prestacionesBuscar.ascx" tagname="prestacionesBuscar" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CssPrestaciones.css" type="text/css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            padding-right: 15px;
            height: 34px;
        }
        .auto-style2 {
            text-align: left;
            padding-left: 15px;
            height: 34px;
        }
        .auto-style3 {
            height: 706px;
        }
    </style>
</head>
<body style="height: 682px">
    <form id="form1" runat="server" class="auto-style3">
        <div>
            <uc1:Cabecera ID="Cabecera1" runat="server" />
        </div>

        <h2>DATOS DE LAS PRESTACIONES</h2>

        <br />

        <table>
            <tr>
                <td class="auto-style1" id="prestacionBuscar1">
                    Código Prestación
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regTxtCodPre" runat="server" ControlToValidate="txtCodPre" ErrorMessage="El formato debe ser: 111-111-111" ForeColor="Red" ValidationExpression=" \d{3}-\d{3}-\d{3}">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqdTxtCodPre" runat="server" ControlToValidate="txtCodPre" ErrorMessage="El Código de prestación es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:Button ID="btnVerPrestaciones" runat="server" CausesValidation="False" OnClick="btnVerPrestaciones_Click" Text="Ver prestaciones" />
                </td>
                <td>
                    <uc2:prestacionesBuscar ID="prestacionesBuscar1" runat="server"/>
                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" Visible="False" CausesValidation="False" OnClick="btnSeleccionar_Click" />
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
                    <asp:RangeValidator ID="rngTxtImpPre" runat="server" ControlToValidate="txtImpPre" ErrorMessage="El Valor deve estar comprendido entre 0.00 y 500.00" ForeColor="Red" MaximumValue="500,00" MinimumValue="0,00" Type="Double">*</asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqdTxtImpPre" runat="server" ControlToValidate="txtImpPre" ErrorMessage="El Importe Fijo es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="columna1">
                    Porcentaje del Importe
                </td>
                <td class="columna2">
                    <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="rngTxtPorPre" runat="server" ControlToValidate="txtPorPre" ErrorMessage="El valor deve estar comprendido entre 0.00% y 15.00%" ForeColor="Red" MaximumValue="15,00" MinimumValue="0,00" Type="Double">*</asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqdTxtPorPre" runat="server" ControlToValidate="txtPorPre" ErrorMessage="El Porcentaje del importe es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
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

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar"/>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" />
        
        <br />
    </form>
</body>
</html>
