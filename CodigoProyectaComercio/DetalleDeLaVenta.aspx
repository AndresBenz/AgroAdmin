<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="DetalleDeLaVenta.aspx.cs" Inherits="CodigoAgroAdmin.DetalleDeLaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .gridDetallesVenta {
            width: 100%;
            border-collapse: collapse;
            font-family: Arial, sans-serif;
        }

        .gridDetallesVenta th {
            background-color: #006699;
            color: white;
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .gridDetallesVenta td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: left;
        }

        .gridDetallesVenta tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridDetallesVenta tr:nth-child(odd) {
            background-color: #ffffff;
        }

        .gridDetallesVenta tr:hover {
            background-color: #f1f1f1;
        }

           .btn {
        background-color: #007bff;
        color: white;
        border: none;
        padding: 10px 15px;
        font-size: 14px;
        cursor: pointer;
        border-radius: 5px;
    }
    .btn:hover {
        background-color: #0056b3;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h2>Detalle de la Venta</h2>

        <p>Cliente: <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label></p>
        <p>Fecha: <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></p>
        <p>Total: <asp:Label ID="lblTotal" runat="server" Text="Total: $0.00" Font-Bold="True"></asp:Label></p>

        <asp:GridView ID="dgvDetallesVenta" runat="server" AutoGenerateColumns="False" CssClass="gridDetallesVenta">
            <Columns>
                <asp:BoundField DataField="NombreProducto" HeaderText="Producto" SortExpression="NombreProducto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" SortExpression="PrecioUnitario" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" SortExpression="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Button ID="btnGenerarPDF" runat="server" Text="Generar PDF" OnClick="btnGenerarPDF_Click" CssClass="btn btn-primary" />

</asp:Content>
