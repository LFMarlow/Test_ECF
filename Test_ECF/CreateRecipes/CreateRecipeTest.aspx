<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRecipeTest.aspx.cs" Inherits="Test_ECF.CreateRecipeTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Recipes.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <div class="content_wrapper">
        <div class="photo_wrapper">
            <article class="info_container_article">
                <section class="recipe_info">
                    <div class="main_wrapper">
                        <h3 style="font-size: 1em">Titre de la nouvelle recette :</h3>
                        <asp:TextBox ID="TxtTitle" CssClass="TxtBoxTitle" Placeholder="Titre de la nouvelle recette" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <br />
                        <h3 style="font-size: 1em">Lien de l'image à afficher :</h3>
                        <asp:TextBox ID="TxtURLImage" CssClass="TxtBoxTitle" runat="server" placeholder="URL de l'image"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                </section>
                <section class="info_wrapper">
                    <div class="recipe_quick_info">
                        <h3 style="font-size: 1em">Temps de Cuisson : </h3>
                        &nbsp;
                        <asp:TextBox ID="TxtTime" CssClass="TxtBoxTitle" Placeholder="Temps de Cuisson" runat="server"></asp:TextBox>
                        <br />
                        <br /> 
                        &ensp;
                        &ensp;
                        <h3 style="font-size: 1em">Temps de Préparation : </h3>
                        &nbsp;
                        <asp:TextBox ID="TxtTimePrepa" CssClass="TxtBoxTitle" Placeholder="Temps de Preparation" runat="server"></asp:TextBox>
                        &ensp;
                        &ensp;
                        <h3 style="font-size: 1em">Temps de Repos : </h3>
                        &nbsp;
                        <asp:TextBox ID="TxtTimeRepos" CssClass="TxtBoxTitle" Placeholder="Temps de Repos" runat="server"></asp:TextBox>
                    </div>
                </section>
                <br />
                <section class="recipe_info">
                    <div class="main_wrapper">
                        <h3 style="font-size: 1em">Description :</h3>
                        <asp:TextBox ID="TxtDescription" CssClass="TxtBoxTitle" Placeholder="Description de la recette" runat="server"></asp:TextBox>
                        <p></p>
                    </div>
                    <br />
                    <div>
                        <div class="info_allergenes">
                            <h3 style="font-size: 1em">Allergènes (Séparé par des virgules) :</h3>
                            &nbsp;
                            <asp:TextBox ID="TxtAllergenes" CssClass="TxtBoxTitle" Placeholder="Allergènes présent dans la recette" runat="server" Width="500px"></asp:TextBox>
                            <p></p>
                        </div>
                        <br />
                        <div class="info_allergenes">
                            <h3 style="font-size: 1em">Régime (Séparé par des virgules) :</h3>
                            &nbsp;
                            <asp:TextBox ID="TxtBoxRegime" CssClass="TxtBoxTitle" Placeholder="Régime" runat="server"></asp:TextBox>
                            <p></p>
                        </div>
                        <br />
                    </div>
                </section>
            </article>
        </div>
        <section class="info-wrapper">
            <br />
            <div class="ingredient_recipe">
                <h3>Ingrédients (Séparé par des virgules)</h3>
                <br />
                <br />
                <asp:TextBox ID="TxtIngredients" runat="server" Height="112px" Width="288px"></asp:TextBox>
                <asp:Panel ID="PnlIngredients" runat="server">
                </asp:Panel>
            </div>
            <br />
           <div class="info_container">
               <h3>Étapes (Séparé par des virgules)</h3>
               <br />
               <br />
               <asp:TextBox ID="TxtEtapes" CssClass="TxtBoxTitle" runat="server" Height="100px" Width="313px"></asp:TextBox>
               <asp:Panel ID="PnlEtapes" runat="server">
               </asp:Panel>
               <br />
               <asp:CheckBox ID="CheckBoxVisibleClient" runat="server" Text='Recette visible uniquement par les "Clients"' />
               <br/>
               <br />
               <asp:Button ID="BtnCreateRecipe" runat="server" Text="Créer une recettes" OnClick="BtnCreateRecipe_Click" />
           </div>
       </section>
    </div>
</asp:Content>
