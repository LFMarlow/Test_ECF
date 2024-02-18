using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Test_ECF.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Test_ECF
{
    /// <summary>
    /// Description résumée de WBServiceTest_ECF
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WBServiceTest_ECF : System.Web.Services.WebService
    {
        public DALTest_ECF objDAL = new DALTest_ECF();  


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description ="Vérifie dans la base de données, l'adresse e-mail renseigné et le mot de passe")]
        public bool Authentification(ref string prmMail, ref string prmPassword, ref string prmNom, ref string prmPrenom, ref string prmRole, ref string prmAllergenes)
        {
            Classes.Users loginUsers;
            bool isOkay = false;

            loginUsers = new Classes.Users();
            loginUsers = objDAL.AuthentificationDAL(prmMail, prmPassword);
            try
            {
                if (loginUsers != null)
                {
                    prmMail = loginUsers.email;
                    prmPassword = loginUsers.password;
                    prmNom = loginUsers.nom;
                    prmPrenom = loginUsers.prenom;
                    prmRole = loginUsers.roleUsers;
                    prmAllergenes = loginUsers.Allergenes;

                    if (loginUsers.email == prmMail)
                    {
                        if (loginUsers.password == prmPassword)
                        {
                            isOkay = true;
                        }
                    }
                    else
                    {
                        isOkay = false;
                    }
                }
                else
                {
                    
                }
            }catch(System.NullReferenceException)
            {

            }
            return isOkay;

        }
    }
}
