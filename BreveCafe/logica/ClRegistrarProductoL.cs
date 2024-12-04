using productoBreve.entidades;
using productoBreve.datos;
using System;
using System.Collections.Generic;
using BreveCafe.entidades;
using System.Data;

namespace productoBreve.logica
{
    public class ClRegistrarProductoL
    {
        private ClRegistrarProductoD registro = new ClRegistrarProductoD();

        public DataTable ObtenerProductos()
        {
            return registro.ObtenerProductos();
        }

        public bool mtdRegistrarProducto(ClRegistrarProductoE producto, ClCategoriaE categoria)
        {
            return registro.mtdRegistrarProducto(producto, categoria);
        }
        public List<ClCategoriaE> listarCategoria()
        {
            return registro.ListarCategoria();
        }
        public bool EliminarProducto(int idProducto)
        {
            return registro.EliminarProducto(idProducto);

        }
        public bool EditarProducto(int idProducto, string referencia, string nombre, int cantidadStock, string descripcion, decimal precio, int idCategoria)
        {
            return registro.EditarProductos(idProducto, referencia, nombre, cantidadStock, descripcion, precio, idCategoria);
        }

        internal bool EditarProducto(int idProducto, string nombreN, string descripcionN, string stockN, string precioN, string categoriaN)
        {
            throw new NotImplementedException();
        }
        public DataTable ObtenerProductosPorCategoria(int idCategoria)
        {
            return registro.ObtenerProductosPorCategoria(idCategoria);
        }


    }
}
