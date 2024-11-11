<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CodigoProyectaComercio.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Carrito de Compras</h1>
    <asp:Repeater ID="RepeaterCarrito" runat="server">
        <ItemTemplate>
            <div class="cart-item">
                <h5><%# Eval("Nombre") %></h5>
                <p>Precio: $<%# Eval("Precio") %></p>
                <p>Cantidad: <%# Eval("Cantidad") %></p>
                <p>Subtotal: $<%# Eval("Subtotal") %></p>
<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>' />
                </div>
        </ItemTemplate>
    </asp:Repeater>

    <div>
        <h3>Total: $<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h3>
       
    </div>
</asp:Content>