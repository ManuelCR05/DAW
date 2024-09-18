<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GesPresta.Default" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="text-align: center;">
    <form id="form1" runat="server">
        <div>
        </div>
        <uc1:Cabecera ID="Cabecera1" runat="server" />

         <div style="display: grid">
             <div style="align-self: center; justify-self: center">
                <p style="text-align: left">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pulvinar mattis dictum. Vestibulum ultrices et nisl vel gravida. Pellentesque diam.
                </p>
                <p style="text-align: left">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi neque metus, porttitor quis molestie non.
                </p>
                <p style="text-align: left">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit: <a href="https://es.lipsum.com/feed/html" target="_blank">ayuda.social@acme.com</a>
                </p>
            </div>
         </div>
    </form>
</body>
</html>
