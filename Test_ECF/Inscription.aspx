<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Test_ECF.Inscription" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Inscription.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel ="stylesheet" />
    <main aria-labelledby="title">
        <div id="div_content" >
            <asp:Label ID="LblNom" CssClass="Lbl" runat="server" Text="Votre Nom :"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxNom" wrapperClass="mb-4" placeholder="Votre Nom" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblPrenom" CssClass="Lbl" runat="server" Text="Votre Prénom :"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxPrenom" placeholder="Votre Prenom" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblMail" CssClass="Lbl" runat="server" Text="Votre Adresse Mail :"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxMail" TextMode="Email" placeholder="Votre Adresse Mail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblMdp" CssClass="Lbl" runat="server" Text="Votre Mot de passe"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxMDP" TextMode="Password" placeholder="Votre mot de passe" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LblAllergenes" CssClass="Lbl" runat="server" Text="Allergenes"></asp:Label>
            <asp:TextBox ID="TxtBoxAllergenes" class="TxtBx" runat="server" placeholder="Vos Allergenes"></asp:TextBox>
            <br />
            <asp:Button class="BtnInscr" ID="BtnInscription" runat="server" Text="S'inscrire" OnClick="BtnInscription_Click" />
        </div>
    </main>
</asp:Content>
