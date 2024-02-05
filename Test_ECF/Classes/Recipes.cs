using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_ECF.Classes
{
    public class Recipes
    {
        public String titre;
        public String URLImage;
        public String time;
        public String description;
        public String allergenes;
        public String ingredients;
        public String etapes;

        public Recipes()
        {

        }

        public Recipes(string prmTitre, string prmURL, string prmTime, string prmDescription, string prmAllergenes, string prmIngredients, string prmEtapes)
        {
            titre = prmTitre;
            URLImage = prmURL;
            time = prmTime;
            description = prmDescription;
            allergenes = prmAllergenes;
            ingredients = prmIngredients;
            etapes = prmEtapes;

        }
    }
}