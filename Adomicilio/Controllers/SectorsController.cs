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
    public class SectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sectors
        public ActionResult Index()
        {
            return View(db.Sectores.ToList());
        }
       
        // GET: Sectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectores.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // GET: Sectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombresector,CiudadId")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Sectores.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sector);
        }

        // GET: Sectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectores.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombresector,CiudadId")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectores.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sector sector = db.Sectores.Find(id);
            db.Sectores.Remove(sector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      

        //public  List<Sector> GetSectorsList(int idciudad)
        //{var sectores = db.Sectores.Where(x => x.CiudadId == idciudad).ToList();
        //    return sectores;
        //}
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
      
        public List<Sector> GetSectoresList(int id)
        {
            Adomicilio.Models.ApplicationDbContext adb = new ApplicationDbContext();
            List<Sector> _sectores = new List<Sector>();_sectores.Add(new Sector { Nombresector="Todos", CiudadId=id });
            _sectores = adb.Sectores.Where(x => x.CiudadId == id).ToList();
             return _sectores;
        }
    }
}
