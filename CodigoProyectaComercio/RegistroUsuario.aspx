<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="CodigoAgroAdmin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .registration-container {
        max-width: 400px;
        margin: 50px auto;
        padding: 20px;
        border: 1px solid #ccc;
        background-color: #fff;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .registration-container h2 {
        text-align: center;
        margin-bottom: 20px;
    }

    .registration-container div {
        margin-bottom: 10px;
    }

    .registration-container label {
        display: block;
        margin-bottom: 5px;
    }

    .registration-container input {
        width: 100%;
        padding: 10px;
        margin-bottom: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    .registration-container button {
        width: 100%;
        padding: 10px;
        background-color: #28a745;
        border: none;
        border-radius: 5px;
        color: #fff;
        font-size: 16px;
        cursor: pointer;
    }

    .registration-container button:hover {
        background-color: #365a98;
    }

  
    .dropdown-style {
        width: 100%;
        padding: 10px;
        margin-bottom: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 14px;
        background-color: #f9f9f9;
    }

 
    .label-style {
        display: block;
        font-weight: bold;
        margin-bottom: 5px;
        font-size: 14px;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registration-container">
        <h2>Registro</h2>
        <asp:Label ID="lblMensajeRegistro" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        <div>
            <asp:Label ID="lblUsuarioRegistro" runat="server" Text="Nombre de usuario:"></asp:Label>
            <asp:TextBox ID="txtUsuarioRegistro" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuarioRegistro" runat="server" ControlToValidate="txtUsuarioRegistro" ErrorMessage="El nombre de usuario es obligatorio." ForeColor="Red"/>
        </div>
        <div>
            <asp:Label ID="lblEmailRegistro" runat="server" Text="Correo electrónico:"></asp:Label>
            <asp:TextBox ID="txtEmailRegistro" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revEmailRegisto" runat="server" ControlToValidate="txtEmailRegistro" ErrorMessage="Por favor, introduce una dirección de correo electrónico válida." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ForeColor="Red"/>
            <asp:RequiredFieldValidator ID="rfvEmailRegistro" runat="server" ControlToValidate="txtEmailRegistro" ErrorMessage="El email es obligatorio." ForeColor="Red"/>
        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:"></asp:Label>
            <asp:TextBox ID="txtDNIRegistro" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revDNIRegistro" runat="server" ControlToValidate="txtDNIRegistro" ErrorMessage="Por favor, introduce solo números." ValidationExpression="^\d+$" ForeColor="Red"/>
            <asp:RequiredFieldValidator ID="rfvDNIRegistro" runat="server" ControlToValidate="txtDNIRegistro" ErrorMessage="El dni es obligatorio." ForeColor="Red"/>
        </div>
        <div>
            <asp:Label ID="lblTelefonoRegistro" runat="server" Text="Teléfono (Opcional):"></asp:Label>
            <asp:TextBox ID="txtTelefonoRegistro" runat="server"></asp:TextBox>
        </div>
          <div>
                <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo de Usuario:" CssClass="label-style"></asp:Label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="dropdown-style">
                    <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Cliente" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
        <div>
            <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
        </div>
    </div>
</asp:Content>
