using System;
using System.Collections.Generic;

namespace BreveCafe.entidades
{
    public class ClPedidoE
    {
        public int idPedido { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public string estado { get; set; }
        public string metodoPago { get; set; }
        public decimal total { get; set; }
        public int idUsuario { get; set; }
        public int idMesa { get; set; }
        public int idCarrito { get; set; }
        public string NombreCliente { get; set; }
        public string NumeroMesa { get; set; }
        public List<PedidoProducto> Productos { get; set; }
    }
}

