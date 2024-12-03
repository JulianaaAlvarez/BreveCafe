using AppBreveCafe.entidades;
using AppBreveCafe.logica;
using BreveCafe.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class RegistrarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClUsuarioE nuevoProveedor = new ClUsuarioE();

            nuevoProveedor.documento = txtDocumento.Text.Trim();
            nuevoProveedor.nombres = txtNombres.Text.Trim();
            nuevoProveedor.apellidos = txtApellidos.Text.Trim();
            nuevoProveedor.telefono = txtTelefono.Text.Trim();
            nuevoProveedor.email = txtEmail.Text.Trim();
            nuevoProveedor.nit = txtNit.Text.Trim();
            nuevoProveedor.nombreEmpresa = txtNombreEmpresa.Text.Trim();
            nuevoProveedor.insumo = txtInsumo.Text.Trim();
          

            ClRegistrarProveedorL objProveedorL = new ClRegistrarProveedorL();
            int result = objProveedorL.mtdRegistrarProveedor(nuevoProveedor);
        }
    }
}