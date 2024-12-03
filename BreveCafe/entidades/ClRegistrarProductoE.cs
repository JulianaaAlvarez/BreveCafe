using BreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace productoBreve.entidades
{
    public class ClRegistrarProductoE:ClCategoriaE
    {
        public int idProducto { get; set; }
        public string referencia { get; set; }
        public string nombreProducto { get; set; }
        public int cantidadStock { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public decimal precio { get; set; }
        
    }
}