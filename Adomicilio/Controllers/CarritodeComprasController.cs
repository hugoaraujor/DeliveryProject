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
using Microsoft.AspNet.Identity;

namespace Adomicilio
{
    public class CarritodeComprasController : Controller
    {
        [System.Web.Mvc.HttpGet]
        public JsonResult GetCartData(string sessionid, int userid)
        {
            var suma=db.CarritodeCompras.Where(z => z.sessionid == sessionid).Sum(z => z.Precio);
            var cuenta = db.CarritodeCompras.Where(z => z.sessionid == sessionid).Count();
            
            return Json(new {numarticulos=cuenta,montoart=suma}, JsonRequestBehavior.AllowGet);
        }
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarritodeCompras
        public async Task<ActionResult> Index()
        {
            
            return View(await db.CarritodeCompras.ToListAsync());
        }

        // GET: CarritodeCompras
        public async Task<ActionResult> VerCarrito(string sessionid,int xuserid)
        {
            var query = (from a in db.CarritodeCompras
                         join m in db.Menu on a.IdProducto equals m.IdProducto
                         join e in db.Empresa on m.IdEmpresa equals e.IdEmpresa
                         where a.sessionid == sessionid  select new CarritodeComprasViewModel
            {


         id = a.id,
        sessionid =a.sessionid,
        clase =a.clase,
        IdProducto =a.IdProducto,
        UserId =a.UserId,
        Cant =a.Cant,
        Precio =a.Precio,
        Mensaje =a.Mensaje,
        ingredientes =a.ingredientes,
        Extra =a.Extra,
        Fecha =a.Fecha,
        IdEmpresa =m.IdEmpresa,
        RazonSocial =e.RazonSocial,
        RIF =e.RIF,
        Nombre =m.Nombre,
        Descripcion =m.Descripcion,
        imagen=m.imagen
        

    });
            return View(await query.ToListAsync());
        }

        // GET: CarritodeCompras/Details/5
        public async Task<ActionResult> Details(int? id)
        {
             ViewBag.userid = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritodeCompras carritodeCompras = await db.CarritodeCompras.FindAsync(id);
            if (carritodeCompras == null)
            {
                return HttpNotFound();
            }
            return View(carritodeCompras);
        }

        // GET: CarritodeCompras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritodeCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(CarritodeCompras carritodeCompras)
        {
            
            //public async Task<ActionResult> Create([Bind(Include = "id,sessionid,IdProducto,UserId,Cant,Precio,Mensaje,ingredientes,Extra")] CarritodeCompras carritodeCompras)
            if (ModelState.IsValid)
            {
                db.CarritodeCompras.Add(carritodeCompras);
               db.SaveChanges();
                return Json(new { Response = "Success" });
            }
           
            return Json(new { Response = "Error" });
           
        }

        // GET: CarritodeCompras/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritodeCompras carritodeCompras = await db.CarritodeCompras.FindAsync(id);
            if (carritodeCompras == null)
            {
                return HttpNotFound();
            }
            return View(carritodeCompras);
        }
        [HttpPost]
        // POST: CarritodeCompras/Editcant/5
        public  ActionResult Editcant(int? id,int n,decimal precio)
        {
            if (id == null)
            {
                return Json(new { Response = "Error" });
            }
            CarritodeCompras carritodeCompras =  db.CarritodeCompras.Find(id);
            if (carritodeCompras == null)
            {

                return Json(new { Response = "Error" });
            }
            else
            {
                carritodeCompras.Cant = n;
                carritodeCompras.Precio = precio;
                db.Entry(carritodeCompras).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Response = "Success" });
            }
           
        }
        // POST: CarritodeCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,OrdenNro,sessionid,IdProducto,UserId,Cant,Precio,Mensaje,ingredientes,Extra")] CarritodeCompras carritodeCompras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carritodeCompras).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(carritodeCompras);
        }

        // GET: CarritodeCompras/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritodeCompras carritodeCompras = await db.CarritodeCompras.FindAsync(id);
            if (carritodeCompras == null)
            {
                return HttpNotFound();
            }
            return View(carritodeCompras);
        }

        // POST: CarritodeCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CarritodeCompras carritodeCompras = await db.CarritodeCompras.FindAsync(id);
            db.CarritodeCompras.Remove(carritodeCompras);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // POST: CarritodeCompras/Delete/5
        [HttpPost]
        public async Task<ActionResult> Deletecart(int id)
        {
            CarritodeCompras carritodeCompras = await db.CarritodeCompras.FindAsync(id);
            db.CarritodeCompras.Remove(carritodeCompras);
            await db.SaveChangesAsync();
            return Json(new { Response = "Success" });
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
