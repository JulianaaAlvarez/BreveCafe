using AppBreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BreveCafe.datos
{
    public class ClRegistrarProveedorD
    {
        public int mtdRegistrarProveedor (ClUsuarioE objProveedor)
        {
            ClconexionD objConexion = new ClconexionD();
            SqlConnection conexion = objConexion.MtdAbrirConexion();


            SqlCommand cmd = new SqlCommand("spRegistrarProveedor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@documento", objProveedor.documento);
            cmd.Parameters.AddWithValue("@nombres", objProveedor.nombres);
            cmd.Parameters.AddWithValue("@apellidos", objProveedor.apellidos);
            cmd.Parameters.AddWithValue("@telefono", objProveedor.telefono);
            cmd.Parameters.AddWithValue("@email", objProveedor.email);
            cmd.Parameters.AddWithValue("@nit", objProveedor.nit);
            cmd.Parameters.AddWithValue("@nombreEmpresa", objProveedor.nombreEmpresa);
            cmd.Parameters.AddWithValue("@insumo", objProveedor.insumo);
            

            int proveedor = cmd.ExecuteNonQuery();
            objConexion.MtdCerrarConexion();
            return proveedor;

        }
    }
}