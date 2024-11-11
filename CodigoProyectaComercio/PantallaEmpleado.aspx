<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PantallaEmpleado.aspx.cs" Inherits="CodigoAgroAdmin.PantallaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1>Productos Mas vendidos</h1>
    <div class="mb-3">
        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Buscar productos..."></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
    </div>
    <table class="table">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Precio</th>
                <th>Stock Actual</th>      
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RepeaterProductos" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td>$<%# Eval("Precio") %></td>
                        <td><%# Eval("StockActual") %></td>
                       
                        <td>
                            <!--<asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al Carrito" CommandName="Agregar" CommandArgument='<%# Eval("IdProducto") %>' OnCommand="btnAgregarCarrito_Command" CssClass="btn btn-primary btn-sm" />
                          -->  <asp:Button ID="btnVerDetalles" runat="server" Text="Ver Detalles" CommandName="VerDetalles" CommandArgument='<%# Eval("IdProducto") %>' OnCommand="btnVerDetalles_Command" CssClass="btn btn-secondary btn-sm" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

</asp:Content>
