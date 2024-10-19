<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CodigoAgroAdmin.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Productos Mas vendidos</h1>
<asp:Repeater ID="RepeaterProductos" runat="server">
    <ItemTemplate>
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                    <p class="card-text"><strong>Precio: $<%# Eval("Precio") %></strong></p>
                    <p class="card-text"><strong>Stock Actual: <%# Eval("StockActual") %></strong></p>
                    <p class="card-text"><strong>Stock Minimo: <%# Eval("StockMinimo") %></strong></p>
                    <a href="AgregarCarrito.aspx?id=<%# Eval("IdProducto") %>" class="btnAgregarCarrito">Agregar al Carrito</a>
                    <a href="EliminarProducto.aspx?id=<%# Eval("IdProducto") %>" class="btnEliminar">Eliminar</a>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

</asp:Content>
