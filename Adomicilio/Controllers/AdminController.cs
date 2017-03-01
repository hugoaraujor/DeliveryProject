using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Adomicilio.Controllers
{
    public class AdminController : Controller
    { ApplicationDbContext db = new ApplicationDbContext();
      

        // GET: Admin
        public ActionResult Index()
        {
            Masterdashinfo md = new Masterdashinfo();
            md.NuevosContactanos = db.Contactoes.Where(x=>x.nuevo==true).Count();
            md.NroContactanos = db.Contactoes.Count();
            md.NroClientes = db.Users.Count();
            md.NroClientesNuevas = db.Users.Where(x=>x.Created==DateTime.Today).Count();
            md.NroEmpresas=db.Empresa.Count();
            md.NroEmpresas = db.Empresa.Where(x => x.DateCreated== DateTime.Today).Count();
            

            return View(md);
        }
    }
}