using BreveCafe.datos;
using System.Data;

namespace BreveCafe.logica
{
    public class ClVerPedidoL
    {
        private readonly ClVerPedidoD pedido;

        public ClVerPedidoL()
        {
            pedido = new ClVerPedidoD();
        }

        public DataTable obtenerPedidos(int? mesaNumero = null)
        {
            return pedido.obtenerPedidos(mesaNumero);
        }
    }
}
