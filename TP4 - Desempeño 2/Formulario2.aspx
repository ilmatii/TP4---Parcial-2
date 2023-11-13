<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario2.aspx.cs" Inherits="TP4___Desempeño_2.Formulario2" MasterPageFile="~/Maestra.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
      
        <asp:Label ID="BienvenidoLabel" runat="server" Text="" CssClass="bienvenido-label"></asp:Label>

        <h2>Gestión de Archivos</h2>
      
        <input type="file" id="fileUpload" runat="server" />
         
        <asp:Button ID="btnUpload" runat="server" Text="Subir Archivo" OnClick="btnUpload_Click" />
        <hr />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
    <Columns>
        <asp:BoundField DataField="FileName" HeaderText="Nombre de Archivo" />
        <asp:TemplateField HeaderText="Descargar">
            <ItemTemplate>
                <asp:Button runat="server" Text="Descargar" CommandName="DownloadFile" CommandArgument='<%# Eval("FilePath") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


    </div>
</asp:Content>
