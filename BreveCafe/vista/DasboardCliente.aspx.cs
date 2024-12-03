using BreveCafe.logica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBreveCafe.vista
{
    public partial class DasboardCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear una instancia de la clase lógica para acceder a los productos agrupados por categoría
                ClMenuL menuL = new ClMenuL();
                var productosPorCategoria = menuL.mtdListarProductosPorCategoria();

                // Asignar la lista de productos agrupados al Repeater de categorías
                RepeaterCategorias.DataSource = productosPorCategoria;
                RepeaterCategorias.DataBind();
                Repeater1.DataSource = productosPorCategoria;
                Repeater1.DataBind();

            }
        }
    }
}
