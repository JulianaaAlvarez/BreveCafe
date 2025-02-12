<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="BreveCafe.vista.menu" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>BreveCafe</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../assets/img/logobreve.ico" rel="icon">

    <!-- Fonts -->
    <link href="https://fonts.googleapis.com" rel="preconnect">
    <link href="https://fonts.gstatic.com" rel="preconnect" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,400;1,500;1,600;1,700;1,800&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900&display=swap" rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="../assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">

    <!-- Main CSS File -->
    <link href="../assets/css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="../reg/css/styles.min.css" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>

    <style>
        .navbar-toggler {
            border: none;
            background-color: transparent;
        }

        @media (max-width: 991px) {
            .navbar-collapse {
                position: fixed;
                top: 0;
                left: -100%;
                width: 100%;
                height: 100vh;
                background-color: white;
                display: flex;
                justify-content: center;
                align-items: center;
                transition: transform 0.3s ease-in-out;
                z-index: 9999;
            }

                .navbar-collapse.show {
                    transform: translateX(100%);
                }

            .navbar-nav {
                text-align: center;
                width: 100%;
            }

                .navbar-nav .nav-item {
                    margin: 10px 0;
                }

            .navbar-close-btn {
                position: absolute;
                top: 15px;
                right: 15px;
                background: transparent;
                border: none;
                font-size: 30px;
                color: black;
                cursor: pointer;
            }

            .navbar-close-icon {
                font-size: 40px;
            }
        }

        @media (min-width: 992px) {
            .navbar-close-btn {
                display: none;
            }
        }

        .header {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 130px;
            z-index: 1000;
            background-image: url('../assets/img/breveladrillosC.png');
            color: black;
        }

        body {
            padding-top: 130px;
        }
    </style>
    <form id="form1" runat="server">

        <div class="body-wrapper">
            <header id="header" class="header d-flex align-items-center fixed-top" style="background-image: url('../assets/img/breveladrillosC.png'); color: black; font-size: 22px">
                <div class="container-fluid container-xl position-relative d-flex align-items-center">

                    <a href="../index.aspx" class="logo d-flex align-items-center me-auto">
                        <img src="../assets/img/breve.png" alt="" style="max-height: 100px; max-width: auto;">
                        <img src="../assets/img/logobreve.png" alt="" style="max-height: 75px; max-width: auto;">
                    </a>

                    <nav id="navmenu" class="navbar navbar-expand-xl navbar-light">
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>

                        <div class="collapse navbar-collapse" id="navbarNav">
                            <button class="navbar-close-btn" type="button" aria-label="Cerrar Menú">
                                <span class="navbar-close-icon">&times;</span>
                            </button>

                            <ul class="navbar-nav ms-auto">
                                <li class="nav-item"><a href="../index.aspx" class="nav-link active" style="color: black;">Inicio</a></li>
                                <li class="nav-item"><a href="menu.aspx" class="nav-link" style="color: black;">Menú</a></li>
                                <li class="nav-item"><a href="../CafeEspecialidad.aspx" class="nav-link" style="color: black;">Cafe de Especialidad</a></li>
                                <li class="nav-item"><a href="../ubicacion.aspx" class="nav-link" style="color: black;">Ubicación</a></li>
                                <li id="liSesion" runat="server" class="nav-item">
                                    <a href="../login.aspx" class="nav-link" style="color: deepskyblue;">Iniciar sesión</a>
                                </li>
                                <li id="li1" runat="server" class="nav-item">
                                    <a href="CerrarSesion.aspx" class="nav-link" style="color: deepskyblue;">Cerrar Sesion</a>
                                </li>
                            </ul>
                        </div>
                        <asp:Label ForeColor="#0099ff" ID="liInicio" runat="server" Text=""></asp:Label>

                    </nav>
                </div>
            </header>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="content-area col-md-12">
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
                                                        <br />
                                                        <asp:Button ID="btnAñadirCarrito" runat="server" Text="Añadir al carrito" CssClass="btn btn-primary" OnClick="btnAñadirCarrito_Click" />
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



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        // Obtener los elementos
        const closeButton = document.querySelector('.navbar-close-btn');
        const navMenu = document.querySelector('.navbar-collapse');
        const sidebarToggleBtnHeader = document.getElementById('sidebarToggleBtnHeader'); // Botón de categorías en el header

        // Detectamos cuando el menú se abre o cierra
        const navbarToggler = document.querySelector('.navbar-toggler');
        navbarToggler.addEventListener('click', function () {
            if (navMenu.classList.contains('show')) {
                // Ocultar el botón de categorías en el header cuando se abre el menú
                sidebarToggleBtnHeader.style.display = 'none';
            } else {
                // Mostrar el botón de categorías en el header cuando se cierra el menú
                sidebarToggleBtnHeader.style.display = 'block';
            }
        });

        // Función para cerrar el menú del header
        closeButton.addEventListener('click', function () {
            navMenu.classList.remove('show');
            // Mostrar el botón de categorías cuando se cierra el menú
            sidebarToggleBtnHeader.style.display = 'block';
        });


    </script>

    <script src="reg/libs/jquery/dist/jquery.min.js"></script>
    <script src="reg/libs/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="reg/libs/apexcharts/dist/apexcharts.min.js"></script>
    <script src="reg/libs/simplebar/dist/simplebar.js"></script>
    <script src="reg/js/sidebarmenu.js"></script>
    <script src="reg/js/app.min.js"></script>
    <script src="reg/js/dashboard.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/iconify-icon@1.0.8/dist/iconify-icon.min.js"></script>
</body>

</html>
