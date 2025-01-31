using BreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BreveCafe.datos
{
    public class ClMenuD
    {
        private ClconexionD conexion = new ClconexionD();

        // Método para obtener los productos agrupados por categoría
        public List<ClMenuE> mtdListarProductos()
        {
            List<ClMenuE> productos = new List<ClMenuE>();
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spCategoria", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new ClMenuE
                            {
                                idProducto = reader.GetInt32(reader.GetOrdinal("idProducto")),
                                nombre = reader.GetString(reader.GetOrdinal("ProductoNombre")),
                                descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                imagen = reader.GetString(reader.GetOrdinal("imagen")),
                                idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria")),
                                categoria = reader.GetString(reader.GetOrdinal("CategoriaNombre"))
                            });
                        }
                    }
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return productos;
        }

        // Método para obtener un producto por su id (CORREGIDO)
        public ClMenuE ObtenerProductoPorId(int idProducto)
        {
            ClMenuE producto = null;
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT p.*, c.categoria FROM producto p INNER JOIN categoria c ON p.idCategoria = c.idCategoria WHERE p.idProducto = @idProducto", connection))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new ClMenuE
                            {
                                idProducto = reader.GetInt32(reader.GetOrdinal("idProducto")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                imagen = reader.GetString(reader.GetOrdinal("imagen")),
                                idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria")),
                                categoria = reader.GetString(reader.GetOrdinal("categoria"))
                            };
                        }
                    }
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return producto;
        }

        // Nuevo método para listar las categorías
        public List<string> mtdListarCategorias()
        {
            List<string> categorias = new List<string>();
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spCategorias", connection)) // Asumiendo que existe un procedimiento almacenado spCategorias
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorias.Add(reader.GetString(reader.GetOrdinal("CategoriaNombre")));
                        }
                    }
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }

            return categorias;
        }
    }
}

