<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="BreveCafe.vista.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <style>
    .card-container {
        display: flex; /* Activa Flexbox */
        flex-wrap: wrap; /* Permite que las tarjetas bajen a la siguiente fila si no caben en la fila actual */
        justify-content: space-around; /* Distribuye las tarjetas uniformemente */
        gap: 20px; /* Espacio uniforme entre tarjetas */
        padding: 20px; /* Agrega espacio alrededor del contenedor */
    }

    .card {
        width: calc(25% - 20px); /* Ajusta el ancho para que quepan 4 tarjetas por fila con espacio entre ellas */
        border: 1px solid #ddd;
        border-radius: 8px;
        overflow: hidden;
        background-color: white;
        transition: transform 0.3s ease, box-shadow 0.3s ease;
    }

    .card:hover {
        transform: translateY(-5px);
        box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
    }

    .card-img-top {
        width: 100%;
        height: 200px; /* Altura fija para las imágenes */
        object-fit: cover; /* Ajusta la imagen dentro del contenedor sin distorsionarla */
        border-bottom: 1px solid #ddd;
    }

    .card-body {
        padding: 15px;
    }

    .card-title {
        font-size: 18px;
        font-weight: bold;
        margin-bottom: 10px;
    }

    .card-text {
        margin-bottom: 10px;
        font-size: 14px;
    }

    /* Responsive adjustments */
    @media (max-width: 1200px) {
        .card {
            width: calc(33.33% - 20px); /* 3 tarjetas por fila */
        }
    }

    @media (max-width: 768px) {
        .card {
            width: calc(50% - 20px); /* 2 tarjetas por fila */
        }
    }

    @media (max-width: 576px) {
        .card {
            width: 100%; /* Una tarjeta por fila en dispositivos pequeños */
        }
    }
</style>

<div class="col-md-9 col-xl-10" id="main-content" style="background-color: white; min-height: 100vh;">



    <!-- Contenedor de tarjetas -->
    <div id="productosContainer" class="card-container mt-4">

        <asp:Repeater ID="repeaterProductos" runat="server">
            <ItemTemplate>
                <div class="card">
                    <img class="card-img-top" src='<%# Eval("imagen") %>' alt="Imagen del producto">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("nombreProducto") %></h5>
                        <p class="card-text">Descripción: <%# Eval("descripcion") %></p>
                        <p class="card-text">Cantidad en stock: <%# Eval("cantidadStock") %></p>
                        <p class="card-text">Precio: $<%# Eval("precio") %></p>
                        <p class="card-text">Categoría: <%# Eval("idCategoria") %></p>
                        <a href="#" class="btn btn-primary">Comprar</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>
</asp:Content>
