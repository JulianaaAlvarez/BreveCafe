using BreveCafe.entidades;
using BreveCafe.logica;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreveCafe.vista
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        private ClRegistrarCategoriaL registroCategoriaL = new ClRegistrarCategoriaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoria.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo de categoría no puede estar vacío.');", true);
                    return;
                }

                ClCategoriaE categorias = new ClCategoriaE
                {
                    categoria = categoria.Text
                };

                bool registroCompleto = registroCategoriaL.mtdRegistrarCategoria(categorias);

                if (registroCompleto)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Categoria registrada exitosamente!');", true);
                    LimpiarFormulario();
                    CargarCategorias();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: no se pudo registrar la categoría.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error inesperado: {ex.Message}');", true);
            }
        }

        private void LimpiarFormulario()
        {
            categoria.Text = string.Empty;
        }

        private void CargarCategorias()
        {
            DataTable dt = registroCategoriaL.ObtenerCategorias();
            dtCategoria.DataSource = dt;
            dtCategoria.DataBind();
        }

        protected void dtCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCategoria = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Response.Redirect($"editarCategoria.aspx?idCategoria={idCategoria}");
            }
            else if (e.CommandName == "Eliminar")
            {
                EliminarCategoria(idCategoria);
            }
        }

        private void EliminarCategoria(int idCategoria)
        {
            try
            {
                bool eliminacionExitosa = registroCategoriaL.EliminarCategoria(idCategoria);
                if (eliminacionExitosa)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Categoria eliminada exitosamente!');", true);
                    CargarCategorias();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: no se pudo eliminar la categoría.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error inesperado: {ex.Message}');", true);
            }
        }
    }
}
