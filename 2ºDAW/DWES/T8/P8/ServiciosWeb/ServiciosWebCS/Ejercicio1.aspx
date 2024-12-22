<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="ServiciosWebCS.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="css/syle.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="CONSUMIR UN SERVICIO WEB YA EXISTENTE" Font-Bold="True" Font-Size="15pt"></asp:Label>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Titulaciones Oficiales en la Universidad de Alicante" Font-Bold="True" Font-Size="20pt"></asp:Label>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Curso académico (formato aaaa-aa)"></asp:Label>
        <asp:TextBox ID="txtCurso" runat="server"></asp:TextBox>
        <asp:Button ID="btnObtenerInformacion" runat="server" Text="Obtener Información" OnClick="btnObtenerInformacion_Click" />
        <p>
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
