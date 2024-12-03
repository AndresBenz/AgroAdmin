<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionCategoria.aspx.cs" Inherits="CodigoAgroAdmin.GestionCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="page-title">Gestión de Categorías</h1>

    <!--Agregar categoría -->
    <div class="form-container">
        <div class="form-group">
            <asp:Label ID="lblNombreCategoria" runat="server" Text="Nombre:" CssClass="form-label" />
            <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" CssClass="form-check-input" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar Categoría" OnClick="btnAgregarCategoria_Click" CssClass="btn btn-primary" />
        </div>
        <asp:HiddenField ID="hfIdCategoria" runat="server" />
    </div>

    <br />

    <!-- Lista de categorías -->
    <div class="list-container">
        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCategorias_RowCommand" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="IdCategoria" HeaderText="ID Categoria" SortExpression="IdCategoria" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CommandName="EditarCategoria" CommandArgument='<%# Eval("IdCategoria") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="btnEliminar" runat="server" CommandName="EliminarCategoria" CommandArgument='<%# Eval("IdCategoria") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-success mt-3"></asp:Label>
</asp:Content>