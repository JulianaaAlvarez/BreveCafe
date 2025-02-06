using BreveCafe.logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class Formulario_web1 : System.Web.UI.Page

    {
        private ClPedidoEntregadoL entregaL = new ClPedidoEntregadoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEntregas();
            }

        }
        private void CargarEntregas()
        {
            DataTable dt = entregaL.obtenerEntregas();
            gvEntregas.DataSource = dt;
            gvEntregas.DataBind();
        }
    }
}