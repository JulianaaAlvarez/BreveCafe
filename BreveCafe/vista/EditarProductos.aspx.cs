using AppBreveCafe.logica;
using BreveCafe.entidades;
using BreveCafe.logica;
using productoBreve.logica;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        private ClRegistrarProductoL registroProductoL = new ClRegistrarProductoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();

                int idProducto;
                if (int.TryParse(Request.QueryString["idProducto"], out idProducto))
                {
                    cargarProductos(idProducto);
                }
            }
        }

        private void CargarCategorias()
        {
            var categorias = registroProductoL.listarCategoria();

            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "categoria";
            ddlCategoria.DataValueField = "idCategoria";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una Categoría", ""));
        }

        private void cargarProductos(int idProducto)
        {
            DataTable dt = registroProductoL.ObtenerProductos();

            DataRow row = dt.Select($"idProducto = {idProducto}").FirstOrDefault();
            if (row != null)
            {
                referencia.Text = row["referencia"].ToString();
                nombre.Text = row["nombre"].ToString();
                descripcion.Text = row["descripcion"].ToString();
                stock.Text = row["cantidadStock"].ToString();
                precio.Text = row["precio"].ToString();

                string idCategoria = row["idCategoria"].ToString();
                if (ddlCategoria.Items.FindByValue(idCategoria) != null)
                {
                    ddlCategoria.SelectedValue = idCategoria;
                }
            }
        }

        protected void btnActualizar_Click1(object sender, EventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(Request.QueryString["idProducto"]);
                string referenciaN = referencia.Text.Trim();
                string nombreN = nombre.Text.Trim();
                string descripcionN = descripcion.Text.Trim();
                int stockN = int.Parse(stock.Text.Trim());
                decimal precioN = decimal.Parse(precio.Text.Trim());
                int idCategoria = int.Parse(ddlCategoria.SelectedValue);



                bool actualizacionExitosa = registroProductoL.EditarProducto(idProducto, referenciaN, nombreN, stockN, descripcionN, precioN, idCategoria);
                if (actualizacionExitosa)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto actualizado exitosamente!');", true);
                    Response.Redirect("RegistrarProducto.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: no se pudo actualizar el producto.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error inesperado: {ex.Message}');", true);
            }
        }
    }
}
