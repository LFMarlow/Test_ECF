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
            if ((reader != null) && (reader.IsClosed != true))
            {
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
            string verifDoublonMail = "SELECT email FROM utilisateur WHERE email =" + "'" + prmMail + "'";

            Classes.Users objUsers = null;
            bool isConnected = false;

            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    
                    command = new MySqlCommand(verifDoublonMail, connexion);
                    objUsers = new Classes.Users();
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        objUsers.email = result.ToString();
                    }
                    
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
                Alert.Show("Adresse Email ou Mot de passe incorrecte");
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

        public List<String> RecupEmailVisiteur(String prmRole)
        {
            String requete = "SELECT email FROM utilisateur WHERE role_users = '" + prmRole + "'";
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

                        objUsers.Add(Convert.ToString(reader["email"]));

                    } while (reader.Read());

                }
            }
            catch (Exception ex)
            {
                objUsers = null;
            }

            Deconnecter();
            return objUsers;
        }

        public void UpdateRoleUser(string prmEmail)
        {
            String requete = "UPDATE utilisateur SET role_users = 'Patient' WHERE email = '" + prmEmail + "'";
            bool isConnected = false;
            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                }

            }
            catch (InvalidOperationException)
            {
                isConnected = false;
            }
            Deconnecter();
        }

        public void CreateRecipes(string prmTitle, string prmImage, string prmTime, string prmTimeRepos, string prmTimePrepa, string prmDescription, string prmAllergenes, string prmRegime, string prmIngredients, string prmEtapes, bool prmEstPatient)
        {
            String requete = "INSERT INTO recipes (titre, image, time, timeRepos, timePrepa, description, allergenes, regime, ingredients, etapes, estPatient) VALUES ('" + prmTitle.Replace("'","''") + "'," + "'" + prmImage + "'," + "'" + prmTime + "'," + "'" + prmTimeRepos + "'," + "'" + prmTimePrepa + "'," + "'" + prmDescription.Replace("'", "''") + "'," + "'" + prmIngredients.Replace("'", "''") + "'," + "'" + prmRegime + "'," + "'" + prmIngredients.Replace("'", "''") + "'," + "'" + prmEtapes.Replace("'", "''") + "'" + "," + "'" + prmEstPatient + "'" + ")";
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
            String requete = "SELECT titre, image, time, timeRepos, timePrepa, description, allergenes, regime, ingredients, etapes, estPatient FROM recipes WHERE titre = '" + prmTitle + "'";
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
                    objRecipes.timeRepos = Convert.ToString(reader["timeRepos"]);
                    objRecipes.timePrepa = Convert.ToString(reader["timePrepa"]);
                    objRecipes.description = Convert.ToString(reader["description"]);
                    objRecipes.allergenes = Convert.ToString(reader["allergenes"]);
                    objRecipes.regime = Convert.ToString(reader["regime"]);
                    objRecipes.ingredients = Convert.ToString(reader["ingredients"]);
                    objRecipes.etapes = Convert.ToString(reader["etapes"]);
                    objRecipes.estPatient = Convert.ToBoolean(reader["estPatient"]);
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

        public Classes.Recipes EtrePatient(string prmTitle)
        {
            String requete = "SELECT estPatient FROM recipes WHERE titre = '" + prmTitle + "'";
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

                    objRecipes.estPatient = Convert.ToBoolean(reader["estPatient"]);
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return objRecipes;
        }

        public Classes.Users RecupAllergeneUsers(string prmEmail)
        {
            String requete = "SELECT allergenes FROM utilisateur WHERE email = '" + prmEmail + "'";
            bool isConnected = false;
            Classes.Users listAllergenesUsers = new Classes.Users();

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

                        listAllergenesUsers.Allergenes = Convert.ToString(reader["allergenes"]);

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return listAllergenesUsers;
        }

        public List<String> RecupAllergeneRecipes()
        {
            String requete = "SELECT allergenes FROM recipes";
            bool isConnected = false;
            List<String> listAllergenesRecipes = new List<String>();

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

                        listAllergenesRecipes.Add(Convert.ToString(reader["allergenes"]));

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return listAllergenesRecipes;
        }

        public List<String> RecupRecipesWithAllergenesUsers(string prmAllergenes)
        {
            String requete = "SELECT titre FROM recipes WHERE allergenes NOT LIKE '" + "%" + prmAllergenes + "%" + "'";
            bool isConnected = false;
            List<String> listAllRecipes = new List<String>();

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

                        listAllRecipes.Add(Convert.ToString(reader["titre"]));

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return listAllRecipes;
        }

        public List<String> RecupRecipesWithoutAllergene()
        {
            String requete = "SELECT titre FROM recipes";
            bool isConnected = false;
            List<String> listAllRecipes = new List<String>();

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

                        listAllRecipes.Add(Convert.ToString(reader["titre"]));

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return listAllRecipes;
        }

        public void CreateComment (string prmNom, string prmPrenom, string prmCommentaire, string prmTitre)
        {
            String requete = "INSERT INTO avis (nom, prenom, commentaire, titre) VALUES ('" + prmNom + "'," + "'" + prmPrenom + "'," + "'" + prmCommentaire + "'," + "'" + prmTitre + "'" + ")";
            bool isConnected = false;
            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                }

            }
            catch (InvalidOperationException)
            {
                isConnected = false;
            }
            Deconnecter();
        }
        
        public List<String> RecupNomFromRecipes(string prmTitre)
        {
            String requete = "SELECT DISTINCT avis.nom FROM avis, recipes WHERE avis.titre = '" + prmTitre + "'";
            bool isConnected = false;
            List<String> recupNom = new List<String>();

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

                        recupNom.Add(Convert.ToString(reader["nom"]));

                    }while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return recupNom;
        }

        public List<String> RecupPrenomFromRecipes(string prmTitre)
        {
            String requete = "SELECT DISTINCT avis.prenom FROM avis, recipes WHERE avis.titre = '" + prmTitre + "'";
            bool isConnected = false;
            List<String> recupPrenom = new List<String>();

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

                        recupPrenom.Add(Convert.ToString(reader["prenom"]));

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return recupPrenom;
        }

        public String RecupTitreFromRecipes(string prmTitre)
        {
            String requete = "SELECT DISTINCT avis.titre FROM avis, recipes WHERE avis.titre = '" + prmTitre + "'";
            bool isConnected = false;
            String recupTitre = "";

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

                        recupTitre = Convert.ToString(reader["titre"]);

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return recupTitre;
        }

        public List<String> RecupComment(string prmTitre, string prmNom)
        {
            String requete = "SELECT DISTINCT avis.commentaire FROM avis, recipes WHERE avis.titre = '" + prmTitre + "'" + " AND avis.nom = '" + prmNom + "'";
            bool isConnected = false;
            List<String> recupCommentaire = new List<string>();
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

                        recupCommentaire.Add(Convert.ToString(reader["commentaire"]));

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return recupCommentaire;
        }

        public void CreateNote(int prmNote, string prmTitre)
        {
            String requete = "INSERT INTO avis (note, titre) VALUES ('" + prmNote + "', " + "'" + prmTitre + "'" + ")";
            bool isConnected = false;
            try
            {
                isConnected = Connecter();
                if (isConnected)
                {
                    command = new MySqlCommand(requete, connexion);
                    reader = command.ExecuteReader();
                }

            }
            catch (InvalidOperationException)
            {
                isConnected = false;
            }
            Deconnecter();
        }

        public List<Int32> RecupNote(string prmTitre)
        {
            String requete = "SELECT avis.note FROM avis WHERE avis.titre ='" + prmTitre + "'";
            bool isConnected = false;
            List<Int32> recupNote = new List<Int32>();
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
                        if (!reader.IsDBNull(reader.GetOrdinal("note")))
                        {
                            recupNote.Add(Convert.ToInt32(reader["note"]));
                        }
                        

                    } while (reader.Read());
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            Deconnecter();
            return recupNote;
        }
    }
}