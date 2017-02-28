using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;
using PagedList;
using System.Runtime.Remoting.Contexts;
using System.Web.UI.WebControls;

namespace Adomicilio.Controllers
{
    public class HomeController : Controller
    {
        IndexViewModel ivm = new IndexViewModel();

        public Searchlocation currentloc;
        private ApplicationDbContext db = new ApplicationDbContext();
       
      
        public ActionResult Index(IndexViewModel ivm)
        {
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

            if (ivm.iscontact)
            {
                Contacto contacto = new Contacto { Descripcion = ivm.contact.Descripcion, email = ivm.contact.email, Nombre = ivm.contact.Nombre, respondido = ivm.contact.respondido, Telefono = ivm.contact.Telefono, TipodeContacto = ivm.contact.TipodeContacto, DateCreated = DateTime.Now, nuevo = true };


                if (ModelState.IsValid)
                {
                    ivm.added = true;
                    db.Contactoes.Add(contacto);
                    db.SaveChanges();
                    ivm.contact = new Contacto();
                    ivm.contact.Nombre = "";
                    ivm.contact.email = "";
                    ivm.contact.Descripcion = "";
                    ivm.contact.Telefono = "";
                    ivm.iscontact = false;
                    return View(ivm);

                }
                ViewBag.error1 = "Favor complete la información requerida antes de enviar.";
                ViewBag.popup = 1;
                return View(ivm);
            }
            return View(ivm);
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

        public ActionResult Detail()
        {
            IndexViewModel ivm = new IndexViewModel();
            ViewBag.Message = "Detalle de Restaurant.";
            return View(ivm);
        }

    }
}