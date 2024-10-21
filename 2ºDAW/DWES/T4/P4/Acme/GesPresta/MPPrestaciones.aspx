<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MPPrestaciones.aspx.cs" Inherits="GesPresta.MPPrestaciones" %>

<%@ Register src="prestacionesBuscar.ascx" tagname="prestacionesBuscar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="CssPrestaciones.css" type="text/css"/>
    <h2>DATOS DE LAS PRESTACIONES</h2>

    <br />

    <table>
        <tr>
            <td class="auto-style1" id="prestacionBuscar1">
                Código Prestación
            </td>
            <td class="columna2">
                <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regTxtCodPre" runat="server" ControlToValidate="txtCodPre" ErrorMessage="El formato debe ser: 111-111-111" ForeColor="Red" ValidationExpression="\d\d\d-\d\d\d-\d\d\d">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rqdTxtCodPre" runat="server" ControlToValidate="txtCodPre" ErrorMessage="El Código de prestación es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:Button ID="btnVerPrestaciones" runat="server" CausesValidation="False" OnClick="btnVerPrestaciones_Click" Text="Ver prestaciones" />
            </td>
            <td>
                <uc1:prestacionesBuscar ID="prestacionesBuscar1" runat="server" />
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
</asp:Content>
