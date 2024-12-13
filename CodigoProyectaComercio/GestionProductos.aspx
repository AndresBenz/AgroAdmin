<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="CodigoAgroAdmin.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Gestion.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="page-title">Gestionar Productos</h2>




        <div id="divListado" runat="server">
            <!-- Buscador -->
            <div class="form-group">
                <label for="lblBuscar">Buscar Producto Nombre</label>
                <asp:TextBox ID="txtfiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtfiltro_TextChanged" />

            </div>
            <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn-add mt-3" Text="Agregar Producto" OnClick="btnAgregar_Click" />
            </div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>


            <asp:GridView ID="dgvProductos" runat="server" CssClass="custom-table" AutoGenerateColumns="False" OnRowCommand="GridViewProductos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="NombreCategoria" HeaderText="Categoría" />
                    <asp:BoundField DataField="NombreMarca" HeaderText="Marca" />
                    <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
                    <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
                    <asp:BoundField DataField="PorcentajeGanancia" HeaderText="Porcentaje de Ganancia" DataFormatString="{0:F2}%" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn-action" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn-action" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
        <!-- Agregar o editar -->


        <div id="divFormulario" runat="server" visible="false" class="form-container">
            <h2 id="tituloFormulario" runat="server" class="page-title">Agregar Producto</h2>
            <asp:Label ID="lblMensajeFormulario" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            <asp:HiddenField ID="hiddenIdProducto" runat="server" />

            <div class="form-group">
                <label class="form-label" for="nombreProducto">Nombre del Producto</label>
                <asp:TextBox ID="nombreProducto" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del producto"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombreProducto" runat="server" ControlToValidate="nombreProducto" ErrorMessage="El nombre del producto es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="nombreProducto" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ErrorMessage="El nombre solo puede contener letras." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

            </div>
            <div class="form-group">
                <label class="form-label" for="categoriaProducto">Categoria de Producto</label>
                <asp:DropDownList ID="categoriaProducto" runat="server" CssClass="form-control">

                    <asp:ListItem Text="Seleccione Categoria" Value="0"></asp:ListItem>

                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoriaProducto" runat="server" ControlToValidate="categoriaProducto" InitialValue="0" ErrorMessage="Debe seleccionar una categoría." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

            </div>
            <div class="form-group">
                <label class="form-label" for="marcaProducto">Marca del producto</label>
                <asp:DropDownList ID="marcaProducto" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccione Marca" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvMarcaProducto" runat="server" ControlToValidate="marcaProducto" InitialValue="0" ErrorMessage="Debe seleccionar una marca." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

            </div>


            <div class="form-group">
                <label class="form-label" for="stockActual">Stock Actual</label>
                <asp:TextBox ID="stockActual" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese el stock actual"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStockActual" runat="server" ControlToValidate="stockActual" ErrorMessage="El stock actual es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="stockActual" ValidationExpression="^\d+$" ErrorMessage="Solo se pueden ingresar números." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

            </div>

            <div class="form-group">
                <label class="form-label" for="stockMinimo">Stock Mínimo</label>
                <asp:TextBox ID="stockMinimo" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese el stock mínimo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStockMinimo" runat="server" ControlToValidate="stockMinimo" ErrorMessage="El stock mínimo es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="stockMinimo" ValidationExpression="^\d+$" ErrorMessage="Solo se pueden ingresar números." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

            </div>

            <div class="form-group">
                <label class="form-label" for="porcentajeGanancia">Porcentaje de Ganancia</label>
                <asp:TextBox ID="porcentajeGanancia" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Ingrese el porcentaje de ganancia"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPorcentajeGanancia" runat="server" ControlToValidate="porcentajeGanancia" ErrorMessage="El porcentaje de ganancia es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="porcentajeGanancia" ValidationExpression="^\d+(\,\d+)?$" ErrorMessage="El porcentaje de ganancia debe ser un número válido (con o sin coma decimal)." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

            </div>


            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="grupoGuardar" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
