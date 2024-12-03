<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraCliente.Master" AutoEventWireup="true" CodeBehind="DasboardCliente.aspx.cs" Inherits="AppBreveCafe.vista.DasboardCliente" %>

<asp:Content ID="Contenthead" ContentPlaceHolderID="Contenthead" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .card-title {
            font-size: 1.5rem;
            font-weight: bold;
            color: #333;
        }

        .card-text {
            font-size: 1rem;
            color: #555;
        }

        .section-title {
            font-size: 2rem;
            font-weight: bold;
            color: #fff;
            background-color: #6c757d;
            padding: 1rem;
            text-align: center;
            margin: 2rem 0;
        }

        .menu-section {
            margin-bottom: 4rem;
        }

        .card img {
            height: 200px;
            object-fit: cover;
        }

        .breadcrumb__text h2 {
            font-size: 35px;
            color: #000;
            font-weight: 700;
            font-family: "Playfair Display", serif;
        }

        .breadcrumb__text {
            position: relative;
        }

        .breadcrumb__text::after {
            content: '';
            position: absolute;
            bottom: 0;
        }

        /* Estilo base para el menú */
        ul.nav {
            display: flex;
            flex-wrap: nowrap;
            justify-content: flex-start;
            align-items: center;
            margin: 0;
            padding: 10px 0;
            list-style-type: none;
            border-radius: 5px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow-x: auto;
            white-space: nowrap;
            position: sticky;
            top: 120px; /* Ajusta este valor según la altura del header */
            z-index: 1500;
        }

        ul.nav li {
            margin: 0 20px;
            position: relative;
        }

        ul.nav li a {
            color: #333;
            text-decoration: none;
            font-size: 16px;
            font-weight: 600;
            padding: 10px 20px;
            border-radius: 5px;
            background-color: #ffe8ce;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        ul.nav li a:hover {
            background-color: #ffcccc;
            transform: scale(1.05);
        }

        ul.nav li a.active {
            background-color: #dc9f9f;
            font-weight: bold;
            color: #fff;
        }

        ul.nav li a::before {
            content: "";
            position: absolute;
            width: 100%;
            height: 2px;
            background-color: #d19191;
            bottom: -5px;
            left: 0;
            transform: scaleX(0);
            transition: transform 0.3s ease-in-out;
        }

        ul.nav li a:hover::before {
            transform: scaleX(1);
        }

        /* Nuevos estilos para las categorías y productos */
        .categoria {
            margin-bottom: 3rem;
        }

        .categoria h2 {
            font-size: 1.8rem;
            font-weight: bold;
            margin-bottom: 1rem;
            color: #333;
            border-bottom: 2px solid #000;
            padding-bottom: 5px;
        }

        .productos-container {
            display: flex;
            flex-wrap: wrap;
            gap: 1rem;
        }

        .producto-card {
            width: 250px;
            background-color: #fff;
            border: 2px solid #ddd; /* Borde gris claro */
            border-radius: 5px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 1rem;
            text-align: center;
            transition: transform 0.3s ease, box-shadow 0.3s ease; /* Efectos de transición */
        }

        .producto-imagen {
            width: 100%;
            height: 150px;
            object-fit: cover;
            margin-bottom: 1rem;
            transition: transform 0.3s ease; /* Transición suave para la imagen */
        }

        .producto-card h3 {
            font-size: 1.2rem;
            color: #333;
        }

        .producto-card p {
            font-size: 1rem;
            color: #555;
        }

        .precio {
            font-size: 1.2rem;
            font-weight: bold;
            color: #28a745;
        }

        /* Efecto de ampliación y sombra al pasar el cursor sobre la tarjeta */
        .producto-card:hover {
            transform: scale(1.05); /* Ampliación de la tarjeta */
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2); /* Sombra más intensa */
        }

        .producto-card:hover .producto-imagen {
            transform: scale(1.1); /* Ampliar la imagen dentro de la tarjeta */
        }

        /* Estilo específico para el botón 'Volver' */
        .nav li a.volver {
            background-color: #ffecb3; /* Color de fondo suave */
            color: #d9534f; /* Color del texto */
            font-weight: bold;
        }

        .nav li a.volver:hover {
            background-color: #f5c6cb; /* Color de fondo cuando se pasa el ratón */
        }

    </style>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">
    <!-- Menú de navegación -->
    <ul class="nav">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li class="scroll-to-section">
                    <!-- Enlace que lleva a la categoría correspondiente -->
                    <a href="#<%# Eval("Categoria") %>"><%# Eval("Categoria") %></a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li class="scroll-to-section"><a href="../index.aspx" class="volver">Volver</a></li>
    </ul>

    <br /><br /><br />

    <!-- Categorías y productos -->
    <asp:Repeater ID="RepeaterCategorias" runat="server">
        <ItemTemplate>
            <div class="categoria breadcrumb__text">
                <!-- Asignamos un id único a cada categoría -->
                <h2 id="<%# Eval("Categoria") %>"><%# Eval("Categoria") %></h2>
                <div class="productos-container">
                    <asp:Repeater ID="RepeaterProductos" runat="server" DataSource='<%# Eval("Productos") %>'>
                        <ItemTemplate>
                            <div class="producto-card card">
                                <img src='<%# Eval("imagen") %>' alt='<%# Eval("nombre") %>' class="producto-imagen" />
                                <h3><%# Eval("nombre") %></h3>
                                <p><%# Eval("descripcion") %></p>
                                <span class="precio">Precio: $<%# Eval("precio") %></span>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <script>
        document.documentElement.style.scrollBehavior = "smooth"; // Desplazamiento suave
    </script>

</asp:Content>
