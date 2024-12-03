using productoBreve.entidades;
using productoBreve.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cargarProductos();
            }
            

        }
        //private void cargarProductos()
        //{
        //    ClRegistrarProductoL logica = new ClRegistrarProductoL();
        //    List<ClRegistrarProductoE> productos = logica.ListarProductos();
        //    repeaterProductos.DataSource = productos;
        //    repeaterProductos.DataBind();
        //}
    }
}