using System;
using System.Collections.Generic;

namespace BreveCafe.entidades
{
    public class ClCarritoE
    {
        public int idCarrito { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int idUsuario { get; set; }
        public ICollection<PedidoProducto> PedidoProductos { get; set; }
    }

    public class PedidoProducto
    {
        public int idPedidoProducto { get; set; }
        public int idCarrito { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public string observaciones { get; set; }
        public decimal precio { get; set; }
        public string nombre { get; set; }
    }
}

