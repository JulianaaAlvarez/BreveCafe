using AppBreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using BreveCafe.datos;

namespace AppBreveCafe.datos
{
    public class ClLoginD
    {

        public ClUsuarioE MtdLogin(ClUsuarioE objDatos)
        {
             ClUsuarioE objDatosUsuario = new ClUsuarioE();

            string rol = null;
            string nombre = null;
            string apellido = null;

            ClconexionD objConexion = new ClconexionD();

            using (SqlConnection connection = objConexion.MtdAbrirConexion())
            {
                SqlCommand command = new SqlCommand("Login", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", objDatos.email);
                command.Parameters.AddWithValue("@clave", objDatos.clave);

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        rol = reader["rol"].ToString();
                        nombre = reader["nombres"].ToString();
                        apellido = reader["apellidos"].ToString();
                    }
                }
            }

            objDatosUsuario.rol = rol;
            objDatosUsuario.nombres = nombre;
            objDatosUsuario.apellidos = apellido;

            return objDatosUsuario;
        }



    }
}