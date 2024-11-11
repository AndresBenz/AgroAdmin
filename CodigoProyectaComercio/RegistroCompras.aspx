<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroCompras.aspx.cs" Inherits="CodigoAgroAdmin.RegistroCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Compras</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro de Compras</h2>

    <asp:GridView ID="gvCompras" runat="server" DataKeyNames="IdCompra" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCompras_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
            <asp:BoundField DataField="IdProveedor" HeaderText="ID Proveedor" />
            <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Link" SelectText="Ver Detalles" />
        </Columns>
    </asp:GridView>

    <h3>Detalles de la Compra</h3>
    <asp:GridView ID="gvDetallesCompra" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdDetalleCompra" HeaderText="ID Detalle" />
            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="PrecioCompra" HeaderText="Precio de Compra" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
</asp:Content>
