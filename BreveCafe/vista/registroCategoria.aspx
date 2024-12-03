<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="registroCategoria.aspx.cs" Inherits="BreveCafe.vista.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
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
                color: #9a3f3f;
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
           
    body {
        font-family: Arial, sans-serif;
    }
    .container {
        padding-top: 20px;
    }
    .card {
        border-radius: 10px;
        border: none;
    }
    .card-body {
        padding: 2rem;
    }
    .form-group label {
        font-weight: bold;
        margin-bottom: 0.5rem;
    }
    .btn-primary {
        background-color: #007bff;
        border-color: #007bff;
        padding: 0.5rem 1.5rem;
        font-size: 1rem;
    }
    .btn-primary:hover {
        background-color: #0056b3;
        border-color: #0056b3;
    }
    .text-center {
        text-align: center;
    }
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
   


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <br />
    <br />
    <br />
    <br />

   



<!-- Botón para abrir la modal -->
<button type="button" class="btn-custom" data-bs-toggle="modal" data-bs-target="#categoriaModal">
    Registrar Categoría
</button>

<!-- Modal -->
<div class="modal fade" id="categoriaModal" tabindex="-1" aria-labelledby="categoriaModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="categoriaModalLabel">Registrar Categoría</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label for="categoria">Nombre de la Categoría</label>
                    <asp:TextBox ID="categoria" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn-custom" Text="Registrar" OnClick="btnRegistrar_Click" />
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
            </div>
        </div>
    </div>
</div>


<h2 class="text-center mt-5">Lista de Categorías</h2>


    <asp:GridView ID="dtCategoria" runat="server" AutoGenerateColumns="False" CssClass="custom-gridview"
        OnRowCommand="dtCategoria_RowCommand">
        <Columns>
            <asp:BoundField DataField="idCategoria" HeaderText="ID Categoria" SortExpression="idCategoria" />
            <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server"
                        CommandName="Editar"
                        CommandArgument='<%# Eval("idCategoria") %>'
                        CssClass="btn-action"
                        ImageUrl="imagenes/boligrafo.png"
                        AlternateText="Editar" />

                    <asp:ImageButton ID="btnEliminar" runat="server"
                        CommandName="Eliminar"
                        CommandArgument='<%# Eval("idCategoria") %>'
                        CssClass="btn-action"
                        ImageUrl="imagenes/papelera.png"
                        AlternateText="Eliminar"
                        OnClientClick="return confirm('¿Estás seguro de eliminar esta Categoria?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
