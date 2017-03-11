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
using PagedList;
using PagedList.Mvc;
using System.Drawing;
using System.IO;

namespace Adomicilio.Controllers
{
    public class MenusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Menus
        public List<Menu> GetMenus(int idempresa )
        {
          
             var menu = db.Menu.Where(x => x.IdEmpresa == idempresa);
             return menu.ToList();
        }

        // GET: Menus
        public ViewResult Index(int idempresa,string sortOrder, string currentFilter, string searchString, int? page)
        {
            @ViewBag.Number = idempresa;
             ViewBag.Empresa = db.Empresa.Where(x => x.IdEmpresa == idempresa).Single().RazonSocial;
            var menu=db.Menu.Where(x => x.IdEmpresa == idempresa);

            //-----------------
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
                menu = menu.Where(s => s.Nombre.Contains(searchString)
                                       || s.Descripcion.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    menu = menu.OrderByDescending(s => s.Nombre);
                    break;

                default:  // Name ascending 
                    menu = menu.OrderBy(s => s.Nombre);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(empresas.ToPagedList(pageNumber, pageSize));
            return View(menu.ToPagedList(pageNumber, pageSize));
            //return View(await menu.ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.empresa = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = await db.Menu.FindAsync(id);
            
            if (menu.imagen != null)
            {
                MemoryStream ms = new MemoryStream(menu.imagen);
            //    var img = Image.FromStream(ms);
          //     img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                  String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                 ViewBag.foto = img2;
            }
            else
                ViewBag.foto = "../../images/NOPHOTO.png";

            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create(int idempresa)
        {
            
            ViewBag.Empresa = db.Empresa.Where(x=>x.IdEmpresa==idempresa).Single().RazonSocial;
     
            Menu model = new Menu();
            model.IdEmpresa = idempresa;
            return View(model);
        }

        // POST: Menus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdProducto,IdEmpresa,IdGrupoMenu,IdCategory,IdSubCategorias,Nombre,Descripcion,Titulo,clase1,clase2,clase3,Precio1,Precio2,Precio3,imagenname,nuevo,Oferta,imagen,Activa,DateCreated")] Menu menu, [Bind(Include = "file1")] HttpPostedFileBase file1)
        {
            menu.DateCreated = DateTime.Now;
            if (file1 != null)
            {
                var rutaArchivo = this.Request.Form[file1.FileName];
                Image i = Image.FromStream(file1.InputStream, true, true);
                menu.imagen = ImageUtils.ImageToByteArray(i);
            }
            if (ModelState.IsValid)
            {
                db.Menu.Add(menu);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", new { idempresa = (int)menu.IdEmpresa });
            }

         
            return RedirectToAction("Index", new { idempresa =(int) menu.IdEmpresa });
        }

        // GET: Menus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu= await db.Menu.FindAsync(id);
           

            if (menu.imagen != null)
            {
                
                MemoryStream ms = new MemoryStream(menu.imagen);
                //var img = Image.FromStream(ms);
                //try
                //{
                //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                 String img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
          
                ViewBag.foto = img2;
             }
            else
                ViewBag.foto = "../../images/NOPHOTO.png";

            
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = menu.IdEmpresa;
            
            return View(menu);
        }

        // POST: Menus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdProducto,IdEmpresa,IdGrupoMenu,IdCategory,IdSubCategorias,Nombre,Descripcion,Titulo,clase1,clase2,clase3,Precio1,Precio2,Precio3,imagenname,nuevo,Oferta,imagen,Activa,DateCreated")] Menu menu, [Bind(Include = "file1")] HttpPostedFileBase file1)
        {
            if (file1 != null)
            {
                var rutaArchivo = this.Request.Form[file1.FileName];


                Image i = Image.FromStream(file1.InputStream, true, true);
                menu.imagen = ImageUtils.ImageToByteArray(i);
            }
            else
            {


            }
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                 return RedirectToAction("Index", new { idempresa = (int)menu.IdEmpresa });
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", menu.IdEmpresa);
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = await db.Menu.FindAsync(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Menu menu = await db.Menu.FindAsync(id);
            db.Menu.Remove(menu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { idempresa = (int)menu.IdEmpresa });
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
