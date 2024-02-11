using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Test_ECF
{
    public partial class MesRecettes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Variable pour recupéré les allergenes des utilisateurs et recettes
            String allergeneUser = "";

            //Variable pour récupéré l'email pour recupéré les allergenes de l'utilisateur connecté
            String emailUsers = "";

            //Objet pour récupéré toutes les recettes
            Classes.Recipes objRecipes = new Classes.Recipes();
            Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();
            Classes.Users objUsers = new Classes.Users();

            if (Convert.ToBoolean(Session["EstConnecte"]))
            {
                //On récupéré l'email de l'utilisateur pour récupéré les allergenes de ce même users
                emailUsers = Convert.ToString(Session["MailUtilisateur"]);
                objUsers = objDal.RecupAllergeneUsers(emailUsers);
                allergeneUser = objUsers.Allergenes;

                //On récupére la liste des allergenes de l'utilisateur et on Split
                List<String> listAllergenesUsers = new List<string>(allergeneUser.Split(','));
                listAllergenesUsers.RemoveAll(s => s == "");

                //On récupére les allergenes de chaque recette
                List<String> listAllergenesRecipes = new List<string>();
                listAllergenesRecipes = objDal.RecupAllergeneRecipes();
                listAllergenesRecipes.RemoveAll(s => s == "");

                var listComparateur = listAllergenesRecipes.Intersect(listAllergenesUsers);
                string recupResultComparateur;
                recupResultComparateur = string.Join(", ", listComparateur);

                List<String> allTitleRecipes = new List<string>();
                if (!recupResultComparateur.Contains(""))
                {
                    allTitleRecipes = objDal.RecupRecipesWithAllergenesUsers(recupResultComparateur);
                }
                else
                {
                    allTitleRecipes = objDal.RecupRecipesWithoutAllergene();
                }

                if (DropDownList1.Items.Count == 0)
                {
                    DropDownList1.Items.Add("");
                    for (int i = 0; i < allTitleRecipes.Count; i++)
                    {
                        DropDownList1.Items.Add(allTitleRecipes[i].ToString());
                    }
                }
            }

            if (!Convert.ToBoolean(Session["EstConnecte"]))
            {
                //Si le DropDownList est vide, on le rempli avec les recettes contenue dans la BDD (Cela évite d'avoir plusieurs entrée de la même recette)
                if (DropDownList1.Items.Count == 0)
                {
                    //On récupére toutes les informations de chaque recette
                    List<String> recupTitleRecipe = new List<string>();
                    recupTitleRecipe = objDal.RecupTitleRecipes();

                    DropDownList1.Items.Add("");
                    for (int i = 0; i < recupTitleRecipe.Count; i++)
                    {
                        DropDownList1.Items.Add(recupTitleRecipe[i].ToString());
                    }
                }
                LblAvis.Text = "Connecter vous pour donner votre avis sur les recettes !";
            }
            ImageButton1.Visible = false;
            PlaceHolder1.Visible = false;
            LblAllergenes.Visible = false;
            LblVosAllergenes.Visible = false;

            //On récupére les allergenes de l'utilisateur
            if(Convert.ToBoolean(Session["EstConnecte"]) == true)
            {
                emailUsers = Convert.ToString(Session["MailUtilisateur"]);
                objUsers = objDal.RecupAllergeneUsers(emailUsers);
                LblAllergenes.Text = objUsers.Allergenes;
                LblAllergenes.Visible = true;
                LblVosAllergenes.Visible = true;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["titreRecette"] = LblTitleRecipe.Text;

            Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();
            Classes.Recipes objRecipes = new Classes.Recipes();

            objRecipes = objDal.EtrePatient(LblTitleRecipe.Text);
            if (objRecipes.estPatient == true)
            {
                if (Convert.ToString(Session["RoleUtilisateur"]) == "Patient" || (Convert.ToString(Session["RoleUtilisateur"]) == "Administrateur"))
                {
                    
                    Response.Redirect("~/Recipe.aspx");
                }
                else
                {
                    Alert.Show("Vous devez être Patient pour visualiser cette recette.");
                    
                    Response.Redirect("~/MesRecettes.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Recipe.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classes.Recipes objRecipes = new Classes.Recipes();
            Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();
            objRecipes = objDal.RecupURLRecipes(DropDownList1.SelectedItem.Text);

            //On affiche les recettes
            LblTitleRecipe.Text = DropDownList1.SelectedItem.Text;
            ImageButton1.ImageUrl = objRecipes.URLImage;
            PlaceHolder1.Controls.Add(ImageButton1);
            ImageButton1.Visible = true;
            PlaceHolder1.Visible = true;
            if(LblTitleRecipe.Text == "")
            {
                ImageButton1.Visible = false;
            }
        }
    }
}