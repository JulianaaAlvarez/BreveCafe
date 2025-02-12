<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AppBreveCafe.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar sesion</title>
   
    <link href="vista/css/styleDash.css" rel="stylesheet" />
    <script src="vista/js/JavaScriptLogin.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>


  
    <style>
        html {
    background: url('vista/imagenes/breveladrillosC.png') no-repeat center center fixed;
    background-size: cover;
}
    </style>

</head>
<body>
<form id="form1" runat="server">
    <div class="wrapper fadeInDown">
        <div id="formContent">
            <!-- Tabs Titles -->
            <h2 class="active" id="signInTab" onclick="showSignIn()"> Iniciar sesión</h2>
            <h2 class="inactive underlineHover" id="signUpTab" onclick="showSignUp()"> Registrarse </h2>

            <!-- Icon -->
            <div class="fadeIn first">
                <img src="vista/imagenes/brevelogo.png" id="breveLogo" alt="User Icon" style="width: 150px; height: auto;" />
                <img src="vista/imagenes/breve%20nombre.png" id="breveNombre" alt="User Icon" style="width: 300px; height: auto;" />
            </div>

            <!-- Login Form -->
            <div id="loginForm">
                <asp:TextBox ID="txtEmail" runat="server" Class="fadeIn second" placeholder="Email"></asp:TextBox>
                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" Class="fadeIn second error-message" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtEmail"   ></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txtPassword" runat="server" Class="fadeIn third" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" Class="fadeIn second error-message" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtPassword"   ></asp:RequiredFieldValidator>--%>
                <br />
             
                <asp:Button ID="btnLogin" runat="server" Class="fadeIn fourth" Text="Iniciar sesión" OnClick="btnIngresar_Click"/>
            </div>

            <!-- Sign Up Form -->
            <div id="signUpForm" style="display: none;">

                <asp:TextBox ID="txtDocumento" runat="server" Class="fadeIn second" placeholder="Documento"></asp:TextBox>
                 
                <asp:TextBox ID="txtNombres" runat="server" Class="fadeIn second " placeholder="Nombres"></asp:TextBox>
       

                <asp:TextBox ID="txtApellidos" runat="server" Class="fadeIn second" placeholder="Apellidos"></asp:TextBox>
            

                <asp:TextBox ID="txtTelefono" runat="server" Class="fadeIn second" placeholder="Telefono"></asp:TextBox>
              

                <asp:TextBox ID="txtEmailRegistro" runat="server" Class="fadeIn second" placeholder="Email"></asp:TextBox>


                <asp:TextBox ID="txtContrasenaRegistro" runat="server" TextMode="Password" placeholder="Contraseña" class="fadeIn third"></asp:TextBox>





                <asp:Button ID="btnRegistrar" runat="server" Class="fadeIn fourth" Text="Registrarme" OnClick="btnRegistrar_Click"/>
            </div>

            <!-- Remind Password -->
            <div id="formFooter">
                <a class="underlineHover" href="#"> ¿Olvidaste tu contraseña?</a>
            </div>
        </div>
    </div>
</form>
 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</body>
</html>



