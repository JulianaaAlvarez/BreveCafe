using BreveCafe.logica;
using BreveCafe.entidades;
using BreveCafe.datos;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBreveCafe.vista
{
    public partial class DasboardCliente : System.Web.UI.Page
    {
        private ClCarritoL carritoL = new ClCarritoL();
        private ClCarritoD carritoD = new ClCarritoD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClMenuL menuL = new ClMenuL();
                var productosPorCategoria = menuL.mtdListarProductosPorCategoria();

                RepeaterCategorias.DataSource = productosPorCategoria;
                RepeaterCategorias.DataBind();
                Repeater1.DataSource = productosPorCategoria;
                Repeater1.DataBind();
            }
        }

        protected void btnPedir_Command(object sender, CommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            int idUsuario = Convert.ToInt32(Session["idUsuario"] ?? "1");

            PedidoProducto pedidoProducto = new PedidoProducto
            {
                idProducto = idProducto,
                cantidad = 1,
                observaciones = null
            };

            carritoL.AgregarProductoAlCarrito(idUsuario, pedidoProducto);

            ScriptManager.RegisterStartupScript(this, GetType(), "alert", @"
    Swal.fire({
        icon: 'success',
        title: '¡Éxito!',
        text: 'Producto agregado al carrito'
    });
", true);

        }
    }
}
