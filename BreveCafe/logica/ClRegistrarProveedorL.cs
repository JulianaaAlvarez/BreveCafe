using AppBreveCafe.datos;
using AppBreveCafe.entidades;
using BreveCafe.datos;
using BreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreveCafe.logica
{
    public class ClRegistrarProveedorL
    {

        public int mtdRegistrarProveedor(ClUsuarioE objProveedor)
        {
            ClRegistrarProveedorD objProveeDatos = new ClRegistrarProveedorD();
            int proveedor = objProveeDatos.mtdRegistrarProveedor(objProveedor);
            return proveedor;
        }
    }
}