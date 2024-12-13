<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuario.aspx.cs" Inherits="CodigoAgroAdmin.GestionUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Gestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    <div id="listarUsuarios" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="height: 20vh;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
        </div>
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" OnRowCommand="gvUsuarios_RowCommand" CssClass="custom-table">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="ID" SortExpression="IdUsuario" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo Usuario" SortExpression="TipoUsuario" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn btn-warning" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    <div class="form-container" id="formularioUsuario" runat="server" visible="false" style="margin-top: 20px;">
        <h2>
            <asp:Label ID="lblTituloFormulario" runat="server" Text="Agregar/Modificar Usuario" /></h2>
        <asp:Label ID="lblMensajeFormulario" runat="server" ForeColor="Red" />


        <asp:HiddenField ID="hfIdUsuario" runat="server" />
        <div>
            <asp:Label ID="lblUsuario" runat="server" Text="Nombre de Usuario:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El nombre de usuario es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsuario" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ErrorMessage="El nombre solo puede contener letras." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

        </div>
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El correo electrónico es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Formato de correo electrónico no válido." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="El DNI es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ValidationExpression="^\d{8,10}$" ErrorMessage="El DNI debe ser un número de 8 a 10 dígitos." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
</div>
        
        <div>
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El teléfono es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ValidationExpression="^\d{10}$" ErrorMessage="El teléfono debe ser un número de 10 dígitos." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />
        </div>
        <div>
            <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo de Usuario:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlTipoUsuario" CssClass="form-select" runat="server">
                <asp:ListItem Text="Seleccione Un Tipo de Usuario" Value="2"></asp:ListItem>
                <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipoUsuario" runat="server" ControlToValidate="ddlTipoUsuario" InitialValue="2" ErrorMessage="Debe seleccionar un tipo de usuario." CssClass="text-danger" Display="Dynamic" ValidationGroup="grupoGuardar" />

        </div>
        <div style="margin-top: 20px; text-align: center;">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-add" ValidationGroup="grupoGuardar"/>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Visible="false" CssClass="btn btn-primary" ValidationGroup="grupoGuardar"/>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />

        </div>
    </div>
</asp:Content>
