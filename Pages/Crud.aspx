<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="FormularioPrueba.Pages.Crud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    crud
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="Lbtitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombres</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbNombres"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Apellidos</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbApellidos"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbTelefono"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Ciudad</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbCiudad"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Mes</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="tbMes">
                    <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">VentaMes</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbVentaMes"></asp:TextBox>
            </div>

            <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-primary" Text="Create" Visible="false" OnClick="BtnCreate_Click"/>
            <asp:Button runat="server" ID="BtnUpdate" CssClass="btn btn-primary" Text="Update" Visible="false" Onclick="BtnUpdate_Click"/>
            <asp:Button runat="server" ID="BtnDelete" CssClass="btn btn-primary" Text="Delete" Visible="false" Onclick="BtnDelete_Click" />
            <asp:Button runat="server" ID="BtnVolver" CssClass="btn btn-primary btn-dark" Text="Volver" Visible="true" OnClick="BtnVolver_Click" />
        </div>
    </form>
</asp:Content>
