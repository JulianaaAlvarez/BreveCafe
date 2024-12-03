using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BreveCafe.datos
{
    public class ClconexionD
    {
        private SqlConnection conex; // Campo privado para la conexión

        public ClconexionD()
        {
            conex = new SqlConnection("Data Source=. ;Initial Catalog=bdBreveCafe;Integrated Security=True;");
        }

        public SqlConnection MtdAbrirConexion()
        {
            
                conex.Open();
            
            return conex; // Retornar la conexión
        }
        public void MtdCerrarConexion()
        {
            conex.Close();
        }

    }
}