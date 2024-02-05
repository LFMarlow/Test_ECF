using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test_ECF
{
    public partial class MesRecettes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String titre;
            String img;
            String time;
            String descrip;
            String allergenes;
            String ingredient;
            String etapes;

            //Objet pour récupéré toutes les recettes
            Classes.Recipes objRecipes = new Classes.Recipes();
            Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();

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
            ImageButton1.Visible = false;
            PlaceHolder1.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/CreateRecipes/" + LblTitleRecipe.Text + ".aspx");
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
        }
    }
}