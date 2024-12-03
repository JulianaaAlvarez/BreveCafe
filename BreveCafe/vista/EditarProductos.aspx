<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="EditarProductos.aspx.cs" Inherits="BreveCafe.vista.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
    <style>
        /* General Styles */
body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f9;
    color: #333;
}

/* Card Styles */
.card {
    border: 1px solid #ccc;
    border-radius: 8px;
    background-color: #fff;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

/* Header Styles */
.card-header {
    background-color: #ffcccc !important;
    color: #faafaf !important;
    padding: 1rem !important;
    text-align: center !important;
    border-top-left-radius: 8px !important;
    border-top-right-radius: 8px !important;
}


/* Form Styles */
.form-label {
    font-weight: bold;
    color: #003366;
}

.form-control, .form-select {
    border: 1px solid #ccc;
    border-radius: 4px;
    padding: 0.5rem;
}

.form-control:focus, .form-select:focus {
    border-color: #003366;
    box-shadow: 0 0 5px rgba(0, 51, 102, 0.5);
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
    transform: scale(1.1); /* Aumenta el tamaño del texto al pasar el mouse */
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <br />
    <br />
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h3>Actualizar Producto</h3>
            </div>
            <div class="card-body">
          
                    <div class="mb-3">
                        <label for="referencia" class="form-label">Referencia</label>
                        <asp:TextBox ID="referencia" CssClass="form-control" runat="server" placeholder="Ingrese la referencia"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label for="nombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="nombre" CssClass="form-control" runat="server" placeholder="Ingrese el nombre del producto"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="stock" class="form-label">Stock</label>
                        <asp:TextBox ID="stock" CssClass="form-control" TextMode="Number" runat="server" placeholder="Cantidad en stock"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="descripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="descripcion" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" placeholder="Describa el producto"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="precio" class="form-label">Precio</label>
                        <asp:TextBox ID="precio" CssClass="form-control" TextMode="Number" runat="server" placeholder="Ingrese el precio"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Seleccione una Categoría" Value="" />
                        </asp:DropDownList>
                    </div>

                    <asp:Label ID="lblCatch" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

                    <div class="text-center">
                        <asp:Button ID="btnActualizar" runat="server" CssClass="btn-custom" Text="Actualizar" OnClick="btnActualizar_Click1" />
                        <button type="button" class="btn-custom" onclick="window.history.back();">Cancelar</button>
                    </div>
              
            </div>
        </div>
    </div>
</asp:Content>