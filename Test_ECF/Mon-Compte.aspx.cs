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
    }
}