using System;
using System.Data.SqlClient;
using BreveCafe.entidades;

namespace BreveCafe.datos
{
    public class ClPedidoD
    {
        private ClconexionD conexion = new ClconexionD();

        public int CrearPedido(ClPedidoE pedido)
        {
            int idPedido = 0;
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = @"INSERT INTO pedido (fecha, hora, estado, metodoPago, total, idUsuario, idMesa, idCarrito) 
                               OUTPUT INSERTED.idPedido 
                               VALUES (@fecha, @hora, @estado, @metodoPago, @total, @idUsuario, @idMesa, @idCarrito)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fecha", pedido.fecha);
                    command.Parameters.AddWithValue("@hora", pedido.hora);
                    command.Parameters.AddWithValue("@estado", pedido.estado);
                    command.Parameters.AddWithValue("@metodoPago", pedido.metodoPago);
                    command.Parameters.AddWithValue("@total", pedido.total);
                    command.Parameters.AddWithValue("@idUsuario", pedido.idUsuario);
                    command.Parameters.AddWithValue("@idMesa", pedido.idMesa);
                    command.Parameters.AddWithValue("@idCarrito", pedido.idCarrito);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idPedido = (int)result;
                    }
                }
            }
            catch (Exception)
            {
                idPedido = 0;
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }

            return idPedido;
        }
    }
}