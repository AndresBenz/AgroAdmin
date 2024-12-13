<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProveedores.aspx.cs" Inherits="CodigoAgroAdmin.GestionProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                 <link href="Gestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="listarProveedores" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Proveedor" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
            </div>

        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProveedores_RowCommand" CssClass="custom-table">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-warning">Editar</asp:LinkButton>
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
            <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">

        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" CssClass="btn btn-primary" />

    </div>


    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="custom-table" OnRowCommand="gvProductos_RowCommand">
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
    <div style="display: flex; justify-content: center; margin-top: 20px;">
    <asp:Button ID="btnVolver" runat="server" Text="Volver a Proveedores" OnClick="btnVolver_Click" CssClass="btn btn-secondary" />
</div>
</asp:Panel>


    <asp:Panel ID="panelAgregarProducto" runat="server" Visible="false">
    <h2>Seleccionar Producto Existente</h2>

    <div class="mb-3">
        <label for="ddlProductosExistentes">Seleccionar un producto:</label>
        <asp:DropDownList ID="ddlProductosExistentes" runat="server" CssClass="form-control"></asp:DropDownList>
       <asp:RequiredFieldValidator ID="rfvProductosExistentes" runat="server" ControlToValidate="ddlProductosExistentes" InitialValue="" ErrorMessage="Debe seleccionar un producto." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar" />

        </div>
        <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">
    <asp:Button ID="btnAgregarProductoSeleccionado" runat="server" Text="Agregar Producto" OnClick="btnAgregarProductoSeleccionado_Click" CssClass="btn btn-primary" />
            </div>
    <asp:Button ID="btnCancelarAgregar" runat="server" Text="Cancelar" OnClick="btnCancelarAgregar_Click" CssClass="btn btn-primary" />
</asp:Panel>

    <div class="form-container" id="formularioProveedor" runat="server" style="margin-top: 20px;" visible="false">
        <h2>
            <asp:Label ID="lblTituloFormulario" runat="server" Text="Agregar/Editar Proveedor" /></h2>

        <asp:HiddenField ID="hfIdProveedor" runat="server" />
        <div>
            <asp:Label ID="lblNombreProveedor" runat="server" Text="Nombre del Proveedor:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtNombreProveedor" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreProveedor" runat="server" ControlToValidate="txtNombreProveedor" InitialValue="" ErrorMessage="El nombre del proveedor es obligatorio." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar"/>
            <asp:RegularExpressionValidator ID="revNombreProveedor" runat="server" ControlToValidate="txtNombreProveedor" ValidationExpression="^[a-zA-Z\s]+$" ErrorMessage="El nombre solo puede contener letras." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar" />

        </div>
        <div>
            <asp:Label ID="lblDetalleProveedor" runat="server" Text="Detalle:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDetalleProveedor" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDetalleProveedor" runat="server" ControlToValidate="txtDetalleProveedor" InitialValue="" ErrorMessage="El detalle es obligatorio." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar"/>

        </div>
        <div>
            <asp:Label ID="lblCorreoProveedor" runat="server" Text="Correo Electrónico:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtCorreoProveedor" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreoProveedor" runat="server" ControlToValidate="txtCorreoProveedor" InitialValue="" ErrorMessage="El correo electrónico es obligatorio." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar"/>
            <asp:RegularExpressionValidator ID="revCorreoProveedor" runat="server" ControlToValidate="txtCorreoProveedor" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="El correo electrónico no es válido." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar"/>

        </div>
        <div>
            <asp:Label ID="lblTelefonoProveedor" runat="server" Text="Teléfono:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtTelefonoProveedor" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefonoProveedor" runat="server" ControlToValidate="txtTelefonoProveedor" InitialValue="" ErrorMessage="El teléfono es obligatorio." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar"/>
            <asp:RegularExpressionValidator ID="revTelefonoProveedor" runat="server" ControlToValidate="txtTelefonoProveedor" ValidationExpression="^\+?[1-9]\d{1,14}$" ErrorMessage="El teléfono no es válido." ForeColor="Red" Display="Dynamic" ValidationGroup="grupoGuardar"/>

        </div>
        <div>
            <asp:Button ID="btnGuardarProveedor" runat="server" Text="Guardar Proveedor" OnClick="btnGuardarProveedor_Click" CssClass="btn btn-success" ValidationGroup="grupoGuardar"/>
            <asp:Button ID="btnCancelarProveedor" runat="server" Text="Cancelar" OnClick="btnCancelarProveedor_Click" CssClass="btn btn-secondary" />
        </div>
    </div>
</asp:Content>
