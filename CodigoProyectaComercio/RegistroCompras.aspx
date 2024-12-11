﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroCompras.aspx.cs" Inherits="CodigoAgroAdmin.RegistroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Compras</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro de Compras</h2>
    <asp:Panel ID="PanelCompras" runat="server">
        <asp:GridView ID="gvCompras" runat="server" DataKeyNames="IdCompra" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvCompras_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
                <asp:BoundField DataField="NombreProveedor" HeaderText="Nombre Proveedor" />
                <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="TipoPago" HeaderText="Tipo de pago" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CommandName="VerDetalle" CommandArgument='<%# Eval("IdCompra") %>' CssClass="btn btn-info" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="PanelDetallesCompra" runat="server" Visible="false">
        <h3>Detalles de la Compra</h3>
        <asp:GridView ID="gvDetallesCompra" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="IdDetalleCompra" HeaderText="ID Detalle" />
                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="Precio de Compra" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />

            </Columns>
        </asp:GridView>
        <asp:Button ID="btnVolver" runat="server" Text="Volver a Compras" OnClick="btnVolver_Click" CssClass="btn btn-secondary" />

    </asp:Panel>
</asp:Content>
