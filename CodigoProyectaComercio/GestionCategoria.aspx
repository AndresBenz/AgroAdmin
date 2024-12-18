﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionCategoria.aspx.cs" Inherits="CodigoAgroAdmin.GestionCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="Gestion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">Gestión de Categorías</h1>

    <!--Agregar categoría -->
    <div id="divFormulario" class="form-container" runat="server" visible="false">
        <div class="form-group">
            <asp:Label ID="lblNombreCategoria" runat="server" Text="Nombre:" CssClass="form-label" />
            <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreCategoria" ErrorMessage="El nombre de la categoría es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar"/>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombreCategoria" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ErrorMessage="El nombre solo puede contener letras." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar"/>
        </div>
        <div class="form-group">
            <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" CssClass="form-check-input" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnGuardarCategoria" runat="server" Text="Guardar" OnClick="btnGuardarCategoria_Click" CssClass="btn btn-primary"  ValidationGroup="grupoGuardar" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" />
        </div>
        <asp:HiddenField ID="hfIdCategoria" runat="server" />
    </div>

    <br />

    <!-- Lista de categorías -->
    <div id="divLista" class="list-container" runat="server">
        <div class="mt-3">
    <asp:Button ID="btnAgregarNueva" runat="server" Text="Agregar Nueva Categoría" OnClick="btnAgregarNueva_Click" CssClass="btn btn-success" />
</div>
        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCategorias_RowCommand" CssClass="custom-table">
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
