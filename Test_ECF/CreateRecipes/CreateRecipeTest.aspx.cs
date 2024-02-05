using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Test_ECF
{
    public partial class CreateRecipeTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnCreateRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                //Variable pour inséré données dans BDD
                string titleInit = TxtTitle.Text;
                string urlInit = TxtURLImage.Text;
                string timeInit = TxtTime.Text;
                string ingredientsInit = TxtIngredients.Text;
                string etapesInit = TxtEtapes.Text;
                string descripInit = TxtDescription.Text;
                string allergenesInit = TxtAllergenes.Text;

                //On insère dans la BDD les informations
                Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();
                objDal.CreateRecipes(titleInit, urlInit, timeInit, descripInit, allergenesInit, ingredientsInit, etapesInit);

                //Variable pour récupéré les données dans BDD
                String title = "";
                String urlIMG = "";
                String timeRecipe = "";
                String description = "";
                String allergene = "";
                String ingredient = "";
                String etape = "";

                //Variable pour récupéré les données de la recette
                Classes.Recipes objRecipes = new Classes.Recipes();

                //On rentre les données de la BDD dans les variables pour créer la nouvelle page
                objRecipes = objDal.RecupRecipes(titleInit);
                title = objRecipes.titre;
                urlIMG = objRecipes.URLImage;
                timeRecipe = objRecipes.time;
                description = objRecipes.description;
                allergene = objRecipes.allergenes;
                ingredient = objRecipes.ingredients;
                etape = objRecipes.etapes;

                List<String> recupIngrSplit = new List<string>(ingredient.Split(','));
                List<String> recupEtapeSplit = new List<string>(etape.Split(','));

                //Variable à insérer pour créer nouvelle page Recipe
                string str1 = @"<%@ Page Language=""C#"" MasterPageFile=""~/Site.Master"" AutoEventWireup=""true"" CodeBehind=""JustCodeBehind.aspx.cs"" Inherits=""Test_ECF.CreateRecipes.JustCodeBehind"" %>";
                string str2 = @"<asp:Content ID=""Content1"" ContentPlaceHolderID=""MainContent"" runat=""server"">";

                string linkCSS = @"<link href=""../Content/ContentCSS/Recipes.css"" rel=""stylesheet"" /><link href=""https://fonts.googleapis.com/css2?family=Sniglet"" rel =""stylesheet""/>";

                string div_title = @"<div class=""content_wrapper""><div class=""photo_wrapper""><div class=""img_wrapper"">";
                string img_recipe = @"<img class=""img_recipes1"" src=" + urlIMG + "></img>";

                string finIMG = @"</div>";
                string article = @"<article class=""info_container_article""><h1 class=""title_container"">" + title + "</h1>";
                
                string time = @"<section class=""info_wrapper""><div class=""recipe_quick_info""><img src= ""../Content/ContentIMG/tmp_cuisson.png"" alt=""Temps de cuisson"" class='img_cuisson'/><p class='time'>" + timeRecipe.ToString() + "</p></div></section>";
                string descriptBegin = @"<br /><section class='recipe_info'><div class='main_wrapper'><h3 style = 'font-size: 1em'>Description</h3><p></p><div>" + description + "</div>";
                
                string allergenesRecipes = @"<br /><div><div class='info_allergenes'><h3 style = 'font-size: 1em'>Allergenes :</h3><p>" + allergene + "</p></div><br /></div>";
                string endUpPage = @" </section></article></div>";
                
                string wrapper = @"<section class='info-wrapper'><br /><div class='ingredient_recipe'>";
                string ingredientPage = @"<h3>Ingredients</h3><br /><br />";

                string etapePage = @"<div class=""info_container""><h3>Etapes</h3><br /><br />";
                string strEnd = @"</div></section></div></asp:Content>";

                //Variable pour Créer la nouvelle page
                string pagestringDebut = str1.ToString() + str2.ToString() + linkCSS ;
                string midPage = div_title + img_recipe + finIMG + article + time + descriptBegin + allergenesRecipes + endUpPage + wrapper + ingredientPage;
                string etapePagev = etapePage;
                string pagestringFin = strEnd.ToString();
                string fileLoc = Server.MapPath(title + ".aspx");

                //Création de la nouvelle page
                FileStream fs = null;
                if (!File.Exists(fileLoc))
                {
                    using (fs = new FileStream(fileLoc, FileMode.Create))
                    {
                        if (File.Exists(fileLoc))
                        {
                            fs.Flush();
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                            {
                                AddText(sw, pagestringDebut.ToString());
                                AddText(sw, midPage.ToString());
                                AddText(sw, "<ul>");
                                foreach (var ingr in recupIngrSplit)
                                {                                 
                                    AddText(sw, "<li>");
                                    AddText(sw, ingr);
                                    AddText(sw, "</li>");                               
                                }
                                AddText(sw, "</ul>");
                                AddText(sw, etapePagev.ToString());
                                AddText(sw, "<ul>");
                                foreach (var etp in recupEtapeSplit)
                                {
                                    AddText(sw, "<li>");
                                    AddText(sw, etp);
                                    AddText(sw, "</li>");
                                }
                                AddText(sw, "</ul>");
                                AddText(sw, pagestringFin.ToString());
                                sw.Close();
                            }
                        }
                    }   
                }

                if(CheckBoxVisibleClient.Checked == true)
                {
                    Session["OnlyVisiblePatient"] = true;
                }

                Response.Redirect(title + ".aspx", false);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AddText(StreamWriter sw, string text)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            sw.BaseStream.Seek(0, SeekOrigin.Current);
            sw.WriteLine(text, 0, text.Length, utf8);
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}