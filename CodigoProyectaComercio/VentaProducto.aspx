<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="VentaProducto.aspx.cs" Inherits="CodigoAgroAdmin.VentaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Venta de Productos</h1>

    <!-- Formulario para ingresar el DNI del cliente -->
    <div class="form-group">
        <label for="txtDNI">Ingrese DNI del Cliente:</label>
        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscarCliente" Text="Buscar Cliente" CssClass="btn btn-primary mt-2" runat="server" OnClick="btnBuscarCliente_Click" />
    </div>

    <!-- Mensaje si el cliente no existe -->
    <asp:Panel ID="pnlClienteNoExiste" runat="server" Visible="false" CssClass="alert alert-warning mt-3">
        El cliente con el DNI ingresado no existe.
        <asp:Button ID="btnAgregarCliente" Text="Agregar Cliente" CssClass="btn btn-success ml-3" runat="server" OnClick="btnAgregarCliente_Click" />
    </asp:Panel>

    <asp:Panel ID="pnlClienteEncontrado" runat="server" Visible="false" CssClass="alert alert-success mt-3">
        <strong>Cliente encontrado:</strong><br />
        <strong>Nombre:</strong>
        <asp:Label ID="lblNombre" runat="server" CssClass="ml-2"></asp:Label><br />
        <strong>Dirección:</strong>
        <asp:Label ID="lblDireccion" runat="server" CssClass="ml-2"></asp:Label><br />
        <strong>Correo Electrónico:</strong>
        <asp:Label ID="lblCorreo" runat="server" CssClass="ml-2"></asp:Label>
    </asp:Panel>


    <!--Agregar cliente -->
    <div class="edit-container" id="formularioCliente" runat="server" visible="false">
        <h2>
            <asp:Label ID="lblTituloFormulario" runat="server" Text="Agregar Cliente" /></h2>

        <asp:HiddenField ID="hfIdCliente" runat="server" />
        <div>
            <asp:Label ID="lblNombre2" runat="server" Text="Nombre del Cliente:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtDNI2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblCorreo2" runat="server" Text="Correo Electrónico:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDireccion2" runat="server" Text="Direccion:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
        </div>
    </div>

</asp:Content>
