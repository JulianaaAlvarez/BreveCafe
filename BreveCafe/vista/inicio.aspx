<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="BreveCafe.vista.inicio" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset='utf-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <title>BreveCafe</title>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <link href="../assets/img/logobreve.ico" rel="icon">

    <!-- Fonts -->
    <link href="https://fonts.googleapis.com" rel="preconnect">
    <link href="https://fonts.gstatic.com" rel="preconnect" crossorigin>
    <link
        href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,400;1,500;1,600;1,700;1,800&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Jost:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap"
        rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="../assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">

    <!-- Main CSS File -->
    <link href="../assets/css/main.css" rel="stylesheet">
</head>


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


</style>



<body>

   
    <!-- Inicio del header -->
    <header id="header" class="header d-flex align-items-center fixed-top" style="background-image: url('../assets/img/breveladrillosC.png'); color: black; font-size:22px">
        <div class="container-fluid container-xl position-relative d-flex align-items-center">

            <a href="index.aspx" class="logo d-flex align-items-center me-auto">
                <img src="../assets/img/breve.png" alt="" style="max-height: 100px; max-width: auto;">
                <img src="../assets/img/logobreve.png" alt="" style="max-height: 75px; max-width: auto;">
            </a>


            <!-- Menú de navegación -->
            <nav id="navmenu" class="navbar navbar-expand-xl navbar-light">
                <!-- Botón de hamburguesa -->
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <!-- Contenedor del menú (desplegable) -->
                <div class="collapse navbar-collapse" id="navbarNav">
                    <!-- Botón de cerrar (X) dentro del menú -->
                    <button class="navbar-close-btn" type="button" aria-label="Cerrar Menú">
                        <span class="navbar-close-icon">&times;</span>
                        <!-- Icono de cerrar (X) -->
                    </button>

                    <ul class="navbar-nav ms-auto" >
                        <li class="nav-item"><a href="inicio.aspx" class="nav-link active" style="color: black;">Inicio</a></li>
                        <li class="nav-item"><a href="DasboardCliente.aspx" class="nav-link" style="color: black;">Menú</a></li>
                        <li class="nav-item"><a href="../CafeDeEspecialidad.aspx" class="nav-link" style="color: black;">Cafe de Especialidad</a></li>
                        <li class="nav-item"><a href="ubicacion.aspx" class="nav-link" style="color: black;">Ubicación</a></li>
                        <li id="li" runat="server" class="nav-item">
                         <a href="login.aspx" class="nav-link" style="color: deepskyblue;">Iniciar sesión</a>
                        </li>
                        <li id="li2" runat="server" class="nav-item">
                            <a href="CerrarSesion.aspx" class="nav-link" style="color: black;"><i class="bi bi-box-arrow-left"></i></a>
                        </li>
                    </ul>

                </div>
                     <asp:Label ForeColor="white" ID="lblInicio" runat="server" Text="Inicio" CssClass="boton"></asp:Label>

                     <style>
                         .boton {
                             display: inline-block;
                             padding: 5px 10px; /* Reduce el tamaño del botón */
                             background-color: lightcoral;
                             color: white;
                             border-radius: 50px; /* Bordes más sutiles */
                             font-size: 14px; /* Texto más pequeño */
                             font-weight: bold;
                             cursor: default;
                             text-align: center;
                             text-decoration: none;
                         }
                     </style>
                </nav>
        </div>
    </header>

    <!-- banner inicial donde se muestra una descripcion -->
    <section id="hero" class="hero section light-background">
        <div class="container">
            <div class="row gy-4">
                <div class="col-lg-6 order-2 order-lg-1 d-flex flex-column justify-content-center" data-aos="zoom-out">
                    <h1 style="color: black;">"Un espacio donde el tiempo se detiene y cada detalle invita a quedarte.
                        Descubre tu próximo refugio."</h1>
                    <p>"Un lugar creado para quienes buscan inspiración y momentos únicos en cada visita."</p>
                    <div class="d-flex">
                        <a href="DasboardCliente.aspx" class="btn-get-started">Visita Nuestro Menú</a>
                    </div>
                </div>
                
                <div class="col-lg-6 mt-5 order-1 order-lg-2 hero-img d-flex justify-content-end" data-aos="zoom-out"
                    data-aos-delay="200">
                    <br>
                    <img src="../assets/img/cafe.jpg" class="img-fluid animated" alt=""
                        style="max-width: 75%; height: auto; object-fit: cover;">
                </div>
            </div>
        </div>
    </section>
    <!-- Final del banner -->

    <!-- inicio de imagenes de las experiencias del lugar con su diseño -->
    <style>
        .experience {
            position: relative;
            text-align: center;
            color: white;
        }

            .experience img {
                width: 100%;
                height: 300px;
                /* Tamaño fijo para las imágenes */
                object-fit: cover;
                /* Recorta la imagen para ajustarse al tamaño sin deformarse */
                border-radius: 10px;
                /* Esquinas redondeadas opcionales */
            }

            .experience h2 {
                position: absolute;
                top: 50%;
                left: 50%;
                transform: translate(-50%, -50%);
                font-size: 2rem;
                background-color: rgba(0, 0, 0, 0.5);
                padding: 10px;
                border-radius: 5px;
            }

        .btn-custom {
            background-color: #2f603b;
            color: white;
        }
    </style>

    <div class="container text-center my-5">
        <h1>Nuestras Experiencias</h1>
        <div class="row">
            <div class="col-md-6 mb-4">
                <div class="experience">
                    <img src="../assets/img/plato.jpg" alt="Restaurantes">
                </div>
            </div>
            <div class="col-md-6 mb-4">
                <div class="experience">
                    <img src="../assets/img/postre.jpg" alt="Pick up">
                </div>
            </div>
        </div>
        <a href="#" class="btn btn-custom btn-lg">Ver más</a>
    </div>
    <!-- Fin de las imagenes -->
    <section id="about" class="about section">
        <div class="container section-title" data-aos="fade-up">
            <h2>Nosotros</h2>
        </div>

        <div class="container">

            <div class="row gy-4">

                <div class="col-lg-6 content" data-aos="fade-up" data-aos-delay="100">
                    <p>
                        Estamos ubicados en el Municipio de Nobsa Boyacá, Encontraras variedad de Alimentos y
                        Bebidas.
                        Animate a venir ¡Te Esperamos!
                    </p>
                    <ul>
                        <li><i class="bi bi-check2-circle"></i><span>Espacio amplio y comodo</span></li>
                        <li><i class="bi bi-check2-circle"></i><span>Productos de Calidad</span></li>
                        <li><i class="bi bi-check2-circle"></i><span>Tenemos El Mejor Cafe de Nobsa</span></li>
                    </ul>
                </div>

                <div class="col-lg-6" data-aos="fade-up" data-aos-delay="200">
                    <p>
                        En nuestra cafetería no solo encontrarás café de la mejor calidad, sino también un ambiente
                        acogedor donde podrás relajarte y disfrutar de momentos únicos. Cada taza está preparada con
                        ingredientes frescos y un toque de pasión por lo artesanal. Ya sea que busques un espacio
                        para trabajar, reunirte con amigos o simplemente tomarte un descanso del día a día, nuestra
                        cafetería es el lugar perfecto para ti. Te esperamos con una sonrisa y una deliciosa
                        variedad de bebidas y postres para todos los gustos.
                    </p>
                    <a href="../CafeDeEspecialidad.aspx" class="read-more"><span>Descubre más</span><i class="bi bi-arrow-right"></i></a>
                </div>


            </div>

        </div>

    </section>


    <script>
        // Seleccionar el botón de cerrar y el contenedor del menú
        const closeButton = document.querySelector('.navbar-close-btn');
        const navMenu = document.querySelector('.navbar-collapse');

        // Añadir el evento de clic al botón de cerrar
        closeButton.addEventListener('click', function () {
            navMenu.classList.remove('show'); // Eliminar la clase 'show' para ocultar el menú
        });
    </script>

    <!-- JavaScript de Bootstrap -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>

</body>

</html>

