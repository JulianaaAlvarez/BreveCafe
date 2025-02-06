using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BreveCafe.datos
{
    public class ClPedidoEntregadoD
    {
        private ClconexionD conexion = new ClconexionD();

        public DataTable obtenerEntregas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = conexion.MtdAbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("pedidosEntregados", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}