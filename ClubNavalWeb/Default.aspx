<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Proyecto Web - Club Naval</h1>
        <h2>Desarrollo de Sistemas Web</h2>
        <p class="lead">Laboratorio 4. Proyecto web en capas</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Barcos</h2>
            <p>
                <a class="btn btn-default" href="Catalogo/Barcos/AltaBarco.aspx">Alta</a>
            </p>
            <p>
                <a class="btn btn-default" href="Catalogo/Barcos/ListaBarcos.aspx">Lista</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Personas</h2>
            <p>
                <a class="btn btn-default" href="Catalogo/Personas/AltaPersona.aspx">Alta</a>
            </p>
            <p>
                <a class="btn btn-default" href="Catalogo/Personas/ListaPersonas.aspx">Lista</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Salidas</h2>
            <p>
                <a class="btn btn-default" href="Salidas/AltaSalida.aspx">Alta</a>
            </p>
            <p>
                <a class="btn btn-default" href="Salidas/SalidasProceso.aspx">En proceso</a>
            </p>
            <p>
                <a class="btn btn-default" href="Salidas/SalidasFinalizadas.aspx">Finalizadas</a>
            </p>
        </div>
    </div>

</asp:Content>
