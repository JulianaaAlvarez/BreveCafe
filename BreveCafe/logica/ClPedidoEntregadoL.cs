using BreveCafe.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BreveCafe.logica
{
    public class ClPedidoEntregadoL
    {
        private readonly ClPedidoEntregadoD entrega;

        public ClPedidoEntregadoL()
        {
            entrega = new ClPedidoEntregadoD();
        }
        public DataTable obtenerEntregas()
        {
            return entrega.obtenerEntregas();
        }
    }
}