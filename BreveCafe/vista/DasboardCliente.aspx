<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraCliente.Master" AutoEventWireup="true" CodeBehind="DasboardCliente.aspx.cs" Inherits="AppBreveCafe.vista.DasboardCliente" %>

<asp:Content ID="Contenthead" ContentPlaceHolderID="Contenthead" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        /* Estilos generales existentes */
        .card-title {
            font-size: 1.5rem;
            font-weight: bold;
            color: #333;
        }

        .card-text {
            font-size: 1rem;
            color: #555;
        }

        .sidebar-menu {
            position: fixed;
            top: 130px;
            left: -250px; /* Ocultar la barra lateral por defecto */
            width: 250px;
            height: 100%;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
            overflow-y: auto;
            z-index: 1000;
            transition: left 0.3s ease-in-out; /* Transición para abrir/cerrar */
        }

            .sidebar-menu.open-sidebar {
                left: 0; /* Mostrar la barra lateral */
            }

            .sidebar-menu .nav {
                list-style: none;
                padding: 0;
                margin: 0;
                display: block; /* Usamos bloque para apilar los elementos verticalmente */
            }

                .sidebar-menu .nav li {
                    margin-bottom: 15px; /* Reduce el espacio entre los elementos */
                }

                    .sidebar-menu .nav li a {
                        text-decoration: none;
                        color: #000;
                        font-size: 14px;
                        padding: 10px;
                        border-radius: 5px;
                        background-color: #fff;
                        display: block;
                    }

                        .sidebar-menu .nav li a:hover {
                            background-color: #f2abb3;
                        }

                        .sidebar-menu .nav li a.volver {
                            background-color: #f2abb3;
                            color: #fff;
                        }

                            .sidebar-menu .nav li a.volver:hover {
                                background-color: #f2abb3;
                            }

        /* Botón para abrir/cerrar la barra lateral */
        .toggle-sidebar-btn {
            position: fixed;
            top: 130px;
            left: 10px;
            background-color: #6c757d;
            color: #fff;
            border: none;
            border-radius: 5px;
            padding: 10px 15px;
            cursor: pointer;
            z-index: 1100;
            font-size: 16px;
        }

            .toggle-sidebar-btn:focus {
                outline: none;
            }

        /* Estilos de las Cards (sin cambios) */
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
            border: 2px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 1rem;
            text-align: center;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

        .producto-imagen {
            width: 100%;
            height: 150px;
            object-fit: cover;
            margin-bottom: 1rem;
            transition: transform 0.3s ease;
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

        .producto-card:hover {
            transform: scale(1.05);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

            .producto-card:hover .producto-imagen {
                transform: scale(1.1);
            }
    </style>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">
    <!-- Botón para abrir/cerrar la barra lateral -->
    <button class="toggle-sidebar-btn" type="button" onclick="toggleSidebarVisibility()">☰</button>

    <!-- Menú de navegación -->
    <div class="sidebar-menu" id="sidebarMenu">
        <img style="max-height: 100px; max-width: auto;" src="imagenes/brevelogo.png" />
        <br />
        <br />
        <h1 class="breadcrumb__text">Categorías</h1>
        <ul class="nav">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li class="scroll-to-section">
                        <a href="#<%# Eval("Categoria") %>"><%# Eval("Categoria") %></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <li class="scroll-to-section">
                <a href="../index.aspx" class="volver">Volver al Inicio</a>
            </li>
        </ul>
    </div>

    <br />
    <br />
    <br />

    <!-- Categorías y productos -->
<asp:Repeater ID="RepeaterCategorias" runat="server">
    <ItemTemplate>
        <div class="categoria breadcrumb__text">
            <h2 id="<%# Eval("Categoria") %>"><%# Eval("Categoria") %></h2>
            <div class="productos-container">
                <asp:Repeater ID="RepeaterProductos" runat="server" DataSource='<%# Eval("Productos") %>'>
                    <ItemTemplate>
                        <div class="producto-card card">
                            <img src='<%# Eval("imagen") %>' alt='<%# Eval("nombre") %>' class="producto-imagen" />
                            <h3><%# Eval("nombre") %></h3>
                            <p><%# Eval("descripcion") %></p>
                            <span class="precio">Precio: $<%# Eval("precio") %></span>
                            <asp:Button ID="btnPedir" runat="server" Text="Pedir"
                                CommandName="Pedir" CommandArgument='<%# Eval("idProducto") %>'
                                CssClass="btn btn-primary" OnCommand="btnPedir_Command" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>





    <script>
        // Función para abrir/cerrar la barra lateral
        function toggleSidebarVisibility() {
            const sidebar = document.getElementById('sidebarMenu');
            sidebar.classList.toggle('open-sidebar'); // Alternar clase "open-sidebar"
        }
    </script>
</asp:Content>
