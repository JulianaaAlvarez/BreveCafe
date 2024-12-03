<%@ Page Title="Editar Categoria" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="editarCategoria.aspx.cs" Inherits="BreveCafe.vista.editarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .card {
    border-radius: 12px; /* Bordes redondeados */
    background-color: #f8f9fa; /* Fondo claro */
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Sombra sutil */
}

.text-primary {
    color: #007bff; /* Azul primario */
}

.form-control-lg {
    font-size: 1.25rem; /* Tamaño más grande */
    border-radius: 8px; /* Bordes redondeados */
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
   

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-sm border-0">
                    <div class="card-body p-4">
                        <h2 class="text-center mb-4 ">Editar Categoría</h2>
                        <div class="form-group">
                            <asp:TextBox 
                                ID="txtCategoria" 
                                CssClass="form-control form-control-lg mb-3" 
                                runat="server" 
                                placeholder="Nombre de la Categoría"></asp:TextBox>
                        </div>
                        <div class="text-center">
                            <asp:Button 
                                ID="btnActualizar" 
                                runat="server" 
                                CssClass="btn-custom" 
                                Text="Actualizar" 
                                OnClick="btnActualizar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
