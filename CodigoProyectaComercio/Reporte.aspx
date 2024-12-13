<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="CodigoAgroAdmin.Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Reporte de Ventas</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; margin-top: 20px;">
    <asp:Button ID="btnReporteVentas" runat="server" Text="Generar Reporte de Ventas" OnClick="btnReporteVentas_Click" CssClass="btn btn-primary" style="width: 250px; height: 50px; font-size: 18px; margin-right: 20px;"/>
        <asp:Button ID="btnReporteCompras" runat="server" Text="Generar Reporte de Compras" OnClick="btnReporteCompras_Click" CssClass="btn btn-primary" style="width: 250px; height: 50px; font-size: 18px; margin-left: 20px;"/>
</div>
<asp:Panel ID="pnlVentas" runat="server" Visible="false">
     <h1>Reporte de Ventas por Cliente</h1>
    <asp:Label ID="lblIdCliente" runat="server" Text="ID Cliente (opcional):"></asp:Label>
<asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control"></asp:TextBox>

     <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:"></asp:Label>
    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin:"></asp:Label>
    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

    <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" CssClass="btn btn-primary" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>


   <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
        <Columns>
            <asp:BoundField DataField="IdVenta" HeaderText="Id Venta" SortExpression="IdVenta" />
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />

    </asp:Panel>

    <asp:Panel ID="pnlCompras" runat="server" Visible="false">
          <h1>Reporte de Compras por Proveedor</h1>
        
        <asp:Label ID="lblProveedor" runat="server" Text="ID Proveedor (opcional):"></asp:Label>
        <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="lblFechaInicioCompra" runat="server" Text="Fecha Inicio:"></asp:Label>
        <asp:TextBox ID="txtFechaInicioCompra" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="lblFechaFinCompra" runat="server" Text="Fecha Fin:"></asp:Label>
        <asp:TextBox ID="txtFechaFinCompra" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

        <asp:Button ID="btnGenerarReporteCompras" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporteCompras_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblErrorCompra" runat="server" ForeColor="Red" Visible="false"></asp:Label>

        <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="IdCompra" HeaderText="Id Compra" SortExpression="IdCompra" />
                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" SortExpression="Proveedor" />
                <asp:BoundField DataField="FechaCompra" HeaderText="Fecha Compra" SortExpression="FechaCompra" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TipoPago" HeaderText="Tipo de Pago" SortExpression="TipoPago" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Unitario" SortExpression="PrecioCompra" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnCancelarCompra" runat="server" Text="Cancelar" OnClick="btnCancelarCompra_Click" CssClass="btn btn-danger" />
        </asp:Panel>
</asp:Content>
