<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mes-Services.aspx.cs" Inherits="Test_ECF.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Services.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <div class="div_content">
        <section class="section_content_title">
            <h1>Les consultations diététiques</h1>
        </section>
        <section class="section_content">
            <div class="section_content_left">
                <img class="bilan_img" src="Content/ContentIMG/bilan-dietetique.jpg" />
                <br />
                <h2 class="titleLeft">Bilan Diététiques</h2>
                <p>Durant ce 1er RDV, nous déterminons ensemble vos besoins et vos objectifs.
                    <br />
                    Je vous pose des questions sur vos habitudes alimentaires, 
                    votre mode de vie afin de vous proposer des solutions 100% personnalisées ! 
                    À la suite de ce RDV, je vous envoie votre dossier diététique par mail 
                    dans la semaine suivant votre RDV !
                </p>
            </div>
            <div class="section_content_right">
                <img class="bilan_img_right" src="Content/ContentIMG/Com.jpg" />
                <br />
                <h2 class="titleRight">Consultation de suivi</h2>
                <p>Les consultations de suivi nous permettent de faire le point sur ce qui s'est 
                    passé entre les 2 RDV et de trouver des solutions ensemble. 
                    <br />
                    C'est aussi l'occasion de faire le point sur une notion de nutrition afin de vous 
                    rendre plus autonome.
                </p>
            </div>
        </section>
        <br />
        <section class="section_footer_title">
            <h1>Combien de temps dure le suivi diététique ?</h1>
        </section>
        <section class="content_footer">
            <div class="div_content_footer">
                <br />
                <p>Cela va dépendre de vos objectifs, votre parcours et vos besoins. 
                    Certains auront besoin de plus de séances que d’autres et c’est ok. 
                    L’écart entre les consultations va aussi dépendre de tout cela: en général, 
                    je recommande un RDV toutes les 3 semaines au début puis, 
                    une fois que vous êtes un peu plus autonome, tous les 2 mois.
                    <br />
                    Bien sûr, si vous avez besoin d’un suivi plus rapproché ou au contraire plus éloigné, il n’y a pas de soucis. Nous verrons ensemble comment planifier tout ça.
                </p>
            </div>
        </section>
    </div>
</asp:Content>
