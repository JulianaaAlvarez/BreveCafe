using BreveCafe.datos;
using BreveCafe.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BreveCafe.logica
{
    public class ClRegistrarCategoriaL
    {
        private ClRegistroCategoriaD registro = new ClRegistroCategoriaD();

        public bool mtdRegistrarCategoria(ClCategoriaE categoria)
        {
            return registro.mtdRegistrarCategoria(categoria);
        }

        public DataTable ObtenerCategorias()
        {
            return registro.ObtenerCategorias();
        }

        public bool EliminarCategoria(int idCategoria)
        {
            return registro.EliminarCategoria(idCategoria);
        }
        public bool EditarCategoria(int idCategoria, string categoria)
        {
            return registro.EditarCategoria(idCategoria, categoria);
        }

    }
}
