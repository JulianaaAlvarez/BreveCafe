using AppBreveCafe.datos;
using AppBreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBreveCafe.logica
{
    public class ClLoginL
    {

        public ClUsuarioE MtdLoginUsuarios(ClUsuarioE objDatosUsuario)
        {

            ClLoginD objUsuarioD = new ClLoginD();
            ClUsuarioE objDatos = objUsuarioD.MtdLogin(objDatosUsuario);
            return objDatos;
        }
    }
}