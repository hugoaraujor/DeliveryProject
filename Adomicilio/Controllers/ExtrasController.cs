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
    public class ExtrasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Extras
        public ActionResult Index(int id,int idempresa)
        {
            ViewBag.empresa = idempresa;
            ViewBag.idproducto = id;
            return View(db.Extras.ToList());
        }

        // GET: Extras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extras extras = db.Extras.Find(id);
            if (extras == null)
            {
                return HttpNotFound();
            }
            ViewBag.idproducto = id;
            return View(extras);
        }

        // GET: Extras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdicional,IdProducto,Descripcion,Precio")] Extras extras)
        {
            if (ModelState.IsValid)
            {
                db.Extras.Add(extras);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = (int)extras.IdProducto, idempresa = ViewBag.empresa });
            }
            ViewBag.idproducto = extras.IdProducto;
            return View(extras);
        }

        // GET: Extras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extras extras = db.Extras.Find(id);
            if (extras == null)
            {
                return HttpNotFound();
            }
            ViewBag.idproducto = id;
            return View(extras);
        }

        // POST: Extras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdicional,IdProducto,Descripcion,Precio")] Extras extras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = (int)extras.IdProducto, idempresa = ViewBag.empresa });
            }
            ViewBag.idproducto = extras.IdProducto;
            return View(extras);
        }

        // GET: Extras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extras extras = db.Extras.Find(id);
            if (extras == null)
            {
                return HttpNotFound();
            }
            return View(extras);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extras extras = db.Extras.Find(id);
            db.Extras.Remove(extras);
            db.SaveChanges();
            ViewBag.idproducto = id;
            return RedirectToAction("Index", new { id = (int)extras.IdProducto, idempresa = ViewBag.empresa });
        }

        public List<Extras> GetExtras(int idproducto)
        {
            var extras = db.Extras.Where(x => x.IdProducto == idproducto).ToList();

            return extras;
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
