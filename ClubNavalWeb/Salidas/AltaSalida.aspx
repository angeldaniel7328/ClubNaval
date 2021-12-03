<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaSalida.aspx.cs" Inherits="ClubNavalWeb.Salidas.AltaSalida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Alta Salida</h3>
            <hr />
        </div>
        <div class="row form-group">
            <label for="<%=FechaSalida.ClientID %>">Fecha y Hora de Salida:</label>
            <input id="FechaSalida" runat="server" type="text" class="form-control" /><div style="position: absolute; top: 0; left: 0">
                <asp:RequiredFieldValidator ID="rfvtxtMatricula" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="FechaSalida" ErrorMessage="Fecha de salida requerida"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtDestino.ClientID %>">Destino:</label>
            <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control" placeholder="Destino"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtDestino" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtDestino" ErrorMessage="Destino de la salida requerida"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <label for="<%=ddlCapitan.ClientID %>">Capitán:</label>
            <asp:DropDownList ID="ddlCapitan" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Capitán"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlCapitan" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlCapitan" InitialValue="0" ErrorMessage="Selecciona el capitán del barco"></asp:RequiredFieldValidator>
        </div>

        <div class="row form-group">
            <label for="<%=ddlOwner.ClientID %>">Dueño:</label>
            <asp:DropDownList ID="ddlOwner" runat="server" CssClass="form-control" style="width:25%" OnSelectedIndexChanged="ddlOwner_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="0" Text="Selecciona dueño"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlCargo" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlOwner" InitialValue="0" ErrorMessage="Selecciona el dueño del barco"></asp:RequiredFieldValidator>
        </div>

        <div class="row form-group">
            <label for="<%=ddlBarco.ClientID %>">Barco:</label>
            <asp:DropDownList ID="ddlBarco" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Barco"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlBarco" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlBarco" InitialValue="0" ErrorMessage="Selecciona el barco"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click"/>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $.datetimepicker.setLocale('es');
            $("#<%=FechaSalida.ClientID%>").datetimepicker({
                format: 'd/m/Y H:i',
                minDate: '0'
            });
        });
    </script>
</asp:Content>
