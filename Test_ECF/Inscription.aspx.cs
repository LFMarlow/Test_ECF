using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Test_ECF.Classes;

namespace Test_ECF
{
    public partial class Inscription : System.Web.UI.Page
    {
        DALTest_ECF objDal = new DALTest_ECF();

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void BtnInscription_Click(object sender, EventArgs e)
        {
            String Nom = TxtBoxNom.Text;
            String Prenom = TxtBoxPrenom.Text;
            String email = TxtBoxMail.Text;
            String password = TxtBoxMDP.Text;
            String roleUsers = "Visiteur";
            String allergenes = TxtBoxAllergenes.Text;

            Classes.Users objUsers = new Classes.Users();

            if (Nom != "" && Prenom != "" && email != "" && password != "")
            {
                try
                {
                    objUsers = objDal.VerifDoublonMailInscription(email);
                    if (objUsers.email == null)
                    {
                        objDal.Inscription(Nom, Prenom, email, password, roleUsers, allergenes);
                        Alert.Show("Inscription Réussi ! Vous pouvez dès à présent vous connecter");
                        
                        Response.Redirect("~/Connexion", false);
                    }
                    else
                    {
                        Alert.Show("Cette adresse email existe déjà");
                    }
                }
                catch (Exception ex)
                {
                    Alert.Show("Connexion echoué");
                }
            }
            else
            {
                Alert.Show("Tout les champs doivent être remplis");
            }
        }
    }
}