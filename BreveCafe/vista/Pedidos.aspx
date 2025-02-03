<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="BreveCafe.vista.Pedidos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Carrito de Compras</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
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
                            <asp:DropDownList ID="ddlMesa" runat="server" CssClass="form-control">

                            </asp:DropDownList>
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
                <asp:Button ID="btnProcederPago" runat="server" Text="Proceder a Pago" CssClass="btn btn-success" OnClick="btnProcederPago_Click" />
            </div>

            <!-- Botón Volver -->
            <div class="text-center mt-3">
                <button type="button" class="btn btn-primary" onclick="location.href='DasboardCliente.aspx'">Volver</button>
            </div>
        </div>
    </form>
</body>
</html>
