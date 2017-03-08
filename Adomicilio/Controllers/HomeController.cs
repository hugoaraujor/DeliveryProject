using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;
using PagedList;
using System.Runtime.Remoting.Contexts;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Adomicilio.Controllers
{
   public class HomeController : Controller
    {
       
        int n = 0;
        IndexViewModel ivm = new IndexViewModel();

        public Searchlocation currentloc;
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(IndexViewModel ivm)
        { 
            var username = User.Identity.GetUserName();
            var userid = User.Identity.GetUserId();
            ivm.userid = userid;
            ivm.username = username;
            ivm.loggedin = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (ivm.page == 0)
                ivm.page = 1;
            
            int? page = ivm.page;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ivm.ListaEspecialidades = db.Especialidad.OrderBy(x => x.EspecialidadDesc).ToList();
            if (ivm.menuopcion==0)
            ivm.restaurante = db.Empresa.Where(r => r.Activa == true&r.idCiudad==ivm.ciudad).OrderBy(r => r.RazonSocial).ToPagedList(pageNumber, pageSize);
            else
                ivm.restaurante = db.Empresa.Where(r => r.Activa == true && r.idCiudad == ivm.ciudad&r.TipodeComida==ivm.menuopcion).OrderBy(r => r.RazonSocial).ToPagedList(pageNumber, pageSize);

           
            return View(ivm);
        }
        [HttpGet]
        public ActionResult Contacto()
        {
        
            return View("Contacto",null);
        }
        [HttpPost]
        public ActionResult Contacto(Contacto contact )
        {
            var AUX = HttpContext.Session["DataInserted"].ToString();


                if (ModelState.IsValid&& HttpContext.Session["DataInserted"].ToString()!="1")
                {
                    contact.nuevo = true;
                    db.Contactoes.Add(contact);
                    db.SaveChanges();
                    //  ModelState.Clear();
                    ViewBag.msj = "Fue agregada su Solicitud. Puede Cerrar esta ventana.";
                //   return new EmptyPartialViewResult();
                HttpContext.Session["DataInserted"] = "1";
                return this.Content("Su solicitud fue enviada con éxito");
                }
            if (ModelState.IsValid && HttpContext.Session["DataInserted"].ToString() == "1")
                return this.Content("Su solicitud fue enviada con éxito");
            else
                return PartialView(contact); 
        }
        public PartialViewResult Resultados(IndexViewModel ivm)
        {


            if (ivm.page == 0)
                ivm.page = 1;

            

            int? page = ivm.page;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ivm.ListaEspecialidades = db.Especialidad.OrderBy(x => x.EspecialidadDesc).ToList();

            ivm.restaurante = db.Empresa.Where(r => r.Activa == true).OrderBy(r => r.RazonSocial).ToPagedList(pageNumber, pageSize);
            return PartialView("StoresView", ivm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Detail(IndexViewModel ivm,int id,int idg=0)
        {
            
            ViewBag.Message = "Detalle de Restaurant.";
            GruposMenusController GmC = new GruposMenusController();
            Adomicilio.Models.Menu MC = new Adomicilio.Models.Menu();
            
            ivm.CurrentEmpresa = new ApplicationDbContext().Empresa.Where(x => x.IdEmpresa == id).SingleOrDefault();
            ivm.opcionesmenu = GmC.getgrupos(ivm.CurrentEmpresa.IdEmpresa);
            ivm.primergrupo = ivm.opcionesmenu.First().Id;
            ivm.PLatos = new MenusController().GetMenus(idg);
            if (idg==0)
                @ViewBag.Grupo = GmC.getgrupostr(ivm.primergrupo);
            else
                @ViewBag.Grupo = GmC.getgrupostr(idg);
            return View(ivm);
        }

    }
}