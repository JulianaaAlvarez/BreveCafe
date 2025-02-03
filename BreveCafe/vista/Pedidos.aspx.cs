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

        protected void gvCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMesa = (DropDownList)e.Row.FindControl("ddlMesa");
                if (ddlMesa != null)
                {
                    var mesas = carritoService.ObtenerMesas();
                    ddlMesa.DataSource = mesas;
                    ddlMesa.DataBind();

                    // Aquí podrías establecer un valor seleccionado si es necesario
                    // Ejemplo: ddlMesa.SelectedValue = producto.MesaId; si tienes el ID de la mesa asociada
                }
            }
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                carritoService.EliminarProductoDelCarrito(idUsuario, idProducto);
            }
            else if (e.CommandName == "Mas")
            {
                carritoService.AjustarCantidadProducto(idUsuario, idProducto, 1);
            }
            else if (e.CommandName == "Menos")
            {
                carritoService.AjustarCantidadProducto(idUsuario, idProducto, -1);
            }

            CargarCarrito();
        }

        protected void btnProcederPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pago.aspx");
        }
    }
}
