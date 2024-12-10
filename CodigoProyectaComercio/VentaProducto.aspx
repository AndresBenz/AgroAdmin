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

  <!-- Filtrar producto -->
    <h2>Lista Productos</h2>
    <asp:Label Text="Filtrar" runat="server" />
    <asp:TextBox runat="server" ID="txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged"/>
   <asp:GridView ID="dgvProductos" runat="server" OnRowCommand="dgvProductos_RowCommand" AutoGenerateColumns="false" 
    CssClass="table table-striped table-bordered" AllowPaging="true" PageSize="5" DataKeyNames="IdProducto">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" DataFormatString="${0:F2}" />
        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" SortExpression="StockActual" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnSumar" runat="server" Text="+" CssClass="btn btn-success btn-sm"
                    CommandName="Incrementar" CommandArgument='<%# Eval("IdProducto") %>' />
                <asp:Button ID="btnRestar" runat="server" Text="-" CssClass="btn btn-danger btn-sm"
                    CommandName="Decrementar" CommandArgument='<%# Eval("IdProducto") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    


<!-- GridView para mostrar productos seleccionados -->
    <asp:Button ID="btnVerSeleccionados" runat="server" Text="Ver Seleccionados" 
    CssClass="btn btn-primary mt-3" OnClick="btnVerSeleccionados_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" Visible="false" />
<asp:GridView ID="dgvSeleccionados" runat="server" AutoGenerateColumns="false" 
    CssClass="table mt-3">
    <Columns>
        <asp:BoundField DataField="IdProducto" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
         <asp:BoundField DataField="CantidadSeleccionada" HeaderText="Cantidad Seleccionada" SortExpression="CantidadSeleccionada" />
           <asp:BoundField DataField="Precio" HeaderText="Precio" />

        
    </Columns>

</asp:GridView>
    <asp:Label ID="lblTotal" runat="server" Text="Total: $0.00" CssClass="total-label"></asp:Label>
    <asp:Button ID="btnComprarTodos" runat="server" Text="Comprar Todos" 
    CssClass="btn btn-primary mt-3" OnClick="btnComprarTodos_Click" />
    




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
