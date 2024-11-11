<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroVentas.aspx.cs" Inherits="CodigoAgroAdmin.RegistroVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewDetallesVenta" runat="server" AutoGenerateColumns="False" CssClass="table">
        <Columns>
            <asp:BoundField DataField="IdDetalleVenta" HeaderText="Id Detalle Venta" />
            <asp:BoundField DataField="IdVenta" HeaderText="Id Venta" />
            <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
        </Columns>
    </asp:GridView>
</asp:Content>