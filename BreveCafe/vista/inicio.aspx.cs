using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rol = Session["rol"] as string;
            if (rol == "Cliente")
            {
                lblInicio.Text = "Hola " + Session["Cliente"];


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