<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mon-Compte.aspx.cs" Inherits="Test_ECF.Mon_Compte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ContentCSS/Compte.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Sniglet" rel="stylesheet" />
    <%if (Convert.ToString(Session["RoleUtilisateur"]) != "Administrateur")
        {%>
            <div class="main_content">
                <h1 class="title_content">Informations de votre Compte</h1>
                <br />
                <div class="nav_tab">
                    <h2 class="title_content">Vos Informations de Connexion</h2>
                    <br />
                    <div class="div_content_prenoms">
                        <h5 class="Prenom">Prénom : &nbsp</h5>
                        <asp:Label ID="LblPrenon" CssClass="LblPrenom" runat="server" Text="Prenom"></asp:Label>
                    </div>
                    <div class="div_content_nom">
                        <h5 class="Nom">Nom : &nbsp</h5>
                        <asp:Label ID="LblNom" CssClass="LblNom" runat="server" Text="Nom"></asp:Label>
                    </div>
                    <div class="div_content_mail">
                        <h5 class="Mail">Adresse E-mail utilisé : &nbsp</h5>
                        <asp:Label ID="LblMail" CssClass="LblMail" runat="server" Text="Adresse E-Mail"></asp:Label>
                    </div>
                    <div class="div_content_session">
                        <h5 class="Session">Session Actuelle : &nbsp</h5>
                        <asp:Label ID="LblSession" CssClass="LblSession" runat="server" Text="Sessions Actuelle"></asp:Label>
                    </div>
                <br />
                <br />
                <h2 class="title_content">Allergenes :</h2>
                <p class="info_allergenes">
                    Sur les recettes proposées, il est possible de retrouver des allergènes.
                    Veuillez choisir vos allergènes, ainsi, les recettes en contenant n'apparaitront plus.
                </p>
                <div class="div_content_allergenes">
                    <asp:CheckBoxList ID="CheckBoxListAllergies" runat="server"></asp:CheckBoxList>
                </div>
                </div>
            </div>
            <%}else
              { %>
                  <div class="main_content">
                      <h1 class="title_content">Informations de votre Compte</h1>
                      <br />
                      <div class="nav_tab">
                          <h2 class="title_content">Vos Informations de Connexion</h2>
                          <br />
                          <div class="div_content_prenoms">
                              <h5 class="Prenom">Prénom : &nbsp</h5>
                              <asp:Label ID="LblPrenonAdmin" CssClass="LblPrenom" runat="server" Text=""></asp:Label>
                          </div>
                          <div class="div_content_nom">
                              <h5 class="Nom">Nom : &nbsp</h5>
                              <asp:Label ID="LblNomAdmin" CssClass="LblNom" runat="server" Text=""></asp:Label>
                          </div>
                          <div class="div_content_mail">
                              <h5 class="Mail">Adresse E-mail utilisé : &nbsp</h5>
                              <asp:Label ID="LblMailAdmin" CssClass="LblMail" runat="server" Text=""></asp:Label>
                          </div>
                          <div class="div_content_session">
                              <h5 class="Session">Session Actuelle : &nbsp</h5>
                              <asp:Label ID="LblSessionAdmin" CssClass="LblSession" runat="server" Text=""></asp:Label>
                          </div>
                          <br />
                          <br />
                          <div class="div_visiteur">
                              <h2 class="title_content">Voici la liste des "Visiteur" : &nbsp;</h2>
                              <br />
                              <asp:Label ID="LblVisiteur" CssClass="LblVisiteur" runat="server" Text=""></asp:Label>
                          </div>
                          <div class="div_content_visiteur">
                              <asp:Label ID="LblVisiteurToPatient" runat="server" Text="Veuillez sélectionner le 'Visiteur' à changer en 'Patient' :"></asp:Label>
                              &nbsp;
                              <asp:DropDownList ID="DropDownVisiteurs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownVisiteurs_SelectedIndexChanged"></asp:DropDownList>
                          </div>
                          <br />
                          <br />
                          <asp:Button ID="BtnCreteRecipes" runat="server" CssClass="Btn_Create" Text="Créer une nouvelle recette" OnClick="BtnCreteRecipes_Click" />
                      </div>
            <%}%>
                  </div>
</asp:Content>
