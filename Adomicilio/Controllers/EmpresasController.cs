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
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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

            var empresas = from s in db.Empresa join tipos in db.TipoEmpresa on s.CategoriaLocal equals tipos.Id
                           select new EmpresaCatalog {
                               IdEmpresa = s.IdEmpresa,
                               RazonSocial = s.RazonSocial,
                               RIF = s.RIF,
                               Telefonos = s.Telefonos,
                               Slogan = s.Slogan,
                               CategoriaLocal = s.CategoriaLocal,
                               TipodeComida = tipos.Id,
                               like = s.like,
                               Direccion = s.Direccion,
                               horario1 = s.horario1,
                               Delivery = s.Delivery,
                               Contacto = s.Contacto,
                               logo = s.logo,
                               Activa = s.Activa,
                               DateEdited = s.DateEdited,
                               tipodelivery = s.tipodelivery,
                               idCiudad = s.idCiudad,
                               idEstado = s.idEstado,
                               Sectores = s.Sectores,
                               imagenurl = s.imagenurl,
                               User = s.User,
                               claveuser = s.claveuser,
                               ip = s.ip,
                               tipodecomidastr = tipos.TipodeLocal,
                               DateCreated = s.DateCreated
                           };

        
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

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            //return View(empresas.ToPagedList(pageNumber, pageSize));
            return View(empresas.ToPagedList(pageNumber, pageSize));
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
            EmpresaCatalog empresaCat = new EmpresaCatalog {  IdEmpresa = s.IdEmpresa,
                                                          RazonSocial = s.RazonSocial,
                                                          RIF = s.RIF,
                                                          Telefonos = s.Telefonos,
                                                          Slogan = s.Slogan,
                 CategoriaLocal = s.CategoriaLocal,
                TipodeComida = s.TipodeComida,
                tipodecomidastr=tipos.TipodeLocal,
                like =s.like,Direccion=s.Direccion,
                horario1 = s.horario1,
                Delivery =s.Delivery,
                Contacto =s.Contacto,
                logo =s.logo,
                Activa =s.Activa,
                DateEdited =s.DateEdited,
                tipodelivery = s.tipodelivery,
                idCiudad =s.idCiudad,
                idEstado = s.idEstado,
                Sectores =s.Sectores,
                imagenurl =s.imagenurl,
                User =s.User,
                claveuser =s.claveuser,
                ip =s.ip,
            DateCreated=s.DateCreated
            };

            empresaCat.grupomenu = gruposMenu;
            if (s == null)
            {
                return HttpNotFound();
            }

            if (s.logo != null)
            {
                MemoryStream ms = new MemoryStream(s.logo);
               // Image imge = Image.FromStream(ms);

                String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                // Response.Clear();
                //  Response.ContentType = "image/png";
                //  Response.BufferOutput = true;
                //img.Save(Response.OutputStream, ImageFormat.Png);
                //   Response.Flush();
                ViewBag.foto = img2;
            } else
                ViewBag.foto = "../../images/NOPHOTO.png";

            @ViewBag.Number = s.IdEmpresa;
            return View(empresaCat);
        }
       
        public async Task<int> Likes(int? id,bool add)
        {
            Empresa s = null;
            if (id != null)
            {
                 s = await db.Empresa.FindAsync(id);
            }
            
            if (s != null )
            {
                if (add)
                    s.like++;
                else
                    s.like--;

                    db.Entry(s).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                                  
            }

            return s.like;
        }
        public async Task<int> Votar(int? id,int valor)
        {
            Empresa s = null;
            if (id != null)
            {
                s = await db.Empresa.FindAsync(id);
            }

            if (s != null)
            { if (s.Valoracion==0 )
                    s.Valoracion =  valor;
            else
                s.Valoracion= ((int)Math.Floor((decimal)(s.Valoracion+valor)/2));
             
                db.Entry(s).State = EntityState.Modified;
                await db.SaveChangesAsync();

            }

            return s.Valoracion;
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
        public async Task<ActionResult> Create([Bind(Include = "IdEmpresa,RazonSocial,RIF ,Telefonos, Slogan, CategoriaLocal,TipodeComida,like,Direccion,horario1,Delivery,Contacto,logo, Activa,DateCreated, DateEdited ,tipodelivery ,idCiudad ,idEstado,Sectores , imagenurl,User ,claveuser, ip ")] Empresa empresa, [Bind(Include = "file1")] HttpPostedFileBase file1)
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
                return  HttpNotFound();
            }
            if (empresa.logo != null)
            {
                
                MemoryStream ms = new MemoryStream(empresa.logo);
                //ms.Seek(0, SeekOrigin.Begin);
                //var img = Image.FromStream(ms);
                //ms.Seek(0, SeekOrigin.Begin);
                //ms.WriteTo(salida);
                //   Response.Clear();
                //   Response.ContentType = "image/png";
                // Response.BufferOutput = true;
                // img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
               // img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //  Response.Flush();
               
                //String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
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
        public async Task<ActionResult> Edit([Bind(Include = "IdEmpresa,RazonSocial,RIF ,Telefonos, Slogan, CategoriaLocal,TipodeComida,like,Direccion,horario1,Delivery,Contacto,logo, Activa,DateCreated, DateEdited ,tipodelivery ,idCiudad ,idEstado,Sectores , imagenurl,User ,claveuser, ip ")] Empresa empresa, [Bind(Include = "file1")] HttpPostedFileBase file1)
        {

            if (empresa.Valoracion == null)
                empresa.Valoracion = 0;
            if (empresa.like == null)
                empresa.like=0;
            if (empresa.Delivery == null)
                empresa.Delivery = 0;
            if (empresa.Activa == null)
                empresa.Activa=true;
            if (empresa.claveuser == null)
                empresa.claveuser = "";
            if (empresa.tipodelivery == null)
                empresa.tipodelivery = 0;
            if (empresa.User == null)
                empresa.User = "";
            if (empresa.ip == null)
                empresa.ip= "";
            if (empresa.ip == null)
                empresa.ip = "";


            if (file1 != null)
            {
                var rutaArchivo = this.Request.Form[file1.FileName];


                Image i = Image.FromStream(file1.InputStream, true, true);
                empresa.logo = ImageUtils.ImageToByteArray(i);
            }
            else
            {


            }
            if (empresa.logo != null)
            {

                MemoryStream ms = new MemoryStream(empresa.logo);
                //ms.Seek(0, SeekOrigin.Begin);
                //var img = Image.FromStream(ms);
                //ms.Seek(0, SeekOrigin.Begin);
                //ms.WriteTo(salida);
                //   Response.Clear();
                //   Response.ContentType = "image/png";
                // Response.BufferOutput = true;
                // img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                // img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //  Response.Flush();

                //String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                // Response.Clear();
                //  Response.ContentType = "image/png";
                //  Response.BufferOutput = true;
                //img.Save(Response.OutputStream, ImageFormat.Png);
                //   Response.Flush();

                ViewBag.foto = img2;
            }
            else
                ViewBag.foto = "../../images/NOPHOTO.png";

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
