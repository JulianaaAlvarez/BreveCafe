using BreveCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBreveCafe.vista
{
    public partial class MaestraCliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rol = Session["rol"] as string;
            if (rol == "Cliente")
            {
                liInicio.Text = "Bienvenido: " + Session["Cliente"];

                liSesion.Visible = false;
                li1.Visible = true;
            }
            else
            {
                liSesion.Visible = true;
                li1.Visible = false;

            }


        }
    }
}