using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBreveCafe.entidades
{
    public class ClLoginE
   
    {

        public int idRol { get; set; }
        public string rol { get; set; }

    }
    public class ClUsuarioE:ClLoginE

    {


        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string clave { get; set; }
        public string nit { get; set; }
        public string nombreEmpresa { get; set; }
        public string insumo { get; set; }
    
    }
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }


}
