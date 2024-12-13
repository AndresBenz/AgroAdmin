<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="RegistroDeCompra.aspx.cs" Inherits="CodigoAgroAdmin.RegistroDeCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Gestion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="page-title">Registro de Compra</h2>


    <asp:DropDownList ID="ddlProveedores" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProveedores_SelectedIndexChanged" Width="300px" class="form-control" Style="display: block; margin-left: auto; margin-right: auto;">
        <asp:ListItem Text="Seleccione un proveedor" Value="0"></asp:ListItem>
    </asp:DropDownList>




    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvProductos_RowCommand" CssClass="custom-table">
        <Columns>
            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrecio" runat="server" Text="0" Width="100px" class="form-control" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:TextBox ID="txtCantidad" runat="server" Width="100px" class="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CommandName="Agregar" CommandArgument='<%# Eval("IdProducto") %>' class="btn-add" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <h3 class="page-title">Productos Seleccionados</h3>
    <asp:GridView ID="gvSeleccionados" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvSeleccionados_RowCommand" class="btn-action">
        <Columns>
            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="CantidadSeleccionada" HeaderText="Cantidad" />
            <asp:BoundField DataField="Precio" HeaderText="Precio C/U" />
            <asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h4>Total General: $<asp:Label ID="lblTotal" runat="server" Text="0" class="form-label"></asp:Label></h4>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false" class="form-label"></asp:Label>


    <asp:RadioButtonList ID="rblMetodoPago" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblMetodoPago_SelectedIndexChanged" class="form-control">
        <asp:ListItem Text="Efectivo" Value="Efectivo" />
        <asp:ListItem Text="Transferencia" Value="Transferencia" />
    </asp:RadioButtonList>

    <asp:Label ID="lblMetodoPagoSeleccionado" runat="server" Text="Selecciona un método de pago." class="form-label" />

    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Compra" OnClick="btnConfirmar_Click" class="btn-primary mt-3" />


    <asp:Panel ID="pnlVentaExitoso" runat="server" CssClass="alert alert-success" Visible="false"
        Style="position: fixed; top: 35%; left: 65%; transform: translate(-50%, -50%); z-index: 1000; background-color: rgba(0, 128, 0, 0.8); color: white; text-align: center; padding: 20px; border-radius: 10px;">
        <div>
            <h2>¡Compra registrada exitosamente!</h2>
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClick="btnCerrar_Click" CssClass="btn btn-danger" />

        </div>
    </asp:Panel>

</asp:Content>
