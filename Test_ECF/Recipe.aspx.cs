using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Test_ECF
{
    public partial class Recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    //Création des variables qui serviront à récupéré les données de la recette
                    String titre = "";
                    String urlImage = "";
                    String tmpCuisson = "";
                    String tmpPrepa = "";
                    String tmpRepos = "";
                    String descrip = "";
                    String allergenes = "";
                    String regime = "";
                    String ingredients = "";
                    String etapes = "";
                    bool estPatient = false;

                    //On récupére le titre de la recette à afficher grâce à une variable de Session
                    titre = Convert.ToString(Session["titreRecette"]);

                    //Variable pour récupéré les données de la recette
                    Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();
                    Classes.Recipes objRecipes = new Classes.Recipes();

                    //On récupére les données de la recette grâce à son titre
                    objRecipes = objDal.RecupRecipes(titre);

                    //On initialise les variables avec les enregistrement de la BDD qui concerne la recette choisi
                    urlImage = objRecipes.URLImage;
                    tmpCuisson = objRecipes.time;
                    tmpPrepa = objRecipes.timePrepa;
                    tmpRepos = objRecipes.timeRepos;
                    descrip = objRecipes.description;
                    allergenes = objRecipes.allergenes;
                    regime = objRecipes.regime;
                    ingredients = objRecipes.ingredients;
                    etapes = objRecipes.etapes;
                    estPatient = objRecipes.estPatient;

                    //On affiche toutes les informations de la recette
                    LblTitle.Text = titre;
                    IMGRecipe.ImageUrl = urlImage;
                    LblTmpCuisson.Text = tmpCuisson;
                    LblTmpPrepa.Text = tmpPrepa;
                    LblTmpRepos.Text = tmpRepos;
                    LblDescription.Text = descrip;
                    lblAllergenes.Text = allergenes;
                    LblRegime.Text = regime;

                    //On récupére la liste des ingrédients et des étapes de préparation des recettes
                    List<String> recupIngrSplit = new List<string>(ingredients.Split(','));
                    List<String> recupEtapeSplit = new List<string>(etapes.Split(','));
                    List<Int32> recupNotes = new List<Int32>();

                    recupNotes = objDal.RecupNote(titre);

                    double noteTotal = recupNotes.Average();
                    LblNote.Text = "La moyenne de cette recette est :" + " " + noteTotal.ToString();

                    foreach (var ingr in recupIngrSplit)
                    {
                        BullListIngr.Items.Add(ingr);
                    }

                    foreach (var etp in recupEtapeSplit)
                    {
                        BullListEtapes.Items.Add(etp);
                    }

                    //Si l'utilisateur n'est pas connecté, il ne peut pas mettre d'avis
                    if (!Convert.ToBoolean(Session["EstConnecte"]))
                    {
                        LblAvisDeco.Text = "Connectez-vous pour laissez un avis pour cette recette !";
                        LblAvisCo.Visible = false;
                        TxtBoxAvis.Visible = false;
                        BtnSendAvis.Visible = false;
                        CheckBoxList1.Visible = false;
                        LblNote.Visible = false;
                        PnlAvis.Visible = false;
                        LblLaissezNote.Visible = false;
                    }
                    else
                    {
                        List<String> recupNomFromRecipes = new List<String>();
                        List<String> recupPrenomFromRecipes = new List<String>();
                        List<String> recupComment = new List<String>();

                        String titreRecipes = "";

                        int i = 0;
                        int j = 0;
                        int k = 0;

                        recupNomFromRecipes = objDal.RecupNomFromRecipes(titre);
                        recupPrenomFromRecipes = objDal.RecupPrenomFromRecipes(titre);
                        titreRecipes = objDal.RecupTitreFromRecipes(titre);

                        LblAvisDeco.Visible = false;
                        LblAvisCo.Visible = true;
                        TxtBoxAvis.Visible = true;
                        BtnSendAvis.Visible = true;
                        PnlAvis.Visible = false;
                        CheckBoxList1.Visible = true;
                        LblAvisCo.Text = "Laissez moi un avis !";


                        if (titreRecipes == titre)
                        {

                            PnlAvis.Visible = true;

                            foreach (var nomCom in recupNomFromRecipes)
                            {
                                System.Web.UI.WebControls.Label LblNom = new System.Web.UI.WebControls.Label();
                                System.Web.UI.WebControls.Label LblPrenom = new System.Web.UI.WebControls.Label();
                                System.Web.UI.WebControls.Label LblComment = new System.Web.UI.WebControls.Label();


                                LblNom.Text = string.Join(", ", recupNomFromRecipes[j]);
                                LblNom.ID = "LabelNom" + (j).ToString();
                                PnlAvis.Controls.Add(LblNom);
                                j++;


                                LblPrenom.Text = string.Join(", ", recupPrenomFromRecipes[k]);
                                LblPrenom.ID = "LabelPrenom" + (k).ToString();
                                PnlAvis.Controls.Add(new LiteralControl("&nbsp;"));
                                PnlAvis.Controls.Add(LblPrenom);
                                k++;


                                recupComment = objDal.RecupComment(titre, LblNom.Text);
                                LblComment.Text = string.Join(",", recupComment.ToList());
                                LblComment.ID = "LabelCommentaire" + (i).ToString();
                                PnlAvis.Controls.Add(new LiteralControl("<br/>"));
                                PnlAvis.Controls.Add(LblComment);
                                PnlAvis.Controls.Add(new LiteralControl("<br/>"));
                                PnlAvis.Controls.Add(new LiteralControl("<br/>"));
                                i++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(e.ToString());
                    Response.Redirect("~/MesRecettes.aspx");
                }
            }
        }

        protected void BtnSendAvis_Click(object sender, EventArgs e)
        {
            //On initialise les variables qui nous serviront pour les commentaires
            Classes.DALTest_ECF objDal = new Classes.DALTest_ECF();
            String titreRecipes = "";
            String nom = "";
            String prenom = "";
            String commentaire = "";
            List<String> recupCommentFromRecipes = new List<string>();
            int i = 0;

            //On récupére les informations dont nous avons besoin (Titre de la recette, Nom, Prenom, Le commentaire)
            titreRecipes = LblTitle.Text;
            nom = Convert.ToString(Session["Nom"]);
            prenom = Convert.ToString(Session["Prenom"]);
            commentaire = TxtBoxAvis.Text;

            objDal.CreateComment(nom, prenom, commentaire, titreRecipes);

            PnlAvis.Visible = true;

            if(commentaire != "")
            {
                System.Web.UI.WebControls.Label LblNom = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.Label LblPrenom = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.Label LblComment = new System.Web.UI.WebControls.Label();
                LblNom.Text = nom;
                LblNom.ID = "LabelNom" + (i).ToString();
                LblPrenom.Text = prenom;
                LblPrenom.ID = "LabelPrenom" + (i).ToString();
                LblComment.Text = commentaire;
                LblComment.ID = "LabelCommentaire" + (i).ToString();
                PnlAvis.Controls.Add(LblNom);
                PnlAvis.Controls.Add(new LiteralControl("&nbsp;"));
                PnlAvis.Controls.Add(LblPrenom);
                PnlAvis.Controls.Add(new LiteralControl("<br/>"));
                PnlAvis.Controls.Add(LblComment);
                PnlAvis.Controls.Add(new LiteralControl("<br/>"));
                PnlAvis.Controls.Add(new LiteralControl("<br/>"));
                i++;
            }
            for(int l = 0; l < CheckBoxList1.Items.Count; l++)
            {
                if(CheckBoxList1.Items[l].Selected)
                {
                    int note = int.Parse(CheckBoxList1.Items[l].Value);
                    objDal.CreateNote(note, titreRecipes);
                }
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxList1.Items[0].Selected == true)
            {
                CheckBoxList1.Items[1].Selected = false;
                CheckBoxList1.Items[2].Selected = false;
                CheckBoxList1.Items[3].Selected = false;
                CheckBoxList1.Items[4].Selected = false;
                CheckBoxList1.Items[5].Selected = false;
                if(!Convert.ToBoolean(Session["EstConnecte"]))
                {
                    PnlAvis.Visible = false;
                }
                

            }else if(CheckBoxList1.Items[1].Selected == true)
            {
                CheckBoxList1.Items[0].Selected = false;
                CheckBoxList1.Items[2].Selected = false;
                CheckBoxList1.Items[3].Selected = false;
                CheckBoxList1.Items[4].Selected = false;
                CheckBoxList1.Items[5].Selected = false;
                if (!Convert.ToBoolean(Session["EstConnecte"]))
                {
                    PnlAvis.Visible = false;
                }
            }
            else if (CheckBoxList1.Items[2].Selected == true)
            {
                CheckBoxList1.Items[0].Selected = false;
                CheckBoxList1.Items[1].Selected = false;
                CheckBoxList1.Items[3].Selected = false;
                CheckBoxList1.Items[4].Selected = false;
                CheckBoxList1.Items[5].Selected = false;
                if (!Convert.ToBoolean(Session["EstConnecte"]))
                {
                    PnlAvis.Visible = false;
                }
            }
            else if (CheckBoxList1.Items[3].Selected == true)
            {
                CheckBoxList1.Items[0].Selected = false;
                CheckBoxList1.Items[1].Selected = false;
                CheckBoxList1.Items[2].Selected = false;
                CheckBoxList1.Items[4].Selected = false;
                CheckBoxList1.Items[5].Selected = false;
                if (!Convert.ToBoolean(Session["EstConnecte"]))
                {
                    PnlAvis.Visible = false;
                }
            }
            else if (CheckBoxList1.Items[4].Selected == true)
            {
                CheckBoxList1.Items[0].Selected = false;
                CheckBoxList1.Items[1].Selected = false;
                CheckBoxList1.Items[2].Selected = false;
                CheckBoxList1.Items[3].Selected = false;
                CheckBoxList1.Items[5].Selected = false;
                if (!Convert.ToBoolean(Session["EstConnecte"]))
                {
                    PnlAvis.Visible = false;
                }
            }
            else if (CheckBoxList1.Items[5].Selected == true)
            {
                CheckBoxList1.Items[0].Selected = false;
                CheckBoxList1.Items[1].Selected = false;
                CheckBoxList1.Items[2].Selected = false;
                CheckBoxList1.Items[3].Selected = false;
                CheckBoxList1.Items[4].Selected = false;
                if (!Convert.ToBoolean(Session["EstConnecte"]))
                {
                    PnlAvis.Visible = false;
                }
            }
        }
    }
}