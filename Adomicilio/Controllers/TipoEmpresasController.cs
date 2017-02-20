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

namespace Adomicilio
{
    public class TipoEmpresasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoEmpresas
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoEmpresa.ToListAsync());
        }

        // GET: TipoEmpresas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpresa tipoEmpresa = await db.TipoEmpresa.FindAsync(id);
            if (tipoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpresa);
        }

        // GET: TipoEmpresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TipodeLocal")] TipoEmpresa tipoEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.TipoEmpresa.Add(tipoEmpresa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoEmpresa);
        }

        // GET: TipoEmpresas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpresa tipoEmpresa = await db.TipoEmpresa.FindAsync(id);
            if (tipoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpresa);
        }

        // POST: TipoEmpresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TipodeLocal")] TipoEmpresa tipoEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEmpresa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEmpresa);
        }

        public  List<TipoEmpresa> GetTipos()
        {
            var query = db.TipoEmpresa.ToList();

            return query;
        }

        // GET: TipoEmpresas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpresa tipoEmpresa = await db.TipoEmpresa.FindAsync(id);
            if (tipoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpresa);
        }

        // POST: TipoEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoEmpresa tipoEmpresa = await db.TipoEmpresa.FindAsync(id);
            db.TipoEmpresa.Remove(tipoEmpresa);
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
    }
}
