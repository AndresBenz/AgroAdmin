﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="VentaProducto.aspx.cs" Inherits="CodigoAgroAdmin.VentaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Gestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h1>Venta de Productos</h1>

    <!-- Formulario para ingresar el DNI del cliente -->
    <div class="form-group">
        <label for="txtDNI">Ingrese DNI del Cliente:</label>
        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ValidationExpression="^\d+$" ErrorMessage="El DNI solo puede contener números." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoBuscarCliente" />
        <asp:Button ID="btnBuscarCliente" Text="Buscar Cliente" CssClass="btn btn-primary mt-2" runat="server" OnClick="btnBuscarCliente_Click" ValidationGroup="grupoBuscarCliente" />
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
    <div class="form-container" id="formularioCliente" runat="server" visible="false">
        <h2>
            <asp:Label ID="lblTituloFormulario" runat="server" Text="Agregar Cliente" /></h2>

        <asp:HiddenField ID="hfIdCliente" runat="server" />
        <div>
            <asp:Label ID="lblNombre2" runat="server" Text="Nombre del Cliente:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDNI2" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblCorreo2" runat="server" Text="Correo Electrónico:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDireccion2" runat="server" Text="Direccion:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
        </div>
    </div>

    <!-- Filtrar producto -->
    <asp:UpdatePanel ID="UpdProductos" runat="server">
        <ContentTemplate>

            <h2>Lista Productos</h2>
            <asp:Label Text="Filtrar" runat="server" />
            <asp:TextBox runat="server" ID="txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            <asp:GridView ID="dgvProductos" runat="server" OnPageIndexChanging="dgvProductos_PageIndexChanging" OnRowCommand="dgvProductos_RowCommand" AutoGenerateColumns="false"
                CssClass="custom-table table-striped table-bordered" AllowPaging="true" PageSize="5" DataKeyNames="IdProducto">
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
        </ContentTemplate>
    </asp:UpdatePanel>



    <asp:UpdatePanel ID="UpdSeleccionados" runat="server">
        <ContentTemplate>
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
            <asp:Label ID="lblTotal" runat="server" Text="Total: $0.00" CssClass="total-label" Style="font-size: 2em; font-weight: bold; text-align: center; display: block; margin: 20px 0;"></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">
        <asp:Button ID="btnComprarTodos" runat="server" Text="Comprar Todos"
            CssClass="btn btn-primary" OnClick="btnComprarTodos_Click" />
        <asp:Button ID="btnCancelarTodo" runat="server" Text="Cancelar Todo"
            CssClass="btn btn-secondary" OnClick="btnCancelarTodo_Click" />
    </div>
    <asp:Panel ID="pnlVentaExitoso" runat="server" CssClass="alert alert-success" Visible="false"
        Style="position: fixed; top: 35%; left: 65%; transform: translate(-50%, -50%); z-index: 1000; background-color: rgba(0, 128, 0, 0.8); color: white; text-align: center; padding: 20px; border-radius: 10px;">
        <div>
            <h2>¡Compra registrada exitosamente!</h2>
            <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle de la Compra" CssClass="btn btn-light" OnClick="btnVerDetalle_Click" />
        </div>
    </asp:Panel>




</asp:Content>
