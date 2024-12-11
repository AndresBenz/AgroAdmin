<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="RegistroDeCompra.aspx.cs" Inherits="CodigoAgroAdmin.RegistroDeCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Registro de Compra</h2>

  
    <asp:DropDownList ID="ddlProveedores" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProveedores_SelectedIndexChanged" Width="300px">
        <asp:ListItem Text="Seleccione un proveedor" Value="0"></asp:ListItem>
    </asp:DropDownList>



   <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvProductos_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
         <asp:TemplateField HeaderText="Precio">
            <ItemTemplate>
                <asp:TextBox ID="txtPrecio" runat="server" Text="0"  Width="50px" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="Cantidad">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidad" runat="server" Width="50px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CommandName="Agregar" CommandArgument='<%# Eval("IdProducto") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


    <h3>Productos Seleccionados</h3>
<asp:GridView ID="gvSeleccionados" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvSeleccionados_RowCommand">
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
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>


 <asp:RadioButtonList ID="rblMetodoPago" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblMetodoPago_SelectedIndexChanged">
    <asp:ListItem Text="Efectivo" Value="Efectivo" />
    <asp:ListItem Text="Transferencia" Value="Transferencia" />
</asp:RadioButtonList>

<asp:Label ID="lblMetodoPagoSeleccionado" runat="server" Text="Selecciona un método de pago." />



</asp:Content>
