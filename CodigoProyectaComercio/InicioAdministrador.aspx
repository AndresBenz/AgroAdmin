<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InicioAdministrador.aspx.cs" Inherits="CodigoAgroAdmin.InicioAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
  <div class="container mt-4">
    <!-- Logo y bienvenida -->
    <div class="text-center mb-4">
        <img src="Imagenes/Icono.png" alt="Logo ProyectaComercio" class="img-fluid" style="max-width: 200px;">
        <h2 class="mt-2">Administrador</h2>
    </div>
    <!-- Hora -->
    <div class="text-end mb-3">
        <h5 id="currentTime" class="text-muted"></h5>
    </div>
    <script>
        function updateTime() {
            const now = new Date();
            const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit', second: '2-digit' };
            document.getElementById('currentTime').innerText = now.toLocaleDateString('es-ES', options);
        }
        setInterval(updateTime, 1000);
        updateTime();
    </script>

  
    <div class="row">
        <div class="col-md-3">
            <div class="card text-white bg-primary mb-3">
                <div class="card-header">Ventas Totales</div>
                <div class="card-body">
                     <h5 class="card-title">
                   
                        <asp:Label ID="lblTotalVentas" runat="server" CssClass="card-title" Text="$0.00"></asp:Label>
                    </h5>
                    <p class="card-text">Ventas realizadas este mes</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-success mb-3">
                <div class="card-header">Clientes</div>
                <div class="card-body">
                      <h5 class="card-title">
                <asp:Label ID="lblTotalClientes" runat="server" CssClass="card-title" Text="0"></asp:Label>
            </h5>
                    <p class="card-text">Clientes registrados</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-warning mb-3">
                <div class="card-header">Productos</div>
                <div class="card-body">
                      <h5 class="card-title">
                <asp:Label ID="lblTotalProductos" runat="server" CssClass="card-title" Text="0"></asp:Label>
            </h5>
                    <p class="card-text">Productos en stock</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-danger mb-3">
                <div class="card-header">Proveedores</div>
                <div class="card-body">
                     <h5 class="card-title">
                <asp:Label ID="lblTotalProveedores" runat="server" CssClass="card-title" Text="0"></asp:Label>
            </h5>
                    <p class="card-text">Proveedores activos</p>
                </div>
            </div>
        </div>
    </div>
    <!-- Acceso rápido -->
    <div class="text-center mt-4">
        <a href="Reportes.aspx" class="btn btn-outline-primary btn-lg">Ver Reportes</a>
    </div>
</div>

</asp:Content>