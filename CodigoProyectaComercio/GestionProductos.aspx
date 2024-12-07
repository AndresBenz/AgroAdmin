<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="CodigoAgroAdmin.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Gestionar Productos</h2>




        <div id="divListado" runat="server">
            <!-- Buscador -->
            <div class="form-group">
                <label for="txtBuscar">Buscar Producto por ID o Nombre</label>
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ingrese el ID o nombre del producto"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-secondary mt-2" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>


            <asp:Repeater ID="RepeaterProductos" runat="server">
    <HeaderTemplate>
        <table class="table table-striped table-bordered">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Precio</th>
                    <th>Categoría</th>
                    <th>Marca</th>
                    <th>Stock Actual</th>
                    <th>Stock Mínimo</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Eval("Nombre") %></td>
            <td>$<%# Eval("Precio") %></td>
            <td><%# Eval("NombreCategoria") %></td>
            <td><%# Eval("NombreMarca") %></td>
            <td><%# Eval("StockActual") %></td>
            <td><%# Eval("StockMinimo") %></td>
            <td>
                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnEditar_Click" CssClass="btn btn-primary btn-sm me-2">Editar</asp:LinkButton>
                <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm">Eliminar</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
            </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>

            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success mt-4" Text="Agregar Producto" OnClick="btnAgregar_Click" />
        </div>
        <!-- Agregar o editar -->


        <div id="divFormulario" runat="server" visible="false">
            <h2 id="tituloFormulario" runat="server">Agregar Producto</h2>
            <asp:Label ID="lblMensajeFormulario" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            <asp:HiddenField ID="hiddenIdProducto" runat="server" />

            <div class="form-group">
                <label for="nombreProducto">Nombre del Producto</label>
                <asp:TextBox ID="nombreProducto" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del producto"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="categoriaProducto">Categoria de Producto</label>
                <asp:DropDownList ID="categoriaProducto" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccione Categoria" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="marcaProducto">Marca del producto</label>
                <asp:DropDownList ID="marcaProducto" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccione Marca" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="precioProducto">Precio</label>
                <asp:TextBox ID="precioProducto" runat="server" CssClass="form-control" placeholder="Ingrese el precio"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="stockActual">Stock Actual</label>
                <asp:TextBox ID="stockActual" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese el stock actual"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="stockMinimo">Stock Mínimo</label>
                <asp:TextBox ID="stockMinimo" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese el stock mínimo"></asp:TextBox>
            </div>




            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
