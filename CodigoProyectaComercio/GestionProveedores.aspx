<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProveedores.aspx.cs" Inherits="CodigoAgroAdmin.GestionProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-4">
        <h2>Gestión de Proveedores</h2>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success mb-2" Text="Agregar Proveedor" OnClick="btnAgregar_Click" />
                </div>

                <asp:Repeater ID="RepeaterProveedores" runat="server">
                    <ItemTemplate>
                        <div class="card mb-2">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text">Dirección: <%# Eval("Direccion") %></p>
                                <p class="card-text">Correo Electrónico: <%# Eval("CorreoElectronico") %></p>
                                <p class="card-text">Teléfono: <%# Eval("Telefono") %></p>
                                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("IdProveedor") %>' OnClick="btnEditar_Click" CssClass="btn btn-primary">Editar</asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IdProveedor") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:PlaceHolder ID="phFormulario" runat="server" Visible="false">
                    <h2>Agregar/Editar Proveedor</h2>
                    <asp:HiddenField ID="hiddenIdProveedor" runat="server" />
                    <div class="form-group">
                        <label for="nombreProveedor">Nombre del Proveedor</label>
                        <asp:TextBox ID="nombreProveedor" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del proveedor"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="direccionProveedor">Dirección</label>
                        <asp:TextBox ID="direccionProveedor" runat="server" CssClass="form-control" placeholder="Ingrese la dirección"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="correoProveedor">Correo Electrónico</label>
                        <asp:TextBox ID="correoProveedor" runat="server" CssClass="form-control" placeholder="Ingrese el correo electrónico"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="telefonoProveedor">Teléfono</label>
                        <asp:TextBox ID="telefonoProveedor" runat="server" CssClass="form-control" placeholder="Ingrese el número de teléfono"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar Proveedor" OnClick="btnGuardar_Click" />
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
