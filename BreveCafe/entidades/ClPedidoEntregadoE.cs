using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreveCafe.entidades
{
    public class ClPedidoEntregadoE
    {
        public int idPedido { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }
        public string metodoPago { get; set; }
        public decimal total { get; set; }
        public int idMesa { get; set; }
    }
}