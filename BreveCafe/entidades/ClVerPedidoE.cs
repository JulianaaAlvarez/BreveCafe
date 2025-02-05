using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreveCafe.entidades
{
    public class ClVerPedidoE
    {
        public class clPedidoE
        {
            public int idPedido { get; set; }
            public DateTime fecha { get; set; }
            public string hora { get; set; }
            public string estado { get; set; }
            public string metodoPago { get; set; }
            public decimal total { get; set; }
            public string Usuario { get; set; }
            public string Correo { get; set; }
            public string Mesa { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
        }

    }
}