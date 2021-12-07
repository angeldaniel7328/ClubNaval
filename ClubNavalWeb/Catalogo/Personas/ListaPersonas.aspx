<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPersonas.aspx.cs" Inherits="ClubNavalWeb.Catalogo.Personas.ListaPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .fotogv {
            padding:5px;
        }
    </style>
    <div class="container">
        <div class="row" style="margin-bottom:18px">
            <h3>Lista Personas</h3>
            <hr />
        </div>
        <div class ="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdPersona" OnRowCommand="gvPersonas_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true"
                        DataImageUrlField="UrlFoto" ControlStyle-Width="110px"
                        ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px"
                        DataField="IdPersona" ReadOnly="true" />
                    <asp:BoundField HeaderText="Nombre" ItemStyle-Width="150px"
                        DataField="Nombre" />
                    <asp:BoundField HeaderText="Direccion" ItemStyle-Width="80px"
                        DataField="Direccion" />
                    <asp:BoundField HeaderText="Telefono" ItemStyle-Width="80px"
                        DataField="Telefono" />
                    <asp:BoundField HeaderText="Correo" ItemStyle-Width="80px"
                        DataField="Correo" />
                    <asp:BoundField HeaderText="Cargo" ItemStyle-Width="80px"
                        DataField="Cargo" />
                    <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div style="width:100%">
                                <div style="width:25%;margin:0 auto">
                                    <asp:CheckBox ID="chkDisponible" runat="server" Enabled="false" Checked='<%#Eval("Disponibilidad") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" 
                        Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
