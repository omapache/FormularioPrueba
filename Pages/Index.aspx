<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FormularioPrueba.Pages.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width: 300px">
            <h2>Listado de registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-2"></div>
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control" Text="Create" OnClick="BtnCreate_Click"/>
                </div>
                <div class="col-2"></div>
            </div>
        </div>
        <br />
        <div class="container ">
            <div class="col-2"></div>
            <div class="table small">
                <asp:GridView runat="server" ID="GVusuarios" CssClass="table table-borderless table-hover" Text="Create">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del admin">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" CssClass="btn form-control-info btn-info" ID="BtnRead" OnClick="BtnRead_Click" />
                                <asp:Button runat="server" Text="Update" CssClass="btn form-control-info btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click" />
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-info btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-2"></div>
        </div>
    </form>
</asp:Content>
