<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MaestraAdministrador.Master" AutoEventWireup="true" CodeBehind="RegistrarProveedor.aspx.cs" Inherits="BreveCafe.vista.RegistrarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
        <style>
        body { 
    font-family: Arial, sans-serif; 
    margin: 20px; 
    background-color: #f4f4f9; 
  }

  .form-container { 
    max-width: 600px; 
    margin: 0 auto; 
    background-color: #fff; 
    padding: 20px;
    border-radius: 8px; 
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); 
  }

  .form-group { 
    margin-bottom: 20px; 
  }

  .form-group label { 
    display: block; 
    font-weight: bold; 
    color: #333; 
    margin-bottom: 5px; 
  }

  .form-group input, 
  .form-group select { 
    width: 100%; 
    padding: 12px; 
    border-radius: 8px; 
    border: 1px solid #ccc; 
    font-size: 16px;
    box-sizing: border-box;
    transition: all 0.3s ease;
  }

  .form-group input:focus, 
  .form-group select:focus {
    border-color: #56c8ed; /* Color de borde cuando está en foco */
    outline: none;
    box-shadow: 0 0 5px rgb(45, 145, 229, 0,00); /* Sombra suave para el foco */
  }

.custom-btn { 
  padding: 12px 20px; 
  background-color: #7ebbf8; /* Azul clarito */
  color: white; 
  border: none; 
  border-radius: 30px; /* Bordes redondeados */
  cursor: pointer;
  font-size: 16px;
  transition: all 0.3s ease; /* Transiciones suaves */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Sombra para el efecto de elevación */
}

.custom-btn:hover { 
  background-color: #66b3ff; /* Azul más claro en hover */
  transform: translateY(-3px); /* Efecto de elevación */
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15); /* Sombra más profunda en hover */
}

.custom-btn:active { 
  transform: translateY(2px); /* Efecto de "presionar" */
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* Sombra más suave al presionar */
}



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

       <div class="form-container mt-5">
        <h2 class="text-center">Registro de Proveedor</h2>

            <div class="form-group">
                <label for="txtDocumento">Documento</label>
                <asp:TextBox ID="txtDocumento" runat="server" MaxLength="15" placeholder="Ingrese documento" ></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNombres">Nombres</label>
                <asp:TextBox ID="txtNombres" runat="server" MaxLength="100" placeholder="Ingrese nombres" ></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtApellidos">Apellidos</label>
                <asp:TextBox ID="txtApellidos" runat="server" MaxLength="100" placeholder="Ingrese apellidos" ></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTelefono">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="15" placeholder="Ingrese teléfono" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="150" placeholder="Ingrese email" required="true"></asp:TextBox>
            </div>
    
            <div class="form-group">
                <label for="txtNit">NIT</label>
                <asp:TextBox ID="txtNit" runat="server" MaxLength="20" placeholder="Ingrese NIT"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNombreEmpresa">Nombre de la Empresa</label>
                <asp:TextBox ID="txtNombreEmpresa" runat="server" MaxLength="150" placeholder="Ingrese nombre de la empresa" ></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtInsumo">Insumo</label>
                <asp:TextBox ID="txtInsumo" runat="server" MaxLength="200" placeholder="Ingrese insumo" required="true"></asp:TextBox>
            </div>
            <div class="form-group button">
              <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Proveedor" OnClick="btnRegistrar_Click" CssClass="custom-btn" />

    
    </div>


</asp:Content>
