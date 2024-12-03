<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CerrarSesion.aspx.cs" Inherits="BreveCafe.CerrarSesion" %>


<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Cerrar Sesión</title>
</head>
<body>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("../index.aspx");
        }
    </script>
</body>
</html>
