using BreveCafe.entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BreveCafe.datos
{
    public class ClRegistroCategoriaD
    {
        private ClconexionD conexion = new ClconexionD();

        public bool mtdRegistrarCategoria(ClCategoriaE categoria)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spRegistroCategoria", connection);
            bool exito = false;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoria", categoria.categoria);
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

        public DataTable ObtenerCategorias()
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("ListarCategorias", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            conexion.MtdCerrarConexion();
            return dt;
        }

        public bool EliminarCategoria(int idCategoria)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spEliminarCategorias", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
        public bool EditarCategoria(int idCategoria, string categoria)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();
            SqlCommand cmd = new SqlCommand("spEditarCategoria", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
            cmd.Parameters.AddWithValue("@categoria", categoria);
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
