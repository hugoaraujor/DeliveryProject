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
    public class HorariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Horarios
        public ActionResult Index(int id)
        {
            ViewBag.Number = id;
               HorariosViewModel horarios = new HorariosViewModel();
            horarios.loshorarios = db.Horarios.Where(x=>x.IdEmpresa==id).OrderBy(x=>x.dia).ToList();
            Horarios elhorario = new Horarios();
            horarios.dia = elhorario.dia;
            horarios.Id = 0;
            horarios.IdEmpresa = id;
            horarios.StartHour = elhorario.StartHour;
            horarios.EndtHour = elhorario.EndtHour;
            return View(horarios);
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpresa,dia,StartHour,EndtHour")] Horarios horarios)
        {    if (db.Horarios.Any(x=>x.IdEmpresa==horarios.IdEmpresa && x.dia==horarios.dia))
              {       ModelState.AddModelError("", "Día ingresado previamente.");
                }
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horarios);
                db.SaveChanges();
               
            }

            return RedirectToAction("Index", new { id = horarios.IdEmpresa });
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // POST: Horarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,dia,StartHour,EndtHour")] Horarios horarios)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(horarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horarios);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horarios horarios = db.Horarios.Find(id);
            db.Horarios.Remove(horarios);
            db.SaveChanges();
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
    }
}
