using System.Collections.Generic;

namespace BreveCafe.entidades
{
    public class ClMenuE
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public decimal precio { get; set; }
        public int idCategoria { get; set; }
        public string categoria { get; set; }

        public class CategoriaProductos
        {
            public int idCategoria { get; set; }
            public string Categoria { get; set; }
            public List<ClMenuE> Productos { get; set; }
        }
    }
}
