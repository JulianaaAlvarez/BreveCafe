<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="BreveCafe.vista.Pedidos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Carrito de Compras</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <style>
        .producto-card {
            border: 1px solid #ddd;
            padding: 15px;
            margin-bottom: 20px;
        }
        .producto-imagen {
            max-width: 100%;
            height: auto;
        }
        #imagenPago {
            display: none;
            max-width: 100%;
            height: auto;
            margin-top: 10px;
        }
        #codigoFijo, #mensajeEvidencia, #btnConfirmar {
            display: none;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center">Carrito de Compras</h1>

            <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvCarrito_RowCommand" OnRowDataBound="gvCarrito_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="Producto" SortExpression="nombre" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Button ID="btnMenos" runat="server" Text="-" CommandName="Menos" CommandArgument='<%# Eval("idProducto") %>' CssClass="btn btn-secondary btn-sm" />
                            <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("cantidad") %>' CssClass="mx-2"></asp:Label>
                            <asp:Button ID="btnMas" runat="server" Text="+" CommandName="Mas" CommandArgument='<%# Eval("idProducto") %>' CssClass="btn btn-secondary btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mesa">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlMesa" runat="server" CssClass="form-control"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idProducto") %>' CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="text-right">
                <h3>Total: $<asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label></h3>
            </div>

            <div class="text-center mt-3">
                <!-- Botón para abrir el modal -->
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#pagoModal">
                    Proceder a Pago
                </button>
            </div>

            <!-- Botón Volver -->
            <div class="text-center mt-3">
                <button type="button" class="btn btn-primary" onclick="location.href='DasboardCliente.aspx'">Volver</button>
            </div>
        </div>
    </form>

    <!-- MODAL DE PAGO -->
    <div class="modal fade" id="pagoModal" tabindex="-1" role="dialog" aria-labelledby="pagoModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="pagoModalLabel">Seleccione su método de pago</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body text-center">
                    <p>¿Cómo desea realizar el pago?</p>
                    <button type="button" class="btn btn-primary" onclick="mostrarImagen('nequi')">Pagar por Nequi</button>
                    <button type="button" class="btn btn-secondary" onclick="mostrarImagen('caja')">Pagar en Caja</button>
                    
                    <img id="imagenPago" src="" alt="Método de pago">
                    
                    <h4 id="codigoFijo">Número: 3502359358</h4>

                    <p id="mensajeEvidencia">Mostrar evidencia en caja</p>

                        <div class="d-flex justify-content-center mt-3">
                            <button id="btnConfirmar" class="btn btn-success" onclick="confirmarCompra()">Confirmar Compra</button>
                        </div>

                </div>
            </div>
        </div>
    </div>

    <script>
        function mostrarImagen(metodo) {
            var imagen = document.getElementById("imagenPago");
            var codigoFijo = document.getElementById("codigoFijo");
            var mensajeEvidencia = document.getElementById("mensajeEvidencia");
            var btnConfirmar = document.getElementById("btnConfirmar");

            if (metodo === "nequi") {
                imagen.src = "../assets/img/nequi.jpeg"; // Cambia esto por la ruta de la imagen de Nequi
                codigoFijo.style.display = "block";
                mensajeEvidencia.style.display = "block";
            } else if (metodo === "caja") {
                imagen.src = "../assets/img/caja.jpg"; // Cambia esto por la ruta de la imagen de pago en caja
                codigoFijo.style.display = "none";
                mensajeEvidencia.style.display = "none";
            }

            imagen.style.display = "block";
            btnConfirmar.style.display = "block";
        }

        function confirmarCompra() {
            alert("Compra confirmada. ¡Gracias por su pedido!");
            $("#pagoModal").modal("hide");
        }
    </script>
</body>
</html>
