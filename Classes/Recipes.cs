using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Test_ECF.Classes
{
    public class Recipes
    {
        public String titre;
        public String URLImage;
        public String time;
        public String timeRepos;
        public String timePrepa;
        public String description;
        public String allergenes;
        public String regime;
        public String ingredients;
        public String etapes;
        public bool estPatient;

        public Recipes()
        {

        }

        public Recipes(string prmTitre, string prmURL, string prmTime, string prmTimeRepos, string prmTimePrepa ,string prmDescription, string prmAllergenes, string prmRegime, string prmIngredients, string prmEtapes, bool prmEstPatient)
        {
            titre = prmTitre;
            URLImage = prmURL;
            time = prmTime;
            timeRepos = prmTimeRepos;
            timePrepa = prmTimePrepa;
            description = prmDescription;
            allergenes = prmAllergenes;
            regime = prmRegime;
            ingredients = prmIngredients;
            etapes = prmEtapes;
            estPatient = prmEstPatient;
        }
    }
}