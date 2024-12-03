using AppBreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AppBreveCafe.datos;
using BreveCafe.datos;

namespace AppBreveCafe.datos
{
    public class ClRegistroUsuariosD
    {

        public int MtdRegistrarUsuario(ClUsuarioE objUsuario)
        {
            ClconexionD objConexion = new ClconexionD();
            SqlConnection conexion = objConexion.MtdAbrirConexion();

            
            string verificarCorreoQuery = "SELECT COUNT(*) FROM usuario WHERE email = @email";
            SqlCommand verificarCmd = new SqlCommand(verificarCorreoQuery, conexion);
            verificarCmd.Parameters.AddWithValue("@email", objUsuario.email);

            int count = (int)verificarCmd.ExecuteScalar();

            if (count > 0)
            {
                objConexion.MtdCerrarConexion();
                return -1; 
            }

            
            SqlCommand cmd = new SqlCommand("spInsertarUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Documento", objUsuario.documento);
            cmd.Parameters.AddWithValue("@Nombres", objUsuario.nombres);
            cmd.Parameters.AddWithValue("@Apellidos", objUsuario.apellidos);
            cmd.Parameters.AddWithValue("@Telefono", objUsuario.telefono);
            cmd.Parameters.AddWithValue("@Email", objUsuario.email);
            cmd.Parameters.AddWithValue("@Clave", objUsuario.clave);

            int filas = cmd.ExecuteNonQuery();
            objConexion.MtdCerrarConexion();
            return filas;



        }
    }
}