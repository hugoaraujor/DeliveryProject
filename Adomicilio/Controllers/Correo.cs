using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Adomicilio.Controllers
{
    public class Correo
    {
            //Enviar Correo.
            public void sendMail(System.Net.Mail.MailMessage message)
            {
            string Correo = ConfigurationManager.AppSettings["cuentaEmail"];
            // string Correo = Properties.Settings.Default.cuentaEmail;// GetApplicationSettings("cuentaEmail");
            string clave = ConfigurationManager.AppSettings["claveenvio"];// this.GetApplicationSettings("claveenvio");
            string servicio = ConfigurationManager.AppSettings["servicio"];// this.GetApplicationSettings("servicio");
            string puerto =  ConfigurationManager.AppSettings["puerto"];// this.GetApplicationSettings("puerto");


                #region formatter
                string text = message.Body.ToString();
                // string html = HttpUtility.HtmlEncode("Please confirm your account by clicking this link: <a href=\"" + HttpUtility.HtmlEncode(@message.Body.ToString()).ToString() + "\">link</a><br/>");
                //  html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + html);
                #endregion

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.IsBodyHtml = true;
                msg.Body = message.Body;
                msg.From = message.Sender;
                msg.To.Add(message.To.ToString());
                msg.Subject = message.Subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, System.Net.Mime.MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, System.Net.Mime.MediaTypeNames.Text.Html));
              
                SmtpClient smtpClient = new SmtpClient(servicio, Convert.ToInt32(puerto));
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(Correo, clave);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 20000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            smtpClient.Send(msg);


            }
            
          
        }
    }
