using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
namespace Test_ECF
{
    public partial class CreateRecipes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreateRecipe_Click(object sender, EventArgs e)
        {
            int i = 0;
            int numTxtBox = 0;
            String urlIMG = TxtBoxImg.Text;
            int timeRecipe = 0;
            String title = "";
            String description = "";
            String allergene = "";
            String ingredient = "";
            String etape = "";

            title = TxtBoxTitle.Text;
            description = TxtBoxDescription.Text;
            allergene = TxtBoxAllergene.Text;
            ingredient = TxtBoxIngredient.Text;
            etape = TxtBoxEtape.Text;

     /*       for (i = 0; i < Convert.ToInt32(TxtBoxIngredient.Text); i++) 
            {
                
                TxtBox.ID = "TxtBoxIngredients" + numTxtBox;
                TxtBox.Text = "OUI";
                TxtBox.Width = 100;
                TxtBox.Height = 100;
                TxtBox.Visible = true;
                numTxtBox = numTxtBox + 1;
            }

            */






            string str1 = @"<%@ Page Language=""C#"" MasterPageFile=""~/Site.Master"" AutoEventWireup=""true"" %><script runat=""server""></script>";
            string str2 = @"<asp:Content ID=""Content1"" ContentPlaceHolderID=""MainContent"" runat=""server"">";
            string linkCSS = @"<link href=""/Content/ContentCSS/Recipes.css"" rel=""stylesheet"" /><link href = ""https://fonts.googleapis.com/css2?family=Sniglet"" rel = ""stylesheet""/>";
            string div_title = @"<div class=""content_wrapper""><div class=""photo_wrapper""><div class=""img_wrapper"">";
            string img_recipe = @"<img class=""img_recipes1"" src=" + urlIMG + "></img>";
            string finIMG = "</div>";
            string article = @"<article class=""info_container_article""><h1 class=""title_container"">" + title + "</h1>";
            string time = @"<section class=""info_wrapper""><div class=""recipe_quick_info""><img src= ""Content/ContentIMG/tmp_cuisson.png"" alt=""Temps de cuisson"" class=""img_cuisson""/><p class=""time"">" + timeRecipe.ToString() + "</p></div></section>";
            string descriptBegin = @"<br /><section class=""recipe_info""><div class=""main_wrapper""><h3 style = ""font-size: 1em"">Description</h3><p></p><div>" + description + "</div>";
            string allergenesRecipes = @"<br /><div><div class=""info_allergenes""><h3> Allergenes :</h3><p>" + allergene + "</p></div><br /></div>";
            string endUpPage = @" </section></article></div>";
            string wrapper = @"<section class=""info-wrapper""><br /><div class=""ingredient_recipe"">";
            string ingredientPage = @"<h3>Ingredients</h3><br /><br /><li>" + ingredient + "</li></div><br/>";
            string etapePage = @"<div class=""info_container""><h3>Etapes</h3><br /><br /><li>" + etape + "</li>";
            string strEnd = @"</div></section></div></asp:Content>";

            string pagestring = str1.ToString() + str2.ToString() + linkCSS + div_title + img_recipe + finIMG + article + time + descriptBegin + allergenesRecipes + endUpPage + wrapper + ingredientPage + etapePage + strEnd.ToString();
            string fileLoc = Server.MapPath(title + ".aspx");

            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
                if (File.Exists(fileLoc))
                {
                    using (StreamWriter sw = new StreamWriter(fileLoc))
                    {
                        sw.Write(pagestring.ToString());
                    }
                }
            }
            Response.Redirect(title + ".aspx");
        }

        protected void TxtBoxTitle_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Oui");
        }
    }
}