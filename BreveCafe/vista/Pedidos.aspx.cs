using BreveCafe.logica;
using BreveCafe.entidades;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class Pedidos : System.Web.UI.Page
    {
        private ClCarritoL carritoService = new ClCarritoL();
        private int idUsuario = 1; // Asegúrate de obtener el ID de usuario de la sesión

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            var carrito = carritoService.ObtenerCarritoPorUsuario(idUsuario);
            if (carrito != null)
            {
                var productosDelCarrito = carritoService.ObtenerProductosDelCarrito(carrito.idCarrito);

                gvCarrito.DataSource = productosDelCarrito;
                gvCarrito.DataBind();

                decimal total = 0;
                foreach (var producto in productosDelCarrito)
                {
                    total += producto.cantidad * producto.precio;
                }
                lblTotal.Text = total.ToString("0.00");
            }
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                carritoService.EliminarProductoDelCarrito(idUsuario, idProducto);
                CargarCarrito();
            }
        }

        protected void btnProcederPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pago.aspx");
        }
    }
}

