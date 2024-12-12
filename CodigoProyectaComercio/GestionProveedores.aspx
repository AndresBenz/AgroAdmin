<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProveedores.aspx.cs" Inherits="CodigoAgroAdmin.GestionProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .edit-container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .edit-container h2 {
                text-align: center;
                margin-bottom: 20px;
            }

            .edit-container div {
                margin-bottom: 10px;
            }

            .edit-container label {
                display: block;
                margin-bottom: 5px;
            }

            .edit-container input, .edit-container select {
                width: 100%;
                padding: 10px;
                margin-bottom: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
            }

            .edit-container button {
                width: 100%;
                padding: 10px;
                background-color: #28a745;
                border: none;
                border-radius: 5px;
                color: #fff;
                font-size: 16px;
                cursor: pointer;
            }

                .edit-container button:hover {
                    background-color: #365a98;
                }

        .dropdown-style {
            font-size: 14px;
            background-color: #f9f9f9;
        }

        .label-style {
            font-weight: bold;
            font-size: 14px;
        }

        .message-label {
            text-align: center;
            font-weight: bold;
            margin: 20px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="listarProveedores" runat="server">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Proveedor" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />


        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProveedores_RowCommand" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-primary">Editar</asp:LinkButton>
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-danger">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="btnProductosProveedores" runat="server" CommandName="ProductosProveedores" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-info">Productos</asp:LinkButton>
    </ItemTemplate>
</asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </div>


<asp:Panel ID="panelProductos" runat="server" Visible="false">
    <h2>Productos del Proveedor</h2>
        <!-- Dropdown para seleccionar productos existentes -->
        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" CssClass="btn btn-success mb-3" />

    


    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvProductos_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEliminarProducto" runat="server" CommandName="EliminarProducto" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-danger">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnVolver" runat="server" Text="Volver a Proveedores" OnClick="btnVolver_Click" CssClass="btn btn-secondary" />
</asp:Panel>


    <asp:Panel ID="panelAgregarProducto" runat="server" Visible="false">
    <h2>Seleccionar Producto Existente</h2>

    <div class="mb-3">
        <label for="ddlProductosExistentes">Seleccionar un producto:</label>
        <asp:DropDownList ID="ddlProductosExistentes" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <asp:Button ID="btnAgregarProductoSeleccionado" runat="server" Text="Agregar Producto" OnClick="btnAgregarProductoSeleccionado_Click" CssClass="btn btn-primary" />

    <asp:Button ID="btnCancelarAgregar" runat="server" Text="Cancelar" OnClick="btnCancelarAgregar_Click" CssClass="btn btn-danger" />
</asp:Panel>

    <div class="edit-container" id="formularioProveedor" runat="server" visible="false">
        <h2>
            <asp:Label ID="lblTituloFormulario" runat="server" Text="Agregar/Editar Proveedor" /></h2>

        <asp:HiddenField ID="hfIdProveedor" runat="server" />
        <div>
            <asp:Label ID="lblNombreProveedor" runat="server" Text="Nombre del Proveedor:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtNombreProveedor" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDetalleProveedor" runat="server" Text="Detalle:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtDetalleProveedor" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblCorreoProveedor" runat="server" Text="Correo Electrónico:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtCorreoProveedor" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTelefonoProveedor" runat="server" Text="Teléfono:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtTelefonoProveedor" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGuardarProveedor" runat="server" Text="Guardar Proveedor" OnClick="btnGuardarProveedor_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelarProveedor" runat="server" Text="Cancelar" OnClick="btnCancelarProveedor_Click" CssClass="btn btn-secondary" />
        </div>
    </div>
</asp:Content>
