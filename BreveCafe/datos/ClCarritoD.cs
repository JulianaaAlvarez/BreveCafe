using BreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BreveCafe.datos
{
    public class ClCarritoD
    {
        private ClconexionD conexion = new ClconexionD();

        public ClCarritoE ObtenerCarritoPorUsuario(int idUsuario)
        {
            ClCarritoE carrito = null;
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "SELECT idCarrito, fechaCreacion, idUsuario FROM carro WHERE idUsuario = @idUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carrito = new ClCarritoE
                            {
                                idCarrito = (int)reader["idCarrito"],
                                fechaCreacion = (DateTime)reader["fechaCreacion"],
                                idUsuario = (int)reader["idUsuario"],
                                estado = "Activo" // Valor por defecto
                            };
                        }
                    }
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }

            return carrito;
        }

        public void AgregarProductoAlCarrito(int idCarrito, PedidoProducto pedidoProducto)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "INSERT INTO pedidoProducto (idCarrito, idProducto, cantidad, observaciones) " +
                               "VALUES (@idCarrito, @idProducto, @cantidad, @observaciones)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCarrito", idCarrito);
                    command.Parameters.AddWithValue("@idProducto", pedidoProducto.idProducto);
                    command.Parameters.AddWithValue("@cantidad", pedidoProducto.cantidad);
                    command.Parameters.AddWithValue("@observaciones", pedidoProducto.observaciones ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
        }

        public int CrearCarrito(int idUsuario)
        {
            int idCarrito;
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "INSERT INTO carro (fechaCreacion, idUsuario) OUTPUT INSERTED.idCarrito VALUES (@fechaCreacion, @idUsuario)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    idCarrito = (int)command.ExecuteScalar();
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }

            return idCarrito;
        }

        public List<PedidoProducto> ObtenerProductosDelCarrito(int idCarrito)
        {
            var productos = new List<PedidoProducto>();
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = @"
                    SELECT pp.*, p.nombre, p.precio 
                    FROM pedidoProducto pp
                    INNER JOIN producto p ON pp.idProducto = p.idProducto
                    WHERE pp.idCarrito = @idCarrito";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCarrito", idCarrito);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new PedidoProducto
                            {
                                idPedidoProducto = (int)reader["idPedidoProducto"],
                                idCarrito = (int)reader["idCarrito"],
                                idProducto = (int)reader["idProducto"],
                                cantidad = (int)reader["cantidad"],
                                observaciones = reader["observaciones"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                precio = (decimal)reader["precio"]
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

        public void EliminarProductoDelCarrito(int idCarrito, int idProducto)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "DELETE FROM pedidoProducto WHERE idCarrito = @idCarrito AND idProducto = @idProducto";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCarrito", idCarrito);
                    command.Parameters.AddWithValue("@idProducto", idProducto);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
        }

        public void ActualizarCantidadProducto(int idCarrito, int idProducto, int cantidad)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "UPDATE pedidoProducto SET cantidad = @cantidad WHERE idCarrito = @idCarrito AND idProducto = @idProducto";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cantidad", cantidad);
                    command.Parameters.AddWithValue("@idCarrito", idCarrito);
                    command.Parameters.AddWithValue("@idProducto", idProducto);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
        }

        public List<string> ObtenerMesas()
        {
            List<string> mesas = new List<string>();
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "SELECT numeroMesa FROM mesa";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mesas.Add(reader["numeroMesa"].ToString());
                        }
                    }
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }

            return mesas;
        }

        public void MarcarCarritoComoProcesado(int idCarrito)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "UPDATE carro SET estado = 'Procesado' WHERE idCarrito = @idCarrito";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCarrito", idCarrito);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
        }

        public void CrearNuevoCarritoParaUsuario(int idUsuario)
        {
            SqlConnection connection = conexion.MtdAbrirConexion();

            try
            {
                string query = "INSERT INTO carro (fechaCreacion, idUsuario, estado) VALUES (@fechaCreacion, @idUsuario, 'Activo')";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
        }
    }
}