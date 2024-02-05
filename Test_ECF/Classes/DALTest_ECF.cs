using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Test_ECF.Classes
{
    public class DALTest_ECF
    {
        private string chaineTest = ConfigurationManager.ConnectionStrings["ChaineBdd"].ConnectionString;
        //private string chaineConnexion = "database=test_ecf; server=localhost; user id=Admin; pwd=65s?j72DZh%Kj[";
        MySqlConnection connexion;
        MySqlCommand command;
        MySqlDataReader reader;

        public DALTest_ECF(){
            connexion = new MySqlConnection(chaineTest);
        }

        //Method de connexion à la BDD
        private bool Connecter()
        {
            bool isConnected = false;
            try
            {
                connexion.Open();

                if(connexion.State == System.Data.ConnectionState.Open)
                {
                    isConnected = true;
                    
                }

            }catch (Exception ex)
            {
                isConnected = false;
            }

            return isConnected;
        }

        //Deconnexion de la BDD
        private void Deconnecter()
        {
            if ((reader != null) && (reader.IsClosed != true)){

                reader.Close();
            
            }
            connexion.Close();
        }

        //Inscription dans BDD
        public void Inscription(string prmNom, string prmPrenom, string prmMail, string prmPassword, string prmRoleUsers, string prmAllergenes)
        {
            string usersInscription =
            "INSERT INTO utilisateur (nom, prenom, email, password, role_users, allergenes) VALUES ('" + prmNom + "'," + "'" + prmPrenom + "'," + "'" + prmMail + "'," + "'" + prmPassword + "'," + "'" + prmRoleUsers + "'," + "'" + prmAllergenes + "'" + ")";

            bool isConnected = false;

            try
            {
                isConnected = Connecter();
                if(isConnected)
                {
                    command = new MySqlCommand(usersInscription,connexion);
                    reader = command.ExecuteReader();
                }
            }
            catch (InvalidOperationException)
            {
                isConnected = false;
            }
            Deconnecter();
        }

        //Vérification si adresse mail déjà renseigné
        public Classes.Users VerifDoublonMailInscription(string prmMail)
        {
            string verifDoublonMail = "SELECT (email) FROM utilisateur WHERE email =" + "'" + prmMail + "'";

            Classes.Users objUsers = null;
            bool isConnected = false;

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    
                    command = new MySqlCommand(verifDoublonMail, connexion);
                    reader = command.ExecuteReader();
                    reader.Read();
                    objUsers = new Classes.Users();

                    objUsers.email = Convert.ToString(reader["email"]);
                };
            }
            catch (Exception ex)
            {
                objUsers = null;
            }

            Deconnecter();
            return objUsers;
        }
        public Classes.Users AuthentificationDAL(String prmEmail, String prmPassword)
        {

            String requete = "SELECT * FROM utilisateur WHERE email = '" + prmEmail + "' AND password= '" + prmPassword + "'";
            bool isConnected = false;
            Classes.Users objUsers = null;

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                    reader.Read();
                    objUsers = new Classes.Users();

                    objUsers.nom = Convert.ToString(reader["nom"]);
                    objUsers.prenom = Convert.ToString(reader["prenom"]);
                    objUsers.email = Convert.ToString(reader["email"]);
                    objUsers.password = Convert.ToString(reader["password"]);
                    objUsers.roleUsers = Convert.ToString(reader["role_users"]);
                    objUsers.Allergenes = Convert.ToString(reader["allergenes"]);

                }
            }
            catch (Exception ex)
            {
                //Erreur de récupération
                objUsers = null;
                MessageBox.Show("Adresse Email ou Mot de passe incorrecte", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Deconnecter();
            return objUsers;

        }

        public List<String> RecupUsersNomPrenom()
        {
            String requete = "SELECT nom, prenom FROM utilisateur";
            bool isConnected = false;
            List<String> objUsers = null;

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                    reader.Read();
                    objUsers = new List<String>();

                    do
                    {
                        objUsers.Add(Convert.ToString(reader["nom"]));
                        objUsers.Add(Convert.ToString(reader["prenom"]));
                    } while (reader.Read());
                        
                }
            }catch (Exception ex)
            {
                objUsers = null;
            }

            Deconnecter();
            return objUsers;
        }

        public void CreateRecipes(string prmTitle, string prmImage, string prmTime, string prmDescription, string prmAllergenes, string prmIngredients, string prmEtapes)
        {
            String requete = "INSERT INTO recipes (titre, image, time, description, allergenes, ingredients, etapes) VALUES ('" + prmTitle.Replace("'","''") + "'," + "'" + prmImage + "'," + "'" + prmTime + "'," + "'" + prmDescription.Replace("'", "''") + "'," + "'" + prmAllergenes.Replace("'", "''") + "'," + "'" + prmIngredients.Replace("'", "''") + "'," + "'" + prmEtapes.Replace("'", "''") + "'" +  ")";
            bool isConnected = false;
            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                }
                
            }catch (InvalidOperationException)
            {
                isConnected = false;
            }
            Deconnecter();
        }

        public Classes.Recipes RecupRecipes(string prmTitle)
        {
            String requete = "SELECT titre, image, time, description, allergenes, ingredients, etapes FROM recipes WHERE titre = '" + prmTitle + "'";
            bool isConnected = false;
            Classes.Recipes objRecipes = null;

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    objRecipes = new Recipes();
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                    reader.Read();

                    objRecipes.titre = Convert.ToString(reader["titre"]);
                    objRecipes.URLImage = Convert.ToString(reader["image"]);
                    objRecipes.time = Convert.ToString(reader["time"]);
                    objRecipes.description = Convert.ToString(reader["description"]);
                    objRecipes.allergenes = Convert.ToString(reader["allergenes"]);
                    objRecipes.ingredients = Convert.ToString(reader["ingredients"]);
                    objRecipes.etapes = Convert.ToString(reader["etapes"]);
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return objRecipes;
        }

        public List<String> RecupTitleRecipes()
        {
            String requete = "SELECT titre FROM recipes";
            bool isConnected = false;
            List<String> objRecipes = new List<String>();

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                    reader.Read();

                    do
                    {

                        objRecipes.Add(Convert.ToString(reader["titre"]));

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return objRecipes;
        }

        public Classes.Recipes RecupURLRecipes(string prmTitle)
        {
            String requete = "SELECT image FROM recipes WHERE titre = '" + prmTitle + "'";
            bool isConnected = false;
            Classes.Recipes objRecipes = new Classes.Recipes();

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {

                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                    reader.Read();

                    do
                    {

                        objRecipes.URLImage = Convert.ToString(reader["image"]);

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return objRecipes;
        }
    }
}