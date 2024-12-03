using System.Collections.Generic;
using System.Linq;
using BreveCafe.entidades;
using BreveCafe.datos;

namespace BreveCafe.logica
{
    public class ClMenuL
    {
        ClMenuD menuD = new ClMenuD();

        // Método para listar los productos agrupados por categoría
        public List<ClMenuE.CategoriaProductos> mtdListarProductosPorCategoria()
        {
            List<ClMenuE> productos = menuD.mtdListarProductos();

            var productosPorCategoria = productos
                .GroupBy(p => new { p.idCategoria, p.categoria }) // Agrupar por categoría
                .Select(grupo => new ClMenuE.CategoriaProductos
                {
                    idCategoria = grupo.Key.idCategoria,
                    Categoria = grupo.Key.categoria, // Cambiado para coincidir con el front-end
                    Productos = grupo.ToList()
                })
                .ToList();

            return productosPorCategoria;
        }

        // Nuevo método para listar las categorías
        public List<string> mtdListarCategorias()
        {
            // Obtener la lista de categorías desde el método de datos (suponiendo que ClMenuD tiene acceso a la base de datos)
            List<ClMenuE> productos = menuD.mtdListarProductos();

            // Seleccionar las categorías únicas
            var categorias = productos
                .Select(p => p.categoria)
                .Distinct()
                .ToList();

            return categorias;
        }
    }
}
