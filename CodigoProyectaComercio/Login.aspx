<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CodigoAgroAdmin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .login-container h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .login-container div {
            margin-bottom: 10px;
        }

        .login-container label {
            display: block;
            margin-bottom: 5px;
        }

        .login-container input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .login-container button {
            width: 100%;
            padding: 10px;
            background-color: #28a745;
            border: none;
            border-radius: 5px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }

        .login-container button:hover {
            background-color: #365a98;
        }

        .login-container .link-button {
            text-align: center;
            margin-top: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <asp:Panel ID="pnlLogin" runat="server">
            <h2>Inicio de Sesión</h2>
            <asp:Label ID="lblmensajeLogin" runat="server" ForeColor="Red"></asp:Label>
            <div>
                <asp:Label ID="lblCorreoLogin" runat="server" Text="Correo electrónico:"></asp:Label>
                <asp:TextBox ID="txtCorreoLogin" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblDNILogin" runat="server" Text="DNI:"></asp:Label>
                <asp:TextBox ID="txtDNILogin" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>