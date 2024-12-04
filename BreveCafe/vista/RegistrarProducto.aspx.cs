using BreveCafe.entidades;
using productoBreve.entidades;
using productoBreve.logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBreveCafe.vista
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        private ClRegistrarProductoL registroProductoL = new ClRegistrarProductoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategoria();
                CargarCategoriasBusqueda();  // Método para cargar las categorías en el filtro de búsqueda
                CargarProductos();
            }
        }

        private void CargarCategoria()
        {
            List<ClCategoriaE> listarCategoria = registroProductoL.listarCategoria();
            ddlCategoria.Items.Clear();
            ddlCategoria.Items.Add(new ListItem("Seleccione una categoria", ""));
            if (listarCategoria != null && listarCategoria.Count > 0)
            {
                foreach (ClCategoriaE categoria in listarCategoria)
                {
                    string texto = $"{categoria.categoria}";
                    ddlCategoria.Items.Add(new ListItem(texto, categoria.idCategoria.ToString()));
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al cargar las categorias.');", true);
            }
        }

        private void CargarCategoriasBusqueda()
        {
            List<ClCategoriaE> listarCategoria = registroProductoL.listarCategoria();
            ddlBuscarCategoria.Items.Clear();
            ddlBuscarCategoria.Items.Add(new ListItem("Mostrar todos", "")); // Agregar la opción "Mostrar todos"
            if (listarCategoria != null && listarCategoria.Count > 0)
            {
                foreach (ClCategoriaE categoria in listarCategoria)
                {
                    ddlBuscarCategoria.Items.Add(new ListItem(categoria.categoria, categoria.idCategoria.ToString()));
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al cargar las categorías.');", true);
            }
        }

        protected void ddlBuscarCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategoriaSeleccionada;
            if (int.TryParse(ddlBuscarCategoria.SelectedValue, out idCategoriaSeleccionada) && idCategoriaSeleccionada != 0)
            {
                CargarProductosPorCategoria(idCategoriaSeleccionada);
            }
            else
            {
                CargarProductos(); // Si selecciona "Mostrar todos", se cargan todos los productos
            }
        }

        private void CargarProductosPorCategoria(int idCategoria)
        {
            DataTable productos = registroProductoL.ObtenerProductosPorCategoria(idCategoria);

            if (productos != null && productos.Rows.Count > 0)
            {
                dtProducto.DataSource = productos;
                dtProducto.DataBind();
            }
            else
            {
                productos.Rows.Add(productos.NewRow());
                dtProducto.DataSource = productos;
                dtProducto.DataBind();
                dtProducto.Rows[0].Cells.Clear();
                dtProducto.Rows[0].Cells.Add(new TableCell
                {
                    ColumnSpan = dtProducto.Columns.Count,
                    Text = "No hay productos disponibles para esta categoría.",
                    HorizontalAlign = HorizontalAlign.Center
                });
            }
        }

        // Registrar producto
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagen.HasFile)
                {
                    string rutaImagen = Server.MapPath("../assets/img/") + imagen.FileName;
                    imagen.SaveAs(rutaImagen);

                    ClRegistrarProductoE producto = new ClRegistrarProductoE
                    {
                        referencia = referencia.Text,
                        nombreProducto = nombre.Text,
                        descripcion = descripcion.Text,
                        imagen = "../assets/img/" + imagen.FileName,
                        precio = decimal.Parse(precio.Text),
                        cantidadStock = int.Parse(stock.Text),
                    };

                    ClCategoriaE oCategoria = new ClCategoriaE()
                    {
                        idCategoria = int.Parse(ddlCategoria.SelectedValue)
                    };

                    bool registroCompleto = registroProductoL.mtdRegistrarProducto(producto, oCategoria);

                    if (registroCompleto)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto registrado exitosamente!');", true);
                        LimpiarFormulario();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error no se registro el Producto');", true);
                    }
                }
                else
                {
                    lblCatch.Text = "Por favor, cargue una imagen.";
                }
            }
            catch (FormatException fe)
            {
                lblCatch.Text = "Error de formato en uno de los campos: " + fe.Message;
            }
            catch (Exception ex)
            {
                lblCatch.Text = "Error: " + ex.Message;
            }
        }

        // Limpiar formulario
        private void LimpiarFormulario()
        {
            referencia.Text = string.Empty;
            nombre.Text = string.Empty;
            descripcion.Text = string.Empty;
            precio.Text = string.Empty;
            stock.Text = string.Empty;
            ddlCategoria.SelectedIndex = 0;
        }

        // Eliminar producto
        private void EliminarProducto(int idProducto)
        {
            try
            {
                bool eliminacionExitosa = registroProductoL.EliminarProducto(idProducto);
                if (eliminacionExitosa)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto Eliminado exitosamente!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: no se pudo eliminar el Producto.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Error inesperado: {ex.Message}');", true);
            }
        }

        // Evento de paginación
        protected void dtProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtProducto.PageIndex = e.NewPageIndex;

            int idCategoriaSeleccionada;
            if (int.TryParse(ddlBuscarCategoria.SelectedValue, out idCategoriaSeleccionada) && idCategoriaSeleccionada != 0)
            {
                CargarProductosPorCategoria(idCategoriaSeleccionada); // Filtrar productos por la categoría seleccionada
            }
            else
            {
                CargarProductos(); // Si no se ha seleccionado una categoría, mostrar todos los productos
            }
        }

        // Cargar productos con paginación
        private void CargarProductos()
        {
            DataTable productos = registroProductoL.ObtenerProductos();

            if (productos != null && productos.Rows.Count > 0)
            {
                dtProducto.DataSource = productos;
                dtProducto.DataBind();
            }
            else
            {
                productos.Rows.Add(productos.NewRow());
                dtProducto.DataSource = productos;
                dtProducto.DataBind();
                dtProducto.Rows[0].Cells.Clear();
                dtProducto.Rows[0].Cells.Add(new TableCell
                {
                    ColumnSpan = dtProducto.Columns.Count,
                    Text = "No hay productos disponibles.",
                    HorizontalAlign = HorizontalAlign.Center
                });
            }
        }

        // Evento de RowCommand (Editar/Eliminar)
        protected void dtProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProducto;
            if (int.TryParse(e.CommandArgument.ToString(), out idProducto))
            {
                if (e.CommandName == "Editar")
                {
                    Response.Redirect($"EditarProductos.aspx?idProducto={idProducto}");
                }
                else if (e.CommandName == "Eliminar")
                {
                    EliminarProducto(idProducto);
                }
            }
            else
            {
                lblCatch.Text = "El ID del producto no es válido.";
            }
        }
    }
}
