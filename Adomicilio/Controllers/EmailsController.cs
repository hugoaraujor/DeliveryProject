using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;
using System.Configuration;
using System.Net.Mail;

namespace Adomicilio.Controllers
{
    public class EmailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Emails
        public async Task<ActionResult> Index()
        {
            return View(await db.Emails.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,FromName,FromEmail,ToName,Subject,ToEmail,Message,Added,Descripcion")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                emails.Added = DateTime.Now;
                db.Emails.Add(emails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emails);
        }

        // GET: Emails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,FromName,FromEmail,ToName,Subject,ToEmail,Message,Added,Descripcion")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                emails.Added = DateTime.Now;
                db.Entry(emails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emails);
        }

        // GET: Emails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = await db.Emails.FindAsync(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Emails emails = await db.Emails.FindAsync(id);
            db.Emails.Remove(emails);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public string Reemplazodeetiquetas(string texto, ApplicationUser Userdata, Emails destino, string link1 = "", string link2 = "", string link3 = "")
        {
            for (int i = 0; i < 3; i++)
            {
                texto = texto.Replace("&Nombre", Userdata.Nombres);
                texto = texto.Replace("&Apellidos", Userdata.Apellidos);
                texto = texto.Replace("&Correo", Userdata.Email);
                texto = texto.Replace("&SuNombre", destino.ToName);
                texto = texto.Replace("&SuEmail", destino.ToEmail);
                texto = texto.Replace("&Link[1]", link1);
                texto = texto.Replace("&Link[2]", link2);
                texto = texto.Replace("&Link[3]", link3);
            }
            return texto;
        }
        internal void Send(Emails  message)
        {

            string Correo = ConfigurationManager.AppSettings["cuentaEmail"];
            // string Correo = Properties.Settings.Default.cuentaEmail;// GetApplicationSettings("cuentaEmail");
            string clave = ConfigurationManager.AppSettings["claveenvio"];// this.GetApplicationSettings("claveenvio");
            string servicio = ConfigurationManager.AppSettings["servicio"];// this.GetApplicationSettings("servicio");
            string puerto = ConfigurationManager.AppSettings["puerto"];// this.GetApplicationSettings("puerto");


            #region formatter
            string text = message.Message.ToString();
            // string html = HttpUtility.HtmlEncode("Please confirm your account by clicking this link: <a href=\"" + HttpUtility.HtmlEncode(@message.Body.ToString()).ToString() + "\">link</a><br/>");
            //  html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + html);
            #endregion

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.IsBodyHtml = true;
            msg.Body = message.Message;
            msg.From =new MailAddress( Correo);
            msg.To.Add(message.ToEmail);
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, System.Net.Mime.MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Message, null, System.Net.Mime.MediaTypeNames.Text.Html));

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
