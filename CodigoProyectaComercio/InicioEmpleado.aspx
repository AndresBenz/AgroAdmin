<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="InicioEmpleado.aspx.cs" Inherits="CodigoAgroAdmin.InicioEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="Gestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1 class="page-title">Productos con Stock Bajo o Agotado</h1>
    

    <asp:GridView ID="gvProductosBajoStock" runat="server" AutoGenerateColumns="False" CssClass="custom-table" EmptyDataText="No hay productos con bajo stock" OnRowDataBound="gvProductosBajoStock_RowDataBound">
        <Columns>
            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" SortExpression="IdProducto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" SortExpression="StockActual" />
            <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" SortExpression="StockMinimo" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
