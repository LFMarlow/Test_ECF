<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Test_ECF.Inscription" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Inscription.css" rel="stylesheet" />
    <main aria-labelledby="title">
        <div id="div_content" >
            <asp:Label ID="LblNom" runat="server" Text="Votre Nom :"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxNom" wrapperClass="mb-4" placeholder="Votre Nom" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblPrenom" runat="server" Text="Votre Prénom :"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxPrenom" placeholder="Votre Prenom" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblMail" runat="server" Text="Votre Adresse Mail :"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxMail" TextMode="Email" placeholder="Votre Adresse Mail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblMdp" runat="server" Text="Votre Mot de passe"></asp:Label>
            <asp:TextBox class="TxtBx" ID="TxtBoxMDP" TextMode="Password" placeholder="Votre mot de passe" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LblAllergenes" runat="server" Text="Allergenes"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxListAllergenes" runat="server"></asp:CheckBoxList>
            <br />
            <asp:Button class="BtnInscr" ID="BtnInscription" runat="server" Text="S'inscrire" OnClick="BtnInscription_Click" />
        </div>
    </main>
</asp:Content>
