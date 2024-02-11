using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Test_ECF
{
    public partial class Connexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(Session["EstConnecte"]) == true)
            {
                Response.Redirect("~/", false);
            }
        }

        protected void BtnConnexion_Click(object sender, EventArgs e)
        {

            String nom = " ";  //Nom de l'utilisateur
            String prenom = " ";   //Prenom de l'utilisateur
            String mail;      //Mail de l'utilisateur
            String password;       //Password de l'utilisateur
            String roleUser = " "; //Roles de l'utilisateur (Visiteurs, Patient, Admin)
            String allergenes = " "; //Allergene de l'utilisateur

            bool isOk = false;        //True si l'authentification à réussis

            WBServiceTest_ECF objProxy = new WBServiceTest_ECF();

            //Récupération des données du formulaire
            mail = TxtBoxMailConnexion.Text;
            password = TxtBoxMDPConnexion.Text;

            if (!String.IsNullOrWhiteSpace(mail) && (!String.IsNullOrWhiteSpace(password)))
            {
                //Authentification de l'utilisateur
                isOk = objProxy.Authentification(ref mail, ref password, ref nom, ref prenom, ref roleUser, ref allergenes);

                //Si l'authentification à réussi, on enregistre les informations
                if (isOk)
                {
                    Session["EstConnecte"] = true;
                    Session["MailUtilisateur"] = mail;
                    Session["PassUtilisateur"] = password;
                    Session["Nom"] = nom;
                    Session["Prenom"] = prenom;
                    Session["RoleUtilisateur"] = roleUser;
                    Session["Allergenes"] = allergenes;
                    Response.Redirect("~/", false);
                }
                else
                {
                    Alert.Show("Informations Erronées.");
                }
            }
            else
            {
                Alert.Show("Vous devez remplir les champs obligatoirement.");
            }

        }
    }
}