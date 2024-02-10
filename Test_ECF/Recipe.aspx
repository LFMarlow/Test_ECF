<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="Test_ECF.Recipe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Recipes.css"" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel ="stylesheet"/>
    <div class="content_wrapper">
        <div class="photo_wrapper">
            <div class="img_wrapper">
                <asp:Image ID="IMGRecipe" CssClass="img_recipes1" runat="server" />
            </div>
            <article class="info_container_article">
                <h1 class="title_container"><asp:Label ID="LblTitle" runat="server" Text=""></asp:Label></h1>
                <section class="info_wrapper">
                    <div class="recipe_quick_info">
                        <img src= "/Content/ContentIMG/tmp_cuisson.png" alt="Temps de cuisson" class="img_cuisson"/>
                        <p class='time'><asp:Label ID="LblTmpCuisson" runat="server" Text=""></asp:Label>
                            <img src= "/Content/ContentIMG/tmp_prepa.png" alt="Temps de Preparation" class="img_cuisson"/>
                            <asp:Label ID="LblTmpPrepa" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;
                            <img src= "/Content/ContentIMG/tmp_repos.png" alt="Temps de Repos" class="img_cuisson""/>
                            <asp:Label ID="LblTmpRepos" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </section>
                <br />
                <section class="recipe_info">
                    <div class="main_wrapper">
                        <h3 style="font-size: 1em">Description</h3>
                        <p></p>
                        <div>
                            <asp:Label ID="LblDescription" runat="server" Text=""></asp:Label>
                        </div>
                        <br />
                        <div>
                            <div class='info_allergenes'>
                                <h3 style = 'font-size: 1em'>Allergenes :</h3>
                                &nbsp;
                                <p><asp:Label ID="lblAllergenes" runat="server" Text=""></asp:Label></p>
                            </div>
                            <br />
                        </div>
                        <div>
                            <div class='info_allergenes'>
                                <h3 style = 'font-size: 1em'>Régime :</h3>
                                &nbsp;
                                <p><asp:Label ID="LblRegime" runat="server" Text=""></asp:Label></p>
                            </div>
                        </div>
                        <br />
                    </div>
                </section>
            </article>
        </div>
        <section class='info-wrapper'>
            <br />
            <div class='ingredient_recipe'>
                <h3>Ingredients</h3>
                <br />
                <br />
                <asp:BulletedList ID="BullListIngr" runat="server"></asp:BulletedList>
                <div class="info_container">
                    <h3>Etapes</h3>
                    <br />
                    <br />
                    <asp:BulletedList ID="BullListEtapes" runat="server"></asp:BulletedList>
                </div>
            </div>
        </section>
    <div class='footer_avis'>
        <h4 class='title_container'><asp:Label ID="LblAvisDeco" runat="server" Text=""></asp:Label></h4>
        <br />
        <h4 class="title_note"><asp:Label ID="LblAvisCo" runat="server" Text=""></asp:Label></h4>
        <br />
        <br />
        <asp:TextBox ID="TxtBoxAvis" CssClass="TxtBoxAvis" runat="server"></asp:TextBox>
        <br />
        <br />
        <h4 class="title_note"><asp:Label ID="LblLaissezNote" runat="server" Text="Laissez une note pour cette recette !"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblNote" runat="server" Text=""></asp:Label></h4>
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="BtnSendAvis" CssClass="BtnSend" runat="server" Text="Laissez un Avis" OnClick="BtnSendAvis_Click" />
        <br />
        <br />
        <asp:Panel ID="PnlAvis" CssClass="PnlAvis" runat="server"></asp:Panel>
    </div>
    </div>
</asp:Content>
