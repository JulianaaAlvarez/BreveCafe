using BreveCafe.datos;
using BreveCafe.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class menu : System.Web.UI.Page
    {
        private ClCarritoL carritoL = new ClCarritoL();
        private ClCarritoD carritoD = new ClCarritoD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rol = Session["rol"] as string;
                if (rol == "Cliente")
                {
                    liInicio.Text = "Hola " + Session["Cliente"];

                    liSesion.Visible = false;
                    li1.Visible = true;
                }
                else
                {
                    liSesion.Visible = true;
                    li1.Visible = false;

                }

                ClMenuL menuL = new ClMenuL();
                var productosPorCategoria = menuL.mtdListarProductosPorCategoria();

                RepeaterCategorias.DataSource = productosPorCategoria;
                RepeaterCategorias.DataBind();
                Repeater1.DataSource = productosPorCategoria;
                Repeater1.DataBind();
            }
        }

        protected void btnAñadirCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("../login.aspx");
        }

    }
}