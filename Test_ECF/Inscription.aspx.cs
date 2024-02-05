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
            CheckBoxListAllergenes.Items.Add("Gluten");
            CheckBoxListAllergenes.Items.Add("Oeuf");

        }

        protected void BtnInscription_Click(object sender, EventArgs e)
        {
            string Nom = TxtBoxNom.Text;
            string Prenom = TxtBoxPrenom.Text;
            string email = TxtBoxMail.Text;
            string password = TxtBoxMDP.Text;
            string roleUsers = "Patients";
            string allergenes = " ";
            Classes.Users objUsers = new Classes.Users();

            if (Nom != "" && Prenom != "" && email != "" && password != "")
            {
                try
                {
                    objUsers = objDal.VerifDoublonMailInscription(email);
                    if (objUsers == null)
                    {
                        /*     for(int i = 0; i < CheckBoxListAllergenes.Items.Count-1; i++)
                             {
                                 if (CheckBoxListAllergenes.Items[i].Selected)
                                 {
                                     allergenes = CheckBoxListAllergenes.Items[i].Text;
                                 }
                             }*/
                        if (CheckBoxListAllergenes.Items[0].Selected && CheckBoxListAllergenes.Items[1].Selected == false)
                        {
                            allergenes = CheckBoxListAllergenes.Items[0].Text;

                        }else if (CheckBoxListAllergenes.Items[1].Selected && CheckBoxListAllergenes.Items[0].Selected == false)
                        {
                            allergenes = CheckBoxListAllergenes.Items[1].Text;

                        }else if (CheckBoxListAllergenes.Items[0].Selected && CheckBoxListAllergenes.Items[1].Selected)
                        {
                            allergenes = CheckBoxListAllergenes.Items[0].Text + "," + " " + CheckBoxListAllergenes.Items[1].Text;
                        }
                        objDal.Inscription(Nom, Prenom, email, password, roleUsers, allergenes);
                        MessageBox.Show("Inscription Réussi ! Vous pouvez dès à présent vous connecter", "Réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Response.Redirect("~/Connexion", false);
                    }
                    else
                    {
                        MessageBox.Show("Cette adresse email existe déjà", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connexion echoué");
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Tout les champs doivent être remplis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}