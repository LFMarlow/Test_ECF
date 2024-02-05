<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Test_ECF.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <link href="/Content/ContentCSS/Contact.css" rel="stylesheet" />
    <main aria-labelledby="title">
        <div class="content">
            <br />
            <h3 class="titleContact">Posez moi vos questions</h3>
            <br />
            <asp:Label ID="Nom" runat="server" Text="Nom"></asp:Label>
            <asp:TextBox ID="TxtBoxNom" CssClass="TxtBoxNom" runat="server" placeholder="Nom"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Prenom" runat="server" Text="Prenom"></asp:Label>
            <asp:TextBox ID="TxtBoxPrenom" CssClass="TxtBoxPrenom" runat="server" placeholder="Prenom"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="AdresseMail" runat="server"  Text="Adresse E-Mail"></asp:Label>
            <asp:TextBox ID="TxtBoxMail" CssClass="TxtBoxMail" runat="server" placeholder="Adresse E-Mail"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Sujet" runat="server" Text="Sujet"></asp:Label>
            <asp:TextBox ID="TxtBoxSujet" CssClass="TxtBoxSujet" runat="server" placeholder="Sujet"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Message" runat="server" Text="Message"></asp:Label>
            <asp:TextBox ID="TxtBoxArea1" CssClass="TxtBoxArea1" runat="server" placeholder="Je souhaite devenir membre..."></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnSend" CssClass="BtnSend" runat="server" Text="Envoyer" OnClick="BtnSend_Click"></asp:Button>
            <br />
        </div>
    </main>
</asp:Content>
