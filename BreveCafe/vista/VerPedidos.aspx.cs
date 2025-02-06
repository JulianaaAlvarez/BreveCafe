using BreveCafe.logica;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class VerPedidos : Page
    {
        private ClVerPedidoL pedidoL = new ClVerPedidoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos(int? mesaNumero = null)
        {
            DataTable dt = pedidoL.obtenerPedidos(mesaNumero);
            gvPedidos.DataSource = dt;
            gvPedidos.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int mesaNumero;
            if (int.TryParse(txtMesa.Text.Trim(), out mesaNumero))
            {
                CargarPedidos(mesaNumero);
            }
            else
            {
                CargarPedidos(); 
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtMesa.Text = ""; 
            CargarPedidos(); 
        }

        protected void btnEntregar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idPedido = Convert.ToInt32(btn.CommandArgument);

            ClVerPedidoL pedidoL = new ClVerPedidoL();
            bool actualizado = pedidoL.ActualizarEstadoPedido(idPedido, "Entregado");

            if (actualizado)
            {
                CargarPedidos(); // Recargar los pedidos para reflejar el cambio
            }
        }

    }
}
