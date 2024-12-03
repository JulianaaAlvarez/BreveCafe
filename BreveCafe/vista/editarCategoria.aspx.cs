using BreveCafe.entidades;
using BreveCafe.logica;
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class editarCategoria : System.Web.UI.Page
    {
        private ClRegistrarCategoriaL registroCategoriaL = new ClRegistrarCategoriaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idCategoria;
                if (int.TryParse(Request.QueryString["idCategoria"], out idCategoria))
                {
                    CargarCategoria(idCategoria);
                }
            }
        }

        private void CargarCategoria(int idCategoria)
        {
            // Cargar la categoría desde la base de datos
            DataTable dt = registroCategoriaL.ObtenerCategorias();
            DataRow row = dt.Select($"idCategoria = {idCategoria}").FirstOrDefault();
            if (row != null)
            {
                txtCategoria.Text = row["categoria"].ToString();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCategoria = Convert.ToInt32(Request.QueryString["idCategoria"]);
                string categoriaNueva = txtCategoria.Text.Trim();

                if (string.IsNullOrWhiteSpace(categoriaNueva))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo de categoría no puede estar vacío.');", true);
                    return;
                }

                bool actualizacionExitosa = registroCategoriaL.EditarCategoria(idCategoria, categoriaNueva);

                if (actualizacionExitosa)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Categoría actualizada exitosamente!');", true);
                    Response.Redirect("registroCategoria.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: no se pudo actualizar la categoría.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error inesperado: {ex.Message}');", true);
            }
        }
    }
}
