using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBreveCafe.vista
{
    public partial class MaestraAdministrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblInicio.Text = "Bienvenido: " + Session["admin"];
        }
    }
}