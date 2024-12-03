<%@ Page Title="Dashboard Admin" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="RegistrarProducto.aspx.cs" Inherits="AppBreveCafe.vista.DashboardAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
  /* Estilos para la tabla GridView */
.custom-gridview {
    width: 100%;
    border-collapse: collapse;
    margin: 20px 0;
    font-family: 'Arial', sans-serif;
    background-color: #ffffff;
    border: 1px solid #ddd;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Sombra suave */
}

.custom-gridview th {
    background-color: #ffcccc; /* Azul clarito */
    color:#9a3f3f;
    padding: 12px 15px;
    text-align: left;
    font-size: 14px;
    font-weight: bold;
    border-bottom: 2px solid #ddd;
}

.custom-gridview td {
    padding: 12px 15px;
    border-bottom: 1px solid #ddd;
    font-size: 14px;
    color: #555;
}

.custom-gridview tr:nth-child(even) {
    background-color: #f9f9f9; /* Fondo gris claro */
}

.custom-gridview tr:hover {
    background-color: #f1f1f1; /* Fondo al pasar el mouse */
}

.custom-gridview .gridview-pager {
    text-align: center;
    padding: 10px 0;
}

/* Estilos para los botones de acción */
.btn-action {
    width: 30px;
    height: 30px;
    margin-top: 5px;
    cursor: pointer;
    border-radius: 50%;
    transition: transform 0.2s, box-shadow 0.3s ease;
}

.btn-action:hover {
    transform: scale(1.5); /* Aumenta el tamaño del botón */
    box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.2); /* Sombra suave */
}

.btn-action:active {
    transform: scale(0.95); /* Reduce el tamaño cuando se presiona */
}

/* Pager Style */
.gridview-pager {
    font-size: 14px;
    margin-top: 10px;
}
/* Estilos de los botones de paginación */
.gridview-pager a {
    text-decoration: none;
    padding: 8px 12px;
    margin: 0 5px;
    background-color: #9a3f3f; /* Fondo rosa claro */
    color: white;
    border-radius: 5px;
    transition: background-color 0.3s;
}

.gridview-pager a:hover {
    background-color: #ac4343; /* Fondo rosa más oscuro al pasar el mouse */
    color: white;
}

.gridview-pager a:active {
    background-color: #ac4343; /* Fondo rosa aún más oscuro al hacer clic */
}

/* Estilo de la página actual (span) */
.gridview-pager span {
    padding: 8px 12px;
    margin: 0 5px;
    background-color: #9a3f3f; /* Fondo rosado muy suave para la página actual */
    color: #ac4343; /* Color por defecto de los enlaces */
    font-size: 14px;
}

/* Estilos generales del paginador */
.gridview-pager {
    font-size: 14px;
}

/* Estilo para los enlaces de paginación */
.gridview-pager a {
    color: #a13f3f; /* Cambiar a rosado claro jjjjjjjjjjjjjjjjjjjjjjjjjjjjj*/
    background-color: #ffcccc; /* Fondo transparente */
    border: 1px solid #ddd; /* Borde sutil */
    padding: 7px 14px;
    text-decoration: none;
    border-radius: 5px;
    margin: 5px;
    transition: background-color 0.3s, color 0.3s;
}

/* Hover sobre los enlaces de paginación */
.gridview-pager a:hover {
    background-color: #d36a6a; /* Fondo rosado claro */
    color: #ffffff; /* Cambiar texto a blanco en hover */
}

/* Estilo para el número de página activo */
.gridview-pager span {
    background-color: #bf6262; /* Fondo rosado claro */
    color: #ffffff; /* Texto blanco para el número activo */
    padding: 7px 14px;
    border-radius: 5px;
    margin: 5px;
}

/* Estilo para la paginación */
.gridview-pager {
    font-size: 14px;
    text-align: center;
}

/* Ajuste de tamaño de los números */
.gridview-pager a, .gridview-pager span {
    font-size: 12px; /* Tamaño de fuente de los números */
}
/* Clase personalizada para el botón */
.btn-custom {
    padding: 12px 30px;
    background-color: #bad6ee; /* Azul clarito */
    color: #0b4968; /* Color del texto en un azul oscuro */
    border: none;
    border-radius: 50px; /* Bordes redondeados */
    font-size: 16px;
    font-weight: bold;
    text-align: center;
    cursor: pointer;
    transition: all 0.3s ease; /* Transición suave para los efectos */
    display: inline-flex;
    align-items: center;
    justify-content: center;
}

.btn-custom:hover {
    background-color: #b2ebf2; /* Azul más oscuro cuando se pasa el mouse */
    transform: translateY(-5px); /* Efecto de elevación */
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1); /* Sombra sutil */
}

.btn-custom:active {
    background-color: #80deea; /* Cambio de color cuando se hace clic */
    transform: translateY(2px); /* Efecto de "presionar" */
    box-shadow: 0 3px 8px rgba(0, 0, 0, 0.1); /* Sombra más suave al presionar */
}

.btn-custom span {
    display: inline-block;
    transition: transform 0.3s ease;
}

.btn-custom:hover span {
    transform: scale(1.1); /* Aumenta el tamaño del texto al pasar el mouse */
}


    </style>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <link href="../assets/css/botonregistrarproducto.css" rel="stylesheet" />

    <div class="col-md-12 col-xl-10" id="main-content" style="background-color: white; min-height: 100vh;">
        <br />
        <br />

        <!-- Botón para registrar productos -->
   <button class="btn-custom mt-5" style="margin-left: 1cm;" type="button" data-bs-toggle="modal" data-bs-target="#exampleModal">
    <span>Registrar Productos</span>
</button>

        <br />
        <br />

<asp:GridView ID="dtProducto" runat="server" AutoGenerateColumns="False"
    CssClass="custom-gridview"
    OnRowCommand="dtProducto_RowCommand"
    AllowPaging="True"
    PageSize="5" OnPageIndexChanging="dtProducto_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="idProducto" HeaderText="ID Producto" SortExpression="idProducto" />
        <asp:BoundField DataField="referencia" HeaderText="Referencia" SortExpression="referencia" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
        <asp:BoundField DataField="cantidadStock" HeaderText="Cantidad Stock" SortExpression="cantidadStock" />
        <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" />
        <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
        <asp:BoundField DataField="idCategoria" HeaderText="ID Categoría" SortExpression="idCategoria" />

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server"
                    CommandName="Editar"
                    CommandArgument='<%# Eval("idProducto") %>'
                    CssClass="btn-action"
                    ImageUrl="imagenes/boligrafo.png"
                    AlternateText="Editar" />
                <br />
                <asp:ImageButton ID="btnEliminar" runat="server"
                    CommandName="Eliminar"
                    CommandArgument='<%# Eval("idProducto") %>'
                    CssClass="btn-action"
                    ImageUrl="imagenes/papelera.png"
                    AlternateText="Eliminar"
                    OnClientClick="return confirm('¿Estás seguro de eliminar este producto?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    <PagerSettings Mode="Numeric" Position="Bottom" />
    <PagerStyle CssClass="gridview-pager" />
</asp:GridView>



    </div>

    <!-- Modal Registro -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Registro de Productos</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Contenido del formulario de registro -->
                    <h5>Referencia</h5>
                    <asp:TextBox ID="referencia" CssClass="form-control" runat="server"></asp:TextBox>
                    <h5>Nombre del producto</h5>
                    <asp:TextBox ID="nombre" CssClass="form-control" runat="server"></asp:TextBox>
                    <h5>Stock</h5>
                    <asp:TextBox ID="stock" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    <h5>Descripción</h5>
                    <asp:TextBox ID="descripcion" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                    <h5>Imagen</h5>
                    <asp:FileUpload ID="imagen" CssClass="form-control" runat="server" />
                    <h5>Precio</h5>
                    <asp:TextBox ID="precio" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    <div class="form-group">
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoria" CssClass="form-label" AssociatedControlID="ddlCategoria"></asp:Label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" AutoPostBack="false">
                            <asp:ListItem Text="Seleccione una Categoria" Value="" />
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="lblCatch" runat="server" Text="" CssClass="text-info"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
