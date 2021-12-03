<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalidasFinalizadas.aspx.cs" Inherits="ClubNavalWeb.Salidas.SalidasFinalizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Salidas Finalizadas</h3>
            <hr />
        </div>

        <div class="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvSalidas"
                runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdSalida">
                <Columns>
                    <asp:ImageField HeaderText="Foto Barco" ReadOnly="true" DataImageUrlField="UrlFotoBarco" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:ImageField HeaderText="Foto Capitán" ReadOnly="true" DataImageUrlField="UrlFotoCapitan" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdSalida" ReadOnly="true" />
                    <asp:BoundField HeaderText="Fecha" ItemStyle-Width="150px" DataField="FechaHoraSalida" />
                    <asp:BoundField HeaderText="Destino" ItemStyle-Width="200px" DataField="Destino" />
                    <asp:BoundField HeaderText="Capitán" ItemStyle-Width="200px" DataField="NombreCapitan" />
                    <asp:BoundField HeaderText="Barco" ItemStyle-Width="200px" DataField="NombreBarco" />
                    </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>