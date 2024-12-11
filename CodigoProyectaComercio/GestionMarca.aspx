<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionMarca.aspx.cs" Inherits="CodigoAgroAdmin.GestionMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="Gestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <h1 class="page-title">Gestion Marca</h1>
    <!-- Formulario de edición/agregado -->
    <div id="divEditarMarca" runat="server" visible="false" class="form-container">
        <h3>Editar Marca</h3>
        
        <asp:Label ID="lblNombreEditar" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombreEditar" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblActivoEditar" runat="server" Text="Activo: "></asp:Label>
        <asp:CheckBox ID="chkActivoEditar" runat="server" CssClass="form-check-input" /><br />

        <asp:Button ID="btnGuardarEditarMarca" runat="server" Text="Guardar" OnClick="btnGuardarEditarMarca_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelarEditar" runat="server" Text="Cancelar" OnClick="btnCancelarEditar_Click" CssClass="btn btn-secondary" />
        
        <asp:Label ID="lblErrorEditar" runat="server" Text="El nombre de la marca es obligatorio." ForeColor="Red" Visible="false"></asp:Label>
    </div>
     <!-- Lista de marcas -->
      <div id="divListaMarcas" runat="server">
       <div class="mt-3">
    <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar Nueva Marca" OnClick="btnAgregarMarca_Click" CssClass="btn btn-success" />
</div>
    <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False" OnRowCommand="gvMarcas_RowCommand" CssClass="custom-table">
        <Columns>
            <asp:BoundField DataField="IdMarca" HeaderText="ID Marca" SortExpression="IdMarca" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnModificar" runat="server" CommandName="Modificar" CommandArgument='<%# Eval("IdMarca") %>' Text="Modificar" CssClass="btn btn-warning" />
                    <asp:Button ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("IdMarca") %>' Text="Eliminar" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
          </div>
</asp:Content>