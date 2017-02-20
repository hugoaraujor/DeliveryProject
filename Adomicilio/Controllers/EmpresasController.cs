using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Adomicilio.Models;
using System.Drawing;
using PagedList;
using PagedList.Mvc;
namespace Adomicilio
{
    public class EmpresasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empresas
        public ViewResult  Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
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

            var empresas = from s in db.Empresa join tipos in db.TipoEmpresa    on s.CategoriaLocal equals tipos.Id
                           select new EmpresaCatalog { Activa = s.Activa, IdEmpresa = s.IdEmpresa, RazonSocial = s.RazonSocial, Telefonos = s.Telefonos, CategoriaLocal = s.CategoriaLocal, TipoLocal = tipos.TipodeLocal, Contacto = s.Contacto, DateCreated = s.DateCreated, Slogan = s.Slogan, RIF = s.RIF, Delivery = s.Delivery, Direccion = s.Direccion, horario1 = s.horario1, TipodeComida = s.TipodeComida };
            if (!String.IsNullOrEmpty(searchString))
            {
                empresas = empresas.Where(s => s.RazonSocial.Contains(searchString)
                                       || s.Slogan.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    empresas = empresas.OrderByDescending(s => s.RazonSocial);
                    break;
                
                default:  // Name ascending 
                    empresas = empresas.OrderBy(s => s.RazonSocial);
                    break;
            }

            int pageSize =10;
            int pageNumber = (page ?? 1);
            //return View(empresas.ToPagedList(pageNumber, pageSize));
            return View(empresas.ToPagedList(pageNumber,pageSize));
        }
        
        // GET: Empresas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa s = await db.Empresa.FindAsync(id);
            GruposMenusController gmc = new GruposMenusController();
            List<GruposMenu> gruposMenu = gmc.getgrupos(s.IdEmpresa);
            TipoEmpresa tipos = db.TipoEmpresa.Find(s.CategoriaLocal);
            EmpresaCatalog empresaCat=new EmpresaCatalog {Activa = s.Activa, IdEmpresa = s.IdEmpresa, RazonSocial = s.RazonSocial, Telefonos = s.Telefonos, CategoriaLocal = s.CategoriaLocal, TipoLocal = tipos.TipodeLocal, Contacto = s.Contacto, DateCreated = s.DateCreated, Slogan = s.Slogan, RIF = s.RIF, Delivery = s.Delivery, Direccion = s.Direccion, horario1 = s.horario1,TipodeComida=s.TipodeComida };
            empresaCat.grupomenu = gruposMenu;
            if (s == null)
            {
                return HttpNotFound();
            }

            if (s.logo != null)
            {
                MemoryStream ms = new MemoryStream(s.logo);
            Image imge=Image.FromStream(ms);
             
            String  img2= "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
            // Response.Clear();
            //  Response.ContentType = "image/png";
            //  Response.BufferOutput = true;
            //img.Save(Response.OutputStream, ImageFormat.Png);
            //   Response.Flush();
            ViewBag.foto = img2;
        }else
                ViewBag.foto = "../../images/NOPHOTO.png";

            @ViewBag.Number = s.IdEmpresa;
            return View(empresaCat);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            Empresa empresa = new Empresa();
            empresa.DateCreated = DateTime.Now;
            empresa.Activa = true;
            empresa.Valoracion = 0;
            empresa.like = 0;

            return View(empresa);
        }

        // POST: Empresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RazonSocial,RIF,Telefonos,Slogan,Valoracion,CategoriaLocal,like,Direccion,horario1,Delivery,Contacto,TipodeComida")] Empresa empresa, [Bind(Include = "file1")] HttpPostedFileBase file1)
        {
            if (file1 != null)
            {       var rutaArchivo = this.Request.Form[file1.FileName];


            Image i = Image.FromStream(file1.InputStream, true, true);
            empresa.logo = ImageUtils.ImageToByteArray(i);
        }
            empresa.Activa = true;
            empresa.DateCreated = DateTime.Now;
            empresa.Valoracion=0;
            empresa.like=0;
            
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = await db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            if (empresa.logo != null)
            {
                MemoryStream ms = new MemoryStream(empresa.logo);
                var img = Image.FromStream(ms);
                //   Response.Clear();
                //   Response.ContentType = "image/png";
                // Response.BufferOutput = true;
                // img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //  Response.Flush();
               
                String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                // Response.Clear();
                //  Response.ContentType = "image/png";
                //  Response.BufferOutput = true;
                //img.Save(Response.OutputStream, ImageFormat.Png);
                //   Response.Flush();
           
                ViewBag.foto = img2;
            }else
                ViewBag.foto = "../../images/NOPHOTO.png";

            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEmpresa,RazonSocial,RIF,Telefonos,Slogan,Valoracion,CategoriaLocal,like,Direccion,horario1,Delivery,Contacto,logo,Activa,DateCreated,TipodeComida")] Empresa empresa, [Bind(Include = "file1")] HttpPostedFileBase file1)
        {
            if (file1 != null)
            {
                var rutaArchivo = this.Request.Form[file1.FileName];


                Image i = Image.FromStream(file1.InputStream, true, true);
                empresa.logo = ImageUtils.ImageToByteArray(i);
            }
            else
            {


            }
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = await db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empresa empresa = await db.Empresa.FindAsync(id);
            db.Empresa.Remove(empresa);
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
