using BreveCafe.datos;
using BreveCafe.entidades;
using System;
using System.Linq;

namespace BreveCafe.logica
{
    public class ClPedidoL
    {
        private readonly ClPedidoD _pedidoRepository = new ClPedidoD();
        private readonly ClCarritoL _carritoService = new ClCarritoL();

        public int CrearPedido(int idUsuario, int idMesa, string metodoPago)
        {
            try
            {
                var carrito = _carritoService.ObtenerCarritoPorUsuario(idUsuario);
                if (carrito == null)
                {
                    return 0;
                }

                var productosCarrito = _carritoService.ObtenerProductosDelCarrito(carrito.idCarrito);
                if (productosCarrito == null || !productosCarrito.Any())
                {
                    return 0;
                }

                var pedido = new ClPedidoE
                {
                    fecha = DateTime.Now.Date,
                    hora = DateTime.Now.TimeOfDay,
                    estado = "Pendiente",
                    metodoPago = metodoPago,
                    total = productosCarrito.Sum(p => p.cantidad * p.precio),
                    idUsuario = idUsuario,
                    idMesa = idMesa,
                    idCarrito = carrito.idCarrito
                };

                int idPedido = _pedidoRepository.CrearPedido(pedido);

                if (idPedido > 0)
                {
                    _carritoService.ProcesarCarrito(idUsuario);
                }

                return idPedido;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}