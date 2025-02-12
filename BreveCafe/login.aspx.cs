using AppBreveCafe.entidades;
using AppBreveCafe.logica;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace AppBreveCafe
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MostrarSweetAlert("Error", "El email es obligatorio", "error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MostrarSweetAlert("Error", "La contraseña es obligatoria", "error");
                return;
            }

            ClUsuarioE objUsuarioE = new ClUsuarioE();
            objUsuarioE.email = txtEmail.Text;
            objUsuarioE.clave = EncryptPassword(txtPassword.Text);

            ClLoginL objUsuarioL = new ClLoginL();
            ClUsuarioE objUsuario = objUsuarioL.MtdLoginUsuarios(objUsuarioE);

            if (objUsuario != null)
            {
                if (!string.IsNullOrEmpty(objUsuario.rol))
                {
                    if (objUsuario.rol == "Administrador")
                    {
                        Session["admin"] = objUsuario.nombres;
                        Response.Redirect("vista/RegistrarProducto.aspx");
                    }
                    else if (objUsuario.rol == "Cliente")
                    {
                        Session["Cliente"] = objUsuario.nombres;
                        Session["rol"] = objUsuario.rol;
                        Response.Redirect("vista/inicio.aspx");
                    }
                }
                else
                {
                    MostrarSweetAlert("Error", "Usuario o Contraseña incorrecta", "error");
                }
            }
            else
            {
                MostrarSweetAlert("Error", "No se encontró el usuario", "error");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClUsuarioE nuevoUsuario = new ClUsuarioE();

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MostrarSweetAlert("Error", "El documento es obligatorio", "error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MostrarSweetAlert("Error", "Los nombres son obligatorios", "error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MostrarSweetAlert("Error", "Los apellidos son obligatorios", "error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarSweetAlert("Error", "El teléfono es obligatorio", "error");
                return;
            }

            if (txtTelefono.Text.Length != 10 || !txtTelefono.Text.All(char.IsDigit))
            {
                MostrarSweetAlert("Error", "El teléfono debe tener exactamente 10 números", "error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmailRegistro.Text))
            {
                MostrarSweetAlert("Error", "El email es obligatorio", "error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContrasenaRegistro.Text))
            {
                MostrarSweetAlert("Error", "La contraseña es obligatoria", "error");
                return;
            }

            if (!IsValidEmail(txtEmailRegistro.Text))
            {
                MostrarSweetAlert("Error", "El email no tiene un formato válido", "error");
                return;
            }
            if (!IsValidPassword(txtContrasenaRegistro.Text))
            {
                MostrarSweetAlert("Error", "La contraseña debe tener al menos 8 caracteres, una mayúscula y un número", "error");
                return;
            }

            nuevoUsuario.documento = txtDocumento.Text.Trim();
            nuevoUsuario.nombres = txtNombres.Text.Trim();
            nuevoUsuario.apellidos = txtApellidos.Text.Trim();
            nuevoUsuario.telefono = txtTelefono.Text.Trim();
            nuevoUsuario.email = txtEmailRegistro.Text.Trim();
            nuevoUsuario.clave = EncryptPassword(txtContrasenaRegistro.Text.Trim());

            ClRegistroUsuariosL objUsuarioL = new ClRegistroUsuariosL();
            int result = objUsuarioL.MtdRegistrarUsuarioP(nuevoUsuario);

            if (result == -1)
            {
                MostrarSweetAlert("Error", "El correo ya está registrado. Intente con otro correo.", "error");
            }
            else if (result > 0)
            {
                EnviarCorreo(nuevoUsuario.email, nuevoUsuario.nombres);
                MostrarSweetAlert("Éxito", "Usuario registrado con éxito", "success");
            }
            else
            {
                MostrarSweetAlert("Error", "El usuario no fue registrado", "error");
            }
        }

        private void MostrarSweetAlert(string titulo, string mensaje, string tipo)
        {
            string script = $"Swal.fire('{titulo}', '{mensaje}', '{tipo}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            return regex.IsMatch(password);
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void EnviarCorreo(string emailDestinatario, string nombreUsuario)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUser = "julianaalvarezrojas167@gmail.com";
                string smtpPassword = "uxag yhhx nyrf psxz";

                using (System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);

                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.From = new System.Net.Mail.MailAddress(smtpUser);
                    mailMessage.To.Add(emailDestinatario);
                    mailMessage.Subject = "Confirmación de registro";

                    // Cuerpo del correo en HTML
                    string htmlBody = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f9f9f9;
                    color: #333;
                    margin: 0;
                    padding: 0;
                }}
                .container {{
                    max-width: 600px;
                    margin: 20px auto;
                    background-color: #ffffff;
                    border: 1px solid #ddd;
                    border-radius: 8px;
                    padding: 20px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }}
                .header {{
                    text-align: center;
                    background-color: #4682B4; /* Azul acero oscuro */
                    color: #fff;
                    padding: 10px 0;
                    border-radius: 8px 8px 0 0;
                }}
                .content {{
                    padding: 20px;
                    text-align: center;
                }}
                .footer {{
                    text-align: center;
                    font-size: 12px;
                    color: #888;
                    margin-top: 20px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h1>¡Bienvenido a BreveCafe!</h1>
                </div>
                <div class='content'>
                    <p>Hola <strong>{nombreUsuario}</strong>,</p>
                    <p>Gracias por registrarte en nuestra plataforma. Tu cuenta ha sido creada con éxito.</p>
                    <p>Estamos encantados de tenerte con nosotros.</p>
                    <p><a href='#' style='color: #4CAF50; text-decoration: none;'>Visita nuestro sitio</a></p>
                </div>
                <div class='footer'>
                    <p>© 2024 BreveCafe. Todos los derechos reservados.</p>
                </div>
            </div>
        </body>
        </html>";

                    mailMessage.Body = htmlBody;
                    mailMessage.IsBodyHtml = true;

                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al enviar el correo: " + ex.Message + "');</script>");
            }
        }

    }
}
