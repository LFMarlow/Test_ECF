using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_ECF.Classes
{
    public class Users
    {
        public String nom;
        public String prenom;
        public String email;
        public String password;
        public String roleUsers;
        public String Allergenes;

        public Users()
        {

        }

        public Users(string prmMail, string prmPassword)
        {
            email = prmMail;
            password = prmPassword;
        }

        public Users(string prmNom, string prmPrenom, string prmEmail, string prmPassword, string prmRoles, string prmAllergenes)
        {
            nom = prmNom;
            prenom = prmPrenom;
            email = prmEmail;
            password = prmPassword;
            roleUsers = prmRoles;
            Allergenes = prmAllergenes;
        }
    }
}