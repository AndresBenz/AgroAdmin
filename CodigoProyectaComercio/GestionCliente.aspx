<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionCliente.aspx.cs" Inherits="CodigoAgroAdmin.GestionCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Gestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="listarClientes" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
        </div>
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClientes_RowCommand" CssClass="custom-table">

            <Columns>
                <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("DNI") %>' CssClass="btn btn-warning" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("DNI") %>' CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </div>

    <div class="form-container" id="formularioCliente" runat="server" visible="false" style="margin-top: 20px;">
        <h2>
            <asp:Label ID="lblTituloFormulario" runat="server" Text="Agregar/Modificar Cliente" /></h2>

        <asp:HiddenField ID="hfIdCliente" runat="server" />
        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre del Cliente:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreCliente" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre del producto es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ErrorMessage="El nombre solo puede contener letras." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" InitialValue="" ErrorMessage="El DNI es obligatorio." ForeColor="Red" ValidationGroup="grupoGuardar" />
            <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ValidationExpression="^\d{8,10}$" ErrorMessage="El DNI debe ser un número entre 8 y 10 dígitos." ForeColor="Red" ValidationGroup="grupoGuardar" />
        </div>
        <div>
            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" InitialValue="" ErrorMessage="El correo es obligatorio." ForeColor="Red" ValidationGroup="grupoGuardar" />
            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zAZ0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="El correo electrónico no tiene un formato válido." ForeColor="Red" ValidationGroup="grupoGuardar" />
        </div>
        <div>
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" InitialValue="" ErrorMessage="El teléfono es obligatorio." ForeColor="Red" ValidationGroup="grupoGuardar" />
            <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ValidationExpression="^\d{10}$" ErrorMessage="El teléfono debe ser un número de 10 dígitos." ForeColor="Red" ValidationGroup="grupoGuardar" />
        </div>
        <div style="margin-top: 20px; text-align: center;">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-add" ValidationGroup="grupoGuardar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn-secondary" />
        </div>
    </div>
</asp:Content>
