using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;
using PagedList;
using PagedList.Mvc;
namespace Adomicilio.Controllers
{
    public class ContactoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacto
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Contacto> loscontactos = db.Contactoes;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            if (!String.IsNullOrEmpty(searchString))
            {
               
                loscontactos = db.Contactoes.Where(s => s.Nombre.Contains(searchString)|| s.TipodeContacto.ToString().Contains(searchString) || s.Descripcion.Contains(searchString)).OrderByDescending(x => x.DateCreated).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    loscontactos = loscontactos.OrderBy(s => s.Nombre);
                    break;

                default:  // Name ascending 
                    loscontactos = loscontactos.OrderByDescending(s => s.DateCreated);
                    break;
            }

            int pageSize = 14;
            int pageNumber = (page ?? 1);
           
           

            return View(loscontactos.ToPagedList(pageNumber, pageSize));
        }

        // GET: Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            contacto.nuevo = false;
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
         
            }
            return View(contacto);
        }

        // GET: Contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContact,Telefono,Nombre,TipodeContacto,Descripcion,email,DateCreated")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Contactoes.Add(contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacto);
        }
       
        // GET: Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

       

        // GET: Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto contacto = db.Contactoes.Find(id);
            db.Contactoes.Remove(contacto);
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
