using System;
using System.Data;
using System.Data.SqlClient;

namespace BreveCafe.datos
{
    public class ClVerPedidoD
    {
        private ClconexionD conexion = new ClconexionD();

        public DataTable obtenerPedidos(int? mesaNumero = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = conexion.MtdAbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("verPedidos", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (mesaNumero.HasValue)
                {
                    cmd.Parameters.AddWithValue("@mesaNumero", mesaNumero.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@mesaNumero", DBNull.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
