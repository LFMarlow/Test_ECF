<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Test_ECF.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/About.css" rel="stylesheet" />
    <main aria-labelledby="title" id="body_content">
        <center><h2 id="title">Sandrine, Diététicienne Nutritionniste en ligne</h2></center>
        <div class="img_wrapper">
            <img src="/Content/ContentIMG/SandrineC.jpg" alt="welcome background image" class="welcome-img main-image" />
            <div class="content">
                <h2>A propos de moi</h2>
            </div>
                <p class="p_content">Je suis Sandrine, une Diététicienne Nutritionniste en ligne passionnée par mon métier.
                    <br />
                    J’ai une approche pratique de la nutrition, qui se concentre sur le plaisir de manger tout en maintenant une alimentation saine et équilibrée.
                    <br />
                    Je consulte à distance du lundi au samedi inclus !
                </p>
        </div>
    </main>
</asp:Content>
