<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRecipeTest.aspx.cs" Inherits="Test_ECF.CreateRecipeTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Recipes.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <div class="content_wrapper">
        <div class="photo_wrapper">
            <div class="img_wrapper">
                <asp:TextBox ID="TxtURLImage" CssClass="TxtBoxTitle" runat="server" placeholder="URL de l'image"></asp:TextBox>
            </div>
            <article class="info_container_article">
                <h1 class="title_container">Titre de la nouvelle recette</h1>
                <asp:TextBox ID="TxtTitle" CssClass="TxtBoxTitle" runat="server"></asp:TextBox>
                <section class="info_wrapper">
                    <div class="recipe_quick_info">
                        <img src="../Content/ContentIMG/tmp_cuisson.png" alt="Temps de cuisson" class="img_cuisson" />
                        <asp:TextBox ID="TxtTime" CssClass="TxtBoxTitle" runat="server"></asp:TextBox>
                        <p class="time"></p>
                    </div>
                </section>
                <br />
                <section class="recipe_info">
                    <div class="main_wrapper">
                        <h3 style="font-size: 1em">Description :</h3>
                        <asp:TextBox ID="TxtDescription" CssClass="TxtBoxTitle" runat="server"></asp:TextBox>
                        <p></p>
                        <div></div>
                    </div>
                    <br />
                    <div>
                        <div class="info_allergenes">
                            <h3 style="font-size: 1em">Allergènes :</h3>
                            <asp:TextBox ID="TxtAllergenes" CssClass="TxtBoxTitle" runat="server"></asp:TextBox>
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
                <h3>Ingrédients</h3>
                <br />
                <br />
                <asp:TextBox ID="TxtIngredients" runat="server"></asp:TextBox>
                <asp:Panel ID="PnlIngredients" runat="server">
                </asp:Panel>
            </div>
            <br />
           <div class="info_container">
               <h3>Étapes</h3>
               <br />
               <br />
               <asp:TextBox ID="TxtEtapes" CssClass="TxtBoxTitle" runat="server"></asp:TextBox>
               <asp:Panel ID="PnlEtapes" runat="server">
               </asp:Panel>
               <asp:CheckBox ID="CheckBoxVisibleClient" runat="server" Text='Recette visible uniquement par les "Clients"' OnCheckedChanged="CheckBox1_CheckedChanged" />
               <br/>
               <asp:Button ID="BtnCreateRecipe" runat="server" Text="Créer une recettes" OnClick="BtnCreateRecipe_Click" />
           </div>
       </section>
    </div>
</asp:Content>
