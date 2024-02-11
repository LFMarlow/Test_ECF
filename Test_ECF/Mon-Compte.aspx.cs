using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Test_ECF.Classes;

namespace Test_ECF
{
    public partial class Mon_Compte : System.Web.UI.Page
    {
        DALTest_ECF objDal = new DALTest_ECF();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["EstConnecte"]))
            {
                String[] test;
                int i = 0;
                LblPrenon.Text = Session["Prenom"].ToString();
                LblPrenonAdmin.Text = Session["Prenom"].ToString();

                LblNom.Text = Session["Nom"].ToString();
                LblNomAdmin.Text = Session["Nom"].ToString();

                LblMail.Text = Session["MailUtilisateur"].ToString();
                LblMailAdmin.Text = Session["MailUtilisateur"].ToString();

                LblSession.Text = Session["RoleUtilisateur"].ToString();
                LblSessionAdmin.Text = Session["RoleUtilisateur"].ToString();

                test = Session["Allergenes"].ToString().Split(',');
                foreach (var sub in test)
                {
                    CheckBoxListAllergies.Items.Add(sub.ToString());
                    CheckBoxListAllergies.Items[i].Selected = true;
                    i++;
                }

                if(Convert.ToString(Session["RoleUtilisateur"]) == "Administrateur")
                {
                    List<String> recupVisiteur = new List<string>();
                    recupVisiteur = objDal.RecupEmailVisiteur("Visiteur");

                    if (recupVisiteur != null)
                    {
                        LblVisiteur.Visible = false;
                        if (DropDownVisiteurs.Items.Count == 0)
                        {
                            DropDownVisiteurs.Items.Add("");
                            foreach (var visiteur in recupVisiteur)
                            {
                                DropDownVisiteurs.Items.Add(visiteur);
                            }
                        }
                    }
                    else
                    {
                        LblVisiteur.Visible = true;
                        DropDownVisiteurs.Visible = false;
                        LblVisiteur.Text = "Il n'y a pas de Visiteur pour le moment";
                        LblVisiteurToPatient.Visible = false;
                    } 
                }
            }
            else
            {
                Response.Redirect("/Connexion", false);
            }     
        }

        protected void BtnCreteRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateRecipes/CreateRecipeTest", false);
        }

        protected void DropDownVisiteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownVisiteurs.SelectedValue != "")
            {
                    Classes.DALTest_ECF objDal = new DALTest_ECF();
                    objDal.UpdateRoleUser(DropDownVisiteurs.SelectedValue);

                    Alert.Show(DropDownVisiteurs.SelectedValue + " " + "Est devenu 'Patient' !");
               
                RefreshDropDownList();
            }
        }

        public void RefreshDropDownList()
        {
            List<String> recupVisiteur = new List<string>();
            recupVisiteur = objDal.RecupEmailVisiteur("Visiteur");

            if (recupVisiteur != null)
            {
                LblVisiteur.Visible = false;
                if (DropDownVisiteurs.Items.Count == 0)
                {
                    DropDownVisiteurs.Items.Add("");
                    foreach (var visiteur in recupVisiteur)
                    {
                        DropDownVisiteurs.Items.Add(visiteur);
                    }
                }
            }
            else
            {
                LblVisiteur.Visible = true;
                DropDownVisiteurs.Visible = false;
                LblVisiteur.Text = "Il n'y a pas de Visiteur pour le moment";
                LblVisiteurToPatient.Visible = false;
            }
        }
    }
}