<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="CodigoAgroAdmin.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de Productos</h1>
    
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" EmptyDataText="No hay productos disponibles.">
        <Columns>
            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
            <asp:BoundField DataField="NombreProducto" HeaderText="Nombre del Producto" />
            <asp:BoundField DataField="TipoProducto" HeaderText="Tipo" />
            <asp:BoundField DataField="MarcaProducto" HeaderText="Marca" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
            <asp:ImageField DataImageUrlField="URLimagen" HeaderText="Imagen" ControlStyle-Width="100px" ControlStyle-Height="100px" />
        </Columns>
    </asp:GridView>
</asp:Content>
