<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ubicacion.aspx.cs" Inherits="BreveCafe.ubicacion" %>


<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Ubicacion</title>
    
    <!-- Incluir Leaflet.js -->
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.7.1/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js"></script>
    
    <style>
        /* Estilo para el mapa */
        #map {
            height: 500px; /* Aumentamos el tamaño del mapa */
            width: 100%;
            border-radius: 10px; /* Bordes redondeados */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); /* Sombra */
            margin-top: 20px;
        }

        /* Títulos y contenedor */
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f4f4f9;
            padding: 20px;
        }

        h2 {
            text-align: center;
            color: #333;
            font-size: 24px;
            margin-bottom: 20px;
        }

        .leaflet-control-zoom {
            background-color: #fff; /* Fondo blanco para controles de zoom */
            border-radius: 5px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.15);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ubicación: Calle 9 #7-30, Nobsa, Boyacá</h2>
            <div id="map"></div>
        </div>
    </form>

    <script type="text/javascript">
        // Coordenadas de "calle 9 #7-30, Nobsa, Boyacá"
        var lat = 5.7674238;
        var lon = -72.9421289;

        // Crear el mapa centrado en la dirección
        var map = L.map('map', {
            center: [lat, lon],
            zoom: 15,
            zoomControl: true,
            attributionControl: false
        });

        // Cargar el mapa de OpenStreetMap con un estilo atractivo
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
            maxZoom: 19
        }).addTo(map);

        // Ícono personalizado para el marcador (Ícono de localización)
        var customIcon = L.icon({
            iconUrl: 'data:image/png;base64,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',  // URL de la imagen de marcador
            iconSize: [32, 32], // Tamaño del ícono
            iconAnchor: [16, 32], // Ancla del ícono
            popupAnchor: [0, -32] // Posición del popup
        });

        // Agregar un marcador con el ícono personalizado
        L.marker([lat, lon], { icon: customIcon }).addTo(map)
            .bindPopup("Calle 9 #7-30, Nobsa, Boyacá")
            .openPopup();

        // Agregar control de zoom y localización
        L.control.zoom({ position: 'topright' }).addTo(map);
    </script>
</body>
</html>
