using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;

namespace Adomicilio.Controllers
{
    public class DireccionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Direcciones
        public ActionResult Index()
        {
            return View(db.Direccion.ToList());
        }
        
        
        // GET: Direcciones
        public ActionResult Manage(int id)
        {

            Direccion nuevadireccion= new Direccion();
            nuevadireccion.IdUser = id;
            return View(db.Direccion.Where(x=>x.IdUser==id).ToList());
        }

        // POST: Direcciones
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(Direccion addr)
        {if (ModelState.IsValid)
            {
                if (addr.IdDireccion == 0)
                {
                    DireccionesController dc = new DireccionesController();
                    dc.Add(addr);
                    var id = addr.IdUser;
                    ModelState.Clear();
                    return RedirectToAction("Manage", new { id = addr.IdUser });
                }
            }
            return RedirectToAction("Manage", addr.IdUser);
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDireccion,IdUser,Calle,CasaNro,Urbanizacion,referencia,Alias")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(direccion);
        }
       
        public bool Add( Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDireccion,IdUser,Calle,CasaNro,Urbanizacion,referencia,Alias")] Direccion direccion)
        {
            Uri myReferrer = Request.UrlReferrer;
            string actual = myReferrer.ToString();
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage",new { id=direccion.IdUser});
            }
            return RedirectToAction("Manage", new { id = direccion.IdUser });
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            Uri myReferrer = Request.UrlReferrer;
            string actual = myReferrer.ToString();
            Console.WriteLine(myReferrer);
            Console.WriteLine(actual);
            var varuid = 0;
             if (Session["LoggedIn"] !=null)
            {
                Direccion direccion = db.Direccion.Find(id);

                if (direccion.Alias != "Domicilio"&&direccion!=null)
                {
                   varuid = direccion.IdUser;
                    db.Direccion.Remove(direccion); 
                db.SaveChanges();
                }

            }
            return Redirect(actual);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
