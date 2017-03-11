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
    public class MenuIngredientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MenuIngredients
        public ActionResult Index(int id,int idempresa)
        {
            ViewBag.empresa= idempresa;
            ViewBag.idproducto = id;
            return View(db.MenuIngredients.ToList());
        }

        // GET: MenuIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuIngredients menuIngredients = db.MenuIngredients.Find(id);
            if (menuIngredients == null)
            {
                return HttpNotFound();
            }
            return View(menuIngredients);
        }

        // GET: MenuIngredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuIngredients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIngrediente,IdProducto,Descripcion,Requerido")] MenuIngredients menuIngredients)
        {
            if (ModelState.IsValid)
            {
                db.MenuIngredients.Add(menuIngredients);
                db.SaveChanges();
            
                
            }

            return RedirectToAction("Index", new { id = (int)menuIngredients.IdProducto });
        }

        // GET: MenuIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuIngredients menuIngredients = db.MenuIngredients.Find(id);
            if (menuIngredients == null)
            {
                return HttpNotFound();
            }
            return View(menuIngredients);
        }

        // POST: MenuIngredients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIngrediente,IdProducto,Descripcion,Requerido")] MenuIngredients menuIngredients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuIngredients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", new { id = (int)menuIngredients.IdProducto,idempresa = ViewBag.empresa });
        }

        // GET: MenuIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuIngredients menuIngredients = db.MenuIngredients.Find(id);
            if (menuIngredients == null)
            {
                return HttpNotFound();
            }
            return View(menuIngredients);
        }

        // POST: MenuIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuIngredients menuIngredients = db.MenuIngredients.Find(id);
            db.MenuIngredients.Remove(menuIngredients);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = (int)menuIngredients.IdProducto, idempresa = ViewBag.empresa });
        }

        public List<MenuIngredients> Getingredientes(int idproducto)
        {
            var menuIngredients = db.MenuIngredients.Where(x => x.IdProducto == idproducto).ToList();

            return menuIngredients;
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
