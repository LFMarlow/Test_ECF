<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recipes3.aspx.cs" Inherits="Test_ECF.Recipes3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Recipes.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <div class="content_wrapper">
        <div class="photo_wrapper">
            <div class="img_wrapper">
                <img src="Content/ContentIMG/recipes3.jpg" alt="Cookies Banane Coco Chocolat" class="img_recipes1"/>
            </div>
            <article class="info_container_article">
                <h1 class="title_container">Cookies Banane Coco Chocolat</h1>
                <section class="info_wrapper">
                    <div class="recipe_quick_info">
                        <img src="Content/ContentIMG/tmp_cuisson.png" alt="Temps de cuisson" class="img_cuisson" />
                        <p class="time">00:15</p>
                    </div>
                </section>
                <br />
                <section class="recipe_info">
                    <div class="main_wrapper">
                        <h3 style="font-size: 1em">Description</h3>
                        <p></p>
                        <div>Un cookie géant tout moelleux au bon goût de banane et de noix de coco et avec des pépites de chocolat bien sûr !</div>
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
            <li>2 bananes bien mûres</li>
            <li>80g de beurre demi-sel à température ambiante ou de beurre d’amande ou de beurre de cacahuète</li>
            <li>130g de farine</li>
            <li>50g de flocons d'avoine</li>
            <li>80g de noix de coco</li>
            <li>2 cuillères à café de levure chimique</li>
            <li>60g de cassonade ou de sucre blanc</li>
            <li>1 oeuf</li>
            <li>70g de chocolat noir en pépites ou concassés grossièrement</li>
        </div>
        <br />
        <div class="info_container">
            <h3>Étapes</h3>
            <br />
            <br />
            <li>Préchauffer le four à 180°.</li>
            <li>Ecraser les bananes.</li>
            <li>Dans un saladier, réduire le beurre en pommade avec la cassonade, jusqu’à obtention d'une crème.</li>
            <li>Dans un autre récipient, mélanger la farine, les flocons d'avoine, la noix de coco et la levure.</li>
            <li>Verser ce mélange sur le mélange beurre/sucre, mélanger rapidement. Ajoutez l'œuf battu, mélanger.</li>
            <li>Incorporer les pépites de chocolat.</li>
            <li>Sur une plaque garnie d'une feuille en silicone ou d’un papier cuisson et à l'aide d'une cuillère à soupe , déposer des tas en laissant un espace puis les aplatir légèrement.</li>
            <li>Faire cuire 15 à 18 min.</li>
       </div>
   </section>
   </div>
</asp:Content>
