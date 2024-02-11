<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRecipes.aspx.cs" Inherits="Test_ECF.CreateRecipes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/CreateRecipes.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <div class="div_main_content">
        <h1 class="title_content">Créer une nouvelle recette</h1>
        <br />
        <div class="nav_tab">
            <div class="div_content_title_recipe">
                <asp:Label ID="LblTitleRecipe" CssClass="LblTitleRecipe" runat="server" Text="Titre de la recette :"></asp:Label>
                <asp:TextBox ID="TxtBoxTitle" CssClass="TxtBoxTitle" runat="server"></asp:TextBox>
            </div>
            <div class="div_content_title_recipe">
                <asp:Label ID="LblImg" CssClass="LblImg" runat="server" Text="URL de la photo de la recette :"></asp:Label>
                <asp:TextBox ID="TxtBoxImg" CssClass="TxtBoxImg" runat="server"></asp:TextBox>
            </div>
            <div class="div_content_time">
                <asp:Label ID="LblTime" CssClass="LblDescription" runat="server" Text="Temps de préparation :"></asp:Label>
                <asp:TextBox ID="TxtBoxTime" CssClass="TxtBoxTime" runat="server"></asp:TextBox>
            </div>
            <div class="div_content_description">
                <asp:Label ID="LblDescription" CssClass="LblDescription" runat="server" Text="Description :"></asp:Label>
                <asp:TextBox ID="TxtBoxDescription" CssClass="TxtBoxDescription" runat="server"></asp:TextBox>
            </div>
            <div class="div_content_Allergenes">
                <asp:Label ID="LblAllergenes" CssClass="LblAllergenes" runat="server" Text="Allergenes :"></asp:Label>
                <asp:TextBox ID="TxtBoxAllergene" CssClass="TxtBoxAllergene" runat="server"></asp:TextBox>
            </div>
            <div class="div_content_ingredients">
                <asp:Label ID="LblIngredients" CssClass="LblIngredients" runat="server" Text="Ingredients :"></asp:Label>
                <asp:TextBox ID="TxtBoxIngredient" CssClass="TxtBoxIngredient" runat="server"></asp:TextBox>
            </div>
            <div class="div_content_etapes">
                <asp:Label ID="LblEtapes" CssClass="LblEtapes" runat="server" Text="Etapes de préparation :"></asp:Label>
                <asp:TextBox ID="TxtBoxEtape" CssClass="TxtBoxEtape" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="BtnCreateRecipe" runat="server" Text="Soumettre la nouvelle recette" OnClick="BtnCreateRecipe_Click" />

            <asp:Image ID="Image1" runat="server" />
        </div>
    </div>
</asp:Content>
