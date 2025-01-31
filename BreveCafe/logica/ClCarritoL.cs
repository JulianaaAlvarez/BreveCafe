using BreveCafe.datos;
using BreveCafe.entidades;
using System.Collections.Generic;

namespace BreveCafe.logica
{
    public class ClCarritoL
    {
        private readonly ClCarritoD _repository = new ClCarritoD();
        private readonly ClMenuD _productoRepository = new ClMenuD();

        public ClCarritoE ObtenerCarritoPorUsuario(int idUsuario)
        {
            return _repository.ObtenerCarritoPorUsuario(idUsuario);
        }

        public void AgregarProductoAlCarrito(int idUsuario, PedidoProducto pedidoProducto)
        {
            var carrito = _repository.ObtenerCarritoPorUsuario(idUsuario);

            if (carrito == null)
            {
                int idCarrito = _repository.CrearCarrito(idUsuario);
                carrito = new ClCarritoE { idCarrito = idCarrito, idUsuario = idUsuario };
            }

            var producto = _productoRepository.ObtenerProductoPorId(pedidoProducto.idProducto);
            if (producto != null)
            {
                pedidoProducto.precio = producto.precio;
            }

            _repository.AgregarProductoAlCarrito(carrito.idCarrito, pedidoProducto);
        }

        public List<PedidoProducto> ObtenerProductosDelCarrito(int idCarrito)
        {
            return _repository.ObtenerProductosDelCarrito(idCarrito);
        }

        public void EliminarProductoDelCarrito(int idUsuario, int idProducto)
        {
            var carrito = _repository.ObtenerCarritoPorUsuario(idUsuario);

            if (carrito != null)
            {
                _repository.EliminarProductoDelCarrito(carrito.idCarrito, idProducto);
            }
        }
    }
}

