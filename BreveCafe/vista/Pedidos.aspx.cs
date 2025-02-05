using BreveCafe.logica;
using BreveCafe.entidades;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace BreveCafe.vista
{
    public partial class Pedidos : System.Web.UI.Page
    {
        private ClCarritoL carritoService = new ClCarritoL();
        private ClPedidoL pedidoService = new ClPedidoL();
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

                decimal total = productosDelCarrito.Sum(p => p.cantidad * p.precio);
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
                    ddlMesa.DataSource = mesas.Select(m => new { Text = m, Value = m });
                    ddlMesa.DataTextField = "Text";
                    ddlMesa.DataValueField = "Value";
                    ddlMesa.DataBind();
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

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                string metodoPago = hdnMetodoPago.Value;
                int idMesa = ObtenerMesaSeleccionada();

                // Validar que se haya seleccionado una mesa
                if (idMesa <= 0)
                {
                    MostrarMensaje("Por favor, seleccione una mesa.");
                    return;
                }

                // Validar que se haya seleccionado un método de pago
                if (string.IsNullOrEmpty(metodoPago))
                {
                    MostrarMensaje("Por favor, seleccione un método de pago.");
                    return;
                }

                int idPedido = pedidoService.CrearPedido(idUsuario, idMesa, metodoPago);

                if (idPedido > 0)
                {
                    MostrarMensaje("Pedido confirmado. ¡Gracias por su compra!");
                    Response.Redirect("DasboardCliente.aspx");
                }
                else
                {
                    MostrarMensaje("Hubo un error al procesar su pedido. Por favor, intente nuevamente.");
                }
            }
            catch // Removemos el parámetro 'ex' ya que no lo estamos usando
            {
                MostrarMensaje("Hubo un error al procesar su pedido. Por favor, intente nuevamente.");
            }
        }

        private int ObtenerMesaSeleccionada()
        {
            try
            {
                if (gvCarrito.Rows.Count > 0)
                {
                    DropDownList ddlMesa = (DropDownList)gvCarrito.Rows[0].FindControl("ddlMesa");
                    if (ddlMesa != null && !string.IsNullOrEmpty(ddlMesa.SelectedValue))
                    {
                        return Convert.ToInt32(ddlMesa.SelectedValue);
                    }
                }
            }
            catch (Exception)
            {
                // Si hay algún error en la conversión o al obtener el valor
            }
            return 0;
        }

        private void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert",
                $"alert('{mensaje.Replace("'", "\\'")}');", true);
        }
    }
}