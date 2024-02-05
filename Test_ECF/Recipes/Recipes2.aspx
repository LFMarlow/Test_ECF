<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recipes2.aspx.cs" Inherits="Test_ECF.Recipes2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Recipes.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <div class="content_wrapper">
        <div class="photo_wrapper">
            <div class="img_wrapper">
                <img src="Content/ContentIMG/recipes2.jpg" alt="Tomates farcies au poisson blanc" class="img_recipes1"/>
            </div>
            <article class="info_container_article">
                <h1 class="title_container">Tomates farcies au poisson blanc</h1>
                <section class="info_wrapper">
                    <div class="recipe_quick_info">
                        <img src="Content/ContentIMG/tmp_cuisson.png" alt="Temps de cuisson" class="img_cuisson" />
                        <p class="time">01:00</p>
                    </div>
                </section>
                <br />
                <section class="recipe_info">
                    <div class="main_wrapper">
                        <h3 style="font-size: 1em">Description</h3>
                        <p></p>
                        <div>Une recette qui change des traditionnelles tomates farcies à la viande.</div>
                    </div>
                    <br />
                    <div>
                        <div class="info_allergenes">
                            <h3>Allergènes :</h3>
                            <p>&nbsp;Oeuf, Gluten</p>
                        </div>
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
            <li>6 Tomates</li>
            <li>200g de filet de lieu noir ou autre poisson blanc</li>
            <li>2 tranches de pain de mie complet</li>
            <li>1 Oeuf</li>
            <li>1 cuillère à soupe de sauce basilic ou pesto</li>
            <li>1 cuillère à soupe d’huile d’olive</li>
            <li>Sel, Poivre</li>
            <li>Fines herbes</li>
        </div>
        <br />
        <div class="info_container">
            <h3>Étapes</h3>
            <br />
            <br />
            <li>Au préalable laver les tomates et les creuser à l’aide d’une cuillère parisienne. Saler légèrement l’intérieur et les mettre à dégorger à l’envers environ 30 min.</li>
            <li>Faire préchauffer le four à 190°.</li>
            <li>Pendant ce temps enlever les arêtes du poisson si besoin. Le placer dans un mixeur. Rajouter le pain de mie en morceaux l’œuf la sauce l’huile et les fines herbes. Saler et poivrer.</li>
            <li>Répartir la farce dans chaque tomate.</li>
            <li>Mettre au four pendant au moins 30 min.</li>
       </div>
    </section>
    </div>
</asp:Content>
