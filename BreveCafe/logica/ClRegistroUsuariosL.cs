using AppBreveCafe.datos;
using AppBreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBreveCafe.logica
{
    public class ClRegistroUsuariosL
    {
        public int MtdRegistrarUsuarioP(ClUsuarioE objUsuario)
        {
            ClRegistroUsuariosD objUsuarioDatos = new ClRegistroUsuariosD();
            int filas = objUsuarioDatos.MtdRegistrarUsuario(objUsuario);
            return filas;
        }
    }
}