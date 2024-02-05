<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MesRecettes.aspx.cs" Inherits="Test_ECF.MesRecettes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/MesRecettes.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <main class="main_content">
        <h2 class="title_content">Voici toutes mes recettes</h2>
        <br />
        <div>
            <h2><asp:Label ID="LblDDL" runat="server" Text="Choisir la Recette que vous voulez voir"></asp:Label></h2>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="recipes_container">
            <div class="recipes_wrapper">
                <h4><asp:Label ID="LblTitleRecipe" CssClass="recipes_title" runat="server" Text=""></asp:Label></h4>
                <asp:ImageButton ID="ImageButton1" CssClass="recipes1_img" runat="server" OnClick="ImageButton1_Click" />
                <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
            </div>
        </div>
    </main> 
</asp:Content>
