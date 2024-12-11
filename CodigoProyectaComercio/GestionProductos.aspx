<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="CodigoAgroAdmin.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Gestionar Productos</h2>




        <div id="divListado" runat="server">
            <!-- Buscador -->
            <div class="form-group">
                <label for="lblBuscar">Buscar Producto por ID o Nombre</label>
                <asp:TextBox ID="txtfiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtfiltro_TextChanged"/>
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>


     <asp:GridView ID="dgvProductos" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowCommand="GridViewProductos_RowCommand">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
        <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
        <asp:BoundField DataField="NombreMarca" HeaderText="Marca" />
        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
<asp:TemplateField>
    <ItemTemplate>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-primary btn-sm me-2" />
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField>
    <ItemTemplate>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-danger btn-sm" />
    </ItemTemplate>
</asp:TemplateField>

    </Columns>
</asp:GridView>

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
