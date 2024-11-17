<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="CodigoAgroAdmin.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .edit-container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .edit-container h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .edit-container div {
            margin-bottom: 10px;
        }

        .edit-container label {
            display: block;
            margin-bottom: 5px;
        }

        .edit-container input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .edit-container button {
            width: 100%;
            padding: 10px;
            background-color: #28a745;
            border: none;
            border-radius: 5px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }

        .edit-container button:hover {
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
    <div class="edit-container">
        <h2>Modificar Usuario</h2>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
        <div>
            <asp:Label ID="lblUsuario" runat="server" Text="Nombre de Usuario:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="label-style"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo de Usuario:" CssClass="label-style"></asp:Label>
            <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="dropdown-style">
                <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        </div>
    </div>
</asp:Content>
