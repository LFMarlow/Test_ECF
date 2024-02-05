using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Test_ECF.CreateRecipes
{
    public partial class JustCodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["OnlyVisiblePatient"]) == true)
            {
                if (Convert.ToString(Session["RoleUtilisateur"]) == "Patients" || Convert.ToString(Session["RoleUtilisateur"]) == "Administrateur")
                {

                }
                else
                {
                    MessageBox.Show("Vous devez être enregistré comme Patients pour visualiser cette Recette");
                    Response.Redirect("~/", false);
                }
            }
            else
            {

            }
        }
    }
}