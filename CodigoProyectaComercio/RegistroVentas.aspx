<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroVentas.aspx.cs" Inherits="CodigoAgroAdmin.RegistroVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="PanelVentas" runat="server">
    <asp:GridView ID="GridViewVentas" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="GridViewVentas_RowCommand" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridViewVentas_PageIndexChanging"> 
    <Columns>
        <asp:BoundField DataField="IdVenta" HeaderText="Id Venta" />
        <asp:BoundField DataField="IdCliente" HeaderText="Id Cliente" /> 
        <asp:BoundField DataField="NombreCliente" HeaderText="Nombre Cliente" /> 
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CommandName="VerDetalle" CommandArgument='<%# Eval("IdVenta") %>' CssClass="btn btn-info" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
          </asp:Panel>
     <asp:Panel ID="PanelDetallesVenta" runat="server" Visible="false">
    <asp:GridView ID="GridViewDetallesVenta" runat="server" AutoGenerateColumns="False" CssClass="table">
    <Columns>
        <asp:BoundField DataField="IdDetalleVenta" HeaderText="Id Detalle Venta" />
        <asp:BoundField DataField="IdVenta" HeaderText="Id Venta" />
        <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
    </Columns>
</asp:GridView>
                 <asp:Button ID="btnVolver" runat="server" Text="Volver a Ventas" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />

            </asp:Panel>
</asp:Content>