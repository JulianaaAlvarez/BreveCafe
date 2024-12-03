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
                Response.Write("<script>alert('El email es obligatorio');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Response.Write("<script>alert('La contraseña es obligatoria');</script>");
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

                        Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Contraseña incorrecta');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No se encontró el usuario');</script>");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClUsuarioE nuevoUsuario = new ClUsuarioE();

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                Response.Write("<script>alert('El documento es obligatorio');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                Response.Write("<script>alert('Los nombres son obligatorios');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                Response.Write("<script>alert('Los apellidos son obligatorios');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                Response.Write("<script>alert('El teléfono es obligatorio');</script>");
                return;
            }

            if (txtTelefono.Text.Length != 10 || !txtTelefono.Text.All(char.IsDigit))
            {
                Response.Write("<script>alert('El teléfono debe tener exactamente 10 números');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmailRegistro.Text))
            {
                Response.Write("<script>alert('El email es obligatorio');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContrasenaRegistro.Text))
            {
                Response.Write("<script>alert('La contraseña es obligatoria');</script>");
                return;
            }

            if (!IsValidEmail(txtEmailRegistro.Text))
            {
                Response.Write("<script>alert('El email no tiene un formato válido');</script>");
                return;
            }
            if (!IsValidPassword(txtContrasenaRegistro.Text))
            {
                Response.Write("<script>alert('La contraseña debe tener al menos 8 caracteres, una mayúscula y un número');</script>");
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
                Response.Write("<script>alert('El correo ya está registrado. Intente con otro correo.');</script>");
            }
            else if (result > 0)
            {
                EnviarCorreo(nuevoUsuario.email, nuevoUsuario.nombres);
                Response.Write("<script>alert('Usuario registrado con éxito');</script>");
            }
            else
            {
                Response.Write("<script>alert('El usuario no fue registrado');</script>");
            }
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

                    mailMessage.Body = $"Hola {nombreUsuario},\n\n" +
                                       "Gracias por registrarte en nuestra plataforma. Tu cuenta ha sido creada con éxito.\n\n" +
                                       "¡Bienvenido!";

                    mailMessage.IsBodyHtml = false;

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
