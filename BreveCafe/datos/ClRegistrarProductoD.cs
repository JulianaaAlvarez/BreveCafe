using productoBreve.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BreveCafe.datos;
using BreveCafe.entidades;
using System.Drawing;
using System.Data;

namespace productoBreve.datos
{
    public class ClRegistrarProductoD
    {
        private ClconexionD conexion = new ClconexionD();

        public bool mtdRegistrarProducto(ClRegistrarProductoE productos, ClCategoriaE categoria)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spRegistroProducto", connection);
            bool exito = false;
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@referencia", productos.referencia);
                cmd.Parameters.AddWithValue("@nombre", productos.nombreProducto);
                cmd.Parameters.AddWithValue("@cantidadStock", productos.cantidadStock);
                cmd.Parameters.AddWithValue("@descripcion", productos.descripcion);
                cmd.Parameters.AddWithValue("@imagenProducto", productos.imagen);
                cmd.Parameters.AddWithValue("@precio", productos.precio);
                cmd.Parameters.AddWithValue("@idCategoria", categoria.idCategoria);
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return exito;
        }

        public DataTable ObtenerProductosPorCategoria(int idCategoria)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spProductosPorCategoria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable productos = new DataTable();
            da.Fill(productos);
            conexion.MtdCerrarConexion();
            return productos;
        }


        public DataTable ObtenerProductos()
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("listarProductos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.MtdCerrarConexion();
            return dt;
        }

        public bool EditarProductos(int idProducto, string referencia, string nombre, int cantidadStock, string descripcion, decimal precio, int idCategoria)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spActualizarProducto", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            cmd.Parameters.AddWithValue("@referencia", referencia);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@cantidadStock", cantidadStock);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
            bool exito = false;

            try
            {
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return exito;
        }

        public List<ClCategoriaE> ListarCategoria()
        {
            List<ClCategoriaE> categorias = new List<ClCategoriaE>();
            ClconexionD con = new ClconexionD();
            SqlConnection conect = con.MtdAbrirConexion();
            {
                using (SqlCommand cmd = new SqlCommand("ListarCategorias", conect))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClCategoriaE categoria = new ClCategoriaE()
                            {
                                idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria")),
                                categoria = reader.GetString(reader.GetOrdinal("categoria"))
                            };
                            categorias.Add(categoria);
                        }
                    }
                }
            }
            return categorias;
        }

        public bool EliminarProducto(int idProducto)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spEliminarProducto", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            bool exito = false;

            try
            {
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return exito;
        }
    }
}
