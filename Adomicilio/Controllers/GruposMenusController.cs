using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;

namespace Adomicilio
{
    public class GruposMenusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
       
       
        public ActionResult Index(int? id,string mensaje="",string NombreGrupo="",int orden=0)
        {
            
            String emp=    db.Empresa.Where(x => x.IdEmpresa ==id).SingleOrDefault().RazonSocial;
            if (mensaje!="")
                ViewBag.Mensaje= "Ya hay un grupo con esa descripción.";
            else
                ViewBag.Mensaje = "";
            if (id == null)
                id = 0;
            ViewBag.Number=id;
            ViewBag.Empresa = emp;
            ViewBag.empresaid = id;
            return View(db.GruposMenu.Where(x => x.IdEmpresa == id).OrderBy(z=>z.Orden).ToList());
        }
       

        // GET: GruposMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposMenu gruposMenu = db.GruposMenu.Find(id);
            if (gruposMenu == null)
            {
                return HttpNotFound();
            }
            return View(gruposMenu);
        }

        // GET: GruposMenus/Create
        public ActionResult Create(int? idempresa)
        {
            ViewBag.empresa = idempresa;
            return View();
        }

        // POST: GruposMenus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpresa,GrupoMenuDesc")] GruposMenu gruposMenu)
        {
            var orden= db.GruposMenu.Where(x => x.IdEmpresa == gruposMenu.IdEmpresa).Count()+1;
            gruposMenu.Orden = orden;
            if (ModelState.IsValid)
            {
                db.GruposMenu.Add(gruposMenu);
                db.SaveChanges();
                RedirectToAction("Index", "GruposMenus", new { id = gruposMenu.IdEmpresa });
            }
            ViewBag.empresa = gruposMenu.IdEmpresa;
            return RedirectToAction("Index","GruposMenus", new { id= gruposMenu.IdEmpresa });
        }

        // GET: GruposMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposMenu gruposMenu = db.GruposMenu.Find(id);
            if (gruposMenu == null)
            {
                return HttpNotFound();
            }
            return View(gruposMenu);
        }

        // POST: GruposMenus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,GrupoMenuDesc,Orden")] GruposMenu gruposMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gruposMenu).State = EntityState.Modified;
                db.SaveChanges();
            }
           return  RedirectToAction("Index", "GruposMenus", new { id = gruposMenu.IdEmpresa });
        }

        // GET: GruposMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposMenu gruposMenu = db.GruposMenu.Find(id);
            if (gruposMenu == null)
            {
                return HttpNotFound();
            }
            
            return View(gruposMenu);
        }
        // GET: GruposMenus/Delete/5
        public List<GruposMenu> getgrupos(int? idempresa)
        {
            List<GruposMenu> gruposMenu = db.GruposMenu.Where(x => x.IdEmpresa == idempresa).ToList();
            

            return gruposMenu;
        }
        // POST: GruposMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GruposMenu gruposMenu = db.GruposMenu.Find(id);
            db.GruposMenu.Remove(gruposMenu);
            db.SaveChanges();
            return RedirectToAction("Index", "GruposMenus", new { id = gruposMenu.IdEmpresa });
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
