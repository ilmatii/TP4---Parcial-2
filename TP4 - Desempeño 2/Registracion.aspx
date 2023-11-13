<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registracion.aspx.cs" Inherits="TP4___Desempeño_2.Registracion" MasterPageFile="~/Maestra.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2 class="text-center mb-4">Registro</h2>
        
        <div class="form-group">
            <label for="TextBox1">Mail:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Ingrese su correo electrónico"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TextBox2">Nombre de usuario:</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Ingrese su nombre de usuario"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TextBox3">Edad:</label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Ingrese su edad"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TextBox4">Contraseña:</label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TextBox5">Repita la contraseña:</label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" CssClass="form-control" placeholder="Repita su contraseña"></asp:TextBox>
        </div>

        <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
        <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
