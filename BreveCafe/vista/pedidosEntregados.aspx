<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="pedidosEntregados.aspx.cs" Inherits="BreveCafe.vista.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
      <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
  <style>
      /* Estilos para la tabla GridView */
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

      /* Estilos de los botones de paginación */
      .gridview-pager a {
          text-decoration: none;
          padding: 8px 12px;
          margin: 0 5px;
          background-color: #9a3f3f; /* Fondo rosa claro */
          color: white;
          border-radius: 5px;
          transition: background-color 0.3s;
      }

      .gridview-pager a:hover {
          background-color: #ac4343; /* Fondo rosa más oscuro al pasar el mouse */
          color: white;
      }

      .gridview-pager a:active {
          background-color: #ac4343; /* Fondo rosa aún más oscuro al hacer clic */
      }

      .gridview-pager span {
          padding: 8px 12px;
          margin: 0 5px;
          background-color: #9a3f3f; /* Fondo rosado muy suave para la página actual */
          color: #ac4343; /* Color por defecto de los enlaces */
          font-size: 14px;
      }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container mt-4">
    <h2 class="text-center mt-5">Historial de Entregas</h2>

    <asp:GridView ID="gvEntregas" runat="server" CssClass="custom-gridview" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="hora" HeaderText="Hora" />
            <asp:BoundField DataField="estado" HeaderText="Estado" />
            <asp:BoundField DataField="metodoPago" HeaderText="Método de Pago" />
            <asp:BoundField DataField="total" HeaderText="Total" />
            <asp:BoundField DataField="idMesa" HeaderText="Mesa" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
