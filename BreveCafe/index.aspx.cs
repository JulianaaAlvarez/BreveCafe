using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rol = Session["rol"] as string;
            if (rol == "Cliente")
            {
                lblInicio.Text = "Bienvenido: " + Session["Cliente"];


                li.Visible = false;
                li2.Visible = true;
            }
            else
            {
                li.Visible = true;
                li2.Visible = false;
            }
        }
    }
}