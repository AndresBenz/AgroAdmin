<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionCliente.aspx.cs" Inherits="CodigoAgroAdmin.GestionCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Gestión de Clientes</h2>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success mb-2" Text="Agregar Cliente" OnClick="btnAgregar_Click" />
                </div>

                <asp:Repeater ID="RepeaterClientes" runat="server">
                    <ItemTemplate>
                        <div class="card mb-2">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text">Dirección: <%# Eval("Direccion") %></p>
                                <p class="card-text">Correo Electrónico: <%# Eval("CorreoElectronico") %></p>
                                <p class="card-text">Teléfono: <%# Eval("Telefono") %></p>
                                <p class="card-text">DNI: <%# Eval("DNI") %></p>
                                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("DNI") %>' OnClick="btnEditar_Click" CssClass="btn btn-primary">Editar</asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("DNI") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:PlaceHolder ID="phFormulario" runat="server" Visible="false">
                    <h2>Agregar/Editar Cliente</h2>
                    <div class="form-group">
                        <label for="nombreCliente">Nombre del Cliente</label>
                        <asp:TextBox ID="nombreCliente" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del cliente"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="DNICliente">DNI</label>
                        <asp:TextBox ID="DNICliente" runat="server" CssClass="form-control" placeholder="Ingrese DNI del cliente"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="direccionCliente">Dirección</label>
                        <asp:TextBox ID="direccionCliente" runat="server" CssClass="form-control" placeholder="Ingrese la dirección"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="correoCliente">Correo Electrónico</label>
                        <asp:TextBox ID="correoCliente" runat="server" CssClass="form-control" placeholder="Ingrese el correo electrónico"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="telefonoCliente">Teléfono</label>
                        <asp:TextBox ID="telefonoCliente" runat="server" CssClass="form-control" placeholder="Ingrese el número de teléfono"></asp:TextBox>
                    </div>

                    <asp:HiddenField ID="hiddenIdCliente" runat="server" />


                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar Cliente" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
