<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="CodigoAgroAdmin.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <style>
        .profile-container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .profile-container h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        .profile-details {
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .profile-details label {
            font-weight: bold;
            color: #555;
        }

        .profile-details .value {
            margin-left: 10px;
            color: #000;
        }

        .profile-item {
            display: flex;
            justify-content: space-between;
        }

        .profile-item:nth-child(even) {
            background-color: #f0f0f0;
        }

        .profile-item:nth-child(odd) {
            background-color: #ffffff;
        }

        .profile-item {
            padding: 10px;
            border-radius: 5px;
        }
        .logout-button {
            width: 100%;
            padding: 10px;
            margin-top: 20px;
            background-color: #dc3545;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        .logout-button:hover {
            background-color: #c82333;
        }

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profile-container">
        <h2>Detalles del Usuario</h2>
        <div class="profile-details">
            <div class="profile-item">
                <label for="lblIdUsuario">ID de Usuario:</label>
                <span class="value"><asp:Label ID="lblIdUsuario" runat="server" /></span>
            </div>
            <div class="profile-item">
                <label for="lblDNI">DNI:</label>
                <span class="value"><asp:Label ID="lblDNI" runat="server" /></span>
            </div>
            <div class="profile-item">
                <label for="lblNombre">Nombre:</label>
                <span class="value"><asp:Label ID="lblNombre" runat="server" /></span>
            </div>
            <div class="profile-item">
                <label for="lblCorreoElectronico">Correo Electrónico:</label>
                <span class="value"><asp:Label ID="lblCorreoElectronico" runat="server" /></span>
            </div>
            <div class="profile-item">
                <label for="lblTelefono">Teléfono:</label>
                <span class="value"><asp:Label ID="lblTelefono" runat="server" /></span>
            </div>
        </div>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesión" CssClass="logout-button" OnClick="btnLogout_Click" />

    </div></asp:Content>
