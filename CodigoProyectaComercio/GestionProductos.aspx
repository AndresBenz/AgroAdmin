<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="CodigoAgroAdmin.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Gestionar Productos</h2>

        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Buscador -->
                <div class="form-group">
                    <label for="txtBuscar">Buscar Producto por ID o Nombre</label>
                    <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ingrese el ID o nombre del producto"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-secondary mt-2" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>


                <asp:Repeater ID="RepeaterProductos" runat="server">
                    <ItemTemplate>
                        <div class="card mb-2">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                <p class="card-text">Stock Actual: <%# Eval("StockActual") %></p>
                                <p class="card-text">Stock Mínimo: <%# Eval("StockMinimo") %></p>
                                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnEditar_Click" CssClass="btn btn-primary">Editar</asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success mt-4" Text="Agregar Producto" OnClick="btnAgregar_Click" />

                <!-- Agregar o editar -->
                <asp:PlaceHolder ID="phFormulario" runat="server" Visible="false">

                    <h2>Editar Producto</h2>
                    <asp:Label ID="lblMensajeFormulario" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <asp:HiddenField ID="hiddenIdProducto" runat="server" />
                    <div class="form-group">
                        <label for="nombreProducto">Nombre del Producto</label>
                        <asp:TextBox ID="nombreProducto" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del producto"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="tipoProducto">Tipo de Producto</label>
                        <asp:TextBox ID="categoriaProducto" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese el tipo de producto"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Marca">Marca del producto</label>
                        <asp:TextBox ID="marcaProducto" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese la marca del producto"></asp:TextBox>
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
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary" Text="Cancelar" OnClick="btnCancelar_Click" />
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phAcciones" runat="server" Visible="false">
                    <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary mt-2" OnClick="btnEditar_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger mt-2" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
                </asp:PlaceHolder>
                <asp:Button ID="btnConfirmarEditar" runat="server" CssClass="btn btn-success" Text="Confirmar Edición" OnClick="btnConfirmarEditar_Click" />

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
