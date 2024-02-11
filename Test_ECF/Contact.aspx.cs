using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Test_ECF
{
    public partial class Contact : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string expediteur;
                string destinataire;
                string sujet;
                string message;
                string nom;
                string prenom;

                expediteur = TxtBoxMail.Text;
                destinataire = "thomas59.lesage@gmail.com";
                sujet = TxtBoxSujet.Text;
                nom = TxtBoxNom.Text;
                prenom = TxtBoxPrenom.Text;
                message = TxtBoxArea1.Text;

                MailMessage Mail = new MailMessage(expediteur, destinataire, sujet, message);
                SmtpClient monSmtpClient = new SmtpClient("smtp.gmail.com", 587);

                monSmtpClient.EnableSsl = true;

                monSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                monSmtpClient.Credentials = new System.Net.NetworkCredential("thomas59.lesage@gmail.com", "ungx otdh nqwi elhb");

                monSmtpClient.Send(Mail);

                Alert.Show("Votre e-mail à bien été envoyé !");

            }
            catch
            {
                Alert.Show("Erreur lors de l'envoi de l'e-mail");
            }
        }
    }
}